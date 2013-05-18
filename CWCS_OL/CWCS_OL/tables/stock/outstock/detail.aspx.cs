using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.stock.outstock
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("s3r"))
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
                    DataTable dt = db.ExecuteDataTable("SELECT StockTrans.ID, StockTrans.StockId, StockTrans.BillNo, Goods.GoodsNo, Goods.Name, Goods.BarCode, Goods.Category, Goods.Specification, Goods.Unit, StockTrans.Amount, StockTrans.TotalPrice, StockTrans.FromTo, StockTrans.Manager, StockTrans.EditTime, StockTrans.Operator, StockTrans.Remark,StockTrans.RUKU_DATE,StockTrans.JIAOKUSHU,StockTrans.DANJIA,StockTrans.CAIWU,StockTrans.LIANXUHAO,StockTrans.JIZHANG,StockTrans.BAOGUAN,StockTrans.YANSHOU,StockTrans.FAPIAO FROM StockTrans INNER JOIN Goods ON StockTrans.GoodsId = Goods.ID WHERE (StockTrans.ID=@ID) AND (StockTrans.Type = 1)");
                    if (dt.Rows.Count < 1)
                    {
                        Response.Write("该记录不存在");
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    Label_StockId.Text = Server.HtmlEncode(dr[1].ToString());
                    Label_BillNo.Text = Server.HtmlEncode(dr[2].ToString());
                    Label_GoodsNo.Text = Server.HtmlEncode(dr[3].ToString());
                    Label_Name.Text = Server.HtmlEncode(dr[4].ToString());
                    Label_Specification.Text = Server.HtmlEncode(dr[7].ToString());
                    Label_Unit.Text = Server.HtmlEncode(dr[8].ToString());
                    Label_Amount.Text = Server.HtmlEncode(dr[9].ToString());
                    Label_TotalPrice.Text = Server.HtmlEncode(dr[10].ToString());
                    Label_FromTo.Text = Server.HtmlEncode(dr[11].ToString());
                    Label_Manager.Text = Server.HtmlEncode(dr[12].ToString());
                    Label_EditTime.Text = Server.HtmlEncode(dr[13].ToString());
                    Label_Operator.Text = Server.HtmlEncode(dr[14].ToString());
                    Label_Remark.Text = Server.HtmlEncode(dr[15].ToString());

                    Label_rukudate.Text = Server.HtmlEncode(dr[16].ToString());
                    Label_jiaokushu.Text = Server.HtmlEncode(dr[17].ToString());
                    Label_danjia.Text = Server.HtmlEncode(dr[18].ToString());
                    Label_caiwu.Text = Server.HtmlEncode(dr[19].ToString());
                    Label_lianxuhao.Text = Server.HtmlEncode(dr[20].ToString());
                    Label_jizhang.Text = Server.HtmlEncode(dr[21].ToString());
                    Label_baoguan.Text = Server.HtmlEncode(dr[22].ToString());
                    Label_yanshou.Text = Server.HtmlEncode(dr[23].ToString());
                    Label_fapiao.Text = Server.HtmlEncode(dr[24].ToString());
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [StockTrans] WHERE [ID]<@ID AND [Type]=1 ORDER BY [ID] DESC");
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
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [StockTrans] WHERE [ID]>@ID AND [Type]=1 ORDER BY [ID] ASC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_next.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_next.Enabled = false;
                    }
                }
                if (!this.GetCurrentUser().hasPermission("s3u"))
                {
                    Button_edit.Enabled = false;
                }
            }
        }

        protected void Button_edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx?id=" + Request.Params["id"]);
        }
    }
}