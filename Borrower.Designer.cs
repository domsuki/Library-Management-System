namespace LoginRegister
{
    partial class Borrower
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
            this.ReturnBTN = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.quantitytxt = new System.Windows.Forms.TextBox();
            this.authortxt = new System.Windows.Forms.TextBox();
            this.bookidtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.searchBorrowed = new System.Windows.Forms.Label();
            this.BorrowBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.firstnameread = new System.Windows.Forms.TextBox();
            this.lastnameread = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.studentidbox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.borrowerTableAdapter1 = new LoginRegister.NewBorrowDataSetTableAdapters.BorrowerTableAdapter();
            this.borrowerTableAdapter2 = new LoginRegister.TheNewBorrowDataGridTableAdapters.BorrowerTableAdapter();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.returnedSearch = new System.Windows.Forms.TextBox();
            this.bookSearch = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.borrowedSearch = new System.Windows.Forms.TextBox();
            this.BorrowerDataGrid = new System.Windows.Forms.DataGridView();
            this.ReturnedDataGrid = new System.Windows.Forms.DataGridView();
            this.BookDataGrid = new System.Windows.Forms.DataGridView();
            this.TitleComboBox = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnedDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReturnBTN
            // 
            this.ReturnBTN.BackColor = System.Drawing.Color.Moccasin;
            this.ReturnBTN.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBTN.ForeColor = System.Drawing.Color.DarkBlue;
            this.ReturnBTN.Location = new System.Drawing.Point(373, 593);
            this.ReturnBTN.Name = "ReturnBTN";
            this.ReturnBTN.Size = new System.Drawing.Size(144, 48);
            this.ReturnBTN.TabIndex = 21;
            this.ReturnBTN.Text = "Return";
            this.ReturnBTN.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(56, 345);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "Books";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TitleComboBox);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.quantitytxt);
            this.panel2.Controls.Add(this.authortxt);
            this.panel2.Controls.Add(this.bookidtxt);
            this.panel2.Location = new System.Drawing.Point(61, 377);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 209);
            this.panel2.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(559, -50);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 16);
            this.label14.TabIndex = 10;
            this.label14.Text = "Find Books";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(2, 176);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(3, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Author";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(4, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Title";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(4, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 28);
            this.label8.TabIndex = 1;
            this.label8.Text = "Book ID";
            // 
            // quantitytxt
            // 
            this.quantitytxt.BackColor = System.Drawing.Color.PapayaWhip;
            this.quantitytxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantitytxt.Location = new System.Drawing.Point(156, 170);
            this.quantitytxt.Margin = new System.Windows.Forms.Padding(4);
            this.quantitytxt.Name = "quantitytxt";
            this.quantitytxt.Size = new System.Drawing.Size(300, 34);
            this.quantitytxt.TabIndex = 0;
            // 
            // authortxt
            // 
            this.authortxt.BackColor = System.Drawing.Color.PapayaWhip;
            this.authortxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authortxt.Location = new System.Drawing.Point(156, 112);
            this.authortxt.Margin = new System.Windows.Forms.Padding(4);
            this.authortxt.Name = "authortxt";
            this.authortxt.Size = new System.Drawing.Size(300, 34);
            this.authortxt.TabIndex = 0;
            // 
            // bookidtxt
            // 
            this.bookidtxt.BackColor = System.Drawing.Color.PapayaWhip;
            this.bookidtxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookidtxt.Location = new System.Drawing.Point(156, 59);
            this.bookidtxt.Margin = new System.Windows.Forms.Padding(4);
            this.bookidtxt.Name = "bookidtxt";
            this.bookidtxt.Size = new System.Drawing.Size(300, 34);
            this.bookidtxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(563, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 62);
            this.label1.TabIndex = 26;
            this.label1.Text = "Student Transaction Page";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(1223, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Returned Books";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(57, 157);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 28);
            this.label10.TabIndex = 19;
            this.label10.Text = "Student Info";
            // 
            // searchBorrowed
            // 
            this.searchBorrowed.AutoSize = true;
            this.searchBorrowed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBorrowed.ForeColor = System.Drawing.Color.DarkBlue;
            this.searchBorrowed.Location = new System.Drawing.Point(987, 416);
            this.searchBorrowed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchBorrowed.Name = "searchBorrowed";
            this.searchBorrowed.Size = new System.Drawing.Size(150, 28);
            this.searchBorrowed.TabIndex = 1;
            this.searchBorrowed.Text = "Available Books";
            // 
            // BorrowBTN
            // 
            this.BorrowBTN.BackColor = System.Drawing.Color.Moccasin;
            this.BorrowBTN.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowBTN.ForeColor = System.Drawing.Color.DarkBlue;
            this.BorrowBTN.Location = new System.Drawing.Point(223, 593);
            this.BorrowBTN.Name = "BorrowBTN";
            this.BorrowBTN.Size = new System.Drawing.Size(144, 48);
            this.BorrowBTN.TabIndex = 23;
            this.BorrowBTN.Text = "Borrow";
            this.BorrowBTN.UseVisualStyleBackColor = false;
            this.BorrowBTN.Click += new System.EventHandler(this.BorrowBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginRegister.Properties.Resources.logo_uc2;
            this.pictureBox1.Location = new System.Drawing.Point(422, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // firstnameread
            // 
            this.firstnameread.BackColor = System.Drawing.Color.PapayaWhip;
            this.firstnameread.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameread.Location = new System.Drawing.Point(217, 245);
            this.firstnameread.Margin = new System.Windows.Forms.Padding(4);
            this.firstnameread.Name = "firstnameread";
            this.firstnameread.ReadOnly = true;
            this.firstnameread.Size = new System.Drawing.Size(300, 34);
            this.firstnameread.TabIndex = 29;
            // 
            // lastnameread
            // 
            this.lastnameread.BackColor = System.Drawing.Color.PapayaWhip;
            this.lastnameread.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnameread.Location = new System.Drawing.Point(217, 296);
            this.lastnameread.Margin = new System.Windows.Forms.Padding(4);
            this.lastnameread.Name = "lastnameread";
            this.lastnameread.ReadOnly = true;
            this.lastnameread.Size = new System.Drawing.Size(300, 34);
            this.lastnameread.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(63, 193);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(63, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "First Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Location = new System.Drawing.Point(63, 296);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 28);
            this.label12.TabIndex = 1;
            this.label12.Text = "Last Name";
            // 
            // studentidbox
            // 
            this.studentidbox.BackColor = System.Drawing.Color.PapayaWhip;
            this.studentidbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentidbox.FormattingEnabled = true;
            this.studentidbox.Location = new System.Drawing.Point(217, 196);
            this.studentidbox.Name = "studentidbox";
            this.studentidbox.Size = new System.Drawing.Size(300, 36);
            this.studentidbox.TabIndex = 30;
            this.studentidbox.SelectedIndexChanged += new System.EventHandler(this.studentidbox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkBlue;
            this.label13.Location = new System.Drawing.Point(985, 82);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 38);
            this.label13.TabIndex = 19;
            this.label13.Text = "Reports";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkBlue;
            this.label15.Location = new System.Drawing.Point(216, 82);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 38);
            this.label15.TabIndex = 19;
            this.label15.Text = "Borrower";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkBlue;
            this.label16.Location = new System.Drawing.Point(767, 120);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 28);
            this.label16.TabIndex = 1;
            this.label16.Text = "Borrowed";
            // 
            // borrowerTableAdapter1
            // 
            this.borrowerTableAdapter1.ClearBeforeFill = true;
            // 
            // borrowerTableAdapter2
            // 
            this.borrowerTableAdapter2.ClearBeforeFill = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkBlue;
            this.label17.Location = new System.Drawing.Point(578, 159);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 28);
            this.label17.TabIndex = 1;
            this.label17.Text = "Search";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(1056, 156);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 28);
            this.label11.TabIndex = 1;
            this.label11.Text = "Search";
            // 
            // returnedSearch
            // 
            this.returnedSearch.Location = new System.Drawing.Point(1133, 159);
            this.returnedSearch.Name = "returnedSearch";
            this.returnedSearch.Size = new System.Drawing.Size(388, 22);
            this.returnedSearch.TabIndex = 38;
            // 
            // bookSearch
            // 
            this.bookSearch.Location = new System.Drawing.Point(851, 464);
            this.bookSearch.Name = "bookSearch";
            this.bookSearch.Size = new System.Drawing.Size(486, 22);
            this.bookSearch.TabIndex = 38;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkBlue;
            this.label18.Location = new System.Drawing.Point(778, 457);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 28);
            this.label18.TabIndex = 1;
            this.label18.Text = "Search";
            // 
            // borrowedSearch
            // 
            this.borrowedSearch.Location = new System.Drawing.Point(653, 162);
            this.borrowedSearch.Name = "borrowedSearch";
            this.borrowedSearch.Size = new System.Drawing.Size(388, 22);
            this.borrowedSearch.TabIndex = 38;
            // 
            // BorrowerDataGrid
            // 
            this.BorrowerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BorrowerDataGrid.Location = new System.Drawing.Point(653, 196);
            this.BorrowerDataGrid.Name = "BorrowerDataGrid";
            this.BorrowerDataGrid.RowHeadersWidth = 51;
            this.BorrowerDataGrid.RowTemplate.Height = 24;
            this.BorrowerDataGrid.Size = new System.Drawing.Size(388, 205);
            this.BorrowerDataGrid.TabIndex = 39;
            // 
            // ReturnedDataGrid
            // 
            this.ReturnedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReturnedDataGrid.Location = new System.Drawing.Point(1133, 196);
            this.ReturnedDataGrid.Name = "ReturnedDataGrid";
            this.ReturnedDataGrid.RowHeadersWidth = 51;
            this.ReturnedDataGrid.RowTemplate.Height = 24;
            this.ReturnedDataGrid.Size = new System.Drawing.Size(388, 205);
            this.ReturnedDataGrid.TabIndex = 40;
            // 
            // BookDataGrid
            // 
            this.BookDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookDataGrid.Location = new System.Drawing.Point(851, 511);
            this.BookDataGrid.Name = "BookDataGrid";
            this.BookDataGrid.RowHeadersWidth = 51;
            this.BookDataGrid.RowTemplate.Height = 24;
            this.BookDataGrid.Size = new System.Drawing.Size(486, 211);
            this.BookDataGrid.TabIndex = 41;
            // 
            // TitleComboBox
            // 
            this.TitleComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleComboBox.FormattingEnabled = true;
            this.TitleComboBox.Location = new System.Drawing.Point(156, 15);
            this.TitleComboBox.Name = "TitleComboBox";
            this.TitleComboBox.Size = new System.Drawing.Size(300, 36);
            this.TitleComboBox.TabIndex = 11;
            this.TitleComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleComboBox_SelectedIndexChanged);
            // 
            // Borrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1533, 734);
            this.Controls.Add(this.BookDataGrid);
            this.Controls.Add(this.ReturnedDataGrid);
            this.Controls.Add(this.BorrowerDataGrid);
            this.Controls.Add(this.borrowedSearch);
            this.Controls.Add(this.returnedSearch);
            this.Controls.Add(this.bookSearch);
            this.Controls.Add(this.studentidbox);
            this.Controls.Add(this.lastnameread);
            this.Controls.Add(this.firstnameread);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReturnBTN);
            this.Controls.Add(this.BorrowBTN);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.searchBorrowed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "Borrower";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrower";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowerDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnedDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReturnBTN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox quantitytxt;
        private System.Windows.Forms.TextBox authortxt;
        private System.Windows.Forms.TextBox bookidtxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label searchBorrowed;
        private System.Windows.Forms.Button BorrowBTN;
        private System.Windows.Forms.TextBox firstnameread;
        private System.Windows.Forms.TextBox lastnameread;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox studentidbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private NewBorrowDataSetTableAdapters.BorrowerTableAdapter borrowerTableAdapter1;
        private TheNewBorrowDataGridTableAdapters.BorrowerTableAdapter borrowerTableAdapter2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox returnedSearch;
        private System.Windows.Forms.TextBox bookSearch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox borrowedSearch;
        private System.Windows.Forms.DataGridView BorrowerDataGrid;
        private System.Windows.Forms.DataGridView ReturnedDataGrid;
        private System.Windows.Forms.DataGridView BookDataGrid;
        private System.Windows.Forms.ComboBox TitleComboBox;
    }
}