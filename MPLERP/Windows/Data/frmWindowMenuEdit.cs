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


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            WindowMenuRule rule = new WindowMenuRule();
            WindowMenu entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            WindowMenuRule rule = new WindowMenuRule();
            WindowMenu entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
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
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WindowMenuRule rule = new WindowMenuRule();
            WindowMenu entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sys_WindowMenu";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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