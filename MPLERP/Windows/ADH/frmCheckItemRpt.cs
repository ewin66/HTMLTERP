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
    public partial class frmCheckItemRpt : frmAPBaseUIRpt
    {
        public frmCheckItemRpt()
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

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (SysConvert.ToInt32(drpLevel.EditValue) != 0)
            {
                tempStr += " AND LevelID=" + SysString.ToDBString(SysConvert.ToInt32(drpLevel.EditValue));
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT ItemCode,GoodsCode,MWidth,Mweight,ColorNum,ColorName,ItemName,COUNT(ISN) Qty  FROM UV1_ADH_CheckFormDts WHERE 1=1 ";
            sql += HTDataConditionStr;
            sql += "group by  ItemCode,GoodsCode,MWidth,Mweight,ColorNum,ColorName,ItemName order by Qty desc";
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
            Common.BindADHLevel(drpLevel, true);
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

        #region ������ӡ

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

            DataTable dt=(DataTable)gridView1.GridControl.DataSource;

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType,dt);

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