using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DeviceManager
{
    public partial class frmDeviceManager : Form
    {
        // --- Dữ liệu ---
        private BindingList<ThietBi> _danhSachThietBi = new BindingList<ThietBi>();
        private BindingSource _bindingSource = new BindingSource();

        // Trạng thái: đang thêm mới hay đang cập nhật
        private bool _dangThemMoi = false;

        public frmDeviceManager()
        {
            InitializeComponent();
        }

        // =====================================================================
        // KHỞI TẠO
        // =====================================================================
        private void frmDeviceManager_Load(object sender, EventArgs e)
        {
            KhoiTaoCboCategory();
            KhoiTaoCotDataGridView();
            KhoiTaoBindingSource();
            NapDuLieuMau();
            DatTrangThaiForm(false);
        }

        private void KhoiTaoCboCategory()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new string[]
            {
                "Điện thoại di động",
                "Máy tính xách tay",
                "Máy tính bảng",
                "Phụ kiện",
                "Thiết bị âm thanh",
                "Thiết bị lưu trữ",
                "Màn hình"
            });
            cboCategory.SelectedIndex = -1;
        }

        private void KhoiTaoCotDataGridView()
        {
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.ReadOnly = true;
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AllowUserToDeleteRows = false;
            dgvDevices.MultiSelect = false;
            dgvDevices.BackgroundColor = Color.White;
            dgvDevices.BorderStyle = BorderStyle.Fixed3D;
            dgvDevices.RowHeadersVisible = false;
            dgvDevices.Font = new Font("Segoe UI", 9f);
            dgvDevices.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvDevices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvDevices.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvDevices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDevices.EnableHeadersVisualStyles = false;

            // Định nghĩa cột
            var colMa = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaThietBi",
                HeaderText = "Mã thiết bị",
                Name = "colMa",
                Width = 90,
                ReadOnly = true
            };

            var colTen = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenThietBi",
                HeaderText = "Tên thiết bị",
                Name = "colTen",
                Width = 200,
                ReadOnly = true
            };

            var colLoai = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiThietBi",
                HeaderText = "Loại thiết bị",
                Name = "colLoai",
                Width = 160,
                ReadOnly = true
            };

            var colGia = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn giá (VNĐ)",
                Name = "colGia",
                Width = 130,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            var colSoLuong = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Số lượng tồn",
                Name = "colSoLuong",
                Width = 110,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            dgvDevices.Columns.AddRange(colMa, colTen, colLoai, colGia, colSoLuong);
        }

        private void KhoiTaoBindingSource()
        {
            _bindingSource.DataSource = _danhSachThietBi;
            dgvDevices.DataSource = _bindingSource;
        }

        private void NapDuLieuMau()
        {
            _danhSachThietBi.Add(new ThietBi("TB0001", "iPhone 15 Pro Max", "Điện thoại di động", 35000000m, 10));
            _danhSachThietBi.Add(new ThietBi("TB0002", "Samsung Galaxy S24", "Điện thoại di động", 28000000m, 15));
            _danhSachThietBi.Add(new ThietBi("TB0003", "MacBook Air M3", "Máy tính xách tay", 29000000m, 5));
            _danhSachThietBi.Add(new ThietBi("TB0004", "iPad Pro 12.9", "Máy tính bảng", 25000000m, 8));
            _danhSachThietBi.Add(new ThietBi("TB0005", "AirPods Pro 2", "Thiết bị âm thanh", 6500000m, 20));
            ThietBi.ResetCounter(6);
        }

        // =====================================================================
        // ĐIỀU KHIỂN TRẠNG THÁI FORM
        // =====================================================================
        private void DatTrangThaiForm(bool dangNhapLieu)
        {
            // Khi không nhập liệu: chỉ cho phép chọn dòng và bấm Thêm/Xóa
            btnAdd.Enabled = !dangNhapLieu;
            btnUpdate.Enabled = !dangNhapLieu && _bindingSource.Count > 0;
            btnDelete.Enabled = !dangNhapLieu && _bindingSource.Count > 0;
            btnSave.Enabled = dangNhapLieu;
            btnClear.Enabled = dangNhapLieu;

            // Khu vực nhập liệu
            txtDeviceName.Enabled = dangNhapLieu;
            cboCategory.Enabled = dangNhapLieu;
            txtPrice.Enabled = dangNhapLieu;
            numQuantity.Enabled = dangNhapLieu;
            dgvDevices.Enabled = !dangNhapLieu;
        }

        private void LamMoiForm()
        {
            txtDeviceId.Clear();
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider.Clear();
            _dangThemMoi = false;
            DatTrangThaiForm(false);

            // Cập nhật nút sau khi làm mới
            btnUpdate.Enabled = _bindingSource.Count > 0;
            btnDelete.Enabled = _bindingSource.Count > 0;
        }

        // =====================================================================
        // VALIDATION
        // =====================================================================
        private bool KiemTraHopLe()
        {
            bool hopLe = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider.SetError(txtDeviceName, "Tên thiết bị không được để trống!");
                hopLe = false;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại thiết bị!");
                hopLe = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal gia) || gia < 0)
            {
                errorProvider.SetError(txtPrice, "Đơn giá phải là số hợp lệ và không nhỏ hơn 0!");
                hopLe = false;
            }

            return hopLe;
        }

        // =====================================================================
        // ĐỔ DỮ LIỆU LÊN FORM (Data Binding 2 chiều: Grid → Form)
        // =====================================================================
        private void DoNguocDuLieuLenForm(ThietBi tb)
        {
            if (tb == null) return;
            txtDeviceId.Text = tb.MaThietBi;
            txtDeviceName.Text = tb.TenThietBi;
            cboCategory.SelectedItem = tb.LoaiThietBi;
            txtPrice.Text = tb.DonGia.ToString("N0");
            numQuantity.Value = tb.SoLuongTon;
            errorProvider.Clear();
        }

        // =====================================================================
        // SỰ KIỆN DATAGRIDVIEW
        // =====================================================================
        private void dgvDevices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0) return;
            if (_bindingSource.Current is ThietBi tb)
            {
                DoNguocDuLieuLenForm(tb);
            }
        }

        // =====================================================================
        // SỰ KIỆN NÚT
        // =====================================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Tạo mã tự động cho thiết bị mới
            var tbMoi = new ThietBi();
            txtDeviceId.Text = tbMoi.MaThietBi;
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider.Clear();

            _dangThemMoi = true;
            DatTrangThaiForm(true);
            txtDeviceName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not ThietBi tb) return;
            DoNguocDuLieuLenForm(tb);
            _dangThemMoi = false;
            DatTrangThaiForm(true);
            txtDeviceName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            decimal gia = decimal.Parse(txtPrice.Text.Replace(",", "").Replace(".", ""));
            // Thử parse lại an toàn hơn
            if (!decimal.TryParse(
                    txtPrice.Text.Replace(",", ""),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out gia))
            {
                decimal.TryParse(txtPrice.Text, out gia);
            }

            if (_dangThemMoi)
            {
                // Thêm mới vào BindingList → DataGridView tự cập nhật
                var tbMoi = new ThietBi(
                    txtDeviceId.Text,
                    txtDeviceName.Text.Trim(),
                    cboCategory.SelectedItem.ToString()!,
                    gia,
                    (int)numQuantity.Value
                );
                _danhSachThietBi.Add(tbMoi);

                // Chọn dòng vừa thêm
                _bindingSource.MoveLast();

                MessageBox.Show($"Đã thêm thiết bị \"{tbMoi.TenThietBi}\" thành công!",
                    "Thêm mới", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cập nhật đối tượng hiện tại
                if (_bindingSource.Current is not ThietBi tb) return;
                tb.TenThietBi = txtDeviceName.Text.Trim();
                tb.LoaiThietBi = cboCategory.SelectedItem.ToString()!;
                tb.DonGia = gia;
                tb.SoLuongTon = (int)numQuantity.Value;

                // Thông báo BindingSource làm mới dòng hiện tại
                _bindingSource.ResetCurrentItem();

                MessageBox.Show($"Đã cập nhật thiết bị \"{tb.TenThietBi}\" thành công!",
                    "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LamMoiForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not ThietBi tb) return;

            var ketQua = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thiết bị \"{tb.TenThietBi}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (ketQua == DialogResult.Yes)
            {
                _danhSachThietBi.Remove(tb);
                LamMoiForm();

                if (_bindingSource.Count > 0 && _bindingSource.Current is ThietBi tbHienTai)
                    DoNguocDuLieuLenForm(tbHienTai);
                else
                {
                    txtDeviceId.Clear();
                    txtDeviceName.Clear();
                    cboCategory.SelectedIndex = -1;
                    txtPrice.Clear();
                    numQuantity.Value = 0;
                }

                MessageBox.Show("Đã xóa thiết bị thành công!", "Xóa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            if (_bindingSource.Count > 0 && _bindingSource.Current is ThietBi tb)
                DoNguocDuLieuLenForm(tb);
        }

        // =====================================================================
        // VALIDATION EVENTS (real-time)
        // =====================================================================
        private void txtDeviceName_Validating(object sender, CancelEventArgs e)
        {
            if (txtDeviceName.Enabled && string.IsNullOrWhiteSpace(txtDeviceName.Text))
                errorProvider.SetError(txtDeviceName, "Tên thiết bị không được để trống!");
            else
                errorProvider.SetError(txtDeviceName, "");
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!txtPrice.Enabled) return;
            if (!decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal gia) || gia < 0)
                errorProvider.SetError(txtPrice, "Đơn giá phải là số hợp lệ và không nhỏ hơn 0!");
            else
                errorProvider.SetError(txtPrice, "");
        }

        private void cboCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cboCategory.Enabled && cboCategory.SelectedIndex < 0)
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại thiết bị!");
            else
                errorProvider.SetError(cboCategory, "");
        }
    }
}
