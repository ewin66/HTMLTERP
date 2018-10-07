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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmYInvoiceOperation2Edit : frmAPBaseUIFormEdit
    {
        public frmYInvoiceOperation2Edit()
        {
            InitializeComponent();
        }

        #region 全局变量
        int saveIOFormDtsID = 0;//单据明细ID
        #endregion
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入开票单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择供应商/客户");
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
            InvoiceOperationDtsRule rule = new InvoiceOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceYOperationDts[] entityDts = EntityDtsGet();
            decimal totalqty = 0;
            decimal totalamount = 0;
            for (int i = 0; i < entityDts.Length; i++)
            {
                totalqty += entityDts[i].Qty;
                totalamount += entityDts[i].Amount;
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalamount;
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RAdd2(entity, entityDts);

            return entity.ID;

            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceYOperationDts[] entityDts = EntityDtsGet();
            decimal totalqty = 0;
            decimal totalamount = 0;
            for (int i = 0; i < entityDts.Length; i++)
            {
                totalqty += entityDts[i].Qty;
                totalamount += entityDts[i].Amount;
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalamount;
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RUpdate2(entity, entityDts);
        }


        private InvoiceYOperationDts[] EntityDtsGet()
        {

            int index = 0;
            for (int j = 0; j < gridView3.RowCount; j++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(j, "ItemCode")) != "")
                {
                    index++;
                }
            }
            InvoiceYOperationDts[] entitydts = new InvoiceYOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemCode")) != "")
                {
                    entitydts[index] = new InvoiceYOperationDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].ItemCode = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView3.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemName"));
                    entitydts[index].DtsOrderNo = SysConvert.ToString(gridView3.GetRowCellValue(i, "DtsOrderNo"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Qty"));

                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;





                    index++;
                }
            }
            return entitydts;
        }
        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtOrderCode.Text = entity.OrderCode.ToString(); 
  			txtInvoiceNO.Text = entity.InvoiceNO.ToString();

            drpVendorID.EditValue = entity.VendorID;
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtDVendorCon.Text = entity.DVendorCon.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
  			txtTotalQty.Text = entity.TotalQty.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalTaxAmount.Text = entity.TotalTaxAmount.ToString();
            drpDZType.EditValue = entity.DZTypeID;
            txtMakeDate.DateTime = entity.MakeDate;
            txtMainHXQty.Text = entity.PreHXQty.ToString();
            txtMainHXAmount.Text = entity.PreHXAmount.ToString();
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            BindGridDts2();
        }

        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public  void BindGridDts2()
        {
            InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3));

            gridView3.GridControl.DataSource = dtDts;
            gridView3.GridControl.Show();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
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
             txtMakeDate.DateTime = DateTime.Now.Date;
             txtFormNo_DoubleClick(null, null);
             drpSaleOPID.EditValue = FParamConfig.LoginID;
             drpDZType.EditValue = FormListAID;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            Common.BindDZType(drpDZType,true);
            Common.BindOP(drpSaleOPID, true);
            this.HTDataTableName = "Finance_InvoiceOperation";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2,gridView3 };
            this.HTCheckDataField = new string[] { "DLOADDtsID", "DInvoiceQty" };//数据明细校验必须录入字段
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            txtHXQMakeDateS.DateTime = DateTime.Now.AddMonths(-6).Date;
            txtHXQMakeDateE.DateTime = DateTime.Now.Date;
            new VendorProc(drpVendorID);
            this.ToolBarItemAdd(28,"btnLoad2", "加载", false, btnLoad2_Click);
            this.gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);//绑定GridView2事件
            gridViewBindEventA2(gridView2);
            drpDZType.Enabled = false;

        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnLoad2_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    {
                        this.ShowMessage("请选择往来单位");
                        drpVendorID.Focus();
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == (int)EnumDZType.销售)
                    {
                        frmLoadOrder frm = new frmLoadOrder();

                        frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);


                        frm.ShowDialog();
                        string str = string.Empty;
                        if (frm.OrderID != null && frm.OrderID.Length != 0)
                        {
                            //SetGridView1();// 防止一个采购单出现两个合同的数据
                            for (int i = 0; i < frm.OrderID.Length; i++)
                            {
                                if (str != string.Empty)
                                {
                                    str += ",";
                                }
                                str += SysConvert.ToString(frm.OrderID[i]);
                            }
                            setItemNews2(str);

                        }
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == (int)EnumDZType.采购)
                    {
                        WHLoadItemBuyForm();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews2(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView3.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView3.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView3.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView3.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView3.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView3.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));



                }
            }
        }


        #region

        private void WHLoadItemBuyForm()
        {
            
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
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
                WHLoadItemBuyFormSetWH(str);

            }
        }

        /// <summary>
        /// 加载面料采购单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadItemBuyFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//只有一行明细数据
                {
                    gridView3.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView3.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView3.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView3.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView3.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView3.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    setRowID++;
                }
            }
        }
        #endregion
        /// <summary>
        /// GridView2行改变
        /// </summary>
        /// <param name="sender"></param>
        void gridViewRowChanged2(object sender)
        {
            ColumnView view = sender as ColumnView;

            saveIOFormDtsID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DtsID"]));

            txtPreHXFormNo.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["FormNo"]));
            txtPreHXQty.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DZQty"])) -
                SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["InvoiceQty"]))).ToString();
            txtPreHXSingPrice.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DZSinglePrice"]))).ToString();
            txtPreHXAmount.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DZAmount"])) -
                SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["InvoiceAmount"]))).ToString();
            txtPreHXRemark.Text = ""; 

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
                    if (Common.CheckLookUpEditBlank(drpVendorID))
                    {
                        this.ShowMessage("请选择"+lblVendor.Text.ToString());
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    {
                        this.ShowMessage("请选择开票类型");
                        return;
                    }

                    frmLoadIOForm frm = new frmLoadIOForm();
                    frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
                    frm.HTLoadConditionStr = " AND ISNULL(DZFlag,0)=1" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));//只查询未对账
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
                        setItemNews(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToString(dt.Rows[0]["ID"]));
                    gridView1.SetRowCellValue(i, "DLOADSEQ", SysConvert.ToString(dt.Rows[0]["Seq"]));
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToString(dt.Rows[0]["DZQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
                        gridView1.SetRowCellValue(i, "DInvoiceQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                        gridView1.SetRowCellValue(i, "DInvoiceSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
                        gridView1.SetRowCellValue(i, "DInvoiceAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }


                }
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private InvoiceOperation EntityGet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;
            entity.SelectByID();

  			entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.OrderCode = txtOrderCode.Text.Trim(); 
  			entity.InvoiceNO = txtInvoiceNO.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = txtMakeDate.DateTime;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = DateTime.Now.Date;
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
  			entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
            entity.CheckDate = DateTime.Now.Date;
            entity.PreInvFlag = 1;
            entity.KPType = 2;
            entity.KPType = (int)EnumKPType.预开票;
  			 
            
            return entity;
        }

        ///// <summary>
        ///// 获得实体
        ///// </summary>
        ///// <returns></returns>
        //private InvoiceOperationDts[] EntityDtsGet()
        //{

        //    int index = GetDataCompleteNum();
        //    InvoiceOperationDts[] entitydts = new InvoiceOperationDts[index];
        //    index = 0;
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (CheckDataCompleteDts(i))
        //        {
        //            entitydts[index] = new InvoiceOperationDts();
        //            entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID")); 
        //            if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
        //            {
        //                entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
        //                entitydts[index].SelectByID();
        //            }
        //            else//新增
        //            {
        //                entitydts[index].MainID = HTDataID;
        //                entitydts[index].Seq = i + 1;
        //            }
                    
        //            entitydts[index].DLOADID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADID")); 
        //            entitydts[index].DLOADSEQ = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADSEQ")); 
        //            entitydts[index].DLOADNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLOADNO")); 
        //            entitydts[index].DInvoiceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceQty")); 
        //            entitydts[index].DInvoiceSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceSinglePrice"));
        //            entitydts[index].DInvoiceAmount = entitydts[index].DInvoiceQty * entitydts[index].DInvoiceSinglePrice; 
        //            entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
        //            entitydts[index].PayAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayAmount"));
        //            entitydts[index].DLOADDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADDtsID"));


        //            entitydts[index].DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts[index].DInvoiceAmount - entitydts[index].DInvoiceAmount / 1.17m, 5);

        //            index++;
        //        }
        //    }
        //    return entitydts;
        //}

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.发票单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

    

        private void drpDZType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpDZType.EditValue) != 0)
                {
                    int DZType = SysConvert.ToInt32(drpDZType.EditValue);

                    Common.BindVendorByDZTypeID(drpVendorID, DZType, true);
                    //switch (DZType)
                    //{
                    //    case (int)EnumDZType.采购:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
                    //        lblVendor.Text = "供应商";
                    //        break;
                    //    case (int)EnumDZType.加工:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
                    //        lblVendor.Text = "加工厂";
                    //        break;
                    //    case (int)EnumDZType.销售:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                    //        lblVendor.Text = "客户";
                    //        break;

                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
      


        #region 其它事件

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

                InvoiceOperationRule rule = new InvoiceOperationRule();
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

                InvoiceOperationRule rule = new InvoiceOperationRule();
                InvoiceOperation entity = new InvoiceOperation();
                entity.ID = HTDataID;
                entity.SelectByID();
                if (entity.PreHXQty != 0)
                {
                    this.ShowMessage("已有核销数据，不允许提交");
                    return;
                }
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

        #region 仓库核销查询操作
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHXQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void BindGrid()
        {
            if (HTFormStatus != FormStatus.新增 && HTFormStatus != FormStatus.修改)
            {
                IOFormRule rule = new IOFormRule();
                gridView2.GridControl.DataSource = rule.RShowDts(GetCondition(), ProcessGrid.GetQueryField(gridView2));
                gridView2.GridControl.Show();
            }
        }

        private string GetCondition()
        {
            string temp = "";
            if (txtItemCode.Text.Trim() != "")
            {
                temp += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                temp += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
            if (txtColorNum.Text.Trim() != "")
            {
                temp += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }
            if (txtColorName.Text.Trim() != "")
            {
                temp += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if(chkHXQMakeDate.Checked)
            {
                temp+=" AND FormDate BETWEEN "+SysString.ToDBString(txtHXQMakeDateS.DateTime)+" AND "+SysString.ToDBString(txtHXQMakeDateE.DateTime);
            }
            if(chkHXOnlyNOFinish.Checked)
            {

            }
            //if(!Common.CheckLookUpEditBlank(drpVendorID))
            //{
            //    temp+=" AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //}

            if (true)//使用默认查询条件 m_THConditionStr == string.Empty
            {
                temp += " AND SubType IN(SELECT ID FROM Enum_FormList WHERE DZFlag<>0 AND DZType=" + SysString.ToDBString(SysConvert.ToInt32(drpDZType.EditValue)) + ")";
            }
            else//使用退货查询条件
            {
                //tempStr += " AND SubType IN(" + m_THConditionStr + ")";
            }
            temp += " AND ISNULL(DZFlag,0)=1" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            temp += " AND ISNULL(DtsInvoiceDelFlag,0)=0";
            
            return temp;
        }

        #endregion

        #region 核销 操作

        /// <summary>
        /// 获得核销明细实体
        /// </summary>
        /// <returns></returns>
        private InvoiceOperationDts EntityDtsGetOne()
        {

            InvoiceOperationDts entitydts = new InvoiceOperationDts();

            entitydts.MainID = HTDataID;
            entitydts.DLOADID = SysConvert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID"));
            entitydts.DLOADDtsID = SysConvert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DtsID"));
            entitydts.DLOADSEQ = SysConvert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Seq"));
            entitydts.DLOADNO = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "FormNo"));

            entitydts.DInvoiceQty = SysConvert.ToDecimal(txtPreHXQty.Text.Trim());
            entitydts.DInvoiceSinglePrice = SysConvert.ToDecimal(txtPreHXSingPrice.Text.Trim());
            entitydts.DInvoiceAmount = entitydts.DInvoiceQty * entitydts.DInvoiceSinglePrice;
            entitydts.Remark = txtPreHXRemark.Text.Trim();

            entitydts.DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts.DInvoiceAmount - entitydts.DInvoiceAmount / 1.17m, 5);

            entitydts.ItemCode = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ItemCode"));
            entitydts.ColorNum = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ColorNum"));
            entitydts.ColorName = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ColorName"));
           


            return entitydts;
        }
        /// <summary>
        /// 核销操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreHXExcute_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请定位主记录");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("单据未提交，不能操作");
                    return;
                }

                if (saveIOFormDtsID == 0)
                {
                    this.ShowMessage("请选择对账记录");
                    return;
                }
                if (SysConvert.ToDecimal(txtPreHXQty.Text.Trim()) == 0)
                {
                    this.ShowMessage("请输入核销数量");
                    txtPreHXQty.Focus();
                    return;
                }

                InvoiceOperationRule rule = new InvoiceOperationRule();
                InvoiceOperation entity = EntityGet();
                InvoiceOperationDts entitydts = EntityDtsGetOne();

                rule.RHX(entity, entitydts);

                FCommon.AddDBLog(this.Text, "核销", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

                this.BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// 撤销核销操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreHXCancelExcute_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请定位主记录");
                    return;
                }
                int dtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                if (dtsID == 0)
                {
                    this.ShowMessage("请选择核销记录");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("确认撤销核销本条记录？"))
                {
                    return;
                }

                InvoiceOperationRule rule = new InvoiceOperationRule();
                InvoiceOperation entity = EntityGet();

                rule.RHXCancel(entity, dtsID);


                FCommon.AddDBLog(this.Text, "撤销核销", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                this.BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 核销数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreHXQty_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtPreHXAmount.Text = (SysConvert.ToDecimal(txtPreHXQty.Text.Trim()) * SysConvert.ToDecimal(txtPreHXSingPrice.Text.Trim())).ToString();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


    }
}