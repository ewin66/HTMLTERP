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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmCheckOperation2Edit : frmAPBaseUIFormEdit
    {
        public frmCheckOperation2Edit()
        {
            InitializeComponent();
        }
        int IsMerge = 0;

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {

            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("��������˵���");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��������λ");
                drpVendorID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ҵ��Ա");
                drpSaleOPID.Focus();
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
            CheckOperationDtsRule rule = new CheckOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            SetWHQty(dtDts);
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        private void SetWHQty(DataTable dtDts)
        {
            foreach (DataRow dr in dtDts.Rows)
            {
                if (SysConvert.ToInt32(dr["FormDZFlag"]) == (int)EnumDZFlag.���ʸ�)
                {
                    dr["Qty"] = 0 - SysConvert.ToDecimal(dr["Qty"]);
                    dr["Amount"] = 0 - SysConvert.ToDecimal(dr["Amount"]);
                }
            }
        }





        /// <summary>
        /// ���������
        /// </summary>
        void ProcThisQty(CheckOperation entity, CheckOperationDts[] entitydts, CheckOperationInvDts[] entityInvDts, CheckOperationPayDts[] entityPayDts)
        {
            decimal totalThisQty = 0;//���ڷ�������
            decimal totalThisAmount = 0;//���ڷ������
            decimal totalThisInvQty = 0;//���ڷ�Ʊ����
            decimal totalThisInvAmount = 0;//���ڷ�Ʊ���
            decimal totalThisPayAmount = 0;//����֧�����

            for (int i = 0; i < entitydts.Length; i++)
            {
                totalThisQty += entitydts[i].DCheckQty;
                totalThisAmount += entitydts[i].DCheckAmount;
            }
            for (int i = 0; i < entityInvDts.Length; i++)
            {
                totalThisInvQty += entityInvDts[i].DInvoiceQty;
                totalThisInvAmount += entityInvDts[i].DInvoiceAmount;
            }

            for (int i = 0; i < entityPayDts.Length; i++)
            {
                totalThisPayAmount += entityPayDts[i].ExAmount;
            }

            entity.ThisExAmount = entity.PreExAmount + totalThisAmount - totalThisPayAmount;
            entity.ThisInvoiceQty = entity.PreInvoiceQty + totalThisQty - totalThisInvQty;
            entity.ThisInvoiceAmount = entity.PreInvoiceAmount + totalThisAmount - totalThisInvAmount;
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
            CheckOperationDts[] entitydts = EntityDtsGet();
            //CheckOperationInvDts[] entityInvDts = EntityInvDtsGet();
            //CheckOperationPayDts[] entityPayDts = EntityPayDtsGet();
            decimal TotalCheckAmount = 0;
            decimal TotalQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalCheckAmount += SysConvert.ToDecimal(entitydts[i].DCheckAmount);
                TotalQty += SysConvert.ToDecimal(entitydts[i].DCheckQty);
            }
            entity.TotalCheckAmount = TotalCheckAmount;
            entity.TotalQty = TotalQty;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();

            //ProcThisQty(entity, entitydts, entityInvDts, entityPayDts);//����������
            //�б��еĶ������ݲ����ظ����� sc 20140123


            rule.RAdd(entity, entitydts);
            return entity.ID;
        }


        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
            CheckOperationDts[] entitydts = EntityDtsGet();
            //CheckOperationInvDts[] entityInvDts = EntityInvDtsGet();
            //CheckOperationPayDts[] entityPayDts = EntityPayDtsGet();
            decimal TotalCheckAmount = 0;
            decimal TotalQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalCheckAmount += SysConvert.ToDecimal(entitydts[i].DCheckAmount);
                TotalQty += SysConvert.ToDecimal(entitydts[i].DCheckQty);
            }
            entity.TotalCheckAmount = TotalCheckAmount;
            entity.TotalQty = TotalQty;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CheckOperation entity = new CheckOperation();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();


            txtFormNo.Text = entity.FormNo.ToString();
            txtOrderCode.Text = entity.OrderCode.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpDZType.EditValue = entity.DZTypeID;

            drpVendorID.EditValue = entity.VendorID;


            txtRemark.Text = entity.Remark.ToString();
            txtDVendorCon.Text = entity.DVendorCon.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalCheckAmount.Text = entity.TotalCheckAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();

            drpCheckMethodType.EditValue = entity.CheckMethodTypeID;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;

            txtThisExAmount.Text = entity.ThisExAmount.ToString();
            txtThisInvoiceAmount.Text = entity.ThisInvoiceAmount.ToString();
            txtThisInvoiceQty.Text = entity.ThisInvoiceQty.ToString();

            txtPreExAmount.Text = entity.PreExAmount.ToString();
            txtPreInvoiceAmount.Text = entity.PreInvoiceAmount.ToString();
            txtPreInvoiceQty.Text = entity.PreInvoiceQty.ToString();
            txtFormDate.DateTime = entity.FormDate;
            IsMerge = entity.MergeFlage;
            txtInvoiceApplyNo.Text = entity.InvoiceApplyNo;

            if (!findFlag)
            {

            }

            BindGridDts();
            //BindGrid2();
            //BindGrid3();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
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
            base.IniInsertSet();

            txtMakeDate.DateTime = DateTime.Now;
            drpDZType.EditValue = FormListAID;
            txtFormNo_DoubleClick(null, null);
            drpSaleOPID.EditValue = FParamConfig.LoginID;
            drpCheckMethodType.EditValue = (int)EnumCheckMethodType.��ʱ����ˮ��;

            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtFormDate.DateTime = DateTime.Now.Date;
            //if (this.FormListAID == 3 && HTFormStatus == FormStatus.����)
            //{
            //    btnIsMerge_Click(null, null);
            //}


        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            Common.BindDZType(drpDZType, true);
            this.HTDataTableName = "Finance_CheckOperation";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "DLOADID", "ItemCode" };//������ϸУ�����¼���ֶ�
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            Common.BindOP(drpSaleOPID, true);
            Common.BindCheckMethodType(drpCheckMethodType, true);
            //Common.BindVendorByDZTypeID(drpVendorID, this.FormListAID, true);
            //new VendorProc(drpVendorID);
            DevMethod.BindVendorByDZTypeID(drpVendorID, this.FormListAID, true);//2015.4.8 CX UPDATE
            //Common.BindMLType(drpMLTpe, true);
            //Common.BindEnumUnit(drpUnit, true);
            txtMakeDate.DateTime = DateTime.Now.Date;
            Common.BindCLS(drpUnit, "Sale_SaleOrder", "Unit", true);


        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CheckOperation EntityGet()
        {
            CheckOperation entity = new CheckOperation();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.OrderCode = txtOrderCode.Text.Trim();

            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = txtFormDate.DateTime;
            entity.Remark = txtRemark.Text.Trim();
            entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.TotalCheckAmount = SysConvert.ToDecimal(txtTotalCheckAmount.Text.Trim());
            entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
            entity.CheckMethodTypeID = SysConvert.ToInt32(drpCheckMethodType.EditValue);
            entity.PreExAmount = SysConvert.ToDecimal(txtPreExAmount.Text.Trim());
            entity.PreInvoiceAmount = SysConvert.ToDecimal(txtPreInvoiceAmount.Text.Trim());
            entity.PreInvoiceQty = SysConvert.ToDecimal(txtPreInvoiceQty.Text.Trim());
            entity.ThisExAmount = SysConvert.ToDecimal(txtThisExAmount.Text.Trim());
            entity.ThisInvoiceAmount = SysConvert.ToDecimal(txtThisInvoiceAmount.Text.Trim());
            entity.ThisInvoiceQty = SysConvert.ToDecimal(txtThisInvoiceQty.Text.Trim());
            entity.MergeFlage = IsMerge;
            entity.InvoiceApplyNo = txtInvoiceApplyNo.Text.Trim();

            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }

            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CheckOperationDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CheckOperationDts[] entitydts = new CheckOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CheckOperationDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//�Ѵ��ڱ�ʾ�޸�
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                        entitydts[index].SelectByID();
                    }
                    else//����
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].DLOADID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADID"));
                    entitydts[index].DLOADSEQ = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADSEQ"));
                    entitydts[index].DLOADNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLOADNO"));
                    entitydts[index].DLOADDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADDtsID"));
                    entitydts[index].DCheckQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckQty"));

                    entitydts[index].TZAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TZAmount"));

                    entitydts[index].DCheckSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckSinglePrice"));
                    entitydts[index].DCheckDYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckDYPrice"));
                    if (entitydts[index].DCheckSinglePrice != 0)//���˵��۲�Ϊ0�����˽��=��������*���˵���+���˴�����+�������
                    {
                        entitydts[index].DCheckAmount = entitydts[index].DCheckQty * entitydts[index].DCheckSinglePrice + entitydts[index].DCheckDYPrice + entitydts[index].TZAmount;
                    }
                    else//���˵���Ϊ0��//���˵��۲�Ϊ0,���˽��=��������*���˵���+���˴�����+�������
                    {
                        entitydts[index].DCheckAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckAmount")) + entitydts[index].DCheckDYPrice + entitydts[index].TZAmount;
                    }
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark"));

                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));

                    entitydts[index].QSID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "QSID"));//ȱ��ID
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));

                    //entitydts[index]. = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "QSID"));//ȱ��ID

                    entitydts[index].FAmount1 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount1"));//С�׷�
                    entitydts[index].FAmount2 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount2"));//������
                    entitydts[index].FAmount3 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount3"));//�ư��
                    entitydts[index].FAmount4 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount4"));//�ϻ���





                    index++;
                }
            }
            return entitydts;
        }


        #endregion



        #region �����¼�
        /// <summary>
        /// ˫�����ص���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.���˵���);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }





        #endregion

        #region ����
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
                    if (Common.CheckSearchLookUpEditBlank(drpVendorID))
                    {
                        this.ShowMessage("��ѡ��" + lblVendor.Text.ToString());
                        return;
                    }
                    string str = string.Empty;
                    //if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    //{
                    //    this.ShowMessage("��ѡ���������");
                    //    return;
                    //}
                    if (this.FormListAID == 3 && IsMerge == 1)
                    {
                        frmLoadIOFormTotal frm = new frmLoadIOFormTotal();
                        frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
                        frm.DZFlag = 1;//���˼��زֿⵥ��
                        ///δ���˻��߶������������ڲֿ�����
                        frm.HTLoadConditionStr = " AND (ISNULL(DZFlag,0)=0 OR ABS(ISNULL(DZQty,0))<>ISNULL(Qty,0) )" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));//ֻ��ѯδ����


                        frm.ShowDialog();
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
                            setItemTotalNews(str);
                        }
                        return;

                    }
                    frmLoadIOForm frm2 = new frmLoadIOForm();
                    frm2.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
                    frm2.DZFlag = 1;//���˼��زֿⵥ��
                    ///δ���˻��߶������������ڲֿ�����
                    frm2.HTLoadConditionStr = " AND (ISNULL(DZFlag,0)=0 OR ISNULL(NoDZQty,0)<>0)" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));//ֻ��ѯδ����


                    frm2.ShowDialog();
                    if (frm2.DtsID != null && frm2.DtsID.Length != 0)
                    {
                        for (int i = 0; i < frm2.DtsID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm2.DtsID[i]);
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
        private void setItemTotalNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            int index = checkRowSet();
            int length = 0;
            int f = gridView1.RowCount;
            for (int i = index; i < orderid.Length + index; i++)
            {
                if (i >= f)
                {
                    WCommon.DataTableAddRow((DataTable)gridView1.GridControl.DataSource, i - 1);
                }
                string sql = "SELECT distinct(FormNo),ID,CompanyTypeID,FromIOFormID,WHTypeID,HeadType,SubType, VendorID,OutDep,Indep,DutyOP,WHOP,PassOP,SOID,SpecialNo,FormDate,CardNo,CheckDate,ConfirmFlag,CheckOP,WHID,WHType,LastUpdTime,DelFlag,SubmitFlag,LastUpdOP,Remark,JHCode,XZ,SaleOPID,DM,InvoiceNo,Expr1,Expr3,SectionID,DtsVendorID,SBitID,ItemCode,ItemName,ItemStd,ItemModel,VendorBatch,ColorNum,ColorName,YarnStatus,YarnTypeID,SizeName,Unit,(ISNULL(SinglePrice,0)*ISNULL(TotalQty,0)) as Amount,SinglePrice,WAmount,DtsSO,DtsSaleOPID,Needle,SourceWeight,SourceQty,MoveQty,MoveWeight,SourceTubeQty,TubeGW,TubeQty,MoveTubeQty,SourcePieceQty,MovePieceQty,PieceQty,PieceQtyDesc,JarNo,Twist,DLCode,GoodsCode,VColorNum,VColorName,VItemCode,PFPrice,SaleOPName,TotalQty,TotalAmount,SubmitOPID,SubmitTime,ToWHID,ToSectionID,ToSBitID,WHNM,FormNM,DZNo,DZTime,DZOPID,DZFlag,DZAmount,DZSinglePrice,DZQty,DtsInvoiceNo,DtsInvoiceDelTime,DtsInvoiceDelOPID,DtsInvoiceDelFlag,PayAmount,InvoiceQty,InOrderFormNo,InSO,DtsInVendorID,WeightUnit,MWeight,MWidth,GoodsLevel,DtsOrderFormNo,InvoiceAmount,FreeNum1,InSaleOPID,VendorName,VendorAttn,FormDZFlag,FormDZType,MLType,FHTypeID,KDNo,DYPrice,DEFlag,YQQty,AQty,NOKPQty,NoKPAmount,Volume,VConvertXS,QtyConvertXS,DVendorID,LoadDtsID,MakeOPName,DCOPID,MainID,SaleFlag,ColorFlag,BuyFlag,DtsRemark,Qty,Batch,DtsID  FROM UV1_WH_LoadIOFormDtsTotal WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count >= 1)
                {
                    dt.Rows[0]["Qty"] = SysConvert.ToDecimal(dt.Rows[0]["TotalQty"].ToString());
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToString(dt.Rows[0]["ID"]));
                    gridView1.SetRowCellValue(i, "DLOADSEQ", index);
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));//��������
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(i, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    //gridView1.SetRowCellValue(i, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "DCheckDYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));//��������
                    gridView1.SetRowCellValue(i, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));


                    if (FormListAID == 3)//���۶���
                    {
                        sql = "Select * from UV1_Sale_SaleOrderDts where 1=1";
                        sql += " AND FormNo=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                        sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                        sql += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                        sql += " AND ColorName=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ColorName"]));
                        DataTable dtS = SysUtils.Fill(sql);
                        if (dtS.Rows.Count != 0)
                        {
                            gridView1.SetRowCellValue(i, "FAmount1", SysConvert.ToDecimal(dtS.Rows[0]["FAmount1"]));//
                            gridView1.SetRowCellValue(i, "FAmount2", SysConvert.ToDecimal(dtS.Rows[0]["FAmount2"]));//
                            gridView1.SetRowCellValue(i, "FAmount3", SysConvert.ToDecimal(dtS.Rows[0]["FAmount3"]));//
                            gridView1.SetRowCellValue(i, "FAmount4", SysConvert.ToDecimal(dtS.Rows[0]["FAmount4"]));//
                        }
                    }


                    decimal DZQty = SysConvert.ToDecimal(dt.Rows[0]["DZQty"]); //��������
                    decimal DZAmount = SysConvert.ToDecimal(dt.Rows[0]["DZAmount"]);//���˽��
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));//���������
                        if (SysConvert.ToInt32(dt.Rows[0]["FormDZFlag"]) == (int)EnumDZFlag.���ʸ�)
                        {
                            gridView1.SetRowCellValue(i, "DCheckQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                            gridView1.SetRowCellValue(i, "Qty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "DCheckQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                        }
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SinglePrice"]) != string.Empty)//����ⵥ��
                    {
                        gridView1.SetRowCellValue(i, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                        gridView1.SetRowCellValue(i, "DCheckSinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["Amount"]) != string.Empty) //�������
                    {
                        gridView1.SetRowCellValue(i, "Amount", SysConvert.ToString(dt.Rows[0]["Amount"]));
                        if (SysConvert.ToInt32(dt.Rows[0]["FormDZFlag"]) == (int)EnumDZFlag.���ʸ�)
                        {
                            gridView1.SetRowCellValue(i, "DCheckAmount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]) - DZAmount);
                            gridView1.SetRowCellValue(i, "Amount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "DCheckAmount", SysConvert.ToDecimal(dt.Rows[0]["Amount"]) - DZAmount);
                        }
                    }

                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)//ƥ��
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }

                    length++;

                }
            }
        }
        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            int index = checkRowSet();
            int length = 0;
            int f = gridView1.RowCount;
            for (int i = index; i < orderid.Length + index; i++)
            {
                if (i >= f)
                {
                    WCommon.DataTableAddRow((DataTable)gridView1.GridControl.DataSource, i - 1);
                }
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count == 1)
                {
                    dt.Rows[0]["Qty"] = SysConvert.ToDecimal(dt.Rows[0]["Qty"].ToString()) - SysConvert.ToDecimal(dt.Rows[0]["YQQty"].ToString()); //������
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToString(dt.Rows[0]["ID"]));
                    gridView1.SetRowCellValue(i, "DLOADSEQ", SysConvert.ToString(dt.Rows[0]["Seq"]));
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));//��������
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(i, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(i, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    //gridView1.SetRowCellValue(i, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "DCheckDYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));//��������
                    gridView1.SetRowCellValue(i, "DYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));


                    if (FormListAID == 3)//���۶���
                    {
                        sql = "Select * from UV1_Sale_SaleOrderDts where 1=1";
                        sql += " AND FormNo=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                        sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                        sql += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                        sql += " AND ColorName=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ColorName"]));
                        DataTable dtS = SysUtils.Fill(sql);
                        if (dtS.Rows.Count != 0)
                        {
                            gridView1.SetRowCellValue(i, "FAmount1", SysConvert.ToDecimal(dtS.Rows[0]["FAmount1"]));//
                            gridView1.SetRowCellValue(i, "FAmount2", SysConvert.ToDecimal(dtS.Rows[0]["FAmount2"]));//
                            gridView1.SetRowCellValue(i, "FAmount3", SysConvert.ToDecimal(dtS.Rows[0]["FAmount3"]));//
                            gridView1.SetRowCellValue(i, "FAmount4", SysConvert.ToDecimal(dtS.Rows[0]["FAmount4"]));//
                        }
                    }


                    decimal DZQty = SysConvert.ToDecimal(dt.Rows[0]["DZQty"]); //��������
                    decimal DZAmount = SysConvert.ToDecimal(dt.Rows[0]["DZAmount"]);//���˽��
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));//���������
                        gridView1.SetRowCellValue(i, "Weight", SysConvert.ToString(SysConvert.ToDecimal(dt.Rows[0]["Weight"])));//����⹫����
                        gridView1.SetRowCellValue(i, "Yard", SysConvert.ToString(SysConvert.ToDecimal(dt.Rows[0]["Yard"])));//���������
                        if (SysConvert.ToInt32(dt.Rows[0]["FormDZFlag"]) == (int)EnumDZFlag.���ʸ�)
                        {
                            if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/KG" || SysConvert.ToString(dt.Rows[0]["Unit"]) == "USD/KG")
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Weight"]) - DZQty);
                                gridView1.SetRowCellValue(i, "Weight", 0 - SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                            }
                            else if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/M" || SysConvert.ToString(dt.Rows[0]["Unit"]) == "USD/M")
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                                gridView1.SetRowCellValue(i, "Qty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                            }
                            else if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/Y" || SysConvert.ToString(dt.Rows[0]["Unit"]) == "USD/Y")
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Yard"]) - DZQty);
                                gridView1.SetRowCellValue(i, "Yard", 0 - SysConvert.ToDecimal(dt.Rows[0]["Yard"]));
                            }
                            else
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                                gridView1.SetRowCellValue(i, "Qty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                            }
                        }
                        else
                        {
                            if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/KG" || SysConvert.ToString(dt.Rows[0]["Unit"]) == "USD/KG")
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", SysConvert.ToDecimal(dt.Rows[0]["Weight"]) - DZQty);
                            }
                            else if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/M" || SysConvert.ToString(dt.Rows[0]["Unit"]) == "USD/M")
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                            }
                            else if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/Y" || SysConvert.ToString(dt.Rows[0]["Unit"]) == "USD/Y")
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", SysConvert.ToDecimal(dt.Rows[0]["Yard"]) - DZQty);
                            }
                            else
                            {
                                gridView1.SetRowCellValue(i, "DCheckQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - DZQty);
                            }
                        }
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SinglePrice"]) != string.Empty)//����ⵥ��
                    {
                        gridView1.SetRowCellValue(i, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                        gridView1.SetRowCellValue(i, "DCheckSinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["Amount"]) != string.Empty) //�������
                    {
                        gridView1.SetRowCellValue(i, "Amount", SysConvert.ToString(dt.Rows[0]["Amount"]));
                        if (SysConvert.ToInt32(dt.Rows[0]["FormDZFlag"]) == (int)EnumDZFlag.���ʸ�)
                        {
                            gridView1.SetRowCellValue(i, "DCheckAmount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]) - DZAmount);
                            gridView1.SetRowCellValue(i, "Amount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "DCheckAmount", SysConvert.ToDecimal(dt.Rows[0]["Amount"]) - DZAmount);
                        }
                    }

                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)//ƥ��
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }

                    length++;

                }
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

        /// <summary>
        /// ���ݶ�������ȡ�ÿͻ���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpDZType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpDZType.EditValue) != 0)
                {
                    int DZType = SysConvert.ToInt32(drpDZType.EditValue);
                    //Common.BindVendorByDZTypeID(drpVendorID, DZType, true);
                    DevMethod.BindVendorByDZTypeID(drpVendorID, this.FormListAID, true);
                    //switch (DZType)
                    //{
                    //    case (int)EnumDZType.�ɹ�:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.���� }, true);
                    //        lblVendor.Text = "��Ӧ��";
                    //        break;
                    //    case (int)EnumDZType.�ӹ�:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.���� }, true);
                    //        lblVendor.Text = "�ӹ���";
                    //        break;
                    //    case (int)EnumDZType.����:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
                    //        lblVendor.Text = "�ͻ�";
                    //        break;

                    //}
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

                CheckOperationRule rule = new CheckOperationRule();
                rule.RSubmit(HTDataID, 1);

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
                //for(int i = 0;i<gridView1.RowCount;i++)
                //{
                //    string sql = "Select InvoiceQty from WH_IOFormDts where MainID=" + SysString.ToDBString(gridView1.GetRowCellValue (i,"DLOADID").ToString());
                //    sql += " AND Seq=" + SysString.ToDBString(gridView1.GetRowCellValue(i, "DLOADSEQ").ToString());
                //    DataTable dt = SysUtils.Fill(sql);
                //    if (dt.Rows.Count != 0) 
                //    {
                //        if (SysConvert .ToDecimal (dt.Rows[0]["InvoiceQty"]) != 0m)
                //        {
                //            this.ShowMessage("�ѿ�Ʊ�����ɳ����ύ");
                //            return;
                //        }
                //    }
                //}

                DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {

                    if (SysConvert.ToInt32(dr["InvoiceFlag"]) == 1)
                    {
                        this.ShowMessage("�ڣ�" + i + "�������ѿ�Ʊ�����ɳ����ύ");
                        return;
                    }
                    i++;
                }


                CheckOperationRule rule = new CheckOperationRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.�����ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void frmCheckOperation2Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    CheckOperation entity = new CheckOperation();
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

        private void btnIsMerge_Click(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.����)
            {
                IsMerge = 1;
            }
        }





    }
}