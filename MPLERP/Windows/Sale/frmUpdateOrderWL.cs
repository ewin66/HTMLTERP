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
    public partial class frmUpdateOrderWL : BaseForm
    {
        public frmUpdateOrderWL()
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

        private string m_WLVendorID;
        public string WLVendorID
        {
            get
            {
                return m_WLVendorID;
            }
            set
            {
                m_WLVendorID = value;
            }
        }
        private string m_WLFormNo;
        public string WLFormNo
        {
            get
            {
                return m_WLFormNo;
            }
            set
            {
                m_WLFormNo = value;
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
                DevMethod.BindVendor(drpWLVendorID, new int[] { (int)EnumVendorType.物流公司 }, true);
                drpWLVendorID.EditValue = m_WLVendorID;
                txtWLFormNo.Text = m_WLFormNo;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 修改内销订单的物流公司，物流单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE Sale_SaleOrder SET WLVendorID=" + SysString.ToDBString(SysConvert.ToString(drpWLVendorID.EditValue));
                sql += ",WLFormNo=" + SysString.ToDBString(txtWLFormNo.Text.Trim());
                sql += " WHERE ID=" + SysString.ToDBString(m_ID);
                SysUtils.ExecuteNonQuery(sql);
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




    }

}