using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class MY_DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-36EMDPS4\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True");

        // get the connection
        public SqlConnection getConnection
        {
            get
            {
                return connection;
            }
        }


        // open the connection
        public void openConnection()
        {
            if ((connection.State == ConnectionState.Closed))
            {
                connection.Open();
            }

        }

        // close the connection
        public void closeConnection()
        {
            if ((connection.State == ConnectionState.Open))
            {
                connection.Close();
            }

        }
    }
}
