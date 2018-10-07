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
    public partial class frmBugFormEdit : frmAPBaseUISinEdit
    {
        public frmBugFormEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToString(drpBugType.EditValue) == "")
            {
                this.ShowMessage("��ѡ���쳣����");
                drpBugType.Focus();
                return false;
            }
            if (SysConvert.ToString(drpStatus.EditValue) == "")
            {
                this.ShowMessage("��ѡ��״̬");
                drpStatus.Focus();
                return false;
            } 
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            BugFormRule rule = new BugFormRule();
            BugForm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            BugFormRule rule = new BugFormRule();
            BugForm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            BugForm entity = new BugForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormNo.Text = entity.FormNo.ToString();
             drpMakeOPID.EditValue = entity.MakeOPID;
  			//txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtConFormNo.Text = entity.ConFormNo.ToString();
            drpBugType.EditValue = entity.BugType;
  			//txtBugType.Text = entity.BugType.ToString(); 
            drpStatus.EditValue = entity.Status;
            //txtStatus.Text = entity.Status.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtAutoOPID.Text = entity.AutoOPID.ToString(); 
  			txtAutoDate.DateTime = entity.AutoDate; 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            BugFormRule rule = new BugFormRule();
            BugForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Data_BugForm", "FormNo", 0, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_BugForm";
            //
            Common.BindBugStatus(drpStatus, true);
            Common.BindBugType(drpBugType, true);
            Common.BindOP(drpMakeOPID, true);

        }
        public override void IniInsertSet()
        {
            drpMakeOPID.EditValue = FParamConfig.LoginID;
            txtAutoDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private BugForm EntityGet()
        {
            BugForm entity = new BugForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = SysConvert.ToString(drpMakeOPID.EditValue);
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.ConFormNo = txtConFormNo.Text.Trim(); 
  			entity.BugType = SysConvert.ToInt32(drpBugType.EditValue); 
  			entity.Status = SysConvert.ToInt32(drpStatus.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.AutoOPID = txtAutoOPID.Text.Trim(); 
  			entity.AutoDate = txtAutoDate.DateTime.Date; 
  			
            return entity;
        }
        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.�쳣��������);
                    ProductCommon.FormNoIniSet(txtFormNo, "Data_BugForm", "FormNo", 0);
                }
                
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }
    }
}