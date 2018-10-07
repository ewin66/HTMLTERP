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
    /// ���ܣ�ְλ����
    /// 
    /// </summary>
    public partial class frmDutyEdit : frmAPBaseUISinEdit
    {
        public frmDutyEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
           
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
            DutyRule rule = new DutyRule();
            Duty entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            DutyRule rule = new DutyRule();
            Duty entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Duty entity = new Duty();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
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
            DutyRule rule = new DutyRule();
            Duty entity = EntityGet();
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
            this.HTDataTableName = "Data_Duty";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Duty EntityGet()
        {
            Duty entity = new Duty();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //��TextBox��KeyPress�¼����ж�����ֵ��ASC��,�����Ϊ���־Ͱ�e.Handled��ΪTure,ȡ��KeyPress�¼�,����txtIDֻ����������
            if (e.KeyChar > 57 || (e.KeyChar > 8 && e.KeyChar < 47) || e.KeyChar < 8)
            {
                e.Handled = true;
            }

        }
    }
}