using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CWCS_OL
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().HasUser)
                Response.Redirect("/admin/login.aspx");
            Label_alarm.Text=GetAlarmMsg();
            Label_welcome.Text = System.DateTime.Now.ToLongDateString() + " ";
            LunarCalendar lc = new LunarCalendar();
            Label_welcome.Text += lc.GetChineseDate(System.DateTime.Now)+" ";
            Label_welcome.Text += this.GetCurrentUser().Name;
            Session.Timeout = 1440;
        }

        protected String GetAlarmMsg()
        {
            String retMsg = "";
            //sanshi within one month
            String sql = "select ID,SANSHI_NO from tbSANSHI where DATEDIFF(DAY,GETDATE(),EXPIRED_TIME) between 0 and 30";
            using (DataBase db = new DataBase())
            {
                DataTable dt=db.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    retMsg += "<br/>三时系列法会 还有一个月到期<br/><br/>";
                    foreach (DataRow dr in dt.Rows)
                    {
                        retMsg += "<a href='tables/sanshi/detail.aspx?ID="+dr[0].ToString() + "' target='right'>三时系列法会 编号：" + dr[1].ToString()+"</a><br/>";
                    }
                }
            }
            //fahua within one month
            sql = "select ID,FAHUA_NO from tbFAHUA where DATEDIFF(DAY,GETDATE(),EXPIRED_TIME) between 0 and 30";
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    retMsg += "<br/>法华法会 还有一个月到期<br/><br/>";
                    foreach (DataRow dr in dt.Rows)
                    {
                        retMsg += "<a href='tables/fahua/detail.aspx?ID=" + dr[0].ToString() + "' target='right'>法华法会 编号：" + dr[1].ToString() + "</a><br/>";
                    }
                }
            }
            //sanshi after one month
            sql = "select ID,SANSHI_NO from tbSANSHI where DATEDIFF(DAY,EXPIRED_TIME,GETDATE()) > 30";
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    retMsg += "<br/>三时系列法会 已经过期快一个月<br/><br/>";
                    foreach (DataRow dr in dt.Rows)
                    {
                        retMsg += "<a href='tables/sanshi/detail.aspx?ID=" + dr[0].ToString() + "' target='right'>三时系列法会 编号：" + dr[1].ToString() + "</a><br/>";
                    }
                }
            }
            //fahua after one month
            sql = "select ID,FAHUA_NO from tbFAHUA where DATEDIFF(DAY,EXPIRED_TIME,GETDATE()) > 30";
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    retMsg += "<br/>法华法会 已经过期快一个月<br/><br/>";
                    foreach (DataRow dr in dt.Rows)
                    {
                        retMsg += "<a href='tables/fahua/detail.aspx?ID=" + dr[0].ToString() + "' target='right'>法华法会 编号：" + dr[1].ToString() + "</a><br/>";
                    }
                }
            }
            //Get 当月过生日的人
            sql = "SELECT [ID],[SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_SEX],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP],[SHIZHU_HOME_TEL],[SHIZHU_MOBILE],[SHIZHU_TYPE],[SHIZHU_EMAIL],[SHIZHU_EDU],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_IDCODE],[SHIZHU_BIRTHDAY],[SHIZHU_BIRTH_TYPE],[SHIZHU_LUNAR_DAY],[SHIZHU_TUIXIN],[SHIZHU_SANGUI],[SHIZHU_WUJIE],[BIRTH_MONTH],[BIRTH_DAY] FROM [SHIZHU_INFO]" +
    "WHERE ([SHIZHU_BIRTH_TYPE]='公历' AND [BIRTH_MONTH]=" + DateTime.Now.Month + ")";
            //deal with the 农历
            sql += " OR ([SHIZHU_BIRTH_TYPE]='农历' AND (";
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int lm, ly;
            for (int i = 1; i <= 31; i++)
            {
                try
                {
                    DateTime d = new DateTime(year, month, i);
                    if (i != 1)
                        sql += " OR ";
                    System.Globalization.ChineseLunisolarCalendar calendar = new System.Globalization.ChineseLunisolarCalendar();
                    lm = calendar.GetMonth(d);
                    ly = calendar.GetDayOfMonth(d);
                    sql += "([BIRTH_MONTH]=" + lm + " AND [BIRTH_DAY]=" + ly + ")";
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            sql += "))";
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                    retMsg += "<br />这个月过生日的人<br />";
                foreach (DataRow dr in dt.Rows)
                {
                    retMsg += "<a href='/tables/shizhuinfo/detail.aspx?id="+
                        dr[0].ToString()+"' target='right'>"+dr[2].ToString()+" ";
                    
                    if (dr[21].ToString() == "" || dr[22].ToString() == "")
                    {
                        //
                    }
                    else if (dr[16].ToString() == "农历")
                    {
                        retMsg += dr[16].ToString() + " " + LunarCalendar.GetChinesename((int)dr[21], (int)dr[22]);
                    }
                    else
                    {
                        retMsg += dr[16].ToString() + " " + dr[21].ToString() + "月" + dr[22].ToString() + "日";
                    }
                    retMsg += "</a><br />";
                }
            }
            return retMsg;
        }
    }
}