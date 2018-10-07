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
    /// ���ܣ�����������
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmMLLBEdit : frmAPBaseUISinEdit
    {
        public frmMLLBEdit()
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
            MLLBRule rule = new MLLBRule();
            MLLB entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            MLLBRule rule = new MLLBRule();
            MLLB entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            MLLB entity = new MLLB();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtRemark.Text = entity.Remark.ToString();
            drpUseableFlag.EditValue = entity.UseableFlag;
            txtSort.Text = entity.Sort.ToString();
            
            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            MLLBRule rule = new MLLBRule();
            MLLB entity = EntityGet();
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
            this.HTDataTableName = "Data_MLLB";
            //
        }

        public override void IniInsertSet()
        {
            drpUseableFlag.EditValue = 1;
            DataTable dt = SysUtils.Fill("select max(Sort)+1 from Data_MLLB");
            txtSort.Text = dt.Rows[0][0].ToString();
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private MLLB EntityGet()
        {
            MLLB entity = new MLLB();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();//����
            entity.Name = txtName.Text.Trim(); //����
  			entity.Remark = txtRemark.Text.Trim(); //��ע
            entity.Sort =SysConvert.ToInt32(txtSort.Text.Trim());//����
            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);//��Ч��
  			
            return entity;
        }
        #endregion

       
    }
}