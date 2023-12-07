using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
            AuthorGrid.CellClick += dataGridView1_CellClick;
        }

        private void Author_Load(object sender, EventArgs e)
        {

            
            RefreshTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < AuthorGrid.Rows.Count)
            {
                DataGridViewRow row = AuthorGrid.Rows[e.RowIndex];

                string authorid = row.Cells["AuthorID"].Value.ToString();
                string authorname = row.Cells["AuthorName"].Value.ToString();
                string noofbooks = row.Cells["NoOfBooks"].Value.ToString();

                // Set the values to the textboxes
                authorID.Text = authorid;
                authorName.Text = authorname;
                noOfBooks.Text = noofbooks;
            }
        }

        private void RefreshTable()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    DataSet dataSet = new DataSet(); ;
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string q = "SELECT * FROM Author";
                    using (SqlCommand CMD = new SqlCommand(q, con))
                    {
                        adapter.SelectCommand = CMD;

                        adapter.Fill(dataSet, "Author");
                        AuthorGrid.DataSource = dataSet.Tables["Author"];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error " + ex.Message);
                }
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // Assuming you have a DataGridView with the name dataGridView1
            if (AuthorGrid.SelectedRows.Count > 0)
            {
                // Get the selected AuthorID from the DataGridView
                string selectedAuthorID = AuthorGrid.SelectedRows[0].Cells["AuthorID"].Value.ToString();

                // Ask for confirmation before deleting
                DialogResult result = MessageBox.Show("Are you sure you want to delete this author?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Connection string - update it with your database connection information
                    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            // SQL query to delete data from the Author table based on AuthorID
                            string deleteQuery = "DELETE FROM Author WHERE AuthorID = @AuthorID";

                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                // Add parameter to the query
                                command.Parameters.AddWithValue("@AuthorID", selectedAuthorID);

                                // Execute the query
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Author deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RefreshTable();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Get values from text boxes
            string authorid= authorID.Text;
            string authorname = authorName.Text;
            string noofbooks = noOfBooks.Text;

            // Check if any of the text boxes is empty
            if (string.IsNullOrEmpty(authorid) || string.IsNullOrEmpty(authorname) || string.IsNullOrEmpty(noofbooks))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Connection string - update it with your database connection information
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to insert data into the Author table
                    string query = "INSERT INTO Author (AuthorID, AuthorName, NoOfBooks) VALUES (@AuthorID, @AuthorName, @NoOfBooks)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@AuthorID", authorid);
                        command.Parameters.AddWithValue("@AuthorName", authorname);
                        command.Parameters.AddWithValue("@NoOfBooks", noofbooks);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Author added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshTable();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            // Assuming you have a DataGridView with the name dataGridView1
            if (AuthorGrid.SelectedRows.Count > 0)
            {
                // Get the selected AuthorID from the DataGridView
                string selectedAuthorID = AuthorGrid.SelectedRows[0].Cells["AuthorID"].Value.ToString();

                // Get values from text boxes
                string updatedAuthorID = authorID.Text;
                string updatedAuthorName = authorName.Text;
                string updatedNoOfBooks = noOfBooks.Text;

                // Check if any of the text boxes is empty
                if (string.IsNullOrEmpty(updatedAuthorID) || string.IsNullOrEmpty(updatedAuthorName) || string.IsNullOrEmpty(updatedNoOfBooks))
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ask for confirmation before updating
                DialogResult result = MessageBox.Show("Are you sure you want to update this author?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Connection string - update it with your database connection information
                    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\source\\repos\\Library Management-System\\Database.mdf\";Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            // SQL query to update data in the Author table based on AuthorID
                            string updateQuery = "UPDATE Author SET AuthorID = @UpdatedAuthorID, AuthorName = @UpdatedAuthorName, NoOfBooks = @UpdatedNoOfBooks WHERE AuthorID = @AuthorID";

                            using (SqlCommand command = new SqlCommand(updateQuery, connection))
                            {
                                // Add parameters to the query
                                command.Parameters.AddWithValue("@UpdatedAuthorID", updatedAuthorID);
                                command.Parameters.AddWithValue("@UpdatedAuthorName", updatedAuthorName);
                                command.Parameters.AddWithValue("@UpdatedNoOfBooks", updatedNoOfBooks);
                                command.Parameters.AddWithValue("@AuthorID", selectedAuthorID);

                                // Execute the query
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Author updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RefreshTable();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthorSearch_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            string searchText = AuthorSearch.Text;
            string query = "SELECT AuthorID, AuthorName, NoOfBooks FROM Author WHERE AuthorID LIKE '%' + @searchText + '%' OR AuthorName LIKE '%' + @searchText + '%' OR CAST(NoOfBooks AS NVARCHAR) LIKE '%' + @searchText + '%'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    AuthorGrid.DataSource = dataTable;
                    con.Close();
                }
            }
        }
    }
}

