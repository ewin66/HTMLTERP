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
    public partial class frmYQWHEdit : frmAPBaseUIFormEdit
    {
        public frmYQWHEdit()
        {
            InitializeComponent();
        }

        #region ȫ�ֱ���

        private DataTable[] dtPack = new DataTable[150];//�뵥��Ϣ��
        private int PreRowID = -1;//��ʼ�к�
        private int CurRowID = -1;//��ǰ�к�
        int saveNoLoadCheckDayNum = 0;//δ���رȶ���������ֹ����ʱ�������ϵͳ����
        int saveLoadFormType = 0;//���ص�������
        int saveFillDataType = 0;//������������

        string saveTHLoadFormListIDStr = string.Empty;

        //private int DtsID = 0;
        //private int DtsSeq = 0;
        #endregion
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            
            if (txtFormNo.Text.Trim() == string.Empty)
            {
                this.ShowMessage("�����뵥��");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
            {
                this.ShowMessage("��ѡ����ȱ����");
                drpVendorID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpWHID.EditValue) == string.Empty)
            {
                this.ShowMessage("��ѡ��ֿ�");
                drpWHID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSubType.EditValue) == string.Empty)
            {
                this.ShowMessage("��ѡ����ȱ����");
                drpSubType.Focus();
                return false;
            }

            if (!this.CheckCorrectDts())
            {
                return false;
            }

          

            return true;
        }

        public bool CheckCorrectDts2()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                string DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                string VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                string VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                int PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                if (DtsSO != "")
                {
                    string sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(DtsSO);
                    sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
                    sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                    sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                    sql += " AND VColorNum=" + SysString.ToDBString(VColorNum);
                    sql += " AND VColorName=" + SysString.ToDBString(VColorName);
                    sql += " AND JarNum="+SysString.ToDBString(JarNum);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0]["PieceQty"]) != PieceQty)
                        {
                            if (MessageBox.Show("��" + SysConvert.ToInt32(i + 1).ToString() + "������ϸ�����뷢������ϸ������һ������������ϸ�����ǣ�" + SysConvert.ToInt32(dt.Rows[0]["PieceQty"]).ToString()+"���Ƿ��������", "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (SysConvert.ToDecimal(dt.Rows[0]["Qty"]) != Qty)
                        {
                            if (MessageBox.Show("��" + SysConvert.ToInt32(i + 1).ToString() + "�����������뷢������������һ�����������������ǣ�" + SysConvert.ToDecimal(dt.Rows[0]["Qty"]).ToString() + "���Ƿ��������", "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            YQFormDtsRule rule = new YQFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            YQFormRule rule = new YQFormRule();
            YQForm entity = EntityGet();
            YQFormDts[] entitydts = EntityDtsGet();
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            GetMaDanDetail(CurRowID);
            ArrayList List = new ArrayList();
            GetMadanDts(List);
            rule.RAdd2(entity, entitydts,List);
            return entity.ID;
        }


       
        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            YQFormRule rule = new YQFormRule();
            YQForm entity = EntityGet();
            YQFormDts[] entitydts = EntityDtsGet();
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
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
            YQForm entity = new YQForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpVendorID.EditValue = entity.VendorID.ToString();
            drpXZ.EditValue = entity.XZ.ToString();
            drpWHID.EditValue = entity.WHID.ToString();
            drpSubType.EditValue = entity.SubType;
            txtDM.Text = entity.DM.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtInvoiceNo.Text = entity.InvoiceNo.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtRemark.Text = entity.Remark;
            drpFHTypeID.EditValue =SysConvert.ToInt32(entity.FHTypeID);
            txtKDNo.Text = entity.KDNo.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            SetYQFormDetail();
            BindPack();
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

                        if ((dtPack[j].Rows[m]["PackNo"].ToString() != string.Empty || SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]) != 0))
                        {
                            YQFormDtsPack entity = new YQFormDtsPack();
                            entity.MainID = HTDataID;
                            entity.Seq = j + 1;
                            entity.SubSeq = m + 1;

                            entity.BoxNo = dtPack[j].Rows[m]["BoxNo"].ToString();
                            entity.Qty = SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]);
                            entity.Remark = SysConvert.ToString(dtPack[j].Rows[m]["Remark"]);
                            entity.PDQty = SysConvert.ToDecimal(dtPack[j].Rows[m]["PDQty"]);
                            entity.FactQty = SysConvert.ToDecimal(dtPack[j].Rows[m]["FactQty"]);


                            List.Add(entity);

                        }
                    }
                }
            }
        }
        private void SetYQFormDetail()
        {
            
            #region
            int TempID = -1;
            int PSeq = -1;
            int j = 0;//����gridview���к�
            string sql = string.Empty;
            sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_YQFormDtsPack WHERE 1=0";
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
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_YQFormDtsPack WHERE 1=0";
                        TempID = SysUtils.Fill(sql).Rows.Count;
                        dtPack[PSeq] = SysUtils.Fill(sql);
                        j++;
                    }
                    else
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_YQFormDtsPack WHERE 1=1";
                        sql += " AND MainID=" + SysString.ToDBString(dr["MainID"].ToString());
                        sql += " AND Seq=" + SysString.ToDBString(dr["Seq"].ToString());

                        dtPack[PSeq] = SysUtils.Fill(sql);
                    }
                }
            }
            for (int i = 0; i < 150; i++)
            {
                Common.AddDtRow(dtPack[i], 150);
            }
            #endregion
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
                    dtPack[p_RowID].Rows[i]["Qty"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"]));
                    dtPack[p_RowID].Rows[i]["Remark"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["Remark"]));
                }
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            YQFormRule rule = new YQFormRule();
            YQForm entity = EntityGet();
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
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
         

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_YQForm";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2, gridView3};
            this.HTCheckDataField = new string[] {"ItemCode","SectionID","Qty"};//������ϸУ�����¼���ֶ�
            Common.BindOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�,(int)EnumVendorType.����}, true);
            new VendorProc(drpVendorID);
            Common.BindWHByFormList(drpWHID,this.FormListAID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_YQFormDts", "GoodsLevel", true);
            Common.BindYQType(drpSubType,true);
           
            Common.BindCLS(drpXZ, "WH_YQForm", "XZ", true);
            //Common.BindEnumUnit(RestxtUnit, true);

            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitFab", true);

            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
            this.ToolBarItemAdd(28, "btnLoad", "����", false, btnLoad_Click);
            this.ToolBarItemAdd(28, "btnLoadStorge", "���ؿ��", false, btnLoadStorge_Click);
           
          
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
        /// �޸ĵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnUpdateAmount_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.��ѯ)
                {
                    if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��10))
                    {
                        this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                        return;
                    }
                    if (HTDataID == 0)
                    {
                        this.ShowMessage("�뱣�浥��");
                        return;
                    }
                    frmUpdateWHAmount frm = new frmUpdateWHAmount();
                    frm.ID = HTDataID;
                    frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    frm.ShowDialog();
                    BindGridDts();
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.DtsID.ToString() });
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ͨ�ô�����ط����������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridColumnReadOnly(gridView2, new string[] { "BoxNo", "Qty" }, true);
            ProcessGrid.SetGridColumnReadOnly(gridView3, new string[] { "BoxNo", "Qty" }, true);
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
        /// <summary>
        /// ���ؿ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadStorge_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    if (Common.CheckLookUpEditBlank(drpSubType))
                    {
                        this.ShowMessage("��ѡ�񵥾�����");
                        return;
                    }

                    if (SysConvert.ToString(drpWHID.EditValue) == "")
                    {
                        this.ShowMessage("��ѡ��ֿ�");
                        drpWHID.Focus();
                        return;
                    }
                    frmLoadStorge frm = new frmLoadStorge();
                    frm.WHID = SysConvert.ToString(drpWHID.EditValue);
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
        /// ���زɹ���
        /// </summary>
        private void WHLoadItemBuyForm()
        {
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                SetWH(str);
               

            }
        }

        /// <summary>
        /// ���ؿ����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void SetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_Storge WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(setRowID, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                    gridView1.SetRowCellValue(setRowID, "SBitID", SysConvert.ToString(dt.Rows[0]["SBitID"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));

                    gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["DutyOPID"]));
                    setRowID++;
                }
            }
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private YQForm EntityGet()
        {
            YQForm entity = new YQForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime;
            entity.XZ = drpXZ.Text.Trim();
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.WHType = drpWHID.EditValue.ToString();
            entity.SubType =SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            //entity.DM = txtDM.Text.Trim();
           // entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeadType = this.FormListAID;
            entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.KDNo = txtKDNo.Text.Trim();
            entity.FHTypeID = SysConvert.ToInt32(drpFHTypeID.EditValue);
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private YQFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            YQFormDts[] entitydts = new YQFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new YQFormDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].WHID = SysConvert.ToString(drpWHID.EditValue); 
  			 		entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID")); 
  			 		entitydts[index].SBitID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SBitID"));

                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));

  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch")); 
  			 		entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].MoveQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MoveQty")); 
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));
                    if (entitydts[index].SinglePrice == 0)
                    {
                        entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")) + entitydts[index].DYPrice;
                    }
                    else
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].MoveQty + entitydts[index].DYPrice;
                    }
  			 		entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel")); 
  			 		entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum")); 
  			 		entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName")); 
  			 		entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));

                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));

                    entitydts[index].PackDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "PackDts"));

                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));                    
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));

                    entitydts[index].DtsInVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsInVendorID"));
                    entitydts[index].InSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSO"));
                    entitydts[index].InOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "InOrderFormNo"));
                    entitydts[index].InSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));

                    entitydts[index].DLaodDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLaodDtsID"));
                    entitydts[index].DLoadFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLoadFormNo"));
                    entitydts[index].DLoadSubType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLoadSubType"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region �����������
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    if (Common.CheckLookUpEditBlank(drpSubType))
                    {
                        this.ShowMessage("��ѡ����ȱ����");
                        drpSubType.Focus();
                        return;
                    }
                    if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    {
                        this.ShowMessage("��ѡ����ȱ��λ");
                        drpVendorID.Focus();
                        return;
                    }
                    WHLoadWHYQForm();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region �����ͻ���
        /// <summary>
        /// �����ͻ���
        /// </summary>
        private void WHLoadFHForm()
        {
            if (SysConvert.ToInt32(drpSubType.EditValue) == 0)
            {
                this.ShowMessage("��ѡ���������");
                drpSubType.Focus();
                return;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ͻ�");
                drpVendorID.Focus();
                return;
            }
            int SubType = SysConvert.ToInt32(drpSubType.EditValue);
            frmLoadFHForm frm = new frmLoadFHForm();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT DtsSO+ItemCode+ColorNum+ColorName OrderFormNo FROM UV1_WH_YQFormDts";
            if (saveNoLoadCheckDayNum != 0)
            {
                sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            sql += ")";
            frm.NoLoadCondition = sql;
            switch (saveFillDataType)
            {
                case  (int)EnumFillDataType.���۳����׼�����:
                    frm.SourceID=(int)EnumFHForType.���ۺ�ͬ;
                    break;
                //case (int)EnumFillDataType.�������۳����׼�����:
                //    frm.SourceID=(int)EnumFHForType.������;
                //    break;

            }
           
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.FHFormID != null && frm.FHFormID.Length != 0)
            {

                for (int i = 0; i < frm.FHFormID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.FHFormID[i]);
                }
                WHLoadFHFormSetWH(str, SubType);
                gridViewRowChanged1(gridView1);


            }
        }

        private void WHLoadFHFormSetWH(string p_Str, int p_SubType)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] fhformid = p_Str.Split(',');
            for (int i = 0; i < fhformid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_FHFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(fhformid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
                    //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                    switch (saveFillDataType)
                    {
                        case (int)EnumFillDataType.���۳����׼�����:
                            gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                            break;
                        //case (int)EnumFillDataType.�������۳����׼�����:
                        //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsDYFormNo"]));
                        //    break;
                    }
                    gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[0]["SaleOPID"]));

                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }

                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    }

                    string outsectionID, outSbitID;
                    WHLoadFHFormSetWH(dt.Rows[0], out outsectionID, out outSbitID);

                    gridView1.SetRowCellValue(setRowID, "SectionID", outsectionID);
                    gridView1.SetRowCellValue(setRowID, "SBitID",outSbitID);
                    setRowID++;
                }
            }
        }

        /// <summary>
        /// ���ؿ���һ����
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        void  WHLoadFHFormSetWH(DataRow dr,out string o_SectionID,out string o_SBitID)
        {
            string outstr = string.Empty;
            string sql = string.Empty;
            sql = "SELECT SectionID,SBitID FROM WH_Storge WHERE WHID=" + SysString.ToDBString(SysConvert.ToString(drpWHID.EditValue));
            sql += " AND ItemCode=" +SysString.ToDBString(dr["ItemCode"].ToString());
            sql += " AND ColorNum=" + SysString.ToDBString(dr["ColorNum"].ToString());
            sql += " AND ColorName=" + SysString.ToDBString(dr["ColorName"].ToString());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                o_SectionID = SysConvert.ToString(dt.Rows[0]["SectionID"]);
                o_SBitID = SysConvert.ToString(dt.Rows[0]["SBitID"]);
            }
            else
            {
                o_SectionID = "";
                o_SBitID = "";
            }
            return ;
        }
        #endregion

        #region ���س���ⵥ
        /// <summary>
        /// ���س���ⵥ
        /// </summary>
        private void WHLoadWHYQForm()
        {
            frmLoadYQIOForm frm = new frmLoadYQIOForm();
            string sql = "";
            sql += " AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //sql += " AND SubType IN (1101,1102,1201,1203)";
            //sql += " AND ISNULL(InvoiceQty,0)=0";
            frm.HTLoadConditionStr = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.DtsID != null && frm.DtsID.Length != 0)
            {

                for (int i = 0; i < frm.DtsID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.DtsID[i]);
                }
                WHLoadWHYQFormSetWH(str);
                gridViewRowChanged1(gridView1);
            }
        }

        /// <summary>
        /// ���س���ⵥ��Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadWHYQFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {

                    gridView1.SetRowCellValue(setRowID, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["DLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DtsVendorID"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    //if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    //}
                    //if (SysConvert.ToString(dt.Rows[0]["Weight"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "Weight", SysConvert.ToString(dt.Rows[0]["Weight"]));
                    //}
                    gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));

                    gridView1.SetRowCellValue(setRowID, "DLaodDtsID", SysConvert.ToInt32(dt.Rows[0]["DtsID"]));
                    gridView1.SetRowCellValue(setRowID, "DLoadFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLoadSubType", SysConvert.ToInt32(dt.Rows[0]["SubType"]));
                    setRowID++;
                }
            }
        }

        #endregion

        #region ����Ⱦ���ӹ���
        /// <summary>
        /// ����Ⱦ���ӹ���
        /// </summary>
        private void WHLoadFabricProcessForm()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��"+drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadRbJG frm = new frmLoadRbJG();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_YQFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            //frm.LoadType = (int)EnumMLType.����;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadFabricProcessFormSetWH(str);

            }
        }

        /// <summary>
        /// ����Ⱦ���ӹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricProcessFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_FabricProcessDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    if (i == 0)
                    {
                        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["DyeFactorty"]);
                    }

                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32((int)EnumMLType.����));
                    //if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    //}

                    setRowID++;
                }
            }
        }

        #endregion

        #region ����ӡ���ӹ���
        /// <summary>
        /// ����ӡ���ӹ���
        /// </summary>
        private void WHLoadPrintingProcessForm()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadYHJG frm = new frmLoadYHJG();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_YQFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
           // frm.LoadType = (int)EnumMLType.����;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {

                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadPrintingProcessFormSetWH(str);

            }
        }

        /// <summary>
        /// ����ӡ���ӹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadPrintingProcessFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_PrintingProcessDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    if (i == 0)
                    {
                        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["DyeFactorty"]);
                    }
                    //foreach (DataRow dt.Rows[0] in dt.Rows)
                    //{
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWeight", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "MWidth", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", "");
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32((int)EnumMLType.����));
                    //if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                    //{
                    //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SingPrice"]));
                    //}

                    setRowID++;
                    //}
                }
            }
        }

        #endregion

        #region  ���ذ���֯��ӹ���
        /// <summary>
        ///  ���ذ���֯��ӹ���
        /// </summary>
        private void WHLoadWeaveProcessForm()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��" + drpVendorID.ToolTip.ToString());
                drpVendorID.Focus();
                return;
            }
            frmLoadZZJG frm = new frmLoadZZJG();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            string sql = string.Empty;
            //sql += " AND ISNULL(TotalRecQty,0)<>0";
            //sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(DtsSO+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WH_YQFormDts";
            //if (saveNoLoadCheckDayNum != 0)
            //{
            //    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            //}
            //sql += ")";
            // frm.LoadType = (int)EnumMLType.����;
            frm.NoLoadCondition = sql;
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
            {
                for (int i = 0; i < frm.ItemBuyID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.ItemBuyID[i]);
                }
                WHLoadWeaveProcessFormSetWH(str);

            }
        }

        /// <summary>
        /// ���ذ���֯��ӹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadWeaveProcessFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_WeaveProcessDts WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (i == 0)
                        {
                            drpVendorID.EditValue = SysConvert.ToString(dr["DyeFactory"]);
                        }
                        gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dr["ItemCode"]));
                        gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dr["ItemName"]));
                        gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dr["ItemStd"]));
                        gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dr["ItemModel"]));
                        gridView1.SetRowCellValue(setRowID, "Batch", SysConvert.ToString(dr["Batch"]));
                        gridView1.SetRowCellValue(setRowID, "VendorBatch", SysConvert.ToString(dr["VendorBatch"]));
                        gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dr["ColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dr["ColorName"]));
                        gridView1.SetRowCellValue(setRowID, "YarnType", SysConvert.ToString(dr["YarnType"]));
                        gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dr["VColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dr["VColorName"]));
                        gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dr["FormNo"]));
                        gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dr["OrderFormNo"]));

                        gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dr["Unit"]));
                        //gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dr["DVendorID"]));
                        if (SysConvert.ToString(dr["Qty"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToString(dr["Qty"]));
                        }
                        //gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToString(dr["MLType"]));
                        //if (SysConvert.ToString(dr["SingPrice"]) != "")
                        //{
                        //    gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToString(dr["SingPrice"]));
                        //}

                        setRowID++;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region �����¼�
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.���ⵥ��);
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��ȱ����);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ݲֿ�ѡ����λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpWHType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.ProcHideSectionSbit(SysConvert.ToString(drpWHID.EditValue), gridView1);
                Common.BindSection(drpGridSectionID, SysConvert.ToString(drpWHID.EditValue), false);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// �������͸ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSubType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)//�༭״̬��
                {
                    int YQType = SysConvert.ToInt32(drpSubType.EditValue) ;
                    if (YQType == (int)EnumYQType.���)
                    {
                        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.�ͻ� }, true);
                    }
                    if (YQType == (int)EnumYQType.�ɹ�)
                    {
                        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.����}, true);
                    }
                    if (YQType == (int)EnumYQType.����)
                    {
                        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
                    }
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "Qty")) > 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        //private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    try
        //    {
        //        OnFocusedRowChanged(e.FocusedRowHandle);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void OnFocusedRowChanged(int p_FocusedRow)
        //{
        //    try
        //    {

        //        BaseFocusLabel.Focus();
        //        this.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(p_FocusedRow, gridView1.Columns["MainID"]));
        //        this.DtsSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(p_FocusedRow, gridView1.Columns["Seq"]));


        //    }
        //    catch (Exception E)
        //    {

        //        ShowMessage(E.Message);
        //    }
        //}

        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            string WHID = SysConvert.ToString(drpWHID.EditValue);
            string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GoodsCode"]));
            string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorNum"]));
            string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorName"]));
            int DLaodDtsID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DLaodDtsID"]));
            chkAll.Checked = false;
            chkAny.Checked = false;
            this.BindGrid3(WHID, SectionID, ItemCode, GoodsCode, ColorNum, ColorName, DLaodDtsID);
        }

        private void BindGrid3(string WHID, string SectionID, string ItemCode, string GoodsCode, string ColorNum, string ColorName, int DLaodDtsID)
        {
            string sql = "";
            if (DLaodDtsID == 0)
            {
                sql = "SELECT *,0 SelectFlag FROM WH_PackBox WHERE 1=1";
                sql += " AND WHID=" + SysString.ToDBString(WHID);
                //sql += " AND SectionID=" + SysString.ToDBString(SectionID);
                sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
                sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
                sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                //sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
                //if (SysConvert.ToInt32(drpSubType.EditValue) == (int)EnumYQType.�ɹ�)
                //{
                //    sql += " AND InFormNo NOT IN (SELECT FormNo FROM UV1_WH_IOFormDts WHERE ISNULL(InvoiceQty,0)<>0 AND SubmitFlag>0) ";
                //}
                //if (SysConvert.ToInt32(drpSubType.EditValue) == (int)EnumYQType.����)
                //{
                //    sql += " AND OutFormNo NOT IN (SELECT FormNo FROM UV1_WH_IOFormDts WHERE ISNULL(InvoiceQty,0)<>0 AND SubmitFlag>0)";
                //}
                //sql += " AND ISNULL(Qty,0)>0";
                sql += " ORDER BY BoxNo";
            }
            else
            {
                sql = "SELECT 0 SelectFlag,'' PackNo,BoxNo,PQty Qty,Remark,SectionID from UV1_WH_IOFormDtsPack WHERE DtsID=" + SysString.ToDBString(DLaodDtsID);
                //sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
                //sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
                //sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                //sql += " AND ISNULL(InvoiceQty,0)=0";
            }
            DataTable dt = SysUtils.Fill(sql);
            gridView3.GridControl.DataSource = dt;
            gridView3.GridControl.Show();
        }


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


                    //        }
                    //    }
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

                if (SysConvert.ToInt32(dtStorgePack.Rows[rowID]["SelectFlag"]) == 1)
                {
                    SetGrid2(BoxNo, Qty);
                }
                else
                {
                    SetGrid2Del(BoxNo, Qty);

                }
                SetPackDts();
            }
        }

        private void SetPackDts()
        {
            this.BaseFocusLabel.Focus();
            string PackDts = "";
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if(SysConvert.ToDecimal(gridView2.GetRowCellValue(i,"Qty"))!=0)
                {
                    if (PackDts != "")
                    {
                        PackDts += ",";
                    }
                    
                    PackDts += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty")).ToString("f1");
                    
                }

            }
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PackDts", PackDts);
        }


        /// <summary>
        /// ���ã��ж������Ƿ���ڣ��粻���ڣ���ɸ�ֵ
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2(string BoxNo, decimal Qty)
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

                    SetGrid1Qty();
                    return;
                }
            }
            //û�и�ֵ�ɹ���˵���в���
            dtPackSource.Rows.Add(dtPackSource.NewRow());

            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["BoxNo"] = BoxNo;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["Qty"] = Qty;

            SetGrid1Qty();
        }

        /// <summary>
        /// ���ã��ж������Ƿ���ڣ�����ڣ����ɾ��
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2Del(string BoxNo, decimal Qty)
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
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) != string.Empty)
                {
                    pieceQty++;
                    qty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                }
                else//������������У��Զ�����ѭ�������Ч��
                {
                    break;
                }
            }

            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", pieceQty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty);
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

        #region �����¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    this.ShowMessage("�˹�����ʱ�ر�");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    this.ShowMessage("�˹�����ʱ�ر�");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    this.ShowMessage("�˹�����ʱ�ر�");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    this.ShowMessage("�˹�����ʱ�ر�");
                    return;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void lbtnLoadFH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtFHFormNo.Text.Trim() == "")
                {
                    this.ShowMessage("�����뷢�����ź�ƥ��");
                    return;
                }
                string sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo="+SysString.ToDBString(txtFHFormNo.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    this.ShowMessage("�������Ų����ڣ�����");
                    return;
                }

                sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                sql += " AND ISNULL(SubmitFlag,0)<>0";
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    this.ShowMessage("������û���ύ������");
                    return;
                }

                sql = "SELECT  FormNo FROM UV1_Sale_FHForm WHERE FormNo IN(SELECT DtsSO FROM UV1_WH_YQFormDts WHERE SubType IN(SELECT ID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(FormListAID)+" ) ) AND FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    this.ShowMessage("����������д���ⵥ������");
                    return;
                }

                //sql = "SELECT FHForTypeID,SaleOPID,'' Section,'' SBitID,ItemCode,'' ItemModel,'' Batch,'' VendorBatch,ColorNum,ColorName,'' JarNum,'' Remark,PieceQty,Qty,Unit,0 Weight,0 SinglePrice,Amount,'' DLCode,GoodsCode,GoodsLevel,VColorNum,VColorName,VItemCode,MWidth,MWeight,WeightUnit,0 ManinID,0 Seq,VendorID DtsInVendorID,'' InSO,'' InOrderFormNo,'' InSaleOPID,FHForTypeID ID,FormNo DtsSO,DtsOrderFormNo FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                //sql += " AND ISNULL(SubmitFlag,0)<>0";
                sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtFHFormNo.Text.Trim());
                sql += " AND ISNULL(SubmitFlag,0)<>0";
                dt = SysUtils.Fill(sql);
                if(dt.Rows.Count>0)
                {
                    int FHForTypeID = SysConvert.ToInt32(dt.Rows[0]["FHForTypeID"]);
                    if (FHForTypeID ==(int)EnumFHForType.������)
                    {
                        drpSubType.EditValue = 1203;
                    }
                    else
                    {
                        drpSubType.EditValue = 1201;
                    }
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int setRowID = i;
                        gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                        gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                        gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                        gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[i]["GoodsCode"]));
                        gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                        gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[i]["VColorNum"]));
                        gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[i]["VColorName"]));
                        gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[i]["VItemCode"]));
                        gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToDecimal(dt.Rows[i]["MWidth"]));
                        gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToDecimal(dt.Rows[i]["MWeight"]));
                        gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[i]["WeightUnit"]));
                        gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[i]["GoodsLevel"]));
                        gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                        gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        gridView1.SetRowCellValue(setRowID, "DtsInVendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                        gridView1.SetRowCellValue(setRowID, "DYPrice", SysConvert.ToDecimal(dt.Rows[i]["DYPrice"]));
                        //gridView1.SetRowCellValue(setRowID, "InSO", SysConvert.ToString(dt.Rows[0]["SO"]));
                        switch (saveFillDataType)
                        {
                            case (int)EnumFillDataType.���۳����׼�����:
                                gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsOrderFormNo"]));
                                break;
                            //case (int)EnumFillDataType.�������۳����׼�����:
                            //    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsDYFormNo"]));
                            //    break;
                        }
                        gridView1.SetRowCellValue(setRowID, "InOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsOrderFormNo"]));
                        gridView1.SetRowCellValue(setRowID, "InSaleOPID", SysConvert.ToString(dt.Rows[i]["SaleOPID"]));

                        if (SysConvert.ToString(dt.Rows[0]["Qty"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                        }

                        if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToInt32(dt.Rows[i]["PieceQty"]));
                        }
                        if (SysConvert.ToString(dt.Rows[0]["SingPrice"]) != "")
                        {
                            gridView1.SetRowCellValue(setRowID, "SinglePrice", SysConvert.ToDecimal(dt.Rows[i]["SingPrice"]));
                        }

                        string outsectionID, outSbitID;
                        WHLoadFHFormSetWH(dt.Rows[i], out outsectionID, out outSbitID);

                        gridView1.SetRowCellValue(setRowID, "SectionID", outsectionID);
                        gridView1.SetRowCellValue(setRowID, "SBitID", outSbitID);
                    }
                    gridViewRowChanged1(gridView1);
                }

            }
            catch(Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmOutWHEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    YQForm entity = new YQForm();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    if (entity.SubmitFlag == 0)
                    {
                        if (DialogResult.Yes != ShowConfirmMessage(this.Text + Environment.NewLine + "û���ύ����,�Ƿ�ȷ�Ϲرմ���"))
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "FactQty")
                {
                    decimal pdqty = SysConvert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "FactQty"))
                    - SysConvert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Qty"));
                    if (pdqty != 0)
                    {
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "PDQty", pdqty);
                    }
                    else
                    {
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "PDQty", DBNull.Value);
                    }
                    SetGrid1Qty2();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        void SetGrid1Qty2()
        {
            int pieceQty = 0;
            decimal qty = 0;
            decimal pdqty = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) != string.Empty)
                {
                    pieceQty++;
                    qty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                    pdqty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "PDQty"));
                }
                else//������������У��Զ�����ѭ�������Ч��
                {
                    break;
                }
            }

            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", pieceQty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MoveQty", pdqty);
        }

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
                if (!CheckCorrect())
                {
                    return;
                }

                YQFormRule rule = new YQFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.���ύ);

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

                if (!CheckCorrect())
                {
                    return;
                }

                YQFormRule rule = new YQFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.δ�ύ);

                FCommon.AddDBLog(this.Text, FormStatus.�����ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


       




    }
}