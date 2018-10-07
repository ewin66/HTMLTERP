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
using DevExpress.XtraEditors.Controls;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ��̵����
    /// </summary>
    public partial class frmCheckWHEdit : frmAPBaseUIFormEdit
    {
        public frmCheckWHEdit()
        {
            InitializeComponent();
        }
        #region ȫ�ֱ���

        private DataTable[] dtPack = new DataTable[150];//�뵥��Ϣ��
        private int PreRowID = -1;//��ʼ�к�
        private int CurRowID = -1;//��ǰ�к�

        int saveLoadFormType = 0;//���ص�������
        int saveFillDataType = 0;//������������

        string saveTHLoadFormListIDStr = string.Empty;

        //private int DtsID = 0;
        //private int DtsSeq = 0;
        #endregion

        #region ȫ�ֱ���
        int HeadType = 8;//�̵�
        #endregion


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�����뵥��");
                txtFormNo.Focus();
                return false;
            }
            //if (SysConvert.ToString(drpWHTypeID.EditValue) == "")
            //{
            //    this.ShowMessage("��ѡ��ֿ�����");
            //    drpWHTypeID.Focus();
            //    return false;
            //}
            if (SysConvert.ToString(drpSubType.EditValue) == "")
            {
                this.ShowMessage("��ѡ���������");
                drpSubType.Focus();
                return false;
            }


            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            GetMaDanDetail(CurRowID);
            ArrayList List = new ArrayList();
            GetMadanDts(List);
            rule.RAdd2(entity, entitydts, List);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            GetMaDanDetail(CurRowID);
            ArrayList List = new ArrayList();
            GetMadanDts(List);
            rule.RUpdate(entity, entitydts, List);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();


            HTDataFormNo = entity.FormNo;

            txtFormIOFormID.Text = entity.FromIOFormID.ToString();

            txtFormNo.Text = entity.FormNo.ToString();
            txtHeadType.Text = this.HeadType.ToString();
            drpSubType.EditValue = SysConvert.ToInt32(entity.SubType);
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpWHID.EditValue = entity.WHID.ToString();
            //   drpWHTypeID.EditValue = SysConvert.ToInt32(entity.WHTypeID);

            txtOutDep.Text = entity.OutDep.ToString();

            txtWHOP.Text = entity.WHOP.ToString();
            txtPassOP.Text = entity.PassOP.ToString();
            drpDutyOP.EditValue = entity.SaleOPID.ToString();
            txtRemark.Text = entity.Remark.ToString();


            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }
            BindGridDts();
            SetIOFormDetail();
            BindPack();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            //drpWHTypeID.EditValue = Common.GetWHTypeByFormListID(this.FormListAID);
            txtFormDate.DateTime = DateTime.Now.Date;
            // drpWHTypeID.Properties.ReadOnly = true;
            //   drpWHTypeID.EditValue = 1;
        }



        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3, gridView4 };
            this.HTCheckDataField = new string[] { "ItemCode", "SectionID", "Qty" };//������ϸУ�����¼���ֶ�

            //this.RightFormID = this.GetFormIDByClassName("frmIOForm");
            Common.BindWHBySubType(drpWH, this.FormListAID, true);
            Common.BindOP(drpDutyOP, true);
            Common.BindSubType(drpSubType, this.FormListAID, true);
            //Common.BindEnumUnit(RestxtUnit, true);

            this.ToolBarItemAdd(28, "btnCheckLoad", "���ؿ��", false, btnCheckLoad_Click);

            this.ToolBarItemAdd(28, "btnCheckShow", "�ԱȲ���", false, btnCheckShow_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;
            gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;
            gridView3.OptionsBehavior.ShowEditorOnMouseUp = false;
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
        }


        /// <summary>
        /// ͨ�ô�����ط����������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridColumnReadOnly(gridView2, new string[] { "BoxNo", "Qty", "Weight", "GoodsLevel" }, true);
            ProcessGrid.SetGridColumnReadOnly(gridView3, new string[] { "BoxNo", "Qty", "Weight", "GoodsLevel" }, true);
        }


        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    CurRowID = view.FocusedRowHandle;
                    GetMaDanDetail(PreRowID);
                    PreRowID = CurRowID;
                    BindPack();
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
            string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            string SBitID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SBitID"]));
            string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GoodsCode"]));
            string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorNum"]));
            string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorName"]));
            string Batch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Batch"));
            string VendorBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorBatch"));
            string VendorID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorID"));
            string DtsSO = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SO"));
            string ItemUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Unit"));
            string JarNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "JarNum"));
            decimal MWidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));
            decimal MWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));
            chkAll.Checked = false;
            chkAny.Checked = false;
            #region ���Ҳֿ��������
            string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(WHID);//��òֿ���������ֶ�
            DataTable dt = SysUtils.Fill(sql);
            string FieldNamestr = string.Empty;
            if (dt.Rows.Count != 0)
            {
                FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }
            #endregion
            sql = "SELECT *,0 SelectFlag FROM UV1_WH_PackBox WHERE 1=1";
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
            sql += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0)";
            DataTable dt1 = SysUtils.Fill(sql);
            gridView3.GridControl.DataSource = dt1;
            gridView3.GridControl.Show();
            //this.BindGrid3(WHID, SectionID, ItemCode, GoodsCode, ColorNum, ColorName);
        }
        #region OLD
        //private void gridViewRowChanged1(object sender)
        //{
        //    BaseFocusLabel.Focus();
        //    ColumnView view = sender as ColumnView;
        //    ProcessGrid.SetFormValue(this, view);
        //    string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
        //    string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
        //    string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
        //    string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GoodsCode"]));
        //    string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorNum"]));
        //    string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorName"]));
        //    string Batch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Batch"]));
        //    string VendorBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["VendorBatch"]));
        //    string JarNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["JarNum"]));
        //    string ItemUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Unit"]));


        //    string VendorID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorID"));
        //    string DtsSO = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SO"));
        //    decimal MWidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));
        //    decimal MWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));


        //    chkAll.Checked = false;
        //    chkAny.Checked = false;
        //    this.BindGrid3(WHID, SectionID, ItemCode, GoodsCode, ColorNum, ColorName, Batch, VendorBatch, JarNum, ItemUnit, VendorID, MWeight, MWidth);
        //}

        //private void BindGrid3(string WHID, string SectionID, string ItemCode, string GoodsCode, string ColorNum
        //    , string ColorName, string Batch, string VendorBatch, string JarNum, string ItemUnit, string VendorID, decimal MWeight, decimal MWidth)
        //{

        //#region ���Ҳֿ��������
        //string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(WHID);//��òֿ���������ֶ�
        //DataTable dt = SysUtils.Fill(sql);

        //string FieldNamestr = string.Empty;
        //if (dt.Rows.Count != 0)
        //{
        //    FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
        //}

        //#endregion



        //    sql = "SELECT  *,0 SelectFlag FROM WH_PackBox WHERE 1=1";
        //    sql += " AND WHID=" + SysString.ToDBString(WHID);
        //    sql += " AND SectionID=" + SysString.ToDBString(SectionID);
        //    int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
        //    if (FieldNamestr != string.Empty)
        //    {
        //        string[] FieldName = FieldNamestr.Split('+');
        //        for (int i = 0; i < FieldName.Length; i++)
        //        {
        //            string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//�ҵ��������ֶζ�Ӧ��ID
        //            DataTable dtFieldName = SysUtils.Fill(sqlFieldName);
        //            if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
        //            {
        //                CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
        //            }
        //            switch (CalFieldName)
        //            {
        //                case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
        //                    sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(ItemCode);
        //                    break;
        //                case (int)WHCalMethodFieldName.ColorNum://ɫ��
        //                    sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(ColorNum);
        //                    break;
        //                case (int)WHCalMethodFieldName.ColorName://��ɫ
        //                    sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(ColorName);
        //                    break;
        //                case (int)WHCalMethodFieldName.Batch:   //����
        //                    sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(Batch);
        //                    break;
        //                case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
        //                    sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(VendorBatch);
        //                    break;
        //                case (int)WHCalMethodFieldName.VendorID://�ͻ�
        //                    sql += " AND ISNULL(DtsVendorID,'')=" + SysString.ToDBString(VendorID);
        //                    break;
        //                case (int)WHCalMethodFieldName.JarNum:  //�׺�
        //                    sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(JarNum);
        //                    break;
        //                case (int)WHCalMethodFieldName.Unit:  //�׺�
        //                    sql += " AND ISNULL(Unit,'')=" + SysString.ToDBString(ItemUnit);
        //                    break;
        //                case (int)WHCalMethodFieldName.MWidth://�ŷ�
        //                    sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(MWidth);
        //                    break;
        //                case (int)WHCalMethodFieldName.MWeight://����
        //                    sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(MWeight);
        //                    break;

        //                default:
        //                    throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName + ",����ϵ����Ա");
        //            }
        //        }
        //    }

        //    sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
        //    //sql += " AND ISNULL(Qty,0)>0";
        //    dt = SysUtils.Fill(sql);
        //    gridView3.GridControl.DataSource = dt;
        //    gridView3.GridControl.Show();


        //    //string sql = "SELECT *,0 SelectFlag FROM WH_PackBox WHERE 1=1";
        //    //sql += " AND WHID=" + SysString.ToDBString(WHID);
        //    //sql += " AND SectionID=" + SysString.ToDBString(SectionID);
        //    //sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
        //    //sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
        //    //sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
        //    //sql += " AND ColorName=" + SysString.ToDBString(ColorName);
        //    //sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
        //    //DataTable dt = SysUtils.Fill(sql);
        //    //gridView3.GridControl.DataSource = dt;
        //    //gridView3.GridControl.Show();
        //}

        #endregion
        /// <summary>
        /// ��ȡ�뵥��Ϣ
        /// </summary>
        private void GetMaDanDetail(int p_RowID)
        {
            BaseFocusLabel.Focus();
            if (SysConvert.ToString(gridView1.GetRowCellValue(PreRowID, "ItemCode")) != string.Empty)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    dtPack[p_RowID].Rows[i]["MainID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["MainID"]));
                    dtPack[p_RowID].Rows[i]["Seq"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["Seq"]));
                    dtPack[p_RowID].Rows[i]["SubSeq"] = PreRowID + 1;
                    dtPack[p_RowID].Rows[i]["BoxNo"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["BoxNo"]));
                    dtPack[p_RowID].Rows[i]["GoodsLevel"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["GoodsLevel"]));
                    if (SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"])) == 0)
                    {
                        dtPack[p_RowID].Rows[i]["Qty"] = DBNull.Value;
                    }
                    else
                    {
                        dtPack[p_RowID].Rows[i]["Qty"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"]));
                    }
                    if (SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Weight"])) == 0)
                    {
                        dtPack[p_RowID].Rows[i]["Weight"] = DBNull.Value;
                    }
                    else
                    {
                        dtPack[p_RowID].Rows[i]["Weight"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Weight"]));
                    }
                    dtPack[p_RowID].Rows[i]["Remark"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["Remark"]));
                }
            }
        }


        /// <summary>
        /// ���뵥
        /// </summary>
        private void BindPack()
        {
            if (CurRowID >= 0)
            {
                DataTable dt = dtPack[CurRowID];
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();
            }
        }


        /// <summary>
        /// �õ��뵥������
        /// </summary>
        /// <param name="List"></param>
        private void GetMadanDts(ArrayList List)
        {
            BaseFocusLabel.Focus();
            for (int j = 0; j < gridView1.RowCount; j++)//
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) != string.Empty)
                {
                    for (int m = 0; m < dtPack[j].Rows.Count; m++)//�뵥ѭ��
                    {

                        if ((dtPack[j].Rows[m]["PackNo"].ToString() != string.Empty || SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]) != 0) || SysConvert.ToDecimal(dtPack[j].Rows[m]["Weight"]) != 0)
                        {
                            IOFormDtsPack entity = new IOFormDtsPack();
                            entity.MainID = HTDataID;
                            entity.Seq = j + 1;
                            entity.SubSeq = m + 1;

                            entity.BoxNo = dtPack[j].Rows[m]["BoxNo"].ToString();
                            entity.GoodsLevel = SysConvert.ToString(dtPack[j].Rows[m]["GoodsLevel"]);
                            entity.Qty = SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]);
                            entity.Weight = SysConvert.ToDecimal(dtPack[j].Rows[m]["Weight"]);
                            entity.Remark = SysConvert.ToString(dtPack[j].Rows[m]["Remark"]);
                            //entity.FactQty = SysConvert.ToDecimal(dtPack[j].Rows[m]["FactQty"]);
                            //entity.PDQty = entity.FactQty - entity.Qty;

                            List.Add(entity);

                        }
                    }
                }
            }
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FromIOFormID = SysConvert.ToInt32(txtFormIOFormID.Text.Trim());
            entity.FormNo = txtFormNo.Text.Trim();
            //entity.HeadType = SysConvert.ToInt32(txtHeadType.Text.Trim());
            entity.HeadType = this.FormListAID;
            entity.SubType = SysConvert.ToInt32(drpSubType.EditValue);
            entity.FormDate = txtFormDate.DateTime.Date;
            // entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            //entity.WHTypeID = SysConvert.ToInt32(drpWHTypeID.EditValue);

            entity.OutDep = txtOutDep.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpDutyOP.EditValue);
            entity.WHOP = txtWHOP.Text.Trim();
            entity.PassOP = txtPassOP.Text.Trim();
            entity.DutyOP = SysConvert.ToString(drpDutyOP.EditValue);
            entity.Remark = txtRemark.Text.Trim();


            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = DateTime.Now.Date;
            }


            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            IOFormDts[] entitydts = new IOFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new IOFormDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].WHID = SysConvert.ToString(gridView1.GetRowCellValue(i, "WHID"));
                    entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID"));
                    entitydts[index].SBitID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SBitID"));

                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));

                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));

                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    if (entitydts[index].Unit == "RMB/KG")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Weight;
                    }
                    if (entitydts[index].Unit == "RMB/M")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                    }
                    //entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));

                    entitydts[index].MoveWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MoveWeight"));
                    entitydts[index].MoveQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MoveQty"));
                    entitydts[index].MovePieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MovePieceQty"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region �����¼�
        /// <summary>
        /// ˫�����ɵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    txtFormNo.Text = "";
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetWHFormNo(this.FormListAID, SysConvert.ToInt32(drpSubType.EditValue), SysConvert.ToString(drpWHID.EditValue));

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region �ύ�������ύ����
        /// <summary>
        /// �ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                IOFormRule rule = new IOFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.���ύ);

                #region old
                ////if (!HTSubmitCheck(FormStatus.�ύ))
                ////{
                ////    return;
                ////}

                ////HTSubmit(HTDataTableName, HTDataID.ToString());
                ////sc �̵��ύǰУ��ϸ������ϸ���Ƿ����
                //for (int i = 0; i < gridView2.RowCount; i++)
                //{
                //    string sql = "SELECT Qty FROM WH_PackBox WHERE BoxNo = " + SysString.ToDBString(SysConvert.ToString((gridView2.GetRowCellValue(i, "BoxNo"))));
                //    DataTable dt = SysUtils.Fill(sql);
                //    if (dt.Rows.Count != 0)
                //    {
                //        if (SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty")) != SysConvert.ToDecimal(dt.Rows[0]["Qty"]))
                //        {
                //            this.ShowMessage("��ϸ��:" + SysConvert.ToString((gridView2.GetRowCellValue(i, "BoxNo"))) + "  �ѿ���ƥ������ϸ���Ӧ���ϣ�����!");
                //            return;
                //        }
                //    }
                //}

                //IOFormRule rule = new IOFormRule();
                //rule.RSubmit(HTDataID, (int)ConfirmFlag.���ύ);
                #endregion

                FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �����ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }
                IOFormRule rule = new IOFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.δ�ύ);
                #region old
                ////if (!HTSubmitCheck(FormStatus.�ύ))
                ////{
                ////    return;
                ////}

                ////HTSubmit(HTDataTableName, HTDataID.ToString());


                //IOFormRule rule = new IOFormRule();
                //rule.RSubmit(HTDataID, (int)ConfirmFlag.δ�ύ);
                #endregion

                FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region �����
        /// <summary>
        /// ������͸ı�󶨲�ͬ�Ŀͻ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSubType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtFormNo_DoubleClick(null, null);
                Common.BindSBit(drpSBitID, SysConvert.ToString(drpSubType.EditValue), false);
                Common.BindWHByFormList(drpWH, SysConvert.ToInt32(drpSubType.EditValue), false);
                string sql = "SELECT * FROM Enum_FormList WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"]);
                    saveFillDataType = SysConvert.ToInt32(dt.Rows[0]["FillDataTypeID"]);
                    saveTHLoadFormListIDStr = SysConvert.ToString(dt.Rows[0]["THLoadFormListIDStr"]);
                    if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)//�༭״̬��
                    {
                        if (dt.Rows[0]["DefaultWHID"].ToString() != string.Empty)
                        {
                            drpWHID.EditValue = dt.Rows[0]["DefaultWHID"].ToString();
                        }
                    }
                }
                else
                {
                    saveLoadFormType = 0;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// �õ�HeadType
        /// </summary>
        /// <param name="p_WHType"></param>
        /// <returns></returns>
        private int GetHeadType(int p_WHType)
        {

            string sql = "SELECT ID From Enum_FormList WHERE WHTypeID=" + SysString.ToDBString(p_WHType);
            sql += " AND WHQtyPosID=1 AND ParentID in(1,2)";//���

            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["ID"]);
            }
            else
            {
                return 0;
            }

        }
        #endregion


        #region ˫�����ؿ��
        /// <summary>
        /// ˫��������ص���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    RestxtItemCode_DoubleClick(null, null);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ����Grid����
        /// </summary>
        /// <param name="p_StorgeID">���ID</param>
        private void BindGridData(int p_StorgeID, int p_RowID, string p_SODts, string p_SaleDts)
        {
            Storge entity = new Storge();
            entity.ID = p_StorgeID;
            entity.SelectByID();

            if (entity.ItemCode != "")
            {
                if (p_SODts != string.Empty)
                {
                    gridView1.SetRowCellValue(p_RowID, "DtsSO", p_SODts);
                    gridView1.SetRowCellValue(p_RowID, "DtsSaleOPID", p_SaleDts);
                }

                gridView1.SetRowCellValue(p_RowID, "WHID", entity.WHID);
                gridView1.SetRowCellValue(p_RowID, "SectionID", entity.SectionID);
                gridView1.SetRowCellValue(p_RowID, "SBitID", entity.SBitID);
                gridView1.SetRowCellValue(p_RowID, "DtsVendorID", entity.VendorID);


                gridView1.SetRowCellValue(p_RowID, "ItemCode", entity.ItemCode);
                gridView1.SetRowCellValue(p_RowID, "ItemName", entity.ItemName);
                gridView1.SetRowCellValue(p_RowID, "ItemStd", entity.ItemStd);
                //gridView1.SetRowCellValue(p_RowID, "ItemModel", entity.ItemModel);
                gridView1.SetRowCellValue(p_RowID, "Batch", entity.Batch);
                gridView1.SetRowCellValue(p_RowID, "VendorBatch", entity.VendorBatch);
                gridView1.SetRowCellValue(p_RowID, "Unit", entity.Unit);
                //gridView1.SetRowCellValue(p_RowID, "YarnStatus", entity.YarnStatus);
                //gridView1.SetRowCellValue(p_RowID, "YarnTypeID", entity.YarnTypeID);
                //gridView1.SetRowCellValue(p_RowID, "TubeQty", entity.TubeQty);
                //gridView1.SetRowCellValue(p_RowID, "TubeGW", entity.TubeGW);
                //gridView1.SetRowCellValue(p_RowID, "Twist", entity.Twist);
                ////gridView1.SetRowCellValue(p_RowID,"SinglePrice",entity.SinglePrice);
                //gridView1.SetRowCellValue(p_RowID, "PieceQty", entity.PieceQty);
                //gridView1.SetRowCellValue(p_RowID, "Needle", entity.Needle);
                gridView1.SetRowCellValue(p_RowID, "JarNum", entity.JarNum);
                //gridView1.SetRowCellValue(p_RowID, "JarNo", entity.JarNo);
                gridView1.SetRowCellValue(p_RowID, "ColorName", entity.ColorName);
                gridView1.SetRowCellValue(p_RowID, "ColorNum", entity.ColorNum);

                gridView1.SetRowCellValue(p_RowID, "Remark", entity.Remark);

                //gridView1.SetRowCellValue(p_RowID, "Weight", entity.Weight);       
                //gridView1.SetRowCellValue(p_RowID, "Qty", entity.FreeQty);//���ؿ�����

                gridView1.SetRowCellValue(p_RowID, "SourceWeight", entity.Weight);
                gridView1.SetRowCellValue(p_RowID, "SourceQty", entity.FreeQty);//���ؿ�����

                gridView1.SetRowCellValue(p_RowID, "Amount", entity.Qty * SysConvert.ToDecimal(gridView1.GetRowCellValue(p_RowID, "SinglePrice")));


                //drpWHTypeID.EditValue = SysConvert.ToInt32(entity.WHTypeID);



                drpWHID.EditValue = SysConvert.ToString(entity.WHID);
                //txtDSN.Text = entity.DSN;
                //txtSSN.Text = entity.SSN;
                //drpCompanyTypeID.EditValue = SysConvert.ToInt32(entity.CompanyTypeID);
            }
        }


        /// <summary>
        /// ˫��������ص���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckShow_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select BoxNo,ItemCode,ColorNum,ColorName,JarNum,Qty,Weight,GoodsLevel,'' SourceType from WH_PackBox where 1=0";
                DataTable dtShow = SysUtils.Fill(sql);

                #region  ///�Աȿ���ɨ����������
                string p_WHID = SysConvert.ToString(gridView1.GetRowCellValue(0, "WHID"));//��
                string p_SectionID = SysConvert.ToString(gridView1.GetRowCellValue(0, "SectionID"));//��
                string p_SBitID = SysConvert.ToString(gridView1.GetRowCellValue(0, "SBitID"));//λ
                string ISN1 = string.Empty;
                string ISN2 = string.Empty;
                string ShowInfo = string.Empty;
                sql = "SELECT * FROM WH_PackBox WHERE 1=1";
                sql += " AND WHID=" + SysString.ToDBString(p_WHID);
                sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
                sql += " AND SBitID=" + SysString.ToDBString(p_SBitID);
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
                sql += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0)";
                sql += " AND BoxNo not in(select BoxNo from WH_IOFormDtsPack where MainID=" + HTDataID + ")";
                DataTable dt = SysUtils.Fill(sql);//����д����룬��������ɨ��ûɨ�赽
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (ISN1 != "")
                        {
                            ISN1 += ",";
                        }
                        ISN1 += SysConvert.ToString(dt.Rows[i]["BoxNo"]);

                        DataRow dr = dtShow.NewRow();
                        dr["BoxNo"] = SysConvert.ToString(dt.Rows[i]["BoxNo"]);
                        dr["ItemCode"] = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                        dr["ColorNum"] = SysConvert.ToString(dt.Rows[i]["ColorNum"]);
                        dr["ColorName"] = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                        dr["JarNum"] = SysConvert.ToString(dt.Rows[i]["JarNum"]);
                        dr["Qty"] = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        dr["Weight"] = SysConvert.ToDecimal(dt.Rows[i]["Weight"]);
                        dr["GoodsLevel"] = SysConvert.ToString(dt.Rows[i]["GoodsLevel"]);
                        //dr["Unit"] = SysConvert.ToString(dt.Rows[i]["Unit"]);
                        dr["SourceType"] = "ȱ������";
                        dtShow.Rows.Add(dr);


                    }
                }
                sql = "select * from WH_PackBox where BoxNo in(";
                sql += "select BoxNo from WH_IOFormDtsPack where MainID=" + HTDataID;
                sql += " AND BoxNo not in(select  BoxNo FROM WH_PackBox WHERE 1=1";
                sql += " AND WHID=" + SysString.ToDBString(p_WHID);
                sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
                sql += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0)";
                sql += ")";
                sql += ")";
                DataTable dt2 = SysUtils.Fill(sql);//ɨ�������,���Ǵ˿������ û�и�����
                if (dt2.Rows.Count != 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        if (ISN2 != "")
                        {
                            ISN2 += ",";
                        }
                        ISN2 += SysConvert.ToString(dt2.Rows[i]["BoxNo"]);

                        DataRow dr = dtShow.NewRow();
                        dr["BoxNo"] = SysConvert.ToString(dt2.Rows[i]["BoxNo"]);
                        dr["ItemCode"] = SysConvert.ToString(dt2.Rows[i]["ItemCode"]);
                        dr["ColorNum"] = SysConvert.ToString(dt2.Rows[i]["ColorNum"]);
                        dr["ColorName"] = SysConvert.ToString(dt2.Rows[i]["ColorName"]);
                        dr["JarNum"] = SysConvert.ToString(dt2.Rows[i]["JarNum"]);
                        dr["Qty"] = SysConvert.ToDecimal(dt2.Rows[i]["Qty"]);
                        dr["Weight"] = SysConvert.ToDecimal(dt2.Rows[i]["Weight"]);
                        dr["GoodsLevel"] = SysConvert.ToString(dt2.Rows[i]["GoodsLevel"]);
                        //dr["Unit"] = SysConvert.ToString(dt2.Rows[i]["Unit"]);
                        dr["SourceType"] = "�������";
                        dtShow.Rows.Add(dr);

                    }
                }

                gridView4.GridControl.DataSource = dtShow;
                gridView4.GridControl.Show();

                //if(ISN1!="")
                //{
                //    ShowInfo += "ȱ������ϼ�" + SysConvert.ToString(dt.Rows.Count) + "��" + Environment.NewLine;
                //    ShowInfo += ISN1 + Environment.NewLine;
                //}
                //if (ISN2 != "")
                //{
                //    ShowInfo += "�������ϼ�" + SysConvert.ToString(dt2.Rows.Count) + "��" + Environment.NewLine;
                //    ShowInfo += ISN2 + Environment.NewLine;
                //}

                //this.ShowInfoMessage(ShowInfo);


                #endregion
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region �����¼�����ӡ��أ�
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
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.תPDF, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
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

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.��ӡ, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
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
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ3))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.���, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion

        #region ���ؿ��
        /// <summary>
        /// ���ؾ��ؽ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemQty_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Qty = 0;
                decimal Price = 0;
                decimal Amount = 0;
                decimal Weight = 0;
                decimal WAmount = 0;
                Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SinglePrice"));
                Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));

                Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Weight"));
                Amount = Qty * Price;

                WAmount = Weight * Price;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Amount", Amount);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "WAmount", WAmount);

                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DiffWeight", (Weight - Qty));

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {


                //Common.ProcHideSectionSbit(SysConvert.ToString(drpWHID.EditValue), gridView1);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpCSectionID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                //Common.BindSBit(drpCSBitID, SysConvert.ToString(drpWHID.EditValue), SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID")), false);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ˫����Ʒ������ؿ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadStorge frm = new frmLoadStorge();
                    frm.SubType = SysConvert.ToString(drpSubType.EditValue);
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.StorgeID != null && frm.StorgeID.Length != 0)
                    {

                        for (int i = 0; i < frm.StorgeID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.StorgeID[i]);
                        }
                        SetWH(str);

                        gridViewRowChanged1(gridView1);
                    }


                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ؿ����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void SetWH(string p_Str)
        {
            string[] itembuyid = p_Str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < itembuyid.Length + index; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_Storge WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[length]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                    gridView1.SetRowCellValue(i, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                    gridView1.SetRowCellValue(i, "SBitID", SysConvert.ToString(dt.Rows[0]["SBitID"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(i, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(i, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    gridView1.SetRowCellValue(i, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", DBNull.Value);
                    }

                    if (SysConvert.ToDecimal(dt.Rows[0]["Qty"]) != 0)
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "Qty", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["Weight"]) != 0)
                    {
                        gridView1.SetRowCellValue(i, "Weight", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "Weight", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));//���ͻ�
                    gridView1.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dt.Rows[0]["SO"]));//����������
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));//����ͬ��
                    gridView1.SetRowCellValue(i, "DtsSaleOPID", SysConvert.ToString(dt.Rows[0]["DutyOPID"]));//���ҵ��
                    gridView1.SetRowCellValue(i, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));

                    length++;

                }
            }
        }

        /// <summary>
        /// �õ���ǰ�����
        /// </summary>
        /// <returns></returns>
        private int checkRowSet()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == string.Empty)
                {
                    index = i;
                    return index;
                }
            }
            return index;

        }
        #endregion

        #region �뵥����

        /// <summary>
        /// ���뵥��ϸ��ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    BaseFocusLabel.Focus();

                    MDStorgeSelectChange_Event(gridView3.FocusedRowHandle);

                    //DataTable dto = (DataTable)gridView2.GridControl.DataSource;
                    //for (int i = 0; i < gridView3.RowCount; i++)
                    //{
                    //    if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                    //    {
                    //        string BoxNo = SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo"));
                    //        decimal Qty = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Qty"));

                    //        if (SysConvert.ToInt32(gridView3.GetRowCellValue(i, "SelectFlag")) == 1)
                    //        {
                    //            SetGrid2(BoxNo, Qty);
                    //        }
                    //        else
                    //        {
                    //            SetGrid2Del(BoxNo, Qty);

                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ���ؿ���뵥ѡ��ı���
        /// </summary>
        void MDStorgeSelectChange_Event(int rowID)
        {
            DataTable dtStorgePack = (DataTable)gridView3.GridControl.DataSource;

            if (SysConvert.ToString(dtStorgePack.Rows[rowID]["BoxNo"]) != string.Empty)
            {
                string BoxNo = SysConvert.ToString(dtStorgePack.Rows[rowID]["BoxNo"]);
                decimal Qty = SysConvert.ToDecimal(dtStorgePack.Rows[rowID]["Qty"]);
                decimal Weight = SysConvert.ToDecimal(dtStorgePack.Rows[rowID]["Weight"]);
                string GoodsLevel = SysConvert.ToString(dtStorgePack.Rows[rowID]["GoodsLevel"]);
                if (SysConvert.ToInt32(dtStorgePack.Rows[rowID]["SelectFlag"]) == 1)
                {
                    SetGrid2(BoxNo, Qty, Weight, GoodsLevel);
                }
                else
                {
                    SetGrid2Del(BoxNo);

                }
            }
        }


        /// <summary>
        /// ���ã��ж������Ƿ���ڣ��粻���ڣ���ɸ�ֵ
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2(string BoxNo, decimal Qty, decimal Weight, string GoodsLevel)
        {
            bool findFlag = false;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) == BoxNo)
                {
                    findFlag = true;
                }
            }
            if (findFlag)
            {
                return;
            }
            DataTable dtPackSource = (DataTable)gridView2.GridControl.DataSource;
            for (int i = 0; i < dtPackSource.Rows.Count; i++)
            {
                if (SysConvert.ToString(dtPackSource.Rows[i]["BoxNo"]) == string.Empty)
                {
                    dtPackSource.Rows[i]["BoxNo"] = BoxNo;
                    dtPackSource.Rows[i]["Qty"] = Qty;
                    dtPackSource.Rows[i]["Weight"] = Weight;
                    dtPackSource.Rows[i]["GoodsLevel"] = GoodsLevel;

                    SetGrid1Qty();
                    return;
                }
            }
            //û�и�ֵ�ɹ���˵���в���
            dtPackSource.Rows.Add(dtPackSource.NewRow());
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["BoxNo"] = BoxNo;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["Qty"] = Qty;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["Weight"] = Weight;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["GoodsLevel"] = GoodsLevel;

            SetGrid1Qty();
        }

        /// <summary>
        /// ���ã��ж������Ƿ���ڣ�����ڣ����ɾ��
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2Del(string BoxNo)
        {
            bool findFlag = false;
            int findIndex = -1;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) == BoxNo)
                {
                    findIndex = i;
                    findFlag = true;
                }
            }
            if (!findFlag)
            {
                return;
            }
            DataTable dtPackSource = (DataTable)gridView2.GridControl.DataSource;
            dtPackSource.Rows.RemoveAt(findIndex);

            SetGrid1Qty();
        }


        /// <summary>
        /// ����Grid1Qty����
        /// </summary>
        void SetGrid1Qty()
        {
            int pieceQty = 0;
            decimal qty = 0;
            decimal weight = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) != string.Empty)
                {
                    pieceQty++;
                    qty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                    weight += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Weight"));
                }
                else//������������У��Զ�����ѭ�������Ч��
                {
                    break;
                }
            }

            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MovePieceQty", pieceQty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MoveQty", qty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MoveWeight", weight);
        }

        private void SetIOFormDetail()
        {

            #region
            int TempID = -1;
            int PSeq = -1;
            int j = 0;//����gridview���к�
            string sql = string.Empty;
            sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
            DataTable dt = SysUtils.Fill(sql);
            for (int i = 0; i < 150; i++)
            {
                dtPack[i] = dt.Clone();
            }
            DataTable dtVirtual = (DataTable)gridView1.GridControl.DataSource;
            foreach (DataRow dr in dtVirtual.Rows)
            {
                if (dr["ItemCode"].ToString() != string.Empty)
                {
                    if (dr["Seq"].ToString() == string.Empty)
                    {
                        PSeq = j;
                    }
                    else
                    {
                        PSeq = SysConvert.ToInt32(dr["Seq"].ToString()) - 1;
                    }

                    if (this.HTFormStatus == FormStatus.����)
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
                        TempID = SysUtils.Fill(sql).Rows.Count;
                        dtPack[PSeq] = SysUtils.Fill(sql);
                        j++;
                    }
                    else
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=1";
                        sql += " AND MainID=" + SysString.ToDBString(dr["MainID"].ToString());
                        sql += " AND Seq=" + SysString.ToDBString(dr["Seq"].ToString());

                        dtPack[PSeq] = SysUtils.Fill(sql);
                    }
                }
            }
            for (int i = 0; i < 150; i++)
            {
                Common.AddDtRow(dtPack[i], 50);
            }
            #endregion
        }
        #endregion

        #region ȫѡ ��ѡ
        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                        {
                            if (chkAll.Checked)
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 1);
                                MDStorgeSelectChange_Event(i);
                            }
                            else
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 0);
                                MDStorgeSelectChange_Event(i);
                            }


                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��ѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAny_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                        {
                            if (SysConvert.ToInt32(gridView3.GetRowCellValue(i, "SelectFlag")) == 0)
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 1);
                                MDStorgeSelectChange_Event(i);
                            }
                            else
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 0);
                                MDStorgeSelectChange_Event(i);
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �뵥��ϸ�����ı�
        /// <summary>
        /// ֵ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                //if (e.Column.FieldName == "FactQty")
                //{
                //    decimal pdqty = SysConvert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "FactQty"))
                //    - SysConvert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Qty"));
                //    if (pdqty != 0)
                //    {
                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "PDQty", pdqty);
                //    }
                //    else
                //    {
                //        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "PDQty", DBNull.Value);
                //    }
                //    SetGrid1Qty();
                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SBitID")
            {
                string SBitID = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "SBitID"));
                string sql = "SELECT * FROM WH_SBit WHERE SBitID =" + SysString.ToDBString(SBitID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                    gridView1.SetRowCellValue(e.RowHandle, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                }
            }
        }
        #endregion


    }
}