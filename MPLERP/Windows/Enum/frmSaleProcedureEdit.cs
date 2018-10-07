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
    public partial class frmSaleProcedureEdit : frmAPBaseUISinEdit
    {
        public frmSaleProcedureEdit()
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
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入流程名称");
                txtName.Focus();
                return false;
            }

            if (chkJGUseFlag.Checked)//如果加工扣料标志勾选
            {
                if (Common.CheckLookUpEditBlank(drpJGItemTypeID))
                {
                    this.ShowMessage("请输入物品类型");
                    drpJGItemTypeID.Focus();
                    return false;
                }

                if (Common.CheckLookUpEditBlank(drpJGWHIDDefault))
                {
                    this.ShowMessage("请输入默认仓库");
                    drpJGWHIDDefault.Focus();
                    return false;
                }
                if (Common.CheckLookUpEditBlank(drpJGFormListID))
                {
                    this.ShowMessage("请输入仓库单据类型");
                    drpJGFormListID.Focus();
                    return false;
                }

                
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            SaleProcedureRule rule = new SaleProcedureRule();
            SaleProcedure entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SaleProcedureRule rule = new SaleProcedureRule();
            SaleProcedure entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SaleProcedure entity = new SaleProcedure();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString();
            chkShowFlag.Checked = SysConvert.ToBoolean(entity.ShowFlag);
            chkJGUseFlag.Checked = SysConvert.ToBoolean(entity.JGUseFlag);
            chkPackCheckFlag.Checked = SysConvert.ToBoolean(entity.PackCheckFlag);
            drpJGItemTypeID.EditValue = entity.JGItemTypeID;
            drpJGWHIDDefault.EditValue = entity.JGWHIDDefault.ToString();
            drpJGFormListID.EditValue = entity.JGFormListID;
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
            SaleProcedureRule rule = new SaleProcedureRule();
            SaleProcedure entity = EntityGet();
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
            this.HTDataTableName = "Enum_SaleProcedure";

            Common.BindItemType(drpJGItemTypeID, true);
            //Common.BindAllWH(drpJGWHIDDefault, true);
            //Common.BindSubType(drpJGFormListID, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleProcedure EntityGet()
        {
            SaleProcedure entity = new SaleProcedure();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.ShowFlag = SysConvert.ToInt32(chkShowFlag.Checked); 
            entity.PackCheckFlag = SysConvert.ToInt32(chkPackCheckFlag.Checked); 
  			entity.JGUseFlag = SysConvert.ToInt32(chkJGUseFlag.Checked); 
  			entity.JGItemTypeID = SysConvert.ToInt32(drpJGItemTypeID.EditValue);
            entity.JGWHIDDefault = SysConvert.ToString(drpJGWHIDDefault.EditValue);
  			entity.JGFormListID = SysConvert.ToInt32(drpJGFormListID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
  			
            return entity;
        }
        #endregion

        #region 其它事件
        private void drpJGItemTypeID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpJGItemTypeID.EditValue) != 0)
                {
                    Common.BindWHByItemType(drpJGWHIDDefault, SysConvert.ToInt32(drpJGItemTypeID.EditValue), true);
                    Common.BindSubTypeByItemType(drpJGFormListID, SysConvert.ToInt32(drpJGItemTypeID.EditValue), true);
                }
                else
                {
                    Common.BindWHByItemType(drpJGWHIDDefault, -1, true);
                    Common.BindSubTypeByItemType(drpJGFormListID, -1, true);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion


        ///// <summary>
        ///// 重写新增事件，不提供新增功能
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnInsert_Click(object sender, EventArgs e)
        //{
        //    this.ShowMessage("若需要增加数据，请联系软件开发商");
        //    //base.btnInsert_Click(sender, e);
        //}

        ///// <summary>
        ///// 重写删除事件，不提供删除功能
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDelete_Click(object sender, EventArgs e)
        //{
        //    this.ShowMessage("若需要删除数据，请联系软件开发商");
        //    //base.btnDelete_Click(sender, e);
        //}

    }
}