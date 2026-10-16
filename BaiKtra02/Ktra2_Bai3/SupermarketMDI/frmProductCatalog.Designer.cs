namespace SupermarketMDI
{
    partial class frmProductCatalog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            grpInput = new System.Windows.Forms.GroupBox();
            lblProductId = new System.Windows.Forms.Label();
            txtProductId = new System.Windows.Forms.TextBox();
            lblProductName = new System.Windows.Forms.Label();
            txtProductName = new System.Windows.Forms.TextBox();
            lblCategory = new System.Windows.Forms.Label();
            cboCategory = new System.Windows.Forms.ComboBox();
            lblPrice = new System.Windows.Forms.Label();
            txtPrice = new System.Windows.Forms.TextBox();
            lblQuantity = new System.Windows.Forms.Label();
            numQuantity = new System.Windows.Forms.NumericUpDown();

            grpImage = new System.Windows.Forms.GroupBox();
            picProductImage = new System.Windows.Forms.PictureBox();
            btnChoAnh = new System.Windows.Forms.Button();

            pnlButtons = new System.Windows.Forms.Panel();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            grpGrid = new System.Windows.Forms.GroupBox();
            dgvProducts = new System.Windows.Forms.DataGridView();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);

            // ===== grpInput =====
            grpInput.SuspendLayout();
            grpInput.Text = "Thông tin sản phẩm";
            grpInput.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpInput.Location = new System.Drawing.Point(6, 6);
            grpInput.Size = new System.Drawing.Size(370, 200);

            int lx = 10, tx = 130, ty = 22, lh = 32, lw = 115, tw = 220;
            void AddRow(System.Windows.Forms.Label l, string lt, System.Windows.Forms.Control c, int row)
            {
                l.Text = lt; l.Location = new System.Drawing.Point(lx, ty + row * lh);
                l.Size = new System.Drawing.Size(lw, 23); l.Font = new System.Drawing.Font("Segoe UI", 9f);
                l.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                c.Location = new System.Drawing.Point(tx, ty + row * lh);
                if (c is System.Windows.Forms.TextBox || c is System.Windows.Forms.ComboBox)
                    c.Size = new System.Drawing.Size(tw, 23);
                c.Font = new System.Drawing.Font("Segoe UI", 9f);
            }
            AddRow(lblProductId, "Mã sản phẩm:", txtProductId, 0);
            txtProductId.Size = new System.Drawing.Size(110, 23); txtProductId.ReadOnly = true; txtProductId.BackColor = System.Drawing.Color.WhiteSmoke;
            AddRow(lblProductName, "Tên sản phẩm:", txtProductName, 1);
            txtProductName.Validating += new System.ComponentModel.CancelEventHandler(txtProductName_Validating);
            AddRow(lblCategory, "Loại sản phẩm:", cboCategory, 2);
            cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboCategory.Validating += new System.ComponentModel.CancelEventHandler(cboCategory_Validating);
            AddRow(lblPrice, "Đơn giá (VNĐ):", txtPrice, 3);
            txtPrice.Size = new System.Drawing.Size(140, 23);
            txtPrice.Validating += new System.ComponentModel.CancelEventHandler(txtPrice_Validating);
            AddRow(lblQuantity, "Số lượng tồn:", numQuantity, 4);
            numQuantity.Size = new System.Drawing.Size(100, 23); numQuantity.Minimum = 0; numQuantity.Maximum = 99999;

            grpInput.Controls.AddRange(new System.Windows.Forms.Control[]
            { lblProductId, txtProductId, lblProductName, txtProductName, lblCategory, cboCategory,
              lblPrice, txtPrice, lblQuantity, numQuantity });
            grpInput.ResumeLayout(false);

            // ===== grpImage =====
            grpImage.SuspendLayout();
            grpImage.Text = "Hình ảnh";
            grpImage.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpImage.Location = new System.Drawing.Point(6, 214);
            grpImage.Size = new System.Drawing.Size(370, 180);

            picProductImage.Location = new System.Drawing.Point(10, 22);
            picProductImage.Size = new System.Drawing.Size(240, 148);
            picProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picProductImage.BackColor = System.Drawing.Color.WhiteSmoke;

            btnChoAnh.Text = "📷 Chọn ảnh";
            btnChoAnh.Location = new System.Drawing.Point(260, 22);
            btnChoAnh.Size = new System.Drawing.Size(100, 34);
            btnChoAnh.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnChoAnh.BackColor = System.Drawing.Color.Teal;
            btnChoAnh.ForeColor = System.Drawing.Color.White;
            btnChoAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChoAnh.Click += new System.EventHandler(btnChoAnh_Click);

            grpImage.Controls.AddRange(new System.Windows.Forms.Control[] { picProductImage, btnChoAnh });
            grpImage.ResumeLayout(false);

            // ===== pnlButtons =====
            pnlButtons.Location = new System.Drawing.Point(6, 402);
            pnlButtons.Size = new System.Drawing.Size(370, 42);

            int bx2 = 0, bw2 = 68, bh2 = 30;
            void MakeBtn(System.Windows.Forms.Button b, string txt, System.Drawing.Color clr, System.EventHandler ev)
            {
                b.Text = txt; b.Location = new System.Drawing.Point(bx2, 6); b.Size = new System.Drawing.Size(bw2, bh2);
                b.Font = new System.Drawing.Font("Segoe UI", 8.5f); b.BackColor = clr; b.ForeColor = System.Drawing.Color.White;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat; b.Click += ev; bx2 += bw2 + 4;
            }
            MakeBtn(btnAdd, "➕ Thêm", System.Drawing.Color.ForestGreen, btnAdd_Click);
            MakeBtn(btnUpdate, "✏️ Sửa", System.Drawing.Color.SteelBlue, btnUpdate_Click);
            MakeBtn(btnDelete, "🗑️ Xóa", System.Drawing.Color.Crimson, btnDelete_Click);
            MakeBtn(btnSave, "💾 Lưu", System.Drawing.Color.DarkOrange, btnSave_Click);
            MakeBtn(btnClear, "🔄 Hủy", System.Drawing.Color.Gray, btnClear_Click);

            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[]
            { btnAdd, btnUpdate, btnDelete, btnSave, btnClear });

            // ===== grpGrid =====
            grpGrid.SuspendLayout();
            grpGrid.Text = "Danh sách sản phẩm";
            grpGrid.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpGrid.Location = new System.Drawing.Point(386, 6);
            grpGrid.Size = new System.Drawing.Size(700, 438);
            dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvProducts.SelectionChanged += new System.EventHandler(dgvProducts_SelectionChanged);
            grpGrid.Controls.Add(dgvProducts);
            grpGrid.ResumeLayout(false);

            // ===== errorProvider =====
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;

            // ===== FORM =====
            this.Text = "📦 Quản lý Sản phẩm";
            this.ClientSize = new System.Drawing.Size(1096, 460);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Load += new System.EventHandler(frmProductCatalog_Load);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            { grpInput, grpImage, pnlButtons, grpGrid });
        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblProductId, lblProductName, lblCategory, lblPrice, lblQuantity;
        private System.Windows.Forms.TextBox txtProductId, txtProductName, txtPrice;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.GroupBox grpImage;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnChoAnh;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd, btnUpdate, btnDelete, btnSave, btnClear;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
