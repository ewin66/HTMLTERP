using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using ZedGraph;
using Dundas.Charting.WinControl;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：产品管理
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmGBJCDtsRpt : frmAPBaseUIRpt
    {
        public frmGBJCDtsRpt()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]

        /// <summary>
        /// 查询条件
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (drpQVendorID.Text.Trim() != "")
            {
                tempStr += " AND VendorID LIKE " + SysString.ToDBString("%" + drpQVendorID.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue)!="")
            {
                tempStr += " AND SaleOPID =" + SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }
            if (txtQGBCode.Text.Trim() != "")
            {
                tempStr += " AND GBCode LIKE " + SysString.ToDBString("%" + txtQGBCode.Text.Trim() + "%");
            }
            if (drpQGBStatusID.Text.Trim() != "")
            {
                tempStr += " AND GBStatusID LIKE " + SysString.ToDBString("%" + drpQGBStatusID.Text.Trim() + "%");
            }
            if (this.checkEdit1.Checked)
            {
                tempStr += " AND JCTime BETWEEN " + SysString.ToDBString(txtQJCTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQJCTimeE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (this.chkIndate.Checked)
            {
                tempStr += " AND GHTime BETWEEN " + SysString.ToDBString(txtQGHTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQGHTimeE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if(txtItemCode.Text.Trim()!="")
            {
                tempStr+=" AND ItemCode LIKE"+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid1
        /// </summary>
        public void BindGrid1()
        {
            GBJCDtsRule rule = new GBJCDtsRule();
            DataTable dtt=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();

        }
        /// <summary>
        /// 绑定Grid3
        /// </summary>
        public void BindGrid3()
        {
            GBJCDtsRule rule = new GBJCDtsRule();
            string ConditionStr = HTDataConditionStr;
            ConditionStr += " AND GHTime IS NULL AND SubmitFlag=1";
            gridView3.GridControl.DataSource = rule.RShow(ConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView3.GridControl.Show();

        }
        /// <summary>
        /// 绑定Grid4
        /// </summary>
        public  void BindGrid4(DataTable dts)
        {   
                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn("SaleOPID", typeof(string)));
                dt.Columns.Add(new DataColumn("Sort", typeof(int)));
                DataColumn dc2 = new DataColumn("Amount", typeof(decimal));
                dt.Columns.Add(dc2);
                DataColumn dc3 = new DataColumn("Per", typeof(string));
                dt.Columns.Add(dc3);
                decimal totalqty = 0;
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    totalqty += SysConvert.ToDecimal(dts.Rows[i]["Amount"]);
                }

                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Sort"] = i + 1;
                    dr["Amount"] = SysConvert.ToDecimal(dts.Rows[i]["Amount"]);
                    dr["SaleOPID"] = dts.Rows[i]["SaleOPID"].ToString();
                    if (totalqty != 0)
                    {
                        dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dts.Rows[i]["Amount"]) * 100 / totalqty, 2).ToString() + "%";
                    }
                    dt.Rows.Add(dr);
                }
                gridView4.GridControl.DataSource = dt;
                gridView4.GridControl.Show();
        }
        /// <summary>
        /// 绑定Grid2
        /// </summary>
        public void BindGrid2(DataTable dts)
        {
            dts.Columns.Add(new DataColumn("Sort", typeof(int)));
            DataColumn dc3 = new DataColumn("Per", typeof(string));
            dts.Columns.Add(dc3);
            decimal totalqty = 0;
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                totalqty += SysConvert.ToDecimal(dts.Rows[i]["Amount"]);
            }

            for (int i = 0; i < dts.Rows.Count; i++)
            {
                dts.Rows[i]["Sort"] = i + 1;
                dts.Rows[i]["Amount"] = SysConvert.ToDecimal(dts.Rows[i]["Amount"]);
                dts.Rows[i]["VendorAttn"] = dts.Rows[i]["VendorAttn"].ToString();
                if (totalqty != 0)
                {
                    dts.Rows[i]["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dts.Rows[i]["Amount"]) * 100 / totalqty, 2).ToString() + "%";
                }
            }
            gridView2.GridControl.DataSource = dts;
            gridView2.GridControl.Show();

        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid5(DataTable dts)
        {
            DataTable dt = new DataTable();
            for (int i = 1; i <= 12; i++)
            {
                DataColumn dc = new DataColumn("Qty" + i, typeof(string));
                dt.Columns.Add(dc);
            }
            DataRow dr = dt.NewRow();
            for (int i = 1; i <= 12; i++)
            {
                dr["Qty" + i] = SysConvert.ToString(SysConvert.ToInt32(dts.Rows[i - 1]["Amount"].ToString())) + " 个";
            }
            dt.Rows.Add(dr);
            gridView5.GridControl.DataSource = dt;
            gridView5.GridControl.Show();
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid6()
        {
            string sql = "SELECT COUNT(ItemCode) Qty,ItemCode,GoodsCode,VendorID from UV2_Dev_GBJCDts where SubmitFlag=1 ";
            sql += " AND ItemCode<>'' ";
            sql += HTDataConditionStr;
            sql += "group by ItemCode,GoodsCode,VendorID order by Qty DESC";
            DataTable dt = SysUtils.Fill(sql);
            gridView6.GridControl.DataSource = dt;
            gridView6.GridControl.Show();
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            btnQuery_Click(null, null);
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI

            ProcessGrid.BindGridColumn(gridView2, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView2, FormListAID, FormListBID);//设置列UI

            ProcessGrid.BindGridColumn(gridView3, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView3, FormListAID, FormListBID);//设置列UI

            ProcessGrid.BindGridColumn(gridView4, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView4, FormListAID, FormListBID);//设置列UI

            ProcessGrid.BindGridColumn(gridView6, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView6, FormListAID, FormListBID);//设置列UI
            txtQJCTimeS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQJCTimeE.DateTime = DateTime.Now.Date;
            txtQGHTimeS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQGHTimeE.DateTime = DateTime.Now.Date;
            Common.BindYear(drpCheckYear, 3, 1, false);
            drpCheckYear.Text = DateTime.Now.Year.ToString();
            Common.BindOP(drpSaleOPID, true);
            this.HTDataTableName = "UV2_Dev_GBJCDts";
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);//客户
            new VendorProc(drpQVendorID);
            Common.BindGBStatus(drpQGBStatusID, true);
            btnQuery_Click(null, null);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Item EntityGet()
        {
            Item entity = new Item();
            entity.ID = HTDataID;
            return entity;
        }



        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #endregion

        #region 报表颜色处理类
        /// <summary>
        /// 订单颜色处理类
        /// </summary>
        public class SericsColorProc
        {
            private static bool m_ColorIniFlag = false;//颜色是否初始化标志
            public static bool ColorIniFlag
            {
                get
                {
                    if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
                    {
                        ColorIniProc();
                        m_ColorIniFlag = true;
                    }
                    return m_ColorIniFlag;
                }
            }

            private static int[] ColorStatusID;

            public static Color[] ColorStatusColor;
            /// <summary>
            /// 初始化颜色
            /// </summary>
            private static void ColorIniProc()
            {
                string sql = "SELECT ID,ColorStr FROM Enum_SeriesColor WHERE ID<>0 ORDER BY ID";
                DataTable dt = SysUtils.Fill(sql);
                ColorStatusID = new int[dt.Rows.Count];

                ColorStatusColor = new Color[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());

                    string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                    if (tempstr.Length == 3)//长度为3
                    {
                        ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                    }
                    else
                    {
                        ColorStatusColor[i] = Color.Black;
                    }

                }
            }

            /// <summary>
            /// 获得颜色
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static Color GetColor(int i)
            {
                string sql = "SELECT ID,ColorStr FROM Enum_SeriesColor WHERE 1=1  ";
                sql += " AND ID = " + SysString.ToDBString(i);
                sql += "ORDER BY ID";
                DataTable dt = SysUtils.Fill(sql);
                Color p_Color = Color.Black;
                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0]["ColorStr"].ToString() != "")
                    {
                        string[] tempstr = dt.Rows[0]["ColorStr"].ToString().Split(',');
                        if (tempstr.Length == 3)//长度为3
                        {
                            p_Color = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                        }
                    }
                }
                return p_Color;
            }
        }
        #endregion

        #region 重载方法
        /// <summary>
        /// 查询
        /// </summary>
        public override void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnQuery_Click(sender, e);
                DataTable dts5 = this.GetDataSource(SysConvert.ToInt32(drpCheckYear.Text.ToString()));
                BindGrid5(dts5);
                BindGrid1();
                BindGrid3();
                BindGrid6();
                CreateChart5();
                DataTable dts2 = GetDataSourceVendorSouce2();
                BindGrid2(dts2);
                DataTable dts4 = GetDataSourceVendorSouce4();
                BindGrid4(dts4);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        #endregion

        #region 图形报表
        /// <summary>
        /// 每月借出量分析
        /// </summary>
        private void CreateChart5()
        {
            try
            {
                string sql = "SELECT A.MonthInt, Amount FROM Rpt_Month A";
                sql += " LEFT OUTER JOIN ";
                sql += "(SELECT Count(*) Amount,Mon FROM ";
                sql += "(select ID ,DATEPART (M,JCTime ) Mon, JCTime from UV2_Dev_GBJCDts where 1=1";
                sql += " AND SubmitFlag=1 AND JCTime BETWEEN " + SysString.ToDBString(drpCheckYear.Text.ToString() + "-01-01") + " AND " + SysString.ToDBString(drpCheckYear.Text.ToString() + "-12-31 23:59:59");
                sql += ") AS A ";
                sql += "group by Mon) AS B";
                sql += " ON A.MonthInt=B.Mon ORDER BY A.MonthInt";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    Chart5.Titles["Title1"].Text = drpCheckYear.Text.Trim() + "每月借出量图形报表";
                    //设置X轴
                    Chart5.ChartAreas["Chart Area 1"].Area3DStyle.Enable3D = false;//2D效果
                    Chart5.ChartAreas["Chart Area 1"].AxisX.Title = "月份";
                    Chart5.ChartAreas["Chart Area 1"].AxisX.TitleAlignment = StringAlignment.Far;//设置X轴标题的名称所在位置位远
                    Chart5.ChartAreas["Chart Area 1"].AxisX.Interval = 0;//设置X轴显示间隔为2,对于X轴数据比较多的时候比较有用
                    Chart5.ChartAreas["Chart Area 1"].AxisX.View.Zoomable = true;
                    Chart5.ChartAreas["Chart Area 1"].AxisY.View.Zoomable = true;
                    Chart5.ChartAreas["Chart Area 1"].CursorX.AutoScroll = false;
                    Chart5.ChartAreas["Chart Area 1"].CursorY.AutoScroll = false;
                    Chart5.ChartAreas["Chart Area 1"].AxisX.LabelStyle.ShowEndLabels = true;//去掉X轴首尾标签
                    Chart5.ChartAreas["Chart Area 1"].AxisX.ScrollBar.PositionInside = true;
                    Chart5.ChartAreas["Chart Area 1"].AxisX.Margin = true;
                    //设置Y轴
                    Chart5.ChartAreas["Chart Area 1"].AxisY.Title = "借出量";
                    Chart5.ChartAreas["Chart Area 1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远

                    //清除原有Series
                    Chart5.Series.Clear();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        Series series = new Series();

                        series.Type = SeriesChartType.Column;
                        series.BorderStyle = ChartDashStyle.Solid;
                        series.BorderWidth = 1;
                        series.BorderColor = Color.FromArgb(180, 26, 59, 105);
                        series.BackGradientType = GradientType.None;
                        series.ShowLabelAsValue = true;
                        //series.Color = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
                        series.Color = SericsColorProc.GetColor(1);
                        series.CustomAttributes = "DrawingStyle=Cylinder";
                        Chart5.Series.Add(series);
                    }

                    double[][] Arrays1 = new double[dt.Rows.Count][];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Arrays1[i] = new double[1];
                        Arrays1[i][0] = SysConvert.ToDouble(dt.Rows[i]["Amount"]);

                        Series series = new Series();
                        series.ShowLabelAsValue = true;
                        Chart5.Series.Add(series);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Chart5.Series["Series2"].Points.Add(i + 1);
                        Chart5.Series["Series2"].Points[i].YValues = Arrays1[i];
                        Chart5.Series["Series2"].Points[i].AxisLabel = SysConvert.ToString(dt.Rows[i]["MonthInt"].ToString()) + "月";
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        #endregion

        #region 绑定排名
        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSource(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.MonthInt, Amount FROM Rpt_Month A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " LEFT OUTER JOIN ";
            sql += "(SELECT Count(ID) Amount,Mon FROM ";
            sql += "  (SELECT ID,DATEPART (M,JCTime ) Mon,JCTime ";
            sql += "   FROM UV2_Dev_GBJCDts WHERE  JCTime ";
            sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            sql += "AND SubmitFlag=1";
            sql += ") AS A ";
            sql += " GROUP BY Mon) AS B";
            sql += " ON A.MonthInt=B.Mon ORDER BY A.MonthInt";
            dt = SysUtils.Fill(sql);
            return dt;
        }
        /// <summary>
        /// 绑定数据源2
        /// </summary>
        private DataTable GetDataSourceVendorSouce2()
        {
                DataTable dt = new DataTable();
                string sql = "";
                sql = "SELECT * FROM ";
                sql+="( SELECT VendorID,VendorAttn,count(ID) as Amount from UV2_Dev_GBJCDts where 1=1 ";
                sql += HTDataConditionStr;
                sql += " AND SubmitFlag=1";
                sql += " GROUP BY VendorID,VendorAttn";
                sql += ") AS TA";
                sql += " ORDER BY Amount DESC ";
                dt = SysUtils.Fill(sql);
                return dt;
           
        }
        /// <summary>
        /// 绑定数据源4
        /// </summary>
        private DataTable GetDataSourceVendorSouce4()
        {     
                DataTable dt = new DataTable();
                string sql = " select SaleOPID,count(ID) as Amount from UV2_Dev_GBJCDts where 1=1 ";
                sql += HTDataConditionStr;
                sql += "AND SubmitFlag=1";
                sql += "group by SaleOPID";
                sql += " ORDER BY count(ID) DESC ";
                dt = SysUtils.Fill(sql);
                return dt;
           
        }
        #endregion

        #region 快速查询
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region 打印

        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }

            DataTable dt = (DataTable)gridView3.GridControl.DataSource;
            DataTable dtnew = dt.Clone();
            if (gridView1.RowFilter != string.Empty)
            {
                DataRow[] rows = dt.Select(gridView3.RowFilter);

                foreach (DataRow row in rows)
                {
                    dtnew.ImportRow(row);
                }

            }
            else
            {
                dtnew = dt;
            }

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtnew);

            return true;
        }

        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                // base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.预览);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                //base.btnPrint_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.打印);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.设计);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        //public override void btnToExcel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ToExcel(gridView1);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ToExcelSelectColumn(gridView1);
                FCommon.AddDBLog(this.Text, "导出列表", "", "");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



    }
}