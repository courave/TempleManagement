using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.employee
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] != null)
                {
                    using (DataBase db = new DataBase())
                    {
                        String sql = "SELECT [ID],[NATIVE_NAME],[TYPE],[SEX],[PHONE],[EMAIL],[STATUS] "+
                    ",[BIRTH_MONTH],[BIRTH_YEAR],[HOME_ADDR],[DEGREE],[HOBBY],[ABILITY] "+
                    ",[COMMENTS],[NICK_NAME],[FAHAO],[HIRE_DATE],[QUIT_DATE] "+
                    ",[JIGUAN],[MINZU],[CHUJIA_DATE],[CHUJIA_TEMPLE],[TIDUSHI],[SHOUJIE_DATE] "+
                    ",[SHOUJIESHI],[ID_NO],[ZIP_CODE],[JIAONEI_POSITION],[SHEHUI_POSITION] "+
                    ",[NOW_POSITION],[RESUME],[MAIN_SOCIAL],[JIANGCHENG],[ZDEGREE],[ONAME],[CERT] " +
                    "FROM [EMPLOYEES] WHERE [ID]=" + Request.Params["id"];
                        DataTable dt = db.ExecuteDataTable(sql);
                        if (dt.Rows.Count <= 0)
                        {
                            Response.End();
                        }
                        if (!(bool)dt.Rows[0][6])
                        {
                            Response.Write("该员工已离职");
                        }
                        else
                        {
                            TextBox_name.Text = dt.Rows[0][1].ToString();
                            DropDownList_type.Text = dt.Rows[0][2].ToString();
                            DropDownList_sex.Text = (bool)dt.Rows[0][3] ? "1" : "0";
                            TextBox_phone.Text = dt.Rows[0][4].ToString();
                            TextBox_email.Text = dt.Rows[0][5].ToString();
                            TextBox_month.Text = dt.Rows[0][7].ToString();
                            TextBox_year.Text = dt.Rows[0][8].ToString();
                            TextBox_addr.Text = dt.Rows[0][9].ToString();
                            DropDownList_degree.Text = dt.Rows[0][10].ToString();
                            TextBox_hobby.Text = dt.Rows[0][11].ToString();
                            TextBox_ability.Text = dt.Rows[0][12].ToString();
                            FCKeditor_comment.Value = dt.Rows[0][13].ToString();
                            TextBox_nickname.Text = dt.Rows[0][14].ToString();
                            TextBox_fahao.Text = dt.Rows[0][15].ToString();
                            TextBox_hire.Text = dt.Rows[0][16].ToString();
                            TextBox_quit.Text = dt.Rows[0][17].ToString();
                            TextBox_jiguan.Text = dt.Rows[0][18].ToString();
                            TextBox_minzu.Text = dt.Rows[0][19].ToString();
                            TextBox_chujiadate.Text = dt.Rows[0][20].ToString();
                            TextBox_chujiatemple.Text = dt.Rows[0][21].ToString();
                            TextBox_tidushi.Text = dt.Rows[0][22].ToString();
                            TextBox_shoujiedate.Text = dt.Rows[0][23].ToString();
                            TextBox_shoujieshi.Text = dt.Rows[0][24].ToString();
                            TextBox_idno.Text = dt.Rows[0][25].ToString();
                            TextBox_zipcode.Text = dt.Rows[0][26].ToString();
                            TextBox_jiaonei.Text = dt.Rows[0][27].ToString();
                            TextBox_shehui.Text = dt.Rows[0][28].ToString();
                            TextBox_now.Text = dt.Rows[0][29].ToString();
                            FCKeditor_resume.Value = dt.Rows[0][30].ToString();
                            FCKeditor_mainsocial.Value = dt.Rows[0][31].ToString();
                            FCKeditor_jiangcheng.Value = dt.Rows[0][32].ToString();
                            DropDownList_zdegree.Text = dt.Rows[0][33].ToString();
                            TextBox_oname.Text = dt.Rows[0][34].ToString();
                            TextBox_cert.Text = dt.Rows[0][35].ToString();
                        }

                    }
                }
                else
                {
                    FCKeditor_resume.Value = "<table style='border: 1px solid #000000; border-collapse: collapse; width:100%'><tr><td style='border: 1px solid #000000; text-align:center;'>" +
                "何年月至何年月</td><td style='border: 1px solid #000000; text-align:center;'>" +
                "在何地区何单位</td><td style='border: 1px solid #000000; text-align:center;'>" +
                "从事何工作</td></tr><tr><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td>" +
                "<td style='border: 1px solid #000000; text-align:center;'></td></tr><tr><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td></tr><tr><td style='border: 1px solid #000000; text-align:center;'></td><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td></tr><tr>" +
                "<td style='border: 1px solid #000000; text-align:center;'></td><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td></tr><tr>" +
                "<td style='border: 1px solid #000000; text-align:center;'></td><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td></tr><tr>" +
                "<td style='border: 1px solid #000000; text-align:center;'></td><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td></tr><tr>" +
                "<td style='border: 1px solid #000000; text-align:center;'></td><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td></tr><tr><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td><td style='border: 1px solid #000000; text-align:center;'></td><td style='border: 1px solid #000000; text-align:center;'>" +
                "</td></tr></table>";
                }
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            String sql = "";
            if (Request.Params["id"] == null)
            {
                //insert
                sql = "INSERT INTO [EMPLOYEES]([NATIVE_NAME],[TYPE],[SEX],[PHONE],[EMAIL] "+
                    ",[STATUS],[BIRTH_MONTH],[BIRTH_YEAR],[HOME_ADDR],[DEGREE],[HOBBY] " +
                    ",[ABILITY],[HEAD_IMG],[COMMENTS],[NICK_NAME],[FAHAO],[HIRE_DATE] "+
                    ",[QUIT_DATE],[JIGUAN],[MINZU],[CHUJIA_DATE],[CHUJIA_TEMPLE],[TIDUSHI] "+
                    ",[SHOUJIE_DATE],[SHOUJIESHI],[ID_NO],[ZIP_CODE],[JIAONEI_POSITION] "+
                    ",[SHEHUI_POSITION],[NOW_POSITION],[RESUME],[MAIN_SOCIAL],[JIANGCHENG] "+
                    ",[ID_COPY_FRONT],[ID_COPY_BACK],[ZDEGREE],[ONAME],[CERT]) " +
                    "VALUES "+
                    "(@NATIVE_NAME,@TYPE,@SEX,@PHONE,@EMAIL,@STATUS,@BIRTH_MONTH "+
                    ",@BIRTH_YEAR,@HOME_ADDR,@DEGREE,@HOBBY,@ABILITY,@HEAD_IMG,@COMMENTS "+
                    ",@NICK_NAME,@FAHAO,@HIRE_DATE,@QUIT_DATE,@JIGUAN,@MINZU,@CHUJIA_DATE "+
                    ",@CHUJIA_TEMPLE,@TIDUSHI,@SHOUJIE_DATE,@SHOUJIESHI,@ID_NO,@ZIP_CODE "+
                    ",@JIAONEI_POSITION,@SHEHUI_POSITION,@NOW_POSITION,@RESUME,@MAIN_SOCIAL "+
                    ",@JIANGCHENG,@ID_COPY_FRONT,@ID_COPY_BACK,@ZDEGREE,@ONAME,@CERT)";
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("NATIVE_NAME", TextBox_name.Text);
                    db.AddParameter("TYPE", DropDownList_type.SelectedValue);
                    db.AddParameter("SEX", DropDownList_sex.SelectedValue);
                    db.AddParameter("PHONE", TextBox_phone.Text);
                    db.AddParameter("EMAIL", TextBox_email.Text);
                    db.AddParameter("STATUS", true);
                    db.AddParameter("BIRTH_MONTH", TextBox_month.Text);
                    db.AddParameter("BIRTH_YEAR", TextBox_year.Text);
                    db.AddParameter("HOME_ADDR", TextBox_addr.Text);
                    db.AddParameter("DEGREE", DropDownList_degree.SelectedValue);
                    db.AddParameter("HOBBY", TextBox_hobby.Text);
                    db.AddParameter("ABILITY", TextBox_ability.Text);
                    if (FileUpload_headimg.HasFile)
                        db.AddParameter("HEAD_IMG", FileUpload_headimg.FileBytes);
                    else
                        db.AddParameter("HEAD_IMG", DBNull.Value,SqlDbType.Image);
                    db.AddParameter("COMMENTS", FCKeditor_comment.Value);
                    db.AddParameter("NICK_NAME", TextBox_nickname.Text);
                    db.AddParameter("FAHAO", TextBox_fahao.Text);
                    
                    DateTime tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_hire.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("HIRE_DATE", DBNull.Value);
                    else
                        db.AddParameter("HIRE_DATE", tmp);
                    
                    tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_quit.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("QUIT_DATE", DBNull.Value);
                    else
                        db.AddParameter("QUIT_DATE", tmp);

                    db.AddParameter("JIGUAN", TextBox_jiguan.Text);
                    db.AddParameter("MINZU", TextBox_minzu.Text);
                    tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_chujiadate.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("CHUJIA_DATE", DBNull.Value);
                    else
                        db.AddParameter("CHUJIA_DATE", tmp);
                    db.AddParameter("CHUJIA_TEMPLE", TextBox_chujiatemple.Text);
                    db.AddParameter("TIDUSHI", TextBox_tidushi.Text);
                    tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_shoujiedate.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("SHOUJIE_DATE", DBNull.Value);
                    else
                        db.AddParameter("SHOUJIE_DATE", tmp);
                    db.AddParameter("SHOUJIESHI", TextBox_shoujieshi.Text);
                    db.AddParameter("ID_NO", TextBox_idno.Text);
                    db.AddParameter("ZIP_CODE", TextBox_zipcode.Text);
                    db.AddParameter("JIAONEI_POSITION", TextBox_jiaonei.Text);
                    db.AddParameter("SHEHUI_POSITION", TextBox_shehui.Text);
                    db.AddParameter("NOW_POSITION", TextBox_now.Text);
                    db.AddParameter("RESUME", FCKeditor_resume.Value);
                    db.AddParameter("MAIN_SOCIAL", FCKeditor_mainsocial.Value);
                    db.AddParameter("JIANGCHENG", FCKeditor_jiangcheng.Value);
                    if (FileUpload_frontid.HasFile)
                    {
                        db.AddParameter("ID_COPY_FRONT", FileUpload_frontid.FileBytes);
                    }
                    else
                    {
                        db.AddParameter("ID_COPY_FRONT", DBNull.Value, SqlDbType.Image);
                    }
                    if(FileUpload_backid.HasFile)
                        db.AddParameter("ID_COPY_BACK", FileUpload_backid.FileBytes);
                    else
                        db.AddParameter("ID_COPY_BACK", DBNull.Value, SqlDbType.Image);
                    db.AddParameter("ZDEGREE", DropDownList_zdegree.SelectedValue);
                    db.AddParameter("ONAME", TextBox_oname.Text);
                    db.AddParameter("CERT", TextBox_cert.Text);


                    DataTable dt2 = db.ExecuteDataTable(sql + " SELECT SCOPE_IDENTITY()");

                    if (dt2.Rows.Count == 1)
                    {
                        Response.Write("<script>alert('更新成功')</script>");
                        Response.Redirect("detail.aspx?id=" + dt2.Rows[0][0].ToString() + "&type=" + Server.UrlEncode(DropDownList_type.SelectedValue));
                    }
                    else
                    {
                        Response.Write("<script>alert('更新失败')</script>");
                    }
                }
            }
            else
            {
                sql = "UPDATE [EMPLOYEES] SET [NATIVE_NAME]=@NATIVE_NAME,[TYPE]=@TYPE,[SEX]=@SEX,[PHONE]=@PHONE " +
        ",[EMAIL]=@EMAIL,[STATUS]=@STATUS,[BIRTH_MONTH]=@BIRTH_MONTH,[BIRTH_YEAR]=@BIRTH_YEAR " +
        ",[HOME_ADDR]=@HOME_ADDR,[DEGREE]=@DEGREE,[HOBBY]=@HOBBY,[ABILITY]=@ABILITY,[COMMENTS]=@COMMENTS " +
        ",[NICK_NAME]=@NICK_NAME,[FAHAO]=@FAHAO,[HIRE_DATE]=@HIRE_DATE,[QUIT_DATE]=@QUIT_DATE " +
        ",[JIGUAN]=@JIGUAN,[MINZU]=@MINZU,[CHUJIA_DATE]=@CHUJIA_DATE,[CHUJIA_TEMPLE]=@CHUJIA_TEMPLE, " +
        "[TIDUSHI]=@TIDUSHI,[SHOUJIE_DATE]=@SHOUJIE_DATE,[SHOUJIESHI]=@SHOUJIESHI,[ID_NO]=@ID_NO, " +
        "[ZIP_CODE]=@ZIP_CODE,[JIAONEI_POSITION]=@JIAONEI_POSITION,[SHEHUI_POSITION]=@SHEHUI_POSITION, " +
        "[NOW_POSITION]=@NOW_POSITION,[RESUME]=@RESUME,[MAIN_SOCIAL]=@MAIN_SOCIAL,[JIANGCHENG]=@JIANGCHENG, "+
        "[ZDEGREE]=@ZDEGREE,[ONAME]=@ONAME,[CERT]=@CERT ";
                if (FileUpload_headimg.HasFile)
                {
                    sql += " ,[HEAD_IMG] = @HEAD_IMG ";
                }
                if (FileUpload_frontid.HasFile)
                {
                    sql += " ,[ID_COPY_FRONT] = @ID_COPY_FRONT ";
                }
                if (FileUpload_backid.HasFile)
                {
                    sql += " ,[ID_COPY_BACK] = @ID_COPY_BACK ";
                }
                sql += "WHERE ID=@ID";
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    db.AddParameter("NATIVE_NAME", TextBox_name.Text);
                    db.AddParameter("TYPE", DropDownList_type.SelectedValue);
                    db.AddParameter("SEX", DropDownList_sex.SelectedValue);
                    db.AddParameter("PHONE", TextBox_phone.Text);
                    db.AddParameter("EMAIL", TextBox_email.Text);
                    db.AddParameter("STATUS", true);
                    db.AddParameter("BIRTH_MONTH", TextBox_month.Text);
                    db.AddParameter("BIRTH_YEAR", TextBox_year.Text);
                    db.AddParameter("HOME_ADDR", TextBox_addr.Text);
                    db.AddParameter("DEGREE", DropDownList_degree.SelectedValue);
                    db.AddParameter("HOBBY", TextBox_hobby.Text);
                    db.AddParameter("ABILITY", TextBox_ability.Text);
                    db.AddParameter("COMMENTS", FCKeditor_comment.Value);
                    db.AddParameter("NICK_NAME", TextBox_nickname.Text);
                    db.AddParameter("FAHAO", TextBox_fahao.Text);
                    DateTime tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_hire.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("HIRE_DATE", DBNull.Value);
                    else
                        db.AddParameter("HIRE_DATE", tmp);
                    if (FileUpload_headimg.HasFile)
                    {
                        db.AddParameter("HEAD_IMG", FileUpload_headimg.FileBytes);
                    }

                    tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_quit.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("QUIT_DATE", DBNull.Value);
                    else
                        db.AddParameter("QUIT_DATE", tmp);

                    if (FileUpload_headimg.HasFile)
                    {
                        db.AddParameter("HEAD_IMG", FileUpload_headimg.FileBytes);
                    }

                    db.AddParameter("JIGUAN", TextBox_jiguan.Text);
                    db.AddParameter("MINZU", TextBox_minzu.Text);
                    tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_chujiadate.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("CHUJIA_DATE", DBNull.Value);
                    else
                        db.AddParameter("CHUJIA_DATE", tmp);
                    db.AddParameter("CHUJIA_TEMPLE", TextBox_chujiatemple.Text);
                    db.AddParameter("TIDUSHI", TextBox_tidushi.Text);
                    tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_shoujiedate.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                        db.AddParameter("SHOUJIE_DATE", DBNull.Value);
                    else
                        db.AddParameter("SHOUJIE_DATE", tmp);
                    db.AddParameter("SHOUJIESHI", TextBox_shoujieshi.Text);
                    db.AddParameter("ID_NO", TextBox_idno.Text);
                    db.AddParameter("ZIP_CODE", TextBox_zipcode.Text);
                    db.AddParameter("JIAONEI_POSITION", TextBox_jiaonei.Text);
                    db.AddParameter("SHEHUI_POSITION", TextBox_shehui.Text);
                    db.AddParameter("NOW_POSITION", TextBox_now.Text);
                    db.AddParameter("RESUME", FCKeditor_resume.Value);
                    db.AddParameter("MAIN_SOCIAL", FCKeditor_mainsocial.Value);
                    db.AddParameter("JIANGCHENG", FCKeditor_jiangcheng.Value);
                    db.AddParameter("ZDEGREE", DropDownList_zdegree.SelectedValue);
                    db.AddParameter("ONAME", TextBox_oname.Text);
                    db.AddParameter("CERT", TextBox_cert.Text);
                    if (FileUpload_frontid.HasFile)
                    {
                        db.AddParameter("ID_COPY_FRONT", FileUpload_frontid.FileBytes);
                    }
                    if (FileUpload_backid.HasFile)
                        db.AddParameter("ID_COPY_BACK", FileUpload_backid.FileBytes);

                    if (db.ExecuteNonQuery(sql) == 1)
                    {
                        Response.Write("<script>alert('更新成功')</script>");
                        Response.Redirect("detail.aspx?id=" + Request.Params["id"] + "&type=" + Server.UrlEncode(DropDownList_type.SelectedValue));
                    }
                    else
                    {
                        Response.Write("<script>alert('更新失败')</script>");
                    }
                    
                }
            }
        }
    }
}