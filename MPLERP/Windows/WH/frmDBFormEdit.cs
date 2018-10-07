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
    public partial class frmDBFormEdit : frmModuleBaseWHEdit
    {
        public frmDBFormEdit()
        {
            InitializeComponent();
        }

        #region 全局变量

        private DataTable[] dtPack = new DataTable[150];//码单信息表
        private int PreRowID = -1;//初始行号
        private int CurRowID = -1;//当前行号
        //private int DtsID = 0;
        //private int DtsSeq = 0;

        bool saveXMFlag = false;//是否有细码
        int saveFormNoControlID = 0;//单号控制ID
        int saveWHType = 0;//仓库类型
        string saveDefaultWHID = string.Empty;
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

            if (SysConvert.ToString(drpFormListDBID.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择单据类型");
                drpFormListDBID.Focus();
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
            DBFormDtsRule rule = new DBFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            DBFormRule rule = new DBFormRule();
            DBForm entity = EntityGet();
            DBFormDts[] entitydts = EntityDtsGet();
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = TotalQty;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
          
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }


       
        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            DBFormRule rule = new DBFormRule();
            DBForm entity = EntityGet();
            DBFormDts[] entitydts = EntityDtsGet();
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = TotalQty;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
          
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            DBForm entity = new DBForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpVendorID.EditValue = entity.VendorID;
            drpWHID.EditValue = entity.WHID;
            drpTargetWHID.EditValue = entity.TargetWHID;
            //drpFormListDBID.EditValue = entity.FormListDBID;
           
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtRemark.Text = entity.Remark;

            txtOutWHFormNo.Text = entity.OutWHFormNo;
            txtInWHFormNo.Text = entity.InWHFormNo;

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
                            DBFormDtsPack entity = new DBFormDtsPack();
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
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//成品仓库不使用码单模式
            {             
                //6402 6404必须相左设置的
                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6404)))//成品仓库出库支持录入码单
                {
                    ucFabView1.UCColumnISNHide = true;//隐藏条码列
                }
            }
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
            DBFormRule rule = new DBFormRule();
            DBForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            drpFormListDBID.Properties.ReadOnly = true;
            txtInWHFormNo.Properties.ReadOnly = true;
            txtOutWHFormNo.Properties.ReadOnly = true;
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);

            drpWHID.EditValue = saveDefaultWHID;
         

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_DBForm";
            this.HTDataDts = gridView1;
            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2};
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段 ,"Qty"
            //Common.BindOP(drpSaleOPID, true);


            BindFormListDB();
            new VendorProc(drpVendorID);
            Common.BindWHByWHType(drpWHID, saveWHType, true);
            Common.BindWHByWHType(drpTargetWHID, saveWHType, true);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            Common.BindSubTypeDB(drpFormListDBID, true);

            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitFab", true);
            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;
            drpFormListDBID.EditValue = this.FormListAID;
           
            //Common.BindEnumUnit(RestxtUnit, true);
           // B


          

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


                    if (saveXMFlag)//
                    {
                        sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum,InputQty FROM WH_DBFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
                        DataTable dt = SysUtils.Fill(sql);

                        BindUCFabView(dt, "", 0);
                    }

                   

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
                    if (Common.CheckLookUpEditBlank(drpFormListDBID))
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
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));

                    gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["DutyOPID"]));
                    setRowID++;
                }
            }
        }



        /// <summary>
        /// 单据类型初始化设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BindFormListDB()
        {
            try
            {
                string sql = "SELECT * FROM Enum_FormListDB WHERE ID=" + SysString.ToDBString(this.FormListAID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    saveDefaultWHID = dt.Rows[0]["DefaultWHID"].ToString();

                    Common.BindVendorByFormListID(drpVendorID, SysConvert.ToInt32(dt.Rows[0]["OutWHFormID"]), true);//设置客户

                    saveXMFlag = SysConvert.ToBoolean(SysConvert.ToInt32(dt.Rows[0]["XMFlag"]));
                    saveFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]);
                    saveWHType = SysConvert.ToInt32(dt.Rows[0]["WHTypeID"]);
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
        private DBForm EntityGet()
        {
            DBForm entity = new DBForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime.Date;

            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.TargetWHID = SysConvert.ToString(drpTargetWHID.EditValue);
            entity.FormListDBID = SysConvert.ToInt32(drpFormListDBID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private DBFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            DBFormDts[] entitydts = new DBFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new DBFormDts();
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
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));



                    entitydts[index].InputQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputQty"));
                    entitydts[index].InputUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "InputUnit"));
                    entitydts[index].InputSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputSinglePrice"));
                    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice;// +entitydts[index].FAmount1 + entitydts[index].FAmount2 + entitydts[index].FAmount3 + entitydts[index].FAmount4 + entitydts[index].FAmount5;
                    entitydts[index].InputConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputConvertXS"));

               


                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty + entitydts[index].DYPrice;
  			 		entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel")); 
  			 		entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum")); 
  			 		entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName")); 
  			 		entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));

                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));

                    entitydts[index].PackDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "PackDts"));

                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));                    
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID")); //SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));

                    entitydts[index].DtsInVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsInVendorID"));
                    entitydts[index].InSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSO"));
                    entitydts[index].InOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "InOrderFormNo"));
                    entitydts[index].InSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));
                    entitydts[index].LoadDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadDtsID"));


                    //if ((SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5404)) && entitydts[index].InputUnit != string.Empty)//销售订单使用下单数量制单时确定是否需要单位转换模式及计算方法类型 默认否，此功能设置为是时，5405应设置为0
                    //  || SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
                    //{
                    //    entitydts[index].InputQty = ProductCommon.UnitConvertValueAnyUnit(entitydts[index].Unit, entitydts[index].Qty, entitydts[index].InputUnit, entitydts[index].InputConvertXS);
                    //    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].DYPrice;
                    //    entitydts[index].SinglePrice = SysConvert.ToDecimal(entitydts[index].InputSinglePrice * entitydts[index].InputConvertXS, 2);
                    //    entitydts[index].Amount = entitydts[index].InputAmount;


                    //}


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
                    if (Common.CheckLookUpEditBlank(drpFormListDBID))
                    {
                        this.ShowMessage("请选择单据类型");
                        return;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

      

        

        

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
                    txtFormNo.Text = rule.RGetFormNo(saveFormNoControlID);
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

                //sc 出库提交前校验细码与库存细码是否对上
                if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//非 成品仓库不使用码单模式
                {
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
                }
                DBFormRule rule = new DBFormRule();
                if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//非 成品仓库不使用码单模式
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

                DBFormRule rule = new DBFormRule();
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

        

        private void frmOutWHEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    DBForm entity = new DBForm();
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
                    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                    string ItemName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                    string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum"));
                    string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                    string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));
                    string Batch = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Batch"));

                    if (ID > 0)
                    {
                        frmLoadOutWH frm = new frmLoadOutWH();
                        frm.PackType = (int)EnumPackType.调拨单据;
                        frm.IOFormID = HTDataID;
                        frm.ID = ID;
                        frm.WHID = WHID;
                        frm.ItemCode = ItemCode;
                        frm.ColorNum = ColorNum;
                        frm.ColorName = ColorName;
                        frm.JarNum = JarNum;
                        frm.Batch = Batch;
                        frm.KPButtonFlag = true;
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



        #region 打印重写
        //public override void btnDesign_Click(object sender, EventArgs e)
        //{
        //    HTPrintDataSourceFlag = true;
        //    DataTable dtm = UCFabDataConvert.WHFabConvert(HTDataID, 8);
        //    dtm.TableName = "eee";
        //    HTPrintDataSource = new DataTable[] { dtm };
        //    base.btnDesign_Click(sender, e);
        //}
        #endregion

       


    }
}