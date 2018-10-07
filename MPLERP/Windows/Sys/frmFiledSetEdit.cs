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
    /// ���ܣ����ֶ�����
    /// 
    /// 
    /// </summary>
    public partial class frmFiledSetEdit : frmAPBaseUISinEdit
    {
        public frmFiledSetEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToInt32(txtFormID.Text.Trim())==0)
            {
                this.ShowMessage("������ҳ��ID");
                txtFormID.Focus();
                return false;
            }

            if (SysConvert.ToString(txtName.Text.Trim()) == "")
            {
                this.ShowMessage("����������");
                txtName.Focus();
                return false;
            }

            if (SysConvert.ToString(txtFiledName.Text.Trim()) =="")
            {
                this.ShowMessage("�������ֶ�");
                txtFiledName.Focus();
                return false;
            }

            if (SysConvert.ToString(txtFiledType.Text.Trim()) == "")
            {
                this.ShowMessage("�������ֶ�����");
                txtFiledType.Focus();
                return false;
            }  

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FiledSetRule rule = new FiledSetRule();
            FiledSet entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FiledSetRule rule = new FiledSetRule();
            FiledSet entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FiledSet entity = new FiledSet();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormID.Text = entity.FormID.ToString();
             txtFAID.Text = entity.FAID.ToString();
             txtFBID.Text = entity.FBID.ToString(); 
  			txtSort.Text = entity.Sort.ToString(); 
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtFiledName.Text = entity.FiledName.ToString(); 
  			txtFiledType.Text = entity.FiledType.ToString(); 
  			drpBindType.EditValue =SysConvert.ToInt32( entity.BindType); 
  			txtLength.Text = entity.Length.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();

            drpUseableFlag.EditValue = entity.UseableFlag;
            drpUpDateFlag.EditValue = entity.UpDateFlag;
            txtMainTable.Text = entity.MainTable;
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FiledSetRule rule = new FiledSetRule();
            FiledSet entity = EntityGet();
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
        /// ������ʼ��
        /// </summary>
        public override void IniInsertSet()
        {
            drpUpDateFlag.EditValue = 1;
            drpUseableFlag.EditValue = 1;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sys_FiledSet";
            //

            Common.BindCLSList(drpBindType,true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FiledSet EntityGet()
        {
            FiledSet entity = new FiledSet();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormID = SysConvert.ToInt32(txtFormID.Text.Trim());
            entity.FAID = SysConvert.ToInt32(txtFAID.Text.Trim());
            entity.FBID = SysConvert.ToInt32(txtFBID.Text.Trim()); 
  			entity.Sort = SysConvert.ToInt32(txtSort.Text.Trim()); 
  			entity.Code = SysConvert.ToInt32(txtCode.Text.Trim()); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.FiledName = txtFiledName.Text.Trim(); 
  			entity.FiledType = txtFiledType.Text.Trim();
            entity.BindType = SysConvert.ToString(drpBindType.EditValue);
  			entity.Length = SysConvert.ToInt32(txtLength.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();

            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            entity.UpDateFlag = SysConvert.ToInt32(drpUpDateFlag.EditValue);
            entity.MainTable = txtMainTable.Text.Trim();
  			
            return entity;
        }
        #endregion
    }
}