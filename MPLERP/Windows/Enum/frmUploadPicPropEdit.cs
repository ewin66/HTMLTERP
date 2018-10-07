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
    public partial class frmUploadPicPropEdit : frmAPBaseUISinEdit
    {
        public frmUploadPicPropEdit()
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
            UploadPicPropRule rule = new UploadPicPropRule();
            UploadPicProp entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            UploadPicPropRule rule = new UploadPicPropRule();
            UploadPicProp entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            UploadPicProp entity = new UploadPicProp();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtPicWidth.Text = entity.PicWidth.ToString();
            txtPicHeight.Text = entity.PicHeight.ToString();
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
            UploadPicPropRule rule = new UploadPicPropRule();
            UploadPicProp entity = EntityGet();
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
            this.HTDataTableName = "Enum_UploadPicProp";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private UploadPicProp EntityGet()
        {
            UploadPicProp entity = new UploadPicProp();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.PicWidth = SysConvert.ToInt32(txtPicWidth.Text.Trim());
            entity.PicHeight = SysConvert.ToInt32(txtPicHeight.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();

            return entity;
        }
        #endregion
    }
}