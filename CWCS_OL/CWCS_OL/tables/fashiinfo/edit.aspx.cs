using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.fashiinfo
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["ID"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("07c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("07u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("SELECT [FAHAO], [ZHIWEI], [FASHI_NAME] FROM [FASHI_INFO] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];
                        TextBox_FAHAO.Text = Server.HtmlEncode(dr[0].ToString());
                        TextBox_NAME.Text = Server.HtmlEncode(dr[2].ToString());
                        TextBox_ZHIWEI.Text = Server.HtmlEncode(dr[1].ToString());
                        
                    }
                }
            }
        }
        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("07c"))
            {
                return "";
            }
            using (DataBase db = new DataBase())
            {
                //db.AddParameter("LOG_TIME", DateTime.Now);
                //db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHAO", TextBox_FAHAO.Text);
                db.AddParameter("ZHIWEI", TextBox_ZHIWEI.Text);
                db.AddParameter("FASHI_NAME", TextBox_NAME.Text);
                String sql;
                sql = "INSERT INTO [FASHI_INFO]([FAHAO], [ZHIWEI], [FASHI_NAME]) VALUES" +
                        "(@FAHAO, @ZHIWEI, @FASHI_NAME)";
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
            if (!this.GetCurrentUser().hasPermission("07u"))
            {
                return false;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("FAHAO", TextBox_FAHAO.Text);
                db.AddParameter("ZHIWEI", TextBox_ZHIWEI.Text);
                db.AddParameter("FASHI_NAME", TextBox_NAME.Text);
                String sql = "UPDATE [FASHI_INFO] SET [FAHAO] = @FAHAO" +
                    "      ,[ZHIWEI] = @ZHIWEI"+
                    "      ,[FASHI_NAME] = @FASHI_NAME"+
                    " WHERE [ID]=@ID";
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [FASHI_INFO] WHERE [ID] > @ID ORDER BY [ID] ASC");
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