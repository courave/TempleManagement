using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace CWCS_OL.tables.fahua
{
    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("04r"))
            {
                Response.Write("没有查看权限");
                Response.End();
            }
            if (!IsPostBack)
            {
                Session["fahua_reportsource"] = null;
                InitTemplateList();
            }
            if (Session["fahua_reportsource"] == null)
            {
                InitPage();
            }
            else
            {
                CrystalReportViewer1.ReportSource = Session["fahua_reportsource"];
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
                DataTable dt = db.ExecuteDataTable("SELECT [id], [name], [deftemplate] FROM [PrintConfig] WHERE [type] IN (N'fahua',N'fahua_single')");
                String strDefault = "";

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList_template.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    if (strDefault == "" && (bool)dr[2])
                        strDefault = dr[0].ToString();

                }

                if (Session["fahua_printtemplate"] == null)
                {
                    if (strDefault != "")
                    {
                        DropDownList_template.SelectedValue = strDefault;
                    }
                }
                else
                {
                    DropDownList_template.SelectedValue = Session["fahua_printtemplate"].ToString();
                }
            }
        }
        private void InitPage()
        {
            List<fahuaPrint> l = new List<fahuaPrint>();

            if (Request.Params["printall"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("SELECT [ID], [LOG_TIME], [LOG_USER], "+
                        "[FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO],"+
                        " [ZUOCI] FROM [tbFAHUA]");
                    if (dt.Rows.Count < 1)
                    {
                        Response.End();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        l.Add(GetPrintByDataRow(dr));
                        MarkAsPrinted(dr[0].ToString(), "tbFAHUA");
                    }
                }
            }
            else if (Request.Params["fromPage"] != null)
            {
                using (DataBase db = new DataBase())
                {
                    String fromPage = Request.Params["fromPage"].ToString();
                    String toPage = Request.Params["toPage"].ToString();
                    DataTable dt = db.ExecuteDataTable("SELECT [ID], [LOG_TIME], [LOG_USER], " +
                        "[FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO]," +
                        " [ZUOCI] FROM [tbFAHUA] WHERE [ZUOCI] BETWEEN '" +
                        fromPage + "' AND '" + toPage + "'");

                    foreach (DataRow dr in dt.Rows)
                    {
                        l.Add(GetPrintByDataRow(dr));
                        MarkAsPrinted(dr[0].ToString(), "tbFAHUA");
                    }
                }
            }
            else if (Request.Params["printcur"] != null)
            {
                if (Session["fahua_cursql"] == null)
                    Response.End();
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable(Session["fahua_cursql"].ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        l.Add(GetPrintByDataRow(dr));
                        MarkAsPrinted(dr[0].ToString(), "tbFAHUA");
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
                DataTable dtOne = db2.ExecuteDataTable("SELECT [ID],[LOG_TIME],[LOG_USER],[FAHUI_NAME],[ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZIHAO],[ZUOCI] FROM [tbFAHUA] WHERE [ID] = @ID");
                if (dtOne.Rows.Count != 1)
                {
                    Response.End();
                }

                l.Add(GetPrintByDataRow(dtOne.Rows[0]));
            }

            ReportClass cr_fahua = new CrystalReport_fahua();

            if (DropDownList_template.SelectedValue == "0")
            {
                cr_fahua = new CrystalReport_fahua();
            }
            else if (DropDownList_template.SelectedValue == "-1")
            {
                cr_fahua = new CrystalReport_fahua_single();
            }
            else
            {
                using (DataBase db = new DataBase())
                {
                    db.AddParameter("id", DropDownList_template.SelectedValue);
                    DataTable dt = db.ExecuteDataTable("SELECT [type] FROM [PrintConfig] WHERE [id] = @id");
                    if (dt.Rows.Count != 0)
                        cr_fahua = CWCS_OL.print.PrintEdit.GetNewReportByType(dt.Rows[0][0].ToString());
                    else
                        cr_fahua = new CrystalReport_fahua();
                }
            }
            cr_fahua.SetDataSource(l);
            Session["fahua_reportsource"] = cr_fahua;
            CrystalReportViewer1.ReportSource = cr_fahua;
        }

        private fahuaPrint GetPrintByDataRow(DataRow dr)
        {
            fahuaPrint yp = new fahuaPrint();
            //yp.FOGUANG = dr[4].ToString() + "\n" + dr[5].ToString() + "\n" + dr[6].ToString() + "\n" + dr[7].ToString();
            //yp.FOGUANG = "";
            //for (int i = 4; i < 8; i++)
            //{
            //    if (dr[i].ToString() != "")
            //    {
            //        yp.FOGUANG += dr[i].ToString() + "\n";
            //    }
            //}
            yp.FOGUANG1 = dr[4].ToString();
            yp.FOGUANG2 = dr[5].ToString();
            yp.FOGUANG3 = dr[6].ToString();
            yp.FOGUANG4 = dr[7].ToString();
            yp.ZIHAO = dr[8].ToString();
            yp.ZUOCI = dr[9].ToString();
            return yp;
        }

        protected void DropDownList_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fahua_printtemplate"] = DropDownList_template.SelectedValue;
            InitPage();
        }
    }
}