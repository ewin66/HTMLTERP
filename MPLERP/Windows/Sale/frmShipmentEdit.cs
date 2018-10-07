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

namespace MLTERP
{
    public partial class frmShipmentEdit : frmAPBaseUIFormEdit
    {
        public frmShipmentEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请双击生成发货单号");
                txtCode.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpShipTypeID.EditValue) == 0)
            {
                this.ShowMessage("请选择发货类型");
                drpShipTypeID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("请选择业务员");
                drpSaleOPID.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorOPID.EditValue) == "")
            {
                this.ShowMessage("请选择客户担当");
                drpVendorOPID.Focus();
                return false;
            }
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
            ShipmentDtsRule rule = new ShipmentDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ShipmentRule rule = new ShipmentRule();
            Shipment entity = EntityGet();
            ShipmentDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ShipmentRule rule = new ShipmentRule();
            Shipment entity = EntityGet();
            ShipmentDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Shipment entity = new Shipment();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;
  			drpShipTypeID.EditValue = entity.ShipTypeID; 
  			txtShipDate.DateTime = entity.ShipDate; 
  			txtVendorName.Text = entity.VendorName.ToString(); 
  			txtVendorAddress.Text = entity.VendorAddress.ToString(); 
  			txtVendorTel.Text = entity.VendorTel.ToString(); 
  			txtVendorFax.Text = entity.VendorFax.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpVendorID.EditValue = entity.VendorID; 
  			txtCode.Text = entity.Code.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpCurrencyID.EditValue = entity.CurrencyID; 
  			txtTotalAmount.Text = entity.TotalAmount.ToString(); 
  			txtTotalQty.Text = entity.TotalQty.ToString(); 
  			txtRate.Text = entity.Rate.ToString();
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            drpVendorOPID.EditValue = entity.VendorOPID;

            drpRecVendorID.EditValue = entity.RecVendorID;
            txtRecVendorAddress.Text = entity.RecVendorAddress;


            txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
            txtMakeDate.DateTime = entity.MakeDate; 

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
            ShipmentRule rule = new ShipmentRule();
            Shipment entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID,txtTotalAmount,txtTotalQty }, false);
            
        }

        
        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtShipDate.Text = DateTime.Now.Date.ToShortDateString();
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);

            txtMakeDate.Text = DateTime.Now.Date.ToShortDateString();

            drpCompanyTypeID.EditValue = 1;
            drpCurrencyID.EditValue = (int)EnumCurrency.人民币;//人民币

            txtCode_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_Shipment";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//数据明细校验必须录入字段
         
            Common.BindOP(drpSaleOPID,(int)EnumOPDep.业务部,true);
            Common.BindCurrency(drpCurrencyID, true);//币种
            Common.BindCompanyType(drpCompanyTypeID, true);//绑定公司别
            Common.BindSubTypeShipment(drpShipTypeID, 6, true);//绑定发货类型
            Common.BindCLS(drpYarnStatus, "Sale", "YarnType", true);//纱线形态
            Common.BindYarnType(drpYarnTypeID, true);//纱类

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.面料 }, "", "ItemModel", true, true);


            string p_Conidion = string.Empty;
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                SetPosCondition = " AND VendorID in(Select VendorID FROM UV1_Data_VendorInSaleOP WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                SetPosCondition += "  OR DtsInSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";

                p_Conidion = " AND ( ";
                p_Conidion += " InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion += " OR ID in (Select MainID From Data_VendorInSaleOP where InSaleOP= " + SysString.ToDBString(FParamConfig.LoginID) + ")";
                p_Conidion += ")";

            }
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, p_Conidion, true);//客户
            new VendorProc(drpVendorID, p_Conidion);

            Common.BindVendor(drpRecVendorID, new int[] { (int)EnumVendorType.客户 }, p_Conidion, true);//客户
            new VendorProc(drpRecVendorID, p_Conidion);



            this.ToolBarItemAdd(28, "btnLoad", "加载", false, btnCheckLoad_Click);

            SetTabIndex(0, groupControlMainten);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Shipment EntityGet()
        {
            Shipment entity = new Shipment();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.ShipTypeID = SysConvert.ToInt32(drpShipTypeID.EditValue); 
  			entity.ShipDate = txtShipDate.DateTime.Date; 
  			entity.VendorName = txtVendorName.Text.Trim(); 
  			entity.VendorAddress = txtVendorAddress.Text.Trim(); 
  			entity.VendorTel = txtVendorTel.Text.Trim(); 
  			entity.VendorFax = txtVendorFax.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.VendorID =SysConvert.ToString( drpVendorID.EditValue);
  			entity.Code = txtCode.Text.Trim(); 
  			entity.SaleOPID =SysConvert.ToString( drpSaleOPID.EditValue); 
  			entity.CurrencyID = SysConvert.ToInt32(drpCurrencyID.EditValue); 
  			entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim()); 
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim()); 
  			entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim()); 
  			entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);

            entity.RecVendorID = SysConvert.ToString(drpRecVendorID.EditValue);
            entity.RecVendorAddress = txtRecVendorAddress.Text.Trim();

            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ShipmentDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ShipmentDts[] entitydts = new ShipmentDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ShipmentDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].CompactCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "CompactCode")); 
                    entitydts[index].YarnTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "YarnTypeID")); 
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice")); 
  			 		entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].DesignNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNo")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].YarnStatus = SysConvert.ToString(gridView1.GetRowCellValue(i, "YarnStatus")); 
  			 		entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum")); 
  			 		entitydts[index].IsShipmentFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "IsShipmentFlag")); 
  			 		entitydts[index].ShipmentQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ShipmentQty")); 
  			 		entitydts[index].ShipmentDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "ShipmentDate")); 
  			 		entitydts[index].ShipmentFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "ShipmentFormNo")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        //#region 提交、撤销提交处理
        ///// <summary>
        ///// 提交
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交1))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }
        //        ShipmentRule rule = new ShipmentRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.已提交);
        //        FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 撤销提交
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnSubmitCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交1))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }

        //        ShipmentRule rule = new ShipmentRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交);

        //        FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        //#endregion

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
                //base.btnPreview_Click(sender, e);
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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.预览, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
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
                //base.btnPrint_Click(sender, e);

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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
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
                //base.btnDesign_Click(sender, e);
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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion

        #region 其它事件
        //客户改变事件
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtVendorName.Text = dt.Rows[0]["VendorName"].ToString();
                    txtVendorAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtVendorFax.Text = dt.Rows[0]["Fax"].ToString();
                    txtVendorTel.Text = dt.Rows[0]["Tel"].ToString();
                }
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    Common.BindVendorSaleOPID(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 收货客户改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpRecVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpRecVendorID.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    txtRecVendorAddress.Text = dt.Rows[0]["Address"].ToString();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        //发货单号双击生成
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.发货单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        //价格数量离开计算金额
        private void txtSinglePrice_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal TotalQty = 0.0m;
                decimal TotalMoney = 0.0m;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Qty")) != "")
                    {
                        decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                        decimal DtsUnitPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                        decimal DtsAmount = SysConvert.ToDecimal(Qty * DtsUnitPrice, 2);

                        gridView1.SetRowCellValue(i, "Amount", DtsAmount);

                        TotalQty += Qty;
                        TotalMoney += DtsAmount;
                    }
                }

                txtTotalQty.Text = SysConvert.ToString(TotalQty);
                txtTotalAmount.Text = SysConvert.ToString(TotalMoney);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    //frmSODtsLoad frm = new frmSODtsLoad();
                    //frm.ShowDialog();
                    //if (frm.HTLoadData.Count != 0)
                    //{
                    //    string listStr = ((string[])frm.HTLoadData[2])[0];

                    //   string sql = "Select CompanyTypeID,SOID Code,VendorID,DtsItemCode ItemCode,DtsItemName ItemName,DtsItemStd ItemStd, DtsItemModel ItemModel,UnitPrice Price,Qty, ColorNum,ColorName,''JarNum,YarnTypeID,YarnStatus,";
                    //    sql += "DesignNO,SaleOPID";
                    //    sql += " FROM UV1_Sale_SODts WHERE 1=1 AND" + listStr;
                        

                    //    DataTable dt = SysUtils.Fill(sql);

                    //    for (int k = 0; k < dt.Rows.Count; k++)
                    //    {
                    //        bool FindBlankFlag = false;//是否找到空行
                    //        for (int i = 0; i < gridView1.RowCount; i++)
                    //        {
                    //            if (SysConvert.ToString(gridView1.GetRowCellValue(i, gridView1.Columns["ItemCode"])) == "")
                    //            {
                    //                FindBlankFlag = true;
                    //                gridView1.FocusedRowHandle = i;//聚焦
                    //                btnAddRow_Click(null, null);//插入新行
                    //                break;
                    //            }
                    //        }

                    //        if (!FindBlankFlag)//没有找到 插入一个新行并聚焦
                    //        {
                    //            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    //            btnAddRow_Click(null, null);//插入新行
                    //            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    //        }

                    //        //开始赋值



                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CompactCode", dt.Rows[k]["Code"]);//采购、加工、染色单号            
                  
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemCode", dt.Rows[k]["ItemCode"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemName", dt.Rows[k]["ItemName"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemStd", dt.Rows[k]["ItemStd"]);

                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemModel", dt.Rows[k]["ItemModel"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ColorNum", dt.Rows[k]["ColorNum"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ColorName", dt.Rows[k]["ColorName"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DesignNO", dt.Rows[k]["DesignNO"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "JarNum", dt.Rows[k]["JarNum"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "YarnStatus", dt.Rows[k]["YarnStatus"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "YarnTypeID", dt.Rows[k]["YarnTypeID"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SinglePrice", dt.Rows[k]["Price"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Weight", dt.Rows[k]["Qty"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", dt.Rows[k]["Qty"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Amount", SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[k]["Qty"]) * SysConvert.ToDecimal(dt.Rows[k]["Price"]), 2));


                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Unit", "KG");

                    //    }
                    //    if (dt.Rows.Count != 0)
                    //    {
                    //        drpVendorID.EditValue = dt.Rows[0]["VendorID"].ToString();
                    //        drpCompanyTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["CompanyTypeID"].ToString());
                          
                    //    }

                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 复制单据时产生当前日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMakeDate_DoubleClick(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.新增)
            {
                txtMakeDate.DateTime = DateTime.Now.Date;
            }
        }
        #endregion

       
    

   


    }
}