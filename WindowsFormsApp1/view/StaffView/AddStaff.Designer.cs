namespace WindowsFormsApp1.view.StaffView
{
    partial class AddStaff
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.ComboBox();
            this.lblEmploymentType = new System.Windows.Forms.Label();
            this.txtEmploymentType = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblContactInfo = new System.Windows.Forms.Label();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.txtBankAccount = new System.Windows.Forms.TextBox();
            this.lblTaxCode = new System.Windows.Forms.Label();
            this.txtTaxCode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(12, 15);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(57, 13);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(140, 12);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(12, 43);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(29, 13);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Role";
            // 
            // txtRole
            // 
            this.txtRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRole.FormattingEnabled = true;
            this.txtRole.Items.AddRange(new object[] {
            "Teacher",
            "Assistant",
            "Counselor",
            "Admin",
            "Accountant"});
            this.txtRole.Location = new System.Drawing.Point(140, 40);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(300, 21);
            this.txtRole.TabIndex = 3;
            // 
            // lblEmploymentType
            // 
            this.lblEmploymentType.AutoSize = true;
            this.lblEmploymentType.Location = new System.Drawing.Point(12, 71);
            this.lblEmploymentType.Name = "lblEmploymentType";
            this.lblEmploymentType.Size = new System.Drawing.Size(96, 13);
            this.lblEmploymentType.TabIndex = 4;
            this.lblEmploymentType.Text = "Employment Type";
            // 
            // txtEmploymentType
            // 
            this.txtEmploymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEmploymentType.FormattingEnabled = true;
            this.txtEmploymentType.Items.AddRange(new object[] {
            "Full-time",
            "Part-time",
            "Freelancer"});
            this.txtEmploymentType.Location = new System.Drawing.Point(140, 68);
            this.txtEmploymentType.Name = "txtEmploymentType";
            this.txtEmploymentType.Size = new System.Drawing.Size(300, 21);
            this.txtEmploymentType.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 99);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(140, 96);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 127);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(12, 155);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(52, 13);
            this.lblHireDate.TabIndex = 10;
            this.lblHireDate.Text = "Hire Date";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Location = new System.Drawing.Point(140, 152);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.ShowCheckBox = true;
            this.dtpHireDate.Size = new System.Drawing.Size(200, 20);
            this.dtpHireDate.TabIndex = 11;
            // 
            // lblContactInfo
            // 
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.Location = new System.Drawing.Point(12, 183);
            this.lblContactInfo.Name = "lblContactInfo";
            this.lblContactInfo.Size = new System.Drawing.Size(68, 13);
            this.lblContactInfo.TabIndex = 12;
            this.lblContactInfo.Text = "Contact Info";
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(140, 180);
            this.txtContactInfo.Multiline = true;
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(300, 60);
            this.txtContactInfo.TabIndex = 13;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Location = new System.Drawing.Point(12, 248);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(76, 13);
            this.lblBankAccount.TabIndex = 14;
            this.lblBankAccount.Text = "Bank Account";
            // 
            // txtBankAccount
            // 
            this.txtBankAccount.Location = new System.Drawing.Point(140, 245);
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(300, 20);
            this.txtBankAccount.TabIndex = 15;
            // 
            // lblTaxCode
            // 
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(12, 276);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(56, 13);
            this.lblTaxCode.TabIndex = 16;
            this.lblTaxCode.Text = "Tax Code";
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Location = new System.Drawing.Point(140, 273);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(300, 20);
            this.txtTaxCode.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 350);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTaxCode);
            this.Controls.Add(this.lblTaxCode);
            this.Controls.Add(this.txtBankAccount);
            this.Controls.Add(this.lblBankAccount);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.lblContactInfo);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmploymentType);
            this.Controls.Add(this.lblEmploymentType);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Name = "AddStaff";
            this.Text = "Add Staff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox txtRole;
        private System.Windows.Forms.Label lblEmploymentType;
        private System.Windows.Forms.ComboBox txtEmploymentType;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label lblContactInfo;
        private System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.TextBox txtBankAccount;
        private System.Windows.Forms.Label lblTaxCode;
        private System.Windows.Forms.TextBox txtTaxCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}