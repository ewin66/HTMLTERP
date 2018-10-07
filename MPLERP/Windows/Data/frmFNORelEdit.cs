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
    public partial class frmFNORelEdit : frmAPBaseUISinEdit
    {
        public frmFNORelEdit()
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
            FNORelRule rule = new FNORelRule();
            FNORel entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FNORelRule rule = new FNORelRule();
            FNORel entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FNORel entity = new FNORel();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtName.Text = entity.Name.ToString(); 
  			txtCLSA.Text = entity.CLSA.ToString(); 
  			txtCLSB.Text = entity.CLSB.ToString(); 
  			drpFormNoControlID.EditValue = entity.FormNoControlID; 
  			txtRemark.Text = entity.Remark.ToString();
            txtSubTypeID.Text = entity.SubTypeID.ToString();       
            chkSelfEditFlag.Checked = SysConvert.ToBoolean(entity.SelfEditFlag);

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FNORelRule rule = new FNORelRule();
            FNORel entity = EntityGet();
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
            this.HTDataTableName = "Data_FNORel";
            Common.BindFormNoControl(drpFormNoControlID, true);
            //
            SetTabIndex(0, groupControlMainten);

            lbDes1.Text = "���ڵ��ݴ򿪶ര����ж����ˮ��ʹ��";
            lbDes2.Text = "��ѡʱ��ʶ���Զ���ȡ��ţ��˹��޸�";
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FNORel EntityGet()
        {
            FNORel entity = new FNORel();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim(); 
  			entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim(); 
  			entity.FormNoControlID = SysConvert.ToInt32(drpFormNoControlID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.SelfEditFlag = SysConvert.ToInt32(chkSelfEditFlag.Checked);
            entity.SubTypeID = SysConvert.ToInt32(txtSubTypeID.Text);
  			
            return entity;
        }
        #endregion
    }
}