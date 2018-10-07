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
    public partial class frmFabricCompSiteProcessEdit : frmAPBaseUIFormEdit
    {
        public frmFabricCompSiteProcessEdit()
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

            if (drpDyeFactorty.EditValue == string.Empty)
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

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FabricProcessRule rule = new FabricProcessRule();
            FabricProcess entity = EntityGet();
            FabricProcessDts[] entitydts = EntityDtsGet();
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
            rule.RAdd(entity, entitydts);
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
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo;
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtFormDate.DateTime = entity.FormDate.Date;
            drpVendorID.EditValue = entity.VendorID;
            drpOrderLevelID.EditValue = entity.OrderLevelID;
            drpOrderTypeID.EditValue = entity.OrderTypeID;
            txtReqDate.DateTime = entity.ReqDate;
            txtOrderDate.DateTime = entity.OrderDate;
            txtOrderFormNo.Text = entity.OrderFormNo;
            txtCustomerCode.Text = entity.CustomerCode.ToString();
            //txtPayMethodID.Text = entity.PayMethodID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtContractDesc.Text = entity.ContractDesc.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            drpWLAmountType.EditValue = entity.WLAmountType;
            txtWLAmount.Text = entity.WLAmount.ToString();

            drpDyeFactorty.EditValue = entity.DyeFactorty.ToString();
            txtRSTec.Text = entity.DyeingTec.ToString();
            txtBuyerReq.Text = entity.DyeingReq.ToString();
            chkLightSource.Text = entity.LightSource.ToString();
            txtSGReq.Text = entity.SGReq.ToString();
            txtSendAddr.Text = entity.SendAddress.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();

            if (!findFlag)
            {
               
            }

            BindGridDts();
            BindOrderInfo();
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
            ProductCommon.FormNoCtlEditSet(txtFormNo, "WO_FabricProcess", "FormNo", 5, p_Flag);//复合加工


            ProductCommon.JGButtonStatusSet(HTFormStatus, HTDataSubmitFlag, HTDataID, btnJGKL);//设置扣料按钮状态
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
           // txtFormDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
            ParamSetRule psrule = new ParamSetRule();
            txtReqDate.DateTime = DateTime.Now.Date.AddDays(psrule.RShowIntByCode((int)ParamSetEnum.采购合同交期自动延后天数)).Date;

            drpPayMothodFlag.EditValue = Common.GetPayMethodByProcessType((int)EnumProcessType.复合加工单);

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_FabricProcess";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode", "Qty" };//数据明细校验必须录入字段
            //Common.BindOrderType(drpOrderTypeID, true);
            //Common.BindOrderLevel(drpOrderLevelID, true);
            //Common.BindWLAmount(drpWLAmountType, true);
            //Common.BindPayMethod(drpPayMothodFlag, true);
            //Common.BindOP(drpSaleOPID, (int)EnumOPDep.业务部, true);
            //Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
            //Common.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.染厂 }, true);
            //drpDyeFactorty.Tag = (int)EnumVendorType.工厂;
            new VendorProc(drpDyeFactorty);

            new PopContainerUtil(chkLightSource, Common.BindLightSource);   //对色光源
            //Common.BindCLS(txtSGReq, "WO_FabricProcess", "SGReq", true);    //手感要求
            //Common.BindSOContext(drpSOContext, true);
            //Common.BindEnumUnit(restxtunit, true);
            //Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
            saveNoLoadCheckDayNum = new ParamSetRule().RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            // this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);   //加载产品信息
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载订单", false, btnLoad_Click);    //加载销售订单
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加载产品信息", false, btnDevItemLoad_Click);
            //this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加工扣料", false, btnBuckleMaterial_Click);

            ProductCommon.JGButtonIni(btnJGKL, (int)EnumSaleProcedure.复合加工单);//初始化扣料按钮
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
            //Common.BindOP(drpSaleOPID, (int)EnumOPDep.业务部, true);
            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.织厂, (int)EnumVendorType.工厂 }, true);
            Common.BindCLS(txtSGReq, "WO_FabricProcess", "SGReq", true);    //手感要求
            Common.BindSOContext(drpSOContext, "", true);
            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);
        }

        private void gridViewRowChanged1(object sender)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));
                string sql = "SELECT * FROM UV1_Data_ItemColorDtsHis WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                sql += " ORDER BY SalePriceDate DESC";
                DataTable dt = SysUtils.Fill(sql);
                //gridView2.GridControl.DataSource = dt;
                //gridView2.GridControl.Show();
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
            entity.OrderLevelID = SysConvert.ToInt32(drpOrderLevelID.EditValue);
            entity.OrderTypeID = SysConvert.ToInt32(drpOrderTypeID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.OrderFormNo = SysConvert.ToString(txtOrderFormNo.Text.Trim());   //销售合同号
            //entity.OrderDate = txtOrderDate.DateTime;
            entity.ReqDate = txtReqDate.DateTime;
            //entity.PayMethodID = txtPayMethodID.Text.Trim();
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.ContractDesc = txtContractDesc.Text.Trim();
            entity.CustomerCode = txtCustomerCode.Text.Trim();
            entity.PayMethodID = SysConvert.ToString(drpPayMothodFlag.EditValue);
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.WLAmountType = SysConvert.ToInt32(drpWLAmountType.EditValue);
            entity.WLAmount = SysConvert.ToDecimal(txtWLAmount.Text.Trim());

            entity.DyeFactorty = drpDyeFactorty.EditValue.ToString();
            entity.DyeingTec = txtRSTec.Text.Trim();
            entity.DyeingReq = txtBuyerReq.Text.Trim();
            entity.LightSource = chkLightSource.Text.Trim();
            entity.SGReq = txtSGReq.Text.Trim();
            entity.SendAddress = txtSendAddr.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.ProcessTypeID = (int)EnumProcessType.复合加工单;
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
  			 		entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum")); 
  			 		entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName")); 
  			 		entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
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
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.染布加工单号);
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_FabricProcess", "FormNo", 5);//复合加工
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
                    frmLoadOrder frm = new frmLoadOrder();

                    string sql = string.Empty;
                    sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(OrderFormNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WO_FabricProcessDts";
                    if (saveNoLoadCheckDayNum != 0)
                    {
                        sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                    }

                    sql += " and ProcessTypeID ="+(int)EnumProcessType.复合加工单+" )";//复合
                    //sql += ")";
                    frm.NoLoadCondition = sql;
                    frm.CheckFlag = 1;

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

        ///// <summary>
        ///// 防止一个采购单出现两个合同的数据
        ///// </summary>
        //private void SetGridView1()
        //{
        //    string sql = "SELECT * FROM Buy_ItemBuyFormDts WHERE 1=0";
        //    DataTable dt = SysUtils.Fill(sql);
        //    Common.AddDtRow(dt, 100);
        //    gridView1.GridControl.DataSource =dt;
        //    gridView1.GridControl.Show();
        //}

        private void setItemNews(string p_Str)
        {
            int currentDataRowID = gridView1.FocusedRowHandle;
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID="+SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //gridView1.SetRowCellValue(currentDataRowID +i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "DVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtReqDate.DateTime = SysConvert.ToDateTime(dt.Rows[0]["DtsReqDate"]);

                    drpOrderLevelID.EditValue = SysConvert.ToInt32(dt.Rows[0]["OrderLevelID"]);
                    drpOrderTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["OrderTypeID"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
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
                rule.RSubmit(HTDataID, (int)ConfirmFlag.审核通过);

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
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

               

                }
            }
        }
        #endregion

     
        #region 加工扣料
        /// <summary>
        /// 加载加工扣料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJGKL_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.查询 && HTDataSubmitFlag == 1)
                {
                    ProductCommon.JGOpenKLForm((int)EnumSaleProcedure.染整加工单, HTDataID, HTDataFormNo);
                    ProductCommon.JGButtonStatusSet(HTFormStatus, HTDataSubmitFlag, HTDataID, btnJGKL);//设置扣料按钮状态               
                }
                else
                {
                    this.ShowMessage("请在查询提交状态下操作");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
       

        #endregion


       


    }
}