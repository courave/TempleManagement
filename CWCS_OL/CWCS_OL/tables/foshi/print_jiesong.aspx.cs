using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace CWCS_OL.tables.foshi
{
    public partial class print_jiesong : System.Web.UI.Page
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
                Session["foshi_jiesong_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["foshi_jiesong_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["foshi_jiesong_reportsource"];
            }
        }

        protected void InitTemplateList()
        {
            using (DataBase db = new DataBase())
            {
                DropDownList_template.Items.Add(new ListItem("<不使用模板>", ""));
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] = N'foshi_jiesong'");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["foshi_jiesong_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["foshi_jiesong_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<foshi_jiesongPrint> l = new List<foshi_jiesongPrint>();

            if (Request.Params["id"] == null)
            {
                Response.End();
            }
            else
            {
                DataBase db2 = new DataBase();
                db2.AddParameter("ID", Request.Params["id"]);
                DataTable dt = db2.ExecuteDataTable("SELECT [Driver], [LicPlate], [PeopleCount], [Cost] FROM [FOSHI_JIESONG] WHERE ([FoshiID] = @ID)");
                if (dt.Rows.Count < 1)
                {
                    Response.End();
                }

                foreach (DataRow dr in dt.Rows)
                {
                    l.Add(GetPrintByDataRow(dr));
                }
            }

            CrystalReport_foshi_jiesong cr_foshi_jiesong = new CrystalReport_foshi_jiesong();

            if (DropDownList_template.SelectedValue != "")
                CWCS_OL.print.PrintEdit.UpdateReportWithTemplate(cr_foshi_jiesong, DropDownList_template.SelectedValue);
            cr_foshi_jiesong.SetDataSource(l);
            Session["foshi_jiesong_reportsource"] = cr_foshi_jiesong;
            CrystalReportViewer1.ReportSource = cr_foshi_jiesong;

            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", Request.Params["id"]);
                DataTable dt = db.ExecuteDataTable("SELECT [ZHAIZHU_NAME],[JIESONG_ADDR] FROM [tbFOSHI] WHERE [ID]=@ID");
                if (dt.Rows.Count != 1)
                {
                    Response.End();
                }
                DataRow dr = dt.Rows[0];
                ((TextObject)cr_foshi_jiesong.Section1.ReportObjects["Text_NAME"]).Text = Server.HtmlEncode(dr[0].ToString());
                ((TextObject)cr_foshi_jiesong.Section1.ReportObjects["Text_JIESONG_ADDR"]).Text = Server.HtmlEncode(dr[1].ToString());
            }
        }

        private foshi_jiesongPrint GetPrintByDataRow(DataRow dr)
        {
            foshi_jiesongPrint wp = new foshi_jiesongPrint();
            wp.Driver = dr[0].ToString();
            wp.LicPlate = dr[1].ToString();
            wp.PeopleCount = dr[2].ToString();
            wp.Cost = dr[3].ToString();

            return wp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["foshi_jiesong_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }

    }
}