using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Form2 frm = new Form2();
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
            Form3 frm = new Form3();
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
            Form4 frm = new Form4();
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
            Form5 frm = new Form5();
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
