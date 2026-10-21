using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolMDIAsync
{
    public partial class frmStudent : Form
    {
        protected BindingList<Student> _danhSach = new BindingList<Student>();
        protected BindingSource _bs = new BindingSource();

        private frmMain? FormCha => MdiParent as frmMain;

        public frmStudent() { InitializeComponent(); }

        // =====================================================================
        // LOAD — gọi nạp dữ liệu bất đồng bộ
        // =====================================================================
        private async void frmStudent_Load(object sender, EventArgs e)
        {
            KhoiTaoCbo();
            KhoiTaoDGV();
            KhoiTaoBinding();
            await NapDuLieuAsync();
        }

        private void KhoiTaoCbo()
        {
            cboGender.Items.Clear();
            cboGender.Items.AddRange(new[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;
        }

        private void KhoiTaoDGV()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.MultiSelect = false;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.Font = new Font("Segoe UI", 9f);
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvStudents.EnableHeadersVisualStyles = false;

            dgvStudents.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "StudentId", HeaderText = "Mã SV",     Width = 80  },
                new DataGridViewTextBoxColumn { DataPropertyName = "FullName",  HeaderText = "Họ tên",    Width = 200 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Age",       HeaderText = "Tuổi",      Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { DataPropertyName = "Gender",    HeaderText = "Giới tính", Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { DataPropertyName = "AvatarPath",HeaderText = "Ảnh",       Width = 180 }
            );

            var ctx = new ContextMenuStrip();
            ctx.Items.Add("🗑️ Xóa dòng",       null, (s, e) => XoaSinhVien());
            ctx.Items.Add(new ToolStripSeparator());
            ctx.Items.Add("🔄 Làm mới dữ liệu", null, async (s, e) => await NapDuLieuAsync());
            ctx.Items.Add("🔍 Xem chi tiết",    null, (s, e) => XemChiTiet());
            dgvStudents.ContextMenuStrip = ctx;
        }

        private void KhoiTaoBinding()
        {
            _bs.DataSource = _danhSach;
            dgvStudents.DataSource = _bs;
            txtStudentId.DataBindings.Add("Text", _bs, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName .DataBindings.Add("Text", _bs, "FullName",  true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge      .DataBindings.Add("Text", _bs, "Age",       true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender   .DataBindings.Add("Text", _bs, "Gender",    true, DataSourceUpdateMode.OnPropertyChanged);
            _bs.PositionChanged += (s, e) => HienThiAnh();
            _bs.CurrentChanged  += (s, e) => HienThiAnh();
        }

        private void HienThiAnh()
        {
            if (_bs.Current is not Student sv) { picAvatar.Image = null; return; }
            if (!string.IsNullOrEmpty(sv.AvatarPath) && File.Exists(sv.AvatarPath))
                try { picAvatar.Image = Image.FromFile(sv.AvatarPath); } catch { picAvatar.Image = null; }
            else picAvatar.Image = null;
        }

        // =====================================================================
        // NẠP DỮ LIỆU BẤT ĐỒNG BỘ (ASYNC / AWAIT + IProgress<int>)
        // =====================================================================
        private async Task NapDuLieuAsync()
        {
            // Khoá nút để tránh kích hoạt trùng lặp
            btnLoadAsync.Enabled = false;
            progressLoad.Value   = 0;
            progressLoad.Visible = true;
            lblPhanTram.Text     = "0%";
            lblPhanTram.Visible  = true;

            FormCha?.BatDauTienTrinh("⏳ Đang nạp danh sách sinh viên...");

            // IProgress<int> tự marshal callback về UI Thread — thread-safe
            var progress = new Progress<int>(pct =>
            {
                progressLoad.Value = pct;
                lblPhanTram.Text   = $"{pct}%";
                FormCha?.CapNhatTienTrinh(pct, $"Đang nạp... {pct}%");
            });

            List<Student>? ketQua = null;
            string? loi = null;

            try
            {
                // Task.Run đẩy tính toán nặng xuống Thread phụ
                // UI Thread KHÔNG bị block — người dùng vẫn tương tác được
                ketQua = await Task.Run(async () =>
                {
                    var list = new List<Student>();
                    var danhSachMau = new[]
                    {
                        new Student("SV0001","Nguyễn Văn An",   20,"Nam",""),
                        new Student("SV0002","Trần Thị Bình",   21,"Nữ", ""),
                        new Student("SV0003","Lê Hoàng Minh",   19,"Nam",""),
                        new Student("SV0004","Phạm Ngọc Linh",  22,"Nữ", ""),
                        new Student("SV0005","Hoàng Đức Thắng", 20,"Nam",""),
                        new Student("SV0006","Vũ Thị Mai",      21,"Nữ", ""),
                        new Student("SV0007","Đặng Văn Hùng",   22,"Nam",""),
                        new Student("SV0008","Bùi Thị Lan",     19,"Nữ", ""),
                        new Student("SV0009","Ngô Minh Tuấn",   23,"Nam",""),
                        new Student("SV0010","Đinh Thị Hoa",    20,"Nữ", ""),
                    };

                    for (int i = 0; i < danhSachMau.Length; i++)
                    {
                        await Task.Delay(300); // Giả lập đọc từ DB/file (300ms/bản ghi)
                        list.Add(danhSachMau[i]);

                        int phanTram = (i + 1) * 100 / danhSachMau.Length;
                        ((IProgress<int>)progress).Report(phanTram);
                    }
                    return list;
                });
            }
            catch (Exception ex)
            {
                loi = ex.Message;
            }
            finally
            {
                // finally luôn chạy trên UI Thread sau await
                btnLoadAsync.Enabled = true;
                await Task.Delay(600); // Giữ 100% thấy được
                progressLoad.Visible = false;
                lblPhanTram.Visible  = false;

                if (loi != null)
                {
                    FormCha?.KetThucTienTrinh($"❌ Lỗi: {loi}");
                    MessageBox.Show($"Lỗi nạp dữ liệu: {loi}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _danhSach.Clear();
                    if (ketQua != null) foreach (var sv in ketQua) _danhSach.Add(sv);
                    Student.ResetCounter(_danhSach.Count + 1);
                    FormCha?.KetThucTienTrinh($"✅ Đã nạp {_danhSach.Count} sinh viên");
                }
            }
        }

        // ── Nút nạp lại async ────────────────────────────────────────────────
        private async void btnLoadAsync_Click(object sender, EventArgs e)
            => await NapDuLieuAsync();

        // =====================================================================
        // CRUD (giống Bài 4.7)
        // =====================================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            var sv = new Student(); _danhSach.Add(sv); _bs.MoveLast();
            picAvatar.Image = null; txtFullName.Focus();
            GuiThongBao($"✅ Đã thêm {sv.StudentId}");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            _bs.EndEdit(); _bs.ResetCurrentItem();
            GuiThongBao($"✅ Cập nhật: {(_bs.Current as Student)?.FullName}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDelete_Click(object sender, EventArgs e) => XoaSinhVien();

        private void XoaSinhVien()
        {
            if (_bs.Current is not Student sv) return;
            if (MessageBox.Show($"Xóa \"{sv.FullName}\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _danhSach.Remove(sv); HienThiAnh(); GuiThongBao($"🗑️ Đã xóa: {sv.FullName}");
        }
        private void XemChiTiet()
        {
            if (_bs.Current is not Student sv) return;
            MessageBox.Show($"Mã SV: {sv.StudentId}\nHọ tên: {sv.FullName}\nTuổi: {sv.Age}\nGiới tính: {sv.Gender}",
                "Chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnChoAnh_Click(object sender, EventArgs e)
        {
            if (_bs.Current is not Student sv) return;
            using var dlg = new OpenFileDialog { Filter = "Tệp ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            sv.AvatarPath = dlg.FileName; _bs.ResetCurrentItem(); HienThiAnh();
        }
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog { Filter = "CSV file (*.csv)|*.csv", FileName = $"SinhVien_{DateTime.Now:yyyyMMdd}.csv" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var w = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
                w.WriteLine("StudentId,FullName,Age,Gender,AvatarPath");
                foreach (var sv in _danhSach) w.WriteLine(sv.ToCsvLine());
                GuiThongBao($"📤 Xuất CSV: {Path.GetFileName(dlg.FileName)}");
                MessageBox.Show("Xuất CSV thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool KiemTraHopLe()
        {
            bool ok = true; errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            { errorProvider.SetError(txtFullName, "Họ tên không được để trống!"); ok = false; }
            if (!int.TryParse(txtAge.Text, out int a) || a < 1 || a > 100)
            { errorProvider.SetError(txtAge, "Tuổi phải từ 1–100!"); ok = false; }
            return ok;
        }
        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text)) errorProvider.SetError(txtFullName, "Không được để trống!");
            else errorProvider.SetError(txtFullName, "");
        }
        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtAge.Text, out int a) || a < 1 || a > 100) errorProvider.SetError(txtAge, "Tuổi 1–100!");
            else errorProvider.SetError(txtAge, "");
        }

        protected virtual void GuiThongBao(string msg) => FormCha?.CapNhatTrangThai(msg);
    }
}
