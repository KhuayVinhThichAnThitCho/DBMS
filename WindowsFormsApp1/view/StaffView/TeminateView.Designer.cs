namespace WindowsFormsApp1.view.StaffView
{
    partial class TeminateView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblStaffId = new System.Windows.Forms.Label();
            this.txtStaffId = new System.Windows.Forms.TextBox();
            this.dgvQualifications = new System.Windows.Forms.DataGridView();
            this.colQSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.colCSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStaffId
            // 
            this.lblStaffId.AutoSize = true;
            this.lblStaffId.Location = new System.Drawing.Point(12, 15);
            this.lblStaffId.Name = "lblStaffId";
            this.lblStaffId.Size = new System.Drawing.Size(43, 13);
            this.lblStaffId.TabIndex = 0;
            this.lblStaffId.Text = "Staff Id";
            // 
            // txtStaffId
            // 
            this.txtStaffId.Location = new System.Drawing.Point(70, 12);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.ReadOnly = true;
            this.txtStaffId.Size = new System.Drawing.Size(250, 20);
            this.txtStaffId.TabIndex = 1;
            // 
            // dgvQualifications
            // 
            this.dgvQualifications.AllowUserToAddRows = false;
            this.dgvQualifications.AllowUserToDeleteRows = false;
            this.dgvQualifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQualifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQualifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQualifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQSelect});
            this.dgvQualifications.Location = new System.Drawing.Point(15, 45);
            this.dgvQualifications.MultiSelect = false;
            this.dgvQualifications.Name = "dgvQualifications";
            this.dgvQualifications.RowHeadersVisible = false;
            this.dgvQualifications.Size = new System.Drawing.Size(760, 180);
            this.dgvQualifications.TabIndex = 2;
            // 
            // colQSelect
            // 
            this.colQSelect.HeaderText = "Chọn";
            this.colQSelect.Name = "colQSelect";
            this.colQSelect.Width = 50;
            // 
            // dgvContracts
            // 
            this.dgvContracts.AllowUserToAddRows = false;
            this.dgvContracts.AllowUserToDeleteRows = false;
            this.dgvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCSelect});
            this.dgvContracts.Location = new System.Drawing.Point(15, 245);
            this.dgvContracts.MultiSelect = false;
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.RowHeadersVisible = false;
            this.dgvContracts.Size = new System.Drawing.Size(760, 180);
            this.dgvContracts.TabIndex = 3;
            // 
            // colCSelect
            // 
            this.colCSelect.HeaderText = "Chọn";
            this.colCSelect.Name = "colCSelect";
            this.colCSelect.Width = 50;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(15, 440);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(120, 25);
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "Xóa mục đã chọn";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(155, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TeminateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.dgvContracts);
            this.Controls.Add(this.dgvQualifications);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.lblStaffId);
            this.Name = "TeminateView";
            this.Text = "Terminate Staff Items";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaffId;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.DataGridView dgvQualifications;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colQSelect;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCSelect;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnClose;
    }
}