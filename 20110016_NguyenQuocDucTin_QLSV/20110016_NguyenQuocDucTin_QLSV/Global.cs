using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal class Global
    {
        public static string userID { get; private set; }
        public static void setUserID(string userid)
        {
            userID = userid;
        }
    }
}
