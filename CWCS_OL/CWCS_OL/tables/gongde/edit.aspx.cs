using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.gongde
{
    public partial class edit : System.Web.UI.Page
    {
        public string strFangwei = "请选择...";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DataBase db = new DataBase())
                {
                    String sql = "select distinct [type] from [gongde_type]";
                    DataTable dt = db.ExecuteDataTable(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DropDownList_type.Items.Add(dr[0].ToString());
                    }
                }
                if (Request.Params["ID"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("06c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                    Button_save.Enabled = false;
                    Button_savenext.Enabled = false;
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("06u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("select a.SHIZHU_ID,a.SHIZHU_NAME,a.SHIZHU_SEX,a.SHIZHU_TYPE, "+
                                        "a.SHIZHU_HOME_ADDR,a.SHIZHU_HOME_ZIP,a.SHIZHU_HOME_TEL,a.SHIZHU_MOBILE, "+
                                        "a.SHIZHU_EMAIL,a.SHIZHU_BIRTH_TYPE,a.SHIZHU_BIRTHDAY,a.SHIZHU_LUNAR_DAY, "+
                                        "a.SHIZHU_TUIXIN,b.DONATE_NO,b.DONATE_TYPE,b.DONATE_MONEY,b.INVOICE_NO, "+
                                        "b.DONATE_DATE,b.LOG_USER,b.LOG_TIME,b.GONGDE_FANGMING,DONATE_DESCRIPTION, "+
                                        "b.DONATE_COMMENTS,b.FANGWEI,b.ROW,b.COL from SHIZHU_INFO a,SHIZHU_GONGDE b WHERE a.SHIZHU_ID=b.SHIZHU_ID "+
                                        "AND b.ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        
                        DataRow dr = dt.Rows[0];
                        strFangwei = dr[23].ToString() + " " + dr[24].ToString() + "," + dr[25].ToString();
                        TextBox_id.Text = Server.HtmlEncode(dr[0].ToString());
                        TextBox_name.Text = Server.HtmlEncode(dr[1].ToString());
                        Label_sex.Text = Server.HtmlEncode(dr[2].ToString());
                        Label_addr.Text = Server.HtmlEncode(dr[4].ToString());
                        Label_zip.Text = Server.HtmlEncode(dr[5].ToString());
                        Label_tel.Text = Server.HtmlEncode(dr[6].ToString());
                        Label_mobile.Text = Server.HtmlEncode(dr[7].ToString());
                        Label_type.Text = Server.HtmlEncode(dr[3].ToString());
                        Label_email.Text = Server.HtmlEncode(dr[8].ToString());
                        
                        Label_birthday.Text = Server.HtmlEncode(dr[10].ToString());
                        Label_birth_type.Text = Server.HtmlEncode(dr[9].ToString());
                        Label_lunar_date.Text = Server.HtmlEncode(dr[11].ToString());
                        Label_tuixin.Text = Server.HtmlEncode(dr[12].ToString());

                        TextBox_donate_no.Text = Server.HtmlEncode(dr[13].ToString());
                        DropDownList_type.Text = Server.HtmlEncode(dr[14].ToString());
                        TextBox_donate_money.Text = Server.HtmlEncode(dr[15].ToString());
                        TextBox_invoice_no.Text = Server.HtmlEncode(dr[16].ToString());
                        TextBox_donate_date.Text = Server.HtmlEncode(dr[17].ToString());
                        TextBox_log_user.Text = Server.HtmlEncode(dr[18].ToString());
                        TextBox_log_time.Text = Server.HtmlEncode(dr[19].ToString());
                        TextBox_gongde_fangming.Text = Server.HtmlEncode(dr[20].ToString());
                        TextBox_donate_description.Text = Server.HtmlEncode(dr[21].ToString());
                        TextBox_donate_comments.Text = Server.HtmlEncode(dr[22].ToString());
                        TextBox_fangwei.Text = Server.HtmlEncode(dr[23].ToString());
                        TextBox_row.Text = Server.HtmlEncode(dr[24].ToString());
                        TextBox_col.Text = Server.HtmlEncode(dr[25].ToString());

                    }
                }
            }
        }
        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("06c"))
            {
                return "";
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("SHIZHU_ID", TextBox_id.Text);
                db.AddParameter("DONATE_NO", TextBox_donate_no.Text);
                db.AddParameter("DONATE_TYPE", DropDownList_type.Text);
                db.AddParameter("DONATE_MONEY", TextBox_donate_money.Text);
                db.AddParameter("INVOICE_NO", TextBox_invoice_no.Text);
                db.AddParameter("DONATE_DATE", TextBox_donate_date.Text);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("GONGDE_FANGMING", TextBox_gongde_fangming.Text);
                db.AddParameter("DONATE_DESCRIPTION", TextBox_donate_description.Text);
                db.AddParameter("DONATE_COMMENTS", TextBox_donate_comments.Text);
                db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                db.AddParameter("ROW", TextBox_row.Text);
                db.AddParameter("COL", TextBox_col.Text);
                String sql;
                sql = "INSERT INTO [SHIZHU_GONGDE] "+
                     "([DONATE_NO] ,[DONATE_TYPE] ,[DONATE_MONEY] ,[INVOICE_NO] "+
                     ",[DONATE_DATE] ,[LOG_USER] ,[LOG_TIME] ,[GONGDE_FANGMING] "+
                     ",[DONATE_DESCRIPTION] ,[DONATE_COMMENTS] ,[SHIZHU_ID],[FANGWEI],[ROW],[COL]) "+
                     "VALUES (@DONATE_NO ,@DONATE_TYPE ,@DONATE_MONEY ,@INVOICE_NO "+
                     ",@DONATE_DATE ,@LOG_USER ,@LOG_TIME ,@GONGDE_FANGMING "+
                     ",@DONATE_DESCRIPTION ,@DONATE_COMMENTS ,@SHIZHU_ID,@FANGWEI,@ROW,@COL)";
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
            if (!this.GetCurrentUser().hasPermission("03u"))
            {
                return false;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("SHIZHU_ID", TextBox_id.Text);
                db.AddParameter("DONATE_NO", TextBox_donate_no.Text);
                db.AddParameter("DONATE_TYPE", DropDownList_type.Text);
                db.AddParameter("DONATE_MONEY", TextBox_donate_money.Text);
                db.AddParameter("INVOICE_NO", TextBox_invoice_no.Text);
                db.AddParameter("DONATE_DATE", TextBox_donate_date.Text);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("GONGDE_FANGMING", TextBox_gongde_fangming.Text);
                db.AddParameter("DONATE_DESCRIPTION", TextBox_donate_description.Text);
                db.AddParameter("DONATE_COMMENTS", TextBox_donate_comments.Text);
                db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                db.AddParameter("ROW", TextBox_row.Text);
                db.AddParameter("COL", TextBox_col.Text);
                String sql;
                sql = "UPDATE [SHIZHU_GONGDE] "+
 "  SET [DONATE_NO] = @DONATE_NO " +
 "     ,[DONATE_TYPE] = @DONATE_TYPE "+
 "     ,[DONATE_MONEY] = @DONATE_MONEY "+
 "     ,[INVOICE_NO] = @INVOICE_NO "+
 "     ,[DONATE_DATE] = @DONATE_DATE "+
 "     ,[LOG_USER] = @LOG_USER "+
"      ,[LOG_TIME] = @LOG_TIME "+
 "     ,[GONGDE_FANGMING] = @GONGDE_FANGMING "+
 "     ,[DONATE_DESCRIPTION] = @DONATE_DESCRIPTION "+
 "     ,[DONATE_COMMENTS] = @DONATE_COMMENTS "+
 "     ,[SHIZHU_ID] = @SHIZHU_ID "+
 "     ,[FANGWEI] = @FANGWEI " +
 "     ,[ROW] = @ROW " +
 "     ,[COL] = @COL " +
 "WHERE ID=@ID";
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [SHIZHU_GONGDE] WHERE [ID] > @ID ORDER BY [ID] ASC");
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