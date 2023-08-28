using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fRegister : Form
    {
        public fRegister()
        {
            InitializeComponent();
        }

        public static bool verify = false;
        public static string role;

        private void fRegister_Load(object sender, EventArgs e)
        {
/*            pbxLogin.Image = Image.FromFile("../../images/login.jpg");*/
            if (verify == true)
            {
                lblConfirmEmail.Text = "Email Valid!";
                btnRegister.Enabled = true;
            }
            else
            {
                lblConfirmEmail.Text = "";
                btnRegister.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            verify = false;
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (verif())
                {
                    User user = new User();
                    string id = "";
                    if (role == "Student")
                    {
                        id = txtID.Text + "STU";
                    } else if (role == "Teacher")
                    {
                        id = txtID.Text + "TEA";
                    } else if (role == "HumanResourse")
                    {
                        id = txtID.Text + "HRE";
                    }
                    string fname = txtFirstName.Text;
                    string lname = txtLastName.Text;
                    string uname = txtUsername.Text;
                    string pass = txtPassword.Text;
                    string conPass = txtConfirmPass.Text;
                    string email = txtEmail.Text;
                    MemoryStream img = new MemoryStream();
                    pbxUpFile.Image.Save(img, pbxUpFile.Image.RawFormat);
                    if (role == "Student")
                    {
                        if (user.CheckUserNameInAccountStudent(uname) && user.CheckUserNameInRegister(uname) && user.CheckUserNameInAccountTeacher(uname) && user.CheckUserNameInAccountHumanResourse(uname))
                        {
                            if (String.Compare(pass, conPass) != 0)
                            {
                                MessageBox.Show("Password does not match!!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (checkValidEmail(email))
                            {
                                if (user.registerUser(role, id, fname, lname, uname, pass, email, img))
                                {
                                    /*MessageBox.Show("New User Added", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                                    MessageBox.Show("Request has been sent! Please wait for confirmation!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Gmail is not formatted correctly", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username already existed!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (role == "Teacher")
                    {
                        if (user.CheckUserNameInAccountStudent(uname) && user.CheckUserNameInRegister(uname) && user.CheckUserNameInAccountTeacher(uname) && user.CheckUserNameInAccountHumanResourse(uname))
                        {
                            if (String.Compare(pass, conPass) != 0)
                            {
                                MessageBox.Show("Password does not match!!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (checkValidEmail(email))
                            {
                                if (user.registerUser(role, id, fname, lname, uname, pass, email, img))
                                {
                                    /*MessageBox.Show("New User Added", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                                    MessageBox.Show("Request has been sent! Please wait for confirmation!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Gmail is not formatted correctly", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username already existed!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (role == "HumanResourse")
                    {
                        if (user.CheckUserNameInAccountStudent(uname) && user.CheckUserNameInRegister(uname) && user.CheckUserNameInAccountTeacher(uname) && user.CheckUserNameInAccountHumanResourse(uname))
                        {
                            if (String.Compare(pass, conPass) != 0)
                            {
                                MessageBox.Show("Password does not match!!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (checkValidEmail(email))
                            {
                                if (user.registerUser(role, id, fname, lname, uname, pass, email, img))
                                {
                                    /*MessageBox.Show("New User Added", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                                    MessageBox.Show("Request has been sent! Please wait for confirmation!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Gmail is not formatted correctly", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username already existed!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } else
                {
                    MessageBox.Show("Empty Fields", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                verify = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if ((txtUsername.Text.Trim() == "")
                || (txtPassword.Text.Trim() == "")
                || (txtConfirmPass.Text.Trim() == "")
                || (txtEmail.Text.Trim() == "")
                || (txtID.Text.Trim() == "")
                || (txtFirstName.Text.Trim() == "")
                || (txtLastName.Text.Trim() == "")
                || (pbxUpFile.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool checkValidEmail(string email)
        {
            // Kiểm tra định dạng email bằng biểu thức chính quy
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        string randomCode;
        public static string to;

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            User user = new User();
            string email = txtEmail.Text;
            if (txtEmail.Text.Trim() != "")
            {

                if (!user.CheckEmailInAccount(email) && user.CheckEmailInRegister(email))
                {
                    string from, pass, messageBody;
                    Random rand = new Random();
                    randomCode = (rand.Next(999999)).ToString();    
                    fConfirmCode.confirmCode = randomCode;
                    MailMessage message = new MailMessage();
                    to = (txtEmail.Text).ToString();
                    from = "khaihkttran@gmail.com";
                    pass = "vrwbsjxttjtfgmey";
                    messageBody = "Your confirmation code is " + randomCode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "Topdev's Confirmation Code!";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Code Send Successfully! Please enter the received code to confirm!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fConfirmCode f = new fConfirmCode();
                        f.ShowDialog();
                        fRegister_Load(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This Email is being used! Please enter another email!", "Email Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else
            {
                MessageBox.Show("Invalid Gmail!", "Email Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg;*.png;.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pbxUpFile.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
