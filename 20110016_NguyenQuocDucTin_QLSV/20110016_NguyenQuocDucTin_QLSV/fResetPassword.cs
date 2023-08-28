using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fResetPassword : Form
    {
        public fResetPassword()
        {
            InitializeComponent();
        }

        public static string EmailConfirm;
        User user = new User();

        private void fResetPassword_Load(object sender, EventArgs e)
        {
            string username = user.getUsername(EmailConfirm);
            string password = user.getPassword(EmailConfirm);

            txtUsername.Text = username;
            txtCurrentPassword.Text = password;
        }

        private void rbtnYes_Click(object sender, EventArgs e)
        {
            txtNewPass.Enabled = true;
            txtConfirmPass.Enabled = true;
        }

        private void rbtnNo_Click(object sender, EventArgs e)
        {
            txtNewPass.Enabled = false;
            txtConfirmPass.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (rbtnYes.Checked == true)
            {
                string password = txtNewPass.Text;
                string ConfirmPass = txtConfirmPass.Text;

                if (verif())
                {
                    if (String.Compare(password, ConfirmPass) != 0)
                    {
                        MessageBox.Show("Password Not Match!", "Invalid Password Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (user.updatePassword(EmailConfirm, password))
                        {
                            MessageBox.Show("Password Updated", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Password Not Updated!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Password Was Not Changed!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        bool verif()
        {
            if (txtNewPass.Text.Trim() == "" || txtConfirmPass.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
