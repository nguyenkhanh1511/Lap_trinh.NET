using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SchoolMDI
{
    public partial class frmProduct : Form
    {
        protected BindingList<Product> _danhSach = new BindingList<Product>();
        protected BindingSource _bs = new BindingSource();

        private frmMain? FormCha => MdiParent as frmMain;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            KhoiTaoCbo();
            KhoiTaoDGV();
            KhoiTaoBinding();
            NapDuLieuMau();
        }

        private void KhoiTaoCbo()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new[] { "Điện tử", "Văn phòng phẩm", "Thực phẩm", "Thời trang", "Đồ gia dụng" });
            cboCategory.SelectedIndex = 0;
        }

        private void KhoiTaoDGV()
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
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LavenderBlush;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvProducts.EnableHeadersVisualStyles = false;

            dgvProducts.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "ProductId",   HeaderText = "Mã SP",    Width = 80  },
                new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên SP",   Width = 200 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Category",    HeaderText = "Danh mục", Width = 120 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Price",       HeaderText = "Đơn giá",  Width = 110,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { DataPropertyName = "Quantity",    HeaderText = "Số lượng", Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            );

            var ctx = new ContextMenuStrip();
            ctx.Items.Add("🗑️ Xóa dòng",       null, (s, e) => XoaSanPham());
            ctx.Items.Add(new ToolStripSeparator());
            ctx.Items.Add("🔄 Làm mới dữ liệu", null, (s, e) => errorProvider.Clear());
            ctx.Items.Add("🔍 Xem chi tiết",    null, (s, e) => XemChiTiet());
            dgvProducts.ContextMenuStrip = ctx;
        }

        private void KhoiTaoBinding()
        {
            _bs.DataSource = _danhSach;
            dgvProducts.DataSource = _bs;

            txtProductId  .DataBindings.Add("Text", _bs, "ProductId",   true, DataSourceUpdateMode.OnPropertyChanged);
            txtProductName.DataBindings.Add("Text", _bs, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged);
            cboCategory   .DataBindings.Add("Text", _bs, "Category",    true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrice      .DataBindings.Add("Text", _bs, "Price",       true, DataSourceUpdateMode.OnPropertyChanged);
            numQuantity   .DataBindings.Add("Value", _bs, "Quantity",   true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void NapDuLieuMau()
        {
            _danhSach.Add(new Product("SP0001", "Laptop Dell XPS",    "Điện tử",       28000000m, 5));
            _danhSach.Add(new Product("SP0002", "Bút bi Thiên Long",  "Văn phòng phẩm",     5000m, 200));
            _danhSach.Add(new Product("SP0003", "Chuột không dây",   "Điện tử",         350000m, 30));
            _danhSach.Add(new Product("SP0004", "Sữa tươi Vinamilk", "Thực phẩm",        28000m, 50));
            Product.ResetCounter(5);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            var sp = new Product();
            _danhSach.Add(sp);
            _bs.MoveLast();
            txtProductName.Focus();
            GuiThongBao($"✅ Đã thêm {sp.ProductId}");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            _bs.EndEdit();
            _bs.ResetCurrentItem();
            GuiThongBao($"✅ Đã cập nhật: {(_bs.Current as Product)?.ProductName}");
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e) => XoaSanPham();

        private void XoaSanPham()
        {
            if (_bs.Current is not Product sp) return;
            if (MessageBox.Show($"Xóa \"{sp.ProductName}\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _danhSach.Remove(sp);
            GuiThongBao($"🗑️ Đã xóa: {sp.ProductName}");
        }

        private void XemChiTiet()
        {
            if (_bs.Current is not Product sp) return;
            MessageBox.Show(
                $"Mã SP    : {sp.ProductId}\nTên     : {sp.ProductName}\n" +
                $"Danh mục: {sp.Category}\nĐơn giá: {sp.Price:N0} VNĐ\nSố lượng: {sp.Quantity}",
                "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog { Filter = "CSV file (*.csv)|*.csv", FileName = $"SanPham_{DateTime.Now:yyyyMMdd}.csv" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var w = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
                w.WriteLine("ProductId,ProductName,Category,Price,Quantity");
                foreach (var sp in _danhSach) w.WriteLine(sp.ToCsvLine());
                GuiThongBao($"📤 Xuất CSV: {Path.GetFileName(dlg.FileName)}");
                MessageBox.Show("Xuất CSV thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool KiemTraHopLe()
        {
            bool ok = true; errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            { errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!"); ok = false; }
            if (!decimal.TryParse(txtPrice.Text, out decimal p) || p < 0)
            { errorProvider.SetError(txtPrice, "Giá phải là số >= 0!"); ok = false; }
            return ok;
        }

        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
                errorProvider.SetError(txtProductName, "Không được để trống!");
            else errorProvider.SetError(txtProductName, "");
        }
        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal p) || p < 0)
                errorProvider.SetError(txtPrice, "Giá không hợp lệ!");
            else errorProvider.SetError(txtPrice, "");
        }

        protected virtual void GuiThongBao(string msg) => FormCha?.CapNhatTrangThai(msg);
    }
}
