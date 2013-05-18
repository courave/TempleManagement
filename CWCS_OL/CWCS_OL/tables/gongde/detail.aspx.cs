using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.gongde
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("06r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    Response.Write("请先选择一条记录");
                    Response.End();
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("select a.SHIZHU_ID,a.SHIZHU_NAME,a.SHIZHU_SEX,a.SHIZHU_TYPE, "+
                                        "a.SHIZHU_HOME_ADDR,a.SHIZHU_HOME_ZIP,a.SHIZHU_HOME_TEL,a.SHIZHU_MOBILE, "+
                                        "a.SHIZHU_EMAIL,a.SHIZHU_BIRTH_TYPE,a.SHIZHU_BIRTHDAY,a.SHIZHU_LUNAR_DAY, "+
                                        "a.SHIZHU_TUIXIN,b.DONATE_NO,b.DONATE_TYPE,b.DONATE_MONEY,b.INVOICE_NO, "+
                                        "b.DONATE_DATE,b.LOG_USER,b.LOG_TIME,b.GONGDE_FANGMING,DONATE_DESCRIPTION, "+
                                        "b.DONATE_COMMENTS from SHIZHU_INFO a,SHIZHU_GONGDE b WHERE a.SHIZHU_ID=b.SHIZHU_ID "+
                                        "AND b.ID=@ID");
                    if (dt.Rows.Count != 1)
                    {
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    Label_id.Text = Server.HtmlEncode(dr[0].ToString());
                    Label_name.Text = Server.HtmlEncode(dr[1].ToString());
                    Label_sex.Text = Server.HtmlEncode(dr[2].ToString());
                    Label_addr.Text = Server.HtmlEncode(dr[4].ToString());
                    Label_zip.Text = Server.HtmlEncode(dr[5].ToString());
                    Label_tel.Text = Server.HtmlEncode(dr[6].ToString());
                    Label_mobile.Text = Server.HtmlEncode(dr[7].ToString());
                    Label_type.Text = Server.HtmlEncode(dr[3].ToString());
                    Label_email.Text = Server.HtmlEncode(dr[8].ToString());
                    Label_birthday.Text = Server.HtmlEncode(dr[10].ToString());
                    Label_birthtype.Text = Server.HtmlEncode(dr[9].ToString());
                    Label_lunarday.Text = Server.HtmlEncode(dr[11].ToString());
                    Label_tuixin.Text = Server.HtmlEncode(dr[12].ToString());
                    Label_donate_no.Text = Server.HtmlEncode(dr[13].ToString());
                    Label_donate_type.Text = Server.HtmlEncode(dr[14].ToString());
                    Label_donate_money.Text = Server.HtmlEncode(dr[15].ToString());
                    Label_invoice_no.Text = Server.HtmlEncode(dr[16].ToString());
                    Label_donate_date.Text = Server.HtmlEncode(dr[17].ToString());
                    Label_log_user.Text = Server.HtmlEncode(dr[18].ToString());
                    Label_log_time.Text = Server.HtmlEncode(dr[19].ToString());
                    Label_gongde_fangming.Text = Server.HtmlEncode(dr[20].ToString());
                    Label_donate_description.Text = Server.HtmlEncode(dr[21].ToString());
                    Label_donate_comments.Text = Server.HtmlEncode(dr[22].ToString());
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [SHIZHU_GONGDE] WHERE [ID]<@ID ORDER BY [ID] DESC");
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
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [SHIZHU_GONGDE] WHERE [ID]>@ID ORDER BY [ID] ASC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_next.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_next.Enabled = false;
                    }
                }
                if (!this.GetCurrentUser().hasPermission("06u"))
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