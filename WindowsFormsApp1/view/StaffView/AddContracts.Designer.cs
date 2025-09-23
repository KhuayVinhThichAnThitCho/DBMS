namespace WindowsFormsApp1.view.StaffView
{
    partial class AddContracts
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
            this.lblContractType = new System.Windows.Forms.Label();
            this.cboContractType = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblSalaryModel = new System.Windows.Forms.Label();
            this.cboSalaryModel = new System.Windows.Forms.ComboBox();
            this.lblBaseSalary = new System.Windows.Forms.Label();
            this.numBaseSalary = new System.Windows.Forms.NumericUpDown();
            this.lblHourlyRate = new System.Windows.Forms.Label();
            this.numHourlyRate = new System.Windows.Forms.NumericUpDown();
            this.lblAllowances = new System.Windows.Forms.Label();
            this.numAllowances = new System.Windows.Forms.NumericUpDown();
            this.lblBonus = new System.Windows.Forms.Label();
            this.numBonus = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourlyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBonus)).BeginInit();
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
            this.txtStaffId.Location = new System.Drawing.Point(160, 12);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.Size = new System.Drawing.Size(280, 20);
            this.txtStaffId.TabIndex = 1;
            // 
            // lblContractType
            // 
            this.lblContractType.AutoSize = true;
            this.lblContractType.Location = new System.Drawing.Point(12, 43);
            this.lblContractType.Name = "lblContractType";
            this.lblContractType.Size = new System.Drawing.Size(76, 13);
            this.lblContractType.TabIndex = 2;
            this.lblContractType.Text = "Contract Type";
            // 
            // cboContractType
            // 
            this.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContractType.FormattingEnabled = true;
            this.cboContractType.Items.AddRange(new object[] {
            "Full-time",
            "Part-time",
            "Freelance"});
            this.cboContractType.Location = new System.Drawing.Point(160, 40);
            this.cboContractType.Name = "cboContractType";
            this.cboContractType.Size = new System.Drawing.Size(280, 21);
            this.cboContractType.TabIndex = 3;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(12, 71);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Start Date";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(160, 68);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 5;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(12, 99);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "End Date";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(160, 96);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 7;
            // 
            // lblSalaryModel
            // 
            this.lblSalaryModel.AutoSize = true;
            this.lblSalaryModel.Location = new System.Drawing.Point(12, 127);
            this.lblSalaryModel.Name = "lblSalaryModel";
            this.lblSalaryModel.Size = new System.Drawing.Size(67, 13);
            this.lblSalaryModel.TabIndex = 8;
            this.lblSalaryModel.Text = "Salary Model";
            // 
            // cboSalaryModel
            // 
            this.cboSalaryModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalaryModel.FormattingEnabled = true;
            this.cboSalaryModel.Items.AddRange(new object[] {
            "Fixed",
            "Hourly",
            "Cố định",
            "Theo giờ"});
            this.cboSalaryModel.Location = new System.Drawing.Point(160, 124);
            this.cboSalaryModel.Name = "cboSalaryModel";
            this.cboSalaryModel.Size = new System.Drawing.Size(280, 21);
            this.cboSalaryModel.TabIndex = 9;
            // 
            // lblBaseSalary
            // 
            this.lblBaseSalary.AutoSize = true;
            this.lblBaseSalary.Location = new System.Drawing.Point(12, 155);
            this.lblBaseSalary.Name = "lblBaseSalary";
            this.lblBaseSalary.Size = new System.Drawing.Size(66, 13);
            this.lblBaseSalary.TabIndex = 10;
            this.lblBaseSalary.Text = "Base Salary";
            // 
            // numBaseSalary
            // 
            this.numBaseSalary.DecimalPlaces = 2;
            this.numBaseSalary.Location = new System.Drawing.Point(160, 153);
            this.numBaseSalary.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBaseSalary.Name = "numBaseSalary";
            this.numBaseSalary.Size = new System.Drawing.Size(120, 20);
            this.numBaseSalary.TabIndex = 11;
            // 
            // lblHourlyRate
            // 
            this.lblHourlyRate.AutoSize = true;
            this.lblHourlyRate.Location = new System.Drawing.Point(12, 183);
            this.lblHourlyRate.Name = "lblHourlyRate";
            this.lblHourlyRate.Size = new System.Drawing.Size(62, 13);
            this.lblHourlyRate.TabIndex = 12;
            this.lblHourlyRate.Text = "Hourly Rate";
            // 
            // numHourlyRate
            // 
            this.numHourlyRate.DecimalPlaces = 2;
            this.numHourlyRate.Location = new System.Drawing.Point(160, 181);
            this.numHourlyRate.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numHourlyRate.Name = "numHourlyRate";
            this.numHourlyRate.Size = new System.Drawing.Size(120, 20);
            this.numHourlyRate.TabIndex = 13;
            // 
            // lblAllowances
            // 
            this.lblAllowances.AutoSize = true;
            this.lblAllowances.Location = new System.Drawing.Point(12, 211);
            this.lblAllowances.Name = "lblAllowances";
            this.lblAllowances.Size = new System.Drawing.Size(63, 13);
            this.lblAllowances.TabIndex = 14;
            this.lblAllowances.Text = "Allowances";
            // 
            // numAllowances
            // 
            this.numAllowances.DecimalPlaces = 2;
            this.numAllowances.Location = new System.Drawing.Point(160, 209);
            this.numAllowances.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numAllowances.Name = "numAllowances";
            this.numAllowances.Size = new System.Drawing.Size(120, 20);
            this.numAllowances.TabIndex = 15;
            // 
            // lblBonus
            // 
            this.lblBonus.AutoSize = true;
            this.lblBonus.Location = new System.Drawing.Point(12, 239);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(69, 13);
            this.lblBonus.TabIndex = 16;
            this.lblBonus.Text = "BonusPolicy";
            // 
            // numBonus
            // 
            this.numBonus.DecimalPlaces = 2;
            this.numBonus.Location = new System.Drawing.Point(160, 237);
            this.numBonus.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBonus.Name = "numBonus";
            this.numBonus.Size = new System.Drawing.Size(120, 20);
            this.numBonus.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(241, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numBonus);
            this.Controls.Add(this.lblBonus);
            this.Controls.Add(this.numAllowances);
            this.Controls.Add(this.lblAllowances);
            this.Controls.Add(this.numHourlyRate);
            this.Controls.Add(this.lblHourlyRate);
            this.Controls.Add(this.numBaseSalary);
            this.Controls.Add(this.lblBaseSalary);
            this.Controls.Add(this.cboSalaryModel);
            this.Controls.Add(this.lblSalaryModel);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cboContractType);
            this.Controls.Add(this.lblContractType);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.lblStaffId);
            this.Name = "AddContracts";
            this.Text = "Add Contract";
            ((System.ComponentModel.ISupportInitialize)(this.numBaseSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourlyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBonus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaffId;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.Label lblContractType;
        private System.Windows.Forms.ComboBox cboContractType;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblSalaryModel;
        private System.Windows.Forms.ComboBox cboSalaryModel;
        private System.Windows.Forms.Label lblBaseSalary;
        private System.Windows.Forms.NumericUpDown numBaseSalary;
        private System.Windows.Forms.Label lblHourlyRate;
        private System.Windows.Forms.NumericUpDown numHourlyRate;
        private System.Windows.Forms.Label lblAllowances;
        private System.Windows.Forms.NumericUpDown numAllowances;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.NumericUpDown numBonus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}