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
    public partial class TeacherAvailableCourse : Form
    {
        private CourseService courseService = new CourseService();
        public TeacherAvailableCourse()
        {
            InitializeComponent();
            LoadCoursesToGrid();
        }
        private void LoadCoursesToGrid()
        {
            try
            {
                List<Course> courses = courseService.getAllCourses();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = courses;

                // Set column headers
                dataGridView1.Columns["Id"].HeaderText = "Course ID";
                dataGridView1.Columns["CourseCode"].HeaderText = "Course Code";
                dataGridView1.Columns["CourseName"].HeaderText = "Course Name";
                dataGridView1.Columns["Level"].HeaderText = "Level";
                dataGridView1.Columns["DurationSessions"].HeaderText = "Duration (Sessions)";
                dataGridView1.Columns["BaseFee"].HeaderText = "Base Fee (VND)";
                dataGridView1.Columns["CreatedAt"].HeaderText = "Created At";


                // Format BaseFee column as currency
                dataGridView1.Columns["BaseFee"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["BaseFee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Format CreatedAt column
                dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Auto resize columns
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // ✅ Add "View Classes" button column (only once)
                if (dataGridView1.Columns["ViewClassesButton"] == null)
                {
                    DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                    btnColumn.Name = "ViewClassesButton";
                    btnColumn.HeaderText = "Action";
                    btnColumn.Text = "View Classes";
                    btnColumn.UseColumnTextForButtonValue = true;
                    btnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns.Add(btnColumn);
                }
                if (dataGridView1.Columns["RegisterButton"] == null)
                {
                    DataGridViewButtonColumn registerBtn = new DataGridViewButtonColumn();
                    registerBtn.Name = "RegisterButton";
                    registerBtn.HeaderText = "Đăng ký";
                    registerBtn.Text = "Đăng ký";
                    registerBtn.UseColumnTextForButtonValue = true;
                    registerBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns.Add(registerBtn);
                }

                dataGridView1.CellContentClick -= dataGridView1_CellContentClick;
                dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            var selectedCourse = (Course)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (selectedCourse == null) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "ViewClassesButton")
            {
                // ✅ Mở form xem lớp
                TeacherAvailableClass classForm = new TeacherAvailableClass(selectedCourse.Id);
                classForm.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "RegisterButton")
            {
                // ✅ Mở form đăng ký (bạn sẽ tạo sau)
                AvailableClassForm availableClassForm = new AvailableClassForm(selectedCourse.Id);
                availableClassForm.ShowDialog();
            }
        }
    }
}
