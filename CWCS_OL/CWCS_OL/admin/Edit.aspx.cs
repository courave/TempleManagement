using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWCS_OL.admin
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["ID"] == null)
                {
                    if (!this.GetCurrentUser().hasPermission("00c"))
                    {
                        Response.Write("没有新增数据权限");
                        Response.End();
                    }
                    Button_save.Text = "新增";
                }
                else
                {
                    if (!this.GetCurrentUser().hasPermission("00u"))
                    {
                        Response.Write("没有修改数据权限");
                        Response.End();
                    }
                    DataBase db = new DataBase();
                    db.AddParameter("ID", Request.Params["id"].ToString());
                    DataTable dt = db.ExecuteDataTable("SELECT [ID],[USERNAME],[PERMISSION] FROM [ADMIN] WHERE ID=@ID");
                    if (dt.Rows.Count != 1)
                    {
                        Response.Write("无此人记录");
                        Response.End();
                    }
                    DataRow dr = dt.Rows[0];
                    Label_id.Text = dr[0].ToString();
                    TextBox_name.Text = dr[1].ToString();
                    CUserInfo user = new CUserInfo(Request.Params["id"].ToString(), true);

                    foreach (ListItem li in CheckBoxList_permission.Items)
                    {
                        li.Selected = user.hasPermission(li.Value);
                    }
                    if (!this.GetCurrentUser().hasPermission("00assign"))
                    {
                        foreach (ListItem li in CheckBoxList_permission.Items)
                        {
                            li.Enabled = false;
                        }
                    }
                }
            }
        }

        protected void Button_save_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"]==null)
            {
                if (!this.GetCurrentUser().hasPermission("00c"))
                {
                    return;
                }
                String permission = "";
                if (this.GetCurrentUser().hasPermission("00assign"))
                {
                    foreach (ListItem li in CheckBoxList_permission.Items)
                    {
                        if (li.Selected)
                        {
                            if (permission != "")
                                permission += ",";
                            permission += li.Value;
                        }
                    }
                }
                DataBase db = new DataBase();
                db.AddParameter("Name", TextBox_name.Text);
                db.AddParameter("Password", TextBox_password.Text);
                db.AddParameter("Permission", permission);
                String sql = "INSERT INTO [ADMIN] ([USERNAME], [PASSWORD], [PERMISSION]) VALUES (@Name, @Password, @Permission)";
                int rc = db.ExecuteNonQuery(sql);
                if (rc != 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('新增时出错');</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.open(\"List.aspx\",\"_self\");</script>");
                }
            }
            else
            {
                string id = Request.Params["id"].ToString();
                if (!this.GetCurrentUser().hasPermission("00u"))
                {
                    return;
                }
                string permission = "";
                foreach (ListItem li in CheckBoxList_permission.Items)
                {
                    if (li.Selected)
                    {
                        if (permission != "")
                            permission += ",";
                        permission += li.Value;
                    }
                }
                DataBase db = new DataBase();
                db.AddParameter("ID", id);
                db.AddParameter("Name", TextBox_name.Text);
                if (TextBox_password.Text != "")
                {
                    db.AddParameter("Password", TextBox_password.Text);
                }
                db.AddParameter("Permission", permission);
                int rc = db.ExecuteNonQuery("UPDATE [ADMIN] SET [USERNAME] = @Name, " +
    (TextBox_password.Text == "" ? "" : "[PASSWORD] = @Password, ") +
    "[PERMISSION] = @Permission WHERE [ID] = @ID");
                if (rc != 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存时出错');</script>");
                }
                else
                {
                    Response.Redirect("Detail.aspx?id=" + id);
                }

            }
        }

        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                String id = Request.Params["id"].ToString();
                Response.Redirect("Detail.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("Detail.aspx");
            }
        }


    }
}