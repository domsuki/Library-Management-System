using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
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
                    string password = txtPassword.Text;
                    byte[] encryptedPassword;
                    byte[] key;
                    byte[] iv;

                    using (Aes aes = Aes.Create())
                    {
                        aes.KeySize = 256;
                        key = aes.Key;
                        iv = aes.IV;

                        using (var encryptor = aes.CreateEncryptor(key, iv))
                        {
                            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                            encryptedPassword = encryptor.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);
                        }
                    }

                    cn.Open();
                    {
                        cmd = new SqlCommand("INSERT INTO LoginandRegistration (username, password, userType, [key], iv) VALUES (@username, @password, @userType, @key, @iv)", cn);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", Convert.ToBase64String(encryptedPassword));
                        cmd.Parameters.AddWithValue("@userType", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@key", Convert.ToBase64String(key));
                        cmd.Parameters.AddWithValue("@iv", Convert.ToBase64String(iv));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration Successful!");
                        this.Hide();
                        Start start = new Start();
                        start.Show();
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

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
