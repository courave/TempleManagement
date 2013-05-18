using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.foshi
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("08r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!this.GetCurrentUser().hasPermission("08d"))
            {
                GridView1.Columns[1].Visible = false;
                SqlDataSource1.DeleteCommand = "";
            }
            if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
            {
                string keyWord = Request.Params["key"].ToString();

                String[] fields = { "[ZHAIZHU_NAME]", "[FOSHI_DATETIME]", "[JIESONG_ADDR]", "[TEL]", "[LOG_USER]", "[LOG_TIME]", "[COMMENT]" };
                String sql = "SELECT [ID], [ZHAIZHU_NAME], [FOSHI_DATETIME], ISNULL([FCOUNT],0) AS FASHI_COUNT, [JIESONG_ADDR], [TEL], [LOG_USER], [LOG_TIME], [COMMENT] FROM [tbFOSHI] A LEFT JOIN (SELECT FOSHI_ID,COUNT(*) AS FCOUNT FROM [FASHI_FOSHI] GROUP BY FOSHI_ID) B ON A.ID=B.FOSHI_ID WHERE 1<>1 ";
                foreach (String field in fields)
                {
                    sql += " OR " + field + " like '%" + keyWord + "%'";
                }
                SqlDataSource1.SelectCommand = sql;
            }
        }

        protected void LinkButton_del_Click(object sender, EventArgs e)
        {
            String foshiId = ((LinkButton)sender).CommandArgument;
            if (String.IsNullOrEmpty(foshiId))
                return;
            if (!this.GetCurrentUser().hasPermission("08d"))
                return;

            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", foshiId);
                int rc = db.ExecuteNonQuery("DELETE FROM [FASHI_FOSHI] WHERE [FOSHI_ID] = @ID");
                db.AddParameter("ID", foshiId);
                rc = db.ExecuteNonQuery("DELETE FROM [FOSHI_SHENG] WHERE [FoshiID] = @ID");
                db.AddParameter("ID", foshiId);
                rc = db.ExecuteNonQuery("DELETE FROM [FOSHI_JIESONG] WHERE [FoshiID] = @ID");
                db.AddParameter("ID", foshiId);
                rc = db.ExecuteNonQuery("DELETE FROM [tbFOSHI] WHERE [ID] = @ID");
                if (rc > 0)
                {
                    GridView1.DataBind();
                }
            }
        }
    }
}