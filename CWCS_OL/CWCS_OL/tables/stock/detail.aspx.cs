using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.stock
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("s0r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    Response.Write("无当前记录");
                    Response.End();
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT Stock.StockId, Goods.GoodsNo, Goods.Name, Goods.BarCode, Goods.Category, Goods.Specification, Goods.Unit, Stock.Amount FROM Goods INNER JOIN Stock ON Goods.ID = Stock.GoodsId WHERE (Stock.ID = @ID)");
                    if (dt.Rows.Count < 1)
                    {
                        Response.Write("该记录不存在");
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    Label_StockId.Text = Server.HtmlEncode(dr[0].ToString());
                    Label_GoodsNo.Text = Server.HtmlEncode(dr[1].ToString());
                    Label_Name.Text = Server.HtmlEncode(dr[2].ToString());
                    Label_BarCode.Text = Server.HtmlEncode(dr[3].ToString());
                    Label_Category.Text = Server.HtmlEncode(dr[4].ToString());
                    Label_Specification.Text = Server.HtmlEncode(dr[5].ToString());
                    Label_Unit.Text = Server.HtmlEncode(dr[6].ToString());
                    Label_Amount.Text = Server.HtmlEncode(dr[7].ToString());
                    

                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [Stock] WHERE [ID]<@ID ORDER BY [ID] DESC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_prev.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_prev.Enabled = false;
                    }
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [Stock] WHERE [ID]>@ID ORDER BY [ID] ASC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_next.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_next.Enabled = false;
                    }
                }

            }
        }

    }
}