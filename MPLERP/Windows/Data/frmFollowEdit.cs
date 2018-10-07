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
    /// ���ܣ����Ź���
    /// 
    /// </summary>
    public partial class frmFollowEdit : frmAPBaseUISinEdit
    {
        public frmFollowEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
           
            if (txtSort.Text.Trim() == "")
            {
                this.ShowMessage("���������");
                txtSort.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtName.Focus();
                return false;
            }

            if (txtDes.Text.Trim() == "")
            {
                this.ShowMessage("��������Ŀ");
                txtSort.Focus();
                return false;
            }  
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FollowRule rule = new FollowRule();
            Follow entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FollowRule rule = new FollowRule();
            Follow entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Follow entity = new Follow();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtSort.Text = entity.Sort.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtName.Text = entity.Name.ToString();
            txtDes.Text = entity.Des.ToString();
            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FollowRule rule = new FollowRule();
            Follow entity = EntityGet();
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
            this.HTDataTableName = "Data_Follow";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Follow EntityGet()
        {
            Follow entity = new Follow();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Sort = SysConvert.ToInt32(txtSort.Text.Trim());
            entity.Name = txtName.Text.Trim();
            entity.Des = txtDes.Text.Trim();
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        
    }
}