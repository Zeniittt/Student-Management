using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Net;
using System.Xml.Linq;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class Student
    {
        MY_DB mydb = new MY_DB();

        // function to insert a new student

        public bool insertStudent(string Id, string fname, string lname, string email, string major, string faculty, DateTime bdate, string gender, string phone, string hometown, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Student (id, fname, lname, email, major, faculty, bdate, gender, phone, hometown, address, picture)" + " VALUES(@id, @fn, @ln, @eml, @mj, @fct, @bdt, @gdr, @phn, @ht, @adrs, @pic)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@eml", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@mj", SqlDbType.VarChar).Value = major;
            command.Parameters.Add("@fct", SqlDbType.VarChar).Value = faculty;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@ht", SqlDbType.VarChar).Value = hometown;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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

        public bool insertInfoStudent(string Id, string fname, string lname, string email, MemoryStream picture, string username, string password)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Student (id, fname, lname, email, picture, username, password)" + " VALUES(@id, @fn, @ln, @eml, @pic, @username, @password)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@eml", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = username;

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

        public bool addCourseStudent(string courseName, string studentID)
        {
            SqlCommand command = new SqlCommand("UPDATE Student SET selectedCourse= @selectedCourse  where id = @studentID", mydb.getConnection);

            command.Parameters.Add("@selectedCourse", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;

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

        public bool updateStudent(string Id, string fname, string lname, string email, string major, string faculty, DateTime bdate, string gender, string phone, string hometown, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Student SET fname = @fn, lname = @ln, email = @eml, major = @mj, faculty = @fct, bdate = @bdt, gender = @gdr, phone = @phn, hometown = @ht, address = @adrs, picture = @pic WHERE id = @Id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@eml", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@mj", SqlDbType.VarChar).Value = major;
            command.Parameters.Add("@fct", SqlDbType.VarChar).Value = faculty;
            command.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@ht", SqlDbType.VarChar).Value = hometown;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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

        public bool deleteStudent(int Id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Student WHERE id = " + Id, mydb.getConnection);

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

        public string getCourseOfStudentRegister(string studentID)
        {
            string result;
            SqlCommand command = new SqlCommand("SELECT selectedCourse FROM Student where id = @id  ", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = studentID;

            mydb.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                result = table.Rows[0]["selectedCourse"].ToString();
                return result;
            }
            else return null;
        }

        public DataTable getStudentOnCourse(string courseName)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT CourseStudent.studentID as [Student ID], CourseStudent.fname as [First Name], CourseStudent.lname as [Last Name], Student.bdate as [Birthday]  FROM Student INNER JOIN CourseStudent on Student.id = CourseStudent.studentID WHERE courseName= @courseName");

            command.Parameters.Add("@courseName", SqlDbType.VarChar).Value = courseName;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getNotificationByCourseID(int idCourse)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT * FROM Notification WHERE idCourse = @idCourse");

            command.Parameters.Add("@idCourse", SqlDbType.Int).Value = idCourse;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getNotificationByTitleNotification(string title)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT * FROM Notification WHERE title = @title");

            command.Parameters.Add("@title", SqlDbType.VarChar).Value = title;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = command.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }

        public string totalStudent()
        {
            return execCount("SELECT COUNT (*) FROM Student");
        }

        public string totalMaleStudent()
        {
            return execCount("SELECT COUNT (*) FROM Student where gender = 'Male'");
        }

        public string totalFemaleStudent()
        {
            return execCount("SELECT COUNT (*) FROM Student where gender = 'Female'");
        }

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
