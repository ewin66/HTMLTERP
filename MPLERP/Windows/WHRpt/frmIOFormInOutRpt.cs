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
    
    
    /// <summary>
    ///出入库报表 王焕梅 2012.05.05
    /// </summary>
    public partial class frmIOFormInOutRpt : frmAPBaseUIForm
    {
        public frmIOFormInOutRpt()
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
            if (txtVendor.Text.Trim() != "")
            {
                tempStr += " AND VendorID LIKE " + SysString.ToDBString("%" + txtVendor.Text.Trim() + "%");
            }
            if (txtOutDep.Text.Trim() != "")
            {
                tempStr += " AND OutDep LIKE " + SysString.ToDBString("%" + txtOutDep.Text.Trim() + "%");
            }
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }
            if (txtBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtBatch.Text.Trim() + "%");
            }
            if (chkSinglePrice.Checked)
            {
                tempStr += " AND SinglePrice BETWEEN " + SysConvert.ToDecimal(txtSinglePriceS.Text) + " AND " + SysConvert.ToDecimal(txtSinglePriceE.Text);
            }
            if (txtVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtVendorBatch.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpSaleOPName.EditValue) != "")
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPName.EditValue));
            }
            if (txtSpecialNo.Text.Trim() != "")
            {
                tempStr += " AND SpecialNo LIKE " + SysString.ToDBString("%" + txtSpecialNo.Text.Trim() + "%");
            }
            if (chkItemDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtFormDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
           
            IOFormDtsRule rule = new IOFormDtsRule();
            gridView1.GridControl.DataSource = rule.RShowIO(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
          

        }

       

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
          //  this.HTDataTableName = "Data_OP";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);
            Common.BindDOP(drpSaleOPName, true);
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
        }

        #endregion

      
        
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQOPID_EditValueChanged(object sender, EventArgs e)
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
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQOPNM_EditValueChanged(object sender, EventArgs e)
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

       

      

        private void frmIOFormInOutRpt_Load(object sender, EventArgs e)
        {

        }

        
    }
}