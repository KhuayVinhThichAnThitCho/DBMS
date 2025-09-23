using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.data.Staff;

namespace WindowsFormsApp1.view.StaffView
{
    public partial class TeminateView : Form
    {
        private readonly StaffDao staffDao = new StaffDao();
        private Guid staffId;

        public TeminateView(Guid staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            txtStaffId.Text = staffId.ToString();
            LoadData();
        }

        private void LoadData()
        {
            var ds = staffDao.GetStaffAllById(staffId);
            if (ds.Tables.Contains("Qualifications"))
            {
                dgvQualifications.DataSource = ds.Tables["Qualifications"];
            }
            if (ds.Tables.Contains("Contracts"))
            {
                dgvContracts.DataSource = ds.Tables["Contracts"];
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            bool anyDeleted = false;

            // Delete selected qualifications
            foreach (DataGridViewRow row in dgvQualifications.Rows)
            {
                var cell = row.Cells["colQSelect"] as DataGridViewCheckBoxCell;
                if (cell != null && cell.Value is bool && (bool)cell.Value)
                {
                    if (Guid.TryParse(row.Cells["id"].Value?.ToString(), out var qid))
                    {
                        var msg = staffDao.DeleteQualification(qid);
                        anyDeleted = true;
                        if (!string.IsNullOrEmpty(msg)) MessageBox.Show(msg, "Kết quả");
                    }
                }
            }
            // Delete selected contracts
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                var cell = row.Cells["colCSelect"] as DataGridViewCheckBoxCell;
                if (cell != null && cell.Value is bool && (bool)cell.Value)
                {
                    if (Guid.TryParse(row.Cells["id"].Value?.ToString(), out var cid))
                    {
                        var msg = staffDao.DeleteContract(cid);
                        anyDeleted = true;
                        if (!string.IsNullOrEmpty(msg)) MessageBox.Show(msg, "Kết quả");
                    }
                }
            }

            if (anyDeleted)
            {
                // Notify parent to reload and close
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa chọn mục nào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
