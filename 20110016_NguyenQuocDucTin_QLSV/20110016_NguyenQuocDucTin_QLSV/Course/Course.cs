using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class Course
    {
        MY_DB mydb = new MY_DB();

        public bool insertCourse(int id, string semester, string courseName, string idContact, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (id, semester, lable, idTeacher, period, description)" + " VALUES(@id, @semester, @lable, @idTeacher, @period, @description)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = semester;
            command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@idTeacher", SqlDbType.VarChar).Value = idContact;
            command.Parameters.Add("@period", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@description", SqlDbType.VarChar).Value = description;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))

            {
                mydb.closeConnection();
                return true;
            }

            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool insertCourseToCourseStudent(string studentID, string firstName, string lastName, int courseID, string courseName, string semester)
        {
            SqlCommand command = new SqlCommand("INSERT INTO CourseStudent (studentID, fname, lname, courseID, courseName, semester)" + " VALUES(@studentID, @firstName, @lastName, @courseID, @courseName, @semester)", mydb.getConnection);

            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@courseName", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = semester;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))

            {
                mydb.closeConnection();
                return true;
            }

            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool checkCourseOfCourseStudent(string studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CourseStudent WHERE studentID = @studentID and courseID = @courseID", mydb.getConnection);
            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool updateCourse(int id, string semester, string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("UPDATE Course SET id = @id, semester = @semester, lable = @lable, period = @period, description = @description WHERE id = " + id, mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = semester;
            command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@period", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@description", SqlDbType.VarChar).Value = description;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))

            {
                mydb.closeConnection();
                return true;
            }

            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool deleteCourse(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id = " + id, mydb.getConnection);

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool deleteStudentOnCourseStudent(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM CourseStudent WHERE studentID = '" + id + "'", mydb.getConnection);

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool deleteCourseOnCourseStudent(string studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM CourseStudent WHERE studentID = @studentID and courseID = @courseID", mydb.getConnection);

            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool checkCourseName(string courseName, int courseId = 0)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE lable=@lable and id <> @id", mydb.getConnection);
            command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@id", SqlDbType.Int).Value = courseId;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int getCourseIDByCourseName(string courseName)
        {
            int result;
            SqlCommand command = new SqlCommand("SELECT id FROM Course WHERE lable = '" + courseName + "'", mydb.getConnection);
            //command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                string s = table.Rows[0]["id"].ToString();
                result = Convert.ToInt32(s);
                return result;
            }
            else return 0;            
        }

        public string getSemesterIDByCourseName(string courseName)
        {
            string result;
            SqlCommand command = new SqlCommand("SELECT semester FROM Course WHERE lable = '" + courseName + "'", mydb.getConnection);
            //command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                result = table.Rows[0]["semester"].ToString();
                return result;
            }
            else return null;
        }

        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            string count = command.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }

        public string totalCourses()
        {
            return execCount("Select count(*) from Course");
        }

        public DataTable getCourseByID(int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = courseID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseByTeacherID(string idContact)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE idTeacher = @idTeacher", mydb.getConnection);
            command.Parameters.Add("@idTeacher", SqlDbType.VarChar).Value = idContact;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public string getTeacherIDByCourseID(int idCourse)
        {
            string result;
            SqlCommand command = new SqlCommand("SELECT idTeacher FROM Course WHERE id = " + idCourse , mydb.getConnection);
            //command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                result = table.Rows[0]["idTeacher"].ToString();
                return result;
            }
            else return null;
        }

        public string getCourseNameByCourseID(int idCourse)
        {
            string result;
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE id = " + idCourse, mydb.getConnection);
            //command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                result = table.Rows[0]["lable"].ToString();
                return result;
            }
            else return null;
        }

        public DataTable getAllCourses()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

/*        public DataTable getCoursesByStudentID(string id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CourseStudent WHERE studentID = @studentID", mydb.getConnection);
            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }*/

        public DataTable getCourseOfStudent(string studentID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CourseStudent where studentID = @studentID", mydb.getConnection);
            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseNameAndSemesterCourse(string studentID)
        {
            SqlCommand command = new SqlCommand("SELECT courseName, semester FROM CourseStudent where studentID = @studentID", mydb.getConnection);
            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
