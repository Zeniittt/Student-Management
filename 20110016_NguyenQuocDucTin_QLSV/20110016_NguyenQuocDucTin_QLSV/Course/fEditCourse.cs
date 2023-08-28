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
    public partial class fEditCourse : Form
    {
        public fEditCourse()
        {
            InitializeComponent();
        }

        Course course = new Course();

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string semester = txtSemester.Text;
            string name = txtNameCourse.Text;
            int hours = (int)nUDwnTimeCourse.Value;
            string description = txtDescription.Text;
            int id = (int)cbBoxCourseID.SelectedValue;

            if (!course.checkCourseName(name, Convert.ToInt32(cbBoxCourseID.SelectedValue)))
            {
                MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.updateCourse(id, semester, name, hours, description))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillCombo(cbBoxCourseID.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Course Not Update", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fEditCourse_Load(object sender, EventArgs e)
        {
            cbBoxCourseID.DataSource = course.getAllCourses();
            cbBoxCourseID.DisplayMember = "lable";
            cbBoxCourseID.ValueMember = "id";
            cbBoxCourseID.SelectedItem = null;
        }

        public void fillCombo(int index)
        {
            cbBoxCourseID.DataSource = course.getAllCourses();
            cbBoxCourseID.DisplayMember = "lable";
            cbBoxCourseID.ValueMember = "id";
            cbBoxCourseID.SelectedIndex = index;
        }

        private void cbBoxCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cbBoxCourseID.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseByID(id);
                txtSemester.Text = table.Rows[0][1].ToString();
                txtNameCourse.Text = table.Rows[0][2].ToString();
                nUDwnTimeCourse.Value = Int32.Parse(table.Rows[0][3].ToString());
                txtDescription.Text = table.Rows[0][4].ToString();
            }
            catch { }
        }
    }
}
