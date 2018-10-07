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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmMakeYarnTP :BaseForm
    {
        public frmMakeYarnTP()
        {
            InitializeComponent();
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

     


        
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {

               
               
 
            }
            catch (Exception E)
            {
               
            }

        }

     

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                if (SysConvert.ToDecimal(txtQty.Text.Trim()) <= 0)
                {
                    this.ShowMessage("清输入数量");
                    return;
                }
                //YarnTiaoPing entity = new YarnTiaoPing();
                //entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
                //entity.MakeDate = DateTime.Now.Date;
                //entity.MakeOPName = FParamConfig.LoginName;
                //entity.FormDate = DateTime.Now.Date;
                //entity.Remark = txtRemark.Text.Trim();
                //entity.VendorID = m_VendorID;
                //YarnTiaoPingRule rule = new YarnTiaoPingRule();
                //rule.RAdd(entity);
               
                this.Close();



            }
            catch (Exception E)
            {

            }
        }








    }
}