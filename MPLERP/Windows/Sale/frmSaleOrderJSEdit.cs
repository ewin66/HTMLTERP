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
    public partial class frmSaleOrderJSEdit : frmAPBaseUIFormEdit
    {
        public frmSaleOrderJSEdit()
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
            SaleOrderJSDtsRule rule = new SaleOrderJSDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " AND CBSourceTypeID = 3" + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));//销售
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();

            DataTable dtDts2 = rule.RShow(" AND MainID=" + HTDataID + " AND CBSourceTypeID = 1" + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));//采购
            gridView2.GridControl.DataSource = dtDts2;
            gridView2.GridControl.Show();

            DataTable dtDts3 = rule.RShow(" AND MainID=" + HTDataID + " AND CBSourceTypeID = 2" + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3));//加工
            gridView3.GridControl.DataSource = dtDts3;
            gridView3.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            SaleOrderJSRule rule = new SaleOrderJSRule();
            SaleOrderJS entity = EntityGet();
            SaleOrderJSDts[] entitydts = EntityDtsGet();
            SaleOrderJSDts[] entitydts2 = EntityDtsGet2();
            SaleOrderJSDts[] entitydts3 = EntityDtsGet3();

            #region 计算
            decimal OrderAmount = 0;
            decimal CGAmount = 0;
            decimal RSAmount = 0;

            for (int i = 0; i < entitydts.Length; i++)
            {
                OrderAmount += entitydts[i].Amount;
            }

            for (int i = 0; i < entitydts2.Length; i++)
            {
                CGAmount += entitydts2[i].Amount;
            }

            for (int i = 0; i < entitydts3.Length; i++)
            {
                RSAmount += entitydts3[i].Amount;
            }

            //for (int i = 0; i < entitydts4.Length; i++)
            //{
            //    ZZAmount += entitydts4[i].Amount;
            //}

            //for (int i = 0; i < entitydts5.Length; i++)
            //{
            //    RZAmount += entitydts5[i].Amount;
            //}

            //for (int i = 0; i < entitydts6.Length; i++)
            //{
            //    OtherAmount += entitydts6[i].Amount;
            //}

            entity.OrderAmount = OrderAmount;
            entity.CGAmount = CGAmount;
            entity.RSAmount = RSAmount;
            entity.CBAmount = CGAmount + RSAmount + entity.YSAmount + entity.HKAmount + entity.OtherAmount;
            entity.LRAmount = OrderAmount - entity.CBAmount;
            if (entity.OrderAmount != 0)
            {
                entity.LRPer = entity.LRAmount * 100m / entity.OrderAmount;
            }
            //int RowIndex = 0;
            //if (entitydts.Length > RowIndex)
            //{
            //    RowIndex = entitydts.Length;
            //}
            //if (entitydts2.Length > RowIndex)
            //{
            //    RowIndex = entitydts2.Length;
            //}
            //if (entitydts3.Length > RowIndex)
            //{
            //    RowIndex = entitydts3.Length;
            //}
            //if (entitydts4.Length > RowIndex)
            //{
            //    RowIndex = entitydts4.Length;
            //}
            //if (entitydts5.Length > RowIndex)
            //{
            //    RowIndex = entitydts5.Length;
            //}
            //if (entitydts6.Length > RowIndex)
            //{
            //    RowIndex = entitydts6.Length;
            //}

            //entity.RowIndex = RowIndex;
            #endregion

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts, entitydts2, entitydts3);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SaleOrderJSRule rule = new SaleOrderJSRule();
            SaleOrderJS entity = EntityGet();
            SaleOrderJSDts[] entitydts = EntityDtsGet();
            SaleOrderJSDts[] entitydts2 = EntityDtsGet2();
            SaleOrderJSDts[] entitydts3 = EntityDtsGet3();

            #region 计算
            decimal OrderAmount = 0;
            decimal CGAmount = 0;
            decimal RSAmount = 0;

            for (int i = 0; i < entitydts.Length; i++)
            {
                OrderAmount += entitydts[i].Amount;
            }

            for (int i = 0; i < entitydts2.Length; i++)
            {
                CGAmount += entitydts2[i].Amount;
            }

            for (int i = 0; i < entitydts3.Length; i++)
            {
                RSAmount += entitydts3[i].Amount;
            }

            //for (int i = 0; i < entitydts4.Length; i++)
            //{
            //    ZZAmount += entitydts4[i].Amount;
            //}

            //for (int i = 0; i < entitydts5.Length; i++)
            //{
            //    RZAmount += entitydts5[i].Amount;
            //}

            //for (int i = 0; i < entitydts6.Length; i++)
            //{
            //    OtherAmount += entitydts6[i].Amount;
            //}

            entity.OrderAmount = OrderAmount;
            entity.CGAmount = CGAmount;
            entity.RSAmount = RSAmount;
            entity.CBAmount = CGAmount + RSAmount + entity.YSAmount + entity.HKAmount + entity.OtherAmount;
            entity.LRAmount = OrderAmount - entity.CBAmount;
            if (entity.OrderAmount != 0m)
            {
                entity.LRPer = entity.LRAmount * 100m / entity.OrderAmount;
            }
            int RowIndex = 0;
            if (entitydts.Length > RowIndex)
            {
                RowIndex = entitydts.Length;
            }
            //if (entitydts2.Length > RowIndex)
            //{
            //    RowIndex = entitydts2.Length;
            //}
            //if (entitydts3.Length > RowIndex)
            //{
            //    RowIndex = entitydts3.Length;
            //}
            //if (entitydts4.Length > RowIndex)
            //{
            //    RowIndex = entitydts4.Length;
            //}
            //if (entitydts5.Length > RowIndex)
            //{
            //    RowIndex = entitydts5.Length;
            //}
            //if (entitydts6.Length > RowIndex)
            //{
            //    RowIndex = entitydts6.Length;
            //}

            //entity.RowIndex = RowIndex;
            #endregion

            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entitydts2, entitydts3);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SaleOrderJS entity = new SaleOrderJS();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeOPID.Text = entity.MakeOPID.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtSO.Text = entity.SO.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtOrderAmount.Text = entity.OrderAmount.ToString();
            txtCGAmount.Text = entity.CGAmount.ToString();
            txtRSAmount.Text = entity.RSAmount.ToString();
            txtZZAmount.Text = entity.ZZAmount.ToString();
            txtRZAmount.Text = entity.RZAmount.ToString();
            txtOtherAmount.Text = entity.OtherAmount.ToString();
            txtHKAmount.Text = entity.HKAmount.ToString();
            txtYSAmount.Text = entity.YSAmount.ToString();
            txtLRAmount.Text = entity.LRAmount.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtCBAmount.Text = entity.CBAmount.ToString();
            txtLRPer.Text = entity.LRPer.ToString();
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
            SaleOrderJSRule rule = new SaleOrderJSRule();
            SaleOrderJS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtFormNo }, false);
            ProcessCtl.ProcControlEdit(new Control[] { txtSO }, false);

        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrderJS";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2, gridView3 };
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);

            Common.BindOP(drpSaleOPID, true);

            Common.BindVendor(drpLVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindVendor(drpLVendorID2, new int[] { (int)EnumVendorType.供应商 }, true);
            Common.BindVendor(drpLVendorID3, new int[] { (int)EnumVendorType.织厂, (int)EnumVendorType.染厂, (int)EnumVendorType.工厂, (int)EnumVendorType.加工户 }, true);


            this.ToolBarItemAdd(28, "btnLoad", "加载", false, btnLoad_Click);


        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrderJS EntityGet()
        {
            SaleOrderJS entity = new SaleOrderJS();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = txtMakeOPID.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.SO = txtSO.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.OrderAmount = SysConvert.ToDecimal(txtOrderAmount.Text.Trim());
            entity.CGAmount = SysConvert.ToDecimal(txtCGAmount.Text.Trim());
            entity.RSAmount = SysConvert.ToDecimal(txtRSAmount.Text.Trim());
            entity.ZZAmount = SysConvert.ToDecimal(txtZZAmount.Text.Trim());
            entity.RZAmount = SysConvert.ToDecimal(txtRZAmount.Text.Trim());
            entity.OtherAmount = SysConvert.ToDecimal(txtOtherAmount.Text.Trim());
            entity.HKAmount = SysConvert.ToDecimal(txtHKAmount.Text.Trim());
            entity.YSAmount = SysConvert.ToDecimal(txtYSAmount.Text.Trim());

            entity.LRAmount = SysConvert.ToDecimal(txtLRAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrderJSDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            SaleOrderJSDts[] entitydts = new SaleOrderJSDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new SaleOrderJSDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        //entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].SO = txtSO.Text.Trim();
                    entitydts[index].OrderDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "OrderDate"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].TotalRecQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalRecQty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].SingPrice * entitydts[index].Qty;
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));

                    entitydts[index].FHDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FHDate"));
                    entitydts[index].KPDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "KPDate"));
                    entitydts[index].FormDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FormDate"));
                    entitydts[index].FormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "FormNo"));
                    entitydts[index].SubType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SubType"));
                    entitydts[index].CBSourceTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CBSourceTypeID"));

                    index++;
                }
            }
            return entitydts;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrderJSDts[] EntityDtsGet2()
        {

            int index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty")) > 0)
                {
                    index++;
                }
            }
            SaleOrderJSDts[] entitydts = new SaleOrderJSDts[index];
            index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty")) > 0)
                {
                    entitydts[index] = new SaleOrderJSDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        //entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].SO = txtSO.Text.Trim();
                    entitydts[index].OrderDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "OrderDate"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView2.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView2.GetRowCellValue(i, "ColorName"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                    entitydts[index].TotalRecQty = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "TotalRecQty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView2.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].SingPrice * entitydts[index].Qty;
                    entitydts[index].Remark = SysConvert.ToString(gridView2.GetRowCellValue(i, "Remark"));

                    entitydts[index].FHDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "FHDate"));
                    entitydts[index].KPDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "KPDate"));
                    entitydts[index].FormDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "FormDate"));
                    entitydts[index].FormNo = SysConvert.ToString(gridView2.GetRowCellValue(i, "FormNo"));
                    entitydts[index].SubType = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "SubType"));
                    entitydts[index].CBSourceTypeID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "CBSourceTypeID"));

                    index++;
                }
            }
            return entitydts;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrderJSDts[] EntityDtsGet3()
        {

            int index = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Qty")) > 0)
                {
                    index++;
                }
            }
            SaleOrderJSDts[] entitydts = new SaleOrderJSDts[index];
            index = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Qty")) > 0)
                {
                    entitydts[index] = new SaleOrderJSDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        //entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].SO = txtSO.Text.Trim();
                    entitydts[index].OrderDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "OrderDate"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView3.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "Qty"));
                    entitydts[index].TotalRecQty = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "TotalRecQty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView3.GetRowCellValue(i, "Unit"));
                    entitydts[index].SingPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "SingPrice"));
                    entitydts[index].Amount = entitydts[index].SingPrice * entitydts[index].Qty;
                    entitydts[index].Remark = SysConvert.ToString(gridView3.GetRowCellValue(i, "Remark"));

                    entitydts[index].FHDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "FHDate"));
                    entitydts[index].KPDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "KPDate"));
                    entitydts[index].FormDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "FormDate"));
                    entitydts[index].FormNo = SysConvert.ToString(gridView3.GetRowCellValue(i, "FormNo"));
                    entitydts[index].SubType = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "SubType"));
                    entitydts[index].CBSourceTypeID = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "CBSourceTypeID"));

                    index++;
                }
            }
            return entitydts;
        }


        #endregion

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.订单结算单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 其它事件

        #endregion

        #region 加载

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (txtSO.Text.Trim() == "")
                    {
                        this.ShowMessage("清输入订单号");
                        txtSO.Focus();
                        return;
                    }

                    #region 销售
                    //1.销售合计---取销售出库的数据
                    string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsOrderFormNo =" + SysString.ToDBString(txtSO.Text.Trim());
                    sql += " AND FormDZType = 3";//销售
                    sql += " AND SubmitFlag>0";
                    DataTable dt = SysUtils.Fill(sql);



                    for (int i = gridView1.RowCount; i <= dt.Rows.Count; i++)
                    {
                        gridView1.AddNewRow();
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        gridView1.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                        gridView1.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                        gridView1.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                        gridView1.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                        gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                        gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                        gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                        gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                        gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                        gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                        gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                        gridView1.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["DZSinglePrice"]));//CBSourceTypeID
                        gridView1.SetRowCellValue(i, "CBSourceTypeID", SysConvert.ToInt32(dt.Rows[i]["FormDZType"]));

                    }
                    #endregion

                    #region 采购
                    //2.采购合计---取采购单数据
                    sql = "SELECT * FROM UV1_Buy_ItemBuyFormDts WHERE OrderFormNo =" + SysString.ToDBString(txtSO.Text.Trim());
                    sql += " AND SubmitFlag>0";
                    dt = SysUtils.Fill(sql);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        gridView2.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                        gridView2.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                        gridView2.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                        //gridView2.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                        gridView2.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                        gridView2.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                        gridView2.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                        gridView2.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                        gridView2.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                        gridView2.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                        gridView2.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                        gridView2.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                        gridView2.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["SingPrice"]));
                        //gridView2.SetRowCellValue(i, "CBSourceTypeID", SysConvert.ToInt32(dt.Rows[i]["FormDZType"]));

                    }
                    #endregion

                    #region 加工
                    //3.加工合计--取加工单数据
                    sql = "SELECT * FROM UV1_WO_FabricProcessDts WHERE OrderFormNo =" + SysString.ToDBString(txtSO.Text.Trim());
                    sql += " AND SubmitFlag>0";
                    dt = SysUtils.Fill(sql);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        gridView3.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                        gridView3.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                        gridView3.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                        //gridView3.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                        gridView3.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                        gridView3.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                        gridView3.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                        gridView3.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                        gridView3.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                        gridView3.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                        gridView3.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                        gridView3.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                        gridView3.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["SingPrice"]));
                        //gridView3.SetRowCellValue(i, "CBSourceTypeID", SysConvert.ToInt32(dt.Rows[i]["FormDZType"]));

                    }
                    #endregion


                    #region 货款金额
                    sql = " Select Sum(Amount) PaymentHandleAmount  from Finance_PaymentHandle where 1=1";
                    sql += " AND OrderFormNo=" + SysString.ToDBString(txtSO.Text.Trim());
                    dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        txtHKAmount.Text = SysConvert.ToString(dt.Rows[0]["PaymentHandleAmount"]);
                    }

                    #endregion


                    #region OLD

                    //2.采购合计

                    ////采购入库
                    //sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsOrderFormNo =" + SysString.ToDBString(txtSO.Text.Trim());
                    //sql += " AND FormDZType = 1";
                    //sql += " AND SubmitFlag>0";
                    //dt = SysUtils.Fill(sql);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    gridView2.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                    //    gridView2.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    //    gridView2.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                    //    gridView2.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                    //    gridView2.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    //    gridView2.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                    //    gridView2.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                    //    gridView2.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                    //    gridView2.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    //    gridView2.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    //    gridView2.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                    //    gridView2.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    //    gridView2.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["DZSinglePrice"]));
                    //    gridView2.SetRowCellValue(i, "CBSourceTypeID", SysConvert.ToInt32(dt.Rows[i]["FormDZType"]));

                    //}

                    ////3.加工合计
                    //sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsOrderFormNo =" + SysString.ToDBString(txtSO.Text.Trim());
                    //sql += " AND FormDZType = 2";
                    //sql += " AND SubmitFlag>0";
                    //dt = SysUtils.Fill(sql);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    gridView3.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                    //    gridView3.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    //    gridView3.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                    //    gridView3.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                    //    gridView3.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    //    gridView3.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                    //    gridView3.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                    //    gridView3.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                    //    gridView3.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    //    gridView3.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    //    gridView3.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                    //    gridView3.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    //    gridView3.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["DZSinglePrice"]));
                    //    gridView3.SetRowCellValue(i, "CBSourceTypeID", SysConvert.ToInt32(dt.Rows[i]["FormDZType"]));

                    //}

                    ////4.织造合计
                    //sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsOrderFormNo LIKE" + SysString.ToDBString("%" + txtSO.Text.Trim() + "%");
                    //sql += " AND SubType IN (1114)";
                    //sql += " AND SubmitFlag>0";
                    //dt = SysUtils.Fill(sql);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    gridView4.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                    //    gridView4.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    //    gridView4.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                    //    gridView4.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                    //    gridView4.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    //    gridView4.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                    //    gridView4.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                    //    gridView4.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                    //    gridView4.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    //    gridView4.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    //    gridView4.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty2"]));
                    //    gridView4.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    //    gridView4.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["DZSinglePrice"]));

                    //}

                    ////4.染整
                    //sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsOrderFormNo LIKE" + SysString.ToDBString("%" + txtSO.Text.Trim() + "%");
                    //sql += " AND SubType IN (1115,1118)";
                    //sql += " AND SubmitFlag>0";
                    //dt = SysUtils.Fill(sql);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    gridView5.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                    //    gridView5.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    //    gridView5.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                    //    gridView5.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                    //    gridView5.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    //    gridView5.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                    //    gridView5.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                    //    gridView5.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                    //    gridView5.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    //    gridView5.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    //    gridView5.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty2"]));
                    //    gridView5.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    //    gridView5.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["DZSinglePrice"]));

                    //}

                    //sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsOrderFormNo LIKE" + SysString.ToDBString("%" + txtSO.Text.Trim() + "%");
                    //sql += " AND SubType IN (1116)";
                    //sql += " AND SubmitFlag>0";
                    //dt = SysUtils.Fill(sql);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    gridView5.SetRowCellValue(i, "FormDate", SysConvert.ToDateTime(dt.Rows[i]["FormDate"]));
                    //    gridView5.SetRowCellValue(i, "FormNo", SysConvert.ToString(dt.Rows[i]["FormNo"]));
                    //    gridView5.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[i]["VendorID"]));
                    //    gridView5.SetRowCellValue(i, "SubType", SysConvert.ToInt32(dt.Rows[i]["SubType"]));
                    //    gridView5.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[i]["ItemCode"]));
                    //    gridView5.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[i]["ItemName"]));
                    //    gridView5.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[i]["ItemStd"]));
                    //    gridView5.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[i]["ItemModel"]));

                    //    gridView5.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[i]["ColorNum"]));
                    //    gridView5.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[i]["ColorName"]));
                    //    gridView5.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[i]["Qty"]));
                    //    gridView5.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[i]["Unit"]));
                    //    gridView5.SetRowCellValue(i, "SingPrice", SysConvert.ToDecimal(dt.Rows[i]["DZSinglePrice"]));

                    //}

                    #endregion

                    this.ShowInfoMessage("加载完成！");



                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSO_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadOrder frm = new frmLoadOrder();

                    string sql = string.Empty;
                    sql += " AND FormNo NOT IN(SELECT SO FROM Sale_SaleOrderJS WHERE 1=1 ";
                    sql += ")";
                    sql += " AND ISNULL(OrderStepID,0)=8";
                    sql += " AND SubmitFlag=1";
                    frm.NoLoadCondition = sql;
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
            if (orderid.Length > 0)
            {
                string sql = "SELECT  * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtSO.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);
                }
            }

        }

        private void txtSO_EditValueChanged(object sender, EventArgs e)
        {

        }

        //#region 提交、撤销提交处理
        ///// <summary>
        ///// 提交
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }



        //        SaleOrderJSRule rule = new SaleOrderJSRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.已提交);




        //        FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);


        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}



        ///// <summary>
        ///// 撤销提交
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnSubmitCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }
        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }

        //        SaleOrderJSRule rule = new SaleOrderJSRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交);

        //        FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        //#endregion


    }
}