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
    public partial class frmFOPDepEdit : frmAPBaseUISinEdit
    {
        public frmFOPDepEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtName.Focus();
                return false;
            }

            if (txtCLSA.Text.Trim() == "")
            {
                this.ShowMessage("���������");
                txtCLSA.Focus();
                return false;
            }

            if (txtCLSB.Text.Trim() == "")
            {
                this.ShowMessage("�������ֶ���");
                txtCLSB.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpDepID.EditValue) == 0)
            {
                this.ShowMessage("��ѡ����");
                drpDepID.Focus();
                return false;
            } 

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FOPDep entity = new FOPDep();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtName.Text = entity.Name.ToString(); 
  			txtCLSA.Text = entity.CLSA.ToString(); 
  			txtCLSB.Text = entity.CLSB.ToString();
            drpDepID.EditValue = entity.DepID; 
  			txtRemark.Text = entity.Remark.ToString();
            //drpFlag.EditValue = entity.XTFlag;

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
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
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            drpFlag.EditValue = 0;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_FOPDep";
            Common.BindDep(drpDepID);
            //

            SetTabIndex(0, groupControlMainten);
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FOPDep EntityGet()
        {
            FOPDep entity = new FOPDep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim(); 
  			entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim();
            entity.DepID = SysConvert.ToInt32(drpDepID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim();
            //entity.XTFlag = SysConvert.ToInt32(drpFlag.EditValue);
            return entity;
        }
        #endregion
    }
}