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
    public partial class fManageScore : Form
    {
        public fManageScore()
        {
            InitializeComponent();
        }

        Student student = new Student();
        Score score = new Score();
        Course course = new Course();
        string data = "Score";

        private void fManageScore_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = score.getStudentScore();

            cbBoxSelectCourse.DataSource = course.getAllCourses();
            cbBoxSelectCourse.DisplayMember = "lable";
            cbBoxSelectCourse.ValueMember = "id";
        }

        private void btnShowStudent_Click(object sender, EventArgs e)
        {
            data = "Student";
            SqlCommand command = new SqlCommand("SELECT id as [Student ID], fname as [First Name], lname as [Last Name], bdate as [Birthday] FROM Student");
            dataGridView1.DataSource = student.getStudents(command);
        }

        private void btnShowScore_Click(object sender, EventArgs e)
        {
            data = "Score";
            dataGridView1.DataSource = score.getStudentScore();
        }

        void getDataFromDataGridView()
        {
            string studentIDChoose = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbBoxSelectCourse.DataSource = course.getCourseOfStudent(studentIDChoose);
            cbBoxSelectCourse.DisplayMember = "courseName";
            cbBoxSelectCourse.ValueMember = "studentID";
            if (data == "Student")
            {
                txtStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            } else if (data == "Score")
            {
                txtStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbBoxSelectCourse.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtScore.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void btnAvarage_Click(object sender, EventArgs e)
        {
            fAverageScoreByCourse f = new fAverageScoreByCourse();
            f.ShowDialog();
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
                    }
                    else
                    {
                        MessageBox.Show("Score out range", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The Score For This Course Are Already Set", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string studentID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int courseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if ((MessageBox.Show("Are you sure you want to delete this score", "Remove score", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                if (score.deleteScore(studentID, courseID))
                {
                    MessageBox.Show("Score Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = score.getStudentScore();
                }
                else
                {
                    MessageBox.Show("Score Not Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
