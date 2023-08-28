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
    public partial class fUpdateDeleteStudent : Form
    {
        public fUpdateDeleteStudent()
        {
            InitializeComponent();
        }

        Student student = new Student();
        Course course = new Course();

        private void btnFind_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE id = " + id);

            DataTable table = student.getStudents(command);

            if (table.Rows.Count > 0)
            {
                txtFirstName.Text = table.Rows[0]["fname"].ToString();
                txtLastName.Text = table.Rows[0]["lname"].ToString();
                txtEmail.Text = table.Rows[0]["email"].ToString();
                txtMajor.Text = table.Rows[0]["major"].ToString();
                txtFaculty.Text = table.Rows[0]["faculty"].ToString();
                dtpBirthDate.Value = (DateTime)table.Rows[0]["bdate"];

                // gender
                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    rbnFemale.Checked = true;
                }
                else
                {
                    rbnMale.Checked = true;
                }

                txtPhone.Text = table.Rows[0]["phone"].ToString();
                txtHometown.Text = table.Rows[0]["hometown"].ToString();
                txtAddress.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pbxUpFile.Image = Image.FromStream(picture);
            }

            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
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
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string idStudent = txtID.Text;
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM Student WHERE id = " + id);
            DataTable table = student.getStudents(command);
            if (table.Rows.Count > 0)
            {
                if (verif())
                {
                    if (course.deleteStudentOnCourseStudent(idStudent))
                    {
                        if(student.deleteStudent(id))
                        {
                            MessageBox.Show("Student Removed", "Removed Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }              
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

        bool verif()
        {
            if ((txtFirstName.Text.Trim() == "")
                || (txtLastName.Text.Trim() == "")
                || (txtID.Text.Trim() == "")
                || (txtEmail.Text.Trim() == "")
                || (txtMajor.Text.Trim() == "")
                || (txtHometown.Text.Trim() == "")
                || (txtFaculty.Text.Trim() == "")
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

        private void fUpdateDeleteStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                string idStudent = txtID.Text;
                SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE id = '" + idStudent + "'");
                DataTable table = student.getStudents(command);
                string selectedCourse = table.Columns[6].ColumnName;
                // Duyệt qua các hàng trong DataTable
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    // Duyệt qua các cột trong hàng hiện tại
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        // Kiểm tra giá trị của phần tử hiện tại có bằng null hay không
                        if (DBNull.Value.Equals(table.Rows[i][j]))
                        {
                            //string valueOfColumn = table.Rows[i][j].ToString();
                            if (table.Columns[j].ToString() != selectedCourse)
                            {
                                flag = true;
                                break;
                            }                               
                        }
                        else
                        {
                            flag = false;
                        }    
                    }
                }
                if (flag == false)
                {
                    fAddCourceForStudent.studentID = txtID.Text;
                    fAddCourceForStudent.studentFirstName = txtFirstName.Text;
                    fAddCourceForStudent.studentLastName = txtLastName.Text;
                    fAddCourceForStudent f = new fAddCourceForStudent();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You must fill out all the information to be able to register for the course ♥ !", "Add Course For Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Course For Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
