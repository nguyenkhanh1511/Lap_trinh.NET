using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BT4._2
{
    // 1. ĐẶT FORM1 LÊN ĐẦU FILE
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mtxtPhone.Mask = "(000) 000-0000";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";

            List<Course> listCourses = new List<Course>
            {
                new Course("CS01", "Lập trình C# WinForms"),
                new Course("CS02", "Lập trình Web ASP.NET Core"),
                new Course("CS03", "Phân tích dữ liệu với Python"),
                new Course("CS04", "Thiết kế CSDL SQL Server")
            };

            cboCourse.DataSource = listCourses;
            cboCourse.DisplayMember = "CourseName";
            cboCourse.ValueMember = "CourseId";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!mtxtPhone.MaskCompleted)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtPhone.Focus();
                return;
            }

            string gender = rdoMale.Checked ? "Nam" : "Nữ";
            string birthDate = dtpBirthDate.Value.ToString("dd/MM/yyyy");
            string selectedCourseName = cboCourse.Text;
            string selectedCourseId = cboCourse.SelectedValue?.ToString() ?? "";
            string scholarshipStatus = chkScholarship.Checked ? "Có" : "Không";

            string info = $"THÔNG TIN ĐĂNG KÝ HỌC\n" +
                          $"--------------------------------\n" +
                          $"Họ và tên: {txtName.Text.Trim()}\n" +
                          $"Ngày sinh: {birthDate}\n" +
                          $"Giới tính: {gender}\n" +
                          $"Số điện thoại: {mtxtPhone.Text}\n" +
                          $"Khóa học: {selectedCourseName} (Mã: {selectedCourseId})\n" +
                          $"Nhận học bổng: {scholarshipStatus}";

            MessageBox.Show(info, "Kết quả đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }

    // 2. CHUYỂN CLASS COURSE XUỐNG DƯỚI NÀY
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }

        public Course(string id, string name)
        {
            CourseId = id;
            CourseName = name;
        }
    }
}