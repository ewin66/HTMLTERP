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
    public partial class frmInvoiceOperationEdit : frmAPBaseUIFormEdit
    {
        public frmInvoiceOperationEdit()
        {
            InitializeComponent();
        }
        bool ismx = false;
        int isMerge = 0;
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
            //if (SysConvert.ToInt32(drpKPType.EditValue) != (int)EnumKPType.�ڳ���Ʊ)
            //{
            //    if (txtInvoiceNO.Text.Trim() == "")
            //    {
            //        this.ShowMessage("�����뷢Ʊ��");
            //        txtInvoiceNO.Focus();
            //        return false;
            //    }
            //}

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

            if (SysConvert.ToInt32(drpKPType.EditValue) == 0)
            {
                this.ShowMessage("��ѡ��Ʊ���ͣ�");
                drpKPType.Focus();
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
        /// ��������ϸ
        /// </summary>
        public  void BindGridDts2()
        {
            InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));

            gridView2.GridControl.DataSource = dtDts;
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// ���������ݻ�����
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entitydts"></param>
        void ProcEntitySaveData(InvoiceOperation entity, InvoiceOperationDts[] entitydts)
        {
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            decimal PayAmount = 0;
            decimal totaltaxamount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].DInvoiceQty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].DInvoiceAmount);
                PayAmount += SysConvert.ToDecimal(entitydts[i].PayAmount);
                totaltaxamount += SysConvert.ToDecimal(entitydts[i].DInvoiceTaxAmount);
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.PayAmount = PayAmount;
            entity.TotalTaxAmount = totaltaxamount;

            entity.PreHXQty = entity.TotalQty;
            entity.PreHXAmount = entity.TotalAmount;
            entity.PreHXFlag = (int)YesOrNo.Yes;
        }

        /// <summary>
        /// ���������ݻ�����
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entitydts"></param>
        void ProcEntitySaveData2(InvoiceOperation entity, InvoiceYOperationDts[] entitydts)
        {
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            decimal PayAmount = 0;
            decimal totaltaxamount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entitydts[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
                
            }
            entity.TotalQty = TotalQty;
            entity.TotalAmount = TotalAmount;
            entity.PayAmount = PayAmount;
            entity.TotalTaxAmount = totaltaxamount;

            entity.PreHXQty = entity.TotalQty;
            entity.PreHXAmount = entity.TotalAmount;
            entity.PreHXFlag = (int)YesOrNo.Yes;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceOperationDts[] entitydts = EntityDtsGet();
            InvoiceYOperationDts[] entityDts2 = EntityDtsGet2();
            if (!ismx)
            {
                if (entity.KPType == (int)EnumKPType.Ԥ��Ʊ)
                {
                    ProcEntitySaveData2(entity, entityDts2);
                }
                else
                {
                    ProcEntitySaveData(entity, entitydts);
                }
                if (SysConvert.ToInt32(drpKPType.EditValue) == (int)EnumKPType.�ڳ���Ʊ)
                {
                    entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                    entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
                    entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
                }
            }
            else
            {
                entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            }
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            rule.RAdd(entity, entitydts, entityDts2);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            InvoiceOperationDts[] entitydts = EntityDtsGet();
            InvoiceYOperationDts[] entityDts2 = EntityDtsGet2();
            if (!ismx)
            {
                if (entity.KPType == (int)EnumKPType.Ԥ��Ʊ)
                {
                    ProcEntitySaveData2(entity, entityDts2);
                }
                else
                {
                    ProcEntitySaveData(entity, entitydts);
                }
                if (SysConvert.ToInt32(drpKPType.EditValue) == (int)EnumKPType.�ڳ���Ʊ)
                {
                    entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                    entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
                }
            }
            else
            {
                entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            }
            //if (entity.KPType == (int)EnumKPType.Ԥ��Ʊ)
            //{
            //    ProcEntitySaveData2(entity, entityDts2);
            //}
            //else
            //{
            //    ProcEntitySaveData(entity, entitydts);
            //}
            //if (SysConvert.ToInt32(drpKPType.EditValue) == (int)EnumKPType.�ڳ���Ʊ)
            //{
            //    entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            //    entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            //}
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entityDts2);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            ismx = entity.MXFlag == 0 ? false : true;
  			txtFormNo.Text = entity.FormNo.ToString();
            simpleButton1.Text = ismx ? "ָ����ϸ" : "��ָ����ϸ";
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
            drpKPType.EditValue = entity.KPType;

            txtMakeDate.DateTime = entity.MakeDate;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
            BindGridDts2();
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
             txtFormNo_DoubleClick(null, null);
             drpSaleOPID.EditValue = FParamConfig.LoginID;
             txtMakeDate.DateTime = DateTime.Now.Date;
             drpDZType.EditValue = FormListAID;//��������
             drpKPType.EditValue = 1;
             simpleButton1.Text = ismx ? "ָ����ϸ" : "��ָ����ϸ";
             //ismx = false;

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            //ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            //ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI

            this.HTDataTableName = "Finance_InvoiceOperation";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            this.HTCheckDataField = new string[] { "DLOADID", "ItemCode" };//������ϸУ�����¼���ֶ�

            Common.BindDZType(drpDZType, true);
            Common.BindOP(drpSaleOPID, true);
            Common.BindKPType(drpKPType, true);

            Common.BindCLS(drpUnit, "Data_Item", "ItemUnitAtt", true);
            Common.BindCLS(drpUnit2, "Data_Item", "ItemUnitAtt", true);
            if (!ismx)
            {
                this.ToolBarItemAdd(28, "btnLoadDCheck", "���ض���", false, btnLoadDCheck_Click);
            }

            //label7.Visible = ismx;
            simpleButton1.Text = ismx ? "ָ����ϸ" : "��ָ����ϸ";

            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "���غ�ͬ", false, btnLoad2_Click);
            //new VendorProc(drpVendorID);
            drpDZType.Enabled = false;


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
                    frm.InvoiceFlag = 1;
                    string tempConditionStr = " AND ISNULL(DZFlag,0)=1" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                    tempConditionStr += " AND  ABS(ISNULL(InvoiceQty,0))<>ISNULL(Qty,0) ";
                    tempConditionStr += " AND ABS(ISNULL(DZQty,0))>ABS(ISNULL(InvoiceQty,0))";
                    frm.HTLoadConditionStr = tempConditionStr;//ֻ��ѯ�Ѷ��� ������δ��Ʊ��������

                 
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
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "Batch", SysConvert.ToString(dt.Rows[0]["Batch"]));
                    gridView1.SetRowCellValue(i, "VendorBatch", SysConvert.ToString(dt.Rows[0]["VendorBatch"]));
                    gridView1.SetRowCellValue(i, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    gridView1.SetRowCellValue(i, "DInvoiceDYPrice", SysConvert.ToDecimal(dt.Rows[0]["DYPrice"]));
                    decimal InvoiceQty = SysConvert.ToDecimal(dt.Rows[0]["InvoiceQty"]);
                    decimal InvoiceAmount = SysConvert.ToDecimal(dt.Rows[0]["InvoiceAmount"]);
                    if (SysConvert.ToString(dt.Rows[0]["DZQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZQty", SysConvert.ToString(dt.Rows[0]["DZQty"]));
                        decimal tempQty = SysConvert.ToDecimal(dt.Rows[0]["DZQty"]) - InvoiceQty;//����δ��Ʊ����
                        gridView1.SetRowCellValue(i, "DInvoiceQty", tempQty);//SysConvert.ToString(dt.Rows[0]["DZQty"])
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                        gridView1.SetRowCellValue(i, "DInvoiceSinglePrice", SysConvert.ToString(dt.Rows[0]["DZSinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["DZAmount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "DZAmount", SysConvert.ToString(dt.Rows[0]["DZAmount"]));
                        decimal tempAmount = SysConvert.ToDecimal(dt.Rows[0]["DZAmount"]) - InvoiceAmount;//����δ��Ʊ���
                        gridView1.SetRowCellValue(i, "DInvoiceAmount", tempAmount);//SysConvert.ToString(dt.Rows[0]["DZAmount"])
                    }
                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }

                    gridView1.SetRowCellValue(i, "InvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["InvoiceQty"]));//��Ʊ����
                    gridView1.SetRowCellValue(i, "InvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["InvoiceAmount"]));//��Ʊ���


                }
            }
        }

     
        public void btnLaodQS_Click(object sender, EventArgs e)
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
                    if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    {
                        this.ShowMessage("��ѡ��Ʊ����");
                        return;
                    }

                    frmLoadQS frm = new frmLoadQS();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
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
                        setItemQS(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemQS(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            int Row = GetRow();
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  WH_QS WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i+Row, "DLOADID","0");
                    gridView1.SetRowCellValue(i + Row, "DLOADSEQ", "0");
                    gridView1.SetRowCellValue(i + Row, "DLOADNO", "");
                    gridView1.SetRowCellValue(i + Row, "DLOADDtsID", "0");


                    gridView1.SetRowCellValue(i + Row, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));

                    gridView1.SetRowCellValue(i + Row, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i + Row, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));



                    gridView1.SetRowCellValue(i + Row, "DInvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));//��Ʊ����
                    gridView1.SetRowCellValue(i + Row, "DInvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["Amount"]));//��Ʊ���
                    gridView1.SetRowCellValue(i + Row, "DInvoiceSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SinglePrice"]));//��Ʊ����
                    gridView1.SetRowCellValue(i + Row, "Remark", SysConvert.ToString(dt.Rows[0]["Remark"]));//��ע
                  


                }
            }
        }

        private int GetRow()
        {
            int row = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == "")
                {
                    row = i;
                    return row;
                }
            }
            return row;
        }
        #endregion

        #region ���ض��˵�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnLoadDCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    if (ismx)
                    {
                        return;
                    }
                    
                    if (Common.CheckSearchLookUpEditBlank(drpVendorID))
                    {
                        this.ShowMessage("��ѡ��" + lblVendor.Text.ToString());
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    {
                        this.ShowMessage("��ѡ��Ʊ����");
                        return;
                    }

                    frmLoadCheckForm frm = new frmLoadCheckForm();
                    frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);

                    string tempConditionStr = " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));

                    frm.HTLoadConditionStr = tempConditionStr;//ֻ��ѯ�Ѷ��� ������δ��Ʊ��������
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
                        SetDCheckItem(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetDCheckItem(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV2_Finance_CheckOperationDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToInt32(dt.Rows[0]["DLOADID"]));
                    gridView1.SetRowCellValue(i, "DLOADSEQ", SysConvert.ToInt32(dt.Rows[0]["DLOADSEQ"]));
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["DLOADNO"]));
                    gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToInt32(dt.Rows[0]["DLOADDtsID"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                  //  gridView1.SetRowCellValue(i, "DInvoiceDYPrice", SysConvert.ToDecimal(dt.Rows[0]["DCheckDYPrice"]));
                    gridView1.SetRowCellValue(i, "DZQty", SysConvert.ToDecimal(dt.Rows[0]["DCheckQty"]));
                    gridView1.SetRowCellValue(i, "DInvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["DCheckQty"]));
                    gridView1.SetRowCellValue(i, "DZSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["DCheckSinglePrice"]));
                    gridView1.SetRowCellValue(i, "DInvoiceSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["DCheckSinglePrice"]));
                    gridView1.SetRowCellValue(i, "DZAmount", SysConvert.ToDecimal(dt.Rows[0]["DCheckAmount"]));
                    gridView1.SetRowCellValue(i, "DInvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["DCheckAmount"]));
                    gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                    gridView1.SetRowCellValue(i, "DInvoiceDYPrice", SysConvert.ToDecimal(dt.Rows[0]["TZAmount"]));
                    gridView1.SetRowCellValue(i, "DLoadCheckDtsID", SysConvert.ToInt32(dt.Rows[0]["DtsID"]));

                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "MergeFlage", SysConvert.ToInt32(dt.Rows[0]["MergeFlage"]));
                    gridView1.SetRowCellValue(i, "InvoiceQty", SysConvert.ToDecimal(dt.Rows[0]["InvoiceQty"]));//��Ʊ����
                    gridView1.SetRowCellValue(i, "InvoiceAmount", SysConvert.ToDecimal(dt.Rows[0]["InvoiceAmount"]));//��Ʊ���


                }
            }
        }


      
        #endregion

        #region ���غ�ͬ

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoad2_Click(object sender, EventArgs e)
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
                    if (SysConvert.ToInt32(drpKPType.EditValue) !=(int)EnumKPType.Ԥ��Ʊ)
                    {
                        this.ShowMessage("��Ʊ������ѡ��Ԥ��Ʊ");
                        drpKPType.Focus();
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == (int)EnumDZType.����)
                    {
                        frmLoadOrder frm = new frmLoadOrder();
                        frm.CheckFlag2 = 1;
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
                    gridView2.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView2.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView2.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView2.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView2.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView2.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    gridView2.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));



                }
            }
        }


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
                    gridView2.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView2.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView2.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView2.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView2.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView2.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));

                    setRowID++;
                }
            }
        }
        #endregion

        #region Ԥ��Ʊ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadYInvoice_Click(object sender, EventArgs e)
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
                    if (SysConvert.ToInt32(drpKPType.EditValue) != (int)EnumKPType.������Ʊ)
                    {
                        this.ShowMessage("��Ʊ������ѡ��������Ʊ");
                        drpKPType.Focus();
                        return;
                    }

                    frmLoadYInvoice frm = new frmLoadYInvoice();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);


                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.DtsID != null && frm.DtsID.Length != 0)
                    {
                        //SetGridView1();// ��ֹһ���ɹ�������������ͬ������
                        for (int i = 0; i < frm.DtsID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.DtsID[i]);
                        }
                        setItemNews3(str);


                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews3(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            int Row = GetRow();
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Finance_InvoiceYOperationDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i + Row, "DLOADID", "0");
                    gridView1.SetRowCellValue(i + Row, "DLOADSEQ", "0");
                    gridView1.SetRowCellValue(i + Row, "DLOADDtsID", "0");
                    gridView1.SetRowCellValue(i + Row, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i + Row, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i + Row, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i + Row, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i + Row, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i + Row, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["DtsOrderNo"]));
                    gridView1.SetRowCellValue(i + Row, "DInvoiceQty", 0 - SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i + Row, "DInvoiceSinglePrice", SysConvert.ToDecimal(dt.Rows[0]["SinglePrice"]));
                    gridView1.SetRowCellValue(i + Row, "DInvoiceAmount", 0 - SysConvert.ToDecimal(dt.Rows[0]["Amount"]));
                    gridView1.SetRowCellValue(i + Row, "DLoadNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));


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
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = DateTime.Now.Date;
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.TotalTaxAmount = SysConvert.ToDecimal(entity.TotalAmount - entity.TotalAmount / 1.17m, 5);
  			entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
            entity.KPType = SysConvert.ToInt32(drpKPType.EditValue);
            entity.MXFlag = ismx ? 1 : 0;
            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = txtMakeDate.DateTime;
            }

            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private InvoiceOperationDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            InvoiceOperationDts[] entitydts = new InvoiceOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new InvoiceOperationDts();
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
  			 		entitydts[index].DInvoiceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceQty")); 
  			 		entitydts[index].DInvoiceSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceSinglePrice"));
                    entitydts[index].DInvoiceDYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceDYPrice")); 
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    if (entitydts[index].DInvoiceSinglePrice != 0)
                    {
                        entitydts[index].DInvoiceAmount = entitydts[index].DInvoiceQty * entitydts[index].DInvoiceSinglePrice + entitydts[index].DInvoiceDYPrice;
                    }
                    else
                    {
                        entitydts[index].DInvoiceAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DInvoiceAmount")) + entitydts[index].DInvoiceDYPrice; 
                    }
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].PayAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayAmount"));
                    entitydts[index].DLOADDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADDtsID"));
                    entitydts[index].DLoadCheckDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLoadCheckDtsID"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));

                    entitydts[index].DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts[index].DInvoiceAmount - entitydts[index].DInvoiceAmount / 1.17m, 5);
                    entitydts[index].MergeFlage = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MergeFlage"));
                    index++;
                }
            }
            return entitydts;
        }

        private InvoiceYOperationDts[] EntityDtsGet2()
        {

            int index = 0;
            for (int j = 0; j < gridView2.RowCount; j++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(j, "ItemCode")) != "")
                {
                    index++;
                }
            }
            InvoiceYOperationDts[] entitydts = new InvoiceYOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemCode")) != "")
                {
                    entitydts[index] = new InvoiceYOperationDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//�Ѵ��ڱ�ʾ�޸�
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "ID"));
                        entitydts[index].SelectByID();
                    }
                    else//����
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].ItemCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorName"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemName"));
                    entitydts[index].DtsOrderNo = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsOrderNo"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView2.GetRowCellValue(i, "Unit"));

                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "SinglePrice"));
                    if (entitydts[index].SinglePrice != 0)
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                    }
                    else
                    {
                        entitydts[index].Amount = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Amount"));
                    }
                    entitydts[index].DInvoiceTaxAmount = SysConvert.ToDecimal(entitydts[index].Amount - entitydts[index].Amount / 1.17m, 5);




                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    if (this.FormListAID == 3)//���ۿ�Ʊ
                    {
                        txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��Ʊ����);
                    }
                    else
                    {
                        txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��Ʊ����2);
                    }
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
                    //Common.BindVendorByDZTypeID(drpVendorID, DZType, true);   
                    DevMethod.BindVendorByDZTypeID(drpVendorID, DZType, true);//2015.4.8 CX UPDATE
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
                //string sql = "Update Finance_CheckOperationDts set LoadFlag = 1 where  ";
                //SysUtils.Fill(sql);

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

        private void frmInvoiceOperationEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    InvoiceOperation entity = new InvoiceOperation();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
            {
                ismx = ismx ? false : true;
                //label7.Visible = ismx;
                simpleButton1.Text = ismx ? "ָ����ϸ" : "��ָ����ϸ";
                //btnLoadDCheck_Click(null, null);
            }
        }


    }
}