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
    /// 功能：加工单跟单字段配置表
    /// 
    /// </summary>
    public partial class frmWOFollowFieldSetEdit : frmAPBaseUISinEdit
    {
        public frmWOFollowFieldSetEdit()
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
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            WOFollowFieldSet entity = new WOFollowFieldSet();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpWOFollowTypeID.EditValue = entity.WOFollowTypeID;
  			txtFTableType.Text = entity.FTableType.ToString(); 
  			txtDFieldName.Text = entity.DFieldName.ToString(); 
  			txtDCaption.Text = entity.DCaption.ToString(); 
  			txtDShowFlag.Text = entity.DShowFlag.ToString(); 
  			txtUpdateMainFieldName.Text = entity.UpdateMainFieldName.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
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
            this.HTDataTableName = "Enum_WOFollowFieldSet";
            //

            Common.BindWOFollowType(drpWOFollowTypeID, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private WOFollowFieldSet EntityGet()
        {
            WOFollowFieldSet entity = new WOFollowFieldSet();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WOFollowTypeID = SysConvert.ToInt32(drpWOFollowTypeID.EditValue); 
  			entity.FTableType = SysConvert.ToInt32(txtFTableType.Text.Trim()); 
  			entity.DFieldName = SysConvert.ToInt32(txtDFieldName.Text.Trim()); 
  			entity.DCaption = txtDCaption.Text.Trim(); 
  			entity.DShowFlag = SysConvert.ToInt32(txtDShowFlag.Text.Trim()); 
  			entity.UpdateMainFieldName = txtUpdateMainFieldName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}