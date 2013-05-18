﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace CWCS_OL.tables.sanshi
{
    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("03r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                Session["sanshi_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["sanshi_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["sanshi_reportsource"];
            }
        }
        public bool MarkAsPrinted(string id, string tbname)
        {
            using (DataBase db = new DataBase())
            {
                string sql = "UPDATE " + tbname + " SET [HAS_PRINT] = 1 WHERE ID=" + id;
                if (db.ExecuteNonQuery(sql) == 1)
                    return true;
                return false;
            }
        }
        protected void InitTemplateList()
        {
            using (DataBase db = new DataBase())
            {
                DropDownList_template.Items.Add(new ListItem("<不使用模板>", "0"));
                DropDownList_template.Items.Add(new ListItem("<不使用模板-单>", "-1"));
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] IN (N'sanshi',N'sanshi_single')");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["sanshi_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["sanshi_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<sanshiPrint> l = new List<sanshiPrint>();

            if (Request.Params["printall"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("SELECT [ID], [LOG_USER], [LOG_TIME], "+
                        "[FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], "+
                        "[JIEYIN4], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [YANGSHANG4], "+
                        "[YANGSHANG5], [YANGSHANG6] FROM [tbsanshi]");
                    if (dt.Rows.Count < 1)
                    {
                        Response.End();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        l.Add(GetPrintByDataRow(dr));
                        MarkAsPrinted(dr[0].ToString(), "tbSanshi");
                    }
                }
            }
            else if (Request.Params["fromPage"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    String fromPage = Request.Params["fromPage"].ToString();
                    String toPage = Request.Params["toPage"].ToString();
                    DataTable dt = db.ExecuteDataTable("SELECT [ID], [LOG_USER], [LOG_TIME], "+
                        "[FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], "+
                        "[JIEYIN4], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [YANGSHANG4], "+
                        "[YANGSHANG5], [YANGSHANG6] FROM [tbsanshi] WHERE [ZUOCI] BETWEEN '" +
                        fromPage + "' AND '" + toPage + "'");
                    if (dt.Rows.Count < 1)
                    {
                        Response.End();
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        l.Add(GetPrintByDataRow(dr));
                        MarkAsPrinted(dr[0].ToString(), "tbSanshi");
                    }
                }
            }
            else if (Request.Params["printcur"] != null)
            {
                if (Session["sanshi_cursql"] == null)
                    Response.End();
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable(Session["sanshi_cursql"].ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        l.Add(GetPrintByDataRow(dr));
                        MarkAsPrinted(dr[0].ToString(), "tbSanshi");
                    }

                }
            }
            else if (Request.Params["id"] == null)
            {
                Response.End();
            }
            else
            {
                DataBase db2 = new DataBase();
                db2.AddParameter("ID", Request.Params["id"]);
                DataTable dtOne = db2.ExecuteDataTable("SELECT [ID], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [JIEYIN2], [JIEYIN3], [JIEYIN4], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [YANGSHANG4], [YANGSHANG5], [YANGSHANG6] FROM [tbsanshi] WHERE [ID] = @ID");
                if (dtOne.Rows.Count != 1)
                {
                    Response.End();
                }

                l.Add(GetPrintByDataRow(dtOne.Rows[0]));
            }

            ReportClass cr_sanshi = new CrystalReport_sanshi();

            if (DropDownList_template.SelectedValue == "0")
            {
                cr_sanshi = new CrystalReport_sanshi();
            }
            else if (DropDownList_template.SelectedValue == "-1")
            {
                cr_sanshi = new CrystalReport_sanshi_single();
            }
            else
            {
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("id", DropDownList_template.SelectedValue);
                    DataTable dt = db.ExecuteDataTable("SELECT [type] FROM [PrintConfig] WHERE [id] = @id");
                    if (dt.Rows.Count != 0)
                        cr_sanshi = CWCS_OL.print.PrintEdit.GetNewReportByType(dt.Rows[0][0].ToString());
                    else
                        cr_sanshi = new CrystalReport_sanshi();
                }
            }
            cr_sanshi.SetDataSource(l);
            Session["sanshi_reportsource"] = cr_sanshi;
            CrystalReportViewer1.ReportSource = cr_sanshi;
        }

        private sanshiPrint GetPrintByDataRow(DataRow dr)
        {
            sanshiPrint wp = new sanshiPrint();
            wp.FOGUANG1 = dr[6].ToString();
            wp.FOGUANG2 = dr[7].ToString();
            wp.FOGUANG3 = dr[8].ToString();
            wp.FOGUANG4 = dr[9].ToString();
            wp.YANGSHANG1 = dr[10].ToString();
            wp.YANGSHANG2 = dr[11].ToString();
            wp.YANGSHANG3 = dr[12].ToString();
            wp.YANGSHANG4 = dr[13].ToString();
            wp.YANGSHANG5 = dr[14].ToString();
            wp.YANGSHANG6 = dr[15].ToString();
            wp.ZIHAO = dr[5].ToString();
            wp.ZUOCI = dr[4].ToString();
            return wp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sanshi_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }

    }
}