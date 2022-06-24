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
            cbParamType.SelectedIndex = 0;
            LoadDatabase();
        }
        public void LoadDatabase()
        {
            Lib.Database.AppParams _params = Lib.Database.LoadParams();
            if (_params != null)
            {
                tbxFtp_Address.Text = _params.Ftp_Address;
                tbxFtp_User.Text = _params.Ftp_User;
                tbxFtp_Password.Text = _params.Ftp_Password;
                tbxFtp_Folder.Text = _params.Ftp_Folder;
                tbxNs_Address.Text = _params.Ns_Address;
                tbxNs_Password.Text = _params.Ns_Password;
                tbxNs_User.Text = _params.Ns_User;
            }

            List<Lib.Database.ToolParams> toolParams = Lib.Database.LoadToolParams();
            foreach(Lib.Database.ToolParams toolParam in toolParams)
            {
                dvParam.Rows.Add();
                dvParam.Rows[dvParam.RowCount - 1].Cells[0].Value = toolParam.ParamName;
                dvParam.Rows[dvParam.RowCount - 1].Cells[1].Value = toolParam.ParamType;
                dvParam.Rows[dvParam.RowCount - 1].Cells[2].Value = toolParam.ParamValue;
            }
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

                //Toolparam
                List<Lib.Database.ToolParams> toolParams = new List<Lib.Database.ToolParams>();
                foreach(DataGridViewRow row in dvParam.Rows)
                {
                    Lib.Database.ToolParams param = new Lib.Database.ToolParams
                    {
                        ParamName = row.Cells[0].Value.ToString(),
                        ParamType = row.Cells[1].Value.ToString(),
                        ParamValue = row.Cells[2].Value.ToString(),
                    };
                    toolParams.Add(param);
                }
                Lib.Database.SaveToolParams(toolParams);

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
        private void cbParamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbParamType.SelectedIndex == 0)
                nnParamValue.DecimalPlaces = 0;
            if (cbParamType.SelectedIndex == 1)
                nnParamValue.DecimalPlaces = 3;
        }

        private void btnAddParam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxParamName.Text))
            {
                MessageBox.Show("Param Name is invalid");
                return;
            }
            string paramName = tbxParamName.Text;
            string paramType = cbParamType.Text;
            string paramValue = ((UpDownBase)nnParamValue).Text;

            bool found = false;
            foreach(DataGridViewRow row in dvParam.Rows)
            {
                if(paramName == row.Cells[0].Value.ToString())
                {
                    row.Cells[0].Value = paramName;
                    row.Cells[1].Value = paramType;
                    row.Cells[2].Value = paramValue;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                dvParam.Rows.Add();
                dvParam.Rows[dvParam.RowCount - 1].Cells[0].Value = paramName;
                dvParam.Rows[dvParam.RowCount - 1].Cells[1].Value = paramType;
                dvParam.Rows[dvParam.RowCount - 1].Cells[2].Value = paramValue;
            }

            tbxParamName.Text = "";
        }

        private void dvParam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string paramName = dvParam.Rows[e.RowIndex].Cells[0].Value.ToString();
            string paramType = dvParam.Rows[e.RowIndex].Cells[1].Value.ToString();
            string value = dvParam.Rows[e.RowIndex].Cells[2].Value.ToString();

            tbxParamName.Text = paramName;
            if(paramType == "INT")
            {
                cbParamType.SelectedIndex = 0;
                nnParamValue.Value = int.Parse(value);
            }
            else
            {
                cbParamType.SelectedIndex = 1;
                nnParamValue.Value = decimal.Parse(value);
            }
        }
    }
}
