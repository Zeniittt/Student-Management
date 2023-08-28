using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SortOrder = System.Windows.Forms.SortOrder;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fMainStudent : Form
    {
        public fMainStudent()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();
        Course course = new Course();
        Student student = new Student();
        Teacher teacher = new Teacher();

        private void fMainStudent_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
            getListCourseRegistration();
            lstViewNotify.Columns.Add("Title", 200);
            lstViewNotify.Columns.Add("Sender", 100);
            lstViewNotify.Columns.Add("Time", 100);
            lstViewNotify.View = View.Details;
        }

        public void getImageAndUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Global.userID;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                byte[] image = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(image);
                picBoxImage.Image = Image.FromStream(picture);

                lblUser.Text = table.Rows[0]["fname"].ToString() + " " + table.Rows[0]["lname"].ToString();
            }
        }

        public void getListCourseRegistration()
        {
            DataTable table = course.getCourseOfStudent(Global.userID);
            int[] arrayIDCourse = new int[table.Rows.Count];
            foreach (DataRow row in table.Rows)
            {
                int idCourse = (int)row["courseID"];
                arrayIDCourse[table.Rows.IndexOf(row)] = idCourse;
            }
            foreach (int idCourse in arrayIDCourse)
            {
                DataTable valuesOfNotification = student.getNotificationByCourseID(idCourse);
                string idTeacher = course.getTeacherIDByCourseID(idCourse);
                string nameTeacher = teacher.getNameTeacherByTeacherID(idTeacher);
                foreach(DataRow row in valuesOfNotification.Rows)
                {
                    lstViewNotify.Items.Add(new ListViewItem(new string[] { row["title"].ToString(), nameTeacher, row["time"].ToString() }))
                        .Tag = DateTime.Parse(row["time"].ToString());
                }
                
            }
            lstViewNotify.Sorting = SortOrder.Descending;
            lstViewNotify.Sort();
        }

        private void lstViewNotify_ItemActivate(object sender, EventArgs e)
        {
            // Lấy phần tử được chọn
            ListViewItem selectedItem = lstViewNotify.SelectedItems[0];

            // Lấy giá trị của cột đầu tiên của phần tử được chọn
            string titleNotification = selectedItem.SubItems[0].Text;
            DataTable table = student.getNotificationByTitleNotification(titleNotification);
            int idCourse = (int) table.Rows[0]["idCourse"];
            txtCourse.Text = course.getCourseNameByCourseID(idCourse);
            lblTimeCreate.Text = table.Rows[0]["time"].ToString();
            rTxtTitle.Text = table.Rows[0]["title"].ToString();
            rTxtDescription.Text = table.Rows[0]["description"].ToString();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
