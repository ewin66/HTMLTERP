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
    /// 功能：加工单跟单站别表
    /// 
    /// </summary>
    public partial class frmWOFollowStepEdit : frmAPBaseUISinEdit
    {
        public frmWOFollowStepEdit()
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
            WOFollowStepRule rule = new WOFollowStepRule();
            WOFollowStep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            WOFollowStepRule rule = new WOFollowStepRule();
            WOFollowStep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            WOFollowStep entity = new WOFollowStep();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpWOFollowTypeID.EditValue = entity.WOFollowTypeID;
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtColorStr.Text = entity.ColorStr.ToString(); 
  			txtMainFlag.Text = entity.MainFlag.ToString(); 
  			txtSubFlag.Text = entity.SubFlag.ToString(); 
  			txtSubUpdateMainFlag.Text = entity.SubUpdateMainFlag.ToString(); 
  			txtGnsUpdateSubFlag.Text = entity.GnsUpdateSubFlag.ToString(); 
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
            WOFollowStepRule rule = new WOFollowStepRule();
            WOFollowStep entity = EntityGet();
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
            this.HTDataTableName = "Enum_WOFollowStep";
            //


            Common.BindWOFollowType(drpWOFollowTypeID, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private WOFollowStep EntityGet()
        {
            WOFollowStep entity = new WOFollowStep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WOFollowTypeID = SysConvert.ToInt32(drpWOFollowTypeID.EditValue); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.ColorStr = txtColorStr.Text.Trim(); 
  			entity.MainFlag = SysConvert.ToInt32(txtMainFlag.Text.Trim()); 
  			entity.SubFlag = SysConvert.ToInt32(txtSubFlag.Text.Trim()); 
  			entity.SubUpdateMainFlag = SysConvert.ToInt32(txtSubUpdateMainFlag.Text.Trim()); 
  			entity.GnsUpdateSubFlag = SysConvert.ToInt32(txtGnsUpdateSubFlag.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

       
    }
}