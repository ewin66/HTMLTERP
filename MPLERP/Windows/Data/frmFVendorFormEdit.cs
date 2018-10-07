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
    public partial class frmFVendorFormEdit : frmAPBaseUISinEdit
    {
        public frmFVendorFormEdit()
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
                this.ShowMessage("请输入表明");
                txtCLSA.Focus();
                return false;
            }

            if (txtCLSB.Text.Trim() == "")
            {
                this.ShowMessage("请输入字段名");
                txtCLSB.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpVendorTypeID.EditValue) == 0)
            {
                this.ShowMessage("请选择客户类型");
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
            FVendorFormRule rule = new FVendorFormRule();
            FVendorForm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FVendorFormRule rule = new FVendorFormRule();
            FVendorForm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FVendorForm entity = new FVendorForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtName.Text = entity.Name.ToString(); 
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
            FVendorFormRule rule = new FVendorFormRule();
            FVendorForm entity = EntityGet();
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
            this.HTDataTableName = "Data_FVendorForm";
            Common.BindVendorType(drpVendorTypeID, true);
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FVendorForm EntityGet()
        {
            FVendorForm entity = new FVendorForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim(); 
  			entity.CLSA = txtCLSA.Text.Trim(); 
  			entity.CLSB = txtCLSB.Text.Trim(); 
  			entity.VendorTypeID = SysConvert.ToInt32(drpVendorTypeID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}