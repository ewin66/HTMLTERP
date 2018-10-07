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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ����۶����༭
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-4
    /// 
    /// 
    /// 2014-5-21
    /// �޸�����һ��ת��ģʽ
    /// ¼�붩�������ж����λ������ InputQty InputUnit
    /// ����ʱ����Enum_Unit����ĵ�λת���������ת���������λ ��תΪΪ������λ�������ݿ��ؽ���ת��
    /// �漰������Ϊ 5405 ת�����ܿ��� 5406 ת����λ
    /// ����ҵ�񵥾�ȫ��ʹ��ת����λ������ֻ�е��˷����������½��д���
    /// 
    /// </summary>
    public partial class frmSaleOrderEdit : frmAPBaseUIFormEdit
    {
        public frmSaleOrderEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�������ͬ��");
                txtFormNo.Focus();
                return false;
            }

            if (Common.CheckSearchLookUpEditBlank(drpVendorID))
            {
                this.ShowMessage("��ѡ��ͻ�");
                drpVendorID.Focus();
                return false;
            }

            if (Common.CheckLookUpEditBlank(drpOrderTypeID))
            {
                this.ShowMessage("��ѡ�񶩵�����");
                drpOrderTypeID.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpPayMothodFlag.EditValue) == 0)
            {
                this.ShowMessage("��ѡ�񸶿ʽ");
                drpPayMothodFlag.Focus();
                return false;
            }

            if (drpSaleFlowModuleID.Visible)
            {
                if (Common.CheckLookUpEditBlank(drpSaleFlowModuleID))
                {
                    this.ShowMessage("��ѡ������ģʽ");
                    drpSaleFlowModuleID.Focus();
                    return false;
                }
            }



            if (!this.CheckCorrectDts())
            {
                return false;
            }

            //if (!this.CheckSOCorrect())// ���鶩���Ƿ��ظ�
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// ���鶩���Ƿ��ظ�
        /// </summary>
        /// <returns></returns>
        //private bool CheckSOCorrect()
        //{
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //        {
        //            for (int j = 0; j < gridView1.RowCount; j++)
        //            {
        //                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //                {
        //                    if (i != j && SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorNum")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorName")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWeight")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWidth")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsReqDate")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "DtsReqDate")))
        //                    {
        //                        this.ShowMessage("��" + SysConvert.ToString(SysConvert.ToInt32(i + 1)) + "���������" + SysConvert.ToString(SysConvert.ToInt32(j + 1)) + "�������ظ�,��Ʒ���.ɫ��.��ɫ.�ŷ�.����.����һ��,��������±���");
        //                        return false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}


        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            SaleOrderDtsRule rule = new SaleOrderDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            SaleOrderDts[] entitydts = EntityDtsGet();
            SaleOrderProcedureDts[] entityProcedureDts = EntityProcedureDtsGet();

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
            entity.OrderStepID = (int)EnumOrderStep.�µ�;
            rule.RAdd(entity, entitydts, entityProcedureDts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            SaleOrderDts[] entitydts = EntityDtsGet();
            SaleOrderProcedureDts[] entityProcedureDts = EntityProcedureDtsGet();

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
            rule.RUpdate(entity, entitydts, entityProcedureDts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SaleOrder entity = new SaleOrder();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo;
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpVendorID.EditValue = entity.VendorID;
            drpVendorOPID.EditValue = entity.VendorOPID;
            drpOrderLevelID.EditValue = entity.OrderLevelID;
            drpOrderTypeID.EditValue = entity.OrderTypeID;
            txtReqDate.DateTime = entity.ReqDate;
            txtOrderDate.DateTime = entity.OrderDate;
            txtCustomerCode.Text = entity.CustomerCode.ToString();
            txtPayMethodID.Text = entity.PayMethodID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtContractDesc.Text = entity.ContractDesc.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            drpWLAmountType.EditValue = entity.WLAmountType;
            txtWLAmount.Text = entity.WLAmount.ToString();
            drpSaleFlowModuleID.EditValue = entity.SaleFlowModuleID;
            drpSaleOPID.EditValue = entity.SaleOPID;

            drpCurrency.EditValue = entity.Currency;

            drpVTel.EditValue = entity.VTel;
            drpVFax.EditValue = entity.VFax;
            drpVAddress.EditValue = entity.VAddress;
            txtCustomerCode2.Text = entity.CustomerCode2.ToString();
            txtEngAmount.Text = entity.EngAmount.ToString();

            chkConvertUnitFlag.Checked = SysConvert.ToBoolean(entity.ConvertUnitFlag);//ת����־
            if (!findFlag)
            {

            }


            BindGridDts();
            BindOrderInfo();
            BindOrderProcedureDts();
        }


        void BindOrderInfo()
        {
            ucOrderInfo1.OrderTypeID = 1;
            ucOrderInfo1.OrderNo = txtFormNo.Text.Trim();
            ucOrderInfo1.IniData();
        }

        /// <summary>
        /// ��������ϸ
        /// </summary>
        void BindOrderProcedureDts()
        {
            SaleOrderProcedureDtsRule rule = new SaleOrderProcedureDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID);
            SetCheckProcedure(chklSaleProcedure, dt);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            chklSaleProcedure.Enabled = false;

            ProcessGrid.SetGridEdit(gridView1, new string[] { "InputAmount", "Amount" }, false);


            if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5419)) == 1)//����������ģʽ0 �ֶ����룻 1 �Զ����ɣ�  2 Ա������+�����ˮ��
            {
                ProductCommon.FormNoCtlEditSet(txtFormNo, "Sale_SaleOrder", "FormNo", 0, p_Flag);
            }


            if (p_Flag)//����༭״̬������ɫ��ѡ��
            {
                BindGridColor();
            }
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtOrderDate.DateTime = DateTime.Now.Date;
            ParamSetRule psrule = new ParamSetRule();
            txtReqDate.DateTime = DateTime.Now.Date.AddDays(psrule.RShowIntByCode((int)ParamSetEnum.���ۺ�ͬ�����Զ��Ӻ�����)).Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
            drpSaleOPID.EditValue = FParamConfig.LoginID;

            drpCurrency.EditValue = "USD";//����Ĭ������
            drpOrderTypeID.Text = "�������";
            drpOrderLevelID.Text = "��ͨ";

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrder";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode", "Qty", "Unit", "DtsReqDate" };//������ϸУ�����¼���ֶ�

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//ת��ΪĬ�ϵ�λģʽ����,Ŀǰ֧��ת��Ϊ����ģʽ
            {
                this.HTCheckDataField = new string[] { "ItemCode", "InputQty", "InputUnit", "DtsReqDate" };//������ϸУ�����¼���ֶ�
            }
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "��������", false, btnLoad_Click);
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5407)))//���۶������ϰ�ť����
            {
                btnYarnCalc.Visible = false;
                btnFabricCalc.Visible = false;
            }
            else if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5402)))//���۶������ϲ����ϰ�ť��ʾ��ͬʱ���Ƴ�Ʒ�ɹ����ظ��ϲ����ϰ�ť
            {
                btnFabricCompSiteCalc.Visible = true;
            }
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5404)))//���۶���ʹ���µ������Ƶ�ʱȷ���Ƿ���Ҫ��λת��ģʽ�����㷽������;Ĭ�Ϸ񣬴˹�������Ϊ��ʱ��5405Ӧ����Ϊ0����5406��Ч���ַ���ֵ�������õ�ת����ʽ����0/1:Ĭ�Ϲ�ʽ/��ʽģʽ��/
            {
                chkConvertUnitFlag.Visible = true;
            }
            else
            {
                chkConvertUnitFlag.Visible = false;
            }
            if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) != 0)//���۶�����ʾ�����Ϣ 0������ʾ���; 1����ʾ�����Ϣ;2:ֻ��ʾɴ�߿��;3��ֻ��ʾ�������;4ֻ��ʾ��Ʒ���
            {
                xtraTabControl1.Visible = true;

                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) == 2)
                {
                    xtraTabPage1.PageVisible = true;//ɴ�߿��
                    xtraTabPage2.PageVisible = false;//�������
                    xtraTabPage3.PageVisible = false;//��Ʒ���
                }
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) == 3)
                {
                    xtraTabPage1.PageVisible = false;//ɴ�߿��
                    xtraTabPage2.PageVisible = true;//�������
                    xtraTabPage3.PageVisible = false;//��Ʒ���
                }
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5415)) == 4)
                {
                    xtraTabPage1.PageVisible = false;//ɴ�߿��
                    xtraTabPage2.PageVisible = false;//�������
                    xtraTabPage3.PageVisible = true;//��Ʒ���
                }

            }
            else
            {
                xtraTabControl1.Visible = false;
            }
            chklSaleProcedure.BackColor = this.BackColor;//����ؼ�����ɫ����
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5420)))//���۶�������ģʽ����
            {
                drpSaleFlowModuleID.Visible = false;
                chklSaleProcedure.Location = new System.Drawing.Point(195, 627);
                lbSalePro.Visible = false;
            }
        }


        /// <summary>
        /// ��ʼ��ˢ������(�������ʱ���û�ˢ�°�ťʱ����)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindOrderType(drpOrderTypeID, true);
            Common.BindOrderLevel(drpOrderLevelID, true);
            Common.BindWLAmount(drpWLAmountType, true);
            Common.BindPayMethod(drpPayMothodFlag, true);
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindSaleFlowModule(drpSaleFlowModuleID, true);
            Common.BindSaleProcedure(chklSaleProcedure, false);
            Common.BindSOContext(drpSOContext, "����", true);
            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);
            DevMethod.BindItem(drpItemCode, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.ҵ�� }, true);
        }

        private void gridViewRowChanged1(object sender)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GoodsCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));
                //Common.BindItemSalePrice(txtItemSalePrice, ItemCode, GoodsCode, ColorNum, ColorName, true);
                // this.ShowMessage(view.FocusedRowHandle.ToString());
                BindGridColor();


                if (xtraTabControl1.Visible == true)
                {
                    ShowStorgeInfo(ItemCode);
                }
                this.gridView1.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �������б��ڵ���ɫ�ؼ�
        /// </summary>
        void BindGridColor()
        {
            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)//�������޸ģ�����ɫ��ɫ��
            {
                string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                Common.BindItemColor(drpGridColorNum, drpGridColorName, itemCode, true);//�������ϰ�ɫ��ɫ��
            }
        }

        /// <summary>
        /// ��ʾ�����Ϣ
        /// </summary>
        private void ShowStorgeInfo(string p_ItemCode)
        {
            try
            {
                int PItemType = 0;
                string sql = "select * from Data_Item where ItemCode=" + SysString.ToDBString(p_ItemCode);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    PItemType = SysConvert.ToInt32(dt.Rows[0]["ItemTypeID"]);
                    string GreyFabItemCode = SysConvert.ToString(dt.Rows[0]["GreyFabItemCode"]);

                    if (PItemType == (int)EnumItemType.����)
                    {
                        sql = "SELECT Sum(Qty) SQty,ColorNum,ColorName FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//��ѯɫɴ���            
                        sql += " GROUP BY ColorNum,ColorName ORDER BY SQty DESC";
                        DataTable dtS = SysUtils.Fill(sql);
                        decimal tqty = 0;
                        string tstr = string.Empty;
                        foreach (DataRow dr in dtS.Rows)
                        {
                            tqty += SysConvert.ToDecimal(dr["SQty"]);

                            tstr += Environment.NewLine + "ɫ��/��ɫ��" + dr["ColorNum"].ToString() + "/" + dr["ColorName"].ToString() + " ������" + SysConvert.ToDecimal(dr["SQty"]);


                        }

                        tstr = "���ϼ�:" + tqty.ToString() + tstr;//��ϸ��
                        txtWHStorgeQtyCP.Text = tstr;


                        sql = "SELECT Sum(Qty) SQty,Batch FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(GreyFabItemCode);//�������            
                        sql += " GROUP BY Batch ORDER BY SQty DESC";
                        dtS = SysUtils.Fill(sql);
                        tqty = 0;
                        tstr = string.Empty;
                        foreach (DataRow dr in dtS.Rows)
                        {
                            tqty += SysConvert.ToDecimal(dr["SQty"]);

                            tstr += Environment.NewLine + "���ţ�" + dr["Batch"].ToString() + " ������" + SysConvert.ToDecimal(dr["SQty"]);
                        }
                        tstr = "���ϼ�:" + tqty.ToString() + tstr;//��ϸ��
                        txtWHStorgePB.Text = tstr;









                    }

                    if (PItemType == (int)EnumItemType.����)
                    {
                        sql = "SELECT Sum(Qty) SQty,Batch FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//��ѯɫɴ���            
                        sql += " GROUP BY Batch ORDER BY SQty DESC";
                        DataTable dtS = SysUtils.Fill(sql);
                        decimal tqty = 0;
                        string tstr = string.Empty;
                        foreach (DataRow dr in dtS.Rows)
                        {
                            tqty += SysConvert.ToDecimal(dr["SQty"]);

                            tstr += Environment.NewLine + "���ţ�" + dr["Batch"].ToString() + " ������" + SysConvert.ToDecimal(dr["SQty"]);


                        }

                        tstr = "���ϼ�:" + tqty.ToString() + tstr;//��ϸ��

                        txtWHStorgePB.Text = tstr;
                    }



                    decimal tqtySX = 0;
                    string tstrSX = string.Empty;
                    sql = "Select * from Data_ItemDts where MainID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    sql += " AND DtsItemCode<>''";
                    DataTable dtY = SysUtils.Fill(sql);
                    if (dtY.Rows.Count != 0)
                    {
                        tstrSX = string.Empty;

                        for (int i = 0; i < dtY.Rows.Count; i++)
                        {

                            sql = "SELECT Sum(Qty) SQty FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(SysConvert.ToString(dtY.Rows[i]["DtsItemCode"]));//ɴ��            
                            sql += "  ORDER BY SQty DESC";
                            DataTable dtS = SysUtils.Fill(sql);

                            //tqtySX = 0;
                            tstrSX += Environment.NewLine + "ɴ��Ʒ����" + SysConvert.ToString(dtY.Rows[i]["DtsItemModel"]);
                            if (dtS.Rows.Count != 0)
                            {
                                foreach (DataRow dr in dtS.Rows)
                                {
                                    tqtySX += SysConvert.ToDecimal(dr["SQty"]);

                                    tstrSX += Environment.NewLine + " ������" + SysConvert.ToDecimal(dr["SQty"]);
                                }
                            }
                            else
                            {
                                tstrSX += Environment.NewLine + " ������0";
                            }

                        }
                        tstrSX = "���ϼ�:" + tqtySX.ToString() + tstrSX;//��ϸ��
                        txtWHStorgeQtySX.Text = tstrSX;
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
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleOrder EntityGet()
        {
            SaleOrder entity = new SaleOrder();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime;
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.OrderLevelID = SysConvert.ToInt32(drpOrderLevelID.EditValue);
            entity.OrderTypeID = SysConvert.ToInt32(drpOrderTypeID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
            entity.OrderDate = txtOrderDate.DateTime;
            entity.ReqDate = txtReqDate.DateTime;
            entity.PayMethodID = txtPayMethodID.Text.Trim();
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.ContractDesc = txtContractDesc.Text.Trim();
            entity.CustomerCode = txtCustomerCode.Text.Trim();
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.WLAmountType = SysConvert.ToInt32(drpWLAmountType.EditValue);
            entity.WLAmount = SysConvert.ToDecimal(txtWLAmount.Text.Trim());
            entity.SaleFlowModuleID = SysConvert.ToInt32(drpSaleFlowModuleID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.ConvertUnitFlag = SysConvert.ToInt32(chkConvertUnitFlag.Checked);

            entity.Currency = SysConvert.ToString(drpCurrency.EditValue);
            entity.VTel = SysConvert.ToString(drpVTel.EditValue);
            entity.VFax = SysConvert.ToString(drpVFax.EditValue);
            entity.VAddress = SysConvert.ToString(drpVAddress.EditValue);
            entity.CustomerCode2 = txtCustomerCode2.Text.Trim();
            entity.EngAmount = txtEngAmount.Text.Trim();
            entity.FAID = 1;
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleOrderDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            SaleOrderDts[] entitydts = new SaleOrderDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new SaleOrderDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].AllMWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "AllMWidth"));

                    entitydts[index].FAmount1 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount1"));
                    entitydts[index].FAmount2 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount2"));
                    entitydts[index].FAmount3 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount3"));
                    entitydts[index].FAmount4 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount4"));
                    entitydts[index].FAmount5 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FAmount5"));

                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));//���

                    entitydts[index].InputQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputQty"));
                    entitydts[index].InputUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "InputUnit"));
                    entitydts[index].InputSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputSinglePrice"));
                    entitydts[index].InputAmount = entitydts[index].InputSinglePrice * entitydts[index].InputQty + entitydts[index].FAmount1 + entitydts[index].FAmount2 + entitydts[index].FAmount3 + entitydts[index].FAmount4 + entitydts[index].FAmount5;
                    entitydts[index].InputConvertXS = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "InputConvertXS"));

                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].DYPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DYPrice"));

                    entitydts[index].Amount = entitydts[index].SingPrice * entitydts[index].Qty + entitydts[index].FAmount1 + entitydts[index].FAmount2 + entitydts[index].FAmount3 + entitydts[index].FAmount4 + entitydts[index].FAmount5;
                    entitydts[index].DtsReqDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "DtsReqDate"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
                    entitydts[index].OutRange = SysConvert.ToString(gridView1.GetRowCellValue(i, "OutRange"));
                    entitydts[index].FK = SysConvert.ToString(gridView1.GetRowCellValue(i, "FK"));
                    entitydts[index].MaxQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MaxQty"));
                    entitydts[index].MinQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MinQty"));
                    entitydts[index].ReqDateEdit = SysConvert.ToString(gridView1.GetRowCellValue(i, "ReqDateEdit"));


                    if (chkConvertUnitFlag.Checked || SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//2014.6.22 ֧�ֽ��湴ѡ�ж��Ƿ���Ҫת��  �� ���������� ת��ΪĬ�ϵ�λģʽ����,Ŀǰ֧��ת��Ϊ����ģʽ
                    {
                        string unitdefault = SysConvert.ToString(ProductParamSet.GetStrValueByID(5406));//ת����Ĭ�ϵ�λ
                        if (unitdefault != string.Empty)
                        {
                            entitydts[index].Unit = unitdefault;//��ֵת����λ
                        }

                        int calMode = -1;//���㹫ʽ����
                        string baseUnit = string.Empty;
                        decimal baseQty = ProductCommon.UnitConvertValueBaseUnit(entitydts[index].InputUnit, entitydts[index].InputQty, out baseUnit);
                        if (baseUnit != entitydts[index].Unit)//�ͻ�����λ��һ�£�Ҫ����
                        {
                            //Ŀǰ�����ȫ��������ת��Ϊ����KG
                            decimal convertQty = 0;
                            if (chkConvertUnitFlag.Checked)//ʹ���Ƶ������ù�ʽ
                            {
                                calMode = SysConvert.ToInt32(ProductParamSet.GetStrValueByID(5404));//���۶���ʹ���µ������Ƶ�ʱȷ���Ƿ���Ҫ��λת��ģʽ�����㷽������
                                switch (calMode)
                                {
                                    case 0://������
                                        break;
                                    case 1://����һ
                                        // convertQty = ProductCommon.UnitConvertMiToKG1ST(baseQty, entitydts[index].MWidth, entitydts[index].MWeight);
                                        break;
                                    case 2://������
                                        // convertQty = ProductCommon.UnitConvertMiToKG2ND(baseQty, entitydts[index].MWidth, entitydts[index].MWeight);//��������������ã�Ŀǰ�����ᱣ����
                                        break;
                                    case 10://����ʮ
                                        convertQty = ProductCommon.UnitConvertMiToUnit10Ten(entitydts[index].InputQty, entitydts[index].InputConvertXS);//ת��ϵ��ֱ�Ӽ���
                                        break;
                                }

                            }
                            else
                            {
                                //  convertQty = ProductCommon.UnitConvertMiToKG2ND(baseQty, entitydts[index].MWidth, entitydts[index].MWeight);//��������������ã�Ŀǰ�����ᱣ����
                            }
                            entitydts[index].Qty = SysConvert.ToDecimal(convertQty, 2);//ת��������


                        }
                        else//һ�£����û��㣬��Ҫ���¸�ֵ�������������ۼ����
                        {
                            entitydts[index].Qty = SysConvert.ToDecimal(baseQty, 2);
                        }

                        if (calMode != 10)//����ʮ�ǲ��ù�ϵ����,������Ǹ��ݶ���¼��ϵ��ֱ�ӻ����
                        {
                            if (entitydts[index].InputQty != 0)
                            {
                                entitydts[index].InputConvertXS = SysConvert.ToDecimal(entitydts[index].Qty / entitydts[index].InputQty, 4);
                            }
                            else
                            {
                                entitydts[index].InputConvertXS = 0;
                            }
                        }
                        if (entitydts[index].InputConvertXS != 0)
                        {
                            entitydts[index].SingPrice = SysConvert.ToDecimal(entitydts[index].InputSinglePrice / entitydts[index].InputConvertXS, 2);
                        }

                        entitydts[index].Amount = entitydts[index].InputAmount;
                    }
                    else//��ת����
                    {
                        if (gridView1.Columns["InputQty"].Visible)//�µ��ɼ�
                        {
                            entitydts[index].Qty = entitydts[index].InputQty;
                            entitydts[index].SingPrice = entitydts[index].InputSinglePrice;
                            entitydts[index].Unit = entitydts[index].InputUnit;
                            entitydts[index].Amount = entitydts[index].InputAmount;
                        }
                    }



                    if (this.HTFormStatus == FormStatus.���� || entitydts[index].ID == 0)//�༭״̬��������ϸ��¼
                    {
                        entitydts[index].OrderStepID = (int)EnumOrderStep.�µ�;
                    }

                    index++;
                }
            }
            return entitydts;
        }


        #region ����ģʽ���
        /// <summary>
        /// ������ѡ��
        /// </summary>
        /// <param name="p_CheckList"></param>
        private void SetCheckProcedure(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList, DataTable p_Dt)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (DataRow dr in p_Dt.Rows)//������¼
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr["SaleProcedureID"].ToString() == p_CheckList.GetItemValue(i).ToString())//ֵ���
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// �����ϸʵ��
        /// </summary>
        /// <returns></returns>
        private SaleOrderProcedureDts[] EntityProcedureDtsGet()
        {
            int num = 0;
            for (int i = 0; i < chklSaleProcedure.ItemCount; i++)
            {
                if (chklSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    num++;
                }
            }

            SaleOrderProcedureDts[] entityA = new SaleOrderProcedureDts[num];
            num = 0;
            for (int i = 0; i < chklSaleProcedure.ItemCount; i++)
            {
                if (chklSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    entityA[num] = new SaleOrderProcedureDts();
                    entityA[num].MainID = HTDataID;
                    entityA[num].Seq = num + 1;
                    entityA[num].SaleProcedureID = SysConvert.ToInt32(chklSaleProcedure.GetItemValue(i));
                    num++;
                }
            }
            return entityA;
        }

        #endregion

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

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ1))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                if (!CheckCalc())
                {
                    return;
                }

                SaleOrderRule rule = new SaleOrderRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.���ύ, this.FormID, this.FormListAID, this.FormListBID);
                FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �ύ���ϼ��
        /// </summary>
        /// <returns></returns>
        private bool CheckCalc()
        {
            bool calCheckFlag = true;//�Ƿ�У������,Ĭ����У���
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5407)))//���۶������ϰ�ť����
            {
                calCheckFlag = false;
            }
            else if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5408)))//���۶����ύʱ����֤�Ƿ�����
            {
                calCheckFlag = false;
            }
            if (calCheckFlag)//У������
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (CheckCalcProcedureNeedCheck(new int[] { (int)EnumSaleProcedure.ɴ�߲ɹ���, (int)EnumSaleProcedure.Ⱦɴ�ӹ��� }))//ɴ�߲ɹ�/Ⱦɴ�ӹ�����Ҫ����
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YarnCalcFlag")) == 0)
                        {
                            this.ShowMessage("��" + SysConvert.ToInt32(i + 1).ToString() + "��û�н���ɴ�����ϣ����飡");
                            return false;
                        }
                    }
                    if (CheckCalcProcedureNeedCheck(new int[] { (int)EnumSaleProcedure.�����ɹ��� }))//�����ɹ�����Ҫ����
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FabricCalcFlag")) == 0)
                        {
                            this.ShowMessage("��" + SysConvert.ToInt32(i + 1).ToString() + "��û�н����������ϣ����飡");
                            return false;
                        }
                    }

                    if (CheckCalcProcedureNeedCheck(new int[] { (int)EnumSaleProcedure.��Ʒ�ɹ��� }))//��Ʒ�ɹ���Ʒ���Ǹ��ϲ�����Ҫ�㸴������
                    {
                        int fabtypeID = ProductCommon.ItemControlGetFabricType(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode")));
                        if (fabtypeID == (int)EnumFabricType.��������)
                        {
                            if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CompSiteCalFlag")) == 0)
                            {
                                this.ShowMessage("��" + SysConvert.ToInt32(i + 1).ToString() + "��û�н��и������ϣ����飡");
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ����ύ�����Ƿ���ҪУ��
        /// </summary>
        /// <param name="p_ProcedureIDA"></param>
        /// <returns></returns>
        private bool CheckCalcProcedureNeedCheck(int[] p_ProcedureIDA)
        {
            bool outb = false;
            for (int i = 0; i < chklSaleProcedure.ItemCount; i++)
            {
                if (chklSaleProcedure.GetItemCheckState(i) == CheckState.Checked)
                {
                    for (int j = 0; j < p_ProcedureIDA.Length; j++)
                    {
                        if (SysConvert.ToInt32(chklSaleProcedure.GetItemValue(i)) == p_ProcedureIDA[j])//����ҵ�������ѭ��
                        {
                            outb = true;
                            break;
                        }
                    }
                }
                if (outb)//����ҵ�������ѭ��
                {
                    break;
                }
            }
            return outb;
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

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ2))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                SaleOrderRule rule = new SaleOrderRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.δ�ύ, this.FormID, this.FormListAID, this.FormListBID);

                FCommon.AddDBLog(this.Text, FormStatus.�����ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region �����¼�
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��ͬ��);

                    if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5419)) == 1)//����������ģʽ0 �ֶ����룻 1 �Զ����ɣ�  2 Ա������+�����ˮ��
                    {
                        ProductCommon.FormNoIniSet(txtFormNo, "Sale_SaleOrder", "FormNo", 0);
                    }
                    else if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5419)) == 2)
                    {
                        if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
                        {
                            string sql = "Select OPCode from Data_OP Where OPID = " + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
                            DataTable dt = SysUtils.Fill(sql);
                            if (dt.Rows.Count == 1)
                            {
                                string OPCode = SysConvert.ToString(dt.Rows[0]["OPCode"]);//Ա������                               
                                string FormNo = OPCode + DateTime.Now.Date.ToString("yyMM");//��ͬ��                               
                                sql = "Select ISNULL(Max(FormNo),'') FormNo from Sale_SaleOrder Where FormNo Like " + SysString.ToDBString(FormNo + "%");
                                DataTable dtFormNo = SysUtils.Fill(sql);
                                if (dtFormNo.Rows.Count == 1)
                                {
                                    string MaxFormNo = SysConvert.ToString(dtFormNo.Rows[0]["FormNo"]);
                                    if (MaxFormNo != string.Empty)
                                    {
                                        int Sort = SysConvert.ToInt32(MaxFormNo.Substring(MaxFormNo.Length - 3, 3)) + 1;
                                        txtFormNo.Text = FormNo + SysString.LongToStr(Sort, 3);
                                    }
                                    else
                                    {
                                        txtFormNo.Text = FormNo + "001";
                                    }
                                }

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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                restxtItemCode_DoubleClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ˫����Ʒ������ز�Ʒ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.SelectItemType = SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5413)); //0����ʾֻ֧�ּ��ز�Ʒ  1����ʾֻ֧��ѡ����ز�Ʒ��������  2:��ʾ����


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
                    gridViewRowChanged1(gridView1);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string str)
        {

            int setRowID = Common.GetNewRow(gridView1, "ItemCode");
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "FK", SysConvert.ToString(dt.Rows[0]["FK"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    setRowID++;
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
        /// ѡ���ͬ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSOContext_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Context FROM Data_SOContext WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpSOContext.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtContractDesc.Text = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void frmSaleOrderEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    SaleOrder entity = new SaleOrder();
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

        /// <summary>
        /// ɴ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYarnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (HTDataID == 0)
                {
                    this.ShowMessage("�뱣�����ݺ���д��ͬ����");
                    return;
                }
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {

                    return;
                }
                //if (HTDataSubmitFlag == (int)YesOrNo.Yes)
                //{
                //    this.ShowMessage("�������ύ������������");
                //    return;
                //}
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                int DID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frmSaleItem2 frm = new frmSaleItem2();
                frm.ID = HTDataID;
                frm.DID = DID;
                frm.SO = txtFormNo.Text.Trim();
                frm.ShowDialog();
                BindGridDts();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { DID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricCalc_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (HTDataID == 0)
                {
                    this.ShowMessage("�뱣�����ݺ�����");
                    return;
                }
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {

                    return;
                }

                //if (HTDataSubmitFlag == (int)YesOrNo.Yes)
                //{
                //    this.ShowMessage("�������ύ������������");
                //    return;
                //}
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                int DID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frmSaleFabric frm = new frmSaleFabric();
                frm.ID = HTDataID;
                frm.DID = DID;
                frm.SO = txtFormNo.Text.Trim();
                frm.ShowDialog();
                BindGridDts();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { DID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ϲ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricCompSiteCalc_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (HTDataID == 0)
                {
                    this.ShowMessage("�뱣�����ݺ�����");
                    return;
                }
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    return;
                }
                //if (HTDataSubmitFlag == (int)YesOrNo.Yes)
                //{
                //    this.ShowMessage("�������ύ������������");
                //    return;
                //}
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                int DID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frmSaleFabricCompSite frm = new frmSaleFabricCompSite();
                frm.ID = HTDataID;
                frm.DID = DID;
                frm.SO = txtFormNo.Text.Trim();
                frm.ShowDialog();
                BindGridDts();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { DID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ѡ��ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSaleFlowModuleID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)//�༭״̬�¶�ȡģʽֵ
                {
                    int flowID = SysConvert.ToInt32(drpSaleFlowModuleID.EditValue);
                    SaleFlowModuleDtsRule dtsrule = new SaleFlowModuleDtsRule();
                    DataTable dt = dtsrule.RShow(" AND MainID=" + flowID);
                    SetCheckProcedure(chklSaleProcedure, dt);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        /// <summary>
        /// ֵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {

                    Common.BindVendorContact(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
                    Common.BindVendorAddress(drpVAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




        /// <summary>
        /// ֵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (this.HTFormStatus == FormStatus.���� || this.HTFormStatus == FormStatus.�޸�)
                {
                    if (e.Column.FieldName == "ItemCode")
                    {
                        ColumnView view = sender as ColumnView;
                        string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                        string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 1)
                        {
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemName", dt.Rows[0]["ItemName"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemStd", dt.Rows[0]["ItemStd"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemModel", dt.Rows[0]["ItemModel"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "Unit", dt.Rows[0]["ItemUnit"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "Needle", dt.Rows[0]["Needle"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "WeightUnit", dt.Rows[0]["WeightUnit"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "FK", dt.Rows[0]["FK"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWidth", dt.Rows[0]["MWidth"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWeight", dt.Rows[0]["MWeight"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"]);
                        }

                    }
                }

                if (e.Column.FieldName == "ColorNum")//ɫ�Ÿı䣬������ֵɫ��
                {
                    ColumnView view = sender as ColumnView;
                    string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                    string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                    view.SetRowCellValue(view.FocusedRowHandle, "ColorName", Common.GetItemColorNameByColorNum(ItemCode, ColorNum));

                }

                if (e.Column.FieldName == "SingPrice" || e.Column.FieldName == "Qty")
                {
                    ColumnView view = sender as ColumnView;
                    decimal singprice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "SingPrice"));
                    decimal qty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Qty"));
                    decimal Amount = SysConvert.ToDecimal(singprice * qty, 2);
                    view.SetRowCellValue(view.FocusedRowHandle, "Amount", Amount);

                }
                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5414)))//�޸��µ�����,���ۻ��߶������ʱ�Զ�������
                {
                    if (e.Column.FieldName == "InputQty" || e.Column.FieldName == "InputSinglePrice" || e.Column.FieldName == "FAmount1"
                        || e.Column.FieldName == "FAmount2" || e.Column.FieldName == "FAmount3" || e.Column.FieldName == "FAmount4" || e.Column.FieldName == "FAmount5")
                    {
                        ColumnView view = sender as ColumnView;
                        decimal InputQty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputQty"));
                        decimal InputSinglePrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputSinglePrice"));
                        decimal FAmount1 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount1"));
                        decimal FAmount2 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount2"));
                        decimal FAmount3 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount3"));
                        decimal FAmount4 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount4"));
                        decimal FAmount5 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "FAmount5"));
                        decimal Amount = InputQty * InputSinglePrice + FAmount1 + FAmount2 + FAmount3 + FAmount4 + FAmount5;
                        view.SetRowCellValue(view.FocusedRowHandle, "Amount", Amount);
                        view.SetRowCellValue(view.FocusedRowHandle, "InputAmount", Amount);

                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ��ͬ���ʽ
        /// <summary>
        /// ��ͬ���ʽ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateSaleOrderPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("�뱣���ͬ��ά�����ʽ");
                    return;
                }
                frmUpdateSaleOrderPay frm = new frmUpdateSaleOrderPay();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(380, 180);
                frm.ID = HTDataID;
                frm.FormNo = txtFormNo.Text.Trim();
                frm.Amount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
                frm.ShowDialog();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void txtQty_Leave_1(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));
                decimal OutRange = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OutRange"));
                if (OutRange > 0)
                {
                    decimal MaxQty = Qty * (1m + (OutRange / 100m));
                    decimal MinQty = Qty * (1m - (OutRange / 100m));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MaxQty", MaxQty);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MinQty", MinQty);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpVendorOPID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    drpVTel.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPID.EditValue));
                    drpVFax.Text = Common.GetVendorContactFAXByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPID.EditValue));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
                gridView1.FocusedRowHandle = 0;
                gridView1.FocusedColumn = gridView1.Columns["ItemCode"];
                gridView1.ShowEditor();
            }
        }













    }
}