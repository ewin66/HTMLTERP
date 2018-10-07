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

namespace MLTERP
{
    public partial class frmFabricInWHEdit : frmModuleBaseWHEdit
    {
        public frmFabricInWHEdit()
        {
            InitializeComponent();
        }

        #region 全局变量

        private DataTable[] dtPack = new DataTable[150];//码单信息表
        private int PreRowID = -1;//初始行号
        private int CurRowID = -1;//当前行号
        int saveNoLoadCheckDayNum = 0;//未加载比对天数，防止随着时间的推移系统变慢


        int saveLoadFormType = 0;
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

            //if (SysConvert.ToString(drpWHID.EditValue) == string.Empty)
            //{
            //    this.ShowMessage("请选择仓库");
            //    drpWHID.Focus();
            //    return false;
            //}

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
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpVendorID.EditValue = entity.VendorID.ToString();
            drpXZ.EditValue = entity.XZ.ToString();
            drpWHID.EditValue = entity.WHID.ToString();
            drpSubType.EditValue = entity.SubType;
            txtWHDM.Text = entity.DM.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtWHInvoiceNo.Text = entity.InvoiceNo.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtRemark.Text = entity.Remark;
            drpFHTypeID.EditValue = entity.FHTypeID;

            txtMakeOPName.Text = entity.MakeOPName;

            txtKDNo.Text = entity.KDNo.ToString();
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

            this.HTCheckDataField = new string[] { "ItemCode", "SectionID" };//数据明细校验必须录入字段 ,"Qty"
            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            //Common.BindOP(drpSaleOPID, true);
            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }

            Common.BindOPID(drpGridDCOPID,true);
            Common.BindVendor2(drpVendorID, (int)EnumVendorType.工厂, true);
            //new VendorProc(drpVendorID);
            Common.BindWHByFormList(drpWH, this.FormListAID, true);     //(int)EnumWHType.面料仓库
            Common.BindFHType(drpFHTypeID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel",true);
            Common.BindSubType(drpSubType, this.FormListAID, true);             //入库类型绑定
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
           // Common.BindWHByFormList(drp, SysConvert.ToInt32(drpSubType.EditValue), true);
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            //Common.BindEnumUnit(RestxtUnit, true);

            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitFab", true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载单据", false, btnLoad_Click);
            //this.ToolBarItemAdd(28, "btnUpdateAmount", "修改单价", false, btnUpdateAmount_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;
            //gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6401)))//坯布仓库不使用码单模式
            {
                btnToGBDetail.Visible = false;//隐藏操作按钮
                groupControlBottom.Visible = false;//码单隐藏
            }

        }

         /// <summary>
        /// 修改单价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnUpdateAmount_Click(object sender, EventArgs e)
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
                    frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ID"));
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
            //entity.WHType = drpWHID.EditValue.ToString();
            entity.SubType =SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            //entity.WHTypeID = SysConvert.ToInt32(drpWHID.EditValue);
            //entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            //entity.DM = txtWHDM.Text.Trim();
            //entity.InvoiceNo = txtWHInvoiceNo.Text.Trim();
            //entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeadType = this.FormListAID;
            entity.KDNo = txtKDNo.Text.Trim();
            entity.FHTypeID = SysConvert.ToInt32(drpFHTypeID.EditValue);

            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = DateTime.Now.Date;

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
  			 		
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 

  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
  			 		entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch")); 
  			 		entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));

                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo")); //款号
  			 		
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty")); 
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
  			 		entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel")); 
  			 		entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum")); 
  			 		entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName")); 
  			 		entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].CarNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "CarNo"));

                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);//往来单位客户
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));//加载单据单号
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));//销售订单号
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID"));//销售客户

                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));
                    entitydts[index].PackDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "PackDts"));//细码
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));  //区分成品面料和白坯布

                    entitydts[index].NeedleNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "NeedleNum"));//针数
                    entitydts[index].InchNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "InchNum"));//寸数
                    entitydts[index].DCOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DCOPID")); //档车工
                    
                    index++;
                }
            }
            return entitydts;
        }

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
                            IOFormDtsPack entity = new IOFormDtsPack();
                            entity.ID = SysConvert.ToInt32(dtPack[j].Rows[m]["ID"]);
                            entity.SelectByID();
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

        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                    //string sql = "EXEC USP1_WH_PackBox " + ID;
                    string sql = string.Empty;
                    sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum FROM WH_IOFormDtsPack WHERE DID= "+SysString.ToDBString(ID);
                    DataTable dt = SysUtils.Fill(sql);
                    //SetGrid(dt);

                    BindUCFabView(dt);
                    //gridView2.GridControl.DataSource = dt;
                    //gridView2.GridControl.Show();
                    string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHID"));
                    string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SectionID"));
                    Common.BindSection(drpGridSectionID, WHID, false);
                    Common.BindSBit(drpSBit, WHID, SectionID, true);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        //private void SetGrid(DataTable dt)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (SysConvert.ToDecimal(dr["Qty1"]) == 0)
        //        {
        //            dr["Qty1"] = DBNull.Value;
        //            dr["PackNo1"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty2"]) == 0)
        //        {
        //            dr["Qty2"] = DBNull.Value;
        //            dr["PackNo2"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty3"]) == 0)
        //        {
        //            dr["Qty3"] = DBNull.Value;
        //            dr["PackNo3"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty4"]) == 0)
        //        {
        //            dr["Qty4"] = DBNull.Value;
        //            dr["PackNo4"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty5"]) == 0)
        //        {
        //            dr["Qty5"] = DBNull.Value;
        //            dr["PackNo5"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty6"]) == 0)
        //        {
        //            dr["Qty6"] = DBNull.Value;
        //            dr["PackNo6"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty7"]) == 0)
        //        {
        //            dr["Qty7"] = DBNull.Value;
        //            dr["PackNo7"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty8"]) == 0)
        //        {
        //            dr["Qty8"] = DBNull.Value;
        //            dr["PackNo8"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty9"]) == 0)
        //        {
        //            dr["Qty9"] = DBNull.Value;
        //            dr["PackNo9"] = DBNull.Value;
        //        }
        //        if (SysConvert.ToDecimal(dr["Qty10"]) == 0)
        //        {
        //            dr["Qty10"] = DBNull.Value;
        //            dr["PackNo10"] = DBNull.Value;
        //        }
        //    }
        //}

        /// <summary>
        /// 绑定面料显示控件
        /// </summary>
        void BindUCFabView(DataTable dtSource)
        {
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
        #endregion

        #region 加载数据相关方法
       

        

        #endregion

        #region 其它事件
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.入库单号);

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
        private void drpWHID_EditValueChanged(object sender, EventArgs e)
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
                    saveTHLoadFormListIDStr = SysConvert.ToString(dt.Rows[0]["THLoadFormListIDStr"]);
                     //if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//编辑状态下
                     //{
                     //    if (dt.Rows[0]["DefaultWHID"].ToString() != string.Empty)
                     //    {
                     //        drpWHID.EditValue = dt.Rows[0]["DefaultWHID"].ToString();
                     //    }
                     //}
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
        /// 双击产品编码加载挂板信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    //frmLoadItemGB frm = new frmLoadItemGB();
                    //frm.ShowDialog();
                    //string str = string.Empty;
                    //if (frm.GBID != null && frm.GBID.Length != 0)
                    //{

                    //    for (int i = 0; i < frm.GBID.Length; i++)
                    //    {
                    //        if (str != string.Empty)
                    //        {
                    //            str += ",";
                    //        }
                    //        str += SysConvert.ToString(frm.GBID[i]);
                    //    }
                    //    setItemNewsLocal(str);
                    //}

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
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    //gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    gridView1.SetRowCellValue(i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    //gridView1.SetRowCellValue(i, "DLoadID", SysConvert.ToInt32(orderid[i]));

                    //if (i == 0)
                    //{
                    //    sql = "SELECT VendorID FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //    dt = SysUtils.Fill(sql);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0][0]);
                    //    }
                    //}

                }
            }
        }
        private void setItemNewsLocal(string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", DBNull.Value);
                    }

                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

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

        ///// <summary>
        ///// 码单值改变
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
        //        {
        //            if (e.Column.FieldName.ToUpper() == "QTY")//数量改变才运算
        //            {
        //                SetGrid1Qty();
        //            }
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        ///// <summary>
        ///// 设置Grid1Qty数量
        ///// </summary>
        //void SetGrid1Qty()
        //{
        //    int pieceQty = 0;
        //    decimal qty = 0;
        //    for (int i = 0; i < gridView2.RowCount; i++)
        //    {
        //        if (SysConvert.ToString(gridView2.GetRowCellValue(i, "Qty")) != string.Empty && SysConvert.ToString(gridView2.GetRowCellValue(i, "Qty")) != "0")
        //        {
        //            pieceQty++;
        //            qty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
        //        }
        //        else//如果不是连续行，自动跳出循环，提高效率
        //        {
        //            break;
        //        }
        //    }

        //    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", pieceQty);
        //    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty);
        //}
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
                if (!CheckCorrect())
                {
                    return;
                }

                

                IOFormRule rule = new IOFormRule();
                if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6401)))//非 坯布仓库不使用码单模式
                {
                    string o_ErrorMsg = string.Empty;
                    if (!rule.RCheckCorrectPackData(HTDataID, out o_ErrorMsg))// 如果校验不通过
                    {
                        this.ShowMessage(o_ErrorMsg);
                        return;
                    }
                }
                
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

        ///// <summary>
        ///// 双击加载件数
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void txtPieceQty_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //this.BaseFocusLabel.Focus();
        //        frmLoadPack frm = new frmLoadPack();
        //        frm.StartPosition = FormStartPosition.Manual;
        //        frm.Location = new Point(780, 80);
        //        string packdts = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackDts"));
        //        if (packdts != "")
        //        {
        //            frm.YPackStr = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackDts"));
        //        }
        //        else
        //        {
        //            frm.YPackStr =GetPackDts();
        //        }
               
        //        frm.ShowDialog();
        //        if (frm.PackStr != "")
        //        {
        //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", frm.Qty);
        //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PackDts", frm.PackStr);
        //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", frm.Num);
        //            string[] arr = frm.PackStr.Split(',');
        //            for (int i = 0; i < gridView1.RowCount; i++)
        //            {
        //                if (i < arr.Length)
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
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private string GetPackDts()
        //{
        //    string str = "";
        //    for(int i=0;i<gridView2.RowCount;i++)
        //    {
               
        //        if(SysConvert.ToDecimal(gridView2.GetRowCellValue(i,"Qty"))!=0)
        //        {
        //            if (str != "")
        //            {
        //                str += ",";
        //            }
        //            str += SysConvert.ToString(gridView2.GetRowCellValue(i, "Qty"));
        //        }
        //    }
        //    return str;
        //}

        //private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    try
        //    {

        //        if (e.Column.FieldName == "PackNo1" || e.Column.FieldName == "PackNo2" || e.Column.FieldName == "PackNo3" || e.Column.FieldName == "PackNo4"
        //            || e.Column.FieldName == "PackNo5" || e.Column.FieldName == "PackNo6" || e.Column.FieldName == "PackNo7" || e.Column.FieldName == "PackNo8"
        //            || e.Column.FieldName == "PackNo9" || e.Column.FieldName == "PackNo10")
        //        {
        //            e.Appearance.BackColor = Color.Silver;
        //        }
        //        if (e.Column.FieldName == "TQty")
        //        {
        //            e.Appearance.BackColor = Color.Tan;
        //        }
                
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        #region 发货单同步

        private void btnGO_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (!checkFH())
                    {
                        return;
                    }
                    LoadWHByFHForm();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载发货单据
        /// </summary>
        private void LoadWHByFHForm()
        {
            string sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo="+SysString.ToDBString(txtFHFormNo.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    gridView1.FocusedRowHandle = i;
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[i]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[i]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[i]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[i]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[i]["Qty"]));
                    gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToInt32(dt.Rows[i]["PieceQty"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    gridView1.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsOrderFormNo"]));
                    gridView1.SetRowCellValue(i, "VColorNum", SysConvert.ToString(dt.Rows[i]["VColorNum"]));
                    gridView1.SetRowCellValue(i, "VColorName", SysConvert.ToString(dt.Rows[i]["VColorName"]));
                    gridView1.SetRowCellValue(i, "VItemCode", SysConvert.ToString(dt.Rows[i]["VItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsLevel", SysConvert.ToString(dt.Rows[i]["GoodsLevel"]));

                    //SetGird2ByFHForm(SysConvert.ToInt32(dt.Rows[i]["ID"]), SysConvert.ToInt32(dt.Rows[i]["Seq"]));
                   
                     
                    
                }
            }

        }

        ///// <summary>
        ///// 取得细码的值
        ///// </summary>
        ///// <param name="p_ID"></param>
        ///// <param name="p_Seq"></param>
        //private void SetGird2ByFHForm(int p_ID, int p_Seq)
        //{
        //    string sql = "SELECT Qty FROM Sale_FHFormDtsPack WHERE MainID=" + SysString.ToDBString(p_ID);
        //    sql += " AND Seq=" + SysString.ToDBString(p_Seq);
        //    DataTable dt = SysUtils.Fill(sql);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        gridView2.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i][0]));
        //    }
        //}

        /// <summary>
        /// 验证发货单
        /// </summary>
        /// <returns></returns>
        private bool checkFH()
        {
            if (txtFHFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入同步的发货单号");
                txtFHFormNo.Focus();
                return false;
            }
            string sql = "SELECT * FROM Sale_FHForm WHERE FormNo="+SysString.ToDBString(txtFHFormNo.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                this.ShowMessage("发货单号不存在，请重新输入");
                txtFHFormNo.Text = "";
                txtFHFormNo.Focus();
                return false;
            }
            return true;
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

        private void frmInWHEdit_FormClosing(object sender, FormClosingEventArgs e)
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
                if (this.HTDataSubmitFlag==0)//未提交状态才允许编辑码单
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

        /// <summary>
        /// 称重入库
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
                        frmLoadPackNoCZ frm = new frmLoadPackNoCZ();
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

        private void drpWH_EditValueChanged(object sender, EventArgs e)
        {
            gridViewRowChanged2(gridView1);
        }

        private void drpGridSectionID_EditValueChanged(object sender, EventArgs e)
        {
            gridViewRowChanged2(gridView1);
        }









    }
}