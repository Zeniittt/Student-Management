using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fEditContact : Form
    {
        public fEditContact()
        {
            InitializeComponent();
        }



        public string id { get; set; }
        Student student = new Student();
        Contact contact = new Contact();

        private void btnSelect_Click(object sender, EventArgs e)
        {
            fListContact f = new fListContact();
            f.flag = "Edit";
            f.ShowDialog();
            loadData();
        }

        public void fEditContact_Load(object sender, EventArgs e)
        {

            getGroup();
            /*            if(id == "")
                        {

                        } else
                        {
                            DataTable table = contact.getContactByID(id);
                            txtID.Text = table.Rows[0][0].ToString();
                            txtFirstName.Text = table.Rows[0][1].ToString();
                            txtLastName.Text = table.Rows[0][2].ToString();
                            string group = table.Rows[0][3].ToString();
                            cbBoxGroup.Text = contact.getGroupNameByGroupID(group);
                            txtPhone.Text = table.Rows[0][5].ToString();
                            txtEmail.Text = table.Rows[0][9].ToString();
                            txtAddress.Text = table.Rows[0][6].ToString();
                        }*/
        }

        public void getGroup()
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
            string groupName = cbBoxGroup.Text;
            int group_id = contact.getGroupID(groupName);
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            MemoryStream pic = new MemoryStream();
            if (verif())
            {
                try
                {
                    picBoxImage.Image.Save(pic, picBoxImage.Image.RawFormat);
                    if (contact.updateContact(id, fname, lname, group_id, phone, email, address, pic))
                    {
                        MessageBox.Show("Update Contact Successfully!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if ((txtFirstName.Text.Trim() == "")
                || (txtID.Text.Trim() == "")
                || (txtLastName.Text.Trim() == "")
                || (txtEmail.Text.Trim() == "")
                || (txtAddress.Text.Trim() == "")
                || (txtPhone.Text.Trim() == "")
                || (cbBoxGroup.Text.Trim() == "")
                || (picBoxImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void loadData()
        {
            try
            {
                DataTable table = contact.getContactByID(id);
                txtID.Text = table.Rows[0][0].ToString();
                txtFirstName.Text = table.Rows[0][1].ToString();
                txtLastName.Text = table.Rows[0][2].ToString();
                string group = table.Rows[0][3].ToString();
                cbBoxGroup.Text = contact.getGroupNameByGroupID(group);
                txtPhone.Text = table.Rows[0][5].ToString();
                txtEmail.Text = table.Rows[0][9].ToString();
                txtAddress.Text = table.Rows[0][6].ToString();
                byte[] pic;
                pic = (byte[])table.Rows[0][10];
                MemoryStream picture = new MemoryStream(pic);
                picBoxImage.Image = Image.FromStream(picture);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg;*.png;.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                picBoxImage.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
