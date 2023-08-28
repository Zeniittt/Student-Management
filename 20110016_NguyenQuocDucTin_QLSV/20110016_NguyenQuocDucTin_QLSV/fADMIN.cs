using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20110016_NguyenQuocDucTin_QLSV
{
    public partial class fADMIN : Form
    {
        public fADMIN()
        {
            InitializeComponent();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fListAccountRegister f = new fListAccountRegister();
                f.ShowDialog();
            } catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
