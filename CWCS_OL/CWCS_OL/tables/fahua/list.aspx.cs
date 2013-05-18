using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.fahua
{
    public partial class list : System.Web.UI.Page
    {
        public string selQuery = "SELECT [ID], [FAHUA_NO], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [EXPIRED_TIME], [ZIHAO], [ZUOCI], [ZHUZHAO4], [SHIZHU_BIANHAO],[HAS_PRINT] FROM [tbFAHUA]";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("04r"))
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
                if (!this.GetCurrentUser().hasPermission("04d"))
                {
                    GridView1.Columns[1].Visible = false;
                    SqlDataSource1.DeleteCommand = "";
                }
                if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
                {
                    string keyWord = Request.Params["key"].ToString();

                    String[] fields = { "[LOG_TIME]", "[LOG_USER]", "[FAHUI_NAME]", "[ZHUZHAO1]", "[ZHUZHAO2]", "[ZHUZHAO3]", "[ZHUZHAO4]", "[ZIHAO]", "[ZUOCI]", "[EXPIRED_TIME]", "[FAHUA_NO]","[HAS_PRINT]","[SHIZHU_BIANHAO]" };
                    selQuery = "SELECT [ID], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI],[EXPIRED_TIME],[FAHUA_NO],[HAS_PRINT],[SHIZHU_BIANHAO] FROM [tbFAHUA] WHERE (1<>1 ";
                    foreach (String field in fields)
                    {
                        selQuery += " OR " + field + " like '%" + keyWord + "%'";
                    }
                    selQuery += ")";
                    SqlDataSource1.SelectCommand = selQuery;
                }
                Session["fahua_cursql"] = selQuery;
            }
        }

        protected void Button_searchCur_Click(object sender, EventArgs e)
        {
            if (TextBox_searchText.Text.Trim() == "")
                return;
            if (Session["fahua_cursql"] != null)
                selQuery = Session["fahua_cursql"].ToString();
            if (selQuery.ToUpper().IndexOf("WHERE") > 0)
            {
                selQuery += " AND " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
            }
            else
            {
                selQuery += " WHERE " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
            }
            Session["fahua_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery;
        }

        protected void Button_searchAll_Click(object sender, EventArgs e)
        {
            if (TextBox_searchText.Text.Trim() == "")
                return;
            selQuery = "SELECT [ID], [FAHUA_NO], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [EXPIRED_TIME], [ZIHAO], [ZUOCI], [ZHUZHAO4], [SHIZHU_BIANHAO],[HAS_PRINT] FROM [tbFAHUA]";

            selQuery += " WHERE " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
            Session["fahua_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery;
        }

        protected void Button_today_Click(object sender, EventArgs e)
        {
            selQuery = "SELECT [ID], [FAHUA_NO], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [EXPIRED_TIME], [ZIHAO], [ZUOCI], [ZHUZHAO4], [SHIZHU_BIANHAO],[HAS_PRINT] FROM [tbFAHUA]";
            selQuery += " WHERE YEAR(LOG_TIME)='"+DateTime.Now.Year+"' AND MONTH(LOG_TIME)='"+
                DateTime.Now.Month+"' AND DAY(LOG_TIME)='"+DateTime.Now.Day+"'";
            Session["fahua_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery;
        }
        protected void Button_getunprint_Click(object sender, EventArgs e)
        {
            selQuery = "SELECT [ID], [FAHUA_NO], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [EXPIRED_TIME], [ZIHAO], [ZUOCI], [ZHUZHAO4], [SHIZHU_BIANHAO],[HAS_PRINT] FROM [tbFAHUA]";

            selQuery += " WHERE (HAS_PRINT = 0 OR HAS_PRINT IS NULL) ";

            SqlDataSource1.SelectCommand = selQuery;
        }
    }
}