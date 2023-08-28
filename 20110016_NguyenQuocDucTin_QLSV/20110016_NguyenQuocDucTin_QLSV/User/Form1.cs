using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                User user = new User();
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                if (rbtnStudent.Checked == true)
                {
                    if (user.checkLoginInAccountStuddent(username, password))
                    {
                        using (fLoading frmLoad = new fLoading(loadData))
                        {
                            frmLoad.ShowDialog();
                        }
                        fMainStudent f = new fMainStudent();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbtnTeacher.Checked == true)
                {
                    if (user.checkLoginInAccountTeacher(username, password))
                    {
                        using (fLoading frmLoad = new fLoading(loadData))
                        {
                            frmLoad.ShowDialog();
                        }
                        fMainTeacher f = new fMainTeacher();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbtnHumanResourse.Checked == true)
                {
                    if (user.checkLoginInAccountHumanResourse(username, password))
                    {
                        using (fLoading frmLoad = new fLoading(loadData))
                        {
                            frmLoad.ShowDialog();
                        }
                        fMainHumanResourse f = new fMainHumanResourse();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rBtnADMIN.Checked == true)
                {
                    if (user.checkLoginADMIN(username, password))
                    {
                        using (fLoading frmLoad = new fLoading(loadData))
                        {
                            frmLoad.ShowDialog();
                        }
                        fMain f = new fMain();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (user.checkLoginInRegister(username, password))
                {
                    MessageBox.Show("Your account is waiting for ADMIN approval! Please wait ♥!", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please choose a role to log in!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            pbxLogin.Image = Image.FromFile("../../images/login.jpg");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lklRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbtnStudent.Checked) fRegister.role = "Student";
            else if (rbtnTeacher.Checked) fRegister.role = "Teacher";
            else if (rbtnHumanResourse.Checked) fRegister.role = "HumanResourse";
            fRegister f = new fRegister();
            f.ShowDialog();
        }

        private void lklForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fForgetPassword f = new fForgetPassword();
            f.ShowDialog();
        }

        void loadData()
        {
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(10);
            }
        }
    }
}
