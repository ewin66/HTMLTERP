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
    /// ���ܣ��ͻ���ˮ����ϸ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-17
    /// ����������
    /// </summary>
    public partial class frmFormNCVendorEdit : frmAPBaseUISinEdit
    {
        public frmFormNCVendorEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ͻ�");
                drpVendorID.Focus();
                return false;
            }   

            if (SysConvert.ToString(drpFNCVID.EditValue) == "")
            {
                this.ShowMessage("��ѡ�񵥾�");
                drpFNCVID.Focus();
                return false;
            }

                  
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FormNCVendor entity = new FormNCVendor();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            drpVendorID.EditValue = entity.VendorID;
            drpFNCVID.EditValue = entity.FNCVID;
            txtCurSort.Text = entity.CurSort.ToString();
            txtCurYear.Text = entity.CurYear.ToString();
            txtCurMonth.Text = entity.CurMonth.ToString();
            txtCurDay.Text = entity.CurDay.ToString();
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
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
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
            this.HTDataTableName = "Data_FormNCVendor";
            Common.BindFNCV(drpFNCVID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);//�ͻ�
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FormNCVendor EntityGet()
        {
            FormNCVendor entity = new FormNCVendor();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FNCVID = SysConvert.ToInt32(drpFNCVID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.CurYear =SysConvert.ToInt32(txtCurYear.Text.ToString());
            entity.CurMonth =SysConvert.ToInt32(txtCurMonth.Text.ToString());
            entity.CurDay = SysConvert.ToInt32(txtCurMonth.Text.ToString());
            entity.CurSort = SysConvert.ToInt32(txtCurSort.Text.ToString());
            entity.Remark = txtRemark.Text.ToString();
            return entity;
        }
        #endregion

       
    }
}