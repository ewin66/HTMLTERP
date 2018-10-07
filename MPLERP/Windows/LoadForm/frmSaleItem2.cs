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



namespace MLTERP
{
    public partial class frmSaleItem2 : BaseForm
    {
        public frmSaleItem2()
        {
            InitializeComponent();
        }

        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private int m_DID;
        public int DID
        {
            get
            {
                return m_DID;
            }
            set
            {
                m_DID = value;
            }
        }

        private string m_SO;
        public string SO
        {
            get
            {
                return m_SO;
            }
            set
            {
                m_SO = value;
            }
        }


        private string MessStr=string.Empty;
        


        
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {

                ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI


                Common.BindBuyType(drpBuyType, true);
                BindGrid();

            }
            catch (Exception E)
            {
               
            }
        }

        private void BindGrid()
        {
            string sql = "SELECT * FROM Sale_SaleOrderItem WHERE Mainid=" + SysString.ToDBString(m_ID);
            sql += " AND DID="+SysString.ToDBString(m_DID);
            sql += " ORDER BY ItemCode";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();
                decimal TotalQty = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    TotalQty += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                }
                txtTotalQty.Text = TotalQty.ToString();
            }
            else
            {
                sql = "SELECT DtsItemCode,DtsItemName,DtsItemStd,DtsItemModel,Percentage,Qty FROM UV1_Sale_SaleOrderDtsItem";
                sql += " WHERE MainID=" + SysString.ToDBString(ID);
                sql += " AND ID="+SysString.ToDBString(DID);
                //sql += " GROUP BY DtsItemCode,DtsItemName,DtsItemStd";
                DataTable dto = SysUtils.Fill(sql);
                for (int i = 0; i < dto.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ItemCode"] = SysConvert.ToString(dto.Rows[i]["DtsItemCode"]);
                    dr["ItemName"] = SysConvert.ToString(dto.Rows[i]["DtsItemName"]);
                    dr["ItemStd"] = SysConvert.ToString(dto.Rows[i]["DtsItemStd"]);
                    dr["ItemModel"] = SysConvert.ToString(dto.Rows[i]["DtsItemModel"]);
                    dr["SQty"] = SysConvert.ToDecimal(dto.Rows[i]["Qty"]);
                    //dr["Unit"] ="KG";
                    dr["SO"] = m_SO;
                    dr["Per"] = SysConvert.ToDecimal(dto.Rows[i]["Percentage"]);
                    dr["RQty"] = SysConvert.ToDecimal(dr["Qty"]);// *((SysConvert.ToDecimal(dr["Per"]) / 100m));
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6427)))//织损默认设置3%
                    {
                        dr["SH"] = 3;
                    }
                    dt.Rows.Add(dr);
                }
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();

            }
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception E)
            {
                
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoad.Focus();
                SaleOrder entity = new SaleOrder();
                entity.ID = m_ID;
                entity.SelectByID();
                if (entity.SubmitFlag == 1 || entity.SubmitFlag == 2)
                {
                    this.ShowMessage("订单已提交，不能修改");
                    return;
                }

                SaleOrderItemRule rule = new SaleOrderItemRule();
                SaleOrderItem[] entityDts = GetEntityDts();
                decimal TotalRer = 0;
                for (int i = 0; i < entityDts.Length; i++)
                {
                    TotalRer += entityDts[i].Per;
                }
                if (TotalRer != 100)
                {
                    this.ShowMessage("纱线的比例合计不为100，请检查！");
                    return;
                }
                if (MessStr != "")
                {
                    this.ShowMessage(MessStr);
                    return;
                }
                rule.RUpdate(m_ID,m_DID,entityDts);
                BindGrid();
                this.ShowInfoMessage("保存成功，请确认！");
                //this.Close();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private SaleOrderItem[] GetEntityDts()
        {
            int Index = 0;
            int Row = 0;
            MessStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(SysConvert.ToString(gridView1.GetRowCellValue(i,"ItemCode"))!="")
                {
                    Index++;
                }
            }
            SaleOrderItem[] entity = new SaleOrderItem[Index];
            Index=0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Row = i + 1;
                if(SysConvert.ToString(gridView1.GetRowCellValue(i,"ItemCode"))!="")
                {
                  
                    entity[Index] = new SaleOrderItem();
                    entity[Index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i,"ID"));
                    entity[Index].SelectByID();
                    entity[Index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entity[Index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entity[Index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entity[Index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entity[Index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entity[Index].Unit = "KG";// SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entity[Index].SH = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SH"));
                    entity[Index].BL = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "BL"));
                    entity[Index].SH2 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SH2"));
                    entity[Index].SH3 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SH3"));
                    entity[Index].SQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SQty"));
                  
                    entity[Index].Per = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Per"));
                    //entity[Index].RQty = entity[Index].SQty * (entity[Index].Per/100m);
                    //if (entity[Index].BL > 0)
                    //{
                    //    entity[Index].RQty = entity[Index].BL * entity[Index].RQty;
                    //}
                    entity[Index].BuyType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "BuyType"));
                    if(entity[Index].BuyType==0)
                    {
                        MessStr="第"+Row.ToString()+"行 纱线采购类型 未选择，请选择！";
                       
                    }
                    if (entity[Index].Per==0)
                    {
                        MessStr="第" + Row.ToString() + "行 纱线比例 未输入，请选择！";
                        
                    }
                    if (entity[Index].BuyType == (int)EnumBuyType.色纱采购 && entity[Index].ColorName == "")
                    {
                        MessStr="第" + Row.ToString() + "行 颜色 未输入，请选择！";
                    }
                    //if (entity[Index].SH3 == 0)
                    //{
                    //    MessStr = "第" + Row.ToString() + "行 染布损耗 未输入，请选择！";
                    //}
                    entity[Index].SO = m_SO;
                    entity[Index].DID = DID;
                    entity[Index].Qty = entity[Index].SQty * (entity[Index].Per / 100m) * (1m + (entity[Index].SH / 100m)) * (1m + (entity[Index].SH2 / 100m))*(1m + (entity[Index].SH3 / 100m));
                    if (entity[Index].BL > 0)
                    {
                        entity[Index].Qty = entity[Index].Qty * entity[Index].BL;
                        entity[Index].RQty = entity[Index].SQty * entity[Index].BL;
                    }
                    else
                    {
                        entity[Index].RQty = entity[Index].SQty;
                    }
                    Index++;

                }
            }

            return entity;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SaleOrder entity = new SaleOrder();
                entity.ID = m_ID;
                entity.SelectByID();
                if (entity.SubmitFlag == 1)
                {
                    this.ShowMessage("订单已提交，不能修改");
                    return;
                }
                this.BaseFocusLabel.Focus();
                int IID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ID"));
                string sql = "DELETE Sale_SaleOrderItem WHERE ID=" + SysString.ToDBString(IID);
                SysUtils.ExecuteNonQuery(sql);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal SQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SQty"));
                decimal BL = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BL"));
                decimal Per = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Per"));
                decimal SH = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SH"));
                decimal SH2 = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SH2"));
                decimal SH3 = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SH3"));
                decimal Qty = 0;
                decimal RQty = 0;
                //RQty = SQty * (Per / 100m) * (1m + (SH3 / 100m));
                Qty = SQty * (Per / 100m) * (1m + (SH / 100m)) * (1m + (SH2 / 100m)) * (1m + (SH3 / 100m));
                if (BL > 0)
                {
                    Qty = Qty * BL;
                    RQty = SQty * BL;

                }
                else
                {
                    RQty = SQty;
                }
                Qty = SysConvert.ToDecimal(Qty, 0);
                RQty = SysConvert.ToDecimal(RQty, 0);
                
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", Qty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "RQty", RQty);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       


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

        private void txtPer_Leave(object sender, EventArgs e)
        {
             try
            {
                txt_Leave(null,null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                Common.DelDtRow((DataTable)gridView1.GridControl.DataSource, gridView1.FocusedRowHandle);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void mcopy_Click(object sender, EventArgs e)
        {
            try
            {

                //DataTable dtSource = (DataTable)gridView1.GridControl.DataSource;
                //this.BaseFocusLabel.Focus();
                //string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                //string ItemName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemName"));
                //string ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemStd"));
                //decimal SH = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SH"));
                //decimal Per = 100 - SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Per"));
                //decimal SQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SQty"));
                //decimal Qty = SQty * (1 + SH / 100m) * (Per / 100m);
                //txt_Leave(null, null);

                //DataRow dr = dtSource.NewRow();
                //dr["ItemCode"] = ItemCode;
                //dr["ItemName"] = ItemName;
                //dr["ItemStd"] = ItemStd;
                //dr["SH"] = SH;
                //dr["SQty"] = SQty;
                //dr["Unit"] = "KG";
                //dtSource.Rows.Add(dr);
                //gridView1.GridControl.DataSource = dtSource;
                //gridView1.GridControl.Show();

                this.BaseFocusLabel.Focus();
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                string ItemName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemName"));
                string ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemStd"));
                decimal SQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SQty"));
                Common.DataTableAddRow((DataTable)gridView1.GridControl.DataSource, gridView1.FocusedRowHandle);
                DataTable dtSource = (DataTable)gridView1.GridControl.DataSource;
                foreach (DataRow dr in dtSource.Rows)
                {
                    if (SysConvert.ToString(dr["ItemCode"]) == "")
                    {
                        dr["ItemCode"] = ItemCode;
                        dr["ItemName"] = ItemName;
                        dr["ItemStd"] = ItemStd;
                        dr["SQty"] = SQty;
                    }
                }
                gridView1.GridControl.DataSource = dtSource;
                gridView1.GridControl.Show();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.RowHandle % 2 == 0)
                    {
                        e.Appearance.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
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