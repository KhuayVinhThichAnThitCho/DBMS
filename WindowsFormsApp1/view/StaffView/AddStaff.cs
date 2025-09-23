using System;
using System.Windows.Forms;
using WindowsFormsApp1.data.Staff;

namespace WindowsFormsApp1.view.StaffView
{
    public partial class AddStaff : Form
    {
        private readonly StaffDao staffDao = new StaffDao();

        public AddStaff()
        {
            InitializeComponent();
            // Default selections for ComboBoxes, if items exist
            if (txtRole is ComboBox && ((ComboBox)txtRole).Items.Count > 0)
            {
                ((ComboBox)txtRole).SelectedIndex = 0;
            }
            if (txtEmploymentType is ComboBox && ((ComboBox)txtEmploymentType).Items.Count > 0)
            {
                ((ComboBox)txtEmploymentType).SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var fullName = txtFullName.Text?.Trim();
                string role = (txtRole is ComboBox cbRole) ? cbRole.SelectedItem?.ToString() : txtRole.Text?.Trim();
                string employmentType = (txtEmploymentType is ComboBox cbEmp) ? cbEmp.SelectedItem?.ToString() : txtEmploymentType.Text?.Trim();
                var phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();
                var email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                DateTime? hireDate = dtpHireDate.Checked ? (DateTime?)dtpHireDate.Value.Date : null;
                var contactInfo = string.IsNullOrWhiteSpace(txtContactInfo.Text) ? null : txtContactInfo.Text.Trim();
                var bankAccount = string.IsNullOrWhiteSpace(txtBankAccount.Text) ? null : txtBankAccount.Text.Trim();
                var taxCode = string.IsNullOrWhiteSpace(txtTaxCode.Text) ? null : txtTaxCode.Text.Trim();

                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(employmentType))
                {
                    MessageBox.Show("Full Name, Role, and Employment Type are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                staffDao.AddStaff(fullName, role, employmentType, phone, email, hireDate, contactInfo, bankAccount, taxCode);
                MessageBox.Show("Staff added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
