using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.foshi
{
    public partial class detail_fashi : System.Web.UI.Page
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
                    DataTable dt = db.ExecuteDataTable("SELECT [ZHAIZHU_NAME] FROM [tbFOSHI] WHERE [ID]=@ID");
                    if (dt.Rows.Count != 1)
                    {
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    Label_ZHAIZHU_NAME.Text = Server.HtmlEncode(dr[0].ToString());
                }
                if (!this.GetCurrentUser().hasPermission("08u"))
                {
                    Button_edit.Enabled = false;
                }
                else
                {
                    Button_edit.OnClientClick = "window.open('edit.aspx?id=" + Request.Params["id"] + "','newwindow');return false;";
                }
            }
        }

    }
}