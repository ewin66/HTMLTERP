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
    /// <summary>
    ///  ���ܣ�Ⱦ���ӹ���
    /// 
    /// 
    /// </summary>
    public partial class frmFabricProcessEdit : frmAPBaseUIFormEdit
    {
        public frmFabricProcessEdit()
        {
            InitializeComponent();
        }

        int LoadF = 0;//���ض��� ��һ��ֵ�е�û������  itemcode ֵ�ı� ��data_Item���ֵʱ���Ǹ��Ƶ�0�� �����LoadF���ж�

        int saveNoLoadCheckDayNum = 0;//δ���رȶ���������ֹ����ʱ�������ϵͳ����

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
                this.ShowMessage("������ӹ�����");
                txtFormNo.Focus();
                return false;
            }

            //if (SysConvert.ToString(drpVendorID.EditValue) == "")
            //{
            //    this.ShowMessage("��ѡ��Ӧ��");
            //    drpVendorID.Focus();
            //    return false;
            //}

            if (drpDyeFactorty.EditValue == string.Empty)
            {
                this.ShowMessage("��ѡ��ӹ���");
                drpDyeFactorty.Focus();
                return false;
            }

            if (!CheckCorrectDts())
            {
                return false;
            }

            if (!CheckCorrectDtsAttach())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// ������֤
        /// </summary>
        /// <returns></returns>
        public bool CheckCorrectDtsAttach()
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
            //    if (ItemCode != "")
            //    {
            //        string sql = "SELECT * FROM UV1_WO_FabricProcessDts WHERE OrderFormNo+ItemCode=" + SysString.ToDBString(txtOrderFormNo.Text.Trim() + ItemCode);
            //        DataTable dt = SysUtils.Fill(sql);
            //        if (dt.Rows.Count > 0)
            //        {
            //            if (MessageBox.Show("��ͬ��" + txtOrderFormNo.Text.Trim() + ",��Ʒ���룺" + ItemCode + "�ĺ�ͬ��Ⱦɫ����Ҫ�����ӹ���", "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //}
            return true;
        }

        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            FabricProcessDtsRule rule = new FabricProcessDtsRule();
            DataTable dtDts = rule.RShowYS(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();

        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FabricProcessRule rule = new FabricProcessRule();
            FabricProcess entity = EntityGet();
            FabricProcessDts[] entitydts = EntityDtsGet();
            decimal totalqty = 0;
            decimal totalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
                totalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FabricProcessRule rule = new FabricProcessRule();
            FabricProcess entity = EntityGet();
            FabricProcessDts[] entitydts = EntityDtsGet();
            decimal totalqty = 0;
            decimal totalAmount = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
                totalAmount += SysConvert.ToDecimal(entitydts[i].Amount);
            }
            entity.TotalQty = totalqty;
            entity.TotalAmount = totalAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo;
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtFormDate.DateTime = entity.FormDate.Date;
            drpVendorID.EditValue = entity.VendorID;
            drpOrderLevelID.EditValue = entity.OrderLevelID;
            txtOrderTypeName.Text = entity.OrderType;
            txtReqDate.DateTime = entity.ReqDate;
            txtOrderDate.DateTime = entity.OrderDate;
            txtOrderFormNo.Text = entity.OrderFormNo;
            txtCustomerCode.Text = entity.CustomerCode.ToString();
            //txtPayMethodID.Text = entity.PayMethodID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtContractDesc.Text = entity.ContractDesc.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            drpWLAmountType.EditValue = entity.WLAmountType;
            txtWLAmount.Text = entity.WLAmount.ToString();

            drpDyeFactorty.EditValue = entity.DyeFactorty.ToString();
            txtRSTec.Text = entity.DyeingTec.ToString();
            txtBuyerReq.Text = entity.DyeingReq.ToString();
            chkLightSource.Text = entity.LightSource.ToString();
            txtSGReq.Text = entity.SGReq.ToString();
            txtSendAddr.Text = entity.SendAddress.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            drpPackMethod.Text = entity.PackMethod;
            drpAfterFinish.Text = entity.AfterFinish;
            drpGenDan.EditValue = entity.GenDan.ToString();
            drpShipMethod.EditValue = entity.ShipMethod;
            drpLightSource.EditValue = entity.LightSource.ToString();
            drpLightSource2.EditValue = entity.LightSource2.ToString();
            drpLightSource3.EditValue = entity.LightSource3.ToString();
            drpPriceReportID.EditValue = entity.PriceReportID.ToString();
            if (!findFlag)
            {

            }

            BindGridDts();
            BindOrderInfo();
        }


        void BindOrderInfo()
        {
            //ucOrderInfo1.OrderTypeID = 2;
            //ucOrderInfo1.OrderNo = txtFormNo.Text.Trim();
            //ucOrderInfo1.IniData();
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FabricProcessRule rule = new FabricProcessRule();
            FabricProcess entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "WO_FabricProcess", "FormNo", 1, p_Flag);


            //  ProductCommon.JGButtonStatusSet(HTFormStatus, HTDataSubmitFlag, HTDataID, btnJGKL);//���ÿ��ϰ�ť״̬
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            // txtFormDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
            ParamSetRule psrule = new ParamSetRule();
            txtReqDate.DateTime = DateTime.Now.Date.AddDays(psrule.RShowIntByCode((int)ParamSetEnum.�ɹ���ͬ�����Զ��Ӻ�����)).Date;


            drpPayMothodFlag.EditValue = Common.GetPayMethodByProcessType((int)EnumProcessType.Ⱦ���ӹ���);
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_FabricProcess";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode", "Qty" };//������ϸУ�����¼���ֶ�
            //Common.BindOrderType(drpOrderTypeID, true);
            //Common.BindOrderLevel(drpOrderLevelID, true);
            //Common.BindWLAmount(drpWLAmountType, true);
            //Common.BindPayMethod(drpPayMothodFlag, true);
            //Common.BindOP(drpSaleOPID, (int)EnumOPDep.ҵ��, true);
            //Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);
            //Common.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.Ⱦ�� }, true);
            //drpDyeFactorty.Tag = (int)EnumVendorType.����;
            // new VendorProc(drpDyeFactorty);

            new PopContainerUtil(chkLightSource, Common.BindLightSource);   //��ɫ��Դ
            //Common.BindCLS(txtSGReq, "WO_FabricProcess", "SGReq", true);    //�ָ�Ҫ��
            //Common.BindSOContext(drpSOContext, true);
            //Common.BindEnumUnit(restxtunit, true);
            //Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
            saveNoLoadCheckDayNum = new ParamSetRule().RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
            // this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);   //���ز�Ʒ��Ϣ
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "���ض���", false, btnLoad_Click);    //�������۶���
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "���ز�Ʒ", false, btnDevItemLoad_Click);
            //this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "�ӹ�����", false, btnBuckleMaterial_Click);

            // ProductCommon.JGButtonIni(btnJGKL, (int)EnumSaleProcedure.Ⱦ���ӹ���);//��ʼ�����ϰ�ť

            Common.BindVendor(drpDVendorID, (int)EnumVendorType.�ͻ�, true);
        }


        public override void IniFormLoadBehind()
        {
            gridView1.Columns["BoxQty"].Visible = false;
            gridView1.Columns["SetQty"].Visible = false;
            gridView1.Columns["DozensQty"].Visible = false;
        }


        /// <summary>
        /// ��ʼ��ˢ������(�������ʱ���û�ˢ�°�ťʱ����)
        /// </summary>
        public override void IniRefreshData()
        {
            // Common.BindOrderType(drpOrderTypeID, true);
            Common.BindOrderLevel(drpOrderLevelID, true);
            Common.BindOP(drpPriceReportID, true);//��ʱ��������
            Common.BindWLAmount(drpWLAmountType, true);
            Common.BindPayMethod(drpPayMothodFlag, true);
            //Common.BindOP(drpSaleOPID, (int)EnumOPDep.ҵ��, true);
           
            //Common.BindOP(drpGenDan, (int)EnumOPDep.������, true);
            Common.BindGenDan(drpGenDan, true);//�󶨸���Ա 

            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//��֯�ṹ��ϵ����
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }
            DevMethod.BindItem(drpItemCode, true);
            DevMethod.BindItemPB(drpCPItemCode, true);
            DevMethod.BindItemBCP(drpBCPItemCode, true);

            //new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[4] { "BCPItemCode", "BCPItemName", "BCPItemStd", "BCPItemModel" }, drpBCPItemCode, txtBCPItemName, new int[] { (int)EnumItemType.���Ʒ }, "", "BCPItemStd", true, true);

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            DevMethod.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�����ӹ��� }, true);
            Common.BindCLS(txtSGReq, "WO_FabricProcess", "SGReq", true);    //�ָ�Ҫ��
            Common.BindSOContext(drpSOContext, "Ⱦɫ", true);
            Common.BindCLS(drpPackMethod, "WO_FabricProcess", "PackMethod", true);
            Common.BindCLS(drpAfterFinish, "WO_FabricProcess", "AfterFinish", true);
            Common.BindCLS(drpGridCalUnit, "WO_FabricProcessDts", "CalUnit", true);
            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);

            Common.BindCLS(drpShipMethod, "WO_FabricProcess", "ShipMethod", true);//���䷽ʽ

            Common.BindCLS(drpDtsPackMethod, "WO_FabricProcess", "PackMethod", true);
            Common.BindCLS(drpDtsAfterFinish, "WO_FabricProcess", "AfterFinish", true);



        }

        private void gridViewRowChanged1(object sender)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;


                BindGridColor();
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

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FabricProcess EntityGet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime;
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.OrderLevelID = SysConvert.ToInt32(drpOrderLevelID.EditValue);
            entity.OrderType = txtOrderTypeName.Text.Trim();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.OrderFormNo = SysConvert.ToString(txtOrderFormNo.Text.Trim());   //���ۺ�ͬ��
            //entity.OrderDate = txtOrderDate.DateTime;
            entity.ReqDate = txtReqDate.DateTime;
            //entity.PayMethodID = txtPayMethodID.Text.Trim();
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.ContractDesc = txtContractDesc.Text.Trim();
            entity.CustomerCode = txtCustomerCode.Text.Trim();
            entity.PayMethodID = SysConvert.ToString(drpPayMothodFlag.EditValue);
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.WLAmountType = SysConvert.ToInt32(drpWLAmountType.EditValue);
            entity.WLAmount = SysConvert.ToDecimal(txtWLAmount.Text.Trim());

            entity.DyeFactorty = drpDyeFactorty.EditValue.ToString();
            entity.DyeingTec = txtRSTec.Text.Trim();
            entity.DyeingReq = txtBuyerReq.Text.Trim();
            entity.LightSource = chkLightSource.Text.Trim();
            entity.SGReq = txtSGReq.Text.Trim();
            entity.SendAddress = txtSendAddr.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.ProcessTypeID = (int)EnumProcessType.Ⱦ���ӹ���;
            entity.GenDan = SysConvert.ToString(drpGenDan.EditValue);
            entity.PackMethod = drpPackMethod.Text.ToString();
            entity.AfterFinish = drpAfterFinish.Text.ToString();
            entity.LightSource = SysConvert.ToString(drpLightSource.EditValue);
            entity.LightSource2 = SysConvert.ToString(drpLightSource2.EditValue);
            entity.LightSource3 = SysConvert.ToString(drpLightSource3.EditValue);
            entity.ShipMethod = SysConvert.ToString(drpShipMethod.EditValue);
            entity.PriceReportID = SysConvert.ToString(drpPriceReportID.EditValue);

            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FabricProcessDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            FabricProcessDts[] entitydts = new FabricProcessDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new FabricProcessDts();
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
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));

                    entitydts[index].PieceWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PieceWeight"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    //entitydts[index].PBWeight = entitydts[index].PieceWeight * entitydts[index].PieceQty;
                    entitydts[index].PBWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PBWeight"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));


                    entitydts[index].BoxQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "BoxQty"));
                    entitydts[index].SetQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SetQty"));
                    entitydts[index].DozensQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DozensQty")); 

                    entitydts[index].BCPColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPColorNum"));
                    entitydts[index].BCPColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPColorName"));
                    entitydts[index].BCPMWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPMWidth"));
                    entitydts[index].BCPMWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPMWeight"));

                    entitydts[index].OrderQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "OrderQty"));
                    entitydts[index].OrderUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "OrderUnit"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].Qty * entitydts[index].SingPrice;
                    //entitydts[index].ReceivedDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "ReceivedDate")); 
                    //entitydts[index].ReceivedQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ReceivedQty")); 
                    //entitydts[index].TotalRecQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalRecQty")); 
                    //entitydts[index].RemainQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RemainQty")); 
                    //entitydts[index].RemainRate = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RemainRate")); 
                    //entitydts[index].OrderPreStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "OrderPreStatusID")); 
                    //entitydts[index].OrderStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "OrderStatusID"));
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].CalNum = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CalNum"));
                    entitydts[index].CalUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "CalUnit"));
                    entitydts[index].DtsRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark"));
                    entitydts[index].DesignNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNo"));
                    entitydts[index].EditionOK = SysConvert.ToString(gridView1.GetRowCellValue(i, "EditionOK"));

                    entitydts[index].StyleNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "StyleNo"));//���


                    entitydts[index].FreeStr1 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr1"));
                    entitydts[index].FreeStr2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr2"));
                    entitydts[index].FreeStr3 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr3"));
                    entitydts[index].FreeStr4 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr4"));
                    entitydts[index].FreeStr5 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr5"));
                    entitydts[index].CPItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemCode"));
                    entitydts[index].CPItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemName"));
                    entitydts[index].CPItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemStd"));
                    entitydts[index].CPItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemModel"));
                    entitydts[index].SL = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SL"));

                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].DtsAfterFinish = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsAfterFinish"));
                    entitydts[index].AllMWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "AllMWidth"));//�ƺ�MwidthΪȫ����AllMWidthΪ��Ч�ŷ�
                    entitydts[index].DtsPackMethod = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsPackMethod"));

                    entitydts[index].BCPItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPItemCode"));
                    entitydts[index].BCPItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPItemStd"));
                    entitydts[index].BCPItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPItemName"));
                    entitydts[index].BCPItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "BCPItemModel"));

                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region ���غ�ͬ
        /// <summary>
        /// ˫�����ɲɹ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.Ⱦ���ӹ�����);
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_FabricProcess", "FormNo", 1);
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
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadOrder frm = new frmLoadOrder();
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(702)))//Ⱦ���ӹ���֧�ּ��ضඩ��
                    {
                        frm.Double = true;
                    }
                    string sql = string.Empty;
                    sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(OrderFormNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_WO_FabricProcessDts";
                    if (saveNoLoadCheckDayNum != 0)
                    {
                        sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                    }

                    sql += " and ProcessTypeID =" + (int)EnumProcessType.Ⱦ���ӹ��� + " )";//Ⱦ��
                    //sql += ")";
                    frm.NoLoadCondition = sql;
                    frm.CheckFlag = 1;

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
                        setItemNews(str);
                        LoadF = 0;
                        gridViewRowChanged1(gridView1);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        ///// <summary>
        ///// ��ֹһ���ɹ�������������ͬ������
        ///// </summary>
        //private void SetGridView1()
        //{
        //    string sql = "SELECT * FROM Buy_ItemBuyFormDts WHERE 1=0";
        //    DataTable dt = SysUtils.Fill(sql);
        //    Common.AddDtRow(dt, 100);
        //    gridView1.GridControl.DataSource =dt;
        //    gridView1.GridControl.Show();
        //}

        private void setItemNews(string p_Str)
        {
            LoadF = 1;
            this.BaseFocusLabel.Focus();
            string[] orderid = p_Str.Split(',');
            int currentDataRowID = gridView1.FocusedRowHandle;
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    int ProductTypeID = SysConvert.ToInt32(dt.Rows[0]["ProductTypeID"]);//1ë��  2����
                    if (ProductTypeID == 1)
                    {
                        gridView1.Columns["BoxQty"].Visible = true;
                        gridView1.Columns["BoxQty"].VisibleIndex = 11;
                        gridView1.Columns["SetQty"].Visible = true;
                        gridView1.Columns["SetQty"].VisibleIndex = 12;
                        gridView1.Columns["DozensQty"].Visible = true;
                        gridView1.Columns["DozensQty"].VisibleIndex = 13;

                        gridView1.SetRowCellValue(currentDataRowID, "BoxQty", SysConvert.ToInt32(dt.Rows[0]["BoxQty"]));
                        gridView1.SetRowCellValue(currentDataRowID, "SetQty", SysConvert.ToInt32(dt.Rows[0]["SetQty"]));
                        gridView1.SetRowCellValue(currentDataRowID, "DozensQty", SysConvert.ToInt32(dt.Rows[0]["DozensQty"]));
                    }
                    else
                    {

                        gridView1.Columns["BoxQty"].Visible = false;
                        gridView1.Columns["SetQty"].Visible = false;
                        gridView1.Columns["DozensQty"].Visible = false;
                    }



                    string MWeight = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                    string ItemStd = SysConvert.ToString(dt.Rows[0]["ItemStd"]);


                    gridView1.SetRowCellValue(currentDataRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));

                    // gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(currentDataRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(currentDataRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(currentDataRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(currentDataRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(currentDataRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(currentDataRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(currentDataRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(currentDataRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(currentDataRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(currentDataRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(currentDataRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(currentDataRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));
                    gridView1.SetRowCellValue(currentDataRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(currentDataRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                    gridView1.SetRowCellValue(currentDataRowID, "AllMWidth", SysConvert.ToDecimal(dt.Rows[0]["AllMWidth"]));


                    string Unit = SysConvert.ToString(dt.Rows[0]["Unit"]);
                    if (Unit.Contains("/KG"))
                    {
                        //gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                        gridView1.SetRowCellValue(currentDataRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else if (Unit.Contains("/M"))
                    {
                        //gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                        gridView1.SetRowCellValue(currentDataRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }
                    else if (Unit.Contains("/Y"))
                    {
                        //gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Yard"]));
                        gridView1.SetRowCellValue(currentDataRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Yard"]));
                    }
                    else if (Unit.Contains("/PC"))
                    {
                        //gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                        gridView1.SetRowCellValue(currentDataRowID, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                    }

                    //gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    //gridView1.SetRowCellValue(currentDataRowID + i, "OrderQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));


                    gridView1.SetRowCellValue(currentDataRowID, "OrderUnit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);

                    txtReqDate.DateTime = SysConvert.ToDateTime(dt.Rows[0]["DtsReqDate"]);

                    drpOrderLevelID.EditValue = SysConvert.ToInt32(dt.Rows[0]["OrderLevelID"]);
                    txtOrderTypeName.Text = SysConvert.ToString(dt.Rows[0]["OrderTypeName"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);


                    //��ʼ�������������������λ�ĸ�ֵ
                    string o_UnitQtyName = "";
                    decimal o_PerMiQty = 0;
                    Common.GetCalUnitAndPerMiQty(SysConvert.ToString(dt.Rows[0]["ItemCode"]), out o_UnitQtyName, out o_PerMiQty);
                    gridView1.SetRowCellValue(currentDataRowID, "CalNum", o_PerMiQty.ToString());
                    gridView1.SetRowCellValue(currentDataRowID, "CalUnit", o_UnitQtyName.ToString());




                    sql = "Select SH from Sale_SaleOrderFabric where MainID=" + SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    sql += " AND CPItemCode=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    DataTable dtSH = SysUtils.Fill(sql);
                    if (dtSH.Rows.Count != 0)
                    {
                        gridView1.SetRowCellValue(currentDataRowID, "SL", SysConvert.ToDecimal(dtSH.Rows[0]["SH"]));
                    }


                    //gridView1.SetRowCellValue(currentDataRowID + i, "SH", o_UnitQtyName.ToString());


                    //if (i == 0)
                    //{
                    //    sql = "SELECT VendorID FROM Data_Item WHERE ItemCode="+SysString.ToDBString( SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //    dt = SysUtils.Fill(sql);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0][0]);
                    //    } 
                    //}

                    currentDataRowID++;

                }

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
                //return;
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

                FabricProcessRule rule = new FabricProcessRule();
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

                FabricProcessRule rule = new FabricProcessRule();
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

        #region ���ز�Ʒ��Ϣ
        /// <summary>
        /// ���ز�Ʒ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnDevItemLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadFabric frm = new frmLoadFabric();
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
                        setItemFabricNews(str);
                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void setItemFabricNews(string p_Str)
        {
            string[] gbid = p_Str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    //gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));



                }
            }
        }
        #endregion


        #region �ӹ�����
        /// <summary>
        /// ���ؼӹ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnJGKL_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HTFormStatus == FormStatus.��ѯ && HTDataSubmitFlag == 1)
        //        {
        //            ProductCommon.JGOpenKLForm((int)EnumSaleProcedure.Ⱦ���ӹ���, HTDataID, HTDataFormNo);
        //            ProductCommon.JGButtonStatusSet(HTFormStatus, HTDataSubmitFlag, HTDataID, btnJGKL);//���ÿ��ϰ�ť״̬               
        //        }
        //        else
        //        {
        //            this.ShowMessage("���ڲ�ѯ�ύ״̬�²���");
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        #endregion


        #region �����¼�
        /// <summary>
        /// ֵ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {

                    if (e.Column.FieldName == "ItemCode" && LoadF == 0)//
                    {
                        this.BaseFocusLabel.Focus();
                        ColumnView view = sender as ColumnView;
                        string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                        string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 1)
                        {
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemName", dt.Rows[0]["ItemName"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemStd", dt.Rows[0]["ItemStd"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "ItemModel", dt.Rows[0]["ItemModel"]);
                            //view.SetRowCellValue(view.FocusedRowHandle, "Unit", dt.Rows[0]["ItemUnit"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "Needle", dt.Rows[0]["Needle"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWidth", dt.Rows[0]["MWidth"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWeight", dt.Rows[0]["MWeight"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"]);
                        }

                        SetGridValue();
                    }
                    if (e.Column.FieldName == "CPItemCode")
                    {
                        ColumnView view = sender as ColumnView;
                        string CPItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "CPItemCode"));
                        string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(CPItemCode);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 1)
                        {
                            view.SetRowCellValue(e.RowHandle, "CPItemModel", dt.Rows[0]["ItemModel"]);
                            view.SetRowCellValue(e.RowHandle, "CPItemName", dt.Rows[0]["ItemName"]);
                            view.SetRowCellValue(e.RowHandle, "CPItemStd", dt.Rows[0]["ItemStd"]);
                        }
                    }
                    if (e.Column.FieldName == "BCPItemCode")
                    {
                        ColumnView view = sender as ColumnView;
                        string BCPItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "BCPItemCode"));
                        string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(BCPItemCode);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 1)
                        {
                            view.SetRowCellValue(e.RowHandle, "BCPItemModel", dt.Rows[0]["ItemModel"]);
                            view.SetRowCellValue(e.RowHandle, "BCPItemStd", dt.Rows[0]["ItemStd"]);
                            view.SetRowCellValue(e.RowHandle, "BCPItemName", dt.Rows[0]["ItemModel"]);
                        }
                    }

                    if (e.Column.FieldName == "ColorNum")//ɫ����ֵ�ı�
                    {
                        if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5820)))//Ⱦ���ӹ�������ʱ����Ⱦ��ɫ�Ŷ�ȡɫ�������Ⱦ��ɫ��
                        {
                            string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ItemCode"));
                            string colorNum = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ColorNum"));
                            string desingNo = Common.GetDesignNoByItemAndColorNum(itemCode, colorNum);
                            if (desingNo != string.Empty)
                            {
                                gridView1.SetRowCellValue(e.RowHandle, "DesignNo", desingNo);
                            }

                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ColorName", Common.GetItemColorNameByColorNum(itemCode, colorNum));
                        }
                    }

                    if (e.Column.FieldName == "SL" || e.Column.FieldName == "Qty")//�������ʺͳ�Ʒ����������������
                    {
                        decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "Qty"));
                        decimal SL = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "SL"));
                        decimal PBWeight = Qty * (1 + SysConvert.ToDecimal(SL / 100, 2));
                        //gridView1.SetRowCellValue(e.RowHandle, "PBWeight", PBWeight);

                    }

                    if (e.Column.FieldName == "PieceWeight" || e.Column.FieldName == "PieceQty")
                    {
                        ColumnView view = sender as ColumnView;
                        decimal PieceWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "PieceWeight"));
                        decimal PieceQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "PieceQty"));
                        decimal PBWeight = PieceWeight * PieceQty;
                        view.SetRowCellValue(e.RowHandle, "PBWeight", PBWeight);
                    }

                    if (e.RowHandle == 0)
                    {
                        if (e.Column.FieldName == "BCPItemCode" || e.Column.FieldName == "BCPMWidth" || e.Column.FieldName == "BCPMWeight" || e.Column.FieldName == "PieceWeight" || e.Column.FieldName == "CPItemCode" || e.Column.FieldName == "FreeStr1" || e.Column.FieldName == "Unit")
                        {
                            SetGridValue();
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
        /// //���Ʒ���롢Ʒ�������Ʒ�ŷ������أ���λ��ƥ�أ��������롢Ʒ����֯����ϸ ����λ ����ÿ�е���Ϣ���ݵ�һ���Զ��������������һ����Ϣ���ɣ� 20160823
        /// </summary>
        private void SetGridValue()
        {
            string BCPItemCode = SysConvert.ToString(gridView1.GetRowCellValue(0, "BCPItemCode"));
            string BCPMWidth = SysConvert.ToString(gridView1.GetRowCellValue(0, "BCPMWidth"));
            string BCPMWeight = SysConvert.ToString(gridView1.GetRowCellValue(0, "BCPMWeight"));
            decimal PieceWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(0, "PieceWeight"));
            string CPItemCode = SysConvert.ToString(gridView1.GetRowCellValue(0, "CPItemCode"));//��������
            string FreeStr1 = SysConvert.ToString(gridView1.GetRowCellValue(0, "FreeStr1"));//֯����ϸ
            string Unit = SysConvert.ToString(gridView1.GetRowCellValue(0, "Unit"));//��λ
            for (int i = 1; i < gridView1.RowCount; i++)
            {
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                if (ItemCode != "")
                {
                    gridView1.SetRowCellValue(i, "BCPItemCode", BCPItemCode);
                    gridView1.SetRowCellValue(i, "BCPMWidth", BCPMWidth);
                    gridView1.SetRowCellValue(i, "BCPMWeight", BCPMWeight);
                    gridView1.SetRowCellValue(i, "PieceWeight", PieceWeight);
                    gridView1.SetRowCellValue(i, "CPItemCode", CPItemCode);
                    gridView1.SetRowCellValue(i, "FreeStr1", FreeStr1);
                    gridView1.SetRowCellValue(i, "Unit", Unit);
                }
            }
        }

        #endregion






    }
}