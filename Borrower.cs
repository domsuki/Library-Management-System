using System;
using System.Collections.Generic;
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
        // Assuming you have a connection string defined somewhere
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";

        public Borrower()
        {
            InitializeComponent();
            BookDataGrid.CellClick += BookDataGrid_CellClick;
            BorrowerDataGrid.CellClick += BorrowerDataGrid_CellClick;
            LoadBooks();
            BorrowLoad();
            ReturnLoad();

            // Call the method to populate student ID combo box
            StudentIDComboBox();
            BookTitleComboBox();


        }

        private void BorrowerDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < BorrowerDataGrid.Rows.Count)
            {
                DataGridViewRow row = BorrowerDataGrid.Rows[e.RowIndex];

                string studentId = row.Cells["studentid"].Value.ToString();
                string firstname = row.Cells["firstname"].Value.ToString();
                string lastname = row.Cells["lastname"].Value.ToString();
                string booksId = row.Cells["booksid"].Value.ToString();
                string title = row.Cells["title"].Value.ToString();
                string author = row.Cells["author"].Value.ToString();
                string quantity = row.Cells["quantity"].Value.ToString();

                // Set the values to the textboxes
                studentidbox.Text = studentId;
                firstnameread.Text = firstname;
                lastnameread.Text = lastname;
                bookidtxt.Text = booksId;
                TitleComboBox.Text = title;
                authortxt.Text = author;
                quantitytxt.Text = quantity;
            }
        }

        private void BookDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < BorrowerDataGrid.Rows.Count)
            {
                DataGridViewRow row = BorrowerDataGrid.Rows[e.RowIndex];

                // Check if the cell values are not null
                object titleObj = row.Cells["title"].Value;
                object booksIdObj = row.Cells["booksid"].Value;
                object authorObj = row.Cells["author"].Value;
                object quantityObj = row.Cells["quantity"].Value;

                if (titleObj != null && booksIdObj != null && authorObj != null && quantityObj != null)
                {
                    // Convert to string if not null
                    string title = titleObj.ToString();
                    string booksId = booksIdObj.ToString();
                    string author = authorObj.ToString();
                    string quantity = quantityObj.ToString();

                    // Set the values to the textboxes
                    TitleComboBox.Text = title;
                    bookidtxt.Text = booksId;
                    authortxt.Text = author;
                    quantitytxt.Text = quantity;
                }
                else
                {
                    // Handle the case where one or more values are null
                    // You might want to display an error message or handle it in a way that makes sense for your application.
                }
            }
        }

        private void UpdateBorrowerData(SqlConnection con, int studentId, int count)
        {
            // Your existing code for updating Borrower data...
            // ...
        }

        private void InsertNewBorrowerData(SqlConnection con, int studentId)
        {
            // Your existing code for inserting new Borrower data...
            // ...
        }

        private void StudentIDComboBox()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT studentid, firstname, lastname FROM dbo.studentlog";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        studentidbox.Items.Clear();
                        studentDataDictionary.Clear();

                        while (reader.Read())
                        {
                            int studentId = Convert.ToInt32(reader["studentid"]);
                            string firstName = reader["firstname"].ToString();
                            string lastName = reader["lastname"].ToString();

                            // Add the student ID to the combo box
                            studentidbox.Items.Add(studentId);

                            // Store additional data in the dictionary
                            studentDataDictionary.Add(studentId, new StudentData { FirstName = firstName, LastName = lastName });
                        }
                    }
                }
            }
        }
        private Dictionary<int, StudentData> studentDataDictionary = new Dictionary<int, StudentData>();


        private void studentidbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentidbox.SelectedItem != null)
            {
                int selectedStudentId = Convert.ToInt32(studentidbox.SelectedItem);

                // Retrieve additional data from the dictionary
                if (studentDataDictionary.TryGetValue(selectedStudentId, out var studentData))
                {
                    firstnameread.Text = studentData.FirstName;
                    lastnameread.Text = studentData.LastName;
                }
            }
        }

        private class StudentData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class BookData
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public int Quantity { get; set; }

            public BookData(int bookId, string title, string author, int quantity)
            {
                BookId = bookId;
                Title = title;
                Author = author;
                Quantity = quantity;
            }
        }

        // ...

        private Dictionary<int, BookData> bookDataDictionary = new Dictionary<int, BookData>();

        // ...

        private void BookTitleComboBox()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT booksid, title, author, quantity FROM dbo.BookData";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        TitleComboBox.Items.Clear();
                        bookDataDictionary.Clear();

                        while (reader.Read())
                        {
                            int bookId = Convert.ToInt32(reader["booksid"]);
                            string title = reader["title"].ToString();
                            string author = reader["author"].ToString();
                            int quantity = Convert.ToInt32(reader["quantity"]);

                            // Add the book title to the combo box
                            TitleComboBox.Items.Add(title);

                            // Store additional data in the dictionary
                            bookDataDictionary.Add(bookId, new BookData(bookId, title, author, quantity));
                        }
                    }
                }
            }
        }

        private void TitleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assuming TitleComboBox is the ComboBox where you select book titles
            string selectedTitle = TitleComboBox.SelectedItem.ToString();

            // Retrieve additional data from the dictionary
            foreach (var bookData in bookDataDictionary.Values)
            {
                if (bookData.Title == selectedTitle)
                {
                    // Now you can use bookData.BookId, bookData.Author, bookData.Quantity as needed
                    int bookId = bookData.BookId;
                    string author = bookData.Author;
                    int quantity = bookData.Quantity;

                    // Use these values as needed in your application
                    // For example, set them in the corresponding textboxes:
                    bookidtxt.Text = bookId.ToString();
                    authortxt.Text = author;
                    // ... other assignments as needed

                    break; // Exit the loop once you find the matching book
                }
            }
        }



        // Load Book Database
        private void LoadBooks()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM dbo.BookData";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BookDataGrid.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Borrower Data grid
        private void BorrowLoad()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM dbo.Borrower";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BorrowerDataGrid.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ReturnLoad()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM dbo.Returned";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ReturnedDataGrid.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //When executing the borrow button
        private void BorrowBTN_Click(object sender, EventArgs e)
        {
            if (studentidbox.SelectedItem == null)
            {
                MessageBox.Show("Please select a student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int studentId;
                if (studentidbox.SelectedItem is int)
                {
                    studentId = (int)studentidbox.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Invalid selection for student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
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

                        int quantity = 0;

                        // Check if the book exists in the Borrower table
                        using (SqlCommand selectCommand = new SqlCommand("SELECT COUNT(*) FROM Borrower WHERE booksid = @booksid AND studentid = @studentid", con))
                        {
                            selectCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                            selectCommand.Parameters.AddWithValue("@studentid", studentId);
                            int count = Convert.ToInt32(selectCommand.ExecuteScalar());
                            quantity = count; // assign count value to quantity variable
                        }

                        if (quantity > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("There's an existing data, will update the quantity instead", "Update Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.OK)
                            {
                                // Update the quantity in the Borrower table
                                using (SqlCommand updateCommand = new SqlCommand("UPDATE Borrower SET quantity = quantity + @quantity, borroweddate = @borroweddate, returnby = @returnby WHERE booksid = @booksid AND studentid = @studentid", con))
                                {
                                    updateCommand.Parameters.AddWithValue("@quantity", quantitytxt.Text);
                                    updateCommand.Parameters.AddWithValue("@borroweddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    updateCommand.Parameters.AddWithValue("@returnby", DateTime.UtcNow.AddDays(7));
                                    updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                    updateCommand.Parameters.AddWithValue("@studentid", studentId);
                                    updateCommand.ExecuteNonQuery();
                                    BorrowLoad();
                                }
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
                                insertCommand.Parameters.AddWithValue("@title", TitleComboBox.Text);
                                insertCommand.Parameters.AddWithValue("@author", authortxt.Text);
                                insertCommand.Parameters.AddWithValue("@quantity", quantitytxt.Text);
                                insertCommand.Parameters.AddWithValue("@borroweddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                insertCommand.Parameters.AddWithValue("@returnby", DateTime.UtcNow.AddDays(7)); // Use UTC time

                                insertCommand.ExecuteNonQuery();
                            }

                            // Update dbo.BookData for the quantity
                            using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.BookData SET quantity = CASE WHEN quantity > 0 THEN quantity - @quantity ELSE quantity END WHERE booksid = @booksid", con))
                            {
                                updateCommand.Parameters.AddWithValue("@quantity", quantitytxt.Text);
                                updateCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                                updateCommand.ExecuteNonQuery();
                                
                            }

                            MessageBox.Show("Successfully added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BorrowLoad();
                            LoadBooks();
                            ReturnLoad();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ReturnBTN_Click(object sender, EventArgs e)
        {
            if (studentidbox.SelectedItem == null)
            {
                MessageBox.Show("Please select a student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int studentId;
                if (studentidbox.SelectedItem is int) // Check if it's an int
                {
                    studentId = (int)studentidbox.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Invalid selection for student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();

                        // Check if the book is already returned
                        using (SqlCommand checkReturnedCommand = new SqlCommand("SELECT COUNT(*) FROM Returned WHERE studentid = @studentid AND booksid = @booksid", con))
                        {
                            checkReturnedCommand.Parameters.AddWithValue("@studentid", studentId);
                            checkReturnedCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);

                            int rowCount = (int)checkReturnedCommand.ExecuteScalar();

                            if (rowCount > 0)
                            {
                                MessageBox.Show("This book has already been returned by the selected student.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return; // Stop further processing
                            }
                        }

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
                            LoadBooks();
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
                            insertCommand.Parameters.AddWithValue("@title", TitleComboBox.Text);
                            insertCommand.Parameters.AddWithValue("@author", authortxt.Text);
                            insertCommand.Parameters.AddWithValue("@quantity", int.Parse(quantitytxt.Text));
                            insertCommand.Parameters.AddWithValue("@borroweddate", borrowedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                            insertCommand.Parameters.AddWithValue("@returneddate", DateTime.Now);

                            insertCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Return successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrowLoad();
                        LoadBooks();
                        ReturnLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

