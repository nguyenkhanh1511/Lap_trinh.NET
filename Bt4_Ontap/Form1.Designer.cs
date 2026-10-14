namespace Bt4_Ontap
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
            flpSeats = new FlowLayoutPanel();
            cboTimeSlot = new ComboBox();
            lblSelectedCount = new Label();
            lblTotalPrice = new Label();
            btnConfirm = new Button();
            btnCancelAll = new Button();
            SuspendLayout();
            // 
            // flpSeats
            // 
            flpSeats.Dock = DockStyle.Left;
            flpSeats.Location = new Point(0, 0);
            flpSeats.Name = "flpSeats";
            flpSeats.Size = new Size(460, 693);
            flpSeats.TabIndex = 0;
            // 
            // cboTimeSlot
            // 
            cboTimeSlot.FormattingEnabled = true;
            cboTimeSlot.Location = new Point(484, 12);
            cboTimeSlot.Name = "cboTimeSlot";
            cboTimeSlot.Size = new Size(214, 28);
            cboTimeSlot.TabIndex = 1;
            cboTimeSlot.Text = "Khung Giờ";
            cboTimeSlot.SelectedIndexChanged += cboTimeSlot_SelectedIndexChanged;
            // 
            // lblSelectedCount
            // 
            lblSelectedCount.AutoSize = true;
            lblSelectedCount.Location = new Point(484, 65);
            lblSelectedCount.Name = "lblSelectedCount";
            lblSelectedCount.Size = new Size(148, 20);
            lblSelectedCount.TabIndex = 2;
            lblSelectedCount.Text = "Số vị trí đang chọn: 0";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(484, 108);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(146, 20);
            lblTotalPrice.TabIndex = 3;
            lblTotalPrice.Text = "Tạm tính tiền: 0 VNĐ";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(484, 147);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Xác nhận đặt";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancelAll
            // 
            btnCancelAll.Location = new Point(604, 147);
            btnCancelAll.Name = "btnCancelAll";
            btnCancelAll.Size = new Size(94, 29);
            btnCancelAll.TabIndex = 5;
            btnCancelAll.Text = "Hủy chọn tất cả";
            btnCancelAll.UseVisualStyleBackColor = true;
            btnCancelAll.Click += btnCancelAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1347, 693);
            Controls.Add(cboTimeSlot);
            Controls.Add(lblSelectedCount);
            Controls.Add(flpSeats);
            Controls.Add(lblTotalPrice);
            Controls.Add(btnCancelAll);
            Controls.Add(btnConfirm);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpSeats;
        private ComboBox cboTimeSlot;
        private Label lblSelectedCount;
        private Label lblTotalPrice;
        private Button btnConfirm;
        private Button btnCancelAll;
    }
}
