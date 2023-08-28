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
    public partial class fAddScore : Form
    {
        public fAddScore()
        {
            InitializeComponent();
        }

        Score score = new Score();
        Course course = new Course();
        Student student = new Student();

        private void fAddScore_Load(object sender, EventArgs e)
        {
            

            SqlCommand command = new SqlCommand("Select id, fname, lname FROM Student");
            dataGridViewStudent.DataSource = student.getStudents(command);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
            string studentIDChoose = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
            cbBoxSelectCourse.DataSource = course.getCourseOfStudent(studentIDChoose);
            cbBoxSelectCourse.DisplayMember = "courseName";
            cbBoxSelectCourse.ValueMember = "studentID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtStudentID.Text;
                string courseName = cbBoxSelectCourse.Text;
                int courseID = course.getCourseIDByCourseName(courseName);
                float scoreValue = Convert.ToInt32(txtScore.Text);
                string description = txtDescription.Text;

                if (!score.studentScoreExist(studentID, courseID))
                {
                    if (scoreValue >= 0 && scoreValue <= 10)
                    {
                        if (score.insertScore(studentID, courseID, scoreValue, description))
                        {
                            MessageBox.Show("Student Score Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Student Score Not Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }else
                    {
                        MessageBox.Show("Score out range", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }else
                {
                    MessageBox.Show("The Score For This Course Are Already Set", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
