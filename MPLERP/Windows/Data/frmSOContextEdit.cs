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
    public partial class frmSOContextEdit : frmAPBaseUISinEdit
    {
        public frmSOContextEdit()
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
            if (txtCode.Text.Trim() == string.Empty)
            {
                this.ShowMessage("�������ͬ���ݱ��");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == string.Empty)
            {
                this.ShowMessage("�������ͬ��������");
                txtName.Focus();
                return false;
            }

            if (txtContext.Text.Trim() == string.Empty)
            {
                this.ShowMessage("�������ͬ����");
                txtContext.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            SOContextRule rule = new SOContextRule();
            SOContext entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SOContextRule rule = new SOContextRule();
            SOContext entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SOContext entity = new SOContext();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtContext.Text = entity.Context.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            cmbTextType.Text = entity.Type.ToString();
            drpUseableFlag.EditValue = entity.DelFlag;

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SOContextRule rule = new SOContextRule();
            SOContext entity = EntityGet();
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
            this.HTDataTableName = "Data_SOContext";
            //
            Common.BindCLS(cmbTextType, "Data_SOContext", "Type", true);
        }

        public override void IniInsertSet()
        {
            drpUseableFlag.EditValue = 1;
            cmbTextType.Text = "����";
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SOContext EntityGet()
        {
            SOContext entity = new SOContext();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.Context = txtContext.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.Type = cmbTextType.Text.ToString();
            entity.DelFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            return entity;
        }
        #endregion
    }
}