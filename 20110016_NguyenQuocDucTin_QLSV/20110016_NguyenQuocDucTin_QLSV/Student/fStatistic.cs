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
    public partial class fStatistic : Form
    {
        public fStatistic()
        {
            InitializeComponent();
        }

        Color panTotalColor;
        Color panMaleColor;
        Color panFemaleColor;

        private void fStatistic_Load(object sender, EventArgs e)
        {
            panTotalColor = pnlTotal.BackColor;
            panMaleColor = pnlMale.BackColor;
            panFemaleColor = pnlFemale.BackColor;

            Student student = new Student();
            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());

            double maleStudentPercentage = (totalMale * (100 / total));
            double femaleStudentPercentage = (totalFemale * (100 / total));

            lblTotal.Text = ("Total Students: " + total.ToString());
            lblMale.Text = ("Male: " + (maleStudentPercentage.ToString("0.00") + "%"));
            lblFemale.Text = ("Female: " + (femaleStudentPercentage.ToString("0.00") + "%"));
        }

        private void lblTotal_MouseEnter(object sender, EventArgs e)
        {
            lblTotal.ForeColor = panTotalColor;
            pnlTotal.BackColor = Color.White;
        }

        private void lblTotal_MouseLeave(object sender, EventArgs e)
        {
            lblTotal.ForeColor = Color.White;
            pnlTotal.BackColor = panTotalColor;
        }

        private void lblMale_MouseEnter(object sender, EventArgs e)
        {
            lblMale.ForeColor = panMaleColor;
            pnlMale.BackColor = Color.White;
        }

        private void lblMale_MouseLeave(object sender, EventArgs e)
        {
            lblMale.ForeColor = Color.White;
            pnlMale.BackColor = panMaleColor;
        }

        private void lblFemale_MouseEnter(object sender, EventArgs e)
        {
            lblFemale.ForeColor = panFemaleColor;
            pnlFemale.BackColor = Color.White;
        }

        private void lblFemale_MouseLeave(object sender, EventArgs e)
        {
            lblFemale.ForeColor = Color.White;
            pnlFemale.BackColor = panFemaleColor;
        }
    }
}
