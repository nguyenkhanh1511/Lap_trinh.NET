namespace DeviceManager
{
    partial class frmDeviceManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // --- Controls ---
            grpInput = new System.Windows.Forms.GroupBox();
            lblDeviceId = new System.Windows.Forms.Label();
            txtDeviceId = new System.Windows.Forms.TextBox();
            lblDeviceName = new System.Windows.Forms.Label();
            txtDeviceName = new System.Windows.Forms.TextBox();
            lblCategory = new System.Windows.Forms.Label();
            cboCategory = new System.Windows.Forms.ComboBox();
            lblPrice = new System.Windows.Forms.Label();
            txtPrice = new System.Windows.Forms.TextBox();
            lblQuantity = new System.Windows.Forms.Label();
            numQuantity = new System.Windows.Forms.NumericUpDown();

            grpButtons = new System.Windows.Forms.GroupBox();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            grpGrid = new System.Windows.Forms.GroupBox();
            dgvDevices = new System.Windows.Forms.DataGridView();

            errorProvider = new System.Windows.Forms.ErrorProvider(components);

            // ===================== grpInput =====================
            grpInput.SuspendLayout();
            grpInput.Text = "Thông tin thiết bị";
            grpInput.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpInput.Location = new System.Drawing.Point(12, 12);
            grpInput.Size = new System.Drawing.Size(420, 220);
            grpInput.TabIndex = 0;

            // lblDeviceId
            lblDeviceId.Text = "Mã thiết bị:";
            lblDeviceId.Location = new System.Drawing.Point(12, 28);
            lblDeviceId.Size = new System.Drawing.Size(110, 23);
            lblDeviceId.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblDeviceId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // txtDeviceId
            txtDeviceId.Location = new System.Drawing.Point(130, 28);
            txtDeviceId.Size = new System.Drawing.Size(120, 23);
            txtDeviceId.Font = new System.Drawing.Font("Segoe UI", 9f);
            txtDeviceId.ReadOnly = true;
            txtDeviceId.BackColor = System.Drawing.Color.WhiteSmoke;
            txtDeviceId.TabIndex = 0;

            // lblDeviceName
            lblDeviceName.Text = "Tên thiết bị:";
            lblDeviceName.Location = new System.Drawing.Point(12, 62);
            lblDeviceName.Size = new System.Drawing.Size(110, 23);
            lblDeviceName.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // txtDeviceName
            txtDeviceName.Location = new System.Drawing.Point(130, 62);
            txtDeviceName.Size = new System.Drawing.Size(260, 23);
            txtDeviceName.Font = new System.Drawing.Font("Segoe UI", 9f);
            txtDeviceName.TabIndex = 1;
            txtDeviceName.Validating += new System.ComponentModel.CancelEventHandler(txtDeviceName_Validating);

            // lblCategory
            lblCategory.Text = "Loại thiết bị:";
            lblCategory.Location = new System.Drawing.Point(12, 96);
            lblCategory.Size = new System.Drawing.Size(110, 23);
            lblCategory.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // cboCategory
            cboCategory.Location = new System.Drawing.Point(130, 96);
            cboCategory.Size = new System.Drawing.Size(260, 23);
            cboCategory.Font = new System.Drawing.Font("Segoe UI", 9f);
            cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboCategory.TabIndex = 2;
            cboCategory.Validating += new System.ComponentModel.CancelEventHandler(cboCategory_Validating);

            // lblPrice
            lblPrice.Text = "Đơn giá (VNĐ):";
            lblPrice.Location = new System.Drawing.Point(12, 130);
            lblPrice.Size = new System.Drawing.Size(110, 23);
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // txtPrice
            txtPrice.Location = new System.Drawing.Point(130, 130);
            txtPrice.Size = new System.Drawing.Size(150, 23);
            txtPrice.Font = new System.Drawing.Font("Segoe UI", 9f);
            txtPrice.TabIndex = 3;
            txtPrice.Validating += new System.ComponentModel.CancelEventHandler(txtPrice_Validating);

            // lblQuantity
            lblQuantity.Text = "Số lượng tồn:";
            lblQuantity.Location = new System.Drawing.Point(12, 164);
            lblQuantity.Size = new System.Drawing.Size(110, 23);
            lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // numQuantity
            numQuantity.Location = new System.Drawing.Point(130, 164);
            numQuantity.Size = new System.Drawing.Size(100, 23);
            numQuantity.Font = new System.Drawing.Font("Segoe UI", 9f);
            numQuantity.Minimum = 0;
            numQuantity.Maximum = 99999;
            numQuantity.TabIndex = 4;

            grpInput.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblDeviceId, txtDeviceId,
                lblDeviceName, txtDeviceName,
                lblCategory, cboCategory,
                lblPrice, txtPrice,
                lblQuantity, numQuantity
            });
            grpInput.ResumeLayout(false);

            // ===================== grpButtons =====================
            grpButtons.SuspendLayout();
            grpButtons.Text = "Chức năng";
            grpButtons.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpButtons.Location = new System.Drawing.Point(444, 12);
            grpButtons.Size = new System.Drawing.Size(160, 220);
            grpButtons.TabIndex = 1;

            // btnAdd
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.Location = new System.Drawing.Point(14, 28);
            btnAdd.Size = new System.Drawing.Size(130, 34);
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.TabIndex = 0;
            btnAdd.Click += new System.EventHandler(btnAdd_Click);

            // btnUpdate
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.Location = new System.Drawing.Point(14, 72);
            btnUpdate.Size = new System.Drawing.Size(130, 34);
            btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            btnUpdate.ForeColor = System.Drawing.Color.White;
            btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdate.TabIndex = 1;
            btnUpdate.Click += new System.EventHandler(btnUpdate_Click);

            // btnDelete
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.Location = new System.Drawing.Point(14, 116);
            btnDelete.Size = new System.Drawing.Size(130, 34);
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnDelete.BackColor = System.Drawing.Color.Crimson;
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.TabIndex = 2;
            btnDelete.Click += new System.EventHandler(btnDelete_Click);

            // btnSave
            btnSave.Text = "💾 Lưu";
            btnSave.Location = new System.Drawing.Point(14, 28);
            btnSave.Size = new System.Drawing.Size(130, 34);
            btnSave.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnSave.BackColor = System.Drawing.Color.DarkOrange;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.TabIndex = 5;
            btnSave.Visible = true;
            btnSave.Click += new System.EventHandler(btnSave_Click);

            // btnClear
            btnClear.Text = "🔄 Hủy / Làm mới";
            btnClear.Location = new System.Drawing.Point(14, 160);
            btnClear.Size = new System.Drawing.Size(130, 34);
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnClear.BackColor = System.Drawing.Color.Gray;
            btnClear.ForeColor = System.Drawing.Color.White;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.TabIndex = 3;
            btnClear.Click += new System.EventHandler(btnClear_Click);

            grpButtons.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                btnAdd, btnUpdate, btnDelete, btnSave, btnClear
            });
            grpButtons.ResumeLayout(false);

            // ===================== grpGrid =====================
            grpGrid.SuspendLayout();
            grpGrid.Text = "Danh sách thiết bị";
            grpGrid.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpGrid.Location = new System.Drawing.Point(12, 244);
            grpGrid.Size = new System.Drawing.Size(592, 310);
            grpGrid.TabIndex = 2;

            // dgvDevices
            dgvDevices.Location = new System.Drawing.Point(10, 22);
            dgvDevices.Size = new System.Drawing.Size(572, 278);
            dgvDevices.TabIndex = 0;
            dgvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvDevices.SelectionChanged += new System.EventHandler(dgvDevices_SelectionChanged);

            grpGrid.Controls.Add(dgvDevices);
            grpGrid.ResumeLayout(false);

            // ===================== errorProvider =====================
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;

            // ===================== Form =====================
            this.Text = "Quản lý danh mục thiết bị điện tử";
            this.ClientSize = new System.Drawing.Size(616, 566);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(frmDeviceManager_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                grpInput, grpButtons, grpGrid
            });
        }

        #endregion

        // Controls
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;

        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvDevices;

        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
