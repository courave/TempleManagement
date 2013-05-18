using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Data;
using System.Collections;

namespace CWCS_OL.print
{
    public partial class PrintEdit : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.GetCurrentUser().hasPermission("ptu"))
            {
                Response.Write("没有权限修改");
                Response.End();
            }
            if (Request.Params["cancel"] != null)
            {
                Response.Redirect("PrintTemplate.aspx");
                return;
            }
            if (Request.Params["save"] != null)
            {
                SaveTemplate();
                Response.Redirect("PrintTemplate.aspx");
            }
            if (!IsPostBack)
            {
                InitPage();
            }
        }

        private void SaveTemplate()
        {
            String id = Request.Params["id"];
            if (id == null)
            {
                Response.Redirect("PrintTemplate.aspx");
                return;
            }
            
            //TODO: permission check

            String strPrintType;
            using (DataBase db = new DataBase())
            {
                db.AddParameter("id", id);
                DataTable dt = db.ExecuteDataTable("SELECT [type], [name], [deftemplate] FROM [PrintConfig] WHERE [id] = @id");
                if (dt.Rows.Count != 1)
                {
                    Response.Redirect("PrintTemplate.aspx");
                    return;
                }

                strPrintType = dt.Rows[0][0].ToString();
            }

            ReportClass crep = GetNewReportByType(strPrintType);
            if (crep == null)
            {
                Response.End();
            }


            using (DataBase dbDelOld = new DataBase())
            {
                dbDelOld.AddParameter("tid", id);
                dbDelOld.ExecuteNonQuery("DELETE FROM [PrintTemplate] WHERE [tid] = @tid");
            }

            using (DataBase dbUpdate = new DataBase())
            {
                dbUpdate.AddParameter("id", id);
                dbUpdate.AddParameter("name", TextBox_name.Text);
                dbUpdate.AddParameter("deftemplate", CheckBox_default.Checked);
                dbUpdate.ExecuteNonQuery("UPDATE [PrintConfig] SET [name] = @name, [deftemplate] = @deftemplate WHERE [id] = @id");
            }

            foreach (Section section in crep.ReportDefinition.Sections)
            {
                foreach (ReportObject robj in section.ReportObjects)
                {
                    String strFieldId = section.Name + "_" + robj.Name;
                    String strValueTop = Request.Params[strFieldId + "_top"];
                    if (strValueTop == null)
                        strValueTop = (robj.Top / 15).ToString();
                    using (DataBase dbInsert = new DataBase())
                    {
                        dbInsert.AddParameter("tid", id);
                        dbInsert.AddParameter("name", strFieldId + "_top");
                        dbInsert.AddParameter("value", strValueTop);
                        dbInsert.ExecuteNonQuery("INSERT INTO [PrintTemplate]([tid], [name], [value]) VALUES (@tid, @name, @value)");
                    }

                    String strValueLeft = Request.Params[strFieldId + "_left"];
                    if (strValueLeft == null)
                        strValueLeft = (robj.Left / 15).ToString();
                    using (DataBase dbInsert = new DataBase())
                    {
                        dbInsert.AddParameter("tid", id);
                        dbInsert.AddParameter("name", strFieldId + "_left");
                        dbInsert.AddParameter("value", strValueLeft);
                        dbInsert.ExecuteNonQuery("INSERT INTO [PrintTemplate]([tid], [name], [value]) VALUES (@tid, @name, @value)");
                    }


                    String strValueWidth = Request.Params[strFieldId + "_width"];
                    if (strValueWidth == null)
                        strValueWidth = (robj.Width / 15).ToString();
                    using (DataBase dbInsert = new DataBase())
                    {
                        dbInsert.AddParameter("tid", id);
                        dbInsert.AddParameter("name", strFieldId + "_width");
                        dbInsert.AddParameter("value", strValueWidth);
                        dbInsert.ExecuteNonQuery("INSERT INTO [PrintTemplate]([tid], [name], [value]) VALUES (@tid, @name, @value)");
                    }


                    String strValueHeight = Request.Params[strFieldId + "_height"];
                    if (strValueHeight == null)
                        strValueHeight = (robj.Height / 15).ToString();
                    using (DataBase dbInsert = new DataBase())
                    {
                        dbInsert.AddParameter("tid", id);
                        dbInsert.AddParameter("name", strFieldId + "_height");
                        dbInsert.AddParameter("value", strValueHeight);
                        dbInsert.ExecuteNonQuery("INSERT INTO [PrintTemplate]([tid], [name], [value]) VALUES (@tid, @name, @value)");
                    }


                }
            }


        }

        public static ReportClass GetNewReportByType(String type)
        {
            switch (type)
            {
                //Add Tables here
                //case "admin":
                //    return new Geass2.admin.CrystalReport_Admin();
                case "yansheng":
                    return new CWCS_OL.tables.yansheng.CrystalReport_yansheng();
                case "yansheng_single":
                    return new CWCS_OL.tables.yansheng.CrystalReport_yansheng_single();
                case "wangsheng":
                    return new CWCS_OL.tables.wangsheng.CrystalReport_wangsheng();
                case "wangsheng_single":
                    return new CWCS_OL.tables.wangsheng.CrystalReport_wangsheng_single();
                case "sanshi":
                    return new CWCS_OL.tables.sanshi.CrystalReport_sanshi();
                case "sanshi_single":
                    return new CWCS_OL.tables.sanshi.CrystalReport_sanshi_single();
                case "fahua":
                    return new CWCS_OL.tables.fahua.CrystalReport_fahua();
                case "fahua_single":
                    return new CWCS_OL.tables.fahua.CrystalReport_fahua_single();
                case "fashi":
                    return new CWCS_OL.tables.fashiinfo.CrystalReport_fashi();
            }
            return null;
        }

        public static ReportClass UpdateReportWithTemplate(ReportClass crep, String templateId)
        {
            Hashtable htValues = new Hashtable();

            using (DataBase db = new DataBase())
            {
                db.AddParameter("tid", templateId);
                DataTable dtTable = db.ExecuteDataTable("SELECT [name], [value] FROM [PrintTemplate] WHERE [tid] = @tid");
                foreach (DataRow dr in dtTable.Rows)
                {
                    htValues[dr[0].ToString()] = dr[1];
                }
            }
            foreach (Section section in crep.ReportDefinition.Sections)
            {
                foreach (ReportObject robj in section.ReportObjects)
                {
                    String strFieldId = section.Name + "_" + robj.Name;
                    object oTop = htValues[strFieldId + "_top"];
                    if (oTop == null)
                        oTop = (decimal)robj.Top / 15;

                    object oLeft = htValues[strFieldId + "_left"];
                    if (oLeft == null)
                        oLeft = (decimal)robj.Left / 15;

                    object oWidth = htValues[strFieldId + "_width"];
                    if (oWidth == null)
                        oWidth = (decimal)robj.Width / 15;

                    object oHeight = htValues[strFieldId + "_height"];
                    if (oHeight == null)
                        oHeight = (decimal)robj.Height / 15;

                    int iTop = (int)(decimal)oTop * 15;
                    int iLeft = (int)(decimal)oLeft * 15;
                    int iWidth = (int)(decimal)oWidth * 15;
                    int iHeight = (int)(decimal)oHeight * 15;


                    if (robj.Kind.ToString() == "BoxObject")
                    {
                        robj.Top = iTop;
                        robj.Left = iLeft;

                        BoxObject bobj = (BoxObject)robj;
                        bobj.Right = iLeft + iWidth;
                        bobj.Bottom = iTop + iHeight;
                    }
                    else if (robj.Kind.ToString() == "LineObject")
                    {
                        if (iWidth != 0 && iHeight != 0)
                        {
                            if (iWidth < iHeight)
                                iWidth = 0;
                            else
                                iHeight = 0;
                        }

                        LineObject lobj = (LineObject)robj;

                        lobj.Right = lobj.Left;
                        lobj.Bottom = lobj.Top;

                        lobj.Left = iLeft;
                        lobj.Right = iLeft;

                        lobj.Top = iTop;
                        lobj.Bottom = iTop;

                        lobj.Right = iLeft + iWidth;
                        lobj.Bottom = iTop + iHeight;
                    }
                    else
                    {
                        robj.Top = iTop;
                        robj.Left = iLeft;

                        robj.Width = iWidth;
                        robj.Height = iHeight;
                    }
                }
            }
            return crep;
        }

        protected void InitPage()
        {
            String id = Request.Params["id"];
            if (id == null)
            {
                Response.Redirect("PrintTemplate.aspx");
                return;
            }

            String strPrintType;
            using (DataBase db = new DataBase())
            {
                db.AddParameter("id", id);
                DataTable dt = db.ExecuteDataTable("SELECT [type], [name], [deftemplate] FROM [PrintConfig] WHERE [id] = @id");
                if (dt.Rows.Count != 1)
                {
                    Response.Redirect("PrintTemplate.aspx");
                    return;
                }
                strPrintType = dt.Rows[0][0].ToString();
                DropDownList_type.SelectedValue = strPrintType;
                TextBox_name.Text = dt.Rows[0][1].ToString();
                CheckBox_default.Checked = (bool)dt.Rows[0][2];
            }
            StringBuilder sbDiv = new StringBuilder();
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("    <script type=\"text/javascript\">\r\n");

            ReportClass crep = GetNewReportByType(strPrintType);
            if (crep == null)
            {
                Response.End();
            }
            UpdateReportWithTemplate(crep, id);
            foreach (Section section in crep.ReportDefinition.Sections)
            {
                String strDivSection = String.Format("    <div id=\"{0}\" class=\"section\" style=\"width:{1}px;height:{2}px\" title=\"{3}\">\r\n", section.Name, crep.PrintOptions.PageContentWidth / 15, section.Height / 15, section.Name);
                sbDiv.Append(strDivSection);

                foreach (ReportObject robj in section.ReportObjects)
                {
                    String strFieldId = section.Name + "_" + robj.Name;
                    String strField = String.Format("        <div id=\"{0}\" class=\"field\" style=\"width:{1}px; height:{2}px; top:{3}px; left:{4}px;\" title=\"{5}\">\r\n",
                        strFieldId, robj.Width / 15, robj.Height / 15, robj.Top / 15, robj.Left / 15, robj.Name);
                    sbDiv.Append(strField);

                    sbDiv.Append(String.Format("            <div id=\"{0}_rd\" class=\"rRightDown\"></div> <div id=\"{1}_ld\" class=\"rLeftDown\"></div>\r\n", strFieldId, strFieldId));
                    sbDiv.Append(String.Format("            <div id=\"{0}_ru\" class=\"rRightUp\"></div> <div id=\"{1}_lu\" class=\"rLeftUp\"></div>\r\n", strFieldId, strFieldId));
                    sbDiv.Append(String.Format("            <div id=\"{0}_r\" class=\"rRight\"></div> <div id=\"{1}_l\" class=\"rLeft\"></div>\r\n", strFieldId, strFieldId));
                    sbDiv.Append(String.Format("            <div id=\"{0}_u\" class=\"rUp\"></div> <div id=\"{1}_d\" class=\"rDown\"></div>\r\n", strFieldId, strFieldId));

                    sbDiv.Append(String.Format("            <input type=\"hidden\" name=\"{0}_top\" value=\"{1}\" />\r\n", strFieldId, robj.Top / 15));
                    sbDiv.Append(String.Format("            <input type=\"hidden\" name=\"{0}_left\" value=\"{1}\" />\r\n", strFieldId, robj.Left / 15));
                    sbDiv.Append(String.Format("            <input type=\"hidden\" name=\"{0}_width\" value=\"{1}\" />\r\n", strFieldId, robj.Width / 15));
                    sbDiv.Append(String.Format("            <input type=\"hidden\" name=\"{0}_height\" value=\"{1}\" />\r\n", strFieldId, robj.Height / 15));

                    sbDiv.Append("            ");
                    bool isField = robj.Kind.ToString().ToLower().Contains("field");
                    if (isField)
                        sbDiv.Append("&lt;");
                    if (robj.Kind.ToString() == "TextObject")
                    {
                        sbDiv.Append(((TextObject)robj).Text);
                    }
                    else
                    {
                        sbDiv.Append(robj.Name);
                    }
                    if (isField)
                        sbDiv.Append("&gt;");
                    sbDiv.Append("\r\n");
                    sbDiv.Append("        </div>\r\n");

                    sbScript.Append(String.Format("        var {0}_rs = new Resize(\"{1}\", {{ Max: true, mxContainer: \"{2}\" }});\r\n", strFieldId, strFieldId, section.Name));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_rd\", \"right-down\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_ld\", \"left-down\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_ru\", \"right-up\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_lu\", \"left-up\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_r\", \"right\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_l\", \"left\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_u\", \"up\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        {0}_rs.Set(\"{1}_d\", \"down\");\r\n", strFieldId, strFieldId));
                    sbScript.Append(String.Format("        new Drag(\"{0}\", {{ Limit: true, mxContainer: \"{1}\" }});\r\n\r\n", strFieldId, section.Name));

                }


                sbDiv.Append("    </div>\r\n");
            }

            sbDiv.Append("    <hr />\r\n");
            sbDiv.Append("    <input type='submit' name='save' value='保存' onclick='saveedit();' />\r\n");
            sbDiv.Append("    <input type='submit' name='cancel' value='取消' />\r\n");
            sbScript.Append("    </script>\r\n");
            sbDiv.Append(sbScript);
            ClientScript.RegisterStartupScript(this.GetType(), "", sbDiv.ToString());

        }
    }
}
