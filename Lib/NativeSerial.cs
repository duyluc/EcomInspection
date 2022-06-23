using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcomInspection.Lib
{
    public class NativeSerial
    {
        #region Properties
        public enum CommandName
        {
            TurnOnline,
            TurnOffline,
            CheckISStatus,
        }
        public string ISAddress { get; set; }
        public string ISUser { get; set; }
        public string ISPassword { get; set; }
        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }
        Dictionary<CommandName, string> CommandString = new Dictionary<CommandName, string>
        {
            {CommandName.TurnOnline,"SO1"},
            {CommandName.TurnOffline,"SO0" },
            {CommandName.CheckISStatus,"GO"},
        };
        #endregion
        #region Event
        public event EventHandler Connected;
        
        protected void OnConnected()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public NativeSerial()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iSAddress"></param>
        /// <param name="iSUser"></param>
        /// <param name="iSPassword"></param>
        public NativeSerial(string iSAddress, string iSUser, string iSPassword)
        {
            ISAddress = iSAddress;
            ISUser = iSUser;
            ISPassword = iSPassword;
        }
        #region Method
        public void ConnectInsight()
        {
            int errorCounter = 0;
            while (true)
            {
                try
                {
                    bool iscomplete = false;
                    int count = 0;
                    Thread _t = new Thread(() =>
                    {
                        _connectInsight(ISAddress, ISUser, ISPassword);
                        iscomplete = true;
                    });
                    _t.Start();
                    while(count < 100 && !iscomplete)
                    {
                        Thread.Sleep(1);
                    }
                    if (_t.IsAlive)
                    {
                        _t.Abort();
                    }
                    if (!iscomplete)
                    {
                        throw new Exception("Connect Faulted!");
                    }
                    OnConnected();
                    break;
                }
                catch
                {
                    errorCounter++;
                    if(errorCounter == 2)
                    {
                        throw new Exception("Connect Faulted!");
                    }
                }
            }
            
        }
        public bool TurnISOnline()
        {
            if (!_iSCheckConnect())
            {
                ConnectInsight();
            }
            _sendCommand(CommandString[CommandName.TurnOnline]);
            string respond = _readLineRespond();
            if (respond.Contains("1"))
                return true;
            return false;
        }
        public bool TurnISOffline()
        {
            if (!_iSCheckConnect())
            {
                ConnectInsight();
            }
            _sendCommand(CommandString[CommandName.TurnOffline]);
            string respond = _readLineRespond();
            if (respond.Contains("1"))
                return true;
            return false;
        }
        public bool GetISStatus()
        {
            if (!_iSCheckConnect())
            {
                ConnectInsight();
            }
            _sendCommand(CommandString[CommandName.CheckISStatus]);
            string respond = _readLineRespond();
            if (respond.Contains("1"))
                return true;
            return false;
        }
        public string[] GetValue()
        {
            if (!_iSCheckConnect())
            {
                ConnectInsight();
            }
            string command = "GVJob.FormatString";
            _sendCommand(command);
            string[] respond = _readRespond();
            if(respond.Length < 2)
            {
                throw new Exception("Read Value Faulted");
            }
            if (!respond[0].Contains("1"))
            {
                throw new Exception("Read Value Faulted");
            }
            string valuesChain = respond[1];
            string[] s_value = valuesChain.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return s_value;

        }
        private void _connectInsight(string iSAddress, string iSUser, string iSPassword)
        {
            if (string.IsNullOrEmpty(iSAddress)) return;
            if (this.Client != null)
            {
                if (this.Client.Connected) this.Client.Close();
                else
                {
                    this.Client.Dispose();
                }
            }
            this.Client = new TcpClient();
            string ipstring = iSAddress.Split(':')[0];
            //int port = int.Parse(iSAddress.Split(':')[1]);
            int port = 23;

            //Connect to Server
            this.Client.Connect(ipstring, port);
            Stream = this.Client.GetStream();
            //string respond_string = _readLineRespond();
            string[] respond_string = _readRespond();
            if(respond_string.Length == 1)
            {
                if (!respond_string[0].Contains("Welcome"))
                {
                    throw new ArgumentException("Insight Address is wrong!");
                }
                respond_string = _readRespond();
                if (respond_string.Length == 1)
                {
                    if (!respond_string[0].Contains("User"))
                    {
                        throw new ArgumentException("Insight Address is wrong!");
                    }
                }
                else
                {
                    throw new ArgumentException("Insight Address is wrong!");
                }
            }
            else if(respond_string.Length == 2)
            {
                if (!respond_string[0].Contains("Welcome"))
                {
                    throw new ArgumentException("Insight Address is wrong!");
                }
                if (!respond_string[1].Contains("User"))
                {
                    throw new ArgumentException("Insight Address is wrong!");
                }
            }
            else
            {
                throw new ArgumentException("Insight Address is wrong!");
            }
            //Send Account name
            _sendCommand(iSUser);
            //respond_string = _readLineRespond();
            respond_string = _readRespond();
            if (!respond_string[0].Contains("Password"))
            {
                throw new ArgumentException("User is wrong!");
            }

            //Send Password
            _sendCommand(iSPassword);
            //respond_string = _readLineRespond();
            respond_string = _readRespond();
            if (!respond_string[0].Contains("Logged"))
            {
                throw new ArgumentException("Password is wrong");
            }
        }
        private void _sendCommand(string cmd)
        {
            Stream = this.Client.GetStream();
            if (this.Client == null)
            {
                _connectInsight(ISAddress, ISUser, ISPassword);
            }
            else if (!this.Client.Connected)
            {
                _connectInsight(ISAddress, ISUser, ISPassword);
            }

            if (this.Client == null) throw new Exception("Client was Disconnected");
            if (!this.Client.Connected) throw new Exception("Client was Disconnected");
            if (this.Stream == null) throw new Exception("Client was Disconnected");
            byte[] bcmd = Encoding.ASCII.GetBytes(cmd + "\r\n");
            Stream.Write(bcmd, 0, bcmd.Length);
        }
        private string[] _readRespond()
        {
            byte[] buffer = new byte[1024];
            bool iscomplete = false;
            int count = 0;
            string[] s_respond = new string[1] { "-1" }; ;
            Thread _t = new Thread(() =>
            {
                int readed = Stream.Read(buffer, 0, buffer.Length);
                byte[] respond_data = new byte[readed];
                Array.Copy(buffer, 0, respond_data, 0, readed);
                string respond = Encoding.ASCII.GetString(respond_data);
                s_respond = respond.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                iscomplete = true;
            });
            _t.Start();
            while (count < 20 && !iscomplete)
            {
                Thread.Sleep(1);
                count++;
            }
            if (_t.IsAlive)
            {
                _t.Abort();
            }
            return s_respond;
        }
        private string _readLineRespond()
        {
            string respond = "";
            bool iscomplete = false;
            int count = 0;
            Thread _t = new Thread(() =>
            {
                StreamReader reader = new StreamReader(Stream);
                respond = reader.ReadLine();
                iscomplete = true;
            });
            _t.Start();
            while (count < 10 && !iscomplete)
            {
                Thread.Sleep(1);
                count++;
            }
            if (_t.IsAlive)
            {
                _t.Abort();
            }
            return respond;
        }
        private bool _iSCheckConnect()
        {
            if(this.Client == null)
            {
                return false;
            }
            if (!this.Client.Connected)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
