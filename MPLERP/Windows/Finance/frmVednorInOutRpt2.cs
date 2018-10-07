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
using DevExpress.XtraGrid.Views.Base;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：客户往来帐报表
    /// 
    /// 
    /// fornlistAID=1 采购
    /// fornlistAID=2 加工
    /// fornlistAID=3 销售
    /// </summary>
    public partial class frmVednorInOutRpt2 : frmAPBaseUIRpt
    {
        public frmVednorInOutRpt2()
        {
            InitializeComponent();
        }
        private string VendorID = string.Empty;


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;

            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
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
            try
            {

                if (SysConvert.ToString(drpQVendorID.EditValue) == "")
                {
                    this.ShowMessage("请选择往来单位查询");
                    return;
                }

                decimal TotalQC = 0.0m;
                decimal QCAmount = 0.0m;//期初金额
                decimal SQSaleAmount = 0.0m;//销售金额
                decimal SQRecAmount = 0.0m;//收款金额
                decimal SQHKAmount = 0.0m;//期初货款处理

                string sql = "Select SUM(BAmount) QCAmount ";
                sql += " from Finance_BVendorAmount where 1=1";
                sql += HTDataConditionStr;

                DataTable dt3 = SysUtils.Fill(sql);
                if (dt3.Rows.Count != 0)
                {
                    QCAmount = SysConvert.ToDecimal(dt3.Rows[0]["QCAmount"]);
                }
                sql = "Select SUM(Amount) Amount";
                sql += " From UV1_WH_IOFormDts Where 1=1";
                if (FormListAID == 1)
                {
                    sql += " AND ISNULL(BuyFlag,0)=1";
                }
                if (FormListAID == 2)
                {
                    sql += " AND ISNULL(ColorFlag,0)=1";
                }
                if (FormListAID == 3)
                {
                    sql += " AND ISNULL(SaleFlag,0)=1";
                }
                sql += " AND ISNULL(SubmitFlag,0)=1";//已提交
                sql += HTDataConditionStr;
                if (chkINDate.Checked)
                {
                    sql += " AND formdate <" + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd"));
                }
                DataTable dt1 = SysUtils.Fill(sql);
                if (dt1.Rows.Count != 0)
                {
                    SQSaleAmount = SysConvert.ToDecimal(dt1.Rows[0]["Amount"]);
                }
                sql = "Select Sum(ExAmount) RecAmount";
                sql += " from Finance_RecPay where 1=1";
                sql += HTDataConditionStr;
                if (chkINDate.Checked)
                {
                    sql += " AND ExDate< " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd"));
                }
                DataTable dt2 = SysUtils.Fill(sql);
                if (dt2.Rows.Count != 0)
                {
                    SQRecAmount = SysConvert.ToDecimal(dt2.Rows[0]["RecAmount"]);
                }


                ///货款处理信息
                sql = " Select SUM(Amount) ExAmount";
                sql += " from Finance_PaymentHandle where 1=1";
                sql += HTDataConditionStr;
                if (chkINDate.Checked)
                {
                    sql += " AND FormDate< " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd"));
                }
                dt2 = SysUtils.Fill(sql);
                if (dt2.Rows.Count != 0)
                {
                    SQHKAmount = SysConvert.ToDecimal(dt2.Rows[0]["ExAmount"]);
                }


                TotalQC = QCAmount + SQSaleAmount - SQRecAmount + SQHKAmount;

                #region FormListAID ==1
                if (FormListAID == 1)
                {
                    sql = "Select ID,Seq,WHNM,FormDate,'采购' AS FormTypeName,ItemCode,ItemName,ItemStd,ItemModel,Unit,'' Remark,Qty,DZSinglePrice AS SinglePrice,";
                    //sql += " Amount= Case when ISNULL(DZAmount,0)=0 then Amount";
                    //sql += " When ISNULL(DZAmount,0)<>0 then DZAmount end";
                    sql += " DZAmount Amount";
                    sql += " ,0.0 RecAmount,0.0 InvoiceAmount,0.0 PaymentHandleAmount,0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";//对账金额
                    sql += " from UV1_WH_IOFOrmDts where 1=1";
                    sql += " AND ISNULL(BuyFlag,0)=1";
                    sql += " AND ISNULL(SubmitFlag,0)=1";//已提交
                    sql += " AND ISNULL(DZFlag,0)=1";//只查询对过帐的数据
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }

                    sql += " UNION";
                    sql += " Select ID,1 AS Seq,'' WHNM,ExDate ASFormDate,'付款' AS FormTypeName,'' ItemCode,'' ItemName,'' ItemStd,Remark AS ItemModel,'' Unit,";
                    sql += " '' Remark,0.0 Qty,0.0 SinglePrice,0.0 Amount,ExAmount,0.0 InvoiceAmount,0.0 PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";
                    sql += " from Finance_RecPay where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND ExDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }


                    sql += " UNION";
                    sql += " Select ID,1 AS Seq,'' WHNM,MakeDate AS FormDate,'开票' AS FormTypeName,InvoiceNo ItemCode,'' ItemName,'' ItemStd,'' ItemModel,'' Unit,";
                    sql += " '' Remark,0.0 Qty,0.0 SinglePrice,0.0 Amount,0.0 ExAmount,TotalAmount InvoiceAmount,0.0 PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";
                    sql += " from Finance_InvoiceOperation where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }



                    ///货款信息
                    sql += " UNION";
                    sql += " Select ID,1 AS Seq,'' WHNM, FormDate,'货款处理' AS FormTypeName,'' ItemCode,'' ItemName,'' ItemStd,'' ItemModel,'' Unit,";
                    sql += " '' Remark,0.0 Qty,0.0 SinglePrice,0.0 Amount,0.0 ExAmount,0.0 InvoiceAmount,Amount PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";
                    sql += " from Finance_PaymentHandle where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }

                    //sql += " Order BY FormDate";
                }
                #endregion
                #region FormListAID ==2
                if (FormListAID == 2)
                {
                    sql = "Select ID,Seq,WHNM,FormDate,'加工' AS FormTypeName,ItemCode,ItemName,ItemStd,ItemModel,Unit,'' Remark,Qty,DZSinglePrice AS SinglePrice,";
                    //sql += " Amount= Case when ISNULL(DZAmount,0)=0 then Amount";
                    //sql += " When ISNULL(DZAmount,0)<>0 then DZAmount end";
                    sql += " DZAmount Amount";

                    sql += " ,0.0 RecAmount,0.0 InvoiceAmount,0.0 PaymentHandleAmount,0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";//对账金额
                    sql += " from UV1_WH_IOFOrmDts where 1=1";
                    sql += " AND ISNULL(ColorFlag,0)=1";
                    sql += " AND ISNULL(SubmitFlag,0)=1";//已提交
                    sql += " AND ISNULL(DZFlag,0)=1";//只查询对过帐的数据
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }


                    sql += " UNION";
                    sql += " Select ID,1 AS Seq,'' WHNM,ExDate ASFormDate,'付款' AS FormTypeName,'' ItemCode,'' ItemName,'' ItemStd,Remark AS ItemModel,'' Unit,";
                    sql += " '' Remark,0.0 Qty,0.0 SinglePrice,0.0 Amount,ExAmount,0.0 InvoiceAmount,0.0 PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";
                    sql += " from Finance_RecPay where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND ExDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }


                    sql += " UNION";
                    sql += " Select ID,1 AS Seq,'' WHNM,MakeDate AS FormDate,'开票' AS FormTypeName,InvoiceNo ItemCode,'' ItemName,'' ItemStd,'' ItemModel,'' Unit,";
                    sql += " '' Remark,0.0 Qty,0.0 SinglePrice,0.0 Amount,0.0 ExAmount,TotalAmount InvoiceAmount,0.0 PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";
                    sql += " from Finance_InvoiceOperation where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }



                    ///货款信息
                    sql += " UNION";
                    sql += " Select ID,1 AS Seq,'' WHNM, FormDate,'货款处理' AS FormTypeName,'' ItemCode,'' ItemName,'' ItemStd,'' ItemModel,'' Unit,";
                    sql += " '' Remark,0.0 Qty,0.0 SinglePrice,0.0 Amount,0.0 ExAmount,0.0 InvoiceAmount,Amount PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2,0.0 LeftAmount3";
                    sql += " from Finance_PaymentHandle where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }

                    // sql += " Order BY FormDate";
                }
                #endregion
                #region FormListAID ==3
                if (FormListAID == 3)
                {
                    sql = "Select ColorNum, ID,Seq,WHNM,FormDate,";
                    sql += " FormTypeName= Case when FormDZFlag=1 then '销售'";
                    sql += " When FormDZFlag=2 then '退货'  end";
                    sql += " ,ItemCode,ItemName,ItemStd,ItemModel,Unit,";
                    sql += " '' Remark,";
                    sql += " SinglePrice,";
                    sql += "(CASE WHEN (Unit='RMB/KG' OR Unit='USD/KG') THEN ISNULL(Weight,0) ";
                    sql += " WHEN (Unit='RMB/M' OR Unit='USD/M') THEN ISNULL(Qty,0) ";
                    sql += " WHEN (Unit='RMB/Y' OR Unit='USD/Y') THEN ISNULL(Yard,0) ELSE ISNULL(Qty,0) END ) Qty,";
                    sql += " Amount= Case When FormDZFlag=1 AND  ISNULL(Amount,0)<>0  then Amount";
                    sql += " When FormDZFlag=2 AND  ISNULL(Amount,0)<>0 then 0-Amount  ";
                    sql += " end";
                    sql += " ,0.0 RecAmount,0.0 PaymentHandleAmount,0.0 LeftAmount1,0.0 LeftAmount2";
                    sql += " from UV1_WH_IOFOrmDts where 1=1";
                    sql += " AND ISNULL(SaleFlag,0)=1";
                    sql += " AND ISNULL(SubmitFlag,0)=1";//已提交
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }
                    sql += " UNION";
                    sql += " Select '' ColorNum, ID,1 AS Seq,'' WHNM,ExDate AS FormDate,'收款' AS FormTypeName,FormNo ItemCode,'' ItemName,'' ItemStd,ExBank ItemModel,'' Unit,";
                    sql += " Remark Remark,0.0 SinglePrice,0.0 Qty,0.0 Amount,ExAmount RecAmount,0.0 PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2";
                    sql += " FROM Finance_RecPay where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND ExDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }
                    ///货款信息
                    sql += " UNION";
                    sql += " Select '' ColorNum,ID,1 AS Seq,'' WHNM, FormDate,'货款处理' AS FormTypeName,FormNo ItemCode,'' ItemName,'' ItemStd,'' ItemModel,'' Unit,";
                    sql += " Remark Remark,0.0 SinglePrice,0.0 Qty,0.0 Amount,0.0 RecAmount,Amount PaymentHandleAmount,";
                    sql += " 0.0 LeftAmount1,0.0 LeftAmount2";
                    sql += " from Finance_PaymentHandle where 1=1";
                    sql += HTDataConditionStr;
                    if (chkINDate.Checked)
                    {
                        sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                    }
                    //sql += " Order BY FormDate";
                }
                #endregion

                DataTable dt = SysUtils.Fill(sql);

                DataRow dr = dt.NewRow();
                if (TotalQC >= 0)
                {
                    dr["LeftAmount1"] = TotalQC;
                }
                else
                {
                    dr["LeftAmount2"] = 0 - TotalQC;
                }
                dr["FormTypeName"] = "期初余额";
                dr["FormDate"] = txtQIndateS.DateTime.Date.AddDays(-1);
                dr["ID"] = "-1";
                dr["Seq"] = "-1";
                dt.Rows.Add(dr);


                //dt.DefaultView.Sort = " FormDate ASC";




                DataRow[] rows = dt.Select("", "FormDate asc");

                DataTable t = dt.Clone();

                t.Clear();

                foreach (DataRow row in rows)

                    t.ImportRow(row);

                dt = t;





                ProductAmount(dt);

                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();


                gridView1.OptionsCustomization.AllowFilter = false;
                gridView1.OptionsCustomization.AllowSort = false;

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void ProductAmount(DataTable p_Dt)
        {
            decimal LeftAmount = 0.0m;
            foreach (DataRow dr in p_Dt.Rows)
            {
                LeftAmount = LeftAmount + SysConvert.ToDecimal(dr["LeftAmount1"]) - SysConvert.ToDecimal(dr["LeftAmount2"]) + SysConvert.ToDecimal(dr["Amount"]) - SysConvert.ToDecimal(dr["RecAmount"]) + SysConvert.ToDecimal(dr["PaymentHandleAmount"]);
                if (LeftAmount >= 0)
                {
                    dr["LeftAmount1"] = LeftAmount;
                }
                else
                {
                    dr["LeftAmount2"] = 0 - LeftAmount;
                }
            }
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "CaiWu_CWPay";
            this.HTDataList = gridView1;

            txtQIndateS.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtQIndateE.DateTime = DateTime.Now.Date;


            //drpQVendorID_EditValueChanged(null, null);


            //Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.染厂, (int)EnumVendorType.加工户, (int)EnumVendorType.织厂, (int)EnumVendorType.客户, (int)EnumVendorType.全部 }, true);//客户

            DevMethod.BindVendorByDZTypeID(drpQVendorID, this.FormListAID, true);
            //new VendorProc(drpQVendorID);

            btnPrintVisible = true;


            //IsPostBack = false;

        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CWPay EntityGet()
        {
            CWPay entity = new CWPay();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion



        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 颜色变化 方法重载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "FormTypeName")
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "FormTypeName")) == "货款处理")
                    {
                        e.Appearance.BackColor = Color.Red;

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 打印组件事件
        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }

                DataTable dtMain = new DataTable();
                dtMain.TableName = "Main";

                dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
                dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
                dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));
                dtMain.Columns.Add(new DataColumn("QCJF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QCDF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QMJF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QMDF", typeof(decimal)));

                DataRow dr = dtMain.NewRow();
                dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
                dr["DataTime1"] = txtQIndateS.DateTime.Date;
                dr["DataTime2"] = txtQIndateE.DateTime.Date;
                DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
                dtDetail.TableName = "Detail";
                dr["QCJF"] = SysConvert.ToDecimal(dtDetail.Rows[0]["LeftAmount1"]);
                dr["QCDF"] = SysConvert.ToDecimal(dtDetail.Rows[0]["LeftAmount2"]);
                dr["QMJF"] = SysConvert.ToDecimal(dtDetail.Rows[dtDetail.Rows.Count - 1]["LeftAmount1"]);
                dr["QMDF"] = SysConvert.ToDecimal(dtDetail.Rows[dtDetail.Rows.Count - 1]["LeftAmount2"]);
                dtMain.Rows.Add(dr);
                HttSoft.WinUIBase.FastReport.ReportRunTable2(tempReportID, (int)ReportPrintType.设计, dtMain, dtDetail);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }

                DataTable dtMain = new DataTable();
                dtMain.TableName = "Main";

                dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
                dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
                dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));
                dtMain.Columns.Add(new DataColumn("QCJF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QCDF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QMJF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QMDF", typeof(decimal)));

                DataRow dr = dtMain.NewRow();
                dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
                dr["DataTime1"] = txtQIndateS.DateTime.Date;
                dr["DataTime2"] = txtQIndateE.DateTime.Date;
                DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
                dtDetail.TableName = "Detail";
                dr["QCJF"] = SysConvert.ToDecimal(dtDetail.Rows[0]["LeftAmount1"]);
                dr["QCDF"] = SysConvert.ToDecimal(dtDetail.Rows[0]["LeftAmount2"]);
                dr["QMJF"] = SysConvert.ToDecimal(dtDetail.Rows[dtDetail.Rows.Count - 1]["LeftAmount1"]);
                dr["QMDF"] = SysConvert.ToDecimal(dtDetail.Rows[dtDetail.Rows.Count - 1]["LeftAmount2"]);
                dtMain.Rows.Add(dr);
                HttSoft.WinUIBase.FastReport.ReportRunTable2(tempReportID, (int)ReportPrintType.预览, dtMain, dtDetail);
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
                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }

                DataTable dtMain = new DataTable();
                dtMain.TableName = "Main";
                dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
                dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
                dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));
                dtMain.Columns.Add(new DataColumn("QCJF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QCDF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QMJF", typeof(decimal)));
                dtMain.Columns.Add(new DataColumn("QMDF", typeof(decimal)));

                DataRow dr = dtMain.NewRow();
                dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
                dr["DataTime1"] = txtQIndateS.DateTime.Date;
                dr["DataTime2"] = txtQIndateE.DateTime.Date;
                DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
                dtDetail.TableName = "Detail";
                dr["QCJF"] = SysConvert.ToDecimal(dtDetail.Rows[0]["LeftAmount1"]);
                dr["QCDF"] = SysConvert.ToDecimal(dtDetail.Rows[0]["LeftAmount2"]);
                dr["QMJF"] = SysConvert.ToDecimal(dtDetail.Rows[dtDetail.Rows.Count - 1]["LeftAmount1"]);
                dr["QMDF"] = SysConvert.ToDecimal(dtDetail.Rows[dtDetail.Rows.Count - 1]["LeftAmount2"]);
                dtMain.Rows.Add(dr);
                HttSoft.WinUIBase.FastReport.ReportRunTable2(tempReportID, (int)ReportPrintType.打印, dtMain, dtDetail);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        //#region 打印组件事件

        ///// <summary>
        ///// 绑定报表名称
        ///// </summary>
        //public virtual void BindReport(DevComponents.DotNetBar.ComboBoxItem p_DrpID)
        //{
        //    if (FormID != 0)
        //    {
        //        string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where ";//WinListID = " +  FormID.ToString() + "

        //        sql += " WinID=" + this.FormID;
        //        sql += " AND HeadTypeID=" + this.FormListAID;
        //        sql += " AND SubTypeID=" + this.FormListBID;
        //        sql += " ORDER BY Seq";
        //        DataTable dt = SysUtils.Fill(sql);
        //        FCommon.LoadDropDNBarComb(p_DrpID, dt, "ID", "ReportName", true);
        //        if (dt.Rows.Count > 0)
        //        {
        //            p_DrpID.SelectedIndex = 1;
        //        }
        //    }
        //}


        ///// <summary>
        ///// 设计
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDesign_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }

        //        DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //        if (ci.SelectedItem == null)
        //        {
        //            this.ShowMessage("请选择报表模板");
        //            return;
        //        }
        //        int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //        if (tempReportID == 0)
        //        {
        //            this.ShowMessage("请选择报表模板");
        //            return;
        //        }

        //        if (tempReportID == 125)//固定报表格式
        //        {


        //            DataTable dtMain = new DataTable();
        //            dtMain.TableName = "Main";

        //            dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
        //            dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
        //            dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));

        //            DataRow dr = dtMain.NewRow();
        //            dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
        //            dr["DataTime1"] = txtQIndateS.DateTime.Date;
        //            dr["DataTime2"] = txtQIndateE.DateTime.Date;
        //            dtMain.Rows.Add(dr);

        //            DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
        //            dtDetail.TableName = "Detail";

        //            //FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.设计, new DataTable[] { dtMain, dtDetail });
        //        }
        //        else
        //        {
        //            //FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
        //        }


        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// 预览
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPreview_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }

        //        DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //        if (ci.SelectedItem == null)
        //        {
        //            this.ShowMessage("请选择报表模板");
        //            return;
        //        }
        //        int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //        if (tempReportID == 0)
        //        {
        //            this.ShowMessage("请选择报表模板");
        //            return;
        //        }

        //        if (tempReportID == 125)//固定报表格式
        //        {


        //            DataTable dtMain = new DataTable();
        //            dtMain.TableName = "Main";

        //            dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
        //            dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
        //            dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));

        //            DataRow dr = dtMain.NewRow();
        //            dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
        //            dr["DataTime1"] = txtQIndateS.DateTime.Date;
        //            dr["DataTime2"] = txtQIndateE.DateTime.Date;
        //            dtMain.Rows.Add(dr);

        //            DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
        //            dtDetail.TableName = "Detail";

        //            //FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.预览, new DataTable[] { dtMain, dtDetail });
        //        }
        //        else
        //        {
        //            //FastReport.ReportRun(tempReportID, (int)ReportPrintType.预览, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// 打印
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }

        //        DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //        if (ci.SelectedItem == null)
        //        {
        //            this.ShowMessage("请选择报表模板");
        //            return;
        //        }
        //        int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //        if (tempReportID == 0)
        //        {
        //            this.ShowMessage("请选择报表模板");
        //            return;
        //        }


        //        if (tempReportID == 125)//固定报表格式
        //        {


        //            DataTable dtMain = new DataTable();
        //            dtMain.TableName = "Main";

        //            dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
        //            dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
        //            dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));

        //            DataRow dr = dtMain.NewRow();
        //            dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
        //            dr["DataTime1"] = txtQIndateS.DateTime.Date;
        //            dr["DataTime2"] = txtQIndateE.DateTime.Date;
        //            dtMain.Rows.Add(dr);

        //            DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
        //            dtDetail.TableName = "Detail";

        //            //FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.打印, new DataTable[] { dtMain, dtDetail });
        //        }
        //        else
        //        {
        //            //FastReport.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
        //        }
        //    }
        //    catch (Exception E)
        //    {//#endregion
        //        this.ShowMessage(E.Message);
        //    }
        //}
        

    }
}