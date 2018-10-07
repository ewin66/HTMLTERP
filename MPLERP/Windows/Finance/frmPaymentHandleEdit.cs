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
    public partial class frmPaymentHandleEdit : frmAPBaseUIFormEdit
    {
        public frmPaymentHandleEdit()
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
            PaymentHandleRule rule = new PaymentHandleRule();
            PaymentHandle entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            PaymentHandleRule rule = new PaymentHandleRule();
            PaymentHandle entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtOrderFormNo.Text = entity.OrderFormNo.ToString();
            drpVendorID.EditValue = entity.VendorID;
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpCurrency.EditValue = entity.Currency; 
  			txtPayMethod.Text = entity.PayMethod.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            txtMakeOPName.Text = entity.MakeOPID.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtQty.Text = entity.Qty.ToString();
            txtAmount.Text = entity.Amount.ToString();
            txtUnit.EditValue = entity.Unit;
            drpType.EditValue = entity.Type.ToString();
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
            PaymentHandleRule rule = new PaymentHandleRule();
            PaymentHandle entity = EntityGet();
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
            this.HTDataTableName = "Finance_PaymentHandle";
            
            //
        }
        public override void IniRefreshData()
        {
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.��Ӧ��, (int)EnumVendorType.֯��, (int)EnumVendorType.Ⱦ�� }, true);
            drpSaleOPID.EditValue = FParamConfig.LoginID;
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.ҵ�� }, true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            drpCurrency.EditValue = "RMB";//����Ĭ�������
            Common.BindCLS(drpType, "Finance_PaymentHandle", "Type", true);
        }
        public override void IniInsertSet()
        {
            txtFormNo_DoubleClick(null, null);
            drpCurrency.EditValue = "RMB";//����Ĭ������
            txtUnit.EditValue = "M";
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private PaymentHandle EntityGet()
        {
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.OrderFormNo = txtOrderFormNo.Text.Trim();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.Currency = SysConvert.ToString(drpCurrency.EditValue);
  			entity.PayMethod = txtPayMethod.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.Unit =SysConvert.ToString(txtUnit.EditValue);
            entity.Qty = SysConvert.ToDecimal(txtQty.EditValue);
            entity.Amount = SysConvert.ToDecimal(txtAmount.EditValue);
            entity.Type = SysConvert.ToString(drpType.EditValue);
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.MakeOPID = txtMakeOPName.Text.Trim();
  			
            return entity;
        }
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "Finance_PaymentHandle", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    txtItemCode_DoubleClick(null, null);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) == "")
                {
                    this.ShowMessage("��ѡ��ͻ�");
                    drpVendorID.Focus();
                    return;
                }


                LoadSaleOrder();


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �������ۺ�ͬ
        /// </summary>
        private void LoadSaleOrder()
        {
            frmLoadOrder frm = new frmLoadOrder();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            frm.Double = true;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {
                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                setItemNews(str);
            }
        }
        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtQty.Text = SysConvert.ToString(dt.Rows[0]["Qty"]);
                    txtUnit.Text = SysConvert.ToString(dt.Rows[0]["Unit"]);
                    txtRemark.Text = "��Ʒ��ţ�"+ SysConvert.ToString(dt.Rows[0]["ItemCode"]) + ",�ɷ֣�" + SysConvert.ToString(dt.Rows[0]["ItemName"]) + ",Ʒ����" + SysConvert.ToString(dt.Rows[0]["ItemModel"]) + ",ɫ�ţ�" + SysConvert.ToString(dt.Rows[0]["ColorNum"]) + ",��ɫ��" + SysConvert.ToString(dt.Rows[0]["ColorName"]);
                }
            }
        }
        #endregion

        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;
            entity.SelectByID();
            if (entity.ReadFlag == 1)
            {
                this.ShowMessage("�õ������Ĳ����޸�");
                return;
            }
            base.btnUpdate_Click(sender, e);
        }
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;
            entity.SelectByID();
            if (entity.ReadFlag == 1)
            {
                this.ShowMessage("�õ������Ĳ��ܳ����ύ");
                return;
            }
            base.btnSubmitCancel_Click(sender, e);
        }
    }
}