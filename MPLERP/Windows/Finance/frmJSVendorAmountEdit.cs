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
    public partial class frmJSVendorAmountEdit : frmAPBaseUISinEdit
    {
        public frmJSVendorAmountEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择结算单位");
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            JSVendorAmountRule rule = new JSVendorAmountRule();
            JSVendorAmount entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            JSVendorAmountRule rule = new JSVendorAmountRule();
            JSVendorAmount entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            JSVendorAmount entity = new JSVendorAmount();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpVendorID.EditValue = entity.VendorID;
  			txtBQty.Text = entity.BQty.ToString(); 
  			txtBAmount.Text = entity.BAmount.ToString(); 
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
            JSVendorAmountRule rule = new JSVendorAmountRule();
            JSVendorAmount entity = EntityGet();
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
            this.HTDataTableName = "Finance_JSVendorAmount";
            switch (FormListAID)
            {
                case 1:
                    lbVendor.Text = "客户";
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                    new VendorProc(drpVendorID);
                    break;
                case 2:
                    lbVendor.Text = "工厂";
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
                    new VendorProc(drpVendorID);
                    break;

            }
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private JSVendorAmount EntityGet()
        {
            JSVendorAmount entity = new JSVendorAmount();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.BQty = SysConvert.ToDecimal(txtBQty.Text.Trim()); 
  			entity.BAmount = SysConvert.ToDecimal(txtBAmount.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.UpdateOP = FParamConfig.LoginName;
            entity.UpdateDate = DateTime.Now;
  			
            return entity;
        }
        #endregion
    }
}