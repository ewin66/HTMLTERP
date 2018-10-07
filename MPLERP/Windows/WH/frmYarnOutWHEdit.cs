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
    public partial class frmYarnOutWHEdit : frmModuleBaseWHEdit
    {
        public frmYarnOutWHEdit()
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
            txtDM.Text = entity.DM.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtInvoiceNo.Text = entity.InvoiceNo.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtRemark.Text = entity.Remark;
            txtMakeOPName.Text = entity.MakeOPName;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            SetIOFormDetail();
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
        private void SetIOFormDetail()
        {
            
            #region
            int TempID = -1;
            int PSeq = -1;
            int j = 0;//控制gridview的行号
            string sql = string.Empty;
            sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
            DataTable dt = SysUtils.Fill(sql);
            for (int i = 0; i < 150; i++)
            {
                dtPack[i] = dt.Clone();
            }
            DataTable dtVirtual = (DataTable)gridView1.GridControl.DataSource;
            foreach (DataRow dr in dtVirtual.Rows)
            {
                if (dr["ItemCode"].ToString() != string.Empty)
                {
                    if (dr["Seq"].ToString() == string.Empty)
                    {
                        PSeq = j;
                    }
                    else
                    {
                        PSeq = SysConvert.ToInt32(dr["Seq"].ToString()) - 1;
                    }

                    if (this.HTFormStatus == FormStatus.新增)
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
                        TempID = SysUtils.Fill(sql).Rows.Count;
                        dtPack[PSeq] = SysUtils.Fill(sql);
                        j++;
                    }
                    else
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=1";
                        sql += " AND MainID=" + SysString.ToDBString(dr["MainID"].ToString());
                        sql += " AND Seq=" + SysString.ToDBString(dr["Seq"].ToString());

                        dtPack[PSeq] = SysUtils.Fill(sql);
                    }
                }
            }
            for (int i = 0; i < 150; i++)
            {
                Common.AddDtRow(dtPack[i], 150);
            }
            #endregion
        }


        /// <summary>
        /// 绑定码单
        /// </summary>
        private void BindPack()
        {
            if (CurRowID >= 0)
            {
                DataTable dt = dtPack[CurRowID];
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();
            }
        }


        /// <summary>
        /// 获取码单信息
        /// </summary>
        private void GetMaDanDetail(int p_RowID)
        {
            BaseFocusLabel.Focus();
            if (SysConvert.ToString(gridView1.GetRowCellValue(PreRowID, "ItemCode")) != string.Empty)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    dtPack[p_RowID].Rows[i]["MainID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["MainID"]));
                    dtPack[p_RowID].Rows[i]["Seq"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["Seq"]));
                    dtPack[p_RowID].Rows[i]["SubSeq"] = PreRowID + 1;

                    dtPack[p_RowID].Rows[i]["BoxNo"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["BoxNo"]));
                    dtPack[p_RowID].Rows[i]["Qty"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"]));
                    dtPack[p_RowID].Rows[i]["Remark"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["Remark"]));
                }
            }
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
         

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2, gridView3};
            this.HTCheckDataField = new string[] {"ItemCode","Qty"};//数据明细校验必须录入字段
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

            Common.BindVendor(drpDtsVendorID, (int)EnumVendorType.客户, true);
            if (this.FormListAID == 14)
            {
                new ItemProcResLookUP(this.BaseFocusLabel, gridView1, new string[] { "ItemCode", "ItemName", "ItemStd" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.纱线 }, true, true);
            }
            else if(this.FormListAID==18)
            {
                new ItemProcResLookUP(this.BaseFocusLabel, gridView1, new string[] { "ItemCode", "ItemName", "ItemStd" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.辅料 }, true, true);
            }
            Common.BindCLS(cmbYarnType, "WH_IOFormDts", "YarnType", true);  //纱线类型
            Common.BindWHByFormList(drpWH,this.FormListAID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            Common.BindSubType(drpSubType, this.FormListAID, true);
           // Common.BindWHByFormList(drp, SysConvert.ToInt32(drpSubType.EditValue), true);
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            //Common.BindEnumUnit(RestxtUnit, true);

            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitYarn", true);
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "加载单据", false, btnLoad_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;
            gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;
            gridView3.OptionsBehavior.ShowEditorOnMouseUp = false;
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);

        }

        /// <summary>
        /// 通用窗体加载方法，如果不要使用，则重写，一般不要修改
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridColumnReadOnly(gridView2, new string[] { "BoxNo", "Qty" }, true);
            ProcessGrid.SetGridColumnReadOnly(gridView3, new string[] { "BoxNo", "Qty" }, true);
        }



        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    CurRowID = view.FocusedRowHandle;
                    GetMaDanDetail(PreRowID);
                    PreRowID = CurRowID;
                   // BindPack();
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

                    //if (SysConvert.ToString(drpWHID.EditValue) == "")
                    //{
                    //    this.ShowMessage("请选择仓库");
                    //    drpWHID.Focus();
                    //    return;
                    //}
                    frmLoadYarnStorge frm = new frmLoadYarnStorge();
                    //frm.WHID = SysConvert.ToString(drpWHID.EditValue);
                    if (this.FormListAID == 14)
                    {
                        frm.WHTypeID = (int)EnumWHType.原料仓库;
                        frm.ItemType = (int)EnumItemType.纱线;
                    }
                    else if (this.FormListAID == 18)
                    {
                        frm.WHTypeID = (int)EnumWHType.辅料仓库;
                        frm.ItemType = (int)EnumItemType.辅料;
                    }
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
                        gridViewRowChanged1(gridView1);
                        
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
                    gridView1.SetRowCellValue(setRowID, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                    gridView1.SetRowCellValue(setRowID, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                    gridView1.SetRowCellValue(setRowID, "SBitID", SysConvert.ToString(dt.Rows[0]["SBitID"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(setRowID, "YarnType", SysConvert.ToString(dt.Rows[0]["YarnType"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    //gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    //gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
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
            //entity.WHType = drpWHID.EditValue.ToString();
            entity.SubType =SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            //entity.DM = txtDM.Text.Trim();
           // entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeadType = this.FormListAID;
            //entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = DateTime.Now.Date;
            
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
                    entitydts[index].DtsVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));

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
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
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
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));

                    entitydts[index].DtsInVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsInVendorID"));
                    entitydts[index].InSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSO"));
                    entitydts[index].InOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "InOrderFormNo"));
                    entitydts[index].InSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));
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
            switch (saveFillDataType)
            {
                case  (int)EnumFillDataType.销售出库标准回填方法:
                    frm.SourceID=(int)EnumFHForType.销售合同;
                    break;
                //case (int)EnumFillDataType.调样销售出库标准回填方法:
                //    frm.SourceID=(int)EnumFHForType.调样单;
                //    break;

            }
           
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.FHFormID != null && frm.FHFormID.Length != 0)
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
                gridViewRowChanged1(gridView1);


            }
        }

        private void WHLoadFHFormSetWH(string p_Str, int p_SubType)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] fhformid = p_Str.Split(',');
            for (int i = 0; i < fhformid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_FHFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(fhformid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));

                    gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    switch (saveFillDataType)
                    {
                        case (int)EnumFillDataType.销售出库标准回填方法:
                            gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                            break;
                        //case (int)EnumFillDataType.调样销售出库标准回填方法:
                        //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsDYFormNo"]));
                        //    break;
                    }
                    gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
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

                    string outsectionID, outSbitID;
                    WHLoadFHFormSetWH(dt.Rows[0], out outsectionID, out outSbitID);

                    gridView1.SetRowCellValue(setRowID, "SectionID", outsectionID);
                    gridView1.SetRowCellValue(setRowID, "SBitID",outSbitID);
                    setRowID++;
                }
            }
        }

        /// <summary>
        /// 返回库存第一个区
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        void  WHLoadFHFormSetWH(DataRow dr,out string o_SectionID,out string o_SBitID)
        {
            string outstr = string.Empty;
            string sql = string.Empty;
            sql = "SELECT SectionID,SBitID FROM WH_Storge WHERE WHID=" + SysString.ToDBString(SysConvert.ToString(drpWHID.EditValue));
            sql += " AND ItemCode=" +SysString.ToDBString(dr["ItemCode"].ToString());
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
            return ;
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
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "Qty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        //private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    try
        //    {
        //        OnFocusedRowChanged(e.FocusedRowHandle);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void OnFocusedRowChanged(int p_FocusedRow)
        //{
        //    try
        //    {

        //        BaseFocusLabel.Focus();
        //        this.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(p_FocusedRow, gridView1.Columns["MainID"]));
        //        this.DtsSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(p_FocusedRow, gridView1.Columns["Seq"]));


        //    }
        //    catch (Exception E)
        //    {

        //        ShowMessage(E.Message);
        //    }
        //}

        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            string WHID = SysConvert.ToString(drpWHID.EditValue);
            string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GoodsCode"]));
            string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorNum"]));
            string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorName"]));
            chkAll.Checked = false;
            chkAny.Checked = false;
            this.BindGrid3(WHID, SectionID, ItemCode, GoodsCode, ColorNum, ColorName);
        }

        private void BindGrid3(string WHID, string SectionID, string ItemCode, string GoodsCode, string ColorNum, string ColorName)
        {
            string sql = "SELECT *,0 SelectFlag FROM WH_PackBox WHERE 1=1";
            sql += " AND WHID=" + SysString.ToDBString(WHID);
            //sql += " AND SectionID=" + SysString.ToDBString(SectionID);
            sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
            sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
            sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
            sql += " AND ColorName=" + SysString.ToDBString(ColorName);
            sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
            sql += " AND ISNULL(Qty,0)>0";
            DataTable dt = SysUtils.Fill(sql);
            gridView3.GridControl.DataSource = dt;
            gridView3.GridControl.Show();
        }


        /// <summary>
        /// 给码单明细赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    BaseFocusLabel.Focus();

                    MDStorgeSelectChange_Event(gridView3.FocusedRowHandle);

                    //DataTable dto = (DataTable)gridView2.GridControl.DataSource;
                    //for (int i = 0; i < gridView3.RowCount; i++)
                    //{
                    //    if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                    //    {
                    //        string BoxNo = SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo"));
                    //        decimal Qty = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Qty"));

                    //        if (SysConvert.ToInt32(gridView3.GetRowCellValue(i, "SelectFlag")) == 1)
                    //        {

                    //            SetGrid2(BoxNo, Qty);
                    //        }
                    //        else
                    //        {


                    //        }
                    //    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载库存码单选择改变行
        /// </summary>
        void MDStorgeSelectChange_Event(int rowID)
        {
            DataTable dtStorgePack = (DataTable)gridView3.GridControl.DataSource;

            if (SysConvert.ToString(dtStorgePack.Rows[rowID]["BoxNo"]) != string.Empty)
            {
                string BoxNo = SysConvert.ToString(dtStorgePack.Rows[rowID]["BoxNo"]);
                decimal Qty = SysConvert.ToDecimal(dtStorgePack.Rows[rowID]["Qty"]);

                if (SysConvert.ToInt32(dtStorgePack.Rows[rowID]["SelectFlag"]) == 1)
                {
                    SetGrid2(BoxNo, Qty);
                }
                else
                {
                    SetGrid2Del(BoxNo, Qty);

                }
                SetPackDts();
            }
        }

        private void SetPackDts()
        {
            this.BaseFocusLabel.Focus();
            string PackDts = "";
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if(SysConvert.ToDecimal(gridView2.GetRowCellValue(i,"Qty"))!=0)
                {
                    if (PackDts != "")
                    {
                        PackDts += ",";
                    }
                    
                    PackDts += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty")).ToString("f1");
                    
                }

            }
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PackDts", PackDts);
        }


        /// <summary>
        /// 设置，判断条码是否存在，如不存在，则可赋值
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2(string BoxNo, decimal Qty)
        {
            bool findFlag = false;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) == BoxNo)
                {
                    findFlag = true;
                }
            }
            if (findFlag)
            {
                return;
            }
            DataTable dtPackSource = (DataTable)gridView2.GridControl.DataSource;
            for (int i = 0; i < dtPackSource.Rows.Count; i++)
            {
                if (SysConvert.ToString(dtPackSource.Rows[i]["BoxNo"]) == string.Empty)
                {
                    dtPackSource.Rows[i]["BoxNo"] = BoxNo;
                    dtPackSource.Rows[i]["Qty"] = Qty;

                    SetGrid1Qty();
                    return;
                }
            }
            //没有赋值成功，说明行不足
            dtPackSource.Rows.Add(dtPackSource.NewRow());

            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["BoxNo"] = BoxNo;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["Qty"] = Qty;

            SetGrid1Qty();
        }

        /// <summary>
        /// 设置，判断条码是否存在，如存在，则可删除
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2Del(string BoxNo, decimal Qty)
        {
            bool findFlag = false;
            int findIndex = -1;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) == BoxNo)
                {
                    findIndex = i;
                    findFlag = true;
                }
            }
            if (!findFlag)
            {
                return;
            }
            DataTable dtPackSource = (DataTable)gridView2.GridControl.DataSource;
            dtPackSource.Rows.RemoveAt(findIndex);

            SetGrid1Qty();
        }

        /// <summary>
        /// 设置Grid1Qty数量
        /// </summary>
        void SetGrid1Qty()
        {
            int pieceQty = 0;
            decimal qty = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) != string.Empty)
                {
                    pieceQty++;
                    qty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                }
                else//如果不是连续行，自动跳出循环，提高效率
                {
                    break;
                }
            }

            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", pieceQty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty);
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

                if (!CheckCorrect())
                {
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

        #region 全选 反选
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                        {
                            if (chkAll.Checked)
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 1);
                                MDStorgeSelectChange_Event(i);
                            }
                            else
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 0);
                                MDStorgeSelectChange_Event(i);
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
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAny_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                        {
                            if (SysConvert.ToInt32(gridView3.GetRowCellValue(i, "SelectFlag")) == 0)
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 1);
                                MDStorgeSelectChange_Event(i);
                            }
                            else
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 0);
                                MDStorgeSelectChange_Event(i);
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
                string sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo="+SysString.ToDBString(txtFHFormNo.Text.Trim());
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

               sql = "SELECT  FormNo FROM UV1_Sale_FHForm WHERE FormNo IN(SELECT DtsSO FROM WH_IOFormDts) AND FormNo="+SysString.ToDBString(txtFHFormNo.Text.Trim());

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
                if(dt.Rows.Count>0)
                {
                    int FHForTypeID = SysConvert.ToInt32(dt.Rows[0]["FHForTypeID"]);
                    if (FHForTypeID ==(int)EnumFHForType.调样单)
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
                        gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[i]["GoodsCode"]));
                        gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                        gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[i]["VColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[i]["VColorName"]));
                        gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[i]["VItemCode"]));
                        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[i]["MWidth"]));
                        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[i]["MWeight"]));
                        gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[i]["WeightUnit"]));
                        gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[i]["GoodsLevel"]));
                        gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));

                        gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
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
                            gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[i]["Qty"]));
                        }

                        if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[i]["PieceQty"]));
                        }
                        if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[i]["SingPrice"]));
                        }

                        string outsectionID, outSbitID;
                        WHLoadFHFormSetWH(dt.Rows[i], out outsectionID, out outSbitID);

                        gridView1.SetRowCellValue(setRowID, "SectionID", outsectionID);
                        gridView1.SetRowCellValue(setRowID, "SBitID", outSbitID);
                    }
                    gridViewRowChanged1(gridView1);
                }

            }
            catch(Exception E)
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