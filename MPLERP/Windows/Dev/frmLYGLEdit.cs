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
    public partial class frmLYGLEdit : frmAPBaseUIFormEdit
    {
        public frmLYGLEdit()
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
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请双击生成单号");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue) == ""&&txtLYVendorName.Text.Trim()=="")
            {
                this.ShowMessage("请选择或输入客户");
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
            LYGLDtsRule rule = new LYGLDtsRule();
            DataTable dtDts = rule.RShowDts(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            LYGLRule rule = new LYGLRule();
            LYGL entity = EntityGet();
            LYGLDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            LYGLRule rule = new LYGLRule();
            LYGL entity = EntityGet();
            LYGLDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            LYGL entity = new LYGL();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtMakeOPName.Text = entity.MakeOPName;
            txtPostCode.Text = entity.PostCode;
            drpPostComID.EditValue = entity.PostComID;
            txtRecName.Text = entity.RecName;
            txtRecPhone.Text = entity.RecPhone;
            txtRemark.Text = entity.Remark;
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorID.EditValue = entity.VendorID;
            txtLYVendorName.Text = entity.LYVendorName.ToString();

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
            LYGLRule rule = new LYGLRule();
            LYGL entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Dev_LYGL", "FormNo", 0, p_Flag);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_LYGL";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "GBCode" };//数据明细校验必须录入字段
            Common.BindDOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
            Common.BindVendor(drpPostComID, new int[] { (int)EnumVendorType.快递公司 }, true);
            new VendorProc(drpPostComID);
            Common.BindCLS(txtSaleQYSource, "Dev_LYGLDts", "SaleQYSource", true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载挂板借出录入", false, btnLoadIO_Click);

        }

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
                    frmLoadItemGB frm = new frmLoadItemGB();
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
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void btnLoadIO_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadGBJCLR frm = new frmLoadGBJCLR();
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
                        setItemNewsJCLR(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        

        private void setItemNews(string str)
        {
            string[] arr = str.Split(',');
            int index = gridView1.FocusedRowHandle;
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    //gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToString(dt.Rows[0]["MWidth"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToString(dt.Rows[0]["MWeight"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWeight", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));

                }
                length++;
            }
        }

        private void setItemNewsJCLR(string str)
        {
            string[] arr = str.Split(',');
            int index = gridView1.FocusedRowHandle;
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV2_Dev_GBJCLRDts WHERE DevDtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    //gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToString(dt.Rows[0]["MWidth"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToString(dt.Rows[0]["MWeight"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWeight", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));

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
        private LYGL EntityGet()
        {
            LYGL entity = new LYGL();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.FormDate = DateTime.Now.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.PostComID = SysConvert.ToString(drpPostComID.EditValue);
            entity.PostCode = txtPostCode.Text.Trim();
            entity.RecName = txtRecName.Text.Trim();
            entity.RecPhone = txtRecPhone.Text.Trim();
            entity.LYVendorName = txtLYVendorName.Text.Trim();


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private LYGLDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            LYGLDts[] entitydts = new LYGLDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new LYGLDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].GBCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode"));
                    entitydts[index].JQDesc = SysConvert.ToString(gridView1.GetRowCellValue(i, "JQDesc"));
                    entitydts[index].PBFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PBFlag"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].SalePriceDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "SalePriceDate"));
                    entitydts[index].SalePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SalePrice"));
                    entitydts[index].SaleQYSource = SysConvert.ToString(gridView1.GetRowCellValue(i, "SaleQYSource"));

                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].JYFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "JYFlag"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion



        #region 其它事件
        /// <summary>
        /// 双击得到留样单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.留样单号);
                    ProductCommon.FormNoIniSet(txtFormNo, "Dev_LYGL", "FormNo",0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 条码扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScanCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string ScanCode = txtScanCode.Text.Trim();
                txtScanCode.Text = string.Empty;
                if (ScanCode == string.Empty)
                {
                    this.ShowMessage("请扫描挂板条形码");
                    return;
                }
                if (!checkScanCode(ScanCode))
                {
                    this.ShowMessage("挂板条形码不存在，请检查后重新扫描");
                    return;
                }
                int rowHand = GetRowHand(ScanCode);
                if (rowHand < 0)
                {
                    return;
                }
                else
                {
                    string sql = "SELECT ColorNum,ColorName,MWidth,MWeight,WeightUnit,GoodsCode,ItemName,ItemCode FROM UV1_Data_ItemGB WHERE GBCode=" + SysString.ToDBString(ScanCode);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(rowHand, "GBCode", ScanCode);
                        gridView1.SetRowCellValue(rowHand, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                        gridView1.SetRowCellValue(rowHand, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                        gridView1.SetRowCellValue(rowHand, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                        gridView1.SetRowCellValue(rowHand, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                        gridView1.SetRowCellValue(rowHand, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                        gridView1.SetRowCellValue(rowHand, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                        gridView1.SetRowCellValue(rowHand, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                        gridView1.SetRowCellValue(rowHand, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    }

                }

            }
        }

        private int GetGBStatus(string p_ScanCode)
        {
            string sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
        /// <summary>
        /// 得到扫描到的赋值行
        /// </summary>
        /// <param name="p_ScanCode"></param>
        /// <returns></returns>
        private int GetRowHand(string p_ScanCode)
        {
            int rowHand = -1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) == p_ScanCode)
                {
                    return rowHand;
                }
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) == string.Empty)
                {
                    rowHand = i;
                    return rowHand;
                }
            }
            return -1;
        }

        /// <summary>
        /// 校验挂板条形码是否存在
        /// </summary>
        /// <param name="p_ScanCode"></param>
        /// <returns></returns>
        private bool checkScanCode(string p_ScanCode)
        {
            string sql = "SELECT GBCode FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void frmLYGLEdit_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region 留样打印

        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            if (HTDataID == 0)
            {
                this.ShowMessage("请先保存数据后打印");
                return false;
            }
            string IDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "JYFlag")) == 1)
                {
                    if (IDStr != "")
                    {
                        IDStr += ",";
                    }
                    IDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                }
            }

            if (IDStr == "")
            {
                this.ShowMessage("没有留样需要打印");
                return false;
            }


            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }


            FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { IDStr });
            return true;
        }

        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
               // base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.预览);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


      
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                //base.btnPrint_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.打印);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.设计);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

    }
      


}
