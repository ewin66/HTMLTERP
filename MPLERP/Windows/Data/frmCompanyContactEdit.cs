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
    public partial class frmCompanyContactEdit : frmAPBaseUISinEdit
    {
        public frmCompanyContactEdit()
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
            if (Common.CheckLookUpEditBlank(drpDepID))
            {
                this.ShowMessage("�����벿��");
                drpDepID.Focus();
                return false;
            }
            if (txtTel.Text.Trim().Equals(""))
            {
                this.ShowMessage("������绰");
                txtTel.Focus();
                return false;
            }        

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CompanyContact entity = new CompanyContact();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             drpCompanyID.EditValue = entity.CompanyID; 
  			drpDepID.EditValue = entity.DepID; 
  			txtTel.Text = entity.Tel.ToString(); 
  			txtFax.Text = entity.Fax.ToString(); 
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
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
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
            this.HTDataTableName = "Data_CompanyContact";
            //
            Common.BindCompanyType(drpCompanyID, false);
            Common.BindDep(drpDepID, false);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CompanyContact EntityGet()
        {
            CompanyContact entity = new CompanyContact();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CompanyID = SysConvert.ToInt32(drpCompanyID.EditValue); 
  			entity.DepID = SysConvert.ToInt32(drpDepID.EditValue); 
  			entity.Tel = txtTel.Text.Trim(); 
  			entity.Fax = txtFax.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}