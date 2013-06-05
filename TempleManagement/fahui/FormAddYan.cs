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
    public partial class FormAddYan : Form
    {
        private String fahuiid="-1";
        private Boolean isNew = true;
        private String yanid = "-1";
        public FormAddYan(String _fahuiid)
        {
            InitializeComponent();
            fahuiid = _fahuiid;
            isNew = true;
            yanid = "-1";
        }
        public FormAddYan(String fahuiyear, String fahuiname)
        {
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT ID FROM FAHUI_LIST WHERE FAHUI_YEAR=" + fahuiyear + " AND FAHUI_NAME='" + fahuiname + "'");
                if (dt.Rows.Count == 0) { MessageBox.Show("请先选择法会!"); this.Close(); }
                InitializeComponent();
                fahuiid = dt.Rows[0][0].ToString();
                isNew = true;
                yanid = "-1";
            }
        }
        public FormAddYan(Boolean _isNew, String _yanid)
        {
            isNew = _isNew;
            yanid = _yanid;
        }
        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (SaveChanges())
            {
                if (isNew)
                    ClearControls();
                else
                    this.Close();
            }
            else
            {
                MessageBox.Show((isNew?"新增":"更新")+"记录失败!");
            }
        }
        private Boolean SaveChanges()
        {
            String zihao = comboBox_zihao.Text;
            String zuoci = textBox_zuoci.Text;
            String zhuzhao1 = textBox_zhuzhao1.Text;
            String zhuzhao2 = textBox_zhuzhao2.Text;
            String zhuzhao3 = textBox_zhuzhao3.Text;
            String zhuzhao4 = textBox_zhuzhao4.Text;
            if (zhuzhao1 == "" && zhuzhao2 == "" && zhuzhao3 == "" && zhuzhao4 == "") return false;
            String sql = "";
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ZHUZHAO1", zhuzhao1);
                db.AddParameter("ZHUZHAO2", zhuzhao2);
                db.AddParameter("ZHUZHAO3", zhuzhao3);
                db.AddParameter("ZHUZHAO4", zhuzhao4);
                db.AddParameter("ZUOCI", zuoci);
                db.AddParameter("ZIHAO", zihao);

                if (isNew)
                {
                    db.AddParameter("HAS_PRINT", false);
                    db.AddParameter("FAHUI_ID", fahuiid);
                    sql = "INSERT INTO [FAHUI_YAN]([ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO],[HAS_PRINT],[FAHUI_ID]) " +
                            "VALUES (@ZHUZHAO1,@ZHUZHAO2,@ZHUZHAO3,@ZHUZHAO4,@ZUOCI,@ZIHAO,@HAS_PRINT,@FAHUI_ID)";
                }
                else
                {
                    db.AddParameter("ID", yanid);
                    sql = "UPDATE [FAHUI_YAN] SET [ZHUZHAO1] = @ZHUZHAO1,[ZHUZHAO2] = @ZHUZHAO2,[ZHUZHAO3] = @ZHUZHAO3 " +
                        ",[ZHUZHAO4] = @ZHUZHAO4,[ZUOCI] = @ZUOCI,[ZIHAO] = @ZIHAO WHERE ID=@ID";
                }
                if (db.ExecuteNonQuery(sql) == 1) return true;
            }
            return false;
        }

        private void ClearControls()
        {
            //throw new Exception("The method or operation is not implemented.");
            int zuoci = 0;
            int.TryParse(textBox_zuoci.Text, out zuoci);
            zuoci++;
            textBox_zuoci.Text = zuoci.ToString();
            textBox_zhuzhao1.Text = "";
            textBox_zhuzhao2.Text = "";
            textBox_zhuzhao3.Text = "";
            textBox_zhuzhao4.Text = "";
        }
        private void InitData()
        {
            if (!isNew)
            {
                using (DataBase db = new DataBase())
                {
                    String sql = "SELECT FAHUI_YEAR,FAHUI_NAME FROM FAHUI_LIST A,FAHUI_YAN B WHERE A.ID=B.FAHUI_ID AND B.ID="+yanid;
                    DataTable dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count == 1)
                    {
                        lblFahui.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
                    }
                }
                this.Text = "更改信息";
                button_confirm.Text = "确定更改";
                button_switch.Enabled = false;
            }
            else
            {
                using (DataBase db = new DataBase())
                {
                    //lblFahui
                    String sql = "SELECT FAHUI_YEAR,FAHUI_NAME FROM FAHUI_LIST WHERE ID=" + fahuiid;
                    DataTable dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count == 1)
                    {
                        lblFahui.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
                    }
                    //zihao
                    comboBox_zihao.Text = "天";
                    //zuoci
                    sql = "SELECT MAX(ZUOCI) FROM FAHUI_YAN WHERE FAHUI_ID="+fahuiid;
                    dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count == 1)
                    {
                        int zuoci = 0;
                        int.TryParse(dt.Rows[0][0].ToString(), out zuoci);
                        zuoci++;
                        textBox_zuoci.Text = zuoci.ToString();
                    }

                }
            }

        }

        private void FormAddYan_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
