using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.filemgr
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("fmr"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!this.GetCurrentUser().hasPermission("fmd"))
            {
                GridView1.Columns[1].Visible = false;
            }
            if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
            {
                string keyWord = Request.Params["key"].ToString();

                String[] fields = { "[ID]", "[FileNo]", "[FileTitle]", "[LogUser]", "[LogTime]" };
                String sql = "SELECT [ID], [FileNo], [FileTitle], [LogUser], [LogTime] FROM [FileMgr] WHERE 1<>1 ";
                foreach (String field in fields)
                {
                    sql += " OR " + field + " like '%" + keyWord + "%'";
                }
                SqlDataSource1.SelectCommand = sql;
            }
        }

        protected void LinkButton_del_Click(object sender, EventArgs e)
        {
            String fileMgrId = ((LinkButton)sender).CommandArgument;
            if (String.IsNullOrEmpty(fileMgrId))
                return;
            if (!this.GetCurrentUser().hasPermission("fmd"))
                return;

            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", fileMgrId);
                int rc = db.ExecuteNonQuery("DELETE FROM [File] WHERE [MgrId] = @ID");
                db.AddParameter("ID", fileMgrId);
                rc = db.ExecuteNonQuery("DELETE FROM [FileMgr] WHERE [ID] = @ID");
                if (rc > 0)
                {
                    GridView1.DataBind();
                }
            }
        }
    }
}