using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginRegister

{
    public partial class StudentLog : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True");
        public StudentLog()
        {
            InitializeComponent();
        }

        private void StudentLog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentlogDS.studentlog' table. You can move, or remove it, as needed.
            this.studentlogTableAdapter1.Fill(this.studentlogDS.studentlog);

        }

        private void studentidtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReloadDataGridView()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            string query = "SELECT studentid, firstname, lastname FROM studentlog";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void addstudentbtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM studentlog WHERE studentid = @StudentID", con))
                    {
                        checkCommand.Parameters.AddWithValue("@StudentID", studentidtxt.Text);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0) // check if count is greater than zero instead of less than zero
                        {
                            MessageBox.Show("Student already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //studentlog record
                            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO studentlog (studentid, firstname, lastname) VALUES (@studentid, @firstname, @lastname)", con))
                            {
                                insertCommand.Parameters.AddWithValue("@studentid", studentidtxt.Text);
                                insertCommand.Parameters.AddWithValue("@firstname", firstnametxt.Text);
                                insertCommand.Parameters.AddWithValue("@lastname", lastnametxt.Text);
                                insertCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Successfully added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload the data in the DataGridView
                            ReloadDataGridView();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deletestudentbtn_Click(object sender, EventArgs e)
        {
            // Get the student ID from the textbox
            string studentId = studentidtxt.Text;

            // Set up the database connection string
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\d0msk\\Source\\Repos\\Library Management-System\\Database.mdf\";Integrated Security=True";

            // Open a connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Check if the student exists in the studentlog table
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM studentlog WHERE studentid = @StudentID", con))
                    {
                        checkCommand.Parameters.AddWithValue("@StudentID", studentId);
                        int count = (int)checkCommand.ExecuteScalar();

                        // If the student doesn't exist, show an error message
                        if (count == 0)
                        {
                            MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Delete the student from the studentlog table
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM studentlog WHERE studentid = @StudentID", con))
                    {
                        deleteCommand.Parameters.AddWithValue("@StudentID", studentId);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Show a success message
                    MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Call a method to reload the data in the DataGridView, if necessary.
                    ReloadDataGridView();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
