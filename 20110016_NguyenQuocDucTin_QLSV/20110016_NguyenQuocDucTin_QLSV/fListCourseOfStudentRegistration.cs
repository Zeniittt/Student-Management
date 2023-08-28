using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fListCourseOfStudentRegistration : Form
    {
        public fListCourseOfStudentRegistration()
        {
            InitializeComponent();
        }

        public string idStudent = "";
        Course course = new Course();

        private void fListCourseOfStudentRegistration_Load(object sender, EventArgs e)
        {
            lstViewCourse.View = View.Details;
            DataTable table = course.getCourseNameAndSemesterCourse(idStudent);
            foreach (DataRow row in table.Rows)
            {
                ListViewItem item = new ListViewItem(row["courseName"].ToString());
                item.SubItems.Add(row["semester"].ToString());
                lstViewCourse.Items.Add(item);
            }


        }
    }
}
