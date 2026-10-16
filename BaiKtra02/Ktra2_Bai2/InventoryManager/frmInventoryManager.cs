using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace InventoryManager
{
    public partial class frmInventoryManager : Form
    {
        private BindingList<SanPham> _danhSach = new BindingList<SanPham>();
        private BindingSource _bindingSource = new BindingSource();
        private bool _dangThemMoi = false;

        // Timer cập nhật giờ thực lên StatusStrip
        private System.Windows.Forms.Timer _timerGio = new System.Windows.Forms.Timer();

        public frmInventoryManager()
        {
            InitializeComponent();
        }

        // =====================================================================
        // KHỞI TẠO
        // =====================================================================
        private void frmInventoryManager_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBox();
            KhoiTaoCotDataGridView();
            KhoiTaoBindingSource();
            NapDuLieuMau();
            DatTrangThaiForm(false);
            KhoiTaoTimer();
            CapNhatStatusStrip();
        }

        private void KhoiTaoComboBox()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new string[]
            {
                "Điện thoại di động", "Máy tính xách tay", "Máy tính bảng",
                "Phụ kiện", "Thiết bị âm thanh", "Thiết bị lưu trữ", "Màn hình"
            });
            cboCategory.SelectedIndex = -1;
        }

        private void KhoiTaoCotDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.ReadOnly = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.MultiSelect = false;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.Font = new Font("Segoe UI", 9f);
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.EnableHeadersVisualStyles = false;

            dgvProducts.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 80 },
                new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 180 },
                new DataGridViewTextBoxColumn { DataPropertyName = "LoaiSanPham", HeaderText = "Loại", Width = 140 },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DonGia", HeaderText = "Đơn giá (VNĐ)", Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SoLuongTon", HeaderText = "Tồn kho", Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn { DataPropertyName = "DuongDanAnh", HeaderText = "File ảnh", Width = 160 }
            );
        }

        private void KhoiTaoBindingSource()
        {
            _bindingSource.DataSource = _danhSach;
            dgvProducts.DataSource = _bindingSource;
        }

        private void NapDuLieuMau()
        {
            _danhSach.Add(new SanPham("SP0001", "iPhone 15 Pro", "Điện thoại di động", 32000000m, 12, ""));
            _danhSach.Add(new SanPham("SP0002", "Dell XPS 15", "Máy tính xách tay", 38000000m, 5, ""));
            _danhSach.Add(new SanPham("SP0003", "Samsung T7 SSD", "Thiết bị lưu trữ", 1850000m, 30, ""));
            SanPham.ResetCounter(4);
        }

        private void KhoiTaoTimer()
        {
            _timerGio.Interval = 1000;
            _timerGio.Tick += (s, e) => lblThoiGian.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            _timerGio.Start();
        }

        // =====================================================================
        // TRẠNG THÁI FORM
        // =====================================================================
        private void DatTrangThaiForm(bool dangNhapLieu)
        {
            bool coDuLieu = _bindingSource.Count > 0;
            btnAdd.Enabled = !dangNhapLieu;
            btnUpdate.Enabled = !dangNhapLieu && coDuLieu;
            btnDelete.Enabled = !dangNhapLieu && coDuLieu;
            btnSave.Enabled = dangNhapLieu;
            btnClear.Enabled = dangNhapLieu;
            btnChoAnh.Enabled = dangNhapLieu;

            txtProductName.Enabled = dangNhapLieu;
            cboCategory.Enabled = dangNhapLieu;
            txtPrice.Enabled = dangNhapLieu;
            numQuantity.Enabled = dangNhapLieu;
            dgvProducts.Enabled = !dangNhapLieu;
        }

        private void LamMoiForm()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            picProductImage.Image = null;
            picProductImage.Tag = null;
            errorProvider.Clear();
            _dangThemMoi = false;
            DatTrangThaiForm(false);
            btnUpdate.Enabled = _bindingSource.Count > 0;
            btnDelete.Enabled = _bindingSource.Count > 0;
        }

        private void CapNhatStatusStrip()
        {
            int tongSoLuong = 0;
            decimal tongGiaTri = 0;
            foreach (var sp in _danhSach)
            {
                tongSoLuong += sp.SoLuongTon;
                tongGiaTri += sp.DonGia * sp.SoLuongTon;
            }
            lblTongSoLuong.Text = $"Tổng SL: {tongSoLuong:N0}";
            lblTongGiaTri.Text = $"Tổng giá trị: {tongGiaTri:N0} VNĐ";
        }

        // =====================================================================
        // VALIDATION
        // =====================================================================
        private bool KiemTraHopLe()
        {
            bool ok = true;
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            { errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!"); ok = false; }
            if (cboCategory.SelectedIndex < 0)
            { errorProvider.SetError(cboCategory, "Vui lòng chọn loại sản phẩm!"); ok = false; }
            if (!decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal gia) || gia < 0)
            { errorProvider.SetError(txtPrice, "Đơn giá phải là số hợp lệ và >= 0!"); ok = false; }
            return ok;
        }

        // =====================================================================
        // ĐỔ DỮ LIỆU LÊN FORM
        // =====================================================================
        private void HienThiSanPhamLenForm(SanPham sp)
        {
            if (sp == null) return;
            txtProductId.Text = sp.MaSanPham;
            txtProductName.Text = sp.TenSanPham;
            cboCategory.SelectedItem = sp.LoaiSanPham;
            txtPrice.Text = sp.DonGia.ToString("N0");
            numQuantity.Value = sp.SoLuongTon;

            if (!string.IsNullOrEmpty(sp.DuongDanAnh) && File.Exists(sp.DuongDanAnh))
            {
                try { picProductImage.Image = Image.FromFile(sp.DuongDanAnh); picProductImage.Tag = sp.DuongDanAnh; }
                catch { picProductImage.Image = null; picProductImage.Tag = null; }
            }
            else { picProductImage.Image = null; picProductImage.Tag = null; }
            errorProvider.Clear();
        }

        // =====================================================================
        // SỰ KIỆN DATAGRIDVIEW
        // =====================================================================
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;
            if (_bindingSource.Current is SanPham sp)
                HienThiSanPhamLenForm(sp);
        }

        // =====================================================================
        // NÚT CHỨC NĂNG
        // =====================================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var spMoi = new SanPham();
            txtProductId.Text = spMoi.MaSanPham;
            txtProductName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            picProductImage.Image = null;
            picProductImage.Tag = null;
            errorProvider.Clear();
            _dangThemMoi = true;
            DatTrangThaiForm(true);
            txtProductName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not SanPham sp) return;
            HienThiSanPhamLenForm(sp);
            _dangThemMoi = false;
            DatTrangThaiForm(true);
            txtProductName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            decimal.TryParse(txtPrice.Text.Replace(",", ""),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal gia);
            if (gia == 0) decimal.TryParse(txtPrice.Text, out gia);

            string duongDanAnh = picProductImage.Tag?.ToString() ?? "";

            if (_dangThemMoi)
            {
                var spMoi = new SanPham(
                    txtProductId.Text,
                    txtProductName.Text.Trim(),
                    cboCategory.SelectedItem!.ToString()!,
                    gia, (int)numQuantity.Value, duongDanAnh);
                _danhSach.Add(spMoi);
                _bindingSource.MoveLast();
                MessageBox.Show($"Đã thêm \"{spMoi.TenSanPham}\" thành công!", "Thêm mới",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_bindingSource.Current is not SanPham sp) return;
                sp.TenSanPham = txtProductName.Text.Trim();
                sp.LoaiSanPham = cboCategory.SelectedItem!.ToString()!;
                sp.DonGia = gia;
                sp.SoLuongTon = (int)numQuantity.Value;
                sp.DuongDanAnh = duongDanAnh;
                _bindingSource.ResetCurrentItem();
                MessageBox.Show($"Đã cập nhật \"{sp.TenSanPham}\" thành công!", "Cập nhật",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CapNhatStatusStrip();
            LamMoiForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not SanPham sp) return;
            if (MessageBox.Show($"Xóa sản phẩm \"{sp.TenSanPham}\"?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _danhSach.Remove(sp);
                CapNhatStatusStrip();
                LamMoiForm();
                if (_bindingSource.Current is SanPham spHT) HienThiSanPhamLenForm(spHT);
                MessageBox.Show("Đã xóa thành công!", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            if (_bindingSource.Current is SanPham sp) HienThiSanPhamLenForm(sp);
        }

        // =====================================================================
        // CHỌN ẢNH (OpenFileDialog)
        // =====================================================================
        private void btnChoAnh_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Chọn ảnh sản phẩm",
                Filter = "Tệp ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp",
                Multiselect = false
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picProductImage.Image = Image.FromFile(dlg.FileName);
                    picProductImage.Tag = dlg.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải ảnh: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =====================================================================
        // MENU: IMPORT / EXPORT CSV
        // =====================================================================
        private void menuExportCsv_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Title = "Xuất báo cáo CSV",
                Filter = "CSV file (*.csv)|*.csv",
                FileName = $"KhoHang_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var writer = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
                writer.WriteLine("MaSanPham,TenSanPham,LoaiSanPham,DonGia,SoLuongTon,DuongDanAnh");
                foreach (var sp in _danhSach)
                    writer.WriteLine(sp.ToCsvLine());

                MessageBox.Show($"Xuất CSV thành công!\nFile: {dlg.FileName}", "Xuất CSV",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất CSV: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuImportCsv_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Nhập dữ liệu từ CSV",
                Filter = "CSV file (*.csv)|*.csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lines = File.ReadAllLines(dlg.FileName, System.Text.Encoding.UTF8);
                int soLuongNhap = 0, soLuongLoi = 0;

                _danhSach.Clear();
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("MaSanPham")) continue;
                    var sp = SanPham.FromCsvLine(line);
                    if (sp != null) { _danhSach.Add(sp); soLuongNhap++; }
                    else soLuongLoi++;
                }

                CapNhatStatusStrip();
                MessageBox.Show(
                    $"Import hoàn tất!\n✅ Thành công: {soLuongNhap} dòng\n❌ Lỗi: {soLuongLoi} dòng",
                    "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc CSV: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // MENU: MỞ FILE / LƯU BÁO CÁO
        // =====================================================================
        private void menuOpenFile_Click(object sender, EventArgs e) => menuImportCsv_Click(sender, e);

        private void menuSaveReport_Click(object sender, EventArgs e) => menuExportCsv_Click(sender, e);

        // =====================================================================
        // THOÁT
        // =====================================================================
        private void menuExit_Click(object sender, EventArgs e) => this.Close();

        private void frmInventoryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            var ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (ketQua == DialogResult.No)
                e.Cancel = true;
        }

        // =====================================================================
        // VALIDATION EVENTS
        // =====================================================================
        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            if (txtProductName.Enabled && string.IsNullOrWhiteSpace(txtProductName.Text))
                errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!");
            else errorProvider.SetError(txtProductName, "");
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!txtPrice.Enabled) return;
            if (!decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal gia) || gia < 0)
                errorProvider.SetError(txtPrice, "Đơn giá không hợp lệ!");
            else errorProvider.SetError(txtPrice, "");
        }

        private void cboCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cboCategory.Enabled && cboCategory.SelectedIndex < 0)
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại sản phẩm!");
            else errorProvider.SetError(cboCategory, "");
        }
    }
}
