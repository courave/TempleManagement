using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.employee
{
    public partial class image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Params["id"] == null)
                Response.End();
            String sql = "SELECT NATIVE_NAME,HEAD_IMG FROM EMPLOYEES WHERE ID=" + Request.Params["id"];
            if (Request.Params["idpic"] != null)
            {
                if (Request.Params["idpic"] == "front")
                    sql = "SELECT NATIVE_NAME,ID_COPY_FRONT FROM EMPLOYEES WHERE ID=" + Request.Params["id"];
                else
                {
                    sql = "SELECT NATIVE_NAME,ID_COPY_BACK FROM EMPLOYEES WHERE ID=" + Request.Params["id"];
                }
            }
            using (DataBase db = new DataBase())
            {
                DataTable dt=db.ExecuteDataTable(sql);
                if (dt.Rows.Count != 1)
                    Response.End();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(dt.Rows[0][0].ToString(), System.Text.Encoding.UTF8) + ";");
                Response.BinaryWrite((byte[])dt.Rows[0][1]);
            }
            
        }
    }
}