using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.fashiinfo
{
    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("07r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                Session["fashi_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["fashi_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["fashi_reportsource"];
            }
        }

        protected void InitTemplateList()
        {
            using (DataBase db = new DataBase())
            {
                DropDownList_template.Items.Add(new ListItem("<不使用模板>", ""));
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] = N'fashi'");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["fashi_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["fashi_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<fashiPrint> l = new List<fashiPrint>();

            if (Request.Params["printall"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("SELECT [FAHAO], [ZHIWEI], [FASHI_NAME] FROM [FASHI_INFO]");
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
                DataTable dtOne = db2.ExecuteDataTable("SELECT [FAHAO], [ZHIWEI], [FASHI_NAME] FROM [FASHI_INFO] WHERE [ID] = @ID");
                if (dtOne.Rows.Count != 1)
                {
                    Response.End();
                }

                l.Add(GetPrintByDataRow(dtOne.Rows[0]));
            }

            CrystalReport_fashi cr_fashi = new CrystalReport_fashi();

            if (DropDownList_template.SelectedValue != "")
                CWCS_OL.print.PrintEdit.UpdateReportWithTemplate(cr_fashi, DropDownList_template.SelectedValue);
            cr_fashi.SetDataSource(l);
            Session["fashi_reportsource"] = cr_fashi;
            CrystalReportViewer1.ReportSource = cr_fashi;
        }

        private fashiPrint GetPrintByDataRow(DataRow dr)
        {
            fashiPrint wp = new fashiPrint();

            wp.FASHI_FAHAO = dr[0].ToString();
            wp.FASHI_NAME = dr[2].ToString();
            wp.FASHI_ZHIWEI = dr[1].ToString();
            return wp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fashi_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }

    }
}