using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;
using System.IO;

namespace EcomInspection
{
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
            LoadDatabase();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit?","Warning",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void FrmSetting_Load(object sender, EventArgs e)
        {
            //Load DataBase
        }
        public void LoadDatabase()
        {
            Lib.Database.AppParams _params = Lib.Database.LoadParams();
            if (_params == null) return;
            tbxFtp_Address.Text = _params.Ftp_Address;
            tbxFtp_User.Text = _params.Ftp_User;
            tbxFtp_Password.Text = _params.Ftp_Password;
            tbxFtp_Folder.Text = _params.Ftp_Folder;
            tbxNs_Address.Text = _params.Ns_Address;
            tbxNs_Password.Text = _params.Ns_Password;
            tbxNs_User.Text = _params.Ns_User;
        }
        public void SaveDatabase()
        {
            try
            {
                if (string.IsNullOrEmpty(tbxFtp_Address.Text)) throw new ArgumentNullException("FTP-Address");
                if (string.IsNullOrEmpty(tbxFtp_User.Text)) throw new ArgumentNullException("FTP-User");
                if (string.IsNullOrEmpty(tbxFtp_Folder.Text)) throw new ArgumentNullException("FTP-Folder");
                if (string.IsNullOrEmpty(tbxNs_Address.Text)) throw new ArgumentNullException("Ns-Address");

                Lib.Database.AppParams _param = new Lib.Database.AppParams
                {
                    Ftp_Address = tbxFtp_Address.Text,
                    Ftp_User = tbxFtp_User.Text,
                    Ftp_Folder = tbxFtp_Folder.Text,
                    Ftp_Password = tbxFtp_Password.Text,

                    Ns_Address = tbxNs_Address.Text,
                    Ns_User = tbxNs_User.Text,
                    Ns_Password = tbxNs_Password.Text,
                };

                Lib.Database.SaveAppParams(_param);
                MessageBox.Show("Saved!");
                FrmMain.MustUpdate = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to change params?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SaveDatabase();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBlg = new FolderBrowserDialog();
            if(fBlg.ShowDialog() == DialogResult.OK)
            {
                tbxFtp_Folder.Text = fBlg.SelectedPath;
            }
        }
    }
}
