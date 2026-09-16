using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BT4._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            lstMenu.Items.Add(new MenuItem("Hamburger", 50));
            lstMenu.Items.Add(new MenuItem("Pizza", 120));
            lstMenu.Items.Add(new MenuItem("Gà Rán", 35));
            lstMenu.Items.Add(new MenuItem("Pepsi", 15));

            UpdateTotal();
        }

        // Nút > (btnAdd): Chuyển món từ lstMenu sang lstSelected
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItem != null)
            {
                MenuItem selectedItem = (MenuItem)lstMenu.SelectedItem;

                lstSelected.Items.Add(selectedItem);
                lstMenu.Items.Remove(selectedItem);

                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút < (btnRemove): Xóa món khỏi lstSelected và trả về lstMenu
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem != null)
            {
                MenuItem itemToRemove = (MenuItem)lstSelected.SelectedItem;

                lstMenu.Items.Add(itemToRemove);
                lstSelected.Items.Remove(itemToRemove);

                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần bỏ khỏi danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Cập nhật tổng tiền
        private void UpdateTotal()
        {
            int total = 0;
            foreach (MenuItem item in lstSelected.Items)
            {
                total += item.Price;
            }

            lblTotal.Text = $"Tổng tiền: {total * 1000:N0} VNĐ";
        }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public MenuItem(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price:N0}k";
        }
    }
}