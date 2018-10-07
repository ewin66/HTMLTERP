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
    /// ���ܣ����ݿͻ���ϸ
    /// </summary>
    public partial class frmVendorTypeFormEdit : frmAPBaseUISinEdit
    {
        public frmVendorTypeFormEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCLSA.Text.Trim().Equals(""))
            {
                this.ShowMessage("���������");
                txtCLSA.Focus();
                return false;
            }
            if (txtCLSB.Text.Trim().Equals(""))
            {
                this.ShowMessage("���������");
                txtCLSB.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpVendorTypeID))
            {
                this.ShowMessage("������ͻ�");
                drpVendorTypeID.Focus();
                return false;
            } 
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            VendorTypeFormRule rule = new VendorTypeFormRule();
            VendorTypeForm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            VendorTypeFormRule rule = new VendorTypeFormRule();
            VendorTypeForm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            VendorTypeForm entity = new VendorTypeForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCLSA.Text = entity.CLSA.ToString(); 
  			txtCLSB.Text = entity.CLSB.ToString();
            drpVendorTypeID.EditValue = entity.VendorTypeID; 
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
            VendorTypeFormRule rule = new VendorTypeFormRule();
            VendorTypeForm entity = EntityGet();
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
            this.HTDataTableName = "Data_VendorTypeForm";
            //

            Common.BindVendorType(drpVendorTypeID, false);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private VendorTypeForm EntityGet()
        {
            VendorTypeForm entity = new VendorTypeForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim(); 
  			entity.VendorTypeID = SysConvert.ToInt32(drpVendorTypeID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}