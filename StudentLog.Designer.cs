namespace LoginRegister
{
    partial class StudentLog
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.studentid = new System.Windows.Forms.Label();
            this.lastnametxt = new System.Windows.Forms.TextBox();
            this.studentidtxt = new System.Windows.Forms.TextBox();
            this.firstnametxt = new System.Windows.Forms.TextBox();
            this.addstudentbtn = new System.Windows.Forms.Button();
            this.deletestudentbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(161, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 28);
            this.label3.TabIndex = 23;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(161, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "First Name";
            // 
            // studentid
            // 
            this.studentid.AutoSize = true;
            this.studentid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentid.ForeColor = System.Drawing.Color.DarkBlue;
            this.studentid.Location = new System.Drawing.Point(161, 101);
            this.studentid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.studentid.Name = "studentid";
            this.studentid.Size = new System.Drawing.Size(104, 28);
            this.studentid.TabIndex = 25;
            this.studentid.Text = "Student ID";
            // 
            // lastnametxt
            // 
            this.lastnametxt.BackColor = System.Drawing.Color.PapayaWhip;
            this.lastnametxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnametxt.Location = new System.Drawing.Point(322, 209);
            this.lastnametxt.Margin = new System.Windows.Forms.Padding(4);
            this.lastnametxt.Name = "lastnametxt";
            this.lastnametxt.Size = new System.Drawing.Size(302, 34);
            this.lastnametxt.TabIndex = 20;
            this.lastnametxt.TextChanged += new System.EventHandler(this.lastnametxt_TextChanged);
            // 
            // studentidtxt
            // 
            this.studentidtxt.BackColor = System.Drawing.Color.PapayaWhip;
            this.studentidtxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentidtxt.Location = new System.Drawing.Point(324, 101);
            this.studentidtxt.Margin = new System.Windows.Forms.Padding(4);
            this.studentidtxt.Name = "studentidtxt";
            this.studentidtxt.Size = new System.Drawing.Size(300, 34);
            this.studentidtxt.TabIndex = 21;
            this.studentidtxt.TextChanged += new System.EventHandler(this.studentidtxt_TextChanged);
            // 
            // firstnametxt
            // 
            this.firstnametxt.BackColor = System.Drawing.Color.PapayaWhip;
            this.firstnametxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnametxt.Location = new System.Drawing.Point(324, 155);
            this.firstnametxt.Margin = new System.Windows.Forms.Padding(4);
            this.firstnametxt.Name = "firstnametxt";
            this.firstnametxt.Size = new System.Drawing.Size(300, 34);
            this.firstnametxt.TabIndex = 22;
            this.firstnametxt.TextChanged += new System.EventHandler(this.firstnametxt_TextChanged);
            // 
            // addstudentbtn
            // 
            this.addstudentbtn.BackColor = System.Drawing.Color.Moccasin;
            this.addstudentbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addstudentbtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.addstudentbtn.Location = new System.Drawing.Point(330, 266);
            this.addstudentbtn.Name = "addstudentbtn";
            this.addstudentbtn.Size = new System.Drawing.Size(144, 48);
            this.addstudentbtn.TabIndex = 27;
            this.addstudentbtn.Text = "Add Student";
            this.addstudentbtn.UseVisualStyleBackColor = false;
            this.addstudentbtn.Click += new System.EventHandler(this.addstudentbtn_Click);
            // 
            // deletestudentbtn
            // 
            this.deletestudentbtn.BackColor = System.Drawing.Color.Moccasin;
            this.deletestudentbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletestudentbtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.deletestudentbtn.Location = new System.Drawing.Point(480, 266);
            this.deletestudentbtn.Name = "deletestudentbtn";
            this.deletestudentbtn.Size = new System.Drawing.Size(144, 48);
            this.deletestudentbtn.TabIndex = 27;
            this.deletestudentbtn.Text = "Delete";
            this.deletestudentbtn.UseVisualStyleBackColor = false;
            this.deletestudentbtn.Click += new System.EventHandler(this.deletestudentbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginRegister.Properties.Resources.logo_uc2;
            this.pictureBox1.Location = new System.Drawing.Point(186, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(327, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 62);
            this.label1.TabIndex = 28;
            this.label1.Text = "Student Log";
            // 
            // StudentDataGrid
            // 
            this.StudentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDataGrid.Location = new System.Drawing.Point(136, 350);
            this.StudentDataGrid.Name = "StudentDataGrid";
            this.StudentDataGrid.RowHeadersWidth = 51;
            this.StudentDataGrid.RowTemplate.Height = 24;
            this.StudentDataGrid.Size = new System.Drawing.Size(512, 206);
            this.StudentDataGrid.TabIndex = 30;
            // 
            // StudentLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 586);
            this.Controls.Add(this.StudentDataGrid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deletestudentbtn);
            this.Controls.Add(this.addstudentbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentid);
            this.Controls.Add(this.lastnametxt);
            this.Controls.Add(this.studentidtxt);
            this.Controls.Add(this.firstnametxt);
            this.MaximizeBox = false;
            this.Name = "StudentLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Log";
            this.Load += new System.EventHandler(this.StudentLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label studentid;
        private System.Windows.Forms.TextBox lastnametxt;
        private System.Windows.Forms.TextBox studentidtxt;
        private System.Windows.Forms.TextBox firstnametxt;
        private System.Windows.Forms.Button addstudentbtn;
        private System.Windows.Forms.Button deletestudentbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView StudentDataGrid;
    }
}