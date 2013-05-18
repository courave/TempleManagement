using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace CWCS_OL.tables.foshi
{
    public partial class print_fashi : System.Web.UI.Page
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
                Session["foshi_fashi_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["foshi_fashi_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["foshi_fashi_reportsource"];
            }
        }

        protected void InitTemplateList()
        {
            using (DataBase db = new DataBase())
            {
                DropDownList_template.Items.Add(new ListItem("<不使用模板>", ""));
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] = N'foshi_fashi'");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["foshi_fashi_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["foshi_fashi_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<foshi_fashiPrint> l = new List<foshi_fashiPrint>();

            if (Request.Params["id"] == null)
            {
                Response.End();
            }
            else
            {
                DataBase db2 = new DataBase();
                db2.AddParameter("ID", Request.Params["id"]);
                DataTable dt = db2.ExecuteDataTable("SELECT FAHAO, POSITION, DANZI FROM FASHI_FOSHI WHERE FOSHI_ID = @ID");
                if (dt.Rows.Count < 1)
                {
                    Response.End();
                }

                foreach (DataRow dr in dt.Rows)
                {
                    l.Add(GetPrintByDataRow(dr));
                }
            }

            CrystalReport_foshi_fashi cr_foshi_fashi = new CrystalReport_foshi_fashi();

            if (DropDownList_template.SelectedValue != "")
                CWCS_OL.print.PrintEdit.UpdateReportWithTemplate(cr_foshi_fashi, DropDownList_template.SelectedValue);
            cr_foshi_fashi.SetDataSource(l);
            Session["foshi_fashi_reportsource"] = cr_foshi_fashi;
            CrystalReportViewer1.ReportSource = cr_foshi_fashi;

            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", Request.Params["id"]);
                DataTable dt = db.ExecuteDataTable("SELECT [ZHAIZHU_NAME] FROM [tbFOSHI] WHERE [ID]=@ID");
                if (dt.Rows.Count != 1)
                {
                    Response.End();
                }
                DataRow dr = dt.Rows[0];
                ((TextObject)cr_foshi_fashi.Section1.ReportObjects["Text_NAME"]).Text = Server.HtmlEncode(dr[0].ToString());
            }
        }

        private foshi_fashiPrint GetPrintByDataRow(DataRow dr)
        {
            foshi_fashiPrint wp = new foshi_fashiPrint();
            wp.FAHAO = dr[0].ToString();
            wp.POSITION = dr[1].ToString();
            wp.DANZI = dr[2].ToString();

            return wp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["foshi_fashi_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }

    }
}