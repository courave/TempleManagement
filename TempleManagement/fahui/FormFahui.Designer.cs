namespace TempleManagement.fahui
{
    partial class FormFahui
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
            this.menuStrip_fahui = new System.Windows.Forms.MenuStrip();
            this.listView_fahui = new System.Windows.Forms.ListView();
            this.ToolStripMenuItem_addfahui = new System.Windows.Forms.ToolStripMenuItem();
            this.修改法会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制法会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.搜索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_fahui.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_fahui
            // 
            this.menuStrip_fahui.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_addfahui,
            this.修改法会ToolStripMenuItem,
            this.复制法会ToolStripMenuItem,
            this.搜索ToolStripMenuItem});
            this.menuStrip_fahui.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_fahui.Name = "menuStrip_fahui";
            this.menuStrip_fahui.Size = new System.Drawing.Size(678, 24);
            this.menuStrip_fahui.TabIndex = 0;
            this.menuStrip_fahui.Text = "menuStrip1";
            // 
            // listView_fahui
            // 
            this.listView_fahui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_fahui.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_fahui.Location = new System.Drawing.Point(0, 24);
            this.listView_fahui.Name = "listView_fahui";
            this.listView_fahui.Size = new System.Drawing.Size(678, 402);
            this.listView_fahui.TabIndex = 1;
            this.listView_fahui.UseCompatibleStateImageBehavior = false;
            this.listView_fahui.View = System.Windows.Forms.View.Tile;
            this.listView_fahui.DoubleClick += new System.EventHandler(this.listView_fahui_DoubleClick);
            // 
            // ToolStripMenuItem_addfahui
            // 
            this.ToolStripMenuItem_addfahui.Name = "ToolStripMenuItem_addfahui";
            this.ToolStripMenuItem_addfahui.Size = new System.Drawing.Size(67, 20);
            this.ToolStripMenuItem_addfahui.Text = "添加法会";
            this.ToolStripMenuItem_addfahui.Click += new System.EventHandler(this.ToolStripMenuItem_addfahui_Click);
            // 
            // 修改法会ToolStripMenuItem
            // 
            this.修改法会ToolStripMenuItem.Name = "修改法会ToolStripMenuItem";
            this.修改法会ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.修改法会ToolStripMenuItem.Text = "修改法会";
            // 
            // 复制法会ToolStripMenuItem
            // 
            this.复制法会ToolStripMenuItem.Name = "复制法会ToolStripMenuItem";
            this.复制法会ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.复制法会ToolStripMenuItem.Text = "复制法会";
            // 
            // 搜索ToolStripMenuItem
            // 
            this.搜索ToolStripMenuItem.Name = "搜索ToolStripMenuItem";
            this.搜索ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.搜索ToolStripMenuItem.Text = "搜索";
            // 
            // FormFahui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 426);
            this.Controls.Add(this.listView_fahui);
            this.Controls.Add(this.menuStrip_fahui);
            this.MainMenuStrip = this.menuStrip_fahui;
            this.Name = "FormFahui";
            this.Text = "FormFahui";
            this.Load += new System.EventHandler(this.FormFahui_Load);
            this.menuStrip_fahui.ResumeLayout(false);
            this.menuStrip_fahui.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_fahui;
        private System.Windows.Forms.ListView listView_fahui;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_addfahui;
        private System.Windows.Forms.ToolStripMenuItem 修改法会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制法会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 搜索ToolStripMenuItem;
    }
}