using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Data;
using HttSoft.Framework;
using HttSoft.FrameFunc;

namespace MLTERP
{
    /// <summary>
    ///生成Calendar
    /// 潘杰俊
    /// 2009-08-01
    /// </summary>
    public class CreateCalendar
    {
        #region Grid日历控件处理
        /// <summary>
        /// 星期枚举
        /// </summary>
        public enum EnumWeek
        {
            日 = 0,
            一 = 1,
            二 = 2,
            三 = 3,
            四 = 4,
            五 = 5,
            六 = 6
        }

        /// <summary>
        /// 根据日期得到是星期几
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public int GetWeekOfDay(DateTime datetime)
        {
            int firstday = 0;
            switch (datetime.DayOfWeek.ToString())
            {
                case "Sunday":
                    {
                        firstday = 0;
                        break;
                    }
                case "Monday":
                    {
                        firstday = 1;
                        break;
                    }
                case "Tuesday":
                    {
                        firstday = 2;
                        break;
                    }
                case "Wednesday":
                    {
                        firstday = 3;
                        break;
                    }
                case "Thursday":
                    {
                        firstday = 4;
                        break;
                    }
                case "Friday":
                    {
                        firstday = 5;
                        break;
                    }
                case "Saturday":
                    {
                        firstday = 6;
                        break;
                    }

            }
            return firstday;
        }

        /// <summary>
        /// 获得月份最后一天的日期
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public  int GetLastDay(DateTime datetime)
        {
            int nYear = datetime.Year;
            int nMonth = datetime.Month;
            int lastday = 0;

            if (nMonth == 2)
            {
                if (nYear % 400 == 0)
                    lastday = 29;
                else if (nYear % 100 == 0)
                    lastday = 28;
                else if (nYear % 4 == 0)
                    lastday = 29;
                else
                    lastday = 28;
            }
            else
            {
                switch (nMonth)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: lastday = 31; break;
                    case 4:
                    case 6:
                    case 9:
                    case 11: lastday = 30; break;
                    default:
                        break;
                }
            }
            return lastday;
        }


        /// <summary>
        /// 获得月份最后一天的日期
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static int GetLastDay(int nYear, int nMonth)
        {
            int lastday = 0;

            if (nMonth == 2)
            {
                if (nYear % 400 == 0)
                    lastday = 29;
                else if (nYear % 100 == 0)
                    lastday = 28;
                else if (nYear % 4 == 0)
                    lastday = 29;
                else
                    lastday = 28;
            }
            else
            {
                switch (nMonth)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: lastday = 31; break;
                    case 4:
                    case 6:
                    case 9:
                    case 11: lastday = 30; break;
                    default:
                        break;
                }
            }
            return lastday;
        }

        /// <summary>
        /// 把某月的天数以7列的方式排列出来，形成一个datatable
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public DataTable DateArrange(DateTime datetime, DateTime[] dDateTime)
        {

            DataTable dt = new DataTable();
            for (int i = 0; i < 7; i++)
            {
                dt.Columns.Add("A" + i.ToString(), typeof(string));
            }

            int beginday = GetWeekOfDay(SysConvert.ToDateTime(datetime.ToString("yyyy-MM-01")));
            int endday = GetLastDay(datetime);
            DataRow row = null;

            for (int i = 1; i <= endday; i++)
            {
                if (beginday % 7 == 0 || i == 1)
                {
                    if (i != 1)
                    {
                        dt.Rows.Add(row);
                        beginday = 0;
                    }

                    row = dt.NewRow();
                    string str = GetEventTitleOfDate(dDateTime, SysConvert.ToDateTime(datetime.Year.ToString() + "-" + datetime.Month.ToString() + "-" + i.ToString()));
                    row[beginday] = i.ToString() + str;
                    beginday++;
                }
                else
                {
                    string str = GetEventTitleOfDate(dDateTime, SysConvert.ToDateTime(datetime.Year.ToString() + "-" + datetime.Month.ToString() + "-" + i.ToString()));
                    row[beginday] = i.ToString() + str;
                    beginday++;
                }

                if (i == endday)
                {
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        /// <summary>
        /// 循环DateTable，获取当前日期的事件标题，形成字符串，
        /// 不一天一天的查询数据库，是考虑到频繁访问数据库的效率。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetEventTitleOfDate(DateTime[] DateTime, DateTime datetime)
        {
            string str = "";
            for (int i = 0; i < DateTime.Length; i++)
            {
                if (DateTime[i].ToString("yyyy-MM-dd") == datetime.ToString("yyyy-MM-dd"))
                {
                    str = "☆";
                }
            }

            return str;
        }

       /// <summary>
        /// 初始化一个月的日历格式
       /// </summary>
        /// <param name="CalendarGrid">装载的BandedGridView控件</param>
       /// <param name="datetime">月日期</param>
       /// <param name="dDateTime">特殊显示日期数组</param>
       /// <param name="sTitle">标题</param>
       /// <param name="sName"></param>
        public void InitMonthTitle(BandedGridView CalendarGrid, DateTime datetime, DateTime[] dDateTime, string sTitle, string sName)
        {
            CalendarGrid.Columns.Clear();
            CalendarGrid.Bands.Clear();

            BandedGridColumn gc = new BandedGridColumn();
            gc.FieldName = "A" + 0.ToString();
            gc.OptionsColumn.ReadOnly = true;
            gc.OptionsColumn.AllowEdit = true;
            gc.Caption = Enum.GetNames(typeof(EnumWeek))[0];
            gc.VisibleIndex = 0;
            gc.Width = 32;
            CalendarGrid.Columns.Add(gc);

            BandedGridColumn gc1 = new BandedGridColumn();
            gc1.FieldName = "A" + 1.ToString();
            gc1.OptionsColumn.ReadOnly = true;
            gc1.OptionsColumn.AllowEdit = true;
            gc1.Caption = Enum.GetNames(typeof(EnumWeek))[1];
            gc1.VisibleIndex = 1;
            gc1.Width = 32;
            CalendarGrid.Columns.Add(gc1);

            BandedGridColumn gc2 = new BandedGridColumn();
            gc2.FieldName = "A" + 2.ToString();
            gc2.OptionsColumn.ReadOnly = true;
            gc2.OptionsColumn.AllowEdit = true;
            gc2.Caption = Enum.GetNames(typeof(EnumWeek))[2];
            gc2.VisibleIndex = 2;
            gc2.Width = 32;
            CalendarGrid.Columns.Add(gc2);

            BandedGridColumn gc3 = new BandedGridColumn();
            gc3.FieldName = "A" + 3.ToString();
            gc3.OptionsColumn.ReadOnly = true;
            gc3.OptionsColumn.AllowEdit = true;
            gc3.Caption = Enum.GetNames(typeof(EnumWeek))[3];
            gc3.VisibleIndex = 3;
            gc3.Width = 32;
            CalendarGrid.Columns.Add(gc3);

            BandedGridColumn gc4 = new BandedGridColumn();
            gc4.FieldName = "A" + 4.ToString();
            gc4.OptionsColumn.ReadOnly = true;
            gc4.OptionsColumn.AllowEdit = true;
            gc4.Caption = Enum.GetNames(typeof(EnumWeek))[4];
            gc4.VisibleIndex = 4;
            gc4.Width = 32;
            CalendarGrid.Columns.Add(gc4);

            BandedGridColumn gc5 = new BandedGridColumn();
            gc5.FieldName = "A" + 5.ToString();
            gc5.OptionsColumn.ReadOnly = true;
            gc5.OptionsColumn.AllowEdit = true;
            gc5.Caption = Enum.GetNames(typeof(EnumWeek))[5];
            gc5.VisibleIndex = 5;
            gc5.Width = 32;
            CalendarGrid.Columns.Add(gc5);

            BandedGridColumn gc6 = new BandedGridColumn();
            gc6.FieldName = "A" + 6.ToString();
            gc6.OptionsColumn.ReadOnly = true;
            gc6.OptionsColumn.AllowEdit = true;
            gc6.Caption = Enum.GetNames(typeof(EnumWeek))[6];
            gc6.VisibleIndex = 5;
            gc6.Width = 32;
            CalendarGrid.Columns.Add(gc6);

            GridBand gridBand = new GridBand();
            string CaptionBand = sTitle;
            string NameBand = "gridBand1";
            gridBand.Caption = CaptionBand;
            gridBand.Columns.Add(gc);
            gridBand.Columns.Add(gc1);
            gridBand.Columns.Add(gc2);
            gridBand.Columns.Add(gc3);
            gridBand.Columns.Add(gc4);
            gridBand.Columns.Add(gc5);
            gridBand.Columns.Add(gc6);
            gridBand.Name = NameBand;
            CalendarGrid.Bands.Add(gridBand);

            CalendarGrid.OptionsCustomization.AllowFilter = false;
            CalendarGrid.OptionsCustomization.AllowSort = false;
            CalendarGrid.OptionsCustomization.AllowGroup = false;

            DataTable dt = DateArrange(datetime,dDateTime);
            CalendarGrid.GridControl.DataSource = dt;
        }

        public CreateCalendar(BandedGridView CalendarGrid, DateTime datetime, DateTime[] dDateTime, string sTitle, string sName)
        {
            InitMonthTitle(CalendarGrid, datetime, dDateTime, sTitle, sName);
        }

        public CreateCalendar()
        {
           
        }

        public void InitMonthTitle(BandedGridView CalendarGrid, DateTime datetime, DateTime[] dDateTime, string sTitle)
        {
            CalendarGrid.Columns.Clear();
            CalendarGrid.Bands.Clear();

            BandedGridColumn gc = new BandedGridColumn();
            gc.FieldName = "A" + 0.ToString();
            gc.OptionsColumn.ReadOnly = true;
            gc.OptionsColumn.AllowEdit = true;
            gc.Caption = Enum.GetNames(typeof(EnumWeek))[0];
            gc.VisibleIndex = 0;
            gc.Width = 32;
            CalendarGrid.Columns.Add(gc);

            BandedGridColumn gc1 = new BandedGridColumn();
            gc1.FieldName = "A" + 1.ToString();
            gc1.OptionsColumn.ReadOnly = true;
            gc1.OptionsColumn.AllowEdit = true;
            gc1.Caption = Enum.GetNames(typeof(EnumWeek))[1];
            gc1.VisibleIndex = 1;
            gc1.Width = 32;
            CalendarGrid.Columns.Add(gc1);

            BandedGridColumn gc2 = new BandedGridColumn();
            gc2.FieldName = "A" + 2.ToString();
            gc2.OptionsColumn.ReadOnly = true;
            gc2.OptionsColumn.AllowEdit = true;
            gc2.Caption = Enum.GetNames(typeof(EnumWeek))[2];
            gc2.VisibleIndex = 2;
            gc2.Width = 32;
            CalendarGrid.Columns.Add(gc2);

            BandedGridColumn gc3 = new BandedGridColumn();
            gc3.FieldName = "A" + 3.ToString();
            gc3.OptionsColumn.ReadOnly = true;
            gc3.OptionsColumn.AllowEdit = true;
            gc3.Caption = Enum.GetNames(typeof(EnumWeek))[3];
            gc3.VisibleIndex = 3;
            gc3.Width = 32;
            CalendarGrid.Columns.Add(gc3);

            BandedGridColumn gc4 = new BandedGridColumn();
            gc4.FieldName = "A" + 4.ToString();
            gc4.OptionsColumn.ReadOnly = true;
            gc4.OptionsColumn.AllowEdit = true;
            gc4.Caption = Enum.GetNames(typeof(EnumWeek))[4];
            gc4.VisibleIndex = 4;
            gc4.Width = 32;
            CalendarGrid.Columns.Add(gc4);

            BandedGridColumn gc5 = new BandedGridColumn();
            gc5.FieldName = "A" + 5.ToString();
            gc5.OptionsColumn.ReadOnly = true;
            gc5.OptionsColumn.AllowEdit = true;
            gc5.Caption = Enum.GetNames(typeof(EnumWeek))[5];
            gc5.VisibleIndex = 5;
            gc5.Width = 32;
            CalendarGrid.Columns.Add(gc5);

            BandedGridColumn gc6 = new BandedGridColumn();
            gc6.FieldName = "A" + 6.ToString();
            gc6.OptionsColumn.ReadOnly = true;
            gc6.OptionsColumn.AllowEdit = true;
            gc6.Caption = Enum.GetNames(typeof(EnumWeek))[6];
            gc6.VisibleIndex = 5;
            gc6.Width = 32;
            CalendarGrid.Columns.Add(gc6);

            GridBand gridBand = new GridBand();
            string CaptionBand = sTitle;
            string NameBand = "gridBand1";
            gridBand.Caption = CaptionBand;
            gridBand.Columns.Add(gc);
            gridBand.Columns.Add(gc1);
            gridBand.Columns.Add(gc2);
            gridBand.Columns.Add(gc3);
            gridBand.Columns.Add(gc4);
            gridBand.Columns.Add(gc5);
            gridBand.Columns.Add(gc6);
            gridBand.Name = NameBand;
            CalendarGrid.Bands.Add(gridBand);

            CalendarGrid.OptionsCustomization.AllowRowSizing = false;

            CalendarGrid.OptionsCustomization.AllowColumnMoving = false;
            CalendarGrid.OptionsCustomization.AllowFilter = false;
            CalendarGrid.OptionsCustomization.AllowGroup = false;
            CalendarGrid.OptionsCustomization.AllowSort = false;
            CalendarGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            CalendarGrid.OptionsSelection.EnableAppearanceFocusedRow = false;
            CalendarGrid.OptionsView.ShowGroupPanel = false;
            CalendarGrid.OptionsView.ShowIndicator = false;

            DataTable dt = DateArrange(datetime, dDateTime);
            CalendarGrid.GridControl.DataSource = dt;

            //FCommon.SetGridColumnStatus(CalendarGrid, false);

        }

        public void InitMonthTitle(BandedGridView CalendarGrid, DateTime datetime, DateTime[] dDateTime)
        {
            InitMonthTitle(CalendarGrid, datetime, dDateTime, datetime.ToString("yyyy年MM月"));
        }


        #endregion
    }
}
