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
    public partial class FormPrintYanMultiple : Form
    {
        private String sql = "";
        private DataTable PrintDt = new DataTable();
        public FormPrintYanMultiple(String _fahuiid) : this(_fahuiid, true) { }
        public FormPrintYanMultiple(String _fahuiid,Boolean _printall)
        {
            InitializeComponent();
            sql = "SELECT [ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO] FROM [FAHUI_YAN] WHERE FAHUI_ID="+_fahuiid;
            if (!_printall)
                sql += " AND HAS_PRINT<>1";
            using (pub.DataBase db = new pub.DataBase())
            {
                PrintDt = db.ExecuteDataTable(sql);
            }
        }
        public FormPrintYanMultiple(DataTable _PrintDt)
        {
            InitializeComponent();
            PrintDt = _PrintDt;
        }
        private void FormPrintYanMultiple_Load(object sender, EventArgs e)
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
            CrystalReport_yanprintmultiple reportYanMultiple = new CrystalReport_yanprintmultiple();
            List<ClassYanMultiple> printList = new List<ClassYanMultiple>();
            for (i = 0; i < dt.Rows.Count; i++)
            {
                ClassYanMultiple yanMultiple = new ClassYanMultiple();
                String zhuzhao = "";
                DataRow dr = dt.Rows[i];
                yanMultiple.zihao_1 = dr["ZIHAO"].ToString();
                yanMultiple.zuoci_1 = dr["ZUOCI"].ToString();
                if (dr["ZHUZHAO1"].ToString() != "")
                    zhuzhao = dr["ZHUZHAO1"].ToString();
                if (dr["ZHUZHAO2"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO2"].ToString();
                if (dr["ZHUZHAO3"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO3"].ToString();
                if (dr["ZHUZHAO4"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO4"].ToString();
                String[] zhuzhaos = zhuzhao.Split(';');
                if (zhuzhaos.Count() > 0)
                    yanMultiple.zhuzhao3_1 = zhuzhaos[0].Trim(';');
                if (zhuzhaos.Count() > 1)
                    yanMultiple.zhuzhao2_1 = zhuzhaos[1].Trim(';');
                if (zhuzhaos.Count() > 2)
                    yanMultiple.zhuzhao4_1 = zhuzhaos[2].Trim(';');
                if (zhuzhaos.Count() > 3)
                    yanMultiple.zhuzhao1_1 = zhuzhaos[3].Trim(';');
                ////////////////////////////////////////////////////
                i++;
                if (i >= dt.Rows.Count)
                {
                    printList.Add(yanMultiple);
                    break;
                }
                zhuzhao = "";
                dr = dt.Rows[i];
                yanMultiple.zihao_2 = dr["ZIHAO"].ToString();
                yanMultiple.zuoci_2 = dr["ZUOCI"].ToString();
                if (dr["ZHUZHAO1"].ToString() != "")
                    zhuzhao = dr["ZHUZHAO1"].ToString();
                if (dr["ZHUZHAO2"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO2"].ToString();
                if (dr["ZHUZHAO3"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO3"].ToString();
                if (dr["ZHUZHAO4"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO4"].ToString();
                zhuzhaos = zhuzhao.Split(';');
                if (zhuzhaos.Count() > 0)
                    yanMultiple.zhuzhao3_2 = zhuzhaos[0].Trim(';');
                if (zhuzhaos.Count() > 1)
                    yanMultiple.zhuzhao2_2 = zhuzhaos[1].Trim(';');
                if (zhuzhaos.Count() > 2)
                    yanMultiple.zhuzhao4_2 = zhuzhaos[2].Trim(';');
                if (zhuzhaos.Count() > 3)
                    yanMultiple.zhuzhao1_2 = zhuzhaos[3].Trim(';');
                ////////////////////////////////////////////////////
                i++;
                if (i >= dt.Rows.Count)
                {
                    printList.Add(yanMultiple);
                    break;
                }
                zhuzhao = "";
                dr = dt.Rows[i];
                yanMultiple.zihao_3 = dr["ZIHAO"].ToString();
                yanMultiple.zuoci_3 = dr["ZUOCI"].ToString();
                if (dr["ZHUZHAO1"].ToString() != "")
                    zhuzhao = dr["ZHUZHAO1"].ToString();
                if (dr["ZHUZHAO2"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO2"].ToString();
                if (dr["ZHUZHAO3"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO3"].ToString();
                if (dr["ZHUZHAO4"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO4"].ToString();
                zhuzhaos = zhuzhao.Split(';');
                if (zhuzhaos.Count() > 0)
                    yanMultiple.zhuzhao3_3 = zhuzhaos[0].Trim(';');
                if (zhuzhaos.Count() > 1)
                    yanMultiple.zhuzhao2_3 = zhuzhaos[1].Trim(';');
                if (zhuzhaos.Count() > 2)
                    yanMultiple.zhuzhao4_3 = zhuzhaos[2].Trim(';');
                if (zhuzhaos.Count() > 3)
                    yanMultiple.zhuzhao1_3 = zhuzhaos[3].Trim(';');
                ////////////////////////////////////////////////////
                i++;
                if (i >= dt.Rows.Count)
                {
                    printList.Add(yanMultiple);
                    break;
                }
                zhuzhao = "";
                dr = dt.Rows[i];
                yanMultiple.zihao_4 = dr["ZIHAO"].ToString();
                yanMultiple.zuoci_4 = dr["ZUOCI"].ToString();
                if (dr["ZHUZHAO1"].ToString() != "")
                    zhuzhao = dr["ZHUZHAO1"].ToString();
                if (dr["ZHUZHAO2"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO2"].ToString();
                if (dr["ZHUZHAO3"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO3"].ToString();
                if (dr["ZHUZHAO4"].ToString() != "")
                    zhuzhao = ";" + dr["ZHUZHAO4"].ToString();
                zhuzhaos = zhuzhao.Split(';');
                if (zhuzhaos.Count() > 0)
                    yanMultiple.zhuzhao3_4 = zhuzhaos[0].Trim(';');
                if (zhuzhaos.Count() > 1)
                    yanMultiple.zhuzhao2_4 = zhuzhaos[1].Trim(';');
                if (zhuzhaos.Count() > 2)
                    yanMultiple.zhuzhao4_4 = zhuzhaos[2].Trim(';');
                if (zhuzhaos.Count() > 3)
                    yanMultiple.zhuzhao1_4 = zhuzhaos[3].Trim(';');
                printList.Add(yanMultiple);
            }
            reportYanMultiple.SetDataSource(printList);
            crystalReportViewer_printyanmultiple.ReportSource = reportYanMultiple;
        }
    }
}
