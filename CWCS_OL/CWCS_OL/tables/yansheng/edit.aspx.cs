using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.yansheng
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("01c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }

                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                    if (Request.Params["fahui"] != null)
                    {
                        TextBox_fahui_name.Text = Request.Params["fahui"].ToString();
                        TextBox_zuoci.Text = Util.GenZuoci("tbYANSHENG",
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
                    if (!this.GetCurrentUser().hasPermission("01u"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt= db.ExecuteDataTable("SELECT [ID],[LOG_TIME],[LOG_USER],[FAHUI_NAME],[ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO] FROM [tbYANSHENG] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];
                        
                        TextBox_fahui_name.Text = Server.HtmlEncode(dr[3].ToString());
                        TextBox_zihao.Text = Server.HtmlEncode(dr[9].ToString());
                        TextBox_zuoci.Text = Server.HtmlEncode(dr[8].ToString());
                        TextBox_zhuzhao1.Text = Server.HtmlEncode(dr[4].ToString());
                        TextBox_zhuzhao2.Text = Server.HtmlEncode(dr[5].ToString());
                        TextBox_zhuzhao3.Text = Server.HtmlEncode(dr[6].ToString());
                        TextBox_zhuzhao4.Text = Server.HtmlEncode(dr[7].ToString());
                        TextBox_log_user.Text = Server.HtmlEncode(dr[2].ToString());
                        TextBox_log_time.Text = Server.HtmlEncode(dr[1].ToString());
                    }
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
            else if(Request.Params["fahui"]==null)
            {
                Response.Redirect("Detail.aspx");
            }
            else
            {
                Response.Redirect("edit.aspx?fahui=" + Request.Params["fahui"].ToString());
            }
        }

        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("01c"))
            {
                return "";
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHUI_NAME", TextBox_fahui_name.Text);
                if (TextBox_zhuzhao2.Text.Trim() == "" &&
                    TextBox_zhuzhao3.Text.Trim() == "" &&
                    TextBox_zhuzhao4.Text.Trim() == "" &&
                    TextBox_zhuzhao1.Text.Trim() != "")
                {
                    db.AddParameter("ZHUZHAO1", DBNull.Value);
                    db.AddParameter("ZHUZHAO2", DBNull.Value);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO4", DBNull.Value);
                }
                else if (TextBox_zhuzhao2.Text.Trim() != "" &&
                        TextBox_zhuzhao3.Text.Trim() == "" &&
                        TextBox_zhuzhao4.Text.Trim() == "" &&
                        TextBox_zhuzhao1.Text.Trim() != "")
                {
                    db.AddParameter("ZHUZHAO1", DBNull.Value);
                    db.AddParameter("ZHUZHAO2", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao2.Text);
                    db.AddParameter("ZHUZHAO4", DBNull.Value);
                }
                else if (TextBox_zhuzhao2.Text.Trim() != "" &&
                    TextBox_zhuzhao3.Text.Trim() != "" &&
                    TextBox_zhuzhao4.Text.Trim() == "" &&
                    TextBox_zhuzhao1.Text.Trim() != "")
                {
                    db.AddParameter("ZHUZHAO1", DBNull.Value);
                    db.AddParameter("ZHUZHAO2", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao2.Text);
                    db.AddParameter("ZHUZHAO4", TextBox_zhuzhao3.Text);
                }
                else
                {
                    db.AddParameter("ZHUZHAO1", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO2", TextBox_zhuzhao2.Text);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao3.Text);
                    db.AddParameter("ZHUZHAO4", TextBox_zhuzhao4.Text);
                }
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", TextBox_zihao.Text);
                String sql;
                sql = "INSERT INTO [tbYANSHENG] ([LOG_TIME],[LOG_USER],[FAHUI_NAME],[ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO]) VALUES (@LOG_TIME,@LOG_USER,@FAHUI_NAME,@ZHUZHAO1,@ZHUZHAO2,@ZHUZHAO3,@ZHUZHAO4,@ZUOCI,@ZIHAO)";
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
            if (!this.GetCurrentUser().hasPermission("01u"))
            {
                return false;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHUI_NAME", TextBox_fahui_name.Text);
                if (TextBox_zhuzhao2.Text.Trim() == "" &&
                    TextBox_zhuzhao3.Text.Trim() == "" &&
                    TextBox_zhuzhao4.Text.Trim() == "" &&
                    TextBox_zhuzhao1.Text.Trim() != "")
                {
                    db.AddParameter("ZHUZHAO1", DBNull.Value);
                    db.AddParameter("ZHUZHAO2", DBNull.Value);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO4", DBNull.Value);
                }
                else if (TextBox_zhuzhao2.Text.Trim() != "" &&
                        TextBox_zhuzhao3.Text.Trim() == "" &&
                        TextBox_zhuzhao4.Text.Trim() == "" &&
                        TextBox_zhuzhao1.Text.Trim() != "")
                {
                    db.AddParameter("ZHUZHAO1", DBNull.Value);
                    db.AddParameter("ZHUZHAO2", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao2.Text);
                    db.AddParameter("ZHUZHAO4", DBNull.Value);
                }
                else if (TextBox_zhuzhao2.Text.Trim() != "" &&
                    TextBox_zhuzhao3.Text.Trim() != "" &&
                    TextBox_zhuzhao4.Text.Trim() == "" &&
                    TextBox_zhuzhao1.Text.Trim() != "")
                {
                    db.AddParameter("ZHUZHAO1", DBNull.Value);
                    db.AddParameter("ZHUZHAO2", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao2.Text);
                    db.AddParameter("ZHUZHAO4", TextBox_zhuzhao3.Text);
                }
                else
                {
                    db.AddParameter("ZHUZHAO1", TextBox_zhuzhao1.Text);
                    db.AddParameter("ZHUZHAO2", TextBox_zhuzhao2.Text);
                    db.AddParameter("ZHUZHAO3", TextBox_zhuzhao3.Text);
                    db.AddParameter("ZHUZHAO4", TextBox_zhuzhao4.Text);
                }
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", TextBox_zihao.Text);
                String sql;
                sql = "UPDATE [tbYANSHENG] SET [LOG_TIME] = @LOG_TIME, [LOG_USER]=@LOG_USER, "+
                    "[FAHUI_NAME]=@FAHUI_NAME, [ZHUZHAO1]=@ZHUZHAO1, [ZHUZHAO2]=@ZHUZHAO2, "+
                    "[ZHUZHAO3]=@ZHUZHAO3, [ZHUZHAO4]=@ZHUZHAO4, [ZUOCI]=@ZUOCI, [ZIHAO]=ZIHAO WHERE [ID]=@ID";
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
                else if(Request.Params["fahui"]==null)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.document.getElementById(\"list\").src=\"List.aspx\";parent.selRec(\"" + nid + "\");</script>");
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
                    Response.Redirect("Detail.aspx?id=" + id);
                }
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbYANSHENG] WHERE [ID] > @ID ORDER BY [ID] ASC");
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