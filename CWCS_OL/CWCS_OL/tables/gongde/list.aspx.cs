using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.gongde
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("05r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!this.GetCurrentUser().hasPermission("05d"))
            {
                GridView1.Columns[1].Visible = false;
                SqlDataSource1.DeleteCommand = "";
            }
            if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
            {
                string keyWord = Request.Params["key"].ToString();

                String[] fields = { "[SHIZHU_ID]","[SHIZHU_NAME]","[SHIZHU_SEX]","[SHIZHU_HOME_ADDR]","[SHIZHU_HOME_ZIP]","[SHIZHU_HOME_TEL]","[SHIZHU_MOBILE]","[SHIZHU_TYPE]","[SHIZHU_EMAIL]","[SHIZHU_EDU]","[SHIZHU_NATIONALITY]","[SHIZHU_CITY]","[SHIZHU_DISTRICT]","[SHIZHU_IDCODE]","[SHIZHU_BIRTHDAY]","[SHIZHU_BIRTH_TYPE]","[SHIZHU_LUNAR_DAY]","[SHIZHU_TUIXIN]","[SHIZHU_SANGUI]","[SHIZHU_WUJIE]" };
                String sql = "SELECT [ID],[SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL],[SHIZHU_EDU],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_IDCODE],[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY],[SHIZHU_TUIXIN],[SHIZHU_SANGUI],[SHIZHU_WUJIE] FROM [SHIZHU_INFO] WHERE 1<>1 ";
                foreach (String field in fields)
                {
                    sql += " OR " + field + " like '%" + keyWord + "%'";
                }
                SqlDataSource1.SelectCommand = sql;
            }
        }
    }
}