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
    public partial class frmOrderLRRpt : frmAPBaseUIRpt
    {
        public frmOrderLRRpt()
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

          

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

           

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (chkFormDate.Checked)
            {
                tempStr += " AND OrderDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (SysConvert.ToString(drpPlanOPID.EditValue) != "")
            {
                tempStr += " AND VendorID IN (SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(SysConvert.ToString(drpPlanOPID.EditValue)) + " )";
            }

            if (txtVendorCode.Text.Trim() != "")
            {
                tempStr += " AND VendorCode="+SysString.ToDBString(txtVendorCode.Text.Trim());
            }
          
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "EXEC USP1_Sale_SaleOrderLR " + SysString.ToDBString(HTDataConditionStr);
            DataTable dt=SysUtils.Fill(sql);

            DataRow dr = dt.NewRow();
            dr["FormNo"] = "合计";
            dr["DQty1"] = dt.Compute("SUM(DQty1)", "");
            dr["DAmount1"] = dt.Compute("SUM(DAmount1)", "");
            dr["DQty2"] = dt.Compute("SUM(DQty2)", "");
            dr["DAmount2"] = dt.Compute("SUM(DAmount2)", "");
            dr["LR"] = dt.Compute("SUM(LR)", "");
            
            if (SysConvert.ToDecimal(dr["DAmount1"]) > 0)
            {
                dr["LRPer"] =SysConvert.ToDecimal(SysConvert.ToDecimal(dr["LR"])*100m / SysConvert.ToDecimal(dr["DAmount1"]),2);
            }
            dt.Rows.Add(dr);

            
            gridView1.GridControl.DataSource =dt;
            gridView1.GridControl.Show();
        }

        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_LYGL";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.客户 }, true);//客户
            new VendorProc(drpVendorID);
            Common.BindOP(drpPlanOPID, true);
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            //btnQuery_Click(null, null);

        }

      

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private LYGL EntityGet()
        {
            LYGL entity = new LYGL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

        #region 挂板条码打印

        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string LYIDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (LYIDStr != "")
                    {
                        LYIDStr += ",";
                    }
                    LYIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                }
            }

            if (LYIDStr == "")
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


            FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { LYIDStr });
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

       
        

    }
}