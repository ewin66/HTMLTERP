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
   /// ���ܣ���Ʒ���ͷ���
   /// </summary>
    public partial class frmItemClassEdit : frmAPBaseUISinEdit
    {
        public frmItemClassEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToString(drpItemTypeID.EditValue) == "")
            {
                this.ShowMessage("��ѡ������");
                drpItemTypeID.Focus();
                return false;
            }  
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtName.Focus();
                return false;
            }            

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ItemClass entity = new ItemClass();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpItemTypeID.EditValue =SysConvert.ToInt32(entity.ItemTypeID); 
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtParentID.Text = entity.ParentID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtItemCodeRule.Text = entity.ItemCodeRule.ToString();

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
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
            this.HTDataTableName = "Data_ItemClass";

            Common.BindItemType(drpItemTypeID, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemClass EntityGet()
        {
            ItemClass entity = new ItemClass();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ItemTypeID = SysConvert.ToInt32(drpItemTypeID.EditValue); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.ParentID = SysConvert.ToInt32(txtParentID.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.ItemCodeRule = txtItemCodeRule.Text.Trim(); 
            return entity;
        }
        #endregion
    }
}