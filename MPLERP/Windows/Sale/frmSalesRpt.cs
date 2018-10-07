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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmSalesRpt : frmAPBaseUIRpt
    {
        public frmSalesRpt()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtSaleOP.Text.Trim() != string.Empty)
            {
                tempStr += " AND SaleOPName LIKE " + SysString.ToDBString("%" + SysConvert.ToString(txtSaleOP.Text.Trim()) + "%");
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID  =" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            tempStr += " AND ISNULL(StatusName,'')<>'���' AND  ISNULL(StatusName,'')<>'��ʱ���' ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT 0 SelectFlag,ISNULL(Qty,0) - ISNULL(TotalRecQty,0) WFQty,ISNULL(Weight,0) - ISNULL(TotalRecWeight,0) WFWeight,ISNULL(PieceQty,0) - ISNULL(TotalRecPieceQty,0) WFPieceQty,* FROM UV1_Sale_SaleOrderDts WHERE 1=1 ";
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }



        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrderDts";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);
        }
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        /// <summary>
        /// ���ٲ�ѯ
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
        #endregion
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //try
            //{
            //    if (e.Column.FieldName == "SamePre")
            //    {
            //        if (SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "SameQty")) > 0)
            //        {
            //            e.Appearance.BackColor = Color.Plum;
            //        }
            //    }
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }
        void PrintAbout(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }
            string temStr = string.Empty;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (temStr != string.Empty)
                    {
                        temStr += ",";
                    }
                    temStr += SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsID"));
                }
            }
            if (temStr == string.Empty)
            {
                this.ShowMessage("�빴ѡ��Ҫ��ӡ����Ϣ");
                return;
            }
            DataTable dt = new DataTable();
            dt.TableName = "Dts";
            string sql = "SELECT ISNULL(Qty,0) - ISNULL(TotalRecQty,0) WFQty,ISNULL(Weight,0) - ISNULL(TotalRecWeight,0) WFWeight,ISNULL(PieceQty,0) - ISNULL(TotalRecPieceQty,0) WFPieceQty,* FROM UV1_Sale_SaleOrderDts WHERE 1=1 ";
            sql += " AND DtsID IN (";
            sql += temStr + ")";
            dt = SysUtils.Fill(sql);
            HttSoft.WinUIBase.FastReport.ReportRunTable(tempReportID, p_ReportPrintType, dt);
        }
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            //base.btnPrint_Click(sender, e);
            PrintAbout((int)ReportPrintType.��ӡ);
        }
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            //base.btnPreview_Click(sender, e);
            PrintAbout((int)ReportPrintType.Ԥ��);
        }
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            //base.btnDesign_Click(sender, e);
            PrintAbout((int)ReportPrintType.���);
        }

    }
}