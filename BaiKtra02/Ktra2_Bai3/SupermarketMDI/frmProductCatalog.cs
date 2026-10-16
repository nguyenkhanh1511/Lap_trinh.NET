using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SupermarketMDI
{
    public partial class frmProductCatalog : Form
    {
        private BindingList<SanPham> _danhSach = new BindingList<SanPham>();
        private BindingSource _bindingSource = new BindingSource();
        private bool _dangThemMoi = false;

        public frmProductCatalog()
        {
            InitializeComponent();
        }

        // Truy cập Form cha MDI để dùng ProgressBar
        private frmMain? FormCha => this.MdiParent as frmMain;

        // =====================================================================
        // KHỞI TẠO
        // =====================================================================
        private void frmProductCatalog_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBox();
            KhoiTaoCotDGV();
            _bindingSource.DataSource = _danhSach;
            dgvProducts.DataSource = _bindingSource;
            NapDuLieuMau();
            DatTrangThaiForm(false);
        }

        private void KhoiTaoComboBox()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new string[]
            { "Điện thoại di động", "Máy tính xách tay", "Máy tính bảng",
              "Phụ kiện", "Thiết bị âm thanh", "Thiết bị lưu trữ", "Màn hình" });
            cboCategory.SelectedIndex = -1;
        }

        private void KhoiTaoCotDGV()
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
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            dgvProducts.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 80 },
                new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 180 },
                new DataGridViewTextBoxColumn { DataPropertyName = "LoaiSanPham", HeaderText = "Loại", Width = 140 },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DonGia", HeaderText = "Đơn giá (VNĐ)", Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SoLuongTon", HeaderText = "Tồn kho", Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn { DataPropertyName = "DuongDanAnh", HeaderText = "File ảnh", Width = 160 }
            );
        }

        private void NapDuLieuMau()
        {
            _danhSach.Add(new SanPham("SP0001", "iPhone 15 Pro", "Điện thoại di động", 32000000m, 12, ""));
            _danhSach.Add(new SanPham("SP0002", "Dell XPS 15", "Máy tính xách tay", 38000000m, 5, ""));
            _danhSach.Add(new SanPham("SP0003", "Samsung T7 SSD", "Thiết bị lưu trữ", 1850000m, 30, ""));
            SanPham.ResetCounter(4);
        }

        // =====================================================================
        // TRẠNG THÁI FORM
        // =====================================================================
        private void DatTrangThaiForm(bool dangNhap)
        {
            bool coDL = _bindingSource.Count > 0;
            btnAdd.Enabled = !dangNhap;
            btnUpdate.Enabled = !dangNhap && coDL;
            btnDelete.Enabled = !dangNhap && coDL;
            btnSave.Enabled = dangNhap;
            btnClear.Enabled = dangNhap;
            btnChoAnh.Enabled = dangNhap;
            txtProductName.Enabled = dangNhap;
            cboCategory.Enabled = dangNhap;
            txtPrice.Enabled = dangNhap;
            numQuantity.Enabled = dangNhap;
            dgvProducts.Enabled = !dangNhap;
        }

        private void LamMoiForm()
        {
            txtProductId.Clear(); txtProductName.Clear();
            cboCategory.SelectedIndex = -1; txtPrice.Clear(); numQuantity.Value = 0;
            picProductImage.Image = null; picProductImage.Tag = null;
            errorProvider.Clear(); _dangThemMoi = false; DatTrangThaiForm(false);
            btnUpdate.Enabled = _bindingSource.Count > 0;
            btnDelete.Enabled = _bindingSource.Count > 0;
        }

        // =====================================================================
        // VALIDATION
        // =====================================================================
        private bool KiemTraHopLe()
        {
            bool ok = true; errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            { errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!"); ok = false; }
            if (cboCategory.SelectedIndex < 0)
            { errorProvider.SetError(cboCategory, "Vui lòng chọn loại sản phẩm!"); ok = false; }
            if (!decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal g) || g < 0)
            { errorProvider.SetError(txtPrice, "Đơn giá phải là số >= 0!"); ok = false; }
            return ok;
        }

        // =====================================================================
        // ĐỔ DỮ LIỆU LÊN FORM
        // =====================================================================
        private void HienThiLenForm(SanPham sp)
        {
            if (sp == null) return;
            txtProductId.Text = sp.MaSanPham;
            txtProductName.Text = sp.TenSanPham;
            cboCategory.SelectedItem = sp.LoaiSanPham;
            txtPrice.Text = sp.DonGia.ToString("N0");
            numQuantity.Value = sp.SoLuongTon;
            if (!string.IsNullOrEmpty(sp.DuongDanAnh) && File.Exists(sp.DuongDanAnh))
            { try { picProductImage.Image = Image.FromFile(sp.DuongDanAnh); picProductImage.Tag = sp.DuongDanAnh; } catch { picProductImage.Image = null; picProductImage.Tag = null; } }
            else { picProductImage.Image = null; picProductImage.Tag = null; }
            errorProvider.Clear();
        }

        // =====================================================================
        // SỰ KIỆN
        // =====================================================================
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Current is SanPham sp) HienThiLenForm(sp);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var sp = new SanPham(); txtProductId.Text = sp.MaSanPham;
            txtProductName.Clear(); cboCategory.SelectedIndex = -1; txtPrice.Clear();
            numQuantity.Value = 0; picProductImage.Image = null; picProductImage.Tag = null;
            errorProvider.Clear(); _dangThemMoi = true; DatTrangThaiForm(true); txtProductName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not SanPham sp) return;
            HienThiLenForm(sp); _dangThemMoi = false; DatTrangThaiForm(true); txtProductName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            decimal.TryParse(txtPrice.Text.Replace(",", ""),
                System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal gia);
            string anh = picProductImage.Tag?.ToString() ?? "";

            if (_dangThemMoi)
            {
                var spMoi = new SanPham(txtProductId.Text, txtProductName.Text.Trim(),
                    cboCategory.SelectedItem!.ToString()!, gia, (int)numQuantity.Value, anh);
                _danhSach.Add(spMoi);
                _bindingSource.MoveLast();
                MessageBox.Show($"Đã thêm \"{spMoi.TenSanPham}\"!", "Thêm mới", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_bindingSource.Current is not SanPham sp) return;
                sp.TenSanPham = txtProductName.Text.Trim();
                sp.LoaiSanPham = cboCategory.SelectedItem!.ToString()!;
                sp.DonGia = gia; sp.SoLuongTon = (int)numQuantity.Value; sp.DuongDanAnh = anh;
                _bindingSource.ResetCurrentItem();
                MessageBox.Show($"Đã cập nhật \"{sp.TenSanPham}\"!", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LamMoiForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not SanPham sp) return;
            if (MessageBox.Show($"Xóa \"{sp.TenSanPham}\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _danhSach.Remove(sp); LamMoiForm();
                if (_bindingSource.Current is SanPham spHT) HienThiLenForm(spHT);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            if (_bindingSource.Current is SanPham sp) HienThiLenForm(sp);
        }

        private void btnChoAnh_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "Tệp ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp", Title = "Chọn ảnh" };
            if (dlg.ShowDialog() == DialogResult.OK)
            { try { picProductImage.Image = Image.FromFile(dlg.FileName); picProductImage.Tag = dlg.FileName; } catch { } }
        }

        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            if (txtProductName.Enabled && string.IsNullOrWhiteSpace(txtProductName.Text))
                errorProvider.SetError(txtProductName, "Tên không được để trống!");
            else errorProvider.SetError(txtProductName, "");
        }
        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!txtPrice.Enabled) return;
            if (!decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal g) || g < 0)
                errorProvider.SetError(txtPrice, "Đơn giá không hợp lệ!");
            else errorProvider.SetError(txtPrice, "");
        }
        private void cboCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cboCategory.Enabled && cboCategory.SelectedIndex < 0)
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại!");
            else errorProvider.SetError(cboCategory, "");
        }
    }
}
