using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*Application.Run(new fMain());*/
            fLogin flogin = new fLogin();
            if (flogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new fMain());
            }
            else
            {
                Application.Exit();
            }
            /*fLoading f = new fLoading();
            f.ShowDialog();*/
        }
    }
}
