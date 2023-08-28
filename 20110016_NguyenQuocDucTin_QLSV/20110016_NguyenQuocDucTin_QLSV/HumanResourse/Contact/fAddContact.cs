using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.IO;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fAddContact : Form
    {
        public fAddContact()
        {
            InitializeComponent();
        }

        Student student = new Student();
        Contact contact = new Contact();   

        private void fAddContact_Load(object sender, EventArgs e)
        {
            getGroup();
        }

        private void getGroup()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Faculty");
            cbBoxGroup.DataSource = student.getStudents(command);
            cbBoxGroup.DisplayMember = "faculty";
            cbBoxGroup.ValueMember = "id";
            cbBoxGroup.SelectedItem = null;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtID.Text + "TEA";
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
                    try
                    {
                        if (contact.checkIDExist(id))
                        {
                            if (contact.insertContact(id, fname, lname, group_id, phone, email, address, pic))
                            {
                                MessageBox.Show("New Contact Added", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        } else
                        {
                            MessageBox.Show("ID already exist", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("ID already exists", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
