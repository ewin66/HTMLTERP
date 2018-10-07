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
    public partial class frmYQWHEdit : frmAPBaseUIFormEdit
    {
        public frmYQWHEdit()
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
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择溢缺对象");
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
                this.ShowMessage("请选择溢缺类型");
                drpSubType.Focus();
                return false;
            }

            if (!this.CheckCorrectDts())
            {
                return false;
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
                    sql += " AND JarNum="+SysString.ToDBString(JarNum);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0]["PieceQty"]) != PieceQty)
                        {
                            if (MessageBox.Show("第" + SysConvert.ToInt32(i + 1).ToString() + "行数据细码数与发货单中细码数不一样，发货单的细码数是：" + SysConvert.ToInt32(dt.Rows[0]["PieceQty"]).ToString()+"，是否继续保存", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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
            YQFormDtsRule rule = new YQFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            YQFormRule rule = new YQFormRule();
            YQForm entity = EntityGet();
            YQFormDts[] entitydts = EntityDtsGet();
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
            GetMaDanDetail(CurRowID);
            ArrayList List = new ArrayList();
            GetMadanDts(List);
            rule.RAdd2(entity, entitydts,List);
            return entity.ID;
        }


       
        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            YQFormRule rule = new YQFormRule();
            YQForm entity = EntityGet();
            YQFormDts[] entitydts = EntityDtsGet();
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
            GetMaDanDetail(CurRowID);
            ArrayList List = new ArrayList();
            GetMadanDts(List);
            rule.RUpdate(entity, entitydts, List);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            YQForm entity = new YQForm();
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
            drpFHTypeID.EditValue =SysConvert.ToInt32(entity.FHTypeID);
            txtKDNo.Text = entity.KDNo.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            SetYQFormDetail();
            BindPack();
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
                            YQFormDtsPack entity = new YQFormDtsPack();
                            entity.MainID = HTDataID;
                            entity.Seq = j + 1;
                            entity.SubSeq = m + 1;

                            entity.BoxNo = dtPack[j].Rows[m]["BoxNo"].ToString();
                            entity.Qty = SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]);
                            entity.Remark = SysConvert.ToString(dtPack[j].Rows[m]["Remark"]);
                            entity.PDQty = SysConvert.ToDecimal(dtPack[j].Rows[m]["PDQty"]);
                            entity.FactQty = SysConvert.ToDecimal(dtPack[j].Rows[m]["FactQty"]);


                            List.Add(entity);

                        }
                    }
                }
            }
        }
        private void SetYQFormDetail()
        {
            
            #region
            int TempID = -1;
            int PSeq = -1;
            int j = 0;//控制gridview的行号
            string sql = string.Empty;
            sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_YQFormDtsPack WHERE 1=0";
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
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_YQFormDtsPack WHERE 1=0";
                        TempID = SysUtils.Fill(sql).Rows.Count;
                        dtPack[PSeq] = SysUtils.Fill(sql);
                        j++;
                    }
                    else
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_YQFormDtsPack WHERE 1=1";
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
            YQFormRule rule = new YQFormRule();
            YQForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
         

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_YQForm";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2, gridView3};
            this.HTCheckDataField = new string[] {"ItemCode","SectionID","Qty"};//数据明细校验必须录入字段
            Common.BindOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户,(int)EnumVendorType.工厂}, true);
            new VendorProc(drpVendorID);
            Common.BindWHByFormList(drpWHID,this.FormListAID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_YQFormDts", "GoodsLevel", true);
            Common.BindYQType(drpSubType,true);
           
            Common.BindCLS(drpXZ, "WH_YQForm", "XZ", true);
            //Common.BindEnumUnit(RestxtUnit, true);

            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitFab", true);

            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(28, "btnLoad", "加载", false, btnLoad_Click);
            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);
           
          
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
                    BindPack();
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
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private YQForm EntityGet()
        {
            YQForm entity = new YQForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime;
            entity.XZ = drpXZ.Text.Trim();
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.WHType = drpWHID.EditValue.ToString();
            entity.SubType =SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            //entity.DM = txtDM.Text.Trim();
           // entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeadType = this.FormListAID;
            entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.KDNo = txtKDNo.Text.Trim();
            entity.FHTypeID = SysConvert.ToInt32(drpFHTypeID.EditValue);
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private YQFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            YQFormDts[] entitydts = new YQFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new YQFormDts();
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
                    entitydts[index].MoveQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MoveQty")); 
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));
                    if (entitydts[index].SinglePrice == 0)
                    {
                        entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")) + entitydts[index].DYPrice;
                    }
                    else
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].MoveQty + entitydts[index].DYPrice;
                    }
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
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));

                    entitydts[index].DtsInVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsInVendorID"));
                    entitydts[index].InSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSO"));
                    entitydts[index].InOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "InOrderFormNo"));
                    entitydts[index].InSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));

                    entitydts[index].DLaodDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLaodDtsID"));
                    entitydts[index].DLoadFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLoadFormNo"));
                    entitydts[index].DLoadSubType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLoadSubType"));
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
                        this.ShowMessage("请选择溢缺类型");
                        drpSubType.Focus();
                        return;
                    }
                    if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    {
                        this.ShowMessage("请选择溢缺单位");
                        drpVendorID.Focus();
                        return;
                    }
                    WHLoadWHYQForm();
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
            sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT DtsSO+ItemCode+ColorNum+ColorName OrderFormNo FROM UV1_WH_YQFormDts";
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
                    gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
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

        #region 加载出入库单
        /// <summary>
        /// 加载出入库单
        /// </summary>
        private void WHLoadWHYQForm()
        {
            frmLoadYQIOForm frm = new frmLoadYQIOForm();
            string sql = "";
            sql += " AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //sql += " AND SubType IN (1101,1102,1201,1203)";
            //sql += " AND ISNULL(InvoiceQty,0)=0";
            frm.HTLoadConditionStr = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.DtsID != null && frm.DtsID.Length != 0)
            {

                for (int i = 0; i < frm.DtsID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.DtsID[i]);
                }
                WHLoadWHYQFormSetWH(str);
                gridViewRowChanged1(gridView1);
            }
        }

        /// <summary>
        /// 加载出入库单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadWHYQFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//只有一行明细数据
                {

                    gridView1.SetRowCellValue(setRowID, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["DLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DtsVendorID"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    //if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    //}
                    //if (SysConvert.ToString(dt.Rows[0]["Weight"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "Weight", SysConvert.ToString(dt.Rows[0]["Weight"]));
                    //}
                    gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));

                    gridView1.SetRowCellValue(setRowID, "DLaodDtsID", SysConvert.ToInt32(dt.Rows[0]["DtsID"]));
                    gridView1.SetRowCellValue(setRowID, "DLoadFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLoadSubType", SysConvert.ToInt32(dt.Rows[0]["SubType"]));
                    setRowID++;
                }
            }
        }

        #endregion

        #region 加载染布加工单
        /// <summary>
        /// 加载染布加工单
        /// </summary>
        private void WHLoadFabricProcessForm()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择"+drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadRbJG frm = new frmLoadRbJG();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_YQFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            //frm.LoadType = (int)EnumMLType.白坯;
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
                    if (i == 0)
                    {
                        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["DyeFactorty"]);
                    }

                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32((int)EnumMLType.白坯));
                    //if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    //}

                    setRowID++;
                }
            }
        }

        #endregion

        #region 加载印花加工单
        /// <summary>
        /// 加载印花加工单
        /// </summary>
        private void WHLoadPrintingProcessForm()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择" + drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadYHJG frm = new frmLoadYHJG();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_YQFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
           // frm.LoadType = (int)EnumMLType.白坯;
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
                WHLoadPrintingProcessFormSetWH(str);

            }
        }

        /// <summary>
        /// 加载印花加工单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadPrintingProcessFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_PrintingProcessDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    if (i == 0)
                    {
                        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["DyeFactorty"]);
                    }
                    //foreach (DataRow dt.Rows[0] in dt.Rows)
                    //{
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32((int)EnumMLType.白坯));
                    //if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    //}

                    setRowID++;
                    //}
                }
            }
        }

        #endregion

        #region  加载白坯织造加工单
        /// <summary>
        ///  加载白坯织造加工单
        /// </summary>
        private void WHLoadWeaveProcessForm()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择" + drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadZZJG frm = new frmLoadZZJG();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_YQFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            // frm.LoadType = (int)EnumMLType.白坯;
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
                WHLoadWeaveProcessFormSetWH(str);

            }
        }

        /// <summary>
        /// 加载白坯织造加工单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadWeaveProcessFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_WeaveProcessDts WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (i == 0)
                        {
                            drpVendorID.EditValue = SysConvert.ToString(dr["DyeFactory"]);
                        }
                        gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dr["ItemCode"]));
                        gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dr["ItemName"]));
                        gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dr["ItemStd"]));
                        gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dr["ItemModel"]));
                        gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dr["Batch"]));
                        gridView1.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dr["VendorBatch"]));
                        gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dr["ColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dr["ColorName"]));
                        gridView1.SetRowCellValue(setRowID, "YarnType", SysConvert.ToString(dr["YarnType"]));
                        gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dr["VColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dr["VColorName"]));
                        gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dr["FormNo"]));
                        gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dr["OrderFormNo"]));

                        gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dr["Unit"]));
                        //gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dr["DVendorID"]));
                        if (SysConvert.ToString(dr["Qty"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dr["Qty"]));
                        }
                        //gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToString(dr["MLType"]));
                        //if (SysConvert.ToString(dr["SingPrice"]) != "")
                        //{
                        //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dr["SingPrice"]));
                        //}

                        setRowID++;
                    }
                }
            }
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
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.溢缺单号);
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
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//编辑状态下
                {
                    int YQType = SysConvert.ToInt32(drpSubType.EditValue) ;
                    if (YQType == (int)EnumYQType.库存)
                    {
                        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.客户 }, true);
                    }
                    if (YQType == (int)EnumYQType.采购)
                    {
                        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂}, true);
                    }
                    if (YQType == (int)EnumYQType.销售)
                    {
                        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                    }
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
            int DLaodDtsID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DLaodDtsID"]));
            chkAll.Checked = false;
            chkAny.Checked = false;
            this.BindGrid3(WHID, SectionID, ItemCode, GoodsCode, ColorNum, ColorName, DLaodDtsID);
        }

        private void BindGrid3(string WHID, string SectionID, string ItemCode, string GoodsCode, string ColorNum, string ColorName, int DLaodDtsID)
        {
            string sql = "";
            if (DLaodDtsID == 0)
            {
                sql = "SELECT *,0 SelectFlag FROM WH_PackBox WHERE 1=1";
                sql += " AND WHID=" + SysString.ToDBString(WHID);
                //sql += " AND SectionID=" + SysString.ToDBString(SectionID);
                sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
                sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
                sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                //sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
                //if (SysConvert.ToInt32(drpSubType.EditValue) == (int)EnumYQType.采购)
                //{
                //    sql += " AND InFormNo NOT IN (SELECT FormNo FROM UV1_WH_IOFormDts WHERE ISNULL(InvoiceQty,0)<>0 AND SubmitFlag>0) ";
                //}
                //if (SysConvert.ToInt32(drpSubType.EditValue) == (int)EnumYQType.销售)
                //{
                //    sql += " AND OutFormNo NOT IN (SELECT FormNo FROM UV1_WH_IOFormDts WHERE ISNULL(InvoiceQty,0)<>0 AND SubmitFlag>0)";
                //}
                //sql += " AND ISNULL(Qty,0)>0";
                sql += " ORDER BY BoxNo";
            }
            else
            {
                sql = "SELECT 0 SelectFlag,'' PackNo,BoxNo,PQty Qty,Remark,SectionID from UV1_WH_IOFormDtsPack WHERE DtsID=" + SysString.ToDBString(DLaodDtsID);
                //sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
                //sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
                //sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                //sql += " AND ISNULL(InvoiceQty,0)=0";
            }
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

                sql = "SELECT  FormNo FROM UV1_Sale_FHForm WHERE FormNo IN(SELECT DtsSO FROM UV1_WH_YQFormDts WHERE SubType IN(SELECT ID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(FormListAID)+" ) ) AND FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                
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
                    gridViewRowChanged1(gridView1);
                }

            }
            catch(Exception E)
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
                    YQForm entity = new YQForm();
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

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "FactQty")
                {
                    decimal pdqty = SysConvert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "FactQty"))
                    - SysConvert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Qty"));
                    if (pdqty != 0)
                    {
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "PDQty", pdqty);
                    }
                    else
                    {
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "PDQty", DBNull.Value);
                    }
                    SetGrid1Qty2();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        void SetGrid1Qty2()
        {
            int pieceQty = 0;
            decimal qty = 0;
            decimal pdqty = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) != string.Empty)
                {
                    pieceQty++;
                    qty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                    pdqty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "PDQty"));
                }
                else//如果不是连续行，自动跳出循环，提高效率
                {
                    break;
                }
            }

            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", pieceQty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MoveQty", pdqty);
        }

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

                YQFormRule rule = new YQFormRule();
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

                if (!CheckCorrect())
                {
                    return;
                }

                YQFormRule rule = new YQFormRule();
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


       




    }
}