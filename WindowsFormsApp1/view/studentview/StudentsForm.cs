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
    public partial class StudentsForm : Form
    {
        private StudentService StudentService = new StudentService();
        public StudentsForm()
        {
            InitializeComponent();
            LoadStudentsToGrid();

        }
        private void LoadStudentsToGrid()
        {
            try
            {
                List<Student> students = StudentService.getAllStudents();

                // Set DataGridView datasource
                dataGridView1.DataSource = null; // Reset nếu cần
                dataGridView1.DataSource = students;

                // Optionally, set column headers
                dataGridView1.Columns["Id"].HeaderText = "ID";
                dataGridView1.Columns["StudentCode"].HeaderText = "Student Code";
                dataGridView1.Columns["FullName"].HeaderText = "Full Name";
                dataGridView1.Columns["Phone"].HeaderText = "Phone";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["CurrentLevel"].HeaderText = "Level";
                dataGridView1.Columns["Status"].HeaderText = "Status";
                dataGridView1.Columns["CreatedAt"].HeaderText = "Created At";
                dataGridView1.Columns["UpdatedAt"].HeaderText = "Updated At";

                // Optional: auto resize columns
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void create_button_Click(object sender, EventArgs e)
        {

        }

        private void update_button_Click(object sender, EventArgs e)
        {

        }

        private void delete_button_Click(object sender, EventArgs e)
        {

        }
    }
}
