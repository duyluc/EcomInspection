using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using System.IO;

namespace EcomInspection.Lib
{
    public static class Database
    {
        public static string _databaseFolder = "Database";
        public static string DatabaseFolder
        {
            get
            {
                if (!Directory.Exists(_databaseFolder))
                {
                    Directory.CreateDirectory(_databaseFolder);
                }
                return _databaseFolder;
            }
            set
            {
                DatabaseFolder = value;
            }
        }
        #region Save App Setting
        public static string SettingPath = Path.Combine(DatabaseFolder, "Setting.db");
        public class AppSetting
        {
            public int Id { get; set; }
            public string SettingName { get; set; }
            public bool IsEnabled { get; set; }
        }
        #endregion
        #region Save Result Records
        public class ResultRecords
        {
            public int Id { get; set; }
            public string Trigger_Stamp { get; set; }
            public bool Result { get; set; }
        }
        
        static public void SaveRecord(ResultRecords record)
        {
            using(LiteDatabase db = new LiteDatabase(Path.Combine(DatabaseFolder, $"Record_{DateTime.Now.ToString("yyyy-MM-dd")}.db")))
            {
                var col = db.GetCollection<ResultRecords>();
                col.Insert(record);
            }
        }

        /// <summary>
        /// Get All record of a day
        /// </summary>
        /// <param name="date"> Format folow yyyy-MM-dd</param>
        /// <returns></returns>
        static public List<ResultRecords> GetRecordByDate(string date)
        {
            List<ResultRecords> records = new List<ResultRecords>();
            using(LiteDatabase db = new LiteDatabase(Path.Combine(DatabaseFolder, $"Record_{date}.db")))
            {
                var col = db.GetCollection<ResultRecords>();
                records = col.FindAll().ToList();
            }
            return records;
        }

        #region Tool Params
        public static string ParamsPath = Path.Combine(DatabaseFolder, "Params.db");
        public class ToolParams
        {
            public int Id { get; set; }
            public string ParamName { get; set; }
            public string ParamType { get; set; }
            public string ParamValue { get; set; }
        }
        public static void SaveToolParams(List<ToolParams> toolparams)
        {
            using (LiteDatabase db = new LiteDatabase(ParamsPath))
            {
                var col = db.GetCollection<ToolParams>();
                col.DeleteAll();
                foreach(ToolParams toolparam in toolparams)
                {
                    col.Insert(toolparam);
                }
            }
        }
        #endregion
        public static List<ToolParams> LoadToolParams()
        {
            List<ToolParams> toolparams = new List<ToolParams>();
            try
            {
                using (LiteDatabase db = new LiteDatabase(ParamsPath))
                {
                    var col = db.GetCollection<ToolParams>();
                    toolparams = col.FindAll().ToList();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
            return toolparams;
        }
        #endregion
        #region COUNTER
        public static string CounterPath = Path.Combine(DatabaseFolder, "Counter.db");
        public class Counter
        {
            public int Id { get; set; }
            public int Total { get; set; }
            public int OK { get; set; }
        }
        public static void SaveCounter(Counter _counter)
        {
            using (LiteDatabase db = new LiteDatabase(CounterPath))
            {
                var col = db.GetCollection<Counter>();
                col.DeleteAll();
                col.Insert(_counter);
            }
        }
        public static Counter LoadCounter()
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(CounterPath))
                {
                    var col = db.GetCollection<Counter>();
                    List<Counter> _counter = col.FindAll().ToList();
                    if (_counter.Count > 0)
                    {
                        return _counter[0];
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }
        #endregion
        #region AppParams
        public class AppParams
        {
            public int Id { get; set; }
            public string Ftp_Address { get; set; }
            public string Ftp_User { get; set; }
            public string Ftp_Password { get; set; }
            public string Ftp_Folder { get; set; }
            public string Ns_Address { get; set; }
            public string Ns_Password { get; set; }
            public string Ns_User { get; set; }
        }

        

        public static string AppParamPath = Path.Combine(DatabaseFolder, "AppParams.db");

        public static void SaveAppParams(AppParams _params)
        {
            using (LiteDatabase db = new LiteDatabase(AppParamPath))
            {
                var col = db.GetCollection<AppParams>();
                col.DeleteAll();
                col.Insert(_params);
            }
        }
        public static AppParams LoadParams()
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(AppParamPath))
                {
                    var col = db.GetCollection<AppParams>();
                    List<AppParams> _params = col.FindAll().ToList();
                    if(_params.Count > 0)
                    {
                        return _params[0];
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }
        #endregion

    }
}
