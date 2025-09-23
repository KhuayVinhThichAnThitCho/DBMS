using System;
using System.Windows.Forms;
using WindowsFormsApp1.data.Staff;

namespace WindowsFormsApp1.view.StaffView
{
    public partial class AddContracts : Form
    {
        private readonly StaffDao staffDao = new StaffDao();

        public AddContracts()
        {
            InitializeComponent();
            if (cboContractType.Items.Count > 0) cboContractType.SelectedIndex = 0;
            if (cboSalaryModel.Items.Count > 0) cboSalaryModel.SelectedIndex = 0;
        }

        public AddContracts(Guid staffId) : this()
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

                string contractType = cboContractType.SelectedItem?.ToString();
                DateTime startDate = dtpStart.Value.Date;
                DateTime? endDate = dtpEnd.Checked ? (DateTime?)dtpEnd.Value.Date : null;
                string salaryModel = cboSalaryModel.SelectedItem?.ToString();
                decimal? baseSalary = numBaseSalary.Value > 0 ? (decimal?)numBaseSalary.Value : null;
                decimal? hourlyRate = numHourlyRate.Value > 0 ? (decimal?)numHourlyRate.Value : null;
                decimal allowances = numAllowances.Value;
                decimal bonus = numBonus.Value;

                if (string.IsNullOrWhiteSpace(contractType))
                {
                    MessageBox.Show("Contract Type is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(salaryModel))
                {
                    MessageBox.Show("Salary Model is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var message = staffDao.AddContract(staffId, contractType, startDate, endDate, salaryModel, baseSalary, hourlyRate, allowances, bonus);
                MessageBox.Show(message ?? "Done", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!string.IsNullOrEmpty(message) && message.Contains("thành công"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add contract: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
