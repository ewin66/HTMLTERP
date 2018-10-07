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
    public partial class frmSampleTypeEdit : frmAPBaseUISinEdit
    {
        public frmSampleTypeEdit()
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
                txtID.Focus();
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
            SampleTypeRule rule = new SampleTypeRule();
            SampleType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SampleTypeRule rule = new SampleTypeRule();
            SampleType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SampleType entity = new SampleType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtID.Text = entity.ID.ToString();            
            txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtNameEn.Text = entity.NameEn.ToString(); 
  			txtNameJP.Text = entity.NameJP.ToString();
            drpTecClass.EditValue = entity.TecClass.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtUnitPrice.Text = entity.UnitPrice.ToString();
            txtPeriod.Text = entity.Period.ToString();
            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SampleTypeRule rule = new SampleTypeRule();
            SampleType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            if (HTFormStatus == FormStatus.�޸�)
            {
                ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
                ProcessCtl.ProcControlEdit(new Control[] { txtID }, false);
            }
            else
            {
                ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
                ProcessCtl.ProcControlEdit(new Control[] { txtID }, true);
            }
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_SampleType";
            //
            Common.BindCLS(drpTecClass, HTDataTableName, "TecClass", true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SampleType EntityGet()
        {
            SampleType entity = new SampleType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.NameEn = txtNameEn.Text.Trim(); 
  			entity.NameJP = txtNameJP.Text.Trim();
            entity.TecClass = drpTecClass.EditValue.ToString();
            entity.Period = SysConvert.ToDecimal(txtPeriod.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.UnitPrice = SysConvert.ToDecimal(txtUnitPrice.Text.Trim());
            return entity;
        }
        #endregion
    }
}