using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.wangsheng
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("02r"))
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
                    DataTable dt = db.ExecuteDataTable("SELECT [ID], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], [JIEYIN4], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [YANGSHANG4], [YANGSHANG5], [YANGSHANG6] FROM [tbWANGSHENG] WHERE ID=@ID");
                    if (dt.Rows.Count < 1)
                    {
                        Response.Write("该记录不存在");
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    Label_fahui_name.Text = Server.HtmlEncode(dr[3].ToString());
                    Label_zihao.Text = Server.HtmlEncode(dr[5].ToString());
                    Label_zuoci.Text = Server.HtmlEncode(dr[4].ToString());
                    Label_JIEYIN1.Text = Server.HtmlEncode(dr[6].ToString());
                    Label_JIEYIN2.Text = Server.HtmlEncode(dr[7].ToString());
                    Label_JIEYIN3.Text = Server.HtmlEncode(dr[8].ToString());
                    Label_JIEYIN4.Text = Server.HtmlEncode(dr[9].ToString());
                    Label_YANGSHANG1.Text = Server.HtmlEncode(dr[10].ToString());
                    Label_YANGSHANG2.Text = Server.HtmlEncode(dr[11].ToString());
                    Label_YANGSHANG3.Text = Server.HtmlEncode(dr[12].ToString());
                    Label_YANGSHANG4.Text = Server.HtmlEncode(dr[13].ToString());
                    Label_log_user.Text = Server.HtmlEncode(dr[1].ToString());
                    Label_log_time.Text = Server.HtmlEncode(dr[2].ToString());

                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbWANGSHENG] WHERE [ID]<@ID ORDER BY [ID] DESC");
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
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbWANGSHENG] WHERE [ID]>@ID ORDER BY [ID] ASC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_next.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_next.Enabled = false;
                    }
                }
                if (!this.GetCurrentUser().hasPermission("02u"))
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