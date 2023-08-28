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
    public partial class fConfirmCode : Form
    {
        public fConfirmCode()
        {
            InitializeComponent();
        }

        public static string confirmCode;

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (confirmCode == txtCfCode.Text)
            {
                MessageBox.Show("Congratulation! Email has been confirmed!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                fRegister.verify = true;               
            }
            else
            {
                MessageBox.Show("Invalid Code!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
