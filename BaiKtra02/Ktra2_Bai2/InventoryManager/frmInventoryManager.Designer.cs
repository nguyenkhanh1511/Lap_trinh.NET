namespace InventoryManager
{
    partial class frmInventoryManager
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

            // --- Menu ---
            menuStrip = new System.Windows.Forms.MenuStrip();
            menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            menuSaveReport = new System.Windows.Forms.ToolStripMenuItem();
            menuSepHeThong = new System.Windows.Forms.ToolStripSeparator();
            menuExit = new System.Windows.Forms.ToolStripMenuItem();
            menuCongCu = new System.Windows.Forms.ToolStripMenuItem();
            menuImportCsv = new System.Windows.Forms.ToolStripMenuItem();
            menuExportCsv = new System.Windows.Forms.ToolStripMenuItem();

            // --- ToolStrip ---
            toolStrip = new System.Windows.Forms.ToolStrip();
            tsBtnMoFile = new System.Windows.Forms.ToolStripButton();
            tsBtnLuuBaoCao = new System.Windows.Forms.ToolStripButton();
            tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            tsBtnImport = new System.Windows.Forms.ToolStripButton();
            tsBtnExport = new System.Windows.Forms.ToolStripButton();
            tsSep2 = new System.Windows.Forms.ToolStripSeparator();
            tsBtnThoat = new System.Windows.Forms.ToolStripButton();

            // --- StatusStrip ---
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblTongSoLuong = new System.Windows.Forms.ToolStripStatusLabel();
            lblSepStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblTongGiaTri = new System.Windows.Forms.ToolStripStatusLabel();
            lblSepStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblThoiGian = new System.Windows.Forms.ToolStripStatusLabel();

            // --- Panel chính ---
            pnlLeft = new System.Windows.Forms.Panel();
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

            grpButtons = new System.Windows.Forms.GroupBox();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            grpGrid = new System.Windows.Forms.GroupBox();
            dgvProducts = new System.Windows.Forms.DataGridView();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);

            // ==================== MENUSTRIP ====================
            menuStrip.SuspendLayout();

            // menuHeThong
            menuHeThong.Text = "Hệ thống";
            menuOpenFile.Text = "📂 Mở File";
            menuOpenFile.Click += new System.EventHandler(menuOpenFile_Click);
            menuSaveReport.Text = "💾 Lưu Báo Cáo";
            menuSaveReport.Click += new System.EventHandler(menuSaveReport_Click);
            menuExit.Text = "🚪 Thoát";
            menuExit.Click += new System.EventHandler(menuExit_Click);
            menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            { menuOpenFile, menuSaveReport, menuSepHeThong, menuExit });

            // menuCongCu
            menuCongCu.Text = "Công cụ";
            menuImportCsv.Text = "📥 Import CSV";
            menuImportCsv.Click += new System.EventHandler(menuImportCsv_Click);
            menuExportCsv.Text = "📤 Export CSV";
            menuExportCsv.Click += new System.EventHandler(menuExportCsv_Click);
            menuCongCu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            { menuImportCsv, menuExportCsv });

            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuHeThong, menuCongCu });
            menuStrip.ResumeLayout(false);

            // ==================== TOOLSTRIP ====================
            tsBtnMoFile.Text = "Mở File";
            tsBtnMoFile.ToolTipText = "Mở file dữ liệu";
            tsBtnMoFile.Click += new System.EventHandler(menuOpenFile_Click);

            tsBtnLuuBaoCao.Text = "Lưu Báo Cáo";
            tsBtnLuuBaoCao.ToolTipText = "Lưu báo cáo CSV";
            tsBtnLuuBaoCao.Click += new System.EventHandler(menuSaveReport_Click);

            tsBtnImport.Text = "Import";
            tsBtnImport.ToolTipText = "Import từ CSV";
            tsBtnImport.Click += new System.EventHandler(menuImportCsv_Click);

            tsBtnExport.Text = "Export";
            tsBtnExport.ToolTipText = "Export ra CSV";
            tsBtnExport.Click += new System.EventHandler(menuExportCsv_Click);

            tsBtnThoat.Text = "Thoát";
            tsBtnThoat.ToolTipText = "Thoát ứng dụng";
            tsBtnThoat.Click += new System.EventHandler(menuExit_Click);

            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            { tsBtnMoFile, tsBtnLuuBaoCao, tsSep1, tsBtnImport, tsBtnExport, tsSep2, tsBtnThoat });

            // ==================== STATUSSTRIP ====================
            lblTongSoLuong.Text = "Tổng SL: 0";
            lblTongSoLuong.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblSepStatus1.Text = " | ";
            lblTongGiaTri.Text = "Tổng giá trị: 0 VNĐ";
            lblTongGiaTri.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblSepStatus2.Text = " | ";
            lblThoiGian.Text = System.DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            lblThoiGian.Spring = true;
            lblThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            { lblTongSoLuong, lblSepStatus1, lblTongGiaTri, lblSepStatus2, lblThoiGian });

            // ==================== grpInput ====================
            grpInput.SuspendLayout();
            grpInput.Text = "Thông tin sản phẩm";
            grpInput.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpInput.Location = new System.Drawing.Point(6, 6);
            grpInput.Size = new System.Drawing.Size(380, 210);

            int lx = 12, tx = 140, ty = 22, lh = 34;
            int lw = 120, tw = 220;

            lblProductId.Text = "Mã sản phẩm:"; lblProductId.Location = new System.Drawing.Point(lx, ty); lblProductId.Size = new System.Drawing.Size(lw, 23); lblProductId.Font = new System.Drawing.Font("Segoe UI", 9f); lblProductId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            txtProductId.Location = new System.Drawing.Point(tx, ty); txtProductId.Size = new System.Drawing.Size(110, 23); txtProductId.Font = new System.Drawing.Font("Segoe UI", 9f); txtProductId.ReadOnly = true; txtProductId.BackColor = System.Drawing.Color.WhiteSmoke;

            ty += lh;
            lblProductName.Text = "Tên sản phẩm:"; lblProductName.Location = new System.Drawing.Point(lx, ty); lblProductName.Size = new System.Drawing.Size(lw, 23); lblProductName.Font = new System.Drawing.Font("Segoe UI", 9f); lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            txtProductName.Location = new System.Drawing.Point(tx, ty); txtProductName.Size = new System.Drawing.Size(tw, 23); txtProductName.Font = new System.Drawing.Font("Segoe UI", 9f); txtProductName.Validating += new System.ComponentModel.CancelEventHandler(txtProductName_Validating);

            ty += lh;
            lblCategory.Text = "Loại sản phẩm:"; lblCategory.Location = new System.Drawing.Point(lx, ty); lblCategory.Size = new System.Drawing.Size(lw, 23); lblCategory.Font = new System.Drawing.Font("Segoe UI", 9f); lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            cboCategory.Location = new System.Drawing.Point(tx, ty); cboCategory.Size = new System.Drawing.Size(tw, 23); cboCategory.Font = new System.Drawing.Font("Segoe UI", 9f); cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; cboCategory.Validating += new System.ComponentModel.CancelEventHandler(cboCategory_Validating);

            ty += lh;
            lblPrice.Text = "Đơn giá (VNĐ):"; lblPrice.Location = new System.Drawing.Point(lx, ty); lblPrice.Size = new System.Drawing.Size(lw, 23); lblPrice.Font = new System.Drawing.Font("Segoe UI", 9f); lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            txtPrice.Location = new System.Drawing.Point(tx, ty); txtPrice.Size = new System.Drawing.Size(140, 23); txtPrice.Font = new System.Drawing.Font("Segoe UI", 9f); txtPrice.Validating += new System.ComponentModel.CancelEventHandler(txtPrice_Validating);

            ty += lh;
            lblQuantity.Text = "Số lượng tồn:"; lblQuantity.Location = new System.Drawing.Point(lx, ty); lblQuantity.Size = new System.Drawing.Size(lw, 23); lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9f); lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            numQuantity.Location = new System.Drawing.Point(tx, ty); numQuantity.Size = new System.Drawing.Size(100, 23); numQuantity.Font = new System.Drawing.Font("Segoe UI", 9f); numQuantity.Minimum = 0; numQuantity.Maximum = 99999;

            grpInput.Controls.AddRange(new System.Windows.Forms.Control[]
            { lblProductId, txtProductId, lblProductName, txtProductName, lblCategory, cboCategory, lblPrice, txtPrice, lblQuantity, numQuantity });
            grpInput.ResumeLayout(false);

            // ==================== grpImage ====================
            grpImage.SuspendLayout();
            grpImage.Text = "Hình ảnh sản phẩm";
            grpImage.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpImage.Location = new System.Drawing.Point(6, 224);
            grpImage.Size = new System.Drawing.Size(380, 200);

            picProductImage.Location = new System.Drawing.Point(10, 22);
            picProductImage.Size = new System.Drawing.Size(260, 160);
            picProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picProductImage.BackColor = System.Drawing.Color.WhiteSmoke;

            btnChoAnh.Text = "📷 Chọn ảnh";
            btnChoAnh.Location = new System.Drawing.Point(280, 22);
            btnChoAnh.Size = new System.Drawing.Size(90, 34);
            btnChoAnh.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnChoAnh.BackColor = System.Drawing.Color.Teal;
            btnChoAnh.ForeColor = System.Drawing.Color.White;
            btnChoAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChoAnh.Click += new System.EventHandler(btnChoAnh_Click);

            grpImage.Controls.AddRange(new System.Windows.Forms.Control[] { picProductImage, btnChoAnh });
            grpImage.ResumeLayout(false);

            // ==================== grpButtons ====================
            grpButtons.SuspendLayout();
            grpButtons.Text = "Chức năng";
            grpButtons.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpButtons.Location = new System.Drawing.Point(6, 432);
            grpButtons.Size = new System.Drawing.Size(380, 54);

            int bx = 8, bw = 64, bh = 30;
            void MakeBtn(System.Windows.Forms.Button b, string txt, System.Drawing.Color clr, int x, System.EventHandler ev)
            {
                b.Text = txt; b.Location = new System.Drawing.Point(x, 18); b.Size = new System.Drawing.Size(bw, bh);
                b.Font = new System.Drawing.Font("Segoe UI", 8.5f); b.BackColor = clr; b.ForeColor = System.Drawing.Color.White;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat; b.Click += ev;
            }
            MakeBtn(btnAdd, "➕ Thêm", System.Drawing.Color.ForestGreen, bx, btnAdd_Click); bx += bw + 4;
            MakeBtn(btnUpdate, "✏️ Sửa", System.Drawing.Color.SteelBlue, bx, btnUpdate_Click); bx += bw + 4;
            MakeBtn(btnDelete, "🗑️ Xóa", System.Drawing.Color.Crimson, bx, btnDelete_Click); bx += bw + 4;
            MakeBtn(btnSave, "💾 Lưu", System.Drawing.Color.DarkOrange, bx, btnSave_Click); bx += bw + 4;
            MakeBtn(btnClear, "🔄 Hủy", System.Drawing.Color.Gray, bx, btnClear_Click);

            grpButtons.Controls.AddRange(new System.Windows.Forms.Control[]
            { btnAdd, btnUpdate, btnDelete, btnSave, btnClear });
            grpButtons.ResumeLayout(false);

            // ==================== grpGrid ====================
            grpGrid.SuspendLayout();
            grpGrid.Text = "Danh sách sản phẩm kho";
            grpGrid.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpGrid.Location = new System.Drawing.Point(400, 6);
            grpGrid.Size = new System.Drawing.Size(780, 480);

            dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvProducts.SelectionChanged += new System.EventHandler(dgvProducts_SelectionChanged);

            grpGrid.Controls.Add(dgvProducts);
            grpGrid.ResumeLayout(false);

            // ==================== errorProvider ====================
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;

            // ==================== pnlLeft ====================
            pnlLeft.Location = new System.Drawing.Point(0, 55);
            pnlLeft.Size = new System.Drawing.Size(396, 498);
            pnlLeft.Controls.AddRange(new System.Windows.Forms.Control[] { grpInput, grpImage, grpButtons });

            // ==================== FORM ====================
            this.Text = "Quản lý kho hàng";
            this.ClientSize = new System.Drawing.Size(1196, 580);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainMenuStrip = menuStrip;
            this.Load += new System.EventHandler(frmInventoryManager_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmInventoryManager_FormClosing);

            this.Controls.AddRange(new System.Windows.Forms.Control[]
            { menuStrip, toolStrip, statusStrip, pnlLeft, grpGrid });
        }

        #endregion

        // MenuStrip
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuSaveReport;
        private System.Windows.Forms.ToolStripSeparator menuSepHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuCongCu;
        private System.Windows.Forms.ToolStripMenuItem menuImportCsv;
        private System.Windows.Forms.ToolStripMenuItem menuExportCsv;

        // ToolStrip
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsBtnMoFile;
        private System.Windows.Forms.ToolStripButton tsBtnLuuBaoCao;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripButton tsBtnImport;
        private System.Windows.Forms.ToolStripButton tsBtnExport;
        private System.Windows.Forms.ToolStripSeparator tsSep2;
        private System.Windows.Forms.ToolStripButton tsBtnThoat;

        // StatusStrip
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSoLuong;
        private System.Windows.Forms.ToolStripStatusLabel lblSepStatus1;
        private System.Windows.Forms.ToolStripStatusLabel lblTongGiaTri;
        private System.Windows.Forms.ToolStripStatusLabel lblSepStatus2;
        private System.Windows.Forms.ToolStripStatusLabel lblThoiGian;

        // Panels & Groups
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;

        private System.Windows.Forms.GroupBox grpImage;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnChoAnh;

        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
