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
    /// 功能：挂板借出单管理
    /// 作者：章文强
    /// 日期：2012-04-20
    /// 操作：新增
    /// </summary>
    public partial class frmGBJCLREdit : frmAPBaseUIFormEdit
    {
        public frmGBJCLREdit()
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
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }

            //if (drpVendorID.Text == "")
            //{
            //    this.ShowMessage("请选择客户");
            //    drpVendorID.Focus();
            //    return false;
            //}


            return true;
        }
        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            GBJCLRRule rule = new GBJCLRRule();
            GBJCLR entity = EntityGet();
            // GBJCLRDts[] entityDts = EntityDtsGet();
            rule.RAdd(entity);
            return entity.ID;

        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            GBJCLRRule rule = new GBJCLRRule();
            GBJCLR entity = EntityGet();
            //GBJCLRDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity);
        }



        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            GBJCLR entity = new GBJCLR();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorID.EditValue = entity.VendorID;
            txtRemark.Text = entity.Remark.ToString();
            txtMakeOPName.Text = entity.MakeOPName;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }
            BindGrid();
        }


        private void BindGrid()
        {
            GBJCLRDtsRule rule = new GBJCLRDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();




        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            GBJCLRRule rule = new GBJCLRRule();
            GBJCLR entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataDts, new string[] { "SelectFlag" }, true);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_GBJCLR";
            this.HTDataDts = gridView1;
            Common.BindGBStatus(repGBStatus, true);
            Common.BindDOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
            Common.BindGBStatus2(drpGBStatusID, true);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
        }

        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            string GBCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GBCode"]));

            byte[] pic = GetPic(GBCode);
            if (pic != null)
            {
                img1.Image = TemplatePic.ByteToImage(pic);
            }
            else
            {
                img1.Image = null;
            }
            GetItemLabel(GBCode);

            string sql = "SELECT JCTime,VendorAttn FROM UV1_Dev_GBJCLRDts WHERE GBCode=" + SysString.ToDBString(GBCode);
            sql += " ORDER BY JCTime DESC";
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();

        }

        private void GetItemLabel(string GBCode)
        {
            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE GBCode=" + SysString.ToDBString(GBCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                lbGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                lbVendorID.Text = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                lbColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                lbColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
            }
        }

        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private GBJCLR EntityGet()
        {
            GBJCLR entity = new GBJCLR();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = DateTime.Now.Date;
            entity.Remark = txtRemark.Text.Trim();
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = txtMakeDate.DateTime;
            if (this.HTFormStatus == FormStatus.新增) //新增两个挂板借出页面 配单据类型FormListID，zjh 2013.11.14
            {
                entity.FormListID = this.FormListAID;
            }
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private GBJCLRDts[] EntityDtsGet()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) != string.Empty)
                {
                    Num++;
                }
            }
            GBJCLRDts[] entitydts = new GBJCLRDts[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) != string.Empty)
                {
                    entitydts[index] = new GBJCLRDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); ;
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].GBCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode"));//挂板条码 
                    entitydts[index].GBStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "GBStatusID"));//挂板状态
                    entitydts[index].JCTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "JCTime"));//借出时间
                    entitydts[index].GHTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "GHTime"));//归还时间
                    entitydts[index].GHOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "GHOPID"));//归还操作人
                    entitydts[index].LYFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LYFlag"));//留样标志
                    entitydts[index].LYVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "LYVendorID"));//留样客户编码
                    entitydts[index].LYVendorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "LYVendorName"));//留样客户名称

                    index++;

                }
            }
            return entitydts;
        }



        #endregion

        #region 条码扫描操作
        /// <summary>
        /// 扫描条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScanCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (HTFormStatus != FormStatus.查询)
                    {
                        this.ShowMessage("请先保存再扫描");
                        txtScanCode.Text = string.Empty;
                        return;
                    }

                    if (HTDataSubmitFlag != (int)YesOrNo.No)
                    {
                        this.ShowMessage("只有未提交才允许扫描");
                        txtScanCode.Text = string.Empty;
                        return;
                    }

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
                    if (!CheckDouble(ScanCode))
                    {
                        this.ShowMessage("请勿重复扫描");
                        return;
                    }
                    //if (!checkSameGB(ScanCode)) //深圳那边提出，剪样后可以重复扫描，sc 2013.12.18
                    //{
                    //    return;
                    //}
                    //if (!checkScanStatus(ScanCode))
                    //{
                    //    return;
                    //}

                    //插入明细数据
                    GBJCLRDts entity = new GBJCLRDts();
                    GBJCLRDtsRule rule = new GBJCLRDtsRule();
                    entity.MainID = this.HTDataID;
                    entity.Seq = SelectSeq(HTDataID);
                    entity.GBCode = ScanCode;//挂板条码 
                    entity.GBStatusID = (int)EnumGBStatus.借出;//挂板状态
                    entity.JCTime = DateTime.Now.Date;//借出时间
                    entity.GHOPID = "";//归还操作人
                    entity.LYVendorID = "";//留样客户编码
                    entity.LYVendorName = "";//留样客户名称
                    rule.RAdd(entity);
                    BindGrid();
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { ScanCode });
                    txtScanCode.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 根据条码得到图片
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private byte[] GetPic(string p_Code)
        {
            string sql = "SELECT GBPic FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return (byte[])dt.Rows[0]["GBPic"];
            }
            else
            {
                return null;
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
        private bool CheckDouble(string p_ScanCode)
        {
            string sql = "select * from Dev_GBJCLRDts where MainID=" + this.HTDataID + " and GBCode='" + p_ScanCode + "'";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        private int SelectSeq(int id)
        {
            string sql = "select max(Seq) from Dev_GBJCLRDts where MainID=" + id + "";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count < 1)
            {
                return 1;
            }
            else
            {
                return SysConvert.ToInt32(dt.Rows[0][0]) + 1;
            }
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

        /// <summary>
        /// 校验挂板状态
        /// </summary>
        /// <param name="p_ScanCode"></param>
        /// <returns></returns>
        private bool checkScanStatus(string p_ScanCode)
        {
            string sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = SysUtils.Fill(sql);
            int GBStatusID = SysConvert.ToInt32(dt.Rows[0][0]);
            switch (GBStatusID)
            {
                case (int)EnumGBStatus.丢失:
                    this.ShowMessage("挂板[" + p_ScanCode + "]处于丢失状态，不能借出");
                    return false;
                case (int)EnumGBStatus.归还:
                    return true;
                case (int)EnumGBStatus.借出:
                    this.ShowMessage("挂板[" + p_ScanCode + "]已处于借出状态，不能借出");
                    return false;
                case (int)EnumGBStatus.销售:
                    this.ShowMessage("挂板[" + p_ScanCode + "]已处于销售状态，不能借出");
                    return false;
                case (int)EnumGBStatus.在库:
                    return true;

            }
            return true;
        }


        private bool checkSameGB(string p_ScanCode)
        {
            string sql = "SELECT ID FROM UV2_Dev_GBJCLRDts WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = new DataTable();
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                this.ShowMessage("挂板[" + p_ScanCode + "]进行借出录入，不能重复操作");
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 双击弹出单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.挂板借出录入单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 提交/撤销提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                GBJCLRRule rule = new GBJCLRRule();
                rule.RSubmit(HTDataID, 1);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                GBJCLRRule rule = new GBJCLRRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 打印

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpGBStatusID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID != 0)
                {
                    string sql = "SELECT * FROM Dev_GBJCLRDts WHERE MainID=" + SysConvert.ToInt32(HTDataID);
                    if (SysConvert.ToInt32(drpGBStatusID.EditValue) != 0)
                    {
                        sql += " AND GBStatusID=" + SysString.ToDBString(SysConvert.ToInt32(drpGBStatusID.EditValue));
                    }
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
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
            string sql = "SELECT * FROM UV2_Dev_GBJCLRDts WHERE 1=1";
            if (SysConvert.ToInt32(drpGBStatusID.EditValue) != 0)
            {
                sql += " AND GBStatusID=" + SysString.ToDBString(SysConvert.ToInt32(drpGBStatusID.EditValue));
            }
            sql += " AND MainID=" + SysConvert.ToInt32(HTDataID);

            DataTable dt = SysUtils.Fill(sql);

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dt);

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
                if (HTDataID != 0)
                {
                    btnPrintAbount((int)ReportPrintType.预览);
                }


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
                if (HTDataID != 0)
                {
                    btnPrintAbount((int)ReportPrintType.打印);
                }

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
                if (HTDataID != 0)
                {
                    //base.btnDesign_Click(sender, e);
                    btnPrintAbount((int)ReportPrintType.设计);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


        private void btnLYVendor_Click(object sender, EventArgs e)
        {
            try
            {
                string GBIDStr = "";
                this.BaseFocusLabel.Focus();
                frmUpdateLYLRVendor frm = new frmUpdateLYLRVendor();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                    {

                        if (GBIDStr != "")
                        {
                            GBIDStr += "or";
                        }
                        GBIDStr += " (MainID = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "MainID"));
                        GBIDStr += " AND";
                        GBIDStr += " Seq = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq")) + ")";
                    }
                }
                frm.GBCode = GBIDStr;
                frm.ShowDialog();
                BindGrid();

                ProcessGrid.GridViewFocus(gridView1, new string[] { "GBCode" }, new string[] { GBIDStr });

                //ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { frm.GBCode.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)//清除留样客户名称sc 2013.11.13
        {
            IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
            try
            {
                sqlTrans.OpenTrans();
                this.BaseFocusLabel.Focus();
                string sql = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                    {

                        sql = "Update Dev_GBJCLRDts set LYVendorID = '',LYVendorName = '' ";
                        sql += "WHERE (MainID = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "MainID"));
                        sql += " AND";
                        sql += " Seq = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq")) + ")";
                        sqlTrans.ExecuteNonQuery(sql);
                    }

                }
                sqlTrans.CommitTrans();

                BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmGBJCLREdit_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    GBJCLR entity = new GBJCLR();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    //if (entity.SubmitFlag == 0)
                    //{
                    //    if (DialogResult.Yes != ShowConfirmMessage(this.Text + Environment.NewLine + "没有提交单据,是否确认关闭窗体"))
                    //  {
                    //    e.Cancel = true;
                    //  }
                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




    }
}