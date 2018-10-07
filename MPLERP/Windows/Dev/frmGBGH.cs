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
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：挂板借出单查询
    /// 作者：章文强
    /// 日期：2012-04-20
    /// 操作：新增
    /// </summary>
    public partial class frmGBGH : frmAPBaseUIRpt
    {
        public frmGBGH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 判断流程
        /// 1.扫描条码
        /// 2.判断是归还还是撤销归还
        /// 3.如是归还操作判断该条码是否有处于借出状态的条码
        /// 4.如有则更新到归还状态
        /// 5.如是撤销归还操作
        /// 6.判断扫描的条码是否在gridview1内
        /// 7.如不在，则提示不能撤销
        /// 8.如在，根据MainID更新借出单的状态
        /// </summary>
        public DataTable dtCode=null;

        int LYFlag = 0;
        #region 窗体事件
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGBGH_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindGBStatus(repGBStatus, true);

                txtScan.Focus();
                string sql = "SELECT *,'' ItemCode,'' ItemName,'' ItemStd,'' ItemModel,'' MWidth,'' MWeight,'' ColorNum,'' ColorName FROM Dev_GBJCDts WHERE 1=0";
                dtCode = SysUtils.Fill(sql);


                ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI

                gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
                gridViewBindEventA1(gridView1);


                ProcessGrid.BindGridColumn(gridView2, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView2, FormListAID, FormListBID);//设置列UI
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 扫描事件
        /// <summary>
        /// 条码扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string GBCode = txtScan.Text.Trim();
                    if (GBCode == "")
                    {
                        this.ShowMessage("请扫描条码");
                        return;
                    }

                    GBJCRule rule = new GBJCRule();
                    string sql = "SELECT * FROM Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(GBCode);
                    DataTable dt = new DataTable();
                    dt = SysUtils.Fill(sql);
                    if(dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToDecimal(dt.Rows[0]["LYFlag"]) == 1)
                        {
                            this.ShowMessage("此挂板已留样");
                            //return;
                        }
                    }

                    LYFlag = SysConvert.ToInt32(dt.Rows[0]["LYFlag"]);             
                    //if (chkLY.Checked)
                    //{
                    //    LYFlag = 1;
                    //}
                    if (chkCancel.Checked)
                    {

                        if (!CheckCancelFind())
                        {
                            this.ShowMessage("条码不处于列表内，不能撤销归还");
                            return;

                        }
                        if (!CheckCancelStatus(GBCode))
                        {
                            return;
                        }

                        //int MainID = GetGBMainID(GBCode);//若是存在一条未保存和一条提交数据，会取第一行的MainID

                        //rule.RUpdate(GBCode, 0, MainID, LYFlag,FParamConfig.LoginID);
                        rule.RUpdate(GBCode, 0, -1, LYFlag, FParamConfig.LoginID); // 2013.12.26  sc
                        SetGridView1(GBCode);
                        ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { GBCode });
                        gridViewRowChanged1(gridView1);


                    }
                    else
                    {

                        if (!CheckJC())
                        {
                            return;
                        }
                        CreateDatable();
                        rule.RUpdate(GBCode, 1, -1, LYFlag, FParamConfig.LoginID);                       
                        gridViewRowChanged1(gridView1);


                    }

                    txtScan.Text = "";
                    txtScan.Focus();




                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 自定义方法



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            int MainID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["MainID"]));
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
            BindGrid2(MainID);
            GetItemLabel(GBCode);
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
        /// <summary>
        /// 根据条码得到图片
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private byte[] GetPic(string p_Code)
        {
            string sql = "SELECT GBPic2 FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return (byte[])dt.Rows[0]["GBPic2"];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 绑定GridView2
        /// </summary>
        /// <param name="MainID"></param>
        private void BindGrid2(int MainID)
        {
            string sql = "SELECT * FROM UV1_Dev_GBJCDts WHERE MainID="+SysString.ToDBString(MainID);
            sql += " AND GBStatusID="+SysString.ToDBString((int)EnumGBStatus.借出);
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }
       

        private bool CheckCancelStatus(string p_Code)
        {
            string sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                int GBStatusID = SysConvert.ToInt32(dt.Rows[0][0]);
                if (GBStatusID != (int)EnumGBStatus.归还)
                {
                    this.ShowMessage("挂板["+p_Code+"]不处于归还状态，不能撤销");
                    return false;
                }
                return true;
            }
            return false;
        }

        private int GetGBMainID(string GBCode)
        {
             for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(GBCode==SysConvert.ToString(gridView1.GetRowCellValue(i,"GBCode")))
                {
                    return SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                }

            }
            return 0;
        }

        /// <summary>
        /// 撤销归还后处理数据
        /// </summary>
        /// <param name="GBCode"></param>
        private void SetGridView1(string GBCode)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(GBCode==SysConvert.ToString(gridView1.GetRowCellValue(i,"GBCode")))
                {
                    gridView1.SetRowCellValue(i,"GBStatusID",(int)EnumGBStatus.借出);
                    gridView1.SetRowCellValue(i,"GHTime",null);
                    gridView1.SetRowCellValue(i,"GHOPID","");
                }

            }
        }

        /// <summary>
        /// 撤销归还操作时候的验证
        /// </summary>
        /// <returns></returns>
        private bool CheckCancelFind()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) == txtScan.Text.Trim())
                {
                    
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 归还操作时的验证
        /// </summary>
        /// <returns></returns>
        private bool CheckJC()
        {
            string sql = "SELECT JCTime FROM UV1_Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(txtScan.Text.Trim());
            sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
            sql += " AND ISNULL(SubmitFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                txtScan.Text = "";
                this.ShowMessage("挂板:["+txtScan.Text.Trim()+"]没有处于借出状态的借出单，请查看");
                return false;
            }
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                txtScan.Text = "";
                this.ShowMessage("挂板:[" + txtScan.Text.Trim() + "]借出单数据异常，存在两张以上的处于借出状态的同一挂板，请查看");
                return false ;
            }
        }

        /// <summary>
        /// 创建DataTable
        /// </summary>
        private void CreateDatable()
        {
            string[] ItemStr = GetItemStr(txtScan.Text.Trim());
            DataRow row = dtCode.NewRow();
            row["GBCode"] = txtScan.Text.Trim();
            row["GHTime"] = DateTime.Now.Date;
            row["GHOPID"] = FParamConfig.LoginID;
            row["MainID"]=GetMainID(txtScan.Text.Trim());
            row["JCTime"]=GetJCTime(txtScan.Text.Trim());
            row["GBStatusID"] = (int)EnumGBStatus.归还;
            row["LYFlag"] = LYFlag;

            row["ItemCode"] = ItemStr[0];
            row["ItemName"] = ItemStr[1];
            row["ItemStd"] = ItemStr[2];
            row["ItemModel"] = ItemStr[3];
            row["MWidth"] = ItemStr[4];
            row["MWeight"] = ItemStr[5];
            row["ColorNum"] = ItemStr[6];
            row["ColorName"] = ItemStr[7];

            dtCode.Rows.Add(row);
            gridView1.GridControl.DataSource = dtCode;
            gridView1.GridControl.Show();
            ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { txtScan.Text.Trim() });

        }

        private string[] GetItemStr(string p_GBCode)
        {
            string[] ItemStr=new string[8];
            string sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,MWidth,MWeight,ColorNum,ColorName FROM UV1_Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_GBCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                ItemStr[0] = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                ItemStr[1] = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                ItemStr[2] = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                ItemStr[3] = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                ItemStr[4] = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                ItemStr[5] = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                ItemStr[6] = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                ItemStr[7] = SysConvert.ToString(dt.Rows[0]["ColorName"]);
            }
            return ItemStr;
        }

      


        /// <summary>
        /// 得到借出单ID
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private int GetMainID(string p_Code)
        {
            string sql = "SELECT MainID FROM Dev_GBJCDts WHERE GBCode="+SysString.ToDBString(p_Code);
            sql += " AND GBStatusID="+SysString.ToDBString((int)EnumGBStatus.借出);
            DataTable dt = SysUtils.Fill(sql);
            return SysConvert.ToInt32(dt.Rows[0]["MainID"]);
        }

        /// <summary>
        /// 得到借出时间
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private DateTime GetJCTime(string p_Code)
        {
            string sql = "SELECT JCTime FROM Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(p_Code);
            sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
            DataTable dt = SysUtils.Fill(sql);
            return SysConvert.ToDateTime(dt.Rows[0]["JCTime"]);
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
            string GBCodeStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) != "")
                {
                    if (GBCodeStr != "")
                    {
                        GBCodeStr += ",";
                    }
                    GBCodeStr +=SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")));
                }
            }

            if (GBCodeStr == "")
            {
                this.ShowMessage("没有归还数据");
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

            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE GBCode IN(" + GBCodeStr + ")";
            DataTable dt = SysUtils.Fill(sql);
            dt.Columns.Add("LYFlag",typeof(int));
            foreach (DataRow dr in dt.Rows)
            {
                sql = "SELECT LYFlag FROM UV1_Dev_GBJCDts WHERE GBCode="+SysString.ToDBString(dr["GBCode"].ToString());
                sql += " AND SubmitFlag=1 ";
                sql += " AND GBStatusID="+SysString.ToDBString((int)EnumGBStatus.归还);
                sql += " ORDER BY GHTime,FormNo DESC ";
                DataTable dto = SysUtils.Fill(sql);
                if (dto.Rows.Count > 0)
                {
                    dr["LYFlag"] = SysConvert.ToInt32(dto.Rows[0][0]);
                }
                else
                {
                    dr["LYFlag"] = 0;
                }
            }
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
                base.btnPreview_Click(sender, e);

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
                base.btnPrint_Click(sender, e);

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
                base.btnDesign_Click(sender, e);
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