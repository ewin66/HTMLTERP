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
using DevExpress.XtraEditors.Controls;
using System.Collections;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Base;

namespace MLTERP
{
    /// <summary>
    /// 功能：报关装箱发票
    /// </summary>
    public partial class frmCustomEdit : frmAPBaseUIFormEdit
    {
        public frmCustomEdit()
        {
            InitializeComponent();
        }

        #region 全局变量

        DataTable dtReports = new DataTable();
        DataTable dtPackDts = new DataTable();
        DataTable dtInvoiceDts = new DataTable();
        DataTable dtInvoice = new DataTable();
        #endregion

        #region 自定义虚方法定义[需要修改]

        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            if (!this.CheckCorrectDts(gridView3, gridView3CheckField))
            {
                return false;
            }

            //if (!this.CheckCorrectDts(gridView2, gridView2CheckField))
            //{
            //    return false;
            //}
            if (!this.CheckCorrectDts(gridView5, gridView5CheckField))
            {
                return false;
            }


            return true;
        }

        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            CustomDtsRule rule = new CustomDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();

            CustomPackDtsRule Packrule = new CustomPackDtsRule();
            DataTable dtPackDts = Packrule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));

            gridView2.GridControl.DataSource = dtPackDts;
            gridView2.GridControl.Show();


        }
        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public void BindInvoice()
        {
            CustomInvoiceDtsRule Invoicerule = new CustomInvoiceDtsRule();
            DataTable dtInvoice = Invoicerule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView5));

            gridView5.GridControl.DataSource = dtInvoice;
            gridView5.GridControl.Show();
            //Common.AddDtRow(dtInvoice, 100);
        }
        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            this.TableHeadControlSetValue();

            CustomRule rule = new CustomRule();
            Custom entity = EntityGet();
            CustomDts[] entitydts = EntityDtsGet();//合并GridView5
            CustomPackDts[] entitypackdts = EntityPackDtsGet();//无用
            CustomReportDts[] entityReportdts = EntityReportDtsGet();//无用
            CustomInvoiceDts[] entityInvoicedts = EntityInvoiceDtsGet();//GridView5 OK 


            decimal PieceQty = 0;
            decimal NetWeight = 0;
            decimal GrossWeight = 0;
            decimal Volume = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                PieceQty += entitydts[i].PieceQty;//件数
                NetWeight += entitydts[i].NetWeight;//净重
                GrossWeight += entitydts[i].GrossWeight;//毛重
                Volume += entitydts[i].Volume;//体积
            }
            entity.TotalCtnQty = SysConvert.ToDecimal(PieceQty,2);
            entity.TotalBulk = SysConvert.ToDecimal(Volume, 2);
            entity.TotalNetWeight = SysConvert.ToDecimal(NetWeight, 2);
            entity.TotalCrossWeight = SysConvert.ToDecimal(GrossWeight, 2);
            //SetEntityQty(entity, entitydts, entitypackdts, entityInvoicedts);
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts, entitypackdts, entityReportdts, entityInvoicedts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            this.TableHeadControlSetValue();
            CustomRule rule = new CustomRule();
            Custom entity = EntityGet();
            CustomDts[] entitydts = EntityDtsGet();
            CustomPackDts[] entitypackdts = EntityPackDtsGet();
            CustomReportDts[] entityReportdts = EntityReportDtsGet();
            CustomInvoiceDts[] entityInvoicedts = EntityInvoiceDtsGet();

            decimal PieceQty = 0;
            decimal NetWeight = 0;
            decimal GrossWeight = 0;
            decimal Volume = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                PieceQty += entitydts[i].PieceQty;
                NetWeight += entitydts[i].NetWeight;
                GrossWeight += entitydts[i].GrossWeight;
                Volume += entitydts[i].Volume;
            }
            entity.TotalCtnQty = SysConvert.ToDecimal(PieceQty,2);
            entity.TotalBulk = SysConvert.ToDecimal(Volume, 2);
            entity.TotalNetWeight = SysConvert.ToDecimal(NetWeight, 2);
            entity.TotalCrossWeight = SysConvert.ToDecimal(GrossWeight, 2);
            //SetEntityQty(entity, entitydts, entitypackdts, entityInvoicedts);
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entitypackdts, entityReportdts, entityInvoicedts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Custom entity = new Custom();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            txtSO.Text = entity.SO.ToString();
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtInvoiceDate.DateTime = entity.InvoiceDate;
            txtShipDate.DateTime = entity.ShipDate;
            txtInvoiceNo.Text = entity.InvoiceNo.ToString();
            txtMessrs.Text = entity.Messrs.ToString();
            drpShipMethod.EditValue = entity.ShipMethod.ToString();
            drpShipFrom.EditValue = entity.ShipFrom.ToString();
            drpShipTo.EditValue = entity.ShipTo.ToString();
            txtMidChange.Text = entity.MidChange.ToString();
            txtContractNo.Text = entity.ContractNo.ToString();
            txtLCNO.Text = entity.LCNO.ToString();
            txtSCNo.Text = entity.SCNo.ToString();
            txtSaleNo.Text = entity.SaleNo.ToString();
            txtMarkNo.Text = entity.MarkNo.ToString();
            txtDescription.Text = entity.Description.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            drpCurrency.EditValue = entity.Currency.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtTotalCtnQty.Text = entity.TotalCtnQty.ToString();
            txtTotalCrossWeight.Text = entity.TotalCrossWeight.ToString();
            txtTotalNetWeight.Text = entity.TotalNetWeight.ToString();
            txtTotalBulk.Text = entity.TotalBulk.ToString();
            txtIssueBank.Text = entity.IssueBank.ToString();
            txtMakeOPID.Text = Common.GetNameByOPID(entity.MakeOPID.ToString());
            txtAuditTime.DateTime = entity.AuditTime;
            txtLastUpdTime.DateTime = entity.LastUpdTime;
            txtLastUpdOPID.Text = entity.LastUpdOPID.ToString();
            txtRate.Text = entity.Rate.ToString();
            txtZFormNo.Text = entity.ZFormNo.Trim();//20150617
            drpGainType.EditValue = entity.GainType.ToString();
            drpTradeType.EditValue = entity.TradeType.ToString();

            //txtHSCode.Text = entity.HSCode.ToString();
            //txtCustomFee.Text = entity.CustomFee.ToString();
            //txtOthFee.Text = entity.OthFee.ToString();
            txtBANo.Text = entity.BANo.ToString();
            txtYSFS.Text = entity.YSFS.ToString();
            drpZMXZ.EditValue = entity.ZMXZ.ToString();
            txtXKNo.Text = entity.XKNo.ToString();
            txtPZNo.Text = entity.PZNo.ToString();


            txtYAmount.Text = entity.YAmount.ToString();
            txtYPercent.Text = entity.YPercent.ToString();
            txtSAmount.Text = entity.SAmount.ToString();

            //txtHTNo.Text = entity.HTNo.ToString();

            drpToAddr.EditValue = SysConvert.ToString(entity.TOADDR);//ToADDR 卸货地
            drpFromAddr.EditValue = SysConvert.ToString(entity.FROMADDR);//FROMADDR 发货点
            drpYDCountry.EditValue = SysConvert.ToString(entity.HSCode);//运抵国
            drpJNHY.EditValue = SysConvert.ToString(entity.SCNo);//境内货源地
            txtSBDate.DateTime = entity.SBDate;
            txtBGDate.DateTime = entity.BGDate;
            drpBZZL.EditValue = entity.BZZL.ToString();
            drpJHFS.EditValue = entity.JHFS.ToString();
            if (txtInvoiceDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtInvoiceDate.Text = "";
            }
            if (txtBGDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtBGDate.Text = "";
            }
            if (txtShipDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtShipDate.Text = "";
            }
            txtTranFee.Text = entity.TranFee.ToString();
            txtProFee.Text = entity.ProFee.ToString();
            txtOtherFee.Text = entity.OtherFee.ToString();

            HTDataSubmitFlag = entity.SubmitFlag;

            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
                txtMakeOPID.Text = FParamConfig.LoginName;
            }

            string sql = string.Empty;
            //    sql = "SELECT * FROM Ship_CustomReportDts WHERE 1=1 AND MainID=" + HTDataID;
            //dtReports = SysUtils.Fill(sql);

            //sql = "SELECT * FROM Ship_CustomPackDts WHERE 1=1 AND MainID=" + HTDataID;
            //dtPackDts = SysUtils.Fill(sql);

            sql = "SELECT * FROM Ship_CustomDts WHERE 1=1 AND MainID=" + HTDataID;
            dtInvoiceDts = SysUtils.Fill(sql);

            sql = "SELECT * FROM Ship_CustomInvoiceDts WHERE 1=1 AND MainID=" + HTDataID;
            dtInvoice = SysUtils.Fill(sql);
            BindInvoice();
            //BindGridReport();
            BindGridInvoice();
            //BindGridPack();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CustomRule rule = new CustomRule();
            Custom entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

         //   ProcessCtl.ProcControlEdit(new Control[] { txtMakeOPID, txtInvoiceDate, txtTotalCtnQty, txtTotalAmount, txtTotalBulk, txtTotalNetWeight, txtTotalQty, txtTotalCrossWeight }, false);

        }

        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtInvoiceDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtShipDate.DateTime = DateTime.Now.Date;
            txtSBDate.DateTime = DateTime.Now.Date;
            txtYPercent.Text = "0.02";
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Ship_Custom";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3, gridView5, gridView1, gridView4 };
            this.HTCheckDataField = new string[] { "Qty" };//数据明细校验必须录入字段,"Style"

            DevMethod.BindCountry(drpYDCountry);
            Common.BindCompanyType(drpCompanyTypeID, false);


            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);

            //Common.BindCLS(drpGainType, "Ship_ShipBoat", "GainType", true);//成交方式
            //Common.BindCLS(drpTradeType, "Ship_ShipBoat", "TradeType", true);//贸易方式
            //Common.BindCLS(drpShipMethod, "Ship_ShipBoat", "TransType", true);//运输方式
            //Common.BindCLS(drpShipFrom, "Ship_ShipBoat", "PortLoading", true);//出运港
            //Common.BindCLS(drpShipTo, "Ship_ShipBoat", "ShipTo", true);//指运港
            //Common.BindCLS(drpFromAddr, "Ship_ShipBoat", "FromOPName", true);//from
            //Common.BindCLS(drpToAddr, "Ship_ShipBoat", "TOOPName", true);//to
            //Common.BindCLS(drpCurrency, "Ship_Custom", "Currency", true);//币别
            //Common.BindCLS(drpJNHY, this.HTDataTableName, "SCNo", true);//征免性质
            //Common.BindCLS(drpJHFS, this.HTDataTableName, "JHFS", true);//结汇方式
            //Common.BindCLS(drpBZZL, this.HTDataTableName, "BZZL", true);//包装种类

          
            //this.ToolBarItemAdd(28, "btnCheckLoad", "加载", false, btnCheckLoad_Click);

            DevMethod.BindRCountry(drpRCountry);


            //this.ToolBarItemAdd(30, "btnGenerateRpt", "生成报关单", false, btnGenerateRpt_Click);


            SetTabIndex(0, groupControlMainten);




        }

        string[] gridView2CheckField = new string[] { };//GridView2校验必须录入的字段列、"CtnNo",

        string[] gridView3CheckField = new string[] { };//GridView3校验必须录入的字段列

        string[] gridView5CheckField = new string[] { "Qty" };//GridView5校验必须录入的字段列

        #endregion

        #region 自定义方法

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Custom EntityGet()
        {
            Custom entity = new Custom();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.SO = txtSO.Text.Trim();
            if (txtInvoiceDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtInvoiceDate.Text != "")
            {
                entity.InvoiceDate = Common.GetWorkDays(txtInvoiceDate.DateTime.Date);
            }

            if (txtShipDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtShipDate.Text != "")
            {
                entity.ShipDate = Common.GetWorkDays(txtShipDate.DateTime.Date);
            }

            if (txtBGDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtBGDate.Text != "")
            {
                entity.BGDate = Common.GetWorkDays(txtBGDate.DateTime.Date);
            }
            if (txtSBDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtSBDate.Text != "")
            {
                entity.SBDate = Common.GetWorkDays(txtSBDate.DateTime.Date);
            }
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Messrs = txtMessrs.Text.Trim();
            entity.ShipMethod = drpShipMethod.EditValue.ToString();
            entity.ShipFrom = SysConvert.ToString(drpShipFrom.EditValue);
            entity.ShipTo = SysConvert.ToString(drpShipTo.EditValue);
            entity.MidChange = txtMidChange.Text.Trim();
            entity.ContractNo = txtContractNo.Text.Trim();
            entity.LCNO = txtLCNO.Text.Trim();
            entity.SCNo = txtSCNo.Text.Trim();
            entity.SaleNo = txtSaleNo.Text.Trim();
            entity.MarkNo = txtMarkNo.Text.Trim();
            entity.Description = txtDescription.Text.Trim();
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Currency = drpCurrency.EditValue.ToString();
            entity.Remark = txtRemark.Text.Trim();
            entity.TotalCtnQty = SysConvert.ToDecimal(txtTotalCtnQty.Text.Trim());
            entity.TotalCrossWeight = SysConvert.ToDecimal(txtTotalCrossWeight.Text.Trim());
            entity.TotalNetWeight = SysConvert.ToDecimal(txtTotalNetWeight.Text.Trim());
            entity.TotalBulk = SysConvert.ToDecimal(txtTotalBulk.Text.Trim());
            entity.IssueBank = txtIssueBank.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.AuditTime = Common.GetWorkDays(txtAuditTime.DateTime.Date);
            entity.LastUpdTime = Common.GetWorkDays(txtLastUpdTime.DateTime.Date);
            entity.LastUpdOPID = txtLastUpdOPID.Text.Trim();
            entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            entity.TradeType = SysConvert.ToString(drpTradeType.EditValue);
            entity.GainType = SysConvert.ToString(drpGainType.EditValue);
            entity.JHFS = SysConvert.ToString(drpJHFS.EditValue);
            entity.BZZL = SysConvert.ToString(drpBZZL.EditValue);
            entity.CompanyTypeID = this.FormListAID;
            entity.TOADDR = SysConvert.ToString(drpToAddr.EditValue);//ToADDR 卸货地
            entity.FROMADDR = SysConvert.ToString(drpFromAddr.EditValue);//FROMADDR 发货点
            entity.HSCode = SysConvert.ToString(drpYDCountry.EditValue);//运抵国
            entity.SCNo = SysConvert.ToString(drpJNHY.EditValue);//运抵国

            entity.YAmount = SysConvert.ToDecimal(txtYAmount.Text.Trim());
            entity.YPercent = SysConvert.ToDecimal(txtYPercent.Text.Trim());
            entity.SAmount = entity.TotalAmount - entity.YAmount;

            entity.BANo = txtBANo.Text.Trim();
            entity.ZMXZ = SysConvert.ToString(drpZMXZ.EditValue);
            entity.XKNo = txtXKNo.Text.Trim();
            entity.PZNo = txtPZNo.Text.Trim();
            entity.ZFormNo = txtZFormNo.Text.Trim();//20150617
            //entity.HTNo = txtHTNo.Text.Trim();//装箱单号
            entity.YSFS = txtYSFS.Text.Trim();
            //entity.CustomFee = SysConvert.ToDecimal(txtCustomFee.Text.Trim());

            //entity.OthFee = SysConvert.ToDecimal(txtOthFee.Text.Trim());
            entity.HSCode = txtHSCode.Text.Trim();//编码
            entity.TranFee = SysConvert.ToDecimal(txtTranFee.Text.Trim());
            entity.ProFee = SysConvert.ToDecimal(txtProFee.Text.Trim());
            entity.OtherFee = SysConvert.ToDecimal(txtOtherFee.Text.Trim());
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CustomDts[] EntityDtsGet()//合并(qiuchao,2015.7.23修改)
        {

            int index = GetDataCompleteNum();
            CustomDts[] entitydts = new CustomDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CustomDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();


                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].Style = SysConvert.ToString(gridView1.GetRowCellValue(i, "Style"));
                    entitydts[index].DSN = SysConvert.ToString(gridView1.GetRowCellValue(i, "DSN"));
                    entitydts[index].SSN = SysConvert.ToString(gridView1.GetRowCellValue(i, "SSN"));
                    entitydts[index].SStyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "SStyleNo"));
                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));
                    entitydts[index].Model = SysConvert.ToString(gridView1.GetRowCellValue(i, "Model"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].AmountUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "AmountUnit"));
                    entitydts[index].PCSUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "PCSUnit"));

                    entitydts[index].PackPlanCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "PackPlanCode"));
                    entitydts[index].PackPlanID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PackPlanID"));
                    entitydts[index].QGSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "QGSinglePrice"));
                    entitydts[index].QGAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "QGAmount"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].QGQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "QGQty"));
                    entitydts[index].PieceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Volume = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Volume"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].GrossWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "GrossWeight"));
                    entitydts[index].NetWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "NetWeight"));

                    index++;
                }
            }
            return entitydts;
        }
        private CustomInvoiceDts[] EntityInvoiceDtsGet()//分开(qiuchao,2015.7.23修改)
        {

            int index = GetDataCompleteNum(gridView5, gridView5CheckField);
            CustomInvoiceDts[] entitydts = new CustomInvoiceDts[index];
            index = 0;
            for (int i = 0; i < gridView5.RowCount; i++)
            {
                if (CheckDataCompleteDts(gridView5, gridView5CheckField, i))
                {
                    entitydts[index] = new CustomInvoiceDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].ItemCode = SysConvert.ToString(gridView5.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView5.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView5.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].Style = SysConvert.ToString(gridView5.GetRowCellValue(i, "Style"));
                    entitydts[index].DSN = SysConvert.ToString(gridView5.GetRowCellValue(i, "DSN"));
                    entitydts[index].SSN = SysConvert.ToString(gridView5.GetRowCellValue(i, "SSN"));
                    entitydts[index].SStyleNo = SysConvert.ToString(gridView5.GetRowCellValue(i, "SStyleNo"));
                    entitydts[index].StyleNo = SysConvert.ToString(gridView5.GetRowCellValue(i, "StyleNo"));
                    entitydts[index].Model = SysConvert.ToString(gridView5.GetRowCellValue(i, "Model"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Qty"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Amount"));
                    entitydts[index].Unit = SysConvert.ToString(gridView5.GetRowCellValue(i, "Unit"));
                    entitydts[index].AmountUnit = SysConvert.ToString(gridView5.GetRowCellValue(i, "AmountUnit"));
                    entitydts[index].PCSUnit = SysConvert.ToString(gridView5.GetRowCellValue(i, "PCSUnit"));

                    entitydts[index].PackPlanCode = SysConvert.ToString(gridView5.GetRowCellValue(i, "PackPlanCode"));
                    entitydts[index].PackPlanID = SysConvert.ToInt32(gridView5.GetRowCellValue(i, "PackPlanID"));
                    entitydts[index].QGSinglePrice = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGSinglePrice"));
                    entitydts[index].QGAmount = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGAmount"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView5.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].QGQty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGQty"));
                    entitydts[index].PieceQty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Volume = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Volume"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "MWeight"));
                    entitydts[index].GrossWeight = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "GrossWeight"));
                    entitydts[index].NetWeight = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "NetWeight"));
                    index++;
                }
            }
            return entitydts;
        }
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CustomPackDts[] EntityPackDtsGet()//客户发票，箱单(qiuchao,2015.7.23修改)
        {

            int index = GetDataCompleteNum(gridView2, gridView2CheckField);
            CustomPackDts[] entitydts = new CustomPackDts[index];
            index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (CheckDataCompleteDts(gridView2, gridView2CheckField, i))
                {
                    entitydts[index] = new CustomPackDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].Style = SysConvert.ToString(gridView1.GetRowCellValue(i, "Style"));
                    entitydts[index].SSN = SysConvert.ToString(gridView2.GetRowCellValue(i, "SSN"));
                    entitydts[index].DSN = SysConvert.ToString(gridView2.GetRowCellValue(i, "DSN"));
                    entitydts[index].StyleNo = SysConvert.ToString(gridView2.GetRowCellValue(i, "StyleNo"));
                    entitydts[index].SStyleNo = SysConvert.ToString(gridView2.GetRowCellValue(i, "SStyleNo"));
                    entitydts[index].Model = SysConvert.ToString(gridView2.GetRowCellValue(i, "Model"));
                    entitydts[index].CtnNo = SysConvert.ToString(gridView2.GetRowCellValue(i, "CtnNo"));
                    entitydts[index].CtnQty = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "CtnQty"));
                    entitydts[index].CrossWeight = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "CrossWeight"));
                    entitydts[index].NetWeight = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "NetWeight"));
                    entitydts[index].TotalBulk = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "TotalBulk"));
                    entitydts[index].Unit = SysConvert.ToString(gridView2.GetRowCellValue(i, "Unit"));
                    entitydts[index].PackPlanCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "PackPlanCode"));
                    entitydts[index].PackPlanID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "PackPlanID"));
                    entitydts[index].QGSinglePrice = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGSinglePrice"));
                    entitydts[index].QGAmount = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGAmount"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView5.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].QGQty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGQty"));
                    entitydts[index].PieceQty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Volume = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Volume"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "MWeight"));

                    index++;
                }
            }
            return entitydts;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CustomReportDts[] EntityReportDtsGet()
        {

            int index = GetDataCompleteNum(gridView3, gridView3CheckField);
            CustomReportDts[] entitydts = new CustomReportDts[index];
            index = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (CheckDataCompleteDts(gridView3, gridView3CheckField, i))
                {
                    entitydts[index] = new CustomReportDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].GoodNo = SysConvert.ToString(gridView3.GetRowCellValue(i, "GoodNo"));
                    entitydts[index].Model = SysConvert.ToString(gridView3.GetRowCellValue(i, "Model"));
                    entitydts[index].Qty = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "Qty"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Amount"));
                    entitydts[index].Description = SysConvert.ToString(gridView3.GetRowCellValue(i, "Description"));
                    entitydts[index].Unit = SysConvert.ToString(gridView3.GetRowCellValue(i, "Unit"));

                    entitydts[index].KGUnit = SysConvert.ToString(gridView3.GetRowCellValue(i, "KGUnit"));
                    entitydts[index].AmountUnit = SysConvert.ToString(gridView3.GetRowCellValue(i, "AmountUnit"));
                    entitydts[index].AmountEnUnit = SysConvert.ToString(gridView3.GetRowCellValue(i, "AmountEnUnit"));

                    entitydts[index].UnitPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "UnitPrice"));
                    entitydts[index].BGFY = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "BGFY"));
                    entitydts[index].Remark = SysConvert.ToString(gridView3.GetRowCellValue(i, "Remark"));
                    entitydts[index].BGFY2 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "BGFY2"));
                    entitydts[index].BGFY3 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "BGFY3"));
                    entitydts[index].BGFY4 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "BGFY4"));
                    entitydts[index].BGFY5 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "BGFY5"));
                    entitydts[index].Country = SysConvert.ToString(gridView3.GetRowCellValue(i, "Country"));
                    entitydts[index].ZM = SysConvert.ToString(gridView3.GetRowCellValue(i, "ZM"));
                    entitydts[index].NetQty = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "NetQty"));
                    entitydts[index].Remark = SysConvert.ToString(gridView3.GetRowCellValue(i, "Remark"));

                    entitydts[index].length1 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length1"));
                    entitydts[index].length2 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length2"));
                    entitydts[index].length3 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length3"));
                    entitydts[index].length4 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length4"));
                    entitydts[index].length5 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length5"));
                    entitydts[index].length6 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length6"));
                    entitydts[index].length7 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length7"));
                    entitydts[index].length8 = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "length8"));


                    entitydts[index].Size1 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size1"));
                    entitydts[index].Size2 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size2"));
                    entitydts[index].Size3 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size3"));
                    entitydts[index].Size4 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size4"));
                    entitydts[index].Size5 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size5"));
                    entitydts[index].Size6 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size6"));
                    entitydts[index].Size7 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size7"));
                    entitydts[index].Size8 = SysConvert.ToString(gridView3.GetRowCellValue(i, "Size8"));

                    index++;
                }
            }
            return entitydts;
        }


        /// <summary>
        /// 处理主实体之和
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityqtydts"></param>
        private void SetEntityQty(Custom entity, CustomDts[] entitydts, CustomPackDts[] entityPackDts, CustomInvoiceDts[] entityInvoiceDts)
        {
            //decimal TotalQty = 0;
            //decimal TotalAmount = 0;
            //int CtnQty = 0;
            //decimal CrossWeight = 0;
            //decimal NetWeight = 0;
            //decimal TotalBulk = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{

            //    entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Qty;

            //    entitydts[i].ILeftQty = entitydts[i].Qty - entitydts[i].ICheckedQty;
            //    entitydts[i].ILeftAmount = entitydts[i].Amount - entitydts[i].ICheckedAmount;
            //    TotalAmount += entitydts[i].Amount;
            //    TotalQty += entitydts[i].Qty;
            //}
            //for (int i = 0; i < entityPackDts.Length; i++)
            //{
            //    CtnQty += entityPackDts[i].CtnQty;
            //    CrossWeight += entityPackDts[i].CrossWeight;
            //    NetWeight += entityPackDts[i].NetWeight;
            //    TotalBulk += entityPackDts[i].TotalBulk;
            //}
            //entity.TotalAmount = TotalAmount;
            //entity.TotalQty = TotalQty;
            //entity.TotalBulk = TotalBulk;
            //entity.TotalCtnQty = CtnQty;
            //entity.TotalCrossWeight = CrossWeight;
            //entity.TotalNetWeight = NetWeight;
        }

        #endregion

        #region 其它事件

        /// <summary>
        /// 根据币种带汇率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpCurrency_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (drpCurrency.EditValue.ToString() != "")
                {
                    //txtRate.Text = Common.CurrencyTORate(drpCurrency.EditValue.ToString());
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        ///发票列表数量、单位、金额计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGirdQty_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Qty = 0;
                decimal Price = 0;
                decimal Amount = 0;
                decimal TotalQty = 0;
                decimal TotalAmount = 0;

                Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SinglePrice"));
                Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));
                Amount = Qty * Price;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Amount", Amount.ToString());
                for (int j = 0; j < gridView1.RowCount; j++)
                {
                    TotalQty += SysConvert.ToInt32(gridView1.GetRowCellValue(j, "Qty"));
                    TotalAmount += SysConvert.ToDecimal(gridView1.GetRowCellValue(j, "Amount"));

                }

                txtTotalAmount.Text = TotalAmount.ToString();
                txtTotalQty.Text = TotalQty.ToString();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 装箱列表想数、毛重、净重、体积计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGridCtnQty_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    this.BaseFocusLabel.Focus();
            //    decimal CtnQty = 0;
            //    decimal CrossWeight = 0;
            //    decimal NetWeight = 0;
            //    decimal TotalBulk = 0;

            //    for (int j = 0; j < gridView1.RowCount; j++)
            //    {
            //        CtnQty += SysConvert.ToInt32(gridView2.GetRowCellValue(j, "CtnQty"));
            //        CrossWeight += SysConvert.ToDecimal(gridView2.GetRowCellValue(j, "CrossWeight"));
            //        NetWeight += SysConvert.ToDecimal(gridView2.GetRowCellValue(j, "NetWeight"));
            //        TotalBulk += SysConvert.ToDecimal(gridView2.GetRowCellValue(j, "TotalBulk"));
            //    }
            //    txtTotalCtnQty.Text = CtnQty.ToString();
            //    txtTotalCrossWeight.Text = CrossWeight.ToString();
            //    txtTotalNetWeight.Text = NetWeight.ToString();
            //    txtTotalBulk.Text = TotalBulk.ToString();
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }
        #endregion

        #region 数据加载



        /// <summary>
        /// 加载客户订单
        /// </summary>
        private void SOMLoad()
        {
            try
            {
                //frmSOMLoad frm = new frmSOMLoad();
                ////frm.HTLoadConditionStr = " AND isnull(LoadFlag,0)=0";
                //frm.ShowDialog();
                //if (frm.HTLoadData.Count != 0)
                //{

                //    int SOMID = SysConvert.ToInt32(frm.HTLoadData[0].ToString());
                //    SOM entity = new SOM();
                //    entity.ID = SOMID;
                //    entity.SelectByID();
                //    //txtDSN.Text = entity.DSN;
                //    //txtSalesNumber.Text = entity.DSN;
                //    //drpCompanyTypeID.EditValue = entity.CompanyTypeID;
                //    //txtTotalQty.Text = entity.TotalQty.ToString();

                //    string sql = " SELECT * FROM Sale_SOMStyle WHERE MainID=" + SysString.ToDBString(SOMID);
                //    DataTable dt = SysUtils.Fill(sql);
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Seq", dt.Rows[i]["Seq"].ToString());
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "DSN", dt.Rows[i]["DSN"].ToString());
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "SSN", dt.Rows[i]["SSN"].ToString());
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "SStyleNo", dt.Rows[i]["SStyleNo"].ToString());
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "StyleNo", dt.Rows[i]["StyleNo"].ToString());
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Model", "");
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Qty", SysConvert.ToInt32(dt.Rows[i]["TotalQty"].ToString()));




                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle + i, "Seq", dt.Rows[i]["Seq"].ToString());
                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle + i, "DSN", dt.Rows[i]["DSN"].ToString());
                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle + i, "SSN", dt.Rows[i]["SSN"].ToString());
                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle + i, "SStyleNo", dt.Rows[i]["SStyleNo"].ToString());
                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle + i, "StyleNo", dt.Rows[i]["StyleNo"].ToString());
                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle + i, "Model", "");


                //    }
                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 根据装箱数据给表头控件赋值
        /// </summary>
        private void TableHeadControlSetValue()
        {
            //表头控件赋值
            //decimal ctnqty = 0m, netweight = 0m, crossweight = 0m, totalbulk = 0;
            //for (int i = 0; i < dtInvoiceDts.Rows.Count; i++)
            //{
            //    ctnqty += SysConvert.ToDecimal(dtInvoiceDts.Rows[i]["ILeftQty"]);
            //    netweight += SysConvert.ToDecimal(dtInvoiceDts.Rows[i]["NW"]);
            //    crossweight += SysConvert.ToDecimal(dtInvoiceDts.Rows[i]["GW"]);
            //    totalbulk += SysConvert.ToDecimal(dtInvoiceDts.Rows[i]["TJ"]);
            //}
            //txtTotalCtnQty.Text = ctnqty.ToString();
            //txtTotalNetWeight.Text = netweight.ToString();
            //txtTotalCrossWeight.Text = crossweight.ToString();
            //txtTotalBulk.Text = totalbulk.ToString();

        }
        /// <summary>
        /// 生成报关单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateRpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    Custom entity = new Custom();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    string sql = "SELECT * FROM Ship_CustomReportDts WHERE 1=0";
                    DataTable dttemp = SysUtils.Fill(sql);//取得空表结构

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "DSN")) != string.Empty)
                        {
                            bool flag = false;
                            if (chkMergeFlag.Checked)//勾选合并
                            {
                                for (int j = 0; j < dttemp.Rows.Count; j++)
                                {
                                    if (dttemp.Rows[j]["Model"].ToString() == SysConvert.ToString(gridView1.GetRowCellValue(i, "Model")))
                                    {
                                        int tempqty = SysConvert.ToInt32(dttemp.Rows[j]["Qty"].ToString());
                                        int sourceqty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "Qty"));

                                        decimal tempPrice = SysConvert.ToDecimal(dttemp.Rows[j]["UnitPrice"].ToString());
                                        decimal sourcePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));

                                        decimal tempAmount = SysConvert.ToDecimal(dttemp.Rows[j]["Amount"].ToString());
                                        decimal sourceAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));


                                        dttemp.Rows[j]["Qty"] = tempqty + sourceqty;
                                        dttemp.Rows[j]["Amount"] = tempAmount + sourceAmount;

                                        if ((tempqty + sourceqty) != 0)
                                        {
                                            dttemp.Rows[j]["UnitPrice"] = SysConvert.ToDecimal((tempAmount + sourceAmount) / (tempqty + sourceqty), 4);
                                        }
                                        //dttemp.Rows[j]["Country"] = entity.Dyg;

                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            if (!flag)
                            {
                                DataRow dr = dttemp.NewRow();
                                dr["Model"] = SysConvert.ToString(gridView1.GetRowCellValue(i, "Model"));
                                dr["Qty"] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "Qty"));
                                dr["UnitPrice"] = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                                dr["Amount"] = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
                                //dr["Country"] = entity.Dyg;
                                dttemp.Rows.Add(dr);
                            }
                        }
                    }

                    dtReports = dttemp;
                    BindGridReport();
                    ShowInfoMessage("生成报关单成功");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 绑定grid
        /// </summary>
        private void BindGridReport()
        {
            //groupControl1.DataSource = dtReports;
            //groupControl1.Show();
        }

        /// <summary>
        /// 绑定grid
        /// </summary>
        private void BindGridPack()
        {
            gridControl2.DataSource = dtPackDts;
            gridControl2.Show();
        }

        /// <summary>
        /// 绑定grid
        /// </summary>
        private void BindGridInvoice()
        {
            gridControl4.DataSource = dtInvoiceDts;
            gridControl4.Show();
        }
        #endregion

        #region 重载事件（打印相关）
        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPreview_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                //FastReport.ReportRun(tempReportID, (int)ReportPrintType.转PDF, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
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
                base.btnPrint_Click(sender, e);

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                //FastReport.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
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
                base.btnDesign_Click(sender, e);
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交3))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                //FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion


        private void txtMessrs_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                //frmLoadMessrs frm = new frmLoadMessrs();
                //frm.ShowDialog();
                //if (frm.HTLoadData.Count == 1)
                //{
                //    Custom entityCS = new Custom();
                //    entityCS.ID = SysConvert.ToInt32(frm.HTLoadData[0]);
                //    entityCS.SelectByCode();
                //    txtMessrs.Text = entityCS.Messrs;
                //    txtMarkNo.Text = entityCS.MarkNo;
                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Qty" || e.Column.FieldName == "UnitPrice")
                {
                    decimal Qty = SysConvert.ToDecimal(gridView3.GetRowCellValue(e.RowHandle, "Qty"));
                    decimal Price = SysConvert.ToDecimal(gridView3.GetRowCellValue(e.RowHandle, "UnitPrice"));
                    decimal Amount = SysConvert.ToDecimal(Qty * Price);
                    gridView3.SetRowCellValue(e.RowHandle, "Amount", Amount);
                }
            }
            catch (Exception E)
            {
                throw;
            }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Qty" || e.Column.FieldName == "SinglePrice")
                {
                    decimal Qty = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "Qty"));
                    decimal Price = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "SinglePrice"));
                    decimal Amount = SysConvert.ToDecimal(Qty * Price);
                    gridView5.SetRowCellValue(e.RowHandle, "Amount", Amount);
                }
            }
            catch (Exception E)
            {
                throw;
            }
        }


        /// <summary>
        /// 加载计划装箱单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    //frmLoadWOOrder frm = new frmLoadWOOrder();

                    //string sql = string.Empty;
                    //frm.NoLoadCondition = sql;
                    //frm.CheckFlag = 1;

                    //frm.ShowDialog();
                    //string str = string.Empty;
                    //if (frm.OrderID != null && frm.OrderID.Length != 0)
                    //{

                    //    for (int i = 0; i < frm.OrderID.Length; i++)
                    //    {
                    //        if (str != string.Empty)
                    //        {
                    //            str += ",";
                    //        }
                    //        str += SysConvert.ToString(frm.OrderID[i]);
                    //    }
                    //    setItemNews(str);
                    //}

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Plan_PlanPackListCom WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    gridView1.SetRowCellValue(i, "BoxNum", SysConvert.ToString(dt.Rows[0]["TotalBox"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["TotalQty"]));
                    gridView1.SetRowCellValue(i, "DSN", SysConvert.ToString(dt.Rows[0]["VendorStyle"]));

                    //gridView5.SetRowCellValue(i, "BoxNum", SysConvert.ToString(dt.Rows[0]["TotalBox"]));
                    gridView5.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["TotalQty"]));
                    gridView5.SetRowCellValue(i, "DSN", SysConvert.ToString(dt.Rows[0]["VendorStyle"]));
                    gridView1.SetRowCellValue(i, "DSN", SysConvert.ToString(dt.Rows[0]["VendorStyle"]));
                    gridView3.SetRowCellValue(i, "Description", SysConvert.ToString(dt.Rows[0]["VendorStyle"]));

                }
            }

        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal SizeKuan = 0;
                decimal SizeGao = 0;
                decimal SizeChang = 0;
                decimal Bulk = 0;
                decimal BoxNum = 0;
                if (e.Column.FieldName == "SizeK" || e.Column.FieldName == "SizeG" || e.Column.FieldName == "SizeC")
                {
                    SizeKuan = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SizeK"));
                    SizeGao = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SizeG"));
                    SizeChang = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SizeC"));
                    BoxNum = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ILeftQty"));
                    Bulk = (SizeKuan * SizeGao * SizeChang) / 1000000m;
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TJ", Bulk * BoxNum);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpYDCountry_EditValueChanged(object sender, EventArgs e)
        {
            Custom entity = new Custom();
            if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
            {
                if (SysConvert.ToString(drpYDCountry.EditValue) != string.Empty)
                {
                    string sql = "select * from Data_BGInfo WHERE Country=" + SysString.ToDBString(SysConvert.ToString(drpYDCountry.EditValue));
                    DataTable dt = new DataTable();
                    dt = SysUtils.Fill(sql);
                    txtMessrs.Text = dt.Rows[0]["Messrs"].ToString();

                    drpShipTo.EditValue = dt.Rows[0]["Destination"].ToString();
                }
            }
        }

        private void gridView5_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)//2015.7.23邱超改
                {
                    if (e.Column.FieldName == "Qty" || e.Column.FieldName == "SinglePrice" || e.Column.FieldName == "MWidth" || e.Column.FieldName == "MWeight")
                    {
                        ColumnView view = sender as ColumnView;
                        decimal Qty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Qty"));
                        decimal SinglePrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SinglePrice"));
                        // decimal CrossWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "CrossWeight"));
                        decimal MWidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));
                        decimal MWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));
                        view.SetRowCellValue(view.FocusedRowHandle, "Amount", SysConvert.ToDecimal(Qty * SinglePrice, 2));
                        view.SetRowCellValue(view.FocusedRowHandle, "QGSinglePrice", SysConvert.ToDecimal(SinglePrice / SysConvert.ToDecimal(0.9144), 4));
                        view.SetRowCellValue(view.FocusedRowHandle, "QGQty", SysConvert.ToDecimal(Qty * SysConvert.ToDecimal(0.9144), 2));
                        string d = "PKGS";
                        view.SetRowCellValue(view.FocusedRowHandle, "Unit", d);
                        //NetWeight=qty*0.9144*Mwidth*Mweight 
                        decimal b = SysConvert.ToDecimal(Qty * SysConvert.ToDecimal(0.9144) * MWidth * SysConvert.ToDecimal(0.01) * MWeight * SysConvert.ToDecimal(0.001), 0);
                        view.SetRowCellValue(view.FocusedRowHandle, "NetWeight", b);
                        decimal PieceQty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PieceQty"));
                        decimal NetWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "NetWeight"));
                        decimal c = SysConvert.ToDecimal(PieceQty * SysConvert.ToDecimal(0.3) + NetWeight, 0);
                        view.SetRowCellValue(view.FocusedRowHandle, "GrossWeight", c);
                    }
                    if (e.Column.FieldName == "QGQty" || e.Column.FieldName == "SinglePrice")
                    {
                        ColumnView view = sender as ColumnView;

                        decimal QGQty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "QGQty"));
                        decimal SinglePrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SinglePrice"));
                        decimal qgamount = SysConvert.ToDecimal(QGQty * SinglePrice / SysConvert.ToDecimal(0.9144), 2);
                        view.SetRowCellValue(view.FocusedRowHandle, "QGAmount", qgamount);
                    }



                }
                //DataTable dt5 = gridView5.GridControl.DataSource as DataTable;
                //DataTable dt1 = gridView1.GridControl.DataSource as DataTable;
                //DataTable dt3 = gridView3.GridControl.DataSource as DataTable;
                //if (e.Column.FieldName == "Qty" || e.Column.FieldName == "SinglePrice")
                //{
                //    decimal Qty = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "Qty"));
                //    decimal Price = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "SinglePrice"));
                //    decimal Amount = SysConvert.ToDecimal(Qty * Price);
                //    dt5.Rows[e.RowHandle]["Amount"] = Amount;
                //    dt3.Rows[e.RowHandle]["Amount"] = Amount;

                //}
                //if (e.Column.FieldName == "Qty" || e.Column.FieldName == "QGSinglePrice")
                //{
                //    decimal Qty = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "Qty"));
                //    decimal Price = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "QGSinglePrice"));
                //    decimal QGAmount = SysConvert.ToDecimal(Qty * Price);
                //    dt5.Rows[e.RowHandle]["QGAmount"] = QGAmount;

                //}
                //if (e.Column.FieldName == "Model")
                //{
                //    string Model = SysConvert.ToString(gridView5.GetRowCellValue(e.RowHandle, "Model"));
                //    dt3.Rows[e.RowHandle]["Remark"] = Model;
                //    dt1.Rows[e.RowHandle]["Model"] = Model;
                //}
                //if (e.Column.FieldName == "Qty")
                //{
                //    decimal Model = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "Qty"));
                //    dt3.Rows[e.RowHandle]["Qty"] = Model;
                //    dt1.Rows[e.RowHandle]["Qty"] = Model;

                //}
                //if (e.Column.FieldName == "SinglePrice")
                //{
                //    decimal Model = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "SinglePrice"));
                //    dt3.Rows[e.RowHandle]["UnitPrice"] = Model;
                //    dt1.Rows[e.RowHandle]["SinglePrice"] = Model;
                //}
                //if (e.Column.FieldName == "DSN")
                //{
                //    decimal Model = SysConvert.ToDecimal(gridView5.GetRowCellValue(e.RowHandle, "DSN"));
                //    dt3.Rows[e.RowHandle]["Description"] = Model;
                //    dt1.Rows[e.RowHandle]["DSN"] = Model;
                //}

            }
            catch (Exception E)
            {
                throw;
            }
        }

        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)//2015.7.23邱超改
            //    {
            //        if (e.Column.FieldName == "Qty" || e.Column.FieldName == "SinglePrice" || e.Column.FieldName == "MWidth" || e.Column.FieldName == "MWeight")
            //        {
            //            ColumnView view = sender as ColumnView;
            //            decimal Qty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Qty"));
            //            decimal SinglePrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SinglePrice"));
            //            // decimal CrossWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "CrossWeight"));
            //            decimal MWidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));
            //            decimal MWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));

            //            decimal a = SysConvert.ToDecimal(Qty / 100, 0);
            //            view.SetRowCellValue(view.FocusedRowHandle, "PieceQty", a);
            //            view.SetRowCellValue(view.FocusedRowHandle, "Amount", SysConvert.ToDecimal(Qty * SinglePrice, 2));
            //            view.SetRowCellValue(view.FocusedRowHandle, "QGQty", SysConvert.ToDecimal(Qty * SysConvert.ToDecimal(0.9144), 2));
            //            string d = "PKGS";
            //            view.SetRowCellValue(view.FocusedRowHandle, "Unit", d);
            //            //NetWeight=qty*0.9144*Mwidth*Mweight 
            //            decimal b = SysConvert.ToDecimal(Qty * SysConvert.ToDecimal(0.9144) * MWidth * SysConvert.ToDecimal(0.01) * MWeight * SysConvert.ToDecimal(0.001), 0);
            //            view.SetRowCellValue(view.FocusedRowHandle, "NetWeight", b);
            //            decimal PieceQty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PieceQty"));
            //            decimal NetWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "NetWeight"));
            //            decimal c = SysConvert.ToDecimal(PieceQty * SysConvert.ToDecimal(0.3) + NetWeight, 0);
            //            view.SetRowCellValue(view.FocusedRowHandle, "CrossWeight", c);
            //        }
            //        if (e.Column.FieldName == "QGQty" || e.Column.FieldName == "SinglePrice")
            //        {
            //            ColumnView view = sender as ColumnView;


            //            decimal QGQty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "QGQty"));
            //            decimal SinglePrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SinglePrice"));
            //            decimal qgamount = SysConvert.ToDecimal(QGQty * SinglePrice / SysConvert.ToDecimal(0.9144), 2);
            //            view.SetRowCellValue(view.FocusedRowHandle, "QGAmount", qgamount);
            //        }

            //    }
            //}
            //catch (Exception E)
            //{
            //    throw;
            //}
        }
        #region 提交单据
        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.提交))
                {
                    return;
                }
                CustomRule rule = new CustomRule();
                Custom entity = EntityGet();
                rule.RSubmit(entity);
                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                SetFormStatus(FormStatus.查询);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 撤销提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交2))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.撤消提交))
                {
                    return;
                }

                //HTSubmitCancel(_HTDataTableName, _HTDataID.ToString());

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                SetFormStatus(FormStatus.查询);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
     


        /// <summary>
        /// 生成报关单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHB_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    Custom entity = new Custom();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    string sql = "SELECT * FROM Ship_CustomDts WHERE 1=0";
                    DataTable dttemp = SysUtils.Fill(sql);//取得空表结构

                    for (int i = 0; i < gridView5.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView5.GetRowCellValue(i, "Style")) != string.Empty)
                        {
                            bool flag = false;

                            for (int j = 0; j < dttemp.Rows.Count; j++)
                            {

                                if (dttemp.Rows[j]["Style"].ToString() == SysConvert.ToString(gridView5.GetRowCellValue(i, "Style"))
                                      && SysConvert.ToDecimal(dttemp.Rows[j]["SinglePrice"]) == SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "SinglePrice"))
                                      && SysConvert.ToDecimal(dttemp.Rows[j]["QGSinglePrice"]) == SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGSinglePrice"))
                                    )
                                {
                                    decimal tempqty = SysConvert.ToDecimal(dttemp.Rows[j]["Qty"].ToString());
                                    decimal tempAmount = SysConvert.ToDecimal(dttemp.Rows[j]["Amount"].ToString());
                                    //decimal tempSinglePrice = SysConvert.ToDecimal(dttemp.Rows[j]["SinglePrice"].ToString());
                                    decimal tempQGqty = SysConvert.ToDecimal(dttemp.Rows[j]["QGQty"].ToString());
                                    decimal tempQGAmount = SysConvert.ToDecimal(dttemp.Rows[j]["QGAmount"].ToString());
                                    //decimal tempQGSinglePrice = SysConvert.ToDecimal(dttemp.Rows[j]["SinglePrice"].ToString());
                                    decimal tempVolume = SysConvert.ToDecimal(dttemp.Rows[j]["Volume"].ToString());
                                    decimal tempGrossWeight = SysConvert.ToDecimal(dttemp.Rows[j]["GrossWeight"].ToString());
                                    decimal tempNetWeight = SysConvert.ToDecimal(dttemp.Rows[j]["NetWeight"].ToString());
                                    decimal tempPieceQty = SysConvert.ToDecimal(dttemp.Rows[j]["PieceQty"].ToString());


                                    decimal sourceqty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Qty"));
                                    //decimal sourceSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));                                 
                                    decimal sourceAmount = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Amount"));
                                    decimal sourceQGqty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGQty"));
                                    //decimal sourcePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                                    decimal sourceQGAmount = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGAmount"));
                                    decimal sourceVolume = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Volume"));
                                    decimal sourceGrossWeight = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "GrossWeight"));
                                    decimal sourceNetWeight = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "NetWeight"));
                                    decimal sourcePieceQty = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "PieceQty"));

                                    dttemp.Rows[j]["Qty"] = tempqty + sourceqty;
                                    dttemp.Rows[j]["Amount"] = tempAmount + sourceAmount;
                                    dttemp.Rows[j]["QGQty"] = tempQGqty + sourceQGqty;
                                    dttemp.Rows[j]["QGAmount"] = tempQGAmount + sourceQGAmount;
                                    dttemp.Rows[j]["Volume"] = tempVolume + sourceVolume;
                                    dttemp.Rows[j]["GrossWeight"] = tempGrossWeight + sourceGrossWeight;
                                    dttemp.Rows[j]["NetWeight"] = tempNetWeight + sourceNetWeight;
                                    dttemp.Rows[j]["PieceQty"] = tempPieceQty + sourcePieceQty;
                                    //if ((tempqty + sourceqty) != 0)
                                    //{
                                    //    dttemp.Rows[j]["UnitPrice"] = SysConvert.ToDecimal((tempAmount + sourceAmount) / (tempqty + sourceqty), 4);
                                    //}
                                    //dttemp.Rows[j]["Country"] = entity.Dyg;

                                    flag = true;
                                    break;
                                }
                            }
                         
                            if (!flag)
                            {
                                DataRow dr = dttemp.NewRow();
                                dr["Style"] = SysConvert.ToString(gridView5.GetRowCellValue(i, "Style"));
                                dr["ColorNum"] = SysConvert.ToString(gridView5.GetRowCellValue(i, "ColorNum"));
                                 dr["Model"] = SysConvert.ToString(gridView5.GetRowCellValue(i, "Model"));
                                 dr["MWidth"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "MWidth"));
                                 dr["MWeight"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "MWeight"));
                                 dr["Unit"] = SysConvert.ToString(gridView5.GetRowCellValue(i, "Unit"));
                                 dr["SinglePrice"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "SinglePrice"));
                                 dr["QGSinglePrice"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGSinglePrice"));
                                 dr["Qty"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Qty"));                            
                                dr["Amount"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Amount"));
                                dr["QGQty"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGQty"));
                                dr["QGAmount"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "QGAmount"));
                                dr["PieceQty"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "PieceQty"));
                                dr["Volume"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "Volume"));
                                dr["GrossWeight"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "GrossWeight"));
                                dr["NetWeight"] = SysConvert.ToDecimal(gridView5.GetRowCellValue(i, "NetWeight"));
                                dttemp.Rows.Add(dr);
                            }
                        }
                    }

                    dtInvoiceDts = dttemp;
                    BindGridInvoice();
                    ShowInfoMessage("合并成功");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




    }
}