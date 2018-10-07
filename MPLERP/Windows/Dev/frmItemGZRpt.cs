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
    public partial class frmItemGZRpt : frmAPBaseUIRpt
    {
        public frmItemGZRpt()
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
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            this.HTDataList = gridView1;
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);

        }

        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string makedates = "2012-4-1";
                string makedatee = "2021-12-30";
                if (chkMakeDate.Checked)
                {
                    makedates = txtMakeDateS.DateTime.Date.ToString("yyyy-MM-dd");
                    makedatee = txtMakeDateE.DateTime.Date.ToString("yyyy-MM-dd");
                }
                if (chkColorFlag.Checked)
                {
                    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                    string sql = "EXEC USP1_Dev_ColorGZ " + SysString.ToDBString(ItemCode) + "," + SysString.ToDBString(makedates) + "," + SysString.ToDBString(makedatee);
                    DataTable dt = SysUtils.Fill(sql);
                    gridView2.GridControl.DataSource = dt;
                    gridView2.GridControl.Show();
                }


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
                if (txtItemCode.Text.Trim() != "")
                {
                    condion += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
                }

                if (txtGoodsCode.Text.Trim() != "")
                {
                    condion += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
                }

                if (txtVendorID.Text.Trim() != "")
                {
                    condion += " AND VendorID LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
                }

                string makedates = "2012-4-1";
                string makedatee = "2021-12-30";
                if (chkMakeDate.Checked)
                {
                    makedates = txtMakeDateS.DateTime.Date.ToString();
                    makedatee = txtMakeDateE.DateTime.Date.ToString();
                }
                string sql = "EXEC USP1_Dev_ItemCodeGZ " + SysString.ToDBString(condion) + "," + SysString.ToDBString(makedates) + "," + SysString.ToDBString(makedatee);
                frmWait frm = new frmWait();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ConditionStr = sql;
                frm.ShowDialog();
                gridView1.GridControl.DataSource = frm.Dt;
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
                if (e.Column.FieldName == "JCQty" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "JCQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "LYQty" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "LYQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "DYQty" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "DYQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "BJQty" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "BJQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "SaleQty" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "SaleQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "TQty" && SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "TQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void chkColorFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridViewRowChanged2(gridView1);
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
                if (e.Column.FieldName == "JCQty" && SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "JCQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "LYQty" && SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "LYQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "DYQty" && SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "DYQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "BJQty" && SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "BJQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "SaleQty" && SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "SaleQty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (e.Column.FieldName == "TQty" && SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "TQty")) > 0)
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