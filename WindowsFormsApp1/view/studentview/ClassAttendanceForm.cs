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

namespace WindowsFormsApp1.view.studentview
{
    public partial class ClassAttendanceForm : Form
    {
        private DataGridView dgvAttendance;
        private Color presentColor = Color.LightGreen;  // Green for Present
        private Color absentColor = Color.LightCoral;   // Red for Absent
        private Color buttonRowColor = Color.LightGray; // Gray for button row
        private List<Student> students; // Store student data
        private List<Schedule> scheduleDates; // Store class schedule data
        private List<Attendance> existingAttendance; // Store existing attendance data
        private Guid classId; // Store class ID
        public ClassAttendanceForm(
           Guid classId,
            List<Student> studentData,
            List<Schedule> scheduleDates,
            List<Attendance> existingAttendance)
        {
            InitializeComponent();
            this.classId = classId;
            this.students = studentData ?? new List<Student>();
            this.scheduleDates = scheduleDates ?? new List<Schedule>();
            this.existingAttendance = existingAttendance ?? new List<Attendance>();
            InitializeAttendanceForm();
        }

        private void InitializeAttendanceForm()
        {
            dgvAttendance = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            this.Controls.Add(dgvAttendance);

            LoadData();
        }

        private void LoadData()
        {
            // === Clear old ===
            dgvAttendance.Columns.Clear();
            dgvAttendance.Rows.Clear();

            // === First Column: Student Names ===
            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "StudentName",
                HeaderText = "Student Name",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightBlue,
                    Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold)
                }
            };
            dgvAttendance.Columns.Add(nameColumn);

            // === Add Date Columns with ComboBox ===
            foreach (var schedule in scheduleDates)
            {
                var col = new DataGridViewComboBoxColumn
                {
                    HeaderText = $"{schedule.SessionDate:yyyy-MM-dd} (Session {schedule.SessionNumber})",
                    Name = schedule.SessionDate.ToString("yyyyMMdd"),
                    DataSource = new string[] { "", "Present", "Absent" }, // Empty option included
                    FlatStyle = FlatStyle.Flat,
                    Tag = schedule // Store entire Schedule object in Tag
                };

                // Style the combobox cells
                col.DefaultCellStyle.BackColor = Color.White;
                col.DefaultCellStyle.ForeColor = Color.Black;
                dgvAttendance.Columns.Add(col);
            }

            // === Add first row = Submit buttons ===
            int btnRowIndex = dgvAttendance.Rows.Add();
            var btnRow = dgvAttendance.Rows[btnRowIndex];
            btnRow.DefaultCellStyle.BackColor = buttonRowColor;
            btnRow.DefaultCellStyle.ForeColor = Color.Black;
            btnRow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);

            btnRow.Cells[0].Value = "Submit:";
            btnRow.Cells[0].Style.BackColor = buttonRowColor;
            btnRow.Cells[0].Style.ForeColor = Color.Black;
            btnRow.Cells[0].Style.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);

            for (int i = 1; i < dgvAttendance.Columns.Count; i++)
            {
                DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                btnCell.Value = "Submit";
                btnCell.Style.BackColor = buttonRowColor;
                btnCell.Style.ForeColor = Color.Black;
                btnCell.Style.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
                btnCell.FlatStyle = FlatStyle.Flat;
                dgvAttendance[i, btnRowIndex] = btnCell;
            }

            // === Add students rows ===
            for (int s = 0; s < students.Count; s++)
            {
                var student = students[s];
                int rowIndex = dgvAttendance.Rows.Add();
                var currentRow = dgvAttendance.Rows[rowIndex];

                // Student name cell styling, store StudentId in Tag
                currentRow.Cells[0].Value = student.FullName;
                currentRow.Cells[0].Tag = student.Id; // Store StudentId in Tag
                currentRow.Cells[0].Style.BackColor = Color.LightBlue;
                currentRow.Cells[0].Style.ForeColor = Color.Black;
                currentRow.Cells[0].Style.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                currentRow.Cells[0].ReadOnly = true;

                // Load existing attendance or leave blank
                for (int i = 1; i < dgvAttendance.Columns.Count; i++)
                {
                    string dateStr = scheduleDates[i - 1].SessionDate.ToString("yyyy-MM-dd");
                    string attendanceStatus = "";

                    // Check if there is existing attendance for this student and date
                    var attendanceRecord = existingAttendance.FirstOrDefault(
                        a => a.StudentId == student.Id && a.SessionDate.ToString("yyyy-MM-dd") == dateStr);

                    if (attendanceRecord != null)
                    {
                        attendanceStatus = attendanceRecord.Status;
                    }

                    dgvAttendance.Rows[rowIndex].Cells[i].Value = attendanceStatus;

                    // Apply color based on attendance status
                    ApplyAttendanceColor(rowIndex, i, attendanceStatus);
                }
            }

            // === Handle button clicks ===
            dgvAttendance.CellClick += DgvAttendance_CellClick;
            dgvAttendance.CellValueChanged += DgvAttendance_CellValueChanged; // Handle combo box changes
            dgvAttendance.EditingControlShowing += DgvAttendance_EditingControlShowing; // Handle combo box styling
        }

        private void ApplyAttendanceColor(int rowIndex, int columnIndex, string attendanceStatus)
        {
            var cell = dgvAttendance.Rows[rowIndex].Cells[columnIndex];

            if (attendanceStatus == "Present")
            {
                cell.Style.BackColor = presentColor;
                cell.Style.ForeColor = Color.DarkGreen;
                cell.Style.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            }
            else if (attendanceStatus == "Absent")
            {
                cell.Style.BackColor = absentColor;
                cell.Style.ForeColor = Color.DarkRed;
                cell.Style.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
            }
            else // Empty or null
            {
                cell.Style.BackColor = Color.White;
                cell.Style.ForeColor = Color.Black;
                cell.Style.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
            }
        }

        private void DgvAttendance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex > 0) // Student rows, date columns
            {
                string attendanceStatus = dgvAttendance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
                ApplyAttendanceColor(e.RowIndex, e.ColumnIndex, attendanceStatus);
            }
        }

        private void DgvAttendance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvAttendance.CurrentCell.ColumnIndex > 0 && e.Control is ComboBox comboBox)
            {
                // Handle combo box selection change to update colors
                comboBox.SelectedIndexChanged += (s, args) =>
                {
                    if (dgvAttendance.CurrentCell != null && dgvAttendance.CurrentCell.RowIndex > 0)
                    {
                        string selectedValue = comboBox.SelectedItem?.ToString() ?? "";
                        ApplyAttendanceColor(dgvAttendance.CurrentCell.RowIndex,
                                           dgvAttendance.CurrentCell.ColumnIndex,
                                           selectedValue);
                    }
                };
            }
        }

        private void DgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex > 0) // first row, any date column
            {
                var schedule = dgvAttendance.Columns[e.ColumnIndex].Tag as Schedule;
                if (schedule == null) return;

                string date = schedule.SessionDate.ToString("yyyy-MM-dd");

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to submit attendance for {date} (Session {schedule.SessionNumber})?",
                    "Confirm Submission",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    var attendanceData = GetAttendanceForDate(e.ColumnIndex);
                    var output = new
                    {
                        ClassId = classId,
                        SessionDate = schedule.SessionDate,
                        SessionNumber = schedule.SessionNumber,
                        Attendance = attendanceData
                    };

                    StringBuilder summary = new StringBuilder($"Attendance for {date} (Session {schedule.SessionNumber}) submitted!\n\n");
                    summary.AppendLine($"Class ID: {output.ClassId}");
                    summary.AppendLine($"Session Date: {output.SessionDate:yyyy-MM-dd}");
                    summary.AppendLine($"Session Number: {output.SessionNumber}");
                    summary.AppendLine("Attendance:");
                    foreach (var record in output.Attendance)
                    {
                        summary.AppendLine($"  Student ID: {record.StudentId}, Status: {record.AttendanceStatus}");
                    }
                    MessageBox.Show(summary.ToString(), "Success");
                }
            }
        }

        private List<(Guid StudentId, string AttendanceStatus)> GetAttendanceForDate(int columnIndex)
        {
            var attendanceData = new List<(Guid StudentId, string AttendanceStatus)>();

            // Start from row 1 to skip the Submit button row
            for (int rowIndex = 1; rowIndex < dgvAttendance.Rows.Count; rowIndex++)
            {
                var row = dgvAttendance.Rows[rowIndex];
                if (row.Cells[0].Tag is Guid studentId)
                {
                    string attendanceStatus = row.Cells[columnIndex].Value?.ToString() ?? "";
                    attendanceData.Add((studentId, attendanceStatus));
                }
            }

            return attendanceData;
        }
    }
}