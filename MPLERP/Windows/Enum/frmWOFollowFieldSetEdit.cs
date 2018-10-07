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
    /// ���ܣ��ӹ��������ֶ����ñ�
    /// 
    /// </summary>
    public partial class frmWOFollowFieldSetEdit : frmAPBaseUISinEdit
    {
        public frmWOFollowFieldSetEdit()
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
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            WOFollowFieldSet entity = new WOFollowFieldSet();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpWOFollowTypeID.EditValue = entity.WOFollowTypeID;
  			txtFTableType.Text = entity.FTableType.ToString(); 
  			txtDFieldName.Text = entity.DFieldName.ToString(); 
  			txtDCaption.Text = entity.DCaption.ToString(); 
  			txtDShowFlag.Text = entity.DShowFlag.ToString(); 
  			txtUpdateMainFieldName.Text = entity.UpdateMainFieldName.ToString(); 
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
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
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
            this.HTDataTableName = "Enum_WOFollowFieldSet";
            //

            Common.BindWOFollowType(drpWOFollowTypeID, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WOFollowFieldSet EntityGet()
        {
            WOFollowFieldSet entity = new WOFollowFieldSet();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WOFollowTypeID = SysConvert.ToInt32(drpWOFollowTypeID.EditValue); 
  			entity.FTableType = SysConvert.ToInt32(txtFTableType.Text.Trim()); 
  			entity.DFieldName = SysConvert.ToInt32(txtDFieldName.Text.Trim()); 
  			entity.DCaption = txtDCaption.Text.Trim(); 
  			entity.DShowFlag = SysConvert.ToInt32(txtDShowFlag.Text.Trim()); 
  			entity.UpdateMainFieldName = txtUpdateMainFieldName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}