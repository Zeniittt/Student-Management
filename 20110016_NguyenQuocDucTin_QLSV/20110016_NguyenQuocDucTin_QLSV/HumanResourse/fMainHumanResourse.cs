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
    public partial class fMainHumanResourse : Form
    {
        public fMainHumanResourse()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();
        Contact contact = new Contact();
        public string idContact { get; set; }

        public void getImageAndUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM HumanResourse WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Global.userID;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                byte[] image = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(image);
                picBoxImage.Image = Image.FromStream(picture);

                lblUser.Text = table.Rows[0]["fname"].ToString() + " " + table.Rows[0]["lname"].ToString();
            }
        }

        private void fMainHumanResourse_Load(object sender, EventArgs e)
        {
            if(idContact != null)
            {
                txtRemoveContact.Text = idContact;
            } else
            {
                getImageAndUsername();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            fProfileHumanResourse f = new fProfileHumanResourse();
            f.ShowDialog();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            fAddContact f = new fAddContact();
            f.ShowDialog();
        }

        private void btnSelectContact_Click(object sender, EventArgs e)
        {
            fListContact f = new fListContact();
            f.flag = "Remove";
            f.ShowDialog();
            loadIDContactForRemove();
        }

        private void EditContact_Click(object sender, EventArgs e)
        {
            fEditContact f = new fEditContact();
            f.Show();
        }

        public void loadIDContactForRemove()
        {
            txtRemoveContact.Text = idContact;
        }

        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            string idContact = txtRemoveContact.Text;
            if (MessageBox.Show("Are You Sure Want To Delete This Contact", "Remove Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (contact.deleteContact(idContact))
                {
                    MessageBox.Show("Contact Deleted", "Remove Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Contact Not Deleted", "Remove Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            fFullListContact f = new fFullListContact();
            f.ShowDialog();
        }
    }

}
