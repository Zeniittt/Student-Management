using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class Score
    {

        MY_DB mydb = new MY_DB();

        public bool insertScore(string studentID, int courseID, float score, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Score (studentID, courseID, score, description)" + " VALUES(@studentID, @courseID, @score, @description)", mydb.getConnection);

            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@score", SqlDbType.Float).Value = score;
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

        public bool deleteScore(string studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Score WHERE studentID = @studentID and courseID = @courseID", mydb.getConnection);

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

        public bool studentScoreExist(string studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Score WHERE studentID = @studentID and courseID = @courseID", mydb.getConnection);

            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;

            mydb.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable getStudentScore()
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT Score.studentID as [Student ID], Student.fname as [First Name], Student.lname as [Last Name], Score.courseID as [Course ID], Course.lable as [Course Name], Score.score as [Score] FROM Student INNER JOIN score on Student.id = Score.studentID INNER JOIN course on Score.courseID = Course.id");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getAvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT Course.lable, AVG(Score.score) as AverageGrade FROM Course, Score WHERE Course.id = Score.courseID GROUP BY Course.lable";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getStudentScoreByID(string studentID)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT Score.studentID, Student.fname, Student.lname, Score.courseID, Course.lable, Score.score FROM Student INNER JOIN Score ON Student.id = Score.studentID INNER JOIN Course ON Score.courseID = Course.id WHERE Score.studentID = @studentID";
            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }




    }
}
