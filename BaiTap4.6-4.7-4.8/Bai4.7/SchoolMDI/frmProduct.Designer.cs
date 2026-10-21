namespace SchoolMDI
{
    partial class frmProduct
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

            grpInput      = new System.Windows.Forms.GroupBox();
            lblId         = new System.Windows.Forms.Label();
            txtProductId  = new System.Windows.Forms.TextBox();
            lblName       = new System.Windows.Forms.Label();
            txtProductName= new System.Windows.Forms.TextBox();
            lblCategory   = new System.Windows.Forms.Label();
            cboCategory   = new System.Windows.Forms.ComboBox();
            lblPrice      = new System.Windows.Forms.Label();
            txtPrice      = new System.Windows.Forms.TextBox();
            lblQty        = new System.Windows.Forms.Label();
            numQuantity   = new System.Windows.Forms.NumericUpDown();
            pnlButtons    = new System.Windows.Forms.Panel();
            btnAdd        = new System.Windows.Forms.Button();
            btnUpdate     = new System.Windows.Forms.Button();
            btnDelete     = new System.Windows.Forms.Button();
            btnExportCsv  = new System.Windows.Forms.Button();
            grpGrid       = new System.Windows.Forms.GroupBox();
            dgvProducts   = new System.Windows.Forms.DataGridView();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);

            grpInput.SuspendLayout();
            grpInput.Text="Thông tin sản phẩm";
            grpInput.Font=new System.Drawing.Font("Segoe UI",9f,System.Drawing.FontStyle.Bold);
            grpInput.Location=new System.Drawing.Point(6,6); grpInput.Size=new System.Drawing.Size(340,208);

            int lx=10,tx=120,ty=24,gap=36,lw=104,tw=206;
            void Row(System.Windows.Forms.Label l,string t,System.Windows.Forms.Control c,int r){
                l.Text=t; l.Location=new System.Drawing.Point(lx,ty+r*gap); l.Size=new System.Drawing.Size(lw,23);
                l.Font=new System.Drawing.Font("Segoe UI",9f); l.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
                c.Location=new System.Drawing.Point(tx,ty+r*gap); c.Font=new System.Drawing.Font("Segoe UI",9f);
                if(c is System.Windows.Forms.TextBox tb) tb.Size=new System.Drawing.Size(tw,23);
                if(c is System.Windows.Forms.ComboBox cb) cb.Size=new System.Drawing.Size(tw,23);
            }
            Row(lblId,      "Mã sản phẩm:",  txtProductId,   0);
            txtProductId.Size=new System.Drawing.Size(100,23); txtProductId.ReadOnly=true;
            txtProductId.BackColor=System.Drawing.Color.WhiteSmoke;
            Row(lblName,    "Tên sản phẩm:", txtProductName, 1);
            txtProductName.Validating+=new System.ComponentModel.CancelEventHandler(txtProductName_Validating);
            Row(lblCategory,"Danh mục:",     cboCategory,    2);
            cboCategory.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
            Row(lblPrice,   "Đơn giá (VNĐ):",txtPrice,       3);
            txtPrice.Size=new System.Drawing.Size(130,23);
            txtPrice.Validating+=new System.ComponentModel.CancelEventHandler(txtPrice_Validating);
            Row(lblQty,     "Số lượng:",      numQuantity,    4);
            numQuantity.Size=new System.Drawing.Size(100,23); numQuantity.Minimum=0; numQuantity.Maximum=99999;

            grpInput.Controls.AddRange(new System.Windows.Forms.Control[]
            { lblId,txtProductId,lblName,txtProductName,lblCategory,cboCategory,lblPrice,txtPrice,lblQty,numQuantity });
            grpInput.ResumeLayout(false);

            pnlButtons.Location=new System.Drawing.Point(6,222); pnlButtons.Size=new System.Drawing.Size(340,42);
            int bx=0,bw=78,bh=32;
            void Btn(System.Windows.Forms.Button b,string t,System.Drawing.Color c,System.EventHandler ev){
                b.Text=t; b.Location=new System.Drawing.Point(bx,5); b.Size=new System.Drawing.Size(bw,bh);
                b.Font=new System.Drawing.Font("Segoe UI",8.5f); b.BackColor=c; b.ForeColor=System.Drawing.Color.White;
                b.FlatStyle=System.Windows.Forms.FlatStyle.Flat; b.Click+=ev; bx+=bw+4;
            }
            Btn(btnAdd,   "➕ Thêm", System.Drawing.Color.ForestGreen, btnAdd_Click);
            Btn(btnUpdate,"✏️ Sửa",  System.Drawing.Color.SteelBlue,   btnUpdate_Click);
            Btn(btnDelete,"🗑️ Xóa",  System.Drawing.Color.Crimson,     btnDelete_Click);
            btnExportCsv.Text="📤 CSV"; btnExportCsv.Location=new System.Drawing.Point(bx,5);
            btnExportCsv.Size=new System.Drawing.Size(bw+20,bh);
            btnExportCsv.Font=new System.Drawing.Font("Segoe UI",8.5f);
            btnExportCsv.BackColor=System.Drawing.Color.DarkSlateBlue;
            btnExportCsv.ForeColor=System.Drawing.Color.White;
            btnExportCsv.FlatStyle=System.Windows.Forms.FlatStyle.Flat;
            btnExportCsv.Click+=new System.EventHandler(btnExportCsv_Click);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[]{btnAdd,btnUpdate,btnDelete,btnExportCsv});

            grpGrid.SuspendLayout(); grpGrid.Text="Danh sách sản phẩm";
            grpGrid.Font=new System.Drawing.Font("Segoe UI",9f,System.Drawing.FontStyle.Bold);
            grpGrid.Location=new System.Drawing.Point(356,6); grpGrid.Size=new System.Drawing.Size(680,258);
            dgvProducts.Dock=System.Windows.Forms.DockStyle.Fill;
            grpGrid.Controls.Add(dgvProducts); grpGrid.ResumeLayout(false);

            errorProvider.BlinkStyle=System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl=this;

            this.Text="📦 Quản lý Sản phẩm"; this.ClientSize=new System.Drawing.Size(1050,278);
            this.Font=new System.Drawing.Font("Segoe UI",9f); this.BackColor=System.Drawing.Color.WhiteSmoke;
            this.Load+=new System.EventHandler(frmProduct_Load);
            this.Controls.AddRange(new System.Windows.Forms.Control[]{grpInput,pnlButtons,grpGrid});
        }
        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblId,lblName,lblCategory,lblPrice,lblQty;
        private System.Windows.Forms.TextBox txtProductId,txtProductName,txtPrice;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd,btnUpdate,btnDelete,btnExportCsv;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
