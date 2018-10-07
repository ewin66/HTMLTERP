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
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmYarnInWHEdit : frmModuleBaseWHEdit
    {
        public frmYarnInWHEdit()
        {
            InitializeComponent();
        }

        #region ȫ�ֱ���

        private DataTable[] dtPack = new DataTable[150];//�뵥��Ϣ��
        private int PreRowID = -1;//��ʼ�к�
        private int CurRowID = -1;//��ǰ�к�
        int saveNoLoadCheckDayNum = 0;//δ���رȶ���������ֹ����ʱ�������ϵͳ����


        int saveLoadFormType = 0;
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
                this.ShowMessage("��������ⵥ��");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
            {
                this.ShowMessage("��ѡ�������λ(��ͻ�)");
                drpVendorID.Focus();
                return false;
            }

            //if (SysConvert.ToString(drpWHID.EditValue) == string.Empty)
            //{
            //    this.ShowMessage("��ѡ��ֿ�");
            //    drpWHID.Focus();
            //    return false;
            //}

            if (SysConvert.ToString(drpSubType.EditValue) == string.Empty)
            {
                this.ShowMessage("��ѡ�񵥾�����");
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
            rule.RAdd(entity, entitydts);
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
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;
            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpVendorID.EditValue = entity.VendorID.ToString();
            drpXZ.EditValue = entity.XZ.ToString();
            drpWHID.EditValue = entity.WHID.ToString();
            drpSubType.EditValue = entity.SubType;
            txtWHDM.Text = entity.DM.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtWHInvoiceNo.Text = entity.InvoiceNo.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtRemark.Text = entity.Remark;

            txtMakeOPName.Text = entity.MakeOPName;

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            SetIOFormDetail();
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
            txtMakeOPName.Properties.ReadOnly = true;
            
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
         

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;

            this.HTCheckDataField = new string[] {"ItemCode","Qty"};//������ϸУ�����¼���ֶ�
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//��֯�ṹ��ϵ����
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }
            Common.BindVendor2(drpVendorID, (int)EnumVendorType.����, true);
            //new VendorProc(drpVendorID);
            if (this.FormListAID == 13 || this.FormListAID == 10)//10���ڳ�
            {
                new ItemProcResLookUP(this.BaseFocusLabel, gridView1, new string[] { "ItemCode", "ItemName", "ItemStd", "Unit" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.ɴ�� },"","ItemModel", true, true);
            }
            else if (this.FormListAID == 17)
            {
                new ItemProcResLookUP(this.BaseFocusLabel, gridView1, new string[] { "ItemCode", "ItemName", "ItemStd", "Unit" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.���� }, "", "ItemModel", true, true);
            }
            Common.BindCLS(cmbYarnType, "WH_IOFormDts", "YarnType", true);  //ɴ������
            Common.BindWHByFormList(drpWH,this.FormListAID, true);      
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel",true);
            Common.BindSubType(drpSubType, this.FormListAID, true);             //������Ͱ�
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
           // Common.BindWHByFormList(drp, SysConvert.ToInt32(drpSubType.EditValue), true);
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            //Common.BindEnumUnit(RestxtUnit, true);

            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitYarn", true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "���ص���", false, btnLoad_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;
            gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;


        }


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
                        this.ShowMessage("��ѡ�񵥾�����");
                        return;
                    }
                    switch (saveLoadFormType)
                    {
                        default:
                            LoadRelFormData(saveLoadFormType, gridView1, drpVendorID);
                            break;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �Զ��巽��
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
                    dtPack[p_RowID].Rows[i]["ID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["ID"]));
                    dtPack[p_RowID].Rows[i]["MainID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["MainID"]));
                    dtPack[p_RowID].Rows[i]["Seq"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["Seq"]));
                    dtPack[p_RowID].Rows[i]["SubSeq"] = PreRowID + 1;

                    dtPack[p_RowID].Rows[i]["PackNo"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["PackNo"]));
                    dtPack[p_RowID].Rows[i]["Qty"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"]));
                    dtPack[p_RowID].Rows[i]["Remark"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["Remark"]));
                }
            }
        }

       

        private void SetIOFormDetail()
        {
            //Itemcode+FabricTypeCode+FabricType+Batch+ColorNum+ColorName+JarNum+OrderCode+YarnStatus
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
                Common.AddDtRow(dtPack[i], 150);
            }
            #endregion
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime;
            entity.XZ = drpXZ.Text.Trim();
            entity.VendorID = drpVendorID.EditValue.ToString();
            //entity.WHType = drpWHID.EditValue.ToString();
            entity.SubType =SysConvert.ToInt32(drpSubType.EditValue.ToString());
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            //entity.WHTypeID = SysConvert.ToInt32(drpWHID.EditValue);
            //entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            //entity.DM = txtWHDM.Text.Trim();
            //entity.InvoiceNo = txtWHInvoiceNo.Text.Trim();
            //entity.InvoiceNo = txtInvoiceNo.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HeadType = this.FormListAID;
            entity.MakeDate = DateTime.Now.Date;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            
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
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch")); 
  			 		entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum")); 
  			 		
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty")); 
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                    entitydts[index].YarnType = SysConvert.ToString(gridView1.GetRowCellValue(i, "YarnType")); 
  			 		entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum")); 
  			 		entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName")); 
  			 		
                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    if (entitydts[index].DtsOrderFormNo == string.Empty&&index>0)
                    {
                        entitydts[index].DtsOrderFormNo = entitydts[index - 1].DtsOrderFormNo;
                    }
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));
                    entitydts[index].PackDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "PackDts"));//ϸ��
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));  //���ֳ�Ʒ���ϺͰ�����
                    index++;
                }
            }
            return entitydts;
        }

        /// <summary>
        /// ����뵥��ϸ
        /// </summary>
        /// <param name="List"></param>
        private void GetMadanDts(ArrayList List)
        {
            BaseFocusLabel.Focus();
            for (int j = 0; j < gridView1.RowCount; j++)//ɴ��ѭ��
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) != string.Empty)
                {
                    for (int m = 0; m < dtPack[j].Rows.Count; m++)//�뵥ѭ��
                    {

                        if ((SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]) != 0))//dtPack[j].Rows[m]["PackNo"].ToString() != string.Empty ||
                        {
                            IOFormDtsPack entity = new IOFormDtsPack();
                            entity.ID = SysConvert.ToInt32(dtPack[j].Rows[m]["ID"]);
                            entity.SelectByID();
                            entity.MainID = HTDataID;
                            entity.Seq = j + 1;
                            entity.SubSeq = m + 1;
                            entity.BoxNo = dtPack[j].Rows[m]["BoxNo"].ToString();
                            entity.Qty = SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]);
                            entity.Remark = SysConvert.ToString(dtPack[j].Rows[m]["Remark"]);

                           
                            List.Add(entity);

                        }
                    }
                }
            }
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
                    string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHID"));
                    string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SectionID"));
                    Common.BindSection(drpGridSectionID, WHID, false);
                    Common.BindSBit(drpSBit, WHID, SectionID, true);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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
        #endregion

        #region ����������ط���

     

      

        

        #endregion

        #region �����¼�
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetWHFormNo(this.FormListAID, SysConvert.ToInt32(drpSubType.EditValue), SysConvert.ToString(drpWHID.EditValue));
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
        private void drpWHID_EditValueChanged(object sender, EventArgs e)
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
                txtFormNo_DoubleClick(null, null);
                Common.BindVendorByFormListID(drpVendorID, SysConvert.ToInt32(drpSubType.EditValue), true);//���ÿͻ�

                string sql = "SELECT * FROM Enum_FormList WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"]);
                    saveTHLoadFormListIDStr = SysConvert.ToString(dt.Rows[0]["THLoadFormListIDStr"]);
                     if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)//�༭״̬��
                     {
                         if (dt.Rows[0]["DefaultWHID"].ToString() != string.Empty)
                         {
                             drpWHID.EditValue = dt.Rows[0]["DefaultWHID"].ToString();
                         }
                     }
                     string VendorCaption = dt.Rows[0]["VendorIDCaption"].ToString();
                     if (VendorCaption != string.Empty)
                     {
                         labVendorID.Text = VendorCaption;
                         drpVendorID.ToolTip = VendorCaption;
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
        /// ˫����Ʒ������عҰ���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadItemGB frm = new frmLoadItemGB();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {

                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNews(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        private void setItemNews(string str)
        {
            string[] arr = str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) != 0)
                    {
                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) != 0)
                    {
                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWeight",DBNull.Value);
                    }
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    //gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));

                }
                length++;
            }
        }

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

        ///// <summary>
        ///// �뵥ֵ�ı�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
        //        {
        //            if (e.Column.FieldName.ToUpper() == "QTY")//�����ı������
        //            {
        //                SetGrid1Qty();
        //            }
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        /// <summary>
        /// ����Grid1Qty����
        /// </summary>
        void SetGrid1Qty()
        {
            int pieceQty = 0;
            decimal qty = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "Qty")) != string.Empty && SysConvert.ToString(gridView2.GetRowCellValue(i, "Qty")) != "0")
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

                IOFormRule rule = new IOFormRule();
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
                if (!CheckLastUpdateDay(txtFormDate.DateTime))
                {
                    return;
                }
                //if (!CheckCorrect())
                //{
                //    return;
                //}

                IOFormRule rule = new IOFormRule();
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

        /// <summary>
        /// ˫�����ؼ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPieceQty_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //this.BaseFocusLabel.Focus();
                frmLoadPack frm = new frmLoadPack();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(780, 80);
                string packdts = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackDts"));
                if (packdts != "")
                {
                    frm.YPackStr = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackDts"));
                }
                else
                {
                    frm.YPackStr =GetPackDts();
                }
               
                frm.ShowDialog();
                if (frm.PackStr != "")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", frm.Qty);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PackDts", frm.PackStr);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", frm.Num);
                    string[] arr = frm.PackStr.Split(',');
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (i < arr.Length)
                        {
                            gridView2.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(arr[i]));
                        }
                        else
                        {
                            gridView2.SetRowCellValue(i, "Qty", 0);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private string GetPackDts()
        {
            string str = "";
            for(int i=0;i<gridView2.RowCount;i++)
            {
               
                if(SysConvert.ToDecimal(gridView2.GetRowCellValue(i,"Qty"))!=0)
                {
                    if (str != "")
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(gridView2.GetRowCellValue(i, "Qty"));
                }
            }
            return str;
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

        #region ������ͬ��

        private void btnGO_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    if (!checkFH())
                    {
                        return;
                    }
                    LoadWHByFHForm();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ط�������
        /// </summary>
        private void LoadWHByFHForm()
        {
            string sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE FormNo="+SysString.ToDBString(txtFHFormNo.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    gridView1.FocusedRowHandle = i;
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[i]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[i]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[i]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[i]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[i]["Qty"]));
                    gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToInt32(dt.Rows[i]["PieceQty"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    gridView1.SetRowCellValue(i, "DtsSO", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[i]["DtsOrderFormNo"]));
                    gridView1.SetRowCellValue(i, "VColorNum", SysConvert.ToString(dt.Rows[i]["VColorNum"]));
                    gridView1.SetRowCellValue(i, "VColorName", SysConvert.ToString(dt.Rows[i]["VColorName"]));
                    gridView1.SetRowCellValue(i, "VItemCode", SysConvert.ToString(dt.Rows[i]["VItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsLevel", SysConvert.ToString(dt.Rows[i]["GoodsLevel"]));

                    SetGird2ByFHForm(SysConvert.ToInt32(dt.Rows[i]["ID"]), SysConvert.ToInt32(dt.Rows[i]["Seq"]));
                   
                     
                    
                }
            }

        }

        /// <summary>
        /// ȡ��ϸ���ֵ
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_Seq"></param>
        private void SetGird2ByFHForm(int p_ID, int p_Seq)
        {
            string sql = "SELECT Qty FROM Sale_FHFormDtsPack WHERE MainID=" + SysString.ToDBString(p_ID);
            sql += " AND Seq=" + SysString.ToDBString(p_Seq);
            DataTable dt = SysUtils.Fill(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gridView2.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i][0]));
            }
        }

        /// <summary>
        /// ��֤������
        /// </summary>
        /// <returns></returns>
        private bool checkFH()
        {
            if (txtFHFormNo.Text.Trim() == "")
            {
                this.ShowMessage("������ͬ���ķ�������");
                txtFHFormNo.Focus();
                return false;
            }
            string sql = "SELECT * FROM Sale_FHForm WHERE FormNo="+SysString.ToDBString(txtFHFormNo.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                this.ShowMessage("�������Ų����ڣ�����������");
                txtFHFormNo.Text = "";
                txtFHFormNo.Focus();
                return false;
            }
            return true;
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

        private void drpWH_EditValueChanged(object sender, EventArgs e)
        {
            gridViewRowChanged2(gridView1);
        }

        private void drpGridSectionID_EditValueChanged(object sender, EventArgs e)
        {
            gridViewRowChanged2(gridView1);
        }


    }
}