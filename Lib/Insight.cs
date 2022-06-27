using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomInspection.Lib
{
    public class Insight
    {

        public enum Status
        {
            Connected,
            Disconnected,
            Free,
            Online,
            Offline,
            Busy
        }

        #region fields
        private Status _iSConnection = Status.Disconnected;
        private Status _iSOnlineStatus = Status.Offline;
        private string _lastTriggerTime = "";
        #endregion

        #region IS's Event
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler Onlined;
        public event EventHandler Offlined;
        public event EventHandler Triggered;

        private void OnConnected()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }
        private void OnDisconnected()
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }
        private void OnOnlined()
        {
            Onlined?.Invoke(this, EventArgs.Empty);
        }
        private void OnOfflined()
        {
            Offlined?.Invoke(this, EventArgs.Empty);
        }
        private void OnTriggered()
        {
            Triggered?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Properties
        public FTP FTPServer { get; set; }
        public NativeSerial NS { get; set; }
        public Status ISConnection
        {
            get
            {
                return _iSConnection;
            }

            set
            {
                if (_iSConnection == value) return;
                _iSConnection = value;
                if (_iSConnection == Status.Connected)
                {
                    OnConnected();
                }
                else
                {
                    OnDisconnected();
                }

            }
        }
        public Status ISOnlineStatus
        {
            get
            {
                return _iSOnlineStatus;
            }

            set
            {
                if (_iSOnlineStatus == value) return;
                _iSOnlineStatus = value;
                if (_iSOnlineStatus == Status.Online)
                {
                    OnOnlined();
                }
                else
                {
                    OnOfflined();
                }

            }
        }
        public Status NSStatus { get; set; } = Status.Free;
        public string LastTriggerTime
        {
            get
            {
                return _lastTriggerTime;
            }

            set
            {
                if(_lastTriggerTime == value) return;
                _lastTriggerTime = value;
                OnTriggered();
            }
        }
        public string CurrentJob { get; set; } = "";
        public string[] CurrentFormatString { get; set; }
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public Insight(string ftpAddress, string ftpUser, string ftppassWord,string ftpLocalFolder,string iSAddress, string iSUser, string iSPassword)
        {
            FTPServer = new FTP(ftpAddress,ftpUser,ftppassWord,ftpLocalFolder);
            NS = new NativeSerial(iSAddress, iSUser, iSPassword);
            try
            {
                CurrentFormatString = NS.GetValue();
                if (CurrentFormatString.Length < 1)
                {
                    throw new ArgumentNullException("Trigger Time was null");
                }
                _lastTriggerTime = CurrentFormatString[0];
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
        }

        #region Method
        public void CheckISStatus()
        {
            if (NS.Client == null)
            {
                ISConnection = Status.Disconnected;
            }
            else if (!NS.Client.Connected)
            {
                ISConnection = Status.Disconnected;
            }
            else
            {
                ISConnection = Status.Connected;
            }

            if (NS.GetISStatus())
            {
                ISOnlineStatus = Status.Online;
            }
            else
            {
                ISOnlineStatus = Status.Offline;
            }
            
            if(ISConnection == Status.Disconnected)
            {
                return;
            }
            //Get IS FormatString
            try
            {
                CurrentFormatString = NS.GetValue();
                if(CurrentFormatString.Length < 1)
                {
                    throw new ArgumentNullException("Trigger Time was null");
                }
                LastTriggerTime = CurrentFormatString[0];
            }
            catch(Exception ex)
            {
                Log.WriteLog(ex);
            }
        }
        #endregion

    }
}
