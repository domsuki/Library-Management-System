namespace LoginRegister
{
    partial class Author
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
            this.authorID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.authorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.noOfBooks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AuthorGrid = new System.Windows.Forms.DataGridView();
            this.authorBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.authordbset = new LoginRegister.authordbset();
            this.authorTableAdapter = new LoginRegister.authordbsetTableAdapters.AuthorTableAdapter();
            this.AuthorSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AuthorGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authordbset)).BeginInit();
            this.SuspendLayout();
            // 
            // authorID
            // 
            this.authorID.BackColor = System.Drawing.Color.PapayaWhip;
            this.authorID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorID.Location = new System.Drawing.Point(211, 39);
            this.authorID.Margin = new System.Windows.Forms.Padding(4);
            this.authorID.Name = "authorID";
            this.authorID.Size = new System.Drawing.Size(317, 34);
            this.authorID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(45, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "Author ID";
            // 
            // authorName
            // 
            this.authorName.BackColor = System.Drawing.Color.PapayaWhip;
            this.authorName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorName.Location = new System.Drawing.Point(211, 84);
            this.authorName.Margin = new System.Windows.Forms.Padding(4);
            this.authorName.Name = "authorName";
            this.authorName.Size = new System.Drawing.Size(317, 34);
            this.authorName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(45, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Author Name";
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(211, 180);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(102, 41);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(319, 180);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(101, 41);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(426, 180);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(102, 41);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // noOfBooks
            // 
            this.noOfBooks.BackColor = System.Drawing.Color.PapayaWhip;
            this.noOfBooks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfBooks.Location = new System.Drawing.Point(211, 131);
            this.noOfBooks.Margin = new System.Windows.Forms.Padding(4);
            this.noOfBooks.Name = "noOfBooks";
            this.noOfBooks.Size = new System.Drawing.Size(317, 34);
            this.noOfBooks.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(45, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "No of Books";
            // 
            // AuthorGrid
            // 
            this.AuthorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuthorGrid.Location = new System.Drawing.Point(50, 283);
            this.AuthorGrid.Name = "AuthorGrid";
            this.AuthorGrid.RowHeadersWidth = 51;
            this.AuthorGrid.RowTemplate.Height = 24;
            this.AuthorGrid.Size = new System.Drawing.Size(478, 269);
            this.AuthorGrid.TabIndex = 9;
            this.AuthorGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // authorBindingSource1
            // 
            this.authorBindingSource1.DataMember = "Author";
            this.authorBindingSource1.DataSource = this.authordbset;
            // 
            // authordbset
            // 
            this.authordbset.DataSetName = "authordbset";
            this.authordbset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // authorTableAdapter
            // 
            this.authorTableAdapter.ClearBeforeFill = true;
            // 
            // AuthorSearch
            // 
            this.AuthorSearch.Location = new System.Drawing.Point(50, 247);
            this.AuthorSearch.Name = "AuthorSearch";
            this.AuthorSearch.Size = new System.Drawing.Size(478, 22);
            this.AuthorSearch.TabIndex = 10;
            this.AuthorSearch.TextChanged += new System.EventHandler(this.AuthorSearch_TextChanged);
            // 
            // Author
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(574, 617);
            this.Controls.Add(this.AuthorSearch);
            this.Controls.Add(this.AuthorGrid);
            this.Controls.Add(this.noOfBooks);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authorName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.authorID);
            this.MaximizeBox = false;
            this.Name = "Author";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Author";
            this.Load += new System.EventHandler(this.Author_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuthorGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authordbset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox authorID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox authorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.TextBox noOfBooks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView AuthorGrid;
        private authordbset authordbset;
        private authordbsetTableAdapters.AuthorTableAdapter authorTableAdapter;
        private System.Windows.Forms.BindingSource authorBindingSource1;
        private System.Windows.Forms.TextBox AuthorSearch;
    }
}