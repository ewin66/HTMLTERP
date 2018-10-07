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
using System.Web.UI.WebControls;
using DevExpress.XtraEditors;

namespace MLTERP
{
    public partial class frmPiBuOutWHEdit : frmModuleBaseWHEdit
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

        public frmPiBuOutWHEdit()
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
            ContextMenuStrip _MenuFrist = this.HTDataDts.GridControl.ContextMenuStrip as ContextMenuStrip;
            if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)
            {
                for (int i = 0; i < _MenuFrist.Items.Count; i++)
                {
                    _MenuFrist.Items[i].Visible = true;
                }
                _MenuFrist.Items[7].Visible = false;
            }
            if (this.HTFormStatus == FormStatus.查询)
            {
                for (int i = 0; i < _MenuFrist.Items.Count; i++)
                {
                    _MenuFrist.Items[i].Visible = false;
                }
                _MenuFrist.Items[7].Visible = true;
                _MenuFrist.Items[7].Enabled = true;
            }
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
            Common.BindCLS(RestxtUnit, "Sale_SaleOrder", "Unit", true);
            Common.BindSBit(drpSBitID, this.FormListAID.ToString(), true);
            ParamSetRule psrule = new ParamSetRule();
            //saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加载单据", false, btnLoad_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
        }
        public override void IniFormLoadBehind()
        {
            base.IniFormLoadBehind();
            ContextMenuStrip _MenuFrist = this.HTDataDts.GridControl.ContextMenuStrip as ContextMenuStrip;
            HTAPAddContextMenu(_MenuFrist, "设置细码", cMenu_Click);
        }
        public void btnLoadStorge_Click(object sender, EventArgs e)
        {
            LoadStorge();
        }
        public void cMenu_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (this.HTDataSubmitFlag == 0)//未提交状态才允许编辑码单
                {
                    if (HTDataID == 0)
                    {
                        this.ShowMessage("请保存单据后设置细码");
                        return;
                    }
                    int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    string WHID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "WHID"));
                    string SectionID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID"));
                    string SBitID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SBitID"));
                    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                    string ItemName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemName"));
                    string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum"));
                    string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                    string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));
                    string Batch = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Batch"));
                    string DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsOrderFormNo"));
                    if (ID > 0)
                    {

                        frmLoadOutWH frm = new frmLoadOutWH();
                        frm.PackType = (int)EnumPackType.仓库单据;
                        frm.IOFormID = HTDataID;
                        frm.ID = ID;
                        frm.WHID = WHID;
                        frm.SectionID = SectionID;
                        frm.SBitID = SBitID;
                        frm.ItemCode = ItemCode;
                        frm.ColorNum = ColorNum;
                        frm.ColorName = ColorName;
                        frm.JarNum = JarNum;
                        frm.Batch = Batch;
                        frm.KPButtonFlag = true;
                        frm.OrderFormNo = DtsOrderFormNo;
                        frm.WHType = SysConvert.ToInt32(Common.GetWHTypeByWHID(WHID));

                        frm.ShowDialog();
                        if (frm.SaveFlag)//如果保存则刷新数据
                        {
                            BindGridDts();
                            ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { ID.ToString() });
                            gridViewRowChanged2(gridView1);
                        }
                    }
                }
                else
                {
                    this.ShowMessage("单据已提交，不允许编辑码单");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
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
                    //string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHID"));
                    //string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SectionID"));
                    //Common.BindSection(drpGridSectionID, WHID, false);
                    //Common.BindSBit(drpSBit, WHID, SectionID, true);
                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                    string sql = string.Empty;

                    string inputUnit = string.Empty;
                    decimal inputConvertXS = 0;
                    inputUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "InputUnit"));
                    inputConvertXS = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputConvertXS"));
                    sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,Weight,Yard,GoodsLevel,'' ItemModel,'' JarNum,InputQty FROM WH_IOFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
                    DataTable dt = SysUtils.Fill(sql);

                    BindUCFabView(dt, inputUnit, inputConvertXS);
                }
                gridView1.Focus();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 绑定面料显示控件
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="inputUnit">转换单位</param>
        /// <param name="inputConvertXS">转换系数</param>
        void BindUCFabView(DataTable dtSource, string inputUnit, decimal inputConvertXS)
        {
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
            //{
            ucFabView1.UCQtyConvertMode = true;
            //ucFabView1.UCQtyConvertModeInputUnit = inputUnit;
            //ucFabView1.UCQtyConvertModeInputConvertXS = inputConvertXS;
            //}
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//成品仓库不使用码单模式
            //{
            //6402 6404必须相左设置的
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6404)))//成品仓库出库支持录入码单
            //{
            //ucFabView1.UCColumnISNHide = true;//隐藏条码列
            //    }
            //}
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
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
                    if (Common.CheckLookUpEditBlank(drpSubType))
                    {
                        this.ShowMessage("请选择单据类型");
                        return;
                    }
                    switch (saveLoadFormType)
                    {
                        case (int)LoadFormType.染布加工单:
                            SetWHLoadFabricProcessForm();
                            break;

                        case (int)LoadFormType.外销订单:
                            WHLoadSaleFormSetWH(gridView1, drpVendorID, (int)LoadFormType.外销订单);
                            break;
                        case (int)LoadFormType.内销订单:
                            WHLoadSaleFormSetWH(gridView1, drpVendorID, (int)LoadFormType.内销订单);
                            break;
                        case (int)LoadFormType.销售订单:  //坯布出库加载坯布订单
                            WHLoadSaleOrderFormPB();
                            break;
                        default:
                            LoadRelFormData(saveLoadFormType, gridView1, drpVendorID);
                            break;

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// 加载销售合同  加载坯布订单
        /// </summary>
        private void WHLoadSaleOrderFormPB()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择单位");
                drpVendorID.Focus();
                return;
            }
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;
            frm.ExtraCondition = " and FAid = 1 ";//加载坯布的订单

            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {

                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                WHLoadSaleOrderFormSetWHPB(str);

            }
        }
        /// <summary>
        /// 加载销售合同
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadSaleOrderFormSetWHPB(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//只有一行明细数据
                {
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    //gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    //gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
                    //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    //switch (saveFillDataType)
                    //{
                    //    case (int)EnumFillDataType.销售出库标准回填方法:
                    //        gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    //        break;
                    //    //case (int)EnumFillDataType.调样销售出库标准回填方法:
                    //    //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsDYFormNo"]));
                    //    //    break;
                    //}
                    gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));//DtsOrderFormNo
                    gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["SaleOPID"]));

                    string Unit = SysConvert.ToString(dt.Rows[0]["Unit"]);
                    if (Unit.EndsWith("KG"))
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else if (Unit.EndsWith("M"))
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }

                    //if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    //}

                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    }



                    gridView1.SetRowCellValue(setRowID, "InputQty", SysConvert.ToDecimal(dt.Rows[0]["InputQty"]));
                    gridView1.SetRowCellValue(setRowID, "InputUnit", SysConvert.ToString(dt.Rows[0]["InputUnit"]));
                    gridView1.SetRowCellValue(setRowID, "InputSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["InputSinglePrice"]));
                    gridView1.SetRowCellValue(setRowID, "InputAmount", SysConvert.ToDecimal(dt.Rows[0]["InputAmount"]));
                    gridView1.SetRowCellValue(setRowID, "InputConvertXS", SysConvert.ToDecimal(dt.Rows[0]["InputConvertXS"]));


                    string outsectionID, outSbitID;
                    //WHLoadFHFormSetWH(dt.Rows[0], out outsectionID, out outSbitID);

                    //p_Grid.SetRowCellValue(setRowID, "SectionID", outsectionID);
                    //p_Grid.SetRowCellValue(setRowID, "SBitID", outSbitID);
                    gridView1.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));
                    setRowID++;
                }
            }
        }

        /// <summary>
        /// 加载加工单
        /// </summary>
        private void SetWHLoadFabricProcessForm()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择" + drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadWOProcess frm = new frmLoadWOProcess();
            frm.ProcessTypeID = (int)EnumProcessType.染整加工单;
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {
                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadFabricProcessFormSetWH(str);

            }
        }

        /// <summary>
        /// 加载染布加工单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricProcessFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_FabricProcessDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));//单据单号
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));//销售订单号
                    gridView1.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));//销售客户

                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["CPItemCode"]));//坯布编码
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["CPItemName"]));//坯布--
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["CPItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["CPItemModel"]));

                    //gridView1.SetRowCellValue(setRowID, "Weight", SysConvert.ToDecimal(dt.Rows[0]["PBWeight"]));//坯布重量

                    gridView1.SetRowCellValue(setRowID, "LoadWeight", SysConvert.ToDecimal(dt.Rows[0]["PBWeight"]));
                    gridView1.SetRowCellValue(setRowID, "LoadPieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));

                    gridView1.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToInt32(dt.Rows[0]["DtsID"]));//

                    gridView1.SetRowCellValue(setRowID, "TotalOutQty", SysConvert.ToDecimal(dt.Rows[0]["OutQty"]));

                    //gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    //gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    //gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    //gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SingPrice"]));
                    //gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    //gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    //gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));

                    //gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    //gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    //}

                    //gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));

                    //gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));

                    //if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    //}
                    //else
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    //}

                    setRowID++;
                }
            }
        }



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
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].Yard = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Yard"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));
                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));
                    entitydts[index].InputQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputQty"));
                    entitydts[index].InputUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "InputUnit"));
                    entitydts[index].InputSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputSinglePrice"));
                    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice;
                    entitydts[index].InputConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputConvertXS"));
                    if (entitydts[index].Unit == "RMB/KG" || entitydts[index].Unit == "USD/KG")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Weight + entitydts[index].DYPrice;

                    }
                    if (entitydts[index].Unit == "RMB/M" || entitydts[index].Unit == "USD/M")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty + entitydts[index].DYPrice;
                    }
                    if (entitydts[index].Unit == "RMB/Y" || entitydts[index].Unit == "USD/Y")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Yard + entitydts[index].DYPrice;
                    }
                    //entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty + entitydts[index].DYPrice;
                    entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
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

                    entitydts[index].LoadPieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadPieceQty"));
                    entitydts[index].LoadWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "LoadWeight"));

                    entitydts[index].TotalOutQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalOutQty"));

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
                IOForm entity = new IOForm();
                entity.ID = HTDataID;
                entity.SelectByID();
                if (entity.ReadFlag == 1)
                {
                    this.ShowMessage("该单据已阅不能撤销提交");
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            if (e.Column.FieldName == "SingPrice" || e.Column.FieldName == "Qty" || e.Column.FieldName == "Weight" || e.Column.FieldName == "Yard" || e.Column.FieldName == "Unit")
            {
                ColumnView view = sender as ColumnView;
                decimal singprice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SingPrice"));
                decimal qty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Qty"));
                decimal weight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Weight"));
                decimal yard = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Yard"));
                string Unit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Unit"));
                decimal Amount = 0m;
                //DateTime DtsReqDate = DateTime.Now.Date;
                if (Unit == "RMB/KG" || Unit == "USD/KG")
                {
                    Amount = SysConvert.ToDecimal(singprice * weight, 2);
                }
                if (Unit == "RMB/M" || Unit == "USD/M")
                {
                    Amount = SysConvert.ToDecimal(singprice * qty, 2);
                }
                if (Unit == "RMB/Y" || Unit == "USD/Y")
                {
                    Amount = SysConvert.ToDecimal(singprice * yard, 2);
                }
                view.SetRowCellValue(view.FocusedRowHandle, "Amount", Amount);
                //view.SetRowCellValue(view.FocusedRowHandle, "DtsReqDate", DtsReqDate);
            }
            if (e.Column.FieldName == "SBitID")
            {
                string SBitID = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "SBitID"));
                string sql = "SELECT * FROM WH_SBit WHERE SBitID =" + SysString.ToDBString(SBitID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                    gridView1.SetRowCellValue(e.RowHandle, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                }
            }
        }

    }
}
