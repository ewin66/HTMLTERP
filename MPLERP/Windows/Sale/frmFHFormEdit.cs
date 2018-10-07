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
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 发货单编辑
    /// 
    /// 2014-5-23 陈加海
    /// 修改处理：改增加一个转换模式
    /// 录入订单可能有多个单位的数量 InputQty InputUnit
    /// 保存时录入的系数进行倒算，也就是录入的发货数量*系数=公斤数
    /// </summary>
    public partial class frmFHFormEdit : frmAPBaseUIFormEdit
    {
        public frmFHFormEdit()
        {
            InitializeComponent();
        }

        #region 全局变量
        private DataTable[] dtPack = new DataTable[150];//码单信息表
        private int PreRowID = -1;//初始行号
        private int CurRowID = -1;//当前行号
        int saveNoLoadCheckDayNum = 0;//未加载比对天数，防止随着时间的推移系统变慢
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
           
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入发货单号");
                txtFormNo.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpFHForTypeID))
            {
                this.ShowMessage("请选择发货来源");
                drpFHForTypeID.Focus();
                return false;
            }

            //if (Common.CheckLookUpEditBlank(drpVendorID))
            //{
            //    this.ShowMessage("请选择客户");
            //    drpVendorID.Focus();
            //    return false;
            //}

            //if(SysConvert.ToInt32(drpFHTypeID.EditValue)==0)
            //{
            //    this.ShowMessage("请选择送货性质");
            //    drpFHTypeID.Focus();
            //    return false;
            //}

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return false;
            }

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            //if (!chkeckDY())
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// 杜绝修改调样单
        /// </summary>
        /// <returns></returns>
        private bool chkeckDY()
        {
            if (SysConvert.ToInt32(drpFHForTypeID.EditValue) == (int)EnumFHForType.调样单)
            {
                for(int i=0;i<gridView1.RowCount;i++)
                {
                    string DtsDYFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsDYFormNo"));
                    if (DtsDYFormNo != "")
                    {
                        decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                        string Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                        string sql = "SELECT Qty,Unit FROM Sale_DYGL WHERE FormNo="+SysString.ToDBString(DtsDYFormNo);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count > 0)
                        {
                            //if (Qty != SysConvert.ToDecimal(dt.Rows[0]["Qty"]))
                            //{
                            //    this.ShowMessage("第" + SysConvert.ToInt32(i + 1).ToString() + "行调样数量与调样单的数量不符，请检查！");
                            //    return false;
                            //}
                            if (Unit != SysConvert.ToString(dt.Rows[0]["Unit"]) && SysConvert.ToString(dt.Rows[0]["Unit"]) != "")
                            {
                                this.ShowMessage("第" + SysConvert.ToInt32(i + 1).ToString() + "行调样单位与调样单的单位不符，请检查！");
                                return false;
                            }
                        }
                        else
                        {
                            this.ShowMessage("调样单号："+DtsDYFormNo+"不存在，请检查！");
                            return false;
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
            FHFormDtsRule rule = new FHFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
         
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FHFormRule rule = new FHFormRule();
            FHForm entity = EntityGet();
            FHFormDts[] entitydts = EntityDtsGet();
            decimal totalQty = 0;
            decimal totalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                totalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = totalQty;
            entity.TotalAmount = totalAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            entity.OrderFormNo = GetVOrderFormNo(entitydts);
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        private string GetVOrderFormNo(FHFormDts[] entitydts)
        {
            string VOrderFormNo = "";
            for (int i = 0; i < entitydts.Length; i++)
            {
                if (GetVOF(entitydts[i].DtsOrderFormNo) != "")
                {
                    if (VOrderFormNo != "")
                    {
                        VOrderFormNo += ",";
                    }
                    VOrderFormNo += GetVOF(entitydts[i].DtsOrderFormNo);

                }
            }
            string[] VOrderFormNoArr = VOrderFormNo.Split(',');
            VOrderFormNo = "";
            for (int j = 0; j < VOrderFormNoArr.Length; j++)
            {
                if (VOrderFormNo.IndexOf(VOrderFormNoArr[j]) < 0)
                {
                    if (VOrderFormNo != "")
                    {
                        VOrderFormNo+=",";

                    }
                    VOrderFormNo += VOrderFormNoArr[j];
                }
            }
            return VOrderFormNo;
        }

        private string GetVOF(string p_OrderFormNo)
        {
            string sql = "SELECT CustomerCode FROM Sale_SaleOrder WHERE FormNo="+SysString.ToDBString(p_OrderFormNo);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FHFormRule rule = new FHFormRule();
            FHForm entity = EntityGet();
            FHFormDts[] entitydts = EntityDtsGet();
            decimal totalQty = 0;
            decimal totalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                totalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = totalQty;
            entity.TotalAmount = totalAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            entity.OrderFormNo = GetVOrderFormNo(entitydts);
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FHForm entity = new FHForm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeOPID.Text = entity.MakeOPID.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtFormDate.DateTime = entity.MakeDate;
          
            txtSHR.Text = entity.SHR.ToString();
            drpLXR.EditValue = entity.LXR.ToString();
            drpVendorID.EditValue = entity.VendorID.ToString();
            drpSHOPID.EditValue = entity.SHOPID.ToString();
            drpSHVendorID.EditValue = entity.SHVendorID.ToString();
            txtSHTel.Text = entity.SHTel.ToString();
            txtSendCode.Text = entity.SendCode.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            drpFHForTypeID.EditValue = entity.FHForTypeID;
            txtDYFormNo.Text = entity.DYFormNo.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            txtTel.Text = entity.Tel.ToString();
            drpRecAddress.EditValue = entity.Address.ToString();
            drpFHTypeID.EditValue = entity.FHTypeID;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpFHStatusID.Text = entity.FHStatusID.ToString();
            txtMaiTou.Text = entity.MaiTou.ToString();
            txtDuanyizhuang.Text = entity.Duanyizhuang.ToString();
            if (!findFlag)
            {

            }

            BindGridDts();


            ShowVendorAmount();

        }

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
        //            dtPack[p_RowID].Rows[i]["ID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["ID"]));
        //            dtPack[p_RowID].Rows[i]["MainID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["MainID"]));
        //            dtPack[p_RowID].Rows[i]["Seq"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["Seq"]));
        //            dtPack[p_RowID].Rows[i]["SubSeq"] = PreRowID + 1;
        //            dtPack[p_RowID].Rows[i]["Qty"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"]));
        //            dtPack[p_RowID].Rows[i]["Remark"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["Remark"]));
        //            dtPack[p_RowID].Rows[i]["BoxNo"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["BoxNo"]));
        //        }
        //    }
        //}

        /// <summary>
        /// 获得码单明细
        /// </summary>
        /// <param name="List"></param>
        private void GetMadanDts(ArrayList List)
        {
            BaseFocusLabel.Focus();
            for (int j = 0; j < gridView1.RowCount; j++)//纱线循环
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) != string.Empty)
                {
                    for (int m = 0; m < dtPack[j].Rows.Count; m++)//码单循环
                    {

                        if ((SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]) != 0))//dtPack[j].Rows[m]["PackNo"].ToString() != string.Empty ||
                        {
                            FHFormDtsPack entity = new FHFormDtsPack();
                            entity.ID = SysConvert.ToInt32(dtPack[j].Rows[m]["ID"]);
                            entity.SelectByID();
                            entity.MainID = HTDataID;
                            entity.Seq = j + 1;
                            entity.SubSeq = m + 1;
                            entity.Qty = SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]);
                            entity.Remark = SysConvert.ToString(dtPack[j].Rows[m]["Remark"]);
                            entity.BoxNo = SysConvert.ToString(dtPack[j].Rows[m]["BoxNo"]);


                            List.Add(entity);

                        }
                    }
                }
            }
        }

        //private void Set_FHFormDetail()
        //{
        //    //Itemcode+FabricTypeCode+FabricType+Batch+ColorNum+ColorName+JarNum+OrderCode+YarnStatus
        //    #region
        //    int TempID = -1;
        //    int PSeq = -1;
        //    int j = 0;//控制gridview的行号
        //    string sql = string.Empty;
        //    sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM Sale_FHFormDtsPack WHERE 1=0";
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
        //                sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM Sale_FHFormDtsPack WHERE 1=0";
        //                TempID = SysUtils.Fill(sql).Rows.Count;
        //                dtPack[PSeq] = SysUtils.Fill(sql);
        //                j++;
        //            }
        //            else
        //            {
        //                sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM Sale_FHFormDtsPack WHERE 1=1";
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

       
        /// <summary>
        /// 绑定面料显示控件
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="inputUnit">转换单位</param>
        /// <param name="inputConvertXS">转换系数</param>
        void BindUCFabView(DataTable dtSource,string inputUnit, decimal inputConvertXS)
        {
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
            {
                ucFabView1.UCQtyConvertMode = true;
                ucFabView1.UCQtyConvertModeInputUnit = inputUnit;
                ucFabView1.UCQtyConvertModeInputConvertXS = inputConvertXS;
            }
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FHFormRule rule = new FHFormRule();
            FHForm entity = EntityGet();
            rule.RDelete(entity);
        }

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
                if (!HTSubmitCheck(FormStatus.提交))
                {
                    return;
                }




               




                FHFormRule rule = new FHFormRule();
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
        /// </summary>  //sc 发货单已出库不允许撤销提交
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

                if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5411)))//非  发货单有仓库单据允许撤销修改
                {
                    string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsSo=" + SysString.ToDBString(txtFormNo.Text);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"]) == 1)
                        {
                            this.ShowMessage("此发货单已经出库不允许做修改");
                            return;
                        }
                    }
                }
                FHFormRule rule = new FHFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }





        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Sale_FHForm", "FormNo", 0, p_Flag);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
             //base.IniInsertSet();
             txtMakeDate.DateTime = DateTime.Now;
          
             txtFormDate.DateTime = DateTime.Now;
             txtMakeOPID.Text = FParamConfig.LoginID;
             txtMakeOPName.Text = FParamConfig.LoginName;
             drpSaleOPID.EditValue = FParamConfig.LoginID;
             txtFormNo_DoubleClick(null, null);
             drpFHForTypeID.EditValue = (int)EnumFHForType.销售合同;
            
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            this.HTDataTableName = "Sale_FHForm";
            this.HTDataDts = gridView1;
            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            this.HTCheckDataField = new string[] {"ItemCode"};//数据明细校验必须录入字段
            txtFormNo_DoubleClick(null, null);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            //Common.BindEnumUnit(restxtUnit, true);

            Common.BindCLS(restxtUnit, "Data_Item", "ItemUnitFab", true);

            //Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            //new VendorProc(drpVendorID);
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
           // Common.BindOP(drpSaleOPID, true);

            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }

            Common.BindFHForType(drpFHForTypeID, true);
            Common.BindFHType(drpFHTypeID, true);
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            //this.ToolBarItemAdd(28, ToolButtonName.btnToExcel.ToString(), "导出EXCEL", false, btnToExcel_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            //gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5410)))//发货单不使用码单模式
            {
                btnToGBDetail.Visible = false;//隐藏操作按钮
                groupControlBottom.Visible = false;//码单隐藏
            }
            DevMethod.BindItem(drpItemCode, true);

        }

        public override void IniRefreshData()
        {
            DevMethod.BindVendor(drpSHVendorID, new int[] { (int)EnumVendorType.客户 }, true);
        }
        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5410)))//发货单使用码单模式
                    {
                        int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                        //string sql = "EXEC USP1_FH_PackBox " + ID;
                        //DataTable dt = SysUtils.Fill(sql);
                        //SetGrid(dt);
                        //gridView2.GridControl.DataSource = dt;
                        //gridView2.GridControl.Show();

                        string sql = string.Empty;
                        sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum,InputQty FROM Sale_FHFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
                        DataTable dt = SysUtils.Fill(sql);
                        //SetGrid(dt);
                        string inputUnit = string.Empty;
                        decimal inputConvertXS = 0;
                        if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
                        {
                            inputUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "InputUnit"));
                            inputConvertXS = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputConvertXS"));
                        }
                        BindUCFabView(dt, inputUnit, inputConvertXS);
                    }
                }

                this.gridView1.Focus();
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
                    txtItemCode_DoubleClick(null, null);
                 
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        
        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
               
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
        private FHForm EntityGet()
        {
            FHForm entity = new FHForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
          
  			entity.SHR = txtSHR.Text.Trim();
            entity.LXR = SysConvert.ToString(drpLXR.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SHOPID = SysConvert.ToString(drpSHOPID.EditValue);
            entity.SHVendorID = SysConvert.ToString(drpSHVendorID.EditValue);
            entity.SHTel = txtSHTel.Text.Trim();
  			entity.SendCode = txtSendCode.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim()); 
  			entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim()); 
  			entity.FHForTypeID = SysConvert.ToInt32(drpFHForTypeID.EditValue); 
  			entity.DYFormNo = txtDYFormNo.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
  			entity.SendFlag = SysConvert.ToInt32(drpSendFlag.Text.Trim());
            entity.Tel = txtTel.Text.Trim();
            entity.Address = SysConvert.ToString(drpRecAddress.EditValue);
            entity.FHTypeID = SysConvert.ToInt32(drpFHTypeID.EditValue);
            entity.FHStatusID = drpFHStatusID.Text.Trim();
            entity.MaiTou = txtMaiTou.Text.Trim();
            entity.Duanyizhuang = txtDuanyizhuang.Text.Trim();
            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = DateTime.Now.Date;
            }
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FHFormDts[] EntityDtsGet()
        {
           
            int index = GetDataCompleteNum();
            FHFormDts[] entitydts = new FHFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new FHFormDts();

                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = index + 1;

                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode")); 
  			 		entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight")); 
  			 		entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit")); 
  			 		entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum")); 
  			 		entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName")); 
  			 		entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));

                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));

                    entitydts[index].InputQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputQty"));
                    entitydts[index].InputUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "InputUnit"));
                    entitydts[index].InputSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputSinglePrice"));
                    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice;// +entitydts[index].FAmount1 + entitydts[index].FAmount2 + entitydts[index].FAmount3 + entitydts[index].FAmount4 + entitydts[index].FAmount5;
                    entitydts[index].InputConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputConvertXS"));

               


  			 		entitydts[index].PieceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PieceQty")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
  			 		entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].SingPrice * entitydts[index].Qty + entitydts[index].DYPrice;
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DtsDYFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsDYFormNo"));
                    entitydts[index].PackDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "PackDts"));
                    entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID"));


                    if ((SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5404)) && entitydts[index].InputUnit != string.Empty)//销售订单使用下单数量制单时确定是否需要单位转换模式及计算方法类型 默认否，此功能设置为是时，5405应设置为0
                        || SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
                    {
                        entitydts[index].InputQty = ProductCommon.UnitConvertValueAnyUnit(entitydts[index].Unit, entitydts[index].Qty, entitydts[index].InputUnit, entitydts[index].InputConvertXS);
                        entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice; 
                        entitydts[index].SingPrice = SysConvert.ToDecimal(entitydts[index].InputSinglePrice * entitydts[index].InputConvertXS, 2);
                        entitydts[index].Amount = entitydts[index].InputAmount;


                    }
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region 加载
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpFHForTypeID.EditValue) ==0)
                {
                    this.ShowMessage("请选择送货来源");
                    drpFHForTypeID.Focus();
                    return;
                }
                if (SysConvert.ToString(drpVendorID.EditValue) == "")
                {
                    this.ShowMessage("请选择客户");
                    drpVendorID.Focus();
                    return;
                }
                int FHForTypeFlag = SysConvert.ToInt32(drpFHForTypeID.EditValue);
                switch (FHForTypeFlag)
                {
                    case (int)EnumFHForType.调样单:
                        LoadDYData();
                        break;
                    case (int)EnumFHForType.销售合同:
                        LoadSaleOrder();
                        break;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载销售合同
        /// </summary>
        private void LoadSaleOrder()
        {
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            frm.Double = true;
            string sql = string.Empty;
            sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsOrderFormNo+ItemCode+ColorNum+ColorName,'') FROM UV1_Sale_FHFormDts";
            if (saveNoLoadCheckDayNum != 0)
            {
                sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            
            sql += ")";
            frm.NoLoadCondition = sql;
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

        /// <summary>
        /// 加载订单数据
        /// </summary>
        /// <param name="p_Str"></param>
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
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(i, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(i, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));//PieceQty
                    gridView1.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[0]["SingPrice"]));
                    gridView1.SetRowCellValue(i, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
                    gridView1.SetRowCellValue(i, "Amount", SysConvert.ToDecimal(dt.Rows[0]["Amount"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));

                    gridView1.SetRowCellValue(i, "InputQty", SysConvert.ToDecimal(dt.Rows[0]["InputQty"]));
                    gridView1.SetRowCellValue(i, "InputUnit", SysConvert.ToString(dt.Rows[0]["InputUnit"]));
                    gridView1.SetRowCellValue(i, "InputSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["InputSinglePrice"]));
                    gridView1.SetRowCellValue(i, "InputAmount", SysConvert.ToDecimal(dt.Rows[0]["InputAmount"]));
                    gridView1.SetRowCellValue(i, "InputConvertXS", SysConvert.ToDecimal(dt.Rows[0]["InputConvertXS"]));


                    drpLXR.EditValue = SysConvert.ToString(dt.Rows[0]["VendorOPID"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);


                }
            }
        }
        /// <summary>
        /// 防止一个送货单出现两个合同的数据
        /// </summary>
        private void SetGridView1()
        {
            string sql = "SELECT * FROM  Sale_FHFormDts WHERE 1=0";
            DataTable dt = SysUtils.Fill(sql);
            Common.AddDtRow(dt, 100);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 加载调样单
        /// </summary>
        private void LoadDYData()
        {
            frmLoadJY frm = new frmLoadJY();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            sql += " AND FormNo NOT IN(SELECT DtsDYFormNo FROM UV1_Sale_FHFormDts";
            if (saveNoLoadCheckDayNum != 0)
            {
                sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            sql += " AND DtsDYFormNo<>''";
            sql += ")";
            frm.VendorID2 = "";
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.DYID != null && frm.DYID.Length != 0)
            {

                for (int i = 0; i < frm.DYID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.DYID[i]);
                }
                setDYDts(str);
            }
           
        }



        /// <summary>
        /// 加载调样单数据
        /// </summary>
        /// <param name="str"></param>
        private void setDYDts(string str)
        {
            string[] arr = str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Sale_JYOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["Width"]) > 0)
                    {
                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["Width"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["Weight"]) > 0)
                    {
                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWeight", DBNull.Value);
                    }
                    
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "DtsDYFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                   
                }
                length++;
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

        #endregion

        #region 其它事件
        /// <summary>
        /// 双击单号生成最新单号
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
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.发货单号); 
                    ProductCommon.FormNoIniSet(txtFormNo, "Sale_FHForm", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 双击单号生成送货单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSendCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    //if (Common.CheckLookUpEditBlank(drpVendorID))
                    //{
                    //    //this.ShowMessage("请选择客户");
                    //    drpVendorID.Focus();
                    //    return;
                    //}
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtSendCode.Text = rule.RGetFormNoVendor((int)FormNoControlEnum.发货单送货单号, (int)EnumFNCV.发货单送货单号, SysConvert.ToString(drpVendorID.EditValue));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 客户改变选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtSendCode_DoubleClick(null, null);
                if ((SysConvert.ToString(drpVendorID.EditValue) != string.Empty) && (SysConvert.ToString(drpSHVendorID.EditValue) == string.Empty))
                {
                    Common.BindVendorAddress(drpRecAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                    Common.BindVendorContact(drpLXR, SysConvert.ToString(drpVendorID.EditValue), true);
                }

                //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(701)))//选择客户带出客户主表的联系人电话和地址
                //{
                  
                //    drpRecAddress.Text = Common.GetVendorAddressByVenorID(SysConvert.ToString(drpVendorID.EditValue));
                //    drpLXR.Text = Common.GetVendorContactByVenorID(SysConvert.ToString(drpVendorID.EditValue));
                //    txtTel.Text = Common.GetVendorTelByVenorID(SysConvert.ToString(drpVendorID.EditValue));
                //}
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 联系人改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpLXR_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTel.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpLXR.EditValue));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
       
        #endregion

        #region 细码操作

        //private void txtPackDts_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmLoadPack frm = new frmLoadPack();
        //        frm.StartPosition = FormStartPosition.Manual;
        //        frm.Location = new Point(780, 80);
        //        frm.YPackStr = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackDts"));
        //        frm.ShowDialog();
        //        if (frm.PackStr != "")
        //        {
        //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", frm.Qty);
        //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", frm.Num);
        //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PackDts", frm.PackStr);
        //            string[] arr = frm.PackStr.Split(',');
        //            for (int i = 0; i < gridView1.RowCount; i++)
        //            {
        //                if (i <arr.Length)
        //                {
        //                    gridView2.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(arr[i]));
        //                }
        //                else
        //                {
        //                    gridView2.SetRowCellValue(i, "Qty", 0);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception E)E:\01项目开发\1499面料产品\02SourceCode\MLTERP\MLTERP\Windows\Sale\frmSOEdit.cs
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    try
        //    {

        //        if (SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "Qty")) > 0)
        //        {
        //            e.Appearance.BackColor = Color.Pink;
        //        }

        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        /// <summary>
        /// 双击件数弹出输入细码操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //private void txtPieceQty_DoubleClick_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtPackDts_DoubleClick(null, null);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

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

       
   

        private void frmFHFormEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    FHForm entity = new FHForm();
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
                    int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    string WHID = ""; //SysConvert.ToString(drpWHID.EditValue);
                    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                    string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum"));
                    string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));

                    string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));
                    string Batch = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Batch"));
                    frmLoadOutWH frm = new frmLoadOutWH();
                    frm.PackType = (int)EnumPackType.发货单据;
                    frm.IOFormID = HTDataID;
                    frm.ID = ID;
                    frm.WHID = WHID;
                    frm.ItemCode = ItemCode;
                    frm.ColorNum = ColorNum;
                    frm.ColorName = ColorName;
                    frm.JarNum = JarNum;
                    frm.Batch = Batch;
                    frm.ShowDialog();

                    if (frm.SaveFlag)//如果保存则刷新数据
                    {
                        BindGridDts();
                        ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { ID.ToString() });
                        gridViewRowChanged2(gridView1);
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
        /// 显示客户欠款信息
        /// </summary>
        private void ShowVendorAmount()
        {
            #region  销售出库校验信用额度
            decimal SaleAmount = 0.0m;//销售金额
            decimal RecAmount = 0.0m;//收款金额
            decimal QCAmoumt = 0.0m;//期初金额
            decimal CreditAmount = 0.0m;//期初金额
            string sql = "select SUM(Amount) Amount from UV1_WH_IOFormDts where 1=1";
            sql += " AND SubType=" + 1201;//成品销售出库
            sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            sql += " AND ISNULL(SubmitFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                SaleAmount = SysConvert.ToDecimal(dt.Rows[0]["Amount"]);
            }

            sql = "Select Sum(ExAmount) Amount from UV1_Finance_RecPay where 1=1";
            sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            sql += " AND RecPayTypeID=1";//收款
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                RecAmount = SysConvert.ToDecimal(dt.Rows[0]["Amount"]);
            }

            sql = "Select Sum(BAmount) Amount from Finance_BVendorAmount where 1=1";
            sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //sql += " AND RecPayTypeID=1";//收款
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                QCAmoumt = SysConvert.ToDecimal(dt.Rows[0]["Amount"]);
            }

            //信用额度
            sql = "Select LimitAmount from Data_Vendor where 1=1";
            sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //sql += " AND RecPayTypeID=1";//收款
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                CreditAmount = SysConvert.ToDecimal(dt.Rows[0]["LimitAmount"]);
            }


            lbl1.Text = "历史余额：" + SysConvert.ToString(SaleAmount + QCAmoumt - RecAmount);
            lbl2.Text = "发货金额：" + SysConvert.ToString(txtTotalAmount.Text.Trim());
            lbl3.Text = "当前余额：" + SysConvert.ToString(SaleAmount + QCAmoumt - RecAmount + SysConvert.ToDecimal(txtTotalAmount.Text.Trim()));
            lbl4.Text = "信用额度：" + SysConvert.ToString(CreditAmount);


            //if (SaleAmount - RecAmount + QCAmoumt + SysConvert.ToDecimal(txtTotalAmount.Text.Trim()) > CreditAmount)
            //{
            //    this.ShowMessage("此客户欠款超出信用额度！");
            //    return;
            //}

            #endregion

        }

        private void drpSHVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtSendCode_DoubleClick(null, null);
                if (SysConvert.ToString(drpSHVendorID.EditValue) != string.Empty) 
                {
                    Common.BindVendorAddress(drpRecAddress, SysConvert.ToString(drpSHVendorID.EditValue), true);
                    Common.BindVendorContact(drpLXR, SysConvert.ToString(drpSHVendorID.EditValue), true);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpSHOPID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtSHTel.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpSHVendorID.EditValue), SysConvert.ToString(drpSHOPID.EditValue));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

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
            }
            catch (Exception)
            {
                
                throw;
            }
        }






    }
}