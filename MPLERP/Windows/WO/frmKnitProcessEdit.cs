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
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 织造指示单
    /// 
    /// 说明1：只支持单品种的坯布
    /// 
    /// </summary>
    public partial class frmKnitProcessEdit : frmAPBaseUIFormEdit
    {
        public frmKnitProcessEdit()
        {
            InitializeComponent();
        }


        int saveNoLoadCheckDayNum = 0;//未加载比对天数，防止随着时间的推移系统变慢

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入加工单号");
                txtFormNo.Focus();
                return false;
            }

            //if (SysConvert.ToString(drpVendorID.EditValue) == "")
            //{
            //    this.ShowMessage("请选择供应商");
            //    drpVendorID.Focus();
            //    return false;
            //}

            if (SysConvert.ToString(drpDyeFactorty.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择加工厂");
                drpDyeFactorty.Focus();
                return false;
            }

            if (!CheckCorrectDts())
            {
                return false;
            }

            if (!CheckCorrectDtsAttach())
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 附加验证
        /// </summary>
        /// <returns></returns>
        public bool CheckCorrectDtsAttach()
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
            //    if (ItemCode != "")
            //    {
            //        string sql = "SELECT * FROM UV1_WO_FabricProcessDts WHERE OrderFormNo+ItemCode=" + SysString.ToDBString(txtOrderFormNo.Text.Trim() + ItemCode);
            //        DataTable dt = SysUtils.Fill(sql);
            //        if (dt.Rows.Count > 0)
            //        {
            //            if (MessageBox.Show("合同号" + txtOrderFormNo.Text.Trim() + ",产品编码：" + ItemCode + "的合同已染色，还要继续加工吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //}
            return true;
        }

        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            FabricProcessDtsRule rule = new FabricProcessDtsRule();
            DataTable dtDts = rule.RShowYS(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            //  Common.AddDtRow(dtDts, 1);//只显示一行Gridview
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public void BindGridItemDts()
        {
            FabricProcessItemDtsRule rule = new FabricProcessItemDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));

            gridView2.GridControl.DataSource = dtDts;
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FabricProcessRule rule = new FabricProcessRule();
            FabricProcess entity = EntityGet();
            FabricProcessDts[] entitydts = EntityDtsGet();
            FabricProcessItemDts[] entityitemdts = GetFabricProcessItemDts();
            decimal totalqty = 0;
            decimal totalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
                totalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts, entityitemdts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FabricProcessRule rule = new FabricProcessRule();
            FabricProcess entity = EntityGet();
            FabricProcessDts[] entitydts = EntityDtsGet();
            FabricProcessItemDts[] entityitemdts = GetFabricProcessItemDts();
            decimal totalqty = 0;
            decimal totalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
                totalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entityitemdts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo;
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtFormDate.DateTime = entity.FormDate.Date;
            //drpVendorID.EditValue = entity.VendorID;
            //drpOrderLevelID.EditValue = entity.OrderLevelID;
            //drpOrderTypeID.EditValue = entity.OrderTypeID;
            txtReqDate.DateTime = entity.ReqDate;
            //txtOrderDate.DateTime = entity.OrderDate;
            txtOrderFormNo.Text = entity.OrderFormNo;
            //txtCustomerCode.Text = entity.CustomerCode.ToString();
            //txtPayMethodID.Text = entity.PayMethodID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtContractDesc.Text = entity.ContractDesc.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            //drpWLAmountType.EditValue = entity.WLAmountType;
            //txtWLAmount.Text = entity.WLAmount.ToString();
            txtOrderTypeName.Text = entity.OrderType;
            drpDyeFactorty.EditValue = entity.DyeFactorty.ToString();
            //txtRSTec.Text = entity.DyeingTec.ToString();
            //txtBuyerReq.Text = entity.DyeingReq.ToString();
            //chkLightSource.Text = entity.LightSource.ToString();
            //txtSGReq.Text = entity.SGReq.ToString();
            //txtSendAddr.Text = entity.SendAddress.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();

            txtGYRequire.Text = entity.GYRequire.ToString();
            txtLoss.Text = entity.Loss.ToString();
            txtBiLi.Text = entity.BiLi.ToString();
            drpYHStyle.EditValue = entity.YHStyle;

            drpOrderVendorID.EditValue = entity.VendorID;

            if (!findFlag)
            {

            }

            BindGridDts();
            BindOrderInfo();
            BindGridItemDts();


            //ProductCommon.JGButtonStatusSet(HTFormStatus, HTDataSubmitFlag, HTDataID, btnJGKL);//设置扣料按钮状态
        }


        void BindOrderInfo()
        {
            //ucOrderInfo1.OrderTypeID = 2;
            //ucOrderInfo1.OrderNo = txtFormNo.Text.Trim();
            //ucOrderInfo1.IniData();
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FabricProcessRule rule = new FabricProcessRule();
            FabricProcess entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "WO_FabricProcess", "FormNo", 2, p_Flag);


            //  ProductCommon.JGButtonStatusSet(HTFormStatus, HTDataSubmitFlag, HTDataID, btnJGKL);//设置扣料按钮状态
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
            ParamSetRule psrule = new ParamSetRule();
            txtReqDate.DateTime = DateTime.Now.Date.AddDays(psrule.RShowIntByCode((int)ParamSetEnum.采购合同交期自动延后天数)).Date;

            drpPayMothodFlag.EditValue = Common.GetPayMethodByProcessType((int)EnumProcessType.织造加工单);

            //BindGridDts();



        }

        public override void IniUpdateSet()
        {
            //BindGridDts();
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_FabricProcess";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };
            this.HTCheckDataField = new string[] { "ItemCode", "Qty" };//数据明细校验必须录入字段

            //Common.BindPayMethod(drpPayMothodFlag, true);
            //Common.BindOP(drpSaleOPID, (int)EnumOPDep.业务部, true);
            //new VendorProc(drpVendorID);
            //Common.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.织厂 }, true);
            //new VendorProc(drpDyeFactorty);


            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);
            Common.BindCLS(drpYHStyle, "WO_FabricProcess", "YHStyle", true);

            new ItemProcResLookUP(BaseFocusLabel, gridView2, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.纱线 }, "", "ItemStd", true, true);


            saveNoLoadCheckDayNum = new ParamSetRule().RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            // this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);   //加载产品信息
            if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5822)))//织造加工单启用用料计算功能
            {
                this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载订单", false, btnLoadSO_Click);    //加载销售订单
            }
            //  this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载订单算料", false, btnLoad_Click);
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加载产品", false, btnDevItemLoad_Click);

            //  ProductCommon.JGButtonIni(btnJGKL, (int)EnumSaleProcedure.织胚加工单);//初始化扣料按钮
            //this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加工扣料", false, btnBuckleMaterial_Click);


            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5805)))//织造加工单启用用料计算功能
            //{
            //    groupControlItem.Visible = true;
            //}


            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
            //{
            //    gridView1.Columns["ItemCode"].ColumnEdit = drpGridItemCode;
            //    gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            //    gridViewBindEventA1(gridView1);

            //    this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            //}
            //else if(groupControlItem.Visible)//用料计算
            //{
            //    this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            //}


        }


        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindPayMethod(drpPayMothodFlag, true);
            //Common.BindOP(drpSaleOPID, (int)EnumOPDep.业务部, true);

            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }
            DevMethod.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.织厂, (int)EnumVendorType.其他加工厂 }, true);
            DevMethod.BindItemPB(drpItemCode, true);
            Common.BindVendor(drpGridDVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindSOContext(drpSOContext, "织造", true);


            Common.BindVendor(drpOrderVendorID, new int[] { (int)EnumVendorType.内销客户, (int)EnumVendorType.客户 }, true);

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


        /// <summary>
        ///通用 重新设置实体
        /// 
        /// </summary>
        private void gridViewRowChanged1(object sender)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                string cpItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "CPItemCode"));
                if (cpItemCode != string.Empty)
                {
                    Common.BindFabricItemByCPItemCode(drpGridItemCode, cpItemCode, true);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 替换白坯面料 物料编码值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ItemCode")
                {
                    string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ItemCode"));
                    if (itemCode != string.Empty)
                    {
                        string[] itemA = Common.GetItemArrayByCode(itemCode);
                        if (itemA.Length > 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, "ItemName", itemA[1]);
                            gridView1.SetRowCellValue(e.RowHandle, "ItemStd", itemA[2]);
                            gridView1.SetRowCellValue(e.RowHandle, "ItemModel", itemA[3]);
                        }
                        //Common.GetItemColorNameByColorNum
                        // Common.BindFabricItemByCPItemCode(drpGridItemCode, cpItemCode, true);
                    }


                }

                if (e.Column.FieldName == "Qty")//计算用纱
                {
                    SetFabUseItemDtsCalc();

                }


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Percentage" || e.Column.FieldName == "Loss")//计算用纱
                {
                    SetFabUseItemDtsCalc();
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
        private FabricProcess EntityGet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime;
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            //entity.OrderLevelID = SysConvert.ToInt32(drpOrderLevelID.EditValue);
            //entity.OrderTypeID = SysConvert.ToInt32(drpOrderTypeID.EditValue);
            //entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.OrderFormNo = SysConvert.ToString(txtOrderFormNo.Text.Trim());   //销售合同号
            //entity.OrderDate = txtOrderDate.DateTime;
            entity.ReqDate = txtReqDate.DateTime;
            //entity.PayMethodID = txtPayMethodID.Text.Trim();
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.ContractDesc = txtContractDesc.Text.Trim();
            //entity.CustomerCode = txtCustomerCode.Text.Trim();
            entity.PayMethodID = SysConvert.ToString(drpPayMothodFlag.EditValue);
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            //entity.WLAmountType = SysConvert.ToInt32(drpWLAmountType.EditValue);
            //entity.WLAmount = SysConvert.ToDecimal(txtWLAmount.Text.Trim());
            entity.OrderType = txtOrderTypeName.Text.Trim();
            entity.DyeFactorty = drpDyeFactorty.EditValue.ToString();
            //entity.DyeingTec = txtRSTec.Text.Trim();
            //entity.DyeingReq = txtBuyerReq.Text.Trim();
            //entity.LightSource = chkLightSource.Text.Trim();
            //entity.SGReq = txtSGReq.Text.Trim();
            //entity.SendAddress = txtSendAddr.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);

            entity.VendorID = SysConvert.ToString(drpOrderVendorID.EditValue);

            entity.BiLi = SysConvert.ToString(txtBiLi.Text.Trim());
            entity.Loss = SysConvert.ToDecimal(txtLoss.Text.Trim());
            entity.GYRequire = SysConvert.ToString(txtGYRequire.Text.Trim());
            entity.YHStyle = SysConvert.ToString(drpYHStyle.Text.Trim());
            entity.ProcessTypeID = (int)EnumProcessType.织造加工单;
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FabricProcessDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            FabricProcessDts[] entitydts = new FabricProcessDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new FabricProcessDts();
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
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));

                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));//款号

                    entitydts[index].CPItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemCode"));
                    entitydts[index].CPItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemName"));
                    entitydts[index].CPItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemModel"));
                    entitydts[index].CPItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemStd"));

                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));


                    entitydts[index].PieceWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PieceWeight"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));

                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    //entitydts[index].Qty = entitydts[index].PieceWeight * entitydts[index].PieceQty;

                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));

                    entitydts[index].OrderQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "OrderQty"));
                    entitydts[index].OrderUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "OrderUnit"));

                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].Qty * entitydts[index].SingPrice;
                    //entitydts[index].ReceivedDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "ReceivedDate")); 
                    //entitydts[index].ReceivedQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ReceivedQty")); 
                    //entitydts[index].TotalRecQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalRecQty")); 
                    //entitydts[index].RemainQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RemainQty")); 
                    //entitydts[index].RemainRate = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RemainRate")); 
                    //entitydts[index].OrderPreStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "OrderPreStatusID")); 
                    //entitydts[index].OrderStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "OrderStatusID"));
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));




                    entitydts[index].FreeStr1 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr1"));
                    entitydts[index].FreeStr2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr2"));
                    entitydts[index].FreeStr3 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr3"));
                    entitydts[index].FreeStr4 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr4"));
                    entitydts[index].FreeStr5 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr5"));

                    entitydts[index].AllMWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "AllMWidth"));
                    entitydts[index].Machine = SysConvert.ToString(gridView1.GetRowCellValue(i, "Machine"));
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));

                    index++;
                }
            }
            return entitydts;
        }


        /// <summary>
        /// 获取加工用料
        /// </summary>
        /// <returns></returns>
        private FabricProcessItemDts[] GetFabricProcessItemDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    Num++;
                }
            }
            FabricProcessItemDts[] entitydts = new FabricProcessItemDts[Num];
            int index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    entitydts[index] = new FabricProcessItemDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].DtsItemCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode"));
                    entitydts[index].DtsItemName = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemName"));
                    entitydts[index].DtsItemStd = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemStd"));
                    entitydts[index].DtsItemModel = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemModel"));
                    entitydts[index].Percentage = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Percentage"));
                    entitydts[index].Loss = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Loss"));
                    entitydts[index].UseQty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "UseQty"));
                    entitydts[index].DtsRemark = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsRemark"));
                    index++;

                }
            }
            return entitydts;
        }
        #endregion

        #region 加载合同
        /// <summary>
        /// 双击生成采购单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.织造加工单号);
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_FabricProcess", "FormNo", 2);
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
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    frmLoadSlaeOrderFabric frm = new frmLoadSlaeOrderFabric();
                    string sql = string.Empty;
                    //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(OrderFormNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WO_FabricProcessDts";
                    sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') DtsSO FROM UV1_WO_FabricProcessDts";

                    if (saveNoLoadCheckDayNum != 0)
                    {
                        sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        sql += " WHERE 1=1 ";
                    }
                    sql += "  AND ProcessTypeID = 2 )";//织造类型


                    frm.NoLoadCondition = sql;// " AND FormNo+ItemCode NOT IN (SELECT ISNULL(DtsSO+ItemCode,'') FROM UV1_WO_FabricProcessDts)";
                    frm.BuyFlag = true;
                    frm.Double = false;//选择单条数据
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.ItemID != null && frm.ItemID.Length != 0)
                    {
                        //SetGridView1();// 防止一个采购单出现两个合同的数据
                        for (int i = 0; i < frm.ItemID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.ItemID[i]);
                        }
                        SetSaleOrderFabric(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void SetSaleOrderFabric(string str)
        {
            string[] arr = str.Split(',');
            //int index = gridView1.FocusedRowHandle;//checkRowSet();
            int index = 0;//只保存一条数据
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Sale_SaleOrderTFabric WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));

                    gridView1.SetRowCellValue(i, "DVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));

                    gridView1.SetRowCellValue(i, "Machine", SysConvert.ToString(dt.Rows[0]["Machine"]));//机台
                    txtGYRequire.Text = SysConvert.ToString(dt.Rows[0]["TecDesc"]);//工艺描述





                    gridView1.SetRowCellValue(i, "CPItemCode", SysConvert.ToString(dt.Rows[0]["CPItemCode"]));
                    gridView1.SetRowCellValue(i, "CPItemName", SysConvert.ToString(dt.Rows[0]["CPItemName"]));
                    gridView1.SetRowCellValue(i, "CPItemModel", SysConvert.ToString(dt.Rows[0]["CPItemModel"]));
                    gridView1.SetRowCellValue(i, "CPItemStd", SysConvert.ToString(dt.Rows[0]["CPItemStd"]));


                    if (i == index)//第一行
                    {
                        if (groupControlItem.Visible)//物料用料控件容器可见 绑定物料使用
                        {
                            SetFabUseItemDts(SysConvert.ToString(dt.Rows[0]["ItemCode"]), SysConvert.ToInt32(dt.Rows[0]["ID"]));
                        }


                        if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
                        {
                            Common.BindFabricItemByCPItemCode(drpGridItemCode, SysConvert.ToString(dt.Rows[0]["CPItemCode"]), true);
                        }
                    }

                }
                length++;
            }
            if (groupControlItem.Visible)//物料用料控件容器可见 绑定物料使用
            {
                SetFabUseItemDtsCalc();//计算用料
            }
        }

        #region 用纱明细设置及计算
        /// <summary>
        /// 设置用纱明细(关联坯布管理数据)
        /// </summary>
        private void SetFabUseItemDts(string p_FabItemCode, int p_ID)
        {
            DataTable dtSource = (DataTable)gridView2.GridControl.DataSource;
            dtSource.Rows.Clear();

            string sql = string.Empty;
            sql = "SELECT B.* FROM Data_ItemDts B,Data_Item A WHERE A.ID=B.MainID AND A.ItemCode=" + SysString.ToDBString(p_FabItemCode);
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                DataRow drSource = dtSource.NewRow();
                drSource["DtsItemCode"] = dr["DtsItemCode"];
                drSource["DtsItemName"] = dr["DtsItemName"];
                drSource["DtsItemStd"] = dr["DtsItemStd"];
                drSource["DtsItemModel"] = dr["DtsItemModel"];
                drSource["Percentage"] = dr["Percentage"];
                //drSource["Loss"] = dr["Loss"];


                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5821)))//
                {
                    sql = "select SH from Sale_SaleOrderItem where 1=1";//织损
                    sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(dr["DtsItemCode"]));
                    if (p_ID != 0)
                    {
                        sql += " AND MainID=" + p_ID;
                    }
                    DataTable dtSH = SysUtils.Fill(sql);
                    if (dtSH.Rows.Count != 0)
                    {
                        drSource["Loss"] = SysConvert.ToDecimal(dtSH.Rows[0]["SH"]) * SysConvert.ToDecimal(0.01);
                    }
                }
                else
                {
                    drSource["Loss"] = dr["Loss"];
                }



                dtSource.Rows.Add(drSource);
            }
        }




        /// <summary>
        /// 设置用纱明细(计算用量)
        /// </summary>
        private void SetFabUseItemDtsCalc()
        {
            if (groupControlItem.Visible)//用料计算可见
            {
                DataTable dtSource = (DataTable)gridView2.GridControl.DataSource;
                DataTable dtDts = (DataTable)gridView1.GridControl.DataSource;
                decimal qty = SysConvert.ToDecimal(dtDts.Compute("SUM(Qty)", ""));//生产数量

                foreach (DataRow dr in dtSource.Rows)
                {
                    if (dr["DtsItemCode"].ToString() != string.Empty)
                    {
                        decimal calQty = (1 + SysConvert.ToDecimal(dr["Loss"])) * qty * (SysConvert.ToDecimal(dr["Percentage"]) / 100m);
                        calQty = SysConvert.ToDecimal(calQty, 2);
                        dr["UseQty"] = calQty;
                    }
                }
            }
        }
        #endregion




        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadSO_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadOrder frm = new frmLoadOrder();

                    string sql = string.Empty;
                    //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(OrderFormNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WO_FabricProcessDts";
                    sql += " AND FormNo+ItemCode NOT IN(SELECT ISNULL(DtsSO+CPItemCode,'') DtsSO FROM UV1_WO_FabricProcessDts where 1=1 ";

                    //if (saveNoLoadCheckDayNum != 0)
                    //{
                    //    sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                    //}
                    sql += "  and ProcessTypeID = 2 )";//织造类型
                    frm.NoLoadCondition = sql;
                    frm.CheckFlag = 1;
                    frm.CheckFlag2 = 1;//不验证验证合同唯一性  （不同的合同也可以加载）
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        //SetGridView1();// 防止一个采购单出现两个合同的数据
                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
                        }
                        setItemNews(str);
                        gridViewRowChanged1(gridView1);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string p_Str)
        {
            int currentDataRowID = gridView1.FocusedRowHandle;
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(currentDataRowID + i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "CustomerCode", SysConvert.ToString(dt.Rows[0]["CustomerCode"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "CPItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "CPItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "CPItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "CPItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "DVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "AllMWidth", SysConvert.ToString(dt.Rows[0]["AllMWidth"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    //gridView1.SetRowCellValue(currentDataRowID +i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtReqDate.DateTime = SysConvert.ToDateTime(dt.Rows[0]["DtsReqDate"]);
                    txtOrderTypeName.Text = SysConvert.ToString(dt.Rows[0]["OrderTypeName"]);
                    //drpOrderLevelID.EditValue = SysConvert.ToInt32(dt.Rows[0]["OrderLevelID"]);
                    //drpOrderTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["OrderTypeID"]);
                    //drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);
                    //if (i == 0)
                    //{
                    //    sql = "SELECT VendorID FROM Data_Item WHERE ItemCode="+SysString.ToDBString( SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //    dt = SysUtils.Fill(sql);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0][0]);
                    //    }
                    //}


                    string Unit = SysConvert.ToString(dt.Rows[0]["Unit"]);
                    if (Unit.Contains("/KG"))
                    {
                        gridView1.SetRowCellValue(currentDataRowID + i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else if (Unit.Contains("/M"))
                    {
                        gridView1.SetRowCellValue(currentDataRowID + i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }
                    else if (Unit.Contains("/Y"))
                    {
                        gridView1.SetRowCellValue(currentDataRowID + i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Yard"]));
                    }
                    else if (Unit.Contains("/PC"))
                    {
                        gridView1.SetRowCellValue(currentDataRowID + i, "OrderQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }

                    //gridView1.SetRowCellValue(currentDataRowID + i, "OrderQty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "OrderUnit", SysConvert.ToString(dt.Rows[0]["Unit"]));

                    drpOrderVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);

                }
            }
        }

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
                //return;
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                FabricProcessRule rule = new FabricProcessRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.已提交);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
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
                //return;
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                FabricProcessRule rule = new FabricProcessRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion



        #region 加载产品信息

        /// <summary>
        /// 加载产品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnDevItemLoad_Click(object sender, EventArgs e)
        {

            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.HTItemTypeID = (int)EnumItemType.坯布;
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
                        setItemFabricNews(str);
                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void setItemFabricNews(string p_Str)
        {

            string[] gbid = p_Str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    //gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));



                }
            }

        }
        #endregion

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged_1(object sender, CellValueChangedEventArgs e)
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
                        view.SetRowCellValue(view.FocusedRowHandle, "MWidth", dt.Rows[0]["MWidth"]);
                        view.SetRowCellValue(view.FocusedRowHandle, "MWeight", dt.Rows[0]["MWeight"]);
                        view.SetRowCellValue(view.FocusedRowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"]);
                    }
                }

                if (e.Column.FieldName == "PieceQty" || e.Column.FieldName == "PieceWeight")
                {
                    ColumnView view = sender as ColumnView;
                    decimal PieceQty = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "PieceQty"));
                    decimal PieceWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PieceWeight"));
                    decimal Qty = PieceQty * PieceWeight;
                    view.SetRowCellValue(view.FocusedRowHandle, "Qty", Qty);
                }
            }
        }


        #region 加工扣料
        ///// <summary>
        ///// 加载加工扣料
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnJGKL_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HTFormStatus == FormStatus.查询 && HTDataSubmitFlag == 1)
        //        {
        //            ProductCommon.JGOpenKLForm((int)EnumSaleProcedure.织胚加工单, HTDataID, HTDataFormNo);

        //            ProductCommon.JGButtonStatusSet(HTFormStatus, HTDataSubmitFlag, HTDataID, btnJGKL);//设置扣料按钮状态                   
        //        }
        //        else
        //        {
        //            this.ShowMessage("请在查询提交状态下操作");
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        #endregion





    }
}