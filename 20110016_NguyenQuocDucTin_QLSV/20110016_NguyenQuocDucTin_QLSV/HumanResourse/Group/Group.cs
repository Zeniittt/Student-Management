using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class Group
    {
        MY_DB mydb = new MY_DB();
        public DataTable getAllGroup()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Faculty", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public string getGroupNameByGroupID(int idGroup)
        {
            string result;
            SqlCommand command = new SqlCommand("SELECT * FROM Faculty WHERE id = " + idGroup, mydb.getConnection);
            //command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
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

        public int getGroupIDByGroupName(string nameGroup)
        {
            int result;
            SqlCommand command = new SqlCommand("SELECT * FROM Faculty WHERE faculty = '" + nameGroup + "'", mydb.getConnection);
            //command.Parameters.Add("@lable", SqlDbType.VarChar).Value = courseName;
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
    }
}
