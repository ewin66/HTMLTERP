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
    /// 功能：公司别管理表
    /// 作者：刘德苏
    /// 日期：2012-4-20
    /// 操作：新增
    public partial class frmCompanyTypeEdit : frmAPBaseUISinEdit
    {
        public frmCompanyTypeEdit()
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
            CompanyTypeRule rule = new CompanyTypeRule();
            CompanyType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CompanyTypeRule rule = new CompanyTypeRule();
            CompanyType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CompanyType entity = new CompanyType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtOrganizeCode.Text = entity.OrganizeCode.ToString(); 
  			txtTel.Text = entity.Tel.ToString(); 
  			txtFax.Text = entity.Fax.ToString(); 
  			txtAddress.Text = entity.Address.ToString(); 
  			txtZipCode.Text = entity.ZipCode.ToString(); 
  			txtTaxCode.Text = entity.TaxCode.ToString(); 
  			txtBank.Text = entity.Bank.ToString(); 
  			txtAccount.Text = entity.Account.ToString(); 
  			txtBasedCurrency.Text = entity.BasedCurrency.ToString(); 
  			txtDealCurrency.Text = entity.DealCurrency.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtEnName.Text = entity.EnName.ToString(); 
  			txtEnAddress.Text = entity.EnAddress.ToString(); 
  			txtAllName.Text = entity.AllName.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CompanyTypeRule rule = new CompanyTypeRule();
            CompanyType entity = EntityGet();
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
            this.HTDataTableName = "Enum_CompanyType";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CompanyType EntityGet()
        {
            CompanyType entity = new CompanyType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.OrganizeCode = txtOrganizeCode.Text.Trim(); 
  			entity.Tel = txtTel.Text.Trim(); 
  			entity.Fax = txtFax.Text.Trim(); 
  			entity.Address = txtAddress.Text.Trim(); 
  			entity.ZipCode = txtZipCode.Text.Trim(); 
  			entity.TaxCode = txtTaxCode.Text.Trim(); 
  			entity.Bank = txtBank.Text.Trim(); 
  			entity.Account = txtAccount.Text.Trim(); 
  			entity.BasedCurrency = txtBasedCurrency.Text.Trim(); 
  			entity.DealCurrency = txtDealCurrency.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.EnName = txtEnName.Text.Trim(); 
  			entity.EnAddress = txtEnAddress.Text.Trim(); 
  			entity.AllName = txtAllName.Text.Trim(); 
  			
            return entity;
        }
        #endregion

      
    }
}