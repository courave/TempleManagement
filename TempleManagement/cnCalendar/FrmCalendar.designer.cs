
partial class FrmCalendar
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
        this.rbtnGl = new System.Windows.Forms.RadioButton();
        this.rbtnNl = new System.Windows.Forms.RadioButton();
        this.cbYear = new System.Windows.Forms.ComboBox();
        this.cbMonth = new System.Windows.Forms.ComboBox();
        this.cbDay = new System.Windows.Forms.ComboBox();
        this.SuspendLayout();
        // 
        // rbtnGl
        // 
        this.rbtnGl.AutoSize = true;
        this.rbtnGl.Checked = true;
        this.rbtnGl.Location = new System.Drawing.Point(17, 8);
        this.rbtnGl.Name = "rbtnGl";
        this.rbtnGl.Size = new System.Drawing.Size(73, 17);
        this.rbtnGl.TabIndex = 0;
        this.rbtnGl.TabStop = true;
        this.rbtnGl.Text = "公历生日";
        this.rbtnGl.UseVisualStyleBackColor = true;
        // 
        // rbtnNl
        // 
        this.rbtnNl.AutoSize = true;
        this.rbtnNl.Location = new System.Drawing.Point(102, 8);
        this.rbtnNl.Name = "rbtnNl";
        this.rbtnNl.Size = new System.Drawing.Size(73, 17);
        this.rbtnNl.TabIndex = 1;
        this.rbtnNl.Text = "农历生日";
        this.rbtnNl.UseVisualStyleBackColor = true;
        this.rbtnNl.CheckedChanged += new System.EventHandler(this.rbtnNl_CheckedChanged);
        // 
        // cbYear
        // 
        this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbYear.FormattingEnabled = true;
        this.cbYear.Location = new System.Drawing.Point(13, 35);
        this.cbYear.Name = "cbYear";
        this.cbYear.Size = new System.Drawing.Size(108, 21);
        this.cbYear.TabIndex = 2;
        this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
        // 
        // cbMonth
        // 
        this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbMonth.FormattingEnabled = true;
        this.cbMonth.Location = new System.Drawing.Point(126, 35);
        this.cbMonth.Name = "cbMonth";
        this.cbMonth.Size = new System.Drawing.Size(59, 21);
        this.cbMonth.TabIndex = 3;
        this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
        // 
        // cbDay
        // 
        this.cbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbDay.FormattingEnabled = true;
        this.cbDay.Location = new System.Drawing.Point(190, 35);
        this.cbDay.Name = "cbDay";
        this.cbDay.Size = new System.Drawing.Size(59, 21);
        this.cbDay.TabIndex = 4;
        // 
        // FrmCalendar
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
        this.ClientSize = new System.Drawing.Size(263, 65);
        this.Controls.Add(this.cbDay);
        this.Controls.Add(this.cbMonth);
        this.Controls.Add(this.cbYear);
        this.Controls.Add(this.rbtnNl);
        this.Controls.Add(this.rbtnGl);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "FrmCalendar";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Text = "FrmCalendar";
        this.Load += new System.EventHandler(this.FrmCalendar_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbtnGl;
    private System.Windows.Forms.RadioButton rbtnNl;
    private System.Windows.Forms.ComboBox cbYear;
    private System.Windows.Forms.ComboBox cbMonth;
    private System.Windows.Forms.ComboBox cbDay;
}
