using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.shizhuinfo
{
    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("05r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                Session["shizhu_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["shizhu_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["shizhu_reportsource"];
            }
        }

        protected void InitTemplateList()
        {
            using (DataBase db = new DataBase())
            {
                DropDownList_template.Items.Add(new ListItem("<不使用模板>", ""));
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] = N'shizhu'");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["shizhu_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["shizhu_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<shizhuPrint> l = new List<shizhuPrint>();

            if (Request.Params["printall"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("SELECT [SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP] FROM [SHIZHU_INFO]");
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
            else if (Request.Params["fromPage"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    String fromPage = Request.Params["fromPage"].ToString();
                    String toPage = Request.Params["toPage"].ToString();
                    DataTable dt = db.ExecuteDataTable("SELECT [SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP] FROM [SHIZHU_INFO] WHERE [SHIZHU_ID] BETWEEN '" +
                        fromPage + "' AND '" + toPage + "'");
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
                DataTable dtOne = db2.ExecuteDataTable("SELECT [SHIZHU_ID],[SHIZHU_NAME],[SHIZHU_NATIONALITY],[SHIZHU_CITY],[SHIZHU_DISTRICT],[SHIZHU_HOME_ADDR],[SHIZHU_HOME_ZIP] FROM [SHIZHU_INFO] WHERE [ID] = @ID");
                if (dtOne.Rows.Count != 1)
                {
                    Response.End();
                }

                l.Add(GetPrintByDataRow(dtOne.Rows[0]));
            }

            CrystalReport_shizhu cr_shizhu = new CrystalReport_shizhu();

            if (DropDownList_template.SelectedValue != "")
                CWCS_OL.print.PrintEdit.UpdateReportWithTemplate(cr_shizhu, DropDownList_template.SelectedValue);
            cr_shizhu.SetDataSource(l);
            Session["shizhu_reportsource"] = cr_shizhu;
            CrystalReportViewer1.ReportSource = cr_shizhu;
        }

        private shizhuPrint GetPrintByDataRow(DataRow dr)
        {
            shizhuPrint wp = new shizhuPrint();

            wp.SHIZHU_ID = dr[0].ToString();
            wp.SHIZHU_NAME = dr[1].ToString();
            wp.SHIZHU_NATIONALITY = dr[2].ToString();
            wp.SHIZHU_CITY = dr[3].ToString();
            wp.SHIZHU_DISTRICT = dr[4].ToString();
            wp.SHIZHU_HOME_ADDR = dr[5].ToString();
            wp.SHIZHU_HOME_ZIP = dr[6].ToString();
            return wp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["shizhu_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }

    }
}