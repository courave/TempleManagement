using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.stock
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("s0r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
            {
                string keyWord = Request.Params["key"].ToString();

                String[] fields = { "Stock.ID", "Stock.StockId", "Goods.GoodsNo", "Goods.Name", "Goods.BarCode", "Goods.Unit", "Stock.Amount" };
                String sql = "SELECT Stock.ID, Stock.StockId, Goods.GoodsNo, Goods.Name, Goods.BarCode, Goods.Unit, Stock.Amount FROM Goods INNER JOIN Stock ON Goods.ID = Stock.GoodsId WHERE 1<>1 ";
                foreach (String field in fields)
                {
                    sql += " OR " + field + " like '%" + keyWord + "%'";
                }
                SqlDataSource1.SelectCommand = sql;
            }
        }
    }
}