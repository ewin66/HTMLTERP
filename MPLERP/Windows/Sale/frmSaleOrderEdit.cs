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
using DevExpress.XtraGrid.Views.Base;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：销售订单编辑
    /// 作者：陈加海
    /// 日期：2014-4
    /// 
    /// 
    /// 2014-5-21
    /// 修改增加一个转换模式
    /// 录入订单可能有多个单位的数量 InputQty InputUnit
    /// 保存时依据Enum_Unit定义的单位转换规则进行转换表基础单位 后转为为基础单位，再依据克重进行转换
    /// 涉及到参数为 5405 转换功能开启 5406 转换后单位
    /// 后续业务单据全部使用转换后单位操作，只有到了发货环节重新进行处理
    /// 
    /// </summary>
    public partial class frmSaleOrderEdit : frmAPBaseUIFormEdit
    {
        public frmSaleOrderEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入合同号");
                txtFormNo.Focus();
                return false;
            }

            if (Common.CheckSearchLookUpEditBlank(drpVendorID))
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return false;
            }

            if (Common.CheckLookUpEditBlank(drpOrderTypeID))
            {
                this.ShowMessage("请选择订单类型");
                drpOrderTypeID.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpPayMothodFlag.EditValue) == 0)
            {
                this.ShowMessage("请选择付款方式");
                drpPayMothodFlag.Focus();
                return false;
            }

            if (drpSaleFlowModuleID.Visible)
            {
                if (Common.CheckLookUpEditBlank(drpSaleFlowModuleID))
                {
                    this.ShowMessage("请选择流程模式");
                    drpSaleFlowModuleID.Focus();
                    return false;
                }
            }



            if (!this.CheckCorrectDts())
            {
                return false;
            }

            //if (!this.CheckSOCorrect())// 检验订单是否重复
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// 检验订单是否重复
        /// </summary>
        /// <returns></returns>
        //private bool CheckSOCorrect()
        //{
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //        {
        //            for (int j = 0; j < gridView1.RowCount; j++)
        //            {
        //                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //                {
        //                    if (i != j && SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorNum")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorName")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWeight")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWidth")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsReqDate")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "DtsReqDate")))
        //                    {
        //                        this.ShowMessage("第" + SysConvert.ToString(SysConvert.ToInt32(i + 1)) + "行数据与第" + SysConvert.ToString(SysConvert.ToInt32(j + 1)) + "行数据重复,产品编号.色号.颜色.门幅.克重.交期一致,请检查后重新保存");
        //                        return false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            SaleOrderDtsRule rule = new SaleOrderDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            SaleOrderDts[] entitydts = EntityDtsGet();
            SaleOrderProcedureDts[] entityProcedureDts = EntityProcedureDtsGet();

            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            entity.OrderStepID = (int)EnumOrderStep.新单;
            rule.RAdd(entity, entitydts, entityProcedureDts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            SaleOrderDts[] entitydts = EntityDtsGet();
            SaleOrderProcedureDts[] entityProcedureDts = EntityProcedureDtsGet();

            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entityProcedureDts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SaleOrder entity = new SaleOrder();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo;
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpVendorID.EditValue = entity.VendorID;
            drpVendorOPID.EditValue = entity.VendorOPID;
            drpOrderLevelID.EditValue = entity.OrderLevelID;
            drpOrderTypeID.EditValue = entity.OrderTypeID;
            txtReqDate.DateTime = entity.ReqDate;
            txtOrderDate.DateTime = entity.OrderDate;
            txtCustomerCode.Text = entity.CustomerCode.ToString();
            txtPayMethodID.Text = entity.PayMethodID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtContractDesc.Text = entity.ContractDesc.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            drpWLAmountType.EditValue = entity.WLAmountType;
            txtWLAmount.Text = entity.WLAmount.ToString();
            drpSaleFlowModuleID.EditValue = entity.SaleFlowModuleID;
            drpSaleOPID.EditValue = entity.SaleOPID;

            drpCurrency.EditValue = entity.Currency;

            drpVTel.EditValue = entity.VTel;
            drpVFax.EditValue = entity.VFax;
            drpVAddress.EditValue = entity.VAddress;
            txtCustomerCode2.Text = entity.CustomerCode2.ToString();
            txtEngAmount.Text = entity.EngAmount.ToString();

            chkConvertUnitFlag.Checked = SysConvert.ToBoolean(entity.ConvertUnitFlag);//转换标志
            if (!findFlag)
            {

            }


            BindGridDts();
            BindOrderInfo();
            BindOrderProcedureDts();
        }


        void BindOrderInfo()
        {
            ucOrderInfo1.OrderTypeID = 1;
            ucOrderInfo1.OrderNo = txtFormNo.Text.Trim();
            ucOrderInfo1.IniData();
        }

        /// <summary>
        /// 绑定流程明细
        /// </summary>
        void BindOrderProcedureDts()
        {
            SaleOrderProcedureDtsRule rule = new SaleOrderProcedureDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID);
            SetCheckProcedure(chklSaleProcedure, dt);
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
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            chklSaleProcedure.Enabled = false;

            ProcessGrid.SetGridEdit(gridView1, new string[] { "InputAmount", "Amount" }, false);


            if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5419)) == 1)//订单号生成模式0 手动输入； 1 自动生成；  2 员工代码+年份流水号
            {
                ProductCommon.FormNoCtlEditSet(txtFormNo, "Sale_SaleOrder", "FormNo", 0, p_Flag);
            }


            if (p_Flag)//如果编辑状态绑定下颜色的选择
            {
                BindGridColor();
            }
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtOrderDate.DateTime = DateTime.Now.Date;
            ParamSetRule psrule = new ParamSetRule();
            txtReqDate.DateTime = DateTime.Now.Date.AddDays(psrule.RShowIntByCode((int)ParamSetEnum.销售合同交期自动延后天数)).Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
            drpSaleOPID.EditValue = FParamConfig.LoginID;

            drpCurrency.EditValue = "USD";//币种默认美金
            drpOrderTypeID.Text = "外销大货";
            drpOrderLevelID.Text = "普通";

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrder";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode", "Qty", "Unit", "DtsReqDate" };//数据明细校验必须录入字段

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
            {
                this.HTCheckDataField = new string[] { "ItemCode", "InputQty", "InputUnit", "DtsReqDate" };//数据明细校验必须录入字段
            }
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载面料", false, btnLoad_Click);
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5407)))//销售订单算料按钮隐藏
            {
                btnYarnCalc.Visible = false;
                btnFabricCalc.Visible = false;
            }
            else if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5402)))//销售订单复合布算料按钮显示，同时控制成品采购加载复合布算料按钮
            {
                btnFabricCompSiteCalc.Visible = true;
            }
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5404)))//销售订单使用下单数量制单时确定是否需要单位转换模式及计算方法类型;默认否，此功能设置为是时，5405应设置为0，但5406有效；字符串值设置套用的转换公式类型0/1:默认公式/公式模式二/
            {
                chkConvertUnitFlag.Visible = true;
            }
            else
            {
                chkConvertUnitFlag.Visible = false;
            }
            if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) != 0)//销售订单显示库存信息 0：不显示库存; 1：显示库存信息;2:只显示纱线库存;3：只显示坯布库存;4只显示成品库存
            {
                xtraTabControl1.Visible = true;

                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) == 2)
                {
                    xtraTabPage1.PageVisible = true;//纱线库存
                    xtraTabPage2.PageVisible = false;//坯布库存
                    xtraTabPage3.PageVisible = false;//成品库存
                }
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) == 3)
                {
                    xtraTabPage1.PageVisible = false;//纱线库存
                    xtraTabPage2.PageVisible = true;//坯布库存
                    xtraTabPage3.PageVisible = false;//成品库存
                }
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) == 4)
                {
                    xtraTabPage1.PageVisible = false;//纱线库存
                    xtraTabPage2.PageVisible = false;//坯布库存
                    xtraTabPage3.PageVisible = true;//成品库存
                }

            }
            else
            {
                xtraTabControl1.Visible = false;
            }
            chklSaleProcedure.BackColor = this.BackColor;//特殊控件背景色处理
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5420)))//销售订单流程模式隐藏
            {
                drpSaleFlowModuleID.Visible = false;
                chklSaleProcedure.Location = new System.Drawing.Point(195, 627);
                lbSalePro.Visible = false;
            }
        }


        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindOrderType(drpOrderTypeID, true);
            Common.BindOrderLevel(drpOrderLevelID, true);
            Common.BindWLAmount(drpWLAmountType, true);
            Common.BindPayMethod(drpPayMothodFlag, true);
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindSaleFlowModule(drpSaleFlowModuleID, true);
            Common.BindSaleProcedure(chklSaleProcedure, false);
            Common.BindSOContext(drpSOContext, "销售", true);
            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);
            DevMethod.BindItem(drpItemCode, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.业务部 }, true);
        }

        private void gridViewRowChanged1(object sender)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GoodsCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));
                //Common.BindItemSalePrice(txtItemSalePrice, ItemCode, GoodsCode, ColorNum, ColorName, true);
                // this.ShowMessage(view.FocusedRowHandle.ToString());
                BindGridColor();


                if (xtraTabControl1.Visible == true)
                {
                    ShowStorgeInfo(ItemCode);
                }
                this.gridView1.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 绑定数据列表内的颜色控件
        /// </summary>
        void BindGridColor()
        {
            if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//新增和修改，绑定颜色和色号
            {
                string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                Common.BindItemColor(drpGridColorNum, drpGridColorName, itemCode, true);//根据物料绑定色号色名
            }
        }

        /// <summary>
        /// 显示库存信息
        /// </summary>
        private void ShowStorgeInfo(string p_ItemCode)
        {
            try
            {
                int PItemType = 0;
                string sql = "select * from Data_Item where ItemCode=" + SysString.ToDBString(p_ItemCode);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    PItemType = SysConvert.ToInt32(dt.Rows[0]["ItemTypeID"]);
                    string GreyFabItemCode = SysConvert.ToString(dt.Rows[0]["GreyFabItemCode"]);

                    if (PItemType == (int)EnumItemType.面料)
                    {
                        sql = "SELECT Sum(Qty) SQty,ColorNum,ColorName FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//查询色纱库存            
                        sql += " GROUP BY ColorNum,ColorName ORDER BY SQty DESC";
                        DataTable dtS = SysUtils.Fill(sql);
                        decimal tqty = 0;
                        string tstr = string.Empty;
                        foreach (DataRow dr in dtS.Rows)
                        {
                            tqty += SysConvert.ToDecimal(dr["SQty"]);

                            tstr += Environment.NewLine + "色号/颜色：" + dr["ColorNum"].ToString() + "/" + dr["ColorName"].ToString() + " 数量：" + SysConvert.ToDecimal(dr["SQty"]);


                        }

                        tstr = "库存合计:" + tqty.ToString() + tstr;//明细：
                        txtWHStorgeQtyCP.Text = tstr;


                        sql = "SELECT Sum(Qty) SQty,Batch FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(GreyFabItemCode);//坯布库存            
                        sql += " GROUP BY Batch ORDER BY SQty DESC";
                        dtS = SysUtils.Fill(sql);
                        tqty = 0;
                        tstr = string.Empty;
                        foreach (DataRow dr in dtS.Rows)
                        {
                            tqty += SysConvert.ToDecimal(dr["SQty"]);

                            tstr += Environment.NewLine + "批号：" + dr["Batch"].ToString() + " 数量：" + SysConvert.ToDecimal(dr["SQty"]);
                        }
                        tstr = "库存合计:" + tqty.ToString() + tstr;//明细：
                        txtWHStorgePB.Text = tstr;









                    }

                    if (PItemType == (int)EnumItemType.坯布)
                    {
                        sql = "SELECT Sum(Qty) SQty,Batch FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//查询色纱库存            
                        sql += " GROUP BY Batch ORDER BY SQty DESC";
                        DataTable dtS = SysUtils.Fill(sql);
                        decimal tqty = 0;
                        string tstr = string.Empty;
                        foreach (DataRow dr in dtS.Rows)
                        {
                            tqty += SysConvert.ToDecimal(dr["SQty"]);

                            tstr += Environment.NewLine + "批号：" + dr["Batch"].ToString() + " 数量：" + SysConvert.ToDecimal(dr["SQty"]);


                        }

                        tstr = "库存合计:" + tqty.ToString() + tstr;//明细：

                        txtWHStorgePB.Text = tstr;
                    }



                    decimal tqtySX = 0;
                    string tstrSX = string.Empty;
                    sql = "Select * from Data_ItemDts where MainID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    sql += " AND DtsItemCode<>''";
                    DataTable dtY = SysUtils.Fill(sql);
                    if (dtY.Rows.Count != 0)
                    {
                        tstrSX = string.Empty;

                        for (int i = 0; i < dtY.Rows.Count; i++)
                        {

                            sql = "SELECT Sum(Qty) SQty FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(SysConvert.ToString(dtY.Rows[i]["DtsItemCode"]));//纱线            
                            sql += "  ORDER BY SQty DESC";
                            DataTable dtS = SysUtils.Fill(sql);

                            //tqtySX = 0;
                            tstrSX += Environment.NewLine + "纱线品名：" + SysConvert.ToString(dtY.Rows[i]["DtsItemModel"]);
                            if (dtS.Rows.Count != 0)
                            {
                                foreach (DataRow dr in dtS.Rows)
                                {
                                    tqtySX += SysConvert.ToDecimal(dr["SQty"]);

                                    tstrSX += Environment.NewLine + " 数量：" + SysConvert.ToDecimal(dr["SQty"]);
                                }
                            }
                            else
                            {
                                tstrSX += Environment.NewLine + " 数量：0";
                            }

                        }
                        tstrSX = "库存合计:" + tqtySX.ToString() + tstrSX;//明细：
                        txtWHStorgeQtySX.Text = tstrSX;
                    }
                }


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
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
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime;
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.OrderLevelID = SysConvert.ToInt32(drpOrderLevelID.EditValue);
            entity.OrderTypeID = SysConvert.ToInt32(drpOrderTypeID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
            entity.OrderDate = txtOrderDate.DateTime;
            entity.ReqDate = txtReqDate.DateTime;
            entity.PayMethodID = txtPayMethodID.Text.Trim();
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.ContractDesc = txtContractDesc.Text.Trim();
            entity.CustomerCode = txtCustomerCode.Text.Trim();
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.WLAmountType = SysConvert.ToInt32(drpWLAmountType.EditValue);
            entity.WLAmount = SysConvert.ToDecimal(txtWLAmount.Text.Trim());
            entity.SaleFlowModuleID = SysConvert.ToInt32(drpSaleFlowModuleID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.ConvertUnitFlag = SysConvert.ToInt32(chkConvertUnitFlag.Checked);

            entity.Currency = SysConvert.ToString(drpCurrency.EditValue);
            entity.VTel = SysConvert.ToString(drpVTel.EditValue);
            entity.VFax = SysConvert.ToString(drpVFax.EditValue);
            entity.VAddress = SysConvert.ToString(drpVAddress.EditValue);
            entity.CustomerCode2 = txtCustomerCode2.Text.Trim();
            entity.EngAmount = txtEngAmount.Text.Trim();
            entity.FAID = 1;
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrderDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            SaleOrderDts[] entitydts = new SaleOrderDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new SaleOrderDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].AllMWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "AllMWidth"));

                    entitydts[index].FAmount1 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount1"));
                    entitydts[index].FAmount2 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount2"));
                    entitydts[index].FAmount3 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount3"));
                    entitydts[index].FAmount4 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount4"));
                    entitydts[index].FAmount5 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount5"));

                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));//款号

                    entitydts[index].InputQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputQty"));
                    entitydts[index].InputUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "InputUnit"));
                    entitydts[index].InputSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputSinglePrice"));
                    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].FAmount1 + entitydts[index].FAmount2 + entitydts[index].FAmount3 + entitydts[index].FAmount4 + entitydts[index].FAmount5;
                    entitydts[index].InputConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputConvertXS"));

                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));

                    entitydts[index].Amount = entitydts[index].SingPrice * entitydts[index].Qty + entitydts[index].FAmount1 + entitydts[index].FAmount2 + entitydts[index].FAmount3 + entitydts[index].FAmount4 + entitydts[index].FAmount5;
                    entitydts[index].DtsReqDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "DtsReqDate"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
                    entitydts[index].OutRange = SysConvert.ToString(gridView1.GetRowCellValue(i, "OutRange"));
                    entitydts[index].FK = SysConvert.ToString(gridView1.GetRowCellValue(i, "FK"));
                    entitydts[index].MaxQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MaxQty"));
                    entitydts[index].MinQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MinQty"));
                    entitydts[index].ReqDateEdit = SysConvert.ToString(gridView1.GetRowCellValue(i, "ReqDateEdit"));


                    if (chkConvertUnitFlag.Checked || SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//2014.6.22 支持界面勾选判定是否需要转换  或 参数设置了 转换为默认单位模式开启,目前支持转换为公斤模式
                    {
                        string unitdefault = SysConvert.ToString(ProductParamSet.GetStrValueByID(5406));//转换后默认单位
                        if (unitdefault != string.Empty)
                        {
                            entitydts[index].Unit = unitdefault;//赋值转换后单位
                        }

                        int calMode = -1;//计算公式类型
                        string baseUnit = string.Empty;
                        decimal baseQty = ProductCommon.UnitConvertValueBaseUnit(entitydts[index].InputUnit, entitydts[index].InputQty, out baseUnit);
                        if (baseUnit != entitydts[index].Unit)//和基础单位不一致，要换算
                        {
                            //目前换算的全部是数量转换为重量KG
                            decimal convertQty = 0;
                            if (chkConvertUnitFlag.Checked)//使用制单计算用公式
                            {
                                calMode = SysConvert.ToInt32(ProductParamSet.GetStrValueByID(5404));//销售订单使用下单数量制单时确定是否需要单位转换模式及计算方法类型
                                switch (calMode)
                                {
                                    case 0://不计算
                                        break;
                                    case 1://方法一
                                        // convertQty = ProductCommon.UnitConvertMiToKG1ST(baseQty, entitydts[index].MWidth, entitydts[index].MWeight);
                                        break;
                                    case 2://方法二
                                        // convertQty = ProductCommon.UnitConvertMiToKG2ND(baseQty, entitydts[index].MWidth, entitydts[index].MWeight);//后续扩充参数配置，目前方法会保留好
                                        break;
                                    case 10://方法十
                                        convertQty = ProductCommon.UnitConvertMiToUnit10Ten(entitydts[index].InputQty, entitydts[index].InputConvertXS);//转换系数直接计算
                                        break;
                                }

                            }
                            else
                            {
                                //  convertQty = ProductCommon.UnitConvertMiToKG2ND(baseQty, entitydts[index].MWidth, entitydts[index].MWeight);//后续扩充参数配置，目前方法会保留好
                            }
                            entitydts[index].Qty = SysConvert.ToDecimal(convertQty, 2);//转换后数量


                        }
                        else//一致，不用换算，但要重新赋值最终数量、单价及金额
                        {
                            entitydts[index].Qty = SysConvert.ToDecimal(baseQty, 2);
                        }

                        if (calMode != 10)//方法十是不用管系数的,本身就是根据订单录入系数直接换算的
                        {
                            if (entitydts[index].InputQty != 0)
                            {
                                entitydts[index].InputConvertXS = SysConvert.ToDecimal(entitydts[index].Qty / entitydts[index].InputQty, 4);
                            }
                            else
                            {
                                entitydts[index].InputConvertXS = 0;
                            }
                        }
                        if (entitydts[index].InputConvertXS != 0)
                        {
                            entitydts[index].SingPrice = SysConvert.ToDecimal(entitydts[index].InputSinglePrice / entitydts[index].InputConvertXS, 2);
                        }

                        entitydts[index].Amount = entitydts[index].InputAmount;
                    }
                    else//不转换则
                    {
                        if (gridView1.Columns["InputQty"].Visible)//下单可见
                        {
                            entitydts[index].Qty = entitydts[index].InputQty;
                            entitydts[index].SingPrice = entitydts[index].InputSinglePrice;
                            entitydts[index].Unit = entitydts[index].InputUnit;
                            entitydts[index].Amount = entitydts[index].InputAmount;
                        }
                    }



                    if (this.HTFormStatus == FormStatus.新增 || entitydts[index].ID == 0)//编辑状态下新增明细记录
                    {
                        entitydts[index].OrderStepID = (int)EnumOrderStep.新单;
                    }

                    index++;
                }
            }
            return entitydts;
        }


        #region 流程模式相关
        /// <summary>
        /// 设置已选项
        /// </summary>
        /// <param name="p_CheckList"></param>
        private void SetCheckProcedure(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList, DataTable p_Dt)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (DataRow dr in p_Dt.Rows)//遍历记录
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr["SaleProcedureID"].ToString() == p_CheckList.GetItemValue(i).ToString())//值相等
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 获得明细实体
        /// </summary>
        /// <returns></returns>
        private SaleOrderProcedureDts[] EntityProcedureDtsGet()
        {
            int num = 0;
            for (int i = 0; i < chklSaleProcedure.ItemCount; i++)
            {
                if (chklSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    num++;
                }
            }

            SaleOrderProcedureDts[] entityA = new SaleOrderProcedureDts[num];
            num = 0;
            for (int i = 0; i < chklSaleProcedure.ItemCount; i++)
            {
                if (chklSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    entityA[num] = new SaleOrderProcedureDts();
                    entityA[num].MainID = HTDataID;
                    entityA[num].Seq = num + 1;
                    entityA[num].SaleProcedureID = SysConvert.ToInt32(chklSaleProcedure.GetItemValue(i));
                    num++;
                }
            }
            return entityA;
        }

        #endregion

        #endregion


        #region 提交、撤销提交处理
        /// <summary>
        /// 提交
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

                if (!CheckCalc())
                {
                    return;
                }

                SaleOrderRule rule = new SaleOrderRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.已提交, this.FormID, this.FormListAID, this.FormListBID);
                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 提交算料检查
        /// </summary>
        /// <returns></returns>
        private bool CheckCalc()
        {
            bool calCheckFlag = true;//是否校验算料,默认是校验的
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5407)))//销售订单算料按钮隐藏
            {
                calCheckFlag = false;
            }
            else if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5408)))//销售订单提交时不验证是否算料
            {
                calCheckFlag = false;
            }
            if (calCheckFlag)//校验算料
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (CheckCalcProcedureNeedCheck(new int[] { (int)EnumSaleProcedure.纱线采购单, (int)EnumSaleProcedure.染纱加工单 }))//纱线采购/染纱加工才需要算料
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YarnCalcFlag")) == 0)
                        {
                            this.ShowMessage("第" + SysConvert.ToInt32(i + 1).ToString() + "行没有进行纱线算料，请检查！");
                            return false;
                        }
                    }
                    if (CheckCalcProcedureNeedCheck(new int[] { (int)EnumSaleProcedure.坯布采购单 }))//坯布采购才需要算料
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FabricCalcFlag")) == 0)
                        {
                            this.ShowMessage("第" + SysConvert.ToInt32(i + 1).ToString() + "行没有进行坯布算料，请检查！");
                            return false;
                        }
                    }

                    if (CheckCalcProcedureNeedCheck(new int[] { (int)EnumSaleProcedure.成品采购单 }))//成品采购且品种是复合布才需要算复合算料
                    {
                        int fabtypeID = ProductCommon.ItemControlGetFabricType(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode")));
                        if (fabtypeID == (int)EnumFabricType.复合面料)
                        {
                            if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CompSiteCalFlag")) == 0)
                            {
                                this.ShowMessage("第" + SysConvert.ToInt32(i + 1).ToString() + "行没有进行复合算料，请检查！");
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 检测提交算料是否需要校验
        /// </summary>
        /// <param name="p_ProcedureIDA"></param>
        /// <returns></returns>
        private bool CheckCalcProcedureNeedCheck(int[] p_ProcedureIDA)
        {
            bool outb = false;
            for (int i = 0; i < chklSaleProcedure.ItemCount; i++)
            {
                if (chklSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    for (int j = 0; j < p_ProcedureIDA.Length; j++)
                    {
                        if (SysConvert.ToInt32(chklSaleProcedure.GetItemValue(i)) == p_ProcedureIDA[j])//如果找到，跳出循环
                        {
                            outb = true;
                            break;
                        }
                    }
                }
                if (outb)//如果找到，跳出循环
                {
                    break;
                }
            }
            return outb;
        }

        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
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

                SaleOrderRule rule = new SaleOrderRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交, this.FormID, this.FormListAID, this.FormListBID);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 其它事件
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.合同号);

                    if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5419)) == 1)//订单号生成模式0 手动输入； 1 自动生成；  2 员工代码+年份流水号
                    {
                        ProductCommon.FormNoIniSet(txtFormNo, "Sale_SaleOrder", "FormNo", 0);
                    }
                    else if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5419)) == 2)
                    {
                        if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
                        {
                            string sql = "Select OPCode from Data_OP Where OPID = " + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
                            DataTable dt = SysUtils.Fill(sql);
                            if (dt.Rows.Count == 1)
                            {
                                string OPCode = SysConvert.ToString(dt.Rows[0]["OPCode"]);//员工代号                               
                                string FormNo = OPCode + DateTime.Now.Date.ToString("yyMM");//合同号                               
                                sql = "Select ISNULL(Max(FormNo),'') FormNo from Sale_SaleOrder Where FormNo Like " + SysString.ToDBString(FormNo + "%");
                                DataTable dtFormNo = SysUtils.Fill(sql);
                                if (dtFormNo.Rows.Count == 1)
                                {
                                    string MaxFormNo = SysConvert.ToString(dtFormNo.Rows[0]["FormNo"]);
                                    if (MaxFormNo != string.Empty)
                                    {
                                        int Sort = SysConvert.ToInt32(MaxFormNo.Substring(MaxFormNo.Length - 3, 3)) + 1;
                                        txtFormNo.Text = FormNo + SysString.LongToStr(Sort, 3);
                                    }
                                    else
                                    {
                                        txtFormNo.Text = FormNo + "001";
                                    }
                                }

                            }

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
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                restxtItemCode_DoubleClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 双击产品编码加载产品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.SelectItemType = SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5413)); //0：表示只支持加载产品  1：表示只支持选择加载产品或者坯布  2:表示坯布


                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {

                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNews(str);
                    }
                    gridViewRowChanged1(gridView1);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string str)
        {

            int setRowID = Common.GetNewRow(gridView1, "ItemCode");
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "FK", SysConvert.ToString(dt.Rows[0]["FK"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    setRowID++;
                }
            }
        }

        private int checkRowSet()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == string.Empty)
                {
                    index = i;
                    return index;
                }
            }
            return index;

        }

        /// <summary>
        /// 选择合同内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSOContext_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Context FROM Data_SOContext WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpSOContext.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtContractDesc.Text = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void frmSaleOrderEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    SaleOrder entity = new SaleOrder();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    if (entity.SubmitFlag == 0)
                    {
                        if (DialogResult.Yes != ShowConfirmMessage(this.Text + Environment.NewLine + "没有提交单据,是否确认关闭窗体"))
                        {
                            e.Cancel = true;
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
        /// 纱线算料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYarnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存数据后填写合同内容");
                    return;
                }
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    return;
                }
                //if (HTDataSubmitFlag == (int)YesOrNo.Yes)
                //{
                //    this.ShowMessage("单据已提交，不允许算料");
                //    return;
                //}
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                int DID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frmSaleItem2 frm = new frmSaleItem2();
                frm.ID = HTDataID;
                frm.DID = DID;
                frm.SO = txtFormNo.Text.Trim();
                frm.ShowDialog();
                BindGridDts();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { DID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 坯布算料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricCalc_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存数据后算料");
                    return;
                }
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    return;
                }

                //if (HTDataSubmitFlag == (int)YesOrNo.Yes)
                //{
                //    this.ShowMessage("单据已提交，不允许算料");
                //    return;
                //}
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                int DID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frmSaleFabric frm = new frmSaleFabric();
                frm.ID = HTDataID;
                frm.DID = DID;
                frm.SO = txtFormNo.Text.Trim();
                frm.ShowDialog();
                BindGridDts();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { DID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 复合布算料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricCompSiteCalc_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存数据后算料");
                    return;
                }
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    return;
                }
                //if (HTDataSubmitFlag == (int)YesOrNo.Yes)
                //{
                //    this.ShowMessage("单据已提交，不允许算料");
                //    return;
                //}
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                int DID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frmSaleFabricCompSite frm = new frmSaleFabricCompSite();
                frm.ID = HTDataID;
                frm.DID = DID;
                frm.SO = txtFormNo.Text.Trim();
                frm.ShowDialog();
                BindGridDts();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { DID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSaleFlowModuleID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//编辑状态下读取模式值
                {
                    int flowID = SysConvert.ToInt32(drpSaleFlowModuleID.EditValue);
                    SaleFlowModuleDtsRule dtsrule = new SaleFlowModuleDtsRule();
                    DataTable dt = dtsrule.RShow(" AND MainID=" + flowID);
                    SetCheckProcedure(chklSaleProcedure, dt);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        /// <summary>
        /// 值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {

                    Common.BindVendorContact(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
                    Common.BindVendorAddress(drpVAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




        /// <summary>
        /// 值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)
                {
                    if (e.Column.FieldName == "ItemCode")
                    {
                        ColumnView view = sender as ColumnView;
                        string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                        string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 1)
                        {
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemName", dt.Rows[0]["ItemName"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemStd", dt.Rows[0]["ItemStd"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemModel", dt.Rows[0]["ItemModel"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "Unit", dt.Rows[0]["ItemUnit"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "Needle", dt.Rows[0]["Needle"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "WeightUnit", dt.Rows[0]["WeightUnit"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "FK", dt.Rows[0]["FK"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWidth", dt.Rows[0]["MWidth"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWeight", dt.Rows[0]["MWeight"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"]);
                        }

                    }
                }

                if (e.Column.FieldName == "ColorNum")//色号改变，检索赋值色名
                {
                    ColumnView view = sender as ColumnView;
                    string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                    string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                    view.SetRowCellValue(view.FocusedRowHandle, "ColorName", Common.GetItemColorNameByColorNum(ItemCode, ColorNum));

                }

                if (e.Column.FieldName == "SingPrice" || e.Column.FieldName == "Qty")
                {
                    ColumnView view = sender as ColumnView;
                    decimal singprice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SingPrice"));
                    decimal qty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Qty"));
                    decimal Amount = SysConvert.ToDecimal(singprice * qty, 2);
                    view.SetRowCellValue(view.FocusedRowHandle, "Amount", Amount);

                }
                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5414)))//修改下单数量,单价或者额外费用时自动计算金额
                {
                    if (e.Column.FieldName == "InputQty" || e.Column.FieldName == "InputSinglePrice" || e.Column.FieldName == "FAmount1"
                        || e.Column.FieldName == "FAmount2" || e.Column.FieldName == "FAmount3" || e.Column.FieldName == "FAmount4" || e.Column.FieldName == "FAmount5")
                    {
                        ColumnView view = sender as ColumnView;
                        decimal InputQty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputQty"));
                        decimal InputSinglePrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputSinglePrice"));
                        decimal FAmount1 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount1"));
                        decimal FAmount2 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount2"));
                        decimal FAmount3 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount3"));
                        decimal FAmount4 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount4"));
                        decimal FAmount5 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount5"));
                        decimal Amount = InputQty * InputSinglePrice + FAmount1 + FAmount2 + FAmount3 + FAmount4 + FAmount5;
                        view.SetRowCellValue(view.FocusedRowHandle, "Amount", Amount);
                        view.SetRowCellValue(view.FocusedRowHandle, "InputAmount", Amount);

                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 合同付款方式
        /// <summary>
        /// 合同付款方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateSaleOrderPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存合同后维护付款方式");
                    return;
                }
                frmUpdateSaleOrderPay frm = new frmUpdateSaleOrderPay();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(380, 180);
                frm.ID = HTDataID;
                frm.FormNo = txtFormNo.Text.Trim();
                frm.Amount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                frm.ShowDialog();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void txtQty_Leave_1(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));
                decimal OutRange = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OutRange"));
                if (OutRange > 0)
                {
                    decimal MaxQty = Qty * (1m + (OutRange / 100m));
                    decimal MinQty = Qty * (1m - (OutRange / 100m));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MaxQty", MaxQty);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MinQty", MinQty);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpVendorOPID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    drpVTel.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPID.EditValue));
                    drpVFax.Text = Common.GetVendorContactFAXByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPID.EditValue));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
                gridView1.FocusedRowHandle = 0;
                gridView1.FocusedColumn = gridView1.Columns["ItemCode"];
                gridView1.ShowEditor();
            }
        }













    }
}