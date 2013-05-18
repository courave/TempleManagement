using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.employee
{
    public partial class lorot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    Response.Write("尚未选择员工");
                    Response.End();
                }

                if (Request.Params["type"] == "法师")
                {
                    DropDownList_lorot.Visible = false;
                    leave.Visible = true;
                    overtime.Visible = false;
                    zg_time.Visible = false;
                    fs_time.Visible = true;
                }
                else if (Request.Params["lorot"] == null)
                {
                    zg_time.Visible = true;
                    fs_time.Visible = false;
                    if (DropDownList_lorot.SelectedValue == "l")
                    {
                        leave.Visible = true;
                        overtime.Visible = false;
                    }
                    else if (DropDownList_lorot.SelectedValue == "ot")
                    {
                        leave.Visible = false;
                        overtime.Visible = true;
                    }
                }
                else
                {
                    zg_time.Visible = true;
                    fs_time.Visible = false;
                    DropDownList_lorot.Text = Request.Params["lorot"];
                    if (Request.Params["lorot"] == "l")
                    {
                        leave.Visible = true;
                        overtime.Visible = false;
                    }
                    else
                    {
                        overtime.Visible = true;
                        leave.Visible = false;
                    }
                }

                using (DataBase db = new DataBase())
                {
                    //leave summary part
                    string sql = "SELECT SUM(DATEDIFF(MI,LEAVE_FROM,LEAVE_TO))-SUM(DATEDIFF(DD,LEAVE_FROM,LEAVE_TO))*16*60 LEAVE_TIME ,LEAVE_TYPE " +
                            "FROM LEAVE_RECORD WHERE EMPLOYEE_ID=" + Request.Params["id"] + " GROUP BY EMPLOYEE_ID,LEAVE_TYPE";
                    DataTable dt = db.ExecuteDataTable(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        leave_summary.InnerHtml += dr[1].ToString() + ":";
                        leave_summary.InnerHtml += (double)(int)dr[0] / 60 / 8 + "天&nbsp;";
                    }
                    //leave history part
                    sql = "select TOP 10 LEAVE_REASON,LEAVE_TYPE,DATEDIFF(MI,LEAVE_FROM,LEAVE_TO)-datediff(DD,LEAVE_FROM,LEAVE_TO)*16*60 LEAVE_TIME, " +
                        "LEAVE_FROM,LEAVE_TO,REQUEST_TIME FROM LEAVE_RECORD WHERE EMPLOYEE_ID=" + Request.Params["id"] + " ORDER BY REQUEST_TIME DESC";
                    dt = db.ExecuteDataTable(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        leave_history.InnerHtml += dr[1].ToString() + "：" + dr[0].ToString();
                        leave_history.InnerHtml += "<br />" + dr[3].ToString() + "到" + dr[4].ToString();
                        leave_history.InnerHtml += " 共" + (double)(int)dr[2] / 60 + "小时<br />";
                        leave_history.InnerHtml += "申请时间：" + dr[5].ToString() + "<br /><br /><br />";
                    }
                }

                using (DataBase db = new DataBase())
                {
                    //leave summary part
                    string sql = "SELECT SUM(DATEDIFF(MI,OVERTIME_FROM,OVERTIME_TO))-SUM(DATEDIFF(DD,OVERTIME_FROM,OVERTIME_TO))*16*60 OVERTIME_TIME ,OVERTIME_TYPE " +
                            "FROM OVERTIME_RECORD WHERE EMPLOYEE_ID=" + Request.Params["id"] + " GROUP BY EMPLOYEE_ID,OVERTIME_TYPE";
                    DataTable dt = db.ExecuteDataTable(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        ot_summary.InnerHtml += dr[1].ToString() + ":";
                        ot_summary.InnerHtml += (double)(int)dr[0] / 60 / 8 + "天&nbsp;";
                    }
                    //leave history part
                    sql = "select TOP 10 OVERTIME_REASON,OVERTIME_TYPE,DATEDIFF(MI,OVERTIME_FROM,OVERTIME_TO)-datediff(DD,OVERTIME_FROM,OVERTIME_TO)*16*60 OVERTIME_TIME, " +
                        "OVERTIME_FROM,OVERTIME_TO,REQUEST_TIME FROM OVERTIME_RECORD WHERE EMPLOYEE_ID=" + Request.Params["id"] + " ORDER BY REQUEST_TIME DESC";
                    dt = db.ExecuteDataTable(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        ot_history.InnerHtml += dr[1].ToString() + "：" + dr[0].ToString();
                        ot_history.InnerHtml += "<br />" + dr[3].ToString() + "到" + dr[4].ToString();
                        ot_history.InnerHtml += " 共" + (double)(int)dr[2] / 60 + "小时<br />";
                        ot_history.InnerHtml += "申请时间：" + dr[5].ToString() + "<br /><br /><br />";
                    }
                }

            }
        }

        protected void DropDownList_lorot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList_lorot.SelectedValue == "l")
            {
                leave.Visible = true;
                overtime.Visible = false;
            }
            else if (DropDownList_lorot.SelectedValue == "ot")
            {
                leave.Visible = false;
                overtime.Visible = true;
            }
        }

        protected void Button_submit_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
                Response.End();
            using (DataBase db = new DataBase())
            {
                String sql = "INSERT INTO [LEAVE_RECORD] ([LEAVE_REASON],[LEAVE_FROM],[LEAVE_TO],[EMPLOYEE_ID],[REQUEST_TIME],[LEAVE_TYPE]) " +
                "VALUES (@LEAVE_REASON,@LEAVE_FROM,@LEAVE_TO,@EMPLOYEE_ID,@REQUEST_TIME,@LEAVE_TYPE)";
                db.AddParameter("LEAVE_REASON", TextBox_reason.Text);
                if (Request.Params["type"] == "法师")
                {
                    DateTime startdate = DateTime.Parse(DateTime.Now.ToShortDateString() + " 8:00");
                    double d = 0.0;
                    double.TryParse(TextBox_fsday.Text, out d);
                    DateTime enddate = startdate.AddDays((int)d);
                    d=d-(int)d;
                    enddate = enddate.AddSeconds(d * 8 * 60 * 60);
                    db.AddParameter("LEAVE_FROM", startdate);
                    db.AddParameter("LEAVE_TO", enddate);

                }
                else
                {
                    DateTime tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_from.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                    {
                        db.AddParameter("LEAVE_FROM", DBNull.Value);
                    }
                    else
                    {
                        db.AddParameter("LEAVE_FROM", tmp);
                    }
                    tmp = DateTime.MinValue;
                    DateTime.TryParse(TextBox_to.Text, out tmp);
                    if (tmp == DateTime.MinValue)
                    {
                        db.AddParameter("LEAVE_TO", DBNull.Value);
                    }
                    else
                    {
                        db.AddParameter("LEAVE_TO", tmp);
                    }
                }
                db.AddParameter("EMPLOYEE_ID", Request.Params["id"]);
                db.AddParameter("REQUEST_TIME", DateTime.Now);
                db.AddParameter("LEAVE_TYPE", DropDownList_type.SelectedValue);
                if (db.ExecuteNonQuery(sql) == 1)
                {
                    Response.Write("<script>alert('提交成功')</script>");
                    Response.Redirect("lorot.aspx?id=" + Request.Params["id"] + "&type=" + Request.Params["type"]+"&lorot="+DropDownList_lorot.SelectedValue);
                }
                else
                {
                    Response.Write("<script>alert('提交失败')</script>");
                }

            }
        }

        protected void Buttonj_submit_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
                Response.End();
            using (DataBase db = new DataBase())
            {
                String sql = "INSERT INTO [OVERTIME_RECORD] ([OVERTIME_REASON],[OVERTIME_FROM],[OVERTIME_TO],[EMPLOYEE_ID],[REQUEST_TIME],[OVERTIME_TYPE]) " +
                "VALUES (@OVERTIME_REASON,@OVERTIME_FROM,@OVERTIME_TO,@EMPLOYEE_ID,@REQUEST_TIME,@OVERTIME_TYPE)";
                db.AddParameter("OVERTIME_REASON", TextBoxj_reason.Text);
                DateTime tmp = DateTime.MinValue;
                DateTime.TryParse(TextBoxj_from.Text, out tmp);
                if (tmp == DateTime.MinValue)
                {
                    db.AddParameter("OVERTIME_FROM", DBNull.Value);
                }
                else
                {
                    db.AddParameter("OVERTIME_FROM", tmp);
                }
                tmp = DateTime.MinValue;
                DateTime.TryParse(TextBoxj_to.Text, out tmp);
                if (tmp == DateTime.MinValue)
                {
                    db.AddParameter("OVERTIME_TO", DBNull.Value);
                }
                else
                {
                    db.AddParameter("OVERTIME_TO", tmp);
                }
                db.AddParameter("EMPLOYEE_ID", Request.Params["id"]);
                db.AddParameter("REQUEST_TIME", DateTime.Now);
                db.AddParameter("OVERTIME_TYPE", DropDownListj_type.SelectedValue);
                if (db.ExecuteNonQuery(sql) == 1)
                {
                    Response.Write("<script>alert('提交成功')</script>");
                    Response.Redirect("lorot.aspx?id=" + Request.Params["id"] + "&type=" + Request.Params["type"] + "&lorot=" + DropDownList_lorot.SelectedValue);
                }
                else
                {
                    Response.Write("<script>alert('提交失败')</script>");
                }

            }
        }
    }
}