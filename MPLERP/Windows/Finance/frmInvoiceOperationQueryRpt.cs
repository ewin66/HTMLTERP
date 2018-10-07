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
    public partial class frmInvoiceOperationQueryRpt : frmAPBaseUIRpt
    {
        public frmInvoiceOperationQueryRpt()
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
     
            HTDataConditionStr = tempStr;

        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
          
            string sql = "SELECT * FROM UV1_Finance_InvoiceOperationDts WHERE 1=1";
            if (FormListAID == (int)EnumVendorType.客户)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.销售);
            }
            if (FormListAID == (int)EnumVendorType.工厂)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.采购);
            }
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

            if (txtFormNo.Text.Trim() != "")
            {
                sql += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if(txtInvoiceNo.Text.Trim()!="")
            {
                sql+=" AND InvoiceNo LIKE "+SysString.ToDBString("%"+txtInvoiceNo.Text.Trim()+"%");
            }

            if (SysConvert.ToInt32(drpKPType.EditValue) != 0)
            {
                sql += " AND KPType="+SysString.ToDBString(SysConvert.ToInt32(drpKPType.EditValue));
            }

           
            DataTable dt = SysUtils.Fill(sql);

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

            if (txtFormNo.Text.Trim() != "")
            {
                sql += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (txtInvoiceNo.Text.Trim() != "")
            {
                sql += " AND InvoiceNo LIKE " + SysString.ToDBString("%" + txtInvoiceNo.Text.Trim() + "%");
            }

            if (SysConvert.ToInt32(drpKPType.EditValue) != 0)
            {
                sql += " AND KPType=" + SysString.ToDBString(SysConvert.ToInt32(drpKPType.EditValue));
            }
            DataTable dt2 = SysUtils.Fill(sql);

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["FormNo"] = SysConvert.ToString(dt2.Rows[i]["FormNo"]);
                dr["InvoiceNo"] = SysConvert.ToString(dt2.Rows[i]["InvoiceNo"]);
               
                dr["MakeDate"] = SysConvert.ToDateTime(dt2.Rows[i]["MakeDate"]);
                dr["SubmitFlag"] = SysConvert.ToInt32(dt2.Rows[i]["SubmitFlag"]);
                dr["SaleOPName"] = SysConvert.ToString(dt2.Rows[i]["SaleOPName"]);
                dr["DInvoiceQty"] = SysConvert.ToDecimal(dt2.Rows[i]["Qty"]);
                dr["DInvoiceSinglePrice"] = SysConvert.ToDecimal(dt2.Rows[i]["SinglePrice"]);
                dr["DInvoiceAmount"] = SysConvert.ToDecimal(dt2.Rows[i]["Amount"]);
                dr["VendorName"] =Common.GetVendorNameByVendorID(SysConvert.ToString(dt2.Rows[i]["VendorID"]));
                dr["KPName"] = SysConvert.ToString(dt2.Rows[i]["KPName"]);
                dr["GoodsCode"] = SysConvert.ToString(dt2.Rows[i]["GoodsCode"]);
                dr["Unit"] = SysConvert.ToString(dt2.Rows[i]["Unit"]);
                dr["ItemCode"] = SysConvert.ToString(dt2.Rows[i]["ItemCode"]);
                dr["ColorNum"] = SysConvert.ToString(dt2.Rows[i]["ColorNum"]);
                dr["ColorName"] = SysConvert.ToString(dt2.Rows[i]["ColorName"]);
               
                dt.Rows.Add(dr);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "MakeDate Asc";
            DataTable dto = dv.ToTable();
            gridView1.GridControl.DataSource = dto;
            gridView1.GridControl.Show();
           
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

            ProcessGrid.BindGridColumn(gridView1, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);


          
            Common.BindOP(drpSaleOPID, true);
            Common.BindKPType(drpKPType, true);
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
            btnQuery_Click(null, null);

        }

        private void BindVendor()
        {

          
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
            return entity;
        }
        #endregion

        #region 快速查询
        private void txtMakeOPName_EditValueChanged(object sender, EventArgs e)
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

        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
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
        #endregion

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