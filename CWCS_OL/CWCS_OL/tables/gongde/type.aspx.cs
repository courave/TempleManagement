using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.gongde
{
    public partial class type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] != null)
                {
                    using (DataBase db = new DataBase())
                    {
                        String sql = "select [type],[fangwei],[rows],[cols] from [gongde_type] where [id]="+Request.Params["id"];
                        DataTable dt = db.ExecuteDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            TextBox_type.Text = dt.Rows[0][0].ToString();
                            TextBox_fangwei.Text = dt.Rows[0][1].ToString();
                            TextBox_rows.Text = dt.Rows[0][2].ToString();
                            TextBox_cols.Text = dt.Rows[0][3].ToString();

                        }
                        else
                        {
                            Response.Write("无该条记录");
                            Response.End();
                        }
                    }
                }
                else
                {
                }
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                String sql;
                if (Request.Params["id"] == null)
                {
                    sql = "INSERT INTO [GONGDE_TYPE] ([TYPE],[FANGWEI],[ROWS],[COLS]) VALUES (@TYPE,@FANGWEI,@ROWS,@COLS)";
                    db.AddParameter("TYPE", TextBox_type.Text);
                    db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                    db.AddParameter("ROWS", TextBox_rows.Text);
                    db.AddParameter("COLS", TextBox_cols.Text);
                    if (db.ExecuteNonQuery(sql) == 1)
                    {
                        Response.Write("<script>alert('新增成功');</script>");
                        Response.Redirect("type.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('新增失败');</script>");
                    }
                }
                else
                {
                    sql = "UPDATE [GONGDE_TYPE] "+
                        "   SET [TYPE] = @TYPE "+
                        "      ,[FANGWEI] = @FANGWEI "+
                        "      ,[ROWS] = @ROWS "+
                        "      ,[COLS] = @COLS "+
                        " WHERE [ID]="+Request.Params["id"];
                    db.AddParameter("TYPE", TextBox_type.Text);
                    db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                    db.AddParameter("ROWS", TextBox_rows.Text);
                    db.AddParameter("COLS", TextBox_cols.Text);
                    if (db.ExecuteNonQuery(sql) == 1)
                    {
                        Response.Write("<script>alert('更新成功');</script>");
                        Response.Redirect("type.aspx?id=" + Request.Params["id"]);
                    }
                    else
                    {
                        Response.Write("<script>alert('更新失败');</script>");
                    }
                }
            }
        }
    }
}