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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmSaleProcedureEdit : frmAPBaseUISinEdit
    {
        public frmSaleProcedureEdit()
        {
            InitializeComponent();
        }


        #region  ����BarĬ�ϰ�ť
        /// <summary>
        /// ����BarĬ�ϰ�ť
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "�޸�", false, btnUpdate_Click, eShortcut.F2);//eShortcut.F2
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "����", false, btnSave_Click, eShortcut.F4);//F4
            this.ToolBarItemAdd(5, ToolButtonName.btnCancel.ToString(), "����", false, btnCancel_Click, eShortcut.F5);


            this.ToolBarItemAdd(15, ToolButtonName.btnFirst.ToString(), "��ҳ", true, btnFirst_Click, eShortcut.CtrlUp);
            this.ToolBarItemAdd(16, ToolButtonName.btnPre.ToString(), "��ҳ", false, btnPre_Click, eShortcut.CtrlLeft);
            this.ToolBarItemAdd(17, ToolButtonName.btnNext.ToString(), "��ҳ", false, btnNext_Click, eShortcut.CtrlRight);
            this.ToolBarItemAdd(18, ToolButtonName.btnLast.ToString(), "ĩҳ", false, btnLast_Click, eShortcut.CtrlDown);



            this.ToolBarItemAdd(7, ToolButtonName.btnClose.ToString(), "�˳�", true, btnClose_Click, eShortcut.F12);
        }

        #endregion

        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("��������������");
                txtName.Focus();
                return false;
            }

            if (chkJGUseFlag.Checked)//����ӹ����ϱ�־��ѡ
            {
                if (Common.CheckLookUpEditBlank(drpJGItemTypeID))
                {
                    this.ShowMessage("��������Ʒ����");
                    drpJGItemTypeID.Focus();
                    return false;
                }

                if (Common.CheckLookUpEditBlank(drpJGWHIDDefault))
                {
                    this.ShowMessage("������Ĭ�ϲֿ�");
                    drpJGWHIDDefault.Focus();
                    return false;
                }
                if (Common.CheckLookUpEditBlank(drpJGFormListID))
                {
                    this.ShowMessage("������ֿⵥ������");
                    drpJGFormListID.Focus();
                    return false;
                }

                
            }

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            SaleProcedureRule rule = new SaleProcedureRule();
            SaleProcedure entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SaleProcedureRule rule = new SaleProcedureRule();
            SaleProcedure entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SaleProcedure entity = new SaleProcedure();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString();
            chkShowFlag.Checked = SysConvert.ToBoolean(entity.ShowFlag);
            chkJGUseFlag.Checked = SysConvert.ToBoolean(entity.JGUseFlag);
            chkPackCheckFlag.Checked = SysConvert.ToBoolean(entity.PackCheckFlag);
            drpJGItemTypeID.EditValue = entity.JGItemTypeID;
            drpJGWHIDDefault.EditValue = entity.JGWHIDDefault.ToString();
            drpJGFormListID.EditValue = entity.JGFormListID;
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
            SaleProcedureRule rule = new SaleProcedureRule();
            SaleProcedure entity = EntityGet();
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
            this.HTDataTableName = "Enum_SaleProcedure";

            Common.BindItemType(drpJGItemTypeID, true);
            //Common.BindAllWH(drpJGWHIDDefault, true);
            //Common.BindSubType(drpJGFormListID, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleProcedure EntityGet()
        {
            SaleProcedure entity = new SaleProcedure();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.ShowFlag = SysConvert.ToInt32(chkShowFlag.Checked); 
            entity.PackCheckFlag = SysConvert.ToInt32(chkPackCheckFlag.Checked); 
  			entity.JGUseFlag = SysConvert.ToInt32(chkJGUseFlag.Checked); 
  			entity.JGItemTypeID = SysConvert.ToInt32(drpJGItemTypeID.EditValue);
            entity.JGWHIDDefault = SysConvert.ToString(drpJGWHIDDefault.EditValue);
  			entity.JGFormListID = SysConvert.ToInt32(drpJGFormListID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
  			
            return entity;
        }
        #endregion

        #region �����¼�
        private void drpJGItemTypeID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpJGItemTypeID.EditValue) != 0)
                {
                    Common.BindWHByItemType(drpJGWHIDDefault, SysConvert.ToInt32(drpJGItemTypeID.EditValue), true);
                    Common.BindSubTypeByItemType(drpJGFormListID, SysConvert.ToInt32(drpJGItemTypeID.EditValue), true);
                }
                else
                {
                    Common.BindWHByItemType(drpJGWHIDDefault, -1, true);
                    Common.BindSubTypeByItemType(drpJGFormListID, -1, true);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion


        ///// <summary>
        ///// ��д�����¼������ṩ��������
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnInsert_Click(object sender, EventArgs e)
        //{
        //    this.ShowMessage("����Ҫ�������ݣ�����ϵ���������");
        //    //base.btnInsert_Click(sender, e);
        //}

        ///// <summary>
        ///// ��дɾ���¼������ṩɾ������
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDelete_Click(object sender, EventArgs e)
        //{
        //    this.ShowMessage("����Ҫɾ�����ݣ�����ϵ���������");
        //    //base.btnDelete_Click(sender, e);
        //}

    }
}