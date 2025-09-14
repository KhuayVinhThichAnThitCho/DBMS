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
    public partial class ClassForm : Form
    {
        private ClassService classService = new ClassService();
        public ClassForm(Guid code)
        {
            InitializeComponent();
            LoadClassesToGrid(code);
        }
        private void LoadClassesToGrid(Guid code)
        {
            try
            {
                // ✅ Get all classes (or by courseCode if needed)
                List<Class> classes = classService.GetAllClasses(code); // You can also use FindClassByCourseId("CS101") etc.

                dataGridView1.DataSource = null; // Reset if needed
                dataGridView1.DataSource = classes;

                // ✅ Set column headers for Class entity
                dataGridView1.Columns["Id"].HeaderText = "Class ID";
                dataGridView1.Columns["ClassCode"].HeaderText = "Class Code";
                dataGridView1.Columns["CourseId"].HeaderText = "Course ID";
                dataGridView1.Columns["TeacherId"].HeaderText = "Teacher ID";
                dataGridView1.Columns["RoomId"].HeaderText = "Room ID";
                dataGridView1.Columns["CurrentCapacity"].HeaderText = "Current Capacity";
                dataGridView1.Columns["MaxCapacity"].HeaderText = "Max Capacity";
                dataGridView1.Columns["Schedule"].HeaderText = "Schedule";
                dataGridView1.Columns["StartDate"].HeaderText = "Start Date";
                dataGridView1.Columns["EndDate"].HeaderText = "End Date";
                dataGridView1.Columns["Status"].HeaderText = "Status";
                dataGridView1.Columns["CreatedAt"].HeaderText = "Created At";

                // Hide columns you don’t want to show (example: IDs if not needed)
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["CourseId"].Visible = false;
                dataGridView1.Columns["TeacherId"].Visible = false;
                dataGridView1.Columns["RoomId"].Visible = false;

                // Format date columns
                dataGridView1.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Optional: auto resize columns
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
