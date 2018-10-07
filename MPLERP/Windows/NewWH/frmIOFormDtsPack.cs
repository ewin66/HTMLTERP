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
    public partial class frmIOFormDtsPack : frmAPBaseUIRpt
    {
        public frmIOFormDtsPack()
        {
            InitializeComponent();//
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtBoxNo.Text.Trim() != "")
            {
                tempStr += " AND BoxNo LIKE " + SysString.ToDBString("%" + txtBoxNo.Text.Trim() + "%");
            }
            if (chkItemDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtCreateTimeS.DateTime.ToString("yyyy-MM-dd HH:mm:ss")) + " AND " + SysString.ToDBString(txtCreateTimeE.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");//
            }
            tempStr += " AND  SubmitFlag=1";
            tempStr += " AND SubType IN(1214,1111)";
            tempStr += " ORDER BY SubmitTime";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT ";
            sql += "*";
            sql += ", (CASE WHEN SubType='1111' THEN -1*(CASE WHEN (Unit='RMB/KG' OR Unit='USD/KG') THEN (ISNULL(SinglePrice,0)*ISNULL(DtsWeight,0)) ";
            sql += " WHEN (Unit='RMB/M' OR Unit='USD/M') THEN ISNULL(SinglePrice,0)*ISNULL(Qty,0) ";
            sql += " WHEN (Unit='RMB/Y' OR Unit='USD/Y') THEN ISNULL(SinglePrice,0)*ISNULL(DtsYard,0) ELSE 0 END )";
            sql += " ELSE ";
            sql += " (CASE WHEN (Unit='RMB/KG' OR Unit='USD/KG') THEN (ISNULL(SinglePrice,0)*ISNULL(DtsWeight,0))";
            sql += " WHEN (Unit='RMB/M' OR Unit='USD/M') THEN ISNULL(SinglePrice,0)*ISNULL(Qty,0) ";
            sql += "  WHEN (Unit='RMB/Y' OR Unit='USD/Y') THEN ISNULL(SinglePrice,0)*ISNULL(DtsYard,0) ELSE 0 END )END) BoxAmount";
            sql += " FROM UV1_WH_IOFormDtsPack3 where 1=1";
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_PackBox";
            this.HTDataList = gridView1;
            txtCreateTimeS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtCreateTimeE.DateTime = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            txtBoxNo.Focus();

        }

        #endregion

        #region �����¼�
        private void txtBoxNo_EditValueChanged(object sender, EventArgs e)
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

        private void txtBoxNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCondtion();
                BindGrid();
            }
        }
        #region
        //#region ��ӡ�뵥
        //private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Column.FieldName == "BoxStatusName")//
        //        {
        //            e.Appearance.BackColor = PackBoxStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BoxStatusName")));
        //        }

        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //bool btnPrintAbount(int p_ReportPrintType)
        //{
        //    this.BaseFocusLabel.Focus();
        //    string BoxIDStr = "";
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
        //        {
        //            if (BoxIDStr != "")
        //            {
        //                BoxIDStr += ",";
        //            }
        //            BoxIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
        //        }
        //    }

        //    if (BoxIDStr == "")
        //    {
        //        this.ShowMessage("�빴ѡ��Ҫ��ӡ�ĹҰ�����");
        //        return false;
        //    }


        //    DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //    if (ci.SelectedItem == null)
        //    {
        //        this.ShowMessage("��ѡ�񱨱�ģ��");
        //        return false;
        //    }
        //    int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //    if (tempReportID == 1)
        //    {
        //        this.ShowMessage("��ѡ�񱨱�ģ��");
        //        return false;
        //    }


        //    string sql = "SELECT * FROM UV1_WH_PackBox WHERE ID IN (" + BoxIDStr + ")";
        //    DataTable dtSource = SysUtils.Fill(sql);

        //    FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtSource);


        //    //FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { BoxIDStr });
        //    return true;
        //}

        ///// <summary>
        ///// ���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPreview_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        base.btnPreview_Click(sender, e);

        //        btnPrintAbount((int)ReportPrintType.Ԥ��);


        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}



        ///// <summary>
        ///// ��ӡ
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPrint_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        base.btnPrint_Click(sender, e);

        //        btnPrintAbount((int)ReportPrintType.��ӡ);

        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// ���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDesign_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        base.btnDesign_Click(sender, e);
        //        btnPrintAbount((int)ReportPrintType.���);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        //#endregion

        ///// <summary>
        ///// ȫѡ
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            if (chkAll.Checked)
        //            {
        //                gridView1.SetRowCellValue(i, "SelectFlag", 1);
        //            }
        //            else
        //            {
        //                gridView1.SetRowCellValue(i, "SelectFlag", 0);
        //            }
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        #endregion
    }
}