using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.fahui
{
    public partial class _default : System.Web.UI.Page
    {
        public String fahuiname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "select distinct log_year from (select YEAR(log_time) as log_year from tbWANGSHENG union select YEAR(log_time) as log_year from tbYANSHENG) as a";
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DropDownList_year.Items.Add(new ListItem(dr[0].ToString()+"年",dr[0].ToString()));
                    }
                }
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("select distinct FAHUI_NAME from (select FAHUI_NAME from tbYansheng where year(LOG_TIME)="+
                        DropDownList_year.SelectedValue+" union select FAHUI_NAME from tbWangsheng where year(LOG_TIME)="+
                        DropDownList_year.SelectedValue + ") as a");
                    if (dt.Rows.Count > 0)
                    {

                        List<String> a = new List<string>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            a.Add(dt.Rows[i][0].ToString());
                        }
                        DropDownList_FAHUI.DataSource = a;
                        DropDownList_FAHUI.DataBind();
                    }
                }
            }
            
        }

        protected void Button_view_Click(object sender, EventArgs e)
        {
            fahuiname= DropDownList_FAHUI.Text;
            //Response.Redirect("../yansheng/default.aspx?fahui=" + fahuiname);
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("select * from tbWangsheng where FAHUI_NAME like '%"+
                    fahuiname+"%'");
                String nav="";
                if (dt.Rows.Count > 0)
                    nav += "wangsheng";
                dt = db.ExecuteDataTable("select * from tbYansheng where FAHUI_NAME like '%" +
                    fahuiname + "%'");
                if (dt.Rows.Count > 0)
                    nav += "yansheng";
                if (nav == "wangshengyansheng")
                {
                    navBar.InnerHtml = "<a href='../yansheng/default.aspx?fahui=" + fahuiname +
                        "&year=" +DropDownList_year.SelectedValue+
                        "'>延生表</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='../wangsheng/default.aspx?fahui=" +
                        fahuiname + "&year=" + DropDownList_year.SelectedValue + "'>往生表</a>";
                }
                else if (nav != "")
                {
                    Response.Redirect("../" + nav + "/default.aspx?fahui=" + fahuiname+"&year=" +DropDownList_year.SelectedValue);
                }
                else
                {
                    navBar.InnerText = "无此法会信息";
                }
            }
        }

        protected void DropDownList_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change dropdownlis_fahui
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("select distinct FAHUI_NAME from (select FAHUI_NAME from tbYansheng where year(LOG_TIME)=" +
                    DropDownList_year.SelectedValue + " union select FAHUI_NAME from tbWangsheng where year(LOG_TIME)=" +
                    DropDownList_year.SelectedValue + ") as a");
                if (dt.Rows.Count > 0)
                {

                    List<String> a = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a.Add(dt.Rows[i][0].ToString());
                    }
                    DropDownList_FAHUI.DataSource = a;
                    DropDownList_FAHUI.DataBind();
                }
            }
        }

    }
}