using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 1440;
        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            CUserInfo user = new CUserInfo(TextBox_username.Text, false);
            if (!user.HasUser)
            {
                Label_loginError.Text = "登录失败";
                return;
            }
            if (user.Password != TextBox_password.Text)
            {
                Label_loginError.Text = "登录失败";
                return;
            }
            Session["CUserInfo"] = user;
            Response.Redirect("/Default.aspx");
        }
    }
}