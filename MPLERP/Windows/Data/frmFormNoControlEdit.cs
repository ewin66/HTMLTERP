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
    public partial class frmFormNoControlEdit : frmAPBaseUISinEdit
    {
        public frmFormNoControlEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("请输入ID");
                txtID.Focus();
                return false;
            }
            if (txtFormNM.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtFormNM.Focus();
                return false;
            }            
            return true;
        }

        public override void IniInsertSet()
        {
            drpSourceFlag.EditValue = 0;
        }
        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FormNoControlRule rule = new FormNoControlRule();
            FormNoControl entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FormNoControlRule rule = new FormNoControlRule();
            FormNoControl entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FormNoControl entity = new FormNoControl();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString(); 
  			txtNoType.Text = entity.NoType.ToString(); 
  			txtFormNM.Text = entity.FormNM.ToString(); 
  			txtFormRuleSpecial.Text = entity.FormRuleSpecial.ToString(); 
  			txtFormRulePre.Text = entity.FormRulePre.ToString(); 
  			txtFormRuleSort.Text = entity.FormRuleSort.ToString(); 
  			txtCurSort.Text = entity.CurSort.ToString(); 
  			txtCurYear.Text = entity.CurYear.ToString(); 
  			txtCurMonth.Text = entity.CurMonth.ToString(); 
  			txtCurDay.Text = entity.CurDay.ToString(); 
  			txtDTableName.Text = entity.DTableName.ToString(); 
  			txtDFieldName.Text = entity.DFieldName.ToString(); 
  			txtCondition.Text = entity.Condition.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpSourceFlag.EditValue = entity.SourceFlag;

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FormNoControlRule rule = new FormNoControlRule();
            FormNoControl entity = EntityGet();
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
            this.HTDataTableName = "Enum_FormNoControl";
            Common.BindFormNoType(drpSourceFlag, true);
            SetTabIndex(0, groupControlMainten);

            //
        }



        /// <summary>
        /// 编辑单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }


        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FormNoControl EntityGet()
        {
            FormNoControl entity = new FormNoControl();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim(); 
  			entity.NoType = SysConvert.ToInt32(txtNoType.Text.Trim()); 
  			entity.FormNM = txtFormNM.Text.Trim(); 
  			entity.FormRuleSpecial = txtFormRuleSpecial.Text.Trim(); 
  			entity.FormRulePre = txtFormRulePre.Text.Trim(); 
  			entity.FormRuleSort = txtFormRuleSort.Text.Trim(); 
  			entity.CurSort = SysConvert.ToInt32(txtCurSort.Text.Trim()); 
  			entity.CurYear = SysConvert.ToInt32(txtCurYear.Text.Trim()); 
  			entity.CurMonth = SysConvert.ToInt32(txtCurMonth.Text.Trim()); 
  			entity.CurDay = SysConvert.ToInt32(txtCurDay.Text.Trim()); 
  			entity.DTableName = txtDTableName.Text.Trim(); 
  			entity.DFieldName = txtDFieldName.Text.Trim(); 
  			entity.Condition = txtCondition.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.SourceFlag = SysConvert.ToInt32(drpSourceFlag.EditValue);
  			
            return entity;
        }
        #endregion
    }
}