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
    public partial class frmCompanyAccountEdit : frmAPBaseUISinEdit
    {
        public frmCompanyAccountEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (Common.CheckLookUpEditBlank(drpCompanyID))
            {
                this.ShowMessage("�����빫˾��");
                drpCompanyID.Focus();
                return false;
            }
            if (txtBank.Text.Trim().Equals(""))
            {
                this.ShowMessage("�����뿪����");
                txtBank.Focus();
                return false;
            }
            if (txtAccount.Text.Trim().Equals(""))
            {
                this.ShowMessage("�������ʺ�");
                txtAccount.Focus();
                return false;
            } 

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CompanyAccountRule rule = new CompanyAccountRule();
            CompanyAccount entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CompanyAccountRule rule = new CompanyAccountRule();
            CompanyAccount entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CompanyAccount entity = new CompanyAccount();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpCompanyID.EditValue = entity.CompanyID;
  			txtBank.Text = entity.Bank.ToString(); 
  			txtAccount.Text = entity.Account.ToString(); 
  			txtSwifCode.Text = entity.SwifCode.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CompanyAccountRule rule = new CompanyAccountRule();
            CompanyAccount entity = EntityGet();
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
            this.HTDataTableName = "Data_CompanyAccount";
            //
            Common.BindCompanyType(drpCompanyID, false);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CompanyAccount EntityGet()
        {
            CompanyAccount entity = new CompanyAccount();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CompanyID = SysConvert.ToInt32(drpCompanyID.EditValue); 
  			entity.Bank = txtBank.Text.Trim(); 
  			entity.Account = txtAccount.Text.Trim(); 
  			entity.SwifCode = txtSwifCode.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        private void txtSwifCode_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}