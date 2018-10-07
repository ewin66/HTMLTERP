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
    public partial class frmFLBuyFormEdit : frmAPBaseUIFormEdit
    {
        public frmFLBuyFormEdit()
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

            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入采购单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择供应商");
                drpVendorID.Focus();
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
        /// 额外的附加验证
        /// </summary>
        /// <returns></returns>
        private bool CheckCorrectDtsAttach()
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
            //    if (ItemCode != "")
            //    {
            //        string sql = "SELECT * FROM UV1_Buy_ItemBuyFormDts WHERE OrderFormNo+ItemCode=" + SysString.ToDBString(txtOrderFormNo.Text.Trim() +ItemCode);
            //        DataTable dt = SysUtils.Fill(sql);
            //        if (dt.Rows.Count > 0)
            //        {
            //            if (MessageBox.Show("合同号" + txtOrderFormNo.Text.Trim() + ",产品编码：" + ItemCode + "的合同已采购，还要继续采购吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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
            ItemBuyFormDtsRule rule = new ItemBuyFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ItemBuyFormRule rule = new ItemBuyFormRule();
            ItemBuyForm entity = EntityGet();
            ItemBuyFormDts[] entitydts = EntityDtsGet();
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
            ItemBuyFormRule rule = new ItemBuyFormRule();
            ItemBuyForm entity = EntityGet();
            ItemBuyFormDts[] entitydts = EntityDtsGet();
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
            ItemBuyForm entity = new ItemBuyForm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtFormDate.DateTime = entity.FormDate;
            txtReqDate.DateTime = entity.ReqDate;
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            txtRemark.Text = entity.Remark.ToString();
            drpVendorID.EditValue = entity.ShopID;
            txtOrderFormNo.Text = entity.OrderFormNo.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            txtContractDesc.Text = entity.ContractDesc;
            txtOrderDate.DateTime = entity.OrderDate;
            drpCGOPID.EditValue = entity.CGOPID;
            drpSaleOPID.EditValue = entity.SaleOPID;
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
            ItemBuyFormRule rule = new ItemBuyFormRule();
            ItemBuyForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Buy_ItemBuyForm", "FormNo", 5, p_Flag);
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
            drpCGOPID.EditValue = FParamConfig.LoginID;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Buy_ItemBuyForm";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode", "Qty" };//数据明细校验必须录入字段
            //Common.BindPayMethod(drpPayMothodFlag, true);
            //Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂,(int)EnumVendorType.供应商 }, true);
            new VendorProc(drpVendorID);
            //Common.BindEnumUnit(restxtunit, true);

            //Common.BindCLS(restxtunit, "Data_Item", "ItemUnitAtt", true);
            //Common.BindOP(drpSaleOPID, true);
            //Common.BindOP(drpCGOPID, true);
            //new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[4] { "ItemCode", "ItemName", "ItemStd", "Unit" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.辅料 }, "", "ItemStd", true, true);
            //Common.BindSOContext(drpSOContext, true);
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载订单号", false, btnLoad_Click);

        }

        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindPayMethod(drpPayMothodFlag, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.辅料供应商 }, true);//(int)EnumVendorType.工厂,

            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitAtt", true);
            //Common.BindOP(drpSaleOPID, true);
            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
                Common.BindOPID(drpCGOPID, "Buy_ItemBuyForm", "CGOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
                Common.BindOP(drpCGOPID, true);
            }
            //Common.BindOP(drpCGOPID, true);
            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[4] { "ItemCode", "ItemName", "ItemStd", "Unit" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.辅料 }, "", "ItemStd", true, true);
            Common.BindSOContext(drpSOContext, "", true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemBuyForm EntityGet()
        {
            ItemBuyForm entity = new ItemBuyForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.ReqDate = txtReqDate.DateTime.Date;
            entity.OrderFormNo = txtOrderFormNo.Text.Trim();
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.Remark = SysConvert.ToString(txtRemark.Text.Trim());
            entity.ShopID = SysConvert.ToString(drpVendorID.EditValue);
            entity.OrderFormNo = txtOrderFormNo.Text.Trim();
            entity.OrderDate = txtOrderDate.DateTime;
            entity.ContractDesc = txtContractDesc.Text.Trim();

            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.CGOPID = SysConvert.ToString(drpCGOPID.EditValue);

            entity.FormAID = this.FormListAID;
            entity.MLType = (int)EnumMLType.辅料;
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemBuyFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ItemBuyFormDts[] entitydts = new ItemBuyFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ItemBuyFormDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));

                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].Qty * entitydts[index].SingPrice;

                    //entitydts[index].RemainQty = entitydts[index].Qty - entitydts[index].TotalRecQty;
                    //if (entitydts[index].Qty > 0)
                    //{
                    //    entitydts[index].RemainRate = entitydts[index].RemainQty / entitydts[index].Qty;
                    //}

                    //entitydts[index].OrderPreStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "OrderPreStatusID")); 
                    //entitydts[index].OrderStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "OrderStatusID"));
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DLoadID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLoadID"));

                    entitydts[index].DtsRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark"));
                    entitydts[index].FreeStr1 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr1"));
                    entitydts[index].FreeStr2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr2"));
                    entitydts[index].FreeStr3 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr3"));
                    entitydts[index].FreeStr4 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr4"));
                    entitydts[index].FreeStr5 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr5"));


                    entitydts[index].OrderQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "OrderQty"));

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
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.销售合同采购单号);
                    ProductCommon.FormNoIniSet(txtFormNo, "Buy_ItemBuyForm", "FormNo", 5);
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
                    //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(OrderFormNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_Buy_ItemBuyFormDts";
                    //if (saveNoLoadCheckDayNum != 0)
                    //{
                    //    sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                    //}
                    //sql += ")";
                    sql += " AND OrderStepID=" + SysString.ToDBString((int)EnumOrderStep.新单);
                    frm.NoLoadCondition = sql;
                    frm.ExtraCondition = " and ProductTypeID = 1 ";//类型是毛巾的订单
                    frm.CheckFlag = 1;

                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        SetGridView1();// 防止一个采购单出现两个合同的数据
                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
                        }
                        setItemNews(str);

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 防止一个采购单出现两个合同的数据
        /// </summary>
        private void SetGridView1()
        {
            string sql = "SELECT * FROM Buy_ItemBuyFormDts WHERE 1=0";
            DataTable dt = SysUtils.Fill(sql);
            Common.AddDtRow(dt, 100);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));

                    gridView1.SetRowCellValue(i, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(i, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(i, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(i, "DVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));

                    string Unit = SysConvert.ToString(dt.Rows[0]["Unit"]);

                    if (Unit.EndsWith("M"))
                    {
                        gridView1.SetRowCellValue(i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }
                    else if (Unit.EndsWith("KG"))
                    {
                        gridView1.SetRowCellValue(i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else if (Unit.EndsWith("Y"))
                    {
                        gridView1.SetRowCellValue(i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Yard"]));
                    }
                    else if (Unit.EndsWith("PC"))
                    {
                        gridView1.SetRowCellValue(i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                    }

                    if (Unit.EndsWith("M"))
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }
                    else if (Unit.EndsWith("KG"))
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else if (Unit.EndsWith("Y"))
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Yard"]));
                    }
                    else if (Unit.EndsWith("PC"))
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                    }

                    gridView1.SetRowCellValue(i, "DLoadID", SysConvert.ToInt32(orderid[i]));
                    txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtOrderDate.DateTime = SysConvert.ToDateTime(dt.Rows[0]["DtsReqDate"]);
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

                ItemBuyFormRule rule = new ItemBuyFormRule();
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

                ItemBuyFormRule rule = new ItemBuyFormRule();
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

        #region 其它事件

        #endregion

        #region 合同付款方式
        /// <summary>
        /// 合同付款方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateItemBuyPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存合同后维护付款方式");
                    return;
                }
                frmUpdateItemBuyPay frm = new frmUpdateItemBuyPay();
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

        /// <summary>
        /// 关闭页面提示提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmItemBuyFormEdit_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmItemBuyFormEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    ItemBuyForm entity = new ItemBuyForm();
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "ItemCode")
            {
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ItemCode"));
                string sql = " select * from Data_Item where ItemCode = " + SysString.ToDBString(ItemCode);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                }

            }
        }


    }
}