using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace CWCS_OL.tables.filemgr
{
    public partial class file : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType == "POST")
            {
                try
                {
                    if (!this.GetCurrentUser().hasPermission("fmp"))
                    {
                        throw new InvalidOperationException("没有上传文件的权限");
                    }

                    byte[] bytFile = new Byte[Request.Files["DocFile"].InputStream.Length];
                    Request.Files["DocFile"].InputStream.Read(bytFile, 0, (int)Request.Files["DocFile"].InputStream.Length);

                    String strFileName = Request.Files["DocFile"].FileName;
                    

                    Response.ContentType = "text/html";
                    
                    if (Session["filemgr_editid"] == null)
                    {
                        List<byte[]> arrNewFile;
                        List<String> arrNewFileName;
                        if (Session["filemgr_new"] == null)
                        {
                            arrNewFile = new List<byte[]>();
                            Session["filemgr_new"] = arrNewFile;
                            arrNewFileName = new List<String>();
                            Session["filemgr_newfn"] = arrNewFileName;
                        }
                        else
                        {
                            arrNewFile = (List<byte[]>)Session["filemgr_new"];
                            arrNewFileName = (List<String>)Session["filemgr_newfn"];
                        }

                        arrNewFile.Add(bytFile);
                        arrNewFileName.Add(strFileName);
                        Response.Write("<script>parent.parent.uploadf('" + strFileName + "',false);</script>");
                    }
                    else
                    {
                        using (DataBase db = new DataBase())
                        {
                            db.AddParameter("MgrId", Session["filemgr_editid"].ToString());
                            db.AddParameter("FileName", strFileName);
                            db.AddParameter("Data", bytFile);
                            int iRc = db.ExecuteNonQuery("INSERT INTO [File]([MgrId],[FileName],[Data]) "+
                                "VALUES(@MgrId,@FileName,@Data)");
                            if (iRc == 1)
                            {
                                Response.Write("<script>parent.parent.uploadf('" + strFileName + "',true);</script>");
                            }
                            else
                            {
                                throw new Exception("数据库错误");
                            }
                        }
                    }

                }
                catch (Exception except)
                {
                    Response.ContentType = "text/html";
                    Response.Write("<script>alert('文件上传失败: " + except.Message + "');</script>");
                    Response.End();
                }
            }
            else
            {
                if (Request.Params["id"] == null)
                {
                    Response.End();
                }
                if (!this.GetCurrentUser().hasPermission("fml"))
                {
                    Response.Write("<script>alert('没有下载权限');window.history.back();</script>");
                    Response.End();
                }

                try
                {
                    using(DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("SELECT [FileName],[Data] FROM [File] WHERE [ID]=@ID");
                        if (dt.Rows.Count != 1)
                        {
                            Response.End();
                        }
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(dt.Rows[0][0].ToString(), System.Text.Encoding.UTF8) + ";");
                        Response.BinaryWrite((byte[])dt.Rows[0][1]);
                    }

                    Response.End();
                }
                catch
                {
                }
            }
        }
    }
}