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
using HttSoft.WinUIBase;


namespace MLTERP
{
    /// <summary>
    /// ���ܣ���Ʒ������ϸ
    /// </summary>
    public partial class frmItemTypeEdit : frmAPBaseUISinEdit
    {
        public frmItemTypeEdit()
        {
            InitializeComponent();
        }
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim().Equals(""))
            {
                this.ShowMessage("������ID");
                txtID.Focus();
                return false;
            }
            if (txtCode.Text.Trim().Equals(""))
            {
                this.ShowMessage("���������");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim().Equals(""))
            {
                this.ShowMessage("����������");
                txtName.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpVendorTypeID))
            {
                this.ShowMessage("��ѡ��Ӧ��");
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
            ItemTypeRule rule = new ItemTypeRule();
            HttSoft.MLTERP.Data.ItemType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemTypeRule rule = new ItemTypeRule();
            HttSoft.MLTERP.Data.ItemType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            HttSoft.MLTERP.Data.ItemType entity = new HttSoft.MLTERP.Data.ItemType();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text= entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            drpVendorTypeID.EditValue = entity.VendorTypeID;
            if (!findFlag)//����Ĭ��ֵ
            {
                txtID.Text = "";
            }
        }


        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            if (HTFormStatus == FormStatus.�޸�)
            {
                txtID.Properties.ReadOnly = true;
                txtCode.Properties.ReadOnly = true;
            }
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemTypeRule rule = new ItemTypeRule();
            HttSoft.MLTERP.Data.ItemType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_ItemType";
            Common.BindVendorType(drpVendorTypeID, false);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private HttSoft.MLTERP.Data.ItemType EntityGet()
        {
            HttSoft.MLTERP.Data.ItemType entity = new HttSoft.MLTERP.Data.ItemType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Name = txtName.Text.Trim();
            entity.Code = txtCode.Text.Trim();
            entity.VendorTypeID = SysConvert.ToInt32(drpVendorTypeID.EditValue);
            return entity;
        }
        #endregion

        private void txtID_EditValueChanged(object sender, EventArgs e)
        {

        }

   
    }
}