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
    public partial class frmUpdateOrderStatus : BaseForm
    {
        public frmUpdateOrderStatus()
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

        private string m_OrderStatusName;
        public string OrderStatusName
        {
            get
            {
                return m_OrderStatusName;
            }
            set
            {
                m_OrderStatusName = value;
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
                Common.BindOrderStatus2(drpOrderStatus, true);
                drpOrderStatus.EditValue = m_OrderStatusName;
               
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
                if(SysConvert.ToString(drpOrderStatus.EditValue)=="")
                {
                    return;
                }
                if (chkOrderStatusFlag.Checked)
                {
                    string sql = "UPDATE Sale_SaleOrderDts SET StatusFlag=1";
                    sql += ",StatusName=" + SysString.ToDBString(SysConvert.ToString(drpOrderStatus.EditValue));
                    sql += " WHERE ID=" + SysString.ToDBString(m_ID);
                    SysUtils.ExecuteNonQuery(sql);

                }
                else
                {
                    string sql = "UPDATE Sale_SaleOrderDts SET StatusFlag=0";
                    sql += ",StatusName=''";
                    sql += " WHERE ID=" + SysString.ToDBString(m_ID);
                    SysUtils.ExecuteNonQuery(sql);
                }
                this.Close();

            }
            catch (Exception E)
            {

            }
        }

        


    }

}