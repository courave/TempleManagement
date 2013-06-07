namespace TempleManagement.print
{
    partial class FormPrintWangSingle
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
            this.crystalReportViewer_wangsingle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer_wangsingle
            // 
            this.crystalReportViewer_wangsingle.ActiveViewIndex = -1;
            this.crystalReportViewer_wangsingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_wangsingle.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer_wangsingle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_wangsingle.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_wangsingle.Name = "crystalReportViewer_wangsingle";
            this.crystalReportViewer_wangsingle.ShowGroupTreeButton = false;
            this.crystalReportViewer_wangsingle.ShowParameterPanelButton = false;
            this.crystalReportViewer_wangsingle.ShowRefreshButton = false;
            this.crystalReportViewer_wangsingle.ShowTextSearchButton = false;
            this.crystalReportViewer_wangsingle.Size = new System.Drawing.Size(547, 577);
            this.crystalReportViewer_wangsingle.TabIndex = 0;
            this.crystalReportViewer_wangsingle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormPrintWangSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 577);
            this.Controls.Add(this.crystalReportViewer_wangsingle);
            this.Name = "FormPrintWangSingle";
            this.Text = "FormPrintWangSingle";
            this.Load += new System.EventHandler(this.FormPrintWangSingle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_wangsingle;
    }
}