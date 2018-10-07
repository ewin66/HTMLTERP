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
using HttSoft.MLTERP.Sys;
using HttSoft.MLTERP.DataCtl;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmLoadZZPlan :BaseForm
    {
        public frmLoadZZPlan()
        {
            InitializeComponent();
        }

        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private int m_HTID=0;
        public int HTID
        {
            get
            {
                return m_HTID;
            }
            set
            {
                m_HTID = value;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTID == 0)
                {
                    HTID=EntityAdd();
                }
                else
                {
                    EntityUpdate();
                }
                this.ShowInfoMessage("保存成功");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmLoadRSPlan_Load(object sender, EventArgs e)
        {
            Common.BindOrderType(drpOrderTypeID, true);
            Common.BindOrderLevel(drpOrderLevelID, true);
            Common.BindWLAmount(drpWLAmountType, true);
            Common.BindPayMethod(drpPayMothodFlag, true);
            Common.BindOPID(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.织厂 }, true);
            Common.BindCLS(txtSGReq, "WO_FabricProcess", "SGReq", true);    //手感要求
            Common.BindSOContext(drpSOContext,"织造", true);
            Common.BindCLS(drpPackMethod, "WO_FabricProcess", "PackMethod", true);
            Common.BindCLS(drpAfterFinish, "WO_FabricProcess", "AfterFinish", true);
            Common.BindCLS(drpGridCalUnit, "WO_FabricProcessDts", "CalUnit", true);
            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);

            Common.BindCLS(drpShipMethod, "WO_FabricProcess", "ShipMethod", true);//运输方式

            EntitySet();
            if (HTID == 0)
            {
                IniInsertSet();
            }
        }

        public  void IniInsertSet()
        {
          
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
            ParamSetRule psrule = new ParamSetRule();
            txtReqDate.DateTime = DateTime.Now.Date.AddDays(psrule.RShowIntByCode((int)ParamSetEnum.采购合同交期自动延后天数)).Date;
            drpPayMothodFlag.EditValue = Common.GetPayMethodByProcessType((int)EnumProcessType.织造加工单);
            GridDtsSet();
        }

        private void GridDtsSet()
        {
            string sql = "select ItemCode,ItemName,ItemStd,ItemModel,MWidth,MWeight from Data_Item WHERE 1=1";
            sql += " AND ItemCode IN (SELECT ISNULL(GreyFabItemCode,'') FROM Data_Item WHERE ItemCode IN (SELECT ItemCode FROM UV1_Sale_ProductionNoticeDts WHERE MainID=" + SysString.ToDBString(ID) + "))";
            sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,MWidth,MWeight";
            DataTable dt = SysUtils.Fill(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));

            }
        }


        public  void EntitySet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTID;
            bool findFlag = entity.SelectByID();
            txtFormNo.Text = entity.FormNo;
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtFormDate.DateTime = entity.FormDate.Date;
            drpVendorID.EditValue = entity.VendorID;
            drpOrderLevelID.EditValue = entity.OrderLevelID;
            drpOrderTypeID.EditValue = entity.OrderTypeID;
            txtReqDate.DateTime = entity.ReqDate;
            txtOrderDate.DateTime = entity.OrderDate;
            txtOrderFormNo.Text = entity.OrderFormNo;
            txtCustomerCode.Text = entity.CustomerCode.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtContractDesc.Text = entity.ContractDesc.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
         
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

            drpShipMethod.EditValue = entity.ShipMethod;

            if (!findFlag)
            {

            }

            BindGridDts();
           
        }


        public  void BindGridDts()
        {
            FabricProcessDtsRule rule = new FabricProcessDtsRule();
            DataTable dtDts = rule.RShowYS(" AND MainID=" + HTID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            Common.AddDtRow(dtDts, 100);
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }



        /// <summary>
        /// 新增
        /// </summary>
        public  int EntityAdd()
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
            entity.SubmitFlag = 1;
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public  void EntityUpdate()
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
            entity.SubmitFlag =1;
            rule.RUpdate(entity, entitydts);
        }


        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTID==0)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.染布加工单号);
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_FabricProcess", "FormNo", 2);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        private FabricProcess EntityGet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTID;
            entity.SelectByID();

            entity.ProductionID = ID;

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime;
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.OrderLevelID = SysConvert.ToInt32(drpOrderLevelID.EditValue);
            entity.OrderTypeID = SysConvert.ToInt32(drpOrderTypeID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.OrderFormNo = SysConvert.ToString(txtOrderFormNo.Text.Trim());   //销售合同号
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
            entity.ProcessTypeID = (int)EnumProcessType.织造加工单;

            entity.PackMethod = drpPackMethod.Text.ToString();
            entity.AfterFinish = drpAfterFinish.Text.ToString();

            entity.ShipMethod = SysConvert.ToString(drpShipMethod.EditValue);


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FabricProcessDts[] EntityDtsGet()
        {

            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
                {
                    index++;
                }
            }
            FabricProcessDts[] entitydts = new FabricProcessDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
                {
                    entitydts[index] = new FabricProcessDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTID;
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
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].Qty * entitydts[index].SingPrice;
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].CalNum = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CalNum"));
                    entitydts[index].CalUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "CalUnit"));
                    entitydts[index].DtsRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark"));
                    entitydts[index].DesignNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNo"));
                    entitydts[index].EditionOK = SysConvert.ToString(gridView1.GetRowCellValue(i, "EditionOK"));

                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
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
                    entitydts[index].PBWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PBWeight"));
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
                    index++;
                }
            }
            return entitydts;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoadProductionNotice frm = new frmLoadProductionNotice();
                frm.ID = ID;
                frm.ShowDialog();
                if (frm.StorgeID != null)
                {
                    int RowHandle = gridView1.FocusedRowHandle;
                    for (int i = 0; i < frm.StorgeID.Length; i++)
                    {
                        int LaodID = SysConvert.ToInt32(frm.StorgeID[i]);
                        string sql = "SELECT * FROM UV1_Sale_ProductionNoticeDts WHERE DtsID=" + SysString.ToDBString(LaodID);
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(RowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                            gridView1.SetRowCellValue(RowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                            gridView1.SetRowCellValue(RowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                            gridView1.SetRowCellValue(RowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                            gridView1.SetRowCellValue(RowHandle + i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                            gridView1.SetRowCellValue(RowHandle + i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                            gridView1.SetRowCellValue(RowHandle + i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                         
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                FabricProcessRule rule = new FabricProcessRule();
                FabricProcess entity = new FabricProcess();
                entity.ID = HTID;
                entity.SelectByID();
                rule.RDelete(entity);
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

      
       
      
       

       

      



     

     


        
        
     

       








    }
}