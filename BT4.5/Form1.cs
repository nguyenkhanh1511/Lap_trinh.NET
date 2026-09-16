using System;
using System.Drawing;
using System.Windows.Forms;

namespace BT4._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cấu hình giao diện ban đầu nếu cần
            this.MinimumSize = new Size(600, 400); // Đặt kích thước tối thiểu để không bị đè giao diện khi co quá nhỏ
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}