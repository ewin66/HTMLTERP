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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Base;

namespace MLTERP
{
    public partial class frmZPOutWHTotalQtyRpt : frmAPBaseUIRpt
    {
        public frmZPOutWHTotalQtyRpt()
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
           
          
            if (txtOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND DtsOrderFormNo LIKE " + SysString.ToDBString("%" + txtOrderFormNo.Text.Trim() + "%");
            }
            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }
          

            //if (this.FormListAID != 0)
            //{
            //    tempStr += " AND HeadType=" + this.FormListAID;
            //}
            


        //    tempStr += Common.GetWHRightCondition();

         
            //tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            //IOFormRule rule = new IOFormRule();

            string sql = "select DtsOrderFormNo,VendorAttn,Unit,SUM(Qty) Qty From UV1_WH_IOFormDts where SubType=1201 and submitflag =1 ";
            sql += HTDataConditionStr;
            sql+=" group by DtsOrderFormNo,VendorAttn,Unit";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;


         //   this.ToolBarItemAdd(28, "btnSaveColor", "保存", false, btnSaveColor_Click);

          //  gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;      
            return entity;
        }

       
        #endregion

        //public override void IniFormLoadBehind()
        //{
        //    ProcessGrid.SetGridColumnReadOnly(gridView1, new string[] { "GrossQty", "GrossWeight", "NetWeight", "SelectFlag" }, false);
        //}

        private void txtOrderFormNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnQuery_Click(null, null);
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }


        #region 扫描出库
        /// <summary>
        ///保存换算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void btnSaveColor_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.BaseFocusLabel.Focus();
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            int p_ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PackID"));
        //            string sql = "Update  WH_IOFormDtsPack set GrossQty=" + SysString.ToDBString(SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "GrossQty")));//毛米长

        //            sql += ",GrossWeight=" + SysString.ToDBString(SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "GrossWeight")));//毛重
        //            sql += ",NetWeight=" + SysString.ToDBString(SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "NetWeight")));//净重
        //           // sql += ",Description=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "Description")));//描述
        //           // sql += ",Destination=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "Destination")));//目的地
        //            sql += " where ID=" + p_ID;
        //            SysUtils.ExecuteNonQuery(sql);
        //        }

        //        this.ShowInfoMessage("保存成功");

        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        #endregion


        //private void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            if (chkAll.Checked)
        //            {
        //                gridView1.SetRowCellValue(i, "SelectFlag", 1);
        //            }
        //            else
        //            {
        //                gridView1.SetRowCellValue(i, "SelectFlag", 0);
        //            }
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}



        //#region 挂板条码打印

        ///// <summary>
        ///// 打印共用条码
        ///// </summary>
        ///// <returns></returns>
        //bool btnPrintAbount(int p_ReportPrintType)
        //{
        //    this.BaseFocusLabel.Focus();



        //    DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //    if (ci.SelectedItem == null)
        //    {
        //        this.ShowMessage("请选择报表模板");
        //        return false;
        //    }
        //    int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //    if (tempReportID == 1)
        //    {
        //        this.ShowMessage("请选择报表模板");
        //        return false;
        //    }

        //    string DYIDStr = "";
            
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
        //            {
        //                if (DYIDStr != "")
        //                {
        //                    DYIDStr += ",";
        //                }
        //                DYIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PackID"));
        //            }
        //        }
        


        //    if (DYIDStr == "")
        //    {
        //        this.ShowMessage("请勾选需要打印的条码");
        //        return false;
        //    }


        //    FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { DYIDStr });
        //    return true;
        //}

        ///// <summary>
        ///// 浏览
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPreview_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        base.btnPreview_Click(sender, e);

        //        btnPrintAbount((int)ReportPrintType.预览);


        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        ///// <summary>
        ///// 打印
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPrint_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        base.btnPrint_Click(sender, e);

        //        btnPrintAbount((int)ReportPrintType.打印);

        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 设计
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDesign_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        base.btnDesign_Click(sender, e);
        //        btnPrintAbount((int)ReportPrintType.设计);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        //#endregion

        //private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    try
        //    {
        //        this.BaseFocusLabel.Focus();

        //        if (e.Column.FieldName == "GrossQty")
        //        {
        //           // 净重=毛米长（米）*克重 （千克/米）*门幅（米）     毛重=净重+0.05kg    云虹公式：

        //            ColumnView view = sender as ColumnView;
        //            decimal grossqty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "GrossQty")); //毛米长
        //            decimal grossweight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "GrossWeight"));//毛重
        //            decimal netweight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "NetWeight"));//净重
        //            decimal mwidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));//门幅
        //            decimal mweight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));//克重
        //            if (mwidth > 0 && mwidth < 1000)
        //            {
        //                decimal mf = mwidth * SysConvert.ToDecimal(0.01);
        //                decimal kz = mweight * SysConvert.ToDecimal(0.001);
        //                decimal jz = SysConvert.ToDecimal(grossqty * mf * kz, 2);
        //                view.SetRowCellValue(view.FocusedRowHandle, "NetWeight", jz);
        //                decimal mz = jz + SysConvert.ToDecimal(0.05);
        //                view.SetRowCellValue(view.FocusedRowHandle, "GrossWeight", mz);
        //            }   
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }

        //}

        //private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{

        //}

    }
}