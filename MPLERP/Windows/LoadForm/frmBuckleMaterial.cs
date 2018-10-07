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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 加工扣料纱线界面
    /// </summary>
    public partial class frmBuckleMaterial : frmAPBaseUIFormEdit
    {
        public frmBuckleMaterial()
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

        /// <summary>
        /// 判断是否需要码单
        /// </summary>
        private bool m_PackFlag=true;
        public bool PackFlag
        {
            get
            {
                return m_PackFlag;
            }
            set
            {
                m_PackFlag = value;
            }
        }

        /// <summary>
        /// 仓库单据物料类型
        /// </summary>
        private int m_WHItemTypeID = 0;
        public int WHItemTypeID
        {
            get
            {
                return m_WHItemTypeID;
            }
            set
            {
                m_WHItemTypeID = value;
            }
        }



        /// <summary>
        /// 仓库单据大类型
        /// </summary>
        private int m_WHFormListAID = 0;
        public int WHFormListAID
        {
            get
            {
                return m_WHFormListAID;
            }
            set
            {
                m_WHFormListAID = value;
            }
        }


        /// <summary>
        /// 仓库单据子类型
        /// </summary>
        private int m_WHFormListBID = 0;
        public int WHFormListBID
        {
            get
            {
                return m_WHFormListBID;
            }
            set
            {
                m_WHFormListBID = value;
            }
        }

        /// <summary>
        /// 扣料库别
        /// </summary>
        private string m_WHID = "";
        public string WHID
        {
            get
            {
                return m_WHID;
            }
            set
            {
                m_WHID = value;
            }
        }

        /// <summary>
        /// 扣料出口类型
        /// </summary>
        private string m_FormNo = "";
        public string FormNo
        {
            get
            {
                return m_FormNo;
            }
            set
            {
                m_FormNo = value;
            }
        }

        /// <summary>
        /// 扣料出口类型
        /// </summary>
        private int m_MainID = 0;
        public int MainID
        {
            get
            {
                return m_MainID;
            }
            set
            {
                m_MainID = value;
            }
        }


        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            
            if (txtFormNo.Text.Trim() == string.Empty)
            {
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
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
            //FabricWHOutFormDtsRule rule = new FabricWHOutFormDtsRule();
            //DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            string sql = "SELECT * FROM WO_FabricWHOutFormDts WHERE MainID IN (SELECT ID FROM WO_FabricWHOutForm WHERE MainID=" + SysString.ToDBString(m_MainID) + ")";
            DataTable dtDts = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FabricWHOutFormRule rule = new FabricWHOutFormRule();
            FabricWHOutForm entity = EntityGet();
            FabricWHOutFormDts[] entitydts = EntityDtsGet();
            //decimal TotalQty = 0;
            //decimal TotalAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
            //    TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            //}
            //entity.TotalQty = TotalQty;
            //entity.TotalAmount = TotalAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
          
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }


       
        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FabricWHOutFormRule rule = new FabricWHOutFormRule();
            FabricWHOutForm entity = EntityGet();
            FabricWHOutFormDts[] entitydts = EntityDtsGet();
            //decimal TotalQty = 0;
            //decimal TotalAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
            //    TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            //}
            //entity.TotalQty = TotalQty;
            //entity.TotalAmount = TotalAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
          
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FabricWHOutForm entity = new FabricWHOutForm();
            entity.MainID = m_MainID;
            bool findFlag=entity.SelectByID2();
            HTDataID = entity.ID;
            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.MakeDate;
            drpWHID.EditValue = entity.WHID;
            //txtRemark.Text = entity.Remark;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;

            txtJGFormNo.Text = m_FormNo;
            txtJGWHFormNo.Text = entity.AutoIOFormNo;

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
       

        /// <summary>
        /// 绑定面料显示控件
        /// </summary>
        void BindUCFabView(DataTable dtSource)
        {
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
        }


       
        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FabricWHOutFormRule rule = new FabricWHOutFormRule();
            FabricWHOutForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, false);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            drpWHID.Properties.ReadOnly = !p_Flag;
            //drpWHID.Enabled = false;
            //txtFormNo.Enabled = false;
            
            ProductCommon.FormNoCtlEditSet(txtFormNo, "WO_FabricWHOutForm", "FormNo", 0, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            drpWHID.EditValue = m_WHID;
            txtJGFormNo.Text = m_FormNo;

         

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_FabricWHOutForm";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段 ,"Qty"
            //Common.BindVendor2(drpVendorID, (int)EnumVendorType.客户, true);
            //new VendorProc(drpVendorID);
            Common.BindWHByItemType(drpWHID, m_WHItemTypeID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            //Common.BindSubType(drpSubType, m_WHFormListAID, true);
            
            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitYarn", true);
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;

            if (m_PackFlag)
            {
                groupControl2.Visible = true;
                ucFabView1.Visible = true;
            }
            else
            {
                groupControl2.Visible = false;
                ucFabView1.Visible = false;
             }

             SetIniFormStatus();



        }

        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(1, ToolButtonName.btnInsert.ToString(), "新增", false, btnInsert_Click, eShortcut.F1);
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "修改", false, btnUpdate_Click, eShortcut.F2);
            this.ToolBarItemAdd(3, ToolButtonName.btnDelete.ToString(), "删除", false, btnDelete_Click, eShortcut.F3);
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "保存", false, btnSave_Click, eShortcut.F4);
            this.ToolBarItemAdd(5, ToolButtonName.btnCancel.ToString(), "放弃", false, btnCancel_Click);
            this.ToolBarItemAdd(29, ToolButtonName.btnSubmit.ToString(), "提交", true, btnSubmit_Click);
            this.ToolBarItemAdd(30, ToolButtonName.btnSubmitCancel.ToString(), "撤消提交", false, btnSubmitCancel_Click);
        }

        private void SetIniFormStatus()
        {
            string sql = "SELECT * FROM WO_FabricWHOutForm WHERE MainID="+SysString.ToDBString(m_MainID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                EntitySet();
                BindGridDts();

                //btnUpdate_Click(null, null);
            }
            else
            {
                btnInsert_Click(null, null);
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
                    sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum FROM WH_IOFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
                    DataTable dt = SysUtils.Fill(sql);

                    BindUCFabView(dt);
                  

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
                    //if (Common.CheckLookUpEditBlank(drpSubType))
                    //{
                    //    this.ShowMessage("请选择单据类型");
                    //    return;
                    //}

                    if (SysConvert.ToString(drpWHID.EditValue) == "")
                    {
                        this.ShowMessage("请选择仓库");
                        drpWHID.Focus();
                        return;
                    }
                    frmLoadYarnStorge frm = new frmLoadYarnStorge(); 
                    frm.WHID = SysConvert.ToString(drpWHID.EditValue);
                    frm.WHTypeID = (int)EnumWHType.原料仓库;
                    frm.ItemType = (int)EnumItemType.纱线;
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
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
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
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FabricWHOutForm EntityGet()
        {
            FabricWHOutForm entity = new FabricWHOutForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.MainID = m_MainID;
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtFormDate.DateTime;
            //entity.VendorID = drpVendorID.EditValue.ToString();
            //entity.Remark = txtRemark.Text.Trim();
            entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.MakeOPName = FParamConfig.LoginName;

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FabricWHOutFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            FabricWHOutFormDts[] entitydts = new FabricWHOutFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new FabricWHOutFormDts();
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
                    //entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));                    
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    //entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));

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

    

        #region 其它事件
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {

                    ProductCommon.FormNoIniSet(txtFormNo, "WO_FabricWHOutForm", "FormNo");

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

                //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                //{
                //    this.ShowMessage("你没有此操作权限");
                //    return;
                //}

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!CheckCorrect())
                {
                    return;
                }

                FabricWHOutFormRule rule = new FabricWHOutFormRule();
                //string o_ErrorMsg = string.Empty;
                //if (!rule.RCheckCorrectPackData(HTDataID, out o_ErrorMsg))// 如果校验不通过
                //{
                //    this.ShowMessage(o_ErrorMsg);
                //    return;
                //}

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

                //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                //{
                //    this.ShowMessage("你没有此操作权限");
                //    return;
                //}
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                if (!CheckCorrect())
                {
                    return;
                }

                FabricWHOutFormRule rule = new FabricWHOutFormRule();
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

        #region 按钮事件重载
        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                FabricWHOutFormRule rule = new FabricWHOutFormRule();
                string o_ErrMsg;
                if (!rule.RAddCheck(MainID, out o_ErrMsg))
                {
                    this.ShowMessage(o_ErrMsg);
                    return;
                }

                base.btnInsert_Click(sender, e);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 新增已存在事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnInsertExist_Click(object sender, EventArgs e)
        {
            try
            {
                FabricWHOutFormRule rule = new FabricWHOutFormRule();
                string o_ErrMsg;
                if (!rule.RAddCheck(MainID, out o_ErrMsg))
                {
                    this.ShowMessage(o_ErrMsg);
                    return;
                }

                base.btnInsertExist_Click(sender, e);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region 其它事件2

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
                        frm.PackType = (int)EnumPackType.仓库单据;
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
        #endregion


        #region 打印重写
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            HTPrintDataSourceFlag = true;
            DataTable dtm = UCFabDataConvert.WHFabConvert(HTDataID, 8);
            dtm.TableName = "eee";
            HTPrintDataSource = new DataTable[] { dtm };
            base.btnDesign_Click(sender, e);
        }
        #endregion

        #region 修改方法

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (m_MainID == 0)
                {
                    this.ShowMessage("请选择记录");
                    return;
                }
                HTDataOldID = HTDataID;
                SetFormStatus(FormStatus.修改);
                IniUpdateSet();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();
                if (this.HTFormStatus == FormStatus.新增)
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    int tempID = EntityAdd();
                    FCommon.AddDBLog(this.Text, "新增", "ID:" + tempID.ToString(), "");
                    this.HTDataID = tempID;

                }
                else if (this.HTFormStatus == FormStatus.修改)
                {
                    //if (!HTSubmitCheck(FormStatus.修改))
                    //{
                    //    return;
                    //}

                    if (!CheckCorrect())
                    {
                        return;
                    }
                    EntityUpdate();
                    FCommon.AddDBLog(this.Text, "修改", "ID:" + HTDataID.ToString(), "");
                }

                SetFormStatus(FormStatus.查询);
                //EntitySet();
                SetPosStatus(HTDataID);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.删除))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("删除为不可恢复操作，确认删除本条记录？"))
                {
                    return;
                }

                EntityDelete();//调用虚方法
                FileDeleteDataFile();//文件删除
                FCommon.AddDBLog(this.Text, "删除", "ID:" + HTDataID, "");
                //this.EntitySet();
                SetPosStatus(0);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


    }
}