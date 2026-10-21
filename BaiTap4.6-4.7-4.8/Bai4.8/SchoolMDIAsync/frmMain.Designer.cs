namespace SchoolMDIAsync
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip   = new System.Windows.Forms.MenuStrip();
            toolStrip   = new System.Windows.Forms.ToolStrip();
            statusStrip = new System.Windows.Forms.StatusStrip();

            miHeThong = new System.Windows.Forms.ToolStripMenuItem();
            miDangXuat= new System.Windows.Forms.ToolStripMenuItem();
            miSepHT   = new System.Windows.Forms.ToolStripSeparator();
            miThoat   = new System.Windows.Forms.ToolStripMenuItem();
            miDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            miSinhVien= new System.Windows.Forms.ToolStripMenuItem();
            miSanPham = new System.Windows.Forms.ToolStripMenuItem();
            miCuaSo   = new System.Windows.Forms.ToolStripMenuItem();
            miCascade = new System.Windows.Forms.ToolStripMenuItem();
            miTileH   = new System.Windows.Forms.ToolStripMenuItem();
            miTileV   = new System.Windows.Forms.ToolStripMenuItem();

            tsBtnSinhVien = new System.Windows.Forms.ToolStripButton();
            tsSep1        = new System.Windows.Forms.ToolStripSeparator();
            tsBtnSanPham  = new System.Windows.Forms.ToolStripButton();
            tsSep2        = new System.Windows.Forms.ToolStripSeparator();
            tsBtnThoat    = new System.Windows.Forms.ToolStripButton();

            lblUser        = new System.Windows.Forms.ToolStripStatusLabel();
            lblSep1        = new System.Windows.Forms.ToolStripStatusLabel();
            lblStatus      = new System.Windows.Forms.ToolStripStatusLabel();
            progressParent = new System.Windows.Forms.ToolStripProgressBar();
            lblTime        = new System.Windows.Forms.ToolStripStatusLabel();

            // MenuStrip
            menuStrip.SuspendLayout();
            miDangXuat.Text="🔓 Đăng xuất"; miDangXuat.Click+=new System.EventHandler(menuDangXuat_Click);
            miThoat.Text="🚪 Thoát";        miThoat.Click+=new System.EventHandler(menuThoat_Click);
            miHeThong.Text="Hệ thống";
            miHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{miDangXuat,miSepHT,miThoat});
            miSinhVien.Text="👨‍🎓 Quản lý Sinh viên"; miSinhVien.Click+=new System.EventHandler(menuSinhVien_Click);
            miSanPham.Text="📦 Quản lý Sản phẩm";   miSanPham.Click+=new System.EventHandler(menuSanPham_Click);
            miDanhMuc.Text="Danh mục";
            miDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{miSinhVien,miSanPham});
            miCascade.Text="🗗 Cascade"; miCascade.Click+=new System.EventHandler(menuCascade_Click);
            miTileH.Text="⬛ Tile H";    miTileH.Click+=new System.EventHandler(menuTileH_Click);
            miTileV.Text="⬜ Tile V";    miTileV.Click+=new System.EventHandler(menuTileV_Click);
            miCuaSo.Text="Cửa sổ";
            miCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{miCascade,miTileH,miTileV});
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{miHeThong,miDanhMuc,miCuaSo});
            menuStrip.ResumeLayout(false);

            // ToolStrip
            tsBtnSinhVien.Text="👨‍🎓 Sinh viên"; tsBtnSinhVien.Click+=new System.EventHandler(tsBtnSinhVien_Click);
            tsBtnSanPham.Text="📦 Sản phẩm";   tsBtnSanPham.Click+=new System.EventHandler(tsBtnSanPham_Click);
            tsBtnThoat.Text="🚪 Thoát";          tsBtnThoat.Click+=new System.EventHandler(tsBtnThoat_Click);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{tsBtnSinhVien,tsSep1,tsBtnSanPham,tsSep2,tsBtnThoat});

            // StatusStrip — thêm ProgressBar
            lblUser.Text="👤 Admin"; lblUser.Font=new System.Drawing.Font("Segoe UI",9f,System.Drawing.FontStyle.Bold);
            lblSep1.Text="  |  ";
            lblStatus.Text="Sẵn sàng"; lblStatus.Spring=true;
            progressParent.Width=200; progressParent.Minimum=0; progressParent.Maximum=100;
            progressParent.Visible=false;
            lblTime.Text=System.DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
            lblTime.Font=new System.Drawing.Font("Segoe UI",9f,System.Drawing.FontStyle.Bold);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            { lblUser,lblSep1,lblStatus,progressParent,lblTime });

            this.Text="🏫 Hệ thống Quản lý (Async)";
            this.IsMdiContainer=true;
            this.ClientSize=new System.Drawing.Size(1280,720);
            this.Font=new System.Drawing.Font("Segoe UI",9f);
            this.StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MainMenuStrip=menuStrip;
            this.Load+=new System.EventHandler(frmMain_Load);
            this.FormClosing+=new System.Windows.Forms.FormClosingEventHandler(frmMain_FormClosing);
            this.Controls.AddRange(new System.Windows.Forms.Control[]{menuStrip,toolStrip,statusStrip});
        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem miHeThong,miDangXuat,miThoat;
        private System.Windows.Forms.ToolStripSeparator miSepHT;
        private System.Windows.Forms.ToolStripMenuItem miDanhMuc,miSinhVien,miSanPham;
        private System.Windows.Forms.ToolStripMenuItem miCuaSo,miCascade,miTileH,miTileV;
        private System.Windows.Forms.ToolStripButton tsBtnSinhVien,tsBtnSanPham,tsBtnThoat;
        private System.Windows.Forms.ToolStripSeparator tsSep1,tsSep2;
        private System.Windows.Forms.ToolStripStatusLabel lblUser,lblSep1,lblStatus,lblTime;
        private System.Windows.Forms.ToolStripProgressBar progressParent;
    }
}
