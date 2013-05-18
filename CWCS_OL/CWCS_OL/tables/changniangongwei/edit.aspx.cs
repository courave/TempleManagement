using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.changniangongwei
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
                        String sql = "SELECT [ID],[LOD_DATE],[BIANHAO],[YUAN],[PAI],[ZUO],[ZHIFUXIN1],[ZHIFUXIN2] " +
                            ",[ZHIFUXIN3],[ZHIFUXIN4],[LIANXIREN],[DIANHUA],[SHOUJI],[YOUBIAN],[DIZHI] " +
                            ",[SHEHE],[CHAOJIAN],[FUJIAN1],[FUJIAN2],[FUJIAN3],[YANGSHANG1],[YANGSHANG2] " +
                            ",[YANGSHANG3],[YANGSHANG4],[YANGSHANG5],[YANGSHANG6],[TYPE],[LOG_USER] " +
                            "FROM [CAHNGNIAN_GONGWEI] WHERE ID=" + Request.Params["id"];
                        DataTable dt = db.ExecuteDataTable(sql);
                        if (dt.Rows.Count <= 0)
                        {
                            Response.Write("没有该条记录");
                            Response.End();
                        }
                        TextBox_logdate.Text = dt.Rows[0][1].ToString();
                        TextBox_bianhao.Text = dt.Rows[0][2].ToString();
                        TextBox_yuan.Text = dt.Rows[0][3].ToString();
                        TextBox_pai.Text = dt.Rows[0][4].ToString();
                        TextBox_zuo.Text = dt.Rows[0][5].ToString();

                        TextBox_lianxiren.Text = dt.Rows[0][10].ToString();
                        TextBox_dianhua.Text = dt.Rows[0][11].ToString();
                        TextBox_shouji.Text = dt.Rows[0][12].ToString();
                        TextBox_youbian.Text = dt.Rows[0][13].ToString();
                        TextBox_dizhi.Text = dt.Rows[0][14].ToString();
                        TextBox_shenhe.Text = dt.Rows[0][15].ToString();
                        if (dt.Rows[0][26].ToString() == "yansheng")
                        {
                            yansheng.Visible = true;
                            wangsheng.Visible = false;
                            DropDownList_type.Text = "yansheng";
                            TextBox_zhifuxin1.Text = dt.Rows[0][6].ToString();
                            TextBox_zhifuxin2.Text = dt.Rows[0][7].ToString();
                            TextBox_zhifuxin3.Text = dt.Rows[0][8].ToString();
                            TextBox_zhifuxin4.Text = dt.Rows[0][9].ToString();
                        }
                        else if (dt.Rows[0][26].ToString() == "wangsheng")
                        {
                            yansheng.Visible = false;
                            wangsheng.Visible = true;
                            DropDownList_type.Text = "wangsheng";
                            TextBox_chaojian.Text = dt.Rows[0][16].ToString();
                            TextBox_fujian1.Text = dt.Rows[0][17].ToString();
                            TextBox_fujian2.Text = dt.Rows[0][18].ToString();
                            TextBox_fujian3.Text = dt.Rows[0][19].ToString();
                            TextBox_yangshang1.Text = dt.Rows[0][20].ToString();
                            TextBox_yangshang2.Text = dt.Rows[0][21].ToString();
                            TextBox_yangshang3.Text = dt.Rows[0][22].ToString();
                            TextBox_yangshang4.Text = dt.Rows[0][23].ToString();
                            TextBox_yangshang5.Text = dt.Rows[0][24].ToString();
                            TextBox_yangshang6.Text = dt.Rows[0][25].ToString();
                        }

                    }
                }
                else
                {
                    TextBox_logdate.Text = DateTime.Now.ToString();
                    TextBox_bianhao.Text = Util.GenerateBianhao("CHANGNIAN", "CAHNGNIAN_GONGWEI");
                }
                if (!this.GetCurrentUser().hasPermission("changnianshenhe"))
                {
                    shenhe.Visible = false;
                }
            }
            if (DropDownList_type.SelectedValue == "yansheng")
            {
                yansheng.Visible = true;
                wangsheng.Visible = false;
            }
            else
            {
                yansheng.Visible = false;
                wangsheng.Visible = true;
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            String sql = "";
            if (Request.Params["id"] == null)
            {
                sql="INSERT INTO [CAHNGNIAN_GONGWEI]([LOD_DATE],[BIANHAO],[YUAN],[PAI] "+
                    ",[ZUO],[ZHIFUXIN1],[ZHIFUXIN2],[ZHIFUXIN3],[ZHIFUXIN4] " +
                    ",[LIANXIREN],[DIANHUA],[SHOUJI],[YOUBIAN],[DIZHI] " +
                    ",[SHEHE],[CHAOJIAN],[FUJIAN1],[FUJIAN2],[FUJIAN3] " +
                    ",[YANGSHANG1],[YANGSHANG2],[YANGSHANG3],[YANGSHANG4] " +
                    ",[YANGSHANG5],[YANGSHANG6],[TYPE],[LOG_USER]) " +
                    " VALUES " +
                    "(@LOD_DATE,@BIANHAO,@YUAN,@PAI,@ZUO,@ZHIFUXIN1 " +
                    ",@ZHIFUXIN2,@ZHIFUXIN3,@ZHIFUXIN4,@LIANXIREN,@DIANHUA " +
                    ",@SHOUJI,@YOUBIAN,@DIZHI,@SHEHE,@CHAOJIAN,@FUJIAN1 " +
                    ",@FUJIAN2,@FUJIAN3,@YANGSHANG1,@YANGSHANG2,@YANGSHANG3 " +
                    ",@YANGSHANG4,@YANGSHANG5,@YANGSHANG6,@TYPE,@LOG_USER)";
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("LOD_DATE", DateTime.Now);
                    db.AddParameter("BIANHAO", TextBox_bianhao.Text);
                    db.AddParameter("YUAN", TextBox_yuan.Text);
                    db.AddParameter("PAI", TextBox_pai.Text);
                    db.AddParameter("ZUO", TextBox_zuo.Text);
                    db.AddParameter("ZHIFUXIN1", TextBox_zhifuxin1.Text);
                    db.AddParameter("ZHIFUXIN2", TextBox_zhifuxin2.Text);
                    db.AddParameter("ZHIFUXIN3", TextBox_zhifuxin3.Text);
                    db.AddParameter("ZHIFUXIN4", TextBox_zhifuxin4.Text);
                    db.AddParameter("LIANXIREN", TextBox_lianxiren.Text);
                    db.AddParameter("DIANHUA", TextBox_dianhua.Text);
                    db.AddParameter("SHOUJI", TextBox_shouji.Text);
                    db.AddParameter("YOUBIAN", TextBox_youbian.Text);
                    db.AddParameter("DIZHI", TextBox_dizhi.Text);
                    db.AddParameter("SHEHE", TextBox_shenhe.Text);
                    db.AddParameter("CHAOJIAN", TextBox_chaojian.Text);
                    db.AddParameter("FUJIAN1", TextBox_fujian1.Text);
                    db.AddParameter("FUJIAN2", TextBox_fujian2.Text);
                    db.AddParameter("FUJIAN3", TextBox_fujian3.Text);
                    db.AddParameter("YANGSHANG1", TextBox_yangshang1.Text);
                    db.AddParameter("YANGSHANG2", TextBox_yangshang2.Text);
                    db.AddParameter("YANGSHANG3", TextBox_yangshang3.Text);
                    db.AddParameter("YANGSHANG4", TextBox_yangshang4.Text);
                    db.AddParameter("YANGSHANG5", TextBox_yangshang5.Text);
                    db.AddParameter("YANGSHANG6", TextBox_yangshang6.Text);
                    db.AddParameter("TYPE", DropDownList_type.SelectedValue);
                    db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                    if (db.ExecuteNonQuery(sql) == 1)
                    {
                        Response.Write("<script>alert('添加成功')</script>");
                        Response.Redirect("edit.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败')</script>");
                    }

                }
            }
            else
            {
                sql = "UPDATE [CAHNGNIAN_GONGWEI] "+
                    "SET [LOD_DATE]=@LOD_DATE,[BIANHAO]=@BIANHAO,[YUAN]=@YUAN,[PAI]=@PAI,[ZUO]=@ZUO "+
                    ",[ZHIFUXIN1]=@ZHIFUXIN1,[ZHIFUXIN2]=@ZHIFUXIN2,[ZHIFUXIN3]=@ZHIFUXIN3,[ZHIFUXIN4]=@ZHIFUXIN4 "+
                    ",[LIANXIREN]=@LIANXIREN,[DIANHUA]=@DIANHUA,[SHOUJI]=@SHOUJI,[YOUBIAN]=@YOUBIAN "+
                    ",[DIZHI]=@DIZHI,[SHEHE]=@SHEHE,[CHAOJIAN]=@CHAOJIAN,[FUJIAN1]=@FUJIAN1,[FUJIAN2]=@FUJIAN2 "+
                    ",[FUJIAN3]=@FUJIAN3,[YANGSHANG1]=@YANGSHANG1,[YANGSHANG2]=@YANGSHANG2,[YANGSHANG3]=@YANGSHANG3 "+
                    ",[YANGSHANG4]=@YANGSHANG4,[YANGSHANG5]=@YANGSHANG5,[YANGSHANG6]=@YANGSHANG6,[TYPE]=@TYPE "+
                    ",[LOG_USER]=@LOG_USER WHERE ID=@ID";
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("ID", Request.Params["id"]);
                    db.AddParameter("LOD_DATE", DateTime.Now);
                    db.AddParameter("BIANHAO", TextBox_bianhao.Text);
                    db.AddParameter("YUAN", TextBox_yuan.Text);
                    db.AddParameter("PAI", TextBox_pai.Text);
                    db.AddParameter("ZUO", TextBox_zuo.Text);
                    db.AddParameter("ZHIFUXIN1", TextBox_zhifuxin1.Text);
                    db.AddParameter("ZHIFUXIN2", TextBox_zhifuxin2.Text);
                    db.AddParameter("ZHIFUXIN3", TextBox_zhifuxin3.Text);
                    db.AddParameter("ZHIFUXIN4", TextBox_zhifuxin4.Text);
                    db.AddParameter("LIANXIREN", TextBox_lianxiren.Text);
                    db.AddParameter("DIANHUA", TextBox_dianhua.Text);
                    db.AddParameter("SHOUJI", TextBox_shouji.Text);
                    db.AddParameter("YOUBIAN", TextBox_youbian.Text);
                    db.AddParameter("DIZHI", TextBox_dizhi.Text);
                    db.AddParameter("SHEHE", TextBox_shenhe.Text);
                    db.AddParameter("CHAOJIAN", TextBox_chaojian.Text);
                    db.AddParameter("FUJIAN1", TextBox_fujian1.Text);
                    db.AddParameter("FUJIAN2", TextBox_fujian2.Text);
                    db.AddParameter("FUJIAN3", TextBox_fujian3.Text);
                    db.AddParameter("YANGSHANG1", TextBox_yangshang1.Text);
                    db.AddParameter("YANGSHANG2", TextBox_yangshang2.Text);
                    db.AddParameter("YANGSHANG3", TextBox_yangshang3.Text);
                    db.AddParameter("YANGSHANG4", TextBox_yangshang4.Text);
                    db.AddParameter("YANGSHANG5", TextBox_yangshang5.Text);
                    db.AddParameter("YANGSHANG6", TextBox_yangshang6.Text);
                    db.AddParameter("TYPE", DropDownList_type.SelectedValue);
                    db.AddParameter("LOG_USER", this.GetCurrentUser().Name);
                    if (db.ExecuteNonQuery(sql) == 1)
                    {
                        Response.Write("<script>alert('添加成功')</script>");
                        Response.Redirect("edit.aspx?id=" + Request.Params["id"]);
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败')</script>");
                    }
                }
            }
        }

    }
}