using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.sanshi
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
                        String sql = "select [fangwei],[rows],[cols] from [SANSHI_TYPE] where [id]="+Request.Params["id"];
                        DataTable dt = db.ExecuteDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            TextBox_fangwei.Text = dt.Rows[0][0].ToString();
                            TextBox_rows.Text = dt.Rows[0][1].ToString();
                            TextBox_cols.Text = dt.Rows[0][2].ToString();

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
                    sql = "INSERT INTO [SANSHI_TYPE] ([FANGWEI],[ROWS],[COLS]) VALUES (@FANGWEI,@ROWS,@COLS)";

                    db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                    db.AddParameter("ROWS", TextBox_rows.Text);
                    db.AddParameter("COLS", TextBox_cols.Text.Replace("，",","));
                    db.ExecuteNonQuery(sql);
                }
                else
                {
                    sql = "UPDATE [SANSHI_TYPE] " +
                        "   SET [FANGWEI] = @FANGWEI "+
                        "      ,[ROWS] = @ROWS "+
                        "      ,[COLS] = @COLS "+
                        " WHERE [ID]="+Request.Params["id"];
                    db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                    db.AddParameter("ROWS", TextBox_rows.Text);
                    db.AddParameter("COLS", TextBox_cols.Text.Replace("，", ","));
                    db.ExecuteNonQuery(sql);
                }
            }
        }
    }
}