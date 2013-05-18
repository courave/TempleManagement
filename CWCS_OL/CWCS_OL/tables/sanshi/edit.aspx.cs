using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.sanshi
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList_isnew.Items.Add("是");
                DropDownList_isnew.Items.Add("否");
                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("03c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }

                    TextBox_expired_time.Text = System.DateTime.Now.AddYears(1).ToString();
                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                    TextBox_zihao.Text = "天";
                    TextBox_zuoci.Text = Util.GenZuoci("tbSANSHI").ToString();
                    TextBox_log_time.Text = DateTime.Now.ToString();
                    TextBox_log_user.Text = this.GetCurrentUser().Name;
                    TextBox_sanshi_no.Text = Util.GenerateBianhao("SANSHI", "tbSANSHI");
                    TextBox_shizhubianhao.Text = Util.GenerateBianhao("CWCS", "SHIZHU_INFO");
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("03u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("SELECT [ID],[SANSHI_NO], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], [JIEYIN4], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [YANGSHANG4], [YANGSHANG5], [YANGSHANG6],[EXPIRED_TIME],[SHIZHU_BIANHAO],[FANGWEI],[ROW],[COL] FROM [tbSANSHI] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];
                        TextBox_sanshi_no.Text = Server.HtmlEncode(dr[1].ToString());
                        TextBox_fahui_name.Text = Server.HtmlEncode(dr[4].ToString());
                        TextBox_zihao.Text = Server.HtmlEncode(dr[6].ToString());
                        TextBox_zuoci.Text = Server.HtmlEncode(dr[5].ToString());
                        TextBox_jieyin1.Text = Server.HtmlEncode(dr[7].ToString());
                        TextBox_jieyin2.Text = Server.HtmlEncode(dr[8].ToString());
                        TextBox_jieyin3.Text = Server.HtmlEncode(dr[9].ToString());
                        TextBox_jieyin4.Text = Server.HtmlEncode(dr[10].ToString());
                        TextBox_yangshang1.Text = Server.HtmlEncode(dr[11].ToString());
                        TextBox_yangshang2.Text = Server.HtmlEncode(dr[12].ToString());
                        TextBox_yangshang3.Text = Server.HtmlEncode(dr[13].ToString());
                        TextBox_yangshang4.Text = Server.HtmlEncode(dr[14].ToString());
                        TextBox_log_user.Text = Server.HtmlEncode(dr[2].ToString());
                        TextBox_log_time.Text = Server.HtmlEncode(dr[3].ToString());
                        TextBox_expired_time.Text = Server.HtmlEncode(dr[17].ToString());
                        TextBox_fangwei.Text = Server.HtmlEncode(dr[19].ToString());
                        TextBox_row.Text = Server.HtmlEncode(dr[20].ToString());
                        TextBox_col.Text = Server.HtmlEncode(dr[21].ToString());

                        dt = db.ExecuteDataTable("select [SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE] FROM SHIZHU_INFO WHERE SHIZHU_ID='" + dr[18].ToString() + "'");
                        if (dt.Rows.Count > 0)
                        {
                            TextBox_shizhubianhao.Text = dt.Rows[0][0].ToString();
                            TextBox_name.Text = dt.Rows[0][1].ToString();
                            TextBox_addr.Text = dt.Rows[0][2].ToString();
                            TextBox_zip.Text = dt.Rows[0][3].ToString();
                            TextBox_tel.Text = dt.Rows[0][4].ToString();
                            TextBox_mobile.Text = dt.Rows[0][5].ToString();
                            DropDownList_isnew.Text = "否";

                        }
                    }
                }
            }

        }
        protected void saveShizhuInfo()
        {
            if (DropDownList_isnew.Text == "是")
            {
                //save new shizhu info
                string sql = "INSERT INTO[SHIZHU_INFO]([SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE]) " +
                    "VALUES (@SHIZHU_ID,@SHIZHU_NAME,@SHIZHU_HOME_ADDR,@SHIZHU_HOME_ZIP,@SHIZHU_HOME_TEL,@SHIZHU_MOBILE)";
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("SHIZHU_ID", TextBox_shizhubianhao.Text);
                    db.AddParameter("SHIZHU_NAME", TextBox_name.Text);
                    db.AddParameter("SHIZHU_HOME_ADDR", TextBox_addr.Text);
                    db.AddParameter("SHIZHU_HOME_ZIP", TextBox_zip.Text);
                    db.AddParameter("SHIZHU_HOME_TEL", TextBox_tel.Text);
                    db.AddParameter("SHIZHU_MOBILE", TextBox_mobile.Text);
                    db.ExecuteNonQuery(sql);
                }
            }
            else
            {
                //do nothing
            }
        }
        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("03c"))
            {
                return "";
            }
            saveShizhuInfo();
            using (DataBase db = new DataBase())
            {
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHUI_NAME", TextBox_fahui_name.Text);
                db.AddParameter("JIEYIN1", TextBox_jieyin1.Text);
                db.AddParameter("JIEYIN2", TextBox_jieyin2.Text);
                db.AddParameter("JIEYIN3", TextBox_jieyin3.Text);
                db.AddParameter("JIEYIN4", TextBox_jieyin4.Text);
                db.AddParameter("YANGSHANG1", TextBox_yangshang1.Text);
                db.AddParameter("YANGSHANG2", TextBox_yangshang2.Text);
                db.AddParameter("YANGSHANG3", TextBox_yangshang3.Text);
                db.AddParameter("YANGSHANG4", TextBox_yangshang4.Text);
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", TextBox_zihao.Text);
                db.AddParameter("SHIZHU_BIANHAO", TextBox_shizhubianhao.Text);
                db.AddParameter("SANSHI_NO", TextBox_sanshi_no.Text);
                db.AddParameter("EXPIRED_TIME", TextBox_expired_time.Text);
                db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                db.AddParameter("ROW", TextBox_row.Text);
                db.AddParameter("COL", TextBox_col.Text);
                String sql;
                sql = "INSERT INTO [tbSANSHI] ([SANSHI_NO],[EXPIRED_TIME],[LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], "+
                    "[ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], [JIEYIN4], [YANGSHANG1], [YANGSHANG2],"+
                    " [YANGSHANG3], [YANGSHANG4],[SHIZHU_BIANHAO],[FANGWEI],[ROW],[COL]) VALUES (@SANSHI_NO,@EXPIRED_TIME,@LOG_USER, " +
                    "@LOG_TIME, @FAHUI_NAME, @ZUOCI, @ZIHAO, @JIEYIN1, @JIEYIN2, @JIEYIN3, @JIEYIN4, "+
                    "@YANGSHANG1, @YANGSHANG2, @YANGSHANG3, @YANGSHANG4,@SHIZHU_BIANHAO,@FANGWEI,@ROW,@COL)";
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
            saveShizhuInfo();
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", id);
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHUI_NAME", TextBox_fahui_name.Text);
                db.AddParameter("JIEYIN1", TextBox_jieyin1.Text);
                db.AddParameter("JIEYIN2", TextBox_jieyin2.Text);
                db.AddParameter("JIEYIN3", TextBox_jieyin3.Text);
                db.AddParameter("JIEYIN4", TextBox_jieyin4.Text);
                db.AddParameter("YANGSHANG1", TextBox_yangshang1.Text);
                db.AddParameter("YANGSHANG2", TextBox_yangshang2.Text);
                db.AddParameter("YANGSHANG3", TextBox_yangshang3.Text);
                db.AddParameter("YANGSHANG4", TextBox_yangshang4.Text);
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", TextBox_zihao.Text);
                db.AddParameter("SANSHI_NO", TextBox_sanshi_no.Text);
                db.AddParameter("EXPIRED_TIME", TextBox_expired_time.Text);
                db.AddParameter("SHIZHU_BIANHAO", TextBox_shizhubianhao.Text);
                db.AddParameter("FANGWEI", TextBox_fangwei.Text);
                db.AddParameter("ROW", TextBox_row.Text);
                db.AddParameter("COL", TextBox_col.Text);
                String sql;
                sql = "UPDATE [tbSANSHI] SET [LOG_TIME] = @LOG_TIME, [LOG_USER]=@LOG_USER, " +
                    "[FAHUI_NAME]=@FAHUI_NAME, [JIEYIN1]=@JIEYIN1, [JIEYIN2]=@JIEYIN2, SHIZHU_BIANHAO=@SHIZHU_BIANHAO, " +
                    "[JIEYIN3]=@JIEYIN3, [JIEYIN4]=@JIEYIN4, [YANGSHANG1]=@YANGSHANG1, [FANGWEI]=@FANGWEI,[ROW]=@ROW,[COL]=@COL,"+
                    "[YANGSHANG2]=@YANGSHANG2, [YANGSHANG3]=@YANGSHANG3, [YANGSHANG4]=@YANGSHANG4, " +
                    " [ZUOCI]=@ZUOCI, [ZIHAO]=@ZIHAO,[SANSHI_NO]=@SANSHI_NO,[EXPIRED_TIME]=@EXPIRED_TIME WHERE [ID]=@ID";
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
        protected void DropDownList_isnew_TextChanged(object sender, EventArgs e)
        {
            if (DropDownList_isnew.Text == "是")
            {
                TextBox_addr.ReadOnly = false;
                TextBox_mobile.ReadOnly = false;
                TextBox_tel.ReadOnly = false;
                TextBox_zip.ReadOnly = false;

                TextBox_addr.BackColor = System.Drawing.Color.White;
                TextBox_mobile.BackColor = System.Drawing.Color.White;
                TextBox_tel.BackColor = System.Drawing.Color.White;
                TextBox_zip.BackColor = System.Drawing.Color.White;
            }
            else
            {
                TextBox_addr.ReadOnly = true;
                TextBox_mobile.ReadOnly = true;
                TextBox_tel.ReadOnly = true;
                TextBox_zip.ReadOnly = true;

                TextBox_addr.BackColor = System.Drawing.Color.Gray;
                TextBox_mobile.BackColor = System.Drawing.Color.Gray;
                TextBox_tel.BackColor = System.Drawing.Color.Gray;
                TextBox_zip.BackColor = System.Drawing.Color.Gray;
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbSANSHI] WHERE [ID] > @ID ORDER BY [ID] ASC");
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

        protected void Button_Extend_Click(object sender, EventArgs e)
        {
            DateTime expiredDate = new DateTime();
            expiredDate = DateTime.Now;
            DateTime.TryParse(TextBox_expired_time.Text, out expiredDate);
            expiredDate=expiredDate.AddYears(1);
            TextBox_expired_time.Text = expiredDate.ToShortDateString();
        }
    }
}