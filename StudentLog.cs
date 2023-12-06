using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginRegister
{
}

namespace LoginRegister
{
}

namespace LoginRegister

{
    public partial class StudentLog : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True");
        public StudentLog()
        {
            InitializeComponent();
            StudentDataGrid.CellClick += dataGridView1_CellContentClick;

        }

        private void StudentLog_Load(object sender, EventArgs e)
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

                    string q = "SELECT * FROM studentlog";
                    using (SqlCommand CMD = new SqlCommand(q, con))
                    {
                        adapter.SelectCommand = CMD;

                        adapter.Fill(dataSet, "studentlog");
                        StudentDataGrid.DataSource = dataSet.Tables["studentlog"];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error " + ex.Message);
                }
            }
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
                            RefreshTable();
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
                    RefreshTable();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < StudentDataGrid.Rows.Count)
            {
                DataGridViewRow row = StudentDataGrid.Rows[e.RowIndex];

                string StudentID = row.Cells["studentid"].Value.ToString();
                string FirstName = row.Cells["firstname"].Value.ToString();
                string LastName = row.Cells["lastname"].Value.ToString();

                // Set the values to the textboxes
                studentidtxt.Text = StudentID;
                firstnametxt.Text = FirstName;
                lastnametxt.Text = LastName;
            }
        }
    }
}
