namespace WindowsFormsApp1.view.StaffView
{
    partial class UpdateStaff
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblEmploymentType = new System.Windows.Forms.Label();
            this.cboEmploymentType = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblTerminationDate = new System.Windows.Forms.Label();
            this.dtpTerminationDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblContactInfo = new System.Windows.Forms.Label();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.btnSaveStaff = new System.Windows.Forms.Button();
            this.grpQual = new System.Windows.Forms.GroupBox();
            this.dgvQual = new System.Windows.Forms.DataGridView();
            this.lblQType = new System.Windows.Forms.Label();
            this.txtQType = new System.Windows.Forms.TextBox();
            this.lblQOrg = new System.Windows.Forms.Label();
            this.txtQOrg = new System.Windows.Forms.TextBox();
            this.lblQScore = new System.Windows.Forms.Label();
            this.numQScore = new System.Windows.Forms.NumericUpDown();
            this.lblQIssue = new System.Windows.Forms.Label();
            this.dtpQIssue = new System.Windows.Forms.DateTimePicker();
            this.lblQExpiry = new System.Windows.Forms.Label();
            this.dtpQExpiry = new System.Windows.Forms.DateTimePicker();
            this.chkQVerified = new System.Windows.Forms.CheckBox();
            this.btnSaveQual = new System.Windows.Forms.Button();
            this.grpContract = new System.Windows.Forms.GroupBox();
            this.dgvContract = new System.Windows.Forms.DataGridView();
            this.lblCType = new System.Windows.Forms.Label();
            this.cboCType = new System.Windows.Forms.ComboBox();
            this.lblCStart = new System.Windows.Forms.Label();
            this.dtpCStart = new System.Windows.Forms.DateTimePicker();
            this.lblCEnd = new System.Windows.Forms.Label();
            this.dtpCEnd = new System.Windows.Forms.DateTimePicker();
            this.lblCSalaryModel = new System.Windows.Forms.Label();
            this.cboCSalaryModel = new System.Windows.Forms.ComboBox();
            this.lblCBase = new System.Windows.Forms.Label();
            this.numCBase = new System.Windows.Forms.NumericUpDown();
            this.lblCHourly = new System.Windows.Forms.Label();
            this.numCHourly = new System.Windows.Forms.NumericUpDown();
            this.lblCAllow = new System.Windows.Forms.Label();
            this.numCAllow = new System.Windows.Forms.NumericUpDown();
            this.lblCBonus = new System.Windows.Forms.Label();
            this.numCBonus = new System.Windows.Forms.NumericUpDown();
            this.btnSaveContract = new System.Windows.Forms.Button();
            this.grpQual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQScore)).BeginInit();
            this.grpContract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCHourly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCAllow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCBonus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStaffId
            // 
            this.lblStaffId.AutoSize = true;
            this.lblStaffId.Location = new System.Drawing.Point(12, 15);
            this.lblStaffId.Name = "lblStaffId";
            this.lblStaffId.Size = new System.Drawing.Size(41, 13);
            this.lblStaffId.TabIndex = 26;
            this.lblStaffId.Text = "Staff Id";
            // 
            // txtStaffId
            // 
            this.txtStaffId.Location = new System.Drawing.Point(80, 12);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.ReadOnly = true;
            this.txtStaffId.Size = new System.Drawing.Size(250, 20);
            this.txtStaffId.TabIndex = 25;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(12, 43);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(54, 13);
            this.lblFullName.TabIndex = 24;
            this.lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(80, 40);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(250, 20);
            this.txtFullName.TabIndex = 23;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(350, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(29, 13);
            this.lblRole.TabIndex = 22;
            this.lblRole.Text = "Role";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Items.AddRange(new object[] {
            "Teacher",
            "Assistant",
            "Counselor",
            "Admin",
            "Accountant"});
            this.cboRole.Location = new System.Drawing.Point(390, 12);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(160, 21);
            this.cboRole.TabIndex = 21;
            // 
            // lblEmploymentType
            // 
            this.lblEmploymentType.AutoSize = true;
            this.lblEmploymentType.Location = new System.Drawing.Point(350, 43);
            this.lblEmploymentType.Name = "lblEmploymentType";
            this.lblEmploymentType.Size = new System.Drawing.Size(64, 13);
            this.lblEmploymentType.TabIndex = 20;
            this.lblEmploymentType.Text = "Employment";
            // 
            // cboEmploymentType
            // 
            this.cboEmploymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmploymentType.Items.AddRange(new object[] {
            "Full-time",
            "Part-time",
            "Freelancer"});
            this.cboEmploymentType.Location = new System.Drawing.Point(420, 40);
            this.cboEmploymentType.Name = "cboEmploymentType";
            this.cboEmploymentType.Size = new System.Drawing.Size(130, 21);
            this.cboEmploymentType.TabIndex = 19;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 71);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(80, 68);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 20);
            this.txtPhone.TabIndex = 17;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(350, 71);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(390, 68);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(12, 99);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(26, 13);
            this.lblHireDate.TabIndex = 14;
            this.lblHireDate.Text = "Hire";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Location = new System.Drawing.Point(80, 96);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.ShowCheckBox = true;
            this.dtpHireDate.Size = new System.Drawing.Size(160, 20);
            this.dtpHireDate.TabIndex = 13;
            // 
            // lblTerminationDate
            // 
            this.lblTerminationDate.AutoSize = true;
            this.lblTerminationDate.Location = new System.Drawing.Point(250, 99);
            this.lblTerminationDate.Name = "lblTerminationDate";
            this.lblTerminationDate.Size = new System.Drawing.Size(62, 13);
            this.lblTerminationDate.TabIndex = 12;
            this.lblTerminationDate.Text = "Termination";
            // 
            // dtpTerminationDate
            // 
            this.dtpTerminationDate.Location = new System.Drawing.Point(320, 96);
            this.dtpTerminationDate.Name = "dtpTerminationDate";
            this.dtpTerminationDate.ShowCheckBox = true;
            this.dtpTerminationDate.Size = new System.Drawing.Size(160, 20);
            this.dtpTerminationDate.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(490, 99);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Items.AddRange(new object[] {
            "Onboarding ",
            "Active ",
            "Suspended",
            "Terminated"});
            this.cboStatus.Location = new System.Drawing.Point(535, 96);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(100, 21);
            this.cboStatus.TabIndex = 9;
            // 
            // lblContactInfo
            // 
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.Location = new System.Drawing.Point(12, 127);
            this.lblContactInfo.Name = "lblContactInfo";
            this.lblContactInfo.Size = new System.Drawing.Size(44, 13);
            this.lblContactInfo.TabIndex = 8;
            this.lblContactInfo.Text = "Contact";
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(80, 124);
            this.txtContactInfo.Multiline = true;
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(250, 50);
            this.txtContactInfo.TabIndex = 7;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(350, 127);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(32, 13);
            this.lblBank.TabIndex = 6;
            this.lblBank.Text = "Bank";
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(390, 124);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(160, 20);
            this.txtBank.TabIndex = 5;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(12, 182);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(25, 13);
            this.lblTax.TabIndex = 4;
            this.lblTax.Text = "Tax";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(80, 179);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(250, 20);
            this.txtTax.TabIndex = 3;
            // 
            // btnSaveStaff
            // 
            this.btnSaveStaff.Location = new System.Drawing.Point(535, 176);
            this.btnSaveStaff.Name = "btnSaveStaff";
            this.btnSaveStaff.Size = new System.Drawing.Size(100, 26);
            this.btnSaveStaff.TabIndex = 2;
            this.btnSaveStaff.Text = "Save Staff";
            this.btnSaveStaff.Click += new System.EventHandler(this.btnSaveStaff_Click);
            // 
            // grpQual
            // 
            this.grpQual.Controls.Add(this.dgvQual);
            this.grpQual.Controls.Add(this.lblQType);
            this.grpQual.Controls.Add(this.txtQType);
            this.grpQual.Controls.Add(this.lblQOrg);
            this.grpQual.Controls.Add(this.txtQOrg);
            this.grpQual.Controls.Add(this.lblQScore);
            this.grpQual.Controls.Add(this.numQScore);
            this.grpQual.Controls.Add(this.lblQIssue);
            this.grpQual.Controls.Add(this.dtpQIssue);
            this.grpQual.Controls.Add(this.lblQExpiry);
            this.grpQual.Controls.Add(this.dtpQExpiry);
            this.grpQual.Controls.Add(this.chkQVerified);
            this.grpQual.Controls.Add(this.btnSaveQual);
            this.grpQual.Location = new System.Drawing.Point(12, 210);
            this.grpQual.Name = "grpQual";
            this.grpQual.Size = new System.Drawing.Size(760, 190);
            this.grpQual.TabIndex = 1;
            this.grpQual.TabStop = false;
            this.grpQual.Text = "Qualifications";
            // 
            // dgvQual
            // 
            this.dgvQual.Location = new System.Drawing.Point(10, 20);
            this.dgvQual.MultiSelect = false;
            this.dgvQual.Name = "dgvQual";
            this.dgvQual.ReadOnly = true;
            this.dgvQual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQual.Size = new System.Drawing.Size(430, 160);
            this.dgvQual.TabIndex = 0;
            this.dgvQual.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQual_CellClick);
            // 
            // lblQType
            // 
            this.lblQType.AutoSize = true;
            this.lblQType.Location = new System.Drawing.Point(450, 28);
            this.lblQType.Name = "lblQType";
            this.lblQType.Size = new System.Drawing.Size(31, 13);
            this.lblQType.TabIndex = 1;
            this.lblQType.Text = "Type";
            // 
            // txtQType
            // 
            this.txtQType.Location = new System.Drawing.Point(510, 25);
            this.txtQType.Name = "txtQType";
            this.txtQType.Size = new System.Drawing.Size(230, 20);
            this.txtQType.TabIndex = 2;
            // 
            // lblQOrg
            // 
            this.lblQOrg.AutoSize = true;
            this.lblQOrg.Location = new System.Drawing.Point(450, 55);
            this.lblQOrg.Name = "lblQOrg";
            this.lblQOrg.Size = new System.Drawing.Size(24, 13);
            this.lblQOrg.TabIndex = 3;
            this.lblQOrg.Text = "Org";
            // 
            // txtQOrg
            // 
            this.txtQOrg.Location = new System.Drawing.Point(510, 52);
            this.txtQOrg.Name = "txtQOrg";
            this.txtQOrg.Size = new System.Drawing.Size(230, 20);
            this.txtQOrg.TabIndex = 4;
            // 
            // lblQScore
            // 
            this.lblQScore.AutoSize = true;
            this.lblQScore.Location = new System.Drawing.Point(450, 82);
            this.lblQScore.Name = "lblQScore";
            this.lblQScore.Size = new System.Drawing.Size(35, 13);
            this.lblQScore.TabIndex = 5;
            this.lblQScore.Text = "Score";
            // 
            // numQScore
            // 
            this.numQScore.DecimalPlaces = 2;
            this.numQScore.Location = new System.Drawing.Point(510, 80);
            this.numQScore.Name = "numQScore";
            this.numQScore.Size = new System.Drawing.Size(100, 20);
            this.numQScore.TabIndex = 6;
            // 
            // lblQIssue
            // 
            this.lblQIssue.AutoSize = true;
            this.lblQIssue.Location = new System.Drawing.Point(450, 110);
            this.lblQIssue.Name = "lblQIssue";
            this.lblQIssue.Size = new System.Drawing.Size(32, 13);
            this.lblQIssue.TabIndex = 7;
            this.lblQIssue.Text = "Issue";
            // 
            // dtpQIssue
            // 
            this.dtpQIssue.Location = new System.Drawing.Point(510, 107);
            this.dtpQIssue.Name = "dtpQIssue";
            this.dtpQIssue.Size = new System.Drawing.Size(140, 20);
            this.dtpQIssue.TabIndex = 8;
            // 
            // lblQExpiry
            // 
            this.lblQExpiry.AutoSize = true;
            this.lblQExpiry.Location = new System.Drawing.Point(450, 138);
            this.lblQExpiry.Name = "lblQExpiry";
            this.lblQExpiry.Size = new System.Drawing.Size(35, 13);
            this.lblQExpiry.TabIndex = 9;
            this.lblQExpiry.Text = "Expiry";
            // 
            // dtpQExpiry
            // 
            this.dtpQExpiry.Location = new System.Drawing.Point(510, 135);
            this.dtpQExpiry.Name = "dtpQExpiry";
            this.dtpQExpiry.ShowCheckBox = true;
            this.dtpQExpiry.Size = new System.Drawing.Size(140, 20);
            this.dtpQExpiry.TabIndex = 10;
            // 
            // chkQVerified
            // 
            this.chkQVerified.AutoSize = true;
            this.chkQVerified.Location = new System.Drawing.Point(660, 80);
            this.chkQVerified.Name = "chkQVerified";
            this.chkQVerified.Size = new System.Drawing.Size(61, 17);
            this.chkQVerified.TabIndex = 11;
            this.chkQVerified.Text = "Verified";
            // 
            // btnSaveQual
            // 
            this.btnSaveQual.Location = new System.Drawing.Point(660, 160);
            this.btnSaveQual.Name = "btnSaveQual";
            this.btnSaveQual.Size = new System.Drawing.Size(80, 23);
            this.btnSaveQual.TabIndex = 12;
            this.btnSaveQual.Text = "Save";
            this.btnSaveQual.Click += new System.EventHandler(this.btnSaveQual_Click);
            // 
            // grpContract
            // 
            this.grpContract.Controls.Add(this.dgvContract);
            this.grpContract.Controls.Add(this.lblCType);
            this.grpContract.Controls.Add(this.cboCType);
            this.grpContract.Controls.Add(this.lblCStart);
            this.grpContract.Controls.Add(this.dtpCStart);
            this.grpContract.Controls.Add(this.lblCEnd);
            this.grpContract.Controls.Add(this.dtpCEnd);
            this.grpContract.Controls.Add(this.lblCSalaryModel);
            this.grpContract.Controls.Add(this.cboCSalaryModel);
            this.grpContract.Controls.Add(this.lblCBase);
            this.grpContract.Controls.Add(this.numCBase);
            this.grpContract.Controls.Add(this.lblCHourly);
            this.grpContract.Controls.Add(this.numCHourly);
            this.grpContract.Controls.Add(this.lblCAllow);
            this.grpContract.Controls.Add(this.numCAllow);
            this.grpContract.Controls.Add(this.lblCBonus);
            this.grpContract.Controls.Add(this.numCBonus);
            this.grpContract.Controls.Add(this.btnSaveContract);
            this.grpContract.Location = new System.Drawing.Point(12, 410);
            this.grpContract.Name = "grpContract";
            this.grpContract.Size = new System.Drawing.Size(760, 210);
            this.grpContract.TabIndex = 0;
            this.grpContract.TabStop = false;
            this.grpContract.Text = "Contracts";
            // 
            // dgvContract
            // 
            this.dgvContract.Location = new System.Drawing.Point(10, 20);
            this.dgvContract.MultiSelect = false;
            this.dgvContract.Name = "dgvContract";
            this.dgvContract.ReadOnly = true;
            this.dgvContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContract.Size = new System.Drawing.Size(430, 180);
            this.dgvContract.TabIndex = 0;
            this.dgvContract.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContract_CellClick);
            // 
            // lblCType
            // 
            this.lblCType.AutoSize = true;
            this.lblCType.Location = new System.Drawing.Point(450, 25);
            this.lblCType.Name = "lblCType";
            this.lblCType.Size = new System.Drawing.Size(31, 13);
            this.lblCType.TabIndex = 1;
            this.lblCType.Text = "Type";
            // 
            // cboCType
            // 
            this.cboCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCType.Items.AddRange(new object[] {
            "Full-time",
            "Part-time",
            "Freelance"});
            this.cboCType.Location = new System.Drawing.Point(530, 22);
            this.cboCType.Name = "cboCType";
            this.cboCType.Size = new System.Drawing.Size(210, 21);
            this.cboCType.TabIndex = 2;
            // 
            // lblCStart
            // 
            this.lblCStart.AutoSize = true;
            this.lblCStart.Location = new System.Drawing.Point(450, 52);
            this.lblCStart.Name = "lblCStart";
            this.lblCStart.Size = new System.Drawing.Size(29, 13);
            this.lblCStart.TabIndex = 3;
            this.lblCStart.Text = "Start";
            // 
            // dtpCStart
            // 
            this.dtpCStart.Location = new System.Drawing.Point(530, 49);
            this.dtpCStart.Name = "dtpCStart";
            this.dtpCStart.Size = new System.Drawing.Size(140, 20);
            this.dtpCStart.TabIndex = 4;
            // 
            // lblCEnd
            // 
            this.lblCEnd.AutoSize = true;
            this.lblCEnd.Location = new System.Drawing.Point(450, 79);
            this.lblCEnd.Name = "lblCEnd";
            this.lblCEnd.Size = new System.Drawing.Size(26, 13);
            this.lblCEnd.TabIndex = 5;
            this.lblCEnd.Text = "End";
            // 
            // dtpCEnd
            // 
            this.dtpCEnd.Location = new System.Drawing.Point(530, 76);
            this.dtpCEnd.Name = "dtpCEnd";
            this.dtpCEnd.ShowCheckBox = true;
            this.dtpCEnd.Size = new System.Drawing.Size(140, 20);
            this.dtpCEnd.TabIndex = 6;
            // 
            // lblCSalaryModel
            // 
            this.lblCSalaryModel.AutoSize = true;
            this.lblCSalaryModel.Location = new System.Drawing.Point(450, 106);
            this.lblCSalaryModel.Name = "lblCSalaryModel";
            this.lblCSalaryModel.Size = new System.Drawing.Size(68, 13);
            this.lblCSalaryModel.TabIndex = 7;
            this.lblCSalaryModel.Text = "Salary Model";
            // 
            // cboCSalaryModel
            // 
            this.cboCSalaryModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCSalaryModel.Items.AddRange(new object[] {
            "Fixed",
            "Hourly",
            "Cố định",
            "Theo giờ"});
            this.cboCSalaryModel.Location = new System.Drawing.Point(530, 103);
            this.cboCSalaryModel.Name = "cboCSalaryModel";
            this.cboCSalaryModel.Size = new System.Drawing.Size(210, 21);
            this.cboCSalaryModel.TabIndex = 8;
            // 
            // lblCBase
            // 
            this.lblCBase.AutoSize = true;
            this.lblCBase.Location = new System.Drawing.Point(450, 133);
            this.lblCBase.Name = "lblCBase";
            this.lblCBase.Size = new System.Drawing.Size(31, 13);
            this.lblCBase.TabIndex = 9;
            this.lblCBase.Text = "Base";
            // 
            // numCBase
            // 
            this.numCBase.DecimalPlaces = 2;
            this.numCBase.Location = new System.Drawing.Point(530, 131);
            this.numCBase.Name = "numCBase";
            this.numCBase.Size = new System.Drawing.Size(100, 20);
            this.numCBase.TabIndex = 10;
            // 
            // lblCHourly
            // 
            this.lblCHourly.AutoSize = true;
            this.lblCHourly.Location = new System.Drawing.Point(450, 160);
            this.lblCHourly.Name = "lblCHourly";
            this.lblCHourly.Size = new System.Drawing.Size(37, 13);
            this.lblCHourly.TabIndex = 11;
            this.lblCHourly.Text = "Hourly";
            // 
            // numCHourly
            // 
            this.numCHourly.DecimalPlaces = 2;
            this.numCHourly.Location = new System.Drawing.Point(530, 158);
            this.numCHourly.Name = "numCHourly";
            this.numCHourly.Size = new System.Drawing.Size(100, 20);
            this.numCHourly.TabIndex = 12;
            // 
            // lblCAllow
            // 
            this.lblCAllow.AutoSize = true;
            this.lblCAllow.Location = new System.Drawing.Point(640, 133);
            this.lblCAllow.Name = "lblCAllow";
            this.lblCAllow.Size = new System.Drawing.Size(32, 13);
            this.lblCAllow.TabIndex = 13;
            this.lblCAllow.Text = "Allow";
            // 
            // numCAllow
            // 
            this.numCAllow.DecimalPlaces = 2;
            this.numCAllow.Location = new System.Drawing.Point(680, 131);
            this.numCAllow.Name = "numCAllow";
            this.numCAllow.Size = new System.Drawing.Size(100, 20);
            this.numCAllow.TabIndex = 14;
            // 
            // lblCBonus
            // 
            this.lblCBonus.AutoSize = true;
            this.lblCBonus.Location = new System.Drawing.Point(640, 160);
            this.lblCBonus.Name = "lblCBonus";
            this.lblCBonus.Size = new System.Drawing.Size(37, 13);
            this.lblCBonus.TabIndex = 15;
            this.lblCBonus.Text = "Bonus";
            // 
            // numCBonus
            // 
            this.numCBonus.DecimalPlaces = 2;
            this.numCBonus.Location = new System.Drawing.Point(680, 158);
            this.numCBonus.Name = "numCBonus";
            this.numCBonus.Size = new System.Drawing.Size(100, 20);
            this.numCBonus.TabIndex = 16;
            // 
            // btnSaveContract
            // 
            this.btnSaveContract.Location = new System.Drawing.Point(660, 184);
            this.btnSaveContract.Name = "btnSaveContract";
            this.btnSaveContract.Size = new System.Drawing.Size(80, 23);
            this.btnSaveContract.TabIndex = 17;
            this.btnSaveContract.Text = "Save";
            this.btnSaveContract.Click += new System.EventHandler(this.btnSaveContract_Click);
            // 
            // UpdateStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 631);
            this.Controls.Add(this.grpContract);
            this.Controls.Add(this.grpQual);
            this.Controls.Add(this.btnSaveStaff);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.lblContactInfo);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpTerminationDate);
            this.Controls.Add(this.lblTerminationDate);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.cboEmploymentType);
            this.Controls.Add(this.lblEmploymentType);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.lblStaffId);
            this.Name = "UpdateStaff";
            this.Text = "Update Staff";
            this.grpQual.ResumeLayout(false);
            this.grpQual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQScore)).EndInit();
            this.grpContract.ResumeLayout(false);
            this.grpContract.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCHourly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCAllow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCBonus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblStaffId;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblEmploymentType;
        private System.Windows.Forms.ComboBox cboEmploymentType;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label lblTerminationDate;
        private System.Windows.Forms.DateTimePicker dtpTerminationDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblContactInfo;
        private System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Button btnSaveStaff;
        private System.Windows.Forms.GroupBox grpQual;
        private System.Windows.Forms.DataGridView dgvQual;
        private System.Windows.Forms.Label lblQType;
        private System.Windows.Forms.TextBox txtQType;
        private System.Windows.Forms.Label lblQOrg;
        private System.Windows.Forms.TextBox txtQOrg;
        private System.Windows.Forms.Label lblQScore;
        private System.Windows.Forms.NumericUpDown numQScore;
        private System.Windows.Forms.Label lblQIssue;
        private System.Windows.Forms.DateTimePicker dtpQIssue;
        private System.Windows.Forms.Label lblQExpiry;
        private System.Windows.Forms.DateTimePicker dtpQExpiry;
        private System.Windows.Forms.CheckBox chkQVerified;
        private System.Windows.Forms.Button btnSaveQual;
        private System.Windows.Forms.GroupBox grpContract;
        private System.Windows.Forms.DataGridView dgvContract;
        private System.Windows.Forms.Label lblCType;
        private System.Windows.Forms.ComboBox cboCType;
        private System.Windows.Forms.Label lblCStart;
        private System.Windows.Forms.DateTimePicker dtpCStart;
        private System.Windows.Forms.Label lblCEnd;
        private System.Windows.Forms.DateTimePicker dtpCEnd;
        private System.Windows.Forms.Label lblCSalaryModel;
        private System.Windows.Forms.ComboBox cboCSalaryModel;
        private System.Windows.Forms.Label lblCBase;
        private System.Windows.Forms.NumericUpDown numCBase;
        private System.Windows.Forms.Label lblCHourly;
        private System.Windows.Forms.NumericUpDown numCHourly;
        private System.Windows.Forms.Label lblCAllow;
        private System.Windows.Forms.NumericUpDown numCAllow;
        private System.Windows.Forms.Label lblCBonus;
        private System.Windows.Forms.NumericUpDown numCBonus;
        private System.Windows.Forms.Button btnSaveContract;
    }
}