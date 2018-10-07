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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ���˾������
    /// ���ߣ�������
    /// ���ڣ�2012-4-20
    /// ����������
    public partial class frmCompanyTypeEdit : frmAPBaseUISinEdit
    {
        public frmCompanyTypeEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CompanyTypeRule rule = new CompanyTypeRule();
            CompanyType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CompanyTypeRule rule = new CompanyTypeRule();
            CompanyType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CompanyType entity = new CompanyType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtOrganizeCode.Text = entity.OrganizeCode.ToString(); 
  			txtTel.Text = entity.Tel.ToString(); 
  			txtFax.Text = entity.Fax.ToString(); 
  			txtAddress.Text = entity.Address.ToString(); 
  			txtZipCode.Text = entity.ZipCode.ToString(); 
  			txtTaxCode.Text = entity.TaxCode.ToString(); 
  			txtBank.Text = entity.Bank.ToString(); 
  			txtAccount.Text = entity.Account.ToString(); 
  			txtBasedCurrency.Text = entity.BasedCurrency.ToString(); 
  			txtDealCurrency.Text = entity.DealCurrency.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtEnName.Text = entity.EnName.ToString(); 
  			txtEnAddress.Text = entity.EnAddress.ToString(); 
  			txtAllName.Text = entity.AllName.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CompanyTypeRule rule = new CompanyTypeRule();
            CompanyType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_CompanyType";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CompanyType EntityGet()
        {
            CompanyType entity = new CompanyType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.OrganizeCode = txtOrganizeCode.Text.Trim(); 
  			entity.Tel = txtTel.Text.Trim(); 
  			entity.Fax = txtFax.Text.Trim(); 
  			entity.Address = txtAddress.Text.Trim(); 
  			entity.ZipCode = txtZipCode.Text.Trim(); 
  			entity.TaxCode = txtTaxCode.Text.Trim(); 
  			entity.Bank = txtBank.Text.Trim(); 
  			entity.Account = txtAccount.Text.Trim(); 
  			entity.BasedCurrency = txtBasedCurrency.Text.Trim(); 
  			entity.DealCurrency = txtDealCurrency.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.EnName = txtEnName.Text.Trim(); 
  			entity.EnAddress = txtEnAddress.Text.Trim(); 
  			entity.AllName = txtAllName.Text.Trim(); 
  			
            return entity;
        }
        #endregion

      
    }
}