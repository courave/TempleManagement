using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.filemgr
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["filemgr_editid"] = null;
                if (Session["filemgr_new"] != null)
                {
                    List<byte[]> arrNewFile = (List<byte[]>)Session["filemgr_new"];
                    if (arrNewFile != null)
                        arrNewFile.Clear();
                    Session["filemgr_new"] = null;
                }
                Session["filemgr_newfn"] = null;
                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("fmc"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                    TextBox_FileNo.Text = Util.GenerateBianhao("FILE", "FileMgr");
                    String nid = SaveNew();
                    Response.Redirect("edit.aspx?id=" + nid);
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("fmu"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"]);
                        DataTable dt = db.ExecuteDataTable("SELECT [FileNo], [FileTitle], [LogUser], [LogTime], [Info] FROM [FileMgr] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];
                        TextBox_FileNo.Text = Server.HtmlEncode(dr[0].ToString());
                        TextBox_FileTitle.Text = Server.HtmlEncode(dr[1].ToString());
                        Label_LogUser.Text = Server.HtmlEncode(dr[2].ToString());
                        Label_LogTime.Text = Server.HtmlEncode(dr[3].ToString());
                        FCKeditor_info.Value = dr[4].ToString();
                        Session["filemgr_editid"] = Request.Params["id"];
                    }
                }
                if (!this.GetCurrentUser().hasPermission("fmp"))
                {
                    GridView1.Columns[0].Visible = false;
                    SqlDataSource1.DeleteCommand = "";
                    flashUpload.Visible = false;
                }
            }

        }

        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("fmc"))
            {
                return "";
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("LogTime", DateTime.Now);
                db.AddParameter("LogUser", this.GetCurrentUser().Name);
                db.AddParameter("FileNo", TextBox_FileNo.Text);
                db.AddParameter("FileTitle", TextBox_FileTitle.Text);
                db.AddParameter("Info", FCKeditor_info.Value);

                String sql;
                sql = "INSERT INTO [FileMgr] ([FileNo], [FileTitle], [LogUser], [LogTime], [Info]) " +
                    "VALUES (@FileNo, @FileTitle, @LogUser, @LogTime, @Info)";
                DataTable dt = db.ExecuteDataTable(sql + " SELECT SCOPE_IDENTITY()");

                String nid = "";
                if (dt.Rows.Count == 1)
                    nid = dt.Rows[0][0].ToString();

                if (Session["filemgr_new"] != null && nid != "")
                {
                    List<byte[]> arrNewFile = (List<byte[]>)Session["filemgr_new"];
                    List<String> arrNewFileName = (List<String>)Session["filemgr_newfn"];
                    for (int i = 0; i < arrNewFile.Count; i++)
                    {
                        using (DataBase dbData = new DataBase())
                        {
                            dbData.AddParameter("MgrId", nid);
                            dbData.AddParameter("FileName", arrNewFileName[i]);
                            dbData.AddParameter("Data", arrNewFile[i]);
                            int iRc = dbData.ExecuteNonQuery("INSERT INTO [File]([MgrId],[FileName],[Data]) " +
                                "VALUES(@MgrId,@FileName,@Data)");
                        }
                    }
                    arrNewFile.Clear();
                    arrNewFileName.Clear();
                }
                Session["filemgr_new"] = null;
                Session["filemgr_newvn"] = null;
                return nid;
                
            }

        }

        protected bool SaveOld(String id)
        {
            //TODO:服务端检查
            if (!this.GetCurrentUser().hasPermission("fmu"))
            {
                return false;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("LogTime", DateTime.Now);
                db.AddParameter("LogUser", this.GetCurrentUser().Name);
                db.AddParameter("FileNo", TextBox_FileNo.Text);
                db.AddParameter("FileTitle", TextBox_FileTitle.Text);
                db.AddParameter("Info", FCKeditor_info.Value);
                String sql;
                sql = "UPDATE [FileMgr] SET [FileNo] = @FileNo, [FileTitle]=@FileTitle, " +
                    "[LogUser]=@LogUser, [LogTime]=@LogTime, [Info]=@Info WHERE [ID]=@ID";
                int rc = db.ExecuteNonQuery(sql);
                return rc == 1;
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                String nid = SaveNew();
                if (nid == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('新增时出错');</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.document.getElementById(\"list\").src=\"List.aspx\";parent.selRec(\"" + nid + "\");</script>");
                }
            }
            else
            {
                //修改
                String id = Request.Params["id"].ToString();

                if (!SaveOld(id))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存时出错');</script>");
                }
                else
                {
                    //Response.Redirect("Detail.aspx?id=" + id);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.document.getElementById(\"list\").src=\"List.aspx\";parent.selRec(\"" + id + "\");</script>");
                }
            }
        }

        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            Session["filemgr_editid"] = null;
            if (Session["filemgr_new"] != null)
            {
                List<byte[]> arrNewFile = (List<byte[]>)Session["filemgr_new"];
                if (arrNewFile != null)
                    arrNewFile.Clear();
                Session["filemgr_new"] = null;
            }
            Session["filemgr_newfn"] = null;

            if (Request.Params["id"] != null)
            {
                String id = Request.Params["id"].ToString();
                Response.Redirect("Detail.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("Detail.aspx");
            }
        }

        protected void Button_savenext_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                //新增
                String nid = SaveNew();
                if (nid == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('新增时出错');</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.document.getElementById(\"list\").src=\"List.aspx\";parent.addNew();</script>");
                }

            }
            else
            {
                //修改
                String id = Request.Params["id"].ToString();

                if (!SaveOld(id))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存时出错');</script>");
                }
                else
                {
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"]);
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [FileMgr] WHERE [ID] > @ID ORDER BY [ID] ASC");
                        if (dt.Rows.Count == 1)
                        {
                            Response.Redirect("Edit.aspx?id=" + dt.Rows[0][0].ToString());
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.addNew();</script>");
                        }
                    }
                }

            }

        }
    }
}