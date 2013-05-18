using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;

public class CUserInfo
{
    protected DataBase db;

    public bool HasUser;
    public int ID;
    public String Name;
    public String Permission;
    public String Password;
    private Hashtable PermissionPool = new Hashtable();

    public CUserInfo()
    {
        HasUser = false;
    }

    public CUserInfo(String sel, bool isId)
    {
        db = new DataBase();
        DataTable dt;
        if (!isId)
        {
            db.AddParameter("Name", sel);
            dt = db.ExecuteDataTable("SELECT [ID],[USERNAME],[PERMISSION],[PASSWORD] FROM [ADMIN] WHERE [USERNAME] = @Name");
        }
        else
        {
            db.AddParameter("ID", sel);
            dt = db.ExecuteDataTable("SELECT [ID],[USERNAME],[PERMISSION],[PASSWORD] FROM [ADMIN] WHERE [ID] = @ID");
        }
        if (dt.Rows.Count != 1)
        {
            HasUser = false;
            return;
        }

        ID = Convert.ToInt32(dt.Rows[0][0].ToString());
        Name = dt.Rows[0][1].ToString();
        Permission = dt.Rows[0][2].ToString();
        Password = dt.Rows[0][3].ToString();

        AddPermission(Permission);

        HasUser = true;
    }

    public CUserInfo(String strUserName)
        : this(strUserName, false)
    {
    }
    private void AddPermission(String permission)
    {
        String[] temp = permission.Split(',');
        foreach (String str in temp)
        {
            try
            {
                PermissionPool.Add(str, str);
            }
            catch { }
        }
    }
    public bool hasPermission(String permissionID)
    {
        return PermissionPool.Contains(permissionID);
    }

}

public static class UserInfoHelper
{
    public static CUserInfo GetCurrentUser(this System.Web.UI.Page page, bool bAutoRedirect)
    {
        if (page.Session["CUserInfo"] == null)
        {
            if (bAutoRedirect) page.Response.Redirect("/admin/login.aspx");
            return null;
        }
        else
        {
            return (CUserInfo)page.Session["CUserInfo"];
        }
    }
    public static CUserInfo GetCurrentUser(this System.Web.UI.Page page)
    {
        return GetCurrentUser(page, true);
    }
}