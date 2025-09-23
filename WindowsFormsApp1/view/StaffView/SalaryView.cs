using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.data.Staff;

namespace WindowsFormsApp1.view.StaffView
{
    public partial class SalaryView : Form
    {
        private readonly StaffDao staffDao = new StaffDao();
        private readonly Guid staffId;

        public SalaryView(Guid staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            txtStaffId.Text = staffId.ToString();
        }

        private void btnLoadTimesheets_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? start = dtpStart.Checked ? (DateTime?)dtpStart.Value.Date : null;
                DateTime? end = dtpEnd.Checked ? (DateTime?)dtpEnd.Value.Date : null;
                var dt = staffDao.GetTimesheetsByStaff(staffId, start, end);
                dgvTimesheets.DataSource = dt;
                if (dgvTimesheets.Columns["work_date"] != null)
                    dgvTimesheets.Columns["work_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                if (dgvTimesheets.Columns["created_at"] != null)
                    dgvTimesheets.Columns["created_at"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load timesheets failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                string approvedBy = string.IsNullOrWhiteSpace(txtApprovedBy.Text) ? Environment.UserName : txtApprovedBy.Text.Trim();
                int approvedCount = 0;
                foreach (DataGridViewRow row in dgvTimesheets.Rows)
                {
                    var chk = row.Cells["colSelect"] as DataGridViewCheckBoxCell;
                    if (chk != null && chk.Value is bool && (bool)chk.Value)
                    {
                        if (Guid.TryParse(row.Cells["id"].Value?.ToString(), out var tid))
                        {
                            var msg = staffDao.ApproveTimesheet(tid, approvedBy);
                            approvedCount++;
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show(msg, "Approve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (approvedCount == 0)
                {
                    MessageBox.Show("Chưa chọn timesheet nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnLoadTimesheets_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Approve failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeneratePayroll_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dtpStart.Checked || !dtpEnd.Checked)
                {
                    MessageBox.Show("Chọn khoảng kỳ lương (Từ/Đến).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var dt = staffDao.GeneratePayroll(dtpStart.Value.Date, dtpEnd.Value.Date);
                if (dt.Columns.Contains("staff_id"))
                {
                    var dv = new DataView(dt);
                    dv.RowFilter = $"staff_id = '{staffId}'";
                    dgvPayroll.DataSource = dv;
                }
                else
                {
                    dgvPayroll.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Generate payroll failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateMonthly_Click(object sender, EventArgs e)
        {
            try
            {
                staffDao.UpsertMonthlyTotals((int)numYear.Value, (int)numMonth.Value);
                MessageBox.Show("Đã cập nhật tổng lương tháng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật tổng tháng thất bại: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewMonthly_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = staffDao.GetMonthlySalary((int)numYear.Value, (int)numMonth.Value, staffId);
                dgvMonthly.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu tháng thất bại: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisburse_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = numDisburse.Value;
                if (amount <= 0)
                {
                    MessageBox.Show("Nhập số tiền > 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var msg = staffDao.AddMonthlyDisbursement(staffId, (int)numYear.Value, (int)numMonth.Value, amount);
                MessageBox.Show(msg ?? "Đã giải ngân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnViewMonthly_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giải ngân thất bại: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
