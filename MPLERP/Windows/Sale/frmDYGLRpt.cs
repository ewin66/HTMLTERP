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
    public partial class frmDYGLRpt : frmAPBaseUIRpt
    {
        public frmDYGLRpt()
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (txtShopID.Text.Trim() != string.Empty)
            {
                tempStr += " AND ShopID LIKE "+SysString.ToDBString("%"+txtShopID.Text.Trim()+"%");
            }

            if (txtDLCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND DLCode LIKE "+SysString.ToDBString("%"+txtDLCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (txtVendorID.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE "+SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }

            if (txtVendorID2.Text.Trim() != "")
            {
                tempStr += " AND VendorID2 LIKE " + SysString.ToDBString("%" + txtVendorID2.Text.Trim() + "%");
            }

            if (txtSaleOPName.Text.Trim() != string.Empty)
            {
                tempStr+=" AND OPName LIKE "+SysString.ToDBString("%"+txtSaleOPName.Text.Trim()+"%");
            }

            if(SysConvert.ToString(drpDYStatusID.EditValue)!=string.Empty)
            {
                tempStr+=" AND DYStatusID="+SysString.ToDBString(SysConvert.ToInt32(drpDYStatusID.EditValue));
            }

            if(drpDYXZ.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DYXZ="+SysString.ToDBString(drpDYXZ.Text.Trim());
            }

            if (chkINDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime) + " AND " + SysString.ToDBString(txtQIndateE.DateTime);
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            DYGLRule rule = new DYGLRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr+" ORDER BY MakeDate DESC,FormNo DESC", ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
        }

       

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_DYGL";
            this.HTDataList = gridView1;
            Common.BindCLS(drpDYXZ, "Sale_DYGL", "DYXZ", true);
            Common.BindDYStatus(drpDYStatusID, true);
            txtQIndateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQIndateE.DateTime = DateTime.Now.Date;
            if (GBDYStatusProc.ColorIniFlag)
            {
                GBDYStatusProc.ColorIniTextBox(new TextBox[] { txtColorStatus1, txtColorStatus2, txtColorStatus3});
            }
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            btnQuery_Click(null, null);
        }

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }

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
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private DYGL EntityGet()
        {
            DYGL entity = new DYGL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "DYName")
                {
                    e.Appearance.BackColor = GBDYStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "DYName")));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (chkAll.Checked)
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 0);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 挂板条码打印

        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string DYIDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (DYIDStr != "")
                    {
                        DYIDStr += ",";
                    }
                    DYIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                }
            }

            if (DYIDStr == "")
            {
                this.ShowMessage("请勾选需要打印的挂板条码");
                return false;
            }


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


            FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { DYIDStr });
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
                base.btnPreview_Click(sender, e);

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
                base.btnPrint_Click(sender, e);

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
                base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.设计);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// 选择判断是否同一个调样工厂
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag")) == 1)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1&&gridView1.FocusedRowHandle!=i)
                        {
                            if (SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorID2")) != SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID2")))
                            {
                                this.ShowMessage("第"+i.ToString()+"行与第"+gridView1.FocusedRowHandle.ToString()+"行数据的调样工厂不同,请选择相同的调样工厂进行打印");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
       
    }
}