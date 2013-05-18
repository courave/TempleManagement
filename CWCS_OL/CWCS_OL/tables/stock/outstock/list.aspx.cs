using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.stock.outstock
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("s3r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            //if (!this.GetCurrentUser().hasPermission("s2d"))
            //{
            //    GridView1.Columns[1].Visible = false;
            //    SqlDataSource1.DeleteCommand = "";
            //}
            if (Request.Params["key"] != null && Request.Params["key"].ToString() != "")
            {
                string keyWord = Request.Params["key"].ToString();

                String[] fields = { "StockTrans.StockId", "StockTrans.BillNo", "StockTrans.EditTime", "StockTrans.Amount", "StockTrans.TotalPrice", "StockTrans.FromTo", "StockTrans.Manager", "StockTrans.Operator", "StockTrans.Remark", "Goods.GoodsNo", "Goods.BarCode", "Goods.Name", "Goods.Unit" };
                String sql = "SELECT StockTrans.ID, StockTrans.StockId, StockTrans.BillNo, StockTrans.EditTime, StockTrans.Amount, StockTrans.TotalPrice, StockTrans.FromTo, StockTrans.Manager, StockTrans.Operator, StockTrans.Remark, Goods.GoodsNo, Goods.BarCode, Goods.Name, Goods.Unit FROM StockTrans INNER JOIN Goods ON StockTrans.GoodsId = Goods.ID WHERE (StockTrans.Type = 1) AND (1<>1 ";
                foreach (String field in fields)
                {
                    sql += " OR " + field + " like '%" + keyWord + "%'";
                }
                SqlDataSource1.SelectCommand = sql + ")";
            }
        }
    }
}