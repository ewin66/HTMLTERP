using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraEditors.Controls;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.UCFab;
using HttSoft.WinUIBase;
using System.Data;
using System;

namespace MLTERP
{
    public partial class frmMaterialOutWHEdit : frmModuleBaseWHEdit
    {
        #region 全局变量
        /// <summary>
        /// 加载单据类型
        /// </summary>
        int saveLoadFormType = 0;
        /// <summary>
        /// 加载默认条件
        /// </summary>
        string saveTHLoadFormListIDStr = string.Empty;
        #endregion

        public frmMaterialOutWHEdit()
        {
            InitializeComponent();
        }
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == string.Empty)
            {
                this.ShowMessage("请输入出库单号");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return false;
            }
            if (SysConvert.ToString(drpSubType.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择单据类型");
                drpSubType.Focus();
                return false;
            }
            if (!this.CheckCorrectDts())
            {
                return false;
            }
            return true;
        }
        #region 增删改查

        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }
        /// <summary>
        /// 增加
        /// </summary>
        public override int EntityAdd()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();
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

            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();
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

            rule.RUpdate(entity, entitydts);
        }
        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            HTDataFormNo = entity.FormNo;
            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpVendorID.EditValue = entity.VendorID.ToString();
            drpSubType.EditValue = entity.SubType;
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtRemark.Text = entity.Remark;
            txtMakeOPName.Text = entity.MakeOPName;
            drpAddress.EditValue = entity.Address;

            drpVendorOPID.EditValue = entity.VendorOPID;
            txtVendorTel.Text = entity.VendorTel;
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
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            rule.RDelete(entity);
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessGrid.SetGridEdit(HTDataDts, new string[] { "ItemCode", "ItemName", "ItemModel", "ItemStd" }, false);
            txtMakeOPName.Properties.ReadOnly = true;

        }

        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段 ,"Qty"
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.业务部 }, true);
            Common.BindWHByFormList(drpWH, this.FormListAID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            Common.BindSubType(drpSubType, this.FormListAID, true);
            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitFab", true);
            ParamSetRule psrule = new ParamSetRule();
            //saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加载单据", false, btnLoad_Click);
            //this.ToolBarItemAdd(28, "btnUpdateAmount", "修改单价", false, btnUpdateAmount_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
        }
        #endregion
        #region 自定义方法
        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHID"));
                    string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SectionID"));
                    Common.BindSection(drpGridSectionID, WHID, false);
                    Common.BindSBit(drpSBit, WHID, SectionID, true);

                }
                gridView1.Focus();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        #region 获取实体
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime;
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.WHTypeID = SysConvert.ToInt32(Common.GetWHTypeByFormListID(this.FormListAID));
            entity.SubType = SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
            entity.VendorTel = txtVendorTel.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeadType = this.FormListAID;
            entity.Address = SysConvert.ToString(drpAddress.EditValue);

            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeDate = DateTime.Now;
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
            }
            return entity;
        }
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            IOFormDts[] entitydts = new IOFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new IOFormDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].WHID = SysConvert.ToString(gridView1.GetRowCellValue(i, "WHID"));
                    entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID"));
                    entitydts[index].SBitID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SBitID"));
                    entitydts[index].WHTypeID = SysConvert.ToInt32(Common.GetWHTypeByWHID(SysConvert.ToString(gridView1.GetRowCellValue(i, "WHID"))));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));
                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));
                    entitydts[index].InputQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputQty"));
                    entitydts[index].InputUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "InputUnit"));
                    entitydts[index].InputSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputSinglePrice"));
                    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice;
                    entitydts[index].InputConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputConvertXS"));
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty + entitydts[index].DYPrice;
                    entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i,"Needle"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].PackDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "PackDts"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID"));
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
                    entitydts[index].DtsInVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsInVendorID"));
                    entitydts[index].InSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSO"));
                    entitydts[index].InOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "InOrderFormNo"));
                    entitydts[index].InSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));
                    entitydts[index].LoadDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadDtsID"));
                    index++;
                }
            }
            return entitydts;
        }
        #endregion
        #region 其他事件
        /// <summary>
        /// 双击生产单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetWHFormNo(this.FormListAID, SysConvert.ToInt32(drpSubType.EditValue), "");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 单据类型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSubType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtFormNo_DoubleClick(null, null);
                DevMethod.BindVendorByFormListID(drpVendorID, SysConvert.ToInt32(drpSubType.EditValue), true);
                string sql = "SELECT * FROM Enum_FormList WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"]);
                    saveTHLoadFormListIDStr = SysConvert.ToString(dt.Rows[0]["THLoadFormListIDStr"]);
                    string VendorCaption = dt.Rows[0]["VendorIDCaption"].ToString();
                    if (VendorCaption != string.Empty)
                    {
                        labVendorID.Text = VendorCaption;
                        drpVendorID.ToolTip = VendorCaption;
                    }
                }
                else
                {
                    saveLoadFormType = 0;
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 选择客户带出客户主表的联系人电话和地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                Common.BindVendorAddress(drpAddress, SysConvert.ToString(drpVendorID.EditValue), true);

                Common.BindVendorContact(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
            }
            drpAddress.EditValue = Common.GetVendorAddressByVenorID(SysConvert.ToString(drpVendorID.EditValue));
            drpVendorOPID.EditValue = Common.GetVendorContactByVenorID(SysConvert.ToString(drpVendorID.EditValue));
            txtVendorTel.Text = Common.GetVendorTelByVenorID(SysConvert.ToString(drpVendorID.EditValue));
        }
        private void drpWH_EditValueChanged(object sender, EventArgs e)
        {
            gridViewRowChanged2(gridView1);
        }

        private void drpGridSectionID_EditValueChanged(object sender, EventArgs e)
        {
            gridViewRowChanged2(gridView1);
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

                IOFormRule rule = new IOFormRule();
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

                IOFormRule rule = new IOFormRule();
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
        ///
        public void btnLoadStorge_Click(object sender, EventArgs e)
        {
            LoadStorge();
        }
        #region 加载库存
        public void LoadStorge()
        {
            try
            {
                frmStorgeLoad frm = new frmStorgeLoad();
                frm.FormListAID = this.FormListAID;
                frm.ShowDialog();
                string str = string.Empty;
                if (frm.StorgeID != null && frm.StorgeID.Length != 0)
                {

                    for (int i = 0; i < frm.StorgeID.Length; i++)
                    {
                        if (str != string.Empty)
                        {
                            str += ",";
                        }
                        str += SysConvert.ToString(frm.StorgeID[i]);
                    }
                }
                int index = 0;
                for (int i = 0; i < this.HTDataDts.RowCount; i++)
                {
                    if (SysConvert.ToString(this.HTDataDts.GetRowCellValue(i, "ItemCode")) != string.Empty)
                    {
                        index = i + 1;
                    }
                }
                string[] itembuyid = str.Split(',');
                for (int i = 0; i < itembuyid.Length; i++)
                {
                    string sql = "SELECT * FROM  UV1_WH_Storge WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 1)
                    {
                        this.HTDataDts.SetRowCellValue(index, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                        this.HTDataDts.SetRowCellValue(index, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                        this.HTDataDts.SetRowCellValue(index, "SBitID", SysConvert.ToString(dt.Rows[0]["SBitID"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                        this.HTDataDts.SetRowCellValue(index, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                        this.HTDataDts.SetRowCellValue(index, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                        this.HTDataDts.SetRowCellValue(index, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                        this.HTDataDts.SetRowCellValue(index, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                        this.HTDataDts.SetRowCellValue(index, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));

                        this.HTDataDts.SetRowCellValue(index, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));

                        this.HTDataDts.SetRowCellValue(index, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                        this.HTDataDts.SetRowCellValue(index, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                        this.HTDataDts.SetRowCellValue(index, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                        this.HTDataDts.SetRowCellValue(index, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                        this.HTDataDts.SetRowCellValue(index, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                        this.HTDataDts.SetRowCellValue(index, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                        this.HTDataDts.SetRowCellValue(index, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                        this.HTDataDts.SetRowCellValue(index, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                        this.HTDataDts.SetRowCellValue(index, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                        this.HTDataDts.SetRowCellValue(index, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                        this.HTDataDts.SetRowCellValue(index, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                        this.HTDataDts.SetRowCellValue(index, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                        this.HTDataDts.SetRowCellValue(index, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                        this.HTDataDts.SetRowCellValue(index, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                        this.HTDataDts.SetRowCellValue(index, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                        this.HTDataDts.SetRowCellValue(index, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                        this.HTDataDts.SetRowCellValue(index, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                        this.HTDataDts.SetRowCellValue(index, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["DutyOPID"]));
                        index++;
                    }
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
