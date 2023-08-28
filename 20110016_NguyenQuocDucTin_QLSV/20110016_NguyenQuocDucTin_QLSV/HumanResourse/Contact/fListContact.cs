using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fListContact : Form
    {
        public fListContact()
        {
            InitializeComponent();
        }

        Contact contact = new Contact();
        public string flag = "";

        private void fListContact_Load(object sender, EventArgs e)
        {
            dataGridViewListContact.DataSource = contact.getContactsToShowListContact();
            dataGridViewListContact.ReadOnly = true;
        }

        private void dataGridViewListContact_Click(object sender, EventArgs e)
        {
            string id = dataGridViewListContact.CurrentRow.Cells[0].Value.ToString();
            if(flag == "Edit")
            {
                fEditContact f = (fEditContact)Application.OpenForms["fEditContact"];
                f.id = id;
                this.Close();
            }    
            else if(flag == "Remove")
            {
                fMainHumanResourse f = (fMainHumanResourse)Application.OpenForms["fMainHumanResourse"];
                f.idContact = id;
                this.Close();
            }
            
        }

        private void fListContact_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(flag == "Edit")
            {
                fEditContact f = (fEditContact)Application.OpenForms["fEditContact"];
                f.loadData();
            } else if(flag == "Remove")
            {
                fMainHumanResourse f = (fMainHumanResourse)Application.OpenForms["fMainHumanResourse"];
                f.loadIDContactForRemove();
            }
        }
    }
}
