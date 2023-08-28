using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fProfileHumanResourse : Form
    {
        public fProfileHumanResourse()
        {
            InitializeComponent();
        }

        User user = new User();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fProfileHumanResourse_Load(object sender, EventArgs e)
        {
            DataTable table = user.getInfoHumanResourse();
            txtID.Text = table.Rows[0][0].ToString();
            txtFirstName.Text = table.Rows[0][1].ToString();
            txtLastName.Text = table.Rows[0][2].ToString();
            txtUsername.Text = table.Rows[0][3].ToString();
            txtPassword.Text = table.Rows[0][4].ToString();
            txtEmail.Text = table.Rows[0][5].ToString();
            byte[] pic = (byte[])table.Rows[0][6];
            MemoryStream picture = new MemoryStream(pic);
            picBoxImage.Image = Image.FromStream(picture);
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg;*.png;.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                picBoxImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            string id = txtID.Text;
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            MemoryStream pic = new MemoryStream();
            try
            {
                if (verif())
                {
                    picBoxImage.Image.Save(pic, picBoxImage.Image.RawFormat);
                    if(user.updateProfile(id, fname, lname, pic))
                    {
                        MessageBox.Show("Update Profile Successfully!", "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update Profile Fail!", "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }             
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool verif()
        {
            if ((txtFirstName.Text.Trim() == "")
                || (txtLastName.Text.Trim() == "")
                || (picBoxImage.Image == null))
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
