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
    public partial class frmYInvoiceOperationEdit : frmAPBaseUIFormEdit
    {
        public frmYInvoiceOperationEdit()
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
            InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
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
            decimal totalqty=0;
            decimal totalamount = 0;
            for (int i = 0; i < entityDts.Length; i++)
            {
                totalqty += entityDts[i].Qty;
                totalamount += entityDts[i].Amount;
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalamount;
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RAdd2(entity,entityDts);

            return entity.ID;
        }

        private InvoiceYOperationDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            InvoiceYOperationDts[] entitydts = new InvoiceYOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new InvoiceYOperationDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].DtsOrderNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderNo"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));

                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                
                  

                  

                    index++;
                }
            }
            return entitydts;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceYOperationDts[] entityDts = EntityDtsGet();
            decimal totalqty=0;
            decimal totalamount = 0;
            for (int i = 0; i < entityDts.Length; i++)
            {
                totalqty += entityDts[i].Qty;
                totalamount += entityDts[i].Amount;
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalamount;
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RUpdate2(entity,entityDts);
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
          
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段
           
            new VendorProc(drpVendorID);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
           
            drpDZType.Enabled = false;

        }


        #endregion

        //#region 加载
        ///// <summary>
        ///// 加载
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnLoad_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
        //        {
        //            if (Common.CheckLookUpEditBlank(drpVendorID))
        //            {
        //                this.ShowMessage("请选择"+lblVendor.Text.ToString());
        //                return;
        //            }
        //            if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
        //            {
        //                this.ShowMessage("请选择开票类型");
        //                return;
        //            }

        //            frmLoadIOForm frm = new frmLoadIOForm();
        //            frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
        //            frm.HTLoadConditionStr = " AND ISNULL(DZFlag,0)=1" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));//只查询未对账
        //            frm.ShowDialog();
        //            string str = string.Empty;
        //            if (frm.DtsID != null && frm.DtsID.Length != 0)
        //            {
        //                for (int i = 0; i < frm.DtsID.Length; i++)
        //                {
        //                    if (str != string.Empty)
        //                    {
        //                        str += ",";
        //                    }
        //                    str += SysConvert.ToString(frm.DtsID[i]);
        //                }
        //                setItemNews(str);
        //            }
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void setItemNews(string p_Str)
        //{
        //    string[] orderid = p_Str.Split(',');
        //    for (int i = 0; i < orderid.Length; i++)
        //    {
        //        string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
        //        DataTable dt = SysUtils.Fill(sql);
        //        if (dt.Rows.Count == 1)
        //        {
        //            gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToString(dt.Rows[0]["ID"]));
        //            gridView1.SetRowCellValue(i, "DLOADSEQ", SysConvert.ToString(dt.Rows[0]["Seq"]));
        //            gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
        //            gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));

        //            gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));
        //            gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
        //            gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
        //            gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
        //            gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
        //            gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
        //            gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
        //            gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
        //            if (SysConvert.ToString(dt.Rows[0]["DZQty"]) != string.Empty)
        //            {
        //                gridView1.SetRowCellValue(i, "DZQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
        //                gridView1.SetRowCellValue(i, "DInvoiceQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
        //            }
        //            if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
        //            {
        //                gridView1.SetRowCellValue(i, "DZSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
        //                gridView1.SetRowCellValue(i, "DInvoiceSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
        //            }
        //            if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
        //            {
        //                gridView1.SetRowCellValue(i, "DZAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
        //                gridView1.SetRowCellValue(i, "DInvoiceAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
        //            }
        //            if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)
        //            {
        //                gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
        //            }


        //        }
        //    }
        //}
        //#endregion

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
            entity.MakeDate = DateTime.Now.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = DateTime.Now.Date;
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
           
  			entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
            entity.PreInvFlag = 1;
            entity.KPType = 2;
  			 
            
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
                    if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    {
                        this.ShowMessage("请选择往来单位");
                        drpVendorID.Focus();
                        return ;
                    }
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
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                   
                 

                }
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
            
        }

      

        #endregion


      
    }
}