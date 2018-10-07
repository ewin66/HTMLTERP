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
using HttSoft.UCFab;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// �ӹ�����ɴ�߽���
    /// </summary>
    public partial class frmBuckleMaterial : frmAPBaseUIFormEdit
    {
        public frmBuckleMaterial()
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

        /// <summary>
        /// �ж��Ƿ���Ҫ�뵥
        /// </summary>
        private bool m_PackFlag=true;
        public bool PackFlag
        {
            get
            {
                return m_PackFlag;
            }
            set
            {
                m_PackFlag = value;
            }
        }

        /// <summary>
        /// �ֿⵥ����������
        /// </summary>
        private int m_WHItemTypeID = 0;
        public int WHItemTypeID
        {
            get
            {
                return m_WHItemTypeID;
            }
            set
            {
                m_WHItemTypeID = value;
            }
        }



        /// <summary>
        /// �ֿⵥ�ݴ�����
        /// </summary>
        private int m_WHFormListAID = 0;
        public int WHFormListAID
        {
            get
            {
                return m_WHFormListAID;
            }
            set
            {
                m_WHFormListAID = value;
            }
        }


        /// <summary>
        /// �ֿⵥ��������
        /// </summary>
        private int m_WHFormListBID = 0;
        public int WHFormListBID
        {
            get
            {
                return m_WHFormListBID;
            }
            set
            {
                m_WHFormListBID = value;
            }
        }

        /// <summary>
        /// ���Ͽ��
        /// </summary>
        private string m_WHID = "";
        public string WHID
        {
            get
            {
                return m_WHID;
            }
            set
            {
                m_WHID = value;
            }
        }

        /// <summary>
        /// ���ϳ�������
        /// </summary>
        private string m_FormNo = "";
        public string FormNo
        {
            get
            {
                return m_FormNo;
            }
            set
            {
                m_FormNo = value;
            }
        }

        /// <summary>
        /// ���ϳ�������
        /// </summary>
        private int m_MainID = 0;
        public int MainID
        {
            get
            {
                return m_MainID;
            }
            set
            {
                m_MainID = value;
            }
        }


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
            //FabricWHOutFormDtsRule rule = new FabricWHOutFormDtsRule();
            //DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            string sql = "SELECT * FROM WO_FabricWHOutFormDts WHERE MainID IN (SELECT ID FROM WO_FabricWHOutForm WHERE MainID=" + SysString.ToDBString(m_MainID) + ")";
            DataTable dtDts = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FabricWHOutFormRule rule = new FabricWHOutFormRule();
            FabricWHOutForm entity = EntityGet();
            FabricWHOutFormDts[] entitydts = EntityDtsGet();
            //decimal TotalQty = 0;
            //decimal TotalAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
            //    TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            //}
            //entity.TotalQty = TotalQty;
            //entity.TotalAmount = TotalAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
          
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }


       
        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FabricWHOutFormRule rule = new FabricWHOutFormRule();
            FabricWHOutForm entity = EntityGet();
            FabricWHOutFormDts[] entitydts = EntityDtsGet();
            //decimal TotalQty = 0;
            //decimal TotalAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
            //    TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            //}
            //entity.TotalQty = TotalQty;
            //entity.TotalAmount = TotalAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
          
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FabricWHOutForm entity = new FabricWHOutForm();
            entity.MainID = m_MainID;
            bool findFlag=entity.SelectByID2();
            HTDataID = entity.ID;
            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.MakeDate;
            drpWHID.EditValue = entity.WHID;
            //txtRemark.Text = entity.Remark;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;

            txtJGFormNo.Text = m_FormNo;
            txtJGWHFormNo.Text = entity.AutoIOFormNo;

            if (!findFlag)
            {
               
            }

            BindGridDts();
            //SetIOFormDetail();
            //BindPack();
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
                            IOFormDtsPack entity = new IOFormDtsPack();
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
       

        /// <summary>
        /// ��������ʾ�ؼ�
        /// </summary>
        void BindUCFabView(DataTable dtSource)
        {
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
        }


       
        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FabricWHOutFormRule rule = new FabricWHOutFormRule();
            FabricWHOutForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, false);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            drpWHID.Properties.ReadOnly = !p_Flag;
            //drpWHID.Enabled = false;
            //txtFormNo.Enabled = false;
            
            ProductCommon.FormNoCtlEditSet(txtFormNo, "WO_FabricWHOutForm", "FormNo", 0, p_Flag);
            
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            drpWHID.EditValue = m_WHID;
            txtJGFormNo.Text = m_FormNo;

         

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_FabricWHOutForm";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//������ϸУ�����¼���ֶ� ,"Qty"
            //Common.BindVendor2(drpVendorID, (int)EnumVendorType.�ͻ�, true);
            //new VendorProc(drpVendorID);
            Common.BindWHByItemType(drpWHID, m_WHItemTypeID, true);
            Common.BindCLS(restxtGoodsLevel, "WH_IOFormDts", "GoodsLevel", true);
            //Common.BindSubType(drpSubType, m_WHFormListAID, true);
            
            Common.BindCLS(RestxtUnit, "Data_Item", "ItemUnitYarn", true);
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
            this.ToolBarItemAdd(28, "btnLoadStorge", "���ؿ��", false, btnLoadStorge_Click);
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;

            if (m_PackFlag)
            {
                groupControl2.Visible = true;
                ucFabView1.Visible = true;
            }
            else
            {
                groupControl2.Visible = false;
                ucFabView1.Visible = false;
             }

             SetIniFormStatus();



        }

        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(1, ToolButtonName.btnInsert.ToString(), "����", false, btnInsert_Click, eShortcut.F1);
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "�޸�", false, btnUpdate_Click, eShortcut.F2);
            this.ToolBarItemAdd(3, ToolButtonName.btnDelete.ToString(), "ɾ��", false, btnDelete_Click, eShortcut.F3);
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "����", false, btnSave_Click, eShortcut.F4);
            this.ToolBarItemAdd(5, ToolButtonName.btnCancel.ToString(), "����", false, btnCancel_Click);
            this.ToolBarItemAdd(29, ToolButtonName.btnSubmit.ToString(), "�ύ", true, btnSubmit_Click);
            this.ToolBarItemAdd(30, ToolButtonName.btnSubmitCancel.ToString(), "�����ύ", false, btnSubmitCancel_Click);
        }

        private void SetIniFormStatus()
        {
            string sql = "SELECT * FROM WO_FabricWHOutForm WHERE MainID="+SysString.ToDBString(m_MainID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                EntitySet();
                BindGridDts();

                //btnUpdate_Click(null, null);
            }
            else
            {
                btnInsert_Click(null, null);
            }
        }


        /// <summary>
        /// ͨ�ô�����ط����������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void IniFormLoadBehind()
        {
            //ProcessGrid.SetGridColumnReadOnly(gridView2, new string[] { "BoxNo", "Qty" }, true);
         
        }



        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                    string sql = string.Empty;
                    sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum FROM WH_IOFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
                    DataTable dt = SysUtils.Fill(sql);

                    BindUCFabView(dt);
                  

                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetGrid(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToDecimal(dr["Qty1"]) == 0)
                {
                    dr["Qty1"] = DBNull.Value;
                    dr["PackNo1"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty2"]) == 0)
                {
                    dr["Qty2"] = DBNull.Value;
                    dr["PackNo2"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty3"]) == 0)
                {
                    dr["Qty3"] = DBNull.Value;
                    dr["PackNo3"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty4"]) == 0)
                {
                    dr["Qty4"] = DBNull.Value;
                    dr["PackNo4"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty5"]) == 0)
                {
                    dr["Qty5"] = DBNull.Value;
                    dr["PackNo5"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty6"]) == 0)
                {
                    dr["Qty6"] = DBNull.Value;
                    dr["PackNo6"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty7"]) == 0)
                {
                    dr["Qty7"] = DBNull.Value;
                    dr["PackNo7"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty8"]) == 0)
                {
                    dr["Qty8"] = DBNull.Value;
                    dr["PackNo8"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty9"]) == 0)
                {
                    dr["Qty9"] = DBNull.Value;
                    dr["PackNo9"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty10"]) == 0)
                {
                    dr["Qty10"] = DBNull.Value;
                    dr["PackNo10"] = DBNull.Value;
                }
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
                    //if (Common.CheckLookUpEditBlank(drpSubType))
                    //{
                    //    this.ShowMessage("��ѡ�񵥾�����");
                    //    return;
                    //}

                    if (SysConvert.ToString(drpWHID.EditValue) == "")
                    {
                        this.ShowMessage("��ѡ��ֿ�");
                        drpWHID.Focus();
                        return;
                    }
                    frmLoadYarnStorge frm = new frmLoadYarnStorge(); 
                    frm.WHID = SysConvert.ToString(drpWHID.EditValue);
                    frm.WHTypeID = (int)EnumWHType.ԭ�ϲֿ�;
                    frm.ItemType = (int)EnumItemType.ɴ��;
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
                    gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
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
        private FabricWHOutForm EntityGet()
        {
            FabricWHOutForm entity = new FabricWHOutForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.MainID = m_MainID;
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtFormDate.DateTime;
            //entity.VendorID = drpVendorID.EditValue.ToString();
            //entity.Remark = txtRemark.Text.Trim();
            entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.MakeOPName = FParamConfig.LoginName;

            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FabricWHOutFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            FabricWHOutFormDts[] entitydts = new FabricWHOutFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new FabricWHOutFormDts();
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
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight")); 
  			 		entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty + entitydts[index].DYPrice;
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
                    //entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));                    
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    //entitydts[index].DtsSaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);//SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));

                    entitydts[index].DtsInVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsInVendorID"));
                    entitydts[index].InSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSO"));
                    entitydts[index].InOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "InOrderFormNo"));
                    entitydts[index].InSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "InSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));
                    entitydts[index].LoadDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadDtsID"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

    

        #region �����¼�
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {

                    ProductCommon.FormNoIniSet(txtFormNo, "WO_FabricWHOutForm", "FormNo");

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

                //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                //{
                //    this.ShowMessage("��û�д˲���Ȩ��");
                //    return;
                //}

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }
                if (!CheckCorrect())
                {
                    return;
                }

                FabricWHOutFormRule rule = new FabricWHOutFormRule();
                //string o_ErrorMsg = string.Empty;
                //if (!rule.RCheckCorrectPackData(HTDataID, out o_ErrorMsg))// ���У�鲻ͨ��
                //{
                //    this.ShowMessage(o_ErrorMsg);
                //    return;
                //}

                rule.RSubmit(HTDataID, (int)ConfirmFlag.���ͨ��);

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

                //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                //{
                //    this.ShowMessage("��û�д˲���Ȩ��");
                //    return;
                //}
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                if (!CheckCorrect())
                {
                    return;
                }

                FabricWHOutFormRule rule = new FabricWHOutFormRule();
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

        #region ��ť�¼�����
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                FabricWHOutFormRule rule = new FabricWHOutFormRule();
                string o_ErrMsg;
                if (!rule.RAddCheck(MainID, out o_ErrMsg))
                {
                    this.ShowMessage(o_ErrMsg);
                    return;
                }

                base.btnInsert_Click(sender, e);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �����Ѵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnInsertExist_Click(object sender, EventArgs e)
        {
            try
            {
                FabricWHOutFormRule rule = new FabricWHOutFormRule();
                string o_ErrMsg;
                if (!rule.RAddCheck(MainID, out o_ErrMsg))
                {
                    this.ShowMessage(o_ErrMsg);
                    return;
                }

                base.btnInsertExist_Click(sender, e);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region �����¼�2

        private void btnToGBDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (this.HTDataSubmitFlag == 0)//δ�ύ״̬������༭�뵥
                {
                    if (HTDataID == 0)
                    {
                        this.ShowMessage("�뱣�浥�ݺ�����ϸ��");
                        return;
                    }
                    int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    string WHID = SysConvert.ToString(drpWHID.EditValue);
                    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                    string ItemName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                    string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum"));
                    string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                    string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));
                    string Batch = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Batch"));

                    if (ID > 0)
                    {
                        frmLoadOutWH frm = new frmLoadOutWH();
                        frm.PackType = (int)EnumPackType.�ֿⵥ��;
                        frm.IOFormID = HTDataID;
                        frm.ID = ID;
                        frm.WHID = WHID;
                        frm.ItemCode = ItemCode;
                        frm.ColorNum = ColorNum;
                        frm.ColorName = ColorName;
                        frm.JarNum = JarNum;
                        frm.Batch = Batch;
                        frm.ShowDialog();
                        if (frm.SaveFlag)//���������ˢ������
                        {
                            BindGridDts();
                            ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { ID.ToString() });
                            gridViewRowChanged2(gridView1);
                        }
                    }
                }
                else
                {
                    this.ShowMessage("�������ύ��������༭�뵥");
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

                if (e.Column.FieldName == "PackNo1" || e.Column.FieldName == "PackNo2" || e.Column.FieldName == "PackNo3" || e.Column.FieldName == "PackNo4"
                    || e.Column.FieldName == "PackNo5" || e.Column.FieldName == "PackNo6" || e.Column.FieldName == "PackNo7" || e.Column.FieldName == "PackNo8"
                    || e.Column.FieldName == "PackNo9" || e.Column.FieldName == "PackNo10")
                {
                    e.Appearance.BackColor = Color.Silver;
                }
                if (e.Column.FieldName == "TQty")
                {
                    e.Appearance.BackColor = Color.Tan;
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region ��ӡ��д
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            HTPrintDataSourceFlag = true;
            DataTable dtm = UCFabDataConvert.WHFabConvert(HTDataID, 8);
            dtm.TableName = "eee";
            HTPrintDataSource = new DataTable[] { dtm };
            base.btnDesign_Click(sender, e);
        }
        #endregion

        #region �޸ķ���

        /// <summary>
        /// �޸��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (m_MainID == 0)
                {
                    this.ShowMessage("��ѡ���¼");
                    return;
                }
                HTDataOldID = HTDataID;
                SetFormStatus(FormStatus.�޸�);
                IniUpdateSet();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();
                if (this.HTFormStatus == FormStatus.����)
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    int tempID = EntityAdd();
                    FCommon.AddDBLog(this.Text, "����", "ID:" + tempID.ToString(), "");
                    this.HTDataID = tempID;

                }
                else if (this.HTFormStatus == FormStatus.�޸�)
                {
                    //if (!HTSubmitCheck(FormStatus.�޸�))
                    //{
                    //    return;
                    //}

                    if (!CheckCorrect())
                    {
                        return;
                    }
                    EntityUpdate();
                    FCommon.AddDBLog(this.Text, "�޸�", "ID:" + HTDataID.ToString(), "");
                }

                SetFormStatus(FormStatus.��ѯ);
                //EntitySet();
                SetPosStatus(HTDataID);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.ɾ��))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("ɾ��Ϊ���ɻָ�������ȷ��ɾ��������¼��"))
                {
                    return;
                }

                EntityDelete();//�����鷽��
                FileDeleteDataFile();//�ļ�ɾ��
                FCommon.AddDBLog(this.Text, "ɾ��", "ID:" + HTDataID, "");
                //this.EntitySet();
                SetPosStatus(0);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


    }
}