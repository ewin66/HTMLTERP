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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：参数管理表
    /// 作者：刘德苏
    /// 日期：2012-4-19
    /// 操作：新增
    /// </summary>
    public partial class frmParamSetEdit : frmAPBaseUISinEdit
    {
        public frmParamSetEdit()
        {
            InitializeComponent();
        }

        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "修改", false, btnUpdate_Click, eShortcut.F2);//eShortcut.F2
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "保存", false, btnSave_Click, eShortcut.F4);//F4
            this.ToolBarItemAdd(5, ToolButtonName.btnCancel.ToString(), "放弃", false, btnCancel_Click, eShortcut.F5);


            this.ToolBarItemAdd(15, ToolButtonName.btnFirst.ToString(), "首页", true, btnFirst_Click, eShortcut.CtrlUp);
            this.ToolBarItemAdd(16, ToolButtonName.btnPre.ToString(), "上页", false, btnPre_Click, eShortcut.CtrlLeft);
            this.ToolBarItemAdd(17, ToolButtonName.btnNext.ToString(), "下页", false, btnNext_Click, eShortcut.CtrlRight);
            this.ToolBarItemAdd(18, ToolButtonName.btnLast.ToString(), "末页", false, btnLast_Click, eShortcut.CtrlDown);



            this.ToolBarItemAdd(7, ToolButtonName.btnClose.ToString(), "退出", true, btnClose_Click, eShortcut.F12);
        }
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim().Equals(""))
            {
                this.ShowMessage("请输入参数编码");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim().Equals(""))
            {
                this.ShowMessage("请输入参数名称");
                txtName.Focus();
                return false;
            }
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ParamSetRule rule = new ParamSetRule();
            ParamSet entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ParamSetRule rule = new ParamSetRule();
            ParamSet entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ParamSet entity = new ParamSet();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtSetValueStr.Text = entity.SetValueStr.ToString(); 
  			txtSetValueInt.Text = entity.SetValueInt.ToString(); 
  			txtSetValueDt.DateTime = entity.SetValueDt; 
  			txtRemark.Text = entity.Remark.ToString();
            if (txtSetValueDt.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtSetValueDt.Text = "";
            }
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
            ParamSetRule rule = new ParamSetRule();
            ParamSet entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            if (HTFormStatus == FormStatus.修改)
            {
                txtCode.Properties.ReadOnly = true;
            }
        }
        public override void IniInsertSet()
        {
            txtSetValueDt.DateTime = DateTime.Now.Date;
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sys_ParamSet";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ParamSet EntityGet()
        {
            ParamSet entity = new ParamSet();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.SetValueStr = txtSetValueStr.Text.Trim(); 
  			entity.SetValueInt = SysConvert.ToInt32(txtSetValueInt.Text.Trim());
            if (txtSetValueDt.Text != string.Empty)
            {
                entity.SetValueDt = txtSetValueDt.DateTime.Date;
            }
            entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}