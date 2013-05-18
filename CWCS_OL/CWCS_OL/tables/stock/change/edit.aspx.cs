using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.stock.change
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("s4c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }

                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("s4u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    TextBox_StockId.Enabled = false;
                    TextBox_GoodsNo.Enabled = false;
                    TextBox_Amount.Enabled = false;
                    Button_select.Visible = false;

                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("SELECT StockTrans.ID, StockTrans.StockId, StockTrans.BillNo, Goods.GoodsNo, Goods.Name, Goods.BarCode, Goods.Category, Goods.Specification, Goods.Unit, StockTrans.Amount, StockTrans.TotalPrice, StockTrans.FromTo, StockTrans.Manager, StockTrans.EditTime, StockTrans.Operator, StockTrans.Remark FROM StockTrans INNER JOIN Goods ON StockTrans.GoodsId = Goods.ID WHERE (StockTrans.ID=@ID) AND (StockTrans.Type = 2)");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];

                        TextBox_StockId.Text = Server.HtmlEncode(dr[1].ToString());
                        TextBox_BillNo.Text = Server.HtmlEncode(dr[2].ToString());
                        TextBox_GoodsNo.Text = Server.HtmlEncode(dr[3].ToString());
                        Label_Name.Text = Server.HtmlEncode(dr[4].ToString());
                        Label_BarCode.Text = Server.HtmlEncode(dr[5].ToString());
                        Label_Unit.Text = Server.HtmlEncode(dr[8].ToString());
                        TextBox_Amount.Text = Server.HtmlEncode(dr[9].ToString());
                        TextBox_TotalPrice.Text = Server.HtmlEncode(dr[10].ToString());
                        TextBox_FromTo.Text = Server.HtmlEncode(dr[11].ToString());
                        TextBox_Manager.Text = Server.HtmlEncode(dr[12].ToString());
                        TextBox_EditTime.Text = Server.HtmlEncode(dr[13].ToString());
                        TextBox_Operator.Text = Server.HtmlEncode(dr[14].ToString());
                        TextBox_Remark.Text = Server.HtmlEncode(dr[15].ToString());
                    }
                }
            }

        }

        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("s4c"))
            {
                return "";
            }

            int iGoodsId = 0;
            double dAmount = 0.0;
            if (!Double.TryParse(TextBox_Amount.Text, out dAmount))
                return "";
            
            if (dAmount == 0.0)
                return "";

            double dTP = 0.0;
            if (!Double.TryParse(TextBox_TotalPrice.Text, out dTP))
                return "";

            using (DataBase db = new DataBase())
            {
                db.AddParameter("GoodsNo", TextBox_GoodsNo.Text);
                DataTable dt = db.ExecuteDataTable("SELECT [ID] FROM [Goods] WHERE [GoodsNo] = @GoodsNo");
                if (dt.Rows.Count < 1)
                    return "";
                iGoodsId = (int)dt.Rows[0][0];
            }

            using (DataBase db = new DataBase())
            {
                db.AddParameter("StockId", TextBox_StockId.Text);
                db.AddParameter("GoodsId", iGoodsId);
                DataTable dt = db.ExecuteDataTable("SELECT [ID] FROM [Stock] WHERE  [StockId] = @StockId AND [GoodsId] = @GoodsId");
                if (dt.Rows.Count < 1)
                {
                    db.AddParameter("StockId", TextBox_StockId.Text);
                    db.AddParameter("GoodsId", iGoodsId);
                    db.AddParameter("Amount", dAmount);
                    int iRc = db.ExecuteNonQuery("INSERT INTO [Stock]([StockId],[GoodsId],[Amount]) VALUES(@StockId, @GoodsId, @Amount)");
                    if (iRc != 1)
                        return "";
                }
                else
                {
                    db.AddParameter("ID", dt.Rows[0][0]);
                    db.AddParameter("Amount", dAmount);
                    int iRc = db.ExecuteNonQuery("UPDATE [Stock] SET [Amount]=[Amount]+@Amount WHERE [ID] = @ID");
                    if (iRc != 1)
                        return "";
                }
            }

            using (DataBase db = new DataBase())
            {
                db.AddParameter("StockId", TextBox_StockId.Text);
                db.AddParameter("GoodsId", iGoodsId);
                db.AddParameter("BillNo", TextBox_BillNo.Text);
                db.AddParameter("EditTime", DateTime.Now);
                db.AddParameter("Amount", dAmount);
                db.AddParameter("TotalPrice", TextBox_TotalPrice.Text);
                db.AddParameter("FromTo", TextBox_FromTo.Text);
                db.AddParameter("Manager", TextBox_Manager.Text);
                db.AddParameter("Operator", this.GetCurrentUser().Name);
                db.AddParameter("Remark", TextBox_Remark.Text);

                String sql;
                sql = "INSERT INTO [StockTrans] ([Type],[StockId],[GoodsId],[BillNo],[EditTime],[Amount],[TotalPrice],[FromTo],[Manager],[Operator],[Remark]) " +
                    "VALUES (2,@StockId,@GoodsId,@BillNo,@EditTime,@Amount,@TotalPrice,@FromTo,@Manager,@Operator,@Remark)";
                DataTable dt = db.ExecuteDataTable(sql + " SELECT SCOPE_IDENTITY()");
                String nid = "";
                if (dt.Rows.Count == 1)
                    nid = dt.Rows[0][0].ToString();
                return nid;
            }

        }

        protected bool SaveOld(String id)
        {
            //TODO:服务端检查
            if (!this.GetCurrentUser().hasPermission("s4u"))
            {
                return false;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("BillNo", TextBox_BillNo.Text);
                db.AddParameter("TotalPrice", TextBox_TotalPrice.Text);
                db.AddParameter("FromTo", TextBox_FromTo.Text);
                db.AddParameter("Manager", TextBox_Manager.Text);
                db.AddParameter("Operator", this.GetCurrentUser().Name);
                db.AddParameter("Remark", TextBox_Remark.Text);

                String sql;
                sql = "UPDATE [StockTrans] SET [BillNo] = @BillNo, [TotalPrice]=@TotalPrice, " +
                    "[FromTo]=@FromTo, [Manager]=@Manager, [Operator]=@Operator, " +
                    "[Remark]=@Remark WHERE [ID]=@ID";
                int rc = db.ExecuteNonQuery(sql);
                return rc == 1;
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                String nid = SaveNew();
                if (nid == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('新增时出错');</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.document.getElementById(\"list\").src=\"List.aspx\";parent.selRec(\"" + nid + "\");</script>");
                }
            }
            else
            {
                //修改
                String id = Request.Params["id"].ToString();

                if (!SaveOld(id))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存时出错');</script>");
                }
                else
                {
                    Response.Redirect("Detail.aspx?id=" + id);
                }
            }
        }

        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                String id = Request.Params["id"].ToString();
                Response.Redirect("Detail.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("Detail.aspx");
            }
        }

        protected void Button_savenext_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                //新增
                String nid = SaveNew();
                if (nid == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('新增时出错');</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.document.getElementById(\"list\").src=\"List.aspx\";parent.addNew();</script>");
                }

            }
            else
            {
                //修改
                String id = Request.Params["id"].ToString();

                if (!SaveOld(id))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存时出错');</script>");
                }
                else
                {
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"]);
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [StockTrans] WHERE [ID] > @ID AND [Type]=2 ORDER BY [ID] ASC");
                        if (dt.Rows.Count == 1)
                        {
                            Response.Redirect("Edit.aspx?id=" + dt.Rows[0][0].ToString());
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.addNew();</script>");
                        }
                    }
                }

            }

        }
    }
}