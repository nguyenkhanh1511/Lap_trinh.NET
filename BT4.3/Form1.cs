using System;
using System.Windows.Forms;

namespace BT4._3
{
    public partial class Form1 : Form
    {
        // Các biến lưu trữ số thứ nhất và phép toán
        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. EVENT HANDLER CHUNG CHO 10 NÚT BẤM SỐ (btn0 -> btn9)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            // Xóa số 0 mặc định hoặc chuẩn bị màn hình mới sau khi bấm phép toán
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;

            // Ép kiểu sender về Button để lấy con số ghi trên bề mặt nút bấm
            Button btn = (Button)sender;

            // Nối chuỗi chữ số vào TextBox hiển thị
            txtDisplay.Text += btn.Text;
        }

        // 2. Event Handler chung cho các nút phép toán (+, -, *, /)
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (resultValue != 0)
            {
                btnEqual.PerformClick();
                operationPerformed = btn.Text;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = btn.Text;
                resultValue = double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
        }

        // 3. Xử lý nút xóa C (btnClear)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // 4. Xử lý nút Bằng = (btnEqual)
        private void btnEqual_Click(object sender, EventArgs e)
        {
            double secondNum = double.Parse(txtDisplay.Text);

            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + secondNum).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - secondNum).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * secondNum).ToString();
                    break;
                case "/":
                    if (secondNum != 0)
                        txtDisplay.Text = (resultValue / secondNum).ToString();
                    else
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(txtDisplay.Text);
            operationPerformed = "";
        }
    }
}