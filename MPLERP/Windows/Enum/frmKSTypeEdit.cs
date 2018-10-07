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
    public partial class frmKSTypeEdit : frmAPBaseUISinEdit
    {
        public frmKSTypeEdit()
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
                this.ShowMessage("�������������");
                txtName.Focus();
                return false;
            }
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("������������");
                txtCode.Focus();
                return false;
            }            
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            KSTypeRule rule = new KSTypeRule();
            KSType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            KSTypeRule rule = new KSTypeRule();
            KSType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            KSType entity = new KSType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtZJM.Text = entity.ZJM.ToString(); 
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
            KSTypeRule rule = new KSTypeRule();
            KSType entity = EntityGet();
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
            this.HTDataTableName = "Enum_KSType";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private KSType EntityGet()
        {
            KSType entity = new KSType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.ZJM = txtZJM.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}