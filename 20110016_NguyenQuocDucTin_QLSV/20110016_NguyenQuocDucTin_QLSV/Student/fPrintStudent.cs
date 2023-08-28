using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fPrintStudent : Form
    {
        public fPrintStudent()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void fPrintStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.qLSVDataSet1.Student);
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            fillGrid(command);

            if(rBtnNo.Checked)
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }

        private void rBtnYes_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = true;
            dtpEnd.Enabled = true;
        }

        private void rBtnNo_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = false;
            dtpEnd.Enabled = false;
        }

        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[11];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            String query;
            if (rBtnYes.Checked)
            {
                string dateStart = dtpStart.Value.ToString("yyyy-MM-dd");
                string dateEnd = dtpEnd.Value.ToString("yyyy-MM-dd");

                if (rBtnMale.Checked)
                {
                    query = "SELECT * FROM Student where gender = 'Male' AND bdate BETWEEN '" + dateStart + " 'AND' " + dateEnd + "'";
                }
                else if (rBtnFemale.Checked)
                {
                    query = "SELECT * FROM Student where gender = 'Female' AND bdate BETWEEN '" + dateStart + " 'AND' " + dateEnd + "'";
                }
                else
                {
                    query = "SELECT * FROM Student WHERE bdate BETWEEN '" + dateStart + " 'AND' " + dateEnd + "'";
                }

                command = new SqlCommand(query);
                fillGrid(command);
            }
            else
            {
                if(rBtnMale.Checked)
                {
                    query = "Select * from Student where gender = 'Male'";
                }
                else if (rBtnFemale.Checked)
                {
                    query = "Select * from Student where gender = 'Female'";
                }
                else
                {
                    query = "Select * from Student";
                }

                command = new SqlCommand(query);
                fillGrid(command);
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\students_list.docx" ;
            using (var writer = new StreamWriter(path))
            {
                if(!File.Exists(path))
                {
                    File.Create(path);
                }

                DateTime bdate;

                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for(int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    {
                        if(j == 6)
                        {
                            bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            writer.Write("\t" + bdate.ToString("yyyy-MM-dd") + "\t" + "|");
                        }
                        else if(j == dataGridView1.Columns.Count - 2)
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                    }
                    writer.WriteLine("");
                    writer.WriteLine("-------------------------------------------------------------------------------------");
                }
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        

    }
}
