using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

/// <summary>
/// 日历选择控件,支持公历和农历选择
/// </summary>
[ToolboxBitmap(typeof(TextBox))]
public partial class CalendarView :TextBox
{
    /// <summary>
    /// 构造函数.设置控件样式
    /// </summary>
    public CalendarView()
    {
        this.Cursor = Cursors.Arrow;
        this.ReadOnly = true;
        this.BackColor = System.Drawing.Color.White;
    }

    private Color panelBGColor = Color.FromArgb(249, 251, 249);
    /// <summary>
    /// 日历选择面板背景颜色
    /// </summary>
    [DefaultValue(typeof(Color), "249, 251, 249"), Category("自定义属性"), Description("日历选择面板背景颜色")]
    public Color PanelBGColor
    {
        get { return panelBGColor; }
        set { panelBGColor = value; }
    }

    private Color panelBorderColor = Color.FromArgb(127, 157, 185);
    /// <summary>
    /// 日历选择面板边框颜色
    /// </summary>
    [DefaultValue(typeof(Color), "127, 157, 185"), Category("自定义属性"), Description("日历选择面板边框颜色")]
    public Color PanelBorderColor
    {
        get { return panelBorderColor; }
        set { panelBorderColor = value; }
    }

    private DateFormat dateValue = new DateFormat { year = DateTime.Now.Year, month = DateTime.Now.Month, day = DateTime.Now.Day };
    /// <summary>
    /// 日期值
    /// </summary>
    [Browsable(false)]
    public DateFormat DateValue
    {
        get { return dateValue; }
        set
        {

            if (value != null && value.IsLunar)
            {
                DateTime dtTemp = ChinaDate.ToDateTime(value.year, value.month, value.day);
                Text = ChinaDate.GetChinaDate(dtTemp);
            }
            else if (value != null)
            {
                Text = string.Format("{0}年{1}月{2}日", value.year, value.month, value.day);
            }
            else
            {
                Text = "";
            }
            dateValue = value;
        }
    }

    private Point FrmPos = new Point();
    private bool IsShow = false;

    /// <summary>
    /// 重写控件单击事件
    /// </summary>
    /// <param name="e"></param>
    protected override void OnClick(EventArgs e)
    {
        User32.RECT winRect = new User32.RECT();
        User32.GetWindowRect(this.Handle, ref winRect);
        FrmPos = new Point(winRect.left, winRect.top);
        FrmPos.Offset(0, Height);
        FrmCalendar SFrm = (FrmCalendar)Application.OpenForms["FrmCalendar"];
        if (SFrm == null)
        {
            if (!IsShow)
            {
                SFrm = new FrmCalendar();
                SFrm.Location = FrmPos;
                SFrm.BorderColor = PanelBorderColor;
                SFrm.BackColor = PanelBGColor;
                SFrm.DateValue = DateValue ?? new DateFormat { year = DateTime.Now.Year, month = DateTime.Now.Month, day = DateTime.Now.Day };
                SFrm.MyEvent += new Action<DateFormat,string>(SFrm_MyEvent);
                SFrm.Show();
                IsShow = true;
            }
            else
            {
                IsShow = false;
            }
        }
        base.OnClick(e);
    }

    private void SFrm_MyEvent(DateFormat du, string dateStr)
    {
        DateValue = du;
        this.Text = dateStr;
    }
}

/// <summary>
/// 日期格式化类
/// </summary>
public class DateFormat 
{
    /// <summary>
    /// 年
    /// </summary>
    public int year { get; set; }
    /// <summary>
    /// 月
    /// </summary>
    public int month { get; set; }
    /// <summary>
    /// 日
    /// </summary>
    public int day { get; set; }

    /// <summary>
    /// 是否为闰月,true为是
    /// </summary>
    public bool isLeap { get; set; }

    /// <summary>
    /// 是否是农历
    /// </summary>
    public bool IsLunar { get; set; }
}

/// <summary>   
/// 辅助类 定义User32 API函数   
/// </summary>   
public class User32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ileft">左上X</param>
        /// <param name="itop">左上Y</param>
        /// <param name="iright">右下X</param>
        /// <param name="ibottom">右下Y</param>
        public RECT(int ileft, int itop, int iright, int ibottom)
        {
            left = ileft;
            top = itop;
            right = iright;
            bottom = ibottom;
        }
        /// <summary>
        /// 左上X
        /// </summary>
        public int left;
        /// <summary>
        /// 左上Y
        /// </summary>
        public int top;
        /// <summary>
        /// 右下X
        /// </summary>
        public int right;
        /// <summary>
        /// 右下Y
        /// </summary>
        public int bottom;
    }
    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowRect(IntPtr hWnd, ref User32.RECT rect);
}

