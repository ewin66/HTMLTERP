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
    public partial class frmCompanyContactEdit : frmAPBaseUISinEdit
    {
        public frmCompanyContactEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (Common.CheckLookUpEditBlank(drpCompanyID))
            {
                this.ShowMessage("请输入公司别");
                drpCompanyID.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpDepID))
            {
                this.ShowMessage("请输入部门");
                drpDepID.Focus();
                return false;
            }
            if (txtTel.Text.Trim().Equals(""))
            {
                this.ShowMessage("请输入电话");
                txtTel.Focus();
                return false;
            }        

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CompanyContact entity = new CompanyContact();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             drpCompanyID.EditValue = entity.CompanyID; 
  			drpDepID.EditValue = entity.DepID; 
  			txtTel.Text = entity.Tel.ToString(); 
  			txtFax.Text = entity.Fax.ToString(); 
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
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
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
            this.HTDataTableName = "Data_CompanyContact";
            //
            Common.BindCompanyType(drpCompanyID, false);
            Common.BindDep(drpDepID, false);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CompanyContact EntityGet()
        {
            CompanyContact entity = new CompanyContact();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CompanyID = SysConvert.ToInt32(drpCompanyID.EditValue); 
  			entity.DepID = SysConvert.ToInt32(drpDepID.EditValue); 
  			entity.Tel = txtTel.Text.Trim(); 
  			entity.Fax = txtFax.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}