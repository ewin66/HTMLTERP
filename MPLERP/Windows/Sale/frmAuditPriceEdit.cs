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
    public partial class frmAuditPriceEdit : frmAPBaseUIFormEdit
    {
        public frmAuditPriceEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("��˫�����ɵ���");
                txtCode.Focus();
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
            AuditPriceDtsRule rule = new AuditPriceDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            AuditPriceRule rule = new AuditPriceRule();
            AuditPrice entity = EntityGet();
            AuditPriceDts[] entitydts = EntityDtsGet();
            decimal ItemAmount = 0.00m;//����ԭ���ܶ�
            for (int i = 0; i < entitydts.Length; i++)
            {
                ItemAmount += entitydts[i].Amount;   
            }
            entity.ItemAmount = ItemAmount;
            entity.PPrice = ItemAmount + entity.OthAmount;//ԭ����ɴ�۸�=ԭ���ܶ�+�ӹ���
            entity.SPrice = entity.PPrice + entity.ColorAmount;//ԭɫ��ɴ�۸�=����ɴ�۸�+Ⱦɫ��
            entity.STPrice = entity.SPrice * (1 + entity.DTSHAmount / 100) + entity.DTAmount;//ɫͲɴ�۸�=ɫ��ɴ�۸�*��1+��Ͳ��ģ�+��Ͳ��

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            AuditPriceRule rule = new AuditPriceRule();
            AuditPrice entity = EntityGet();
            AuditPriceDts[] entitydts = EntityDtsGet();
            decimal ItemAmount = 0.00m;//����ԭ���ܶ�
            for (int i = 0; i < entitydts.Length; i++)
            {
                ItemAmount += entitydts[i].Amount;
            }
            entity.ItemAmount = ItemAmount;
            entity.PPrice = ItemAmount + entity.OthAmount;//ԭ����ɴ�۸�=ԭ���ܶ�+�ӹ���
            entity.SPrice = entity.PPrice + entity.ColorAmount;//ԭɫ��ɴ�۸�=����ɴ�۸�+Ⱦɫ��
            entity.STPrice = entity.SPrice * (1 + entity.DTSHAmount / 100) + entity.DTAmount;//ɫͲɴ�۸�=ɫ��ɴ�۸�*��1+��Ͳ��ģ�+��Ͳ��
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            AuditPrice entity = new AuditPrice();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;

            txtCode.Text = entity.Code.ToString(); 
  			txtProductCode.Text = entity.ProductCode.ToString();
            drpItemCode.EditValue = entity.ItemCode; 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtProductName.Text = entity.ProductName.ToString(); 
  			txtEquipment.Text = entity.Equipment.ToString(); 
  			txtProductGY.Text = entity.ProductGY.ToString(); 
  			txtProductRSGY.Text = entity.ProductRSGY.ToString(); 
  			txtMakeOPID.Text =Common.GetOPName( entity.MakeOPID.ToString()); 
  			txtMakeDate.DateTime = entity.MakeDate;
            drpJSOPID.EditValue = entity.JSOPID;
            drpSHOPID.EditValue = entity.SHOPID;
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtPPrice.Text = entity.PPrice.ToString(); 
  			txtPDatetime.DateTime = entity.PDatetime; 
  			txtSPrice.Text = entity.SPrice.ToString(); 
  			txtSDatetime.DateTime = entity.SDatetime;
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;

            txtItemAmount.Text = entity.ItemAmount.ToString();
            txtOthAmount.Text = entity.OthAmount.ToString();
            txtColorAmount.Text = entity.ColorAmount.ToString();
            txtDTAmount.Text = entity.DTAmount.ToString();
            txtDTSHAmount.Text = entity.DTSHAmount.ToString();
            txtSTPrice.Text = entity.STPrice.ToString();

  			
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
            AuditPriceRule rule = new AuditPriceRule();
            AuditPrice entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtCode, txtMakeOPID, txtMakeDate }, false);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtMakeDate.Text = DateTime.Now.Date.ToShortDateString();
            txtPDatetime.Text = DateTime.Now.Date.ToShortDateString();
            txtSDatetime.Text = DateTime.Now.Date.ToShortDateString();
            drpCompanyTypeID.EditValue = 1;
            txtPPrice.Text = "";
            txtSPrice.Text = "";
            txtProductRSGY.Text = "A.Ⱦ  ë/����" + Environment.NewLine + "B.Ⱦ  ����"+Environment.NewLine
                + "C.Ⱦ  ��" + Environment.NewLine +"D.��������  ( ��˵�� ) :";
            txtCode_DoubleClick(null, null);
            txtDTAmount.Text = "2";
            txtDTSHAmount.Text = "3";
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_AuditPrice";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//������ϸУ�����¼���ֶ�
            Common.BindCompanyType(drpCompanyTypeID, true);//�󶨹�˾��

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.���� }, "", "ItemModel", true, true);
            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, new int[] { (int)EnumItemType.���� }, true, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.ȫ��, (int)EnumVendorType.���� }, true);

            Common.BindOPID(drpSHOPID, true);
            Common.BindOPID(drpJSOPID, true);
            SetTabIndex(0, groupControlMainten);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private AuditPrice EntityGet()
        {
            AuditPrice entity = new AuditPrice();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.ProductCode = txtProductCode.Text.Trim();
            entity.ItemCode = SysConvert.ToString(drpItemCode.EditValue);  
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.ProductName = txtProductName.Text.Trim(); 
  			entity.Equipment = txtEquipment.Text.Trim(); 
  			entity.ProductGY = txtProductGY.Text.Trim(); 
  			entity.ProductRSGY = txtProductRSGY.Text.Trim();
            if (this.HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
            entity.JSOPID = SysConvert.ToString(drpJSOPID.EditValue);
            entity.SHOPID = SysConvert.ToString(drpSHOPID.EditValue);
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.PPrice = SysConvert.ToDecimal(txtPPrice.Text.Trim()); 
  			entity.PDatetime = txtPDatetime.DateTime.Date; 
  			entity.SPrice = SysConvert.ToDecimal(txtSPrice.Text.Trim()); 
  			entity.SDatetime = txtSDatetime.DateTime.Date;
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.ItemAmount = SysConvert.ToDecimal(txtItemAmount.Text.Trim());
            entity.OthAmount = SysConvert.ToDecimal(txtOthAmount.Text.Trim());
            entity.ColorAmount = SysConvert.ToDecimal(txtColorAmount.Text.Trim());
            entity.DTAmount = SysConvert.ToDecimal(txtDTAmount.Text.Trim());
            entity.DTSHAmount = SysConvert.ToDecimal(txtDTSHAmount.Text.Trim());
            entity.STPrice = SysConvert.ToDecimal(txtSTPrice.Text.Trim());
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private AuditPriceDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            AuditPriceDts[] entitydts = new AuditPriceDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new AuditPriceDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Price")); 
  			 		entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
  			 		entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID")); 
  			 		entitydts[index].Percentage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Percentage")); 
  			 		entitydts[index].Loss = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Loss")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion
 

        #region �����¼�
        /// <summary>
        /// ������ؼ۸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOthAmount_EditValueChanged(object sender, EventArgs e)
        {
             try
            {
                txtSTPrice.Text = "";
                txtSPrice.Text = "";
                txtPPrice.Text = "";
                if (txtItemAmount.Text.Trim() != "")
                {
                    decimal ItemAmount = SysConvert.ToDecimal(txtItemAmount.Text.Trim());
                    decimal OthAmount = SysConvert.ToDecimal(txtOthAmount.Text.Trim());
                    decimal ColorAmount = SysConvert.ToDecimal(txtColorAmount.Text.Trim());
                    decimal DTSHAmount = SysConvert.ToDecimal(txtDTSHAmount.Text.Trim());
                    decimal DTAmount = SysConvert.ToDecimal(txtDTAmount.Text.Trim());
                    txtPPrice.Text = SysConvert.ToString(ItemAmount+OthAmount);
                    txtSPrice.Text = SysConvert.ToString(SysConvert.ToDecimal(txtPPrice.Text.Trim()) + ColorAmount);
                    txtSTPrice.Text = SysConvert.ToString(SysConvert.ToDecimal(txtSPrice.Text.Trim())*(1+DTSHAmount/100)+DTAmount);//ɫͲɴ�۸�=ɫ��ɴ�۸�*��1+��Ͳ��ģ�+��Ͳ��
               
                }
             }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ɺ˼۵���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.�˼۵���);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();

                decimal ItemAmount = 0.00m;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Price")) != "")
                    {
                        decimal Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Price"));
                        decimal Loss = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Loss"));
                        decimal Per = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Percentage"));
                        decimal DtsAmount = SysConvert.ToDecimal(Price * (SysConvert.ToDecimal(Per) / 100) * (1 + SysConvert.ToDecimal(Loss) / 100), 2);

                        gridView1.SetRowCellValue(i, "Amount", DtsAmount);
                        ItemAmount += DtsAmount;

                    }
                }
                txtItemAmount.Text = ItemAmount.ToString("f2");

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ���Ƶ���ʱ������ǰ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMakeDate_DoubleClick(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.����)
            {
                txtMakeDate.DateTime = DateTime.Now.Date;
            }
        }

        #endregion

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
                //base.btnPreview_Click(sender, e);
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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.Ԥ��, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
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
                //base.btnPrint_Click(sender, e);

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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.��ӡ, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
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
                //base.btnDesign_Click(sender, e);
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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.���, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion

     

      
    }
}