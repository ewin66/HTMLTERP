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
    public partial class frmSaleOrderRpt : frmAPBaseUIRpt
    {
        public frmSaleOrderRpt()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtMakeOPName.Text.Trim() != "")//查询d
            {
                tempStr = " AND MakeOPName LIKE " + SysString.ToDBString("%" + txtMakeOPName.Text.Trim() + "%");
            }
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
         
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleOrderRule rule = new SaleOrderRule();
            //gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            //gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);

            ProcessGrid.BindGridColumn(gridView2, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView2, this.FormListAID, this.FormListBID);

            ProcessGrid.BindGridColumn(gridView3, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView3, this.FormListAID, this.FormListBID);

            ProcessGrid.BindGridColumn(gridView4, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView4, this.FormListAID, this.FormListBID);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpQVendorID);
            drpCheckYear.Text = DateTime.Now.Year.ToString();

            txtQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQMakeDateE.DateTime = DateTime.Now;

            this.HTQryContainer = groupControlQuery;

            this.HTDataTableName = "Sale_SaleOrder";
            btnQuery_Click(null, null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrder EntityGet()
        {
            SaleOrder entity = new SaleOrder();
            entity.ID = HTDataID;      
            return entity;
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid2(DataTable[] dtS, int[] p_Year)
        {
            DataTable dt = new DataTable();

            DataColumn dcname = new DataColumn("Name", typeof(string));
            dt.Columns.Add(dcname);
            for (int i = 1; i <= 12; i++)
            {
                DataColumn dc = new DataColumn("Qty" + i, typeof(string));
                dt.Columns.Add(dc);
            }
            for (int m = 0; m < dtS.Length; m++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = p_Year[m].ToString();
                for (int i = 1; i <= 12; i++)
                {
                    dr["Qty" + i] = SysConvert.ToString(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS[m].Rows[i - 1]["SQty"].ToString())));
                }
                dt.Rows.Add(dr);
            }
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }
        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid1(DataTable dtS)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("VendorID", typeof(string)));
            dt.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
            dt.Columns.Add(new DataColumn("Sort", typeof(int)));

            DataColumn dc2 = new DataColumn("Qty", typeof(decimal));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("Per", typeof(string));
            dt.Columns.Add(dc3);

            decimal totalqty = 0;
            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                totalqty += SysConvert.ToDecimal(dtS.Rows[i]["SQty"]);
            }

            for (int i = 0; i < dtS.Rows.Count; i++)
            {

                DataRow dr = dt.NewRow();
                dr["Sort"] = i + 1;
                dr["Qty"] = SysConvert.ToDecimal(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"].ToString()), 3));
                dr["VendorID"] = dtS.Rows[i]["VendorID"].ToString();
                dr["VendorAttn"] = dtS.Rows[i]["VendorAttn"].ToString();
                if (totalqty != 0)
                {
                    dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                }
                dt.Rows.Add(dr);
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid4(DataTable dtS)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("MakeOPID", typeof(string)));
            dt.Columns.Add(new DataColumn("MakeOPName", typeof(string)));
            dt.Columns.Add(new DataColumn("Sort", typeof(int)));

            DataColumn dc2 = new DataColumn("Qty", typeof(decimal));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("Per", typeof(string));
            dt.Columns.Add(dc3);

            decimal totalqty = 0;
            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                totalqty += SysConvert.ToDecimal(dtS.Rows[i]["SQty"]);
            }

            for (int i = 0; i < dtS.Rows.Count; i++)
            {

                DataRow dr = dt.NewRow();
                dr["Sort"] = i + 1;
                dr["Qty"] = SysConvert.ToDecimal(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"].ToString()), 3));
                dr["MakeOPID"] = dtS.Rows[i]["MakeOPID"].ToString();
                dr["MakeOPName"] = dtS.Rows[i]["MakeOPName"].ToString();
                if (totalqty != 0)
                {
                    dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                }
                dt.Rows.Add(dr);
            }
            gridView4.GridControl.DataSource = dt;
            gridView4.GridControl.Show();
        }
        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid3(DataTable dtS)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new DataColumn("Sort", typeof(int)));

            DataColumn dc2 = new DataColumn("Qty", typeof(decimal));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("Per", typeof(string));
            dt.Columns.Add(dc3);

            decimal totalqty = 0;
            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                totalqty += SysConvert.ToDecimal(dtS.Rows[i]["SQty"]);
            }

            for (int i = 0; i < dtS.Rows.Count; i++)
            {

                DataRow dr = dt.NewRow();
                dr["Sort"] = i + 1;
                dr["Qty"] = SysConvert.ToDecimal(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"].ToString()), 3));
                dr["ItemCode"] = dtS.Rows[i]["ItemCode"].ToString();
                if (totalqty != 0)
                {
                    dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                }
                dt.Rows.Add(dr);
            }
            gridView3.GridControl.DataSource = dt;
            gridView3.GridControl.Show();
        }

        #endregion
        #region 重载方法
        public override void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                CreateChart5();

                ///客户订单分析
                DataTable[] dtSCur = new DataTable[SysConvert.ToInt32(drpCheckYearNum.Text.Trim())];
                int[] yearA = new int[SysConvert.ToInt32(drpCheckYearNum.Text.Trim())];
                int ti = 0;
                for (int i = SysConvert.ToInt32(drpCheckYearNum.Text.Trim()) - 1; i >= 0; i--)
                {
                    dtSCur[ti] = this.GetDataSource(SysConvert.ToInt32(drpCheckYear.Text.Trim()) - i);
                    yearA[ti] = SysConvert.ToInt32(drpCheckYear.Text.Trim()) - i;
                    ti++;
                }
                //CreateGraphCur(zedGraphControl2, dtSCur, yearA);
                BindGrid2(dtSCur, yearA);
                CreateChart8();//曲线图

                DataTable dtVendorQty = GetDataSourceVendorQty(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                BindGrid1(dtVendorQty);
                CreateChart2(dtVendorQty);//客户订单分析饼图


                DataTable dtQty = GetDataSourceQty(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                BindGrid4(dtQty);
                CreateChart3(dtQty);//业务员订单分析饼图

                DataTable dtcpQty = GetDataSourcecpQty(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                BindGrid3(dtcpQty);
                CreateChart1(dtcpQty);//产品订单分析饼图
                
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
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
        #region  返回对比表
        /// <summary>
        /// 返回对比表
        /// </summary>
        private DataTable DBDate(DataTable[] dtS, int[] p_Year)
        {
            DataTable dt = new DataTable();

            DataColumn dcname = new DataColumn("Name", typeof(string));
            dt.Columns.Add(dcname);
            for (int i = 1; i <= 12; i++)
            {
                DataColumn dc = new DataColumn("SQty" + i, typeof(string));
                dt.Columns.Add(dc);
            }
            for (int m = 0; m < dtS.Length; m++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = p_Year[m].ToString();
                for (int i = 1; i <= 12; i++)
                {
                    dr["SQty" + i] = SysConvert.ToString(SysConvert.ToDecimal(dtS[m].Rows[i - 1]["SQty"].ToString()));
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
         #endregion
        #region 图形报表
        /// <summary>
        /// 月订单量分析
        /// </summary>
        private void CreateChart5()
        {
            try
            {
                string sql = "SELECT A.MonthInt, Amount FROM Rpt_Month A";
                sql += " LEFT OUTER JOIN ";
                sql += "(SELECT sum(TotalQty) Amount,Mon FROM ";
                sql += "(select TotalQty ,DATEPART (M,MakeDate ) Mon, MakeDate from Sale_SaleOrder where 1=1";
                sql += HTDataConditionStr;
                sql += " AND SubmitFlag=1";
                sql += ") AS A ";
                sql += "group by Mon) AS B";
                sql += " ON A.MonthInt=B.Mon ORDER BY A.MonthInt";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    //设置Titles
                    Chart5.Titles["Title1"].Text = "月订单量柱形图";
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
                    Chart5.ChartAreas["Chart Area 1"].AxisY.Title = "月订单量";
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
                        Arrays1[i][0] = SysConvert.ToDouble(dt.Rows[i]["amount"]);

                        Series series = new Series();
                        series.ShowLabelAsValue = true;
                        Chart5.Series.Add(series);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Chart5.Series["Series2"].Points.Add(i + 1);
                        Chart5.Series["Series2"].Points[i].YValues = Arrays1[i];
                        //Chart5.Series["Series2"].Points[i].AxisLabel = SysConvert.ToString(dt.Rows[i]["MonthInt"].ToString()).Substring(SysConvert.ToString(dt.Rows[i]["MonthInt"].ToString()).Length) + "月";
                        Chart5.Series["Series2"].Points[i].AxisLabel = SysConvert.ToString(dt.Rows[i]["MonthInt"].ToString()) + "月";
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        /// <summary>
        /// 年度月订单对比曲线
        /// </summary>
        private void CreateChart8()
        {
            try
            {
                DataTable[] dtSCur = new DataTable[SysConvert.ToInt32(drpCheckYearNum.Text.Trim())];
                int[] yearA = new int[SysConvert.ToInt32(drpCheckYearNum.Text.Trim())];
                int ti = 0;
                for (int i = SysConvert.ToInt32(drpCheckYearNum.Text.Trim()) - 1; i >= 0; i--)
                {
                    dtSCur[ti] = this.GetDataSource(SysConvert.ToInt32(drpCheckYear.Text.Trim()) - i);
                    yearA[ti] = SysConvert.ToInt32(drpCheckYear.Text.Trim()) - i;
                    ti++;
                }

                DataTable dt = DBDate(dtSCur, yearA);
                if (dt.Rows.Count > 0)
                {
                    //设置Titles
                    Chart8.Titles["Title1"].Text = (SysConvert.ToInt32(drpCheckYear.Text) - SysConvert.ToInt32(drpCheckYearNum.Text)).ToString() + "--" + drpCheckYear.Text + "年 月订单对比曲线图";

                    //设置Legend
                    Chart8.Legends["Default"].Docking = LegendDocking.Right;
                    Chart8.Legends["Default"].LegendStyle = LegendStyle.Column;
                    Chart8.Legends["Default"].TableStyle = LegendTableStyle.Auto;
                    Chart8.Legends["Default"].Alignment = StringAlignment.Center;
                    Chart8.Legends["Default"].InsideChartArea = "";
                    //Chart8.Legends["Default"].Title = "对比曲线";
                    Chart8.Legends["Default"].TitleColor = Color.Black;
                    Chart8.Legends["Default"].TitleAlignment = StringAlignment.Center;
                    Chart8.Legends["Default"].TitleSeparator = LegendSeparatorType.Line;
                    Chart8.Legends["Default"].TitleSeparatorColor = Color.Black;
                    Chart8.Legends["Default"].AutoFitText = true;
                    //设置X轴
                    Chart8.ChartAreas["Default"].Area3DStyle.Enable3D = false;//2D效果
                    Chart8.ChartAreas["Default"].AxisX.Title = "月份";
                    Chart8.ChartAreas["Default"].AxisX.TitleAlignment = StringAlignment.Far;//设置X轴标题的名称所在位置位远
                    Chart8.ChartAreas["Default"].AxisX.Interval = 0;//设置X轴显示间隔为2,对于X轴数据比较多的时候比较有用
                    Chart8.ChartAreas["Default"].AxisX.View.Zoomable = true;
                    Chart8.ChartAreas["Default"].AxisY.View.Zoomable = true;
                    Chart8.ChartAreas["Default"].CursorX.AutoScroll = false;
                    Chart8.ChartAreas["Default"].CursorY.AutoScroll = false;
                    Chart8.ChartAreas["Default"].AxisX.LabelStyle.ShowEndLabels = true;//去掉X轴首尾标签
                    Chart8.ChartAreas["Default"].AxisX.ScrollBar.PositionInside = true;
                    Chart8.ChartAreas["Default"].AxisX.Margin = true;
                    //设置Y轴
                    Chart8.ChartAreas["Default"].AxisY.Title = "订单数";
                    Chart8.ChartAreas["Default"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
                    //设置ChartAreas
                    Chart8.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
                    Chart8.ChartAreas["Default"].AxisX.MajorGrid.Interval = 1;
                    Chart8.ChartAreas["Default"].AxisX.MajorTickMark.Interval = 1;
                    //清除原有Series
                    Chart8.Series.Clear();
                    //曲线
                    for (int j = 0; j < yearA.Length; j++)
                    {
                        Series series = new Series();
                        series.LegendText = yearA[j].ToString();
                        series.Type = SeriesChartType.Spline;
                        series.BorderStyle = ChartDashStyle.Solid;
                        series.BorderWidth = 1;
                        series.BorderColor = Color.FromArgb(180, 26, 59, 105);
                        series.BackGradientType = GradientType.None;
                        series.ShowLabelAsValue = true;
                        series.BorderWidth = 3;
                        series.MarkerSize = 8;
                        series.MarkerStyle = MarkerStyle.Circle;
                        series.Color = SericsColorProc.GetColor(j + 1);
                        Chart8.Series.Add(series);
                    }
                    //绑定Series值
                    for (int i = 0; i < Chart8.Series.Count; i++)
                    {
                        double[][] Arrays1 = new double[dtSCur[i].Rows.Count][];

                        for (int j = 0; j < 12; j++)
                        {
                            Arrays1[i] = new double[1];
                            Arrays1[i][0] = SysConvert.ToDouble(dtSCur[i].Rows[j]["SQty"]);

                            Chart8.Series["Series" + SysConvert.ToString(i + 1)].Points.Add(j + 1);
                            Chart8.Series["Series" + SysConvert.ToString(i + 1)].Points[j].YValues = Arrays1[i];
                            Chart8.Series["Series" + SysConvert.ToString(i + 1)].Points[j].AxisLabel = SysConvert.ToString(dtSCur[i].Rows[j]["MonthInt"].ToString()) + "月";
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary> 
        /// 客户订单饼状分析图       
        /// </summary>
        /// <param name="dt"></param>
        private void CreateChart2(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {

                    DataColumn dc3 = new DataColumn("Per", typeof(string));
                    dt.Columns.Add(dc3);
                    decimal totalqty = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalqty += SysConvert.ToDecimal(dt.Rows[i]["SQty"]);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (totalqty != 0)
                        {
                            dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                        }
                    }




                    //设置Titles
                    string TitlesTemp = string.Empty;
                    if (!ChkMakeDate.Checked)
                    {
                        TitlesTemp = SysConvert.ToString(drpCheckYear.EditValue) + "客户订单饼状图";
                    }
                    else
                    {
                        TitlesTemp = SysConvert.ToString(txtQMakeDateS.DateTime.Date) + "至" + SysConvert.ToString(txtQMakeDateE.DateTime.Date) + "客户订单饼状图";
                    }

                    Chart2.Titles["Title1"].Text = TitlesTemp;




                    //设置Legend
                    Chart2.Legends["Default"].Docking = LegendDocking.Right;
                    Chart2.Legends["Default"].LegendStyle = LegendStyle.Column;
                    Chart2.Legends["Default"].TableStyle = LegendTableStyle.Auto;
                    Chart2.Legends["Default"].Alignment = StringAlignment.Center;
                    Chart2.Legends["Default"].InsideChartArea = "";
                    //Chart2.Legends["Default"].Title = "采购量饼状图";
                    Chart2.Legends["Default"].TitleColor = Color.Black;
                    Chart2.Legends["Default"].TitleAlignment = StringAlignment.Center;
                    Chart2.Legends["Default"].TitleSeparator = LegendSeparatorType.Line;
                    Chart2.Legends["Default"].TitleSeparatorColor = Color.Black;
                    Chart2.Legends["Default"].AutoFitText = true;

                    //Chart2.Series[0]["Series1"] = "0:10";

                    //设置ChartAreas
                    Chart2.ChartAreas["Area1"].Area3DStyle.Enable3D = true;

                    //设置Series1
                    Chart2.Series["Series1"].Type = SeriesChartType.Pie;
                    Chart2.Series["Series1"]["PieLabelStyle"] = "Outside";


                    string[] xValues = new string[dt.Rows.Count];
                    double[] yValues = new double[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        xValues[i] = SysConvert.ToString(dt.Rows[i]["VendorAttn"]);
                        yValues[i] = SysConvert.ToDouble(dt.Rows[i]["SQty"]);
                    }

                    Chart2.Series["Series1"].Points.Clear();
                    Chart2.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Chart2.Series["Series1"].Points[i].Label = SysConvert.ToString(dt.Rows[i]["VendorAttn"]) + SysConvert.ToString(dt.Rows[i]["Per"]) + Environment.NewLine + SysConvert.ToString(dt.Rows[i]["SQty"]);

                        Chart2.Series["Series1"].Points[i].LegendText = xValues[i].ToString();

                        Chart2.Series["Series1"].Points[i].ToolTip = "客户: " + xValues[i].ToString() + "\n数量: " + yValues[i].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary> 
        /// 业务员订单饼状分析图       
        /// </summary>
        /// <param name="dt"></param>
        private void CreateChart3(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {

                    DataColumn dc3 = new DataColumn("Per", typeof(string));
                    dt.Columns.Add(dc3);
                    decimal totalqty = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalqty += SysConvert.ToDecimal(dt.Rows[i]["SQty"]);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (totalqty != 0)
                        {
                            dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                        }
                    }




                    //设置Titles
                    string TitlesTemp = string.Empty;
                    if (!ChkMakeDate.Checked)
                    {
                        TitlesTemp = SysConvert.ToString(drpCheckYear.EditValue) + "业务员订单饼状图";
                    }
                    else
                    {
                        TitlesTemp = SysConvert.ToString(txtQMakeDateS.DateTime.Date) + "至" + SysConvert.ToString(txtQMakeDateE.DateTime.Date) + "业务员订单饼状图";
                    }

                    chart3.Titles["Title1"].Text = TitlesTemp;

 

                    //设置Legend
                    chart3.Legends["Default"].Docking = LegendDocking.Right;
                    chart3.Legends["Default"].LegendStyle = LegendStyle.Column;
                    chart3.Legends["Default"].TableStyle = LegendTableStyle.Auto;
                    chart3.Legends["Default"].Alignment = StringAlignment.Center;
                    chart3.Legends["Default"].InsideChartArea = "";
                    //Chart2.Legends["Default"].Title = "采购量饼状图";
                    chart3.Legends["Default"].TitleColor = Color.Black;
                    chart3.Legends["Default"].TitleAlignment = StringAlignment.Center;
                    chart3.Legends["Default"].TitleSeparator = LegendSeparatorType.Line;
                    chart3.Legends["Default"].TitleSeparatorColor = Color.Black;
                    chart3.Legends["Default"].AutoFitText = true;

                    //Chart2.Series[0]["Series1"] = "0:10";

                    //设置ChartAreas
                    chart3.ChartAreas["Area1"].Area3DStyle.Enable3D = true;

                    //设置Series1
                    chart3.Series["Series1"].Type = SeriesChartType.Pie;
                    chart3.Series["Series1"]["PieLabelStyle"] = "Outside";


                    string[] xValues = new string[dt.Rows.Count];
                    double[] yValues = new double[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        xValues[i] = SysConvert.ToString(dt.Rows[i]["MakeOPName"]);
                        yValues[i] = SysConvert.ToDouble(dt.Rows[i]["SQty"]);
                    }

                    chart3.Series["Series1"].Points.Clear();
                    chart3.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart3.Series["Series1"].Points[i].Label = SysConvert.ToString(dt.Rows[i]["MakeOPName"]) + SysConvert.ToString(dt.Rows[i]["Per"]) + Environment.NewLine + SysConvert.ToString(dt.Rows[i]["SQty"]);

                        chart3.Series["Series1"].Points[i].LegendText = xValues[i].ToString();

                        chart3.Series["Series1"].Points[i].ToolTip = "业务员: " + xValues[i].ToString() + "\n数量: " + yValues[i].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary> 
        /// 业务员订单饼状分析图       
        /// </summary>
        /// <param name="dt"></param>
        private void CreateChart1(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {

                    DataColumn dc3 = new DataColumn("Per", typeof(string));
                    dt.Columns.Add(dc3);
                    decimal totalqty = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalqty += SysConvert.ToDecimal(dt.Rows[i]["SQty"]);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (totalqty != 0)
                        {
                            dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                        }
                    }




                    //设置Titles
                    string TitlesTemp = string.Empty;
                    if (!ChkMakeDate.Checked)
                    {
                        TitlesTemp = SysConvert.ToString(drpCheckYear.EditValue) + "产品订单饼状图";
                    }
                    else
                    {
                        TitlesTemp = SysConvert.ToString(txtQMakeDateS.DateTime.Date) + "至" + SysConvert.ToString(txtQMakeDateE.DateTime.Date) + "产品订单饼状图";
                    }

                    chart1.Titles["Title1"].Text = TitlesTemp;



                    //设置Legend
                    chart1.Legends["Default"].Docking = LegendDocking.Right;
                    chart1.Legends["Default"].LegendStyle = LegendStyle.Column;
                    chart1.Legends["Default"].TableStyle = LegendTableStyle.Auto;
                    chart1.Legends["Default"].Alignment = StringAlignment.Center;
                    chart1.Legends["Default"].InsideChartArea = "";
                    //Chart2.Legends["Default"].Title = "采购量饼状图";
                    chart1.Legends["Default"].TitleColor = Color.Black;
                    chart1.Legends["Default"].TitleAlignment = StringAlignment.Center;
                    chart1.Legends["Default"].TitleSeparator = LegendSeparatorType.Line;
                    chart1.Legends["Default"].TitleSeparatorColor = Color.Black;
                    chart1.Legends["Default"].AutoFitText = true;

                    //Chart2.Series[0]["Series1"] = "0:10";

                    //设置ChartAreas
                    chart1.ChartAreas["Area1"].Area3DStyle.Enable3D = true;

                    //设置Series1
                    chart1.Series["Series1"].Type = SeriesChartType.Pie;
                    chart1.Series["Series1"]["PieLabelStyle"] = "Outside";


                    string[] xValues = new string[dt.Rows.Count];
                    double[] yValues = new double[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        xValues[i] = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                        yValues[i] = SysConvert.ToDouble(dt.Rows[i]["SQty"]);
                    }

                    chart1.Series["Series1"].Points.Clear();
                    chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart1.Series["Series1"].Points[i].Label = SysConvert.ToString(dt.Rows[i]["ItemCode"]) + "   "+SysConvert.ToString(dt.Rows[i]["Per"]) + Environment.NewLine + SysConvert.ToString(dt.Rows[i]["SQty"]);

                        chart1.Series["Series1"].Points[i].LegendText = xValues[i].ToString();

                        chart1.Series["Series1"].Points[i].ToolTip = "产品: " + xValues[i].ToString() + "\n数量: " + yValues[i].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        
        #endregion
        #region 绑定数据源
        /// <summary>
        /// 得到报表数据源
        /// </summary>
        private DataTable GetDataSource(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.MonthInt, SQty FROM Rpt_Month A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " LEFT OUTER JOIN ";
            sql += "(SELECT sum(TotalQty) SQty,Mon FROM ";
            sql += "  (SELECT TotalQty,DATEPART (M,MakeDate ) Mon,MakeDate ";
            sql += "   FROM Sale_SaleOrder WHERE  MakeDate ";
            sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");

            sql += ") AS A ";
            sql += " GROUP BY Mon) AS B";
            sql += " ON A.MonthInt=B.Mon ORDER BY A.MonthInt";
            dt = SysUtils.Fill(sql);
            return dt;
        }
        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourceVendorQty(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.VendorAttn, B.SQty,B.VendorID FROM Data_Vendor A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " Right OUTER JOIN ";
            sql += "(SELECT Sum(TotalQty) SQty,VendorID";
            sql += "  ";
            sql += "   FROM Sale_SaleOrder WHERE SubmitFlag=1 AND MakeDate  ";
            if (!ChkMakeDate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            sql += " GROUP BY VendorID) AS B ";
            sql += " ON A.VendorID=B.VendorID ORDER BY B.SQty DESC";
            dt = SysUtils.Fill(sql);
            return dt;
        }
        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourceQty(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.OPName as MakeOPName, B.SQty,B.MakeOPID as MakeOPID FROM Data_OP A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " Right OUTER JOIN ";
            sql += "(SELECT Sum(TotalQty) SQty,MakeOPID";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND MakeDate  ";
            if (!ChkMakeDate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            sql += " GROUP BY MakeOPID) AS B ";
            sql += " ON A.OPID=B.MakeOPID ORDER BY B.SQty DESC";
            dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourcecpQty(int year)
        {
            DataTable dt = new DataTable();
            //string sql = "SELECT A.OPName as MakeOPName, B.SQty,B.MakeOPID as MakeOPID FROM Data_OP A";//cast(B.F_QtySum as decimal(8,2)) 
            //sql += " Right OUTER JOIN ";
            string sql = "SELECT Sum(TotalQty) SQty,ItemCode";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND MakeDate  ";
            if (!ChkMakeDate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            sql += " GROUP BY ItemCode  ";
            sql += " ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            return dt;
        }

        #endregion 
    }
}