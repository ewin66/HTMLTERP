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
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Base;

namespace MLTERP
{
    /// <summary>
    /// 托书
    /// </summary>
    public partial class frmShipBoatEdit : frmAPBaseUIFormEdit
    {
        public frmShipBoatEdit()
        {
            InitializeComponent();
        }


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

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            ShipBoatDtsRule rule = new ShipBoatDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ShipBoatRule rule = new ShipBoatRule();
            ShipBoat entity = EntityGet();
            ShipBoatDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();

            decimal PieceQty = 0;
            decimal NetWeight = 0;
            decimal CroosWeight = 0;
            //decimal BoxNum = 0;
            decimal BulkSize = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                PieceQty += entitydts[i].PieceQty;
                NetWeight += entitydts[i].NetWeight;
                CroosWeight += entitydts[i].CrossWeight;
               // CroosWeight += entitydts[i].CrossWeight;
                // BoxNum += entitydts[i].BoxNum;
                BulkSize += entitydts[i].BulkSize;
            }
            entity.PackNum = SysConvert.ToDecimal(PieceQty,0);
            entity.NetWeight = SysConvert.ToDecimal(NetWeight,0);
            entity.CroosWeight =SysConvert.ToDecimal(CroosWeight,0);
            // entity.PortDischarge = BoxNum.ToString();
            entity.TotalBulk = SysConvert.ToDecimal(BulkSize,1);
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ShipBoatRule rule = new ShipBoatRule();
            ShipBoat entity = EntityGet();
            ShipBoatDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();

            decimal PieceQty = 0;
            decimal NetWeight = 0;
            decimal CroosWeight = 0;
            //decimal BoxNum = 0;
            decimal BulkSize = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                PieceQty += entitydts[i].PieceQty;
                NetWeight += entitydts[i].NetWeight;
                CroosWeight += entitydts[i].CrossWeight;
               // CroosWeight += entitydts[i].CrossWeight;
                // BoxNum += entitydts[i].BoxNum;
                BulkSize += entitydts[i].BulkSize;
            }
            entity.PackNum = SysConvert.ToDecimal(PieceQty,0);
            entity.NetWeight = SysConvert.ToDecimal(NetWeight, 0);
            entity.CroosWeight = SysConvert.ToDecimal(CroosWeight, 0);
            // entity.PortDischarge = BoxNum.ToString();
            entity.TotalBulk = SysConvert.ToDecimal(BulkSize, 1);
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ShipBoat entity = new ShipBoat();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            txtIvoiceNo.Text = entity.IvoiceNo.ToString();
            txtCompanyTypeID.Text = entity.CompanyTypeID.ToString();
            txtSaleNo.Text = entity.SaleNo.ToString();
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtModel.Text = entity.Model.ToString();
            txtModelEn.Text = entity.ModelEn.ToString();
            drpTradeType.EditValue = entity.TradeType.ToString();
            drpGainType.EditValue = entity.GainType.ToString();
            drpReceiveType.EditValue = entity.ReceiveType.ToString();
            drpTransType.EditValue = entity.TransType.ToString();
            txtShipTo.Text = entity.ShipTo.ToString();
            drpFactoryID.EditValue = entity.FactoryID.ToString();
            txtMessrs.Text = entity.Messrs.ToString();
            txtSpeRequest.Text = entity.SpeRequest.ToString();


            //txtSCNo.Text = entity.SCNo.ToString(); 
            //txtBoatName.Text = entity.BoatName.ToString(); 
            txtdex.Text = entity.dex.ToString();

            txtCode.Text = entity.Code.ToString();

            drpY_DPay.EditValue = entity.SCNo.ToString();//预到付
            drpZY.EditValue = entity.BoatName.ToString();//是否分批/转运
            drpFS.EditValue = entity.Container.ToString();//B/L份数

            txtINWHDate.DateTime = entity.GoodsINWHDate;
            drpFROM.EditValue = entity.FromOPName;
            drpTO.EditValue = entity.ToOPName;

            txtSpecial.Text = entity.Special.ToString();
            txtTotalBulk.Text = entity.TotalBulk.ToString();
            txtCroosWeight.Text = entity.CroosWeight.ToString();
            txtNetWeight.Text = entity.NetWeight.ToString();
            txtPackNum.Text = entity.PackNum.ToString();
            txtShippers.Text = entity.Shippers.ToString();
            //drpShippers.EditValue = entity.Shippers.ToString();
            txtConsignee.Text = entity.Consignee.ToString();
            txtNotifyParty.Text = entity.NotifyParty.ToString();
            txtPortLoading.Text = entity.PortLoading.ToString();
            txtXL.EditValue = entity.PortDischarge.ToString();
            txtLCNo.Text = entity.LCNo.ToString();

            txtShipDate.DateTime = entity.ShipDate;
            txtRevisedDate.DateTime = entity.RevisedDate;
            txtOutDate.DateTime = entity.OutDate;
            txtOutFacDate.DateTime = entity.OutFacDate;
            txtExportDate.DateTime = entity.ExportDate;
            if (txtShipDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtShipDate.Text = "";
            }
            if (txtOutDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtOutDate.Text = "";
            }
            if (txtRevisedDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtRevisedDate.Text = "";
            }
            if (txtOutFacDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtOutFacDate.Text = "";
            }
            if (txtExportDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtExportDate.Text = "";
            }

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ShipBoatRule rule = new ShipBoatRule();
            ShipBoat entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtShipDate.DateTime = DateTime.Now.Date;
            txtRevisedDate.DateTime = DateTime.Now.Date;
            txtOutDate.DateTime = DateTime.Now.Date;
            txtOutFacDate.DateTime = DateTime.Now.Date;
            txtExportDate.DateTime = DateTime.Now.Date;
            txtINWHDate.DateTime = DateTime.Now.Date;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Ship_ShipBoat";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Qty" };//数据明细校验必须录入字段

            //Common.BindCompanyType(drpCompanyTypeID, false);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);

            new VendorProc(drpVendorID);
            Common.BindVendor(drpFactoryID, new int[] { (int)EnumVendorType.工厂 }, true);

            new VendorProc(drpFactoryID);

            //Common.BindCLS(drpGainType, this.HTDataTableName, "GainType", true);
            //Common.BindCLS(drpReceiveType, this.HTDataTableName, "ReceiveType", true);
            //Common.BindCLS(drpTradeType, this.HTDataTableName, "TradeType", true);
            //Common.BindCLS(drpTransType, this.HTDataTableName, "TransType", true);
            ////Common.BindCLS(drpXL, this.HTDataTableName, "PortDischarge", true);
            //Common.BindCLS(drpY_DPay, this.HTDataTableName, "SCNO", true);
            //Common.BindCLS(drpFS, this.HTDataTableName, "Container", true);
            //Common.BindCLS(drpZY, this.HTDataTableName, "BoatName", true);
            //Common.BindCLS(drpFROM, this.HTDataTableName, "FromOPName", true);
            //Common.BindCLS(drpTO, this.HTDataTableName, "TOOPName", true);
            DevMethod.BindRepCountry(drpCountry);
            //Common.BindCLS(drpShippers, this.HTDataTableName, "Shippers", true);
            //this.ToolBarItemAdd(28, "btnCheckLoad", "加载", false, btnCheckLoad_Click);

            //this.ToolBarItemSet(-1, ToolButtonName.btnPreview.ToString(), "预览", false, 13);//13
            ////this.ToolBarItemSet(-1, ToolButtonName.btnPrint.ToString(), "打印", false, 12);//12
            //this.ToolBarItemSet(-1, ToolButtonName.btnDesign.ToString(), "设计", false, 28);//28
            //this.ToolBarItemAdd(28, "btnCheckLoad", "打印", false, btnInvoice_Click);
            //this.ToolBarItemAdd(28, "btnCheckLoad", "导出小国家", false, btnESTS_Click);
            //this.ToolBarItemAdd(28, "btnCheckLoad", "导出JL", false, btnJLTS_Click);
            //this.ToolBarItemAdd(28, "btnCheckLoad", "导出DAMCO", false, btnDAMCO_Click);
            //this.ToolBarItemAdd(28, "btnCheckLoad", "导出嘉里大通空运", false, btnJLKY_Click);
            SetTabIndex(0, groupControlMainten);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ShipBoat EntityGet()
        {
            ShipBoat entity = new ShipBoat();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.IvoiceNo = txtIvoiceNo.Text.Trim();
            entity.CompanyTypeID = SysConvert.ToInt32(txtCompanyTypeID.Text.Trim());
            entity.SaleNo = txtSaleNo.Text.Trim();
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.Model = txtModel.Text.Trim();
            entity.ModelEn = txtModelEn.Text.Trim();
            entity.TradeType = drpTradeType.EditValue.ToString();
            entity.GainType = drpGainType.EditValue.ToString();
            entity.ReceiveType = drpReceiveType.EditValue.ToString();
            entity.TransType = drpTransType.EditValue.ToString();
            entity.ShipTo = txtShipTo.Text.Trim();

            entity.FactoryID = txtCode.Text.Trim();
            //entity.FactoryID = drpFactoryID.EditValue.ToString(); 
            entity.FormListAID = this.FormListAID;
            entity.Messrs = txtMessrs.Text.Trim();
            entity.SpeRequest = txtSpeRequest.Text.Trim();


            entity.SCNo = SysConvert.ToString(drpY_DPay.EditValue);//预到付
            entity.BoatName = SysConvert.ToString(drpZY.EditValue);//是否转运
            entity.Container = SysConvert.ToString(drpFS.EditValue);//B/L份数  7月21日改是否分批
            entity.GoodsINWHDate = Common.GetWorkDays(txtINWHDate.DateTime);
            entity.FromOPName = SysConvert.ToString(drpFROM.EditValue);
            entity.ToOPName = SysConvert.ToString(drpTO.EditValue);

            entity.Special = txtSpecial.Text.Trim();
            entity.TotalBulk = SysConvert.ToDecimal(txtTotalBulk.Text.Trim());
            entity.CroosWeight = SysConvert.ToDecimal(txtCroosWeight.Text.Trim());
            entity.NetWeight = SysConvert.ToDecimal(txtNetWeight.Text.Trim());
            entity.PackNum = SysConvert.ToDecimal(txtPackNum.Text.Trim());
            entity.Shippers = txtShippers.Text.Trim();
            //entity.Shippers = SysConvert.ToString(txtShippers.Text.Trim());
            entity.Consignee = txtConsignee.Text.Trim();
            entity.NotifyParty = txtNotifyParty.Text.Trim();
            entity.PortLoading = txtPortLoading.Text.Trim();

            entity.dex = txtdex.Text.Trim();
            entity.Code = txtCode.Text.Trim();
            entity.PortDischarge = txtXL.Text.Trim();
            entity.LCNo = txtLCNo.Text.Trim();//公司编号
            if (entity.AddOPID == "")
            {
                entity.AddOPID = FParamConfig.LoginName;
                entity.AddTime = Common.GetWorkDays(DateTime.Now);
            }
            entity.UpdOPID = FParamConfig.LoginName;
            entity.UpdTime = Common.GetWorkDays(DateTime.Now);

            if (txtShipDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtShipDate.Text != "")
            {
                entity.ShipDate = Common.GetWorkDays(txtShipDate.DateTime.Date);
            }
            if (txtRevisedDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtRevisedDate.Text != "")
            {
                entity.RevisedDate = Common.GetWorkDays(txtRevisedDate.DateTime.Date);
            }
            if (txtOutDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtOutDate.Text != "")
            {
                entity.OutDate = Common.GetWorkDays(txtOutDate.DateTime.Date);
            }
            if (txtOutFacDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtOutFacDate.Text != "")
            {
                entity.OutFacDate = Common.GetWorkDays(txtOutFacDate.DateTime.Date);
            }
            if (txtExportDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtExportDate.Text != "")
            {
                entity.ExportDate = Common.GetWorkDays(txtExportDate.DateTime.Date);
            }

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ShipBoatDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ShipBoatDts[] entitydts = new ShipBoatDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ShipBoatDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].SSN = SysConvert.ToString(gridView1.GetRowCellValue(i, "SSN"));
                    entitydts[index].DSN = SysConvert.ToString(gridView1.GetRowCellValue(i, "DSN"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].SizeKuan = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SizeKuan"));
                    entitydts[index].SizeGao = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SizeGao"));
                    entitydts[index].SizeChang = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SizeChang"));
                    entitydts[index].NetWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "NetWeight"));
                    entitydts[index].CrossWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CrossWeight"));
                    entitydts[index].BulkSize = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "BulkSize"));

                    entitydts[index].BoxNum = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "BoxNum"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].Model = SysConvert.ToString(gridView1.GetRowCellValue(i, "Model"));
                    entitydts[index].Style = SysConvert.ToString(gridView1.GetRowCellValue(i, "Style"));
                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));
                    entitydts[index].TSItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "TSItemName"));
                    entitydts[index].Country = SysConvert.ToString(gridView1.GetRowCellValue(i, "Country"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].HSCODE = SysConvert.ToString(gridView1.GetRowCellValue(i, "HSCODE"));
                    entitydts[index].dex = SysConvert.ToString(gridView1.GetRowCellValue(i, "dex"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].PieceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PieceQty"));


                    index++;
                }
            }
            return entitydts;
        }


        ///// <summary>
        ///// 加载计划装箱单
        ///// </summary>
        //private void PackPlanLoad()
        //{
        //    frmLoadPackPlan frm = new frmLoadPackPlan();
        //    frm.HTLoadConditionStr = " AND PackTypeID=1";
        //    frm.ShowDialog();
        //    if (frm.HTLoadData.Count != 0)
        //    {
        //        int firstID =SysConvert.ToInt32( frm.HTLoadData[0].ToString());

        //        PackPlan entity = new PackPlan();
        //        entity.ID = firstID;
        //        entity.SelectByID();
        //        //drpCompanyTypeID.EditValue = entity.CompanyTypeID;
        //        txtPortLoading.Text = entity.ShipFrom;
        //        txtShipTo.Text = entity.ShipTo;
        //        drpVendorID.EditValue = entity.VendorID.ToString();
        //        txtExportDate.DateTime = entity.ShipDate;
        //        txtPackNum.Text = entity.TotalCtnQty.ToString();
        //        txtCroosWeight.Text = entity.TotalCrossWeight.ToString();
        //        txtTotalBulk.Text = entity.TotalBulk.ToString();
        //        txtNetWeight.Text = entity.TotalNetWeight.ToString();
        //        if (txtExportDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
        //        {
        //            txtExportDate.Text = "";
        //        }
        //        string sql = string.Empty;
        //        sql = "SELECT MainID,StyleNo,SModel,Style,CtnQty,SSN,ISNULL(TotalQty,0) TotalQty,ISNULL(SizeKuan,0) SizeKuan,ISNULL(SizeGao,0) SizeGao,";
        //        sql += " ISNULL(SizeChang,0) SizeChang,ISNULL(NetWeight,0) NetWeight,ISNULL(CrossWeight,0) CrossWeight,ISNULL(BulkSize,0) BulkSize FROM Ship_PackPlanDts WHERE  MainID = " + firstID;
        //        DataTable dtDts = SysUtils.Fill(sql);

        //        if (dtDts.Rows.Count != 0)
        //        {

        //            for (int i = 0; i < dtDts.Rows.Count; i++)
        //            {
        //                gridView1.SetRowCellValue( i, "SSN", dtDts.Rows[i]["SSN"].ToString());
        //                gridView1.SetRowCellValue( i, "DSN", entity.DSN.ToString());
        //                gridView1.SetRowCellValue( i, "Qty", dtDts.Rows[i]["TotalQty"].ToString());

        //                gridView1.SetRowCellValue( i, "SizeKuan", dtDts.Rows[i]["SizeKuan"].ToString());
        //                gridView1.SetRowCellValue( i, "SizeGao", dtDts.Rows[i]["SizeGao"].ToString());
        //                gridView1.SetRowCellValue(i, "SizeChang", dtDts.Rows[i]["SizeChang"].ToString());
        //                gridView1.SetRowCellValue(i, "NetWeight", dtDts.Rows[i]["NetWeight"].ToString());
        //                gridView1.SetRowCellValue( i, "CrossWeight", dtDts.Rows[i]["CrossWeight"].ToString());
        //                gridView1.SetRowCellValue(i, "BulkSize", dtDts.Rows[i]["BulkSize"].ToString());

        //                gridView1.SetRowCellValue(i, "StyleNo", dtDts.Rows[i]["StyleNo"].ToString());
        //                gridView1.SetRowCellValue(i, "Style", dtDts.Rows[i]["Style"].ToString());
        //                gridView1.SetRowCellValue(i, "Model", dtDts.Rows[i]["SModel"].ToString());
        //                gridView1.SetRowCellValue(i, "BoxNum", dtDts.Rows[i]["CtnQty"].ToString()); 

        //            }
        //        }
        //    }

        //}
        #endregion

        #region 其它事件
        /// <summary>
        /// 明细数据计算汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void txtGridJS_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.BaseFocusLabel.Focus();
        //        decimal SizeKuan = 0;
        //        decimal SizeGao = 0;
        //        decimal SizeChang = 0;
        //        decimal TotalNetWeight = 0;
        //        decimal TotalCrossWeight = 0;
        //        decimal TotalBulk = 0;
        //        decimal Bulk = 0;
        //        decimal BoxNum = 0;
        //        decimal TotalBoxNum = 0;
        //        SizeKuan = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SizeKuan"));
        //        SizeGao = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SizeGao"));
        //        SizeChang = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SizeChang"));
        //        BoxNum = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BoxNum"));
        //        Bulk = (SizeKuan * SizeGao * SizeChang) / 1000000m;
        //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "BulkSize", Bulk * BoxNum);
        //        for (int j = 0; j < gridView1.RowCount; j++)
        //        {
        //            TotalNetWeight += SysConvert.ToDecimal(gridView1.GetRowCellValue(j, "NetWeight"));
        //            //TotalCrossWeight += SysConvert.ToDecimal(gridView1.GetRowCellValue(j, "CrossWeight"));
        //            TotalBulk += SysConvert.ToDecimal(gridView1.GetRowCellValue(j, "BulkSize"));
        //            //TotalBoxNum += SysConvert.ToDecimal(gridView1.GetRowCellValue(j, "BoxNum"));
        //        }
        //        txtTotalBulk.Text = TotalBulk.ToString();
        //        txtNetWeight.Text = TotalNetWeight.ToString();
        //        //txtCroosWeight.Text = TotalCrossWeight.ToString();
        //        //txtXL.Text = TotalBoxNum.ToString();
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

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

                    ////sql += " AND OrderStepID=" + SysString.ToDBString((int)EnumOrderStep.新单);
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
                    gridView1.SetRowCellValue(i, "Country", SysConvert.ToString(dt.Rows[0]["CompanyName"]));
                    gridView1.SetRowCellValue(i, "BoxNum", SysConvert.ToString(dt.Rows[0]["TotalBox"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["TotalQty"]));
                    gridView1.SetRowCellValue(i, "DSN", SysConvert.ToString(dt.Rows[0]["VendorStyle"]));

                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorAttn"]);
                    txtLCNo.Text = SysConvert.ToString(dt.Rows[0]["CompanyNo"]);
                }
            }

        }

        /// <summary>
        /// 明细数据计算汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)
                {
                    if (e.Column.FieldName == "Qty" || e.Column.FieldName == "MWidth" || e.Column.FieldName == "MWeight" )
                    {
                        ColumnView view = sender as ColumnView;
                        decimal Qty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Qty"));
                        // decimal CrossWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "CrossWeight"));
                        decimal MWidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));
                        decimal MWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));

                        decimal a = SysConvert.ToDecimal(Qty/100,0);
                        view.SetRowCellValue(view.FocusedRowHandle, "PieceQty", a);
                        string d = "PKGS";
                        view.SetRowCellValue(view.FocusedRowHandle, "Unit", d);
                        //NetWeight=qty*0.9144*Mwidth*Mweight 
                        decimal b = SysConvert.ToDecimal(Qty * SysConvert.ToDecimal(0.9144) * MWidth * SysConvert.ToDecimal(0.01) * MWeight * SysConvert.ToDecimal(0.001), 0);
                        view.SetRowCellValue(view.FocusedRowHandle, "NetWeight", b);
                        decimal PieceQty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PieceQty"));
                        decimal NetWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "NetWeight"));
                        decimal c = SysConvert.ToDecimal(PieceQty * SysConvert.ToDecimal(0.3) + NetWeight, 0);
                        view.SetRowCellValue(view.FocusedRowHandle, "CrossWeight", c);
                    }
                   
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

            //BaseFormatter formatBase = new BaseFormatter();
            //formatBase.EventHandler += new OverideFormat(formatBase_EventHandler);

            SUMTotalAmount();
        }
        #endregion


        #region 处理现实格式

        private string formatBase_EventHandler(string format, object arg, IFormatProvider formatProvider)
        {

            int state = int.Parse(arg.ToString());

            if (state == 0)

                return "";
            else
                return state.ToString();

        }
        private void SUMTotalAmount()
        {

            //DataTable dt1 = (DataTable)gridView1.GridControl.DataSource;
            //DataTable dt2 = (DataTable)gridView2.GridControl.DataSource;
            //DataTable dt3 = (DataTable)gridView3.GridControl.DataSource;
            //decimal ProjectAmount = SysConvert.ToDecimal(dt3.Compute("SUM(ProjectAmount)", ""));
            //decimal SampleAmount = SysConvert.ToDecimal(dt2.Compute("SUM(SampleAmount)", ""));
            //decimal SOAmount = SysConvert.ToDecimal(dt1.Compute("SUM(SOAmount)", ""));
            //txtBillAmount.Text = SysConvert.ToString(SOAmount + SampleAmount);
            //txtActReceAmount.Text = SysConvert.ToString(SOAmount + SampleAmount - ProjectAmount);
        }
        #endregion



        private void drpXL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtShippers_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                //frmLoadShippers frm = new frmLoadShippers();
                //frm.ShowDialog();
                //if (frm.HTLoadData.Count == 1)
                //{
                //    ShipBoat entityCS = new ShipBoat();
                //    entityCS.ID = SysConvert.ToInt32(frm.HTLoadData[0]);
                //    entityCS.SelectByCode();
                //    txtShippers.Text = entityCS.Shippers;

                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtConsignee_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                //frmLoadConsignee frm = new frmLoadConsignee();
                //frm.ShowDialog();
                //if (frm.HTLoadData.Count == 1)
                //{
                //    ShipBoat entityCS = new ShipBoat();
                //    entityCS.ID = SysConvert.ToInt32(frm.HTLoadData[0]);
                //    entityCS.SelectByCode();
                //    txtConsignee.Text = entityCS.Consignee;

                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtMessrs_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                //frmLoadShipMessrs frm = new frmLoadShipMessrs();
                //frm.ShowDialog();
                //if (frm.HTLoadData.Count == 1)
                //{
                //    ShipBoat entityCS = new ShipBoat();
                //    entityCS.ID = SysConvert.ToInt32(frm.HTLoadData[0]);
                //    entityCS.SelectByCode();
                //    txtMessrs.Text = entityCS.Messrs;

                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtNotifyParty_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                //frmLoadNotifyParty frm = new frmLoadNotifyParty();
                //frm.ShowDialog();
                //if (frm.HTLoadData.Count == 1)
                //{
                //    ShipBoat entityCS = new ShipBoat();
                //    entityCS.ID = SysConvert.ToInt32(frm.HTLoadData[0]);
                //    entityCS.SelectByCode();
                //    txtNotifyParty.Text = entityCS.NotifyParty;

                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            string exportfile = string.Empty;
            //TemplateExcel.ExportInvo(HTDataID, out exportfile);
            this.OpenFileNoConfirm(exportfile);
        }


        private void txtShippers_EditValueChanged(object sender, EventArgs e)
        {

        }





    }
}