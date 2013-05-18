using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.filemgr
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("fmr"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    Response.Write("无当前记录");
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
                    Label_FileNo.Text = Server.HtmlEncode(dr[0].ToString());
                    Label_FileTitle.Text = Server.HtmlEncode(dr[1].ToString());
                    Label_LogUser.Text = Server.HtmlEncode(dr[2].ToString());
                    Label_LogTime.Text = Server.HtmlEncode(dr[3].ToString());
                    Label_Info.Text = dr[4].ToString();

                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [FileMgr] WHERE [ID]<@ID ORDER BY [ID] DESC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_prev.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_prev.Enabled = false;
                    }
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [FileMgr] WHERE [ID]>@ID ORDER BY [ID] ASC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_next.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_next.Enabled = false;
                    }
                }
                if (!this.GetCurrentUser().hasPermission("fmu"))
                {
                    Button_edit.Enabled = false;
                }
            }
        }

        protected void Button_edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx?id=" + Request.Params["id"]);
        }
    }
}