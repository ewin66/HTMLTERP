using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
//using HttSoft.HTCPCheck.Data;
//using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTERP.Sys;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTCPCheck.DataCtl;

namespace HTCPCheck
{
    public partial class frmCheckOrderISNRpt : frmAPBaseUIRpt
    {
        public frmCheckOrderISNRpt()
        {
            InitializeComponent();
        }
        int[] IDS = new int[] { };

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //
            if (txtSO.Text.Trim() != string.Empty)
            {
                tempStr += " AND CompactNo LIKE " + SysString.ToDBString("%" + txtSO.Text.Trim() + "%");
            }
            if (txtJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtJarNum.Text.Trim() + "%");
            }
          

            if (chkReqDate.Checked)
            {
                tempStr += " AND CheckDate BETWEEN" + SysString.ToDBString(txtReqDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtReqDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            if (ChkNoInWH.Checked)//只查询未入库的数据
            {
                tempStr += " AND ISNULL(InWHFlag,0)=0 ";
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            CheckOrderISNRule rule = new CheckOrderISNRule();

            gridView1.Columns["CheckFlag"].OptionsColumn.ReadOnly = false;
            gridView1.Columns["CheckFlag"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["CheckFlag"].OptionsColumn.AllowFocus = true;
            HTDataConditionStr += " ORDER BY JarNum, Seq ASC";//JarNumCount
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("CheckFlag", "0 CheckFlag"));

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            //BProductCheckRule rule = new BProductCheckRule();
            //BProductCheck entity = EntityGet();
            //rule.RDelete(entity);
        }

        /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Chk_CheckOrderISN";
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            //IsPostBack = false;



            txtReqDateS.DateTime = DateTime.Now.AddDays(-30);
            txtReqDateE.DateTime = DateTime.Now;

            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;

            ProcessGrid.SetGridEdit(gridView1, "CheckFlag", true);

         


            //增加入库代码
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "勾选入库", true, btnLoad_Click);    //勾选单据入库

            //this.ToolBarItemAdd(28, "btnZToExcel", "导出检验报告", false, btnZToExcel_Click);
            //this.ToolBarItemAdd(28, "btnZToNewExcel", "新导出检验报告", false, btnZToNewExcel_Click);

            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);

            btnPrintVisible = true;
        }


        /// <summary>
        ///通用 重新设置实体1，如果不要使用，则重写，一般不要修改
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            int p_ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));

            string sql = "select * from Chk_CheckOrderISNFault where MainID=" + p_ID;
            DataTable dt = SysUtils.Fill(sql);

            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }


        #endregion

        #region 勾选入库
        /// <summary>
        /// 勾选入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                //frmShowWH frm = new frmShowWH();
                //frm.ShowDialog();
                //string WHID = string.Empty;
                //string Section = string.Empty;
                //if (frm.ZResult == DialogResult.OK)
                //{
                //    WHID = frm.WHID;
                //    Section = frm.Section;
                //}
                //else
                //{
                //    this.ShowMessage("操作取消");
                //    return;
                //}

                //BProductCheckRule rule = new BProductCheckRule();
                //rule.RSubmitInWH(GetCheckItem(), WHID, Section);

                //this.ShowInfoMessage("入库单生成成功！");
                //btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 自定义方法



        private List<CheckOrderISN> GetCheckItem()
        {
            this.BaseFocusLabel.Focus();
            List<CheckOrderISN> list = new List<CheckOrderISN>();
            DataTable dt = gridView1.GridControl.DataSource as DataTable;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (SysConvert.ToInt32(dr["CheckFlag"]) == 1)
                    {
                        CheckOrderISN entity = new CheckOrderISN();
                        entity.ID = SysConvert.ToInt32(dr["DID"]);
                        entity.SelectByID();
                        if (entity.StatusID <= (int)EnumBoxStatus.未入库)
                        {
                            list.Add(entity);
                        }
                    }
                }
            }

            return list;
        }
        #endregion


        private void drpCheckFlag_CheckedChanged(object sender, EventArgs e)
        {
            //CheckEdit chk = sender as CheckEdit;
            //if (chk.Checked)
            //{
            //    int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));

            //    BProductCheckDts entity = new BProductCheckDts();
            //    entity.ID = ID;
            //    entity.SelectByID();
            //    if (entity.StatusID > (int)EnumISNStatus.初始)
            //    {
            //        chk.Checked = false;
            //        this.ShowMessage("布匹已经入库，请检查");
            //    }

            //}
        }

        private void tooltz_Click(object sender, EventArgs e)
        {

            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.删除))
            {
                this.ShowMessage("你没有此操作权限");
                return;
            }
            frmChecking frm = new frmChecking();
         
            //frm.WPFabricID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));
            //frm.WPPackOrderDtsID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            //frm.WPFMFlag = true;
            frm.ShowDialog();
        }

        private void toolcj_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.删除))
            {
                this.ShowMessage("你没有此操作权限");
                return;
            }

            //frmCDCJ frm = new frmCDCJ();
            //frm.ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));
            //frm.PackID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            //frm.ShowDialog();
        }

        public override void btnDesign_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("请选择报表模板");
                return;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("请选择报表模板");
                return;
            }

            DataTable[] dt = GetPrintSource();
            if (dt != null)
            {
                dt[0].TableName = "Main";
                dt[1].TableName = "Dts";
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, dt);
             
            }
        }

        public override void btnPreview_Click(object sender, EventArgs e)
        {

            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("请选择报表模板");
                return;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("请选择报表模板");
                return;
            }
            DataTable[] dt = GetPrintSource();
            if (dt != null)
            {
                dt[0].TableName = "Main";
                dt[1].TableName = "Dts";
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.预览, dt);
            }


        }

        public override void btnPrint_Click(object sender, EventArgs e)
        {
            #region


            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("请选择报表模板");
                return;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("请选择报表模板");
                return;
            }

            DataTable[] dt = GetPrintSource();
            if (dt != null)
            {
                dt[0].TableName = "Main";
                dt[1].TableName = "Dts";
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.打印, dt);
            }

            #endregion

        }

        #region 导出打印检验报告

        #endregion

        #region  补码自动保存
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //if (e.Column.FieldName == "YM")//修改原码
                //{

                //    int DID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));

                //    CheckOrderISNRule rule = new CheckOrderISNRule();
                //    CheckOrderISN entity = new CheckOrderISN();
                //    entity.ID = DID;
                //    entity.SelectByID();

                //    if (SysConvert.ToDecimal(gridView1.GetFocusedRowCellValue("YM")) != entity.YM)
                //    {
                //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                //        {
                //            this.ShowMessage("你没有此操作权限");
                //            return;
                //        }

                //        entity.YM = SysConvert.ToDecimal(gridView1.GetFocusedRowCellValue("YM"));
                //        rule.RUpdate(entity);

                //    }
                //}
                //if (e.Column.FieldName == "CheckFlag")
                //{
                //    if (SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("CheckFlag")) == 1)
                //    {
                //        int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                //        for (int i = 0; i < gridView1.RowCount; i++)
                //        {
                //            if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CheckFlag")) == 1)
                //            {
                //                if (ID != SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")))
                //                {
                //                    this.ShowMessage("请勾选同一缸号！");
                //                    gridView1.SetFocusedRowCellValue("CheckFlag", 0);
                //                }
                //            }
                //        }
                //    }


                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.删除))
            {
                this.ShowMessage("你没有此操作权限");
                return;
            }

            if (MessageBox.Show("确定要删除这匹布吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));

            CheckOrderISN entity = new CheckOrderISN();
            entity.ID = ID;
            entity.SelectByID();
            if (entity.StatusID > (int)EnumBoxStatus.未入库)
            {

                this.ShowMessage("布匹已经入库，请检查");
                return;
            }

            //if (entity.KF25 == 1)
            //{
            //    this.ShowMessage("开匹的数据不能删除");
            //    return;
            //}

            //if (entity.KF22 == 1)
            //{
            //    this.ShowMessage("退货冲销修改的数据不能删除");
            //    return;
            //}

            CheckOrderISNRule rule = new CheckOrderISNRule();
            rule.RDelete(entity);

            btnQuery_Click(null, null);

        }

        #region 导出EXcel


        /// <summary>
        /// 导出EXcel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnZToNewExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string CompactNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CompactNo"));
                string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));

                string OtherSO = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OtherSO"));

                string p_ExportFile = string.Empty;
                CheckOrderISNRule rule = new CheckOrderISNRule();
                GetCondtion();
                HTDataConditionStr += " AND CompactNo=" + SysString.ToDBString(CompactNo) + " AND ColorName=" + SysString.ToDBString(ColorName) + " AND JarNum=" + SysString.ToDBString(JarNum) + " AND Seq>0 " + " AND ISNULL(OtherSO,'')=" + SysString.ToDBString(OtherSO);
                HTDataConditionStr += " ORDER BY CompactNo,JarNum, JarNumCount ASC";//
                //DataTable dttem = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("CheckFlag", "0 CheckFlag").Replace("PF", "0.00 PF"));

                //TemplateExcel.JYToExcel(dttem, out p_ExportFile);

                //this.OpenFileNoConfirm(p_ExportFile);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 导出EXcel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnZToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string CompactNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CompactNo"));
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));
                string OtherSO = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OtherSO"));

                DataTable dt = gridView1.GridControl.DataSource as DataTable;
                if (dt != null)
                {
                    dt.AcceptChanges();

                    string p_ExportFile = string.Empty;
                    DataRow[] item = dt.Select(" ISNULL(CompactNo,'')=" + SysString.ToDBString(CompactNo) + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(ColorName) + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(JarNum) + " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(ItemCode) + " AND ISNULL(OtherSO,'')=" + SysString.ToDBString(OtherSO) + " AND CheckFlag=1");
                    DataTable dttem = dt.Clone();
                    dttem.TableName = "Main";
                    foreach (DataRow dr in item)
                    {
                        dttem.ImportRow(dr);
                    }
                    //TemplateExcel.JYToExcel(dttem, out p_ExportFile);

                    //this.OpenFileNoConfirm(p_ExportFile);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 获取应打印的数据源

        private DataTable[] GetPrintSource()
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string ID = string.Empty;
                string DID = string.Empty;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CheckFlag")) == 1)
                    {
                       

                        if (ID != string.Empty)
                        {
                            ID += ",";
                        }
                        ID += SysConvert.ToString(gridView1.GetRowCellValue(i, "ID"));
                        //if (DID != string.Empty)
                        //{
                        //    DID += ",";
                        //}
                        //DID += SysConvert.ToString(gridView1.GetRowCellValue(i, "DID"));

                    }
                    if (i == gridView1.RowCount - 1)
                    {
                        if (ID != string.Empty)
                        {
                            ID = "(" + ID + ")";
                        }
                        //if (DID != string.Empty)
                        //{
                        //    DID = "(" + DID + ")";
                        //}
                    }
                }

                string sql = "SELECT * FROM Chk_CheckOrderISN WHERE 1=1";
                if (ID != string.Empty)
                {
                    sql += " AND ID IN " + ID;
                }
                else
                {
                    return new DataTable[] { };
                }
                DataTable dt = SysUtils.Fill(sql);
                sql = "SELECT * FROM Chk_CheckOrderISNFault WHERE 1=1";
                if (ID != string.Empty)
                {
                    sql += " AND MainID IN " + ID;
                }
                else
                {
                    return new DataTable[] { };
                }
                //if (DID != string.Empty)
                //{
                //    sql += " AND DID IN " + DID;
                //}
                //else
                //{
                //    return new DataTable[] { };
                //}
                DataTable dt2 = SysUtils.Fill(sql);

                return new DataTable[] { dt, dt2 };
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
                return new DataTable[] { };
            }

        }
        #endregion

        private void tool4_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.删除))
            {
                this.ShowMessage("你没有此操作权限");
                return;
            }

            if (MessageBox.Show("修改的数据请确认不是已经开匹的数据，开匹后的数据无法再修改！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            //frmModifyCompact frm = new frmModifyCompact();
            //frm.ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));
            //frm.ShowDialog();

        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
                    {
                        if (chkSelectAll.Checked)
                        {
                            gridView1.SetRowCellValue(i, "CheckFlag", 1);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "CheckFlag", 0);
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