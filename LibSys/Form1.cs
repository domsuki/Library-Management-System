using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void SignUpButton_Click_1(object sender, EventArgs e)
        {
            // Create an instance of the SignUpSelection form
            SignUpSelection signUpSelection = new SignUpSelection();

            // Show the SignUpSelection form
            signUpSelection.Show();

            // Hide the current form (assuming this code is in a form other than SignUpSelection)
            this.Hide();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
                // Create an instance of the SignInForm form
                SignInForm signInForm = new SignInForm();

                // Show the SignInForm form
                signInForm.Show();

                // Hide the current form (assuming this code is in a form other than SignInForm)
                this.Hide();
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }