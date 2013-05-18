using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.foshi
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("08r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    Response.Write("请先选择一条记录");
                    Response.End();
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT [ZHAIZHU_NAME], [FOSHI_DATETIME], ISNULL([FCOUNT],0) AS FASHI_COUNT, [JIESONG_ADDR], [TEL], [LOG_USER], [LOG_TIME], [COMMENT] FROM [tbFOSHI] A LEFT JOIN (SELECT FOSHI_ID,COUNT(*) AS FCOUNT FROM [FASHI_FOSHI] GROUP BY FOSHI_ID) B ON A.ID=B.FOSHI_ID WHERE A.ID=@ID");
                    if (dt.Rows.Count != 1)
                    {
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    LinkButton_ZHAIZHU_NAME.Text = Server.HtmlEncode(dr[0].ToString());
                    Label_FOSHI_DATETIME.Text = Server.HtmlEncode(dr[1].ToString());
                    LinkButton_FASHI_COUNT.Text = Server.HtmlEncode(dr[2].ToString());
                    LinkButton_JIESONG_ADDR.Text = Server.HtmlEncode(dr[3].ToString());
                    Label_TEL.Text = Server.HtmlEncode(dr[4].ToString());
                    Label_LOG_USER.Text = Server.HtmlEncode(dr[5].ToString());
                    Label_LOG_TIME.Text = Server.HtmlEncode(dr[6].ToString());
                    Label_COMMENT.Text = Server.HtmlEncode(dr[7].ToString());
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbFOSHI] WHERE [ID]<@ID ORDER BY [ID] DESC");
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
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbFOSHI] WHERE [ID]>@ID ORDER BY [ID] ASC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_next.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_next.Enabled = false;
                    }
                }
                if (!this.GetCurrentUser().hasPermission("08u"))
                {
                    Button_edit.Enabled = false;
                }
                else
                {
                    Button_edit.OnClientClick = "window.open('edit.aspx?id=" + Request.Params["id"] + "','newwindow');return false;";
                }
                LinkButton_ZHAIZHU_NAME.OnClientClick = "return parent.list.showSheng('" + Request.Params["id"] + "');";
                LinkButton_FASHI_COUNT.OnClientClick = "return parent.list.showFashi('" + Request.Params["id"] + "');";
                LinkButton_JIESONG_ADDR.OnClientClick = "return parent.list.showJiesong('" + Request.Params["id"] + "');";
            }
        }

    }
}