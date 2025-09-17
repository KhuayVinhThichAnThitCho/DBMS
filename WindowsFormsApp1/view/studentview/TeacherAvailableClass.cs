using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.data;
using WindowsFormsApp1.model;
using WindowsFormsApp1.service;

namespace WindowsFormsApp1.view.studentview
{
    public partial class TeacherAvailableClass : Form
    {
        private ClassDAO ClassDAO = new ClassDAO();
        public TeacherAvailableClass(Guid code)
        {
            InitializeComponent();
            LoadClassesToGrid(code);
        }
        private void LoadClassesToGrid(Guid id)
        {
            try
            {
                // Giáo viên hiện tại (ví dụ)
                string guidString = "106AE34B-B5F2-4BC1-969F-1CF61BE57A2A";
                Guid teacherId = Guid.Parse(guidString);

                DataTable dtClasses = ClassDAO.FindTeacherClasses(id, teacherId);

                // Debug: Print column names to verify the DataTable structure
                // string columnNames = string.Join(", ", dtClasses.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                // MessageBox.Show($"Columns in DataTable: {columnNames}");

                dataGridView1.AutoGenerateColumns = true; // hoặc false nếu muốn custom cột
                dataGridView1.DataSource = dtClasses;

                // Nếu muốn thêm nút "Điểm danh" + "Đánh giá"
                if (dataGridView1.Columns["AttendanceButton"] == null)
                {
                    DataGridViewButtonColumn btnAttendance = new DataGridViewButtonColumn
                    {
                        Name = "AttendanceButton",
                        HeaderText = "Điểm danh",
                        Text = "Điểm danh",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(btnAttendance);
                }

                if (dataGridView1.Columns["AssessmentButton"] == null)
                {
                    DataGridViewButtonColumn btnAssessment = new DataGridViewButtonColumn
                    {
                        Name = "AssessmentButton",
                        HeaderText = "Đánh giá",
                        Text = "Đánh giá",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(btnAssessment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the DataRowView from the selected row
            var rowView = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null)
            {
                MessageBox.Show("Invalid row data.", "Error");
                return;
            }

            // Extract ClassId from the DataTable
            string classIdColumnName = "class_id"; // Confirmed column name from DataTable
            if (!rowView.DataView.Table.Columns.Contains(classIdColumnName))
            {
                MessageBox.Show($"Column '{classIdColumnName}' not found in DataTable.", "Error");
                return;
            }

            if (!Guid.TryParse(rowView[classIdColumnName]?.ToString(), out Guid classId))
            {
                MessageBox.Show("Invalid class ID.", "Error");
                return;
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "AttendanceButton")
            {
                try
                {
                    // TODO: Replace fake data with actual data retrieval from ClassDAO or other DAOs
                    List<Student> students = new List<Student>
                    {
                        new Student { Id = Guid.Parse("16DC4C58-7EC0-4303-AC31-004EDEF254F9"), FullName = "John Smith" },
                        new Student { Id = Guid.Parse("16DC4C58-7EC0-4303-AC31-004EDEF254F2"), FullName = "Mary Johnson" }
                    };

                    List<Schedule> scheduleDates = new List<Schedule>
                    {
                        new Schedule { Id = Guid.Parse("16DC4C58-7EC0-4303-AC31-004EDEF254F9"), SessionDate = new DateTime(2025, 9, 15), SessionNumber = 1 },
                        new Schedule { Id = Guid.Parse("16DC4C58-7EC0-4303-AC31-004EDEF254F2"), SessionDate = new DateTime(2025, 9, 16), SessionNumber = 2 },
                        new Schedule { Id = Guid.Parse("16DC4C58-7EC0-4303-AC31-004EDEF254F3"), SessionDate = new DateTime(2025, 9, 17), SessionNumber = 3 }
                    };

                    List<Attendance> attendances = new List<Attendance>
                    {
                        new Attendance { StudentId = students[0].Id, SessionDate = new DateTime(2025, 9, 15), Status = "Present" },
                        new Attendance { StudentId = students[1].Id, SessionDate = new DateTime(2025, 9, 15), Status = "Present" }
                    };

                    // Instantiate the ClassAttendanceForm with the class ID and data
                    var form = new ClassAttendanceForm(classId, students, scheduleDates, attendances);
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening attendance form: " + ex.Message, "Error");
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "AssessmentButton")
            {
                // Placeholder for Assessment form
                MessageBox.Show($"Opening assessment form for class ID: {classId}", "Assessment");
                // TODO: Implement assessment form logic here
            }
        }
    }
}
