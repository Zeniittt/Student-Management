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
    public partial class fAddCourceForStudent : Form
    {
        public fAddCourceForStudent()
        {
            InitializeComponent();
        }

        public static string studentID;
        public static string studentFirstName;
        public static string studentLastName;
        Student student = new Student();
        Course course = new Course();
        MY_DB mydb = new MY_DB();
        
        private void fAddCourceForStudent_Load(object sender, EventArgs e)
        {
            txtStudentID.Text = studentID;
            loadSemester();   
        }

        private void loadSemester()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Semester");
            cbBoxSemester.DataSource = student.getStudents(command);
            cbBoxSemester.DisplayMember = "semester";
            cbBoxSemester.ValueMember = "id";
            cbBoxSemester.SelectedItem = null;
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string coursecChoosed = "";
            /*int courseID;*/
            try
            {
                if (cbBoxSemester.SelectedItem != null)
                {
                    if (lstBxAvailable.SelectedItem != null)
                    {
                        coursecChoosed = lstBxAvailable.SelectedItem.ToString();
                        if (lstBxAvailable.SelectedIndex != -1) // Kiểm tra xem có phần tử nào được chọn hay không
                        {
                            lstBxAvailable.Items.Remove(coursecChoosed);
                            lstBxSelect.Items.Add(coursecChoosed).ToString();
                        }
                    }
                } else
                {
                    MessageBox.Show("Please choose Semester", "Error Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
            } catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string coursecChoosed = "";
            /*try
            {*/
                if (cbBoxSemester.SelectedItem != null)
                {
                    if (lstBxSelect.SelectedItem != null)
                    {
                        coursecChoosed = lstBxSelect.SelectedItem.ToString();
                        if (lstBxSelect.SelectedIndex != -1) // Kiểm tra xem có phần tử nào được chọn hay không
                        {
                            string semester = course.getSemesterIDByCourseName(coursecChoosed);
                            if (semester == cbBoxSemester.Text)
                            {
                                lstBxSelect.Items.Remove(coursecChoosed);
                                lstBxAvailable.Items.Add(coursecChoosed).ToString();
                            }
                            else
                            {
                                lstBxSelect.Items.Remove(coursecChoosed);
                            }
                        }
                    }
                }else
                {
                    MessageBox.Show("Please choose Semester", "Error Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            /*}catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } */     
        }

        private void lstBxAvailable_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void lstBxSelect_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text;
            string courseName = "";
            foreach (var item in lstBxSelect.Items)
            {
                string semester;
                courseName = item.ToString();
                int courseID = course.getCourseIDByCourseName(courseName);
                if (cbBoxSemester.Text != null)
                {
                    semester = cbBoxSemester.Text;
                    if (course.checkCourseOfCourseStudent(studentID, courseID))
                    {
                        if (course.insertCourseToCourseStudent(studentID, studentFirstName, studentLastName, courseID, courseName, semester))
                        {
                            MessageBox.Show("Successfully registered for the course " + courseName, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);      
                        }
                        else
                        {
                            MessageBox.Show("Not OK");
                        }
                    } else
                    {
                        MessageBox.Show(courseName + " has been registered by you", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else
                {
                    MessageBox.Show("Please choose Semester", "Error Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
                    
        }


        private void loadAvailableCourseBySemester(string semester)
        {
            mydb.openConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Course where semester = '" + semester + "'", mydb.getConnection);

            //command.Parameters.Add("@semester", SqlDbType.VarChar).Value = semester;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bool isHaveCourseSelected = false;
                // Thực hiện các xử lý với item ở đây
                int courseID = reader.GetInt32(0);
                string courseName = reader.GetString(2);
                int countSelectedBox = lstBxSelect.Items.Count;
                if(countSelectedBox == 0)
                {
                    lstBxAvailable.Items.Add(courseName);
                }   
                else
                {
                    for (int i = 0; i < countSelectedBox; i++)
                    {
                        if (lstBxSelect.Items[i].ToString() == courseName)
                        {
                            isHaveCourseSelected = false;
                            break;
                        } else
                        {
                            isHaveCourseSelected = true;
                        }
                    }
                    if(isHaveCourseSelected == true)
                    {
                        lstBxAvailable.Items.Add(courseName);
                    }
                }              
            }

            // Đóng đối tượng SqlDataReader sau khi sử dụng xong
            reader.Close();

            // Đóng kết nối và giải phóng tài nguyên
            mydb.closeConnection();
        }

        private void cbBoxSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBxAvailable.Items.Clear();
            //lstBxSelect.Items.Clear();
            string semesterChoose = "";
            if (cbBoxSemester.SelectedItem != null)
            {
                semesterChoose = ((DataRowView)cbBoxSemester.SelectedItem)["semester"].ToString();
            }
            else
            {
                semesterChoose = null;
            }
            loadAvailableCourseBySemester(semesterChoose);
        }
    }
}
