using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.foshi
{
    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("08r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                Session["foshi_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["foshi_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["foshi_reportsource"];
            }
        }

        protected void InitTemplateList()
        {
            using (DataBase db = new DataBase())
            {
                DropDownList_template.Items.Add(new ListItem("<不使用模板>", ""));
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] = N'foshi'");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["foshi_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["foshi_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<foshiPrint> l = new List<foshiPrint>();

            if (Request.Params["printall"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("SELECT [ZHAIZHU_NAME], [FOSHI_DATETIME], ISNULL([FCOUNT],0) AS FASHI_COUNT, [JIESONG_ADDR], [TEL], [LOG_USER], [LOG_TIME], [COMMENT] FROM [tbFOSHI] A LEFT JOIN (SELECT FOSHI_ID,COUNT(*) AS FCOUNT FROM [FASHI_FOSHI] GROUP BY FOSHI_ID) B ON A.ID=B.FOSHI_ID");
                    if (dt.Rows.Count < 1)
                    {
                        Response.End();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        l.Add(GetPrintByDataRow(dr));
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
                DataTable dtOne = db2.ExecuteDataTable("SELECT [ZHAIZHU_NAME], [FOSHI_DATETIME], ISNULL([FCOUNT],0) AS FASHI_COUNT, [JIESONG_ADDR], [TEL], [LOG_USER], [LOG_TIME], [COMMENT] FROM [tbFOSHI] A LEFT JOIN (SELECT FOSHI_ID,COUNT(*) AS FCOUNT FROM [FASHI_FOSHI] GROUP BY FOSHI_ID) B ON A.ID=B.FOSHI_ID WHERE [ID] = @ID");
                if (dtOne.Rows.Count != 1)
                {
                    Response.End();
                }

                l.Add(GetPrintByDataRow(dtOne.Rows[0]));
            }

            CrystalReport_foshi cr_foshi = new CrystalReport_foshi();

            if (DropDownList_template.SelectedValue != "")
                CWCS_OL.print.PrintEdit.UpdateReportWithTemplate(cr_foshi, DropDownList_template.SelectedValue);
            cr_foshi.SetDataSource(l);
            Session["foshi_reportsource"] = cr_foshi;
            CrystalReportViewer1.ReportSource = cr_foshi;
        }

        private foshiPrint GetPrintByDataRow(DataRow dr)
        {
            foshiPrint wp = new foshiPrint();

            wp.FOSHI_ZHAIZHU_NAME = dr[0].ToString();
            wp.FOSHI_FOSHI_DATETIME = dr[1].ToString();
            wp.FOSHI_FASHI_COUNT = dr[2].ToString();
            wp.FOSHI_JIESONG_ADDR = dr[3].ToString();
            wp.FOSHI_TEL = dr[4].ToString();
            wp.FOSHI_LOG_USER = dr[5].ToString();
            wp.FOSHI_LOG_TIME = dr[6].ToString();
            wp.FOSHI_COMMENT = dr[7].ToString();
            return wp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["foshi_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }

    }
}