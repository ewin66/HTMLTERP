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
    /// ���ܣ�ԭ�Ϲ���
    /// ���ߣ�����÷
    /// ���ڣ�2012-04-24
    /// ����������
    /// </summary>
    
    
    
    public partial class frmMLYLEdit : frmAPBaseUISinEdit
    {
        public frmMLYLEdit()
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
           
            MLYLRule rule = new MLYLRule();
            MLYL entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
           
            MLYLRule rule = new MLYLRule();
            MLYL entity = EntityGet();
            rule.RUpdate(entity);
            
            
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            MLYL entity = new MLYL();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtSort.Text = entity.Sort.ToString(); 
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpUseableFlag.EditValue = entity.UseableFlag;
            

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            MLYLRule rule = new MLYLRule();
            MLYL entity = EntityGet();
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
            this.HTDataTableName = "Data_MLYL";
            //
            
            
        }

        public override void IniInsertSet()
        {
            drpUseableFlag.EditValue = 1;
            DataTable dt = SysUtils.Fill("select max(Sort)+1 from Data_MLYL");
            txtSort.Text = dt.Rows[0][0].ToString();
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private MLYL EntityGet()
        {
            MLYL entity = new MLYL();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Sort = SysConvert.ToInt32(txtSort.Text.Trim()); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue); 
  			
            return entity;
        }

       
        #endregion

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtRemark_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}