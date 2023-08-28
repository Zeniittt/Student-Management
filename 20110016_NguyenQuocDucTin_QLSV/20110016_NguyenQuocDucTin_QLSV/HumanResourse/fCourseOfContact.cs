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
    public partial class fCourseOfContact : Form
    {
        public fCourseOfContact()
        {
            InitializeComponent();
        }

        public string idContact = "";
        Course course = new Course();

        private void fCourseOfContact_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSetCourseOfContact.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.qLSVDataSetCourseOfContact.Course);
            dataGridView1.DataSource = course.getCourseByTeacherID(idContact);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nameCourse = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string semester = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            fCourseStudentList.semester = semester;
            fCourseStudentList.courseName = nameCourse;
            fCourseStudentList f = new fCourseStudentList();
            f.ShowDialog();
        }
    }
}
