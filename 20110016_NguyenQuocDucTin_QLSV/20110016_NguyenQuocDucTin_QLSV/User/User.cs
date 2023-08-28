using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using System.Xml.Linq;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class User
    {
        MY_DB mydb = new MY_DB();

        // function to insert a new user

        public bool insertUserStudent(string username, string password, string email)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Login (username, password, email)" + " VALUES(@uname, @pass, @email)", mydb.getConnection);
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
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

        public bool insertUserTeacher(string id, string fname, string lname, string username, string password, string email, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Teacher (id, fname, lname, username, password, email, picture)" + " VALUES(@id, @fname, @lname, @uname, @pass, @email, @image)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@image", SqlDbType.Image).Value = image.ToArray();
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
     
        public bool CheckUserNameInAccountStudent(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login where username = @uname", mydb.getConnection);
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
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

        public bool CheckUserNameInRegister(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM RegisterAccount where username = @uname", mydb.getConnection);
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
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

        public bool CheckUserNameInAccountTeacher(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Teacher where username = @uname", mydb.getConnection);
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
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

        public bool CheckUserNameInAccountHumanResourse(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HumanResourse where username = @uname", mydb.getConnection);
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
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

        public bool CheckEmailInAccount(string email)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login where email = @email", mydb.getConnection);
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
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

        public bool CheckEmailInRegister(string email)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM RegisterAccount where email = @email", mydb.getConnection);
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
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

        public bool checkLoginInAccountStuddent(string username, string password)
        {
            MY_DB db = new MY_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE username = @User AND password = @Pass", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                string id = table.Rows[0][0].ToString();
                Global.setUserID(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkLoginADMIN(string username, string password)
        {
            MY_DB db = new MY_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = @User AND password = @Pass", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkLoginInAccountTeacher(string username, string password)
        {
            MY_DB db = new MY_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM Teacher WHERE username = @User AND password = @Pass", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                string id = table.Rows[0][0].ToString();
                Global.setUserID(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkLoginInAccountHumanResourse(string username, string password)
        {
            MY_DB db = new MY_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM HumanResourse WHERE username = @User AND password = @Pass", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                string id = table.Rows[0][0].ToString();
                Global.setUserID(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkLoginInRegister(string username, string password)
        {
            MY_DB db = new MY_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM RegisterAccount WHERE username = @User AND password = @Pass", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getUsername(string email)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE email = @email", mydb.getConnection);

            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            string username = table.Rows[0]["username"].ToString();

            return username;
        }

        public string getPassword(string email)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE email = @email", mydb.getConnection);

            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            string password = table.Rows[0]["password"].ToString();

            return password;
        }

        public bool updatePassword(string gmail, string password)
        {
            SqlCommand command = new SqlCommand("UPDATE Login SET password = @pass  WHERE email=@email", mydb.getConnection);
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = gmail;

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

        public bool registerUser(string role, string id, string fname, string lname, string username, string password, string email, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("INSERT INTO RegisterAccount (verify, role, id, fname, lname, username, password, email, image)" + " VALUES(@vrf, @role, @id, @fname, @lname, @uname, @pass, @email, @image)", mydb.getConnection);
            command.Parameters.Add("@vrf", SqlDbType.VarChar).Value = 0;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@image", SqlDbType.Image).Value = image.ToArray();
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

        public DataTable getAccount(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            /*List<CheckedUser> list = new List<CheckedUser>();
            CheckedUser userAccount = new CheckedUser()
            list.Add(CheckedUser);*/
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool deleteRegistration(string username)
        {
            SqlCommand command = new SqlCommand("DELETE FROM RegisterAccount WHERE username = '" + username + "'", mydb.getConnection);
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


        #region Human Resourse
        public bool insertUserHumanResourse(string id, string fname, string lname, string username, string password, string email, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HumanResourse (id, fname, lname, username, password, email, picture)" + " VALUES(@id, @fname, @lname, @uname, @pass, @email, @image)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@image", SqlDbType.Image).Value = image.ToArray();
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

        public DataTable getInfoHumanResourse()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HumanResourse WHERE id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Global.userID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateProfile(string id, string fname, string lname, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("UPDATE HumanResourse SET fname = @fname, lname = @lname, picture = @picture  WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
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

        #endregion
    }
}
