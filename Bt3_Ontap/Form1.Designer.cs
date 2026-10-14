namespace Bt3_Ontap
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpInput = new GroupBox();
            txtPrice = new TextBox();
            textBox3 = new TextBox();
            cboUnit = new ComboBox();
            txtItemID = new TextBox();
            txtItemName = new TextBox();
            grpList = new GroupBox();
            lsvItems = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClearAll = new Button();
            grpInput.SuspendLayout();
            grpList.SuspendLayout();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(textBox3);
            grpInput.Controls.Add(cboUnit);
            grpInput.Controls.Add(txtItemID);
            grpInput.Controls.Add(txtItemName);
            grpInput.Location = new Point(106, 27);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(334, 207);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin vật tư";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(6, 126);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Đơn giá nhập";
            txtPrice.Size = new Size(285, 27);
            txtPrice.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(8, 206);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 4;
            // 
            // cboUnit
            // 
            cboUnit.FormattingEnabled = true;
            cboUnit.Location = new Point(6, 92);
            cboUnit.Name = "cboUnit";
            cboUnit.Size = new Size(84, 28);
            cboUnit.TabIndex = 3;
            cboUnit.SelectedIndexChanged += cboUnit_SelectedIndexChanged;
            // 
            // txtItemID
            // 
            txtItemID.Location = new Point(6, 26);
            txtItemID.Name = "txtItemID";
            txtItemID.PlaceholderText = "Mã vật tư";
            txtItemID.Size = new Size(285, 27);
            txtItemID.TabIndex = 1;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(6, 59);
            txtItemName.Name = "txtItemName";
            txtItemName.PlaceholderText = "Tên vật tư";
            txtItemName.Size = new Size(285, 27);
            txtItemName.TabIndex = 2;
            // 
            // grpList
            // 
            grpList.Controls.Add(lsvItems);
            grpList.Location = new Point(529, 27);
            grpList.Name = "grpList";
            grpList.Size = new Size(605, 207);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Danh sách vật tư";
            // 
            // lsvItems
            // 
            lsvItems.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lsvItems.FullRowSelect = true;
            lsvItems.GridLines = true;
            lsvItems.Location = new Point(0, 26);
            lsvItems.Name = "lsvItems";
            lsvItems.Size = new Size(587, 139);
            lsvItems.TabIndex = 0;
            lsvItems.UseCompatibleStateImageBehavior = false;
            lsvItems.View = View.Details;
            lsvItems.SelectedIndexChanged += lsvItems_SelectedIndexChanged_1;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Mã VT";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tên VT";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Đơn vị tính";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Đơn giá";
            columnHeader4.Width = 100;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(322, 297);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(431, 297);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(543, 297);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xóa dòng";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(655, 297);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(94, 29);
            btnClearAll.TabIndex = 5;
            btnClearAll.Text = "Xóa toàn bộ";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 450);
            Controls.Add(btnClearAll);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(grpList);
            Controls.Add(grpInput);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            grpList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInput;
        private TextBox txtItemID;
        private TextBox txtItemName;
        private ComboBox cboUnit;
        private TextBox textBox3;
        private GroupBox grpList;
        private ListView lsvItems;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClearAll;
        private TextBox txtPrice;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}
