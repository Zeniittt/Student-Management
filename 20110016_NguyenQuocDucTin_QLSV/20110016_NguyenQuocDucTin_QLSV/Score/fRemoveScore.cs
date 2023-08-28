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
    public partial class fRemoveScore : Form
    {
        public fRemoveScore()
        {
            InitializeComponent();
        }

        Score score = new Score();

        private void fRemoveScore_Load(object sender, EventArgs e)
        {
            dataGridViewStudent.DataSource = score.getStudentScore();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string studentID = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
            int courseID = Convert.ToInt32(dataGridViewStudent.CurrentRow.Cells[3].Value.ToString());

            if ((MessageBox.Show("Are you sure you want to delete this score", "Remove score", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                if (score.deleteScore(studentID, courseID))
                {
                    MessageBox.Show("Score Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewStudent.DataSource = score.getStudentScore();
                }
                else
                {
                    MessageBox.Show("Score Not Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
