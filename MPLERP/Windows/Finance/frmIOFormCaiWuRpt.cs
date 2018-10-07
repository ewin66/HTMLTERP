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
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 仓库财务报表
    /// 
    /// </summary>
    public partial class frmIOFormCaiWuRpt : frmAPBaseUIRpt
    {
        public frmIOFormCaiWuRpt()
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtOrderDateS.DateTime)+" AND "+SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue)!= string.Empty)
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }

           

            if(txtInvoiceNo.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND InvoiceNo LIKE "+SysString.ToDBString("%"+txtInvoiceNo.Text.Trim()+"%");
            }

            if(txtQDtsSO.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DtsSO LIKE "+SysString.ToDBString("%"+txtQDtsSO.Text.Trim()+"%");
            }

            if(txtItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if(txtGoodsCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if(txtColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if(txtColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

          

            if(txtQBatch.Text.Trim()!=string.Empty)
            {
                tempStr += " AND Batch=" + SysString.ToDBString("%"+txtQBatch.Text.Trim()+"%");
            }

            if(txtQJarNum.Text.Trim()!=string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID="+SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }
            if (chkDZ.Checked)
            {
                tempStr += " AND ISNULL(DZFlag,0)=1 ";
            }
            if (chkNODZ.Checked)
            {
               // tempStr += " AND ISNULL(DZQty,0)=0";
                tempStr += " AND abs(ISNULL(Qty,0))>abs(ISNULL(DZQty,0))";
            }
            if (chkKP.Checked)
            {
                tempStr += " AND ISNULL(InvoiceQty,0)<>0";
            }
            if (chkNOKP.Checked)
            {
                tempStr += " AND ISNULL(Qty,0)+ISNULL(YQQty,0)-abs(ISNULL(InvoiceQty,0))<>0";
            }
            if (FormListAID != 0)
            {
                tempStr += " AND SubType IN (SELECT ID FROM Enum_FormList WHERE DZType=" + SysString.ToDBString(FormListAID) + ")";
            }
            //if (this.FormListAID == (int)EnumDZType.销售)
            //{
            //    tempStr += " AND SubType IN (SELECT ID FROM Enum_FormList WHERE DZType="+SysString.ToDBString((int)EnumDZType.销售)+")";
            //}
            //if (this.FormListAID == (int)EnumDZType.采购)
            //{
            //    tempStr += " AND SubType IN (SELECT ID FROM Enum_FormList WHERE DZType=" + SysString.ToDBString((int)EnumDZType.采购)+")";
            //}
            //if (this.FormListAID == (int)EnumDZType.加工)
            //{
            //    tempStr += " AND SubType IN (SELECT ID FROM Enum_FormList WHERE DZType=" + SysString.ToDBString((int)EnumDZType.加工) + ")";
            //}
          
            if (chkYKP.Checked&&!chkNOKP.Checked)
            {
                tempStr += " AND 1=2";
            }
            tempStr += " AND ISNULL(SubmitFlag,0)=1";
            tempStr += " AND ISNULL(Qty,0)+ISNULL(YQQty,0)<>0";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormRule rule = new IOFormRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("AQty", "ISNULL(Qty,0)+ISNULL(YQQty,0) AQty").Replace("NOKPQty", "0.00 NOKPQty").Replace("NoKPAmount","0.00 NoKPAmount"));
            SetGrid(dt);
            if (chkYKP.Checked)
            {
                SetGrid2(dt);
            }
            
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 增加与开票信息
        /// </summary>
        /// <param name="dt"></param>
        private void SetGrid2(DataTable dt)
        {
            string sql = "SELECT * FROM UV1_Finance_InvoiceYOperationDts WHERE KPType=2 AND SubmitFlag>0 ";
            if (txtFormNo.Text.Trim() != "")
            {
                sql += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }
            if (chkOrderDate.Checked)
            {
                sql += " AND MakeDate BETWEEN "+SysString.ToDBString(txtOrderDateS.DateTime)+" AND "+SysString.ToDBString(txtOrderDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                sql += " AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if (txtItemCode.Text.Trim() != "")
            {
                sql += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (txtColorNum.Text.Trim() != "")
            {
                sql += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }
            if (txtColorName.Text.Trim() != "")
            {
                sql += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                sql += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (this.FormListAID !=0)
            {
                sql += " AND DZTypeID=" + SysString.ToDBString(FormListAID);
            }
         
            //if (this.FormListAID == (int)EnumVendorType.客户)
            //{
            //    sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.销售);
            //}
            //if (this.FormListAID == (int)EnumVendorType.工厂)
            //{
            //    sql += " AND DZTypeID=" + SysString.ToDBString((int)EnumDZType.采购);
            //}
            if (chkNOKP.Checked)
            {
                sql += " AND DtsID NOT IN (SELECT DLOADID FROM UV1_Finance_InvoiceOperationDts WHERE DLOADNO='预开票' AND SubmitFlag>0) ";
            }
            DataTable dtYKP = SysUtils.Fill(sql);
            for (int i = 0; i < dtYKP.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["FormNM"] = "预开票";
                dr["VendorAttn"] = SysConvert.ToString(dtYKP.Rows[i]["VendorAttn"]);
                dr["ItemCode"] = SysConvert.ToString(dtYKP.Rows[i]["ItemCode"]);
                dr["GoodsCode"] = SysConvert.ToString(dtYKP.Rows[i]["GoodsCode"]);
                dr["ColorNum"] = SysConvert.ToString(dtYKP.Rows[i]["ColorNum"]);
                dr["ColorName"] = SysConvert.ToString(dtYKP.Rows[i]["ColorName"]);
                dr["FormNo"] = SysConvert.ToString(dtYKP.Rows[i]["FormNo"]);
                dr["FormDate"] = SysConvert.ToDateTime(dtYKP.Rows[i]["MakeDate"]);
                dr["DtsOrderFormNo"] = SysConvert.ToString(dtYKP.Rows[i]["DtsOrderNo"]);
                dr["InVoiceQty"] = SysConvert.ToDecimal(dtYKP.Rows[i]["Qty"]);
                dr["InvoiceAmount"] = SysConvert.ToDecimal(dtYKP.Rows[i]["Amount"]);
                dt.Rows.Add(dr);
               
            }
        }

        private void SetGrid(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["Qty"] = GetQty(dr);
                dr["Amount"] = GetAmount(dr);
                dr["AQty"] = GetAQty(dr);
                dr["NOKPQty"] = SysConvert.ToDecimal(dr["AQty"]) - SysConvert.ToDecimal(dr["InvoiceQty"]);
                dr["NoKPAmount"] = SysConvert.ToDecimal(dr["SinglePrice"]) * SysConvert.ToDecimal(dr["NOKPQty"]);

                //dr["Amount"] = GetAmount(dr);
            }
        }

        private decimal GetAmount(DataRow dr)
        {
            string sql = "SELECT DZFlag FROM Enum_FormList WHERE ID=" + SysConvert.ToInt32(dr["SubType"]);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0][0]) == (int)EnumDZFlag.对帐负)
                {
                    return SysConvert.ToDecimal(0-SysConvert.ToDecimal(dr["Amount"]));
                }
                else
                {
                    return SysConvert.ToDecimal(dr["Amount"]);
                }
            }
            return SysConvert.ToDecimal(dr["Amount"]);
        }

        private decimal GetQty(DataRow dr)
        {
           string sql = "SELECT DZFlag FROM Enum_FormList WHERE ID=" + SysConvert.ToInt32(dr["SubType"]);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0][0]) == (int)EnumDZFlag.对帐负)
                {
                    return SysConvert.ToDecimal(0-SysConvert.ToDecimal(dr["Qty"]));

                }
                else
                {
                    return SysConvert.ToDecimal(dr["Qty"]);
                }
            }
            return SysConvert.ToDecimal(dr["Qty"]);
        }

        private decimal GetAQty(DataRow dr)
        {
            string sql = "SELECT DZFlag FROM Enum_FormList WHERE ID=" + SysConvert.ToInt32(dr["SubType"]);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0][0]) == (int)EnumDZFlag.对帐负)
                {
                    return SysConvert.ToDecimal(0 - SysConvert.ToDecimal(dr["AQty"]));

                }
                else
                {
                    return SysConvert.ToDecimal(dr["AQty"]);
                }
            }
            return SysConvert.ToDecimal(dr["AQty"]);
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;

            if (FormListAID != 0)
            {
                int DZType = FormListAID;
                Common.BindVendorByDZTypeID(drpVendorID, DZType, true);
            }
           
           
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            Common.BindSubTypeByDZType(drpSubType, this.FormListAID, true);
  
            Common.BindOP(drpSaleOPID, true);
            new VendorProc(drpVendorID);
            //this.ToolBarItemAdd(28, ToolButtonName.btnToExcel.ToString(), "导出EXCEL", false, btnToExcel_Click);
            btnQuery_Click(null, null);
            
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;      
            return entity;
        }



        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { }, true);//"SelectFlag"
        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string p_ExportFile = string.Empty;
                DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                DataTable dtnew = dt.Clone();
                if (gridView1.RowFilter != string.Empty)
                {
                    DataRow[] rows = dt.Select(gridView1.RowFilter);

                    foreach (DataRow row in rows)
                    {
                        dtnew.ImportRow(row);
                    }

                }
                else
                {
                    dtnew = dt;
                }

                TemplateExcel.CaiWuWHInOutToExcel(dtnew, "", out p_ExportFile);
                this.OpenFileNoConfirm(p_ExportFile);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 仓库出入库财务报表打印

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
            IOFormRule rule = new IOFormRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr,"*");
            SetGrid(dt);
            DataTable dtnew = dt.Clone();
            if (gridView1.RowFilter != string.Empty)
            {
                DataRow[] rows = dt.Select(gridView1.RowFilter);

                foreach (DataRow row in rows)
                {
                    dtnew.ImportRow(row);
                }

            }
            else
            {
                dtnew = dt;
            }

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtnew);

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



      

        #region 检索相关方法

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
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
                    GetCondtion();
                    BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void txtQty_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"DtsID"));
                decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));
                frmShowQty frm = new frmShowQty();
                frm.ID = ID;
                frm.Qty = Qty;
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        
    }
}