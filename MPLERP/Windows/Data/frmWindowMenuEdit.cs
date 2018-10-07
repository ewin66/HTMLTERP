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
    public partial class frmWindowMenuEdit : frmAPBaseUISinEdit
    {
        public frmWindowMenuEdit()
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

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            WindowMenuRule rule = new WindowMenuRule();
            WindowMenu entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            WindowMenuRule rule = new WindowMenuRule();
            WindowMenu entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            WindowMenu entity = new WindowMenu();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtWinListID.Text = entity.WinListID.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtParentID.Text = entity.ParentID.ToString(); 
  			txtSort.Text = entity.Sort.ToString(); 
  			txtHttFlag.Text = entity.HttFlag.ToString(); 
  			txtShowFlag.Text = entity.ShowFlag.ToString(); 
  			txtSystemTypeID.Text = entity.SystemTypeID.ToString(); 
  			txtShortCutChar.Text = entity.ShortCutChar.ToString(); 
  			txtHeadTypeID.Text = entity.HeadTypeID.ToString(); 
  			txtSubTypeID.Text = entity.SubTypeID.ToString(); 
  			txtModuleFlowID.Text = entity.ModuleFlowID.ToString(); 
  			txtMenuTypeID.Text = entity.MenuTypeID.ToString(); 
  			txtUseTypeID.Text = entity.UseTypeID.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WindowMenuRule rule = new WindowMenuRule();
            WindowMenu entity = EntityGet();
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
            this.HTDataTableName = "Sys_WindowMenu";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WindowMenu EntityGet()
        {
            WindowMenu entity = new WindowMenu();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WinListID = SysConvert.ToInt32(txtWinListID.Text.Trim());
            entity.Name = txtName.Text.Trim();
            entity.ParentID = SysConvert.ToInt32(txtParentID.Text.Trim());
            entity.Sort = SysConvert.ToInt32(txtSort.Text.Trim());
            entity.HttFlag = SysConvert.ToInt32(txtHttFlag.Text.Trim());
            entity.ShowFlag = SysConvert.ToInt32(txtShowFlag.Text.Trim());
            entity.SystemTypeID = SysConvert.ToInt32(txtSystemTypeID.Text.Trim());
            entity.ShortCutChar = txtShortCutChar.Text.Trim();
            entity.HeadTypeID = SysConvert.ToInt32(txtHeadTypeID.Text.Trim());
            entity.SubTypeID = SysConvert.ToInt32(txtSubTypeID.Text.Trim());
            entity.ModuleFlowID = SysConvert.ToInt32(txtModuleFlowID.Text.Trim());
            entity.MenuTypeID = SysConvert.ToInt32(txtMenuTypeID.Text.Trim());
            entity.UseTypeID = SysConvert.ToInt32(txtUseTypeID.Text.Trim());

            return entity;
        }
        #endregion

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtMenuTypeID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}