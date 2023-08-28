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
    public partial class fManageCourse : Form
    {
        public fManageCourse()
        {
            InitializeComponent();
        }

        Course course = new Course();
        int pos;

        private void fManageCourse_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }

        void reloadListBoxData()
        {
            lsBxCourse.DataSource = course.getAllCourses();
            lsBxCourse.ValueMember = "id";
            lsBxCourse.DisplayMember = "lable";

            lsBxCourse.SelectedItem = null;

            lblTotalCourses.Text = ("Total Courses: " + course.totalCourses());
        }

        void showData(int index)
        {
            try {
                DataRow dr = course.getAllCourses().Rows[index];
                lsBxCourse.SelectedIndex = index;
                txtCourseID.Text = dr.ItemArray[0].ToString();
                txtSemester.Text = dr.ItemArray[1].ToString();
                txtNameCourse.Text = dr.ItemArray[2].ToString();
                cbBoxContact.Text = dr.ItemArray[3].ToString();
                nUDwnTimeCourse.Value = int.Parse(dr.ItemArray[4].ToString());
                txtDescription.Text = dr.ItemArray[5].ToString();
            }catch
            {
                MessageBox.Show("Please choose course!", "Manage Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void lsBxCourse_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)lsBxCourse.SelectedItem;
            pos = lsBxCourse.SelectedIndex;
            showData(pos);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCourseID.Text);
            string semester = txtSemester.Text;
            string name = txtNameCourse.Text;
            string idContact = cbBoxContact.Text;
            int hours = (int)nUDwnTimeCourse.Value;
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
                    reloadListBoxData();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCourseID.Text);
            string semester = txtSemester.Text;
            string name = txtNameCourse.Text;
            int hours = (int)nUDwnTimeCourse.Value;
            string description = txtDescription.Text;


            if (!course.checkCourseName(name, Convert.ToInt32(txtCourseID.Text)))
            {
                MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.updateCourse(id, semester, name, hours, description))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadListBoxData();
            }
            else
            {
                MessageBox.Show("Course Not Update", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int courseID = Convert.ToInt32(txtCourseID.Text);
                if (MessageBox.Show("Are You Sure Want To Delete This Course", "Remove Course", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (course.deleteCourse(courseID))
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Enter A Valid Numeric ID", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos--;
                showData(pos);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos < (course.getAllCourses().Rows.Count - 1))
            {
                pos++;
                showData(pos);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pos = course.getAllCourses().Rows.Count - 1;
            showData(pos);
        }

        private void lsBxCourse_DoubleClick(object sender, EventArgs e)
        {
            string courseName = "";
            courseName = txtNameCourse.Text;
            fCourseStudentList.courseName = courseName;
            fCourseStudentList.semester = txtSemester.Text;
            fCourseStudentList f = new fCourseStudentList();
            f.ShowDialog();
        }
    }
}
