using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcomInspection.Lib
{
    public  class FTP
    {
        public string FtpAddress { get; set; }
        public string FtpUser { get; set; }
        public string FtpPassword { get; set; }
        public string FtpLocalFolder { get; set; }
        public FTP()
        {

        }
        public FTP(string ftpAddress, string ftpUser, string ftpPassword, string ftpLocalFolder)
        {
            FtpAddress = ftpAddress;
            FtpUser = ftpUser;
            FtpPassword = ftpPassword;
            FtpLocalFolder = ftpLocalFolder;
        }
        public Bitmap GetImage()
        {
            string TFP_path = "FTP://" + FtpAddress;
            List<string> files = GetAllFtpFiles(TFP_path, FtpUser,FtpPassword);
            Bitmap overlayImage = null;
            foreach (string file in files)
            {
                if (file.Contains("svg"))
                {
                    overlayImage = ConvertSVG2Bitmapp(Path.Combine(FtpLocalFolder, file));
                }
            }

            if (overlayImage == null)
                return null;

            foreach (string file in files)
            {
                DeleteFTPFile(TFP_path + "/" + file, FtpUser, FtpPassword);
            }
            return overlayImage;
        }
        public byte[] GetImgByte(string ftpFilePath, string Username, string Password)
        {
            WebClient ftpClient = new WebClient();
            ftpClient.Credentials = new NetworkCredential(Username, Password);
            byte[] imageByte = ftpClient.DownloadData(ftpFilePath);
            return imageByte;
        }
        public Bitmap ConvertSVG2Bitmapp(string svgpath)
        {
            SvgDocument svgDocument = Svg.SvgDocument.Open(svgpath);
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;
            Bitmap bmp = svgDocument.Draw();
            svgDocument = null;
            GC.Collect();
            return bmp;
        }
        public bool CreateFolder(string host, string UserId, string Password)
        {
            string path = "/Index";
            bool IsCreated = true;
            try
            {
                WebRequest request = WebRequest.Create(host + path);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(UserId, Password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                IsCreated = false;
            }
            return IsCreated;
        }
        public List<string> GetAllFtpFiles(string ParentFolderpath, string UserId, string Password)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ParentFolderpath);
                ftpRequest.Credentials = new NetworkCredential(UserId, Password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var lineArr = line.Split('/');
                    line = lineArr[lineArr.Count() - 1];
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();

                return directories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteFTPFile(string FilePath, string UserId, string Password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FilePath);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new System.Net.NetworkCredential(UserId, Password); ;
            request.GetResponse().Close();
        }
    }
}
