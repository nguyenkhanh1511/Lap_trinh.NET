using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class frmStudent : Form
    {
        // ── Dữ liệu ──────────────────────────────────────────────────────────
        protected BindingList<Student> _danhSach = new BindingList<Student>();
        protected BindingSource _bs = new BindingSource();

        public frmStudent()
        {
            InitializeComponent();
        }

        // =====================================================================
        // LOAD
        // =====================================================================
        private void frmStudent_Load(object sender, EventArgs e)
        {
            KhoiTaoCbo();
            KhoiTaoDGV();
            KhoiTaoBinding();
            NapDuLieuMau();
        }

        private void KhoiTaoCbo()
        {
            cboGender.Items.Clear();
            cboGender.Items.AddRange(new[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;
        }

        // ── Cấu hình DataGridView hoàn toàn bằng code ────────────────────────
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
                new DataGridViewTextBoxColumn { DataPropertyName = "StudentId",  HeaderText = "Mã SV",    Width = 80  },
                new DataGridViewTextBoxColumn { DataPropertyName = "FullName",   HeaderText = "Họ tên",   Width = 200 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Age",        HeaderText = "Tuổi",     Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { DataPropertyName = "Gender",     HeaderText = "Giới tính",Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { DataPropertyName = "AvatarPath", HeaderText = "Ảnh đại diện", Width = 200 }
            );

            // ContextMenuStrip cho DGV
            KhoiTaoContextMenu();
        }

        private void KhoiTaoContextMenu()
        {
            var ctx = new ContextMenuStrip();
            var mnuXoa     = new ToolStripMenuItem("🗑️ Xóa dòng",       null, (s, e) => XoaSinhVien());
            var mnuLamMoi  = new ToolStripMenuItem("🔄 Làm mới dữ liệu", null, (s, e) => LamMoiForm());
            var mnuChiTiet = new ToolStripMenuItem("🔍 Xem chi tiết",    null, (s, e) => XemChiTiet());
            ctx.Items.AddRange(new ToolStripItem[] { mnuXoa, new ToolStripSeparator(), mnuLamMoi, mnuChiTiet });
            dgvStudents.ContextMenuStrip = ctx;
        }

        // ── Data Binding 2 chiều qua DataBindings.Add ────────────────────────
        protected virtual void KhoiTaoBinding()
        {
            _bs.DataSource = _danhSach;
            dgvStudents.DataSource = _bs;

            // Bind 2 chiều: Control ↔ BindingSource ↔ BindingList<Student>
            txtStudentId.DataBindings.Add("Text", _bs, "StudentId",   true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName .DataBindings.Add("Text", _bs, "FullName",    true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge      .DataBindings.Add("Text", _bs, "Age",         true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender   .DataBindings.Add("Text", _bs, "Gender",      true, DataSourceUpdateMode.OnPropertyChanged);

            // Khi BindingSource dịch chuyển (chọn dòng khác) → cập nhật ảnh
            _bs.PositionChanged += Bs_PositionChanged;
            _bs.CurrentChanged  += Bs_PositionChanged;
        }

        private void Bs_PositionChanged(object? sender, EventArgs e)
        {
            HienThiAnhHienTai();
        }

        private void HienThiAnhHienTai()
        {
            if (_bs.Current is not Student sv) { picAvatar.Image = null; return; }
            if (!string.IsNullOrEmpty(sv.AvatarPath) && File.Exists(sv.AvatarPath))
            {
                try   { picAvatar.Image = Image.FromFile(sv.AvatarPath); }
                catch { picAvatar.Image = null; }
            }
            else picAvatar.Image = null;
        }

        private void NapDuLieuMau()
        {
            _danhSach.Add(new Student("SV0001", "Nguyễn Văn An",   20, "Nam", ""));
            _danhSach.Add(new Student("SV0002", "Trần Thị Bình",   21, "Nữ",  ""));
            _danhSach.Add(new Student("SV0003", "Lê Hoàng Minh",   19, "Nam", ""));
            _danhSach.Add(new Student("SV0004", "Phạm Ngọc Linh",  22, "Nữ",  ""));
            Student.ResetCounter(5);
        }

        // =====================================================================
        // NÚT THÊM
        // =====================================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Xác nhận dữ liệu hiện tại trước khi thêm mới
            if (!KiemTraHopLe()) return;

            var svMoi = new Student();
            _danhSach.Add(svMoi);
            _bs.MoveLast();

            // Xóa ảnh cho bản ghi mới
            picAvatar.Image = null;
            txtFullName.Focus();
            ThongBaoLenFormCha($"✅ Đã thêm sinh viên {svMoi.StudentId}");
        }

        // =====================================================================
        // NÚT CẬP NHẬT
        // =====================================================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            // Với DataBindings 2 chiều, dữ liệu đã tự đồng bộ vào object
            // Chỉ cần EndEdit để xác nhận
            _bs.EndEdit();
            _bs.ResetCurrentItem();
            ThongBaoLenFormCha($"✅ Đã cập nhật: {(_bs.Current as Student)?.FullName}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================================
        // NÚT XÓA
        // =====================================================================
        private void btnDelete_Click(object sender, EventArgs e) => XoaSinhVien();

        protected void XoaSinhVien()
        {
            if (_bs.Current is not Student sv) return;
            if (MessageBox.Show($"Xóa sinh viên \"{sv.FullName}\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _danhSach.Remove(sv);
            HienThiAnhHienTai();
            ThongBaoLenFormCha($"🗑️ Đã xóa: {sv.FullName}");
        }

        private void LamMoiForm()
        {
            errorProvider.Clear();
            HienThiAnhHienTai();
            ThongBaoLenFormCha("🔄 Đã làm mới");
        }

        private void XemChiTiet()
        {
            if (_bs.Current is not Student sv) return;
            MessageBox.Show(
                $"Mã SV   : {sv.StudentId}\n" +
                $"Họ tên  : {sv.FullName}\n" +
                $"Tuổi    : {sv.Age}\n" +
                $"Giới tính: {sv.Gender}\n" +
                $"Ảnh     : {(string.IsNullOrEmpty(sv.AvatarPath) ? "(chưa có)" : sv.AvatarPath)}",
                "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================================
        // CHỌN ẢNH AVATAR
        // =====================================================================
        private void btnChoAnh_Click(object sender, EventArgs e)
        {
            if (_bs.Current is not Student sv) return;
            using var dlg = new OpenFileDialog
            {
                Title  = "Chọn ảnh đại diện",
                Filter = "Tệp ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            sv.AvatarPath = dlg.FileName;
            _bs.ResetCurrentItem();
            HienThiAnhHienTai();
        }

        // =====================================================================
        // XUẤT CSV
        // =====================================================================
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Title       = "Xuất danh sách sinh viên",
                Filter      = "CSV file (*.csv)|*.csv",
                FileName    = $"SinhVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt  = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var w = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
                w.WriteLine("StudentId,FullName,Age,Gender,AvatarPath");
                foreach (var sv in _danhSach) w.WriteLine(sv.ToCsvLine());
                ThongBaoLenFormCha($"📤 Đã xuất CSV: {Path.GetFileName(dlg.FileName)}");
                MessageBox.Show($"Xuất CSV thành công!\n{dlg.FileName}", "Xuất CSV",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // VALIDATION
        // =====================================================================
        private bool KiemTraHopLe()
        {
            bool ok = true;
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            { errorProvider.SetError(txtFullName, "Họ tên không được để trống!"); ok = false; }
            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 100)
            { errorProvider.SetError(txtAge, "Tuổi phải là số từ 1 đến 100!"); ok = false; }
            return ok;
        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
                errorProvider.SetError(txtFullName, "Họ tên không được để trống!");
            else errorProvider.SetError(txtFullName, "");
        }
        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtAge.Text, out int a) || a < 1 || a > 100)
                errorProvider.SetError(txtAge, "Tuổi phải là số từ 1–100!");
            else errorProvider.SetError(txtAge, "");
        }

        // =====================================================================
        // GIAO TIẾP VỚI FORM CHA MDI (override ở bài 4.7/4.8)
        // =====================================================================
        protected virtual void ThongBaoLenFormCha(string msg) { /* override ở bài 4.7+ */ }
    }
}
