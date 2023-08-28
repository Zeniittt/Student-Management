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
    public partial class fAverageScoreByScore : Form
    {
        public fAverageScoreByScore()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();
        Student student = new Student();

        private void fAverageScoreByScore_Load(object sender, EventArgs e)
        {
            SqlCommand commandMajor = new SqlCommand("SELECT * FROM Major");
            cbBoxMajorSearch.DataSource = student.getStudents(commandMajor);
            cbBoxMajorSearch.DisplayMember = "major";
            cbBoxMajorSearch.ValueMember = "id";
            cbBoxMajorSearch.SelectedItem = null;

            SqlCommand commandFaculty = new SqlCommand("SELECT * FROM Faculty");
            cbBoxFacultySearch.DataSource = student.getStudents(commandFaculty);
            cbBoxFacultySearch.DisplayMember = "faculty";
            cbBoxFacultySearch.ValueMember = "id";
            cbBoxFacultySearch.SelectedItem = null;

            string query = "SELECT id as [Student ID], fname as [First Name], lname as [Last Name], major as [Major], faculty as [Faculty] FROM Student";
            loadStudent(query);
        }

        void loadStudent(string query)
        {
            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand(query);
            command.Connection = mydb.getConnection;
            mydb.openConnection();
            DataTable table = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }
            dataGridView1.DataSource = table;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMajor.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtFaculty.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            string query = "SELECT id as [Student ID], fname as [First Name], lname as [Last Name], major as [Major], faculty as [Faculty] FROM Student";
            loadStudent(query);
        }

        private void btnSuperSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT id, fname, lname, major, faculty FROM Student WHERE";
            string temp = query;

            // kiểm tra câu lệnh query có thay đổi không (nhập nhiều hơn 1 tính năng để tìm kiếm)
            void checkQueryChange()
            {
                if (query != temp)
                {
                    query += " AND";
                }
            }

            //textbox ID
            if (!string.IsNullOrEmpty(txtStudentIDSearch.Text))
            {
                string id = txtStudentIDSearch.Text;
                query += " id = '" + id + "'";
            }

            //textbox FirstName
            if (!string.IsNullOrEmpty(txtFirstNameSearch.Text))
            {
                checkQueryChange();

                string fname = txtFirstNameSearch.Text;
                query += " fname = '" + fname + "'";
            }

            //textbox LastName
            if (!string.IsNullOrEmpty(txtLastNameSearch.Text))
            {
                checkQueryChange();

                string lname = txtLastNameSearch.Text;
                query += " lname = '" + lname + "'";
            }

            // comboBox Major
            if (!string.IsNullOrEmpty(cbBoxMajorSearch.Text))
            {
                checkQueryChange();

                string major = cbBoxMajorSearch.Text;
                query += " major = '" + major + "'";
            }

            // comboBox Faculty
            if (!string.IsNullOrEmpty(cbBoxFacultySearch.Text))
            {
                checkQueryChange();

                string faculty = cbBoxFacultySearch.Text;
                query += " faculty = '" + faculty + "'";
            }

            // nếu không chọn bất kì lựa chọn nào thì sẽ hiện ta tất cả thông tin trong bảng Std và thông báo
            if (query == temp)
            {
                query = "SELECT id as [Student ID], fname as [First Name], lname as [Last Name], major as [Major], faculty as [Faculty] FROM Student";
                MessageBox.Show("Not Found", "Find", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            SqlCommand command = new SqlCommand(query);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = student.getStudents(command);
            dataGridView1.AllowUserToAddRows = false;

        }
    }
}
