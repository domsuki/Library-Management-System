using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class studentDashboard : Form
    {
        public studentDashboard()
        {
            InitializeComponent();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            // Prompt the user to confirm they want to log out
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the current form
                Close();
                // Show the login form again
                Start start = new Start();
                start.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "You are logging in as: " + Form1.loggedInUser;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            studentBooks studentbooks = new studentBooks();
            studentbooks.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Borrower borrower = new Borrower();
            borrower.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentBooks studentbooks = new studentBooks();
            studentbooks.Show();
        }

        private void borrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrower borrower = new Borrower();
            borrower.Show();
        }
    }
}


