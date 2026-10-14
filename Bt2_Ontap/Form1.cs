using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bt2_Ontap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Nạp danh sách Loại sự cố vào ComboBox khi Form mở lên
        private void Form1_Load(object sender, EventArgs e)
        {
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Phần cứng");
            cboCategory.Items.Add("Phần mềm");
            cboCategory.Items.Add("Mạng");
            cboCategory.Items.Add("Tài khoản");
            cboCategory.SelectedIndex = 0; // Chọn mặc định món đầu tiên
        }

        // 2. Nút "Tải ảnh lỗi": Mở OpenFileDialog cho phép chọn ảnh (.jpg, .png)
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh chụp lỗi sự cố";
                openFileDialog.Filter = "Tệp hình ảnh (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picErrorImage.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        // 3. Nút "Gửi yêu cầu": Gom toàn bộ thông tin và hiển thị MessageBox
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu nhập liệu cơ bản
            if (string.IsNullOrWhiteSpace(txtTicketID.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã phiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTicketID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequester.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Người yêu cầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRequester.Focus();
                return;
            }

            // Lấy Mức độ ưu tiên từ RadioButton
            string priority = "Thấp";
            if (rdoMedium.Checked) priority = "Trung bình";
            else if (rdoHigh.Checked) priority = "Khẩn cấp";

            // Lấy danh sách Thiết bị ảnh hưởng từ các CheckBox
            List<string> devices = new List<string>();
            if (chkDesktop.Checked) devices.Add("Máy tính bàn");
            if (chkLaptop.Checked) devices.Add("Laptop");
            if (chkPrinter.Checked) devices.Add("Máy in");
            if (chkPhone.Checked) devices.Add("Điện thoại");

            string deviceList = devices.Count > 0 ? string.Join(", ", devices) : "Không chọn";
            string hasImage = picErrorImage.Image != null ? "Đã đính kèm" : "Chưa đính kèm";

            // Tổng hợp thông tin tóm tắt
            string summary = $"--- TÓM TẮT PHIẾU YÊU CẦU IT ---\n\n" +
                             $"• Mã phiếu: {txtTicketID.Text.Trim()}\n" +
                             $"• Người yêu cầu: {txtRequester.Text.Trim()}\n" +
                             $"• Ngày ghi nhận: {dtpCreatedDate.Value:dd/MM/yyyy}\n" +
                             $"• Mức độ ưu tiên: {priority}\n" +
                             $"• Loại sự cố: {cboCategory.SelectedItem}\n" +
                             $"• Thiết bị ảnh hưởng: {deviceList}\n" +
                             $"• Ảnh chụp lỗi: {hasImage}";

            MessageBox.Show(summary, "Xác nhận gửi phiếu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 4. Nút "Nhập lại": Xóa toàn bộ dữ liệu trên Form về trạng thái ban đầu
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTicketID.Clear();
            txtRequester.Clear();
            dtpCreatedDate.Value = DateTime.Now;

            rdoMedium.Checked = true;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;

            chkDesktop.Checked = false;
            chkLaptop.Checked = false;
            chkPrinter.Checked = false;
            chkPhone.Checked = false;

            if (picErrorImage.Image != null)
            {
                picErrorImage.Image.Dispose();
                picErrorImage.Image = null;
            }

            txtTicketID.Focus();
        }
    }
}

