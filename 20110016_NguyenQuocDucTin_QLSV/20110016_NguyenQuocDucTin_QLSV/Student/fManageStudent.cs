using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fManageStudent : Form
    {
        public fManageStudent()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void fManageStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSetStudent.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter2.Fill(this.qLSVDataSetStudent.Student);
            fillGrid(new SqlCommand("SELECT * FROM Student"));
        }

        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            buttonColumn = (DataGridViewButtonColumn) dataGridView1.Columns[6];
            buttonColumn.Text = "Click here to view Detail";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns[6].Width = 140;
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[12];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            lblTotalStudent.Text = ("Total Students: " + dataGridView1.Rows.Count);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE CONCAT(fname, lname, address) like '%" + txtSearch.Text + "%'");
            fillGrid(command);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMajor.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtFaculty.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtpBirthDate.Value = (DateTime)dataGridView1.CurrentRow.Cells[7].Value;

            //gender
            if ((dataGridView1.CurrentRow.Cells[8].Value.ToString().Trim() == "Female"))
            {
                rbnFemale.Checked = true;
            }
            else
            {
                rbnMale.Checked = true;
            }

            txtPhone.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtHometown.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            // code xử lý hình ảnh up lên
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[12].Value;
            MemoryStream picture = new MemoryStream(pic);
            pbxUpFile.Image = Image.FromStream(picture);


        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg;*.png;.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pbxUpFile.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtMajor.Text = "";
            txtFaculty.Text = "";
            txtPhone.Text = "";
            txtHometown.Text = "";
            txtAddress.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            rbnMale.Checked = true;
            pbxUpFile.Image = null;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("student_" + txtStudentID.Text);
            if((pbxUpFile.Image == null))
            {
                MessageBox.Show("No Image in the PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                pbxUpFile.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        bool verif()
        {
            if ((txtFirstName.Text.Trim() == "")
                || (txtLastName.Text.Trim() == "")
                || (txtAddress.Text.Trim() == "")
                || (txtPhone.Text.Trim() == "")
                || (pbxUpFile.Image == null))
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
            Student student = new Student();
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string email = txtEmail.Text;
            string major = txtMajor.Text;
            string faculty = txtFaculty.Text;
            DateTime bdate = dtpBirthDate.Value;
            string phone = txtPhone.Text;
            string hometown = txtHometown.Text;
            string adrs = txtAddress.Text;
            string gender = "Male";
            if (rbnFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dtpBirthDate.Value.Year;
            int this_year = DateTime.Now.Year;

            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    string id = txtStudentID.Text;
                    pbxUpFile.Image.Save(pic, pbxUpFile.Image.RawFormat);
                    try
                    {
                        if (student.insertStudent(id, fname, lname, email, major, faculty, bdate, gender, phone, hometown, adrs, pic))
                        {
                            MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("ID already exists", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtStudentID.Text;
            Student student = new Student();
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string email = txtEmail.Text;
            string major = txtMajor.Text;
            string faculty = txtFaculty.Text;
            DateTime bdate = dtpBirthDate.Value;
            string phone = txtPhone.Text;
            string hometown = txtHometown.Text;
            string adrs = txtAddress.Text;
            string gender = "Male";

            if (rbnFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dtpBirthDate.Value.Year;
            int this_year = DateTime.Now.Year;
            // student form 10-100, may change
            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    pbxUpFile.Image.Save(pic, pbxUpFile.Image.RawFormat);
                    if (student.updateStudent(id, fname, lname, email, major, faculty, bdate, gender, phone, hometown, adrs, pic))
                    {
                        MessageBox.Show("Student Updated", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStudentID.Text);
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM Student WHERE id = " + id);
            DataTable table = student.getStudents(command);
            if (table.Rows.Count > 0)
            {
                if (verif())
                {
                    if (student.deleteStudent(id))
                    {
                        MessageBox.Show("Student Removed", "Removed Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Removed Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Field", "Removed Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("ID not found", "Removed Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void btnTotal_Click(object sender, EventArgs e)
        {
            lblTotalStudent.Text = ("Total Students: " + dataGridView1.Rows.Count);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Xử lý sự kiện khi button được click
                if (dataGridView1.Columns[e.ColumnIndex].Name == "selectedCourseDataGridViewTextBoxColumn")
                {
                    string idStudent = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    fListCourseOfStudentRegistration f = new fListCourseOfStudentRegistration();
                    f.idStudent = idStudent;
                    f.ShowDialog();
                }
            }
        }
    }
}
