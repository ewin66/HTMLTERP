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
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindVendor(drpOldVendor, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);
                Common.BindVendor(drpNewVendor, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);
                new VendorProc(drpNewVendor);
                drpOldVendor.EditValue = m_VendorID;
                drpNewVendor.EditValue = m_VendorID;
                lbShow.Text = "����ⵥ�ţ�"+m_FormNo;
            }
            catch (Exception E)
            {
               
            }
        }

       
        /// <summary>
        /// �޸����ۺ�ͬվ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_FormNo == "")
                {
                    this.ShowMessage("���ⵥ��Ϊ�գ�����");
                    return;

                }
                if (SysConvert.ToString(drpOldVendor.EditValue) == string.Empty)
                {
                    this.ShowMessage("�ɿͻ�̧ͷû��ѡ������");
                    return;
                }
                if (SysConvert.ToString(drpNewVendor.EditValue) == string.Empty)
                {
                    this.ShowMessage("�¿ͻ�̧ͷû��ѡ������");
                    return;
                }
                if (SysConvert.ToString(drpNewVendor.EditValue) == SysConvert.ToString(drpOldVendor.EditValue))
                {
                    this.ShowMessage("�¾ɿͻ�̧ͷ��ͬ������");
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
                this.ShowInfoMessage("�޸ĳɹ�");

               

            }
            catch (Exception E)
            {

            }
        }

       

       
     
        


    }

}