namespace TempleManagement.shizhu
{
    partial class FormShizhu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_search;
            this.menuStrip_shizhu = new System.Windows.Forms.MenuStrip();
            this.dgvShizhu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIANHAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XINGMING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIZHU_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XINGBIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOME_ADDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUXIAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHENGSHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUOJI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZIPCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOBILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDU_BKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHENFENZHENG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIRTH_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NONGLI_BIRTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GONGLI_BIRTH = new CalendarColumn();
            this.SANGUI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WUJIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TUIXIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolStripMenuItem_add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_modify = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_search = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_shizhu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShizhu)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_shizhu
            // 
            this.menuStrip_shizhu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_add,
            this.ToolStripMenuItem_modify,
            this.ToolStripMenuItem_delete,
            ToolStripMenuItem_search});
            this.menuStrip_shizhu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_shizhu.Name = "menuStrip_shizhu";
            this.menuStrip_shizhu.Size = new System.Drawing.Size(991, 24);
            this.menuStrip_shizhu.TabIndex = 0;
            this.menuStrip_shizhu.Text = "menuStrip1";
            // 
            // dgvShizhu
            // 
            this.dgvShizhu.AllowUserToAddRows = false;
            this.dgvShizhu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShizhu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShizhu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShizhu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.BIANHAO,
            this.XINGMING,
            this.SHIZHU_TYPE,
            this.XINGBIE,
            this.HOME_ADDR,
            this.QUXIAN,
            this.SHENGSHI,
            this.GUOJI,
            this.ZIPCODE,
            this.TELE,
            this.MOBILE,
            this.EMAIL,
            this.EDU_BKG,
            this.SHENFENZHENG,
            this.BIRTH_TYPE,
            this.NONGLI_BIRTH,
            this.GONGLI_BIRTH,
            this.SANGUI,
            this.WUJIE,
            this.TUIXIN});
            this.dgvShizhu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShizhu.Location = new System.Drawing.Point(0, 24);
            this.dgvShizhu.Name = "dgvShizhu";
            this.dgvShizhu.ReadOnly = true;
            this.dgvShizhu.Size = new System.Drawing.Size(991, 499);
            this.dgvShizhu.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // BIANHAO
            // 
            this.BIANHAO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BIANHAO.DataPropertyName = "BIANHAO";
            this.BIANHAO.HeaderText = "施主编号";
            this.BIANHAO.Name = "BIANHAO";
            this.BIANHAO.ReadOnly = true;
            this.BIANHAO.Width = 80;
            // 
            // XINGMING
            // 
            this.XINGMING.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.XINGMING.DataPropertyName = "XINGMING";
            this.XINGMING.HeaderText = "施主姓名";
            this.XINGMING.Name = "XINGMING";
            this.XINGMING.ReadOnly = true;
            this.XINGMING.Width = 80;
            // 
            // SHIZHU_TYPE
            // 
            this.SHIZHU_TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SHIZHU_TYPE.DataPropertyName = "SHIZHU_TYPE";
            this.SHIZHU_TYPE.HeaderText = "施主类型";
            this.SHIZHU_TYPE.Name = "SHIZHU_TYPE";
            this.SHIZHU_TYPE.ReadOnly = true;
            this.SHIZHU_TYPE.Width = 80;
            // 
            // XINGBIE
            // 
            this.XINGBIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.XINGBIE.DataPropertyName = "XINGBIE";
            this.XINGBIE.HeaderText = "性别";
            this.XINGBIE.Name = "XINGBIE";
            this.XINGBIE.ReadOnly = true;
            this.XINGBIE.Width = 56;
            // 
            // HOME_ADDR
            // 
            this.HOME_ADDR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HOME_ADDR.DataPropertyName = "HOME_ADDR";
            this.HOME_ADDR.HeaderText = "家庭住址";
            this.HOME_ADDR.Name = "HOME_ADDR";
            this.HOME_ADDR.ReadOnly = true;
            this.HOME_ADDR.Width = 80;
            // 
            // QUXIAN
            // 
            this.QUXIAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QUXIAN.DataPropertyName = "QUXIAN";
            this.QUXIAN.HeaderText = "区/县";
            this.QUXIAN.Name = "QUXIAN";
            this.QUXIAN.ReadOnly = true;
            this.QUXIAN.Width = 61;
            // 
            // SHENGSHI
            // 
            this.SHENGSHI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SHENGSHI.DataPropertyName = "SHENGSHI";
            this.SHENGSHI.HeaderText = "省/市";
            this.SHENGSHI.Name = "SHENGSHI";
            this.SHENGSHI.ReadOnly = true;
            this.SHENGSHI.Width = 61;
            // 
            // GUOJI
            // 
            this.GUOJI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GUOJI.DataPropertyName = "GUOJI";
            this.GUOJI.HeaderText = "国籍";
            this.GUOJI.Name = "GUOJI";
            this.GUOJI.ReadOnly = true;
            this.GUOJI.Width = 56;
            // 
            // ZIPCODE
            // 
            this.ZIPCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ZIPCODE.DataPropertyName = "ZIPCODE";
            this.ZIPCODE.HeaderText = "邮编";
            this.ZIPCODE.Name = "ZIPCODE";
            this.ZIPCODE.ReadOnly = true;
            this.ZIPCODE.Width = 56;
            // 
            // TELE
            // 
            this.TELE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TELE.DataPropertyName = "TELE";
            this.TELE.HeaderText = "固定电话";
            this.TELE.Name = "TELE";
            this.TELE.ReadOnly = true;
            this.TELE.Width = 80;
            // 
            // MOBILE
            // 
            this.MOBILE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MOBILE.DataPropertyName = "MOBILE";
            this.MOBILE.HeaderText = "手机";
            this.MOBILE.Name = "MOBILE";
            this.MOBILE.ReadOnly = true;
            this.MOBILE.Width = 56;
            // 
            // EMAIL
            // 
            this.EMAIL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EMAIL.DataPropertyName = "EMAIL";
            this.EMAIL.HeaderText = "电子邮件";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.Width = 80;
            // 
            // EDU_BKG
            // 
            this.EDU_BKG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EDU_BKG.DataPropertyName = "EDU_BKG";
            this.EDU_BKG.HeaderText = "教育背景";
            this.EDU_BKG.Name = "EDU_BKG";
            this.EDU_BKG.ReadOnly = true;
            this.EDU_BKG.Width = 80;
            // 
            // SHENFENZHENG
            // 
            this.SHENFENZHENG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SHENFENZHENG.DataPropertyName = "SHENFENZHENG";
            this.SHENFENZHENG.HeaderText = "身份证号码";
            this.SHENFENZHENG.Name = "SHENFENZHENG";
            this.SHENFENZHENG.ReadOnly = true;
            this.SHENFENZHENG.Width = 92;
            // 
            // BIRTH_TYPE
            // 
            this.BIRTH_TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BIRTH_TYPE.DataPropertyName = "BIRTH_TYPE";
            this.BIRTH_TYPE.HeaderText = "过农历生日还是公历生日";
            this.BIRTH_TYPE.Name = "BIRTH_TYPE";
            this.BIRTH_TYPE.ReadOnly = true;
            this.BIRTH_TYPE.Width = 164;
            // 
            // NONGLI_BIRTH
            // 
            this.NONGLI_BIRTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NONGLI_BIRTH.DataPropertyName = "NONGLI_BIRTH";
            this.NONGLI_BIRTH.HeaderText = "农历生日";
            this.NONGLI_BIRTH.Name = "NONGLI_BIRTH";
            this.NONGLI_BIRTH.ReadOnly = true;
            this.NONGLI_BIRTH.Width = 80;
            // 
            // GONGLI_BIRTH
            // 
            this.GONGLI_BIRTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GONGLI_BIRTH.DataPropertyName = "GONGLI_BIRTH";
            this.GONGLI_BIRTH.HeaderText = "公历生日";
            this.GONGLI_BIRTH.Name = "GONGLI_BIRTH";
            this.GONGLI_BIRTH.ReadOnly = true;
            this.GONGLI_BIRTH.Width = 61;
            // 
            // SANGUI
            // 
            this.SANGUI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SANGUI.DataPropertyName = "SANGUI";
            this.SANGUI.HeaderText = "三皈";
            this.SANGUI.Name = "SANGUI";
            this.SANGUI.ReadOnly = true;
            this.SANGUI.Width = 56;
            // 
            // WUJIE
            // 
            this.WUJIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WUJIE.DataPropertyName = "WUJIE";
            this.WUJIE.HeaderText = "五戒";
            this.WUJIE.Name = "WUJIE";
            this.WUJIE.ReadOnly = true;
            this.WUJIE.Width = 56;
            // 
            // TUIXIN
            // 
            this.TUIXIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TUIXIN.DataPropertyName = "TUIXIN";
            this.TUIXIN.HeaderText = "退信";
            this.TUIXIN.Name = "TUIXIN";
            this.TUIXIN.ReadOnly = true;
            this.TUIXIN.Width = 56;
            // 
            // ToolStripMenuItem_add
            // 
            this.ToolStripMenuItem_add.Name = "ToolStripMenuItem_add";
            this.ToolStripMenuItem_add.Size = new System.Drawing.Size(67, 20);
            this.ToolStripMenuItem_add.Text = "添加记录";
            this.ToolStripMenuItem_add.Click += new System.EventHandler(this.ToolStripMenuItem_add_Click);
            // 
            // ToolStripMenuItem_modify
            // 
            this.ToolStripMenuItem_modify.Name = "ToolStripMenuItem_modify";
            this.ToolStripMenuItem_modify.Size = new System.Drawing.Size(67, 20);
            this.ToolStripMenuItem_modify.Text = "修改记录";
            this.ToolStripMenuItem_modify.Click += new System.EventHandler(this.ToolStripMenuItem_modify_Click);
            // 
            // ToolStripMenuItem_delete
            // 
            this.ToolStripMenuItem_delete.Name = "ToolStripMenuItem_delete";
            this.ToolStripMenuItem_delete.Size = new System.Drawing.Size(67, 20);
            this.ToolStripMenuItem_delete.Text = "删除记录";
            this.ToolStripMenuItem_delete.Click += new System.EventHandler(this.ToolStripMenuItem_delete_Click);
            // 
            // ToolStripMenuItem_search
            // 
            ToolStripMenuItem_search.Name = "ToolStripMenuItem_search";
            ToolStripMenuItem_search.Size = new System.Drawing.Size(43, 20);
            ToolStripMenuItem_search.Text = "搜索";
            // 
            // FormShizhu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 523);
            this.Controls.Add(this.dgvShizhu);
            this.Controls.Add(this.menuStrip_shizhu);
            this.MainMenuStrip = this.menuStrip_shizhu;
            this.Name = "FormShizhu";
            this.Text = "FormShizhu";
            this.Load += new System.EventHandler(this.FormShizhu_Load);
            this.menuStrip_shizhu.ResumeLayout(false);
            this.menuStrip_shizhu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShizhu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_shizhu;
        private System.Windows.Forms.DataGridView dgvShizhu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIANHAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn XINGMING;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIZHU_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn XINGBIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOME_ADDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUXIAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHENGSHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUOJI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZIPCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOBILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDU_BKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHENFENZHENG;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIRTH_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NONGLI_BIRTH;
        private CalendarColumn GONGLI_BIRTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SANGUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn WUJIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TUIXIN;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_add;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_modify;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_delete;
    }
}