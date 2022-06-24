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
                return null;
            }
        }
        #endregion

    }
}
