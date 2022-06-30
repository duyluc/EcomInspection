using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EcomInspection.Lib
{
    public static class Log
    {
        private static string _folderPath = "Log";
        public static string FolderPath
        {
            get
            {
                if (!Directory.Exists(_folderPath))
                {
                    Directory.CreateDirectory(_folderPath);
                }
                return _folderPath;
            }
            set
            {
                _folderPath = value;
            }
        }
        public static void WriteLog(string message, bool show = false)
        {
            string logstring = $"<{DateTime.Now.ToString("ss-mm-hh")}> {message}";
            string filepath = Path.Combine(FolderPath, $"Log_{DateTime.Now.ToString("dd-MM-yyyy")}.txt");
            if (File.Exists(filepath))
            {
                using (StreamWriter write = File.AppendText(filepath))
                {
                    write.WriteLine(logstring);
                }
            }
            else
            {
                using (StreamWriter write = File.CreateText(filepath))
                {
                    write.WriteLine(logstring);
                }
            }
            if (show)
            {
                System.Windows.Forms.MessageBox.Show(logstring);
            }
        }
        public static void WriteLog(Exception ex, bool show = false)
        {
            string logstring = $"<{DateTime.Now.ToString("ss-mm-hh")}> {ex.Source} -- {ex.Message}";
            string filepath = Path.Combine(FolderPath, $"Log_{DateTime.Now.ToString("dd-MM-yyyy")}.txt");
            if (File.Exists(filepath))
            {
                using (StreamWriter write = File.AppendText(filepath))
                {
                    write.WriteLine(logstring);
                }
            }
            else
            {
                using (StreamWriter write = File.CreateText(filepath))
                {
                    write.WriteLine(logstring);
                }
            }
            if (show)
            {
                System.Windows.Forms.MessageBox.Show(logstring);
            }
        }
    }
}
