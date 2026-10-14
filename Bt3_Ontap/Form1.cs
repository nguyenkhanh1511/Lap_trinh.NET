using System;
using System.Windows.Forms;
namespace Bt3_Ontap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khởi tạo danh sách Đơn vị tính và cấu hình ListView khi Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            cboUnit.Items.Clear();
            cboUnit.Items.AddRange(new object[] { "Cái", "Bộ", "Kg", "Mét" });
            cboUnit.SelectedIndex = 0;
        }

        // 2. Nút "Thêm mới" - Kiểm tra trùng Mã VT và thêm vào ListView
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string itemID = txtItemID.Text.Trim();

            // Kiểm tra trùng Mã VT
            foreach (ListViewItem item in lsvItems.Items)
            {
                if (item.Text.Equals(itemID, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã vật tư này đã tồn tại trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtItemID.Focus();
                    return;
                }
            }

            // Thêm dòng mới đúng thứ tự 4 cột:
            // Cột 0: Mã VT
            ListViewItem newItem = new ListViewItem(itemID);

            // Cột 1: Tên VT
            newItem.SubItems.Add(txtItemName.Text.Trim());

            // Cột 2: Đơn vị tính (Lấy giá trị từ ComboBox)
            newItem.SubItems.Add(cboUnit.SelectedItem != null ? cboUnit.SelectedItem.ToString() : cboUnit.Text);

            // Cột 3: Đơn giá
            decimal price = decimal.Parse(txtPrice.Text.Trim());
            newItem.SubItems.Add(price.ToString("N0"));

            lsvItems.Items.Add(newItem);
            ClearInput();
        }

        // 3. Sự kiện chọn (Select) 1 dòng trong ListView -> Đẩy dữ liệu ngược lên ô nhập
        private void lsvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvItems.SelectedItems[0];

                txtItemID.Text = selectedItem.SubItems[0].Text;
                txtItemName.Text = selectedItem.SubItems[1].Text;
                cboUnit.SelectedItem = selectedItem.SubItems[2].Text;

                // Loại bỏ định dạng dấu phẩy phân cách tiền để hiển thị vào TextBox
                string rawPrice = selectedItem.SubItems[3].Text.Replace(",", "").Replace(".", "");
                txtPrice.Text = rawPrice;

                txtItemID.Enabled = false; // Không cho phép sửa Mã VT khi đang chọn cập nhật
            }
        }

        // 4. Nút "Cập nhật" - Sửa thông tin dòng đang được chọn
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng vật tư cần cập nhật trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput()) return;

            ListViewItem selectedItem = lsvItems.SelectedItems[0];
            selectedItem.SubItems[1].Text = txtItemName.Text.Trim();

            decimal price = decimal.Parse(txtPrice.Text.Trim());
            selectedItem.SubItems[3].Text = price.ToString("N0");

            MessageBox.Show("Cập nhật thông tin vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInput();
        }

        // 5. Nút "Xóa dòng" - Xác nhận Yes/No trước khi xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa vật tư đang chọn không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                lsvItems.Items.Remove(lsvItems.SelectedItems[0]);
                ClearInput();
            }
        }

        // 6. Nút "Xóa toàn bộ" - Xóa hết các dòng trong ListView
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (lsvItems.Items.Count == 0) return;

            DialogResult dialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa TOÀN BỘ danh sách vật tư không?",
                "Cảnh báo xóa toàn bộ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult == DialogResult.Yes)
            {
                lsvItems.Items.Clear();
                ClearInput();
            }
        }

        // --- HÀM BỔ TRỢ VALIDATE VÀ XÓA TRẮNG DỮ LIỆU ---

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtItemID.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã vật tư!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên vật tư!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá hợp lệ (số không âm)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            txtItemID.Clear();
            txtItemName.Clear();
            txtPrice.Clear();
            if (cboUnit.Items.Count > 0) cboUnit.SelectedIndex = 0;

            txtItemID.Enabled = true; // Mở lại ô Mã VT
            txtItemID.Focus();
        }

        private void lsvItems_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            {
                cboUnit.Items.Clear();
                cboUnit.Items.AddRange(new object[] { "Cái", "Bộ", "Kg", "Mét" });
                cboUnit.SelectedIndex = 0; // Tự động chọn "Cái" mặc định
            }
        }
    }
}