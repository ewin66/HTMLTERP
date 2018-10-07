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
    /// 功能：报价管理
    ///  
    /// </summary>
    public partial class frmQuotedPriceEdit : frmAPBaseUIFormEdit
    {
        public frmQuotedPriceEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入报价单号");
                txtFormNo.Focus();
                return false;
            }

            //if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            //{
            //    this.ShowMessage("请选择业务员");
            //    drpSaleOPID.Focus();
            //    return false;
            //}

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择报价客户");
                drpVendorID.Focus();
                return false;
            }

            if (ProductParamSet.GetIntValueByID(5416) == (int)YesOrNo.Yes)//显示价格条款，价格有效期
            {
                if (txtTradeType.Text == "")
                {
                    this.ShowMessage("请选择贸易类型");
                    txtTradeType.Focus();
                    return false;
                }
            }

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            //if (!CheckQuotedPrice())
            //{
            //    return false;
            //}
            return true;
        }


        /// <summary>
        /// 校验明细数据是否重复
        /// </summary>
        /// <returns></returns>
        //private bool CheckQuotedPrice()
        //{
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //        {
        //            for (int j = 0; j < gridView1.RowCount; j++)
        //            {
        //                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
        //                {
        //                    if (i != j && SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorNum")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorName")))
        //                    {
        //                        this.ShowMessage("第" + SysConvert.ToString(SysConvert.ToInt32(i + 1)) + "行数据与第" + SysConvert.ToString(SysConvert.ToInt32(j + 1)) + "行数据重复,产品编号.色号.颜色一致,请检查后重新保存");
        //                        return false;
        //                    }
        //                }
        //            }

        //            if (SysConvert.ToString(drpVendorID.EditValue) != "")
        //            {
        //                string sql = "SELECT FormNo,MakeDate,USB,RMB FROM UV1_Sale_QuotedPriceDts where DVendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
        //                sql += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")));
        //                sql += " AND SubmitFlag=1";
        //                DataTable dt = SysUtils.Fill(sql);
        //                if (dt.Rows.Count > 0)
        //                {
        //                    if (DialogResult.Yes != ShowConfirmMessage("该客户的产品：" + SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) + "已报价，报价单号为：" + SysConvert.ToString(dt.Rows[0]["FormNo"].ToString()) + ",报价日期为：" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd") + ",报价为：" + SysConvert.ToString(dt.Rows[0]["USB"].ToString()) + SysConvert.ToString(dt.Rows[0]["RMB"].ToString()) + "确定继续报价吗？"))
        //                    {
        //                        return false;
        //                    }
        //                    //this.ShowMessage("该客户的产品：" + SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) + "已报价，报价单号为：" + SysConvert.ToString(dt.Rows[0]["FormNo"].ToString()) + ",报价日期为：" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd") + ",报价为：" + SysConvert.ToString(dt.Rows[0]["SalePrice"].ToString()));
        //                    //return false;
        //                }
        //            }
        //        }


        //    }
        //    return true;
        //}

        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            QuotedPriceDtsRule rule = new QuotedPriceDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();

            //if (dtDts.Rows.Count > 0)
            //{
            //    txtMHL.Text = SysConvert.ToString(gridView1.GetRowCellValue(0,"HL"));
            //}
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            QuotedPriceRule rule = new QuotedPriceRule();
            QuotedPrice entity = EntityGet();
            QuotedPriceDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            QuotedPriceRule rule = new QuotedPriceRule();
            QuotedPrice entity = EntityGet();
            QuotedPriceDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);

        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            QuotedPrice entity = new QuotedPrice();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorOPName.EditValue = entity.VendorOPName;
            txtMHL.Text = entity.HL.ToString();
            txtPriceContext.Text = entity.PriceContext;
            txtEffDate.DateTime = entity.EffDate;

            txtJiaoQi.DateTime = entity.JiaoQi;
            txtYongJing.Text = entity.YongJing.ToString();
            txtGangKou.Text = entity.GangKou.ToString();
            txtKHType.Text = entity.KHType.ToString();
            txtZZMarket.Text = entity.ZZMarket.ToString();

            txtTradeType.Text = entity.TradeType;
            txtAddper.Text = entity.AddPer.ToString();

            txtEffTime.Text = entity.EffTime;
            drpTradeWay.EditValue = entity.TradeWay;
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;
            drpTransportWay.EditValue = entity.TransportWay;
            drpSelvageReq.EditValue = entity.SelvageReq;
            drpDyeReq.EditValue = entity.DyeReq;
            drpArrangeReq.EditValue = entity.ArrangeReq;
            drpPackReq.EditValue = entity.PackReq;
            drpQualityReq.EditValue = entity.QualityReq;
            drpDeliveryReq.EditValue = entity.DeliveryReq;
            drpVEmail.EditValue = entity.VEmail;
            drpVTelephone.EditValue = entity.VTelephone;
            drpVFax.EditValue = entity.VFax;
            drpVAddress.EditValue = entity.VAddress;
            txtOtherReq.EditValue = entity.OtherReq;
            drpBJSaleOPID.EditValue = entity.BJSaleOPID;
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
            QuotedPriceRule rule = new QuotedPriceRule();
            QuotedPrice entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Sale_QuotedPrice", "FormNo", 0, p_Flag);
            //ProcessGrid.SetGridEdit(gridView1, new string[] { "SalePrice" }, true);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now;
            txtFormNo_DoubleClick(null, null);
            txtJiaoQi.DateTime = DateTime.Now.Date;
            drpSaleOPID.EditValue = FParamConfig.LoginID;
            drpBJSaleOPID.EditValue = FParamConfig.LoginID;
            txtTradeType.EditValue = "外贸";
            txtEffDate.DateTime = DateTime.Now.Date;
            txtMHL.Text = "6.8";
        }
        public override void IniRefreshData()
        {
            Common.BindPayMethod(drpPayMothodFlag, true);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            IniUCPicture();

            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[3] { gridView2, gridView3, gridView4 };
            this.HTDataTableName = "Sale_QuotedPrice";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);//客户
            //Common.BindEnumUnit(txtUnit, true);

            Common.BindCLS(txtUnit, "Data_Item", "ItemUnitFab", true);
            // Common.BindOP(drpSaleOPID, true);
            //if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            //{
            //    Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            //}
            //else
            //{
            //    Common.BindOPID(drpSaleOPID, true);
            //}
            DevMethod.BindItem(drpItemCode, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.业务部 }, true);
            DevMethod.BindOP(drpBJSaleOPID, new int[] { (int)EnumOPDep.业务部 }, true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载面料", false, btnLoad_Click);

            //if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5201)))//报价单隐藏留样单加载按钮
            //{
            //    this.ToolBarItemAdd(28, "btnLoadLY", "加载留样单", false, btnLoadLY_Click);
            //}
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);

            Common.BindItemClass(drpItemClassID, new int[] { (int)EnumItemType.面料 }, true);

            if (ProductParamSet.GetIntValueByID(5416) == (int)YesOrNo.Yes)//显示价格条款，价格有效期
            {
                lbEffDate.Visible = true;
                txtEffDate.Visible = true;
                lbPriceContext.Visible = true;
                txtPriceContext.Visible = true;
                lbAddPrice.Visible = true;
                txtAddper.Visible = true;
                lbTrade.Visible = true;
                txtTradeType.Visible = true;
                lbMHL.Visible = true;
                txtMHL.Visible = true;
            }



            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))//查看价格权限
            {
                txtGridSet.PasswordChar = '*';
            }


        }

        /// <summary>
        /// 换行改变事件
        /// </summary>
        /// <param name="sender"></param>
        public void gridViewRowChanged1(object sender)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));



                string sql = "SELECT * FROM Data_ItemColorDtsHis WHERE MainID IN (SELECT ID FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode) + ")";
                sql += " ORDER BY Seq DESC";
                DataTable dt = SysUtils.Fill(sql);
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();

                sql = "SELECT * FROM UV1_Sale_QuotedPriceDts WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                sql += " ORDER BY MakeDate DESC";
                dt = SysUtils.Fill(sql);
                gridView3.GridControl.DataSource = dt;
                gridView3.GridControl.Show();


                if (SysConvert.ToString(drpVendorID.EditValue) != "")
                {
                    sql = "SELECT * FROM UV1_Sale_QuotedPriceDts WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                    sql += " ORDER BY MakeDate DESC";
                    dt = SysUtils.Fill(sql);
                    gridView4.GridControl.DataSource = dt;
                    gridView4.GridControl.Show();
                }

                BindGridColor();
                BindImage();
                //string GBCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GBCode"));

                GetItemLabel(ItemCode);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 绑定数据列表内的颜色控件
        /// </summary>
        void BindGridColor()
        {
            if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//新增和修改，绑定颜色和色号
            {
                string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                Common.BindItemColor(drpGridColorNum, drpGridColorName, itemCode, true);//根据物料绑定色号色名
            }
        }


        #region 自定义方法图片相关
        /// <summary>
        /// 绑定图片
        /// </summary>
        void BindImage()
        {
            string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));

            byte[] picdata = GetPic(itemCode);

            if (picdata != null)
            {
                List<Image> lstimage = new List<Image>();
                if (picdata.Length > 10)
                {
                    lstimage.Add(TemplatePic.ByteToImage(picdata));
                }
                ucPictureView1.UCDataLstImage = lstimage;
            }
            else
            {
                List<Image> lstimage = new List<Image>();
                ucPictureView1.UCDataLstImage = lstimage;
            }

        }


        /// <summary>
        /// 根据条码得到图片
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private byte[] GetPic(string p_Code)
        {
            string sql = "SELECT TOP 1 GBPic FROM UV1_Data_ItemGB WHERE ItemCode=" + SysString.ToDBString(p_Code) + " ORDER BY GBCode ";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["GBPic"] != DBNull.Value)
                {
                    return (byte[])dt.Rows[0]["GBPic"];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 初始化图片控件
        /// </summary>
        void IniUCPicture()
        {
            ucPictureView1.UCReadOnly = true;
            ucPictureView1.UCInputPictureMultiFlag = false;//单图模式
            ucPictureView1.UCInputMainType = 2;//图片模式
            ucPictureView1.UCInputDBSaveType = 1;//同一数据只有Update  

            ucPictureView1.UCDBMainIDFieldName = "";
            ucPictureView1.UCDBRemarkFieldName = "";
            ucPictureView1.UCDBTableName = "Data_ItemGB";
            ucPictureView1.UCDBPicFieldName = "GBPic";
            ucPictureView1.UCDBSmallPicFieldName = "GBPic2";
            ucPictureView1.UCDataID = 0;
            ucPictureView1.UCAct();
        }
        #endregion


        private void GetItemLabel(string itemCode)
        {
            string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(itemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                //lbGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                //lbVendorID.Text = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                lbColorNum.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                lbColorName.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
            }
        }

        /// 加载挂板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    restxtItemCode_DoubleClick(null, null);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// 加载留样单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadLY_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    LoadLYForm();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void LoadLYForm()
        {
            frmLoadLY frm = new frmLoadLY();
            frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.LYID != null && frm.LYID.Length != 0)
            {

                for (int i = 0; i < frm.LYID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.LYID[i]);
                }
                setLYNews(str);
                gridViewRowChanged1(gridView1);
            }
        }


        private void setLYNews(string str)
        {
            string[] arr = str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Dev_LYGLDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    //gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MLLBName", SysConvert.ToString(dt.Rows[0]["MLLBName"]));

                }
                length++;
            }
        }



        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private QuotedPrice EntityGet()
        {
            QuotedPrice entity = new QuotedPrice();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.BJSaleOPID = SysConvert.ToString(drpBJSaleOPID.EditValue);
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.Remark = txtRemark.Text.Trim();
            entity.VendorOPName = SysConvert.ToString(drpVendorOPName.EditValue);
            entity.EffDate = txtEffDate.DateTime;
            entity.PriceContext = txtPriceContext.Text.Trim();
            entity.TradeType = txtTradeType.Text.Trim();

            entity.JiaoQi = txtJiaoQi.DateTime.Date;
            entity.YongJing = txtYongJing.Text.Trim();
            entity.GangKou = txtGangKou.Text.Trim();
            entity.KHType = txtKHType.Text.Trim();
            entity.ZZMarket = txtZZMarket.Text.Trim();

            entity.AddPer = SysConvert.ToDecimal(txtAddper.Text.Trim());
            entity.HL = SysConvert.ToDecimal(txtMHL.Text.Trim());

            // entity.TradeType = txtTradeType.Text.Trim();
            entity.EffTime = txtEffTime.Text.Trim();

            entity.TradeWay = SysConvert.ToString(drpTradeWay.EditValue);
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.TransportWay = SysConvert.ToString(drpTransportWay.EditValue);
            entity.SelvageReq = SysConvert.ToString(drpSelvageReq.EditValue);
            entity.DyeReq = SysConvert.ToString(drpDyeReq.EditValue);
            entity.ArrangeReq = SysConvert.ToString(drpArrangeReq.EditValue);
            entity.PackReq = SysConvert.ToString(drpPackReq.EditValue);
            entity.QualityReq = SysConvert.ToString(drpQualityReq.EditValue);
            entity.DeliveryReq = SysConvert.ToString(drpDeliveryReq.EditValue);
            entity.OtherReq = SysConvert.ToString(txtOtherReq.EditValue);
            entity.VEmail = SysConvert.ToString(drpVEmail.EditValue);
            entity.VTelephone = SysConvert.ToString(drpVTelephone.EditValue);
            entity.VFax = SysConvert.ToString(drpVFax.EditValue);
            entity.VAddress = SysConvert.ToString(drpVAddress.EditValue);


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private QuotedPriceDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            QuotedPriceDts[] entitydts = new QuotedPriceDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new QuotedPriceDts();

                    if (HTFormStatus == FormStatus.新增)
                    {
                        entitydts[index].ID = HTDataID;
                    }
                    else
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    }
                  
                    entitydts[index].SelectByID();

                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].GBCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));//客户品名
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));//客户色号
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));//客户色名
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    //entitydts[index] = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].MinQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MinQty"));
                    entitydts[index].PBPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PBPrice"));
                    entitydts[index].ColorPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ColorPrice"));
                    entitydts[index].ZLPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "ZLPrice"));
                    entitydts[index].Shrinkage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Shrinkage"));
                    entitydts[index].TotalPriceUSB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalPriceUSB"));
                    entitydts[index].HL = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "HL"));
                    entitydts[index].TotalPriceRMB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TotalPriceRMB"));
                    entitydts[index].FK = SysConvert.ToString(gridView1.GetRowCellValue(i, "FK"));
                    entitydts[index].KZ = SysConvert.ToString(gridView1.GetRowCellValue(i, "KZ"));
                    entitydts[index].USB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "USB"));//美元报价M
                    entitydts[index].ItemUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemUnit"));

                    entitydts[index].PackFee = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PackFee"));//包装费
                    entitydts[index].LiRunFee = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "LiRunFee"));//利润
                    entitydts[index].YongJin = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "YongJin"));//佣金
                    entitydts[index].TradeFee = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TradeFee"));//运费
                    entitydts[index].Fee1 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Fee1"));//其他费用
                    entitydts[index].HouZLReq = SysConvert.ToString(gridView1.GetRowCellValue(i, "HouZLReq"));///后整理要求
                    entitydts[index].RMB = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RMB"));//人民币M报价
                    entitydts[index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));///密度
                    entitydts[index].RMBY = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RMBY"));//人民币Y报价
                    entitydts[index].USBY = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "USBY"));//美元Y报价

                    index++;
                }
            }
            return entitydts;
        }

        #endregion


        #region 加载
        /// <summary>
        /// 加载挂板信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {


                    frmLoadFabric frm = new frmLoadFabric();

                    frm.SelectItemType = SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5413)); //0：表示只支持加载产品  1：表示只支持选择加载产品或者坯布  2:表示坯布


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
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));//云虹使用，针形改为密度
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    setRowID++;
                }
            }
        }

        //private void setItemNews(string str)
        //{
        //    string[] arr = str.Split(',');
        //    int index = checkRowSet();
        //    int length = 0;
        //    for (int i = index; i < arr.Length + index; i++)
        //    {
        //        string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
        //        DataTable dt = SysUtils.Fill(sql);

        //        if (dt.Rows.Count > 0)
        //        {
        //            gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
        //            gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
        //            gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
        //            gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
        //            gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
        //            gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
        //            gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
        //            gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
        //            gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
        //            gridView1.SetRowCellValue(i, "MLLBName", SysConvert.ToString(dt.Rows[0]["MLLBName"]));

        //        }
        //        length++;
        //    }
        //}

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

        #endregion


        #region 其他事件

        /// <summary>
        /// 扫描挂板条码带出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemGBCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (ProductParamSet.GetIntValueByID(5015) == (int)YesOrNo.Yes)//报价扫描产品编号，0标示扫描挂板编号
                    {
                        string ItemCode = txtItemGBCode.Text.Trim();
                        if (ItemCode != "")
                        {
                            string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                            DataTable dt = SysUtils.Fill(sql);
                            if (dt.Rows.Count > 0)
                            {
                                int RowHandle = checkRowSet();
                                gridView1.SetRowCellValue(RowHandle, "ItemCode", dt.Rows[0]["ItemCode"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemName", dt.Rows[0]["ItemName"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemModel", dt.Rows[0]["ItemModel"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemStd", dt.Rows[0]["ItemStd"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "HZType", dt.Rows[0]["HZType"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "ItemClassID", SysConvert.ToInt32(dt.Rows[0]["ItemClassID"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "DeliveryTime", dt.Rows[0]["DeliveryTime"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "MinQty", dt.Rows[0]["MinQty"].ToString());
                                gridView1.SetRowCellValue(RowHandle, "PerMiWeight", SysConvert.ToDecimal(dt.Rows[0]["PerMiWeight"].ToString()));
                                gridView1.SetRowCellValue(RowHandle, "SalePrice", SysConvert.ToDecimal(dt.Rows[0]["SalePrice"].ToString()));

                                txtItemGBCode.Text = "";
                                txtItemGBCode.Focus();

                                if (ProductParamSet.GetIntValueByID(5416) == (int)YesOrNo.Yes)//增加加价比例,杰卡要求增加
                                {
                                    if (SysConvert.ToDecimal(dt.Rows[0]["SalePrice"]) > 0)
                                    {
                                        gridView1.SetRowCellValue(RowHandle, "SaleOPPrice", SysConvert.ToDecimal(dt.Rows[0]["SalePrice"]));
                                        gridView1.SetRowCellValue(RowHandle, "SalePrice", SysConvert.ToDecimal(dt.Rows[0]["SalePrice"].ToString()));
                                    }
                                    else
                                    {
                                        gridView1.SetRowCellValue(RowHandle, "SaleOPPrice", DBNull.Value);
                                        gridView1.SetRowCellValue(RowHandle, "SalePrice", DBNull.Value);
                                    }
                                }

                            }
                            else
                            {
                                this.ShowMessage("条码不存在！");
                                txtItemGBCode.Text = "";
                                txtItemGBCode.Focus();
                            }
                        }
                        else
                        {
                            this.ShowMessage("请扫描条码！");
                            txtItemGBCode.Text = "";
                            txtItemGBCode.Focus();
                        }
                    }
                    else
                    {
                        string GBCode = txtItemGBCode.Text.Trim();
                        if (GBCode != string.Empty)
                        {
                            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE 1=1 ";
                            sql += " AND GBCode = " + SysString.ToDBString(GBCode);
                            DataTable dt = SysUtils.Fill(sql);
                            if (dt.Rows.Count == 1)
                            {
                                bool Insertbol = false;
                                for (int i = 0; i < gridView1.RowCount; i++)
                                {
                                    if (!CheckDataCompleteDts(i))
                                    {
                                        gridView1.SetRowCellValue(i, "GBCode", dt.Rows[0]["GBCode"].ToString());
                                        gridView1.SetRowCellValue(i, "ItemCode", dt.Rows[0]["ItemCode"].ToString());
                                        gridView1.SetRowCellValue(i, "ItemName", dt.Rows[0]["ItemName"].ToString());
                                        gridView1.SetRowCellValue(i, "ItemModel", dt.Rows[0]["ItemModel"].ToString());
                                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"].ToString()));
                                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"].ToString()));
                                        gridView1.SetRowCellValue(i, "ColorNum", dt.Rows[0]["ColorNum"].ToString());
                                        gridView1.SetRowCellValue(i, "ColorName", dt.Rows[0]["ColorName"].ToString());
                                        gridView1.SetRowCellValue(i, "MLLBName", dt.Rows[0]["MLLBName"].ToString());
                                        Insertbol = true;
                                    }
                                    if (Insertbol)
                                    {
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                if (dt.Rows.Count == 0)
                                {
                                    this.ShowMessage("该挂板条码不存在请检查");
                                }
                                else
                                {
                                    this.ShowMessage("数据异常：该挂板条码不唯一，请检查");
                                }
                                return;
                            }

                        }
                        txtItemGBCode.Text = "";
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 控制生成报价单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "Sale_QuotedPrice", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)
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
                            view.SetRowCellValue(view.FocusedRowHandle, "MWidth", dt.Rows[0]["MWidth"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "MWeight", dt.Rows[0]["MWeight"]);
                            view.SetRowCellValue(view.FocusedRowHandle, "GoodsCode", dt.Rows[0]["GoodsCode"]);
                        }
                    }

                    //if (e.Column.FieldName == "ColorNum")//色号改变，检索赋值色名
                    //{
                    //    ColumnView view = sender as ColumnView;
                    //    string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                    //    string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                    //    view.SetRowCellValue(view.FocusedRowHandle, "ColorName", Common.GetItemColorNameByColorNum(ItemCode, ColorNum));

                    //}
                    //    if (e.Column.FieldName == "PBPrice" || e.Column.FieldName == "ColorPrice" || e.Column.FieldName == "ZLPrice" || e.Column.FieldName == "HL" || e.Column.FieldName == "PackFee" || e.Column.FieldName == "LiRunFee" || e.Column.FieldName == "Shrinkage" || e.Column.FieldName == "Fee1" || e.Column.FieldName == "TradeFee" || e.Column.FieldName == "YongJin")//价格变化，人民币=白坯价/（1-缩率%）+染整价+后整理价+包装费+利润+其他费用
                    //    {
                    //        ColumnView view = sender as ColumnView;
                    //        decimal PBPrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PBPrice"));//坯布价格
                    //        decimal ColorPrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "ColorPrice"));//染色单价
                    //        decimal ZLPrice = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "ZLPrice"));//后整理价
                    //        decimal PackFee = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PackFee"));//包装费用
                    //        decimal LiRunFee = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "LiRunFee"));//利润
                    //        decimal Shrinkage = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Shrinkage"));//坯布缩率
                    //        decimal Fee1 = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "Fee1"));//其他费用
                    //        //decimal HL = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "HL"));//汇率
                    //        decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());//汇率
                    //        decimal a = Shrinkage * SysConvert.ToDecimal(0.01);
                    //        decimal TotalPriceRMB = PBPrice / (1 - a) + ZLPrice + ColorPrice + PackFee + LiRunFee + Fee1;
                    //        view.SetRowCellValue(view.FocusedRowHandle, "TotalPriceRMB", SysConvert.ToDecimal(TotalPriceRMB, 2));
                    //        if (HL != 0)
                    //        {
                    //            decimal TradeFee = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "TradeFee"));
                    //            decimal YongJin = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "YongJin")) * SysConvert.ToDecimal(0.01) + 1;
                    //            decimal b = TotalPriceRMB * SysConvert.ToDecimal(0.9144);
                    //            decimal c = SysConvert.ToDecimal(b / HL, 2) + TradeFee;
                    //            decimal TotalPriceUSB = SysConvert.ToDecimal(c * YongJin, 2);

                    //            view.SetRowCellValue(view.FocusedRowHandle, "TotalPriceUSB", TotalPriceUSB);

                    //        }
                    //    }

                    //}
                    if (e.Column.FieldName == "RMB" || e.Column.FieldName == "HL")
                    {
                        //人民币米/汇率=美金米，人民币米*0.9144/汇率=美金码；
                        ColumnView view = sender as ColumnView;
                        decimal rmb = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "RMB"));

                        //decimal HL = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "HL"));
                        decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());//汇率
                        decimal usb = SysConvert.ToDecimal(rmb / HL, 2);//人民币M/汇率=美M
                        decimal a = SysConvert.ToDecimal(rmb * SysConvert.ToDecimal(0.9144), 2);
                        decimal usby = SysConvert.ToDecimal(a / HL, 2);
                        view.SetRowCellValue(view.FocusedRowHandle, "USB", usb);
                        view.SetRowCellValue(view.FocusedRowHandle, "USBY", usby);
                    }
                    if (e.Column.FieldName == "RMBY" || e.Column.FieldName == "HL")
                    {
                        //人民币码/0.9144/汇率=美金米，人民币码/汇率=美金码；
                        ColumnView view = sender as ColumnView;

                        decimal rmby = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "RMBY"));
                        //decimal HL = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "HL"));
                        decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());//汇率
                        decimal a = SysConvert.ToDecimal(rmby / SysConvert.ToDecimal(0.9144), 2);
                        decimal usb = SysConvert.ToDecimal(a / HL, 2);
                        decimal usby = SysConvert.ToDecimal(rmby / HL, 2);
                        view.SetRowCellValue(view.FocusedRowHandle, "USB", usb);
                        view.SetRowCellValue(view.FocusedRowHandle, "USBY", usby);
                        //人民币M/汇率=美M

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void txtCost_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Cost = 0;
                decimal PBPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PBPrice"));//坯布价
                decimal RShrinkage = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RShrinkage")), '%');//染缩
                decimal RSAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RSAmount"));//染费
                decimal RSSH = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RSSH")), '%');//染色损耗
                decimal JGAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JGAmount"));//加工费
                decimal JGSH = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JGSH")), '%');//加工损耗
                decimal HZAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HZAmount"));//后整费用
                //decimal ProfitMargin = GetDecimalByString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitMargin")), '%');//利润率
                decimal Quot = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Quot"));//Quot

                //Cost=[{(坯布价*(1+(染缩/100))+RSAmount) *(1+(染色损耗/100))+ 加工费}*(1+(加工损耗/100))+后整费用]*1.06+0.2
                Cost = (((PBPrice * (1m + (RShrinkage / 100m)) + RSAmount) * (1m + (RSSH / 100m)) + JGAmount) * (1m + (JGSH / 100m)) + HZAmount) * 1.06m + 0.2m;
                Cost = SysConvert.ToDecimal(Cost, 2);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "COSTA", Cost + "/M");  //COST自动赋值

                //decimal Quot = 0.0m;
                decimal ProfitMargin = 0.0m;
                if (Quot != 0 && Cost != 0)
                {
                    ProfitMargin = Quot / Cost - 1;
                }
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ProfitMargin", ProfitMargin);  //Quot

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private decimal GetDecimalByString(string p_Decimal, char p_Char)
        {
            decimal value = 0;
            if (SysConvert.ToDecimal(p_Decimal) > 0)
            {
                value = SysConvert.ToDecimal(p_Decimal);
            }
            else
            {
                string[] decimalArr = p_Decimal.Split(p_Char);
                if (decimalArr.Length > 0)
                {
                    value = SysConvert.ToDecimal(decimalArr[0]);
                }
                else
                {
                    value = 0;
                }
            }
            return value;
        }

        private void txtAddPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal SaleOPPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SaleOPPrice"));
                decimal ProfitMargin = SysConvert.ToDecimal(txtAddper.Text.Trim());
                decimal SalePrice = 0;
                if (ProfitMargin > 0)
                {
                    SalePrice = SaleOPPrice * (1m + ProfitMargin / 100m);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SalePrice", SalePrice);
                }

                if (txtTradeType.Text == "外销")
                {

                    //decimal HL = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HL"));
                    //if (HL > 0)
                    //{
                    //    decimal USDPrice = SysConvert.ToDecimal(SalePrice / HL, 2);// *(1m + ProfitMargin / 100m);
                    //    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "USDPrice", USDPrice);
                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void groupControlMainten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHL_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    this.BaseFocusLabel.Focus();
            //    decimal SalePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalePrice"));
            //    decimal HL = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HL"));
            //    if (HL > 0)
            //    {
            //        decimal USDPrice = SysConvert.ToDecimal(SalePrice / HL, 2);// *(1m + ProfitMargin / 100m);
            //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "USDPrice", USDPrice);
            //    }
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }

        private void txtTradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTradeType.Text == "内销")
                {
                    this.gridColumn65.Visible = false;
                    this.gridColumn66.Visible = false;

                }
                else if (txtTradeType.Text.Trim() == "外销")
                {
                    this.gridColumn65.Visible = true;
                    this.gridColumn66.Visible = true;
                    this.gridColumn65.VisibleIndex = 14;
                    this.gridColumn66.VisibleIndex = 15;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtAddper_Leave(object sender, EventArgs e)
        {
            this.BaseFocusLabel.Focus();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SaleOPPrice")) > 0)
                {
                    decimal SaleOPPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SaleOPPrice"));
                    decimal ProfitMargin = SysConvert.ToDecimal(txtAddper.Text.Trim());
                    decimal SalePrice = 0;
                    if (ProfitMargin > 0)
                    {
                        SalePrice = SaleOPPrice * (1m + ProfitMargin / 100m);
                        gridView1.SetRowCellValue(i, "SalePrice", SalePrice);
                    }
                    if (txtTradeType.Text == "外销")
                    {

                        //  decimal HL = SysConvert.ToDecimal(txtMHL.Text.Trim());
                        //if (HL > 0)
                        //{
                        //    decimal USDPrice = SysConvert.ToDecimal(SalePrice / HL, 2);// *(1m + ProfitMargin / 100m);
                        //    gridView1.SetRowCellValue(i, "HL", HL);
                        //    gridView1.SetRowCellValue(i, "USDPrice", USDPrice);
                        //}
                    }
                }
            }
        }

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    Common.BindVendorAddress(drpVAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                    Common.BindVendorContact(drpVendorOPName, SysConvert.ToString(drpVendorID.EditValue), true);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpVendorOPName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    drpVTelephone.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPName.EditValue));
                    drpVEmail.Text = Common.GetVendorContactEmailByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPName.EditValue));
                    drpVFax.Text = Common.GetVendorContactFAXByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpVendorOPName.EditValue));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtMHL_EditValueChanged(object sender, EventArgs e)
        {
            if (this.HTFormStatus == FormStatus.新增 || this.HTFormStatus == FormStatus.修改)
            {
                // gridView1_CellValueChanged(null,null);
                decimal mhl = SysConvert.ToDecimal(txtMHL.Text.Trim());
                if (mhl > 0)
                {

                    DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                    dt.AcceptChanges();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (SysConvert.ToDecimal(dt.Rows[i]["RMB"]) > 0)
                        {
                            dt.Rows[i]["USB"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMB"]) / mhl, 2);
                            dt.Rows[i]["USBY"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMB"]) * SysConvert.ToDecimal(0.9144) / mhl, 2);
                        }
                        else if (SysConvert.ToDecimal(dt.Rows[i]["RMBY"]) > 0)
                        {
                            dt.Rows[i]["RMB"] = 0;
                            dt.Rows[i]["USB"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMBY"]) / SysConvert.ToDecimal(0.9144) / mhl, 2);
                            dt.Rows[i]["USBY"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dt.Rows[i]["RMBY"]) / mhl, 2);
                        }

                    }

                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

            }


        }




    }
}