using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmInvoiceOperationQueryRpt : frmAPBaseUIRpt
    {
        public frmInvoiceOperationQueryRpt()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
     
            HTDataConditionStr = tempStr;

        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
          
            string sql = "SELECT * FROM UV1_Finance_InvoiceOperationDts WHERE 1=1";
            if (FormListAID == (int)EnumVendorType.�ͻ�)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.����);
            }
            if (FormListAID == (int)EnumVendorType.����)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.�ɹ�);
            }
            sql += " AND KPType=" + (int)EnumKPType.������Ʊ;
            if (chkINDate.Checked)
            {
                sql += " AND MakeDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) + ")";
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtFormNo.Text.Trim() != "")
            {
                sql += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if(txtInvoiceNo.Text.Trim()!="")
            {
                sql+=" AND InvoiceNo LIKE "+SysString.ToDBString("%"+txtInvoiceNo.Text.Trim()+"%");
            }

            if (SysConvert.ToInt32(drpKPType.EditValue) != 0)
            {
                sql += " AND KPType="+SysString.ToDBString(SysConvert.ToInt32(drpKPType.EditValue));
            }

           
            DataTable dt = SysUtils.Fill(sql);

            //Ԥ��Ʊ
            sql = "SELECT * FROM UV1_Finance_InvoiceYOperationDts WHERE 1=1";
            if (FormListAID == (int)EnumVendorType.�ͻ�)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.����);
            }
            if (FormListAID == (int)EnumVendorType.����)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.�ɹ�);
            }
            sql += " AND KPType=" + (int)EnumKPType.Ԥ��Ʊ;
            if (chkINDate.Checked)
            {
                sql += " AND MakeDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                sql += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) + ")";
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtFormNo.Text.Trim() != "")
            {
                sql += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (txtInvoiceNo.Text.Trim() != "")
            {
                sql += " AND InvoiceNo LIKE " + SysString.ToDBString("%" + txtInvoiceNo.Text.Trim() + "%");
            }

            if (SysConvert.ToInt32(drpKPType.EditValue) != 0)
            {
                sql += " AND KPType=" + SysString.ToDBString(SysConvert.ToInt32(drpKPType.EditValue));
            }
            DataTable dt2 = SysUtils.Fill(sql);

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["FormNo"] = SysConvert.ToString(dt2.Rows[i]["FormNo"]);
                dr["InvoiceNo"] = SysConvert.ToString(dt2.Rows[i]["InvoiceNo"]);
               
                dr["MakeDate"] = SysConvert.ToDateTime(dt2.Rows[i]["MakeDate"]);
                dr["SubmitFlag"] = SysConvert.ToInt32(dt2.Rows[i]["SubmitFlag"]);
                dr["SaleOPName"] = SysConvert.ToString(dt2.Rows[i]["SaleOPName"]);
                dr["DInvoiceQty"] = SysConvert.ToDecimal(dt2.Rows[i]["Qty"]);
                dr["DInvoiceSinglePrice"] = SysConvert.ToDecimal(dt2.Rows[i]["SinglePrice"]);
                dr["DInvoiceAmount"] = SysConvert.ToDecimal(dt2.Rows[i]["Amount"]);
                dr["VendorName"] =Common.GetVendorNameByVendorID(SysConvert.ToString(dt2.Rows[i]["VendorID"]));
                dr["KPName"] = SysConvert.ToString(dt2.Rows[i]["KPName"]);
                dr["GoodsCode"] = SysConvert.ToString(dt2.Rows[i]["GoodsCode"]);
                dr["Unit"] = SysConvert.ToString(dt2.Rows[i]["Unit"]);
                dr["ItemCode"] = SysConvert.ToString(dt2.Rows[i]["ItemCode"]);
                dr["ColorNum"] = SysConvert.ToString(dt2.Rows[i]["ColorNum"]);
                dr["ColorName"] = SysConvert.ToString(dt2.Rows[i]["ColorName"]);
               
                dt.Rows.Add(dr);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "MakeDate Asc";
            DataTable dto = dv.ToTable();
            gridView1.GridControl.DataSource = dto;
            gridView1.GridControl.Show();
           
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {

            ProcessGrid.BindGridColumn(gridView1, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);


          
            Common.BindOP(drpSaleOPID, true);
            Common.BindKPType(drpKPType, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            lbVendor.Text = "�ͻ�";
            new VendorProc(drpVendorID);
            this.ToolBarItemAdd(28, ToolButtonName.btnToExcel.ToString(), "����EXCEL", false, btnToExcel_Click);
            switch (FormListAID)
            {
                case 1:

                    break;
                case 2:
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.���� }, true);
                    lbVendor.Text = "����";
                    new VendorProc(drpVendorID);
                    break;
            }
            txtFormDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtFormDateE.DateTime = DateTime.Now.Date;
            btnQuery_Click(null, null);

        }

        private void BindVendor()
        {

          
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private InvoiceOperation EntityGet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region ���ٲ�ѯ
        private void txtMakeOPName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �ֿ�������񱨱��ӡ

        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }

            DataTable dt = (DataTable)gridView1.GridControl.DataSource;
            DataTable dtnew = dt.Clone();
            if (gridView1.RowFilter != string.Empty)
            {
                DataRow[] rows = dt.Select(gridView1.RowFilter);

                foreach (DataRow row in rows)
                {
                    dtnew.ImportRow(row);
                }

            }
            else
            {
                dtnew = dt;
            }

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtnew);

            return true;
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                // base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.Ԥ��);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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

                btnPrintAbount((int)ReportPrintType.��ӡ);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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
                btnPrintAbount((int)ReportPrintType.���);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        
    }
}