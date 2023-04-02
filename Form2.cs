using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class Registration : Form
    {
        private SqlConnection cn;
        private SqlCommand cmd;

        public Registration()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                try
                {
                    cn.Open();
                    {
                        cmd = new SqlCommand("INSERT INTO LoginandRegistration (username, password) VALUES (@username, @password)", cn);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text); // Corrected parameter name

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration Successful!");
                        this.Hide(); // hide the current form
                        Form1 form1 = new Form1(); // create a new instance of Form1
                        form1.Show(); // show the new instance of Form1
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a value in both fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Start startForm = new Start();
            startForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
