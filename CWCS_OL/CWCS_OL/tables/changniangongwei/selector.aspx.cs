using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.changniangongwei
{
    public partial class selector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sql;
            DataTable dt;
            if (Request.Params["type"]!=null && Request.Params["fangwei"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    sql = "select rows,cols from changnian_type where fangwei='" + Request.Params["fangwei"]+"'";
                    dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count < 1)
                    {
                        Response.End();
                    }
                    int r = (int)dt.Rows[0][0];
                    String col = dt.Rows[0][1].ToString().Replace("，", ",");
                    string[] cols = col.Split(',');
                    int k = 0;
                    String fcontent = "<table style='width:100%;'>";
                    foreach (string a in cols)
                    {
                        fcontent+="<tr>";
                        k++;
                        int c = 0;
                        int.TryParse(a, out c);
                        for (int i = 1; i <= c; i++)
                        {


                            sql = "SELECT LIANXIREN FROM CAHNGNIAN_GONGWEI WHERE  " +
                                "YUAN='" + Request.Params["fangwei"] + "' AND PAI="+k+" AND ZUO="+i;
                            dt = db.ExecuteDataTable(sql);
                            if (dt.Rows.Count > 0)
                                fcontent += "<td>"+dt.Rows[0][0].ToString() + "</td>";
                            else
                                fcontent += "<td><a href=\"#\" onclick=\"window.opener.selFangwei('" +
                                Request.Params["fangwei"] + "'," + k + "," + i + ");window.close();\">" + i + "</a></td>";
                        }
                        fcontent += "</tr>";
                    }
                    fcontent += "</table>";
                    fangwei.InnerHtml = fcontent;

                }
            }
            else if (Request.Params["type"] != null && Request.Params["fangwei"] == null)
            {
                using (DataBase db = new DataBase())
                {
                    sql = "select fangwei from changnian_type";
                    dt = db.ExecuteDataTable(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        fangwei.InnerHtml += "<a href='selector.aspx?type=" + Request.Params["type"]+
                            "&fangwei=" + dr[0].ToString() + "'>" + dr[0].ToString() + "</a><br />";
                    }
                }
            }
            else
            {
                Response.End();
            }

        }
    }
}