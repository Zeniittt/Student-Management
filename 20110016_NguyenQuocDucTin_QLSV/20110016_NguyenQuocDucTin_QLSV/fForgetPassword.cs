using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fForgetPassword : Form
    {
        public fForgetPassword()
        {
            InitializeComponent();
        }

        User user = new User();
        string randomCode;
        public static string to;

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            try 
            {
                if (txtEmail.Text.Trim() != "")
                {
                    if (checkValidEmail(email))
                    {
                        if (user.CheckEmailInAccount(email))
                        {
                            string from, pass, messageBody;

                            //Generate Random Code For Confirmation
                            Random rand = new Random();
                            randomCode = (rand.Next(999999)).ToString();

                            MailMessage message = new MailMessage();
                            to = (txtEmail.Text).ToString();
                            from = "khaihkttran@gmail.com";
                            pass = "vrwbsjxttjtfgmey";
                            messageBody = "Your reset code is " + randomCode;
                            message.To.Add(to);
                            message.From = new MailAddress(from);
                            message.Body = messageBody;
                            message.Subject = "Password Reseting Code!";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Credentials = new NetworkCredential(from, pass);
                            try
                            {
                                smtp.Send(message);
                                MessageBox.Show("Code Send Successfully!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email not registered account!", "Error Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gmail is not formatted correctly!", "Error Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Email cannot be blank!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex)
            {

            }
        }

        bool checkValidEmail(string email)
        {
            // Kiểm tra định dạng email bằng biểu thức chính quy
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtConfrimationCode.Text).ToString())
            {
                fResetPassword.EmailConfirm = txtEmail.Text;
                this.Close();
                fResetPassword f = new fResetPassword();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Code!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
