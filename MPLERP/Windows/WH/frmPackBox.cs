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
    public partial class frmPackBox : frmAPBaseUIRpt
    {
        public frmPackBox()
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
            if (txtWHID.Text.Trim() != "")
            {
                tempStr += " AND WHID LIKE " + SysString.ToDBString("%" + txtWHID.Text.Trim() + "%");
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtGoodsLevel.Text.Trim() != "")
            {
                tempStr += " AND GoodsLevel LIKE " + SysString.ToDBString("%" + txtGoodsLevel.Text.Trim() + "%");
            }
            if (txtMWeightS.Text.Trim() != "")
            {
                tempStr += " AND MWeight> " + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }
            if (txtMWeightE.Text.Trim() != "")
            {
                tempStr += " AND MWeight< " + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }
            if (chkItemDate.Checked)
            {
                tempStr += " AND CreateTime BETWEEN " + SysString.ToDBString(txtCreateTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtCreateTimeE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            if (FormListAID != 0)
            {
                tempStr += " AND BoxStatusID=" + SysString.ToDBString(FormListAID);
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
            if (SysConvert.ToString(drpUseable.EditValue) != string.Empty)
            {
                tempStr += " AND BoxStatusID=" + SysString.ToDBString(SysConvert.ToInt32(drpUseable.EditValue));
            }
            //if (chkZero.Checked)
            //{
            //    tempStr += " AND ISNULL(Qty,0)>0";
            //}
            //if (chkIn.Checked)
            //{
            //    tempStr += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
            //}
            tempStr += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0)";
            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            PackBoxRule rule = new PackBoxRule();
            DataTable dt = rule.RUShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag").Replace("PrintCD", "'' PrintCD"));
            //if (ChkShowPrintCD.Checked)
            //{
            //    ProcDataTable(dt);
            //}
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        //private void ProcDataTable(DataTable p_dt)
        //{
        //    foreach (DataRow dr in p_dt.Rows)
        //    {
        //        string sql = "select PrintCD from WO_BProductCheckDts where 1=1";
        //        sql += " AND DISN=" + SysString.ToDBString(SysConvert.ToString(dr["BoxNo"]));
        //        DataTable dt = SysUtils.Fill(sql);
        //        if (dt.Rows.Count != 0)
        //        {
        //            dr["PrintCD"] = SysConvert.ToString(dt.Rows[0]["PrintCD"]);
        //        }
        //    }
        //}

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            PackBoxRule rule = new PackBoxRule();
            PackBox entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_PackBox";
            this.HTDataList = gridView1;
            txtCreateTimeS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtCreateTimeE.DateTime = DateTime.Now.Date;
            txtBoxNo.Focus();
            btnQuery_Click(null, null);
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            if (FormListAID != 0)
            {
                chkIn.Visible = false;
            }
            if (FormListAID != 0)
            {
                drpUseable.Visible = false;
                drpUseableFlag.Visible = false;
            }
            if (PackBoxStatusProc.ColorIniFlag)
            {
                PackBoxStatusProc.ColorIniTextBox(new TextBox[] { txtColorSOStatus1, txtColorSOStatus2, txtColorSOStatus3 });
            }


        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private PackBox EntityGet()
        {
            PackBox entity = new PackBox();
            entity.ID = HTDataID;
            return entity;
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

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        #endregion

        #region ��ӡ�뵥
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "BoxStatusName")//
                {
                    e.Appearance.BackColor = PackBoxStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BoxStatusName")));
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string BoxIDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (BoxIDStr != "")
                    {
                        BoxIDStr += ",";
                    }
                    BoxIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                }
            }

            if (BoxIDStr == "")
            {
                this.ShowMessage("�빴ѡ��Ҫ��ӡ�ĹҰ�����");
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


            string sql = "SELECT * FROM UV1_WH_PackBox WHERE ID IN (" + BoxIDStr + ")";
            DataTable dtSource = SysUtils.Fill(sql);

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtSource);


            //FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { BoxIDStr });
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