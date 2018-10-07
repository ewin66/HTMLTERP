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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.UCFab;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：面料出库单
    /// 
    /// FormListAID=12 FormlistBID=0 //成品出库单
    /// 
    /// FormListAID=12 FormlistBID=2 //样品出库单
    /// </summary>
    public partial class frmZPOutWHEdit : frmModuleBaseWHEdit
    {
        public frmZPOutWHEdit()
        {
            InitializeComponent();
        }

        #region 全局变量

        private DataTable[] dtPack = new DataTable[150];//码单信息表
        private int PreRowID = -1;//初始行号
        private int CurRowID = -1;//当前行号
        int saveNoLoadCheckDayNum = 0;//未加载比对天数，防止随着时间的推移系统变慢
        int saveLoadFormType = 0;//加载单据类型
        int saveFillDataType = 0;//回填数据类型

        string saveTHLoadFormListIDStr = string.Empty;

        //private int DtsID = 0;
        //private int DtsSeq = 0;
        #endregion
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
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

            if (SysConvert.ToString(drpWHID.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择仓库");
                drpWHID.Focus();
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

            if (saveLoadFormType == (int)LoadFormType.送货单)
            {
                if (!this.CheckCorrectDts2())
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckCorrectDts2()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                string DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                string VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                string VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                int PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                if (DtsSO != "")
                {
                    string sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(DtsSO);
                    sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
                    sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                    sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                    sql += " AND VColorNum=" + SysString.ToDBString(VColorNum);
                    sql += " AND VColorName=" + SysString.ToDBString(VColorName);
                    sql += " AND JarNum=" + SysString.ToDBString(JarNum);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0]["PieceQty"]) != PieceQty)
                        {
                            if (MessageBox.Show("第" + SysConvert.ToInt32(i + 1).ToString() + "行数据细码数与发货单中细码数不一样，发货单的细码数是：" + SysConvert.ToInt32(dt.Rows[0]["PieceQty"]).ToString() + "，是否继续保存", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (SysConvert.ToDecimal(dt.Rows[0]["Qty"]) != Qty)
                        {
                            if (MessageBox.Show("第" + SysConvert.ToInt32(i + 1).ToString() + "行数据数量与发货单中数量不一样，发货单的数量是：" + SysConvert.ToDecimal(dt.Rows[0]["Qty"]).ToString() + "，是否继续保存", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
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
            //decimal PackAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
                //PackAmount += SysConvert.ToDecimal(entitydts[i].PackQty) * SysConvert.ToDecimal(entitydts[i].PackSinglePrice);
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.PackAmount = SysConvert.ToDecimal(textPackQty.Text.Trim()) * SysConvert.ToDecimal(textPackSinglePrice.Text.Trim());
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
            entity.PackAmount = SysConvert.ToDecimal(textPackQty.Text.Trim()) * SysConvert.ToDecimal(textPackSinglePrice.Text.Trim());
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
            drpXZ.EditValue = entity.XZ.ToString();
            drpWHID.EditValue = entity.WHID.ToString();
            drpSubType.EditValue = entity.SubType;
            txtDM.Text = entity.DM.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtInvoiceNo.Text = entity.InvoiceNo.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtRemark.Text = entity.Remark;
            drpFHTypeID.EditValue = SysConvert.ToInt32(entity.FHTypeID);
            txtKDNo.Text = entity.KDNo.ToString();
            txtMakeOPName.Text = entity.MakeOPName;
            drpAddress.EditValue = entity.Address;
            txtDescription.Text = entity.Description.ToString();
            txtDestination.Text = entity.Destination.ToString();
            drpVendorOPID.EditValue = entity.VendorOPID;
            txtVendorTel.Text = entity.VendorTel;

            textPackQty.Text = entity.PackQty.ToString();//0000000000000000000000
            textPackSinglePrice.Text = entity.PackSinglePrice.ToString();//0000000000000000000000
            textPackAmount.Text = entity.PackAmount.ToString();//0000000000000000000000

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }

            BindGridDts();
            //SetIOFormDetail();
            //BindPack();
        }

        /// <summary>
        /// 得到码单的数据
        /// </summary>
        /// <param name="List"></param>
        private void GetMadanDts(ArrayList List)
        {
            BaseFocusLabel.Focus();
            for (int j = 0; j < gridView1.RowCount; j++)//
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) != string.Empty)
                {
                    for (int m = 0; m < dtPack[j].Rows.Count; m++)//码单循环
                    {

                        if ((dtPack[j].Rows[m]["PackNo"].ToString() != string.Empty || SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]) != 0))
                        {
                            IOFormDtsPack entity = new IOFormDtsPack();
                            entity.MainID = HTDataID;
                            entity.Seq = j + 1;
                            entity.SubSeq = m + 1;

                            entity.BoxNo = dtPack[j].Rows[m]["BoxNo"].ToString();
                            entity.Qty = SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]);
                            entity.Remark = SysConvert.ToString(dtPack[j].Rows[m]["Remark"]);


                            List.Add(entity);

                        }
                    }
                }
            }
        }
        //private void SetIOFormDetail()
        //{

        //    #region
        //    int TempID = -1;
        //    int PSeq = -1;
        //    int j = 0;//控制gridview的行号
        //    string sql = string.Empty;
        //    sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
        //    DataTable dt = SysUtils.Fill(sql);
        //    for (int i = 0; i < 150; i++)
        //    {
        //        dtPack[i] = dt.Clone();
        //    }
        //    DataTable dtVirtual = (DataTable)gridView1.GridControl.DataSource;
        //    foreach (DataRow dr in dtVirtual.Rows)
        //    {
        //        if (dr["ItemCode"].ToString() != string.Empty)
        //        {
        //            if (dr["Seq"].ToString() == string.Empty)
        //            {
        //                PSeq = j;
        //            }
        //            else
        //            {
        //                PSeq = SysConvert.ToInt32(dr["Seq"].ToString()) - 1;
        //            }

        //            if (this.HTFormStatus == FormStatus.新增)
        //            {
        //                sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
        //                TempID = SysUtils.Fill(sql).Rows.Count;
        //                dtPack[PSeq] = SysUtils.Fill(sql);
        //                j++;
        //            }
        //            else
        //            {
        //                sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=1";
        //                sql += " AND MainID=" + SysString.ToDBString(dr["MainID"].ToString());
        //                sql += " AND Seq=" + SysString.ToDBString(dr["Seq"].ToString());

        //                dtPack[PSeq] = SysUtils.Fill(sql);
        //            }
        //        }
        //    }
        //    for (int i = 0; i < 150; i++)
        //    {
        //        Common.AddDtRow(dtPack[i], 150);
        //    }
        //    #endregion
        //}

        /// <summary>
        /// 绑定面料显示控件
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="inputUnit">转换单位</param>
        /// <param name="inputConvertXS">转换系数</param>
        void BindUCFabView(DataTable dtSource, string inputUnit, decimal inputConvertXS)
        {
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
            {
                ucFabView1.UCQtyConvertMode = true;
                ucFabView1.UCQtyConvertModeInputUnit = inputUnit;
                ucFabView1.UCQtyConvertModeInputConvertXS = inputConvertXS;
            }
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//成品仓库不使用码单模式
            //{
            //    //6402 6404必须相左设置的
            //    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6404)))//成品仓库出库支持录入码单
            //    {
            ucFabView1.UCColumnISNHide = true;//隐藏条码列
            //    }
            //}
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
        }


        ///// <summary>
        ///// 绑定码单
        ///// </summary>
        //private void BindPack()
        //{
        //    if (CurRowID >= 0)
        //    {
        //        DataTable dt = dtPack[CurRowID];
        //        gridView2.GridControl.DataSource = dt;
        //        gridView2.GridControl.Show();
        //    }
        //}


        ///// <summary>
        ///// 获取码单信息
        ///// </summary>
        //private void GetMaDanDetail(int p_RowID)
        //{
        //    BaseFocusLabel.Focus();
        //    if (SysConvert.ToString(gridView1.GetRowCellValue(PreRowID, "ItemCode")) != string.Empty)
        //    {
        //        for (int i = 0; i < gridView2.RowCount; i++)
        //        {
        //            dtPack[p_RowID].Rows[i]["MainID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["MainID"]));
        //            dtPack[p_RowID].Rows[i]["Seq"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["Seq"]));
        //            dtPack[p_RowID].Rows[i]["SubSeq"] = PreRowID + 1;

        //            dtPack[p_RowID].Rows[i]["BoxNo"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["BoxNo"]));
        //            dtPack[p_RowID].Rows[i]["Qty"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"]));
        //            dtPack[p_RowID].Rows[i]["Remark"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["Remark"]));
        //        }
        //    }
        //}
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
            textPackSinglePrice.Text = "5";//打包单价默认5元

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;
            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2};
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段 ,"Qty"
            //Common.BindOP(drpSaleOPID, true);
            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }
            Common.BindVendor2(drpVendorID, (int)EnumVendorType.客户, true);
            //new VendorProc(drpVendorID);
            Common.BindWHByFormList(drpWHID, this.FormListAID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            Common.BindSubType(drpSubType, this.FormListAID, true);
            Common.BindFHType(drpFHTypeID, true);
            // Common.BindWHByFormList(drp, SysConvert.ToInt32(drpSubType.EditValue), true);
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            //Common.BindEnumUnit(RestxtUnit, true);

            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitFab", true);
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加载单据", false, btnLoad_Click);
            //this.ToolBarItemAdd(28, "btnUpdateAmount", "修改单价", false, btnUpdateAmount_Click);

            this.ToolBarItemAdd(28, "btnSetRecordOPID", "设置【上布员】【运输员】", false, btnSetRecordOPID_Click);

            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;
            //gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;

            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//成品仓库不使用码单模式
            //{
            //    btnToGBDetail.Visible = false;//隐藏操作按钮
            //    groupControlBottom.Visible = false;//码单隐藏

            //    //6402 6404必须相左设置的
            //    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6404)))//成品仓库出库支持录入码单
            //    {
            //        btnToGBDetailInput.Visible = true;//显示操作按钮
            //        groupControlBottom.Visible = true;//码单显示

            //        btnToGBDetailCZ.Visible = true;
            //    }
            //}




        }

        /// <summary>
        /// 修改单价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnUpdateAmount_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.查询)
                {
                    if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限10))
                    {
                        this.ShowMessage("没有此权限，请联系管理员");
                        return;
                    }
                    if (HTDataID == 0)
                    {
                        this.ShowMessage("请保存单据");
                        return;
                    }
                    frmUpdateWHAmount frm = new frmUpdateWHAmount();
                    frm.ID = HTDataID;
                    frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    frm.ShowDialog();
                    BindGridDts();
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.DtsID.ToString() });
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 通用窗体加载方法，如果不要使用，则重写，一般不要修改
        /// </summary>
        public override void IniFormLoadBehind()
        {
            //ProcessGrid.SetGridColumnReadOnly(gridView2, new string[] { "BoxNo", "Qty" }, true);

        }



        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                    string sql = string.Empty;

                    string inputUnit = string.Empty;
                    decimal inputConvertXS = 0;
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
                    {
                        inputUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "InputUnit"));
                        inputConvertXS = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputConvertXS"));
                    }


                    //if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//非 成品仓库不使用码单模式
                    //{
                    sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum,InputQty FROM WH_IOFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
                    DataTable dt = SysUtils.Fill(sql);

                    BindUCFabView(dt, inputUnit, inputConvertXS);
                    //}

                    //else if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6404)))//成品仓库出库支持录入码单
                    //{
                    //sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum,InputQty FROM WH_IOFormDtsInputPack WHERE DID= " + SysString.ToDBString(ID);
                    //DataTable dt = SysUtils.Fill(sql);

                    //BindUCFabView(dt, inputUnit, inputConvertXS);
                    //}

                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetGrid(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToDecimal(dr["Qty1"]) == 0)
                {
                    dr["Qty1"] = DBNull.Value;
                    dr["PackNo1"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty2"]) == 0)
                {
                    dr["Qty2"] = DBNull.Value;
                    dr["PackNo2"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty3"]) == 0)
                {
                    dr["Qty3"] = DBNull.Value;
                    dr["PackNo3"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty4"]) == 0)
                {
                    dr["Qty4"] = DBNull.Value;
                    dr["PackNo4"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty5"]) == 0)
                {
                    dr["Qty5"] = DBNull.Value;
                    dr["PackNo5"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty6"]) == 0)
                {
                    dr["Qty6"] = DBNull.Value;
                    dr["PackNo6"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty7"]) == 0)
                {
                    dr["Qty7"] = DBNull.Value;
                    dr["PackNo7"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty8"]) == 0)
                {
                    dr["Qty8"] = DBNull.Value;
                    dr["PackNo8"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty9"]) == 0)
                {
                    dr["Qty9"] = DBNull.Value;
                    dr["PackNo9"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty10"]) == 0)
                {
                    dr["Qty10"] = DBNull.Value;
                    dr["PackNo10"] = DBNull.Value;
                }
            }
        }
        /// <summary>
        /// 加载库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadStorge_Click(object sender, EventArgs e)
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

                    if (SysConvert.ToString(drpWHID.EditValue) == "")
                    {
                        this.ShowMessage("请选择仓库");
                        drpWHID.Focus();
                        return;
                    }
                    frmLoadStorge frm = new frmLoadStorge();
                    frm.WHID = SysConvert.ToString(drpWHID.EditValue);
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
                        SetWH(str);

                    }


                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载采购单
        /// </summary>
        private void WHLoadItemBuyForm()
        {
            frmLoadItemBuy frm = new frmLoadItemBuy();
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
                SetWH(str);


            }
        }

        /// <summary>
        /// 加载库存信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void SetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_Storge WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(setRowID, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                    gridView1.SetRowCellValue(setRowID, "SBitID", SysConvert.ToString(dt.Rows[0]["SBitID"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));

                    gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));

                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));

                    gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["DutyOPID"]));
                    setRowID++;
                }
            }
        }
        #endregion

        #region 自定义方法
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
            entity.XZ = drpXZ.Text.Trim();
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.WHType = drpWHID.EditValue.ToString();
            entity.SubType = SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();

            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
            entity.VendorTel = txtVendorTel.Text.Trim();

           // entity.PackQty = SysConvert.ToDecimal(textPackQty.Text.Trim());
            entity.PackSinglePrice = SysConvert.ToDecimal(textPackSinglePrice.Text.Trim());
            entity.PackAmount = SysConvert.ToDecimal(textPackAmount.Text.Trim());

            //entity.DM = txtDM.Text.Trim();
            // entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.Description = txtDescription.Text.Trim();
            entity.Destination = txtDestination.Text.Trim();
            entity.HeadType = this.FormListAID;
            entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.KDNo = txtKDNo.Text.Trim();
            entity.FHTypeID = SysConvert.ToInt32(drpFHTypeID.EditValue);
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
                    entitydts[index].WHID = SysConvert.ToString(drpWHID.EditValue);
                    entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID"));
                    entitydts[index].SBitID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SBitID"));

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
                    //entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight")); 
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));

                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo")); //款号

                    ///2014.08.01 zhoufc  明炜
                    entitydts[index].VConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "VConvertXS"));
                    entitydts[index].QtyConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "QtyConvertXS"));
                    entitydts[index].Volume = entitydts[index].PieceQty * SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "VConvertXS")); //体积=匹数*体积系数
                    entitydts[index].Weight = entitydts[index].Qty + entitydts[index].PieceQty * SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "QtyConvertXS"));//毛重=净重+匹数*净重系数



                    entitydts[index].InputQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputQty"));
                    entitydts[index].InputUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "InputUnit"));
                    entitydts[index].InputSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputSinglePrice"));
                    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice;// +entitydts[index].FAmount1 + entitydts[index].FAmount2 + entitydts[index].FAmount3 + entitydts[index].FAmount4 + entitydts[index].FAmount5;
                    entitydts[index].InputConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputConvertXS"));

                    entitydts[index].GrossQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "GrossQty"));//毛数量
                    entitydts[index].GrossWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "GrossWeight"));//毛重
                    entitydts[index].NetWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "NetWeight"));//净重
                    entitydts[index].Description = SysConvert.ToString(gridView1.GetRowCellValue(i, "Description"));//描述
                    entitydts[index].Destination = SysConvert.ToString(gridView1.GetRowCellValue(i, "Destination"));//目的地

                    entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
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
                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));                    
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID"));
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));

                    entitydts[index].DtsInVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsInVendorID"));
                    entitydts[index].InSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSO"));
                    entitydts[index].InOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "InOrderFormNo"));
                    entitydts[index].InSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));
                    entitydts[index].LoadDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadDtsID"));

                    entitydts[index].MF = SysConvert.ToString(gridView1.GetRowCellValue(i, "MF"));
                    entitydts[index].KZ = SysConvert.ToString(gridView1.GetRowCellValue(i, "KZ"));


                    if ((SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5404)) && entitydts[index].InputUnit != string.Empty)//销售订单使用下单数量制单时确定是否需要单位转换模式及计算方法类型 默认否，此功能设置为是时，5405应设置为0
                      || SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
                    {
                        entitydts[index].InputQty = ProductCommon.UnitConvertValueAnyUnit(entitydts[index].Unit, entitydts[index].Qty, entitydts[index].InputUnit, entitydts[index].InputConvertXS);
                        entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice;
                        entitydts[index].SinglePrice = SysConvert.ToDecimal(entitydts[index].InputSinglePrice * entitydts[index].InputConvertXS, 2);
                        entitydts[index].Amount = entitydts[index].InputAmount;


                    }




                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region 加载数据相关
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
                        case (int)LoadFormType.送货单:
                            WHLoadFHForm();
                            break;
                        case (int)LoadFormType.剪样发货单:
                            WHLoadFHForm2();
                            break;
                        case (int)LoadFormType.销售订单:
                            WHLoadSaleOrderForm();
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

        #region 加载销售订单
        /// <summary>
        /// 加载送货单
        /// </summary>
        private void WHLoadSaleOrderForm()
        {

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return;
            }
            int SubType = SysConvert.ToInt32(drpSubType.EditValue);

            frmLoadOrder frm = new frmLoadOrder();


            string sql = string.Empty;
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(OrderFormNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WO_FabricProcessDts";
            //sql += " AND FormNo NOT IN(SELECT ISNULL(DtsSO,'') DtsSO FROM UV1_WO_FabricProcessDts";

            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += " and ProcessTypeID = 4 )";//其它加工
            frm.NoLoadCondition = sql;
            frm.CheckFlag = 1;

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6424)))//仓库出库选择客户直接带出该客户相关单据
            {
                frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            }

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

                WHLoadSaleOrderFormSetWH(str, SubType);
            }
            //if (frm.FHFormID != null && frm.FHFormID.Length != 0)
            //{

            //    for (int i = 0; i < frm.FHFormID.Length; i++)
            //    {
            //        if (str != string.Empty)
            //        {
            //            str += ",";
            //        }
            //        str += SysConvert.ToString(frm.FHFormID[i]);
            //    }
            //    WHLoadSaleOrderFormSetWH(str, SubType);

            //    if (HTDataID == 0)
            //    {
            //        HTDataID = EntityAdd();
            //        gridViewRowChanged2(gridView1);
            //        BindGridDts();
            //        SetFormStatus(FormStatus.查询);
            //        SetPosStatus(HTDataID);
            //    }



            //}
        }

        private void WHLoadSaleOrderFormSetWH(string p_Str, int p_SubType)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] fhformid = p_Str.Split(',');
            for (int i = 0; i < fhformid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(fhformid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
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

                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }

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
                    WHLoadFHFormSetWH(dt.Rows[0], out outsectionID, out outSbitID);

                    gridView1.SetRowCellValue(setRowID, "SectionID", outsectionID);
                    gridView1.SetRowCellValue(setRowID, "SBitID", outSbitID);
                    gridView1.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));
                    setRowID++;
                }
            }
        }


        #endregion

        #region 加载送货单
        /// <summary>
        /// 加载送货单
        /// </summary>
        private void WHLoadFHForm()
        {
            if (SysConvert.ToInt32(drpSubType.EditValue) == 0)
            {
                this.ShowMessage("请选择出库类型");
                drpSubType.Focus();
                return;
            }

            //if (SysConvert.ToString(drpVendorID.EditValue) == "")
            //{
            //    this.ShowMessage("请选择客户");
            //    drpVendorID.Focus();
            //    return;
            //}
            int SubType = SysConvert.ToInt32(drpSubType.EditValue);
            frmLoadFHForm frm = new frmLoadFHForm();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT DtsSO+ItemCode+ColorNum+ColorName OrderFormNo FROM UV1_WH_IOFormDts";
            if (saveNoLoadCheckDayNum != 0)
            {
                sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            sql += ")";
            frm.NoLoadCondition = sql;
            switch (saveFillDataType)
            {
                case (int)EnumFillDataType.销售出库标准回填方法:
                    frm.SourceID = (int)EnumFHForType.销售合同;
                    break;
                //case (int)EnumFillDataType.调样销售出库标准回填方法:
                //    frm.SourceID=(int)EnumFHForType.调样单;
                //    break;

            }

            frm.ShowDialog();
            string str = string.Empty;
            if (frm.FHFormID != null)
            {
                for (int i = 0; i < frm.FHFormID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.FHFormID[i]);
                }

                WHLoadFHFormSetWH(str, SubType);
            }




            //if (frm.FHFormID != null && frm.FHFormID.Length != 0)
            //{

            //    for (int i = 0; i < frm.FHFormID.Length; i++)
            //    {
            //        if (str != string.Empty)
            //        {
            //            str += ",";
            //        }
            //        str += SysConvert.ToString(frm.FHFormID[i]);
            //    }
            //    WHLoadFHFormSetWH(str, SubType);

            //    if (HTDataID == 0)
            //    {
            //       HTDataID= EntityAdd();
            //       gridViewRowChanged2(gridView1);
            //       BindGridDts();
            //       SetFormStatus(FormStatus.查询);
            //       SetPosStatus(HTDataID);
            //    }



            //}
        }

        private void WHLoadFHFormSetWH(string p_Str, int p_SubType)
        {
            string[] fhformid = p_Str.Split(',');
            if (fhformid.Length == 1)
            {
                string sql = "SELECT * FROM  UV1_Sale_FHFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(fhformid[0]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    drpAddress.EditValue = SysConvert.ToString(dt.Rows[0]["Address"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    drpVendorOPID.EditValue = SysConvert.ToString(dt.Rows[0]["LXR"]);
                    txtVendorTel.Text = SysConvert.ToString(dt.Rows[0]["Tel"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);


                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        sql = "select SingPrice,GoodsCode,DtsOrderFormNo from UV1_Sale_FHFormDts where ID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                        sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")));
                        sql += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")));
                        sql += " AND ColorName=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")));
                        DataTable dts = SysUtils.Fill(sql);
                        if (dts.Rows.Count != 0)
                        {
                            gridView1.SetRowCellValue(i, "SinglePrice", SysConvert.ToDecimal(dts.Rows[0]["SingPrice"]));
                            gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dts.Rows[0]["GoodsCode"]));
                            gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dts.Rows[0]["DtsOrderFormNo"]));
                        }
                    }
                }
            }
            else
            {
                this.ShowMessage("请勾选一条数据加载！");
                return;
            }

            #region Old

            //int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            //string[] fhformid = p_Str.Split(',');
            //for (int i = 0; i < fhformid.Length; i++)
            //{
            //    string sql = "SELECT * FROM  UV1_Sale_FHFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(fhformid[i]));
            //    DataTable dt = SysUtils.Fill(sql);
            //    if (dt.Rows.Count == 1)
            //    {
            //        drpAddress.EditValue = SysConvert.ToString(dt.Rows[0]["Address"]);
            //        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
            //        drpVendorOPID.EditValue = SysConvert.ToString(dt.Rows[0]["LXR"]);
            //        txtVendorTel.Text = SysConvert.ToString(dt.Rows[0]["Tel"]);
            //        drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);

            //        gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
            //        gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
            //        gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
            //        gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
            //        gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
            //        gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
            //        gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
            //        gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
            //        gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
            //        gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
            //        gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
            //        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
            //        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
            //        gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
            //        gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
            //        gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
            //        gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
            //        gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
            //        gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
            //        gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
            //        //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
            //        switch (saveFillDataType)
            //        {
            //            case (int)EnumFillDataType.销售出库标准回填方法:
            //                gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
            //                break;
            //            //case (int)EnumFillDataType.调样销售出库标准回填方法:
            //            //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsDYFormNo"]));
            //            //    break;
            //        }
            //        gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
            //        gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["SaleOPID"]));

            //        if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
            //        {
            //            gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
            //        }

            //        if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
            //        {
            //            gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
            //        }
            //        if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
            //        {
            //            gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
            //        }



            //        gridView1.SetRowCellValue(i, "InputQty", SysConvert.ToDecimal(dt.Rows[0]["InputQty"]));
            //        gridView1.SetRowCellValue(i, "InputUnit", SysConvert.ToString(dt.Rows[0]["InputUnit"]));
            //        gridView1.SetRowCellValue(i, "InputSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["InputSinglePrice"]));
            //        gridView1.SetRowCellValue(i, "InputAmount", SysConvert.ToDecimal(dt.Rows[0]["InputAmount"]));
            //        gridView1.SetRowCellValue(i, "InputConvertXS", SysConvert.ToDecimal(dt.Rows[0]["InputConvertXS"]));


            //        string outsectionID, outSbitID;
            //        WHLoadFHFormSetWH(dt.Rows[0], out outsectionID, out outSbitID);

            //        gridView1.SetRowCellValue(setRowID, "SectionID", outsectionID);
            //        gridView1.SetRowCellValue(setRowID, "SBitID", outSbitID);
            //        gridView1.SetRowCellValue(setRowID, "LoadDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));
            //        setRowID++;
            //    }
            //}

            #endregion
        }

        /// <summary>
        /// 返回库存第一个区
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        void WHLoadFHFormSetWH(DataRow dr, out string o_SectionID, out string o_SBitID)
        {
            string outstr = string.Empty;
            string sql = string.Empty;
            sql = "SELECT SectionID,SBitID FROM WH_Storge WHERE WHID=" + SysString.ToDBString(SysConvert.ToString(drpWHID.EditValue));
            sql += " AND ItemCode=" + SysString.ToDBString(dr["ItemCode"].ToString());
            sql += " AND ColorNum=" + SysString.ToDBString(dr["ColorNum"].ToString());
            sql += " AND ColorName=" + SysString.ToDBString(dr["ColorName"].ToString());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                o_SectionID = SysConvert.ToString(dt.Rows[0]["SectionID"]);
                o_SBitID = SysConvert.ToString(dt.Rows[0]["SBitID"]);
            }
            else
            {
                o_SectionID = "";
                o_SBitID = "";
            }
            return;
        }
        #endregion

        #region 加载剪样发货单
        /// <summary>
        /// 加载送货单
        /// </summary>
        private void WHLoadFHForm2()
        {
            if (SysConvert.ToInt32(drpSubType.EditValue) == 0)
            {
                this.ShowMessage("请选择出库类型");
                drpSubType.Focus();
                return;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return;
            }
            int SubType = SysConvert.ToInt32(drpSubType.EditValue);
            frmLoadFHForm frm = new frmLoadFHForm();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT DtsSO+ItemCode+ColorNum+ColorName OrderFormNo FROM UV1_WH_IOFormDts";
            if (saveNoLoadCheckDayNum != 0)
            {
                sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            sql += ")";
            frm.NoLoadCondition = sql;
            frm.SourceID = (int)EnumFHForType.调样单;
            frm.ShowDialog();
            string str = string.Empty;

            for (int i = 0; i < frm.FHFormID.Length; i++)
            {
                if (str != string.Empty)
                {
                    str += ",";
                }
                str += SysConvert.ToString(frm.FHFormID[i]);
            }
            WHLoadFHFormSetWH(str, SubType);



        }


        #endregion


        #endregion

        #region 其它事件
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.出库单号);
                    txtFormNo.Text = rule.RGetWHFormNo(this.FormListAID, SysConvert.ToInt32(drpSubType.EditValue), SysConvert.ToString(drpWHID.EditValue));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 根据仓库选择区位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpWHType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.ProcHideSectionSbit(SysConvert.ToString(drpWHID.EditValue), gridView1);
                Common.BindSection(drpGridSectionID, SysConvert.ToString(drpWHID.EditValue), false);
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
                    saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"]);
                    saveFillDataType = SysConvert.ToInt32(dt.Rows[0]["FillDataTypeID"]);
                    saveTHLoadFormListIDStr = SysConvert.ToString(dt.Rows[0]["THLoadFormListIDStr"]);
                    if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//编辑状态下
                    {
                        if (dt.Rows[0]["DefaultWHID"].ToString() != string.Empty)
                        {
                            drpWHID.EditValue = dt.Rows[0]["DefaultWHID"].ToString();
                        }
                    }
                    string VendorCaption = dt.Rows[0]["VendorIDCaption"].ToString();
                    if (VendorCaption != string.Empty)
                    {
                        labVendorID.Text = VendorCaption;
                        //drpVendorID.ToolTip = VendorCaption;
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

                //if (!CheckCorrect())
                //{
                //    return;
                //}

                ////sc 出库提交前校验细码与库存细码是否对上
                //if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//非 成品仓库不使用码单模式
                //{
                for (int i = 0; i < ucFabView1.UCDataSource.Rows.Count; i++)
                {
                    string sql = "SELECT Qty FROM WH_PackBox WHERE BoxNo = " + SysString.ToDBString(SysConvert.ToString((ucFabView1.UCDataSource.Rows[i]["BoxNo"])));
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToDecimal(ucFabView1.UCDataSource.Rows[i]["Qty"]) != SysConvert.ToDecimal(dt.Rows[0]["Qty"]))
                        {
                            this.ShowMessage("此细码:" + SysConvert.ToString(ucFabView1.UCDataSource.Rows[i]["BoxNo"]) + "  已开过匹，与库存细码对应不上，请检查!");
                            return;
                        }
                    }

                }
                //}
                IOFormRule rule = new IOFormRule();
                //if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//非 成品仓库不使用码单模式
                //{
                string o_ErrorMsg = string.Empty;
                if (!rule.RCheckCorrectPackData(HTDataID, out o_ErrorMsg))// 如果校验不通过
                {
                    this.ShowMessage(o_ErrorMsg);
                    return;
                }
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

                //if (!CheckCorrect())
                //{
                //    return;
                //}

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



        #region 其他事件
        /// <summary>
        /// 增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    this.ShowMessage("此功能暂时关闭");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 删行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    this.ShowMessage("此功能暂时关闭");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    this.ShowMessage("此功能暂时关闭");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    this.ShowMessage("此功能暂时关闭");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void lbtnLoadFH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtFHFormNo.Text.Trim() == "")
                {
                    this.ShowMessage("请输入发货单号后匹配");
                    return;
                }
                string sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    this.ShowMessage("发货单号不存在，请检查");
                    return;
                }

                sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                sql += " AND ISNULL(SubmitFlag,0)<>0";
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    this.ShowMessage("发货单没有提交，请检查");
                    return;
                }

                sql = "SELECT  FormNo FROM UV1_Sale_FHForm WHERE FormNo IN(SELECT DtsSO FROM UV1_WH_IOFormDts WHERE SubType IN(SELECT ID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(FormListAID) + " ) ) AND FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());

                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    this.ShowMessage("发货单已填写出库单，请检查");
                    return;
                }

                //sql = "SELECT FHForTypeID,SaleOPID,'' Section,'' SBitID,ItemCode,'' ItemModel,'' Batch,'' VendorBatch,ColorNum,ColorName,'' JarNum,'' Remark,PieceQty,Qty,Unit,0 Weight,0 SinglePrice,Amount,'' DLCode,GoodsCode,GoodsLevel,VColorNum,VColorName,VItemCode,MWidth,MWeight,WeightUnit,0 ManinID,0 Seq,VendorID DtsInVendorID,'' InSO,'' InOrderFormNo,'' InSaleOPID,FHForTypeID ID,FormNo DtsSO,DtsOrderFormNo FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                //sql += " AND ISNULL(SubmitFlag,0)<>0";
                sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                sql += " AND ISNULL(SubmitFlag,0)<>0";
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    int FHForTypeID = SysConvert.ToInt32(dt.Rows[0]["FHForTypeID"]);
                    if (FHForTypeID == (int)EnumFHForType.调样单)
                    {
                        drpSubType.EditValue = 1203;
                    }
                    else
                    {
                        drpSubType.EditValue = 1201;
                    }
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int setRowID = i;
                        gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                        gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                        gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));

                        gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));
                        gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                        gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[i]["Needle"]));

                        gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[i]["GoodsCode"]));
                        gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                        gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[i]["VColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[i]["VColorName"]));
                        gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[i]["VItemCode"]));
                        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[i]["MWidth"]));
                        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[i]["MWeight"]));
                        gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[i]["WeightUnit"]));
                        gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[i]["GoodsLevel"]));
                        gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                        gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                        gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[i]["DYPrice"]));
                        //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                        switch (saveFillDataType)
                        {
                            case (int)EnumFillDataType.销售出库标准回填方法:
                                gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsOrderFormNo"]));
                                break;
                            //case (int)EnumFillDataType.调样销售出库标准回填方法:
                            //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsDYFormNo"]));
                            //    break;
                        }
                        gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsOrderFormNo"]));
                        gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[i]["SaleOPID"]));

                        if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                        }

                        if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[i]["PieceQty"]));
                        }
                        if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[i]["SingPrice"]));
                        }

                        string outsectionID, outSbitID;
                        WHLoadFHFormSetWH(dt.Rows[i], out outsectionID, out outSbitID);

                        gridView1.SetRowCellValue(setRowID, "SectionID", outsectionID);
                        gridView1.SetRowCellValue(setRowID, "SBitID", outSbitID);
                    }

                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmOutWHEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    IOForm entity = new IOForm();
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

        private void btnToGBDetail_Click(object sender, EventArgs e)
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
                    string WHID = SysConvert.ToString(drpWHID.EditValue);
                    string SectionID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID"));
                    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                    string ItemName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemName"));
                    string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum"));
                    string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                    string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));
                    string Batch = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Batch"));

                    if (ID > 0)
                    {
                        frmLoadOutWH frm = new frmLoadOutWH();
                        frm.PackType = (int)EnumPackType.仓库单据;
                        frm.IOFormID = HTDataID;
                        frm.ID = ID;
                        frm.WHID = WHID;
                        frm.SectionID = SectionID;
                        frm.ItemCode = ItemCode;
                        frm.ColorNum = ColorNum;
                        frm.ColorName = ColorName;
                        frm.JarNum = JarNum;
                        frm.Batch = Batch;
                        frm.KPButtonFlag = true;
                        frm.WHType = (int)EnumWHType.面料仓库;
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

        /// <summary>
        /// 人工录入细码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToGBDetailInput_Click(object sender, EventArgs e)
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
                        frmLoadPackNoInput frm = new frmLoadPackNoInput();
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

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "PackNo1" || e.Column.FieldName == "PackNo2" || e.Column.FieldName == "PackNo3" || e.Column.FieldName == "PackNo4"
                    || e.Column.FieldName == "PackNo5" || e.Column.FieldName == "PackNo6" || e.Column.FieldName == "PackNo7" || e.Column.FieldName == "PackNo8"
                    || e.Column.FieldName == "PackNo9" || e.Column.FieldName == "PackNo10")
                {
                    e.Appearance.BackColor = Color.Silver;
                }
                if (e.Column.FieldName == "TQty")
                {
                    e.Appearance.BackColor = Color.Tan;
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                Common.BindVendorAddress(drpAddress, SysConvert.ToString(drpVendorID.EditValue), true);

                Common.BindVendorContact(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(701)))//选择客户带出客户主表的联系人电话和地址
            {

                drpAddress.EditValue = Common.GetVendorAddressByVenorID(SysConvert.ToString(drpVendorID.EditValue));

                drpVendorOPID.EditValue = Common.GetVendorContactByVenorID(SysConvert.ToString(drpVendorID.EditValue));
                txtVendorTel.Text = Common.GetVendorTelByVenorID(SysConvert.ToString(drpVendorID.EditValue));
            }
        }

        private void drpGridSectionID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpWHID.EditValue) == "")
                {
                    this.ShowMessage("请选择仓库");
                    drpWHID.Focus();
                    return;
                }
                frmSectionQuery frm = new frmSectionQuery();
                frm.WHID = SysConvert.ToString(drpWHID.EditValue);
                frm.ShowDialog();
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SectionID", frm.SectionID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 人工称重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToGBDetailCZ_Click(object sender, EventArgs e)
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
                        frmLoadPackNoInputCZ frm = new frmLoadPackNoInputCZ();
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SinglePrice" || e.Column.FieldName == "Qty")
            {
                ColumnView view = sender as ColumnView;
                decimal singprice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SinglePrice"));
                decimal qty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Qty"));
                decimal Amount = SysConvert.ToDecimal(singprice * qty, 2);
                view.SetRowCellValue(view.FocusedRowHandle, "Amount", Amount);
            }
            if (e.Column.FieldName == "Unit")
            {

            }
        }




        #region  设置上布员
        /// <summary>
        /// 设置上布员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetRecordOPID_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.查询 || HTDataID != 0)
                {
                    frmSetRecordOPID2 frm = new frmSetRecordOPID2();
                    frm.ID = HTDataID;
                    frm.ShowDialog();
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