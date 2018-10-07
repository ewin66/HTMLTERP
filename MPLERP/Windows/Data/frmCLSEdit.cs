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
    public partial class frmCLSEdit : frmAPBaseUISinEdit
    {
        public frmCLSEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCLSIDC.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtCLSIDC.Focus();
            //    return false;
            //}
            if (txtCLSNM.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtCLSNM.Focus();
                return false;
            }
            if (SysConvert.ToString(drpCLSList.EditValue) == "")
            {
                this.ShowMessage("����������");
                drpCLSList.Focus();
                return false;
            }
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CLS entity = new CLS();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCLSIDC.Text = entity.CLSIDC.ToString();
            txtCLSNM.Text = entity.CLSNM.ToString();
            txtRemark.Text = entity.Remark.ToString();
            drpCLSList.EditValue = entity.CLSListID;
            //txtFCode.Text = entity.FCode;
            if (!findFlag)//����Ĭ��ֵ
            {
            }
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CLS";
            Common.BindCLSList(drpCLSList, true);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CLS EntityGet()
        {
            CLS entity = new CLS();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CLSIDC = txtCLSIDC.Text.Trim();
            entity.CLSNM = txtCLSNM.Text.Trim();
            //entity.CLSNMEn = txtCLSNMEn.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.CLSListID = SysConvert.ToInt32(drpCLSList.EditValue);
            //entity.FCode = txtFCode.Text.Trim();
            return entity;
        }
        #endregion
    }
}