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
    public partial class frmAuthGrpEdit : frmAPBaseUISinEdit
    {
        public frmAuthGrpEdit()
        {
            InitializeComponent();
        }
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("������ID");
                txCode.Focus();
                return false;
            }
            if (txCode.Text.Trim() == "")
            {
                this.ShowMessage("���������");
                txCode.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
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
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            AuthGrp entity = new AuthGrp();
            entity.ID = HTDataID;
            txtID.Text = entity.ID.ToString();
            bool findFlag = entity.SelectByID();
            txCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            drpIsDefaultFlag.EditValue = entity.IsDefaultFlag;
            if (!findFlag)//����Ĭ��ֵ
            {
            }
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControl1, p_Flag);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_AuthGrp";

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private AuthGrp EntityGet()
        {
            AuthGrp entity = new AuthGrp();
            entity.ID = HTDataID;
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.SelectByID();
            entity.Code = txCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.IsDefaultFlag = SysConvert.ToInt32(drpIsDefaultFlag.EditValue);

            return entity;
        }
        #endregion
    }
}