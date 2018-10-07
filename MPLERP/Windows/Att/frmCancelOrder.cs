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
    public partial class frmCancelOrder : BaseForm
    {
        public frmCancelOrder()
        {
            InitializeComponent();
        }

        

        private string m_OrdeFormNo;
        public string OrdeFormNo
        {
            get
            {
                return m_OrdeFormNo;
            }
            set
            {
                m_OrdeFormNo = value;
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

                lbOrderFormNo.Text = "订单号："+m_OrdeFormNo;
                txtCancelOrderDes.Text = "";
               
            }
            catch (Exception E)
            {
               
            }
        }

       
        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
               
                string sql = "UPDATE Sale_SaleOrder SET CancelFlag =1";
                sql += ",CancelReason =" + SysString.ToDBString(txtCancelOrderDes.Text.Trim());
                sql += " WHERE FormNo="+SysString.ToDBString(m_OrdeFormNo);
                SysUtils.ExecuteNonQuery(sql);
                this.Close();

               

            }
            catch (Exception E)
            {

            }
        }

        


    }

}