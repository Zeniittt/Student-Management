using Microsoft.Office.Interop.Word;
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

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fNotificationTeacher : Form
    {
        public fNotificationTeacher()
        {
            InitializeComponent();
        }

        Student student = new Student();
        Teacher teacher = new Teacher();
        Course course = new Course();
        public string idTeacher;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime dateCreate = DateTime.Now;
            int idCourse = course.getCourseIDByCourseName(cbBoxCourse.Text);
            string title = rTxtTitle.Text;
            string description = rTxtDescription.Text;
            try
            {
                if (verif())
                {
                    if (teacher.createNotification(idTeacher, idCourse, dateCreate, title, description))
                    {
                        MessageBox.Show("Create Notification Successfully", "Create Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Create Notification Failed", "Create Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Create Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool verif()
        {
            if ((cbBoxCourse.Text.Trim() == "")
                || (rTxtTitle.Text.Trim() == "")
                || (rTxtDescription.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void fNotificationTeacher_Load(object sender, EventArgs e)
        {
            loadCourse();
        }

        private void loadCourse()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE idTeacher = '" + idTeacher + "'");
            cbBoxCourse.DataSource = student.getStudents(command);
            cbBoxCourse.DisplayMember = "lable";
            cbBoxCourse.ValueMember = "id";
            cbBoxCourse.SelectedItem = null;
        }
    }
}
