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
    public partial class frmCaiWuYSYFRPT : frmAPBaseUIRpt
    {
        public frmCaiWuYSYFRPT()
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
           
            //if (ChkMakeDate.Checked)
            //{
            //    tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            //}

            //if (!Common.CheckLookUpEditBlank(drpQVendorID))
            //{
            //    tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            //}

            //if (txtFormNo.Text.Trim() != "")
            //{
            //    tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            //}

            //tempStr += " AND RecPayTypeID=" + this.FormListAID;
           
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
           string makedates="2012-01-01";
           string makedatee = DateTime.Now.Date.ToString("yyyy-MM-dd");
           if (ChkMakeDate.Checked)
           {
               makedates = txtQMakeDateS.DateTime.ToString("yyyy-MM-dd");
               makedatee = txtQMakeDateE.DateTime.ToString("yyyy-MM-dd");
           }
           string tempstr = "";

           switch (this.FormListAID)
           {
               case 1:
                   tempstr += " AND VendorTypeID=" + (int)EnumVendorType.�ͻ�;
                   if (SysConvert.ToString(drpPlanOPID.EditValue) != "")
                   {
                       tempstr += " AND InSaleOP=" + SysString.ToDBString(drpPlanOPID.EditValue.ToString());
                   }
                   if (SysConvert.ToString(drpQVendorID.EditValue) != "")
                   {
                       tempstr += " AND VendorID=" + SysString.ToDBString(drpQVendorID.EditValue.ToString());
                   }
                   break;
               case 2:
                   tempstr += " AND VendorTypeID=" + (int)EnumVendorType.����;
                   if (SysConvert.ToString(drpQVendorID.EditValue) != "")
                   {
                       tempstr += " AND VendorID=" + SysString.ToDBString(drpQVendorID.EditValue.ToString());
                   }
                   break;
           }
           string sql = "EXEC USP1_Finance_CaiWuYSYFRPT " + SysString.ToDBString(tempstr) + "," + SysString.ToDBString(makedates) + "," + SysString.ToDBString(makedatee);
           DataTable dt = SysUtils.Fill(sql);
           gridView1.GridControl.DataSource = dt;
           gridView1.GridControl.Show();
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
            txtQMakeDateE.DateTime = DateTime.Now;
            //Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.���� }, true);
            this.HTDataTableName = "Finance_RecPay";
            this.HTDataList = gridView1;
            Common.BindOP(drpPlanOPID, true);
            if (this.FormListAID == (int)EnumVendorType.�ͻ�)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            }
            else
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾ }, true);
            }
            new VendorProc(drpQVendorID);

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