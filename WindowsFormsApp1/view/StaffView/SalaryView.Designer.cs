namespace WindowsFormsApp1.view.StaffView
{
    partial class SalaryView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStaffId = new System.Windows.Forms.Label();
            this.txtStaffId = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnLoadTimesheets = new System.Windows.Forms.Button();
            this.dgvTimesheets = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnApprove = new System.Windows.Forms.Button();
            this.groupPayroll = new System.Windows.Forms.GroupBox();
            this.btnGeneratePayroll = new System.Windows.Forms.Button();
            this.dgvPayroll = new System.Windows.Forms.DataGridView();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblMonth = new System.Windows.Forms.Label();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.btnUpdateMonthly = new System.Windows.Forms.Button();
            this.btnViewMonthly = new System.Windows.Forms.Button();
            this.lblDisburse = new System.Windows.Forms.Label();
            this.numDisburse = new System.Windows.Forms.NumericUpDown();
            this.btnDisburse = new System.Windows.Forms.Button();
            this.dgvMonthly = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimesheets)).BeginInit();
            this.groupPayroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisburse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthly)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStaffId
            // 
            this.lblStaffId.AutoSize = true;
            this.lblStaffId.Location = new System.Drawing.Point(12, 15);
            this.lblStaffId.Name = "lblStaffId";
            this.lblStaffId.Size = new System.Drawing.Size(41, 13);
            this.lblStaffId.TabIndex = 0;
            this.lblStaffId.Text = "Staff Id";
            // 
            // txtStaffId
            // 
            this.txtStaffId.Location = new System.Drawing.Point(70, 12);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.ReadOnly = true;
            this.txtStaffId.Size = new System.Drawing.Size(220, 20);
            this.txtStaffId.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(310, 15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(20, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "Từ";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(346, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(160, 20);
            this.dtpStart.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(520, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "Đến";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(544, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(160, 20);
            this.dtpEnd.TabIndex = 5;
            // 
            // btnLoadTimesheets
            // 
            this.btnLoadTimesheets.Location = new System.Drawing.Point(720, 10);
            this.btnLoadTimesheets.Name = "btnLoadTimesheets";
            this.btnLoadTimesheets.Size = new System.Drawing.Size(120, 23);
            this.btnLoadTimesheets.TabIndex = 6;
            this.btnLoadTimesheets.Text = "Tải Timesheets";
            this.btnLoadTimesheets.UseVisualStyleBackColor = true;
            this.btnLoadTimesheets.Click += new System.EventHandler(this.btnLoadTimesheets_Click);
            // 
            // dgvTimesheets
            // 
            this.dgvTimesheets.AllowUserToAddRows = false;
            this.dgvTimesheets.AllowUserToDeleteRows = false;
            this.dgvTimesheets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimesheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimesheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimesheets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect});
            this.dgvTimesheets.Location = new System.Drawing.Point(15, 45);
            this.dgvTimesheets.MultiSelect = false;
            this.dgvTimesheets.Name = "dgvTimesheets";
            this.dgvTimesheets.RowHeadersVisible = false;
            this.dgvTimesheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimesheets.Size = new System.Drawing.Size(921, 220);
            this.dgvTimesheets.TabIndex = 7;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Chọn";
            this.colSelect.Name = "colSelect";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(15, 274);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(120, 23);
            this.btnApprove.TabIndex = 8;
            this.btnApprove.Text = "Duyệt mục đã chọn";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // groupPayroll
            // 
            this.groupPayroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPayroll.Controls.Add(this.btnGeneratePayroll);
            this.groupPayroll.Controls.Add(this.dgvPayroll);
            this.groupPayroll.Location = new System.Drawing.Point(15, 310);
            this.groupPayroll.Name = "groupPayroll";
            this.groupPayroll.Size = new System.Drawing.Size(921, 230);
            this.groupPayroll.TabIndex = 9;
            this.groupPayroll.TabStop = false;
            this.groupPayroll.Text = "Payroll (theo kỳ)";
            // 
            // btnGeneratePayroll
            // 
            this.btnGeneratePayroll.Location = new System.Drawing.Point(6, 19);
            this.btnGeneratePayroll.Name = "btnGeneratePayroll";
            this.btnGeneratePayroll.Size = new System.Drawing.Size(140, 23);
            this.btnGeneratePayroll.TabIndex = 1;
            this.btnGeneratePayroll.Text = "Tính lương theo kỳ";
            this.btnGeneratePayroll.UseVisualStyleBackColor = true;
            this.btnGeneratePayroll.Click += new System.EventHandler(this.btnGeneratePayroll_Click);
            // 
            // dgvPayroll
            // 
            this.dgvPayroll.AllowUserToAddRows = false;
            this.dgvPayroll.AllowUserToDeleteRows = false;
            this.dgvPayroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPayroll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayroll.Location = new System.Drawing.Point(6, 48);
            this.dgvPayroll.MultiSelect = false;
            this.dgvPayroll.Name = "dgvPayroll";
            this.dgvPayroll.RowHeadersVisible = false;
            this.dgvPayroll.Size = new System.Drawing.Size(909, 176);
            this.dgvPayroll.TabIndex = 0;
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(150, 279);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(65, 13);
            this.lblApprovedBy.TabIndex = 10;
            this.lblApprovedBy.Text = "ApprovedBy";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.Location = new System.Drawing.Point(224, 276);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.Size = new System.Drawing.Size(240, 20);
            this.txtApprovedBy.TabIndex = 11;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(15, 550);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 12;
            this.lblYear.Text = "Năm";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(54, 548);
            this.numYear.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 20);
            this.numYear.TabIndex = 13;
            this.numYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(180, 550);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(38, 13);
            this.lblMonth.TabIndex = 14;
            this.lblMonth.Text = "Tháng";
            // 
            // numMonth
            // 
            this.numMonth.Location = new System.Drawing.Point(221, 548);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(120, 20);
            this.numMonth.TabIndex = 15;
            this.numMonth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnUpdateMonthly
            // 
            this.btnUpdateMonthly.Location = new System.Drawing.Point(367, 546);
            this.btnUpdateMonthly.Name = "btnUpdateMonthly";
            this.btnUpdateMonthly.Size = new System.Drawing.Size(140, 23);
            this.btnUpdateMonthly.TabIndex = 16;
            this.btnUpdateMonthly.Text = "Cập nhật tổng tháng";
            this.btnUpdateMonthly.UseVisualStyleBackColor = true;
            this.btnUpdateMonthly.Click += new System.EventHandler(this.btnUpdateMonthly_Click);
            // 
            // btnViewMonthly
            // 
            this.btnViewMonthly.Location = new System.Drawing.Point(513, 546);
            this.btnViewMonthly.Name = "btnViewMonthly";
            this.btnViewMonthly.Size = new System.Drawing.Size(120, 23);
            this.btnViewMonthly.TabIndex = 17;
            this.btnViewMonthly.Text = "Xem tháng";
            this.btnViewMonthly.UseVisualStyleBackColor = true;
            this.btnViewMonthly.Click += new System.EventHandler(this.btnViewMonthly_Click);
            // 
            // lblDisburse
            // 
            this.lblDisburse.AutoSize = true;
            this.lblDisburse.Location = new System.Drawing.Point(640, 550);
            this.lblDisburse.Name = "lblDisburse";
            this.lblDisburse.Size = new System.Drawing.Size(52, 13);
            this.lblDisburse.TabIndex = 18;
            this.lblDisburse.Text = "Giải ngân";
            // 
            // numDisburse
            // 
            this.numDisburse.DecimalPlaces = 2;
            this.numDisburse.Location = new System.Drawing.Point(689, 547);
            this.numDisburse.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numDisburse.Name = "numDisburse";
            this.numDisburse.Size = new System.Drawing.Size(120, 20);
            this.numDisburse.TabIndex = 19;
            // 
            // btnDisburse
            // 
            this.btnDisburse.Location = new System.Drawing.Point(815, 546);
            this.btnDisburse.Name = "btnDisburse";
            this.btnDisburse.Size = new System.Drawing.Size(120, 23);
            this.btnDisburse.TabIndex = 20;
            this.btnDisburse.Text = "Thực hiện";
            this.btnDisburse.UseVisualStyleBackColor = true;
            this.btnDisburse.Click += new System.EventHandler(this.btnDisburse_Click);
            // 
            // dgvMonthly
            // 
            this.dgvMonthly.AllowUserToAddRows = false;
            this.dgvMonthly.AllowUserToDeleteRows = false;
            this.dgvMonthly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMonthly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonthly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonthly.Location = new System.Drawing.Point(15, 575);
            this.dgvMonthly.MultiSelect = false;
            this.dgvMonthly.Name = "dgvMonthly";
            this.dgvMonthly.RowHeadersVisible = false;
            this.dgvMonthly.Size = new System.Drawing.Size(921, 160);
            this.dgvMonthly.TabIndex = 21;
            // 
            // SalaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 740);
            this.Controls.Add(this.dgvMonthly);
            this.Controls.Add(this.btnDisburse);
            this.Controls.Add(this.numDisburse);
            this.Controls.Add(this.lblDisburse);
            this.Controls.Add(this.btnViewMonthly);
            this.Controls.Add(this.btnUpdateMonthly);
            this.Controls.Add(this.numMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtApprovedBy);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.groupPayroll);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvTimesheets);
            this.Controls.Add(this.btnLoadTimesheets);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.lblStaffId);
            this.Name = "SalaryView";
            this.Text = "Salary View";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimesheets)).EndInit();
            this.groupPayroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisburse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblStaffId;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnLoadTimesheets;
        private System.Windows.Forms.DataGridView dgvTimesheets;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.GroupBox groupPayroll;
        private System.Windows.Forms.Button btnGeneratePayroll;
        private System.Windows.Forms.DataGridView dgvPayroll;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Button btnUpdateMonthly;
        private System.Windows.Forms.Button btnViewMonthly;
        private System.Windows.Forms.Label lblDisburse;
        private System.Windows.Forms.NumericUpDown numDisburse;
        private System.Windows.Forms.Button btnDisburse;
        private System.Windows.Forms.DataGridView dgvMonthly;
    }
}