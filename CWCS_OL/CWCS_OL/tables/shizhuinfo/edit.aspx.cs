using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.shizhuinfo
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["ID"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("05c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    TextBox_id.Text = Util.GenerateBianhao("SHIZHU", "SHIZHU_INFO");
                    TextBox_nationality.Text = "中国";
                    TextBox_city.Text = "上海";
                    
                    Button_save.Text = "新增(S)";
                    Button_savenext.Text = "新增下一条(D)";
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("05u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    using (DataBase db = new DataBase())
                    {
                        db.AddParameter("ID", Request.Params["id"].ToString());
                        DataTable dt = db.ExecuteDataTable("SELECT [ID],[SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL],[SHIZHU_EDU],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_IDCODE],[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY],[SHIZHU_TUIXIN],[SHIZHU_SANGUI],[SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY] FROM [SHIZHU_INFO] WHERE ID=@ID");
                        if (dt.Rows.Count < 1)
                        {
                            Response.Write("该记录不存在");
                            Response.End();
                        }
                        DataRow dr = dt.Rows[0];
                        TextBox_id.Text = Server.HtmlEncode(dr[1].ToString());
                        TextBox_name.Text = Server.HtmlEncode(dr[2].ToString());
                        DropDownList_sex.Text = Server.HtmlEncode(dr[3].ToString());
                        TextBox_addr.Text = Server.HtmlEncode(dr[4].ToString());
                        TextBox_zip.Text = Server.HtmlEncode(dr[5].ToString());
                        TextBox_tel.Text = Server.HtmlEncode(dr[6].ToString());
                        TextBox_mobile.Text = Server.HtmlEncode(dr[7].ToString());
                        DropDownList_type.Text = Server.HtmlEncode(dr[8].ToString());
                        TextBox_email.Text = Server.HtmlEncode(dr[9].ToString());
                        DropDownList_edu.Text = Server.HtmlEncode(dr[10].ToString());
                        TextBox_nationality.Text = Server.HtmlEncode(dr[11].ToString());
                        TextBox_city.Text = Server.HtmlEncode(dr[12].ToString());
                        TextBox_district.Text = Server.HtmlEncode(dr[13].ToString());
                        TextBox_idcode.Text = Server.HtmlEncode(dr[ 14].ToString());
                        TextBox_birthday.Text = Server.HtmlEncode(dr[15].ToString());
                        DropDownList_birthtype.Text = Server.HtmlEncode(dr[16].ToString());
                        TextBox_lunarday.Text = Server.HtmlEncode(dr[17].ToString());
                        DropDownList_tuixin.Text = Server.HtmlEncode(dr[18].ToString());
                        TextBox_sangui.Text = Server.HtmlEncode(dr[19].ToString());
                        TextBox_wujie.Text = Server.HtmlEncode(dr[20].ToString());

                        TextBox_month.Text = Server.HtmlEncode(dr[21].ToString());
                        TextBox_day.Text = Server.HtmlEncode(dr[22].ToString());

                    }
                }
            }
        }
        protected String SaveNew()
        {
            //TODO:服务端数据检查
            if (!this.GetCurrentUser().hasPermission("05c"))
            {
                return "";
            }
            using (DataBase db = new DataBase())
            {
                //db.AddParameter("LOG_TIME", DateTime.Now);
                //db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("SHIZHU_ID", TextBox_id.Text);
                db.AddParameter("SHIZHU_NAME", TextBox_name.Text);
                db.AddParameter("SHIZHU_SEX", DropDownList_sex.Text);
                db.AddParameter("SHIZHU_HOME_ADDR", TextBox_addr.Text);
                db.AddParameter("SHIZHU_HOME_ZIP", TextBox_zip.Text);
                db.AddParameter("SHIZHU_HOME_TEL", TextBox_tel.Text);
                db.AddParameter("SHIZHU_MOBILE", TextBox_mobile.Text);
                db.AddParameter("SHIZHU_TYPE", DropDownList_type.Text);
                db.AddParameter("SHIZHU_EMAIL", TextBox_email.Text);
                db.AddParameter("SHIZHU_EDU", DropDownList_edu.Text);
                db.AddParameter("SHIZHU_NATIONALITY", TextBox_nationality.Text);
                db.AddParameter("SHIZHU_CITY", TextBox_city.Text);
                db.AddParameter("SHIZHU_DISTRICT", TextBox_district.Text);
                db.AddParameter("SHIZHU_IDCODE", TextBox_idcode.Text);
                db.AddParameter("SHIZHU_BIRTHDAY", TextBox_birthday.Text);
                db.AddParameter("SHIZHU_BIRTH_TYPE", DropDownList_birthtype.Text);
                db.AddParameter("SHIZHU_LUNAR_DAY", TextBox_lunarday.Text);
                db.AddParameter("SHIZHU_TUIXIN", DropDownList_tuixin.Text);
                db.AddParameter("SHIZHU_SANGUI", TextBox_sangui.Text);
                db.AddParameter("SHIZHU_WUJIE", TextBox_wujie.Text);
                db.AddParameter("BIRTH_MONTH", TextBox_month.Text);
                db.AddParameter("BIRTH_DAY", TextBox_day.Text);
                String sql;
                sql = "INSERT INTO [SHIZHU_INFO]([SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_SEX]"+
                        ",[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL]"+
                        ",[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL]"+
                        ",[SHIZHU_EDU],[SHIZHU_NATIONALITY],[SHIZHU_CITY]"+
                        ",[SHIZHU_DISTRICT],[SHIZHU_IDCODE],[SHIZHU_BIRTHDAY]"+
                        ",[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY],[SHIZHU_TUIXIN]"+
                        ",[SHIZHU_SANGUI],[SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY]) VALUES"+
                        "(@SHIZHU_ID,@SHIZHU_NAME,@SHIZHU_SEX,"+
                        "@SHIZHU_HOME_ADDR,@SHIZHU_HOME_ZIP,@SHIZHU_HOME_TEL,"+
                        "@SHIZHU_MOBILE,@SHIZHU_TYPE,@SHIZHU_EMAIL,"+
                        "@SHIZHU_EDU,@SHIZHU_NATIONALITY,@SHIZHU_CITY,"+
                        "@SHIZHU_DISTRICT,@SHIZHU_IDCODE,@SHIZHU_BIRTHDAY,"+
                        "@SHIZHU_BIRTH_TYPE,@SHIZHU_LUNAR_DAY,@SHIZHU_TUIXIN," +
                        "@SHIZHU_SANGUI,@SHIZHU_WUJIE,@BIRTH_MONTH,@BIRTH_DAY)";
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
                //db.AddParameter("LOG_TIME", DateTime.Now);
                //db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                db.AddParameter("SHIZHU_ID", TextBox_id.Text);
                db.AddParameter("SHIZHU_NAME", TextBox_name.Text);
                db.AddParameter("SHIZHU_SEX", DropDownList_sex.Text);
                db.AddParameter("SHIZHU_HOME_ADDR", TextBox_addr.Text);
                db.AddParameter("SHIZHU_HOME_ZIP", TextBox_zip.Text);
                db.AddParameter("SHIZHU_HOME_TEL", TextBox_tel.Text);
                db.AddParameter("SHIZHU_MOBILE", TextBox_mobile.Text);
                db.AddParameter("SHIZHU_TYPE", DropDownList_type.Text);
                db.AddParameter("SHIZHU_EMAIL", TextBox_email.Text);
                db.AddParameter("SHIZHU_EDU", DropDownList_edu.Text);
                db.AddParameter("SHIZHU_NATIONALITY", TextBox_nationality.Text);
                db.AddParameter("SHIZHU_CITY", TextBox_city.Text);
                db.AddParameter("SHIZHU_DISTRICT", TextBox_district.Text);
                db.AddParameter("SHIZHU_IDCODE", TextBox_idcode.Text);
                db.AddParameter("SHIZHU_BIRTHDAY", TextBox_birthday.Text);
                db.AddParameter("SHIZHU_BIRTH_TYPE", DropDownList_birthtype.Text);
                db.AddParameter("SHIZHU_LUNAR_DAY", TextBox_lunarday.Text);
                db.AddParameter("SHIZHU_TUIXIN", DropDownList_tuixin.Text);
                db.AddParameter("SHIZHU_SANGUI", TextBox_sangui.Text);
                db.AddParameter("SHIZHU_WUJIE", TextBox_wujie.Text);
                db.AddParameter("BIRTH_MONTH", TextBox_month.Text);
                db.AddParameter("BIRTH_DAY", TextBox_day.Text);
                String sql;
                sql = "UPDATE [SHIZHU_INFO]"+
"   SET [SHIZHU_ID] = @SHIZHU_ID" +
"      ,[SHIZHU_NAME] = @SHIZHU_NAME"+
"      ,[SHIZHU_SEX] = @SHIZHU_SEX"+
"      ,[SHIZHU_HOME_ADDR] = @SHIZHU_HOME_ADDR"+
"      ,[SHIZHU_HOME_ZIP] = @SHIZHU_HOME_ZIP"+
"      ,[SHIZHU_HOME_TEL] = @SHIZHU_HOME_TEL"+
"      ,[SHIZHU_MOBILE] = @SHIZHU_MOBILE"+
"      ,[SHIZHU_TYPE] = @SHIZHU_TYPE"+
"      ,[SHIZHU_EMAIL] = @SHIZHU_EMAIL"+
"      ,[SHIZHU_EDU] = @SHIZHU_EDU"+
"      ,[SHIZHU_NATIONALITY] = @SHIZHU_NATIONALITY"+
"      ,[SHIZHU_CITY] = @SHIZHU_CITY"+
"      ,[SHIZHU_DISTRICT] = @SHIZHU_DISTRICT"+
"      ,[SHIZHU_IDCODE] = @SHIZHU_IDCODE"+
"      ,[SHIZHU_BIRTHDAY] = @SHIZHU_BIRTHDAY"+
"      ,[SHIZHU_BIRTH_TYPE] = @SHIZHU_BIRTH_TYPE"+
"      ,[SHIZHU_LUNAR_DAY] = @SHIZHU_LUNAR_DAY"+
"      ,[SHIZHU_TUIXIN] = @SHIZHU_TUIXIN"+
"      ,[SHIZHU_SANGUI] = @SHIZHU_SANGUI"+
"      ,[SHIZHU_WUJIE] = @SHIZHU_WUJIE"+
"      ,[BIRTH_MONTH] = @BIRTH_MONTH" +
"      ,[BIRTH_DAY] = @BIRTH_DAY" +
" WHERE [ID]=@ID";
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
                        DataTable dt = db.ExecuteDataTable("SELECT TOP 1 [ID] FROM [SHIZHU_INFO] WHERE [ID] > @ID ORDER BY [ID] ASC");
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

        protected void btnGetBirthDayByID_Click(object sender, EventArgs e)
        {
            string solarDay="";
            string lunarDay="";
            if (TextBox_idcode.Text.Length > 14)
            {
                string tmp = TextBox_idcode.Text.Substring(6, 8);
                solarDay += tmp.Substring(0, 4) + "-" + tmp.Substring(4, 2) + "-" + tmp.Substring(6, 2);
                DateTime solarBirth=new DateTime();
                DateTime.TryParse(solarDay, out solarBirth);
                try
                {
                    LunarCalendar lc = new LunarCalendar();
                    lunarDay = lc.GetChineseDate(solarBirth);
                }
                catch (Exception err)
                {
                }
                TextBox_birthday.Text = solarDay;
                TextBox_lunarday.Text = lunarDay;
            }
        }

        protected void btnGetLunarBirthday_Click(object sender, EventArgs e)
        {
            if (TextBox_birthday.Text.Length >= 8)
            {
                DateTime solarBirth = new DateTime();
                DateTime.TryParse(TextBox_birthday.Text, out solarBirth);
                try
                {
                    LunarCalendar lc = new LunarCalendar();
                    TextBox_lunarday.Text= lc.GetChineseDate(solarBirth);
                }
                catch (Exception err)
                {
                }
            }
        }

    }
}