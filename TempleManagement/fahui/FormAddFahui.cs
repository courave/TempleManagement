using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempleManagement.pub;

namespace TempleManagement.fahui
{
    public partial class FormAddFahui : Form
    {
        private Boolean isNew = true;
        private String fahuiid = "-1";
        public FormAddFahui():this(true,"-1"){}
        public FormAddFahui(Boolean _isNew, String _fahuiid)
        {
            InitializeComponent();
            isNew = _isNew;
            fahuiid = _fahuiid;
        }

        private void FormAddFahui_Load(object sender, EventArgs e)
        {
            InitData();
            
        }

        private void InitCombo()
        {
            String sql = "SELECT DISTINCT [FAHUI_NAME] FROM [FAHUI_LIST]";
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox_fahuiname.Items.Add(dr[0].ToString());
                }
            }
        }

        private void InitData()
        {
            InitCombo();
            if (!isNew)
            {
                this.Text = "修改法会";
                button_confirm.Text = "确定修改";
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("SELECT FAHUI_YEAR,FAHUI_NAME FROM FAHUI_LIST WHERE ID="+fahuiid);
                    if (dt.Rows.Count != 1) return;
                    dateTimePicker_year.Value = new DateTime(Convert.ToInt32(dt.Rows[0][0]), 1, 1);
                    comboBox_fahuiname.Text = dt.Rows[0][1].ToString();

                }
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            int year = dateTimePicker_year.Value.Year;
            String fahuiname = comboBox_fahuiname.Text;
            using (DataBase db = new DataBase())
            {
                db.AddParameter("FAHUI_YEAR", year);
                db.AddParameter("FAHUI_NAME", fahuiname);
                if (isNew)
                {
                    if (CheckExist(year.ToString(), fahuiname))
                    {
                        String Msg = "已存在该法会,要直接进入吗?\n'是':直接进入该法会进行编辑\n'否':不管,继续添加\n'取消':退出";
                        DialogResult dr = MessageBox.Show(Msg, "已存在该法会", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //throw new Exception("The method or operation is not implemented.");
                            //直接进入
                            FormAddYan frmAddYan = new FormAddYan(year.ToString(), fahuiname);
                            frmAddYan.Show();
                            frmAddYan.TopLevel = true;
                            this.Close();
                            return;
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            this.Close();
                            return;
                        }
                    }
                    DataTable dt=db.ExecuteDataTable("INSERT INTO FAHUI_LIST(FAHUI_YEAR,FAHUI_NAME) VALUES(@FAHUI_YEAR,@FAHUI_NAME) SELECT IDENT_CURRENT('FAHUI_LIST')");
                    if (dt.Rows.Count != 1 || Convert.ToInt32(dt.Rows[0][0]) < 1)
                    {
                        MessageBox.Show("添加法会失败!");
                        return;
                    }
                    fahuiid = dt.Rows[0][0].ToString();
                }
                else
                {
                    int iret = db.ExecuteNonQuery("UPDATE FAHUI_LIST SET FAHUI_YEAR=@FAHUI_YEAR,FAHUI_NAME=@FAHUI_NAME WHERE ID="+fahuiid);
                    if (iret != 1)
                    {
                        MessageBox.Show("更新法会失败!");
                        return;
                    }
                }
                //todo
                //throw new Exception("The method or operation is not implemented.");
                FormAddYan frmAddYan1 = new FormAddYan(fahuiid);
                frmAddYan1.Show();
                frmAddYan1.TopLevel = true;
                this.Close();
            }
        }

        private Boolean CheckExist(String fahuiyear, String fahuiname)
        {
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT ID FROM FAHUI_LIST WHERE FAHUI_YEAR=" + fahuiyear + " AND FAHUI_NAME='" + fahuiname + "'");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
