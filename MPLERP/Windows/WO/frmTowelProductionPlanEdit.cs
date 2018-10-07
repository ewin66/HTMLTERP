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

namespace MLTERP
{
    public partial class frmTowelProductionPlanEdit : frmAPBaseUIFormEdit
    {
        public frmTowelProductionPlanEdit()
        {
            InitializeComponent();
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

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return false;
            }


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
            TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " and SubSeq = 1  ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            TowelProductionPlan entity = EntityGet();
            TowelProductionPlanDts[] entitydts = EntityDtsGet();


            decimal TotalAmount = 0;
            decimal TotalQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalAmount += entitydts[i].Amount;
                TotalQty += entitydts[i].Qty;
            }
            entity.TotalAmount = TotalAmount;
            entity.TotalQty = TotalQty;


            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            TowelProductionPlan entity = EntityGet();
            TowelProductionPlanDts[] entitydts = EntityDtsGet();

            decimal TotalAmount = 0;
            decimal TotalQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalAmount += entitydts[i].Amount;
                TotalQty += entitydts[i].Qty;
            }
            entity.TotalAmount = TotalAmount;
            entity.TotalQty = TotalQty;

            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            TowelProductionPlan entity = new TowelProductionPlan();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            txtMakeOPID.Text = entity.MakeOPID.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            drpVendorID.EditValue = entity.VendorID.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtTotalQty.Text = entity.TotalQty.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtSpecialReq.Text = entity.SpecialReq.ToString();


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
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            TowelProductionPlan entity = EntityGet();
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
            base.IniInsertSet();

            txtMakeOPName.Text = FParamConfig.LoginName;
            txtMakeOPID.Text = FParamConfig.LoginID;
            txtFormDate.DateTime = DateTime.Now;
            txtMakeDate.DateTime = DateTime.Now;

            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_TowelProductionPlan";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.内销客户 }, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.业务部 }, true);


            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载订单", false, btnLoadSO_Click);

        }


        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadSO_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    //if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    //{
                    //    this.ShowMessage("请选择客户");
                    //    drpVendorID.Focus();
                    //    return;
                    //}

                    frmLoadOrder frm = new frmLoadOrder();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);

                    frm.NoLoadCondition = " and DtsID not in (select isnull(LoadDtsID,0) from WO_TowelProductionPlanDts )";
                    frm.CheckFlag = 1;

                    frm.ExtraCondition = " and ProductTypeID = 1";//加载毛巾订单

                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        //SetGridView1();// 防止一个采购单出现两个合同的数据
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
            int currentDataRowID = gridView1.FocusedRowHandle;
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    gridView1.SetRowCellValue(currentDataRowID + i, "DtsSO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));

                    gridView1.SetRowCellValue(currentDataRowID + i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["InputQty"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));

                    gridView1.SetRowCellValue(currentDataRowID + i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(currentDataRowID + i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));

                    txtSpecialReq.Text = SysConvert.ToString(dt.Rows[0]["SpecialReq"]);//特殊要求 -》包装要求

                    gridView1.SetRowCellValue(currentDataRowID + i, "LoadDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));

                }
            }
        }



        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private TowelProductionPlan EntityGet()
        {
            TowelProductionPlan entity = new TowelProductionPlan();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.MakeOPID = txtMakeOPID.Text.Trim();
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.SpecialReq = txtSpecialReq.Text.Trim();


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private TowelProductionPlanDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            TowelProductionPlanDts[] entitydts = new TowelProductionPlanDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new TowelProductionPlanDts();
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
                    entitydts[index].SubSeq = 1;//作为开卡的模板第一道

                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    //entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
                    entitydts[index].Amount = entitydts[index].Qty * entitydts[index].SinglePrice;
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));

                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));

                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].LoadDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadDtsID"));

                    entitydts[index].KBFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "KBFlag"));

                    entitydts[index].LLQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "LLQty"));
                    entitydts[index].LLUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "LLUnit"));


                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        /// <summary>
        /// 单号生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_TowelProductionPlan", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //entitydts[index].Amount = entitydts[index].Qty * entitydts[index].SinglePrice;
            try
            {
                if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)
                {
                    if (e.Column.FieldName == "Qty" || e.Column.FieldName == "SinglePrice")
                    {
                        decimal SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "SinglePrice"));
                        decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "Qty"));
                        decimal Amount = SinglePrice * Qty;
                        gridView1.SetRowCellValue(e.RowHandle, "Amount", Amount);

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 其它事件

        #endregion


    }
}