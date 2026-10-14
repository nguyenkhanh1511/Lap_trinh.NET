namespace Bt2_Ontap
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
            txtTicketID = new TextBox();
            txtRequester = new TextBox();
            dtpCreatedDate = new DateTimePicker();
            rdoLow = new RadioButton();
            rdoMedium = new RadioButton();
            rdoHigh = new RadioButton();
            cboCategory = new ComboBox();
            chkDesktop = new CheckBox();
            chkLaptop = new CheckBox();
            chkPrinter = new CheckBox();
            chkPhone = new CheckBox();
            picErrorImage = new PictureBox();
            btnUploadImage = new Button();
            btnSubmit = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)picErrorImage).BeginInit();
            SuspendLayout();
            // 
            // txtTicketID
            // 
            txtTicketID.Location = new Point(122, 53);
            txtTicketID.Name = "txtTicketID";
            txtTicketID.PlaceholderText = "Mã Phiếu";
            txtTicketID.Size = new Size(413, 27);
            txtTicketID.TabIndex = 0;
            // 
            // txtRequester
            // 
            txtRequester.Location = new Point(122, 99);
            txtRequester.Name = "txtRequester";
            txtRequester.PlaceholderText = "Người yêu cầu";
            txtRequester.Size = new Size(413, 27);
            txtRequester.TabIndex = 1;
            // 
            // dtpCreatedDate
            // 
            dtpCreatedDate.CustomFormat = "dd/MM/yyyy";
            dtpCreatedDate.Format = DateTimePickerFormat.Custom;
            dtpCreatedDate.Location = new Point(122, 148);
            dtpCreatedDate.Name = "dtpCreatedDate";
            dtpCreatedDate.Size = new Size(413, 27);
            dtpCreatedDate.TabIndex = 2;
            // 
            // rdoLow
            // 
            rdoLow.AutoSize = true;
            rdoLow.Location = new Point(122, 201);
            rdoLow.Name = "rdoLow";
            rdoLow.Size = new Size(67, 24);
            rdoLow.TabIndex = 3;
            rdoLow.Text = "Thấp ";
            rdoLow.UseVisualStyleBackColor = true;
            // 
            // rdoMedium
            // 
            rdoMedium.AutoSize = true;
            rdoMedium.Checked = true;
            rdoMedium.Location = new Point(275, 201);
            rdoMedium.Name = "rdoMedium";
            rdoMedium.Size = new Size(100, 24);
            rdoMedium.TabIndex = 4;
            rdoMedium.TabStop = true;
            rdoMedium.Text = "Trung bình";
            rdoMedium.UseVisualStyleBackColor = true;
            // 
            // rdoHigh
            // 
            rdoHigh.AutoSize = true;
            rdoHigh.Location = new Point(444, 201);
            rdoHigh.Name = "rdoHigh";
            rdoHigh.Size = new Size(91, 24);
            rdoHigh.TabIndex = 5;
            rdoHigh.Text = "Khẩn cấp";
            rdoHigh.UseVisualStyleBackColor = true;
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(122, 242);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 6;
            // 
            // chkDesktop
            // 
            chkDesktop.AutoSize = true;
            chkDesktop.Location = new Point(123, 294);
            chkDesktop.Name = "chkDesktop";
            chkDesktop.Size = new Size(117, 24);
            chkDesktop.TabIndex = 7;
            chkDesktop.Text = "Máy tính bàn";
            chkDesktop.UseVisualStyleBackColor = true;
            // 
            // chkLaptop
            // 
            chkLaptop.AutoSize = true;
            chkLaptop.Location = new Point(253, 294);
            chkLaptop.Name = "chkLaptop";
            chkLaptop.Size = new Size(78, 24);
            chkLaptop.TabIndex = 8;
            chkLaptop.Text = "Laptop";
            chkLaptop.UseVisualStyleBackColor = true;
            // 
            // chkPrinter
            // 
            chkPrinter.AutoSize = true;
            chkPrinter.Location = new Point(344, 294);
            chkPrinter.Name = "chkPrinter";
            chkPrinter.Size = new Size(75, 24);
            chkPrinter.TabIndex = 9;
            chkPrinter.Text = "Máy in";
            chkPrinter.UseVisualStyleBackColor = true;
            // 
            // chkPhone
            // 
            chkPhone.AutoSize = true;
            chkPhone.Location = new Point(444, 294);
            chkPhone.Name = "chkPhone";
            chkPhone.Size = new Size(100, 24);
            chkPhone.TabIndex = 10;
            chkPhone.Text = "Điện thoại";
            chkPhone.UseVisualStyleBackColor = true;
            // 
            // picErrorImage
            // 
            picErrorImage.Location = new Point(123, 339);
            picErrorImage.Name = "picErrorImage";
            picErrorImage.Size = new Size(125, 62);
            picErrorImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picErrorImage.TabIndex = 11;
            picErrorImage.TabStop = false;
            // 
            // btnUploadImage
            // 
            btnUploadImage.Location = new Point(275, 372);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.Size = new Size(94, 29);
            btnUploadImage.TabIndex = 12;
            btnUploadImage.Text = "Tải ảnh lỗi";
            btnUploadImage.UseVisualStyleBackColor = true;
            btnUploadImage.Click += btnUploadImage_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(117, 424);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Gửi yêu cầu";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(237, 424);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 14;
            btnReset.Text = "Nhập lại";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(btnSubmit);
            Controls.Add(btnUploadImage);
            Controls.Add(picErrorImage);
            Controls.Add(chkPhone);
            Controls.Add(chkPrinter);
            Controls.Add(chkLaptop);
            Controls.Add(chkDesktop);
            Controls.Add(cboCategory);
            Controls.Add(rdoHigh);
            Controls.Add(rdoMedium);
            Controls.Add(rdoLow);
            Controls.Add(dtpCreatedDate);
            Controls.Add(txtRequester);
            Controls.Add(txtTicketID);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picErrorImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTicketID;
        private TextBox txtRequester;
        private DateTimePicker dtpCreatedDate;
        private RadioButton rdoLow;
        private RadioButton rdoMedium;
        private RadioButton rdoHigh;
        private ComboBox cboCategory;
        private CheckBox chkDesktop;
        private CheckBox chkLaptop;
        private CheckBox chkPrinter;
        private CheckBox chkPhone;
        private PictureBox picErrorImage;
        private Button btnUploadImage;
        private Button btnSubmit;
        private Button btnReset;
    }
}
