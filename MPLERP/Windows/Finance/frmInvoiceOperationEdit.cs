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
    public partial class frmInvoiceOperationEdit : frmAPBaseUIFormEdit
    {
        public frmInvoiceOperationEdit()
        {
            InitializeComponent();
        }
        bool ismx = false;
        int isMerge = 0;
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
            //if (SysConvert.ToInt32(drpKPType.EditValue) != (int)EnumKPType.期初开票)
            //{
            //    if (txtInvoiceNO.Text.Trim() == "")
            //    {
            //        this.ShowMessage("请输入发票号");
            //        txtInvoiceNO.Focus();
            //        return false;
            //    }
            //}

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

            if (SysConvert.ToInt32(drpKPType.EditValue) == 0)
            {
                this.ShowMessage("请选择开票类型！");
                drpKPType.Focus();
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
        /// 绑定数据明细
        /// </summary>
        public  void BindGridDts2()
        {
            InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));

            gridView2.GridControl.DataSource = dtDts;
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// 处理保存数据汇总数
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entitydts"></param>
        void ProcEntitySaveData(InvoiceOperation entity, InvoiceOperationDts[] entitydts)
        {
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            decimal PayAmount = 0;
            decimal totaltaxamount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].DInvoiceQty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].DInvoiceAmount);
                PayAmount += SysConvert.ToDecimal(entitydts[i].PayAmount);
                totaltaxamount += SysConvert.ToDecimal(entitydts[i].DInvoiceTaxAmount);
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.PayAmount = PayAmount;
            entity.TotalTaxAmount = totaltaxamount;

            entity.PreHXQty = entity.TotalQty;
            entity.PreHXAmount = entity.TotalAmount;
            entity.PreHXFlag = (int)YesOrNo.Yes;
        }

        /// <summary>
        /// 处理保存数据汇总数
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entitydts"></param>
        void ProcEntitySaveData2(InvoiceOperation entity, InvoiceYOperationDts[] entitydts)
        {
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            decimal PayAmount = 0;
            decimal totaltaxamount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
                
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.PayAmount = PayAmount;
            entity.TotalTaxAmount = totaltaxamount;

            entity.PreHXQty = entity.TotalQty;
            entity.PreHXAmount = entity.TotalAmount;
            entity.PreHXFlag = (int)YesOrNo.Yes;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceOperationDts[] entitydts = EntityDtsGet();
            InvoiceYOperationDts[] entityDts2 = EntityDtsGet2();
            if (!ismx)
            {
                if (entity.KPType == (int)EnumKPType.预开票)
                {
                    ProcEntitySaveData2(entity, entityDts2);
                }
                else
                {
                    ProcEntitySaveData(entity, entitydts);
                }
                if (SysConvert.ToInt32(drpKPType.EditValue) == (int)EnumKPType.期初开票)
                {
                    entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                    entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
                    entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
                }
            }
            else
            {
                entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            }
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RAdd(entity, entitydts, entityDts2);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceOperationDts[] entitydts = EntityDtsGet();
            InvoiceYOperationDts[] entityDts2 = EntityDtsGet2();
            if (!ismx)
            {
                if (entity.KPType == (int)EnumKPType.预开票)
                {
                    ProcEntitySaveData2(entity, entityDts2);
                }
                else
                {
                    ProcEntitySaveData(entity, entitydts);
                }
                if (SysConvert.ToInt32(drpKPType.EditValue) == (int)EnumKPType.期初开票)
                {
                    entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                    entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
                }
            }
            else
            {
                entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            }
            //if (entity.KPType == (int)EnumKPType.预开票)
            //{
            //    ProcEntitySaveData2(entity, entityDts2);
            //}
            //else
            //{
            //    ProcEntitySaveData(entity, entitydts);
            //}
            //if (SysConvert.ToInt32(drpKPType.EditValue) == (int)EnumKPType.期初开票)
            //{
            //    entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            //    entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            //}
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entityDts2);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            ismx = entity.MXFlag == 0 ? false : true;
  			txtFormNo.Text = entity.FormNo.ToString();
            simpleButton1.Text = ismx ? "指定明细" : "不指定明细";
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
            drpKPType.EditValue = entity.KPType;

            txtMakeDate.DateTime = entity.MakeDate;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            BindGridDts2();
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
             txtMakeDate.DateTime = DateTime.Now.Date;
             drpDZType.EditValue = FormListAID;//对账类型
             drpKPType.EditValue = 1;
             simpleButton1.Text = ismx ? "指定明细" : "不指定明细";
             //ismx = false;

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            //ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            //ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI

            this.HTDataTableName = "Finance_InvoiceOperation";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            this.HTCheckDataField = new string[] { "DLOADID", "ItemCode" };//数据明细校验必须录入字段

            Common.BindDZType(drpDZType, true);
            Common.BindOP(drpSaleOPID, true);
            Common.BindKPType(drpKPType, true);

            Common.BindCLS(drpUnit, "Data_Item", "ItemUnitAtt", true);
            Common.BindCLS(drpUnit2, "Data_Item", "ItemUnitAtt", true);
            if (!ismx)
            {
                this.ToolBarItemAdd(28, "btnLoadDCheck", "加载对账", false, btnLoadDCheck_Click);
            }

            //label7.Visible = ismx;
            simpleButton1.Text = ismx ? "指定明细" : "不指定明细";

            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载合同", false, btnLoad2_Click);
            //new VendorProc(drpVendorID);
            drpDZType.Enabled = false;


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
                    frm.InvoiceFlag = 1;
                    string tempConditionStr = " AND ISNULL(DZFlag,0)=1" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                    tempConditionStr += " AND  ABS(ISNULL(InvoiceQty,0))<>ISNULL(Qty,0) ";
                    tempConditionStr += " AND ABS(ISNULL(DZQty,0))>ABS(ISNULL(InvoiceQty,0))";
                    frm.HTLoadConditionStr = tempConditionStr;//只查询已对账 及还有未开票部分数据

                 
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
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(i, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(i, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    gridView1.SetRowCellValue(i, "DInvoiceDYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
                    decimal InvoiceQty = SysConvert.ToDecimal(dt.Rows[0]["InvoiceQty"]);
                    decimal InvoiceAmount = SysConvert.ToDecimal(dt.Rows[0]["InvoiceAmount"]);
                    if (SysConvert.ToString(dt.Rows[0]["DZQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
                        decimal tempQty = SysConvert.ToDecimal(dt.Rows[0]["DZQty"]) - InvoiceQty;//处理未开票数量
                        gridView1.SetRowCellValue(i, "DInvoiceQty", tempQty);//SysConvert.ToString(dt.Rows[0]["DZQty"])
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                        gridView1.SetRowCellValue(i, "DInvoiceSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
                        decimal tempAmount = SysConvert.ToDecimal(dt.Rows[0]["DZAmount"]) - InvoiceAmount;//处理未开票金额
                        gridView1.SetRowCellValue(i, "DInvoiceAmount", tempAmount);//SysConvert.ToString(dt.Rows[0]["DZAmount"])
                    }
                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }

                    gridView1.SetRowCellValue(i, "InvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["InvoiceQty"]));//发票数量
                    gridView1.SetRowCellValue(i, "InvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["InvoiceAmount"]));//发票金额


                }
            }
        }

     
        public void btnLaodQS_Click(object sender, EventArgs e)
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
                    if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    {
                        this.ShowMessage("请选择开票类型");
                        return;
                    }

                    frmLoadQS frm = new frmLoadQS();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
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
                        setItemQS(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemQS(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            int Row = GetRow();
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  WH_QS WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i+Row, "DLOADID","0");
                    gridView1.SetRowCellValue(i + Row, "DLOADSEQ", "0");
                    gridView1.SetRowCellValue(i + Row, "DLOADNO", "");
                    gridView1.SetRowCellValue(i + Row, "DLOADDtsID", "0");


                    gridView1.SetRowCellValue(i + Row, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));

                    gridView1.SetRowCellValue(i + Row, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i + Row, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));



                    gridView1.SetRowCellValue(i + Row, "DInvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));//发票数量
                    gridView1.SetRowCellValue(i + Row, "DInvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["Amount"]));//发票金额
                    gridView1.SetRowCellValue(i + Row, "DInvoiceSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SinglePrice"]));//发票数量
                    gridView1.SetRowCellValue(i + Row, "Remark", SysConvert.ToString(dt.Rows[0]["Remark"]));//备注
                  


                }
            }
        }

        private int GetRow()
        {
            int row = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == "")
                {
                    row = i;
                    return row;
                }
            }
            return row;
        }
        #endregion

        #region 加载对账单
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnLoadDCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (ismx)
                    {
                        return;
                    }
                    
                    if (Common.CheckSearchLookUpEditBlank(drpVendorID))
                    {
                        this.ShowMessage("请选择" + lblVendor.Text.ToString());
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    {
                        this.ShowMessage("请选择开票类型");
                        return;
                    }

                    frmLoadCheckForm frm = new frmLoadCheckForm();
                    frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);

                    string tempConditionStr = " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));

                    frm.HTLoadConditionStr = tempConditionStr;//只查询已对账 及还有未开票部分数据
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
                        SetDCheckItem(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetDCheckItem(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV2_Finance_CheckOperationDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToInt32(dt.Rows[0]["DLOADID"]));
                    gridView1.SetRowCellValue(i, "DLOADSEQ", SysConvert.ToInt32(dt.Rows[0]["DLOADSEQ"]));
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["DLOADNO"]));
                    gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToInt32(dt.Rows[0]["DLOADDtsID"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                  //  gridView1.SetRowCellValue(i, "DInvoiceDYPrice", SysConvert.ToDecimal(dt.Rows[0]["DCheckDYPrice"]));
                    gridView1.SetRowCellValue(i, "DZQty", SysConvert.ToDecimal(dt.Rows[0]["DCheckQty"]));
                    gridView1.SetRowCellValue(i, "DInvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["DCheckQty"]));
                    gridView1.SetRowCellValue(i, "DZSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["DCheckSinglePrice"]));
                    gridView1.SetRowCellValue(i, "DInvoiceSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["DCheckSinglePrice"]));
                    gridView1.SetRowCellValue(i, "DZAmount", SysConvert.ToDecimal(dt.Rows[0]["DCheckAmount"]));
                    gridView1.SetRowCellValue(i, "DInvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["DCheckAmount"]));
                    gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                    gridView1.SetRowCellValue(i, "DInvoiceDYPrice", SysConvert.ToDecimal(dt.Rows[0]["TZAmount"]));
                    gridView1.SetRowCellValue(i, "DLoadCheckDtsID", SysConvert.ToInt32(dt.Rows[0]["DtsID"]));

                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "MergeFlage", SysConvert.ToInt32(dt.Rows[0]["MergeFlage"]));
                    gridView1.SetRowCellValue(i, "InvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["InvoiceQty"]));//发票数量
                    gridView1.SetRowCellValue(i, "InvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["InvoiceAmount"]));//发票金额


                }
            }
        }


      
        #endregion

        #region 加载合同

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoad2_Click(object sender, EventArgs e)
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
                    if (SysConvert.ToInt32(drpKPType.EditValue) !=(int)EnumKPType.预开票)
                    {
                        this.ShowMessage("开票类型请选择预开票");
                        drpKPType.Focus();
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == (int)EnumDZType.销售)
                    {
                        frmLoadOrder frm = new frmLoadOrder();
                        frm.CheckFlag2 = 1;
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
                    gridView2.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView2.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView2.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView2.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView2.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView2.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    gridView2.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));



                }
            }
        }


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
                    gridView2.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView2.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView2.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView2.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView2.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView2.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    setRowID++;
                }
            }
        }
        #endregion

        #region 预开票加载

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadYInvoice_Click(object sender, EventArgs e)
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
                    if (SysConvert.ToInt32(drpKPType.EditValue) != (int)EnumKPType.正常开票)
                    {
                        this.ShowMessage("开票类型请选择正常开票");
                        drpKPType.Focus();
                        return;
                    }

                    frmLoadYInvoice frm = new frmLoadYInvoice();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);


                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.DtsID != null && frm.DtsID.Length != 0)
                    {
                        //SetGridView1();// 防止一个采购单出现两个合同的数据
                        for (int i = 0; i < frm.DtsID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.DtsID[i]);
                        }
                        setItemNews3(str);


                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews3(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            int Row = GetRow();
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Finance_InvoiceYOperationDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i + Row, "DLOADID", "0");
                    gridView1.SetRowCellValue(i + Row, "DLOADSEQ", "0");
                    gridView1.SetRowCellValue(i + Row, "DLOADDtsID", "0");
                    gridView1.SetRowCellValue(i + Row, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i + Row, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i + Row, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i + Row, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i + Row, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i + Row, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["DtsOrderNo"]));
                    gridView1.SetRowCellValue(i + Row, "DInvoiceQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i + Row, "DInvoiceSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SinglePrice"]));
                    gridView1.SetRowCellValue(i + Row, "DInvoiceAmount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]));
                    gridView1.SetRowCellValue(i + Row, "DLoadNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));


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
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = DateTime.Now.Date;
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
  			entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
            entity.KPType = SysConvert.ToInt32(drpKPType.EditValue);
            entity.MXFlag = ismx ? 1 : 0;
            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = txtMakeDate.DateTime;
            }

            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private InvoiceOperationDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            InvoiceOperationDts[] entitydts = new InvoiceOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new InvoiceOperationDts();
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
  			 		entitydts[index].DInvoiceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceQty")); 
  			 		entitydts[index].DInvoiceSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceSinglePrice"));
                    entitydts[index].DInvoiceDYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceDYPrice")); 
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    if (entitydts[index].DInvoiceSinglePrice != 0)
                    {
                        entitydts[index].DInvoiceAmount = entitydts[index].DInvoiceQty * entitydts[index].DInvoiceSinglePrice + entitydts[index].DInvoiceDYPrice;
                    }
                    else
                    {
                        entitydts[index].DInvoiceAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceAmount")) + entitydts[index].DInvoiceDYPrice; 
                    }
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].PayAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayAmount"));
                    entitydts[index].DLOADDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADDtsID"));
                    entitydts[index].DLoadCheckDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLoadCheckDtsID"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));

                    entitydts[index].DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts[index].DInvoiceAmount - entitydts[index].DInvoiceAmount / 1.17m, 5);
                    entitydts[index].MergeFlage = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MergeFlage"));
                    index++;
                }
            }
            return entitydts;
        }

        private InvoiceYOperationDts[] EntityDtsGet2()
        {

            int index = 0;
            for (int j = 0; j < gridView2.RowCount; j++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(j, "ItemCode")) != "")
                {
                    index++;
                }
            }
            InvoiceYOperationDts[] entitydts = new InvoiceYOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemCode")) != "")
                {
                    entitydts[index] = new InvoiceYOperationDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "ID"));
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].ItemCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorName"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemName"));
                    entitydts[index].DtsOrderNo = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsOrderNo"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView2.GetRowCellValue(i, "Unit"));

                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "SinglePrice"));
                    if (entitydts[index].SinglePrice != 0)
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                    }
                    else
                    {
                        entitydts[index].Amount = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Amount"));
                    }
                    entitydts[index].DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts[index].Amount - entitydts[index].Amount / 1.17m, 5);




                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    if (this.FormListAID == 3)//销售开票
                    {
                        txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.发票单号);
                    }
                    else
                    {
                        txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.发票单号2);
                    }
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
                    //Common.BindVendorByDZTypeID(drpVendorID, DZType, true);   
                    DevMethod.BindVendorByDZTypeID(drpVendorID, DZType, true);//2015.4.8 CX UPDATE
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
                //string sql = "Update Finance_CheckOperationDts set LoadFlag = 1 where  ";
                //SysUtils.Fill(sql);

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

        private void frmInvoiceOperationEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    InvoiceOperation entity = new InvoiceOperation();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
            {
                ismx = ismx ? false : true;
                //label7.Visible = ismx;
                simpleButton1.Text = ismx ? "指定明细" : "不指定明细";
                //btnLoadDCheck_Click(null, null);
            }
        }


    }
}