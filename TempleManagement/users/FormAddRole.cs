﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempleManagement.users
{
    public partial class FormAddRole : Form
    {
        private bool isNew = true;
        private string roleid = "-1";
        public FormAddRole():this(true,"-1"){}
        public FormAddRole(bool _isNew, string _roleid)
        {
            InitializeComponent();
            isNew = _isNew;
            roleid = _roleid;
            InitData();
        }
        private void InitTreeView(string permissions)
        {
            foreach (TreeNode tn in treeView_permissions.Nodes)
            {
                SetNodeStatus(tn, permissions);
            }
        }
        private void SetNodeStatus(TreeNode tn, string permissions)
        {
            if (permissions.IndexOf(tn.Name) >= 0)
                tn.Checked = true;
            foreach (TreeNode node in tn.Nodes)
            {
                SetNodeStatus(node, permissions);
            }
        }
        private void InitData()
        {
            if (isNew) return;
            treeView_permissions.ExpandAll();
            using (pub.DataBase db = new pub.DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT ROLE_NAME,PERMISSION FROM ROLE_INFO WHERE ID=" + roleid);
                if (dt.Rows.Count != 1) return;
                this.Text = "修改角色:" + dt.Rows[0][0].ToString();
                button_confirm.Text = "确定修改";
                textBox_rolename.Text = dt.Rows[0][0].ToString();
                InitTreeView(dt.Rows[0][1].ToString());
            }
        }
        private void FormAddRole_Load(object sender, EventArgs e)
        {

        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            SaveChanges();
            this.Close();
        }
        private void SaveChanges()
        {
            String permissionStr = "";
            foreach (TreeNode tn in treeView_permissions.Nodes)
            {
                permissionStr += GetPermissionStr(tn);
            }
            String roleName = textBox_rolename.Text;
            if (roleName == "") return;
            if (isNew)
            {
                using (pub.DataBase db = new pub.DataBase())
                {
                    db.AddParameter("ROLE_NAME", roleName);
                    db.AddParameter("PERMISSIONS", permissionStr);
                    db.ExecuteNonQuery("INSERT INTO [ROLE_INFO]([ROLE_NAME],[PERMISSION]) VALUES (@ROLE_NAME,@PERMISSIONS)");
                }
            }
            else
            {
                using (pub.DataBase db = new pub.DataBase())
                {
                    db.AddParameter("ROLE_NAME", roleName);
                    db.AddParameter("PERMISSIONS", permissionStr);
                    db.AddParameter("ID", roleid);
                    db.ExecuteNonQuery("UPDATE [ROLE_INFO] SET [ROLE_NAME] = @ROLE_NAME,[PERMISSION] = @PERMISSIONS WHERE ID=@ID");
                }
            }
        }
        private String GetPermissionStr(TreeNode tn)
        {
            String PermissionStr = "";
            if (tn == null || Convert.IsDBNull(tn)) return "";
            if (tn.Checked)
                PermissionStr += tn.Name + ";";
            foreach (TreeNode treeNode in tn.Nodes)
            {
                PermissionStr += GetPermissionStr(treeNode);
            }
            return PermissionStr;

        }
        private void treeView_permissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            pub.TreeViewCheck.CheckControl(e);
        }
    }
}
