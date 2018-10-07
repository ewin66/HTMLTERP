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
using HttSoft.WinUIBase;


namespace MLTERP
{
    /// <summary>
    /// 功能：品牌管理明细
    /// </summary>
    public partial class frmBrandEdit : frmAPBaseUISinEdit
    {
        public frmBrandEdit()
        {
            InitializeComponent();
        }
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
          
            if (txtBrandID.Text.Trim()== "")
            {
                this.ShowMessage("请输入编码");
                txtBrandID.Focus();
                return false;
            }
            if (txtBrandAttn.Text.Trim() == "")
            {
                this.ShowMessage("请输入简称");
                txtBrandAttn.Focus();
                return false;
            }
            if (txtBrandName.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtBrandName.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpVendorID))
            {
                this.ShowMessage("请输入客户");
                drpVendorID.Focus();
                return false;
            }
            if (txtBrandCodeRule.Text.Trim() == "")
            {
                this.ShowMessage("请输入助记码");
                txtBrandDesc.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpCompanyTypeID))
            {
                this.ShowMessage("请输入公司别");
                drpCompanyTypeID.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpSaleOPID))
            {
                this.ShowMessage("请输入营业担当");
                drpSaleOPID.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Brand entity = new Brand();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            drpVendorID.EditValue = entity.VendorID.ToString();
            drpAttOPID.EditValue = entity.AttOPID.ToString();
            drpBeginYear.EditValue = entity.BeginYear.ToString();
            txtBrandAttn.Text = entity.BrandAttn.ToString();
            txtBrandCodeRule.Text = entity.BrandCodeRule.ToString();
            txtBrandDesc.Text = entity.BrandDesc.ToString();
            txtBrandID.Text = entity.BrandID.ToString();
            txtBrandName.Text = entity.BrandName.ToString();
            txtDesignName.Text = entity.DesignName.ToString();
            txtGoodsDesc.Text = entity.GoodsDesc.ToString();
            txtMD.Text = entity.MD.ToString();
            txtProName.Text = entity.ProName.ToString();
            txtRightName.Text = entity.RightName.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            drpSaleType.EditValue = entity.SaleType.ToString();
            txtShowPlan.Text = entity.ShowPlan.ToString();
            drpBrandCls.EditValue=entity.BrandCls;
            drpUseableFlag.EditValue=entity.UseableFlag;
            drpWOOPID.EditValue = entity.WOOPID.ToString();
            txtLimitBuyQty.Text = entity.LimitBuyQty.ToString();
            drpRequestType.EditValue = entity.RequestType;
            drpFinalType.EditValue = entity.FinalType;
            drpAttnFinalType.EditValue = entity.AttnFinalType;
            drpItemFinalType.EditValue =entity.ItemFinalType;
            drpExitType.EditValue = entity.ExitType;
            txtAttnRequirement.Text = entity.AttnRequirement.ToString();
            drpSSNExpense.EditValue = entity.SSNExpense.ToString();
            txtExpressFinal.Text = entity.ExpressFinal.ToString();
            txtQY.Text = entity.QY.ToString();
            drpCurrency.EditValue = entity.Currency.ToString();
            drpPayment.EditValue = entity.Payment.ToString();
            txtProQty.Text = SysConvert.ToString(entity.ProQty);
            txtContactEMail.Text = entity.ContactEMail.ToString();
            txtContact.Text = entity.Contact.ToString();
            txtVendorDutyOP.Text = entity.VendorDutyOP;
            drpSaleOPDepartment.EditValue = entity.SaleOPDepartment;
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            drpBJOPID.EditValue = entity.BJOPID.ToString();
            chkISSHCheck.EditValue = entity.ISSHCheck;
            drpJSXType.EditValue = entity.JSXType.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtMakeOPID.Text = Common.GetNameByOPID(entity.MakeOPID.ToString());
            drpTecOPID.EditValue = entity.TecOPID.ToString();
            drpChkDepID.EditValue = entity.ChkDepID.ToString();
            txtLRJS.Text = entity.LRJS.ToString();//利润加算  sunxun 20100505
            //备用字段赋值 、不清楚字段
            //txtBeginYear.Text = entity.Free1.ToString();
            //txtBeginYear.Text = entity.Free2.ToString();
            //txtBeginYear.Text = entity.Free3.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            if (txtMakeDate.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtMakeDate.Text = "";
            }
            if (!findFlag)
            {
                txtMakeOPID.Text = FParamConfig.LoginName;
            }
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            if (HTFormStatus == FormStatus.修改 || HTFormStatus == FormStatus.查询)
            {
                ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
                ProcessCtl.ProcControlEdit(new Control[] { txtBrandID }, false);
            }
            else
            {
                ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
                ProcessCtl.ProcControlEdit(new Control[] { txtBrandID }, true);
            }
            ProcessCtl.ProcControlEdit(new Control[] { txtMakeOPID, txtMakeDate }, false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = FParamConfig.SysTime();
            txtMakeOPID.Text = FParamConfig.LoginName;
            drpBeginYear.Text = DateTime.Now.Year.ToString();
            drpUseableFlag.EditValue = 1;
            drpSaleOPID.EditValue = FParamConfig.LoginID;
        }

        /// <summary>
        /// 初始化刷新数据(状体加载时或用户刷新按钮时调用) 代码移动 2009-10-31 standy
        /// </summary>
        public override void IniRefreshData()
        {
          
            Common.BindYear(drpBeginYear, 5, 5, true);
            Common.BindCurrency(drpCurrency, true);
            Common.BindCLS(drpPayment, HTDataTableName, "Payment", true);
          
            Common.BindCompanyType(drpCompanyTypeID, false);
            Common.BindDepartment(drpSaleOPDepartment, true);

             //Common.BindDepartment(drpChkDepID,(int)EnumDepartmentType.检品车间, true);


        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Brand";
            
            SetTabIndex(0, groupControlMainten);
           // IsMakeOPID = true;

           new VendorProc(drpVendorID);
           new VendorProc(drpJSXType);       
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Brand EntityGet()
        {
            Brand entity = new Brand();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.AttOPID = drpAttOPID.EditValue.ToString();
            entity.BeginYear = SysConvert.ToInt32(drpBeginYear.EditValue.ToString());
            entity.BrandAttn = Common.ToDBC(txtBrandAttn.Text.Trim());
            entity.BrandCodeRule = Common.ToDBC(txtBrandCodeRule.Text.Trim());
            entity.BrandDesc = txtBrandDesc.Text.Trim();
            entity.BrandID =Common.ToDBC(txtBrandID.Text.Trim());
            entity.BrandName = Common.ToDBC(txtBrandName.Text.Trim());
            entity.DesignName = txtDesignName.Text.Trim();
            entity.GoodsDesc = txtGoodsDesc.Text.Trim();
            entity.MD = txtMD.Text.Trim();
            entity.ProName = txtProName.Text.Trim();
            entity.RightName = txtRightName.Text.Trim();
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            entity.SaleType = drpSaleType.EditValue.ToString();
            entity.ShowPlan = txtShowPlan.Text.Trim();
            entity.BrandCls = drpBrandCls.EditValue.ToString();
            entity.UseableFlag =SysConvert.ToInt32(drpUseableFlag.EditValue);
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.WOOPID = drpWOOPID.EditValue.ToString();
            entity.LimitBuyQty = SysConvert.ToInt32(txtLimitBuyQty.Text.Trim());
            entity.RequestType =drpRequestType.EditValue.ToString();
            entity.FinalType = drpFinalType.EditValue.ToString();
            entity.ExitType = drpExitType.EditValue.ToString();
            entity.ItemFinalType = drpItemFinalType.EditValue.ToString();
            entity.AttnFinalType = drpAttnFinalType.EditValue.ToString();
            entity.ExpressFinal = txtExpressFinal.Text.Trim();
            entity.SSNExpense = drpSSNExpense.EditValue.ToString();
            entity.AttnRequirement = txtAttnRequirement.Text.Trim();
            entity.Payment = drpPayment.EditValue.ToString();
            entity.Currency = drpCurrency.EditValue.ToString();
            entity.QY = txtQY.Text.Trim();
            entity.ProQty = SysConvert.ToInt32(txtProQty.Text.Trim());
            entity.Contact = txtContact.Text.Trim();
            entity.ContactEMail = txtContactEMail.Text.Trim();
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.SaleOPDepartment = drpSaleOPDepartment.EditValue.ToString();
            entity.VendorDutyOP = txtVendorDutyOP.Text.Trim();
            entity.JSXType = drpJSXType.EditValue.ToString();
            entity.ISSHCheck =SysConvert.ToInt32(chkISSHCheck.EditValue.ToString());
            entity.BJOPID = drpBJOPID.EditValue.ToString();
            entity.Remark = txtRemark.Text.ToString();
            entity.TecOPID = SysConvert.ToString(drpTecOPID.EditValue);
            entity.LRJS = SysConvert.ToDecimal(txtLRJS.Text);//利润加算  sunxun  20100505

            entity.ChkDepID = SysConvert.ToString(drpChkDepID.EditValue);

            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
            }
            //备用字段赋值 、不清楚字段
            entity.Free1 = "";
            entity.Free2 = "";
            entity.Free3 = "";

            if (txtMakeDate.DateTime != SystemConfiguration.DateTimeDefaultValue && txtMakeDate.Text != "")
            {
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
            return entity;
        }
        #endregion

        /// <summary>
        /// 助记码默认等于品牌简称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBrandAttn_Leave(object sender, EventArgs e)
        {
            try
            {
               // if (txtBrandCodeRule.Text.Trim() == "")
               // {
                    txtBrandCodeRule.Text = txtBrandAttn.Text.Trim()+"-";
               // }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 担当带部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSaleOPID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Common.CheckLookUpEditBlank(drpSaleOPID))
                {
                    drpSaleOPDepartment.EditValue = Common.OPIDToDepartment(SysConvert.ToString(drpSaleOPID.EditValue));
                }
            }
            catch(Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region 重载事件（打印相关）
        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPreview_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.转PDF, new string[] { "ID" }, new string[] { HTDataID.ToString() });
            }
            catch
            {
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPrint_Click(sender, e);

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID" }, new string[] { HTDataID.ToString() });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDesign_Click(sender, e);
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交3))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID" }, new string[] { HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion
    }
}