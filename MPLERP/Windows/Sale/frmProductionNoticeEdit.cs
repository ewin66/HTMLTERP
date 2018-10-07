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
    /// <summary>
    /// 功能：生产通知单
    /// 
    /// </summary>
    public partial class frmProductionNoticeEdit : frmAPBaseUIFormEdit
    {
        public frmProductionNoticeEdit()
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
            ProductionNoticeDtsRule rule = new ProductionNoticeDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();

            BindGridIOForm();
        }


        private void BindGridIOForm()
        {
            try
            {
                string sql = "select * from UV1_WH_IOFormDts where 1=1";
                sql += " AND SubmitFlag=1";
                sql += " AND SubType=177";//坯布织造入库
                sql += " AND DtsOrderFormNo=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(0,"SO")));
                sql += " AND DtsOrderFormNo<>''";
                DataTable dt1 = SysUtils.Fill(sql);
                gridView2.GridControl.DataSource = dt1;
                gridView2.GridControl.Show();

                 sql = "select * from UV1_WH_IOFormDts where 1=1";
                sql += " AND SubmitFlag=1";
                sql += " AND SubType=162";//坯布染色出库
                sql += " AND DtsOrderFormNo=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(0, "SO")));
                sql += " AND DtsOrderFormNo<>''";
                DataTable dt2 = SysUtils.Fill(sql);
                gridView3.GridControl.DataSource = dt2;
                gridView3.GridControl.Show();

                //sql = "select * from UV1_WH_IOFormDts where 1=1";
                //sql += " AND SubmitFlag=1";
                //sql += " AND SubType=162";//成品入库
                //sql += " AND DtsOrderFormNo=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(0, "SO")));
                //sql += " AND DtsOrderFormNo<>''";
                //DataTable dt3 = SysUtils.Fill(sql);
                //gridView4.GridControl.DataSource = dt3;
                //gridView4.GridControl.Show();

                //sql = "select * from UV1_WH_IOFormDts where 1=1";
                //sql += " AND SubmitFlag=1";
                //sql += " AND SubType=162";//成品出库
                //sql += " AND DtsOrderFormNo=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(0, "SO")));
                //sql += " AND DtsOrderFormNo<>''";
                //DataTable dt4 = SysUtils.Fill(sql);
                //gridView5.GridControl.DataSource = dt4;
                //gridView5.GridControl.Show();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ProductionNoticeRule rule = new ProductionNoticeRule();
            ProductionNotice entity = EntityGet();
            ProductionNoticeDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ProductionNoticeRule rule = new ProductionNoticeRule();
            ProductionNotice entity = EntityGet();
            ProductionNoticeDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ProductionNotice entity = new ProductionNotice();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtFormDate.DateTime = entity.FormDate;
            txtOutDate.DateTime = entity.OutDate;
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            drpTrackOPID.EditValue = entity.TrackOPID.ToString();
            drpProductionLeader.EditValue = entity.ProductionLeader.ToString();
            txtRemark.Text = entity.Remark.ToString();
         

            drpTrackOPID2.EditValue = entity.TrackOPID2.ToString();
            drpTrackOPID3.EditValue = entity.TrackOPID3.ToString();
            drpSOTypeID.EditValue = entity.SOTypeID;

            txtAddress.Text = entity.Address.ToString();
            txtQtyReq.Text = entity.QtyReq.ToString();
            txtCheckStandard.Text = entity.CheckStandard.ToString();
            txtCheckReq.Text = entity.CheckReq.ToString();

            chkLightSource.Text = entity.LightSource;

            txtCPItemCode.Text = entity.CPItemCode.ToString();
            txtCPDensity.Text = entity.CPDensity.ToString();
            txtCPMWidth.Text = entity.CPMWidth.ToString();
            txtCPMWeight.Text = entity.CPMWeight.ToString();

            txtPBItemCode.Text = entity.PBItemCode.ToString();
            txtPBDensity.Text = entity.PBDensity.ToString();
            txtPBMWidth.Text = entity.PBMWidth.ToString();
            txtPBMWeight.Text = entity.PBMWeight.ToString();

            drpFactoryID.Text = entity.FactoryID.ToString();
            drpFactoryID2.Text = entity.FactoryID2.ToString();

            txtXGDate.DateTime = entity.XGDate;
            txtXGReason.Text = entity.XGReason.ToString();

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }

            BindGridDts();


            SetPDInfo();
        }




        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ProductionNoticeRule rule = new ProductionNoticeRule();
            ProductionNotice entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            txtFormNo.Properties.ReadOnly = true;
            txtMakeOPName.Properties.ReadOnly = true;
            txtMakeDate.Properties.ReadOnly = true;

        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormNo_DoubleClick(null, null);
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;
            txtXGDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_ProductionNotice";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode", "ColorName" };//数据明细校验必须录入字段
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3 };
            Common.BindOP(drpSaleOPID, true);
            Common.BindOP(drpTrackOPID, true);
            Common.BindOP(drpTrackOPID2, true);
            Common.BindOP(drpTrackOPID3, true);
            Common.BindOP(drpProductionLeader, true);

            DevMethod.BindVendor(drpFactoryID2, (int)EnumVendorType.染厂, true);
           
            DevMethod.BindVendor(drpFactoryID, new int[] { (int)EnumVendorType.织厂,(int)EnumVendorType.供应商 }, true);

            new PopContainerUtil(chkLightSource, Common.BindLightSource); 

            Common.BindOrderType(drpSOTypeID, true);
            Common.BindCLS(txtCheckStandard, "Sale_ProductionNotice", "CheckStandard", true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载订单", false, btnLoad_Click);



        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ProductionNotice EntityGet()
        {
            ProductionNotice entity = new ProductionNotice();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.OutDate = txtOutDate.DateTime.Date;
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.TrackOPID = SysConvert.ToString(drpTrackOPID.EditValue);
            entity.ProductionLeader = SysConvert.ToString(drpProductionLeader.EditValue);
            entity.Remark = txtRemark.Text.Trim();
         

            entity.SOTypeID = SysConvert.ToInt32(drpSOTypeID.EditValue);
            entity.TrackOPID2 = SysConvert.ToString(drpTrackOPID2.EditValue);
            entity.TrackOPID3 = SysConvert.ToString(drpTrackOPID3.EditValue);
            
            


            entity.QtyReq = txtQtyReq.Text.Trim();
            entity.CheckReq = txtCheckReq.Text.Trim();
            entity.CheckStandard = txtCheckStandard.Text.Trim();
            entity.Address = txtAddress.Text.Trim();

            entity.FormNoIndex = SysConvert.ToInt32(Common.GetSubStringRight(entity.FormNo, 2));//记录单号流水号

            entity.LightSource = SysConvert.ToString(chkLightSource.Text);


            entity.CPItemCode = txtCPItemCode.Text.Trim();
            entity.CPDensity = txtCPDensity.Text.Trim();
            entity.CPMWidth = txtCPMWidth.Text.Trim();
            entity.CPMWeight = txtCPMWeight.Text.Trim();

            entity.PBItemCode = txtPBItemCode.Text.Trim();
            entity.PBDensity = txtPBDensity.Text.Trim();
            entity.PBMWidth = txtPBMWidth.Text.Trim();
            entity.PBMWeight = txtPBMWeight.Text.Trim();


            entity.FactoryID = drpFactoryID.Text.Trim();
            entity.FactoryID2 = drpFactoryID2.Text.Trim();

            entity.XGDate = txtXGDate.DateTime.Date;
            entity.XGReason = txtXGReason.Text.Trim();

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ProductionNoticeDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ProductionNoticeDts[] entitydts = new ProductionNoticeDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ProductionNoticeDts();
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

                    entitydts[index].SO = SysConvert.ToString(gridView1.GetRowCellValue(i, "SO"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ConfirmSample = SysConvert.ToString(gridView1.GetRowCellValue(i, "ConfirmSample"));
                    entitydts[index].SOQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SOQty"));
                    entitydts[index].CPQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CPQty"));
                    entitydts[index].TPQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TPQty"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
                    entitydts[index].DRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DRemark"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].Flower = SysConvert.ToString(gridView1.GetRowCellValue(i, "Flower"));
                    entitydts[index].Shrinkage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Shrinkage"));

                    entitydts[index].LoadID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadID"));

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
                    FormNoControlRule frule = new FormNoControlRule();
                   
                        txtFormNo.Text = frule.RGetFormNo((int)FormNoControlEnum.生产通知单号);
                  
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
                    frmLoadOrder frm = new frmLoadOrder();
                    frm.Double = true;
                    string sql = string.Empty;
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
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    if (HTFormStatus == FormStatus.新增)
                    {
                        if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(6200)) == 2)//生产通知单单号启用新的生成规则：SR+年份+客户编码+01：SR14A00101
                        {
                            FormNoControlRule frule = new FormNoControlRule();
                            string vendorid = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                            txtFormNo.Text = frule.RGetFormNo2((int)FormNoControlEnum.生产通知单号, vendorid);
                        }
                    }


                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));
                    gridView1.SetRowCellValue(i, "SOQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[0]["VendorAttn"]));
                    gridView1.SetRowCellValue(i, "SO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "LoadID", SysConvert.ToDecimal(dt.Rows[0]["DtsID"]));
                    
                    drpSOTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["OrderTypeID"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);
                    txtAddress.Text = Common.GetVendorAddress(dt.Rows[0]["VendorID"].ToString());


                }
            }
        }





        #endregion

        private void txtRSReamrk_EditValueChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 设置排单信息
        /// </summary>
        private void SetPDInfo()
        {
            try
            {

              //   ProcessTypeID=" + SysString.ToDBString((int)EnumProcessType.织造加工单);

                string info = string.Empty;
                string sql = "select ProcessTypeID,SUM(ISNULL(TotalQty,0)) TotalQty from WO_FabricProcess WHERE 1=1";
                sql += " AND ProductionID=" + SysString.ToDBString(HTDataID);
                sql += " Group By ProcessTypeID ";
                DataTable dtDts = SysUtils.Fill(sql);
                if (dtDts.Rows.Count != 0)
                {
                    for (int i = 0; i < dtDts.Rows.Count; i++)
                    {
                        if (SysConvert.ToInt32(dtDts.Rows[i]["ProcessTypeID"]) == (int)EnumProcessType.织造加工单)
                        {
                            info += "  织造排单数：" + SysConvert.ToString(dtDts.Rows[i]["TotalQty"]);
                        }
                        if (SysConvert.ToInt32(dtDts.Rows[i]["ProcessTypeID"]) == (int)EnumProcessType.染整加工单)
                        {
                            info += "  染整排单数：" + SysConvert.ToString(dtDts.Rows[i]["TotalQty"]);
                        }
                        if (SysConvert.ToInt32(dtDts.Rows[i]["ProcessTypeID"]) == (int)EnumProcessType.其他加工单)
                        {
                            info += "  后整理排单数：" + SysConvert.ToString(dtDts.Rows[i]["TotalQty"]);
                        }
                        if (SysConvert.ToInt32(dtDts.Rows[i]["ProcessTypeID"]) == (int)EnumProcessType.印花加工单)
                        {
                            info += "  印花排单数：" + SysConvert.ToString(dtDts.Rows[i]["TotalQty"]);
                        }

                    }
                }

                lblInfo.Text = info;

               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    }
}