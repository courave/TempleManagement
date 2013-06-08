namespace TempleManagement.print
{
    partial class FormPrintYanMultiple
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
            this.crystalReportViewer_printyanmultiple = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer_printyanmultiple
            // 
            this.crystalReportViewer_printyanmultiple.ActiveViewIndex = -1;
            this.crystalReportViewer_printyanmultiple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_printyanmultiple.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer_printyanmultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_printyanmultiple.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_printyanmultiple.Name = "crystalReportViewer_printyanmultiple";
            this.crystalReportViewer_printyanmultiple.ShowGroupTreeButton = false;
            this.crystalReportViewer_printyanmultiple.ShowParameterPanelButton = false;
            this.crystalReportViewer_printyanmultiple.ShowRefreshButton = false;
            this.crystalReportViewer_printyanmultiple.ShowTextSearchButton = false;
            this.crystalReportViewer_printyanmultiple.Size = new System.Drawing.Size(604, 515);
            this.crystalReportViewer_printyanmultiple.TabIndex = 0;
            this.crystalReportViewer_printyanmultiple.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormPrintYanMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 515);
            this.Controls.Add(this.crystalReportViewer_printyanmultiple);
            this.Name = "FormPrintYanMultiple";
            this.Text = "FormPrintYanMultiple";
            this.Load += new System.EventHandler(this.FormPrintYanMultiple_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_printyanmultiple;
    }
}