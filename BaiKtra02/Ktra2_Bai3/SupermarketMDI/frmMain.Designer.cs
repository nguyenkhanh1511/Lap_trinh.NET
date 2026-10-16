namespace SupermarketMDI
{
    partial class frmMain
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

            menuStrip = new System.Windows.Forms.MenuStrip();

            // Hệ thống
            menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            menuSepHT = new System.Windows.Forms.ToolStripSeparator();
            menuThoat = new System.Windows.Forms.ToolStripMenuItem();

            // Danh mục
            menuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            menuQuanLySanPham = new System.Windows.Forms.ToolStripMenuItem();
            menuBaoCao = new System.Windows.Forms.ToolStripMenuItem();

            // Cửa sổ
            menuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            menuCascade = new System.Windows.Forms.ToolStripMenuItem();
            menuTileH = new System.Windows.Forms.ToolStripMenuItem();
            menuTileV = new System.Windows.Forms.ToolStripMenuItem();

            // StatusStrip
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            lblSep = new System.Windows.Forms.ToolStripStatusLabel();
            lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            progressBar = new System.Windows.Forms.ToolStripProgressBar();

            // ==================== MENU ====================
            menuStrip.SuspendLayout();

            menuDangXuat.Text = "🔓 Đăng xuất";
            menuDangXuat.Click += new System.EventHandler(menuDangXuat_Click);
            menuThoat.Text = "🚪 Thoát";
            menuThoat.Click += new System.EventHandler(menuThoat_Click);
            menuHeThong.Text = "Hệ thống";
            menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            { menuDangXuat, menuSepHT, menuThoat });

            menuQuanLySanPham.Text = "📦 Quản lý Sản phẩm";
            menuQuanLySanPham.Click += new System.EventHandler(menuQuanLySanPham_Click);
            menuBaoCao.Text = "📊 Thống kê Doanh thu";
            menuBaoCao.Click += new System.EventHandler(menuBaoCao_Click);
            menuDanhMuc.Text = "Danh mục";
            menuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            { menuQuanLySanPham, menuBaoCao });

            menuCascade.Text = "🗗 Cascade";
            menuCascade.Click += new System.EventHandler(menuCascade_Click);
            menuTileH.Text = "Tile Horizontal";
            menuTileH.Click += new System.EventHandler(menuTileHorizontal_Click);
            menuTileV.Text = "Tile Vertical";
            menuTileV.Click += new System.EventHandler(menuTileVertical_Click);
            menuCuaSo.Text = "Cửa sổ";
            menuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            { menuCascade, menuTileH, menuTileV });

            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            { menuHeThong, menuDanhMuc, menuCuaSo });
            menuStrip.ResumeLayout(false);

            // ==================== STATUSSTRIP ====================
            lblNguoiDung.Text = "👤 Admin";
            lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblSep.Text = " | ";
            lblTrangThai.Text = "Sẵn sàng";
            lblTrangThai.Spring = true;
            progressBar.Width = 150;
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            progressBar.Visible = false;

            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            { lblNguoiDung, lblSep, lblTrangThai, progressBar });

            // ==================== FORM ====================
            this.Text = "🏪 Hệ thống Quản lý Siêu thị";
            this.IsMdiContainer = true;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MainMenuStrip = menuStrip;
            this.Load += new System.EventHandler(frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmMain_FormClosing);

            this.Controls.AddRange(new System.Windows.Forms.Control[] { menuStrip, statusStrip });
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripSeparator menuSepHT;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.ToolStripMenuItem menuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLySanPham;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem menuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem menuCascade;
        private System.Windows.Forms.ToolStripMenuItem menuTileH;
        private System.Windows.Forms.ToolStripMenuItem menuTileV;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel lblSep;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}
