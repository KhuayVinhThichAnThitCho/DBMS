namespace WindowsFormsApp1.view.studentview
{
    partial class StudentsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.create_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1012, 625);
            this.dataGridView1.TabIndex = 0;
            // 
            // create_button
            // 
            this.create_button.Location = new System.Drawing.Point(46, 87);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(96, 39);
            this.create_button.TabIndex = 1;
            this.create_button.Text = "thêm";
            this.create_button.UseVisualStyleBackColor = true;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(170, 87);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(96, 39);
            this.update_button.TabIndex = 2;
            this.update_button.Text = "sửa";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(294, 87);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(96, 39);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "xóa";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // StudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 784);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentsForm";
            this.Text = "StudentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button delete_button;
    }
}