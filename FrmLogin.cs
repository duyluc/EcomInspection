using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcomInspection
{
    public partial class FrmLogin : Form
    {
        private string _password = "0107600024";
        public FrmLogin()
        {
            InitializeComponent();
            this.tbxPassword.Select();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_password == tbxPassword.Text)
            {
                FrmMain.Loggedin = true;
                this.Close();
            }
            else
            {
                tbxPassword.Text = "";
                MessageBox.Show("Check your Password again!");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
