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
    /// ���ܣ���Ʒ����
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmGBJCDtsRpt : frmAPBaseUIRpt
    {
        public frmGBJCDtsRpt()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]

        /// <summary>
        /// ��ѯ����
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
        /// ��Grid1
        /// </summary>
        public void BindGrid1()
        {
            GBJCDtsRule rule = new GBJCDtsRule();
            DataTable dtt=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();

        }
        /// <summary>
        /// ��Grid3
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
        /// ��Grid4
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
        /// ��Grid2
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
        /// �������б�
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
                dr["Qty" + i] = SysConvert.ToString(SysConvert.ToInt32(dts.Rows[i - 1]["Amount"].ToString())) + " ��";
            }
            dt.Rows.Add(dr);
            gridView5.GridControl.DataSource = dt;
            gridView5.GridControl.Show();
        }

        /// <summary>
        /// �������б�
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
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            btnQuery_Click(null, null);
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI

            ProcessGrid.BindGridColumn(gridView2, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView2, FormListAID, FormListBID);//������UI

            ProcessGrid.BindGridColumn(gridView3, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView3, FormListAID, FormListBID);//������UI

            ProcessGrid.BindGridColumn(gridView4, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView4, FormListAID, FormListBID);//������UI

            ProcessGrid.BindGridColumn(gridView6, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView6, FormListAID, FormListBID);//������UI
            txtQJCTimeS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQJCTimeE.DateTime = DateTime.Now.Date;
            txtQGHTimeS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQGHTimeE.DateTime = DateTime.Now.Date;
            Common.BindYear(drpCheckYear, 3, 1, false);
            drpCheckYear.Text = DateTime.Now.Year.ToString();
            Common.BindOP(drpSaleOPID, true);
            this.HTDataTableName = "UV2_Dev_GBJCDts";
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);//�ͻ�
            new VendorProc(drpQVendorID);
            Common.BindGBStatus(drpQGBStatusID, true);
            btnQuery_Click(null, null);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Item EntityGet()
        {
            Item entity = new Item();
            entity.ID = HTDataID;
            return entity;
        }



        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #endregion

        #region ������ɫ������
        /// <summary>
        /// ������ɫ������
        /// </summary>
        public class SericsColorProc
        {
            private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
            public static bool ColorIniFlag
            {
                get
                {
                    if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
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
            /// ��ʼ����ɫ
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
                    if (tempstr.Length == 3)//����Ϊ3
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
            /// �����ɫ
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
                        if (tempstr.Length == 3)//����Ϊ3
                        {
                            p_Color = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                        }
                    }
                }
                return p_Color;
            }
        }
        #endregion

        #region ���ط���
        /// <summary>
        /// ��ѯ
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

        #region ͼ�α���
        /// <summary>
        /// ÿ�½��������
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
                    Chart5.Titles["Title1"].Text = drpCheckYear.Text.Trim() + "ÿ�½����ͼ�α���";
                    //����X��
                    Chart5.ChartAreas["Chart Area 1"].Area3DStyle.Enable3D = false;//2DЧ��
                    Chart5.ChartAreas["Chart Area 1"].AxisX.Title = "�·�";
                    Chart5.ChartAreas["Chart Area 1"].AxisX.TitleAlignment = StringAlignment.Far;//����X��������������λ��λԶ
                    Chart5.ChartAreas["Chart Area 1"].AxisX.Interval = 0;//����X����ʾ���Ϊ2,����X�����ݱȽ϶��ʱ��Ƚ�����
                    Chart5.ChartAreas["Chart Area 1"].AxisX.View.Zoomable = true;
                    Chart5.ChartAreas["Chart Area 1"].AxisY.View.Zoomable = true;
                    Chart5.ChartAreas["Chart Area 1"].CursorX.AutoScroll = false;
                    Chart5.ChartAreas["Chart Area 1"].CursorY.AutoScroll = false;
                    Chart5.ChartAreas["Chart Area 1"].AxisX.LabelStyle.ShowEndLabels = true;//ȥ��X����β��ǩ
                    Chart5.ChartAreas["Chart Area 1"].AxisX.ScrollBar.PositionInside = true;
                    Chart5.ChartAreas["Chart Area 1"].AxisX.Margin = true;
                    //����Y��
                    Chart5.ChartAreas["Chart Area 1"].AxisY.Title = "�����";
                    Chart5.ChartAreas["Chart Area 1"].AxisY.TitleAlignment = StringAlignment.Far;//����Y��������������λ��λԶ

                    //���ԭ��Series
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
                        Chart5.Series["Series2"].Points[i].AxisLabel = SysConvert.ToString(dt.Rows[i]["MonthInt"].ToString()) + "��";
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        #endregion

        #region ������
        /// <summary>
        /// �õ���������Դ
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
        /// ������Դ2
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
        /// ������Դ4
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

        #region ���ٲ�ѯ
        /// <summary>
        /// ���ٲ�ѯ
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

        #region ��ӡ

        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
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
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                // base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.Ԥ��);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                //base.btnPrint_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.��ӡ);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.���);
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
                FCommon.AddDBLog(this.Text, "�����б�", "", "");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



    }
}