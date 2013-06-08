using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempleManagement.print
{
    public partial class FormPrintWangMultiple : Form
    {
        private String sql = "";
        private DataTable PrintDt = new DataTable();
        public FormPrintWangMultiple(String _fahuiid):this(_fahuiid,true){}
        public FormPrintWangMultiple(String _fahuiid, Boolean _printall)
        {
            InitializeComponent();
            sql = "SELECT [ZUOCI],[ZIHAO],[JIEYIN1],[JIEYIN2],[JIEYIN3],[JIEYIN4],[YANGSHANG1],[YANGSHANG2],[YANGSHANG3],[YANGSHANG4] FROM [FAHUI_WANG] WHERE FAHUI_ID=" + _fahuiid;
            if (!_printall)
                sql += " AND HAS_PRINT<>1";
            using (pub.DataBase db = new pub.DataBase())
            {
                PrintDt = db.ExecuteDataTable(sql);
            }
        }
        public FormPrintWangMultiple(DataTable _PrintDt)
        {
            InitializeComponent();
            PrintDt = _PrintDt;
        }
        private void FormPrintWangMultiple_Load(object sender, EventArgs e)
        {
            PrintTable(PrintDt);
        }

        private void PrintTable(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有需要打印的记录!");
                Dispose();
                return;
            }
            int i = 0;
            CrystalReport_wangmultiple reportWangMultiple = new CrystalReport_wangmultiple();
            List<ClassWangMultiple> printList = new List<ClassWangMultiple>();
            for (i = 0; i < dt.Rows.Count; i ++)
            {
                ClassWangMultiple wangMultiple = new ClassWangMultiple();
                String jieyin = "";
                String ys = "";
                DataRow dr=dt.Rows[i];
                wangMultiple.zihao_1 = dr["ZIHAO"].ToString();
                wangMultiple.zuoci_1 = dr["ZUOCI"].ToString();
                if (dr["JIEYIN1"].ToString() != "")
                    jieyin = dr["JIEYIN1"].ToString();
                if (dr["JIEYIN2"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN2"].ToString();
                if (dr["JIEYIN3"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN3"].ToString();
                if (dr["JIEYIN4"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN4"].ToString();
                if (dr["YANGSHANG1"].ToString() != "")
                    ys = dr["YANGSHANG1"].ToString();
                if (dr["YANGSHANG2"].ToString() != "")
                    ys += ";" + dr["YANGSHANG2"].ToString();
                if (dr["YANGSHANG3"].ToString() != "")
                    ys += ";" + dr["YANGSHANG3"].ToString();
                if (dr["YANGSHANG4"].ToString() != "")
                    ys += ";" + dr["YANGSHANG4"].ToString();
                String[] jieyins = jieyin.Split(';');
                if (jieyins.Count() > 0)
                {
                    wangMultiple.jieyin3_1 = jieyins[0].Trim(';');
                }
                if (jieyins.Count() > 1)
                {
                    wangMultiple.jieyin2_1 = jieyins[1].Trim(';');
                }
                if (jieyins.Count() > 2)
                {
                    wangMultiple.jieyin4_1 = jieyins[2].Trim(';');
                }
                if (jieyins.Count() > 3)
                {
                    wangMultiple.jieyin1_1 = jieyins[3].Trim(';');
                }
                String[] yss = ys.Split(';');
                if (yss.Count() > 0)
                {
                    wangMultiple.ys1_1 = yss[0].Trim(';');
                }
                if (yss.Count() > 1)
                {
                    wangMultiple.ys2_1 = yss[1].Trim(';');
                }
                if (yss.Count() > 2)
                {
                    wangMultiple.ys3_1 = yss[2].Trim(';');
                }
                if (yss.Count() > 3)
                {
                    wangMultiple.ys4_1 = yss[3].Trim(';');
                }
                //////////////////////////////////////////////////////////////////
                
                i++;
                if (i >= dt.Rows.Count) 
                {
                    printList.Add(wangMultiple);
                    break; 
                }
                jieyin = "";
                ys = "";
                dr = dt.Rows[i];
                wangMultiple.zihao_2 = dr["ZIHAO"].ToString();
                wangMultiple.zuoci_2 = dr["ZUOCI"].ToString();
                if (dr["JIEYIN1"].ToString() != "")
                    jieyin = dr["JIEYIN1"].ToString();
                if (dr["JIEYIN2"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN2"].ToString();
                if (dr["JIEYIN3"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN3"].ToString();
                if (dr["JIEYIN4"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN4"].ToString();
                if (dr["YANGSHANG1"].ToString() != "")
                    ys = dr["YANGSHANG1"].ToString();
                if (dr["YANGSHANG2"].ToString() != "")
                    ys += ";" + dr["YANGSHANG2"].ToString();
                if (dr["YANGSHANG3"].ToString() != "")
                    ys += ";" + dr["YANGSHANG3"].ToString();
                if (dr["YANGSHANG4"].ToString() != "")
                    ys += ";" + dr["YANGSHANG4"].ToString();
                jieyins = jieyin.Split(';');
                if (jieyins.Count() > 0)
                {
                    wangMultiple.jieyin3_2 = jieyins[0].Trim(';');
                }
                if (jieyins.Count() > 1)
                {
                    wangMultiple.jieyin2_2 = jieyins[1].Trim(';');
                }
                if (jieyins.Count() > 2)
                {
                    wangMultiple.jieyin4_2 = jieyins[2].Trim(';');
                }
                if (jieyins.Count() > 3)
                {
                    wangMultiple.jieyin1_2 = jieyins[3].Trim(';');
                }
                yss = ys.Split(';');
                if (yss.Count() > 0)
                {
                    wangMultiple.ys1_2 = yss[0].Trim(';');
                }
                if (yss.Count() > 1)
                {
                    wangMultiple.ys2_2 = yss[1].Trim(';');
                }
                if (yss.Count() > 2)
                {
                    wangMultiple.ys3_2 = yss[2].Trim(';');
                }
                if (yss.Count() > 3)
                {
                    wangMultiple.ys4_2 = yss[3].Trim(';');
                }
                /////////////////////////////////////////////////////////////////

                i++;
                if (i >= dt.Rows.Count)
                {
                    printList.Add(wangMultiple);
                    break;
                }
                jieyin = "";
                ys = "";
                dr = dt.Rows[i];
                wangMultiple.zihao_3 = dr["ZIHAO"].ToString();
                wangMultiple.zuoci_3 = dr["ZUOCI"].ToString();
                if (dr["JIEYIN1"].ToString() != "")
                    jieyin = dr["JIEYIN1"].ToString();
                if (dr["JIEYIN2"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN2"].ToString();
                if (dr["JIEYIN3"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN3"].ToString();
                if (dr["JIEYIN4"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN4"].ToString();
                if (dr["YANGSHANG1"].ToString() != "")
                    ys = dr["YANGSHANG1"].ToString();
                if (dr["YANGSHANG2"].ToString() != "")
                    ys += ";" + dr["YANGSHANG2"].ToString();
                if (dr["YANGSHANG3"].ToString() != "")
                    ys += ";" + dr["YANGSHANG3"].ToString();
                if (dr["YANGSHANG4"].ToString() != "")
                    ys += ";" + dr["YANGSHANG4"].ToString();
                jieyins = jieyin.Split(';');
                if (jieyins.Count() > 0)
                {
                    wangMultiple.jieyin3_3 = jieyins[0].Trim(';');
                }
                if (jieyins.Count() > 1)
                {
                    wangMultiple.jieyin2_3 = jieyins[1].Trim(';');
                }
                if (jieyins.Count() > 2)
                {
                    wangMultiple.jieyin4_3 = jieyins[2].Trim(';');
                }
                if (jieyins.Count() > 3)
                {
                    wangMultiple.jieyin1_3 = jieyins[3].Trim(';');
                }
                yss = ys.Split(';');
                if (yss.Count() > 0)
                {
                    wangMultiple.ys1_3 = yss[0].Trim(';');
                }
                if (yss.Count() > 1)
                {
                    wangMultiple.ys2_3 = yss[1].Trim(';');
                }
                if (yss.Count() > 2)
                {
                    wangMultiple.ys3_3 = yss[2].Trim(';');
                }
                if (yss.Count() > 3)
                {
                    wangMultiple.ys4_3 = yss[3].Trim(';');
                }

                /////////////////////////////////////////////////////////////////////////
                i++;
                if (i >= dt.Rows.Count)
                {
                    printList.Add(wangMultiple);
                    break;
                }
                jieyin = "";
                ys = "";
                dr = dt.Rows[i];
                wangMultiple.zihao_4 = dr["ZIHAO"].ToString();
                wangMultiple.zuoci_4 = dr["ZUOCI"].ToString();
                if (dr["JIEYIN1"].ToString() != "")
                    jieyin = dr["JIEYIN1"].ToString();
                if (dr["JIEYIN2"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN2"].ToString();
                if (dr["JIEYIN3"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN3"].ToString();
                if (dr["JIEYIN4"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN4"].ToString();
                if (dr["YANGSHANG1"].ToString() != "")
                    ys = dr["YANGSHANG1"].ToString();
                if (dr["YANGSHANG2"].ToString() != "")
                    ys += ";" + dr["YANGSHANG2"].ToString();
                if (dr["YANGSHANG3"].ToString() != "")
                    ys += ";" + dr["YANGSHANG3"].ToString();
                if (dr["YANGSHANG4"].ToString() != "")
                    ys += ";" + dr["YANGSHANG4"].ToString();
                jieyins = jieyin.Split(';');
                if (jieyins.Count() > 0)
                {
                    wangMultiple.jieyin3_4 = jieyins[0].Trim(';');
                }
                if (jieyins.Count() > 1)
                {
                    wangMultiple.jieyin2_4 = jieyins[1].Trim(';');
                }
                if (jieyins.Count() > 2)
                {
                    wangMultiple.jieyin4_4 = jieyins[2].Trim(';');
                }
                if (jieyins.Count() > 3)
                {
                    wangMultiple.jieyin1_4 = jieyins[3].Trim(';');
                }
                yss = ys.Split(';');
                if (yss.Count() > 0)
                {
                    wangMultiple.ys1_4 = yss[0].Trim(';');
                }
                if (yss.Count() > 1)
                {
                    wangMultiple.ys2_4 = yss[1].Trim(';');
                }
                if (yss.Count() > 2)
                {
                    wangMultiple.ys3_4 = yss[2].Trim(';');
                }
                if (yss.Count() > 3)
                {
                    wangMultiple.ys4_4 = yss[3].Trim(';');
                }
                printList.Add(wangMultiple);
            }
            reportWangMultiple.SetDataSource(printList);
            crystalReportViewer_wangmultiple.ReportSource = reportWangMultiple;
        }

    }
}
