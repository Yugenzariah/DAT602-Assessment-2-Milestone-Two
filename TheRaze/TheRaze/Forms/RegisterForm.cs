using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using TheRaze.Data;
using TheRaze.Utils;

namespace TheRaze.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthDao _auth = new AuthDao();

        public RegisterForm()
        {
            InitializeComponent();
        }

        public RegisterForm(string suggestedUsername)
        {
            InitializeComponent();
            txtUsername.Text = suggestedUsername;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var user = txtUsername.Text.Trim();
                var email = txtEmail.Text.Trim();
                var pass = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                _auth.Register(user, email, HashHelper.FakeHash(pass));
                MessageBox.Show("Registered. You can now login.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
