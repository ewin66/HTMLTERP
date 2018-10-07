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
    public partial class frmShowQty : BaseForm
    {
        public frmShowQty()
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

        private decimal m_Qty;
        public decimal Qty
        {
            get
            {
                return m_Qty;
            }
            set
            {
                m_Qty = value;
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

                
                EntitySet();
               
            }
            catch (Exception E)
            {
               
            }
        }

        private void EntitySet()
        {
            IOFormDts entity = new IOFormDts();
            entity.ID = m_ID;
            entity.SelectByID();
           
            txtQty.Text = m_Qty.ToString();
            txtYQQty.Text = entity.YQQty.ToString();
            txtInvoiceQty.Text = entity.InvoiceQty.ToString();
            txtNOKPQty.Text = SysConvert.ToString(m_Qty + entity.YQQty - entity.InvoiceQty);
            lbShow.Text = "产品编号：" + entity.ItemCode + ",商品码：" + entity.GoodsCode + ",颜色：" + entity.ColorNum +" "+ entity.ColorName;
        }

       
       
        


    }

}