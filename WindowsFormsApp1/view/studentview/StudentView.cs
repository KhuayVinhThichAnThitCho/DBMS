using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.view.studentview;

namespace WindowsFormsApp1.view
{
    public partial class StudentView : Form
    {
        public StudentView()
        {
            InitializeComponent();
        }

   
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;

            // Xóa form cũ nếu có
            if (selectedTab.Controls.Count > 0)
                selectedTab.Controls.Clear();

            Form childForm = null;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    childForm = new StudentsForm();
                    break;
                case 1:
                    childForm = new CoursesForm();
                    break;
                case 2:
                    childForm = new EnrollmentForm();
                    break;
                case 3:
                    childForm = new TeacherAvailableCourse();
                    break;
                case 4:
                    childForm = new Finance();
                    break;
            }

            if (childForm != null)
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                selectedTab.Controls.Add(childForm);
                childForm.Show();
            }
        
    }
    }
}
