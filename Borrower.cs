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
    public partial class SearchBookTXT : Form
    {
        // Assuming you have a connection string defined somewhere
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";

        public SearchBookTXT()
        {
            InitializeComponent();

            BorrowerDataGrid.CellClick += BorrowerDataGrid_CellClick;
            ReturnedDataGrid.CellClick += ReturnedDataGrid_CellContentClick;
            DataBooks.CellClick += DataBooks_CellContentClick;


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
                    DataBooks.DataSource = table;
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
                        using (SqlCommand selectCommand = new SqlCommand("SELECT COUNT(*) FROM Borrower WHERE booksid = @booksid AND title = @title AND studentid = @studentid", con))
                        {
                            selectCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);
                            selectCommand.Parameters.AddWithValue("@studentid", studentId);
                            selectCommand.Parameters.AddWithValue("@title", TitleComboBox.Text);
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

        private void clearBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
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

                    con.Open();
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM Returned WHERE studentid = @studentid AND booksid = @booksid", con))
                    {
                        deleteCommand.Parameters.AddWithValue("@studentid", studentId);
                        deleteCommand.Parameters.AddWithValue("@booksid", bookidtxt.Text);

                        // Execute the delete command
                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Returned database has been successfully cleared");
                        }
                        else
                        {
                            MessageBox.Show("No matching records found for deletion.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Refresh data
                    BorrowLoad();
                    LoadBooks();
                    ReturnLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close(); // Close the connection in a finally block to ensure it's closed even if an exception occurs
                }
            }
        }


        private void ReturnedDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < ReturnedDataGrid.Rows.Count)
            {
                DataGridViewRow row = ReturnedDataGrid.Rows[e.RowIndex];

                string studentIdreturned = row.Cells["studentid"].Value.ToString();
                string firstnamereturned = row.Cells["firstname"].Value.ToString();
                string lastnamereturned = row.Cells["lastname"].Value.ToString();
                string booksIdreturned = row.Cells["booksid"].Value.ToString();
                string titlereturned = row.Cells["title"].Value.ToString();
                string authorreturned = row.Cells["author"].Value.ToString();
                string quantityreturned = row.Cells["quantity"].Value.ToString();

                // Set the values to the textboxes
                studentidbox.Text = studentIdreturned;
                firstnameread.Text = firstnamereturned;
                lastnameread.Text = lastnamereturned;
                bookidtxt.Text = booksIdreturned;
                TitleComboBox.Text = titlereturned;
                authortxt.Text = authorreturned;
                quantitytxt.Text = quantityreturned;
            }

        }

        private void borrowedSearch_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            string searchText = borrowedSearch.Text;
            string query = "SELECT studentid, firstname, lastname, booksid, title, author, quantity, borroweddate, returnby FROM Borrower WHERE studentid LIKE '%' + @searchText + '%' OR firstname LIKE '%' + @searchText + '%' OR lastname LIKE '%' + @searchText + '%' OR booksid LIKE '%' + @searchText + '%' OR title LIKE '%' + @searchText + '%' OR author LIKE '%' + @searchText + '%' OR quantity LIKE '%' + @searchText + '%' OR returnby LIKE '%' + @searchText + '%'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    BorrowerDataGrid.DataSource = dataTable;
                    con.Close();
                }
            }
        }

        private void returnedSearch_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            string searchText = returnedSearch.Text;
            string query = "SELECT studentid, firstname, lastname, booksid, title, author, quantity, borroweddate, returnby FROM Borrower WHERE studentid LIKE '%' + @searchText + '%' OR firstname LIKE '%' + @searchText + '%' OR lastname LIKE '%' + @searchText + '%' OR booksid LIKE '%' + @searchText + '%' OR title LIKE '%' + @searchText + '%' OR author LIKE '%' + @searchText + '%' OR quantity LIKE '%' + @searchText + '%' OR returndate LIKE '%' + @searchText + '%'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    ReturnedDataGrid.DataSource = dataTable;
                    con.Close();
                }
            }
        }

        private void DataBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataBooks.Rows.Count)
            {
                DataGridViewRow row = DataBooks.Rows[e.RowIndex];


                string booksIdindex = row.Cells["booksid"].Value.ToString();
                string titleindex = row.Cells["title"].Value.ToString();
                string authorindex = row.Cells["author"].Value.ToString();
                string quantityindex = row.Cells["quantity"].Value.ToString();

                // Set the values to the textboxes

                bookidtxt.Text = booksIdindex;
                TitleComboBox.Text = titleindex;
                authortxt.Text = authorindex;
                quantitytxt.Text = quantityindex;
            }

        }

        private void SearchABook_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            string searchText = SearchABook.Text;
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
                    DataBooks.DataSource = dataTable;
                    con.Close();
                }
            }
        }
    }
}

