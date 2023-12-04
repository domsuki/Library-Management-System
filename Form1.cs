using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\d0msk\Source\Repos\Library Management-System\Database.mdf"";Integrated Security=True");
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                return;
            }

            try
            {
                cn.Open();

                string query = "SELECT userType, password, [key], iv FROM LoginandRegistration WHERE username = @username AND userType = @userType";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@userType", comboBox1.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string encryptedPassword = reader.GetString(1);
                            string keyBase64 = reader.IsDBNull(2) ? null : reader.GetString(2);
                            byte[] key = keyBase64 == null ? null : Convert.FromBase64String(keyBase64);
                            byte[] iv = Convert.FromBase64String(reader.GetString(3));

                            // Decrypt the password using the encryption key and IV
                            string decryptedPassword = DecryptStringAES(Convert.FromBase64String(encryptedPassword), key, iv);

                            if (decryptedPassword == null)
                            {
                                MessageBox.Show("Unable to decrypt the password");
                            }
                            else if (decryptedPassword == txtPass.Text)
                            {
                                // Determine the user type and show the appropriate form
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
                                    MessageBox.Show("Invalid user type. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("The password you have entered is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: Either the Username, Password or UserType is invalid, or does not exist to the record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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




        private string DecryptStringAES(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] decryptedTextBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                    string decryptedText = Encoding.UTF8.GetString(decryptedTextBytes);

                    return decryptedText;
                }
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

