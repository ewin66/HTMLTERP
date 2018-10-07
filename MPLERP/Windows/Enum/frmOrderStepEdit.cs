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
    public partial class frmOrderStepEdit : frmAPBaseUISinEdit
    {
        public frmOrderStepEdit()
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
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("������վ�����");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("������վ������");
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
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            OrderStep entity = new OrderStep();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString();
            ColorConverter cc = new ColorConverter();
            this.drpSelectColor.EditValue = cc.ConvertFromString(entity.ColorStr);

            drpNextStepID.EditValue = entity.NextStepID;
            drpSaleProduceID.EditValue = entity.SaleProcedureID;
            drpFormListID.EditValue = entity.FormListID;

            drpSaleProduceID2.EditValue = entity.SaleProcedureID2;
            drpFormListID2.EditValue = entity.FormListID2;

            chkDZFlag.Checked = SysConvert.ToBoolean(entity.DZFlag);
            chkInvoiceFlag.Checked = SysConvert.ToBoolean(entity.InvoiceFlag);
            chkRecAmountFlag.Checked = SysConvert.ToBoolean(entity.RecAmountFlag);
            chkFinishFlag.Checked = SysConvert.ToBoolean(entity.FinishFlag);
            chkCancelFlag.Checked = SysConvert.ToBoolean(entity.CancelFlag);
            chkCheckItemFlag.Checked = SysConvert.ToBoolean(entity.CheckItemFlag);
            chkCheckColorFlag.Checked = SysConvert.ToBoolean(entity.CheckColorFlag);
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
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
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
            this.HTDataTableName = "Enum_OrderStep";

            Common.BindOrderStep(drpNextStepID, true);
            Common.BindSaleProcedure(drpSaleProduceID, true);
            Common.BindSubTypeNoTop(drpFormListID, true);
            Common.BindSaleProcedure(drpSaleProduceID2, true);
            Common.BindSubTypeNoTop(drpFormListID2, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private OrderStep EntityGet()
        {
            OrderStep entity = new OrderStep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim();
            ColorConverter cc = new ColorConverter();
            entity.ColorStr = cc.ConvertToString(drpSelectColor.Color);//��ɫ
            entity.NextStepID = SysConvert.ToInt32(drpNextStepID.EditValue);

            entity.SaleProcedureID = SysConvert.ToInt32(drpSaleProduceID.EditValue);
            entity.FormListID = SysConvert.ToInt32(drpFormListID.EditValue);

            entity.SaleProcedureID2 = SysConvert.ToInt32(drpSaleProduceID2.EditValue);
            entity.FormListID2 = SysConvert.ToInt32(drpFormListID2.EditValue);

            entity.DZFlag = SysConvert.ToInt32(chkDZFlag.Checked);
            entity.InvoiceFlag = SysConvert.ToInt32(chkInvoiceFlag.Checked);
            entity.RecAmountFlag = SysConvert.ToInt32(chkRecAmountFlag.Checked);
            entity.FinishFlag = SysConvert.ToInt32(chkFinishFlag.Checked);
            entity.CancelFlag = SysConvert.ToInt32(chkCancelFlag.Checked);
            entity.CheckItemFlag = SysConvert.ToInt32(chkCheckItemFlag.Checked);
            entity.CheckColorFlag = SysConvert.ToInt32(chkCheckColorFlag.Checked);
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
      


        public override void btnInsert_Click(object sender, EventArgs e)
        {
            this.ShowMessage("�����������ݣ�����ϵ������");
           
        }
        #endregion

       
    }
}