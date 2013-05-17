using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TempleManagement.pub
{
    public static class UserInfo
    {
        public static string UserName;
        public static string Permissions;
        public static string NickName;
        public static string RoleName;
        public static int ID;
        public static bool checkIfExist(string UserName, string Password)
        {
            Password = pub.Cryptography.Encrypt(Password);
            using (DataBase db = new DataBase())
            {
                db.AddParameter("USER_NAME", UserName);
                db.AddParameter("PASSWORD", Password);
                DataTable dt = db.ExecuteDataTable("SELECT A.[ID],[USER_NAME],[NICK_NAME],[ROLE_NAME]," +
                    "[PERMISSION] FROM USER_INFO A,ROLE_INFO B WHERE A.ROLE_ID=B.ID AND " +
                    "USER_NAME=@USER_NAME AND PASSWORD=@PASSWORD");
                if (dt.Rows.Count == 1)
                {
                    UserInfo.UserName = UserName;
                    UserInfo.NickName = dt.Rows[0][2].ToString();
                    UserInfo.RoleName = dt.Rows[0][3].ToString();
                    UserInfo.ID = int.Parse(dt.Rows[0][0].ToString());
                    UserInfo.Permissions = dt.Rows[0][4].ToString();

                    return true;
                }
                else
                {
                    db.Dispose();
                    return false;
                }
            }
        }
        public static bool hasPermission(string permission)
        {
            if (RoleName.ToLower() == "administrator" || Permissions.IndexOf(permission) >= 0)
                return true;
            return false;
        }
    }
}
