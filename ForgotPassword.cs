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
                    cn.Open();
                    {
                        cmd = new SqlCommand("UPDATE LoginandRegistration SET password = @password WHERE username = @username", cn);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!");
                            this.Hide();
                            Form1 form1 = new Form1();
                            form1.Show();
                        }
                        else
                        {
                            MessageBox.Show("User not found. Please check the username and try again.");
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
            else
            {
                MessageBox.Show("Please enter a value in both fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
