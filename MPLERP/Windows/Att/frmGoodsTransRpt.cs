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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmGoodsTransRpt : frmAPBaseUIRpt
    {
        public frmGoodsTransRpt()
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkJSDate.Checked)
            {
                tempStr += " AND JSDate BETWEEN " + SysString.ToDBString(txtJSDateS.DateTime) + " AND " + SysString.ToDBString(txtJSDateE.DateTime);
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
      
            if (SysConvert.ToString(drpShopID.EditValue) != "")
            {
                tempStr += " AND ShopID = " + SysString.ToDBString(SysConvert.ToString(drpShopID.EditValue));
            }
            if (SysConvert.ToString(drpResive.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpResive.EditValue));
            }
            if (SysConvert.ToString(drpTransComID.EditValue) != "")
            {
                tempStr += " AND TransComID = " + SysString.ToDBString(SysConvert.ToString(drpTransComID.EditValue));
            }
            if (chkJSFlag.Checked)
            {
                tempStr += " AND JSFlag=1";
            }
            if (chkNOJSFlag.Checked)
            {
                tempStr += " AND ISNULL(JSFlag,0)=0";
            }
            if (chkFHDFlag.Checked)
            {
                tempStr += " AND FHDFlag=1";
            }
            if (chkYSFlag.Checked)
            {
                tempStr += " AND YSFlag=1";
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            GoodsTransRule rule = new GoodsTransRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag","0 SelectFlag"));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            GoodsTransRule rule = new GoodsTransRule();
            GoodsTrans entity = EntityGet();
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
            this.HTDataTableName = "Att_GoodsTrans";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            txtJSDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtJSDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpTransComID, new int[] { (int)EnumVendorType.������˾ }, true);
            new VendorProc(drpTransComID);
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.���� }, true);
            new VendorProc(drpShopID);
            Common.BindVendor(drpResive, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpResive);
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            btnQuery_Click(null, null);

        }

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GoodsTrans EntityGet()
        {
            GoodsTrans entity = new GoodsTrans();
            entity.ID = HTDataID;      
            return entity;
        }

        
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
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

        private void chkJSFlag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (chkJSFlag.Checked)
                {
                    chkNOJSFlag.Checked = false;
                }
                else
                {
                    chkNOJSFlag.Checked=true;
                }
                txtFormNo_EditValueChanged(null, null);
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void chkNOJSFlag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if(chkNOJSFlag.Checked)
                {
                    chkJSFlag.Checked=false;
                }
                else
                {
                    chkJSFlag.Checked=true;
                }
                txtFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #region �Ұ������ӡ

        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string GBIDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (GBIDStr != "")
                    {
                        GBIDStr += ",";
                    }
                    GBIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                }
            }

            if (GBIDStr == "")
            {
                this.ShowMessage("�빴ѡ��Ҫ��ӡ��������");
                return false;
            }


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


            FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { GBIDStr });
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
                base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.Ԥ��);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        //private DataTable GetReportdt(string p_DtsID)
        //{
        //    string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID IN("+p_DtsID+")";
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt;
        //    }
        //    return null;
        //}
        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                base.btnPrint_Click(sender, e);

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
                base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.���);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (chkAll.Checked)
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 0);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
       

      
    }
}