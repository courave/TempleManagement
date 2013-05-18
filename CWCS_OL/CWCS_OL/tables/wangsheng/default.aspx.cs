using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.tables.wangsheng
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //frameSet.InnerHtml = "";
            if (Request.Params["fahui"] != null)
            {
                frameSet.InnerHtml = "<iframe src='list.aspx?fahui=" +
                    Request.Params["fahui"].ToString() + "&year=" +
                    Request.Params["year"].ToString() + "' id='list' width='100%' style='border:none;' frameborder='0' runat='server'></iframe>";

            }
        }
    }
}