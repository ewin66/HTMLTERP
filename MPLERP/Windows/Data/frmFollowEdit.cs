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
    /// 功能：部门管理
    /// 
    /// </summary>
    public partial class frmFollowEdit : frmAPBaseUISinEdit
    {
        public frmFollowEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
           
            if (txtSort.Text.Trim() == "")
            {
                this.ShowMessage("请输入序号");
                txtSort.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入流程");
                txtName.Focus();
                return false;
            }

            if (txtDes.Text.Trim() == "")
            {
                this.ShowMessage("请输入项目");
                txtSort.Focus();
                return false;
            }  
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FollowRule rule = new FollowRule();
            Follow entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FollowRule rule = new FollowRule();
            Follow entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Follow entity = new Follow();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtSort.Text = entity.Sort.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtName.Text = entity.Name.ToString();
            txtDes.Text = entity.Des.ToString();
            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FollowRule rule = new FollowRule();
            Follow entity = EntityGet();
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
            this.HTDataTableName = "Data_Follow";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Follow EntityGet()
        {
            Follow entity = new Follow();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Sort = SysConvert.ToInt32(txtSort.Text.Trim());
            entity.Name = txtName.Text.Trim();
            entity.Des = txtDes.Text.Trim();
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        
    }
}