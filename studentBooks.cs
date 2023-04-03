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
    public partial class studentBooks : Form
    {
        public studentBooks()
        {
            InitializeComponent();
        }

        private void studentBooks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDataSet.BookData' table. You can move, or remove it, as needed.
            this.bookDataTableAdapter.Fill(this.booksDataSet.BookData);

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True;";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
