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
    public partial class frmUpdateWHVendor : BaseForm
    {
        public frmUpdateWHVendor()
        {
            InitializeComponent();
        }

        private string m_FormNo;
        public string FormNo
        {
            get
            {
                return m_FormNo;
            }
            set
            {
                m_FormNo = value;
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
                Common.BindVendor(drpOldVendor, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);
                Common.BindVendor(drpNewVendor, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);
                new VendorProc(drpNewVendor);
                drpOldVendor.EditValue = m_VendorID;
                drpNewVendor.EditValue = m_VendorID;
                lbShow.Text = "出入库单号："+m_FormNo;
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
                if (m_FormNo == "")
                {
                    this.ShowMessage("出库单号为空，请检查");
                    return;

                }
                if (SysConvert.ToString(drpOldVendor.EditValue) == string.Empty)
                {
                    this.ShowMessage("旧客户抬头没有选择，请检查");
                    return;
                }
                if (SysConvert.ToString(drpNewVendor.EditValue) == string.Empty)
                {
                    this.ShowMessage("新客户抬头没有选择，请检查");
                    return;
                }
                if (SysConvert.ToString(drpNewVendor.EditValue) == SysConvert.ToString(drpOldVendor.EditValue))
                {
                    this.ShowMessage("新旧客户抬头相同，请检查");
                    return;
                }

                UpdateWHVendorRule rule = new UpdateWHVendorRule();
                UpdateWHVendor entity = new UpdateWHVendor();
                entity.FormNo = m_FormNo;
                entity.OldVendor = m_VendorID;
                entity.NewVendor = SysConvert.ToString(drpNewVendor.EditValue);
                entity.FormDate = DateTime.Now;
                entity.UpdateOPName = FParamConfig.LoginName;
                rule.RAdd(entity);


                string sql = "UPDATE WH_IOForm SET VendorID=" + SysString.ToDBString(drpNewVendor.EditValue.ToString());
                sql += " WHERE FormNo="+SysString.ToDBString(m_FormNo);
                SysUtils.ExecuteNonQuery(sql);
                this.ShowInfoMessage("修改成功");

               

            }
            catch (Exception E)
            {

            }
        }

       

       
     
        


    }

}