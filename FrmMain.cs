using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Svg;
using System.Xml;
using EcomInspection.Lib;
using System.Threading;

namespace EcomInspection
{
    public partial class FrmMain : Form
    {
        #region Fields
        private Stopwatch Sw = new Stopwatch();
        private Insight IS130 { get; set; }
        private System.Windows.Forms.Timer ScanISTimer { get; set; }
        private int _oKCount = 0;
        private int _nGcount = 0;
        private int _totalCount = 0;
        #endregion
        #region Properties
        public int OKCount
        {
            get
            {
                return _oKCount;
            }

            set
            {
                _oKCount = value;
            }
        }
        public int NGCount
        {
            get
            {
                return _nGcount;
            }

            set
            {
                _nGcount = value;
                Graphic_SetCounters();
            }
        }
        public int TotalCount
        {
            get
            {
                return _totalCount;
            }

            set
            {
                _totalCount = value;
                if (value == 0)
                {
                    OKCount = 0;
                    NGCount = 0;
                }
            }
        }
        public static bool MustUpdate = false;
        public static bool Loggedin = false;
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        #region User Mothods
        public void LoadParams()
        {
            bool result = LoadAppParams();
            if(IS130 == null||!result)
            {
                return;
            }
            LoadToolParams();
            if (IS130 != null) ScanISTimer.Start();
        }
        public bool LoadAppParams()
        {
            Lib.Database.AppParams _params = Lib.Database.LoadParams();
            if (_params != null)
            {
                try
                {
                    IS130 = new Insight(_params.Ftp_Address, _params.Ftp_User, _params.Ftp_Password, _params.Ftp_Folder, _params.Ns_Address, _params.Ns_User, _params.Ns_Password);
                    IS130.NS.ConnectInsight();
                    IS130.Triggered += IS130_Triggered;
                    IS130.Connected += IS130_Connected;
                    IS130.Disconnected += IS130_Disconnected;
                    IS130.Onlined += IS130_Onlined;
                    IS130.Offlined += IS130_Offlined;
                    ScanISTimer = new System.Windows.Forms.Timer();
                    ScanISTimer.Interval = 200;
                    ScanISTimer.Tick += ScanISTimer_Tick;
                    btnTurnOnline.Enabled = true;
                    btnTryConnect.Visible = false;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    btnTryConnect.Visible = true;
                    IS130 = null;
                    return false;
                }
            }
            return false;
        }
        public void LoadToolParams()
        {
            List<Lib.Database.ToolParams> toolParams = Lib.Database.LoadToolParams();
            if(toolParams.Count == 0) return;
            try
            {
                foreach(Lib.Database.ToolParams toolParam in toolParams)
                {
                    if(toolParam.ParamType == "INT")
                    {
                        IS130.NS.SetInt(toolParam.ParamName,int.Parse(toolParam.ParamValue));
                    }
                    else
                    {
                        IS130.NS.SetFloat(toolParam.ParamName, double.Parse(toolParam.ParamValue));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnTryConnect.Visible = true;
                IS130 = null;
            }
        }
        public void ShowImage()
        {
            try
            {
                this.Display.Invoke(new Action(() => { Display.BackgroundImage = IS130.FTPServer.GetImage(); Display.BackColor = Color.Gainsboro; }));
            }
            catch (Exception ex)
            {
                this.Display.Invoke(new Action(() => { Display.BackgroundImage = null; Display.BackColor = Color.Red; }));
            }
                
        }
        public void Graphic_TurnOnlineLed(bool isonline)
        {
            led_OnlineStatus.Invoke(new Action(() =>
            {
                if (!isonline)
                {
                    this.led_OnlineStatus.BackgroundImage = EcomInspection.Properties.Resources.red_dot.ToBitmap();
                }
                else
                {
                    this.led_OnlineStatus.BackgroundImage = EcomInspection.Properties.Resources.green_dot.ToBitmap();
                }
            }));
        }
        public void Graphic_TurnConnectLed(bool isonline)
        {
            led_OnlineStatus.Invoke(new Action(() =>
            {
                if (!isonline)
                {
                    this.led_Connection.BackgroundImage = EcomInspection.Properties.Resources.red_dot.ToBitmap();
                }
                else
                {
                    this.led_Connection.BackgroundImage = EcomInspection.Properties.Resources.green_dot.ToBitmap();
                }
            }));
        }
        public void Graphic_SetCounters()
        {
            lbTotal.Invoke(new Action(() =>
            {
                lbTotal.Text = TotalCount.ToString();
            }));
            lbOK.Invoke(new Action(() =>
            {
                lbOK.Text = OKCount.ToString();
            }));
            lbNG.Invoke(new Action(() =>
            {
                lbNG.Text = NGCount.ToString();
            }));
            PieChart.Invoke(new Action(() =>
            {
                if(TotalCount > 0)
                {
                    PieChart.Series[0].Points[0].YValues[0] = 1.0 * OKCount;
                    PieChart.Series[0].Points[1].YValues[0] = 1.0 * NGCount;
                    double percent = Math.Round(1.0* OKCount/ TotalCount,4);
                    PieChart.Series[0].Points[0].Label = (percent * 100.0).ToString() + "%";
                }
                else
                {
                    PieChart.Series[0].Points[0].YValues[0] = 1.0;
                    PieChart.Series[0].Points[1].YValues[0] = 0;
                    PieChart.Series[0].Points[0].Label = "N/A";
                }
            }));
        }
        private void ShowMessage(string t)
        {
            string[] _t = t.Split('\n');
            foreach (string subt in _t)
            {
                if (string.IsNullOrEmpty(subt)) continue;
                string message;
                if (subt.Contains('\n'))
                    message = $"-> {DateTime.Now.ToString("mm-ss")}: " + subt;
                else
                {
                    message = $"-> {DateTime.Now.ToString("mm-ss")}: " + subt + Environment.NewLine;
                }

                //this.tbxMessage.Text += message;
            }

        }
        private void Login()
        {
            btnTurnOnline.Visible = true;
            btnSetting.Visible = true;
            btnClearCount.Enabled = true;
        }
        private void Logout()
        {
            btnTurnOnline.Visible = false;
            btnSetting.Visible = false;
            btnClearCount.Enabled = false;
        }
        #endregion
        #region User Event Handler
        private void IS130_Triggered(object sender, EventArgs e)
        {
            IS130.NSStatus = Insight.Status.Busy;
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                if (IS130.CurrentFormatString.Length < 2)
                {
                    return;
                }
                TotalCount++;
                string okresult = IS130.CurrentFormatString[1];
                if (okresult == "1")
                {
                    OKCount++;
                }
                NGCount = TotalCount - OKCount;
                Thread.Sleep(200);
                this.ShowImage();
                sw.Stop();
                lbTaktTime.Text = $"Process Time: {sw.ElapsedMilliseconds} ms";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IS130.NSStatus = Insight.Status.Free;
            }
        }
        private void IS130_Offlined(object sender, EventArgs e)
        {
            Graphic_TurnOnlineLed(false);
        }
        private void IS130_Onlined(object sender, EventArgs e)
        {
            Graphic_TurnOnlineLed(true);
        }
        private void IS130_Disconnected(object sender, EventArgs e)
        {
            Graphic_TurnConnectLed(false);
        }
        private void IS130_Connected(object sender, EventArgs e)
        {
            Graphic_TurnConnectLed(true);
        }
        private void ScanISTimer_Tick(object sender, EventArgs e)
        {
            if(IS130 == null || IS130.NSStatus == Insight.Status.Busy)
            {
                return;
            }
            try
            {
                ScanISTimer.Stop();
                IS130.CheckISStatus();
                ScanISTimer.Start();
            }
            catch (Exception ex)
            {
                IS130_Offlined(null, EventArgs.Empty);
                IS130_Disconnected(null, EventArgs.Empty);
                MessageBox.Show(ex.Message);
                btnTryConnect.Visible = true;
                IS130 = null;
            }
            
        }
        #endregion
        #region Form Event
        private void FrmMain_Load(object sender, EventArgs e)
        {
            PieChart.Series[0].Points[0].LegendText = "OK";
            PieChart.Series[0].Points[1].LegendText = "NG";
            try
            {
                Database.Counter _counter = Database.LoadCounter();
                if(_counter == null)
                {
                    TotalCount = 0;
                }
                else
                {
                    TotalCount = _counter.Total;
                    OKCount = _counter.OK;
                    NGCount = TotalCount - OKCount;
                }
            }
            catch(Exception ex)
            {
                TotalCount = 0;
                MessageBox.Show($"Can not load counter: {ex.Message}");
            }
            Logout();
            btnTryConnect.Visible = false;
            btnTurnOnline.Enabled = false;
            LoadParams();
        }
        private void btnTurnOnline_Click(object sender, EventArgs e)
        {
            if (IS130.ISOnlineStatus == Insight.Status.Online)
            {
                if (MessageBox.Show("Are you sure want to go Offine?", "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                IS130.NS.TurnISOffline();
            }
            else
            {
                if (MessageBox.Show("Are you sure want to go Online?", "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                IS130.NS.TurnISOnline();
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit?","Warning",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    Database.Counter _counter = new Database.Counter
                    {
                        Total = TotalCount,
                        OK = OKCount
                    };
                    Database.SaveCounter(_counter);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Can not save counter: {ex.Message}");
                }
                this.Close();
            }
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            if(IS130 != null)
            {
                if (IS130.ISOnlineStatus == Insight.Status.Online)
                {
                    MessageBox.Show("Turn Offline Before Setting!");
                    return;
                }
            }
            FrmSetting Settingpage = new FrmSetting();
            Settingpage.ShowDialog();
            if (MustUpdate)
            {
                btnTurnOnline.Enabled = false;
                LoadParams();
                MustUpdate = false;
            }
        }
        private void btnTryConnect_Click(object sender, EventArgs e)
        {
            btnTurnOnline.Enabled = false;
            LoadParams();
        }
        private void btnLoggin_Click(object sender, EventArgs e)
        {
            if(this.btnTurnOnline.Visible == true)
            {
                if (MessageBox.Show("Are you sure want to Logout?", "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                Logout();
            }
            else
            {
                try
                {
                    FrmLogin _loginpage = new FrmLogin();
                    _loginpage.ShowDialog();
                    if (Loggedin)
                    {
                        Login();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Loggedin = false;
                }
            }
            
        }
        private void btnClearCount_Click(object sender, EventArgs e)
        {
            TotalCount = 0;
        }
        #endregion

    }
}
