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
    /// ���ܣ��ӹ�����ö�ٱ������ù���
    /// 
    /// </summary>
    public partial class frmWOFollowTypeEdit : frmAPBaseUISinEdit
    {
        public frmWOFollowTypeEdit()
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
            WOFollowTypeRule rule = new WOFollowTypeRule();
            WOFollowType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            WOFollowTypeRule rule = new WOFollowTypeRule();
            WOFollowType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            WOFollowType entity = new WOFollowType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString();
            drpUseFlag.EditValue = entity.UseFlag;
            drpSaleProcedureID.EditValue = entity.SaleProcedureID;
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtQryTableName.Text = entity.QryTableName.ToString(); 
  			txtQryIDFieldName.Text = entity.QryIDFieldName.ToString(); 
  			txtQryFieldName.Text = entity.QryFieldName.ToString(); 
  			txtQryShowCaption.Text = entity.QryShowCaption.ToString(); 
  			txtQryOrderByFieldName.Text = entity.QryOrderByFieldName.ToString(); 
  			txtQryWhereConFirst.Text = entity.QryWhereConFirst.ToString(); 
  			txtUIImgUrl.Text = entity.UIImgUrl.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WOFollowTypeRule rule = new WOFollowTypeRule();
            WOFollowType entity = EntityGet();
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
            this.HTDataTableName = "Enum_WOFollowType";
          
            Common.BindSaleProcedure(drpSaleProcedureID, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WOFollowType EntityGet()
        {
            WOFollowType entity = new WOFollowType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.UseFlag = SysConvert.ToInt32(drpUseFlag.EditValue); 
  			entity.SaleProcedureID = SysConvert.ToInt32(drpSaleProcedureID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.QryTableName = txtQryTableName.Text.Trim(); 
  			entity.QryIDFieldName = txtQryIDFieldName.Text.Trim(); 
  			entity.QryFieldName = txtQryFieldName.Text.Trim(); 
  			entity.QryShowCaption = txtQryShowCaption.Text.Trim(); 
  			entity.QryOrderByFieldName = txtQryOrderByFieldName.Text.Trim(); 
  			entity.QryWhereConFirst = txtQryWhereConFirst.Text.Trim(); 
  			entity.UIImgUrl = txtUIImgUrl.Text.Trim(); 
  			
            return entity;
        }
        #endregion

      
    }
}