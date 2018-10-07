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
    /// ���ܣ�Ʒ�ƹ�����ϸ
    /// </summary>
    public partial class frmBrandEdit : frmAPBaseUISinEdit
    {
        public frmBrandEdit()
        {
            InitializeComponent();
        }
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
          
            if (txtBrandID.Text.Trim()== "")
            {
                this.ShowMessage("���������");
                txtBrandID.Focus();
                return false;
            }
            if (txtBrandAttn.Text.Trim() == "")
            {
                this.ShowMessage("��������");
                txtBrandAttn.Focus();
                return false;
            }
            if (txtBrandName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtBrandName.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpVendorID))
            {
                this.ShowMessage("������ͻ�");
                drpVendorID.Focus();
                return false;
            }
            if (txtBrandCodeRule.Text.Trim() == "")
            {
                this.ShowMessage("������������");
                txtBrandDesc.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpCompanyTypeID))
            {
                this.ShowMessage("�����빫˾��");
                drpCompanyTypeID.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpSaleOPID))
            {
                this.ShowMessage("������Ӫҵ����");
                drpSaleOPID.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
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
            txtLRJS.Text = entity.LRJS.ToString();//�������  sunxun 20100505
            //�����ֶθ�ֵ ��������ֶ�
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
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            if (HTFormStatus == FormStatus.�޸� || HTFormStatus == FormStatus.��ѯ)
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
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
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
        /// ��ʼ��ˢ������(״�����ʱ���û�ˢ�°�ťʱ����) �����ƶ� 2009-10-31 standy
        /// </summary>
        public override void IniRefreshData()
        {
          
            Common.BindYear(drpBeginYear, 5, 5, true);
            Common.BindCurrency(drpCurrency, true);
            Common.BindCLS(drpPayment, HTDataTableName, "Payment", true);
          
            Common.BindCompanyType(drpCompanyTypeID, false);
            Common.BindDepartment(drpSaleOPDepartment, true);

             //Common.BindDepartment(drpChkDepID,(int)EnumDepartmentType.��Ʒ����, true);


        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
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

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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
            entity.LRJS = SysConvert.ToDecimal(txtLRJS.Text);//�������  sunxun  20100505

            entity.ChkDepID = SysConvert.ToString(drpChkDepID.EditValue);

            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
            }
            //�����ֶθ�ֵ ��������ֶ�
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
        /// ������Ĭ�ϵ���Ʒ�Ƽ��
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
        /// ����������
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
        #region �����¼�����ӡ��أ�
        /// <summary>
        /// ���
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
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.תPDF, new string[] { "ID" }, new string[] { HTDataID.ToString() });
            }
            catch
            {
            }
        }
        /// <summary>
        /// ��ӡ
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
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.��ӡ, new string[] { "ID" }, new string[] { HTDataID.ToString() });
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDesign_Click(sender, e);
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ3))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.���, new string[] { "ID" }, new string[] { HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion
    }
}