using System.Collections.Generic;
using System.Text;
using System;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.Sys;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using ZedGraph;
using Dundas.Charting.WinControl;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Grid;

namespace MLTERP
{
    /// <summary>
    /// 订单图形分析报表
    /// </summary>
    public partial class frmSaleOrderGraphRpt : frmAPBaseUIRpt
    {
        public frmSaleOrderGraphRpt()
        {
            InitializeComponent();
        }
        public override void IniData()
        {
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView1, gridView2, gridView3, gridView4, gridView6, gridView7 };
            int Now = DateTime.Now.Year;
            DataTable dt = new DataTable();
            dt.Columns.Add("Year");
            for (int i = 0; i < 5; i++)
            {
                dt.Rows.Add(dt.NewRow());
                dt.Rows[dt.Rows.Count - 1][0] = Now - i;
            }
            FCommon.LoadDropComb(drpCheckYear, dt, "Year", true);
        }

        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                GridView ToExcelGrid = (GridView)this.GetType().GetField(xtraTabControl1.SelectedTabPage.Tag.ToString(), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);

                this.ToExcel(ToExcelGrid);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 自定义方法

        /// <summary>
        /// 获得颜色
        /// </summary>
        /// <param name="p_I"></param>
        /// <returns></returns>
        private Color GetColor(int p_I)
        {
            Color oc = Color.Red;
            switch (p_I)
            {
                case 1:
                    oc = Color.Blue;
                    break;
                case 2:
                    oc = Color.Yellow;
                    break;
                case 3:
                    oc = Color.Black;
                    break;
                case 4:
                    oc = Color.DarkOrange;
                    break;
                case 5:
                    oc = Color.DarkGray;
                    break;
                case 6:
                    oc = Color.DarkCyan;
                    break;
                case 7:
                    oc = Color.DarkSlateBlue;
                    break;
                case 8:
                    oc = Color.DimGray;
                    break;
                case 9:
                    oc = Color.Gold;
                    break;
                case 10:
                    oc = Color.Ivory;
                    break;
                case 11:
                    oc = Color.Gainsboro;
                    break;
                case 12:
                    oc = Color.Aquamarine;
                    break;
                case 13:
                    oc = Color.Aqua;
                    break;
                case 14:
                    oc = Color.Beige;
                    break;
                case 15:
                    oc = Color.Firebrick;
                    break;
                case 16:
                    oc = Color.LightCoral;
                    break;
                case 17:
                    oc = Color.Linen;
                    break;
                case 18:
                    oc = Color.MintCream;
                    break;
                case 19:
                    oc = Color.SandyBrown;
                    break;
                case 20:
                    oc = Color.Turquoise;
                    break;

            }
            return oc;
        }

        #region 绑定柱状图

        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSource(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.MonthInt, SQty FROM Rpt_Month A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " LEFT OUTER JOIN ";
            sql += "(SELECT Sum(Qty) SQty,Mon FROM ";
            sql += "  (SELECT Qty,DATEPART (M,OrderDate ) Mon,OrderDate ";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND OrderDate ";
            sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemCode =" + SysString.ToDBString(txtItemCode.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel =" + SysString.ToDBString(txtItemModel.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                sql += " AND ColorNum=" + SysString.ToDBString(txtColorNum.Text.Trim());
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                sql += " AND ColorName=" + SysString.ToDBString(txtColorName.Text.Trim());
            }


            sql += ") AS A ";
            sql += " GROUP BY Mon) AS B";
            sql += " ON A.MonthInt=B.Mon ORDER BY A.MonthInt";
            dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateGraph(ZedGraphControl zgc, DataTable dtS)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            //myPane.Y2AxisList.Clear();
            //myPane.YAxisList.Clear();
            //myPane.xAxisList.Clear();
            // Set the titles and axis labels
            myPane.Title.Text = drpCheckYear.Text + "年 月下单量柱状图  (单位：吨)";
            myPane.XAxis.Title.Text = "月份";
            myPane.YAxis.Title.Text = "下单量";

            PointPairList list = new PointPairList();
            for (int x = 0; x < dtS.Rows.Count; x++)
            {
                double tempx = SysConvert.ToDouble(dtS.Rows[x]["MonthInt"].ToString());
                double tempy = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[x]["SQty"].ToString())));

                list.Add(tempx, tempy, tempy.ToString());
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            //LineItem myCurve = myPane.AddCurve("图形", list, Color.Blue,SymbolType.Diamond);
            BarItem myCurve = myPane.AddBar("下单量", list, Color.Blue);//使用哪一种图类



            myCurve.Bar.Fill = new Fill(Color.White, Color.Red, 45F);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            // myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            //myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);//报表图形背景

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);//画布背景//Color.FromArgb(220, 220, 255
            //myPane.BarSettings.Base

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            zgc.Refresh();
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid1(DataTable dtS)
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
                dr["Qty" + i] = SysConvert.ToString(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i - 1]["SQty"].ToString())));
            }
            dt.Rows.Add(dr);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        #endregion

        #region 绑定曲线对比图

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateGraphCur(ZedGraphControl zgc, DataTable[] dtS, int[] p_YI)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            //myPane.Y2AxisList.Clear();
            //myPane.YAxisList.Clear();
            //myPane.xAxisList.Clear();
            // Set the titles and axis labels
            myPane.Title.Text = (SysConvert.ToInt32(drpCheckYear.Text) - SysConvert.ToInt32(drpCheckYearNum.Text)).ToString() + "--" + drpCheckYear.Text + "年 月订单量对比图  (单位：吨)";
            myPane.XAxis.Title.Text = "月份";
            myPane.YAxis.Title.Text = "订单量";

            for (int i = 0; i < dtS.Length; i++)
            {
                PointPairList list = new PointPairList();
                for (int x = 0; x < dtS[i].Rows.Count; x++)
                {
                    double tempx = SysConvert.ToDouble(dtS[i].Rows[x]["MonthInt"].ToString());
                    double tempy = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS[i].Rows[x]["SQty"].ToString())));

                    list.Add(tempx, tempy, tempy.ToString());
                }

                // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
                //LineItem myCurve = myPane.AddCurve("图形", list, Color.Blue,SymbolType.Diamond);
                Color tc = GetColor(i);
                LineItem myCurve = myPane.AddCurve(p_YI[i] + "年", list, tc);//使用哪一种图类



                myCurve.Symbol.Fill = new Fill(Color.White, tc, 45F);
                // Fill the area under the curve with a white-red gradient at 45 degrees
                // myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
                // Make the symbols opaque by filling them with white
                //myCurve.Symbol.Fill = new Fill(Color.White);

                // Fill the axis background with a color gradient
                myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);//报表图形背景

                // Fill the pane background with a color gradient
                myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);//画布背景//Color.FromArgb(220, 220, 255
                //myPane.BarSettings.Base
            }
            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            zgc.Refresh();
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
        #endregion

        #region 绑定业务组别饼图

        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourceVendorAmount(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.VendorAttn, B.Amount,B.VendorID FROM Data_Vendor A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " Right OUTER JOIN ";
            sql += "(SELECT Sum(Amount) Amount,VendorID";
            sql += "  ";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND OrderDate  ";
            if (!chkIndate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemCode =" + SysString.ToDBString(txtItemCode.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel =" + SysString.ToDBString(txtItemModel.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                sql += " AND ColorNum=" + SysString.ToDBString(txtColorNum.Text.Trim());
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                sql += " AND ColorName=" + SysString.ToDBString(txtColorName.Text.Trim());
            }


            sql += " GROUP BY VendorID) AS B ";
            sql += " ON A.VendorID=B.VendorID ORDER BY B.Amount DESC";
            dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateGraphSOTypeSource(ZedGraphControl zgc, DataTable dtS)
        {

            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            //myPane.Y2AxisList.Clear();
            //myPane.YAxisList.Clear();
            //myPane.xAxisList.Clear();
            // Set the titles and axis labels
            myPane.Title.Text = drpCheckYear.Text + "年 订单业务组别饼图  (单位：吨)";
            //myPane.XAxis.Title.Text = "月份";
            myPane.YAxis.Title.Text = "订单量";

            //PointPairList list = new PointPairList();
            double[] vd = new double[dtS.Rows.Count];
            string[] vs = new string[dtS.Rows.Count];
            for (int x = 0; x < dtS.Rows.Count; x++)
            {
                double tempx = SysConvert.ToDouble(dtS.Rows[x]["ID"].ToString());
                double tempy = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[x]["SQty"].ToString())));
                vd[x] = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[x]["SQty"].ToString())));
                vs[x] = dtS.Rows[x]["Name"].ToString();
                //list.Add(tempx, tempy, tempy.ToString() + " T");
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            //LineItem myCurve = myPane.AddCurve("图形", list, Color.Blue,SymbolType.Diamond);
            //BarItem myCurve = myPane.AddPieSlices("投染量", list, Color.Blue);//使用哪一种图类
            PieItem[] myCurve = myPane.AddPieSlices(vd, vs);//使用哪一种图类
            for (int i = 0; i < myCurve.Length; i++)
            {
                Color tc = this.GetColor(i);
                myCurve[i].Fill = new Fill(Color.White, tc, 45F);
            }



            //myCurve.Bar.Fill = new Fill(Color.White, Color.Red, 45F);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            // myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            //myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);//报表图形背景

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);//画布背景//Color.FromArgb(220, 220, 255
            //myPane.BarSettings.Base

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            zgc.Refresh();
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid3(DataTable dtS)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("VendorID", typeof(string)));
            dt.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
            dt.Columns.Add(new DataColumn("Sort", typeof(int)));


            DataColumn dc4 = new DataColumn("Amount", typeof(decimal));
            dt.Columns.Add(dc4);

            DataColumn dc5 = new DataColumn("APer", typeof(string));
            dt.Columns.Add(dc5);
            decimal totalqty = 0;
            decimal totalamount = 0;
            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                totalamount += SysConvert.ToDecimal(dtS.Rows[i]["Amount"]);
            }

            for (int i = 0; i < dtS.Rows.Count; i++)
            {

                DataRow dr = dt.NewRow();
                dr["Sort"] = i + 1;
                dr["Amount"] = SysConvert.ToDecimal(dtS.Rows[i]["Amount"].ToString());
                dr["VendorID"] = dtS.Rows[i]["VendorID"].ToString();
                dr["VendorAttn"] = dtS.Rows[i]["VendorAttn"].ToString();

                if (totalamount != 0)
                {
                    dr["APer"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["Amount"]) * 100 / totalamount, 2).ToString() + "%";
                }
                dt.Rows.Add(dr);
            }
            gridView3.GridControl.DataSource = dt;
            gridView3.GridControl.Show();
        }
        #endregion


        #region 绑定订单类型饼图

        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourceVendorQty(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.VendorAttn, B.SQty,B.VendorID FROM Data_Vendor A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " Right OUTER JOIN ";
            sql += "(SELECT Sum(Qty) SQty,VendorID";
            sql += "  ";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND OrderDate  ";
            if (!chkIndate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemCode =" + SysString.ToDBString(txtItemCode.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel =" + SysString.ToDBString(txtItemModel.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                sql += " AND ColorNum=" + SysString.ToDBString(txtColorNum.Text.Trim());
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                sql += " AND ColorName=" + SysString.ToDBString(txtColorName.Text.Trim());
            }

            sql += " GROUP BY VendorID) AS B ";
            sql += " ON A.VendorID=B.VendorID ORDER BY B.SQty DESC";
            dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateGraphGoodsTypeSource(ZedGraphControl zgc, DataTable dtS)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            //myPane.Y2AxisList.Clear();
            //myPane.YAxisList.Clear();
            //myPane.xAxisList.Clear();
            // Set the titles and axis labels
            myPane.Title.Text = drpCheckYear.Text + "年 订单类型饼图  (单位：吨)";
            //myPane.XAxis.Title.Text = "月份";
            myPane.YAxis.Title.Text = "订单量";

            //PointPairList list = new PointPairList();
            double[] vd = new double[dtS.Rows.Count];
            string[] vs = new string[dtS.Rows.Count];
            for (int x = 0; x < dtS.Rows.Count; x++)
            {
                double tempx = SysConvert.ToDouble(dtS.Rows[x]["ID"].ToString());
                double tempy = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[x]["SQty"].ToString())));
                vd[x] = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[x]["SQty"].ToString())));
                vs[x] = dtS.Rows[x]["Name"].ToString();
                //list.Add(tempx, tempy, tempy.ToString() + " T");
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            //LineItem myCurve = myPane.AddCurve("图形", list, Color.Blue,SymbolType.Diamond);
            //BarItem myCurve = myPane.AddPieSlices("投染量", list, Color.Blue);//使用哪一种图类
            PieItem[] myCurve = myPane.AddPieSlices(vd, vs);//使用哪一种图类
            for (int i = 0; i < myCurve.Length; i++)
            {
                Color tc = this.GetColor(i);
                myCurve[i].Fill = new Fill(Color.White, tc, 45F);
            }



            //myCurve.Bar.Fill = new Fill(Color.White, Color.Red, 45F);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            // myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            //myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);//报表图形背景

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);//画布背景//Color.FromArgb(220, 220, 255
            //myPane.BarSettings.Base

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            zgc.Refresh();
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid4(DataTable dtS)
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
            gridView4.GridControl.DataSource = dt;
            gridView4.GridControl.Show();
        }
        #endregion

        #region 绑定纱线类型饼图

        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourceYarnTypeSouce(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.ID,A.Name, B.SQty FROM Enum_YarnType A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " LEFT OUTER JOIN ";
            sql += "(SELECT Sum(Qty) SQty,YarnTypeID";
            sql += "  ";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND OrderDate  ";
            //sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            if (!chkIndate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemCode =" + SysString.ToDBString(txtItemCode.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel =" + SysString.ToDBString(txtItemModel.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                sql += " AND ColorNum=" + SysString.ToDBString(txtColorNum.Text.Trim());
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                sql += " AND ColorName=" + SysString.ToDBString(txtColorName.Text.Trim());
            }


            sql += " GROUP BY YarnTypeID) AS B ";
            sql += " ON A.ID=B.YarnTypeID ORDER BY A.ID";
            dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateGraphYarnTypeSource(ZedGraphControl zgc, DataTable dtS)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            //myPane.Y2AxisList.Clear();
            //myPane.YAxisList.Clear();
            //myPane.xAxisList.Clear();
            // Set the titles and axis labels
            myPane.Title.Text = drpCheckYear.Text + "年 纱线类型饼图";
            //myPane.XAxis.Title.Text = "月份";
            myPane.YAxis.Title.Text = "订单量";

            //PointPairList list = new PointPairList();
            double[] vd = new double[dtS.Rows.Count];
            string[] vs = new string[dtS.Rows.Count];
            for (int x = 0; x < dtS.Rows.Count; x++)
            {
                double tempx = SysConvert.ToDouble(dtS.Rows[x]["ID"].ToString());
                double tempy = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[x]["SQty"].ToString())));
                vd[x] = SysConvert.ToDouble(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[x]["SQty"].ToString()), 3));
                vs[x] = dtS.Rows[x]["Name"].ToString();
                //list.Add(tempx, tempy, tempy.ToString() + " T");
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            //LineItem myCurve = myPane.AddCurve("图形", list, Color.Blue,SymbolType.Diamond);
            //BarItem myCurve = myPane.AddPieSlices("投染量", list, Color.Blue);//使用哪一种图类
            PieItem[] myCurve = myPane.AddPieSlices(vd, vs);//使用哪一种图类
            for (int i = 0; i < myCurve.Length; i++)
            {
                Color tc = this.GetColor(i);
                myCurve[i].Fill = new Fill(Color.White, tc, 45F);
            }



            //myCurve.Bar.Fill = new Fill(Color.White, Color.Red, 45F);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            // myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            //myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);//报表图形背景

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);//画布背景//Color.FromArgb(220, 220, 255
            //myPane.BarSettings.Base

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            zgc.Refresh();
        }


        #endregion

        #region 绑定客户排名

        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourceVendorSouce(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.VendorAttn, B.SQty,B.Amount,B.VendorID FROM Data_Vendor A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " Right OUTER JOIN ";
            sql += "(SELECT Sum(Qty) SQty,Sum(Amount) as Amount,VendorID";
            sql += "  ";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND OrderDate  ";
            //sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            if (!chkIndate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemCode =" + SysString.ToDBString(txtItemCode.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel =" + SysString.ToDBString(txtItemModel.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                sql += " AND ColorNum=" + SysString.ToDBString(txtColorNum.Text.Trim());
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                sql += " AND ColorName=" + SysString.ToDBString(txtColorName.Text.Trim());
            }

            sql += " GROUP BY VendorID) AS B ";
            sql += " ON A.VendorID=B.VendorID ORDER BY B.SQty DESC";
            dt = SysUtils.Fill(sql);
            return dt;
        }



        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid6(DataTable dtS)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("VendorID", typeof(string)));
            dt.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
            dt.Columns.Add(new DataColumn("Sort", typeof(int)));

            DataColumn dc2 = new DataColumn("Qty", typeof(decimal));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("Per", typeof(string));
            dt.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn("Amount", typeof(decimal));
            dt.Columns.Add(dc4);

            DataColumn dc5 = new DataColumn("APer", typeof(string));
            dt.Columns.Add(dc5);
            decimal totalqty = 0;
            decimal totalamount = 0;
            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                totalqty += SysConvert.ToDecimal(dtS.Rows[i]["SQty"]);
                totalamount += SysConvert.ToDecimal(dtS.Rows[i]["Amount"]);
            }

            for (int i = 0; i < dtS.Rows.Count; i++)
            {

                DataRow dr = dt.NewRow();
                dr["Sort"] = i + 1;
                dr["Qty"] = SysConvert.ToDecimal(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"].ToString())));
                dr["Amount"] = SysConvert.ToDecimal(dtS.Rows[i]["Amount"].ToString());
                dr["VendorID"] = dtS.Rows[i]["VendorID"].ToString();
                dr["VendorAttn"] = dtS.Rows[i]["VendorAttn"].ToString();
                if (totalqty != 0)
                {
                    dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                }
                if (totalamount != 0)
                {
                    dr["APer"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["Amount"]) * 100 / totalamount, 2).ToString() + "%";
                }
                dt.Rows.Add(dr);
            }
            gridView6.GridControl.DataSource = dt;
            gridView6.GridControl.Show();
        }
        #endregion

        #region 绑定产品排名

        /// <summary>
        /// 得到报表数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataSourceItemSouce(int year)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT A.ItemCode,A.ItemName,A.ItemStd,A.ItemModel, B.SQty FROM Data_Item A";//cast(B.F_QtySum as decimal(8,2)) 
            sql += " Right OUTER JOIN ";
            sql += "(SELECT Sum(Qty) SQty,ItemCode";
            sql += "  ";
            sql += "   FROM UV1_Sale_SaleOrderDts WHERE SubmitFlag=1 AND OrderDate  ";
            if (!chkIndate.Checked)
            {
                sql += "   BETWEEN " + SysString.ToDBString(year.ToString() + "-01-01") + " AND " + SysString.ToDBString(year.ToString() + "-12-31 23:59:59");
            }
            else
            {
                sql += "   BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemCode =" + SysString.ToDBString(txtItemCode.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel =" + SysString.ToDBString(txtItemModel.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                sql += " AND ColorNum=" + SysString.ToDBString(txtColorNum.Text.Trim());
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                sql += " AND ColorName=" + SysString.ToDBString(txtColorName.Text.Trim());
            }

            sql += " GROUP BY ItemCode) AS B ";
            sql += " ON A.ItemCode=B.ItemCode ORDER BY B.SQty DESC";
            dt = SysUtils.Fill(sql);
            return dt;
        }



        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid7(DataTable dtS)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemStd", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemModel", typeof(string)));
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
                dr["Qty"] = SysConvert.ToDecimal(SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"].ToString())));
                dr["ItemCode"] = dtS.Rows[i]["ItemCode"].ToString();
                dr["ItemName"] = dtS.Rows[i]["ItemName"].ToString();
                dr["ItemStd"] = dtS.Rows[i]["ItemStd"].ToString();
                dr["ItemModel"] = dtS.Rows[i]["ItemModel"].ToString();
                if (totalqty != 0)
                {
                    dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dtS.Rows[i]["SQty"]) * 100 / totalqty, 2).ToString() + "%";
                }
                dt.Rows.Add(dr);
            }
            gridView7.GridControl.DataSource = dt;
            gridView7.GridControl.Show();
        }
        #endregion

        #endregion

        #region 窗体加载
        /// 窗体加载
        /// </summary>
        private void frmYarnGraphRpt_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessGrid.BindGridColumn(gridView1, this.FormID);
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);

                ProcessGrid.BindGridColumn(gridView2, this.FormID);
                ProcessGrid.SetGridColumnUI(gridView2, this.FormListAID, this.FormListBID);

                ProcessGrid.BindGridColumn(gridView3, this.FormID);
                ProcessGrid.SetGridColumnUI(gridView3, this.FormListAID, this.FormListBID);

                ProcessGrid.BindGridColumn(gridView4, this.FormID);
                ProcessGrid.SetGridColumnUI(gridView4, this.FormListAID, this.FormListBID);


                ProcessGrid.BindGridColumn(gridView6, this.FormID);
                ProcessGrid.SetGridColumnUI(gridView6, this.FormListAID, this.FormListBID);

                ProcessGrid.BindGridColumn(gridView7, this.FormID);
                ProcessGrid.SetGridColumnUI(gridView7, this.FormListAID, this.FormListBID);

                drpCheckYear.Text = DateTime.Now.Year.ToString();


                txtQIndateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
                txtQIndateE.DateTime = DateTime.Now.Date;



                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);


                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #endregion

        #region 按钮事件
        /// <summary>
        /// 查询
        /// </summary>
        public override void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtS = GetDataSource(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                //CreateGraph(zedGraphControl1, dtS);
                BindGrid1(dtS);

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


                ///供应商金额分析
                DataTable dtVendorAmount = GetDataSourceVendorAmount(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                //CreateGraphSOTypeSource(zedGraphControl3, dtSSoTYpeSource);
                BindGrid3(dtVendorAmount);
                CreateChart1(dtVendorAmount);


                ///供应商采购量分析
                DataTable dtVendorQty = GetDataSourceVendorQty(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                BindGrid4(dtVendorQty);
                CreateChart2(dtVendorQty);




                DataTable dtSSoVendor = GetDataSourceVendorSouce(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                BindGrid6(dtSSoVendor);


                DataTable dtSSoItem = GetDataSourceItemSouce(SysConvert.ToInt32(drpCheckYear.Text.Trim()));
                BindGrid7(dtSSoItem);

                CreateChart5();
                CreateChart8();




            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region 图形分析报表
        /// <summary>
        /// 柱状图
        /// </summary>
        private void CreateChart5()
        {
            try
            {
                DataTable dt = GetDataSource(SysConvert.ToInt32(drpCheckYear.Text.Trim()));

                if (dt.Rows.Count > 0)
                {
                    //设置Titles
                    Chart5.Titles["Title1"].Text = drpCheckYear.Text.Trim() + "每月业务量图形报表";
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
                    Chart5.ChartAreas["Chart Area 1"].AxisY.Title = "业务量";
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
                        Arrays1[i][0] = SysConvert.ToDouble(dt.Rows[i]["SQty"]);

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
        /// <summary>
        /// 对比曲线
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
                    Chart8.Titles["Title1"].Text = (SysConvert.ToInt32(drpCheckYear.Text) - SysConvert.ToInt32(drpCheckYearNum.Text)).ToString() + "--" + drpCheckYear.Text + "年 月业务量对比曲线图";

                    //设置Legend
                    Chart8.Legends["Default"].Docking = LegendDocking.Right;
                    Chart8.Legends["Default"].LegendStyle = LegendStyle.Column;
                    Chart8.Legends["Default"].TableStyle = LegendTableStyle.Auto;
                    Chart8.Legends["Default"].Alignment = StringAlignment.Center;
                    Chart8.Legends["Default"].InsideChartArea = "";
                    //Chart8.Legends["Default"].Title = "业务量对比曲线";
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
                    Chart8.ChartAreas["Default"].AxisY.Title = "业务量";
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
        /// 功能：业务员饼状图
        /// 作者：卢克松
        /// 日期：2009-4-3          
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
                    if (!chkIndate.Checked)
                    {
                        TitlesTemp = SysConvert.ToString(drpCheckYear.EditValue) + "年订单总数量饼状图";
                    }
                    else
                    {
                        TitlesTemp = SysConvert.ToString(txtQIndateS.DateTime.Date) + "至" + SysConvert.ToString(txtQIndateE.DateTime.Date) + "订单总数量饼状图";
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
        /// 功能：订单类型饼状图
        /// 日期：2009-4-3          
        /// </summary>
        /// <param name="dt"></param>
        private void CreateChart1(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    //设置Titles
                    DataColumn dc3 = new DataColumn("Per", typeof(string));
                    dt.Columns.Add(dc3);
                    decimal totalamount = 0;
                    string TitlesTemp = string.Empty;
                    if (!chkIndate.Checked)
                    {
                        TitlesTemp = SysConvert.ToString(drpCheckYear.EditValue) + "年订单金额饼状图";
                    }
                    else
                    {
                        TitlesTemp = SysConvert.ToString(txtQIndateS.DateTime.Date) + "至" + SysConvert.ToString(txtQIndateE.DateTime.Date) + "订单金额饼状图";
                    }

                    chart1.Titles["Title1"].Text = TitlesTemp;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalamount += SysConvert.ToDecimal(dt.Rows[i]["Amount"]);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (totalamount != 0)
                        {
                            dr["Per"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["Amount"]) * 100 / totalamount, 2).ToString() + "%";
                        }
                    }

                    //设置Legend
                    chart1.Legends["Default"].Docking = LegendDocking.Right;
                    chart1.Legends["Default"].LegendStyle = LegendStyle.Column;
                    chart1.Legends["Default"].TableStyle = LegendTableStyle.Auto;
                    chart1.Legends["Default"].Alignment = StringAlignment.Center;
                    chart1.Legends["Default"].InsideChartArea = "";
                    //Chart1.Legends["Default"].Title = "订单类型饼状图";
                    chart1.Legends["Default"].TitleColor = Color.Black;
                    chart1.Legends["Default"].TitleAlignment = StringAlignment.Center;
                    chart1.Legends["Default"].TitleSeparator = LegendSeparatorType.Line;
                    chart1.Legends["Default"].TitleSeparatorColor = Color.Black;
                    chart1.Legends["Default"].AutoFitText = true;

                    //设置ChartAreas
                    chart1.ChartAreas["Area1"].Area3DStyle.Enable3D = true;

                    //设置Series1
                    chart1.Series["Series1"].Type = SeriesChartType.Pie;
                    chart1.Series["Series1"]["PieLabelStyle"] = "Outside";

                    string[] xValues = new string[dt.Rows.Count];
                    double[] yValues = new double[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        xValues[i] = SysConvert.ToString(dt.Rows[i]["VendorAttn"]);
                        yValues[i] = SysConvert.ToDouble(dt.Rows[i]["Amount"]);
                    }

                    chart1.Series["Series1"].Points.Clear();
                    chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart1.Series["Series1"].Points[i].Label = SysConvert.ToString(dt.Rows[i]["VendorAttn"]) + SysConvert.ToString(dt.Rows[i]["Per"]) + Environment.NewLine + SysConvert.ToString(dt.Rows[i]["Amount"]);

                        chart1.Series["Series1"].Points[i].LegendText = xValues[i].ToString();
                        chart1.Series["Series1"].Points[i].ToolTip = "客户: " + xValues[i].ToString() + "\n金额: " + yValues[i].ToString();
                    }


                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //zedGraphControl1.PrintDocument.PrintController.IsPreview = true ;
                //zedGraphControl1.PrintDocument.Print();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                e.Appearance.BackColor = Color.White;
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


        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }

        private void gridView4_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e != null)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e != null)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

        private void gridView6_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e != null)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

        private void gridView7_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e != null)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }



    }
}