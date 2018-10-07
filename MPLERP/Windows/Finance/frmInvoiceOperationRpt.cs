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
    public partial class frmInvoiceOperationRpt : frmAPBaseUIRpt
    {
        public frmInvoiceOperationRpt()
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
            if (txtFormNo.Text.Trim()!= "")//查询d
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) ;
            }
            
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if(txtItemVendorID.Text.Trim()!="")
            {
                tempStr += " AND ItemVendorID LIKE" + SysString.ToDBString("%" + txtItemVendorID.Text.Trim() + "%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
            tempStr += " AND DZTypeID="+SysString.ToDBString(FormListAID);
            tempStr += " AND SubmitFlag=1 ";
            HTDataConditionStr = tempStr;

        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT  ItemVendorID,GoodsCode,ItemCode,SUM(Qty) Qty,SUM(Amount) Amount FROM (";
            sql += " SELECT ItemVendorID,GoodsCode,ItemCode,ISNULL(SUM(DInvoiceQty),0) Qty,ISNULL(SUM(DInvoiceAmount),0) Amount FROM UV1_Finance_InvoiceOperationDts WHERE 1=1";
            sql += HTDataConditionStr;
            sql += " AND KPType="+SysString.ToDBString((int)EnumKPType.正常开票);
            sql += " GROUP BY ItemVendorID,GoodsCode,ItemCode";
            sql += " UNION ALL";

            sql += " SELECT ItemVendorID,GoodsCode,ItemCode,ISNULL(SUM(Qty),0) Qty,ISNULL(SUM(Amount),0) Amount FROM UV1_Finance_InvoiceYOperationDts WHERE 1=1";
            sql += HTDataConditionStr;
            sql += " AND KPType=" + SysString.ToDBString((int)EnumKPType.预开票);
            sql += " GROUP BY ItemVendorID,GoodsCode,ItemCode";
            sql += " ) AS T";
            sql += " GROUP BY ItemVendorID,GoodsCode,ItemCode";
            sql += " ORDER BY ItemVendorID";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;// rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
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


            txtQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindOP(drpSaleOPID, true);
           
            this.HTDataTableName = "Finance_InvoiceOperation";
            this.HTDataList = gridView1;
            BindVendor();
            new VendorProc(drpQVendorID);
            btnQuery_Click(null, null);

        }

        private void BindVendor()
        {

            Common.BindVendorByDZTypeID(drpQVendorID, this.FormListAID, true);
            //switch (FormListAID)
            //{
            //    case (int)EnumDZType.采购:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            //        lblVendor.Text = "供应商";
            //        break;
            //    case (int)EnumDZType.加工:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            //        lblVendor.Text = "加工厂";
            //        break;
            //    case (int)EnumDZType.销售:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            //        lblVendor.Text = "客户";
            //        break;

            //}
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        #region 留样打印

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