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

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fMainTeacher : Form
    {
        public fMainTeacher()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();

        public void getImageAndUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM Teacher WHERE id = @id", mydb.getConnection);
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

        private void fMainTeacher_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            fNotificationTeacher f = new fNotificationTeacher();
            f.idTeacher = Global.userID;
            f.ShowDialog();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            fProfileTeacher f = new fProfileTeacher();
            f.ShowDialog();
        }
    }
}
