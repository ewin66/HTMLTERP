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
    /// �ڳ�����ά��
    /// </summary>
    public partial class frmBVendorAmountEdit : frmAPBaseUISinEdit
    {
        public frmBVendorAmountEdit()
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
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            BVendorAmount entity = new BVendorAmount();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpVendorID.EditValue = entity.VendorID;
  			txtBQty.Text = entity.BQty.ToString(); 
  			txtBAmount.Text = entity.BAmount.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpDZType.EditValue = entity.DZTypeID;


            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
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
            this.HTDataTableName = "Finance_BVendorAmount";

            Common.BindDZType(drpDZType, true);
          
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private BVendorAmount EntityGet()
        {
            BVendorAmount entity = new BVendorAmount();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.BQty = SysConvert.ToDecimal(txtBQty.Text.Trim()); 
  			entity.BAmount = SysConvert.ToDecimal(txtBAmount.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();

            entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
         
            entity.UpdateOP = FParamConfig.LoginName;
            entity.UpdateDate = DateTime.Now;
  			
            return entity;
        }
        #endregion

        private void drpDZType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpDZType.EditValue) != 0)
                {
                    int DZType = SysConvert.ToInt32(drpDZType.EditValue);
                    Common.BindVendorByDZTypeID(drpVendorID, DZType, true);                   
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}