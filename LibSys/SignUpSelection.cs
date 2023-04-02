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
    public partial class SignUpSelection : Form
    {
        public SignUpSelection()
        {
            InitializeComponent();
        }

        private void SignUpSelection_Load(object sender, EventArgs e)
        {

        }

        private void BackToForm1_Click(object sender, EventArgs e)
        {
            // Create an instance of the SignInForm form
            Form1 form1 = new Form1();

            // Show the SignInForm form
            form1.Show();

            // Hide the current form (assuming this code is in a form other than SignInForm)
            this.Hide();
        }
    }
}
