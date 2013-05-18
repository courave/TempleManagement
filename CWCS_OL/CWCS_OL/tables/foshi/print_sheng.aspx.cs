using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace CWCS_OL.tables.foshi
{
    public partial class print_sheng : System.Web.UI.Page
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
                Session["foshi_sheng_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["foshi_sheng_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["foshi_sheng_reportsource"];
            }
        }

        protected void InitTemplateList()
        {
            using (DataBase db = new DataBase())
            {
                DropDownList_template.Items.Add(new ListItem("<不使用模板>", ""));
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] = N'foshi_sheng'");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["foshi_sheng_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["foshi_sheng_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<foshi_shengPrint> l = new List<foshi_shengPrint>();

            if (Request.Params["id"] == null)
            {
                Response.End();
            }
            else
            {
                DataBase db2 = new DataBase();
                db2.AddParameter("ID", Request.Params["id"]);
                DataTable dt = db2.ExecuteDataTable("SELECT [Type], [JZ1], [JZ2], [JZ3], [JZ4], [YS1], [YS2], [YS3], [YS4] FROM [FOSHI_SHENG] WHERE ([FoshiID] = @ID) ORDER BY [Type]");
                if (dt.Rows.Count < 1)
                {
                    Response.End();
                }

                foreach (DataRow dr in dt.Rows)
                {
                    l.Add(GetPrintByDataRow(dr));
                }
            }

            CrystalReport_foshi_sheng cr_foshi_sheng = new CrystalReport_foshi_sheng();

            if (DropDownList_template.SelectedValue != "")
                CWCS_OL.print.PrintEdit.UpdateReportWithTemplate(cr_foshi_sheng, DropDownList_template.SelectedValue);
            cr_foshi_sheng.SetDataSource(l);
            Session["foshi_sheng_reportsource"] = cr_foshi_sheng;
            CrystalReportViewer1.ReportSource = cr_foshi_sheng;

            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", Request.Params["id"]);
                DataTable dt = db.ExecuteDataTable("SELECT [ZHAIZHU_NAME] FROM [tbFOSHI] WHERE [ID]=@ID");
                if (dt.Rows.Count != 1)
                {
                    Response.End();
                }
                DataRow dr = dt.Rows[0];
                ((TextObject)cr_foshi_sheng.Section1.ReportObjects["Text_NAME"]).Text = Server.HtmlEncode(dr[0].ToString());
            }
        }

        private foshi_shengPrint GetPrintByDataRow(DataRow dr)
        {
            foshi_shengPrint wp = new foshi_shengPrint();

            if (dr[0].ToString() == "0")
            {
                wp.TYPE = "往生";
                wp.JY1 = dr[1].ToString();
                wp.JY2 = dr[2].ToString();
                wp.JY3 = dr[3].ToString();
                wp.JY4 = dr[4].ToString();
                wp.ZZ1 = "";
                wp.ZZ2 = "";
                wp.ZZ3 = "";
                wp.ZZ4 = "";
                wp.YS1 = dr[5].ToString();
                wp.YS2 = dr[6].ToString();
                wp.YS3 = dr[7].ToString();
                wp.YS4 = dr[8].ToString();
            }
            else
            {
                wp.TYPE = "延生";
                wp.JY1 = "";
                wp.JY2 = "";
                wp.JY3 = "";
                wp.JY4 = "";
                wp.ZZ1 = dr[1].ToString();
                wp.ZZ2 = dr[2].ToString();
                wp.ZZ3 = dr[3].ToString();
                wp.ZZ4 = dr[4].ToString();
                wp.YS1 = "";
                wp.YS2 = "";
                wp.YS3 = "";
                wp.YS4 = "";
            }
            return wp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["foshi_sheng_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }

    }
}