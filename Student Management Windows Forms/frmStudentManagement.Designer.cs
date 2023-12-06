namespace Student_Management_Windows_Forms
{
    partial class frmStudentManagement
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRefresh = new Button();
            dgvStudents = new DataGridView();
            groupBox1 = new GroupBox();
            cboCreateMajor = new ComboBox();
            btnCreateSubmit = new Button();
            btnClear = new Button();
            label3 = new Label();
            txtCreateName = new TextBox();
            label2 = new Label();
            txtCreateCode = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            cboUpdateMajor = new ComboBox();
            btnUpdateSubmit = new Button();
            label4 = new Label();
            txtUpdateName = new TextBox();
            label5 = new Label();
            txtUpdateCode = new TextBox();
            label6 = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(10, 17);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(10, 60);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 29;
            dgvStudents.Size = new Size(689, 356);
            dgvStudents.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboCreateMajor);
            groupBox1.Controls.Add(btnCreateSubmit);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCreateName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCreateCode);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(730, 55);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 189);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create Students";
            // 
            // cboCreateMajor
            // 
            cboCreateMajor.FormattingEnabled = true;
            cboCreateMajor.Location = new Point(64, 112);
            cboCreateMajor.Name = "cboCreateMajor";
            cboCreateMajor.Size = new Size(174, 28);
            cboCreateMajor.TabIndex = 3;
            // 
            // btnCreateSubmit
            // 
            btnCreateSubmit.Location = new Point(150, 154);
            btnCreateSubmit.Name = "btnCreateSubmit";
            btnCreateSubmit.Size = new Size(94, 29);
            btnCreateSubmit.TabIndex = 2;
            btnCreateSubmit.Text = "Submit";
            btnCreateSubmit.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(6, 154);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 115);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 0;
            label3.Text = "Major";
            // 
            // txtCreateName
            // 
            txtCreateName.Location = new Point(64, 68);
            txtCreateName.Name = "txtCreateName";
            txtCreateName.Size = new Size(174, 27);
            txtCreateName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 72);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Name";
            // 
            // txtCreateCode
            // 
            txtCreateCode.Location = new Point(64, 26);
            txtCreateCode.Name = "txtCreateCode";
            txtCreateCode.Size = new Size(174, 27);
            txtCreateCode.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 30);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "Code";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cboUpdateMajor);
            groupBox2.Controls.Add(btnUpdateSubmit);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtUpdateName);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtUpdateCode);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(730, 263);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 189);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Update Students";
            // 
            // cboUpdateMajor
            // 
            cboUpdateMajor.FormattingEnabled = true;
            cboUpdateMajor.Location = new Point(64, 112);
            cboUpdateMajor.Name = "cboUpdateMajor";
            cboUpdateMajor.Size = new Size(174, 28);
            cboUpdateMajor.TabIndex = 3;
            // 
            // btnUpdateSubmit
            // 
            btnUpdateSubmit.Location = new Point(150, 154);
            btnUpdateSubmit.Name = "btnUpdateSubmit";
            btnUpdateSubmit.Size = new Size(94, 29);
            btnUpdateSubmit.TabIndex = 2;
            btnUpdateSubmit.Text = "Submit";
            btnUpdateSubmit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 115);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 0;
            label4.Text = "Major";
            // 
            // txtUpdateName
            // 
            txtUpdateName.Location = new Point(64, 68);
            txtUpdateName.Name = "txtUpdateName";
            txtUpdateName.Size = new Size(174, 27);
            txtUpdateName.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 72);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 0;
            label5.Text = "Name";
            // 
            // txtUpdateCode
            // 
            txtUpdateCode.Location = new Point(64, 26);
            txtUpdateCode.Name = "txtUpdateCode";
            txtUpdateCode.Size = new Size(174, 27);
            txtUpdateCode.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 30);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 0;
            label6.Text = "Code";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(605, 422);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmStudentManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 474);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvStudents);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Name = "frmStudentManagement";
            Text = "Student Management";
            Load += frmStudentManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefresh;
        private DataGridView dgvStudents;
        private GroupBox groupBox1;
        private TextBox txtCreateCode;
        private Label label1;
        private ComboBox cboCreateMajor;
        private Button btnCreateSubmit;
        private Button btnClear;
        private Label label3;
        private TextBox txtCreateName;
        private Label label2;
        private GroupBox groupBox2;
        private ComboBox cboUpdateMajor;
        private Button btnUpdateSubmit;
        private Label label4;
        private TextBox txtUpdateName;
        private Label label5;
        private TextBox txtUpdateCode;
        private Label label6;
        private Button btnDelete;
    }
}