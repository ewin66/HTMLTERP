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



namespace MLTERP
{
    public partial class frmUpdateOrderStep : BaseForm
    {
        public frmUpdateOrderStep()
        {
            InitializeComponent();
        }

        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private int m_OrderStepID;
        public int OrderStepID
        {
            get
            {
                return m_OrderStepID;
            }
            set
            {
                m_OrderStepID = value;
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindOrderStep(drpOrderStep, true);
                drpOrderStep.EditValue = m_OrderStepID;
               
            }
            catch (Exception E)
            {
               
            }
        }

       
        /// <summary>
        /// 修改销售合同站别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if(SysConvert.ToInt32(drpOrderStep.EditValue)==0)
                {
                    return;
                }
                string sql = "UPDATE Sale_SaleOrder SET OrderPreStepID="+SysString.ToDBString(m_OrderStepID);
                sql += ",OrderStepID="+SysString.ToDBString(SysConvert.ToInt32(drpOrderStep.EditValue));
                sql += " WHERE ID="+SysString.ToDBString(m_ID);
                SysUtils.ExecuteNonQuery(sql);

                sql = "UPDATE Sale_SaleOrderDts SET OrderPreStepID=" + SysString.ToDBString(m_OrderStepID);
                sql += ",OrderStepID=" + SysString.ToDBString(SysConvert.ToInt32(drpOrderStep.EditValue));
                sql += " WHERE MainID=" + SysString.ToDBString(m_ID);
                SysUtils.ExecuteNonQuery(sql);
                this.Close();

            }
            catch (Exception E)
            {

            }
        }

        


    }

}