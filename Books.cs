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
            // TODO: This line of code loads data into the 'bookDataDB.BookData' table. You can move, or remove it, as needed.
            this.bookDataTableAdapter1.Fill(this.bookDataDB.BookData);
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
                loadDatagrid();
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
                loadDatagrid();
            }
        }


        private void deletebtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Check if a row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the ID of the selected row
                    string selectedId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

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
                loadDatagrid();
            }
        }

        private void loadDatagrid()
        {
            //this.booksTableAdapter.Fill(this.masterDataSet1.Books);
            this.bookDataTableAdapter.Fill(this.booksDataSet.BookData);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

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
                    dataGridView1.DataSource = dataTable;
                    con.Close();
                }
            }
        }
    }
}
