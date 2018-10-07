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
    /// ���ܣ�����Ŀ������ϸ
    /// 
    /// </summary>
    public partial class frmItemBaseCheckItemEdit : frmAPBaseUISinEdit
    {
        public frmItemBaseCheckItemEdit()
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
            ItemBaseCheckItemRule rule = new ItemBaseCheckItemRule();
            ItemBaseCheckItem entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemBaseCheckItemRule rule = new ItemBaseCheckItemRule();
            ItemBaseCheckItem entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ItemBaseCheckItem entity = new ItemBaseCheckItem();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtName.Text = entity.Name.ToString();
            txtCode.Text = entity.Code.ToString();
            txtCLSA.Text = entity.CLSA.ToString();
            txtCLSB.Text = entity.CLSB.ToString();


            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemBaseCheckItemRule rule = new ItemBaseCheckItemRule();
            ItemBaseCheckItem entity = EntityGet();
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
            this.HTDataTableName = "Data_ItemBaseCheckItem";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBaseCheckItem EntityGet()
        {
            ItemBaseCheckItem entity = new ItemBaseCheckItem();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.CLSA = txtCLSA.Text.Trim();
            entity.CLSB = txtCLSB.Text.Trim(); 
  			
            return entity;
        }
        #endregion

    }
}