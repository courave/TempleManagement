namespace TempleManagement.print
{
    partial class FormPrintWangMultiple
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
            this.crystalReportViewer_wangmultiple = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer_wangmultiple
            // 
            this.crystalReportViewer_wangmultiple.ActiveViewIndex = -1;
            this.crystalReportViewer_wangmultiple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_wangmultiple.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer_wangmultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_wangmultiple.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_wangmultiple.Name = "crystalReportViewer_wangmultiple";
            this.crystalReportViewer_wangmultiple.ShowGroupTreeButton = false;
            this.crystalReportViewer_wangmultiple.ShowParameterPanelButton = false;
            this.crystalReportViewer_wangmultiple.ShowRefreshButton = false;
            this.crystalReportViewer_wangmultiple.ShowTextSearchButton = false;
            this.crystalReportViewer_wangmultiple.Size = new System.Drawing.Size(442, 387);
            this.crystalReportViewer_wangmultiple.TabIndex = 0;
            this.crystalReportViewer_wangmultiple.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormPrintWangMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 387);
            this.Controls.Add(this.crystalReportViewer_wangmultiple);
            this.Name = "FormPrintWangMultiple";
            this.Text = "FormPrintWangMultiple";
            this.Load += new System.EventHandler(this.FormPrintWangMultiple_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_wangmultiple;
    }
}