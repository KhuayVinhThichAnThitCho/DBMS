using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.view;

namespace WindowsFormsApp1
{
    public partial class EnglishAcademy : Form
    {
        public EnglishAcademy()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            // Xóa control cũ trong panel (nếu có)
            panelMain.Controls.Clear();

            // Khởi tạo form2
            StudentView frm = new StudentView();
            frm.TopLevel = false;              // Quan trọng: không cho form chạy độc lập
            frm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền
            frm.Dock = DockStyle.Fill;         // Fill toàn bộ panel

            // Thêm form2 vào panelMain
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void btn_teacher_Click(object sender, EventArgs e)
        {
            // Xóa control cũ trong panel (nếu có)
            panelMain.Controls.Clear();

            // Khởi tạo form2
            StaffView frm = new StaffView();
            frm.TopLevel = false;              // Quan trọng: không cho form chạy độc lập
            frm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền
            frm.Dock = DockStyle.Fill;         // Fill toàn bộ panel

            // Thêm form2 vào panelMain
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void btn_Ass_Click(object sender, EventArgs e)
        {
            // Xóa control cũ trong panel (nếu có)
            panelMain.Controls.Clear();

            // Khởi tạo form2
            TeachingView frm = new TeachingView();
            frm.TopLevel = false;              // Quan trọng: không cho form chạy độc lập
            frm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền
            frm.Dock = DockStyle.Fill;         // Fill toàn bộ panel

            // Thêm form2 vào panelMain
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void btn_equip_Click(object sender, EventArgs e)
        {
            // Xóa control cũ trong panel (nếu có)
            panelMain.Controls.Clear();

            // Khởi tạo form2
            Equipment frm = new Equipment();
            frm.TopLevel = false;              // Quan trọng: không cho form chạy độc lập
            frm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền
            frm.Dock = DockStyle.Fill;         // Fill toàn bộ panel

            // Thêm form2 vào panelMain
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            picBox.BringToFront();
        }
    }
}
