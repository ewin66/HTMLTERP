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
    /// <summary>
    /// ���ܣ����������
    /// ���ߣ�������
    /// ���ڣ�2012-4-19
    /// ����������
    /// </summary>
    public partial class frmParamSetEdit : frmAPBaseUISinEdit
    {
        public frmParamSetEdit()
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
            if (txtCode.Text.Trim().Equals(""))
            {
                this.ShowMessage("�������������");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim().Equals(""))
            {
                this.ShowMessage("�������������");
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
            ParamSetRule rule = new ParamSetRule();
            ParamSet entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ParamSetRule rule = new ParamSetRule();
            ParamSet entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ParamSet entity = new ParamSet();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtSetValueStr.Text = entity.SetValueStr.ToString(); 
  			txtSetValueInt.Text = entity.SetValueInt.ToString(); 
  			txtSetValueDt.DateTime = entity.SetValueDt; 
  			txtRemark.Text = entity.Remark.ToString();
            if (txtSetValueDt.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtSetValueDt.Text = "";
            }
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
            ParamSetRule rule = new ParamSetRule();
            ParamSet entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            if (HTFormStatus == FormStatus.�޸�)
            {
                txtCode.Properties.ReadOnly = true;
            }
        }
        public override void IniInsertSet()
        {
            txtSetValueDt.DateTime = DateTime.Now.Date;
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sys_ParamSet";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ParamSet EntityGet()
        {
            ParamSet entity = new ParamSet();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.SetValueStr = txtSetValueStr.Text.Trim(); 
  			entity.SetValueInt = SysConvert.ToInt32(txtSetValueInt.Text.Trim());
            if (txtSetValueDt.Text != string.Empty)
            {
                entity.SetValueDt = txtSetValueDt.DateTime.Date;
            }
            entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}