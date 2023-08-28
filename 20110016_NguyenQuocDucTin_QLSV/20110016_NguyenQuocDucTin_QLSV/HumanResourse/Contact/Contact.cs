using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class Contact
    {
        MY_DB mydb = new MY_DB();
        public bool insertContact(string Id, string fname, string lname, int faculty_id, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Teacher (id, fname, lname, faculty_id, phone, email, address, picture)" + " VALUES(@id, @fname, @lname, @faculty_id, @phone, @email, @address, @pic)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@faculty_id", SqlDbType.Int).Value = faculty_id;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
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

        public bool updateContact(string Id, string fname, string lname, int faculty_id, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Teacher SET fname = @fname, lname = @lname, faculty_id = @faculty_id, phone = @phone, email = @email, address = @address, picture = @picture WHERE id = @id ", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@faculty_id", SqlDbType.Int).Value = faculty_id;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

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

        public bool deleteContact(string Id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Teacher WHERE id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;

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

        public DataTable getAllContact()
        {
            SqlCommand command = new SqlCommand("SELECT id, fname, phone, email, address, picture FROM Teacher");
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool checkIDExist(string id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Teacher where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                mydb.closeConnection();
                return false;
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }

        public DataTable getContactsToShowListContact()
        {
            SqlCommand command = new SqlCommand("SELECT Teacher.id as [ID], Teacher.fname as [First Name], Teacher.lname as [Last Name], Faculty.faculty as [Group] FROM Teacher INNER JOIN Faculty ON Teacher.faculty_id = Faculty.id");
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getContactByID(string id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Teacher WHERE id = @id");

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public int getGroupID(string groupName)
        {
            int result;
            SqlCommand command = new SqlCommand("SELECT * FROM Faculty where faculty = @faculty  ", mydb.getConnection);
            command.Parameters.Add("@faculty", SqlDbType.VarChar).Value = groupName;

            mydb.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                result = Int32.Parse(table.Rows[0]["id"].ToString());
                return result;
            }
            else return -1;
        }

        public string getGroupNameByGroupID(string id)
        {
            string result;
            SqlCommand command = new SqlCommand("SELECT * FROM Faculty where id = @id  ", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

            mydb.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                result = table.Rows[0]["faculty"].ToString();
                return result;
            }
            else return null;
        }
    }
}
