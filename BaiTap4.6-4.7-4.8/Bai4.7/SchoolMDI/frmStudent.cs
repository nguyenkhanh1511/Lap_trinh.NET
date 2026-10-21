using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SchoolMDI
{
    public partial class frmStudent : Form
    {
        protected BindingList<Student> _danhSach = new BindingList<Student>();
        protected BindingSource _bs = new BindingSource();

        // Trỏ về Form cha để gọi CapNhatTrangThai
        private frmMain? FormCha => MdiParent as frmMain;

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

            // ContextMenuStrip
            var ctx = new ContextMenuStrip();
            ctx.Items.Add("🗑️ Xóa dòng",       null, (s, e) => XoaSinhVien());
            ctx.Items.Add(new ToolStripSeparator());
            ctx.Items.Add("🔄 Làm mới dữ liệu", null, (s, e) => { errorProvider.Clear(); HienThiAnh(); });
            ctx.Items.Add("🔍 Xem chi tiết",    null, (s, e) => XemChiTiet());
            dgvStudents.ContextMenuStrip = ctx;
        }

        private void KhoiTaoBinding()
        {
            _bs.DataSource = _danhSach;
            dgvStudents.DataSource = _bs;

            // DataBindings 2 chiều: thay đổi ở Control → đồng bộ vào object
            txtStudentId.DataBindings.Add("Text", _bs, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName .DataBindings.Add("Text", _bs, "FullName",  true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge      .DataBindings.Add("Text", _bs, "Age",       true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender   .DataBindings.Add("Text", _bs, "Gender",    true, DataSourceUpdateMode.OnPropertyChanged);

            _bs.PositionChanged += (s, e) => HienThiAnh();
            _bs.CurrentChanged  += (s, e) => HienThiAnh();
        }

        protected virtual void HienThiAnh()
        {
            if (_bs.Current is not Student sv) { picAvatar.Image = null; return; }
            if (!string.IsNullOrEmpty(sv.AvatarPath) && File.Exists(sv.AvatarPath))
                try { picAvatar.Image = Image.FromFile(sv.AvatarPath); } catch { picAvatar.Image = null; }
            else picAvatar.Image = null;
        }

        private void NapDuLieuMau()
        {
            _danhSach.Add(new Student("SV0001", "Nguyễn Văn An",  20, "Nam", ""));
            _danhSach.Add(new Student("SV0002", "Trần Thị Bình",  21, "Nữ",  ""));
            _danhSach.Add(new Student("SV0003", "Lê Hoàng Minh",  19, "Nam", ""));
            Student.ResetCounter(4);
        }

        // =====================================================================
        // CRUD
        // =====================================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            var sv = new Student();
            _danhSach.Add(sv);
            _bs.MoveLast();
            picAvatar.Image = null;
            txtFullName.Focus();
            GuiThongBao($"✅ Đã thêm {sv.StudentId}");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            _bs.EndEdit();
            _bs.ResetCurrentItem();
            GuiThongBao($"✅ Đã cập nhật: {(_bs.Current as Student)?.FullName}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e) => XoaSinhVien();

        private void XoaSinhVien()
        {
            if (_bs.Current is not Student sv) return;
            if (MessageBox.Show($"Xóa \"{sv.FullName}\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _danhSach.Remove(sv);
            HienThiAnh();
            GuiThongBao($"🗑️ Đã xóa: {sv.FullName}");
        }

        private void XemChiTiet()
        {
            if (_bs.Current is not Student sv) return;
            MessageBox.Show(
                $"Mã SV    : {sv.StudentId}\nHọ tên  : {sv.FullName}\n" +
                $"Tuổi    : {sv.Age}\nGiới tính: {sv.Gender}\n" +
                $"Ảnh     : {(string.IsNullOrEmpty(sv.AvatarPath) ? "(chưa có)" : sv.AvatarPath)}",
                "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================================
        // CHỌN ẢNH
        // =====================================================================
        private void btnChoAnh_Click(object sender, EventArgs e)
        {
            if (_bs.Current is not Student sv) return;
            using var dlg = new OpenFileDialog { Filter = "Tệp ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            sv.AvatarPath = dlg.FileName;
            _bs.ResetCurrentItem();
            HienThiAnh();
        }

        // =====================================================================
        // XUẤT CSV
        // =====================================================================
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                FileName = $"SinhVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var w = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
                w.WriteLine("StudentId,FullName,Age,Gender,AvatarPath");
                foreach (var sv in _danhSach) w.WriteLine(sv.ToCsvLine());
                GuiThongBao($"📤 Xuất CSV: {Path.GetFileName(dlg.FileName)}");
                MessageBox.Show("Xuất CSV thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // VALIDATION
        // =====================================================================
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
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
                errorProvider.SetError(txtFullName, "Không được để trống!");
            else errorProvider.SetError(txtFullName, "");
        }
        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtAge.Text, out int a) || a < 1 || a > 100)
                errorProvider.SetError(txtAge, "Tuổi phải từ 1–100!");
            else errorProvider.SetError(txtAge, "");
        }

        // =====================================================================
        // GIAO TIẾP VỚI FORM CHA
        // =====================================================================
        protected virtual void GuiThongBao(string msg)
            => FormCha?.CapNhatTrangThai(msg);
    }
}
