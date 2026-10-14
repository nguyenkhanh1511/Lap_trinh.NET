namespace Bt1_Ontap
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
            txtUnitPrice = new TextBox();
            txtQuantity = new TextBox();
            lblTotal = new Label();
            btnCalculate = new Button();
            txtDiscount = new TextBox();
            btnReset = new Button();
            SuspendLayout();
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.ForeColor = SystemColors.WindowText;
            txtUnitPrice.Location = new Point(280, 52);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.PlaceholderText = "Nhập đơn giá...";
            txtUnitPrice.Size = new Size(193, 27);
            txtUnitPrice.TabIndex = 0;
            txtUnitPrice.TextChanged += txtUnitPrice_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.ForeColor = SystemColors.WindowText;
            txtQuantity.Location = new Point(280, 96);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PlaceholderText = "Nhập số lượng...";
            txtQuantity.Size = new Size(193, 27);
            txtQuantity.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(398, 195);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(75, 20);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Tổng Tiền";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(379, 246);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(94, 29);
            btnCalculate.TabIndex = 3;
            btnCalculate.Text = "Tính Tiền";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(280, 146);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.PlaceholderText = "Nhập (% giảm)";
            txtDiscount.Size = new Size(193, 27);
            txtDiscount.TabIndex = 4;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(513, 246);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 5;
            btnReset.Text = "Làm Mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(txtDiscount);
            Controls.Add(btnCalculate);
            Controls.Add(lblTotal);
            Controls.Add(txtQuantity);
            Controls.Add(txtUnitPrice);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private Label lblTotal;
        private Button btnCalculate;
        private TextBox txtDiscount;
        private Button btnReset;
    }
}
