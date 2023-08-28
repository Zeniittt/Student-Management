using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class Teacher
    {
        MY_DB mydb = new MY_DB();

        public bool createNotification(string idTeacher, int idCourse, DateTime dateCreate, string title, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Notification (idTeacher, idCourse, time, title, description)" + " VALUES(@idTeacher, @idCourse, @dateCreate, @title, @description)", mydb.getConnection);

            command.Parameters.Add("@idTeacher", SqlDbType.VarChar).Value = idTeacher;
            command.Parameters.Add("@idCourse", SqlDbType.Int).Value = idCourse;
            command.Parameters.Add("@dateCreate", SqlDbType.DateTime).Value = dateCreate;
            command.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
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

        public string getNameTeacherByTeacherID(string teacherID)
        {
            string result;
            SqlCommand command = new SqlCommand("SELECT * FROM Teacher WHERE id = '" + teacherID + "'", mydb.getConnection);
            //command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                result = table.Rows[0]["fname"].ToString() + " " + table.Rows[0]["lname"].ToString();
                return result;
            }
            else return null;
        }

        public DataTable getInfoTeacher()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Teacher WHERE id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Global.userID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateProfile(string id, string fname, string lname, int idFaculty, string phone, string address, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("UPDATE Teacher SET fname = @fname, lname = @lname, faculty_id = @idFaculty, phone = @phone, address = @address, picture = @picture  WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@idFaculty", SqlDbType.Int).Value = idFaculty;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = image.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
