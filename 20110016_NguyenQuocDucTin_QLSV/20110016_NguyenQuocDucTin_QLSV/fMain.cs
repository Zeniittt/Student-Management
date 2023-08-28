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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAddStudent f = new fAddStudent();
            f.Show(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStudentList f = new fStudentList();
            f.Show(this);
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStatistic f = new fStatistic();
            f.ShowDialog(this);
        }

        private void manageStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fManageStudent f = new fManageStudent();
            f.ShowDialog(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPrintStudent f = new fPrintStudent();
            f.ShowDialog(this);
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAddCourse f = new fAddCourse();
            f.ShowDialog();
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fRemoveCourse f = new fRemoveCourse();
            f.ShowDialog();
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fEditCourse f = new fEditCourse();
            f.ShowDialog();
        }

        private void manageCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fManageCourse f = new fManageCourse();
            f.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fPrintCourse f = new fPrintCourse();
            f.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAddScore f = new fAddScore();
            f.ShowDialog();
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fRemoveScore f = new fRemoveScore();
            f.ShowDialog();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fListAccountRegister f = new fListAccountRegister();
            f.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUpdateDeleteStudent f = new fUpdateDeleteStudent();
            f.ShowDialog();
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fManageScore f = new fManageScore();
            f.ShowDialog();
        }

        private void averageScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAverageScoreByCourse f = new fAverageScoreByCourse();
            f.ShowDialog();
        }

        private void averageScoreByScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAverageScoreByScore f = new fAverageScoreByScore();
            f.ShowDialog();
        }
    }
}
