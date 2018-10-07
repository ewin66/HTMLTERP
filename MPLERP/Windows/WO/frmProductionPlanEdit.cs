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
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Base;

namespace MLTERP
{
    public partial class frmProductionPlanEdit : frmAPBaseUIFormEdit
    {
        public frmProductionPlanEdit()
        {
            InitializeComponent();
        }

        private int[] m_OrderID = new int[] { };
        public int[] OrderID
        {
            get
            {
                return m_OrderID;
            }
            set
            {
                m_OrderID = value;
            }
        }
     

       

       

        /// <summary>
        /// 未加载SQL条件语句
        /// </summary>
        private string m_NoLoadCondition = string.Empty;
        public string NoLoadCondition
        {
            get
            {
                return m_NoLoadCondition;
            }
            set
            {
                m_NoLoadCondition = value;
            }
        }

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}


            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            ProductionPlanDtsRule rule = new ProductionPlanDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();


            ProductionPlanDts2Rule rule2 = new ProductionPlanDts2Rule();
            DataTable dtDts2 = rule2.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));

            gridView2.GridControl.DataSource = dtDts2;
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ProductionPlanRule rule = new ProductionPlanRule();
            ProductionPlan entity = EntityGet();
            ProductionPlanDts[] entitydts = EntityDtsGet();
            ProductionPlanDts2[] entitydts2 = EntityDtsGet2();
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts, entitydts2);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ProductionPlanRule rule = new ProductionPlanRule();
            ProductionPlan entity = EntityGet();
            ProductionPlanDts[] entitydts = EntityDtsGet();
            ProductionPlanDts2[] entitydts2 = EntityDtsGet2();

            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entitydts2);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ProductionPlan entity = new ProductionPlan();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            txtOrderFormNo.Text = entity.OrderFormNo.ToString();
            txtOrderFormQty.Text = entity.OrderFormQty.ToString();
            txtPBItemCode.Text = entity.PBItemCode.ToString();
            txtPBItemName.Text = entity.PBItemName.ToString();
            txtPBItemStd.Text = entity.PBItemStd.ToString();
            txtPBItemModel.Text = entity.PBItemModel.ToString();
            drpFactoryID1.Text = entity.FactoryID1.ToString();
            txtPBMWeight.Text = entity.PBMWeight.ToString();
            txtCPItemCode.Text = entity.CPItemCode.ToString();
            txtCPDensity.Text = entity.CPDensity.ToString();
            txtCPMWidth.Text = entity.CPMWidth.ToString();
            txtCPMWeight.Text = entity.CPMWeight.ToString();
            drpFactoryID2.EditValue = entity.FactoryID2.ToString();
            txtLightSource.Text = entity.LightSource.ToString();
            txtPBReqDate.DateTime = entity.PBReqDate;
            txtTGReqDate.DateTime = entity.TGReqDate;
            txtCPReqDate.DateTime = entity.CPReqDate;
            txtMakeOPID.Text = entity.MakeOPID.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtCheckOPID.Text = entity.CheckOPID.ToString();
            txtCheckDate.DateTime = entity.CheckDate;

            txtPBMWidth.Text = entity.PBMWidth.ToString();
            txtCPItemName.Text = entity.CPItemName.ToString();
            txtCPItemModel.Text = entity.CPItemModel.ToString();
            txtCPItemStd.Text = entity.CPItemStd.ToString();
            drpGenDan.EditValue = entity.GenDan.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtRemark2.Text = entity.Remark2.ToString();

                 

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ProductionPlanRule rule = new ProductionPlanRule();
            ProductionPlan entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.Text = DateTime.Now.ToShortDateString();
            txtTGReqDate.Text = DateTime.Now.ToShortDateString();
            txtCheckDate.Text = DateTime.Now.ToShortDateString();
            txtMakeDate.Text = DateTime.Now.ToShortDateString();
            txtCPReqDate.Text = DateTime.Now.ToShortDateString();
            txtPBReqDate.Text = DateTime.Now.ToShortDateString();
            txtMakeOPID.Text = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_ProductionPlan";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemModel" };//数据明细校验必须录入字段

            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };
           // this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载大货指示样", false, btnSampleLoad_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载合同", false, btnSOLoad_Click);
            DevMethod.BindVendor(drpFactoryID1, new int[] { (int)EnumVendorType.织厂, (int)EnumVendorType.供应商 }, true);//织造加工厂，供应商
            DevMethod.BindVendor(drpFactoryID2, (int)EnumVendorType.染厂, true);//染厂
            Common.BindOP(drpGenDan, (int)EnumOPDep.生产部, true);
            Common.BindOP(drpSaleOPID, (int)EnumOPDep.业务部, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ProductionPlan EntityGet()
        {
            ProductionPlan entity = new ProductionPlan();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.OrderFormNo = txtOrderFormNo.Text.Trim();
            entity.OrderFormQty = txtOrderFormQty.Text.Trim();
            entity.PBItemCode = txtPBItemCode.Text.Trim();
            entity.PBItemName = txtPBItemName.Text.Trim();
            entity.PBItemStd = txtPBItemStd.Text.Trim();
            entity.PBItemModel = txtPBItemModel.Text.Trim();
            entity.FactoryID1 = drpFactoryID1.Text.Trim();
            entity.PBMWeight = txtPBMWeight.Text.Trim();
            entity.CPItemCode = txtCPItemCode.Text.Trim();
            entity.CPDensity = txtCPDensity.Text.Trim();
            entity.CPMWidth = txtCPMWidth.Text.Trim();
            entity.CPMWeight = txtCPMWeight.Text.Trim();
            entity.FactoryID2 = Convert.ToString(drpFactoryID2.EditValue);
            entity.LightSource = txtLightSource.Text.Trim();
            entity.PBReqDate = txtPBReqDate.DateTime.Date;
            entity.TGReqDate = txtTGReqDate.DateTime.Date;
            entity.CPReqDate = txtCPReqDate.DateTime.Date;
            entity.MakeOPID = txtMakeOPID.Text.Trim();
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.CheckOPID = txtCheckOPID.Text.Trim();
            entity.CheckDate = txtCheckDate.DateTime.Date;

            entity.PBMWidth = txtPBMWidth.Text.Trim();
            entity.CPItemName = txtCPItemName.Text.Trim();
            entity.CPItemModel = txtCPItemModel.Text.Trim();
            entity.CPItemStd = txtCPItemStd.Text.Trim();
            entity.GenDan =SysConvert.ToString(drpGenDan.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.Remark2 = txtRemark2.Text.Trim();


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ProductionPlanDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ProductionPlanDts[] entitydts = new ProductionPlanDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ProductionPlanDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].FormDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FormDate"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));


                    index++;
                }
            }
            return entitydts;
        }

        private ProductionPlanDts2[] EntityDtsGet2()
        {

            int index = 0;

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "WagonNo")) != string.Empty)
                {
                    index++;
                }
            }

            ProductionPlanDts2[] entitydts = new ProductionPlanDts2[index];
            index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "WagonNo")) != string.Empty)
                {
                    entitydts[index] = new ProductionPlanDts2();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "ID"));
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }
                    entitydts[index].WagonNo = SysConvert.ToString(gridView2.GetRowCellValue(i, "WagonNo"));
                    entitydts[index].PBFormDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "PBFormDate"));
                    entitydts[index].PBieceQty = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "PBieceQty"));
                    entitydts[index].PBQty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "PBQty"));
                    entitydts[index].CPFormDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "CPFormDate"));
                    entitydts[index].CPQty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "CPQty"));
                    entitydts[index].Shrinkage = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Shrinkage"));
                    entitydts[index].Remark = SysConvert.ToString(gridView2.GetRowCellValue(i, "Remark"));
                    entitydts[index].ZPQty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "ZPQty"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView2.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView2.GetRowCellValue(i, "MWeight"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorName"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].Batch = SysConvert.ToString(gridView2.GetRowCellValue(i, "Batch"));
                    entitydts[index].HuiXiu = SysConvert.ToString(gridView2.GetRowCellValue(i, "HuiXiu"));
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
                if (HTFormStatus == FormStatus.新增)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_ProductionPlan", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 其它事件
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSampleLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    frmLoadSample frm = new frmLoadSample();
                   
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {

                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
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

            string sql = "SELECT * FROM  UV1_Dev_Sample WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {

                txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["SO"]);//合同号 
                //txtCPItemCode.Text = SysConvert.ToString(dt.Rows[0]["CPItemCode"]);
                txtCPItemModel.Text = SysConvert.ToString(dt.Rows[0]["CPItemCode"]);
                txtCPItemName.Text = SysConvert.ToString(dt.Rows[0]["CPItemName"]);
                txtCPItemStd.Text = SysConvert.ToString(dt.Rows[0]["CPItemStd"]);
                txtCPDensity.Text = SysConvert.ToString(dt.Rows[0]["CPDensity"]);
                txtCPMWidth.Text = SysConvert.ToString(dt.Rows[0]["CPMWidth"]);
                txtCPMWeight.Text = SysConvert.ToString(dt.Rows[0]["CPMWeight"]);
                txtLightSource.Text = SysConvert.ToString(dt.Rows[0]["LightSource"]);//对色光源
                drpFactoryID2.EditValue = SysConvert.ToString(dt.Rows[0]["FactoryID3"]);//染厂

            }

        }
        /// <summary>
        /// 加载合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSOLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    frmLoadOrder frm = new frmLoadOrder();
                    frm.CheckFlag2 = 1;

                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {

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
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews2(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            txtRemark2.Text = "";
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);//合同号 
                    txtCPItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtCPItemModel.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                    txtCPItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                    txtCPItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                    txtCPDensity.Text = SysConvert.ToString(dt.Rows[0]["Needle"]);
                    txtCPMWidth.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                    txtCPMWeight.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);
                    txtRemark2.Text += SysConvert.ToString(dt.Rows[0]["ColorNum"]) + "," + SysConvert.ToString(dt.Rows[0]["ColorName"]) + "," + SysConvert.ToString(dt.Rows[0]["Qty"])+Environment.NewLine;

                }
            }

        }
        #endregion

        private void gridView2_CellValueChanged(object sender,CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "CPQty" || e.Column.FieldName == "PBQty")//坯布出库数，染色入库数触发计算缩率
                {
                    ColumnView view = sender as ColumnView;
                    decimal cpqty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "CPQty"));
                    decimal pbqty = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PBQty"));
                    decimal a = SysConvert.ToDecimal(cpqty/pbqty, 2);
                    decimal shrinkage = SysConvert.ToDecimal(1 - a, 2) * 100;
                    view.SetRowCellValue(view.FocusedRowHandle, "Shrinkage", shrinkage);
                }
               
              
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    }
}