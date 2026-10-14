using System;
using System.Windows.Forms;

namespace Bt1_Ontap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Sự kiện Click cho nút "Tính tiền" (btnCalculate)
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // --- VALIDATE DỮ LIỆU NHẬP LIỆU ---

            // Kiểm tra Đơn giá dịch vụ (phải là số và >= 0)
            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal unitPrice) || unitPrice < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá dịch vụ hợp lệ (là số không âm)!", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitPrice.Focus();
                txtUnitPrice.SelectAll();
                return;
            }

            // Kiểm tra Số lượng khách (phải là số nguyên > 0)
            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng khách hợp lệ (là số nguyên lớn hơn 0)!", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                txtQuantity.SelectAll();
                return;
            }

            // Kiểm tra Phần trăm giảm giá (nếu để trống coi như = 0, phải từ 0 đến 100)
            string discountInput = string.IsNullOrWhiteSpace(txtDiscount.Text) ? "0" : txtDiscount.Text.Trim();
            if (!decimal.TryParse(discountInput, out decimal discountPercent) || discountPercent < 0 || discountPercent > 100)
            {
                MessageBox.Show("Phần trăm giảm giá không hợp lệ (phải nằm trong khoảng từ 0% đến 100%)!", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                txtDiscount.SelectAll();
                return;
            }

            // --- TÍNH TOÁN THEO CÔNG THỨC ĐỀ BÀI ---
            // Công thức: Tổng tiền = (Đơn giá * Số lượng) * ((100 - % Giảm) / 100)
            decimal total = (unitPrice * quantity) * (100 - discountPercent) / 100;

            // Display kết quả định dạng phân cách hàng nghìn VNĐ
            lblTotal.Text = $"Tổng tiền: {total:N0} VNĐ";
        }

        // 2. Sự kiện Click cho nút "Làm mới" (btnReset)
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            txtDiscount.Text = "0";
            lblTotal.Text = "Tổng tiền: 0 VNĐ";

            // Di chuyển con trỏ nhập liệu về ô Đơn giá
            txtUnitPrice.Focus();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {

        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}