using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginRegister
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection cn;
        private SqlCommand cmd;
        public static string loggedInUser;

        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True");
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                //MessageBox.Show("One of your fields is invalid");
                return;
            }

            try
            {
                cn.Open();

                string query = "SELECT userType FROM LoginAndRegistration WHERE username = @username AND password = @password AND userType = @userType";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@userType", comboBox1.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string userType = reader.GetString(0);
                            if (userType == "Student")
                            {
                                loggedInUser = txtUser.Text;
                                // Display a welcome message with the logged in user's username
                                DialogResult result = MessageBox.Show($"Welcome, {loggedInUser}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                studentDashboard dashboard = new studentDashboard();
                                dashboard.Show();
                                Hide();
                            }
                            else if (userType == "Admin")
                            {
                                loggedInUser = txtUser.Text;
                                // Display a welcome message with the logged in user's username
                                DialogResult result = MessageBox.Show($"Welcome, {loggedInUser}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mainDashboard dashboard = new mainDashboard();
                                dashboard.Show();
                                Hide();
                            }
                            else
                            {
                                // Handle unrecognized user type
                                //MessageBox.Show("User type not recognized");
                            }
                        }
                        else
                        {
                            // Handle incorrect username or password
                            MessageBox.Show("Either one of your username, password and or your userType is invalid");
                        }
                    }
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



        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
            Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backbtn_Click_1(object sender, EventArgs e)
        {
            Start startForm = new Start();
            startForm.Show();
            this.Hide();
        }

    }
}

