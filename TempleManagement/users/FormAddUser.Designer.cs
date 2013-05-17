namespace TempleManagement.users
{
    partial class FormAddUser
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_nickname = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_passwordconfirm = new System.Windows.Forms.TextBox();
            this.comboBox_role = new System.Windows.Forms.ComboBox();
            this.button_confirm = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 13);
            label1.TabIndex = 0;
            label1.Text = "用户名:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(36, 50);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 13);
            label2.TabIndex = 0;
            label2.Text = "昵称:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(36, 88);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(34, 13);
            label3.TabIndex = 0;
            label3.Text = "密码:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 126);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 13);
            label4.TabIndex = 0;
            label4.Text = "密码确认:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(36, 164);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(34, 13);
            label5.TabIndex = 0;
            label5.Text = "角色:";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(76, 9);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(144, 20);
            this.textBox_username.TabIndex = 1;
            // 
            // textBox_nickname
            // 
            this.textBox_nickname.Location = new System.Drawing.Point(76, 47);
            this.textBox_nickname.Name = "textBox_nickname";
            this.textBox_nickname.Size = new System.Drawing.Size(144, 20);
            this.textBox_nickname.TabIndex = 2;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(76, 85);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(144, 20);
            this.textBox_password.TabIndex = 3;
            this.textBox_password.Enter += new System.EventHandler(this.textBox_password_Enter);
            this.textBox_password.Leave += new System.EventHandler(this.textBox_password_Leave);
            // 
            // textBox_passwordconfirm
            // 
            this.textBox_passwordconfirm.Location = new System.Drawing.Point(76, 123);
            this.textBox_passwordconfirm.Name = "textBox_passwordconfirm";
            this.textBox_passwordconfirm.Size = new System.Drawing.Size(144, 20);
            this.textBox_passwordconfirm.TabIndex = 4;
            this.textBox_passwordconfirm.Enter += new System.EventHandler(this.textBox_passwordconfirm_Enter);
            this.textBox_passwordconfirm.Leave += new System.EventHandler(this.textBox_passwordconfirm_Leave);
            // 
            // comboBox_role
            // 
            this.comboBox_role.FormattingEnabled = true;
            this.comboBox_role.Location = new System.Drawing.Point(76, 161);
            this.comboBox_role.Name = "comboBox_role";
            this.comboBox_role.Size = new System.Drawing.Size(144, 21);
            this.comboBox_role.TabIndex = 5;
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(145, 208);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 6;
            this.button_confirm.Text = "确定新增";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // FormAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 243);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.comboBox_role);
            this.Controls.Add(this.textBox_passwordconfirm);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_nickname);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "FormAddUser";
            this.Text = "新增用户";
            this.Load += new System.EventHandler(this.FormAddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_nickname;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_passwordconfirm;
        private System.Windows.Forms.ComboBox comboBox_role;
        private System.Windows.Forms.Button button_confirm;
    }
}