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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmVendorGZRpt : frmAPBaseUIRpt
    {
        public frmVendorGZRpt()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
       
      
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_LYGL";
            Common.BindOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.客户}, true);
            new VendorProc(drpVendorID);
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            this.HTDataList = gridView1;
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核2))
            {
                drpSaleOPID.EditValue = FParamConfig.LoginID;
                drpSaleOPID.Enabled = false;
            }

        }

        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string sql = "SELECT * FROM UV1_Sale_SaleOrderDts WHERE VendorID="+SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(view.FocusedRowHandle,"VendorID")));
                if (chkMakeDate.Checked)
                {
                    sql += " AND MakeDate BETWEEN "+SysString.ToDBString(txtMakeDateS.DateTime)+" AND "+SysString.ToDBString(txtMakeDateE.DateTime);
                }
                DataTable dt = SysUtils.Fill(sql);
               
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();
                

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void drpYesNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnFX_Click(object sender, EventArgs e)
        {
            try
            {
                string condion = "";
                if (SysConvert.ToString(drpVendorID.EditValue) != "")
                {
                    condion += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
                }

                if(SysConvert.ToString(drpSaleOPID.EditValue)!="")
                {
                    condion+=" AND InSaleOP="+SysString.ToDBString(drpSaleOPID.EditValue.ToString());
                }
                string makedates = "2012-4-1";
                string makedatee = "2021-12-30";
                if (chkMakeDate.Checked)
                {
                    makedates = txtMakeDateS.DateTime.Date.ToString();
                    makedatee = txtMakeDateE.DateTime.Date.ToString();
                }

                string sql = "EXEC USP1_Sale_SaleOrderByVendor " + SysString.ToDBString(condion) + "," + SysString.ToDBString(makedates) + "," + SysString.ToDBString(makedatee);
                DataTable dt = SysUtils.Fill(sql);
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "OrderDate" && SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "OrderDate")) !="")
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "Num" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "Num")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "TotalQty" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "TotalQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "TotalAmount" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "TotalAmount")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
        








    }
}