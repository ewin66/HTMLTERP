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
    public partial class frmCompactTypeEdit : frmAPBaseUISinEdit
    {
        public frmCompactTypeEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("���������");
                txtCode.Focus();
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
            CompactTypeRule rule = new CompactTypeRule();
            CompactType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CompactTypeRule rule = new CompactTypeRule();
            CompactType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CompactType entity = new CompactType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
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
            CompactTypeRule rule = new CompactTypeRule();
            CompactType entity = EntityGet();
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
            this.HTDataTableName = "Enum_CompactType";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CompactType EntityGet()
        {
            CompactType entity = new CompactType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}