using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;

namespace TempleManagement.files
{
    public static class FileToDatabase
    {
        /// <summary>
        /// Upload file to FILE_MGR as image
        /// </summary>
        /// <param name="fileName">Full Path</param>
        /// <returns>File ID, if failed return 0</returns>
        public static int Upload(String fileName)
        {
            if (!File.Exists(fileName)) {
                return 0;
            }
            FileStream fs = new FileStream(fileName,FileMode.Open,FileAccess.Read);
            Byte[] bufferByte = new Byte[fs.Length];
            fs.Read(bufferByte, 0, (int)fs.Length);
            fs.Close();
            fs = null;
            fileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);
            String sql = "INSERT INTO [FILE_MGR]([ORIGIN_FILENAME],[FILE_DATA],[UPLOAD_TIME] "+
                        ",[DOWNLOAD_CNT],[UPLOAD_USER_ID])VALUES (@ORIGIN_FILENAME "+
                        ",@FILE_DATA,@UPLOAD_TIME,@DOWNLOAD_CNT,@UPLOAD_USER_ID) SELECT IDENT_CURRENT('FILE_MGR')";
            using (pub.DataBase db = new pub.DataBase())
            {
                db.AddParameter("ORIGIN_FILENAME", fileName);
                db.AddParameter("FILE_DATA", bufferByte);
                db.AddParameter("UPLOAD_TIME", DateTime.Now);
                db.AddParameter("DOWNLOAD_CNT", 0);
                db.AddParameter("UPLOAD_USER_ID", pub.UserInfo.ID);
                DataTable dt=db.ExecuteDataTable(sql);
                if (dt.Rows.Count == 1) return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            bufferByte = null;
            return 0;
        }
        
        /// <summary>
        /// Download specified file to fileName
        /// </summary>
        /// <param name="fileName">Full path</param>
        public static void Download(String fileName,String FileId)
        {
            using (pub.DataBase db = new pub.DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT FILE_DATA FROM FILE_MGR WHERE ID="+FileId);
                if (dt.Rows.Count != 1) return;
                Byte[] bufferByte = (Byte[])dt.Rows[0][0];
                FileStream fs;
                FileInfo fi = new FileInfo(fileName);
                fs = fi.OpenWrite();
                
                fs.Write(bufferByte, 0, bufferByte.Length);
                fs.Close();
            }
        }

        public static void Preview(String FileId)
        {
            String fileName = Environment.GetEnvironmentVariable("TEMP");
            if (!fileName.EndsWith("\\"))
            {
                fileName += "\\";
            }
            Random rnd = new Random();

            fileName += rnd.Next() + "_" + GetFileName(FileId);
            Download(fileName, FileId);
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static String GetFileName(String FileId)
        {
            using (pub.DataBase db = new pub.DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT ORIGIN_FILENAME FROM FILE_MGR WHERE ID=" + FileId);
                if (dt.Rows.Count != 1) return "";
                return dt.Rows[0][0].ToString();
            }
        }

        public static void Download(String FileId)
        {
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.FileName = GetFileName(FileId);
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Download(sfd.FileName, FileId);
            }
        }

        public static Image GetImage(String FileId)
        {
            using (pub.DataBase db = new pub.DataBase())
            {
                Image retImg=null;
                DataTable dt = db.ExecuteDataTable("SELECT FILE_DATA FROM FILE_MGR WHERE ID=" + FileId);
                if (dt.Rows.Count != 1) return retImg;
                try
                {
                    MemoryStream ms = new MemoryStream((byte[])dt.Rows[0][0]);
                    retImg = Image.FromStream(ms);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                return retImg;
            }
        }
    }
}
