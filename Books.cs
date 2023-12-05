using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace LoginRegister
{
    public partial class Books : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True");

        public Books()
        {
            InitializeComponent();
        }
        private void Books_Load(object sender, EventArgs e)
        {
            RefreshTable();
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

                    string q = "SELECT * FROM BookData";
                    using (SqlCommand CMD = new SqlCommand(q, con))
                    {
                        adapter.SelectCommand = CMD;

                        adapter.Fill(dataSet, "BookData");
                        BookDataGrid.DataSource = dataSet.Tables["BookData"];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error " + ex.Message);
                }
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (txttitle.Text.Trim() == "" || txtid.Text.Trim() == "" || txtauthor.Text.Trim() == "" || txtquantity.Text.Trim() == "")
            {
                MessageBox.Show("Please fill out all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand insertCommand = new SqlCommand("INSERT INTO BookData (title, booksid, author, quantity) VALUES (@title, @booksid, @author, @quantity)", con))
                {
                    insertCommand.Parameters.AddWithValue("@title", txttitle.Text);
                    insertCommand.Parameters.AddWithValue("@booksid", txtid.Text);
                    insertCommand.Parameters.AddWithValue("@author", txtauthor.Text);
                    insertCommand.Parameters.AddWithValue("@quantity", txtquantity.Text);
                    insertCommand.ExecuteNonQuery();

                    MessageBox.Show("Book has successfully added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                RefreshTable();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (txttitle.Text.Trim() == "" || txtid.Text.Trim() == "" || txtauthor.Text.Trim() == "" || txtquantity.Text.Trim() == "")
            {
                MessageBox.Show("Please fill out all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE BookData SET title = @title, author = @author, quantity = @quantity WHERE booksid = @booksid";
                using (SqlCommand updateCommand = new SqlCommand(query, con))
                {
                    updateCommand.Parameters.AddWithValue("@title", txttitle.Text);
                    updateCommand.Parameters.AddWithValue("@booksid", txtid.Text);
                    updateCommand.Parameters.AddWithValue("@author", txtauthor.Text);
                    updateCommand.Parameters.AddWithValue("@quantity", txtquantity.Text);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book has been updated successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                con.Close();
                RefreshTable();
            }
        }


        private void deletebtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Check if a row is selected
                if (BookDataGrid.SelectedRows.Count > 0)
                {
                    // Get the ID of the selected row
                    string selectedId = BookDataGrid.SelectedRows[0].Cells[0].Value.ToString();

                    // Display a confirmation message box
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user confirms the deletion, delete the record and display a success message
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "DELETE FROM BookData WHERE title = @title";
                        using (SqlCommand deleteCommand = new SqlCommand(query, con))
                        {
                            deleteCommand.Parameters.AddWithValue("@title", selectedId);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Book has been deleted successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    // If no row is selected, display an error message
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                RefreshTable();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < BookDataGrid.Rows.Count)
            {
                DataGridViewRow row = BookDataGrid.Rows[e.RowIndex];

                string txtTitle = row.Cells["title"].Value.ToString();
                string txtID = row.Cells["booksid"].Value.ToString();
                string txtAuthor = row.Cells["author"].Value.ToString();
                string txtQuantity = row.Cells["quantity"].Value.ToString();

                // Set the values to the textboxes
                txttitle.Text = txtTitle;
                txtid.Text = txtID;
                txtauthor.Text = txtAuthor;
                txtquantity.Text = txtQuantity;
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            string searchText = SearchBox.Text;
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
                    BookDataGrid.DataSource = dataTable;
                    con.Close();
                }
            }
        }
    }
}
