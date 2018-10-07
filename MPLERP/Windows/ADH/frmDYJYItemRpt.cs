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
    ///出入库报表 王焕梅 2012.05.07 
    /// </summary>
    public partial class frmDYJYItemRpt : frmAPBaseUIRpt
    {
        public frmDYJYItemRpt()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtVendorID.Text.Trim() != "")
            {
                tempStr += " AND ( DVendorID LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
                tempStr += " or DVendorName LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
                tempStr += " or VendorName LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
                tempStr += " )";
            }
            if (SysConvert.ToInt32(drpDHID.EditValue) != 0)
            {
                tempStr += " AND DataDHID="+SysString.ToDBString(SysConvert.ToInt32(drpDHID.EditValue));
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (SysConvert.ToInt32(drpLevel.EditValue) != 0)
            {
                tempStr += " AND LevelID="+SysString.ToDBString(SysConvert.ToInt32(drpLevel.EditValue));
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }
            if (chkDYFlag.Checked)
            {
                tempStr += " AND ISNULL(DYFlag,0)=1 ";
            }
            if (chkJYFlag.Checked)
            {
                tempStr += " AND ISNULL(JYFlag,0)=1 ";
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT ItemCode,ISN,GoodsCode,MWidth,MWeight,ColorNum,ColorName,ItemName,ItemVendorID,ItemStd,COUNT(ISN) Qty,SUM(Qty) Qty2  FROM UV1_ADH_CheckFormDts WHERE 1=1 ";
            sql += HTDataConditionStr;
            sql += "group by  ItemCode,ISN,GoodsCode,MWidth,MWeight,ColorNum,ColorName,ItemName,ItemVendorID,ItemStd order by Qty desc";
            DataTable dt = SysUtils.Fill(sql);
            SetGridView(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
          

        }

        private void SetGridView(DataTable dt)
        {
            dt.Columns.Add("Qty3",typeof(decimal));
            foreach (DataRow dr in dt.Rows)
            {
                string ItemCode = SysConvert.ToString(dr["ItemCode"]);
                string ColorNum = SysConvert.ToString(dr["ColorNum"]);
                string ColorName = SysConvert.ToString(dr["ColorName"]);
                string ColorStr = "";
                if (ColorNum != ColorName)
                {
                    ColorStr = ColorNum + ColorName;
                }
                else
                {
                    ColorStr = ColorNum;
                }
                string sql = "";
                if (ColorStr == "")
                {
                    sql = "SELECT SUM(Qty) Qty FROM WH_Storge  WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                    sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                    sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                    DataTable dto = SysUtils.Fill(sql);
                    if (dto.Rows.Count > 0)
                    {
                        dr["Qty3"] = SysConvert.ToDecimal(dto.Rows[0][0]);
                    }
                }
                else 
                {
                    if (ColorNum == "" || ColorName == "")
                    {
                        sql = "SELECT SUM(Qty) Qty FROM WH_Storge  WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                        sql += " AND( ColorNum=" + SysString.ToDBString(ColorStr);
                        sql += " or ColorName=" + SysString.ToDBString(ColorStr) + ")";
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count > 0)
                        {
                            dr["Qty3"] = SysConvert.ToDecimal(dto.Rows[0][0]);
                        }
                    }
                    else if(ColorNum!=""&&ColorName!="")
                    {
                        sql = "SELECT SUM(Qty) Qty FROM WH_Storge  WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                        sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                        sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count > 0)
                        {
                            dr["Qty3"] = SysConvert.ToDecimal(dto.Rows[0][0]);
                        } 
                    }
                }
               
                
               
            }
        }

       
       

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
          //  this.HTDataTableName = "Data_OP";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindDHID(drpDHID, this.FormListAID, false);
            Common.BindADHLevel(drpLevel, true);
            Common.BindOP(drpSaleOPID, true);
            new VendorProc(drpVendorID);
            btnQuery_Click(null, null);
            



        }

       
        #endregion


       

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQOPID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 留样打印

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

            DataTable dt=(DataTable)gridView1.GridControl.DataSource;

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType,dt);

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