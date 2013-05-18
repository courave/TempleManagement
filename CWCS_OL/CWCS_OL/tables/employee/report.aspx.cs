using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.employee
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_get_Click(object sender, EventArgs e)
        {
            DateTime dFrom = DateTime.MinValue, dTo = DateTime.MinValue;
            DateTime.TryParse(TextBox_from.Text, out dFrom);
            DateTime.TryParse(TextBox_to.Text, out dTo);
            if (dFrom == DateTime.MinValue || dTo == DateTime.MinValue)
            {
                Response.Write("日期格式不对<br/>");
                Response.End();
            }
            //summary part
            string sql = "select NATIVE_NAME,[TYPE],FAHAO,LEAVE_TIME,LEAVE_TYPE from EMPLOYEES AS A,( "+
                "SELECT EMPLOYEE_ID,SUM(DATEDIFF(MI,LEAVE_FROM,LEAVE_TO))-SUM(DATEDIFF(DD,LEAVE_FROM,LEAVE_TO))*16*60 LEAVE_TIME ,LEAVE_TYPE " +
                    "FROM LEAVE_RECORD WHERE REQUEST_TIME BETWEEN @DFROM AND @DTO GROUP BY EMPLOYEE_ID,LEAVE_TYPE "+
                    ") AS B WHERE A.ID=B.EMPLOYEE_ID ORDER BY NATIVE_NAME";
            string summaryContent = "";
            using (DataBase db = new DataBase())
            {
                db.AddParameter("DFROM", dFrom);
                db.AddParameter("DTO", dTo);
                DataTable dt = db.ExecuteDataTable(sql);
                summaryContent += "统计信息<br/><table><tr><th>姓名/法号</th><th>类别</th><th>天数</th></tr>";
                foreach (DataRow dr in dt.Rows)
                {
                    summaryContent+="<tr>";
                    if (dr[1].ToString() == "法师")
                        summaryContent += "<td>" + dr[2].ToString() + "</td>";
                    else
                        summaryContent += "<td>" + dr[0].ToString() + "</td>";
                    summaryContent += "<td>" + dr[4].ToString() + "</td>";
                    summaryContent += "<td>" + ((double)(int)dr[3] / 60 / 8).ToString() + "</td>";
                    summaryContent += "</tr>";
                }
                summaryContent += "</table>";

            }
            summary.InnerHtml = summaryContent;


            //history part
            sql = "select LEAVE_REASON,LEAVE_FROM,LEAVE_TO,LEAVE_TYPE,REQUEST_TIME,NATIVE_NAME,FAHAO,[TYPE] "+
                    "from LEAVE_RECORD AS A,EMPLOYEES AS B WHERE A.EMPLOYEE_ID=B.ID "+
                    "AND REQUEST_TIME BETWEEN @DFROM AND @DTO order by REQUEST_TIME";
            string historyContent="";
            using (DataBase db = new DataBase())
            {
                db.AddParameter("DFROM", dFrom);
                db.AddParameter("DTO", dTo);
                DataTable dt = db.ExecuteDataTable(sql);
                historyContent += "详细信息<br/><table><tr><th>姓名/法号</th><th>类别</th><th>请假时间</th><th>请假理由</th><th>申请时间</th></tr>";
                foreach (DataRow dr in dt.Rows)
                {
                    historyContent += "<tr>";
                    if (dr[7].ToString() == "法师")
                        historyContent += "<td>" + dr[6].ToString() + "</td>";
                    else
                        historyContent += "<td>" + dr[5].ToString() + "</td>";
                    historyContent += "<td>"+dr[3].ToString()+"</td>";
                    if (dr[7].ToString() == "法师")
                    {
                        DateTime lfrom = (DateTime)dr[1];
                        DateTime lto = (DateTime)dr[2];
                        TimeSpan range = lfrom - lto;
                        historyContent += "<td>" + ((double)range.Hours / 8).ToString() + "天</td>";
                    }
                    else
                    {
                        DateTime lfrom = (DateTime)dr[1];
                        DateTime lto = (DateTime)dr[2];
                        TimeSpan range = lfrom - lto;
                        historyContent += "<td>从" + dr[1].ToString() + "到" + dr[2].ToString() + " 共" + range.Hours.ToString() + "小时</td>";
                    }
                    historyContent += "<td>" + dr[0].ToString() + "</td>";
                    historyContent += "<td>" + dr[4].ToString() + "</td>";
                    historyContent += "</tr>";

                }
                historyContent += "</table>";
            }
            history.InnerHtml = historyContent;
        }
    }
}