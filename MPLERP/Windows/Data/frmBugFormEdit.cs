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
    public partial class frmBugFormEdit : frmAPBaseUISinEdit
    {
        public frmBugFormEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToString(drpBugType.EditValue) == "")
            {
                this.ShowMessage("请选择异常类型");
                drpBugType.Focus();
                return false;
            }
            if (SysConvert.ToString(drpStatus.EditValue) == "")
            {
                this.ShowMessage("请选择状态");
                drpStatus.Focus();
                return false;
            } 
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            BugFormRule rule = new BugFormRule();
            BugForm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            BugFormRule rule = new BugFormRule();
            BugForm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            BugForm entity = new BugForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormNo.Text = entity.FormNo.ToString();
             drpMakeOPID.EditValue = entity.MakeOPID;
  			//txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtConFormNo.Text = entity.ConFormNo.ToString();
            drpBugType.EditValue = entity.BugType;
  			//txtBugType.Text = entity.BugType.ToString(); 
            drpStatus.EditValue = entity.Status;
            //txtStatus.Text = entity.Status.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtAutoOPID.Text = entity.AutoOPID.ToString(); 
  			txtAutoDate.DateTime = entity.AutoDate; 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BugFormRule rule = new BugFormRule();
            BugForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Data_BugForm", "FormNo", 0, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_BugForm";
            //
            Common.BindBugStatus(drpStatus, true);
            Common.BindBugType(drpBugType, true);
            Common.BindOP(drpMakeOPID, true);

        }
        public override void IniInsertSet()
        {
            drpMakeOPID.EditValue = FParamConfig.LoginID;
            txtAutoDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private BugForm EntityGet()
        {
            BugForm entity = new BugForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = SysConvert.ToString(drpMakeOPID.EditValue);
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.ConFormNo = txtConFormNo.Text.Trim(); 
  			entity.BugType = SysConvert.ToInt32(drpBugType.EditValue); 
  			entity.Status = SysConvert.ToInt32(drpStatus.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.AutoOPID = txtAutoOPID.Text.Trim(); 
  			entity.AutoDate = txtAutoDate.DateTime.Date; 
  			
            return entity;
        }
        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.异常管理单单号);
                    ProductCommon.FormNoIniSet(txtFormNo, "Data_BugForm", "FormNo", 0);
                }
                
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }
    }
}