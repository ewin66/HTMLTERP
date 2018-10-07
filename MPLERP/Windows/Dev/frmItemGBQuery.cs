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
using DevExpress.XtraGrid.Views.Base;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：挂板查询
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmItemGBQuery : frmAPBaseUIRpt
    {
        public frmItemGBQuery()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]

        /// <summary>
        /// 查询条件
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtVendorID.Text.Trim() != "")
            {
                tempStr += " AND VendorID LIKE " + SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%"); 
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%"); 
            }
            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%"); 
            }
            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            //if (txtMLDL.Text.Trim() != "")
            //{
            //    tempStr += " AND MLDLName LIKE " + SysString.ToDBString("%" + txtMLDL.Text.Trim() + "%");
            //}
            //if (txtMLLB.Text.Trim() != "")
            //{
            //    tempStr += " AND MLLBName LIKE " + SysString.ToDBString("%" + txtMLLB.Text.Trim() + "%");
            //}
            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ID IN(SELECT MainID FROM Data_ItemDts WHERE DtsItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
                if (txtPercentageS.Text.Trim() != "")
                {
                    tempStr += " AND Percentage>=" + SysString.ToDBString(SysConvert.ToDecimal(txtPercentageS.Text.Trim()));
                }
                if (txtPercentageE.Text.Trim() != "")
                {
                    tempStr += " AND Percentage<=" + SysString.ToDBString(SysConvert.ToDecimal(txtPercentageE.Text.Trim()));
                }
                tempStr += ")";
            }
            if (txtMWeightS.Text.Trim() != "")
            {
                tempStr += " AND MWeight>= " + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }
            if (txtMWeightE.Text.Trim() != "")
            {
                tempStr += " AND MWeight<=" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (chkItemDate.Checked)
            {
                tempStr += " AND ItemDate BETWEEN "+SysString.ToDBString(txtItemDateS.DateTime)+" AND "+SysString.ToDBString(txtItemDateE.DateTime);
            }

            if (chkGBDate.Checked)
            {
                tempStr += " AND GBDate BETWEEN "+SysString.ToDBString(txtGBDateS.DateTime)+" AND "+SysString.ToDBString(txtGBDateE.DateTime);
            }
            if (txtGBCode.Text.Trim() != "")
            {
                tempStr += " AND GBCode LIKE "+SysString.ToDBString("%"+txtGBCode.Text.Trim()+"%");
            }
            if (chkGBFlag.Checked)
            {
                tempStr += " AND ISNULL(GBFlag,0)=1 ";
            }
            if (chkNOGBFlag.Checked)
            {
                tempStr += " AND ISNULL(GBFlag,0)=0 ";
            }
            if (chkTestReport.Checked)
            {
                tempStr += " AND ISNULL(testReportFlag,0)=1 ";
            }
            if (chkImage.Checked)
            {
                tempStr += " AND ISNULL(DATALENGTH(GBPic),0)>1";
            }
            if (chkNOImage.Checked)
            {
                tempStr += " AND ISNULL(DATALENGTH(GBPic),0)<2";
            }
            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {

            ItemGBRule rule = new ItemGBRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag").Replace("VendorName", "'' VendorName"));
            if (chkVendor.Checked)
            {
                SetGridView(dt);
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

        }

        private void SetGridView(DataTable p_dt)
        {
            foreach (DataRow dr in p_dt.Rows)
            {
                if (SysConvert.ToInt32(dr["GBStatusID"]) == (int)EnumGBStatus.借出)
                {
                    string sql = "SELECT VendorName FROM UV1_Dev_GBJCDts WHERE GBStatusID="+SysString.ToDBString((int)EnumGBStatus.借出);
                    sql += " AND ISNULL(SubmitFlag,0)=1";
                    sql += " AND GBCode="+SysString.ToDBString(dr["GBCode"].ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        dr["VendorName"] = SysConvert.ToString(dt.Rows[0][0]);
                    }
                }
                
            }
        }

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ItemGB";
            this.HTDataList = gridView1;
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
            txtGBDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtGBDateE.DateTime = DateTime.Now.Date;
            txtItemDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtItemDateE.DateTime = DateTime.Now.Date;
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            //this.ToolBarItemAdd(32, "btnUpdateGB", "挂板修改", true, btnUpdateGB_Click, eShortcut.F9);
            //this.ToolBarItemAdd(32, "btnUpdateGB", "挂板批量修改", true, btnUpdateGBPL_Click, eShortcut.F9);
            //this.ToolBarItemAdd(32, "btnLoadItemRecommend", "产品推荐", true, btnLoadItemRecommend_Click, eShortcut.F9);
            //this.ToolBarItemAdd(32, "btnDelImage", "清除图片", true, btnDelImage_Click, eShortcut.F9);
            btnQuery_Click(null, null);
            if (ItemGBQuery.ColorIniFlag)
            {
                ItemGBQuery.ColorIniTextBox(new TextBox[] { txtColorSOStatus1, txtColorSOStatus2, txtColorSOStatus3, txtColorSOStatus4, txtColorSOStatus5 });
            }
            
        }


       
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Item EntityGet()
        {
            Item entity = new Item();
            entity.ID = HTDataID;      
            return entity;
        }


        ///// <summary>
        /////通用 重新设置实体
        ///// 
        ///// </summary>
        //private void gridViewRowChanged1(object sender)
        //{
        //    try
        //    {
        //        ColumnView view = sender as ColumnView;
        //        if (SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GBCode")) != "")
        //        {
        //            img1.Image = TemplatePic.ByteToImage(GetPicByCode(SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GBCode"))));
        //        }

        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private byte[] GetPicByCode(string p_Code)
        //{
        //    string sql = "SELECT GBPic FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(p_Code);
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return (byte[])dt.Rows[0][0];
        //    }
        //    return null;
        //}

        
        ///// <summary>
        ///// 显示图片大图
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void img1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmPicShow frm = new frmPicShow();
        //        frm.GBID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
        //        frm.ShowDialog();
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        #endregion

        #region 其他方法
        /// <summary>
        /// 查看挂板明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToGBDetail_Click(object sender, EventArgs e)
        {
            try
            {
                int ID=SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ID"));
                if(ID!=0)
                {
                      this.NavigateWin("frmDevItemEdit",ID.ToString(), FormStatus.查询);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        public void NavigateWin(string p_FormClassName, string p_ParentID, FormStatus p_MFormStatus)
        {
            MDIForm.ContextMenuOpenForm(FUISourceObject.GetResultArrayList(FUISourceObject.SourceForm, this), p_FormClassName, this.FormListAID, this.FormListBID, this.SubmitFlag, this.AuditFlag, p_ParentID, p_MFormStatus);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "GBStatusName")
                {
                    e.Appearance.BackColor = ItemGBQuery.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "GBStatusName")));
                }
             
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 挂板条码打印

        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string GBIDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (GBIDStr != "")
                    {
                        GBIDStr += ",";
                    }
                    GBIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                }
            }
           
            if (GBIDStr == "")
            {
                this.ShowMessage("请勾选需要打印的挂板条码");
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


            FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { GBIDStr });
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
                base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.预览);
               

            }
            catch(Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        //private DataTable GetReportdt(string p_DtsID)
        //{
        //    string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID IN("+p_DtsID+")";
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt;
        //    }
        //    return null;
        //}
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {
           
            try
            {
                base.btnPrint_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.打印);
                
            }
            catch(Exception E)
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
                base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.设计);                
            }
            catch(Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        private void btnToShowPic_Click(object sender, EventArgs e)
        {
            try
            {
                frmPicShow frm = new frmPicShow();
                frm.GBID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (chkAll.Checked)
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 0);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void 收藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                frmFavItem frm = new frmFavItem();
                frm.GBCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"GBCode"));
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 挂板修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateGB_Click(object sender, EventArgs e)
        {
            try
            {
                string GBIDStr = "";
                this.BaseFocusLabel.Focus();
                frmUpdateGB frm = new frmUpdateGB();              
                GBIDStr = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GBCode"));
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));

                frm.GBCode = GBIDStr;
                frm.ShowDialog();
                txtName_EditValueChanged(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[] { "GBCode" }, new string[] { GBIDStr });
                //ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { frm.GBCode.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 挂板批量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateGBPL_Click(object sender, EventArgs e)
        {
            try
            {
                string GBIDStr = "";
                this.BaseFocusLabel.Focus();
                frmUpdateGBPL frm = new frmUpdateGBPL();
                
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag")) == 0)
                    {
                        this.ShowMessage("请先勾选，再进行挂板批量修改");
                        return;
                    }
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                    {
                        if (GBIDStr != "")
                        {
                            GBIDStr += ",";
                        }
                        GBIDStr += SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode"));
                    }                   
                }

                //frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                frm.GBCode = GBIDStr;
                frm.ShowDialog();
                txtName_EditValueChanged(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[] { "GBCode" }, new string[] { GBIDStr });
                //ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { frm.GBCode.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 清除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelImage_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (DialogResult.Yes == ShowConfirmMessage("是否清除该挂板图片"))
                {

                    string GBCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GBCode"));
                    if (GBCode != string.Empty)
                    {
                        string sql = "UPDATE Data_ItemGB SET GBPic='0' WHERE GBCode=" + SysString.ToDBString(GBCode);
                        SysUtils.Fill(sql);
                        BindGrid();
                        ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { GBCode });

                    }
                }
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 产品推荐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadItemRecommend_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemRecommend frm = new frmItemRecommend();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(180, 30);
                frm.ShowDialog();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


        #region 检索相关方法

        /// <summary>
        /// 快速查询(值改变即检索)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //GetCondtion();
                //BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 快速查询(回车即检索)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (chkSM.Checked)
                    {
                        if (txtGBCode.Text.Trim() == "")
                        {
                            this.ShowMessage("请输入挂板编码！");
                            return;
                        }
                        string GBCodeStr = txtGBCodeStr.Text.Trim();
                        if (GBCodeStr != "")
                        {
                            GBCodeStr += ",";
                        }
                        GBCodeStr += SysString.ToDBString(txtGBCode.Text.Trim());
                        txtGBCodeStr.Text = GBCodeStr;
                        ItemGBRule rule = new ItemGBRule();
                        DataTable dt = rule.RShow(" AND GBCode IN ("+txtGBCodeStr.Text.Trim()+")", ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "1 SelectFlag").Replace("VendorName", "'' VendorName"));
                        if (chkVendor.Checked)
                        {
                            SetGridView(dt);
                        }
                        gridView1.GridControl.DataSource = dt;
                        gridView1.GridControl.Show();
                        txtGBCode.Text = "";
                        txtGBCode.Focus();

                    }
                    else
                    {
                        GetCondtion();
                        BindGrid();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        /// <summary>
        /// shift快捷键选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFlag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int firstRow = 0;
                int endRow = 0;
                bool Find = false; 
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1 && i != gridView1.FocusedRowHandle)
                    {
                        firstRow = i;
                        Find = true;
                        break;
                    }
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1 && i != gridView1.FocusedRowHandle)
                    {
                        endRow = i;
                    }
                }

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && Find)
                {
                    int RID1 = 0;
                    int RID2 = 0;
                    int SelectFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag"));
                    if (SelectFlag == 1)
                    {
                        if (firstRow > gridView1.FocusedRowHandle)
                        {
                            RID1 = gridView1.FocusedRowHandle;
                            RID2 = firstRow;
                        }
                        else
                        {
                            RID1 = firstRow;
                            RID2 = gridView1.FocusedRowHandle;
                        }
                        for (int i = RID1; i < RID2; i++)
                        {
                            gridView1.SetRowCellValue(i, "SelectFlag", SelectFlag);
                        }
                    }
                    else
                    {
                        if (endRow > gridView1.FocusedRowHandle)
                        {
                            RID1 = gridView1.FocusedRowHandle;
                            RID2 = endRow;
                        }
                        else
                        {
                            RID1 = endRow;
                            RID2 = gridView1.FocusedRowHandle;
                        }
                        for (int i = RID1; i <=RID2; i++)
                        {
                            gridView1.SetRowCellValue(i, "SelectFlag", SelectFlag);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    }
}