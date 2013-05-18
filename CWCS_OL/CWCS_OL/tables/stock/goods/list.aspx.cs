using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.stock.goods
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("s1r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!this.GetCurrentUser().hasPermission("s1d"))
            {
                GridView1.Columns[2].Visible = false;
                //SqlDataSource1.DeleteCommand = "";
            }
            if (Request.Params["sel"] != null)
            {
                GridView1.Columns[0].Visible = false;
                GridView1.Columns[2].Visible = false;
            }
            else
            {
                GridView1.Columns[1].Visible = false;
            }
            if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
            {
                string keyWord = Request.Params["key"].ToString();

                String[] fields = { "[GoodsNo]", "[Name]", "[BarCode]", "[Category]", "[Specification]", "[Unit]", "[Remark]" };
                String sql = "SELECT [ID], [GoodsNo], [Name], [BarCode], [Category], [Specification], [Unit], [Remark] FROM [Goods] WHERE 1<>1 ";
                foreach (String field in fields)
                {
                    sql += " OR " + field + " like '%" + keyWord + "%'";
                }
                SqlDataSource1.SelectCommand = sql;
            }
        }
    }
}