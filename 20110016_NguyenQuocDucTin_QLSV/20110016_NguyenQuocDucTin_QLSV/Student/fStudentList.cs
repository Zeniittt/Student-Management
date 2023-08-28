using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fStudentList : Form
    {
        public fStudentList()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void fStudentList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.qLSVDataSet1.Student);
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            dataGridView1.ReadOnly = true;
            // xử lý hỉnh ảnh, code có tham khảo msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[11];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            SqlCommand commandMajor = new SqlCommand("SELECT * FROM Major");
            cbBoxMajor.DataSource = student.getStudents(commandMajor);
            cbBoxMajor.DisplayMember = "major";
            cbBoxMajor.ValueMember = "id";
            cbBoxMajor.SelectedItem = null;

            SqlCommand commandFaculty = new SqlCommand("SELECT * FROM Faculty");
            cbBoxFaculty.DataSource = student.getStudents(commandFaculty);
            cbBoxFaculty.DisplayMember = "faculty";
            cbBoxFaculty.ValueMember = "id";
            cbBoxFaculty.SelectedItem = null;

            SqlCommand commandGender = new SqlCommand("SELECT * FROM Gender");
            cbBoxGender.DataSource = student.getStudents(commandGender);
            cbBoxGender.DisplayMember = "gender";
            cbBoxGender.ValueMember = "id";
            cbBoxGender.SelectedItem = null;

            SqlCommand commandHometown = new SqlCommand("SELECT * FROM Hometown");
            cbBoxHometown.DataSource = student.getStudents(commandHometown);
            cbBoxHometown.DisplayMember = "hometown";
            cbBoxHometown.ValueMember = "id";
            cbBoxHometown.SelectedItem = null;
        }

            private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            dataGridView1.ReadOnly = true;
            // xử lý hỉnh ảnh, code có tham khảo msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[11];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fUpdateDeleteStudent fUpdateDeleteStd = new fUpdateDeleteStudent();
            // thứ tự của các cột id, fname, lname, bd, grd, phn, adrs, pic
            fUpdateDeleteStd.txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fUpdateDeleteStd.txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            fUpdateDeleteStd.txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            fUpdateDeleteStd.txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            fUpdateDeleteStd.txtMajor.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            fUpdateDeleteStd.txtFaculty.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string bdate = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if(bdate == "")
            {
                fUpdateDeleteStd.dtpBirthDate.Value = DateTime.Now;
            }else
            {
                fUpdateDeleteStd.dtpBirthDate.Value = (DateTime)dataGridView1.CurrentRow.Cells[6].Value;
            }
            //fUpdateDeleteStd.dtpBirthDate.Value = (DateTime)dataGridView1.CurrentRow.Cells[6].Value;

            //gender
            if ((dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim() == "Female"))
            {
                fUpdateDeleteStd.rbnFemale.Checked = true;
            }
            else
            {
                fUpdateDeleteStd.rbnMale.Checked = true;
            }

            fUpdateDeleteStd.txtPhone.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            fUpdateDeleteStd.txtHometown.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            fUpdateDeleteStd.txtAddress.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

            // code xử lý hình ảnh up lên
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[11].Value;
            MemoryStream picture = new MemoryStream(pic);
            fUpdateDeleteStd.pbxUpFile.Image = Image.FromStream(picture);
            this.Show();
            fUpdateDeleteStd.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("select * from Student where concat(fname, lname, phone, address) like '%" + txtSearch.Text + "%'");
            //fSearchStudent f = new fSearchStudent();
            //f.ShowDialog();
            //f.dataGridView1.DataSource = student.getStudents(command);
            //f.dataGridView1.ReadOnly = true;
            //// xử lý hỉnh ảnh, code có tham khảo msdn
            //DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            //f.dataGridView1.RowTemplate.Height = 80;
            //picCol = (DataGridViewImageColumn)f.dataGridView1.Columns[7];
            //picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //f.dataGridView1.AllowUserToAddRows = false;

            //string searchText = txtSearch.Text;
            //fSearchStudent f = new fSearchStudent();
            //f.textSearch = searchText;
            //f.ShowDialog();
            string firstName, lastName, email, major, faculty, hometown, address;
            string searchText = txtSearch.Text;
            if (chkBoxFirstName.Checked == true) firstName = "fname"; else firstName = "null";
            if (chkBoxLastName.Checked == true) lastName = "lname"; else lastName = "null";
            if (chkBoxEmail.Checked == true) email = "email"; else email = "null";
            if (chkBoxMajor.Checked == true) major = "major"; else major = "null";
            if (chkBoxFaculty.Checked == true) faculty = "faculty"; else faculty = "null";
            if (chkBoxHometown.Checked == true) hometown = "hometown"; else hometown = "null";
            if (chkBoxAddress.Checked == true) address = "address"; else address = "null";
            SqlCommand command = new SqlCommand("Select * from Student where concat(" + firstName + ", " + lastName + ", " + email + ", " + major + ", " + faculty + ", " + hometown + ", " + address + ") like '%" + searchText + "%'");
            dataGridView1.DataSource = student.getStudents(command);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[11];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void btnSuperSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Student WHERE";
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
            if (!string.IsNullOrEmpty(txtStudentID.Text))
            {
                string id = txtStudentID.Text;
                query += " id = '" + id + "'";
            }

            //textbox FirstName
            if (!string.IsNullOrEmpty(txtFirstName.Text))
            {
                checkQueryChange();

                string fname = txtFirstName.Text;
                query += " fname = '" + fname + "'";
            }

            //textbox LastName
            if (!string.IsNullOrEmpty(txtLastName.Text))
            {
                checkQueryChange();

                string lname = txtLastName.Text;
                query += " lname = '" + lname + "'";
            }


            //textbox Address
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                checkQueryChange();

                string email = txtEmail.Text;
                query += " email = '" + email + "'";
            }          

            // comboBox Major
            if (!string.IsNullOrEmpty(cbBoxMajor.Text))
            {
                checkQueryChange();

                string major = cbBoxMajor.Text;
                query += " major = '" + major + "'";
            }

            // comboBox Faculty
            if (!string.IsNullOrEmpty(cbBoxFaculty.Text))
            {
                checkQueryChange();

                string faculty = cbBoxFaculty.Text;
                query += " faculty = '" + faculty + "'";
            }

            if (!string.IsNullOrEmpty(cbBoxGender.Text))
            {
                checkQueryChange();

                string gender = cbBoxGender.Text;
                query += " gender = '" + gender + "'";
            }

            if (!string.IsNullOrEmpty(cbBoxHometown.Text))
            {
                checkQueryChange();

                string hometown = cbBoxHometown.Text;
                query += " hometown = '" + hometown + "'";
            }

            // nếu không chọn bất kì lựa chọn nào thì sẽ hiện ta tất cả thông tin trong bảng Std và thông báo
            if (query == temp)
            {
                query = "SELECT * FROM Student";
                MessageBox.Show("Not Found", "Find", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            SqlCommand command = new SqlCommand(query);
            dataGridView1.ReadOnly = true;
            // xử lý hỉnh ảnh, code có tham khảo msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[11];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
