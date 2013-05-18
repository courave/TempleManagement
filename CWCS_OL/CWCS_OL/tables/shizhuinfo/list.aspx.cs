using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.shizhuinfo
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
            if (!IsPostBack)
            {
                DropDownList_month.SelectedValue = DateTime.Now.Month.ToString();
                if (!this.GetCurrentUser().hasPermission("05d"))
                {
                    GridView1.Columns[2].Visible = false;
                    SqlDataSource1.DeleteCommand = "";
                }
                if (Request.Params["sel"] != null)
                {
                    GridView1.Columns[0].Visible = false;
                    GridView1.Columns[2].Visible = false;
                    toolbar.Visible = false;
                    if (Request.Params["sel"].ToString() != "")
                    {
                        SqlDataSource1.SelectCommand = "SELECT [SHIZHU_ID], [ID], [SHIZHU_NAME], [SHIZHU_SEX], [SHIZHU_HOME_ADDR], [SHIZHU_HOME_ZIP], [SHIZHU_CITY], [SHIZHU_NATIONALITY], [SHIZHU_EDU], [SHIZHU_EMAIL], [SHIZHU_TYPE], [SHIZHU_MOBILE], [SHIZHU_HOME_TEL], [SHIZHU_DISTRICT], [SHIZHU_IDCODE], [SHIZHU_BIRTHDAY], [SHIZHU_BIRTH_TYPE], [SHIZHU_LUNAR_DAY], [SHIZHU_TUIXIN], [SHIZHU_SANGUI], [SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY] FROM [SHIZHU_INFO] WHERE [SHIZHU_NAME] = '" + Request.Params["sel"].ToString() + "'";

                    }
                    GridView1.EmptyDataText = "没有找到信息。 &nbsp;<input type='button' onclick='window.close();return false;' value='关闭' />";
                }
                else
                {
                    GridView1.Columns[1].Visible = false;

                }
                if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
                {
                    string keyWord = Request.Params["key"].ToString();

                    String[] fields = { "[SHIZHU_ID]", "[SHIZHU_NAME]", "[SHIZHU_SEX]", "[SHIZHU_HOME_ADDR]", "[SHIZHU_HOME_ZIP]", "[SHIZHU_HOME_TEL]", "[SHIZHU_MOBILE]", "[SHIZHU_TYPE]", "[SHIZHU_EMAIL]", "[SHIZHU_EDU]", "[SHIZHU_NATIONALITY]", "[SHIZHU_CITY]", "[SHIZHU_DISTRICT]", "[SHIZHU_IDCODE]", "[SHIZHU_BIRTHDAY]", "[SHIZHU_BIRTH_TYPE]", "[SHIZHU_LUNAR_DAY]", "[SHIZHU_TUIXIN]", "[SHIZHU_SANGUI]", "[SHIZHU_WUJIE]","[BIRTH_MONTH]","[BIRTH_DAY]" };
                    String sql = "SELECT [ID],[SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL],[SHIZHU_EDU],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_IDCODE],[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY],[SHIZHU_TUIXIN],[SHIZHU_SANGUI],[SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY] FROM [SHIZHU_INFO] WHERE 1<>1 ";
                    foreach (String field in fields)
                    {
                        sql += " OR " + field + " like '%" + keyWord + "%'";
                    }
                    SqlDataSource1.SelectCommand = sql;
                    Session["shizhuinfosql"] = sql;
                }
            }
        }

        protected void Button_Getshouxin_Click(object sender, EventArgs e)
        {
            //deal with the 公历 
            String sql = "SELECT [ID],[SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL],[SHIZHU_EDU],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_IDCODE],[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY],[SHIZHU_TUIXIN],[SHIZHU_SANGUI],[SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY] FROM [SHIZHU_INFO]"+
                "WHERE ([SHIZHU_BIRTH_TYPE]='公历' AND [BIRTH_MONTH]="+DropDownList_month.SelectedValue+")";
            //deal with the 农历
            sql += " OR ([SHIZHU_BIRTH_TYPE]='农历' AND (";
            int month = int.Parse(DropDownList_month.SelectedValue);
            int year = DateTime.Now.Year;
            int lm, ly;
            for (int i = 1; i <= 31; i++)
            {
                try
                {
                    DateTime d = new DateTime(year, month, i);
                    if (i != 1)
                        sql += " OR ";
                    System.Globalization.ChineseLunisolarCalendar calendar = new System.Globalization.ChineseLunisolarCalendar();
                    lm = calendar.GetMonth(d);
                    ly = calendar.GetDayOfMonth(d);
                    sql += "([BIRTH_MONTH]=" + lm + " AND [BIRTH_DAY]=" + ly + ")";
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            sql += "))";
            SqlDataSource1.SelectCommand = sql;
            Session["shizhuinfosql"] = sql;
        }
    }
}