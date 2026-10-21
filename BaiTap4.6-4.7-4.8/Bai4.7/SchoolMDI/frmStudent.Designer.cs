namespace SchoolMDI
{
    partial class frmStudent
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

            grpInput     = new System.Windows.Forms.GroupBox();
            lblId        = new System.Windows.Forms.Label();
            txtStudentId = new System.Windows.Forms.TextBox();
            lblName      = new System.Windows.Forms.Label();
            txtFullName  = new System.Windows.Forms.TextBox();
            lblAge       = new System.Windows.Forms.Label();
            txtAge       = new System.Windows.Forms.TextBox();
            lblGender    = new System.Windows.Forms.Label();
            cboGender    = new System.Windows.Forms.ComboBox();
            grpAvatar    = new System.Windows.Forms.GroupBox();
            picAvatar    = new System.Windows.Forms.PictureBox();
            btnChoAnh    = new System.Windows.Forms.Button();
            pnlButtons   = new System.Windows.Forms.Panel();
            btnAdd       = new System.Windows.Forms.Button();
            btnUpdate    = new System.Windows.Forms.Button();
            btnDelete    = new System.Windows.Forms.Button();
            btnExportCsv = new System.Windows.Forms.Button();
            grpGrid      = new System.Windows.Forms.GroupBox();
            dgvStudents  = new System.Windows.Forms.DataGridView();
            errorProvider= new System.Windows.Forms.ErrorProvider(components);

            grpInput.SuspendLayout();
            grpInput.Text = "Thông tin sinh viên";
            grpInput.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpInput.Location = new System.Drawing.Point(6, 6);
            grpInput.Size = new System.Drawing.Size(350, 178);

            int lx=10, tx=118, ty=24, gap=34, lw=102, tw=218;
            void Row(System.Windows.Forms.Label l, string t, System.Windows.Forms.Control c, int r) {
                l.Text=t; l.Location=new System.Drawing.Point(lx,ty+r*gap); l.Size=new System.Drawing.Size(lw,23);
                l.Font=new System.Drawing.Font("Segoe UI",9f); l.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
                c.Location=new System.Drawing.Point(tx,ty+r*gap); c.Font=new System.Drawing.Font("Segoe UI",9f);
                if(c is System.Windows.Forms.TextBox tb) tb.Size=new System.Drawing.Size(tw,23);
                if(c is System.Windows.Forms.ComboBox cb) cb.Size=new System.Drawing.Size(tw,23);
            }
            Row(lblId,    "Mã sinh viên:", txtStudentId, 0);
            txtStudentId.Size=new System.Drawing.Size(100,23); txtStudentId.ReadOnly=true;
            txtStudentId.BackColor=System.Drawing.Color.WhiteSmoke;
            Row(lblName,  "Họ tên:",       txtFullName,  1);
            txtFullName.Validating += new System.ComponentModel.CancelEventHandler(txtFullName_Validating);
            Row(lblAge,   "Tuổi:",          txtAge,       2);
            txtAge.Size=new System.Drawing.Size(60,23);
            txtAge.Validating += new System.ComponentModel.CancelEventHandler(txtAge_Validating);
            Row(lblGender,"Giới tính:",    cboGender,    3);
            cboGender.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;

            grpInput.Controls.AddRange(new System.Windows.Forms.Control[]
            { lblId,txtStudentId,lblName,txtFullName,lblAge,txtAge,lblGender,cboGender });
            grpInput.ResumeLayout(false);

            grpAvatar.SuspendLayout();
            grpAvatar.Text="Ảnh đại diện"; grpAvatar.Font=new System.Drawing.Font("Segoe UI",9f,System.Drawing.FontStyle.Bold);
            grpAvatar.Location=new System.Drawing.Point(6,192); grpAvatar.Size=new System.Drawing.Size(350,196);
            picAvatar.Location=new System.Drawing.Point(10,22); picAvatar.Size=new System.Drawing.Size(210,164);
            picAvatar.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            picAvatar.SizeMode=System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picAvatar.BackColor=System.Drawing.Color.WhiteSmoke;
            btnChoAnh.Text="📷 Chọn ảnh"; btnChoAnh.Location=new System.Drawing.Point(230,22);
            btnChoAnh.Size=new System.Drawing.Size(108,36); btnChoAnh.Font=new System.Drawing.Font("Segoe UI",9f);
            btnChoAnh.BackColor=System.Drawing.Color.Teal; btnChoAnh.ForeColor=System.Drawing.Color.White;
            btnChoAnh.FlatStyle=System.Windows.Forms.FlatStyle.Flat;
            btnChoAnh.Click+=new System.EventHandler(btnChoAnh_Click);
            grpAvatar.Controls.AddRange(new System.Windows.Forms.Control[]{picAvatar,btnChoAnh});
            grpAvatar.ResumeLayout(false);

            pnlButtons.Location=new System.Drawing.Point(6,396); pnlButtons.Size=new System.Drawing.Size(350,42);
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

            grpGrid.SuspendLayout(); grpGrid.Text="Danh sách sinh viên";
            grpGrid.Font=new System.Drawing.Font("Segoe UI",9f,System.Drawing.FontStyle.Bold);
            grpGrid.Location=new System.Drawing.Point(366,6); grpGrid.Size=new System.Drawing.Size(680,432);
            dgvStudents.Dock=System.Windows.Forms.DockStyle.Fill;
            grpGrid.Controls.Add(dgvStudents); grpGrid.ResumeLayout(false);

            errorProvider.BlinkStyle=System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl=this;

            this.Text="👨‍🎓 Quản lý Sinh viên"; this.ClientSize=new System.Drawing.Size(1060,452);
            this.Font=new System.Drawing.Font("Segoe UI",9f); this.BackColor=System.Drawing.Color.WhiteSmoke;
            this.Load+=new System.EventHandler(frmStudent_Load);
            this.Controls.AddRange(new System.Windows.Forms.Control[]{grpInput,grpAvatar,pnlButtons,grpGrid});
        }
        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblId,lblName,lblAge,lblGender;
        private System.Windows.Forms.TextBox txtStudentId,txtFullName,txtAge;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.GroupBox grpAvatar;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChoAnh;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd,btnUpdate,btnDelete,btnExportCsv;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
