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
    public partial class frmFQCEdit : frmAPBaseUIFormEdit
    {
        public frmFQCEdit()
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
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FQC entity = new FQC();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
          
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			
  			txtDNoInvoiceQty.Text = entity.DNoInvoiceQty.ToString(); 
  			txtDNoInvoiceAmount.Text = entity.DNoInvoiceAmount.ToString(); 
  			txtExAmount.Text = entity.ExAmount.ToString(); 
  			
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			
  			txtRemark.Text = entity.Remark.ToString();
            drpVendorID.EditValue = entity.VendorID;

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
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
            this.HTDataTableName = "Finance_FQC";
            if (this.FormListAID == (int)EnumRecPayType.�տ�)
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            }
            else
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
            }
            new VendorProc(drpVendorID);
            //
        }

        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FQC EntityGet()
        {
            FQC entity = new FQC();
            entity.ID = HTDataID;
            entity.SelectByID();
           
  			entity.FormNo = txtFormNo.Text.Trim();
            entity.VendorID = drpVendorID.EditValue.ToString();
  			entity.DNoInvoiceQty = SysConvert.ToDecimal(txtDNoInvoiceQty.Text.Trim()); 
  			entity.DNoInvoiceAmount = SysConvert.ToDecimal(txtDNoInvoiceAmount.Text.Trim()); 
  			entity.ExAmount = SysConvert.ToDecimal(txtExAmount.Text.Trim());
            entity.RecPayTypeID = this.FormListAID;
  			entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.FormDate = txtMakeDate.DateTime;
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}