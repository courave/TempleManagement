using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.shizhuinfo
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("05r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                if (Request.Params["getId"] != null)
                {
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["getId"]);
                        DataTable dt = db.ExecuteDataTable("SELECT [SHIZHU_ID],[SHIZHU_NAME]," +
                            "[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL]," +
                            "[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL]," +
                            "[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY]," +
                            "[SHIZHU_TUIXIN] FROM " +
                            "[SHIZHU_INFO] WHERE [SHIZHU_ID]=@ID");

                        if (dt.Rows.Count == 0)
                        {
                            Response.Write("<script>alert('您输入的编号不存在。');</script>");
                        }
                        else
                        {
                            DataRow dr = dt.Rows[0];
                            Response.Write("<script>parent.selRec('" + dr[0] + "','" + dr[1] + "','" +
                                dr[2] + "','" + dr[3] + "','" + dr[4] + "','" + dr[5] + "','" + dr[6] + "','" +
                                dr[7] + "','" + dr[8] + "','" + dr[9] + "','" + dr[10] + "','" +
                                dr[11] + "','" + dr[12] + "')</script>");
                        }
                        
                    }

                    Response.End();
                    return;
                }
                if (Request.Params["id"] == null && Request.Params["shizhuid"]==null)
                {
                    Response.Write("请先选择一条记录");
                    Response.End();
                }

                using (DataBase db = new DataBase())
                {
                    String sql = "";
                    if (Request.Params["shizhuid"] != null)
                    {
                        sql = "SELECT [ID],[SHIZHU_ID],[SHIZHU_NAME]," +
                        "[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL]," +
                        "[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL],[SHIZHU_EDU]," +
                        "[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_IDCODE]," +
                        "[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY]," +
                        "[SHIZHU_TUIXIN],[SHIZHU_SANGUI],[SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY] FROM " +
                        "[SHIZHU_INFO] WHERE SHIZHU_ID='" + Request.Params["shizhuid"]+"'";
                    }
                    else
                    {
                        sql = "SELECT [ID],[SHIZHU_ID],[SHIZHU_NAME]," +
                        "[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL]," +
                        "[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL],[SHIZHU_EDU]," +
                        "[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_IDCODE]," +
                        "[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY]," +
                        "[SHIZHU_TUIXIN],[SHIZHU_SANGUI],[SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY] FROM " +
                        "[SHIZHU_INFO] WHERE ID=" + Request.Params["id"];
                    }
                    DataTable dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count != 1)
                    {
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    Label_id.Text = Server.HtmlEncode(dr[1].ToString());
                    Label_name.Text = Server.HtmlEncode(dr[2].ToString());
                    Label_sex.Text = Server.HtmlEncode(dr[3].ToString());
                    Label_addr.Text = Server.HtmlEncode(dr[4].ToString());
                    Label_zip.Text = Server.HtmlEncode(dr[5].ToString());
                    Label_tel.Text = Server.HtmlEncode(dr[6].ToString());
                    Label_mobile.Text = Server.HtmlEncode(dr[7].ToString());
                    Label_type.Text = Server.HtmlEncode(dr[8].ToString());
                    Label_email.Text = Server.HtmlEncode(dr[9].ToString());
                    Label_edu.Text = Server.HtmlEncode(dr[10].ToString());
                    Label_nationality.Text = Server.HtmlEncode(dr[11].ToString());
                    Label_city.Text = Server.HtmlEncode(dr[12].ToString());
                    Label_district.Text = Server.HtmlEncode(dr[13].ToString());
                    Label_idcode.Text = Server.HtmlEncode(dr[14].ToString());
                    Label_birthday.Text = Server.HtmlEncode(dr[15].ToString());
                    Label_birthtype.Text = Server.HtmlEncode(dr[16].ToString());
                    Label_lunarday.Text = Server.HtmlEncode(dr[17].ToString());
                    Label_tuixin.Text = Server.HtmlEncode(dr[18].ToString());
                    Label_sangui.Text = Server.HtmlEncode(dr[19].ToString());
                    Label_wujie.Text = Server.HtmlEncode(dr[20].ToString());
                    Label_birth.Text = dr[16].ToString();
                    if (dr[21].ToString() == "" || dr[22].ToString() == "")
                    {
                        Label_birth.Text = "";
                    }
                    else if (dr[16].ToString() == "农历")
                    {
                        Label_birth.Text += " " + LunarCalendar.GetChinesename((int)dr[21], (int)dr[22]);
                    }
                    else
                    {
                        Label_birth.Text += " " + dr[21].ToString() + "月" + dr[22].ToString() + "日";
                    }
                    //TODO:Add code here for Label_summary
                    //get data from 功德项目表
                    String shizhu_id = dr[1].ToString();
                    sql = "SELECT DONATE_TYPE,DONATE_MONEY,A.ID FROM SHIZHU_GONGDE A,SHIZHU_INFO B WHERE A.SHIZHU_ID=B.SHIZHU_ID"+
                        " AND A.SHIZHU_ID='"+dr[1].ToString()+"'";
                    using (DataBase db2 = new DataBase())
                    {
                        DataTable dt2 = db2.ExecuteDataTable(sql);
                        String gContent = "<ol>";
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            gContent += "<li><a href='../gongde/detail.aspx?id="+dr2[2].ToString()
                                +"' target='_blank'>"+dr2[0].ToString()+" "+dr2[1].ToString()+"</a></li>";
                        }
                        gContent += "</ol>";
                        gongde.InnerHtml = gContent;
                    }
                }
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [SHIZHU_INFO] WHERE [ID]<@ID ORDER BY [ID] DESC");
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
                    DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [SHIZHU_INFO] WHERE [ID]>@ID ORDER BY [ID] ASC");
                    if (dt.Rows.Count == 1)
                    {
                        Button_next.OnClientClick = "return parent.selRec(\"" + dt.Rows[0][0].ToString() + "\");";
                    }
                    else
                    {
                        Button_next.Enabled = false;
                    }
                }
                if (!this.GetCurrentUser().hasPermission("05u"))
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