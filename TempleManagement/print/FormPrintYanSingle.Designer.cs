namespace TempleManagement.print
{
    partial class FormPrintYanSingle
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
            this.crystalReportViewer_printyansingle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer_printyansingle
            // 
            this.crystalReportViewer_printyansingle.ActiveViewIndex = -1;
            this.crystalReportViewer_printyansingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_printyansingle.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer_printyansingle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_printyansingle.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_printyansingle.Name = "crystalReportViewer_printyansingle";
            this.crystalReportViewer_printyansingle.ShowGroupTreeButton = false;
            this.crystalReportViewer_printyansingle.ShowParameterPanelButton = false;
            this.crystalReportViewer_printyansingle.ShowRefreshButton = false;
            this.crystalReportViewer_printyansingle.ShowTextSearchButton = false;
            this.crystalReportViewer_printyansingle.Size = new System.Drawing.Size(592, 519);
            this.crystalReportViewer_printyansingle.TabIndex = 0;
            this.crystalReportViewer_printyansingle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormPrintYanSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 519);
            this.Controls.Add(this.crystalReportViewer_printyansingle);
            this.Name = "FormPrintYanSingle";
            this.Text = "FormPrintYanSingle";
            this.Load += new System.EventHandler(this.FormPrintYanSingle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_printyansingle;
    }
}