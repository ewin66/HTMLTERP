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
    public partial class frmShipmentEdit : frmAPBaseUIFormEdit
    {
        public frmShipmentEdit()
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
                this.ShowMessage("��˫�����ɷ�������");
                txtCode.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpShipTypeID.EditValue) == 0)
            {
                this.ShowMessage("��ѡ�񷢻�����");
                drpShipTypeID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ҵ��Ա");
                drpSaleOPID.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorOPID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ͻ�����");
                drpVendorOPID.Focus();
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
            ShipmentDtsRule rule = new ShipmentDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ShipmentRule rule = new ShipmentRule();
            Shipment entity = EntityGet();
            ShipmentDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ShipmentRule rule = new ShipmentRule();
            Shipment entity = EntityGet();
            ShipmentDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Shipment entity = new Shipment();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;
  			drpShipTypeID.EditValue = entity.ShipTypeID; 
  			txtShipDate.DateTime = entity.ShipDate; 
  			txtVendorName.Text = entity.VendorName.ToString(); 
  			txtVendorAddress.Text = entity.VendorAddress.ToString(); 
  			txtVendorTel.Text = entity.VendorTel.ToString(); 
  			txtVendorFax.Text = entity.VendorFax.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpVendorID.EditValue = entity.VendorID; 
  			txtCode.Text = entity.Code.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpCurrencyID.EditValue = entity.CurrencyID; 
  			txtTotalAmount.Text = entity.TotalAmount.ToString(); 
  			txtTotalQty.Text = entity.TotalQty.ToString(); 
  			txtRate.Text = entity.Rate.ToString();
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            drpVendorOPID.EditValue = entity.VendorOPID;

            drpRecVendorID.EditValue = entity.RecVendorID;
            txtRecVendorAddress.Text = entity.RecVendorAddress;


            txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
            txtMakeDate.DateTime = entity.MakeDate; 

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
            ShipmentRule rule = new ShipmentRule();
            Shipment entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID,txtTotalAmount,txtTotalQty }, false);
            
        }

        
        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtShipDate.Text = DateTime.Now.Date.ToShortDateString();
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);

            txtMakeDate.Text = DateTime.Now.Date.ToShortDateString();

            drpCompanyTypeID.EditValue = 1;
            drpCurrencyID.EditValue = (int)EnumCurrency.�����;//�����

            txtCode_DoubleClick(null, null);
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_Shipment";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//������ϸУ�����¼���ֶ�
         
            Common.BindOP(drpSaleOPID,(int)EnumOPDep.ҵ��,true);
            Common.BindCurrency(drpCurrencyID, true);//����
            Common.BindCompanyType(drpCompanyTypeID, true);//�󶨹�˾��
            Common.BindSubTypeShipment(drpShipTypeID, 6, true);//�󶨷�������
            Common.BindCLS(drpYarnStatus, "Sale", "YarnType", true);//ɴ����̬
            Common.BindYarnType(drpYarnTypeID, true);//ɴ��

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.���� }, "", "ItemModel", true, true);


            string p_Conidion = string.Empty;
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��0))
            {
                SetPosCondition = " AND VendorID in(Select VendorID FROM UV1_Data_VendorInSaleOP WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                SetPosCondition += "  OR DtsInSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";

                p_Conidion = " AND ( ";
                p_Conidion += " InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion += " OR ID in (Select MainID From Data_VendorInSaleOP where InSaleOP= " + SysString.ToDBString(FParamConfig.LoginID) + ")";
                p_Conidion += ")";

            }
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, p_Conidion, true);//�ͻ�
            new VendorProc(drpVendorID, p_Conidion);

            Common.BindVendor(drpRecVendorID, new int[] { (int)EnumVendorType.�ͻ� }, p_Conidion, true);//�ͻ�
            new VendorProc(drpRecVendorID, p_Conidion);



            this.ToolBarItemAdd(28, "btnLoad", "����", false, btnCheckLoad_Click);

            SetTabIndex(0, groupControlMainten);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Shipment EntityGet()
        {
            Shipment entity = new Shipment();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.ShipTypeID = SysConvert.ToInt32(drpShipTypeID.EditValue); 
  			entity.ShipDate = txtShipDate.DateTime.Date; 
  			entity.VendorName = txtVendorName.Text.Trim(); 
  			entity.VendorAddress = txtVendorAddress.Text.Trim(); 
  			entity.VendorTel = txtVendorTel.Text.Trim(); 
  			entity.VendorFax = txtVendorFax.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.VendorID =SysConvert.ToString( drpVendorID.EditValue);
  			entity.Code = txtCode.Text.Trim(); 
  			entity.SaleOPID =SysConvert.ToString( drpSaleOPID.EditValue); 
  			entity.CurrencyID = SysConvert.ToInt32(drpCurrencyID.EditValue); 
  			entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim()); 
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim()); 
  			entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim()); 
  			entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);

            entity.RecVendorID = SysConvert.ToString(drpRecVendorID.EditValue);
            entity.RecVendorAddress = txtRecVendorAddress.Text.Trim();

            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ShipmentDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ShipmentDts[] entitydts = new ShipmentDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ShipmentDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].CompactCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "CompactCode")); 
                    entitydts[index].YarnTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "YarnTypeID")); 
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice")); 
  			 		entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].DesignNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNo")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].YarnStatus = SysConvert.ToString(gridView1.GetRowCellValue(i, "YarnStatus")); 
  			 		entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum")); 
  			 		entitydts[index].IsShipmentFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "IsShipmentFlag")); 
  			 		entitydts[index].ShipmentQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ShipmentQty")); 
  			 		entitydts[index].ShipmentDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "ShipmentDate")); 
  			 		entitydts[index].ShipmentFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "ShipmentFormNo")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        //#region �ύ�������ύ����
        ///// <summary>
        ///// �ύ
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ1))
        //        {
        //            this.ShowMessage("��û�д˲���Ȩ��");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }
        //        ShipmentRule rule = new ShipmentRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.���ύ);
        //        FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// �����ύ
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnSubmitCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ1))
        //        {
        //            this.ShowMessage("��û�д˲���Ȩ��");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }

        //        ShipmentRule rule = new ShipmentRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.δ�ύ);

        //        FCommon.AddDBLog(this.Text, FormStatus.�����ύ.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        //#endregion

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

        #region �����¼�
        //�ͻ��ı��¼�
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtVendorName.Text = dt.Rows[0]["VendorName"].ToString();
                    txtVendorAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtVendorFax.Text = dt.Rows[0]["Fax"].ToString();
                    txtVendorTel.Text = dt.Rows[0]["Tel"].ToString();
                }
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    Common.BindVendorSaleOPID(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �ջ��ͻ��ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpRecVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpRecVendorID.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    txtRecVendorAddress.Text = dt.Rows[0]["Address"].ToString();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        //��������˫������
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.��������);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        //�۸������뿪������
        private void txtSinglePrice_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal TotalQty = 0.0m;
                decimal TotalMoney = 0.0m;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Qty")) != "")
                    {
                        decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                        decimal DtsUnitPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                        decimal DtsAmount = SysConvert.ToDecimal(Qty * DtsUnitPrice, 2);

                        gridView1.SetRowCellValue(i, "Amount", DtsAmount);

                        TotalQty += Qty;
                        TotalMoney += DtsAmount;
                    }
                }

                txtTotalQty.Text = SysConvert.ToString(TotalQty);
                txtTotalAmount.Text = SysConvert.ToString(TotalMoney);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ض���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    //frmSODtsLoad frm = new frmSODtsLoad();
                    //frm.ShowDialog();
                    //if (frm.HTLoadData.Count != 0)
                    //{
                    //    string listStr = ((string[])frm.HTLoadData[2])[0];

                    //   string sql = "Select CompanyTypeID,SOID Code,VendorID,DtsItemCode ItemCode,DtsItemName ItemName,DtsItemStd ItemStd, DtsItemModel ItemModel,UnitPrice Price,Qty, ColorNum,ColorName,''JarNum,YarnTypeID,YarnStatus,";
                    //    sql += "DesignNO,SaleOPID";
                    //    sql += " FROM UV1_Sale_SODts WHERE 1=1 AND" + listStr;
                        

                    //    DataTable dt = SysUtils.Fill(sql);

                    //    for (int k = 0; k < dt.Rows.Count; k++)
                    //    {
                    //        bool FindBlankFlag = false;//�Ƿ��ҵ�����
                    //        for (int i = 0; i < gridView1.RowCount; i++)
                    //        {
                    //            if (SysConvert.ToString(gridView1.GetRowCellValue(i, gridView1.Columns["ItemCode"])) == "")
                    //            {
                    //                FindBlankFlag = true;
                    //                gridView1.FocusedRowHandle = i;//�۽�
                    //                btnAddRow_Click(null, null);//��������
                    //                break;
                    //            }
                    //        }

                    //        if (!FindBlankFlag)//û���ҵ� ����һ�����в��۽�
                    //        {
                    //            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    //            btnAddRow_Click(null, null);//��������
                    //            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    //        }

                    //        //��ʼ��ֵ



                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CompactCode", dt.Rows[k]["Code"]);//�ɹ����ӹ���Ⱦɫ����            
                  
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemCode", dt.Rows[k]["ItemCode"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemName", dt.Rows[k]["ItemName"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemStd", dt.Rows[k]["ItemStd"]);

                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ItemModel", dt.Rows[k]["ItemModel"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ColorNum", dt.Rows[k]["ColorNum"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ColorName", dt.Rows[k]["ColorName"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DesignNO", dt.Rows[k]["DesignNO"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "JarNum", dt.Rows[k]["JarNum"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "YarnStatus", dt.Rows[k]["YarnStatus"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "YarnTypeID", dt.Rows[k]["YarnTypeID"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SinglePrice", dt.Rows[k]["Price"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Weight", dt.Rows[k]["Qty"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", dt.Rows[k]["Qty"]);
                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Amount", SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[k]["Qty"]) * SysConvert.ToDecimal(dt.Rows[k]["Price"]), 2));


                    //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Unit", "KG");

                    //    }
                    //    if (dt.Rows.Count != 0)
                    //    {
                    //        drpVendorID.EditValue = dt.Rows[0]["VendorID"].ToString();
                    //        drpCompanyTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["CompanyTypeID"].ToString());
                          
                    //    }

                    //}
                }
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

       
    

   


    }
}