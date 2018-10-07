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
    public partial class frmFOPDepEdit : frmAPBaseUISinEdit
    {
        public frmFOPDepEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtName.Focus();
                return false;
            }

            if (txtCLSA.Text.Trim() == "")
            {
                this.ShowMessage("请输入表名");
                txtCLSA.Focus();
                return false;
            }

            if (txtCLSB.Text.Trim() == "")
            {
                this.ShowMessage("请输入字段名");
                txtCLSB.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpDepID.EditValue) == 0)
            {
                this.ShowMessage("请选择部门");
                drpDepID.Focus();
                return false;
            } 

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FOPDep entity = new FOPDep();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtName.Text = entity.Name.ToString(); 
  			txtCLSA.Text = entity.CLSA.ToString(); 
  			txtCLSB.Text = entity.CLSB.ToString();
            drpDepID.EditValue = entity.DepID; 
  			txtRemark.Text = entity.Remark.ToString();
            //drpFlag.EditValue = entity.XTFlag;

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
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
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            drpFlag.EditValue = 0;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_FOPDep";
            Common.BindDep(drpDepID);
            //

            SetTabIndex(0, groupControlMainten);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FOPDep EntityGet()
        {
            FOPDep entity = new FOPDep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim(); 
  			entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim();
            entity.DepID = SysConvert.ToInt32(drpDepID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim();
            //entity.XTFlag = SysConvert.ToInt32(drpFlag.EditValue);
            return entity;
        }
        #endregion
    }
}