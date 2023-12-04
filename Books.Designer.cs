namespace LoginRegister
{
    partial class Books
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
            this.components = new System.ComponentModel.Container();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.txtauthor = new System.Windows.Forms.TextBox();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.booksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDataSet1 = new LoginRegister.masterDataSet1();
            this.updatebtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.booksTableAdapter = new LoginRegister.masterDataSet1TableAdapters.BooksTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bookDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.booksDataSet = new LoginRegister.BooksDataSet();
            this.bookDataTableAdapter = new LoginRegister.BooksDataSetTableAdapters.BookDataTableAdapter();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bookDataDB = new LoginRegister.bookDataDB();
            this.bookDataBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bookDataTableAdapter1 = new LoginRegister.bookDataDBTableAdapters.BookDataTableAdapter();
            this.bookDataBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bookDataDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookDataBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.booksidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(55, 161);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 28);
            this.label11.TabIndex = 12;
            this.label11.Text = "Books";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(55, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 28);
            this.label9.TabIndex = 11;
            this.label9.Text = "Books";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtquantity);
            this.panel2.Controls.Add(this.txtauthor);
            this.panel2.Controls.Add(this.txttitle);
            this.panel2.Controls.Add(this.txtid);
            this.panel2.Location = new System.Drawing.Point(51, 190);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 209);
            this.panel2.TabIndex = 10;
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
            this.label7.Location = new System.Drawing.Point(4, 170);
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
            this.label5.Location = new System.Drawing.Point(4, 116);
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
            this.label6.Location = new System.Drawing.Point(4, 10);
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
            this.label8.Location = new System.Drawing.Point(4, 58);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 28);
            this.label8.TabIndex = 1;
            this.label8.Text = "Book ID";
            // 
            // txtquantity
            // 
            this.txtquantity.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtquantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtquantity.Location = new System.Drawing.Point(156, 170);
            this.txtquantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(300, 34);
            this.txtquantity.TabIndex = 0;
            // 
            // txtauthor
            // 
            this.txtauthor.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtauthor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtauthor.Location = new System.Drawing.Point(156, 112);
            this.txtauthor.Margin = new System.Windows.Forms.Padding(4);
            this.txtauthor.Name = "txtauthor";
            this.txtauthor.Size = new System.Drawing.Size(300, 34);
            this.txtauthor.TabIndex = 0;
            // 
            // txttitle
            // 
            this.txttitle.BackColor = System.Drawing.Color.PapayaWhip;
            this.txttitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitle.Location = new System.Drawing.Point(156, 7);
            this.txttitle.Margin = new System.Windows.Forms.Padding(4);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(300, 34);
            this.txttitle.TabIndex = 0;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(156, 58);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(300, 34);
            this.txtid.TabIndex = 0;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginRegister.Properties.Resources.logo_uc2;
            this.pictureBox1.Location = new System.Drawing.Point(308, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(524, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 62);
            this.label1.TabIndex = 15;
            this.label1.Text = "Books";
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.Moccasin;
            this.addbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.addbtn.Location = new System.Drawing.Point(51, 420);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(144, 48);
            this.addbtn.TabIndex = 17;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // booksBindingSource
            // 
            this.booksBindingSource.DataMember = "Books";
            this.booksBindingSource.DataSource = this.masterDataSet1;
            // 
            // masterDataSet1
            // 
            this.masterDataSet1.DataSetName = "masterDataSet1";
            this.masterDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.Moccasin;
            this.updatebtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatebtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.updatebtn.Location = new System.Drawing.Point(207, 420);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(144, 48);
            this.updatebtn.TabIndex = 17;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.BackColor = System.Drawing.Color.Moccasin;
            this.deletebtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletebtn.Location = new System.Drawing.Point(363, 420);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(144, 48);
            this.deletebtn.TabIndex = 17;
            this.deletebtn.Text = "Delete";
            this.deletebtn.UseVisualStyleBackColor = false;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // booksTableAdapter
            // 
            this.booksTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.booksidDataGridViewTextBoxColumn,
            this.authorDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bookDataBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(567, 190);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(461, 278);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // bookDataBindingSource
            // 
            this.bookDataBindingSource.DataMember = "BookData";
            this.bookDataBindingSource.DataSource = this.booksDataSet;
            // 
            // booksDataSet
            // 
            this.booksDataSet.DataSetName = "BooksDataSet";
            this.booksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookDataTableAdapter
            // 
            this.bookDataTableAdapter.ClearBeforeFill = true;
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.PapayaWhip;
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(639, 150);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(389, 34);
            this.SearchBox.TabIndex = 19;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(562, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "Search:";
            // 
            // bookDataDB
            // 
            this.bookDataDB.DataSetName = "bookDataDB";
            this.bookDataDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookDataBindingSource1
            // 
            this.bookDataBindingSource1.DataMember = "BookData";
            this.bookDataBindingSource1.DataSource = this.bookDataDB;
            // 
            // bookDataTableAdapter1
            // 
            this.bookDataTableAdapter1.ClearBeforeFill = true;
            // 
            // bookDataBindingSource2
            // 
            this.bookDataBindingSource2.DataMember = "BookData";
            this.bookDataBindingSource2.DataSource = this.bookDataDB;
            // 
            // bookDataDBBindingSource
            // 
            this.bookDataDBBindingSource.DataSource = this.bookDataDB;
            this.bookDataDBBindingSource.Position = 0;
            // 
            // bookDataBindingSource3
            // 
            this.bookDataBindingSource3.DataMember = "BookData";
            this.bookDataBindingSource3.DataSource = this.bookDataDB;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 125;
            // 
            // booksidDataGridViewTextBoxColumn
            // 
            this.booksidDataGridViewTextBoxColumn.DataPropertyName = "booksid";
            this.booksidDataGridViewTextBoxColumn.HeaderText = "booksid";
            this.booksidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.booksidDataGridViewTextBoxColumn.Name = "booksidDataGridViewTextBoxColumn";
            this.booksidDataGridViewTextBoxColumn.Width = 125;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "author";
            this.authorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.Width = 125;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 125;
            // 
            // Books
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Books";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Books";
            this.Load += new System.EventHandler(this.Books_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.TextBox txtauthor;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button deletebtn;
        private masterDataSet1 masterDataSet1;
        private System.Windows.Forms.BindingSource booksBindingSource;
        private masterDataSet1TableAdapters.BooksTableAdapter booksTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BooksDataSet booksDataSet;
        private System.Windows.Forms.BindingSource bookDataBindingSource;
        private BooksDataSetTableAdapters.BookDataTableAdapter bookDataTableAdapter;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label2;
        private bookDataDB bookDataDB;
        private System.Windows.Forms.BindingSource bookDataBindingSource1;
        private bookDataDBTableAdapters.BookDataTableAdapter bookDataTableAdapter1;
        private System.Windows.Forms.BindingSource bookDataBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn booksidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bookDataBindingSource3;
        private System.Windows.Forms.BindingSource bookDataDBBindingSource;
    }
}