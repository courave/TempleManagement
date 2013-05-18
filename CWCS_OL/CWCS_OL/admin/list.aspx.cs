using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.admin
{
    public partial class list : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("00r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }

            if (!this.GetCurrentUser().hasPermission("00d"))
            {
                GridView1.Columns[1].Visible = false;
                SqlDataSource1.DeleteCommand = "";
            }
            LinkButton_clear.Visible = false;
        }

        protected void LinkButton_search_Click(object sender, EventArgs e)
        {
            if (TextBox_search.Text.ToString().Trim() == "")
                return;
            string[] se = { "USERNAME" };
            string sql = "select * from ADMIN where 1=2 ";
            foreach (string str in se)
            {
                sql += " or " + str + " like '%" + TextBox_search.Text + "%'";
            }
            DataBase db = new DataBase();
            DataTable dt = db.ExecuteDataTable(sql);
            db.Dispose();
            if (dt.Rows.Count < 1)
                return;
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataSourceID = null;
                GridView1.DataBind();
            }
            LinkButton_clear.Visible = true;
                
        }

        protected void LinkButton_clear_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
            LinkButton_clear.Visible = false;
            TextBox_search.Text = "";
        }
    }
}