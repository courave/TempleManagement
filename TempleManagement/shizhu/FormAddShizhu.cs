using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempleManagement.pub;

namespace TempleManagement.shizhu
{
    public partial class FormAddShizhu : Form
    {
        private bool isNew = true;
        private String shizhuid = "-1";
        public FormAddShizhu():this(true,"-1"){}
        public FormAddShizhu(bool _isNew, String _shizhuid)
        {
            InitializeComponent();
            isNew = _isNew;
            shizhuid = _shizhuid;
        }
        private void InitData()
        {
            if (!isNew)
            {
                this.Text = "更改记录";
                button_confirm.Text = "确定更改";
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable("SELECT [BIANHAO],[XINGMING],[XINGBIE],[HOME_ADDR],[ZIPCODE],[TELE],[MOBILE],[SHIZHU_TYPE] "+
                                ",[EMAIL],[EDU_BKG],[GUOJI],[SHENGSHI],[QUXIAN],[SHENFENZHENG],[BIRTH_TYPE],[NONGLI_BIRTH] "+
                                ",[GONGLI_BIRTH],[TUIXIN],[SANGUI],[WUJIE] FROM [SHIZHU_INFO] WHERE ID="+shizhuid);
                    if (dt.Rows.Count != 1) return;
                    DataRow dr = dt.Rows[0];
                    textBox_bianhao.Text = dr[0].ToString();
                    textBox_xingming.Text = dr[1].ToString();
                    comboBox_xingbie.Text = dr[2].ToString();
                    textBox_homeaddr.Text = dr[3].ToString();
                    textBox_zipcode.Text = dr[4].ToString();
                    textBox_tele.Text = dr[5].ToString();
                    textBox_mobile.Text = dr[6].ToString();
                    comboBox_shizhutype.Text = dr[7].ToString();
                    textBox_email.Text = dr[8].ToString();
                    comboBox_edu.Text = dr[9].ToString();
                    textBox_guoji.Text = dr[10].ToString();
                    textBox_shengshi.Text = dr[11].ToString();
                    textBox_quxian.Text = dr[12].ToString();
                    textBox_shengfenzheng.Text = dr[13].ToString();
                    DateFormat calDate = new DateFormat();
                    if (dr[14].ToString() == "公历")
                    {
                        calDate.IsLunar = false;
                        calDate.isLeap = false;
                        DateTime gonglidate = Convert.ToDateTime(dr[16]);
                        calDate.year = gonglidate.Year;
                        calDate.month = gonglidate.Month;
                        calDate.day = gonglidate.Day;
                        calendarView_birth.DateValue = calDate;
                    }
                    else if(dr[14].ToString()=="农历")
                    {
                        calDate.IsLunar = true;
                        String nonglidate = dr[15].ToString();
                        if (nonglidate.IndexOf('R') > 0)
                            calDate.isLeap = true;
                        else calDate.isLeap = false;
                        int year = 1900;
                        int month = 1;
                        int day = 1;
                        if(int.TryParse(nonglidate.Substring(0,4),out year) &&
                           int.TryParse(nonglidate.Substring(5,2),out month) &&
                           int.TryParse(nonglidate.Substring(8, 2), out day))
                        {
                            calDate.year = year;
                            calDate.month = month;
                            calDate.day = day;
                            calendarView_birth.DateValue = calDate;
                        }
                    }
                    comboBox_tuixin.Text = dr[17].ToString();
                    textBox_sangui.Text = dr[18].ToString();
                    textBox_wujie.Text = dr[19].ToString();

                }
            }
            else
            {
                textBox_guoji.Text = "中国";
                textBox_shengshi.Text = "上海";
                textBox_bianhao.Text = GenBianhao();
                comboBox_tuixin.Text = "否";
            }
        }
        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (!CheckDataValidation())
            {
                MessageBox.Show("数据输入不完整!");
                return;
            }
            if (SaveChanges())
            {
                MessageBox.Show("成功" + (isNew ? "新增" : "修改") + "记录!");
                if (isNew)
                    ClearControls();
                else this.Close();
            }
            else
            {
                MessageBox.Show((isNew ? "新增" : "修改") + "记录失败!");
            }
        }
        private bool SaveChanges()
        {
            String bianhao = textBox_bianhao.Text;
            String xingming = textBox_xingming.Text;
            String xingbie = comboBox_xingbie.Text;
            String homeaddr = textBox_homeaddr.Text;
            String zipcode = textBox_zipcode.Text;
            String tele = textBox_tele.Text;
            String mobile = textBox_mobile.Text;
            String shizhutype = comboBox_shizhutype.Text;
            String email = textBox_email.Text;
            String edubkg = comboBox_edu.Text;
            String guoji = textBox_guoji.Text;
            String shengshi = textBox_shengshi.Text;
            String quxian = textBox_quxian.Text;
            String shenfenzheng = textBox_shengfenzheng.Text;
            String birthtype = "";
            String nonglidate = "";
            DateTime gonglidate = new DateTime(1800,1,1);
            if (calendarView_birth.Text!="" && calendarView_birth.DateValue != null)
            {
                DateFormat calDate = calendarView_birth.DateValue;
                if (calDate.IsLunar)
                {
                    birthtype = "农历";
                    nonglidate = calDate.year + "-" + (calDate.month < 10 ? "0" + calDate.month : calDate.month.ToString()) + "-" +
                        (calDate.day < 10 ? "0" + calDate.day : calDate.day.ToString());
                    if (calDate.isLeap)
                        nonglidate += "R";
                }
                else
                {
                    birthtype = "公历";
                    gonglidate = new DateTime(calDate.year, calDate.month, calDate.day);
                }
            }
            String tuixin = comboBox_tuixin.Text;
            String sangui = textBox_sangui.Text;
            String wujie = textBox_wujie.Text;
            String sql = "";
            using (DataBase db = new DataBase())
            {
                db.AddParameter("BIANHAO", bianhao);
                db.AddParameter("XINGMING", xingming);
                db.AddParameter("XINGBIE", xingbie);
                db.AddParameter("HOME_ADDR", homeaddr);
                db.AddParameter("ZIPCODE", zipcode);
                db.AddParameter("TELE", tele);
                db.AddParameter("MOBILE", mobile);
                db.AddParameter("SHIZHU_TYPE", shizhutype);
                db.AddParameter("EMAIL", email);
                db.AddParameter("EDU_BKG", edubkg);
                db.AddParameter("GUOJI", guoji);
                db.AddParameter("SHENGSHI", shengshi);
                db.AddParameter("QUXIAN", quxian);
                db.AddParameter("SHENFENZHENG", shenfenzheng);
                db.AddParameter("BIRTH_TYPE", birthtype);
                db.AddParameter("NONGLI_BIRTH", nonglidate);
                if (gonglidate.Year == 1800)
                    db.AddParameter("GONGLI_BIRTH", DBNull.Value);
                else
                    db.AddParameter("GONGLI_BIRTH", gonglidate);
                db.AddParameter("TUIXIN", tuixin);
                db.AddParameter("SANGUI", sangui);
                db.AddParameter("WUJIE", wujie);
                if (isNew)
                {
                    sql = "INSERT INTO [SHIZHU_INFO]([BIANHAO],[XINGMING],[XINGBIE],[HOME_ADDR],[ZIPCODE],[TELE] "+
                        ",[MOBILE],[SHIZHU_TYPE],[EMAIL],[EDU_BKG],[GUOJI],[SHENGSHI],[QUXIAN],[SHENFENZHENG] "+
                        ",[BIRTH_TYPE],[NONGLI_BIRTH],[GONGLI_BIRTH],[TUIXIN],[SANGUI],[WUJIE]) VALUES "+
                        "(@BIANHAO,@XINGMING,@XINGBIE,@HOME_ADDR,@ZIPCODE,@TELE,@MOBILE,@SHIZHU_TYPE,@EMAIL "+
                        ",@EDU_BKG,@GUOJI,@SHENGSHI,@QUXIAN,@SHENFENZHENG,@BIRTH_TYPE,@NONGLI_BIRTH "+
                        ",@GONGLI_BIRTH,@TUIXIN,@SANGUI,@WUJIE)";
                    if (db.ExecuteNonQuery(sql) == 1)
                        return true;
                }
                else
                {
                    sql = "UPDATE [SHIZHU_INFO] SET [BIANHAO]=@BIANHAO,[XINGMING]=@XINGMING, "+
                        "[XINGBIE]=@XINGBIE,[HOME_ADDR]=@HOME_ADDR,[ZIPCODE]=@ZIPCODE,[TELE]=@TELE, " +
                        "[MOBILE]=@MOBILE,[SHIZHU_TYPE]=@SHIZHU_TYPE,[EMAIL]=@EMAIL,[EDU_BKG]=@EDU_BKG, "+
                        "[GUOJI]=@GUOJI,[SHENGSHI]=@SHENGSHI,[QUXIAN]=@QUXIAN,[SHENFENZHENG]=@SHENFENZHENG, "+
                        "[BIRTH_TYPE]=@BIRTH_TYPE,[NONGLI_BIRTH]=@NONGLI_BIRTH,[GONGLI_BIRTH]=@GONGLI_BIRTH, "+
                        "[TUIXIN]=@TUIXIN,[SANGUI]=@SANGUI,[WUJIE]=@WUJIE WHERE ID="+shizhuid;
                    if (db.ExecuteNonQuery(sql) == 1)
                        return true;
                }
            }
            return false;
        }

        private String GenBianhao()
        {
            //TODO:needs implementation
            
            return new Random().Next().ToString();
        }

        private void ClearControls()
        {
            //throw new Exception("The method or operation is not implemented.");
            textBox_bianhao.Text = GenBianhao();
            textBox_xingming.Text = "";
            comboBox_xingbie.SelectedItem = null;
            textBox_homeaddr.Text = "";
            textBox_zipcode.Text = "";
            textBox_tele.Text = "";
            textBox_mobile.Text = "";
            comboBox_shizhutype.SelectedItem = null;
            textBox_email.Text = "";
            comboBox_edu.SelectedItem = null;
            textBox_shengfenzheng.Text = "";
            calendarView_birth.Text = "";
            calendarView_birth.DateValue = null;
            comboBox_tuixin.SelectedItem = null;
            textBox_sangui.Text = "";
            textBox_wujie.Text = "";

        }

        private void FormAddShizhu_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private Boolean CheckDataValidation()
        {
            if (textBox_bianhao.Text == "") return false;
            if (textBox_xingming.Text == "") return false;
            return true;
        }
    }
}
