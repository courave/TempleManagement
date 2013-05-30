using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

public partial class FrmCalendar :Form
{
    public FrmCalendar()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 边框颜色
    /// </summary>
    public Color BorderColor { get; set; }

    /// <summary>
    /// 日期值
    /// </summary>
    public DateFormat DateValue { get; set; }

    public event Action<DateFormat,string> MyEvent;

    private bool IsShow = false;

    private void FrmCalendar_Load(object sender, EventArgs e)
    {
        rbtnNl.Checked = DateValue.IsLunar;
        if (rbtnGl.Checked)
        {
            AddCalendar();
            cbYear.SelectedValue = DateValue.year;
            cbMonth.SelectedValue = DateValue.month;
            cbDay.SelectedValue = DateValue.day;
        }
    }

    private void AddCalendar()
    {
        DateTime dtyear = new DateTime(DateTime.Now.Year, 12, 1);
        DateTime dtTemp = new DateTime();
        List<DateModel> dmList = new List<DateModel>();
        for (int i = 0; i < 100; i++)
        {
            dtTemp = dtyear.AddYears(-i);
            if (rbtnNl.Checked)
            {
                dmList.Add(new DateModel { DText = ChinaDate.GetYear(dtTemp), DValue = ChinaDate.GetYearNum(dtTemp) });
            }
            else
            {
                dmList.Add(new DateModel { DText = string.Format("{0}年", dtTemp.Year), DValue = dtTemp.Year });
            }
        }
        cbYear.DisplayMember = "DText";
        cbYear.ValueMember = "DValue";
        cbYear.DataSource = dmList;
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg==0006)
        {
            if (IsShow)
            {
                this.Close();
            }
            else
            {
                IsShow = true;
            }
        }
        base.WndProc(ref m);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (Graphics g = e.Graphics)
        {
            Rectangle r = new Rectangle();
            r.Width = this.Width - 1;
            r.Height = this.Height - 1;
            using (Pen pen = new Pen(this.BorderColor))
            {
                g.DrawRectangle(pen, r);
            }
        }
    }

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        string datestr = string.Format("{0}{1}{2}", cbYear.Text, cbMonth.Text, cbDay.Text);
        DateFormat du = new DateFormat();
        du.day = (int)cbDay.SelectedValue;
        du.month=(int)cbMonth.SelectedValue;
        du.year=(int)cbYear.SelectedValue;
        du.IsLunar = rbtnNl.Checked;
        if (cbMonth.Text.Contains("闰"))
            du.isLeap = true;
        MyEvent(du, datestr);
        base.OnClosing(e);
    }

    private void rbtnNl_CheckedChanged(object sender, EventArgs e)
    {
        if (cbYear.SelectedValue != null)
        {
            DateValue.day = (int)cbDay.SelectedValue;
            DateValue.month = (int)cbMonth.SelectedValue;
            DateValue.year = (int)cbYear.SelectedValue;
            DateValue.IsLunar = rbtnNl.Checked ? false : true;
        }
        AddCalendar();
        if (rbtnNl.Checked)
        {
            if (DateValue.IsLunar)
            {
                cbYear.SelectedValue = DateValue.year;
                cbMonth.SelectedValue = DateValue.month;
                cbDay.SelectedValue = DateValue.day;
            }
            else
            {
                DateTime dtTemp = new DateTime(DateValue.year, DateValue.month, DateValue.day);
                cbYear.SelectedValue = ChinaDate.GetYearNum(dtTemp);
                if (cbYear.SelectedValue == null)//超出索引范围时
                    cbYear.SelectedIndex = 0;
                cbMonth.SelectedValue = ChinaDate.GetMonthNum(dtTemp);
                if (cbMonth.SelectedValue == null)
                    cbMonth.SelectedIndex = 0;
                cbDay.SelectedValue = ChinaDate.GetDayNum(dtTemp);
                if (cbDay.SelectedValue == null)
                    cbDay.SelectedIndex = 0;
            }
        }
        else
        {
            if (DateValue.IsLunar)
            {
                DateTime dtTemp = ChinaDate.ToDateTime(DateValue.year, DateValue.month, DateValue.day);
                cbYear.SelectedValue = dtTemp.Year;
                if (cbYear.SelectedValue == null)//超出索引范围时
                    cbYear.SelectedIndex = 0;
                cbMonth.SelectedValue = dtTemp.Month;
                if (cbMonth.SelectedValue == null)
                    cbMonth.SelectedIndex = 0;
                cbDay.SelectedValue = dtTemp.Day;
                if (cbDay.SelectedValue == null)
                    cbDay.SelectedIndex = 0;
            }
            else
            {
                cbYear.SelectedValue = DateValue.year;
                cbMonth.SelectedValue = DateValue.month;
                cbDay.SelectedValue = DateValue.day;
            }
        }
    }

    private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbYear.SelectedValue != null)
        {
            int year = (int)cbYear.SelectedValue;
            DateTime dtMonth = new DateTime();
            List<DateModel> dmList = new List<DateModel>();
            if (rbtnNl.Checked)
            {
                int maxMonth = ChinaDate.GetMaxMonth(new DateTime(year, 12, 1));
                DateTime dtFirst = ChinaDate.GetFirstMonth(year);
                for (int i = 0; i < maxMonth; i++)
                {
                    dtMonth = ChinaDate.AddDateMonth(dtFirst, i);
                    dmList.Add(new DateModel { DText = ChinaDate.GetMonth(dtMonth), DValue = ChinaDate.GetMonthNum(dtMonth) });
                }
            }
            else
            {
                for (int i = 1; i < 13; i++)
                {
                    dmList.Add(new DateModel { DText = string.Format("{0}月", i), DValue = i });
                }
            }
            cbMonth.DisplayMember = "DText";
            cbMonth.ValueMember = "DValue";
            cbMonth.DataSource = dmList;
        }
    }

    private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbMonth.SelectedValue != null && cbYear.SelectedValue != null)
        {
            int year = (int)cbYear.SelectedValue;
            int month = (int)cbMonth.SelectedValue;
            int maxDay;
            List<DateModel> dmList = new List<DateModel>();
            if (rbtnNl.Checked)
            {
                maxDay = ChinaDate.GetMaxDay(year, month);
                DateTime dtFirst = ChinaDate.GetFirstMonth(year, month);
                DateTime dtDay = new DateTime();
                for (int i = 0; i < maxDay; i++)
                {
                    dtDay = ChinaDate.AddDateDay(dtFirst, i);
                    dmList.Add(new DateModel { DText = ChinaDate.GetDay(dtDay), DValue = ChinaDate.GetDayNum(dtDay) });
                }
            }
            else
            {
                maxDay = DateTime.DaysInMonth(year, month);
                for (int i = 1; i < maxDay + 1; i++)
                {
                    dmList.Add(new DateModel { DText = string.Format("{0}日", i), DValue = i });
                }
            }
            cbDay.DisplayMember = "DText";
            cbDay.ValueMember = "DValue";
            cbDay.DataSource = dmList;
        }
    }
        
    private class DateModel 
    {
        public int DValue { get; set; }
        public string DText { get; set; }
    }
}

