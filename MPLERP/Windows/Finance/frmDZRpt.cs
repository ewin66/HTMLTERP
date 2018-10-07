using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmDZRpt : frmAPBaseUIRpt
    {
        public frmDZRpt()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (chkINDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            //查询出入库信息
            string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE 1=1";
            sql += " AND SubmitFlag=1";
            if (chkINDate.Checked)
            {
                sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP="+SysString.ToDBString(drpSaleOPID.EditValue.ToString())+")";
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            sql += " AND SubType NOT IN(SELECT ID FROM Enum_FormList WHERE DZFlag="+SysString.ToDBString((int)EnumDZFlag.不对帐)+")";
            if (FormListAID == (int)EnumVendorType.客户)
            {
                sql += " AND SubType IN(SELECT ID FROM Enum_FormList WHERE DZType=" + SysString.ToDBString((int)EnumDZType.销售) + ")";
            }
            if (FormListAID == (int)EnumVendorType.工厂)
            {
                sql += " AND SubType IN(SELECT ID FROM Enum_FormList WHERE DZType=" + SysString.ToDBString((int)EnumDZType.采购) + ")";
            }
            sql += " ORDER BY FormDate";

           
            DataTable dt = SysUtils.Fill(sql);
            

            dt.Columns.Add("KPQty", typeof(float));
            dt.Columns.Add("KPAmount", typeof(float));
            dt.Columns.Add("LKAmount", typeof(float));
            SetDt(dt);

            //查询开票信息
            sql = "SELECT MakeDate,VendorID,ItemCode,GoodsCode,SUM(DInvoiceQty) DInvoiceQty,SUM(DInvoiceAmount) DInvoiceAmount FROM UV1_Finance_InvoiceOperationDts WHERE 1=1";
            if (FormListAID == (int)EnumVendorType.客户)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.销售);
            }
            if (FormListAID == (int)EnumVendorType.工厂)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.采购);
            }
            sql += " AND SubmitFlag=1";
            sql += " AND KPType="+(int)EnumKPType.正常开票;
            if (chkINDate.Checked)
            {
                sql += " AND MakeDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) + ")";
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            sql += " GROUP BY MakeDate,VendorID,ItemCode,GoodsCode";
            DataTable dt2 = SysUtils.Fill(sql);

            //预开票
            sql = "SELECT * FROM UV1_Finance_InvoiceYOperationDts WHERE 1=1";
            if (FormListAID == (int)EnumVendorType.客户)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.销售);
            }
            if (FormListAID == (int)EnumVendorType.工厂)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.采购);
            }
            sql += " AND SubmitFlag=1";
            sql += " AND KPType=" + (int)EnumKPType.预开票;
            if (chkINDate.Checked)
            {
                sql += " AND MakeDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) + ")";
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            DataTable dt5 = SysUtils.Fill(sql);

            //查询收付款信息
            sql = "SELECT * FROM Finance_RecPay WHERE 1=1";
            if (FormListAID == (int)EnumVendorType.客户)
            {
                sql += " AND RecPayTypeID=" + SysString.ToDBString((int)EnumRecPayType.收款);
            }
            if (FormListAID == (int)EnumVendorType.工厂)
            {
                sql += " AND RecPayTypeID=" + SysString.ToDBString((int)EnumRecPayType.付款);
            }
            sql += " AND SubmitFlag=1";
            sql += " AND ISNULL(HTNO,'')='' ";
            if (chkINDate.Checked)
            {
                sql += " AND ExDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) + ")";
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND 1=0";
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND 1=0";
            }
            DataTable dt3 = SysUtils.Fill(sql);

            //查询收付款信息
            sql = "SELECT * FROM UV1_Finance_RecPayHTDts WHERE 1=1";
            if (FormListAID == (int)EnumVendorType.客户)
            {
                sql += " AND RecPayTypeID=" + SysString.ToDBString((int)EnumRecPayType.收款);
            }
            if (FormListAID == (int)EnumVendorType.工厂)
            {
                sql += " AND RecPayTypeID=" + SysString.ToDBString((int)EnumRecPayType.付款);
            }
            sql += " AND SubmitFlag=1";
            sql += " AND ISNULL(HTNO,'')<>'' ";
            if (chkINDate.Checked)
            {
                sql += " AND ExDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) + ")";
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND HTItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            DataTable dt4 = SysUtils.Fill(sql);



            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["KPQty"] = SysConvert.ToDecimal(dt2.Rows[i]["DInvoiceQty"]);
                dr["KPAmount"] = SysConvert.ToDecimal(dt2.Rows[i]["DInvoiceAmount"]);
                dr["FormDate"] = SysConvert.ToDateTime(dt2.Rows[i]["MakeDate"]);
                dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(dt2.Rows[i]["VendorID"]));
                dr["ItemCode"] = SysConvert.ToString(dt2.Rows[i]["ItemCode"]);
                dr["GoodsCode"] = SysConvert.ToString(dt2.Rows[i]["GoodsCode"]);
                //dr["DtsOrderFormNo"] = SysConvert.ToString(dt3.Rows[j]["HTNO"]);
                dt.Rows.Add(dr);
            }

            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["KPQty"] = SysConvert.ToDecimal(dt5.Rows[i]["Qty"]);
                dr["KPAmount"] = SysConvert.ToDecimal(dt5.Rows[i]["Amount"]);
                dr["FormDate"] = SysConvert.ToDateTime(dt5.Rows[i]["MakeDate"]);
                dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(dt5.Rows[i]["VendorID"]));
                dr["ItemCode"] = SysConvert.ToString(dt5.Rows[i]["ItemCode"]);
                dr["GoodsCode"] = SysConvert.ToString(dt5.Rows[i]["GoodsCode"]);
                dr["DtsOrderFormNo"] = SysConvert.ToString(dt5.Rows[i]["DtsOrderNo"]);
                dt.Rows.Add(dr);
            }

            for (int j = 0; j < dt3.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                dr["LKAmount"] = SysConvert.ToDecimal(dt3.Rows[j]["ExAmount"]);
                dr["FormDate"] = SysConvert.ToDateTime(dt3.Rows[j]["ExDate"]);
                dr["VendorAttn"] =Common.GetVendorNameByVendorID(SysConvert.ToString(dt3.Rows[j]["VendorID"]));
                dr["DtsOrderFormNo"] = SysConvert.ToString(dt3.Rows[j]["HTNO"]);
                dt.Rows.Add(dr);
                
            }

            for (int j = 0; j < dt4.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                dr["LKAmount"] = SysConvert.ToDecimal(dt4.Rows[j]["HTAMOUNT"]);
                dr["FormDate"] = SysConvert.ToDateTime(dt4.Rows[j]["ExDate"]);
                dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(dt4.Rows[j]["VendorID"]));
                dr["DtsOrderFormNo"] = SysConvert.ToString(dt4.Rows[j]["HTNO"]);
                dr["ItemCode"] = SysConvert.ToString(dt4.Rows[j]["HTItemCode"]);
                dr["GoodsCode"] = SysConvert.ToString(dt4.Rows[j]["GoodsCode"]);
                dt.Rows.Add(dr);

            }

            if (chkZK.Checked)
            {
                //查询开票信息
                sql = "SELECT MakeDate,VendorID,ItemCode,GoodsCode,DInvoiceSinglePrice,SUM(DInvoiceQty) DInvoiceQty,SUM(DInvoiceAmount) DInvoiceAmount FROM UV1_Finance_InvoiceOperationDts WHERE 1=1";
                if (FormListAID == (int)EnumVendorType.客户)
                {
                    sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.销售);
                }
                if (FormListAID == (int)EnumVendorType.工厂)
                {
                    sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.采购);
                }
                sql += " AND DLOADNO='折扣缺损'";
                sql += " AND SubmitFlag=1";
                sql += " AND KPType=" + (int)EnumKPType.正常开票;
                if (chkINDate.Checked)
                {
                    sql += " AND MakeDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
                }
                if (SysConvert.ToString(drpVendorID.EditValue) != "")
                {
                    sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
                }
                if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
                {
                    sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) + ")";
                }
                if (txtGoodsCode.Text.Trim() != "")
                {
                    sql += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
                }
                if (txtItemCode.Text.Trim() != "")
                {
                    sql += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
                }
                sql += " GROUP BY MakeDate,VendorID,ItemCode,GoodsCode,DInvoiceSinglePrice";
                DataTable dtZK = SysUtils.Fill(sql);
                for (int i = 0; i < dtZK.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Qty"] = SysConvert.ToDecimal(dtZK.Rows[i]["DInvoiceQty"]);
                    dr["Amount"] = SysConvert.ToDecimal(dtZK.Rows[i]["DInvoiceAmount"]);
                    dr["FormDate"] = SysConvert.ToDateTime(dtZK.Rows[i]["MakeDate"]);
                    dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(dtZK.Rows[i]["VendorID"]));
                    dr["ItemCode"] = SysConvert.ToString(dtZK.Rows[i]["ItemCode"]);
                    dr["GoodsCode"] = SysConvert.ToString(dtZK.Rows[i]["GoodsCode"]);
                    dr["VItemCode"] = "折扣缺损";
                    dr["SinglePrice"] = SysConvert.ToDecimal(dtZK.Rows[i]["DInvoiceSinglePrice"]);
                    //dr["DtsOrderFormNo"] = SysConvert.ToString(dt3.Rows[j]["HTNO"]);
                    dt.Rows.Add(dr);
                }
            }

            dt.Columns.Add("VOrderFormNo",typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["VOrderFormNo"] = GetVOrderFormNo(dr["DtsOrderFormNo"].ToString());
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "FormDate Asc";
            DataTable dto = dv.ToTable();
            gridView1.GridControl.DataSource = dto;
            gridView1.GridControl.Show();
            BindLabel();


        }

        private string GetVOrderFormNo(string p_FormNo)
        {
            string VFormNo = "";
            if (p_FormNo != "")
            {
                string sql = "SELECT CustomerCode FROM Sale_SaleOrder WHERE FormNo="+SysString.ToDBString(p_FormNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    VFormNo = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            return VFormNo;

        }

        private void BindLabel()
        {
            decimal Qty1 = 0;//采购销售数量
            decimal Qty2 = 0;//开票数量
            decimal Amount1 = 0;//采购开票金额
            decimal Amount2 = 0;//开票金额
            decimal Amount = 0;//收付款金额
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Qty1 += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                Qty2 += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "KPQty"));
                Amount1 += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
                Amount2 += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "KPAmount"));
                Amount += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "LKAmount"));
            }
            lbSUM.Text = "应开票数量：" + SysConvert.ToDecimal(Qty1 - Qty2).ToString() + ";应开票金额：" + SysConvert.ToDecimal(Amount1 - Amount2).ToString() + ";应收款金额："+SysConvert.ToDecimal(Amount1-Amount).ToString() ;

        }

        private void SetDt(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                int DZFlag = GetDZType(SysConvert.ToInt32(dr["SubType"]));
                int DZTypeID= GetDZType2(SysConvert.ToInt32(dr["SubType"]));
                if (DZFlag == (int)EnumDZFlag.不对帐)
                {
                    dr["Qty"] = 0;
                    dr["Amount"] = 0;
                }
                if (DZFlag == (int)EnumDZFlag.对帐负)
                {
                    dr["Qty"] =0-SysConvert.ToDecimal(dr["Qty"]);
                    dr["Amount"] = 0 - SysConvert.ToDecimal(dr["Amount"]);
                }

                if (DZTypeID == (int)EnumDZType.采购)
                {
                    dr["DtsOrderFormNo"] = dr["DtsSO"];
                }
                if (dr["DtsOrderFormNo"].ToString().IndexOf("DY") == 0)
                {
                    dr["DtsOrderFormNo"] = "";
                }

               
               
            }
        }

        private int GetDZType(int p_ID)
        {
            string sql = "SELECT DZFlag FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        private int GetDZType2(int p_ID)
        {
            string sql = "SELECT DZType FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

       
        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CapPlanRule rule = new CapPlanRule();
            CapPlan entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CapPlan";
            this.HTDataList = gridView1;
            Common.BindOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            lbVendor.Text = "客户";
            new VendorProc(drpVendorID);
            this.ToolBarItemAdd(28, ToolButtonName.btnToExcel.ToString(), "导出EXCEL", false, btnToExcel_Click);
            switch (FormListAID)
            {
                case 1:

                    break;
                case 2:
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
                    lbVendor.Text = "工厂";
                    new VendorProc(drpVendorID);
                    break;
            }
            txtFormDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtFormDateE.DateTime = DateTime.Now.Date;
           

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CapPlan EntityGet()
        {
            CapPlan entity = new CapPlan();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
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
                this.BaseFocusLabel.Focus();
                string p_ExportFile = string.Empty;
                DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                DataTable dtnew = dt.Clone();
                if (gridView1.RowFilter != string.Empty)
                {
                    DataRow[] rows = dt.Select(gridView1.RowFilter);

                    foreach (DataRow row in rows)
                    {
                        dtnew.ImportRow(row);
                    }

                }
                else
                {
                    dtnew = dt;
                }
                TemplateExcel.CaiWuDZToExcel(dtnew, txtFormDateE.DateTime.ToString("yyyy-MM-dd"), out p_ExportFile);
                this.OpenFileNoConfirm(p_ExportFile);

                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 仓库出入库财务报表打印

        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }
         
            DataTable dt = (DataTable)gridView1.GridControl.DataSource;
            DataTable dtnew = dt.Clone();
            if (gridView1.RowFilter != string.Empty)
            {
                DataRow[] rows = dt.Select(gridView1.RowFilter);

                foreach (DataRow row in rows)
                {
                    dtnew.ImportRow(row);
                }

            }
            else
            {
                dtnew = dt;
            }

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtnew);

            return true;
        }

        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                // base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.预览);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                //base.btnPrint_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.打印);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.设计);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        
       
    }
}