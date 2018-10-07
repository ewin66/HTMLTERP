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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ��ͻ�����
    /// </summary>
    public partial class frmOperateQuoteEdit : frmAPBaseUIFormEdit
    {
        public frmOperateQuoteEdit()
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

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ͻ�");
                drpVendorID.Focus();
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
            OperateQuoteDtsRule rule = new OperateQuoteDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            OperateQuoteRule rule = new OperateQuoteRule();
            OperateQuote entity = EntityGet();
            OperateQuoteDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            OperateQuoteRule rule = new OperateQuoteRule();
            OperateQuote entity = EntityGet();
            OperateQuoteDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            OperateQuote entity = new OperateQuote();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;

  			txtCode.Text = entity.Code.ToString(); 
  			drpVendorID.EditValue = entity.VendorID; 
  			txtQuoteDate.DateTime = entity.QuoteDate; 
  			drpQuoteOPID.EditValue = entity.QuoteOPID;
            drpVendorOPID.EditValue = entity.VendorOPID;
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            drpCurrencyID.EditValue = entity.CurrencyID; 
  			txtRate.Text = entity.Rate.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
            txtMakeDate.DateTime = entity.MakeDate;
            drpYarnTypeID1.EditValue = entity.YarnTypeID;
            drpYarnStatus1.EditValue = entity.YarnStatus;
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
            OperateQuoteRule rule = new OperateQuoteRule();
            OperateQuote entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID}, false);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtQuoteDate.Text = DateTime.Now.Date.ToShortDateString();
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
            this.HTDataTableName = "Sale_OperateQuote";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//������ϸУ�����¼���ֶ�

            Common.BindOPID(drpQuoteOPID, true);//������
            Common.BindCurrency(drpCurrencyID, true);//����
            Common.BindCompanyType(drpCompanyTypeID, true);//�󶨹�˾��
            //Common.BindVendorSaleOPID(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);//�󶨿ͻ�����         
            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.���� }, "", "ItemModel", true, true);
            Common.BindCLS(drpYarnStatus, "Sale", "YarnType", true);//ɴ����̬
            Common.BindYarnType(drpYarnTypeID1, true);//ɴ������
            Common.BindCLS(drpYarnStatus1, "Sale", "YarnType", true);//ɴ����̬

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);


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

            SetTabIndex(0,groupControlMainten);
        }
        /// <summary>
        /// ��������ʵ��1
        /// </summary>
        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;

            string itemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            if (itemCode != "")
            {
                SetStorgeQty(itemCode);
            }

        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private OperateQuote EntityGet()
        {
            OperateQuote entity = new OperateQuote();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.Code = txtCode.Text.Trim(); 
  			entity.VendorID =SysConvert.ToString( drpVendorID.EditValue); 
  			entity.QuoteDate = txtQuoteDate.DateTime.Date;
            entity.QuoteOPID =SysConvert.ToString( drpQuoteOPID.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
  			entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue); 
  			entity.CurrencyID = SysConvert.ToInt32(drpCurrencyID.EditValue); 
  			entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.YarnStatus = SysConvert.ToString(drpYarnStatus1.EditValue);
            entity.YarnTypeID = SysConvert.ToInt32(drpYarnTypeID1.EditValue);
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
        private OperateQuoteDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            OperateQuoteDts[] entitydts = new OperateQuoteDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new OperateQuoteDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].SalePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SalePrice")); 
  		
                    //entitydts[index].YarnStatus = SysConvert.ToString(gridView1.GetRowCellValue(i, "YarnStatus")); 
                    entitydts[index].YarnStatus = SysConvert.ToString(drpYarnStatus1.EditValue);
  			 		entitydts[index].WhitePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "WhitePrice")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
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

        #region �����¼�
        //˫�����ɵ���
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.�ͻ����۵���);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ����һ�����
        /// </summary>
        private void SetStorgeQty(string p_ItemCode)
        {
            string sql = string.Empty;
            DataTable dt;
            decimal tqty = 0;
            string tstr = string.Empty;

            sql = "SELECT WHID,SectionID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//��ѯɫɴ���
            sql += " AND ISNULL(ISJK,0)=0";
            //sql += " AND WHTypeID=" + (int)WHType.ɫɴ + " AND ISNULL(ISJK,0)=0";
            sql += " GROUP BY WHID,SectionID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "������" + "" + " " + dr["SectionID"].ToString() + " ��ɫ��" + dr["ColorName"].ToString() + " ɫ�ţ�" + dr["ColorNum"].ToString() + "   �׺ţ�" + dr["JarNum"].ToString() + "   ������" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "���ϼ�:" + tqty.ToString() + "KG" + tstr;//��ϸ��
            txtWHStorgeQty.Text = tstr;


            sql = "SELECT WHID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//��ѯɫɴ���
            sql += " AND ISNULL(ISJK,0)=1";
            //sql += " AND WHTypeID=" + (int)WHType.ɫɴ + " AND ISNULL(ISJK,0)=1";//�Ŀ�
            sql += " GROUP BY WHID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "�ֿ⣺" + "" + " ��ɫ��" + dr["ColorName"].ToString() + " ɫ�ţ�" + dr["ColorNum"].ToString() + "   �׺ţ�" + dr["JarNum"].ToString() + "   ������" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "���ϼ�:" + tqty.ToString() + "KG" + tstr;//��ϸ��
            txtWHJKStorgeQty.Text = tstr;
        }
       
        /// <summary>
        /// �ͻ��ı�����Ӧ�Ŀͻ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                    {
                        Common.BindVendorSaleOPID(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ItemCode"]));
                SetStorgeQty(itemCode);
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