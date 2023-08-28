using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fProfileTeacher : Form
    {
        public fProfileTeacher()
        {
            InitializeComponent();
        }

        Teacher teacher = new Teacher();
        Group group = new Group();
        Student student = new Student();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fProfileTeacher_Load(object sender, EventArgs e)
        {
            loadGroup();
            DataTable table = teacher.getInfoTeacher();
            txtID.Text = table.Rows[0][0].ToString();
            txtFirstName.Text = table.Rows[0][1].ToString();
            txtLastName.Text = table.Rows[0][2].ToString();
            string idFaculty = table.Rows[0][3].ToString();     
            if(idFaculty != "")
            {
                cbBoxGroup.Text = group.getGroupNameByGroupID(Int32.Parse(idFaculty));
            }else
            {
                cbBoxGroup.Text = "";
            }

            txtPhone.Text = table.Rows[0][5].ToString();
            txtAddress.Text = table.Rows[0][6].ToString();
            txtUsername.Text = table.Rows[0][7].ToString();
            txtPassword.Text = table.Rows[0][8].ToString();
            txtEmail.Text = table.Rows[0][9].ToString();
            byte[] pic = (byte[])table.Rows[0][10];
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

        bool verif()
        {
            if ((txtFirstName.Text.Trim() == "")
                || (txtLastName.Text.Trim() == "")
                || (cbBoxGroup.Text.Trim() == "")
                || (txtPhone.Text.Trim() == "")
                || (txtAddress.Text.Trim() == "")
                || (picBoxImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void loadGroup()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Faculty");
            cbBoxGroup.DataSource = student.getStudents(command);
            cbBoxGroup.DisplayMember = "faculty";
            cbBoxGroup.ValueMember = "id";
            cbBoxGroup.SelectedItem = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string faculty = cbBoxGroup.Text;
            int idFaculty = group.getGroupIDByGroupName(faculty);
            string phone = txtPhone.Text;
            string address = txtAddress.Text;  

            
            MemoryStream pic = new MemoryStream();
            try
            {
                if (verif())
                {
                    picBoxImage.Image.Save(pic, picBoxImage.Image.RawFormat);
                    if (teacher.updateProfile(id, fname, lname, idFaculty, phone, address, pic))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
