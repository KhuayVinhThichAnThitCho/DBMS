using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.model;
using WindowsFormsApp1.service;

namespace WindowsFormsApp1.view.studentview
{
    public partial class StudentRegisterClassForm : Form
    {
        private StudentService studentService = new StudentService();
        private Guid classId;
        private Student selectedStudent;
        public StudentRegisterClassForm(Guid Id)
        {
            InitializeComponent();
            classId = Id;
        }

        private void StudentRegisterClassForm_Load(object sender, EventArgs e)
        {
            // Khi mở form, disable thông tin học viên
            txtStudentCode.ReadOnly = true;
            txtFullName.ReadOnly = true;
            txtPhone1.ReadOnly = false; // chỉ cho nhập số điện thoại để tìm
            txtEmail.ReadOnly = true;
            txtCurrentLevel.ReadOnly = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tìm học viên!");
                return;
            }

            selectedStudent = studentService.getStudentByPhone(phone);

            if (selectedStudent != null)
            {
                txtStudentCode.Text = selectedStudent.StudentCode;
                txtFullName.Text = selectedStudent.FullName;
                txtEmail.Text = selectedStudent.Email;
                txtCurrentLevel.Text = selectedStudent.CurrentLevel;
            }
            else
            {
                MessageBox.Show("Không tìm thấy học viên, vui lòng tạo mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // TODO: mở form thêm mới học viên nếu cần
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // TODO: lấy student_id từ object bạn sẽ xử lý sau
            // TODO: gọi service để tạo bản ghi enrollment cho classId và studentId

            MessageBox.Show("Đã gửi yêu cầu đăng ký lớp!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
