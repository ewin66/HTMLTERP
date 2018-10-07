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
    public partial class frmWHTypeEdit : frmAPBaseUISinEdit
    {
        public frmWHTypeEdit()
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
            WHTypeRule rule = new WHTypeRule();
            WHType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            WHTypeRule rule = new WHTypeRule();
            WHType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            WHType entity = new WHType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtWHPosMethodID.Text = entity.WHPosMethodID.ToString(); 
  			txtItemTypeID.Text = entity.ItemTypeID.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtTax.Text = entity.Tax.ToString(); 
  			txtItemTypeID2.Text = entity.ItemTypeID2.ToString(); 
  			txtItemTypeID3.Text = entity.ItemTypeID3.ToString(); 
  			txtItemTypeID4.Text = entity.ItemTypeID4.ToString(); 
  			txtItemTypeID5.Text = entity.ItemTypeID5.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WHTypeRule rule = new WHTypeRule();
            WHType entity = EntityGet();
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
            this.HTDataTableName = "Enum_WHType";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WHType EntityGet()
        {
            WHType entity = new WHType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.WHPosMethodID = SysConvert.ToInt32(txtWHPosMethodID.Text.Trim()); 
  			entity.ItemTypeID = SysConvert.ToInt32(txtItemTypeID.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.Tax = SysConvert.ToDecimal(txtTax.Text.Trim()); 
  			entity.ItemTypeID2 = SysConvert.ToInt32(txtItemTypeID2.Text.Trim()); 
  			entity.ItemTypeID3 = SysConvert.ToInt32(txtItemTypeID3.Text.Trim()); 
  			entity.ItemTypeID4 = SysConvert.ToInt32(txtItemTypeID4.Text.Trim()); 
  			entity.ItemTypeID5 = SysConvert.ToInt32(txtItemTypeID5.Text.Trim()); 
  			
            return entity;
        }
        #endregion

    }
}