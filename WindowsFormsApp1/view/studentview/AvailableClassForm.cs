using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.model;
using WindowsFormsApp1.service;

namespace WindowsFormsApp1.view.studentview
{
    public partial class AvailableClassForm : Form
    {
        private ClassService classService = new ClassService();

        public AvailableClassForm(Guid code)
        {
            InitializeComponent();
            LoadClassesToGrid(code);

        }
        private void LoadClassesToGrid(Guid id)
        {
            try
            {
                // ✅ Lấy danh sách lớp theo courseId
                List<Class> classes = classService.getAvailableClass(id);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = classes;

                // ✅ Đặt tên cột hiển thị
                dataGridView1.Columns["Id"].HeaderText = "Class ID";
                dataGridView1.Columns["ClassCode"].HeaderText = "Class Code";
                dataGridView1.Columns["CurrentCapacity"].HeaderText = "Current Capacity";
                dataGridView1.Columns["MaxCapacity"].HeaderText = "Max Capacity";
                dataGridView1.Columns["StartDate"].HeaderText = "Start Date";
                dataGridView1.Columns["EndDate"].HeaderText = "End Date";
                dataGridView1.Columns["Status"].HeaderText = "Status";

                // ✅ Ẩn các cột không cần hiển thị
                dataGridView1.Columns["Id"].Visible = false;        // Chỉ cần dùng để lấy khi chọn
                dataGridView1.Columns["CourseId"].Visible = false;
                dataGridView1.Columns["TeacherId"].Visible = false;
                dataGridView1.Columns["RoomId"].Visible = false;
                dataGridView1.Columns["CreatedAt"].Visible = false;
                dataGridView1.Columns["Schedule"].Visible = false;  // Nếu bạn không muốn hiển thị lịch học chi tiết

                // ✅ Định dạng ngày
                dataGridView1.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // ✅ Thêm nút "Chọn lớp" chỉ một lần
                if (dataGridView1.Columns["SelectClassButton"] == null)
                {
                    DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                    btnColumn.Name = "SelectClassButton";
                    btnColumn.HeaderText = "Action";
                    btnColumn.Text = "Chọn lớp";
                    btnColumn.UseColumnTextForButtonValue = true;
                    btnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns.Add(btnColumn);
                }

                // Gắn event click
                dataGridView1.CellContentClick -= dataGridView1_CellContentClick;
                dataGridView1.CellContentClick += dataGridView1_CellContentClick;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "SelectClassButton")
            {
                // ✅ Lấy class được chọn
                var selectedClass = (Class)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (selectedClass != null)
                {
                    Guid classId = selectedClass.Id;
                    MessageBox.Show($"Bạn đã chọn lớp có ID: {classId}");
                    StudentRegisterClassForm studentRegisterClassForm = new StudentRegisterClassForm(classId);
                    studentRegisterClassForm.ShowDialog();
                    // 🔧 Ở đây bạn có thể mở form đăng ký
                    // EnrollmentForm enrollForm = new EnrollmentForm(classId);
                    // enrollForm.ShowDialog();
                }
            }
        }
    }
}

