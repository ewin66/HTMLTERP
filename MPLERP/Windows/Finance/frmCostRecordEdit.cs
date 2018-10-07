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
    public partial class frmCostRecordEdit : frmAPBaseUISinEdit
    {
        public frmCostRecordEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�����ɵ���");
                txtFormNo.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CostRecordRule rule = new CostRecordRule();
            CostRecord entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CostRecordRule rule = new CostRecordRule();
            CostRecord entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CostRecord entity = new CostRecord();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtOrderFormNo.Text = entity.OrderFormNo.ToString();
            drpCostType.EditValue = entity.CostType.ToString();
            txtAmount.Text = entity.Amount.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtMakeOPID.Text = entity.MakeOPID.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtSinglePrice.Text = entity.SinglePrice.ToString();
            txtQty.Text = entity.Qty.ToString();
            txtCostContent.Text = entity.CostContent.ToString();
            txtAidNo.Text = entity.AidNo.ToString();
            txtUnit.Text = entity.Unit.ToString();
            txtSJAmount.Text = entity.SJAmount.ToString();
            txtInvoiceAmount.Text = entity.InvoiceAmount.ToString();
            txtInvoiceBalance.Text = entity.InvoiceBalance.ToString();
            txtInvoiceNo.Text = entity.InvoiceNo.ToString();
            drpPayment.Text = SysConvert.ToString(entity.Payment);

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;

            if (!findFlag)
            {

            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CostRecordRule rule = new CostRecordRule();
            CostRecord entity = EntityGet();
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
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {

            txtFormNo_DoubleClick(null, null);
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;

        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CostRecord";
            //

            //string ConditionV = string.Empty;
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//���۶���ҵ��Աֻ�鿴�Լ��ĵĶ���
            //{
            //    ConditionV = " AND ID IN(Select MainID from Data_VendorSaleOP where OPID in(" + WCommon.GetStructureMemberOPStr() + "))";
            //}
            //Common.BindVendor2(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, ConditionV, true);


            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.��Ӧ��, (int)EnumVendorType.֯��, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�����ӹ��� }, true);
            //new VendorProc(drpVendorID);

            Common.BindCLS(drpCostType, "Finance_CostRecord", "CostType", true);//��������

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CostRecord EntityGet()
        {
            CostRecord entity = new CostRecord();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.OrderFormNo = txtOrderFormNo.Text.Trim();
            entity.CostType = SysConvert.ToString(drpCostType.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.SinglePrice = SysConvert.ToDecimal(txtSinglePrice.Text.Trim());
            entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
            entity.CostContent = txtCostContent.Text.Trim();
            entity.Amount = SysConvert.ToDecimal(txtAmount.Text.Trim());
            entity.AidNo = txtAidNo.Text.Trim();
            entity.Unit = txtUnit.Text.Trim();
            entity.SJAmount = SysConvert.ToDecimal(txtSJAmount.Text.Trim());
            entity.InvoiceAmount = SysConvert.ToDecimal(txtInvoiceAmount.Text.Trim());
            entity.InvoiceBalance = SysConvert.ToDecimal(txtInvoiceBalance.Text.Trim());
            entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Payment = SysConvert.ToString(drpPayment.Text);
            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = DateTime.Now.Date;

            }

            return entity;
        }
        #endregion


        /// <summary>
        /// ˫�����ɵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ProductCommon.FormNoIniSet(txtFormNo, "Finance_CostRecord", "FormNo", 0);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFormDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtInvoiceAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Amount = SysConvert.ToDecimal(txtAmount.Text.Trim());
                decimal InvoiceAmount = SysConvert.ToDecimal(txtInvoiceAmount.Text.Trim());

                decimal InvoiceBalance = InvoiceAmount - Amount;
                txtInvoiceBalance.Text = SysConvert.ToString(InvoiceBalance);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal price = SysConvert.ToDecimal(txtSinglePrice.Text.Trim());
                decimal qty = SysConvert.ToDecimal(txtQty.Text.Trim());

                decimal sjamount = SysConvert.ToDecimal(price * qty, 2);
                txtSJAmount.Text = SysConvert.ToString(sjamount);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}