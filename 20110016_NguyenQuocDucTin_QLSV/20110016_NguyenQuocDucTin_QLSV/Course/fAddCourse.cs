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
    public partial class fAddCourse : Form
    {
        public fAddCourse()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCourseID.Text);
            string semester = txtSemester.Text;
            string name = txtNameCourse.Text;
            string idContact = cbBoxContact.Text;
            int hours = Convert.ToInt32(txtTimeCourse.Text);
            string description = txtDescription.Text;

            Course course = new Course();

            if (name.Trim() == "")
            {
                MessageBox.Show("Add A Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (course.checkCourseName(name))
            {
                if (course.insertCourse(id, semester, name, idContact, hours, description))
                {
                    MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Course Not Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("This Course Name Already Exists", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fAddCourse_Load(object sender, EventArgs e)
        {
            loadContacts();
        }

        void loadContacts()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Teacher");
            cbBoxContact.DataSource = student.getStudents(command);
            cbBoxContact.DisplayMember = "id";
            cbBoxContact.ValueMember = "id";
            cbBoxContact.SelectedItem = null;
        }
    }
}
