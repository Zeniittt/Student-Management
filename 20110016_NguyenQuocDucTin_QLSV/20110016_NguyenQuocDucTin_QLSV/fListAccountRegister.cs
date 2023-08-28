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
    public partial class fListAccountRegister : Form
    {
        public fListAccountRegister()
        {
            InitializeComponent();
        }

        User user = new User();
        Student student = new Student();

        private void fListAccountRegister_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSetAccountRegisterWaitting.RegisterAccount' table. You can move, or remove it, as needed.
            this.registerAccountTableAdapter.Fill(this.qLSVDataSetAccountRegisterWaitting.RegisterAccount);
            SqlCommand commandStudent = new SqlCommand("SELECT * FROM RegisterAccount WHERE role = 'Student'");
            // xử lý hỉnh ảnh, code có tham khảo msdn
            DataGridViewImageColumn picColStudent = new DataGridViewImageColumn();
            dtaGridViewStudent.RowTemplate.Height = 80;
            dtaGridViewStudent.DataSource = user.getAccount(commandStudent);
            picColStudent = (DataGridViewImageColumn)dtaGridViewStudent.Columns[7];
            picColStudent.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dtaGridViewStudent.AllowUserToAddRows = false;

            SqlCommand commandTeacher = new SqlCommand("SELECT * FROM RegisterAccount WHERE role = 'Teacher'");
            // xử lý hỉnh ảnh, code có tham khảo msdn
            DataGridViewImageColumn picColTeacher = new DataGridViewImageColumn();
            dtaGridViewTeacher.RowTemplate.Height = 80;
            dtaGridViewTeacher.DataSource = user.getAccount(commandTeacher);
            picColTeacher = (DataGridViewImageColumn)dtaGridViewTeacher.Columns[7];
            picColTeacher.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dtaGridViewTeacher.AllowUserToAddRows = false;

            SqlCommand commandHumanResourse = new SqlCommand("SELECT * FROM RegisterAccount WHERE role = 'HumanResourse'");
            // xử lý hỉnh ảnh, code có tham khảo msdn
            DataGridViewImageColumn picColHumanResourse = new DataGridViewImageColumn();
            dtaGridViewHumanResourse.RowTemplate.Height = 80;
            dtaGridViewHumanResourse.DataSource = user.getAccount(commandHumanResourse);
            picColHumanResourse = (DataGridViewImageColumn)dtaGridViewHumanResourse.Columns[7];
            picColHumanResourse.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dtaGridViewHumanResourse.AllowUserToAddRows = false;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string id;
            string fname;
            string lname;
            byte[] image;
            string username;
            string password;
            string email;
            int range = dtaGridViewStudent.Rows.Count;
            for (int i = 0; i < range; i++)
            {

                if ((bool)dtaGridViewStudent.Rows[i].Cells[0].Value == true)
                {
                    id = dtaGridViewStudent.Rows[i].Cells[1].Value.ToString();
                    fname = dtaGridViewStudent.Rows[i].Cells[2].Value.ToString();
                    lname = dtaGridViewStudent.Rows[i].Cells[3].Value.ToString();
                    username = dtaGridViewStudent.Rows[i].Cells[4].Value.ToString();
                    password = dtaGridViewStudent.Rows[i].Cells[5].Value.ToString();
                    email = dtaGridViewStudent.Rows[i].Cells[6].Value.ToString();
                    image = (byte[])dtaGridViewStudent.CurrentRow.Cells[7].Value;
                    MemoryStream picture = new MemoryStream(image);

                    if (student.insertInfoStudent(id, fname, lname, email, picture, username, password))
                    {
                        if (user.deleteRegistration(username))
                        {
                            MessageBox.Show("Accept Account Successfully!", "Accept Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Accept Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            fListAccountRegister_Load(null, null);
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            string id;
            string fname;
            string lname;
            byte[] image;
            string username;
            string password;
            string email;
            int range = dtaGridViewTeacher.Rows.Count;
            for (int i = 0; i < range; i++)
            {

                if ((bool)dtaGridViewTeacher.Rows[i].Cells[0].Value == true)
                {
                    id = dtaGridViewTeacher.Rows[i].Cells[1].Value.ToString();
                    fname = dtaGridViewTeacher.Rows[i].Cells[2].Value.ToString();
                    lname = dtaGridViewTeacher.Rows[i].Cells[3].Value.ToString();
                    username = dtaGridViewTeacher.Rows[i].Cells[4].Value.ToString();
                    password = dtaGridViewTeacher.Rows[i].Cells[5].Value.ToString();
                    email = dtaGridViewTeacher.Rows[i].Cells[6].Value.ToString();
                    image = (byte[])dtaGridViewTeacher.CurrentRow.Cells[7].Value;
                    MemoryStream picture = new MemoryStream(image);

                    if (user.insertUserTeacher(id, fname, lname, username, password, email, picture))
                    {
                        if (user.deleteRegistration(username))
                        {
                            MessageBox.Show("Accept Account Successfully!", "Accept Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Accept Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            fListAccountRegister_Load(null, null);
        }

        private void btnAddHumanResourse_Click(object sender, EventArgs e)
        {
            string id;
            string fname;
            string lname;
            byte[] image;
            string username;
            string password;
            string email;
            int range = dtaGridViewHumanResourse.Rows.Count;
            for (int i = 0; i < range; i++)
            {

                if ((bool)dtaGridViewHumanResourse.Rows[i].Cells[0].Value == true)
                {
                    id = dtaGridViewHumanResourse.Rows[i].Cells[1].Value.ToString();
                    fname = dtaGridViewHumanResourse.Rows[i].Cells[2].Value.ToString();
                    lname = dtaGridViewHumanResourse.Rows[i].Cells[3].Value.ToString();
                    username = dtaGridViewHumanResourse.Rows[i].Cells[4].Value.ToString();
                    password = dtaGridViewHumanResourse.Rows[i].Cells[5].Value.ToString();
                    email = dtaGridViewHumanResourse.Rows[i].Cells[6].Value.ToString();
                    image = (byte[])dtaGridViewHumanResourse.CurrentRow.Cells[7].Value;
                    MemoryStream picture = new MemoryStream(image);

                    if (user.insertUserHumanResourse(id, fname, lname, username, password, email, picture))
                    {
                        if (user.deleteRegistration(username))
                        {
                            MessageBox.Show("Accept Account Successfully!", "Accept Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Accept Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            fListAccountRegister_Load(null, null);
        }
    }
}
