using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class Borrower : Form
    {

        public Borrower()
        {

            InitializeComponent();
        }

        private void LoadBooks()
        {
            string connectionString = "Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM dbo.BookData";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        //when clicking borrow
        private void addbtn_Click(object sender, EventArgs e)
        {
            DataRowView selectedStudent = (DataRowView)studentidbox.SelectedItem;
            int studentId = Convert.ToInt32(selectedStudent["studentid"]);

            string connectionString = "Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get student's first name and last name from studentlog database
                    using (SqlCommand selectCommand = new SqlCommand("SELECT firstname, lastname FROM dbo.studentlog WHERE studentid = @StudentID", con))
                    {
                        selectCommand.Parameters.AddWithValue("@StudentID", studentId);
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                firstnameread.Text = reader.GetString(0);
                                lastnameread.Text = reader.GetString(1);
                            }
                            else
                            {
                                MessageBox.Show("Student doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }


                    // Check if the book exists in the Borrower table
                    using (SqlCommand selectCommand = new SqlCommand("SELECT COUNT(*) FROM Borrower WHERE booksid = @booksid AND studentid = @studentid", con))
                    {
                        selectCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                        selectCommand.Parameters.AddWithValue("@studentid", studentId);
                        int count = Convert.ToInt32(selectCommand.ExecuteScalar());
                        int quantity = count; // assign count value to quantity variable
                        if (count > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("There's an exisiting data, will update the quantity instead", "Update Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.OK)
                            {
                                // Update the quantity in the Borrower table
                                using (SqlCommand updateCommand = new SqlCommand("UPDATE Borrower SET quantity = quantity + @quantity WHERE booksid = @booksid AND studentid = @studentid", con))
                                {
                                    updateCommand.Parameters.AddWithValue("@quantity", quantity);
                                    updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                    updateCommand.Parameters.AddWithValue("@studentid", studentId);
                                    updateCommand.ExecuteNonQuery();

                                    // Show confirmation message
                                    MessageBox.Show("Quantity has been updated successfully.", "Update Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    loadDatagrid();
                                }

                                // Update the borrowed date in the Borrower table
                                using (SqlCommand updateCommand = new SqlCommand("UPDATE Borrower SET borroweddate = @borroweddate WHERE booksid = @booksid AND studentid = @studentid", con))
                                {
                                    updateCommand.Parameters.AddWithValue("@borroweddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                    updateCommand.Parameters.AddWithValue("@studentid", studentId);
                                    updateCommand.ExecuteNonQuery();
                                    loadDatagrid();
                                }

                                //update the return date in the Borrower table
                                using (SqlCommand updateCommand = new SqlCommand("UPDATE Borrower SET returnby = @returnby WHERE booksid = @booksid AND studentid = @studentid", con))
                                {
                                    updateCommand.Parameters.AddWithValue("@returnby", DateTime.UtcNow.AddDays(7));
                                    updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                    updateCommand.Parameters.AddWithValue("@studentid", studentId);
                                    updateCommand.ExecuteNonQuery();
                                    loadDatagrid();
                                }

                                //update dbo.BookData for the quantity
                                using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.BookData SET quantity = CASE WHEN quantity > 0 THEN quantity - 1 ELSE quantity END WHERE booksid = @booksid", con))
                                {
                                    updateCommand.Parameters.AddWithValue("@borrowedQuantity", quantity);
                                    updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                    updateCommand.ExecuteNonQuery();
                                    loadDatagrid();
                                }
                            }
                            else
                            {

                                
                            }
                        }
                        else
                        {
                            // Insert a new record in the Borrower table
                            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Borrower (studentid, firstname, lastname, booksid, title, author, quantity, borroweddate, returnby) VALUES (@studentid, @firstname, @lastname, @booksid, @title, @author, @quantity, @borroweddate, @returnby)", con))
                            {
                                insertCommand.Parameters.AddWithValue("@studentid", studentId);
                                insertCommand.Parameters.AddWithValue("@firstname", firstnameread.Text);
                                insertCommand.Parameters.AddWithValue("@lastname", lastnameread.Text);
                                insertCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                insertCommand.Parameters.AddWithValue("@title", titletxt.Text);
                                insertCommand.Parameters.AddWithValue("@author", authortxt.Text);
                                insertCommand.Parameters.AddWithValue("@quantity", quantitytxt.Text);
                                insertCommand.Parameters.AddWithValue("@borroweddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                insertCommand.Parameters.AddWithValue("@returnby", DateTime.UtcNow.AddDays(7)); // Use UTC time

                                insertCommand.ExecuteNonQuery();
                            }
                            using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.BookData SET quantity = CASE WHEN quantity > 0 THEN quantity - 1 ELSE quantity END WHERE booksid = @booksid", con))
                            {
                                updateCommand.Parameters.AddWithValue("@borrowedQuantity", quantity);
                                updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                updateCommand.ExecuteNonQuery();
                                loadDatagrid();
                            }
                        }
                    }

                    MessageBox.Show("Successfully added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload data
                    try
                    {
                        LoadBooks();
                        loadDatagrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        //this is for return process, instead of delete statement
        //ignore the deletebtn id
        private void deletebtn_Click(object sender, EventArgs e)
        {
            DataRowView selectedStudent = (DataRowView)studentidbox.SelectedItem;
            int studentId = Convert.ToInt32(selectedStudent["studentid"]);

            string connectionString = "Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Remove the borrower record
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM Borrower WHERE studentid = @studentid AND booksid = @booksid", con))
                    {
                        deleteCommand.Parameters.AddWithValue("@studentid", studentId);
                        deleteCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Restore the book quantity
                    int borrowedQuantity = int.Parse(quantitytxt.Text);
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.BookData SET quantity = quantity + @borrowedQuantity WHERE booksid = @booksid", con))
                    {
                        updateCommand.Parameters.AddWithValue("@borrowedQuantity", borrowedQuantity);
                        updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Retrieve the borrowed date
                    DateTime borrowedDate = DateTime.MinValue; // set default value
                    using (SqlCommand selectCommand = new SqlCommand("SELECT borroweddate FROM Borrower WHERE studentid = @studentid AND booksid = @booksid", con))
                    {
                        selectCommand.Parameters.AddWithValue("@studentid", studentId);
                        selectCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read()) // check if there is data to read
                            {
                                borrowedDate = reader.GetDateTime(0); // get the borrowed date
                            }
                        }
                    }

                    //add data to dbo.Returned database
                    using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Returned (studentid, firstname, lastname, booksid, title, author, quantity, returneddate) VALUES (@studentid, @firstname, @lastname, @booksid, @title, @author, @quantity, @returneddate)", con))
                    {
                        insertCommand.Parameters.AddWithValue("@studentid", studentId);
                        insertCommand.Parameters.AddWithValue("@firstname", firstnameread.Text);
                        insertCommand.Parameters.AddWithValue("@lastname", lastnameread.Text);
                        insertCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                        insertCommand.Parameters.AddWithValue("@title", titletxt.Text);
                        insertCommand.Parameters.AddWithValue("@author", authortxt.Text);
                        insertCommand.Parameters.AddWithValue("@quantity", int.Parse(quantitytxt.Text));
                        insertCommand.Parameters.AddWithValue("@borroweddate", borrowedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        insertCommand.Parameters.AddWithValue("@returneddate", DateTime.Now);

                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Return successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    loadDatagrid();
                    // Reload data
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ConfirmDeletion()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult == DialogResult.Yes;
        }

        //an refresh instance is initiated after succesful queries
        private void loadDatagrid()
        {
            this.borrowerTableAdapter.Fill(this.masterDataSet2.Borrower);
            // TODO: This line of code loads data into the 'theNewBorrowDataGrid.Borrower' table. You can move, or remove it, as needed.
            this.borrowerTableAdapter2.Fill(this.theNewBorrowDataGrid.Borrower);
            // TODO: This line of code loads data into the 'newReturnedDataSet.Returned' table. You can move, or remove it, as needed.
            this.returnedTableAdapter1.Fill(this.newReturnedDataSet.Returned);
            //TODO: This line of code loads data into the 'newBorrowDataSet.Borrower' table. You can move, or remove it, as needed.
            this.borrowerTableAdapter1.Fill(this.newBorrowDataSet.Borrower);
            // TODO: This line of code loads data into the 'booksDataSet.BookData' table. You can move, or remove it, as needed.
            this.bookDataTableAdapter.Fill(this.booksDataSet.BookData);
            // TODO: This line of code loads data into the 'returneddataset.Returned' table. You can move, or remove it, as needed.
            this.returnedTableAdapter.Fill(this.returneddataset.Returned);


            //read studentlog
            this.studentlogTableAdapter.Fill(this.masterDataSet5.studentlog);

            // TODO: This line of code loads data into the 'masterDataSet2.Borrower' table. You can move, or remove it, as needed.
            this.borrowerTableAdapter.Fill(this.masterDataSet2.Borrower);

        }


        private void Borrower_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'theNewBorrowDataGrid.Borrower' table. You can move, or remove it, as needed.
            this.borrowerTableAdapter2.Fill(this.theNewBorrowDataGrid.Borrower);
            // TODO: This line of code loads data into the 'newReturnedDataSet.Returned' table. You can move, or remove it, as needed.
            this.returnedTableAdapter1.Fill(this.newReturnedDataSet.Returned);
            //TODO: This line of code loads data into the 'newBorrowDataSet.Borrower' table. You can move, or remove it, as needed.
            this.borrowerTableAdapter1.Fill(this.newBorrowDataSet.Borrower);
            // TODO: This line of code loads data into the 'booksDataSet.BookData' table. You can move, or remove it, as needed.
            this.bookDataTableAdapter.Fill(this.booksDataSet.BookData);
            // TODO: This line of code loads data into the 'returneddataset.Returned' table. You can move, or remove it, as needed.
            this.returnedTableAdapter.Fill(this.returneddataset.Returned);


            //read studentlog
            this.studentlogTableAdapter.Fill(this.masterDataSet5.studentlog);

            // TODO: This line of code loads data into the 'masterDataSet2.Borrower' table. You can move, or remove it, as needed.
            this.borrowerTableAdapter.Fill(this.masterDataSet2.Borrower);


        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void studentidbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void firstnameread_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //print preview for borrower
        private void printbtn_Click(object sender, EventArgs e)
        {
            // Create a new PrintDocument object
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.DefaultPageSettings.PaperSize = new PaperSize("Legal", 850, 1400);

            // Set the font and margins for the document
            Font font = new Font("Arial", 12);
            int leftMargin = 50;
            int topMargin = 50;

            // Set up the table headers
            int columnWidth = 100;
            int column1Left = leftMargin;
            int column2Left = column1Left + columnWidth;
            int column3Left = column2Left + columnWidth;
            int column4Left = column3Left + columnWidth;
            int availableWidth = doc.DefaultPageSettings.PaperSize.Width - column4Left - leftMargin;
            int maxColumnWidth = availableWidth / 4;
            int column5Width = maxColumnWidth + 100;
            int column6Width = maxColumnWidth + 100; // slightly wider column 6
            int column7Width = maxColumnWidth + 150; // wider column 7
            int column8Width = maxColumnWidth + 150; // wider column 8
            int column5Left = column4Left + columnWidth;
            int column6Left = column5Left + column5Width;
            int column7Left = column6Left + column6Width;
            int column8Left = column7Left + column7Width;
            int rowHeight = font.Height + 5;

            // Set up the event handlers for printing and previewing
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings = doc.DefaultPageSettings;
            printDoc.PrintPage += (s, ev) => PrintPage(s, ev, font, leftMargin, topMargin, column1Left, column2Left, column3Left, column4Left, column5Left, column6Left, column7Left, column8Left, rowHeight);
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;

            // Show the print preview dialog
            if (preview.ShowDialog() == DialogResult.OK)
            {
                // Show the print dialog if the user clicked the print button in the preview dialog
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
        }




        private void PrintPage(object sender, PrintPageEventArgs ev, Font font, int leftMargin, int topMargin, int column1Left, int column2Left, int column3Left, int column4Left, int column5Left, int column6Left, int column7Left, int column8Left, int rowHeight)
        {
            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;"))
            {
                using (SqlCommand command = new SqlCommand("SELECT studentid, firstname, lastname, booksid, title, author, quantity, borroweddate, returnby FROM dbo.Borrower", connection))
                {
                    // Open the connection and execute the command
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    string label = "Borrowed";
                    Font labelFont = new Font("Arial", 18, FontStyle.Bold);
                    SizeF labelSize = ev.Graphics.MeasureString(label, labelFont);
                    float labelX = leftMargin + (ev.PageBounds.Width - leftMargin - ev.PageSettings.Margins.Right - labelSize.Width) / 2;
                    ev.Graphics.DrawString(label, labelFont, Brushes.Black, labelX, topMargin);

                    topMargin += 40;

                    // Set up the table headings

                    string[] tableHeadings = { "Student ID", "First Name", "Last Name", "Book ID", "Title", "Quantity", "Borrowed Date", "Return By" };
                    Font headingFont = new Font("Arial", 12, FontStyle.Bold);
                    topMargin += 20;
                    for (int i = 0; i < tableHeadings.Length; i++)
                    {
                        int headingLeft = 0;
                        switch (i)
                        {
                            case 0:
                                headingLeft = column1Left;
                                break;
                            case 1:
                                headingLeft = column2Left;
                                break;
                            case 2:
                                headingLeft = column3Left;
                                break;
                            case 3:
                                headingLeft = column4Left;
                                break;
                            case 4:
                                headingLeft = column5Left;
                                break;
                            case 5:
                                headingLeft = column6Left;
                                break;
                            case 6:
                                headingLeft = column7Left;
                                break;
                            case 7:
                                headingLeft = column8Left;
                                break;
                        }

                        ev.Graphics.DrawString(tableHeadings[i], font, Brushes.Black, headingLeft, topMargin);
                    }

                    topMargin += 20;

                    // Loop through the data and print it in the table
                    while (reader.Read())
                    {
                        ev.Graphics.DrawString(reader["studentid"].ToString(), font, Brushes.Black, column1Left, topMargin);
                        ev.Graphics.DrawString(reader["firstname"].ToString(), font, Brushes.Black, column2Left, topMargin);
                        ev.Graphics.DrawString(reader["lastname"].ToString(), font, Brushes.Black, column3Left, topMargin);
                        ev.Graphics.DrawString(reader["booksid"].ToString(), font, Brushes.Black, column4Left, topMargin);
                        ev.Graphics.DrawString(reader["title"].ToString(), font, Brushes.Black, column5Left, topMargin);
                        ev.Graphics.DrawString(reader["quantity"].ToString(), font, Brushes.Black, column6Left, topMargin);
                        ev.Graphics.DrawString(reader["borroweddate"].ToString(), font, Brushes.Black, column7Left, topMargin);
                        ev.Graphics.DrawString(reader["returnby"].ToString(), font, Brushes.Black, column8Left, topMargin);

                        topMargin += rowHeight;
                    }

                    // Close the connection
                    reader.Close();
                }
            }
        }

        //print preview for bookdata
        private void printReturnedbtn_Click(object sender, EventArgs e)
        {
            // Create a new PrintDocument object
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.DefaultPageSettings.PaperSize = new PaperSize("Legal", 850, 1400);

            // Set the font and margins for the document
            Font font = new Font("Arial", 12);
            int leftMargin = 50;
            int topMargin = 50;

            // Set up the event handlers for printing and previewing
            doc.PrintPage += (s, ev) => PrintPage(s, ev, font, leftMargin, topMargin);

            // Show the print preview dialog
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = doc;
            preview.ShowDialog(); ;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev, Font font, int leftMargin, int topMargin)
        {
            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;"))
            {
                using (SqlCommand command = new SqlCommand("SELECT studentid AS 'Student ID', firstname AS 'First Name', lastname AS 'Last Name', booksid AS 'Book ID', title AS 'Title', quantity AS 'Quantity', returneddate AS 'Date Returned' FROM dbo.Returned", connection))
                {
                    // Open the connection and execute the command
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    string label = "Returned";
                    Font labelFont = new Font("Arial", 18, FontStyle.Bold);
                    SizeF labelSize = ev.Graphics.MeasureString(label, labelFont);
                    float labelX = leftMargin + (ev.PageBounds.Width - leftMargin - ev.PageSettings.Margins.Right - labelSize.Width) / 2;
                    ev.Graphics.DrawString(label, labelFont, Brushes.Black, labelX, topMargin);

                    topMargin += 40;

                    // Set up the table headers
                    string[] tableHeadings = { "Student ID", "First Name", "Last Name", "Book ID", "Title", "Quantity", "Date Returned" };
                    Font headingFont = new Font("Arial", 12, FontStyle.Bold);
                    int[] columnWidths = {
                    ev.PageBounds.Width / 8,  // Student ID
                    ev.PageBounds.Width / 8,   // First Name
                    ev.PageBounds.Width / 8,   // Last Name
                    ev.PageBounds.Width / 8,  // Book ID
                    ev.PageBounds.Width / 8,   // Title
                    ev.PageBounds.Width / 8,  // Quantity
                    ev.PageBounds.Width / 8    // Date Returned
                    };

                    int rowHeight = font.Height + 5;

                    // Draw table headers
                    int x = ev.MarginBounds.Left;
                    int y = ev.MarginBounds.Top + 20;
                    for (int i = 0; i < tableHeadings.Length; i++)
                    {
                        ev.Graphics.DrawString(tableHeadings[i], headingFont, Brushes.Black, x, y);
                        x += columnWidths[i];
                    }

                    // Draw table rows
                    while (reader.Read())
                    {
                        x = ev.MarginBounds.Left;
                        y += rowHeight;
                        for (int i = 0; i < tableHeadings.Length; i++)
                        {
                            ev.Graphics.DrawString(reader[tableHeadings[i].ToLower()].ToString(), font, Brushes.Black, x, y);
                            x += columnWidths[i];
                        }
                    }

                    // Close the connection
                    reader.Close();
                }
            }
        }

        //print book reports
        private void printReportbtn_Click(object sender, EventArgs e)
        {
            // Create a PrintDocument object
            PrintDocument pd = new PrintDocument();

            // Set the PrintPage event handler
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage1);

            // Show the print preview dialog
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void pd_PrintPage1(object sender, PrintPageEventArgs e)
        {
            // Define the font to be used for printing
            Font font = new Font("Arial", 10);

            // Define the horizontal and vertical positions of the table header
            int x = 50;
            int y = 50;

            // Print the table header
            e.Graphics.DrawString("Title", font, Brushes.Black, x, y);
            e.Graphics.DrawString("Author", font, Brushes.Black, x + 200, y);
            e.Graphics.DrawString("Book ID", font, Brushes.Black, x + 400, y);
            e.Graphics.DrawString("Quantity", font, Brushes.Black, x + 600, y);

            // Define the vertical position of the first row of data
            y += 20;

            // Connect to the database and retrieve the data
            string connectionString = "LENOVO-PC;Initial Catalog=master;Integrated Security=True;";
            string query = "SELECT title, author, booksid, quantity FROM dbo.BookData";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Loop through the data and print each row
                while (reader.Read())
                {
                    e.Graphics.DrawString(reader["title"].ToString(), font, Brushes.Black, x, y);
                    e.Graphics.DrawString(reader["author"].ToString(), font, Brushes.Black, x + 200, y);
                    e.Graphics.DrawString(reader["booksid"].ToString(), font, Brushes.Black, x + 400, y);
                    e.Graphics.DrawString(reader["quantity"].ToString(), font, Brushes.Black, x + 600, y);

                    // Move to the next row
                    y += 20;
                }

                reader.Close();
                connection.Close();
            }
        }

        private void borrowedSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = borrowedSearch.Text;

            // Define the SQL query to retrieve the matching rows
            string query = "SELECT studentid, firstname, lastname, booksid, title, author, quantity, borroweddate, returnby " +
                           "FROM dbo.Borrower " +
                           "WHERE studentid LIKE '%' + @SearchQuery + '%' OR " +
                           "firstname LIKE '%' + @SearchQuery + '%' OR " +
                           "lastname LIKE '%' + @SearchQuery + '%' OR " +
                           "booksid LIKE '%' + @SearchQuery + '%' OR " +
                           "title LIKE '%' + @SearchQuery + '%' OR " +
                           "author LIKE '%' + @SearchQuery + '%' OR " +
                           "borroweddate LIKE '%' + @SearchQuery + '%' " + // added space after "borroweddate"
                           "OR returnby LIKE '%' + @SearchQuery + '%';";

            using (SqlConnection conn = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchQuery", searchQuery);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                // Reload the DataGridView with the filtered results
                dataGridView2.DataSource = dataTable;
            }
        }


        private void returnedSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = returnedSearch.Text;

            // Define the SQL query to retrieve the matching rows
            string query = "SELECT studentid, firstname, lastname, booksid, title, author, quantity, returneddate " +
                           "FROM dbo.Returned " +
                           "WHERE studentid LIKE '%' + @SearchQuery + '%' OR " +
                           "firstname LIKE '%' + @SearchQuery + '%' OR " +
                           "lastname LIKE '%' + @SearchQuery + '%' OR " +
                           "booksid LIKE '%' + @SearchQuery + '%' OR " +
                           "title LIKE '%' + @SearchQuery + '%' OR " +
                           "author LIKE '%' + @SearchQuery + '%' OR " +
                           "quantity LIKE '%' + @SearchQuery + '%' OR " +
                           "returneddate LIKE '%' + @SearchQuery + '%';";

            using (SqlConnection conn = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchQuery", searchQuery);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                // Reload the DataGridView with the filtered results
                dataGridView3.DataSource = dataTable;
            }
        }


        private void bookSearch_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;";
            string searchText = bookSearch.Text;
            string query = "SELECT title, booksid, author, quantity FROM BookData WHERE title LIKE '%' + @searchText + '%' OR author LIKE '%' + @searchText + '%' OR booksid LIKE '%' + @searchText + '%'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    con.Close();
                }
            }

        }
    }
 }

