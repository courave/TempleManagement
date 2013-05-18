using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.fahua
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList_zihao.Items.Add("天");
                DropDownList_zihao.Items.Add("地");
                DropDownList_zihao.Items.Add("玄");
                DropDownList_zihao.Items.Add("黄");
                DropDownList_zihao.Items.Add("宇");
                DropDownList_zihao.Items.Add("宙");
                DropDownList_zihao.Items.Add("洪");
                DropDownList_zihao.Items.Add("荒");
                DropDownList_isnew.Items.Add("是");
                DropDownList_isnew.Items.Add("否");

                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("04c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }

                    TextBox_expired_time.Text = System.DateTime.Now.AddYears(1).ToString();

                    TextBox_fahua_no.Text = Util.GenerateBianhao("FAHUA","tbFAHUA").ToString();
                    TextBox_zuoci.Text = Util.GenZuoci("tbFAHUA").ToString();
                    TextBox_log_time.Text = DateTime.Now.ToString();
                    TextBox_log_user.Text = this.GetCurrentUser().Name;
                    TextBox_shizhubianhao.Text = Util.GenerateBianhao("CWCS", "SHIZHU_INFO");
                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("04u"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt= db.ExecuteDataTable("SELECT [ID],[LOG_TIME],[LOG_USER],[FAHUI_NAME],[ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO],[FAHUA_NO],[EXPIRED_TIME],[SHIZHU_BIANHAO] FROM [tbFAHUA] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];
                        
                        TextBox_fahui_name.Text = Server.HtmlEncode(dr[3].ToString());
                        DropDownList_zihao.Text = Server.HtmlEncode(dr[9].ToString());
                        TextBox_zuoci.Text = Server.HtmlEncode(dr[8].ToString());
                        TextBox_zhuzhao1.Text = Server.HtmlEncode(dr[4].ToString());
                        TextBox_zhuzhao2.Text = Server.HtmlEncode(dr[5].ToString());
                        TextBox_zhuzhao3.Text = Server.HtmlEncode(dr[6].ToString());
                        TextBox_zhuzhao4.Text = Server.HtmlEncode(dr[7].ToString());
                        TextBox_log_user.Text = Server.HtmlEncode(dr[2].ToString());
                        TextBox_log_time.Text = Server.HtmlEncode(dr[1].ToString());

                        TextBox_fahua_no.Text = Server.HtmlEncode(dr[10].ToString());
                        TextBox_expired_time.Text = Server.HtmlEncode(dr[11].ToString());
                        //12
                        dt = db.ExecuteDataTable("select [SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE] FROM SHIZHU_INFO WHERE SHIZHU_ID='" + dr[12].ToString()+"'");
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

        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("04c"))
            {
                return "";
            }
            saveShizhuInfo();
            using (DataBase db = new DataBase())
            {
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("FAHUI_NAME", TextBox_fahui_name.Text);
                db.AddParameter("ZHUZHAO1", TextBox_zhuzhao1.Text);
                db.AddParameter("ZHUZHAO2", TextBox_zhuzhao2.Text);
                db.AddParameter("ZHUZHAO3", TextBox_zhuzhao3.Text);
                db.AddParameter("ZHUZHAO4", TextBox_zhuzhao4.Text);
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", DropDownList_zihao.Text);
                db.AddParameter("FAHUA_NO", TextBox_fahua_no.Text);
                db.AddParameter("EXPIRED_TIME", TextBox_expired_time.Text);
                db.AddParameter("SHIZHU_BIANHAO", TextBox_shizhubianhao.Text);

                String sql;
                sql = "INSERT INTO [tbFAHUA] ([FAHUA_NO],[EXPIRED_TIME],[LOG_TIME],[LOG_USER],[FAHUI_NAME],[ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO],[SHIZHU_BIANHAO]) VALUES (@FAHUA_NO,@EXPIRED_TIME,@LOG_TIME,@LOG_USER,@FAHUI_NAME,@ZHUZHAO1,@ZHUZHAO2,@ZHUZHAO3,@ZHUZHAO4,@ZUOCI,@ZIHAO,@SHIZHU_BIANHAO)";
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
            if (!this.GetCurrentUser().hasPermission("04u"))
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
                db.AddParameter("ZHUZHAO1", TextBox_zhuzhao1.Text);
                db.AddParameter("ZHUZHAO2", TextBox_zhuzhao2.Text);
                db.AddParameter("ZHUZHAO3", TextBox_zhuzhao3.Text);
                db.AddParameter("ZHUZHAO4", TextBox_zhuzhao4.Text);
                db.AddParameter("ZUOCI", TextBox_zuoci.Text);
                db.AddParameter("ZIHAO", DropDownList_zihao.Text);
                db.AddParameter("FAHUA_NO", TextBox_fahua_no.Text);
                db.AddParameter("EXPIRED_TIME", TextBox_expired_time.Text);
                db.AddParameter("SHIZHU_BIANHAO", TextBox_shizhubianhao.Text);
                String sql;
                sql = "UPDATE [tbFAHUA] SET [FAHUA_NO]=@FAHUA_NO,[EXPIRED_TIME]=@EXPIRED_TIME,[LOG_TIME] = @LOG_TIME, [LOG_USER]=@LOG_USER, " +
                    "[FAHUI_NAME]=@FAHUI_NAME, [ZHUZHAO1]=@ZHUZHAO1, [ZHUZHAO2]=@ZHUZHAO2, "+
                    "[ZHUZHAO3]=@ZHUZHAO3, [ZHUZHAO4]=@ZHUZHAO4, [ZUOCI]=@ZUOCI, [ZIHAO]=@ZIHAO,[SHIZHU_BIANHAO]=@SHIZHU_BIANHAO WHERE [ID]=@ID";
                int rc = db.ExecuteNonQuery(sql);
                return rc == 1;
            }
        }
        protected void saveShizhuInfo()
        {
            if (DropDownList_isnew.Text == "是")
            {
                //save new shizhu info
                string sql = "INSERT INTO[SHIZHU_INFO]([SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE]) "+
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [tbFAHUA] WHERE [ID] > @ID ORDER BY [ID] ASC");
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

        protected void Button_Extend_Click(object sender, EventArgs e)
        {
            DateTime expiredDate = new DateTime();
            expiredDate = DateTime.Now;
            DateTime.TryParse(TextBox_expired_time.Text, out expiredDate);
            expiredDate = expiredDate.AddYears(1);
            TextBox_expired_time.Text = expiredDate.ToShortDateString();
        }
    }
}