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
    public partial class frmItemTypeFormEdit : frmAPBaseUISinEdit
    {
        public frmItemTypeFormEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCLSA.Text.Trim().Equals(""))
            {
                this.ShowMessage("���������");
                txtCLSA.Focus();
                return false;
            }
            if (txtCLSB.Text.Trim().Equals(""))
            {
                this.ShowMessage("������С��");
                txtCLSB.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpItemTypeID))
            {
                this.ShowMessage("������ͻ�����");
                drpItemTypeID.Focus();
                return false;
            } 
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ItemTypeFormRule rule = new ItemTypeFormRule();
            ItemTypeForm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemTypeFormRule rule = new ItemTypeFormRule();
            ItemTypeForm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ItemTypeForm entity = new ItemTypeForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCLSA.Text = entity.CLSA.ToString(); 
  			txtCLSB.Text = entity.CLSB.ToString(); 
  			drpItemTypeID.EditValue = entity.ItemTypeID; 
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
            ItemTypeFormRule rule = new ItemTypeFormRule();
            ItemTypeForm entity = EntityGet();
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
            this.HTDataTableName = "Data_ItemTypeForm";

            Common.BindItemType(drpItemTypeID, false);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemTypeForm EntityGet()
        {
            ItemTypeForm entity = new ItemTypeForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim();
            entity.ItemTypeID = SysConvert.ToInt32(drpItemTypeID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        private void txtRemark_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}