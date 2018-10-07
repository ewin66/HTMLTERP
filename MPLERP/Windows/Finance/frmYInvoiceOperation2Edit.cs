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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmYInvoiceOperation2Edit : frmAPBaseUIFormEdit
    {
        public frmYInvoiceOperation2Edit()
        {
            InitializeComponent();
        }

        #region ȫ�ֱ���
        int saveIOFormDtsID = 0;//������ϸID
        #endregion
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("������ɫ�����");
            //    txtCode.Focus();
            //    return false;
            //}
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�����뿪Ʊ����");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��Ӧ��/�ͻ�");
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
            InvoiceOperationDtsRule rule = new InvoiceOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceYOperationDts[] entityDts = EntityDtsGet();
            decimal totalqty = 0;
            decimal totalamount = 0;
            for (int i = 0; i < entityDts.Length; i++)
            {
                totalqty += entityDts[i].Qty;
                totalamount += entityDts[i].Amount;
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalamount;
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RAdd2(entity, entityDts);

            return entity.ID;

            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceYOperationDts[] entityDts = EntityDtsGet();
            decimal totalqty = 0;
            decimal totalamount = 0;
            for (int i = 0; i < entityDts.Length; i++)
            {
                totalqty += entityDts[i].Qty;
                totalamount += entityDts[i].Amount;
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalamount;
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RUpdate2(entity, entityDts);
        }


        private InvoiceYOperationDts[] EntityDtsGet()
        {

            int index = 0;
            for (int j = 0; j < gridView3.RowCount; j++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(j, "ItemCode")) != "")
                {
                    index++;
                }
            }
            InvoiceYOperationDts[] entitydts = new InvoiceYOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemCode")) != "")
                {
                    entitydts[index] = new InvoiceYOperationDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].ItemCode = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView3.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemName"));
                    entitydts[index].DtsOrderNo = SysConvert.ToString(gridView3.GetRowCellValue(i, "DtsOrderNo"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Qty"));

                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;





                    index++;
                }
            }
            return entitydts;
        }
        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtOrderCode.Text = entity.OrderCode.ToString(); 
  			txtInvoiceNO.Text = entity.InvoiceNO.ToString();

            drpVendorID.EditValue = entity.VendorID;
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtDVendorCon.Text = entity.DVendorCon.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
  			txtTotalQty.Text = entity.TotalQty.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalTaxAmount.Text = entity.TotalTaxAmount.ToString();
            drpDZType.EditValue = entity.DZTypeID;
            txtMakeDate.DateTime = entity.MakeDate;
            txtMainHXQty.Text = entity.PreHXQty.ToString();
            txtMainHXAmount.Text = entity.PreHXAmount.ToString();
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            BindGridDts2();
        }

        /// <summary>
        /// ��������ϸ
        /// </summary>
        public  void BindGridDts2()
        {
            InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3));

            gridView3.GridControl.DataSource = dtDts;
            gridView3.GridControl.Show();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
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
             txtMakeDate.DateTime = DateTime.Now.Date;
             txtFormNo_DoubleClick(null, null);
             drpSaleOPID.EditValue = FParamConfig.LoginID;
             drpDZType.EditValue = FormListAID;
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            Common.BindDZType(drpDZType,true);
            Common.BindOP(drpSaleOPID, true);
            this.HTDataTableName = "Finance_InvoiceOperation";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2,gridView3 };
            this.HTCheckDataField = new string[] { "DLOADDtsID", "DInvoiceQty" };//������ϸУ�����¼���ֶ�
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            txtHXQMakeDateS.DateTime = DateTime.Now.AddMonths(-6).Date;
            txtHXQMakeDateE.DateTime = DateTime.Now.Date;
            new VendorProc(drpVendorID);
            this.ToolBarItemAdd(28,"btnLoad2", "����", false, btnLoad2_Click);
            this.gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);//��GridView2�¼�
            gridViewBindEventA2(gridView2);
            drpDZType.Enabled = false;

        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnLoad2_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    {
                        this.ShowMessage("��ѡ��������λ");
                        drpVendorID.Focus();
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == (int)EnumDZType.����)
                    {
                        frmLoadOrder frm = new frmLoadOrder();

                        frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);


                        frm.ShowDialog();
                        string str = string.Empty;
                        if (frm.OrderID != null && frm.OrderID.Length != 0)
                        {
                            //SetGridView1();// ��ֹһ���ɹ�������������ͬ������
                            for (int i = 0; i < frm.OrderID.Length; i++)
                            {
                                if (str != string.Empty)
                                {
                                    str += ",";
                                }
                                str += SysConvert.ToString(frm.OrderID[i]);
                            }
                            setItemNews2(str);

                        }
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == (int)EnumDZType.�ɹ�)
                    {
                        WHLoadItemBuyForm();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews2(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView3.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView3.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView3.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView3.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView3.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView3.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));



                }
            }
        }


        #region

        private void WHLoadItemBuyForm()
        {
            
            frmLoadItemBuy frm = new frmLoadItemBuy();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
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
                WHLoadItemBuyFormSetWH(str);

            }
        }

        /// <summary>
        /// �������ϲɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadItemBuyFormSetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    gridView3.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView3.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView3.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView3.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView3.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView3.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    setRowID++;
                }
            }
        }
        #endregion
        /// <summary>
        /// GridView2�иı�
        /// </summary>
        /// <param name="sender"></param>
        void gridViewRowChanged2(object sender)
        {
            ColumnView view = sender as ColumnView;

            saveIOFormDtsID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DtsID"]));

            txtPreHXFormNo.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["FormNo"]));
            txtPreHXQty.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DZQty"])) -
                SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["InvoiceQty"]))).ToString();
            txtPreHXSingPrice.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DZSinglePrice"]))).ToString();
            txtPreHXAmount.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DZAmount"])) -
                SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["InvoiceAmount"]))).ToString();
            txtPreHXRemark.Text = ""; 

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
                    if (Common.CheckLookUpEditBlank(drpVendorID))
                    {
                        this.ShowMessage("��ѡ��"+lblVendor.Text.ToString());
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    {
                        this.ShowMessage("��ѡ��Ʊ����");
                        return;
                    }

                    frmLoadIOForm frm = new frmLoadIOForm();
                    frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
                    frm.HTLoadConditionStr = " AND ISNULL(DZFlag,0)=1" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));//ֻ��ѯδ����
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
                        setItemNews(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToString(dt.Rows[0]["ID"]));
                    gridView1.SetRowCellValue(i, "DLOADSEQ", SysConvert.ToString(dt.Rows[0]["Seq"]));
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToString(dt.Rows[0]["DZQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
                        gridView1.SetRowCellValue(i, "DInvoiceQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                        gridView1.SetRowCellValue(i, "DInvoiceSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
                        gridView1.SetRowCellValue(i, "DInvoiceAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
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
        private InvoiceOperation EntityGet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;
            entity.SelectByID();

  			entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.OrderCode = txtOrderCode.Text.Trim(); 
  			entity.InvoiceNO = txtInvoiceNO.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = txtMakeDate.DateTime;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = DateTime.Now.Date;
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
  			entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
            entity.CheckDate = DateTime.Now.Date;
            entity.PreInvFlag = 1;
            entity.KPType = 2;
            entity.KPType = (int)EnumKPType.Ԥ��Ʊ;
  			 
            
            return entity;
        }

        ///// <summary>
        ///// ���ʵ��
        ///// </summary>
        ///// <returns></returns>
        //private InvoiceOperationDts[] EntityDtsGet()
        //{

        //    int index = GetDataCompleteNum();
        //    InvoiceOperationDts[] entitydts = new InvoiceOperationDts[index];
        //    index = 0;
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (CheckDataCompleteDts(i))
        //        {
        //            entitydts[index] = new InvoiceOperationDts();
        //            entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID")); 
        //            if (entitydts[index].MainID == HTDataID && HTDataID != 0)//�Ѵ��ڱ�ʾ�޸�
        //            {
        //                entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
        //                entitydts[index].SelectByID();
        //            }
        //            else//����
        //            {
        //                entitydts[index].MainID = HTDataID;
        //                entitydts[index].Seq = i + 1;
        //            }
                    
        //            entitydts[index].DLOADID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADID")); 
        //            entitydts[index].DLOADSEQ = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADSEQ")); 
        //            entitydts[index].DLOADNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLOADNO")); 
        //            entitydts[index].DInvoiceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceQty")); 
        //            entitydts[index].DInvoiceSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceSinglePrice"));
        //            entitydts[index].DInvoiceAmount = entitydts[index].DInvoiceQty * entitydts[index].DInvoiceSinglePrice; 
        //            entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
        //            entitydts[index].PayAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayAmount"));
        //            entitydts[index].DLOADDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADDtsID"));


        //            entitydts[index].DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts[index].DInvoiceAmount - entitydts[index].DInvoiceAmount / 1.17m, 5);

        //            index++;
        //        }
        //    }
        //    return entitydts;
        //}

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��Ʊ����);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

    

        private void drpDZType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpDZType.EditValue) != 0)
                {
                    int DZType = SysConvert.ToInt32(drpDZType.EditValue);

                    Common.BindVendorByDZTypeID(drpVendorID, DZType, true);
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
      


        #region �����¼�

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

                InvoiceOperationRule rule = new InvoiceOperationRule();
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

                InvoiceOperationRule rule = new InvoiceOperationRule();
                InvoiceOperation entity = new InvoiceOperation();
                entity.ID = HTDataID;
                entity.SelectByID();
                if (entity.PreHXQty != 0)
                {
                    this.ShowMessage("���к������ݣ��������ύ");
                    return;
                }
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

        #region �ֿ������ѯ����
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHXQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void BindGrid()
        {
            if (HTFormStatus != FormStatus.���� && HTFormStatus != FormStatus.�޸�)
            {
                IOFormRule rule = new IOFormRule();
                gridView2.GridControl.DataSource = rule.RShowDts(GetCondition(), ProcessGrid.GetQueryField(gridView2));
                gridView2.GridControl.Show();
            }
        }

        private string GetCondition()
        {
            string temp = "";
            if (txtItemCode.Text.Trim() != "")
            {
                temp += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                temp += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
            if (txtColorNum.Text.Trim() != "")
            {
                temp += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }
            if (txtColorName.Text.Trim() != "")
            {
                temp += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if(chkHXQMakeDate.Checked)
            {
                temp+=" AND FormDate BETWEEN "+SysString.ToDBString(txtHXQMakeDateS.DateTime)+" AND "+SysString.ToDBString(txtHXQMakeDateE.DateTime);
            }
            if(chkHXOnlyNOFinish.Checked)
            {

            }
            //if(!Common.CheckLookUpEditBlank(drpVendorID))
            //{
            //    temp+=" AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //}

            if (true)//ʹ��Ĭ�ϲ�ѯ���� m_THConditionStr == string.Empty
            {
                temp += " AND SubType IN(SELECT ID FROM Enum_FormList WHERE DZFlag<>0 AND DZType=" + SysString.ToDBString(SysConvert.ToInt32(drpDZType.EditValue)) + ")";
            }
            else//ʹ���˻���ѯ����
            {
                //tempStr += " AND SubType IN(" + m_THConditionStr + ")";
            }
            temp += " AND ISNULL(DZFlag,0)=1" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            temp += " AND ISNULL(DtsInvoiceDelFlag,0)=0";
            
            return temp;
        }

        #endregion

        #region ���� ����

        /// <summary>
        /// ��ú�����ϸʵ��
        /// </summary>
        /// <returns></returns>
        private InvoiceOperationDts EntityDtsGetOne()
        {

            InvoiceOperationDts entitydts = new InvoiceOperationDts();

            entitydts.MainID = HTDataID;
            entitydts.DLOADID = SysConvert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID"));
            entitydts.DLOADDtsID = SysConvert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DtsID"));
            entitydts.DLOADSEQ = SysConvert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Seq"));
            entitydts.DLOADNO = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "FormNo"));

            entitydts.DInvoiceQty = SysConvert.ToDecimal(txtPreHXQty.Text.Trim());
            entitydts.DInvoiceSinglePrice = SysConvert.ToDecimal(txtPreHXSingPrice.Text.Trim());
            entitydts.DInvoiceAmount = entitydts.DInvoiceQty * entitydts.DInvoiceSinglePrice;
            entitydts.Remark = txtPreHXRemark.Text.Trim();

            entitydts.DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts.DInvoiceAmount - entitydts.DInvoiceAmount / 1.17m, 5);

            entitydts.ItemCode = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ItemCode"));
            entitydts.ColorNum = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ColorNum"));
            entitydts.ColorName = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ColorName"));
           


            return entitydts;
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreHXExcute_Click(object sender, EventArgs e)
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
                    this.ShowMessage("�붨λ����¼");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("����δ�ύ�����ܲ���");
                    return;
                }

                if (saveIOFormDtsID == 0)
                {
                    this.ShowMessage("��ѡ����˼�¼");
                    return;
                }
                if (SysConvert.ToDecimal(txtPreHXQty.Text.Trim()) == 0)
                {
                    this.ShowMessage("�������������");
                    txtPreHXQty.Focus();
                    return;
                }

                InvoiceOperationRule rule = new InvoiceOperationRule();
                InvoiceOperation entity = EntityGet();
                InvoiceOperationDts entitydts = EntityDtsGetOne();

                rule.RHX(entity, entitydts);

                FCommon.AddDBLog(this.Text, "����", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

                this.BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreHXCancelExcute_Click(object sender, EventArgs e)
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
                    this.ShowMessage("�붨λ����¼");
                    return;
                }
                int dtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                if (dtsID == 0)
                {
                    this.ShowMessage("��ѡ�������¼");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("ȷ�ϳ�������������¼��"))
                {
                    return;
                }

                InvoiceOperationRule rule = new InvoiceOperationRule();
                InvoiceOperation entity = EntityGet();

                rule.RHXCancel(entity, dtsID);


                FCommon.AddDBLog(this.Text, "��������", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                this.BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreHXQty_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtPreHXAmount.Text = (SysConvert.ToDecimal(txtPreHXQty.Text.Trim()) * SysConvert.ToDecimal(txtPreHXSingPrice.Text.Trim())).ToString();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


    }
}