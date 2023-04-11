using System;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
        }

        private void forgotPassLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("To reset your password, you must need an administrator access to continue.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }
    }
}
