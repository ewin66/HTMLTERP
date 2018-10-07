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
    public partial class frmCapPlanEdit : frmAPBaseUIFormEdit
    {
        public frmCapPlanEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}

            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入编号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpPlanOPID.EditValue) == "")
            {
                this.ShowMessage("请选择业务员");
                drpPlanOPID.Focus();
                return false;
            }
  


            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            CapPlanDtsRule rule = new CapPlanDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CapPlanRule rule = new CapPlanRule();
            CapPlan entity = EntityGet();
            CapPlanDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CapPlanRule rule = new CapPlanRule();
            CapPlan entity = EntityGet();
            CapPlanDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CapPlan entity = new CapPlan();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			
  			txtFormNo.Text = entity.FormNo.ToString();
            drpPlanOPID.EditValue = entity.PlanOPID;
  			txtFormDate.DateTime = entity.FormDate; 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtCheckOPID.Text = entity.CheckOPID.ToString(); 
  			txtCheckDate.DateTime = entity.CheckDate; 
  			txtCapPlanTypeID.Text = entity.CapPlanTypeID.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CapPlanRule rule = new CapPlanRule();
            CapPlan entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
             base.IniInsertSet();
             txtFormDate.DateTime = DateTime.Now.Date;
             txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CapPlan";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"VendorID"};//数据明细校验必须录入字段
            Common.BindOP(drpPlanOPID, true);
            Common.BindVendor(drpVendor2, new int[] { (int)EnumVendorType.工厂}, true);
            new VendorProc(drpVendor2);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.客户 }, true);
            Common.BindVendorName(drpVendorName, true);
            switch (this.FormListAID)
            {
                case 1:
                    lbVendor.Visible = false;
                    drpVendor2.Visible = false;
                    break;
                case 2:
                    lbVendor.Visible = true;
                    drpVendor2.Visible = true;
                    break;
            }
            
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CapPlan EntityGet()
        {
            CapPlan entity = new CapPlan();
            entity.ID = HTDataID;
            entity.SelectByID();
            
           
  			entity.FormNo = txtFormNo.Text.Trim();
            entity.PlanOPID = SysConvert.ToString(drpPlanOPID.EditValue);
  			entity.FormDate = txtFormDate.DateTime.Date;
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = DateTime.Now.Date;
            entity.CapPlanTypeID = this.FormListAID;
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CapPlanDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CapPlanDts[] entitydts = new CapPlanDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CapPlanDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID")); 
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }
                    
                    entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID")); 
  			 		entitydts[index].InvoiceAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InvoiceAmount")); 
  			 		entitydts[index].NoInvoiceAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "NoInvoiceAmount")); 
  			 		entitydts[index].TotalNeedPay = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalNeedPay")); 
  			 		entitydts[index].PlanInvoiceAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PlanInvoiceAmount")); 
  			 		entitydts[index].PlanRecAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PlanRecAmount")); 
  			 		entitydts[index].PlanLeaveAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PlanLeaveAmount")); 
  			 		entitydts[index].PlanSaleAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PlanSaleAmount")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].NoInvoiceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "NoInvoiceQty")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus ==FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text=rule.RGetFormNo((int)FormNoControlEnum.资金计划表编号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJS_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    string tempstr = "";
                    string sql = "";
                    switch (this.FormListAID)
                    {
                        case 1:
                            tempstr += " AND VendorTypeID="+(int)EnumVendorType.客户;
                            if (SysConvert.ToString(drpPlanOPID.EditValue) != "")
                            {
                                tempstr += " AND InSaleOP=" + SysString.ToDBString(drpPlanOPID.EditValue.ToString());
                            }
                            sql = "EXEC USP1_Finance_CapPlan " + SysString.ToDBString(tempstr) + ",'2012-01-01'," + SysString.ToDBString(txtFormDate.DateTime);
                            DataTable dt = SysUtils.Fill(sql);
                            gridView1.GridControl.DataSource = dt;
                            gridView1.GridControl.Show();
                            break;
                        case 2:
                            tempstr += " AND VendorTypeID=" + (int)EnumVendorType.工厂;
                            if (SysConvert.ToString(drpVendor2.EditValue) != "")
                            {
                                tempstr += " AND VendorID="+SysString.ToDBString(drpVendor2.EditValue.ToString());
                            }
                            sql = "EXEC USP1_Finance_CapPlan2 " + SysString.ToDBString(tempstr) + ",'2012-01-01'," + SysString.ToDBString(txtFormDate.DateTime);
                            DataTable dto = SysUtils.Fill(sql);
                            gridView1.GridControl.DataSource = dto;
                            gridView1.GridControl.Show();
                            break;
                    }
                   
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtInvoiceAmount_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VendorID"));
                string makedates = "2012-01-01";
                string makedatee = txtFormDate.DateTime.ToString("yyyy-MM-dd");
                frmCapInvoiceAmount frm = new frmCapInvoiceAmount();
                frm.VendorID = VendorID;
                frm.CapFlag = FormListAID;
                frm.Makedates = makedates;
                frm.Makedatee = makedatee;
                frm.Totalamount = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceAmount"));
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtNoInvoiceQty_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VendorID"));
                string makedates = "2012-01-01";
                string makedatee = txtFormDate.DateTime.ToString("yyyy-MM-dd");
                frmCapNoInvoiceQty frm = new frmCapNoInvoiceQty();
                frm.VendorID = VendorID;
                frm.Makedates = makedates;
                frm.Makedatee = makedatee;
                frm.ShowDialog();
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
      
      
        /// <summary>
        /// 为开票金额加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNoInvoiceAmount_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorID"));
                string makedates = "2012-01-01";
                string makedatee = txtFormDate.DateTime.ToString("yyyy-MM-dd");
                frmCapNoInvoiceAmount frm = new frmCapNoInvoiceAmount();
                frm.VendorID = VendorID;
                frm.Makedates = makedates;
                frm.Makedatee = makedatee;
                frm.ShowDialog();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

        #region 其它事件
       
        #endregion


    }
}