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
    /// 功能：产品检索
    /// 作者：陈加海
    /// 日期：2014-04-13
    /// 操作：检索
    /// 卡片模式进阶功能参照面料产品 frmItemList.cs页面
    /// </summary>
    public partial class frmDevItemQuery : frmAPBaseUIRpt
    {
        public frmDevItemQuery()
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
           
            if (txtNeedle.Text.Trim() != "")
            {
                tempStr += " AND Needle LIKE " + SysString.ToDBString("%" + txtNeedle.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
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
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
                //tempStr += " AND ID IN(SELECT MainID FROM Data_ItemDts WHERE DtsItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
                
                //tempStr += ")";
            }

            if (txtItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtItemStd.Text.Trim() + "%");
                //tempStr += " AND ID IN(SELECT MainID FROM Data_ItemDts WHERE DtsItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");

                //tempStr += ")";
            }

            tempStr += " AND UseableFlag=1";
            
            if (chkItemDate.Checked)
            {
                tempStr += " AND ItemDate BETWEEN "+SysString.ToDBString(txtItemDateS.DateTime)+" AND "+SysString.ToDBString(txtItemDateE.DateTime);
            }

            tempStr += " AND ItemTypeID=" + (int)EnumItemType.面料;
          
            tempStr += " ORDER BY ItemCode";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {

            switch(xtraTabControl1.SelectedTabPageIndex)
            {
                case 0://卡片模式
                    BindGridCard();
                    break;
                case 1://列表模式
                    BindGridList();
                    break;
            }
        }


        /// <summary>
        /// 绑定列表
        /// </summary>
        void BindGridList()
        {
            ItemGBRule rule = new ItemGBRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag").Replace("VendorName", "'' VendorName"));

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        /// <summary>
        /// 绑定卡片
        /// </summary>
        void BindGridCard()
        {
            ItemGBRule rule = new ItemGBRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag").Replace("VendorName", "'' VendorName"));

            cardView1.GridControl.DataSource = dt;
            cardView1.GridControl.Show();
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
            this.HTQryContainer = groupControlQuery;

            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Card.CardView[] { cardView1 };

            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
            txtItemDateS.DateTime = DateTime.Now.AddYears(-3).Date;
            txtItemDateE.DateTime = DateTime.Now.Date;
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;

            IsPostBack = true;

            txtScan.Focus();
            //this.ToolBarItemAdd(32, "btnUpdateGB", "挂板修改", true, btnUpdateGB_Click, eShortcut.F9);
            //this.ToolBarItemAdd(32, "btnUpdateGB", "挂板批量修改", true, btnUpdateGBPL_Click, eShortcut.F9);
            //this.ToolBarItemAdd(32, "btnLoadItemRecommend", "产品推荐", true, btnLoadItemRecommend_Click, eShortcut.F9);
            //this.ToolBarItemAdd(32, "btnDelImage", "清除图片", true, btnDelImage_Click, eShortcut.F9);
            
           
            
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


        /// <summary>
        ///通用 重新设置实体
        /// 
        /// </summary>
        private void gridViewRowChanged1(object sender)
        {
            try
            {
                //ColumnView view = sender as ColumnView;
                //if (SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GBCode")) != "")
                //{
                //    img1.Image = TemplatePic.ByteToImage(GetPicByCode(SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GBCode"))));
                //}

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private byte[] GetPicByCode(string p_Code)
        {
            string sql = "SELECT GBPic FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return (byte[])dt.Rows[0][0];
            }
            return null;
        }

        
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
        //        frm.GBCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GBCode"));
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
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5014)))//面料定义界面不要显示原料信息管理内容
                    {
                        GBIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    }
                    else
                    {
                        GBIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                    }
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
            string sql = "";
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5014)))//面料定义界面不要显示原料信息管理内容
            {
                sql = "SELECT * FROM UV1_Data_ItemGB WHERE ID IN (" + GBIDStr + ")";
            }
            else
            {
                sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID IN (" +GBIDStr + ")";
            }
            DataTable dt = SysUtils.Fill(sql);
            dt.Columns.Add("TableTitle",typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["TableTitle"] = txtTableTitle.Text.Trim();
            }
            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dt);
            //FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { GBIDStr });
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

                switch (xtraTabControl1.SelectedTabPageIndex)
                {
                    case 0://卡片模式
                        frm.GBID = SysConvert.ToInt32(cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "DtsID"));
                        break;
                    case 1://列表模式
                        frm.GBID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                        break;
                }
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
                //for (int i = 0; i < gridView1.RowCount; i++)
                //{
                //    //if (chkAll.Checked)
                //    //{
                //    //    gridView1.SetRowCellValue(i, "SelectFlag", 1);
                //    //}
                //    //else
                //    //{
                //    //    gridView1.SetRowCellValue(i, "SelectFlag", 0);
                //    //}
                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

        #endregion


        #region 检索相关方法

      
        #endregion
        #region 其它事件
        private void cmiSelectAll_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    dr["SelectFlag"] = 1;
                }
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 选项卡改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                BindGrid();
            } 
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
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
        #endregion

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string InputContext=txtScan.Text.Trim();
                    if (InputContext == "")
                    {
                        txtScan.Text = "";
                        txtScan.Focus();
                        this.ShowMessage("扫描的条码不存在，请检查！");
                        return;
                    }
                    if (!checkSacn(InputContext))
                    {
                        txtScan.Text = "";
                        txtScan.Focus();
                        this.ShowMessage("扫描的条码不存在，请检查！");
                        return;
                    }
                    if (txtShow.Text.Trim() != "")
                    {
                        txtShow.Text += ",";
                    }
                    txtShow.Text +=SysString.ToDBString(InputContext);
                    txtScan.Text = "";
                    txtScan.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private bool checkSacn(string InputContext)
        {
            bool falg = false;
            string sql = "SELECT ID FROM Data_Item WHERE ItemTypeID="+SysString.ToDBString((int)EnumItemType.面料);
            sql += " AND ItemCode="+SysString.ToDBString(InputContext);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                falg = true;
            }
            return falg;
        }

        private void btnScanPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string tempstr = " AND ItemCode IN ("+txtShow.Text.Trim()+")";

                ItemGBRule rule = new ItemGBRule();
                DataTable dt = rule.RShow(tempstr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "1 SelectFlag").Replace("VendorName", "'' VendorName"));

                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();

                DataTable dt2 = rule.RShow(tempstr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "1 SelectFlag").Replace("VendorName", "'' VendorName"));

                cardView1.GridControl.DataSource = dt2;
                cardView1.GridControl.Show();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtScan.Text = "";
                txtShow.Text = "";
                txtScan.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



       
      

      
       


    }
}