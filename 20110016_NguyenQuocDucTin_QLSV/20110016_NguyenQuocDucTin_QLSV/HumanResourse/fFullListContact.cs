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

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fFullListContact : Form
    {
        public fFullListContact()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();
        Contact contact = new Contact();
        Group group = new Group();

        private void fFullListContact_Load(object sender, EventArgs e)
        {
            loadAllGroup();

            /*dataGridViewListContact.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewListContact.RowTemplate.Height = 80;
            SqlCommand command = new SqlCommand("SELECT Teacher.id, Teacher.fname, Teacher.lname, Faculty.faculty, Teacher.phone, Teacher.email, Teacher.address, Teacher.picture FROM Teacher INNER JOIN Faculty ON Teacher.faculty_id = Faculty.id");
            command.Connection = mydb.getConnection;
            mydb.openConnection();
            DataTable table = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }
            dataGridViewListContact.DataSource = table;
            picCol = (DataGridViewImageColumn)dataGridViewListContact.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewListContact.AllowUserToAddRows = false;*/
            string query = "SELECT Teacher.id, Teacher.fname, Teacher.lname, Faculty.faculty, Teacher.phone, Teacher.email, Teacher.address, Teacher.picture FROM Teacher INNER JOIN Faculty ON Teacher.faculty_id = Faculty.id";
            loadContact(query);

        }

        void loadAllGroup()
        {
            lstBoxGroup.DataSource = group.getAllGroup();
            lstBoxGroup.ValueMember = "id";
            lstBoxGroup.DisplayMember = "faculty";

            lstBoxGroup.SelectedItem = null;
        }

        void loadContact(string query)
        {
            dataGridViewListContact.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewListContact.RowTemplate.Height = 80;
            SqlCommand command = new SqlCommand(query);
            command.Connection = mydb.getConnection;
            mydb.openConnection();
            DataTable table = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }
            dataGridViewListContact.DataSource = table;
            picCol = (DataGridViewImageColumn)dataGridViewListContact.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewListContact.AllowUserToAddRows = false;
        }

        private void lstBoxGroup_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)lstBoxGroup.SelectedItem;
            string groupName = selectedRow["faculty"].ToString();
            string query = "SELECT Teacher.id, Teacher.fname, Teacher.lname, Faculty.faculty, Teacher.phone, Teacher.email, Teacher.address, Teacher.picture FROM Teacher INNER JOIN Faculty ON Teacher.faculty_id = Faculty.id WHERE Faculty.faculty = '" + groupName + "'";
            loadContact(query);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            string query = "SELECT Teacher.id, Teacher.fname, Teacher.lname, Faculty.faculty, Teacher.phone, Teacher.email, Teacher.address, Teacher.picture FROM Teacher INNER JOIN Faculty ON Teacher.faculty_id = Faculty.id";
            loadContact(query);
        }


        private void dataGridViewListContact_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idContact = dataGridViewListContact.CurrentRow.Cells[0].Value.ToString();
            fCourseOfContact f = new fCourseOfContact();
            f.idContact = idContact;
            f.ShowDialog();
        }
    }
}
