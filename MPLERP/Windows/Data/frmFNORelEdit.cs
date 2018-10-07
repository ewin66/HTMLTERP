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
    public partial class frmFNORelEdit : frmAPBaseUISinEdit
    {
        public frmFNORelEdit()
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
            FNORelRule rule = new FNORelRule();
            FNORel entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FNORelRule rule = new FNORelRule();
            FNORel entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FNORel entity = new FNORel();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtName.Text = entity.Name.ToString(); 
  			txtCLSA.Text = entity.CLSA.ToString(); 
  			txtCLSB.Text = entity.CLSB.ToString(); 
  			drpFormNoControlID.EditValue = entity.FormNoControlID; 
  			txtRemark.Text = entity.Remark.ToString();
            txtSubTypeID.Text = entity.SubTypeID.ToString();       
            chkSelfEditFlag.Checked = SysConvert.ToBoolean(entity.SelfEditFlag);

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FNORelRule rule = new FNORelRule();
            FNORel entity = EntityGet();
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
            this.HTDataTableName = "Data_FNORel";
            Common.BindFormNoControl(drpFormNoControlID, true);
            //
            SetTabIndex(0, groupControlMainten);

            lbDes1.Text = "用于单据打开多窗体会有多个流水号使用";
            lbDes2.Text = "勾选时标识不自动获取编号，人工修改";
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FNORel EntityGet()
        {
            FNORel entity = new FNORel();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim(); 
  			entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim(); 
  			entity.FormNoControlID = SysConvert.ToInt32(drpFormNoControlID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.SelfEditFlag = SysConvert.ToInt32(chkSelfEditFlag.Checked);
            entity.SubTypeID = SysConvert.ToInt32(txtSubTypeID.Text);
  			
            return entity;
        }
        #endregion
    }
}