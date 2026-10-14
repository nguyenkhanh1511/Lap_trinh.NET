using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bt4_Ontap
{
    public partial class Form1 : Form
    {
        // Danh sách lưu 20 nút ghế
        private List<Button> listSeatButtons = new List<Button>();

        // Màu sắc trạng thái
        private readonly Color COLOR_EMPTY = Color.LightGray;    // Trống / Chưa chọn
        private readonly Color COLOR_SELECTED = Color.LightGreen; // Đang chọn
        private readonly Color COLOR_BOOKED = Color.IndianRed;   // Đã đặt / Đã khóa

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khởi tạo danh sách khi Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox Khung giờ
            cboTimeSlot.Items.Clear();
            cboTimeSlot.Items.Add("Sáng (100.000đ/vị trí)");
            cboTimeSlot.Items.Add("Tối (150.000đ/vị trí)");
            cboTimeSlot.SelectedIndex = 0;

            // Xóa sạch control cũ
            flpSeats.Controls.Clear();
            listSeatButtons.Clear();

            // Vòng lặp for sinh 20 Button vị trí
            for (int i = 1; i <= 20; i++)
            {
                Button btnSeat = new Button
                {
                    Text = $"Vị trí {i}",
                    Width = 80,   // Chiều rộng nút
                    Height = 55,  // Chiều cao nút
                    Margin = new Padding(5),
                    BackColor = COLOR_EMPTY,
                    Tag = false   // false: Chưa chọn, true: Đang chọn
                };

                // Giả lập vị trí 3 và 12 đã có người đặt trước (Đã khóa)
                if (i == 3 || i == 12)
                {
                    btnSeat.BackColor = COLOR_BOOKED;
                    btnSeat.Enabled = false; // Khóa nút
                }
                else
                {
                    // Gán CHUNG 1 hàm sự kiện Click cho tất cả nút
                    btnSeat.Click += SeatButton_Click;
                }

                listSeatButtons.Add(btnSeat);
                flpSeats.Controls.Add(btnSeat); // Thêm vào FlowLayoutPanel
            }

            UpdateStats();
        }

        // 2. Hàm xử lý dùng chung khi Click vào bất kỳ ghế nào
        private void SeatButton_Click(object? sender, EventArgs e)
        {
            Button? btnSeat = sender as Button;
            if (btnSeat == null) return;

            bool isSelected = btnSeat.Tag is bool b && b;

            if (!isSelected)
            {
                btnSeat.BackColor = COLOR_SELECTED; // Chuyển sang Xanh lá
                btnSeat.Tag = true;
            }
            else
            {
                btnSeat.BackColor = COLOR_EMPTY;    // Trả về Trắng/Xám nhạt
                btnSeat.Tag = false;
            }

            UpdateStats(); // Cập nhật thống kê realtime
        }

        // 3. Sự kiện thay đổi Khung giờ -> Cập nhật tính tiền
        private void cboTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStats();
        }

        // 4. Cập nhật số lượng ghế chọn và tính tiền realtime
        private void UpdateStats()
        {
            int selectedCount = 0;

            foreach (Button btn in listSeatButtons)
            {
                if (btn.Enabled && btn.Tag is bool isSel && isSel)
                {
                    selectedCount++;
                }
            }

            // Đơn giá theo khung giờ
            decimal pricePerSeat = cboTimeSlot.SelectedIndex == 0 ? 100000m : 150000m;
            decimal totalPrice = selectedCount * pricePerSeat;

            lblSelectedCount.Text = $"Số vị trí đang chọn: {selectedCount}";
            lblTotalPrice.Text = $"Tạm tính tiền: {totalPrice:N0} VNĐ";
        }

        // 5. Nút "Xác nhận đặt"
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Button btn in listSeatButtons)
            {
                if (btn.Enabled && btn.Tag is bool isSel && isSel)
                {
                    btn.BackColor = COLOR_BOOKED; // Đổi sang Đỏ
                    btn.Enabled = false;          // Khóa ghế
                    btn.Tag = false;
                    count++;
                }
            }

            if (count > 0)
            {
                MessageBox.Show($"Xác nhận đặt thành công {count} vị trí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStats();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 vị trí trước khi bấm xác nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 6. Nút "Hủy chọn tất cả"
        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            foreach (Button btn in listSeatButtons)
            {
                if (btn.Enabled && btn.Tag is bool isSel && isSel)
                {
                    btn.BackColor = COLOR_EMPTY;
                    btn.Tag = false;
                }
            }

            UpdateStats();
        }
    }
}