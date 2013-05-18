using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.admin
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("00r"))
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
                DataBase db = new DataBase();
                db.AddParameter("ID", Request.Params["id"]);
                DataTable dt = db.ExecuteDataTable("SELECT [ID],[USERNAME],[PERMISSION] FROM [ADMIN] WHERE ID=@ID");
                if (dt.Rows.Count != 1)
                {
                    Response.End();
                }
                DataRow dr = dt.Rows[0];
                Label_id.Text = Server.HtmlEncode(dr[0].ToString());
                Label_name.Text = Server.HtmlEncode(dr[1].ToString());
                Label_permission.Text = Server.HtmlEncode(dr[2].ToString());
                if (!this.GetCurrentUser().hasPermission("00u"))
                {
                    Button_edit.Enabled = false;
                }

            }
        }

        protected void Button_edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx?id=" + Request.Params["id"]);
        }
    }
}