using System;
using System.Windows.Forms;
using WindowsFormsApp1.data.Staff;

namespace WindowsFormsApp1.view.StaffView
{
    public partial class AddQualification : Form
    {
        private readonly StaffDao staffDao = new StaffDao();

        public AddQualification()
        {
            InitializeComponent();
        }

        // New: overload that prefills StaffId and locks the field
        public AddQualification(Guid staffId) : this()
        {
            txtStaffId.Text = staffId.ToString();
            txtStaffId.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Guid.TryParse(txtStaffId.Text.Trim(), out Guid staffId))
                {
                    MessageBox.Show("Invalid Staff Id (must be GUID).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string qualificationType = txtQualificationType.Text?.Trim();
                string issuingOrg = txtIssuingOrg.Text?.Trim();
                decimal? score = numScore.Value > 0 ? (decimal?)numScore.Value : null;
                DateTime issueDate = dtpIssueDate.Value.Date;
                DateTime? expiryDate = dtpExpiryDate.Checked ? (DateTime?)dtpExpiryDate.Value.Date : null;
                bool isVerified = chkVerified.Checked;

                if (string.IsNullOrWhiteSpace(qualificationType) || string.IsNullOrWhiteSpace(issuingOrg))
                {
                    MessageBox.Show("Qualification Type and Issuing Organization are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                staffDao.AddQualification(staffId, qualificationType, issuingOrg, score, issueDate, expiryDate, isVerified);
                MessageBox.Show("Qualification added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add qualification: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
