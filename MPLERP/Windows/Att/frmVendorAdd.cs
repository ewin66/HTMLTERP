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
    public partial class frmVendorAdd : BaseForm
    {
        public frmVendorAdd()
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

        private string m_VendorID;
        public string VendorID
        {
            get
            {
                return m_VendorID;
            }
            set
            {
                m_VendorID = value;
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

                lbOrderFormNo.Text = "工厂："+m_VendorID;
                EntitySet();
               
            }
            catch (Exception E)
            {
               
            }
        }

        private void EntitySet()
        {
            VendorAdd entity = new VendorAdd();
            entity.ID = m_ID;
            entity.SelectByID();
            txtGoodType.Text = entity.GoodType;
            txtVendorPC.Text = entity.VendorPC;
            txtRemark.Text = entity.Remark;
        }

       
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                VendorAddRule rule = new VendorAddRule();
                VendorAdd entity = new VendorAdd();
                entity.ID = m_ID;
                entity.SelectByID();
                entity.ID = m_ID;
                entity.VendorID = m_VendorID;
                entity.Remark = txtRemark.Text.Trim();
                entity.GoodType = txtGoodType.Text.Trim();
                entity.VendorPC = txtVendorPC.Text.Trim();
                rule.RUpdate(entity);
                this.Close();
               

            }
            catch (Exception E)
            {

            }
        }

        


    }

}