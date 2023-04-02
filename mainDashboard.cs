using System;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class mainDashboard : Form
    {
        public mainDashboard()
        {
            InitializeComponent();
            // Set the label text to the currently logged in user
            label3.Text = "You are logging in as: " + Form1.loggedInUser;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Borrower borrower = new Borrower();
            borrower.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void borrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrower borrower = new Borrower();
            borrower.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentLog studentlog = new StudentLog();
            studentlog.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            StudentLog studentlog = new StudentLog();
            studentlog.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            StudentLog studentlog = new StudentLog();
            studentlog.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Borrower borrower = new Borrower();
            borrower.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}