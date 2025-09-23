using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.data.Staff;

namespace WindowsFormsApp1.view.StaffView
{
    public partial class StaffManager : Form
    {
        private readonly StaffDao staffDao = new StaffDao();

        public StaffManager()
        {
            InitializeComponent();
            this.Load += StaffManager_Load;
        }

        private void StaffManager_Load(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.AutoGenerateColumns = true;
                guna2DataGridView1.ColumnHeadersVisible = true;
                guna2DataGridView1.EnableHeadersVisualStyles = false;
                guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                guna2DataGridView1.ColumnHeadersHeight = 28;

                guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();

                // Optional: nicer headers
                SetHeaderText("id", "ID");
                SetHeaderText("full_name", "Full Name");
                SetHeaderText("phone", "Phone");
                SetHeaderText("email", "Email");
                SetHeaderText("role", "Role");
                SetHeaderText("employment_type", "Employment Type");
                SetHeaderText("status", "Status");
                SetHeaderText("hire_date", "Hire Date");
                SetHeaderText("termination_date", "Termination Date");
                SetHeaderText("contact_info", "Contact Info");
                SetHeaderText("bank_account", "Bank Account");
                SetHeaderText("tax_code", "Tax Code");
                SetHeaderText("created_at", "Created At");
                SetHeaderText("qualification_type", "Qualification");

                // Formatting
                if (guna2DataGridView1.Columns["hire_date"] != null)
                    guna2DataGridView1.Columns["hire_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                if (guna2DataGridView1.Columns["termination_date"] != null)
                    guna2DataGridView1.Columns["termination_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                if (guna2DataGridView1.Columns["created_at"] != null)
                    guna2DataGridView1.Columns["created_at"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

                guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                guna2DataGridView1.AutoResizeColumnHeadersHeight();
                guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                guna2DataGridView1.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetHeaderText(string columnName, string headerText)
        {
            var col = guna2DataGridView1.Columns[columnName];
            if (col != null) col.HeaderText = headerText;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddStaff())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // Refresh grid after successful save
                    try
                    {
                        guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to refresh: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cell = guna2DataGridView1.CurrentRow.Cells["id"]; // expects column name 'id'
                if (cell == null || cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    MessageBox.Show("Không lấy được Staff Id từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Guid.TryParse(cell.Value.ToString(), out Guid staffId))
                {
                    MessageBox.Show("Định dạng Staff Id không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dlg = new AddQualification(staffId))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        // Refresh grid (e.g., if you show aggregated qualifications)
                        guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Add Qualification: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cell = guna2DataGridView1.CurrentRow.Cells["id"]; // expects column name 'id'
                if (cell == null || cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    MessageBox.Show("Không lấy được Staff Id từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Guid.TryParse(cell.Value.ToString(), out Guid staffId))
                {
                    MessageBox.Show("Định dạng Staff Id không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dlg = new AddContracts(staffId))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        // Refresh grid after successful contract addition
                        guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Add Contract: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cell = guna2DataGridView1.CurrentRow.Cells["id"]; // expects column name 'id'
                if (cell == null || cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    MessageBox.Show("Không lấy được Staff Id từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Guid.TryParse(cell.Value.ToString(), out Guid staffId))
                {
                    MessageBox.Show("Định dạng Staff Id không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dlg = new UpdateStaff(staffId))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        // Refresh grid after updating
                        guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Update Staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cell = guna2DataGridView1.CurrentRow.Cells["id"]; // expects column name 'id'
                if (cell == null || cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    MessageBox.Show("Không lấy được Staff Id từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Guid.TryParse(cell.Value.ToString(), out Guid staffId))
                {
                    MessageBox.Show("Định dạng Staff Id không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dlg = new TeminateView(staffId))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Terminate View: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var cell = guna2DataGridView1.CurrentRow.Cells["id"]; // expects column name 'id'
                if (cell == null || cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    MessageBox.Show("Không lấy được Staff Id từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Guid.TryParse(cell.Value.ToString(), out Guid staffId))
                {
                    MessageBox.Show("Định dạng Staff Id không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dlg = new SalaryView(staffId))
                {
                    dlg.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Salary View: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to reload: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var cell = guna2DataGridView1.CurrentRow.Cells["id"]; // expects column name 'id'
                if (cell == null || cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    MessageBox.Show("Không lấy được Staff Id từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Guid.TryParse(cell.Value.ToString(), out Guid staffId))
                {
                    MessageBox.Show("Định dạng Staff Id không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                bool success;
                var message = staffDao.DeleteStaffIfTerminated(staffId, out success);
                if (!string.IsNullOrEmpty(message))
                    MessageBox.Show(message, success ? "Thành công" : "Thất bại", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (success)
                {
                    guna2DataGridView1.DataSource = staffDao.GetEmployeeInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhân viên thất bại: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
