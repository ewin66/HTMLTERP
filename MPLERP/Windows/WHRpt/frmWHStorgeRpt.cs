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
    public partial class frmWHStorgeRpt : frmAPBaseUIRpt
    {
        public frmWHStorgeRpt()
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

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(8009)) == 0)//��ѯģʽ 0��ģ����ѯ�� 1��ȷ��ѯ
                {
                    tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
                }
                else
                {
                    tempStr += " AND ColorNum = " + SysString.ToDBString(txtColorNum.Text.Trim());
                }

            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(8009)) == 0)//��ѯģʽ 0��ģ����ѯ�� 1��ȷ��ѯ
                {
                    tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
                }
                else
                {
                    tempStr += " AND ColorName = " + SysString.ToDBString(txtColorName.Text.Trim());
                }
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

            //if (FormListAID == 21)//��Ʒ���
            //{
            //    tempStr += " AND WHID='ML002'";
            //}
            //else if (FormListAID == 19)//��Ʒ
            //{
            //    tempStr += " AND WHID='ML003'";
            //}
            //else if (FormListAID == 1)//��Ʒ
            //{
            //    tempStr += " AND WHID='ML001'";
            //}
            //else
            //{
            tempStr += " AND WHID IN (SELECT WHID FROM WH_WH WHERE WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(this.FormListAID) + "))";
            //}

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            DataTable dt = rule.RShowStorge(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("YCFlag", "0 AS YCFlag"));
            if (ChkShowError.Checked)
            {
                ProcDataTable(dt);
            }
            //SetGridView(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();


        }

        private void ProcDataTable(DataTable p_dt)
        {
            foreach (DataRow dr in p_dt.Rows)
            {
                string WHID = SysConvert.ToString(dr["WHID"]);
                string SectionID = SysConvert.ToString(dr["SectionID"]);
                string ItemCode = SysConvert.ToString(dr["ItemCode"]);
                string ColorNum = SysConvert.ToString(dr["ColorNum"]);
                string ColorName = SysConvert.ToString(dr["ColorName"]);
                string GoodsCode = SysConvert.ToString(dr["GoodsCode"]);
                string Batch = SysConvert.ToString(dr["Batch"]);
                decimal MWidth = SysConvert.ToDecimal(dr["MWidth"]);
                decimal MWeight = SysConvert.ToDecimal(dr["MWeight"]);
                string VendorID = SysConvert.ToString(dr["VendorID"]);
                string GoodsLevel = SysConvert.ToString(dr["GoodsLevel"]);
                string VendorBatch = SysConvert.ToString(dr["VendorBatch"]);
                string JarNum = SysConvert.ToString(dr["JarNum"]);
                string ItemUnit = SysConvert.ToString(dr["Unit"]);

                decimal PieceQty = SysConvert.ToDecimal(dr["PieceQty"]);
                decimal Qty = SysConvert.ToDecimal(dr["Qty"]);
                #region ���Ҳֿ��������
                string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(WHID);//��òֿ���������ֶ�
                DataTable dt = SysUtils.Fill(sql);
                string FieldNamestr = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                }
                #endregion

                int PackPieceQty = 0;
                decimal PackQty = 0.0m;

                sql = "SELECT * FROM WH_PackBox WHERE 1=1";
                sql += " AND WHID =" + SysString.ToDBString(WHID);
                sql += " AND SectionID = " + SysString.ToDBString(SectionID);
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
                            case (int)WHCalMethodFieldName.WHID://�� �Ϸ��Ѵ���
                                break;
                            case (int)WHCalMethodFieldName.SectionID://��
                                break;
                            case (int)WHCalMethodFieldName.SBitID://λ
                                break;
                            case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
                                sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(ItemCode);
                                break;
                            case (int)WHCalMethodFieldName.JarNum://�׺�
                                sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(JarNum);
                                break;
                            case (int)WHCalMethodFieldName.ColorNum://ɫ��
                                sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(ColorNum);
                                break;
                            case (int)WHCalMethodFieldName.ColorName://��ɫ
                                sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(ColorName);
                                break;
                            case (int)WHCalMethodFieldName.MWidth://�ŷ�
                                sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(MWidth);
                                break;
                            case (int)WHCalMethodFieldName.MWeight://����
                                sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(MWeight);
                                break;
                            case (int)WHCalMethodFieldName.VendorID://�ͻ�
                                sql += " AND ISNULL(VendorID,'')=" + SysString.ToDBString(VendorID);
                                break;
                            case (int)WHCalMethodFieldName.GoodsCode://��Ʒ��
                                sql += " AND ISNULL(GoodsCode,'')=" + SysString.ToDBString(GoodsCode);
                                break;
                            case (int)WHCalMethodFieldName.GoodsLevel://�ȼ�
                                sql += " AND ISNULL(GoodsLevel,'')=" + SysString.ToDBString(GoodsLevel);
                                break;
                            case (int)WHCalMethodFieldName.Batch:   //����
                                sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(Batch);
                                break;
                            case (int)WHCalMethodFieldName.Unit:   //��λ
                                sql += " AND ISNULL(Unit,'')=" + SysString.ToDBString(ItemUnit);
                                break;
                            case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                                sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(VendorBatch);
                                break;
                            default:
                                throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName);
                        }
                    }
                }
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
                sql += " AND(ISNULL(Qty,0)>0)";
                DataTable dt1 = SysUtils.Fill(sql);
                if (dt1.Rows.Count != 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        PackQty += SysConvert.ToDecimal(dt1.Rows[i]["Qty"]);
                    }
                    PackPieceQty = dt1.Rows.Count;
                }

                if (PackQty != Qty || PackPieceQty != PieceQty)
                {
                    dr["YCFlag"] = 1;
                }
            }
        }

        private void SetGridView(DataTable p_dt)
        {
            foreach (DataRow dr in p_dt.Rows)
            {

                if (SysConvert.ToDateTime(dr["PDDate"]) > SysConvert.ToDateTime("2012-1-1"))
                {
                    dr["PD"] = "���̿�";
                }
                else
                {
                    //dr["PD"] = "δ�̿�";
                }
            }
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };


            Common.BindWHByFormList(drpWHID, this.FormListAID, true);

            //Common.BindMLType(drpMLType, true);

            Common.BindCLS(drpGridSplitColor, "WH_PackBox", "SplitColor", true);//��ɫ
            Common.BindCLS(drpGridReHandle, "WH_PackBox", "ReHandle", true);//����
            Common.BindCLS(drpGridMiddleDiff, "WH_PackBox", "MiddleDiff", true);//�м��
            Common.BindCLS(drpGridHeadTailDiff, "WH_PackBox", "HeadTailDiff", true);//ͷβ��

            txtQFormDateS.DateTime = DateTime.Now.AddMonths(-6).Date;
            txtQFormDateE.DateTime = DateTime.Now.Date;
            btnQuery_Click(null, null);

            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);



            this.ToolBarItemAdd(28, "btnSaveColor", "�����ɫ", false, btnSaveColor_Click);

        }

        /// <summary>
        ///ͨ�� ��������ʵ��
        /// 
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            try
            {
                //SysFile.WriteFrameworkLog("A3");
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string whid = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHID"));
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
                string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(whid);//��òֿ���������ֶ�
                DataTable dt = SysUtils.Fill(sql);

                string FieldNamestr = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                }

                #endregion

                sql = "SELECT * FROM WH_PackBox WHERE 1=1";
                sql += " AND WHID=" + SysString.ToDBString(whid);
                sql += " AND SectionID=" + SysString.ToDBString(SectionID);
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
                //SysFile.WriteFrameworkLog("A4");


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


        #region ���������
        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcData_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Empty;
                DataTable p_dt = (DataTable)gridView1.GridControl.DataSource;
                foreach (DataRow dr in p_dt.Rows)
                {
                    sql = "SELECT ID FROM WH_PackBox WHERE 1=1";
                    sql += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(dr["WHID"]));
                    sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(dr["ItemCode"]));
                    sql += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(dr["ColorNum"]));
                    sql += " AND ColorName=" + SysString.ToDBString(SysConvert.ToString(dr["ColorName"]));
                    sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dr["SectionID"]));
                    sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
                    sql += " AND ISNULL(Qty,0)>0";
                    int pieceQty = SysUtils.Fill(sql).Rows.Count;
                    sql = "UPDATE WH_Storge SET PieceQty=" + pieceQty.ToString() + " WHERE ID=" + dr["ID"].ToString();
                    SysUtils.ExecuteNonQuery(sql);

                }
                this.ShowInfoMessage("�������");
                this.BindGrid();
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



        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "PDDate")
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "PDDate")) != "")
                    {
                        e.Appearance.BackColor = Color.PaleGreen;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }





        /// <summary>
        ///�����ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSaveColor_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    int p_ID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "ID"));
                    string sql = "Update  WH_PackBox set SplitColor=" + SysString.ToDBString(SysConvert.ToString(gridView2.GetRowCellValue(i, "SplitColor")));
                    sql += ",MiddleDiff=" + SysString.ToDBString(SysConvert.ToString(gridView2.GetRowCellValue(i, "MiddleDiff")));
                    sql += ",HeadTailDiff=" + SysString.ToDBString(SysConvert.ToString(gridView2.GetRowCellValue(i, "HeadTailDiff")));
                    sql += ",ReHandle=" + SysString.ToDBString(SysConvert.ToString(gridView2.GetRowCellValue(i, "ReHandle")));
                    sql += " where ID=" + p_ID;
                    SysUtils.ExecuteNonQuery(sql);
                }

                this.ShowInfoMessage("����ɹ�");

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





    }
}