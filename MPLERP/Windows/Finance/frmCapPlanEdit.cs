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


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("������ɫ�����");
            //    txtCode.Focus();
            //    return false;
            //}

            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("��������");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpPlanOPID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ҵ��Ա");
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
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            CapPlanDtsRule rule = new CapPlanDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
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
        /// �޸�
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
        /// ����
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
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CapPlanRule rule = new CapPlanRule();
            CapPlan entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
             base.IniInsertSet();
             txtFormDate.DateTime = DateTime.Now.Date;
             txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CapPlan";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"VendorID"};//������ϸУ�����¼���ֶ�
            Common.BindOP(drpPlanOPID, true);
            Common.BindVendor(drpVendor2, new int[] { (int)EnumVendorType.����}, true);
            new VendorProc(drpVendor2);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.�ͻ� }, true);
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

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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
        /// ���ʵ��
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
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//�Ѵ��ڱ�ʾ�޸�
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//����
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
                if (HTFormStatus ==FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {

                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text=rule.RGetFormNo((int)FormNoControlEnum.�ʽ�ƻ�����);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJS_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    string tempstr = "";
                    string sql = "";
                    switch (this.FormListAID)
                    {
                        case 1:
                            tempstr += " AND VendorTypeID="+(int)EnumVendorType.�ͻ�;
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
                            tempstr += " AND VendorTypeID=" + (int)EnumVendorType.����;
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
        /// Ϊ��Ʊ������
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

       

        #region �����¼�
       
        #endregion


    }
}