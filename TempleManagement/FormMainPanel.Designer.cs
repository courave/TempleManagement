namespace TempleManagement
{
    partial class FormMainPanel
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
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_users;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_employees;
            this.ToolStripMenuItem_userinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_roleinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_employeeinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_shizhu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_shizhuinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_welcome = new System.Windows.Forms.ToolStripTextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ToolStripMenuItem_qingjiajiaban = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_users = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_employees = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripMenuItem_users
            // 
            ToolStripMenuItem_users.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_userinfo,
            this.ToolStripMenuItem_roleinfo,
            this.ToolStripMenuItem_logout});
            ToolStripMenuItem_users.Name = "ToolStripMenuItem_users";
            ToolStripMenuItem_users.Size = new System.Drawing.Size(67, 20);
            ToolStripMenuItem_users.Text = "用户管理";
            // 
            // ToolStripMenuItem_userinfo
            // 
            this.ToolStripMenuItem_userinfo.Name = "ToolStripMenuItem_userinfo";
            this.ToolStripMenuItem_userinfo.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_userinfo.Text = "用户管理";
            this.ToolStripMenuItem_userinfo.Click += new System.EventHandler(this.ToolStripMenuItem_userinfo_Click);
            // 
            // ToolStripMenuItem_roleinfo
            // 
            this.ToolStripMenuItem_roleinfo.Name = "ToolStripMenuItem_roleinfo";
            this.ToolStripMenuItem_roleinfo.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_roleinfo.Text = "角色管理";
            this.ToolStripMenuItem_roleinfo.Click += new System.EventHandler(this.ToolStripMenuItem_roleinfo_Click);
            // 
            // ToolStripMenuItem_logout
            // 
            this.ToolStripMenuItem_logout.Name = "ToolStripMenuItem_logout";
            this.ToolStripMenuItem_logout.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_logout.Text = "注销";
            this.ToolStripMenuItem_logout.Click += new System.EventHandler(this.ToolStripMenuItem_logout_Click);
            // 
            // ToolStripMenuItem_employees
            // 
            ToolStripMenuItem_employees.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_employeeinfo,
            this.ToolStripMenuItem_qingjiajiaban});
            ToolStripMenuItem_employees.Name = "ToolStripMenuItem_employees";
            ToolStripMenuItem_employees.Size = new System.Drawing.Size(67, 20);
            ToolStripMenuItem_employees.Text = "员工管理";
            // 
            // ToolStripMenuItem_employeeinfo
            // 
            this.ToolStripMenuItem_employeeinfo.Name = "ToolStripMenuItem_employeeinfo";
            this.ToolStripMenuItem_employeeinfo.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_employeeinfo.Text = "员工信息管理";
            this.ToolStripMenuItem_employeeinfo.Click += new System.EventHandler(this.ToolStripMenuItem_employeeinfo_Click);
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_shizhu,
            ToolStripMenuItem_employees,
            ToolStripMenuItem_users,
            this.toolStripTextBox_welcome});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(898, 24);
            this.menuStrip_main.TabIndex = 0;
            // 
            // toolStripMenuItem_shizhu
            // 
            this.toolStripMenuItem_shizhu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_shizhuinfo});
            this.toolStripMenuItem_shizhu.Name = "toolStripMenuItem_shizhu";
            this.toolStripMenuItem_shizhu.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItem_shizhu.Text = "施主管理";
            // 
            // ToolStripMenuItem_shizhuinfo
            // 
            this.ToolStripMenuItem_shizhuinfo.Name = "ToolStripMenuItem_shizhuinfo";
            this.ToolStripMenuItem_shizhuinfo.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_shizhuinfo.Text = "施主信息管理";
            this.ToolStripMenuItem_shizhuinfo.Click += new System.EventHandler(this.ToolStripMenuItem_shizhuinfo_Click);
            // 
            // toolStripTextBox_welcome
            // 
            this.toolStripTextBox_welcome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox_welcome.Name = "toolStripTextBox_welcome";
            this.toolStripTextBox_welcome.ReadOnly = true;
            this.toolStripTextBox_welcome.Size = new System.Drawing.Size(280, 20);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(898, 285);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ToolStripMenuItem_qingjiajiaban
            // 
            this.ToolStripMenuItem_qingjiajiaban.Name = "ToolStripMenuItem_qingjiajiaban";
            this.ToolStripMenuItem_qingjiajiaban.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_qingjiajiaban.Text = "请假加班管理";
            this.ToolStripMenuItem_qingjiajiaban.Click += new System.EventHandler(this.ToolStripMenuItem_qingjiajiaban_Click);
            // 
            // FormMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 309);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip_main);
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "FormMainPanel";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainPanel_FormClosed);
            this.Load += new System.EventHandler(this.FormMainPanel_Load);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_userinfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_roleinfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_logout;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_welcome;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_employeeinfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_shizhu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_shizhuinfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_qingjiajiaban;
    }
}

