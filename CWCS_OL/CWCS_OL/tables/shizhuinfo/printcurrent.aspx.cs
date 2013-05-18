using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.shizhuinfo
{
    public partial class printcurrent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["shizhuinfosql"] != null)
            {
                String sql = Session["shizhuinfosql"].ToString();
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable(sql);
                    String content = "<table>";
                    int i = 1;
                    int cnt=dt.Rows.Count;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (i % 2 == 1)
                        {
                            content += "<tr><td>" +dr["SHIZHU_HOME_ZIP"].ToString()+
                                "<br />"+dr["SHIZHU_NAME"].ToString() + 
                                "<br />"+dr["SHIZHU_HOME_ADDR"].ToString()+"</td>";
                            if (i == cnt)
                                content += "</tr>";
                        }
                        else
                        {
                            content += "<td>" + dr["SHIZHU_HOME_ZIP"].ToString() +
                                "<br />" + dr["SHIZHU_NAME"].ToString() +
                                "<br />" + dr["SHIZHU_HOME_ADDR"].ToString() + "</td></tr>";
                        }
                        i++;
                    }
                    content += "</table>";
                    pContent.InnerHtml = content;

                }
            }
        }
    }
}