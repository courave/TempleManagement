namespace TempleManagement.fahui
{
    partial class FormAddFahui
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.dateTimePicker_year = new System.Windows.Forms.DateTimePicker();
            this.comboBox_fahuiname = new System.Windows.Forms.ComboBox();
            this.button_confirm = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(36, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 13);
            label1.TabIndex = 0;
            label1.Text = "年份:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 66);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 13);
            label2.TabIndex = 0;
            label2.Text = "法会名称:";
            // 
            // dateTimePicker_year
            // 
            this.dateTimePicker_year.CustomFormat = "yyyy";
            this.dateTimePicker_year.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_year.Location = new System.Drawing.Point(76, 20);
            this.dateTimePicker_year.Name = "dateTimePicker_year";
            this.dateTimePicker_year.ShowUpDown = true;
            this.dateTimePicker_year.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker_year.TabIndex = 1;
            // 
            // comboBox_fahuiname
            // 
            this.comboBox_fahuiname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_fahuiname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_fahuiname.FormattingEnabled = true;
            this.comboBox_fahuiname.Location = new System.Drawing.Point(76, 63);
            this.comboBox_fahuiname.Name = "comboBox_fahuiname";
            this.comboBox_fahuiname.Size = new System.Drawing.Size(121, 21);
            this.comboBox_fahuiname.TabIndex = 2;
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(122, 111);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 3;
            this.button_confirm.Text = "确定添加";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // FormAddFahui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 146);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.comboBox_fahuiname);
            this.Controls.Add(this.dateTimePicker_year);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "FormAddFahui";
            this.Text = "添加法会";
            this.Load += new System.EventHandler(this.FormAddFahui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_year;
        private System.Windows.Forms.ComboBox comboBox_fahuiname;
        private System.Windows.Forms.Button button_confirm;

    }
}