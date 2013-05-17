using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempleManagement.users
{
    public partial class FormAddUser : Form
    {
        private bool isNew = true;
        private string userid = "-1";
        public FormAddUser():this(true,"-1"){}
        public FormAddUser(bool _isNew, string _userid)
        {
            InitializeComponent();
            isNew = _isNew;
            userid = _userid;
        }
        private void FormAddUser_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void InitData()
        {
            //init combo role
            using (pub.DataBase db = new pub.DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT ID,ROLE_NAME FROM ROLE_INFO");
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox_role.Items.Add(new ComboItem(dr[0].ToString(), dr[1].ToString()));
                }
            }
            if (isNew) { textBox_password.PasswordChar = '*'; textBox_passwordconfirm.PasswordChar = '*'; return; }
            this.Text = "更改用户信息";
            button_confirm.Text = "确定更改";
            using (pub.DataBase db = new pub.DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT [USER_NAME],[NICK_NAME],[ROLE_ID] FROM [USER_INFO] WHERE ID=" + userid);
                if (dt.Rows.Count != 1)
                    return;
                textBox_password.Text = "<未更改>";
                textBox_passwordconfirm.Text = "<未更改>";
                textBox_username.Text = dt.Rows[0][0].ToString();
                textBox_nickname.Text = dt.Rows[0][1].ToString();
                foreach (ComboItem item in comboBox_role.Items)
                {
                    if (item.Key == dt.Rows[0][2].ToString())
                    {
                        comboBox_role.SelectedItem = item;
                        break;
                    }
                }


            }
        }

        private void textBox_password_Enter(object sender, EventArgs e)
        {
            if (textBox_password.Text != "<未更改>") return;
            textBox_password.Text = "";
            textBox_password.PasswordChar = '*';
        }

        private void textBox_password_Leave(object sender, EventArgs e)
        {
            if (textBox_password.Text == "")
            {
                textBox_password.PasswordChar = '\0';
                textBox_password.Text = "<未更改>";
            }
        }

        private void textBox_passwordconfirm_Enter(object sender, EventArgs e)
        {
            if (textBox_passwordconfirm.Text != "<未更改>") return;
            textBox_passwordconfirm.Text = "";
            textBox_passwordconfirm.PasswordChar = '*';
        }

        private void textBox_passwordconfirm_Leave(object sender, EventArgs e)
        {
            if (textBox_passwordconfirm.Text == "")
            {
                textBox_passwordconfirm.PasswordChar = '\0';
                textBox_passwordconfirm.Text = "<未更改>";
            }
        }
        private bool CheckDataValidation()
        {
            if (textBox_username.Text == "") return false;
            if (textBox_nickname.Text == "") return false;
            if (textBox_password.Text != textBox_passwordconfirm.Text) return false;
            if (isNew && textBox_password.Text == "") return false;
            if (comboBox_role.SelectedItem == null) return false;
            return true;
        }
        private bool SaveChanges()
        {
            if (!CheckDataValidation())
            {
                MessageBox.Show("输入有误,请核查后输入!");
                return false;
            }
            using (pub.DataBase db = new pub.DataBase())
            {
                db.AddParameter("USERNAME", textBox_username.Text);
                db.AddParameter("NICKNAME", textBox_nickname.Text);
                db.AddParameter("ROLE_ID", ((ComboItem)comboBox_role.SelectedItem).Key);
                if (isNew)
                {
                    db.AddParameter("PASSWORD", pub.Cryptography.Encrypt(textBox_password.Text));
                    db.ExecuteNonQuery("INSERT INTO [USER_INFO]([USER_NAME],[PASSWORD],[NICK_NAME],[ROLE_ID]) " +
                                        "VALUES (@USERNAME,@PASSWORD,@NICKNAME,@ROLE_ID)");

                }
                else
                {
                    db.AddParameter("ID", userid);
                    if (textBox_password.Text == "<未更改>" || textBox_password.Text == "")
                    {
                        db.ExecuteNonQuery("UPDATE [USER_INFO] SET [USER_NAME]=@USERNAME,[NICK_NAME]=@NICKNAME,[ROLE_ID]=@ROLE_ID WHERE ID=@ID");
                    }
                    else
                    {
                        db.AddParameter("PASSWORD", pub.Cryptography.Encrypt(textBox_password.Text));
                        db.ExecuteNonQuery("UPDATE [CJ_ADMIN] SET [USER_NAME]=@USERNAME,[PASSWORD]=@PASSWORD,[NICK_NAME]=@NICKNAME,[ROLE_ID]=@ROLE_ID WHERE ID=@ID");
                    }
                }
            }
            return true;
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (SaveChanges())
            {
                this.Close();
            }
        }
    }
}
