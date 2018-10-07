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
    ///���ܣ���汨��  zhoufc
    /// 
    /// fromlistAID=1   ��Ʒ���   fromlistBID=0  fromlistBID=2  ��Ʒ
    /// fromlistAID=2  ɴ�߿��
    /// fromlistAID=3  �������
    /// fromlistAID=4  ���Ͽ��
    /// </summary>
    public partial class frmCodeWHStorgeRpt : frmAPBaseUIRpt
    {
        public frmCodeWHStorgeRpt()
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

            if (SysConvert.ToString(drpWHID.EditValue) != string.Empty)
            {
                tempStr += " AND WHID=" + SysString.ToDBString(drpWHID.EditValue.ToString());
            }

            if (SysConvert.ToString(drpSection.EditValue) != string.Empty)
            {
                tempStr += " AND SectionID = " + SysString.ToDBString(SysConvert.ToString(drpSection.EditValue));
            }
            if (SysConvert.ToString(drpSBits.EditValue) != string.Empty)
            {
                tempStr += " AND SBitID = " + SysString.ToDBString(SysConvert.ToString(drpSBits.EditValue));
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
            if (txtOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND OrderFormNo LIKE " + SysString.ToDBString("%" + txtOrderFormNo.Text.Trim() + "%");
            }

            if (txtJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtJarNum.Text.Trim() + "%");
            }

            if (txtBatch.Text.Trim() != string.Empty)
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtBatch.Text.Trim() + "%");
            }
            tempStr += " AND WHID IN (SELECT WHID FROM WH_WH WHERE WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(this.FormListAID) + "))";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            DataTable dt = rule.RShowStorge(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("YCFlag", "0 AS YCFlag"));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };


            Common.BindWHByFormList(drpWHID, this.FormListAID, true);
            Common.BindCLS(drpGridSplitColor, "WH_PackBox", "SplitColor", true);//��ɫ
            Common.BindCLS(drpGridReHandle, "WH_PackBox", "ReHandle", true);//����
            Common.BindCLS(drpGridMiddleDiff, "WH_PackBox", "MiddleDiff", true);//�м��
            Common.BindCLS(drpGridHeadTailDiff, "WH_PackBox", "HeadTailDiff", true);//ͷβ��
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
        }

        /// <summary>
        ///ͨ�� ��������ʵ��
        /// 
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHID"));
                string SBitID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SBitID"));
                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));
                string Batch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Batch"));
                string VendorBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorBatch"));
                string VendorID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorID"));
                string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SectionID"));
                string JarNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "JarNum"));
                string DtsSO = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SO"));
                string ItemUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Unit"));
                decimal MWidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));
                decimal MWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));
                #region ���Ҳֿ��������
                string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(WHID);//��òֿ���������ֶ�
                DataTable dt = SysUtils.Fill(sql);
                string FieldNamestr = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                }
                #endregion
                sql = "SELECT * FROM UV1_WH_PackBox WHERE 1=1";
                sql += " AND WHID=" + SysString.ToDBString(WHID);
                sql += " AND SectionID=" + SysString.ToDBString(SectionID);
                sql += " AND SBitID=" + SysString.ToDBString(SBitID);
                int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
                if (FieldNamestr != string.Empty)
                {
                    string[] FieldName = FieldNamestr.Split('+');
                    for (int i = 0; i < FieldName.Length; i++)
                    {
                        string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//�ҵ��������ֶζ�Ӧ��ID
                        DataTable dtFieldName = SysUtils.Fill(sqlFieldName);
                        if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                        {
                            CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                        }
                        switch (CalFieldName)
                        {
                            case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
                                sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(ItemCode);
                                break;
                            case (int)WHCalMethodFieldName.ColorNum://ɫ��
                                sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(ColorNum);
                                break;
                            case (int)WHCalMethodFieldName.ColorName://��ɫ
                                sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(ColorName);
                                break;
                            case (int)WHCalMethodFieldName.Batch:   //����
                                sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(Batch);
                                break;
                            case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                                sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(VendorBatch);
                                break;
                            case (int)WHCalMethodFieldName.VendorID://�ͻ�
                                sql += " AND ISNULL(DtsVendorID,'')=" + SysString.ToDBString(VendorID);
                                break;
                            case (int)WHCalMethodFieldName.JarNum:  //�׺�
                                sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(JarNum);
                                break;
                            case (int)WHCalMethodFieldName.Unit:  //�׺�
                                sql += " AND ISNULL(Unit,'')=" + SysString.ToDBString(ItemUnit);
                                break;
                            case (int)WHCalMethodFieldName.MWidth://�ŷ�
                                sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(MWidth);
                                break;
                            case (int)WHCalMethodFieldName.MWeight://����
                                sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(MWeight);
                                break;

                            default:
                                throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName + ",����ϵ����Ա");
                        }
                    }
                }
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
                sql += " AND ISNULL(Qty,0)>0";
                DataTable dt1 = SysUtils.Fill(sql);
                gridView2.GridControl.DataSource = dt1;
                gridView2.GridControl.Show();
                gridView2.Columns["ReHandle"].OptionsColumn.AllowEdit = true;
                gridView2.Columns["ReHandle"].OptionsColumn.ReadOnly = false;
                gridView2.Columns["SplitColor"].OptionsColumn.AllowEdit = true;
                gridView2.Columns["SplitColor"].OptionsColumn.ReadOnly = false;
                gridView2.Columns["MiddleDiff"].OptionsColumn.AllowEdit = true;
                gridView2.Columns["MiddleDiff"].OptionsColumn.ReadOnly = false;
                gridView2.Columns["HeadTailDiff"].OptionsColumn.AllowEdit = true;
                gridView2.Columns["HeadTailDiff"].OptionsColumn.ReadOnly = false;

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindSection(drpSection, SysConvert.ToString(drpWHID.EditValue), true);
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void txtOrderFormNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetCondtion();
                    this.BindGrid();
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }

        private void drpSection_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindSBit(drpSBits, SysConvert.ToString(drpWHID.EditValue), SysConvert.ToString(drpSection.Text), true);
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }

        private void drpSBits_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e != null)
            {
                e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(SysConvert.ToString(gridView2.GetRowCellValue(e.RowHandle, "ColorStr")));
            }
        }
    }
}