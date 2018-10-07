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
    /// ���ܣ��ӹ�������վ���
    /// 
    /// </summary>
    public partial class frmWOFollowStepEdit : frmAPBaseUISinEdit
    {
        public frmWOFollowStepEdit()
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
            WOFollowStepRule rule = new WOFollowStepRule();
            WOFollowStep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            WOFollowStepRule rule = new WOFollowStepRule();
            WOFollowStep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            WOFollowStep entity = new WOFollowStep();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpWOFollowTypeID.EditValue = entity.WOFollowTypeID;
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtColorStr.Text = entity.ColorStr.ToString(); 
  			txtMainFlag.Text = entity.MainFlag.ToString(); 
  			txtSubFlag.Text = entity.SubFlag.ToString(); 
  			txtSubUpdateMainFlag.Text = entity.SubUpdateMainFlag.ToString(); 
  			txtGnsUpdateSubFlag.Text = entity.GnsUpdateSubFlag.ToString(); 
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
            WOFollowStepRule rule = new WOFollowStepRule();
            WOFollowStep entity = EntityGet();
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
            this.HTDataTableName = "Enum_WOFollowStep";
            //


            Common.BindWOFollowType(drpWOFollowTypeID, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WOFollowStep EntityGet()
        {
            WOFollowStep entity = new WOFollowStep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WOFollowTypeID = SysConvert.ToInt32(drpWOFollowTypeID.EditValue); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.ColorStr = txtColorStr.Text.Trim(); 
  			entity.MainFlag = SysConvert.ToInt32(txtMainFlag.Text.Trim()); 
  			entity.SubFlag = SysConvert.ToInt32(txtSubFlag.Text.Trim()); 
  			entity.SubUpdateMainFlag = SysConvert.ToInt32(txtSubUpdateMainFlag.Text.Trim()); 
  			entity.GnsUpdateSubFlag = SysConvert.ToInt32(txtGnsUpdateSubFlag.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

       
    }
}