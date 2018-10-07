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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    
    
    /// <summary>
    ///����ⱨ�� ����÷ 2012.05.07 
    /// </summary>
    public partial class frmCheckVendorRpt : frmAPBaseUIRpt
    {
        public frmCheckVendorRpt()
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
            if (txtVendorID.Text.Trim() != "")
            {
                tempStr += " AND DVendorID LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
            }
            if (SysConvert.ToInt32(drpDHID.EditValue) != 0)
            {
                tempStr += " AND DataDHID="+SysString.ToDBString(SysConvert.ToInt32(drpDHID.EditValue));
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT EXName,DVendorID,VendorName,COUNT(ISN) Qty  FROM UV1_ADH_CheckFormDts WHERE 1=1 ";
            sql += HTDataConditionStr;
            sql += "group by EXName,DVendorID,VendorName order by Qty desc";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
          

        }

       
       

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
          //  this.HTDataTableName = "Data_OP";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindDHID(drpDHID, this.FormListAID, false);
            new VendorProc(drpVendorID);
            btnQuery_Click(null, null);
            



        }

       
        #endregion


       

        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQOPID_EditValueChanged(object sender, EventArgs e)
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

    
      

       

       

      


        
    }
}