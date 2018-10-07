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
using System.Collections;
using HttSoft.WinUIBase;
using System.Web.UI.WebControls;
using DevExpress.XtraEditors;

namespace MLTERP
{
    public partial class frmProductInWHEdit : frmModuleBaseWHEdit
    {
        #region 全局变量
        /// <summary>
        /// 加载页面类型
        /// </summary>
        int saveLoadFormType = 0;
        /// <summary>
        /// 加载页面查询条件
        /// </summary>
        string saveTHLoadFormListIDStr = string.Empty;
        #endregion
        public frmProductInWHEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {

            if (txtFormNo.Text.Trim() == string.Empty)
            {
                this.ShowMessage("请输入入库单号");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择进货单位");
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
        /// 新增
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


            string sql = "SELECT * FROM Enum_FormList WHERE ID=" + this.FormListAID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0]["DefaultSubTypeID"]) != 0)
                {
                    drpSubType.EditValue = SysConvert.ToInt32(dt.Rows[0]["DefaultSubTypeID"]);
                }
                if (SysConvert.ToString(dt.Rows[0]["DefaultVendorID"]) != "")
                {
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["DefaultVendorID"]);
                }
            }
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段 ,"Qty", "SectionID"
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.业务部, (int)EnumOPDep.仓库 }, true);
            Common.BindWHByFormList(drpWH, this.FormListAID, true);
            Common.BindSBit(drpSBitID, this.FormListAID.ToString(), true);
            // Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            Common.BindSubType(drpSubType, this.FormListAID, true);             //入库类型绑定
            ParamSetRule psrule = new ParamSetRule();
            Common.BindCLS(drpUnit, "Sale_SaleOrder", "Unit", true);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载单据", false, btnLoad_Click);
        }

        public override void IniFormLoadBehind()
        {
            base.IniFormLoadBehind();
            ContextMenuStrip _MenuFrist = this.HTDataDts.GridControl.ContextMenuStrip as ContextMenuStrip;
            HTAPAddContextMenu(_MenuFrist, "设置细码", cMenu_Click);
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
                    int PackFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackFlag"));
                    int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MainID"));
                    int Seq = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Seq"));
                    decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));
                    if (ID > 0)
                    {
                        frmLoadPackNo frm = new frmLoadPackNo();
                        frm.PackType = (int)EnumPackType.仓库单据;
                        frm.ID = ID;
                        frm.MainID = MainID;
                        frm.Seq = Seq;
                        frm.Qty = Qty;
                        if (PackFlag == 1)//有码单明细
                        {
                            frm.UpdateFlag = true;
                        }
                        frm.ShowDialog();
                        if (frm.SaveFlag)//如果保存则刷新数据
                        {
                            BindGridDts();
                            ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { ID.ToString() });
                            gridViewRowChanged2(gridView1);
                        }
                    }

                }
                else//提交状态
                {
                    this.ShowMessage("单据已提交，不允许编辑码单");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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
            entity.SubType = SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.WHTypeID = SysConvert.ToInt32(Common.GetWHTypeByFormListID(this.FormListAID));
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeadType = this.FormListAID;
            txtMakeOPName.Text = entity.MakeOPName;
            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = DateTime.Now;
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
                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));

                    entitydts[index].OrderQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "OrderQty"));
                    entitydts[index].OrderUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "OrderUnit"));

                    entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].Yard = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Yard"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    if (entitydts[index].Unit == "RMB/KG" || entitydts[index].Unit == "USD/KG")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Weight;
                    }
                    if (entitydts[index].Unit == "RMB/M" || entitydts[index].Unit == "USD/M")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                    }
                    if (entitydts[index].Unit == "RMB/Y" || entitydts[index].Unit == "USD/Y")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Yard;
                    }
                    entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));

                    entitydts[index].TotalInQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalInQty"));

                    index++;
                }
            }
            return entitydts;
        }
        #endregion
        #region 加载事件
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
                            WHLoadFabricRZ((int)EnumProcessType.染整加工单);
                            break;
                        case (int)LoadFormType.其他加工单:  //后整加工入库
                            WHLoadFabricHZForm((int)EnumProcessType.其他加工单);
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


        /// <summary>
        /// 加载后整加工单
        /// </summary>
        private void WHLoadFabricHZForm(int p_ProcessTypeID)
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择" + drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadWOProcess frm = new frmLoadWOProcess();
            frm.ProcessTypeID = p_ProcessTypeID;// (int)EnumProcessType.染整加工单;
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            sql = " and FormNo+ItemCode+ColorNum not in (select isnull(DtsSO+ItemCode+ColorNum,'') from UV1_WH_IOFormDts )";
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
                WHLoadFabricProcessHZSetWH(str);

            }
        }

        /// <summary>
        /// 加载后整加工单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricProcessHZSetWH(string p_Str)
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

                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SingPrice"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));

                    gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    gridView1.SetRowCellValue(setRowID, "OrderUnit", SysConvert.ToString(dt.Rows[0]["OrderUnit"]));
                    gridView1.SetRowCellValue(setRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["OrderQty"]));

                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    //{
                    //    p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    //}

                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")  //织造加工单 坯布重量 为Qty
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }

                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));

                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }

                    gridView1.SetRowCellValue(setRowID, "LoadPieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    gridView1.SetRowCellValue(setRowID, "LoadQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(setRowID, "LoadWeight", SysConvert.ToDecimal(dt.Rows[0]["PieceWeight"]));

                    gridView1.SetRowCellValue(setRowID, "TotalInQty", SysConvert.ToDecimal(dt.Rows[0]["CPInQty"]));


                    setRowID++;
                }
            }
        }
        #endregion

        /// <summary>
        /// 加载染整加工单
        /// </summary>
        private void WHLoadFabricRZ(int p_ProcessTypeID)
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择" + drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadWOProcess frm = new frmLoadWOProcess();
            frm.ProcessTypeID = p_ProcessTypeID;// (int)EnumProcessType.染整加工单;
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            sql = " and FormNo+ItemCode+ColorNum not in (select isnull(DtsSO+ItemCode+ColorNum,'') from UV1_WH_IOFormDts )";
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
                WHLoadFabricProcessRZ(str);

            }
        }

        /// <summary>
        /// 加载染布加工单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricProcessRZ(string p_Str)
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

                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SingPrice"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));

                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));

                    gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    gridView1.SetRowCellValue(setRowID, "OrderUnit", SysConvert.ToString(dt.Rows[0]["OrderUnit"]));
                    gridView1.SetRowCellValue(setRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["OrderQty"]));

                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    //if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    //{
                    //    p_Grid.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    //}

                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }

                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));

                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));

                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }

                    gridView1.SetRowCellValue(setRowID, "LoadPieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    gridView1.SetRowCellValue(setRowID, "LoadQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(setRowID, "LoadWeight", SysConvert.ToDecimal(dt.Rows[0]["PieceWeight"]));

                    gridView1.SetRowCellValue(setRowID, "TotalInQty", SysConvert.ToDecimal(dt.Rows[0]["CPInQty"]));


                    setRowID++;
                }
            }
        }


        /// <summary>
        /// GridView1换行事件
        /// </summary>
        /// <param name="sender"></param>
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
                    //Common.BindSection(drpGridSectionID, WHID, true);
                    //Common.BindSBit(drpSBit, WHID, SectionID, true);

                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                    string sql = string.Empty;
                    sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,Weight,Yard,GoodsLevel,'' ItemModel,'' JarNum FROM WH_IOFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
                    DataTable dt = SysUtils.Fill(sql);
                    BindUCFabView(dt);
                }
                gridView1.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        void BindUCFabView(DataTable dtSource)
        {
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
        }
        /// <summary>
        /// 单号自动生成
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
                Common.BindVendorByFormListID(drpVendorID, SysConvert.ToInt32(drpSubType.EditValue), true);//设置客户
                string sql = "SELECT * FROM Enum_FormList WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"].ToString());
                    saveTHLoadFormListIDStr = dt.Rows[0]["THLoadFormListIDStr"].ToString();
                    string VendorCaption = dt.Rows[0]["VendorIDCaption"].ToString();
                    if (VendorCaption != string.Empty)
                    {
                        labVendorID.Text = VendorCaption;
                        drpVendorID.ToolTip = VendorCaption;
                    }
                }
                else
                {
                    saveLoadFormType = 0;//清空加载类型
                    saveTHLoadFormListIDStr = string.Empty;//清空加载默认条件
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 检验空行
        /// </summary>
        /// <returns></returns>
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

        #region 提交，撤销提交
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
                if (!CheckCorrect())
                {
                    return;
                }

                IOFormRule rule = new IOFormRule();
                string o_ErrorMsg = string.Empty;

                //if (!rule.RCheckCorrectPackData(HTDataID, out o_ErrorMsg))// 如果校验不通过
                //{
                //    this.ShowMessage(o_ErrorMsg);
                //    return;
                //}

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

                if (!CheckLastUpdateDay(txtFormDate.DateTime))
                {
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
