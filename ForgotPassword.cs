using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class ForgotPassword : Form
    {
        private readonly SqlConnection cn;
        private SqlCommand cmd;
        public ForgotPassword()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True");
        }

        private void changepassbtn_Click(object sender, EventArgs e)
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

                    using (SqlConnection cn = new SqlConnection(@"Data Source=LENOVO-PC;Initial Catalog=master;Integrated Security=True"))
                    {
                        cn.Open();

                        using(SqlCommand cmd = new SqlCommand("UPDATE LoginandRegistration SET password = @password, [key] = @key, iv = @iv WHERE username = @username", cn))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@password", Convert.ToBase64String(encryptedPassword));
                            cmd.Parameters.AddWithValue("@key", Convert.ToBase64String(key));
                            cmd.Parameters.AddWithValue("@iv", Convert.ToBase64String(iv));

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password updated successfully!");
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("User not found. Please check the username and try again.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a value in both fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
