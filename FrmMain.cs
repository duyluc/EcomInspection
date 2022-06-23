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
        private TcpClient Client;
        private NetworkStream Stream;
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
                if (_totalCount == 0)
                {
                    _oKCount = 0;
                    _nGcount = 0;
                }
            }
        }
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        #region User Mothods
        public void ShowImage()
        {
            this.Display.Invoke(new Action(() => { Display.BackgroundImage = IS130.FTPServer.GetImage(); }));
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

                this.tbxMessage.Text += message;
            }

        }
        #endregion
        #region User Event Handler
        private void IS130_Triggered(object sender, EventArgs e)
        {
            if (IS130.NSStatus == Insight.Status.Busy) return;
            IS130.NSStatus = Insight.Status.Busy;
            try
            {
                if (IS130.CurrentFormatString.Length != 4)
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
                Thread.Sleep(150);
                this.ShowImage();
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
            IS130.CheckISStatus();
        }
        #endregion
        #region Form Event
        private void FrmMain_Load(object sender, EventArgs e)
        {
            IS130 = new Insight("192.168.1.10", "FTP-User", "delay10ktcyx", @"C:\Users\duong\OneDrive\Máy tính\Insight_localremote", "192.168.1.20", "admin", "");
            IS130.NS.ConnectInsight();
            IS130.Triggered += IS130_Triggered;
            IS130.Connected += IS130_Connected;
            IS130.Disconnected += IS130_Disconnected;
            IS130.Onlined += IS130_Onlined;
            IS130.Offlined += IS130_Offlined;
            ScanISTimer = new System.Windows.Forms.Timer();
            ScanISTimer.Interval = 200;
            ScanISTimer.Start();
            ScanISTimer.Tick += ScanISTimer_Tick;
        }
        private void btnTurnOnline_Click(object sender, EventArgs e)
        {
            //if (IS130.ISOnlineStatus == Insight.Status.Online)
            //{
            //    Thread _ = new Thread(() =>
            //    {
            //        if (IS130.NSStatus == Insight.Status.Busy) Thread.Sleep(150);
            //        while (IS130.NSStatus == Insight.Status.Busy)
            //        {
            //            Thread.Sleep(1);
            //        }
            //        IS130.NS.TurnISOffline();
            //    });
            //    _.Start();
            //}
            if (IS130.ISOnlineStatus == Insight.Status.Online)
            {
                IS130.NS.TurnISOffline();
            }
            else
            {
                IS130.NS.TurnISOnline();
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxAddress.Text)) return;
            if (this.Client != null)
            {
                if (this.Client.Connected) this.Client.Close();
                else
                {
                    this.Client.Dispose();
                }
            }
            this.Client = new TcpClient();
            string ipstring = tbxAddress.Text.Split(':')[0];
            int port = int.Parse(tbxAddress.Text.Split(':')[1]);

            //Query to Connect Server
            this.Client.Connect(ipstring, port);
            if (!this.Client.Connected)
            {
                MessageBox.Show("Connect Fault!");
                return;
            }

            //show message
            ShowMessage($"Open {ipstring}:{port}");

            this.Stream = this.Client.GetStream();
            byte[] buffer = new byte[1024];
            int readed = Stream.Read(buffer, 0, buffer.Length);

            byte[] respond_data = new byte[readed];
            Array.Copy(buffer, 0, respond_data, 0, readed);

            string respond_string = Encoding.ASCII.GetString(respond_data);
            if (!respond_string.Contains("Welcome"))
            {
                MessageBox.Show("Is not an Insight Server!");
                return;
            }
            if (!respond_string.Contains("User"))
            {
                ShowMessage(respond_string);

                buffer = new byte[1024];
                readed = Stream.Read(buffer, 0, buffer.Length);

                respond_data = new byte[readed];
                Array.Copy(buffer, 0, respond_data, 0, readed);

                respond_string = Encoding.ASCII.GetString(respond_data);
                if (!respond_string.Contains("User"))
                {
                    MessageBox.Show("Something's Wrong!");
                    MessageBox.Show(respond_string);
                    return;
                }
            }
            //Query to send Account name
            Stream.Write(Encoding.ASCII.GetBytes($"admin\r\n"), 0, 7);

            //show message
            ShowMessage(respond_string + "admin");
            //Query to send Account name
            buffer = new byte[1024];
            readed = Stream.Read(buffer, 0, buffer.Length);

            respond_data = new byte[readed];
            Array.Copy(buffer, 0, respond_data, 0, readed);

            respond_string = Encoding.ASCII.GetString(respond_data);
            if (!respond_string.Contains("Password"))
            {
                MessageBox.Show("Something's Wrong!");
                MessageBox.Show(respond_string);
                return;
            }

            //Show message
            ShowMessage(respond_string);

            byte[] endline = Encoding.ASCII.GetBytes("\r\n");
            Stream.Write(endline, 0, endline.Length);
            //------------------------
            buffer = new byte[1024];
            readed = Stream.Read(buffer, 0, buffer.Length);

            respond_data = new byte[readed];
            Array.Copy(buffer, 0, respond_data, 0, readed);

            respond_string = Encoding.ASCII.GetString(respond_data);
            ShowMessage(respond_string);

        }
        private void btnOnline_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMessage("Cmd: " + "SO1");
                //this.SendCommand("SO1");
                //string respond = ReadRespond();
                //ShowMessage("Respond Cmd: " + respond);
            }
            catch (Exception ex)
            {
                ShowMessage("Cmd False");
                ShowMessage(ex.Message);
            }
        }
        private void btnOffline_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMessage("Cmd: " + "SO0");
                //this.SendCommand("SO0");
                //string respond = ReadRespond();
                //ShowMessage("Respond Cmd: " + respond);
            }
            catch (Exception ex)
            {
                ShowMessage("Cmd False");
                ShowMessage(ex.Message);
            }
        }
        private void btnTrigger_Click(object sender, EventArgs e)
        {
            //Image image = GetImage();
            //if (image == null) return;
            //this.Display.BackgroundImage = image;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.tbxMessage.Text = "";
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit?") == DialogResult.OK)
            {
                this.Close();
            }
        }

        #endregion

    }
}
