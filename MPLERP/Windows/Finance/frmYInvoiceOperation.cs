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
    public partial class frmYInvoiceOperation : frmAPBaseUIForm
    {
        public frmYInvoiceOperation()
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
            if (txtFormNo.Text.Trim()!= "")//��ѯd
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) ;
            }

            tempStr += " AND DZTypeID="+SysString.ToDBString(FormListAID);
            tempStr += " AND ISNULL(PreInvFlag,0)=1";
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;

        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
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


            txtQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindOP(drpSaleOPID, true);
            //Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.���� }, true);
            this.HTDataTableName = "Finance_InvoiceOperation";
            this.HTDataList = gridView1;
            BindVendor();
            new VendorProc(drpQVendorID);

        }

        private void BindVendor()
        {

            Common.BindVendorByDZTypeID(drpQVendorID, this.FormListAID, true);
            //switch (FormListAID)
            //{
            //    case (int)EnumDZType.�ɹ�:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.���� }, true);
            //        lblVendor.Text = "��Ӧ��";
            //        break;
            //    case (int)EnumDZType.�ӹ�:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.���� }, true);
            //        lblVendor.Text = "�ӹ���";
            //        break;
            //    case (int)EnumDZType.����:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            //        lblVendor.Text = "�ͻ�";
            //        break;

            //}
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
    }
}