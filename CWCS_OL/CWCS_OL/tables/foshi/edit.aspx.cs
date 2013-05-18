using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.foshi
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("08c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }

                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                        db.AddParameter("LOG_TIME", DateTime.Now);
                        DataTable dt = db.ExecuteDataTable("INSERT INTO [tbFOSHI]([LOG_USER] ,[LOG_TIME]) VALUES (@LOG_USER,@LOG_TIME) SELECT SCOPE_IDENTITY()");
                        if (dt.Rows.Count == 1)
                            hf_id.Value = dt.Rows[0][0].ToString();
                        else
                            Response.End();
                    }
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("08u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    hf_id.Value = Request.Params["id"];
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", hf_id.Value);
                        DataTable dt = db.ExecuteDataTable("SELECT [ZHAIZHU_NAME], [FOSHI_DATETIME], [JIESONG_ADDR], [TEL], [COMMENT] FROM [tbFOSHI] WHERE [ID]=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];
                        TextBox_ZHAIZHU_NAME.Text = Server.HtmlEncode(dr[0].ToString());
                        TextBox_FOSHI_DATETIME.Text = Server.HtmlEncode(dr[1].ToString());
                        TextBox_JIESONG_ADDR.Text = Server.HtmlEncode(dr[2].ToString());
                        TextBox_TEL.Text = Server.HtmlEncode(dr[3].ToString());
                        TextBox_COMMENT.Text = Server.HtmlEncode(dr[4].ToString());
                    }
                }
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("08u"))
            {
                return;
            }
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", hf_id.Value);
                db.AddParameter("ZHAIZHU_NAME", TextBox_ZHAIZHU_NAME.Text);
                db.AddParameter("FOSHI_DATETIME", TextBox_FOSHI_DATETIME.Text);
                db.AddParameter("JIESONG_ADDR", TextBox_JIESONG_ADDR.Text);
                db.AddParameter("TEL", TextBox_TEL.Text);
                db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("LOG_TIME", DateTime.Now);
                db.AddParameter("COMMENT", TextBox_COMMENT.Text);
                String sql = "UPDATE [tbFOSHI] SET [ZHAIZHU_NAME] = @ZHAIZHU_NAME" +
                    "      ,[FOSHI_DATETIME] = @FOSHI_DATETIME" +
                    "      ,[JIESONG_ADDR] = @JIESONG_ADDR" +
                    "      ,[TEL] = @TEL" +
                    "      ,[LOG_USER] = @LOG_USER" +
                    "      ,[LOG_TIME] = @LOG_TIME" +
                    "      ,[COMMENT] = @COMMENT" +
                    " WHERE [ID]=@ID";
                int rc = db.ExecuteNonQuery(sql);
                if (rc == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>window.opener.parent.document.getElementById(\"list\").src=\"List.aspx\";window.opener.parent.selRec(\"" + hf_id.Value + "\");window.close();</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存失败');</script>");
                }
            }
        }

        protected void Button_add_wang_Click(object sender, EventArgs e)
        {
            Panel_wang.Visible = false;
            Panel_wang_new.Visible = true;
        }

        protected void Button_cancel_wang_Click(object sender, EventArgs e)
        {
            Panel_wang.Visible = true;
            Panel_wang_new.Visible = false;
        }

        protected void Button_save_wang_Click(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                db.AddParameter("FoshiID", hf_id.Value);
                db.AddParameter("JZ1", TextBox_JY1.Text);
                db.AddParameter("JZ2", TextBox_JY2.Text);
                db.AddParameter("JZ3", TextBox_JY3.Text);
                db.AddParameter("JZ4", TextBox_JY4.Text);
                db.AddParameter("YS1", TextBox_YS1.Text);
                db.AddParameter("YS2", TextBox_YS2.Text);
                db.AddParameter("YS3", TextBox_YS3.Text);
                db.AddParameter("YS4", TextBox_YS4.Text);
                int rc = db.ExecuteNonQuery("INSERT INTO [FOSHI_SHENG]([FoshiID],[Type],[JZ1],[JZ2],[JZ3],[JZ4],[YS1],[YS2],[YS3],[YS4]) "+
                    "VALUES (@FoshiID,0,@JZ1,@JZ2,@JZ3,@JZ4,@YS1,@YS2,@YS3,@YS4)");
                if (rc == 1)
                {
                    Panel_wang.Visible = true;
                    Panel_wang_new.Visible = false;
                    GridView_wang.DataBind();
                }
                else
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('往生添加失败');</script>");
            }
        }

        protected void Button_add_yan_Click(object sender, EventArgs e)
        {
            Panel_yan.Visible = false;
            Panel_yan_new.Visible = true;
        }

        protected void Button_cancel_yan_Click(object sender, EventArgs e)
        {
            Panel_yan.Visible = true;
            Panel_yan_new.Visible = false;
        }

        protected void Button_save_yan_Click(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                db.AddParameter("FoshiID", hf_id.Value);
                db.AddParameter("JZ1", TextBox_ZZ1.Text);
                db.AddParameter("JZ2", TextBox_ZZ2.Text);
                db.AddParameter("JZ3", TextBox_ZZ3.Text);
                db.AddParameter("JZ4", TextBox_ZZ4.Text);
                int rc = db.ExecuteNonQuery("INSERT INTO [FOSHI_SHENG]([FoshiID],[Type],[JZ1],[JZ2],[JZ3],[JZ4]) " +
                    "VALUES (@FoshiID,1,@JZ1,@JZ2,@JZ3,@JZ4)");
                if (rc == 1)
                {
                    Panel_yan.Visible = true;
                    Panel_yan_new.Visible = false;
                    GridView_yan.DataBind();
                }
                else
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('延生添加失败');</script>");
            }
        }

        protected void Button_add_fashi_Click(object sender, EventArgs e)
        {
            Panel_fashi.Visible = false;
            Panel_fashi_new.Visible = true;
            DropDownList_fahao.Items.Clear();
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT FAHAO FROM EMPLOYEES WHERE TYPE='法师'");
                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_fahao.Items.Add(dr[0].ToString());
                }
            }
            TextBox_FAHAO.Text = DropDownList_fahao.SelectedValue;
            TextBox_ZHIWEI.Text = DropDownList_position.SelectedValue;
        }

        protected void Button_cancel_fashi_Click(object sender, EventArgs e)
        {
            Panel_fashi.Visible = true;
            Panel_fashi_new.Visible = false;
        }

        protected void Button_save_fashi_Click(object sender, EventArgs e)
        {
            String strFashiID = hf_FASHI_ID.Value;


            using (DataBase db = new DataBase())
            {
                db.AddParameter("FOSHI_ID", hf_id.Value);
                db.AddParameter("FAHAO", TextBox_FAHAO.Text);
                db.AddParameter("DANZI", TextBox_DANZI.Text);
                db.AddParameter("POSITION", TextBox_ZHIWEI.Text);
                int rc = db.ExecuteNonQuery("INSERT INTO [FASHI_FOSHI]([FAHAO],[FOSHI_ID],[DANZI],[POSITION]) " +
                    "VALUES (@FAHAO,@FOSHI_ID,@DANZI,@POSITION)");
                if (rc == 1)
                {
                    Panel_fashi.Visible = true;
                    Panel_fashi_new.Visible = false;
                    GridView_fashi.DataBind();
                }
                else
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('法师添加失败');</script>");
            }

        }

        protected void Button_add_jiesong_Click(object sender, EventArgs e)
        {
            Panel_jiesong.Visible = false;
            Panel_jiesong_new.Visible = true;
        }

        protected void Button_cancel_jiesong_Click(object sender, EventArgs e)
        {
            Panel_jiesong.Visible = true;
            Panel_jiesong_new.Visible = false;
        }

        protected void Button_save_jiesong_Click(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                db.AddParameter("FoshiID", hf_id.Value);
                db.AddParameter("Driver", TextBox_Driver.Text);
                db.AddParameter("LicPlate", TextBox_LicPlate.Text);
                db.AddParameter("PeopleCount", TextBox_PeopleCount.Text);
                db.AddParameter("Cost", TextBox_Cost.Text);
                int rc = db.ExecuteNonQuery("INSERT INTO [FOSHI_JIESONG]([FoshiID],[Driver],[LicPlate],[PeopleCount],[Cost]) " +
                    "VALUES (@FoshiID,@Driver,@LicPlate,@PeopleCount,@Cost)");
                if (rc == 1)
                {
                    Panel_jiesong.Visible = true;
                    Panel_jiesong_new.Visible = false;
                    GridView_jiesong.DataBind();
                }
                else
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('接送添加失败');</script>");
            }
        }

        protected void DropDownList_fahao_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_FAHAO.Text = DropDownList_fahao.SelectedValue;
        }

        protected void DropDownList_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_ZHIWEI.Text = DropDownList_position.SelectedValue;
        }
    }
}