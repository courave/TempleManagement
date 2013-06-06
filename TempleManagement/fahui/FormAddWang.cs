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
    public partial class FormAddWang : Form
    {
        private String fahuiid = "-1";
        private Boolean isNew = true;
        private String wangid = "-1";
        private Boolean showSwitch = true;
        public FormAddWang(String _fahuiid)
        {
            InitializeComponent();
            fahuiid = _fahuiid;
            isNew = true;
            wangid = "-1";
        }
        public FormAddWang(String _fahuiid,Boolean _showSwitch)
        {
            InitializeComponent();
            fahuiid = _fahuiid;
            isNew = true;
            wangid = "-1";
            showSwitch = _showSwitch;
        }
        public FormAddWang(String fahuiyear, String fahuiname)
        {
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT ID FROM FAHUI_LIST WHERE FAHUI_YEAR=" + fahuiyear + " AND FAHUI_NAME='" + fahuiname + "'");
                if (dt.Rows.Count == 0) { MessageBox.Show("请先选择法会!"); this.Close(); }
                InitializeComponent();
                fahuiid = dt.Rows[0][0].ToString();
                isNew = true;
                wangid = "-1";
            }
        }
        public FormAddWang(Boolean _isNew, String _wangid)
        {
            isNew = _isNew;
            wangid = _wangid;
            InitializeComponent();
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
                MessageBox.Show((isNew ? "新增" : "更新") + "记录失败!");
            }
        }

        private Boolean SaveChanges()
        {
            String zihao = comboBox_zihao.Text;
            String zuoci = textBox_zuoci.Text;
            String jieyin1 = textBox_jieyin1.Text;
            String jieyin2 = textBox_jieyin2.Text;
            String jieyin3 = textBox_jieyin3.Text;
            String jieyin4 = textBox_jieyin4.Text;
            String ys1 = textBox_ys1.Text;
            String ys2 = textBox_ys2.Text;
            String ys3 = textBox_ys3.Text;
            String ys4 = textBox_ys4.Text;
            if (jieyin1 == "" && jieyin2 == "" && jieyin3 == "" && jieyin4 == "") return false;
            String sql = "";
            using (DataBase db = new DataBase())
            {
                db.AddParameter("ZUOCI", zuoci);
                db.AddParameter("ZIHAO", zihao);
                db.AddParameter("JIEYIN1", jieyin1);
                db.AddParameter("JIEYIN2", jieyin2);
                db.AddParameter("JIEYIN3", jieyin3);
                db.AddParameter("JIEYIN4", jieyin4);
                db.AddParameter("YANGSHANG1", ys1);
                db.AddParameter("YANGSHANG2", ys2);
                db.AddParameter("YANGSHANG3", ys3);
                db.AddParameter("YANGSHANG4", ys4);

                if (isNew)
                {
                    db.AddParameter("HAS_PRINT", false);
                    db.AddParameter("FAHUI_ID", fahuiid);
                    sql="INSERT INTO [FAHUI_WANG] ([ZUOCI],[ZIHAO],[JIEYIN1],[JIEYIN2],[JIEYIN3],[JIEYIN4],[YANGSHANG1], "+
                        "[YANGSHANG2],[YANGSHANG3],[YANGSHANG4],[HAS_PRINT],[FAHUI_ID]) VALUES (@ZUOCI,@ZIHAO,@JIEYIN1, "+
                        "@JIEYIN2,@JIEYIN3,@JIEYIN4,@YANGSHANG1,@YANGSHANG2,@YANGSHANG3,@YANGSHANG4,@HAS_PRINT,@FAHUI_ID)";
                }
                else
                {
                    db.AddParameter("ID", wangid);
                    sql = "UPDATE [FAHUI_WANG] SET [ZUOCI] = @ZUOCI,[ZIHAO] = @ZIHAO,[JIEYIN1] = @JIEYIN1,[JIEYIN2] = @JIEYIN2 " +
                            ",[JIEYIN3] = @JIEYIN3,[JIEYIN4] = @JIEYIN4,[YANGSHANG1] = @YANGSHANG1,[YANGSHANG2] = @YANGSHANG2 " +
                            ",[YANGSHANG3] = @YANGSHANG3,[YANGSHANG4] = @YANGSHANG4 WHERE ID=@ID";
                }
                if (db.ExecuteNonQuery(sql) == 1) return true;
            }
            return false;
        }

        private void ClearControls()
        {
            int zuoci = 0;
            int.TryParse(textBox_zuoci.Text, out zuoci);
            zuoci++;
            textBox_zuoci.Text = zuoci.ToString();
            textBox_jieyin1.Text = "";
            textBox_jieyin2.Text = "";
            textBox_jieyin3.Text = "";
            textBox_jieyin4.Text = "";
            textBox_ys1.Text = "";
            textBox_ys2.Text = "";
            textBox_ys3.Text = "";
            textBox_ys4.Text = "";
        }

        public void InitData()
        {
            if (!isNew)
            {
                using (DataBase db = new DataBase())
                {
                    String sql = "SELECT FAHUI_YEAR,FAHUI_NAME FROM FAHUI_LIST A,FAHUI_WANG B WHERE A.ID=B.FAHUI_ID AND B.ID=" + wangid;
                    DataTable dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count == 1)
                    {
                        lblFahui.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
                    }
                    sql = "SELECT [ZUOCI],[ZIHAO],[JIEYIN1],[JIEYIN2],[JIEYIN3],[JIEYIN4],[YANGSHANG1],[YANGSHANG2],[YANGSHANG3],[YANGSHANG4] FROM [FAHUI_WANG] WHERE ID="+wangid;
                    dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count != 1) return;
                    textBox_zuoci.Text = dt.Rows[0][0].ToString();
                    comboBox_zihao.Text = dt.Rows[0][1].ToString();
                    textBox_jieyin1.Text = dt.Rows[0][2].ToString();
                    textBox_jieyin2.Text = dt.Rows[0][3].ToString();
                    textBox_jieyin3.Text = dt.Rows[0][4].ToString();
                    textBox_jieyin4.Text = dt.Rows[0][5].ToString();
                    textBox_ys1.Text = dt.Rows[0][6].ToString();
                    textBox_ys2.Text = dt.Rows[0][7].ToString();
                    textBox_ys3.Text = dt.Rows[0][8].ToString();
                    textBox_ys4.Text = dt.Rows[0][9].ToString();
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
                    sql = "SELECT MAX(ZUOCI) FROM FAHUI_WANG WHERE FAHUI_ID=" + fahuiid;
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

        private void FormAddWang_Load(object sender, EventArgs e)
        {
            InitData();
            if (!showSwitch) button_switch.Enabled = false;
        }

        private void button_switch_Click(object sender, EventArgs e)
        {
            this.Close();
            
            FormAddYan frmAddYan = new FormAddYan(fahuiid);
            frmAddYan.Show();
            frmAddYan.Activate();
            
        }

    }
}
