using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.wangsheng
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("02c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }

                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                    if(Request.Params["fahui"]!=null)
                    {
                        TextBox_fahui_name.Text=Request.Params["fahui"].ToString();
                        TextBox_zuoci.Text = Util.GenZuoci("tbWANGSHENG",
                            Request.Params["fahui"].ToString()).ToString();
                        Button_save.Visible = false;
                        Button_cancel.Visible = false;
                    }
                    TextBox_zihao.Text = "天";
                    
                    TextBox_log_time.Text = DateTime.Now.ToString();
                    TextBox_log_user.Text = this.GetCurrentUser().Name;
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("02u"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("SELECT [ID], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], [JIEYIN4], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [YANGSHANG4], [YANGSHANG5], [YANGSHANG6] FROM [tbWANGSHENG] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];

                        TextBox_fahui_name.Text = Server.HtmlEncode(dr[3].ToString());
                        TextBox_zihao.Text = Server.HtmlEncode(dr[5].ToString());
                        TextBox_zuoci.Text = Server.HtmlEncode(dr[4].ToString());

                        TextBox_jieyin1.Text = Server.HtmlEncode(dr[6].ToString());
                        TextBox_jieyin2.Text = Server.HtmlEncode(dr[7].ToString());
                        TextBox_jieyin3.Text = Server.HtmlEncode(dr[8].ToString());
                        TextBox_jieyin4.Text = Server.HtmlEncode(dr[9].ToString());
                        TextBox_yangshang1.Text = Server.HtmlEncode(dr[10].ToString());
                        TextBox_yangshang2.Text = Server.HtmlEncode(dr[11].ToString());
                        TextBox_yangshang3.Text = Server.HtmlEncode(dr[12].ToString());
                        TextBox_yangshang4.Text = Server.HtmlEncode(dr[13].ToString());
                        TextBox_log_user.Text = Server.HtmlEncode(dr[1].ToString());
                        TextBox_log_time.Text = Server.HtmlEncode(dr[2].ToString());
                    }
                }
            }

        }

        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("02c"))
            {
                return "";
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHUI_NAME", TextBox_fahui_name.Text);
                if (TextBox_jieyin2.Text.Trim() == "" &&
                    TextBox_jieyin3.Text.Trim() == "" &&
                    TextBox_jieyin4.Text.Trim() == "" &&
                    TextBox_jieyin1.Text.Trim() != "")
                {
                    db.AddParameter("JIEYIN1", DBNull.Value);
                    db.AddParameter("JIEYIN2", DBNull.Value);
                    db.AddParameter("JIEYIN3", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN4", DBNull.Value);
                }
                else if (TextBox_jieyin2.Text.Trim() != "" &&
                        TextBox_jieyin3.Text.Trim() == "" &&
                        TextBox_jieyin4.Text.Trim() == "" &&
                        TextBox_jieyin1.Text.Trim() != "")
                {
                    db.AddParameter("JIEYIN1", DBNull.Value);
                    db.AddParameter("JIEYIN2", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN3", TextBox_jieyin2.Text);
                    db.AddParameter("JIEYIN4", DBNull.Value);
                }
                else if (TextBox_jieyin2.Text.Trim() != "" &&
                    TextBox_jieyin3.Text.Trim() != "" &&
                    TextBox_jieyin4.Text.Trim() == "" &&
                    TextBox_jieyin1.Text.Trim() != "")
                {
                    db.AddParameter("JIEYIN1", DBNull.Value);
                    db.AddParameter("JIEYIN2", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN3", TextBox_jieyin2.Text);
                    db.AddParameter("JIEYIN4", TextBox_jieyin3.Text);
                }
                else
                {
                    db.AddParameter("JIEYIN1", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN2", TextBox_jieyin2.Text);
                    db.AddParameter("JIEYIN3", TextBox_jieyin3.Text);
                    db.AddParameter("JIEYIN4", TextBox_jieyin4.Text);
                }
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", TextBox_zihao.Text);
                db.AddParameter("YANGSHANG1", TextBox_yangshang1.Text);
                db.AddParameter("YANGSHANG2", TextBox_yangshang2.Text);
                db.AddParameter("YANGSHANG3", TextBox_yangshang3.Text);
                db.AddParameter("YANGSHANG4", TextBox_yangshang4.Text);
                String sql;
                sql = "INSERT INTO [tbWANGSHENG] ([LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], "+
                    "[ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], [JIEYIN4], [YANGSHANG1], [YANGSHANG2],"+
                    " [YANGSHANG3], [YANGSHANG4]) VALUES (@LOG_USER, "+
                    "@LOG_TIME, @FAHUI_NAME, @ZUOCI, @ZIHAO, @JIEYIN1, @JIEYIN2, @JIEYIN3, @JIEYIN4, "+
                    "@YANGSHANG1, @YANGSHANG2, @YANGSHANG3, @YANGSHANG4)";
                DataTable dt = db.ExecuteDataTable(sql + " SELECT SCOPE_IDENTITY()");
                String nid = "";
                if (dt.Rows.Count == 1)
                    nid = dt.Rows[0][0].ToString();
                return nid;
            }

        }

        protected bool SaveOld(String id)
        {
            //TODO:服务端检查
            if (!this.GetCurrentUser().hasPermission("02u"))
            {
                return false;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHUI_NAME", TextBox_fahui_name.Text);
                if (TextBox_jieyin2.Text.Trim() == "" &&
                    TextBox_jieyin3.Text.Trim() == "" &&
                    TextBox_jieyin4.Text.Trim() == "" &&
                    TextBox_jieyin1.Text.Trim() != "")
                {
                    db.AddParameter("JIEYIN1", DBNull.Value);
                    db.AddParameter("JIEYIN2", DBNull.Value);
                    db.AddParameter("JIEYIN3", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN4", DBNull.Value);
                }
                else if (TextBox_jieyin2.Text.Trim() != "" &&
                        TextBox_jieyin3.Text.Trim() == "" &&
                        TextBox_jieyin4.Text.Trim() == "" &&
                        TextBox_jieyin1.Text.Trim() != "")
                {
                    db.AddParameter("JIEYIN1", DBNull.Value);
                    db.AddParameter("JIEYIN2", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN3", TextBox_jieyin2.Text);
                    db.AddParameter("JIEYIN4", DBNull.Value);
                }
                else if (TextBox_jieyin2.Text.Trim() != "" &&
                    TextBox_jieyin3.Text.Trim() != "" &&
                    TextBox_jieyin4.Text.Trim() == "" &&
                    TextBox_jieyin1.Text.Trim() != "")
                {
                    db.AddParameter("JIEYIN1", DBNull.Value);
                    db.AddParameter("JIEYIN2", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN3", TextBox_jieyin2.Text);
                    db.AddParameter("JIEYIN4", TextBox_jieyin3.Text);
                }
                else
                {
                    db.AddParameter("JIEYIN1", TextBox_jieyin1.Text);
                    db.AddParameter("JIEYIN2", TextBox_jieyin2.Text);
                    db.AddParameter("JIEYIN3", TextBox_jieyin3.Text);
                    db.AddParameter("JIEYIN4", TextBox_jieyin4.Text);
                }
                db.AddParameter("YANGSHANG1", TextBox_yangshang1.Text);
                db.AddParameter("YANGSHANG2", TextBox_yangshang2.Text);
                db.AddParameter("YANGSHANG3", TextBox_yangshang3.Text);
                db.AddParameter("YANGSHANG4", TextBox_yangshang4.Text);
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", TextBox_zihao.Text);
                String sql;
                sql = "UPDATE [tbWANGSHENG] SET [LOG_TIME] = @LOG_TIME, [LOG_USER]=@LOG_USER, " +
                    "[FAHUI_NAME]=@FAHUI_NAME, [JIEYIN1]=@JIEYIN1, [JIEYIN2]=@JIEYIN2, " +
                    "[JIEYIN3]=@JIEYIN3, [JIEYIN4]=@JIEYIN4, [YANGSHANG1]=@YANGSHANG1, "+
                    "[YANGSHANG2]=@YANGSHANG2, [YANGSHANG3]=@YANGSHANG3, [YANGSHANG4]=@YANGSHANG4, " +
                    " [ZUOCI]=@ZUOCI, [ZIHAO]=ZIHAO WHERE [ID]=@ID";
                int rc = db.ExecuteNonQuery(sql);
                return rc == 1;
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null )
            {
                String nid = SaveNew();
                if (nid == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('新增时出错');</script>");
                }
                else if (Request.Params["fahui"] == null)
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
                    Response.Redirect("Detail.aspx?id=" + id);
                }
            }
        }

        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                String id = Request.Params["id"].ToString();
                Response.Redirect("Detail.aspx?id=" + id);
            }
            else if (Request.Params["fahui"] == null)
            {
                Response.Redirect("Detail.aspx");
            }
            else
            {
                Response.Redirect("edit.aspx?fahui=" + Request.Params["fahui"].ToString());
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
                else if (Request.Params["fahui"] == null)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.document.getElementById(\"list\").src=\"List.aspx\";parent.addNew();</script>");
                }
                else
                {
                    Response.Redirect("edit.aspx?fahui=" + Request.Params["fahui"].ToString());
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbWANGSHENG] WHERE [ID] > @ID ORDER BY [ID] ASC");
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