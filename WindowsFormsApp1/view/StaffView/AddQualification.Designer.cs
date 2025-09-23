namespace WindowsFormsApp1.view.StaffView
{
    partial class AddQualification
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
            this.lblQualificationType = new System.Windows.Forms.Label();
            this.txtQualificationType = new System.Windows.Forms.TextBox();
            this.lblIssuingOrg = new System.Windows.Forms.Label();
            this.txtIssuingOrg = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.numScore = new System.Windows.Forms.NumericUpDown();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.chkVerified = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).BeginInit();
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
            // lblQualificationType
            // 
            this.lblQualificationType.AutoSize = true;
            this.lblQualificationType.Location = new System.Drawing.Point(12, 43);
            this.lblQualificationType.Name = "lblQualificationType";
            this.lblQualificationType.Size = new System.Drawing.Size(96, 13);
            this.lblQualificationType.TabIndex = 2;
            this.lblQualificationType.Text = "Qualification Type";
            // 
            // txtQualificationType
            // 
            this.txtQualificationType.Location = new System.Drawing.Point(160, 40);
            this.txtQualificationType.Name = "txtQualificationType";
            this.txtQualificationType.Size = new System.Drawing.Size(280, 20);
            this.txtQualificationType.TabIndex = 3;
            // 
            // lblIssuingOrg
            // 
            this.lblIssuingOrg.AutoSize = true;
            this.lblIssuingOrg.Location = new System.Drawing.Point(12, 71);
            this.lblIssuingOrg.Name = "lblIssuingOrg";
            this.lblIssuingOrg.Size = new System.Drawing.Size(101, 13);
            this.lblIssuingOrg.TabIndex = 4;
            this.lblIssuingOrg.Text = "Issuing Organization";
            // 
            // txtIssuingOrg
            // 
            this.txtIssuingOrg.Location = new System.Drawing.Point(160, 68);
            this.txtIssuingOrg.Name = "txtIssuingOrg";
            this.txtIssuingOrg.Size = new System.Drawing.Size(280, 20);
            this.txtIssuingOrg.TabIndex = 5;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(12, 99);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(35, 13);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Score";
            // 
            // numScore
            // 
            this.numScore.DecimalPlaces = 2;
            this.numScore.Location = new System.Drawing.Point(160, 97);
            this.numScore.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numScore.Name = "numScore";
            this.numScore.Size = new System.Drawing.Size(120, 20);
            this.numScore.TabIndex = 7;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(12, 127);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(58, 13);
            this.lblIssueDate.TabIndex = 8;
            this.lblIssueDate.Text = "Issue Date";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Location = new System.Drawing.Point(160, 124);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpIssueDate.TabIndex = 9;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(12, 155);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(62, 13);
            this.lblExpiryDate.TabIndex = 10;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Location = new System.Drawing.Point(160, 152);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.ShowCheckBox = true;
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 20);
            this.dtpExpiryDate.TabIndex = 11;
            // 
            // chkVerified
            // 
            this.chkVerified.AutoSize = true;
            this.chkVerified.Location = new System.Drawing.Point(160, 184);
            this.chkVerified.Name = "chkVerified";
            this.chkVerified.Size = new System.Drawing.Size(63, 17);
            this.chkVerified.TabIndex = 12;
            this.chkVerified.Text = "Verified";
            this.chkVerified.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(241, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddQualification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkVerified);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.dtpIssueDate);
            this.Controls.Add(this.lblIssueDate);
            this.Controls.Add(this.numScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.txtIssuingOrg);
            this.Controls.Add(this.lblIssuingOrg);
            this.Controls.Add(this.txtQualificationType);
            this.Controls.Add(this.lblQualificationType);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.lblStaffId);
            this.Name = "AddQualification";
            this.Text = "Add Qualification";
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaffId;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.Label lblQualificationType;
        private System.Windows.Forms.TextBox txtQualificationType;
        private System.Windows.Forms.Label lblIssuingOrg;
        private System.Windows.Forms.TextBox txtIssuingOrg;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.NumericUpDown numScore;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.CheckBox chkVerified;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}