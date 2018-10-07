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
    public partial class frmFQCEdit : frmAPBaseUIFormEdit
    {
        public frmFQCEdit()
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
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FQC entity = new FQC();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
          
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			
  			txtDNoInvoiceQty.Text = entity.DNoInvoiceQty.ToString(); 
  			txtDNoInvoiceAmount.Text = entity.DNoInvoiceAmount.ToString(); 
  			txtExAmount.Text = entity.ExAmount.ToString(); 
  			
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			
  			txtRemark.Text = entity.Remark.ToString();
            drpVendorID.EditValue = entity.VendorID;

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
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
            this.HTDataTableName = "Finance_FQC";
            if (this.FormListAID == (int)EnumRecPayType.收款)
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            }
            else
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
            }
            new VendorProc(drpVendorID);
            //
        }

        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FQC EntityGet()
        {
            FQC entity = new FQC();
            entity.ID = HTDataID;
            entity.SelectByID();
           
  			entity.FormNo = txtFormNo.Text.Trim();
            entity.VendorID = drpVendorID.EditValue.ToString();
  			entity.DNoInvoiceQty = SysConvert.ToDecimal(txtDNoInvoiceQty.Text.Trim()); 
  			entity.DNoInvoiceAmount = SysConvert.ToDecimal(txtDNoInvoiceAmount.Text.Trim()); 
  			entity.ExAmount = SysConvert.ToDecimal(txtExAmount.Text.Trim());
            entity.RecPayTypeID = this.FormListAID;
  			entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.FormDate = txtMakeDate.DateTime;
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}