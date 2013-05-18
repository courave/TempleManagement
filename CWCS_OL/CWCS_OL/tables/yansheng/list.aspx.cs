using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.yansheng
{
    public partial class list : System.Web.UI.Page
    {
        public string selQuery = "SELECT [ID], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI],[HAS_PRINT] FROM [tbYANSHENG]";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.GetCurrentUser().hasPermission("01r"))
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

                if (!this.GetCurrentUser().hasPermission("01d"))
                {
                    GridView1.Columns[1].Visible = false;
                    SqlDataSource1.DeleteCommand = "";
                }
                if (Request.Params["fahui"] != null)
                {
                    selQuery = "SELECT [ID], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI],[HAS_PRINT] FROM [tbYANSHENG]"
                        + " WHERE FAHUI_NAME LIKE '%" + Request.Params["fahui"].ToString() + "%'"+
                        "AND YEAR(LOG_TIME)="+Request.Params["year"]+" ";
                    SqlDataSource1.SelectCommand = selQuery + " ORDER BY ZUOCI";
                }
                if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
                {
                    string keyWord = Request.Params["key"].ToString();

                    String[] fields = { "[LOG_TIME]", "[LOG_USER]", "[FAHUI_NAME]", "[ZHUZHAO1]", "[ZHUZHAO2]", "[ZHUZHAO3]", "[ZHUZHAO4]", "[ZIHAO]", "[ZUOCI]","[HAS_PRINT]" };
                    selQuery = "SELECT [ID], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI],[HAS_PRINT] FROM [tbYANSHENG] WHERE (1<>1 ";
                    foreach (String field in fields)
                    {
                        selQuery += " OR " + field + " like '%" + keyWord + "%'";
                    }
                    selQuery += ")";
                    SqlDataSource1.SelectCommand = selQuery + " ORDER BY ZUOCI";
                }
                Session["yansheng_cursql"] = selQuery;

            }
        }

        protected void Button_searchCur_Click(object sender, EventArgs e)
        {
            selQuery = Session["yansheng_cursql"].ToString();
            if (TextBox_searchText.Text.Trim() == "")
                return;
            if (DropDownList_col.SelectedValue == "ZUOCI")
            {
                string searchText = TextBox_searchText.Text.Replace("，", ",");
                if (searchText.IndexOf(",") >= 0)
                {
                    //do spit stuff
                    string[] ss = searchText.Split(',');
                    if (ss.Length == 2)
                    {
                        if (selQuery.ToUpper().IndexOf("WHERE") > 0)
                        {
                            selQuery += " AND " + DropDownList_col.SelectedValue + " between " + ss[0].ToString() + " AND " + ss[1].ToString() + " ";
                        }
                        else
                        {
                            selQuery += " WHERE " + DropDownList_col.SelectedValue + " between " + ss[0].ToString() + " AND " + ss[1].ToString() + " ";
                        }
                    }
                    else
                    {
                        if (selQuery.ToUpper().IndexOf("WHERE") > 0)
                        {
                            selQuery += " AND " + DropDownList_col.SelectedValue + " = '" + TextBox_searchText.Text.Trim() + "' ";
                        }
                        else
                        {
                            selQuery += " WHERE " + DropDownList_col.SelectedValue + " = '" + TextBox_searchText.Text.Trim() + "' ";
                        }
                    }
                }
                else
                {
                    if (selQuery.ToUpper().IndexOf("WHERE") > 0)
                    {
                        selQuery += " AND " + DropDownList_col.SelectedValue + " = " + TextBox_searchText.Text.Trim() + " ";
                    }
                    else
                    {
                        selQuery += " WHERE " + DropDownList_col.SelectedValue + " = " + TextBox_searchText.Text.Trim() + " ";
                    }
                }
            }
            else
            {
                if (selQuery.ToUpper().IndexOf("WHERE") > 0)
                {
                    selQuery += " AND " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
                }
                else
                {
                    selQuery += " WHERE " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
                }
            }

            Session["yansheng_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery + " ORDER BY ZUOCI";
        }

        protected void Button_searchAll_Click(object sender, EventArgs e)
        {
            if (TextBox_searchText.Text.Trim() == "")
                return;
            selQuery = "SELECT [ID], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI],[HAS_PRINT] FROM [tbYANSHENG]";

            selQuery += " WHERE " + DropDownList_col.SelectedValue + " like '%" + TextBox_searchText.Text.Trim() + "%' ";
            Session["yansheng_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery + " ORDER BY ZUOCI";
        }

        protected void Button_getunprint_Click(object sender, EventArgs e)
        {
            selQuery = "SELECT [ID], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI],[HAS_PRINT] FROM [tbYANSHENG]";

            selQuery += " WHERE (HAS_PRINT = 0 OR HAS_PRINT IS NULL) ";
            Session["yansheng_cursql"] = selQuery;
            SqlDataSource1.SelectCommand = selQuery + " ORDER BY ZUOCI";
        }

    }
}