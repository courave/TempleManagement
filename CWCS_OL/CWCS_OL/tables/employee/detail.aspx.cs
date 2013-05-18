using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.employee
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Write("未选择记录");
                Response.End();
            }
            if (!IsPostBack)
            {
                using (DataBase db = new DataBase())
                {
                    String sql = "SELECT [ID],[NATIVE_NAME],[TYPE],[SEX],[PHONE],[EMAIL],[STATUS] " +
                    ",[BIRTH_MONTH],[BIRTH_YEAR],[HOME_ADDR],[DEGREE],[HOBBY],[ABILITY] " +
                    ",[COMMENTS],[NICK_NAME],[FAHAO],[HIRE_DATE],[QUIT_DATE] " +
                    ",[JIGUAN],[MINZU],[CHUJIA_DATE],[CHUJIA_TEMPLE],[TIDUSHI],[SHOUJIE_DATE] " +
                    ",[SHOUJIESHI],[ID_NO],[ZIP_CODE],[JIAONEI_POSITION],[SHEHUI_POSITION] " +
                    ",[NOW_POSITION],[RESUME],[MAIN_SOCIAL],[JIANGCHENG],[ZDEGREE],[ONAME],[CERT] " +
                    "FROM [EMPLOYEES] WHERE [ID]=" + Request.Params["id"];

                    DataTable dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count != 1)
                    {
                        Response.Write("无此条记录");
                        Response.End();
                    }
                    if (Request.Params["type"] == "法师")
                    {
                        detail_fashi.Visible = true;
                        detail_zhigong.Visible = false;
                        Labelf_name.Text = dt.Rows[0][1].ToString();
                        Imagef_head.ImageUrl = "image.aspx?id=" + dt.Rows[0][0].ToString();
                        Imagef_head.Width = 200;
                        Imagef_head.Height = 200;
                        Imagef_frontid.ImageUrl = "image.aspx?id=" + dt.Rows[0][0].ToString()+"&idpic=front";
                        Imagef_frontid.Width = 400;
                        Imagef_frontid.Height = 200;
                        Imagef_backid.ImageUrl = "image.aspx?id=" + dt.Rows[0][0].ToString()+"&idpic=back";
                        Imagef_backid.Width = 400;
                        Imagef_backid.Height = 200;
                        Labelf_sex.Text = (bool)dt.Rows[0][3] ? "女" : "男";
                        Labelf_phone.Text = dt.Rows[0][4].ToString();
                        Labelf_email.Text = dt.Rows[0][5].ToString();
                        Labelf_yearmonth.Text = dt.Rows[0][8].ToString() + "-" + dt.Rows[0][7].ToString();
                        Labelf_huji.Text = dt.Rows[0][9].ToString();
                        Labelf_degree.Text = dt.Rows[0][10].ToString();
                        Labelf_hobby.Text = dt.Rows[0][11].ToString();
                        Labelf_ability.Text = dt.Rows[0][12].ToString();
                        Labelf_comment.Text = dt.Rows[0][13].ToString();
                        Labelf_nickname.Text = dt.Rows[0][14].ToString();
                        Labelf_fahao.Text = dt.Rows[0][15].ToString();
                        Labelf_hiredate.Text = dt.Rows[0][16].ToString();
                        Labelf_quitdate.Text = dt.Rows[0][17].ToString();
                        Labelf_jiguan.Text = dt.Rows[0][18].ToString();
                        Labelf_minzu.Text = dt.Rows[0][19].ToString();
                        Labelf_chujiadate.Text = dt.Rows[0][20].ToString();
                        Labelf_chujiatemple.Text = dt.Rows[0][21].ToString();
                        Labelf_tidushi.Text = dt.Rows[0][22].ToString();
                        Labelf_shoujiedate.Text = dt.Rows[0][23].ToString();
                        Labelf_shoujieshi.Text = dt.Rows[0][24].ToString();
                        Labelf_idno.Text = dt.Rows[0][25].ToString();
                        Labelf_zipcode.Text = dt.Rows[0][26].ToString();
                        Labelf_jiaonei.Text = dt.Rows[0][27].ToString();
                        Labelf_shehui.Text = dt.Rows[0][28].ToString();
                        Labelf_now.Text = dt.Rows[0][29].ToString();
                        Labelf_resume.Text = dt.Rows[0][30].ToString();
                        Labelf_mainsocial.Text = dt.Rows[0][31].ToString();
                        Labelf_jiangcheng.Text = dt.Rows[0][32].ToString();
                        Labelf_zdegree.Text = dt.Rows[0][33].ToString();
                        Labelf_oname.Text = dt.Rows[0][34].ToString();
                        Labelf_cert.Text = dt.Rows[0][35].ToString();
                    }
                    else
                    {
                        detail_fashi.Visible = false;
                        detail_zhigong.Visible = true;
                        Labelz_name.Text = dt.Rows[0][1].ToString();
                        Imagez_head.ImageUrl = "image.aspx?id=" + dt.Rows[0][0].ToString();
                        Imagez_head.Width = 200;
                        Imagez_head.Height = 200;
                        Imagez_frontid.ImageUrl = "image.aspx?id=" + dt.Rows[0][0].ToString() + "&idpic=front";
                        Imagez_frontid.Width = 400;
                        Imagez_frontid.Height = 200;
                        Imagez_backid.ImageUrl = "image.aspx?id=" + dt.Rows[0][0].ToString() + "&idpic=back";
                        Imagez_backid.Width = 400;
                        Imagez_backid.Height = 200;
                        Labelz_sex.Text = (bool)dt.Rows[0][3] ? "女" : "男";
                        Labelz_phone.Text = dt.Rows[0][4].ToString();
                        Labelz_email.Text = dt.Rows[0][5].ToString();
                        Labelz_yearmonth.Text = dt.Rows[0][8].ToString() + "-" + dt.Rows[0][7].ToString();
                        Labelz_huji.Text = dt.Rows[0][9].ToString();
                        Labelz_degree.Text = dt.Rows[0][10].ToString();
                        Labelz_hobby.Text = dt.Rows[0][11].ToString();
                        Labelz_ability.Text = dt.Rows[0][12].ToString();
                        Labelz_comment.Text = dt.Rows[0][13].ToString();
                        Labelz_nickname.Text = dt.Rows[0][14].ToString();
                        Labelz_hiredate.Text = dt.Rows[0][16].ToString();
                        Labelz_quitdate.Text = dt.Rows[0][17].ToString();
                        Labelz_jiguan.Text = dt.Rows[0][18].ToString();
                        Labelz_minzu.Text = dt.Rows[0][19].ToString();
                        Labelz_idno.Text = dt.Rows[0][25].ToString();
                        Labelz_zipcode.Text = dt.Rows[0][26].ToString();
                        Labelz_jiaonei.Text = dt.Rows[0][27].ToString();
                        Labelz_shehui.Text = dt.Rows[0][28].ToString();
                        Labelz_now.Text = dt.Rows[0][29].ToString();
                        Labelz_resume.Text = dt.Rows[0][30].ToString();
                        Labelz_mainsocial.Text = dt.Rows[0][31].ToString();
                        Labelz_jiangcheng.Text = dt.Rows[0][32].ToString();
                        Labelz_oname.Text = dt.Rows[0][34].ToString();
                    }

                }
            }
        }

    }
}