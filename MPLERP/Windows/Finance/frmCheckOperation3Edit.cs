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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmCheckOperation3Edit : frmAPBaseUIFormEdit
    {
        public frmCheckOperation3Edit()
        {
            InitializeComponent();
        }
        int IsMerge = 0;

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
           
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入对账单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择往来单位");
                drpVendorID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("请选择业务员");
                drpSaleOPID.Focus();
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
            CheckOperationDtsRule rule = new CheckOperationDtsRule();
            DataTable dtDts = new DataTable();
            if (IsMerge == 1)
            {
                string sql = "SELECT MainID,Seq,DLOADID,DLOADSEQ,DLOADDtsID,DLOADNO,DCheckQty,DCheckSinglePrice,DCheckAmount,DtsRemark,FormNM,WHFormNo,WHFormDate,SUM(Qty) Qty,SinglePrice,SUM(Amount) Amount,ItemCode,ItemName,ItemStd,ItemModel,GoodsCode,ColorNum,ColorName,DtsOrderFormNo,SUM(PieceQty) PieceQty,DCheckDYPrice,DYPrice,Unit,FormDZFlag,TZAmount,InvoiceFlag,FAmount1,FAmount2,FAmount3,FAmount4 FROM UV2_Finance_CheckOperationDts2 WHERE 1=1 " + " AND MainID=" + HTDataID + "GROUP BY MainID,Seq,DLOADID,DLOADSEQ,DLOADDtsID,DLOADNO,DCheckQty,DCheckSinglePrice,DCheckAmount,DtsRemark,FormNM,WHFormNo,WHFormDate,SinglePrice,ItemCode,ItemName,ItemStd,ItemModel,GoodsCode,ColorNum,ColorName,DtsOrderFormNo,DCheckDYPrice,DYPrice,Unit,FormDZFlag,TZAmount,InvoiceFlag,FAmount1,FAmount2,FAmount3,FAmount4";
                dtDts = SysUtils.Fill(sql);
            }
            else
            {
                dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            }
            SetWHQty(dtDts);
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        private void SetWHQty(DataTable dtDts)
        {
            foreach (DataRow dr in dtDts.Rows)
            {
                if (SysConvert.ToInt32(dr["FormDZFlag"]) == (int)EnumDZFlag.对帐负)
                {
                    dr["Qty"] = 0 - SysConvert.ToDecimal(dr["Qty"]);
                    dr["Amount"] = 0 - SysConvert.ToDecimal(dr["Amount"]);
                }
            }
        }

      



        /// <summary>
        /// 处理本期余额
        /// </summary>
        void ProcThisQty(CheckOperation entity, CheckOperationDts[] entitydts, CheckOperationInvDts[] entityInvDts, CheckOperationPayDts[] entityPayDts)
        {
            decimal totalThisQty = 0;//本期发生数量
            decimal totalThisAmount = 0;//本期发生金额
            decimal totalThisInvQty = 0;//本期发票数量
            decimal totalThisInvAmount = 0;//本期发票金额
            decimal totalThisPayAmount = 0;//本期支付金额

            for (int i = 0; i < entitydts.Length; i++)
            {
                totalThisQty += entitydts[i].DCheckQty;
                totalThisAmount += entitydts[i].DCheckAmount;
            }
            for (int i = 0; i < entityInvDts.Length; i++)
            {
                totalThisInvQty += entityInvDts[i].DInvoiceQty;
                totalThisInvAmount += entityInvDts[i].DInvoiceAmount;
            }

            for (int i = 0; i < entityPayDts.Length; i++)
            {
                totalThisPayAmount += entityPayDts[i].ExAmount;
            }

            entity.ThisExAmount = entity.PreExAmount + totalThisAmount - totalThisPayAmount;
            entity.ThisInvoiceQty = entity.PreInvoiceQty + totalThisQty - totalThisInvQty;
            entity.ThisInvoiceAmount = entity.PreInvoiceAmount + totalThisAmount - totalThisInvAmount;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
            CheckOperationDts[] entitydts = EntityDtsGet();
            //CheckOperationInvDts[] entityInvDts = EntityInvDtsGet();
            //CheckOperationPayDts[] entityPayDts = EntityPayDtsGet();
            decimal TotalCheckAmount = 0;
            decimal TotalQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalCheckAmount += SysConvert.ToDecimal(entitydts[i].DCheckAmount);
                TotalQty += SysConvert.ToDecimal(entitydts[i].DCheckQty);
            }
            entity.TotalCheckAmount = TotalCheckAmount;
            entity.TotalQty = TotalQty;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();

            //ProcThisQty(entity, entitydts, entityInvDts, entityPayDts);//处理本期余数
            //列表中的对账数据不可重复加载 sc 20140123


            rule.RAdd(entity, entitydts);
            return entity.ID;
        }


        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
            CheckOperationDts[] entitydts = EntityDtsGet();
            //CheckOperationInvDts[] entityInvDts = EntityInvDtsGet();
            //CheckOperationPayDts[] entityPayDts = EntityPayDtsGet();
            decimal TotalCheckAmount = 0;
            decimal TotalQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalCheckAmount += SysConvert.ToDecimal(entitydts[i].DCheckAmount);
                TotalQty += SysConvert.ToDecimal(entitydts[i].DCheckQty);
            }
            entity.TotalCheckAmount = TotalCheckAmount;
            entity.TotalQty = TotalQty;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CheckOperation entity = new CheckOperation();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();


            txtFormNo.Text = entity.FormNo.ToString();
            txtOrderCode.Text = entity.OrderCode.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpDZType.EditValue = entity.DZTypeID;

            drpVendorID.EditValue = entity.VendorID;


            txtRemark.Text = entity.Remark.ToString();
            txtDVendorCon.Text = entity.DVendorCon.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalCheckAmount.Text = entity.TotalCheckAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();

            drpCheckMethodType.EditValue = entity.CheckMethodTypeID;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;

            txtThisExAmount.Text = entity.ThisExAmount.ToString();
            txtThisInvoiceAmount.Text = entity.ThisInvoiceAmount.ToString();
            txtThisInvoiceQty.Text = entity.ThisInvoiceQty.ToString();

            txtPreExAmount.Text = entity.PreExAmount.ToString();
            txtPreInvoiceAmount.Text = entity.PreInvoiceAmount.ToString();
            txtPreInvoiceQty.Text = entity.PreInvoiceQty.ToString();
            txtFormDate.DateTime = entity.FormDate;
            IsMerge = entity.MergeFlage;
            txtInvoiceApplyNo.Text = entity.InvoiceApplyNo;

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
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
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
            base.IniInsertSet();

            txtMakeDate.DateTime = DateTime.Now;
            drpDZType.EditValue = FormListAID;
            txtFormNo_DoubleClick(null, null);
            drpSaleOPID.EditValue = FParamConfig.LoginID;
            drpCheckMethodType.EditValue = (int)EnumCheckMethodType.按时间流水账;

            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtFormDate.DateTime = DateTime.Now.Date;
            btnIsMerge_Click(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            Common.BindDZType(drpDZType, true);
            this.HTDataTableName = "Finance_CheckOperation";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "DLOADID", "ItemCode" };//数据明细校验必须录入字段
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            Common.BindOP(drpSaleOPID, true);
            Common.BindCheckMethodType(drpCheckMethodType, true);
            DevMethod.BindVendorByDZTypeID(drpVendorID, this.FormListAID, true);//2015.4.8 CX UPDATE
            txtMakeDate.DateTime = DateTime.Now.Date;
            Common.BindCLS(drpUnit, "Data_Item", "ItemUnitFab", true);


        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOperation EntityGet()
        {
            CheckOperation entity = new CheckOperation();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.OrderCode = txtOrderCode.Text.Trim();
      
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate =txtFormDate.DateTime;
            entity.Remark = txtRemark.Text.Trim();
            entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.TotalCheckAmount = SysConvert.ToDecimal(txtTotalCheckAmount.Text.Trim());
            entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
            entity.CheckMethodTypeID = SysConvert.ToInt32(drpCheckMethodType.EditValue);
            entity.PreExAmount = SysConvert.ToDecimal(txtPreExAmount.Text.Trim());
            entity.PreInvoiceAmount = SysConvert.ToDecimal(txtPreInvoiceAmount.Text.Trim());
            entity.PreInvoiceQty = SysConvert.ToDecimal(txtPreInvoiceQty.Text.Trim());
            entity.ThisExAmount = SysConvert.ToDecimal(txtThisExAmount.Text.Trim());
            entity.ThisInvoiceAmount = SysConvert.ToDecimal(txtThisInvoiceAmount.Text.Trim());
            entity.ThisInvoiceQty = SysConvert.ToDecimal(txtThisInvoiceQty.Text.Trim());
            entity.MergeFlage = IsMerge;
            entity.InvoiceApplyNo = txtInvoiceApplyNo.Text.Trim();

            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = txtMakeDate.DateTime.Date;
             }

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOperationDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CheckOperationDts[] entitydts = new CheckOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CheckOperationDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].DLOADID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADID"));
                    entitydts[index].DLOADSEQ = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADSEQ"));
                    entitydts[index].DLOADNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLOADNO"));
                    entitydts[index].DLOADDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADDtsID"));
                    entitydts[index].DCheckQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckQty"));  

                    entitydts[index].TZAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TZAmount"));

                    entitydts[index].DCheckSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckSinglePrice"));
                    entitydts[index].DCheckDYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckDYPrice"));
                    if (entitydts[index].DCheckSinglePrice != 0)//对账单价不为0；对账金额=对账数量*对账单价+对账打样费+调整金额
                    {
                        entitydts[index].DCheckAmount = entitydts[index].DCheckQty * entitydts[index].DCheckSinglePrice + entitydts[index].DCheckDYPrice + entitydts[index].TZAmount;
                    }
                    else//对账单价为0；//对账单价不为0,对账金额=对账数量*对账单价+对账打样费+调整金额
                    {
                        entitydts[index].DCheckAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckAmount")) + entitydts[index].DCheckDYPrice + entitydts[index].TZAmount;
                    }
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark"));

                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));

                    entitydts[index].QSID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "QSID"));//缺损ID
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));

                    //entitydts[index]. = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "QSID"));//缺损ID

                    entitydts[index].FAmount1 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount1"));//小缸费
                    entitydts[index].FAmount2 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount2"));//打样费
                    entitydts[index].FAmount3 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount3"));//制版费
                    entitydts[index].FAmount4 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount4"));//上机费
                    index++;
                }
            }
            return entitydts;
        }

      
        #endregion



        #region 其它事件
        /// <summary>
        /// 双击加载单号
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
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.对账单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    


        #endregion

        #region 加载
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
                    if (Common.CheckSearchLookUpEditBlank(drpVendorID))
                    {
                        this.ShowMessage("请选择" + lblVendor.Text.ToString());
                        return;
                    }
                    string str = string.Empty;
                    frmLoadIOFormTotal frm = new frmLoadIOFormTotal();
                    frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
                    frm.DZFlag = 1;//对账加载仓库单据
                    ///未对账或者对账数量不等于仓库数量
                    frm.HTLoadConditionStr = " AND (ISNULL(DZFlag,0)=0 OR ABS(ISNULL(DZQty,0))<>ISNULL(TotalQty,0) )" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));//只查询未对账


                    frm.ShowDialog();
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
                        setItemTotalNews(str);
                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void setItemTotalNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            int index = checkRowSet();
            int length = 0;
            int f = gridView1.RowCount;
            for (int i = index; i < orderid.Length + index; i++)
            {
                if (i >= f)
                {
                    WCommon.DataTableAddRow((DataTable)gridView1.GridControl.DataSource, i - 1);
                }
                string sql = "SELECT ID,FormNo,FormDate,ItemCode,DtsOrderFormNo,WHNM,FormNM,ColorNum,ColorName,GoodsCode,MWidth,MWeight,SinglePrice,SUM(Amount) Amount,ItemName,ItemStd,ItemModel,SUM(Qty) Qty,SUM(PieceQty) PieceQty,Unit,DZAmount,DZQty,FormDZFlag  FROM UV1_WH_IOFormDts2 WHERE 1=1 AND ID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[length])) + "GROUP BY FormNo,FormDate,ItemCode,DtsOrderFormNo,WHNM,FormNM,ColorNum,ColorName,MWidth,MWeight,SinglePrice,ID,ItemName,ItemStd,ItemModel,GoodsCode,Unit,DZAmount,DZQty,FormDZFlag";
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count >= 1)
                {
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToString(dt.Rows[0]["ID"]));
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));//单据类型
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));



                    if (FormListAID == 3)//销售对账
                    {
                        sql = "Select * from UV1_Sale_SaleOrderDts where 1=1";
                        sql += " AND FormNo=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                        sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                        sql += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                        sql += " AND ColorName=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ColorName"]));
                        DataTable dtS = SysUtils.Fill(sql);
                        if (dtS.Rows.Count != 0)
                        {
                            gridView1.SetRowCellValue(i, "FAmount1", SysConvert.ToDecimal(dtS.Rows[0]["FAmount1"]));//
                            gridView1.SetRowCellValue(i, "FAmount2", SysConvert.ToDecimal(dtS.Rows[0]["FAmount2"]));//
                            gridView1.SetRowCellValue(i, "FAmount3", SysConvert.ToDecimal(dtS.Rows[0]["FAmount3"]));//
                            gridView1.SetRowCellValue(i, "FAmount4", SysConvert.ToDecimal(dtS.Rows[0]["FAmount4"]));//
                        }
                    }


                    decimal DZQty = SysConvert.ToDecimal(dt.Rows[0]["DZQty"]); //对账数量
                    decimal DZAmount = SysConvert.ToDecimal(dt.Rows[0]["DZAmount"]);//对账金额
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));//出入库数量
                        if (SysConvert.ToInt32(dt.Rows[0]["FormDZFlag"]) == (int)EnumDZFlag.对帐负)
                        {
                            gridView1.SetRowCellValue(i, "DCheckQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                            gridView1.SetRowCellValue(i, "Qty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "DCheckQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                        }
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SinglePrice"]) != string.Empty)//出入库单价
                    {
                        gridView1.SetRowCellValue(i, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                        gridView1.SetRowCellValue(i, "DCheckSinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["Amount"]) != string.Empty) //出入库金额
                    {
                        gridView1.SetRowCellValue(i, "Amount", SysConvert.ToString(dt.Rows[0]["Amount"]));
                        if (SysConvert.ToInt32(dt.Rows[0]["FormDZFlag"]) == (int)EnumDZFlag.对帐负)
                        {
                            gridView1.SetRowCellValue(i, "DCheckAmount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]) - DZAmount);
                            gridView1.SetRowCellValue(i, "Amount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "DCheckAmount", SysConvert.ToDecimal(dt.Rows[0]["Amount"]) - DZAmount);
                        }
                    }

                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)//匹数
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                    length++;

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

        /// <summary>
        /// 根据对账类型取得客户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpDZType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpDZType.EditValue) != 0)
                {
                    int DZType = SysConvert.ToInt32(drpDZType.EditValue);
                    DevMethod.BindVendorByDZTypeID(drpVendorID, this.FormListAID, true);
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

                CheckOperationRule rule = new CheckOperationRule();
                rule.RSubmit(HTDataID, 1);

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

                DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {

                    if (SysConvert.ToInt32(dr["InvoiceFlag"]) == 1)
                    {
                        this.ShowMessage("第：" + i + "行数据已开票，不可撤销提交");
                        return;
                    }
                    i++;
                }

              
                CheckOperationRule rule = new CheckOperationRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void frmCheckOperation2Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    CheckOperation entity = new CheckOperation();
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

        private void btnIsMerge_Click(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.新增)
            {
                IsMerge = 1;
            }
        }

        private void gridControlDetail_Click(object sender, EventArgs e)
        {

        }

    }
}