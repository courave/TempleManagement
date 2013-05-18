using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.sanshi
{
    public partial class list : System.Web.UI.Page
    {
        public string selQuery = "SELECT [ID], [SANSHI_NO], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [YANGSHANG6], [YANGSHANG5], [YANGSHANG4], [YANGSHANG3], [YANGSHANG2], [YANGSHANG1], [JIEYIN4], [JIEYIN3], [JIEYIN2], [EXPIRED_TIME], [SHIZHU_BIANHAO], [FANGWEI], [ROW], [COL],[HAS_PRINT] FROM [tbSANSHI]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("03r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                for (int i = 0; i < GridView1.Columns.Count; i++)
                {
                    if (GridView1.Columns[i].HeaderText == "")
                        continue;
                    if (GridView1.Columns[i].SortExpression == "")
                        continue;
                    DropDownList_col.Items.Add(new ListItem(GridView1.Columns[i].HeaderText, GridView1.Columns[i].SortExpression));
                }
                if (!this.GetCurrentUser().hasPermission("03d"))
                {
                    GridView1.Columns[1].Visible = false;
                    SqlDataSource1.DeleteCommand = "";
                }
                if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
                {
                    string keyWord = Request.Params["key"].ToString();

                    String[] fields = { "[LOG_USER]", "[LOG_TIME]", "[FAHUI_NAME]", "[ZUOCI]", "[ZIHAO]", "[JIEYIN1]", "[JIEYIN2]", "[JIEYIN3]", "[JIEYIN4]", "[YANGSHANG1]", "[YANGSHANG2]", "[YANGSHANG3]", "[YANGSHANG4]", "[YANGSHANG5]", "[YANGSHANG6]", "[SANSHI_NO]", "[EXPIRED_TIME]", "[FANGWEI]", "[ROW]", "[COL]", "[SHIZHU_BIANHAO]","[HAS_PRINT]" };
                    selQuery = "SELECT [ID], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], [JIEYIN4], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [YANGSHANG4], [YANGSHANG5], [YANGSHANG6],[SANSHI_NO],[EXPIRED_TIME],[FANGWEI],[ROW],[COL],[SHIZHU_BIANHAO],[HAS_PRINT] FROM [tbSANSHI] WHERE (1<>1 ";
                    foreach (String field in fields)
                    {
                        selQuery += " OR " + field + " like '%" + keyWord + "%'";
                    }
                    selQuery += ")";
                    SqlDataSource1.SelectCommand = selQuery;
                }
                Session["sanshi_cursql"] = selQuery;
            }
        }
        protected void Button_searchCur_Click(object sender, EventArgs e)
        {
            if (TextBox_searchText.Text.Trim() == "")
                return;
            if (Session["sanshi_cursql"] != null)
                selQuery = Session["sanshi_cursql"].ToString();
            if (selQuery.ToUpper().IndexOf("WHERE") > 0)
            {
                selQuery += " AND " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
            }
            else
            {
                selQuery += " WHERE " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
            }
            Session["sanshi_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery;
        }

        protected void Button_searchAll_Click(object sender, EventArgs e)
        {
            if (TextBox_searchText.Text.Trim() == "")
                return;
            selQuery = "SELECT [ID], [SANSHI_NO], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [YANGSHANG6], [YANGSHANG5], [YANGSHANG4], [YANGSHANG3], [YANGSHANG2], [YANGSHANG1], [JIEYIN4], [JIEYIN3], [JIEYIN2], [EXPIRED_TIME], [SHIZHU_BIANHAO], [FANGWEI], [ROW], [COL],[HAS_PRINT] FROM [tbSANSHI]";

            selQuery += " WHERE " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
            Session["sanshi_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery;
        }

        protected void Button_today_Click(object sender, EventArgs e)
        {
            selQuery = "SELECT [ID], [SANSHI_NO], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [YANGSHANG6], [YANGSHANG5], [YANGSHANG4], [YANGSHANG3], [YANGSHANG2], [YANGSHANG1], [JIEYIN4], [JIEYIN3], [JIEYIN2], [EXPIRED_TIME], [SHIZHU_BIANHAO], [FANGWEI], [ROW], [COL],[HAS_PRINT] FROM [tbSANSHI]";
            selQuery += " WHERE YEAR(LOG_TIME)='" + DateTime.Now.Year + "' AND MONTH(LOG_TIME)='" +
                DateTime.Now.Month + "' AND DAY(LOG_TIME)='" + DateTime.Now.Day + "'";
            Session["sanshi_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery;
        }
        protected void Button_getunprint_Click(object sender, EventArgs e)
        {
            selQuery = "SELECT [ID], [SANSHI_NO], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [YANGSHANG6], [YANGSHANG5], [YANGSHANG4], [YANGSHANG3], [YANGSHANG2], [YANGSHANG1], [JIEYIN4], [JIEYIN3], [JIEYIN2], [EXPIRED_TIME], [SHIZHU_BIANHAO], [FANGWEI], [ROW], [COL],[HAS_PRINT] FROM [tbSANSHI]";

            selQuery += " WHERE (HAS_PRINT = 0 OR HAS_PRINT IS NULL) ";

            SqlDataSource1.SelectCommand = selQuery;
        }
    }
}