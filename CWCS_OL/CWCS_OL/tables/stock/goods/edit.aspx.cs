using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.stock.goods
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("s1c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }

                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("s1u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("SELECT [ID], [GoodsNo], [Name], [BarCode], [Category], [Specification], [Unit], [Remark] FROM [Goods] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];

                        TextBox_GoodsNo.Text = Server.HtmlEncode(dr[1].ToString());
                        TextBox_Name.Text = Server.HtmlEncode(dr[2].ToString());
                        TextBox_BarCode.Text = Server.HtmlEncode(dr[3].ToString());
                        TextBox_Category.Text = Server.HtmlEncode(dr[4].ToString());
                        TextBox_Specification.Text = Server.HtmlEncode(dr[5].ToString());
                        TextBox_Unit.Text = Server.HtmlEncode(dr[6].ToString());
                        TextBox_Remark.Text = Server.HtmlEncode(dr[7].ToString());
                    }
                }
            }

        }

        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("s1c"))
            {
                return "";
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("GoodsNo", TextBox_GoodsNo.Text);
                db.AddParameter("Name", TextBox_Name.Text);
                db.AddParameter("BarCode", TextBox_BarCode.Text);
                db.AddParameter("Category", TextBox_Category.Text);
                db.AddParameter("Specification", TextBox_Specification.Text);
                db.AddParameter("Unit", TextBox_Unit.Text);
                db.AddParameter("Remark", TextBox_Remark.Text);
                String sql;
                sql = "INSERT INTO [Goods] ([GoodsNo], [Name], [BarCode], [Category], [Specification], [Unit], [Remark]) "+
                    "VALUES (@GoodsNo, @Name, @BarCode, @Category, @Specification, @Unit, @Remark)";
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
            if (!this.GetCurrentUser().hasPermission("s1u"))
            {
                return false;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("GoodsNo", TextBox_GoodsNo.Text);
                db.AddParameter("Name", TextBox_Name.Text);
                db.AddParameter("BarCode", TextBox_BarCode.Text);
                db.AddParameter("Category", TextBox_Category.Text);
                db.AddParameter("Specification", TextBox_Specification.Text);
                db.AddParameter("Unit", TextBox_Unit.Text);
                db.AddParameter("Remark", TextBox_Remark.Text);
                String sql;
                sql = "UPDATE [Goods] SET [GoodsNo] = @GoodsNo, [Name]=@Name, " +
                    "[BarCode]=@BarCode, [Category]=@Category, [Specification]=@Specification, " +
                    "[Unit]=@Unit, [Remark]=@Remark WHERE [ID]=@ID";
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [Goods] WHERE [ID] > @ID ORDER BY [ID] ASC");
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