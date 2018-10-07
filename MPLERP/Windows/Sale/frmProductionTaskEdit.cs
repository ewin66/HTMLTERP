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
    public partial class frmProductionTaskEdit : frmAPBaseUIFormEdit
    {
        public frmProductionTaskEdit()
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
        }

        private void BindZZDts()
        {
            string sql = "select ID,FormNo,FormDate,DyeFactoryName,ItemCode,ItemModel,ItemStd,ColorName,Qty from UV1_WO_FabricProcessDts WHERE  ProcessTypeID=" + SysString.ToDBString((int)EnumProcessType.织造加工单);
            sql += " AND ProductionID=" + SysString.ToDBString(HTDataID);
            DataTable dtDts = SysUtils.Fill(sql);

            gridView2.GridControl.DataSource = dtDts;
            gridView2.GridControl.Show();
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
            txtZZRemark.Text = entity.ZZRemark.ToString();
            txtRSReamrk.Text = entity.RSReamrk.ToString();
            txtHZLRemark.Text = entity.HZLRemark.ToString();
            txtBZRemark.Text = entity.BZRemark.ToString();

            drpTrackOPID2.EditValue = entity.TrackOPID2.ToString();
            drpTrackOPID3.EditValue = entity.TrackOPID3.ToString();
            drpSOTypeID.EditValue = entity.SOTypeID;


            drpFactoryID.EditValue = entity.FactoryID;
            drpFactoryID2.EditValue = entity.FactoryID2;
            drpFactoryID3.EditValue = entity.FactoryID3;
            drpFactoryID4.EditValue = entity.FactoryID4;
            drpFactoryID5.EditValue = entity.FactoryID5;
           
            txtHZLRemark2.Text = entity.HZLRemark2.ToString();
            txtHZLRemark3.Text = entity.HZLRemark3.ToString();


            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }

            BindGridDts();

            BindZZDts();
          
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

            //txtFormNo.Properties.ReadOnly = true;
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

            Common.BindOP(drpSaleOPID, true);
            Common.BindOP(drpTrackOPID, true);
            Common.BindOP(drpTrackOPID2, true);
            Common.BindOP(drpTrackOPID3, true);
            Common.BindOP(drpProductionLeader, true);

            

            Common.BindOrderType(drpSOTypeID, true);

            Common.BindVendor(drpFactoryID, new int[] {(int)EnumVendorType.染厂,(int)EnumVendorType.其他加工厂 }, true);
            //Common.BindVendor(drpFactoryID2, new int[] { (int)EnumVendorType.整理厂, (int)EnumVendorType.其他加工厂 }, true);
            //Common.BindVendor(drpFactoryID3, new int[] { (int)EnumVendorType.整理厂, (int)EnumVendorType.其他加工厂 }, true);
            //Common.BindVendor(drpFactoryID4, new int[] { (int)EnumVendorType.整理厂, (int)EnumVendorType.其他加工厂 }, true);
            //Common.BindVendor(drpFactoryID5, new int[] { (int)EnumVendorType.整理厂, (int)EnumVendorType.其他加工厂 }, true);

            Common.BindVendor(drpDtsFactoryID, new int[] {(int)EnumVendorType.其他加工厂 }, true);

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);

            new VendorProc(drpFactoryID);
            new VendorProc(drpFactoryID2);
            new VendorProc(drpFactoryID3);
            new VendorProc(drpFactoryID4);
            new VendorProc(drpFactoryID5);


            Common.BindSOContext(drpContext, "", true);
            Common.BindSOContext(drpContext2, "", true);
            Common.BindSOContext(drpContext3, "", true);
            Common.BindSOContext(drpContext4, "", true);
            Common.BindSOContext(drpContext5, "", true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);



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
            entity.ZZRemark = txtZZRemark.Text.Trim();
            entity.RSReamrk = txtRSReamrk.Text.Trim();
            entity.HZLRemark = txtHZLRemark.Text.Trim();
            entity.BZRemark = txtBZRemark.Text.Trim();

            entity.SOTypeID = SysConvert.ToInt32(drpSOTypeID.EditValue);
            entity.TrackOPID2 = SysConvert.ToString(drpTrackOPID2.EditValue);
            entity.TrackOPID3 = SysConvert.ToString(drpTrackOPID3.EditValue);

            entity.FormNoIndex = SysConvert.ToInt32(Common.GetSubStringRight(entity.FormNo, 2));//记录单号流水号

            entity.FactoryID = SysConvert.ToString(drpFactoryID.EditValue);
            entity.FactoryID2 = SysConvert.ToString(drpFactoryID2.EditValue);
            entity.FactoryID3 = SysConvert.ToString(drpFactoryID3.EditValue);
            entity.FactoryID4 = SysConvert.ToString(drpFactoryID4.EditValue);
            entity.FactoryID5 = SysConvert.ToString(drpFactoryID5.EditValue);

            //entity.HZGDOPID = SysConvert.ToString(drpHZGD.EditValue);
            entity.HZLRemark2 = txtHZLRemark2.Text.Trim();
            entity.HZLRemark3 = txtHZLRemark3.Text.Trim();

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
                    entitydts[index].DRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DRemark"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].Flower = SysConvert.ToString(gridView1.GetRowCellValue(i, "Flower"));
                    entitydts[index].Shrinkage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Shrinkage"));

                    entitydts[index].LoadID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LoadID"));

                    entitydts[index].TBCPQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TBCPQty"));
                    entitydts[index].ReqDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "ReqDate"));
                    entitydts[index].FactoryID = SysConvert.ToString(gridView1.GetRowCellValue(i, "FactoryID"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));

                    entitydts[index].MaxQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MaxQty"));

                    entitydts[index].MainQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MainQty"));

                    entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));

                    entitydts[index].OutRange = SysConvert.ToString(gridView1.GetRowCellValue(i, "OutRange"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));


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
                    if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(6200)) == 2)//生产通知单单号启用新的生成规则：SR+年份+客户编码+01：SR14A00101
                    {

                    }
                    else
                    {
                        txtFormNo.Text = frule.RGetFormNo((int)FormNoControlEnum.生产通知单号);
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
                    sql += " AND DtsID NOT IN (SELECT LoadID FROM UV1_Sale_ProductionNoticeDts)";
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
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["FK"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "SO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "SOQty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i, "LoadID", SysConvert.ToInt32(dt.Rows[0]["DtsID"]));

                    DateTime DtsReqDate = SysConvert.ToDateTime(dt.Rows[0]["DtsReqDate"]);

                    gridView1.SetRowCellValue(i, "ReqDate", DtsReqDate.AddDays(-2).Date);

                    drpSOTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["OrderTypeID"]);
                    drpSaleOPID.EditValue = SysConvert.ToString(dt.Rows[0]["SaleOPID"]);

                    gridView1.SetRowCellValue(i, "MaxQty", SysConvert.ToString(dt.Rows[0]["MaxQty"]));
                    gridView1.SetRowCellValue(i, "MainQty", SysConvert.ToString(dt.Rows[0]["MinQty"]));
                    gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "VendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));

                    gridView1.SetRowCellValue(i, "OutRange", SysConvert.ToString(dt.Rows[0]["OutRange"]));
                    gridView1.SetRowCellValue(i, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));



                }
            }
        }





        #endregion

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void drpContext_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Context FROM Data_SOContext WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpContext.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtRSReamrk.Text = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpContext2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Context FROM Data_SOContext WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpContext2.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtHZLRemark.Text = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpContext3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Context FROM Data_SOContext WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpContext3.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtHZLRemark2.Text = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpContext4_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Context FROM Data_SOContext WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpContext4.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtHZLRemark3.Text = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpContext5_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Context FROM Data_SOContext WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpContext5.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtBZRemark.Text = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    this.BaseFocusLabel.Focus();
                    decimal Shrinkage = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Shrinkage"));
                    decimal CPQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CPQty"));
                    decimal TPQty=CPQty*(1m+(Shrinkage/100m));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TPQty", TPQty);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        

       

       

        

      

      

      




    }
}