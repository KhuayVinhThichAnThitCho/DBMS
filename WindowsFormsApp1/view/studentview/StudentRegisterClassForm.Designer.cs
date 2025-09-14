namespace WindowsFormsApp1.view.studentview
{
    partial class StudentRegisterClassForm
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
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lv1 = new System.Windows.Forms.Label();
            this.txtStudentCode = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lv2 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.lv3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lv4 = new System.Windows.Forms.Label();
            this.txtCurrentLevel = new System.Windows.Forms.TextBox();
            this.lv5 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(34, 53);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(264, 26);
            this.txtPhone.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(317, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tim";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lv1
            // 
            this.lv1.AutoSize = true;
            this.lv1.Location = new System.Drawing.Point(34, 122);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(94, 20);
            this.lv1.TabIndex = 2;
            this.lv1.Text = "Mã học sinh";
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.Location = new System.Drawing.Point(153, 122);
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.Size = new System.Drawing.Size(239, 26);
            this.txtStudentCode.TabIndex = 3;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(153, 171);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(239, 26);
            this.txtFullName.TabIndex = 5;
            // 
            // lv2
            // 
            this.lv2.AutoSize = true;
            this.lv2.Location = new System.Drawing.Point(34, 171);
            this.lv2.Name = "lv2";
            this.lv2.Size = new System.Drawing.Size(57, 20);
            this.lv2.TabIndex = 4;
            this.lv2.Text = "Họ tên";
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(153, 228);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(239, 26);
            this.txtPhone1.TabIndex = 7;
            // 
            // lv3
            // 
            this.lv3.AutoSize = true;
            this.lv3.Location = new System.Drawing.Point(34, 228);
            this.lv3.Name = "lv3";
            this.lv3.Size = new System.Drawing.Size(102, 20);
            this.lv3.TabIndex = 6;
            this.lv3.Text = "Số điện thoại";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(153, 288);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(239, 26);
            this.txtEmail.TabIndex = 9;
            // 
            // lv4
            // 
            this.lv4.AutoSize = true;
            this.lv4.Location = new System.Drawing.Point(34, 288);
            this.lv4.Name = "lv4";
            this.lv4.Size = new System.Drawing.Size(48, 20);
            this.lv4.TabIndex = 8;
            this.lv4.Text = "Email";
            // 
            // txtCurrentLevel
            // 
            this.txtCurrentLevel.Location = new System.Drawing.Point(153, 344);
            this.txtCurrentLevel.Name = "txtCurrentLevel";
            this.txtCurrentLevel.Size = new System.Drawing.Size(239, 26);
            this.txtCurrentLevel.TabIndex = 11;
            // 
            // lv5
            // 
            this.lv5.AutoSize = true;
            this.lv5.Location = new System.Drawing.Point(34, 344);
            this.lv5.Name = "lv5";
            this.lv5.Size = new System.Drawing.Size(40, 20);
            this.lv5.TabIndex = 10;
            this.lv5.Text = "level";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(153, 408);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(131, 80);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // StudentRegisterClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 606);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtCurrentLevel);
            this.Controls.Add(this.lv5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lv4);
            this.Controls.Add(this.txtPhone1);
            this.Controls.Add(this.lv3);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lv2);
            this.Controls.Add(this.txtStudentCode);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPhone);
            this.Name = "StudentRegisterClassForm";
            this.Text = "StudentRegisterClassForm";
            this.Load += new System.EventHandler(this.StudentRegisterClassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lv1;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lv2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Label lv3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lv4;
        private System.Windows.Forms.TextBox txtCurrentLevel;
        private System.Windows.Forms.Label lv5;
        private System.Windows.Forms.Button btnRegister;
    }
}