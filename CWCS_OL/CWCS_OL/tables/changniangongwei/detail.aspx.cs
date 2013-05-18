using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.changniangongwei
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Write("请先选择一条记录");
                Response.End();
            }
            using (DataBase db = new DataBase())
            {
                String sql = "SELECT [ID],[LOD_DATE],[BIANHAO],[YUAN],[PAI],[ZUO],[ZHIFUXIN1],[ZHIFUXIN2],[ZHIFUXIN3] "+
                            ",[ZHIFUXIN4],[LIANXIREN],[DIANHUA],[SHOUJI],[YOUBIAN],[DIZHI],[SHEHE],[CHAOJIAN] " +
                            ",[FUJIAN1],[FUJIAN2],[FUJIAN3],[YANGSHANG1],[YANGSHANG2],[YANGSHANG3],[YANGSHANG4] "+
                            ",[YANGSHANG5],[YANGSHANG6],[TYPE],[LOG_USER] FROM [CAHNGNIAN_GONGWEI] WHERE ID="+Request.Params["id"];
                DataTable dt = db.ExecuteDataTable(sql);
                if (dt.Rows.Count <= 0)
                {
                    Response.Write("无该条记录");
                    Response.End();
                }
                Label_logdate.Text = dt.Rows[0][1].ToString();
                Label_bianhao.Text = dt.Rows[0][2].ToString();
                Label_yuan.Text = dt.Rows[0][3].ToString();
                Label_pai.Text = dt.Rows[0][4].ToString();
                Label_zuo.Text = dt.Rows[0][5].ToString();

                Label_lianxiren.Text = dt.Rows[0][10].ToString();
                Label_dianhua.Text = dt.Rows[0][11].ToString();
                Label_shouji.Text = dt.Rows[0][12].ToString();
                Label_youbian.Text = dt.Rows[0][13].ToString();
                Label_dizhi.Text = dt.Rows[0][14].ToString();
                Label_shenhe.Text = dt.Rows[0][15].ToString();
                if (dt.Rows[0][26].ToString() == "yansheng")
                {
                    yansheng.Visible = true;
                    wangsheng.Visible = false;
                    Label_type.Text = "yansheng";
                    Label_zhifuxin1.Text = dt.Rows[0][6].ToString();
                    Label_zhifuxin2.Text = dt.Rows[0][7].ToString();
                    Label_zhifuxin3.Text = dt.Rows[0][8].ToString();
                    Label_zhifuxin4.Text = dt.Rows[0][9].ToString();
                }
                else if (dt.Rows[0][26].ToString() == "wangsheng")
                {
                    yansheng.Visible = false;
                    wangsheng.Visible = true;
                    Label_type.Text = "wangsheng";
                    Label_chaojian.Text = dt.Rows[0][16].ToString();
                    Label_fujian1.Text = dt.Rows[0][17].ToString();
                    Label_fujian2.Text = dt.Rows[0][18].ToString();
                    Label_fujian3.Text = dt.Rows[0][19].ToString();
                    Label_yangshang1.Text = dt.Rows[0][20].ToString();
                    Label_yangshang2.Text = dt.Rows[0][21].ToString();
                    Label_yangshang3.Text = dt.Rows[0][22].ToString();
                    Label_yangshang4.Text = dt.Rows[0][23].ToString();
                    Label_yangshang5.Text = dt.Rows[0][24].ToString();
                    Label_yangshang6.Text = dt.Rows[0][25].ToString();
                }
            }
        }
    }
}