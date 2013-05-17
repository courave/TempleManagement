namespace TempleManagement.users
{
    partial class FormAddRole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("添加用户");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("删除用户");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("用户管理", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("添加角色");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("删除角色");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("修改角色信息");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("角色管理", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_rolename = new System.Windows.Forms.TextBox();
            this.treeView_permissions = new System.Windows.Forms.TreeView();
            this.button_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "角色名:";
            // 
            // textBox_rolename
            // 
            this.textBox_rolename.Location = new System.Drawing.Point(64, 6);
            this.textBox_rolename.Name = "textBox_rolename";
            this.textBox_rolename.Size = new System.Drawing.Size(208, 20);
            this.textBox_rolename.TabIndex = 1;
            // 
            // treeView_permissions
            // 
            this.treeView_permissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView_permissions.CheckBoxes = true;
            this.treeView_permissions.Location = new System.Drawing.Point(12, 32);
            this.treeView_permissions.Name = "treeView_permissions";
            treeNode8.Name = "NodeAddUser";
            treeNode8.Text = "添加用户";
            treeNode9.Name = "NodeDelUser";
            treeNode9.Text = "删除用户";
            treeNode10.Name = "NodeUserInfo";
            treeNode10.Text = "用户管理";
            treeNode11.Name = "NodeAddRole";
            treeNode11.Text = "添加角色";
            treeNode12.Name = "NodeDelRole";
            treeNode12.Text = "删除角色";
            treeNode13.Name = "NodeModifyRole";
            treeNode13.Text = "修改角色信息";
            treeNode14.Name = "NodeRoleInfo";
            treeNode14.Text = "角色管理";
            this.treeView_permissions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14});
            this.treeView_permissions.Size = new System.Drawing.Size(260, 228);
            this.treeView_permissions.TabIndex = 2;
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(197, 266);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 3;
            this.button_confirm.Text = "确定新增";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // FormAddRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.treeView_permissions);
            this.Controls.Add(this.textBox_rolename);
            this.Controls.Add(this.label1);
            this.Name = "FormAddRole";
            this.Text = "添加角色";
            this.Load += new System.EventHandler(this.FormAddRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_rolename;
        private System.Windows.Forms.TreeView treeView_permissions;
        private System.Windows.Forms.Button button_confirm;
    }
}