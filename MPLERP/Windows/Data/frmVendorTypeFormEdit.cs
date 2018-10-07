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
    /// 功能：单据客户明细
    /// </summary>
    public partial class frmVendorTypeFormEdit : frmAPBaseUISinEdit
    {
        public frmVendorTypeFormEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCLSA.Text.Trim().Equals(""))
            {
                this.ShowMessage("请输入大类");
                txtCLSA.Focus();
                return false;
            }
            if (txtCLSB.Text.Trim().Equals(""))
            {
                this.ShowMessage("请输入大类");
                txtCLSB.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpVendorTypeID))
            {
                this.ShowMessage("请输入客户");
                drpVendorTypeID.Focus();
                return false;
            } 
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            VendorTypeFormRule rule = new VendorTypeFormRule();
            VendorTypeForm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            VendorTypeFormRule rule = new VendorTypeFormRule();
            VendorTypeForm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            VendorTypeForm entity = new VendorTypeForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCLSA.Text = entity.CLSA.ToString(); 
  			txtCLSB.Text = entity.CLSB.ToString();
            drpVendorTypeID.EditValue = entity.VendorTypeID; 
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
            VendorTypeFormRule rule = new VendorTypeFormRule();
            VendorTypeForm entity = EntityGet();
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
            this.HTDataTableName = "Data_VendorTypeForm";
            //

            Common.BindVendorType(drpVendorTypeID, false);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorTypeForm EntityGet()
        {
            VendorTypeForm entity = new VendorTypeForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim(); 
  			entity.VendorTypeID = SysConvert.ToInt32(drpVendorTypeID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}