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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请生成单号");
                txtFormNo.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CostRecordRule rule = new CostRecordRule();
            CostRecord entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CostRecordRule rule = new CostRecordRule();
            CostRecord entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
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
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CostRecordRule rule = new CostRecordRule();
            CostRecord entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {

            txtFormNo_DoubleClick(null, null);
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;

        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CostRecord";
            //

            //string ConditionV = string.Empty;
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
            //{
            //    ConditionV = " AND ID IN(Select MainID from Data_VendorSaleOP where OPID in(" + WCommon.GetStructureMemberOPStr() + "))";
            //}
            //Common.BindVendor2(drpVendorID, new int[] { (int)EnumVendorType.客户 }, ConditionV, true);


            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.供应商, (int)EnumVendorType.织厂, (int)EnumVendorType.染厂, (int)EnumVendorType.其他加工厂 }, true);
            //new VendorProc(drpVendorID);

            Common.BindCLS(drpCostType, "Finance_CostRecord", "CostType", true);//费用类型

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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
            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = DateTime.Now.Date;

            }

            return entity;
        }
        #endregion


        /// <summary>
        /// 双击生成单号
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