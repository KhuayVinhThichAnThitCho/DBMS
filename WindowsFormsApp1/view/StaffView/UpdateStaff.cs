using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.data.Staff;

namespace WindowsFormsApp1.view.StaffView
{
    public partial class UpdateStaff : Form
    {
        private readonly StaffDao staffDao = new StaffDao();
        private Guid staffId;
        private Guid? selectedQualId;
        private Guid? selectedContractId;

        public UpdateStaff(Guid staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            LoadData();
        }

        private void LoadData()
        {
            var ds = staffDao.GetStaffAllById(staffId);
            // Staff
            if (ds.Tables["Staff"].Rows.Count > 0)
            {
                var r = ds.Tables["Staff"].Rows[0];
                txtStaffId.Text = staffId.ToString();
                txtFullName.Text = r["full_name"]?.ToString();
                cboRole.SelectedItem = r["role"]?.ToString();
                cboEmploymentType.SelectedItem = r["employment_type"]?.ToString();
                txtPhone.Text = r["phone"]?.ToString();
                txtEmail.Text = r["email"]?.ToString();
                if (r["hire_date"] != DBNull.Value) { dtpHireDate.Value = (DateTime)r["hire_date"]; dtpHireDate.Checked = true; } else { dtpHireDate.Checked = false; }
                if (r["termination_date"] != DBNull.Value) { dtpTerminationDate.Value = (DateTime)r["termination_date"]; dtpTerminationDate.Checked = true; } else { dtpTerminationDate.Checked = false; }
                txtContactInfo.Text = r["contact_info"]?.ToString();
                txtBank.Text = r["bank_account"]?.ToString();
                txtTax.Text = r["tax_code"]?.ToString();
                cboStatus.SelectedItem = r["status"]?.ToString();
            }
            // Qualifications
            dgvQual.DataSource = ds.Tables["Qualifications"];
            // Contracts
            dgvContract.DataSource = ds.Tables["Contracts"];
        }

        private void btnSaveStaff_Click(object sender, EventArgs e)
        {
            staffDao.UpdateStaff(
                staffId,
                txtFullName.Text?.Trim(),
                cboRole.SelectedItem?.ToString(),
                cboEmploymentType.SelectedItem?.ToString(),
                txtPhone.Text?.Trim(),
                txtEmail.Text?.Trim(),
                dtpHireDate.Checked ? (DateTime?)dtpHireDate.Value.Date : null,
                dtpTerminationDate.Checked ? (DateTime?)dtpTerminationDate.Value.Date : null,
                txtContactInfo.Text?.Trim(),
                txtBank.Text?.Trim(),
                txtTax.Text?.Trim(),
                cboStatus.SelectedItem?.ToString()
            );
            MessageBox.Show("Staff updated.");
        }

        private void dgvQual_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvQual.Rows[e.RowIndex];
                if (Guid.TryParse(row.Cells["id"].Value?.ToString(), out var qid)) selectedQualId = qid; else selectedQualId = null;
                txtQType.Text = row.Cells["qualification_type"].Value?.ToString();
                txtQOrg.Text = row.Cells["issuing_organization"].Value?.ToString();
                decimal score; if (decimal.TryParse(row.Cells["score"].Value?.ToString(), out score)) numQScore.Value = Math.Min(numQScore.Maximum, Math.Max(numQScore.Minimum, score)); else numQScore.Value = 0;
                DateTime dt; if (DateTime.TryParse(row.Cells["issue_date"].Value?.ToString(), out dt)) dtpQIssue.Value = dt; if (DateTime.TryParse(row.Cells["expiry_date"].Value?.ToString(), out dt)) { dtpQExpiry.Value = dt; dtpQExpiry.Checked = true; } else { dtpQExpiry.Checked = false; }
                bool bv; if (bool.TryParse(row.Cells["is_verified"].Value?.ToString(), out bv)) chkQVerified.Checked = bv; else chkQVerified.Checked = false;
            }
        }

        private void btnSaveQual_Click(object sender, EventArgs e)
        {
            if (selectedQualId == null) { MessageBox.Show("Chọn một qualification để cập nhật."); return; }
            staffDao.UpdateQualification(
                selectedQualId.Value,
                txtQType.Text?.Trim(),
                txtQOrg.Text?.Trim(),
                numQScore.Value > 0 ? (decimal?)numQScore.Value : null,
                dtpQIssue.Value.Date,
                dtpQExpiry.Checked ? (DateTime?)dtpQExpiry.Value.Date : null,
                chkQVerified.Checked
            );
            MessageBox.Show("Qualification updated.");
            LoadData();
        }

        private void dgvContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvContract.Rows[e.RowIndex];
                if (Guid.TryParse(row.Cells["id"].Value?.ToString(), out var cid)) selectedContractId = cid; else selectedContractId = null;
                cboCType.SelectedItem = row.Cells["contract_type"].Value?.ToString();
                DateTime dt; if (DateTime.TryParse(row.Cells["start_date"].Value?.ToString(), out dt)) dtpCStart.Value = dt; if (DateTime.TryParse(row.Cells["end_date"].Value?.ToString(), out dt)) { dtpCEnd.Value = dt; dtpCEnd.Checked = true; } else { dtpCEnd.Checked = false; }
                cboCSalaryModel.SelectedItem = row.Cells["salary_model"].Value?.ToString();
                decimal dec;
                if (decimal.TryParse(row.Cells["base_salary"].Value?.ToString(), out dec)) numCBase.Value = Math.Min(numCBase.Maximum, Math.Max(numCBase.Minimum, dec)); else numCBase.Value = 0;
                if (decimal.TryParse(row.Cells["hourly_rate"].Value?.ToString(), out dec)) numCHourly.Value = Math.Min(numCHourly.Maximum, Math.Max(numCHourly.Minimum, dec)); else numCHourly.Value = 0;
                if (decimal.TryParse(row.Cells["allowances"].Value?.ToString(), out dec)) numCAllow.Value = Math.Min(numCAllow.Maximum, Math.Max(numCAllow.Minimum, dec)); else numCAllow.Value = 0;
                if (decimal.TryParse(row.Cells["bonus_policy"].Value?.ToString(), out dec)) numCBonus.Value = Math.Min(numCBonus.Maximum, Math.Max(numCBonus.Minimum, dec)); else numCBonus.Value = 0;
            }
        }

        private void btnSaveContract_Click(object sender, EventArgs e)
        {
            if (selectedContractId == null) { MessageBox.Show("Chọn một contract để cập nhật."); return; }
            var message = staffDao.UpdateContract(
                selectedContractId.Value,
                null,
                cboCType.SelectedItem?.ToString(),
                dtpCStart.Value.Date,
                dtpCEnd.Checked ? (DateTime?)dtpCEnd.Value.Date : null,
                cboCSalaryModel.SelectedItem?.ToString(),
                numCBase.Value > 0 ? (decimal?)numCBase.Value : null,
                numCHourly.Value > 0 ? (decimal?)numCHourly.Value : null,
                numCAllow.Value,
                numCBonus.Value
            );
            MessageBox.Show(message ?? "Contract updated.");
            LoadData();
        }
    }
}
