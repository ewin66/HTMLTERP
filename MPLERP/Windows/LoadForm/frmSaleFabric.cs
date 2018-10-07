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
    public partial class frmSaleFabric : BaseForm
    {
        public frmSaleFabric()
        {
            InitializeComponent();
        }


        int SaleItemType = (int)EnumItemType.面料;


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




                SaleOrder entity = new SaleOrder();
                entity.ID = m_ID;
                entity.SelectByID();

                 SaleItemType = Common.GetSaleItemTypeByID(entity.SaleFlowModuleID);



                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
                {
                }
                else
                {
                    gridView1.Columns["CPItemCode"].Visible = false;
                }
                BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void BindGrid()
        {
            SaleOrderDts entitydts = new SaleOrderDts();
            entitydts.ID = m_DID;
            entitydts.SelectByID();
            string sql = "SELECT * FROM Sale_SaleOrderFabric WHERE Mainid=" + SysString.ToDBString(m_ID);
            sql += " AND DID=" + SysString.ToDBString(m_DID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)//找到算料的绑定算料内容
            {
                gridView1.GridControl.DataSource = SysUtils.Fill(sql);
                gridView1.GridControl.Show();

                decimal TotalQty = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    TotalQty += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                }
                txtTotalQty.Text = TotalQty.ToString();
            }
            else// 没有找到算料的绑定原始信息
            {
              
                DataTable dto = new DataTable();

                if (SaleItemType == (int)EnumItemType.坯布)
                {
                    sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,ItemUnit FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entitydts.ItemCode);
                    dto = SysUtils.Fill(sql);
                }
                else//成品
                {
                    sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,ItemUnit FROM Data_Item WHERE ItemCode IN (SELECT GreyFabItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entitydts.ItemCode) + ")";
                    dto = SysUtils.Fill(sql);
                }

                if (dto.Rows.Count != 0) /// 查找成品对应的坯布的信息
                {
                    for (int i = 0; i < dto.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5009)))//面料的坯布启用可替换坯布功能,影响到订单坯布算料、坯布采购、织造等
                        {
                            dr["CPItemCode"] = entitydts.ItemCode;
                            dr["CPItemName"] = entitydts.ItemName;
                            dr["CPItemStd"] = entitydts.ItemStd;
                            dr["CPItemModel"] = entitydts.ItemModel;
                        }

                        dr["ItemCode"] = SysConvert.ToString(dto.Rows[i]["ItemCode"]);
                        dr["ItemName"] = SysConvert.ToString(dto.Rows[i]["ItemName"]);
                        dr["ItemStd"] = SysConvert.ToString(dto.Rows[i]["ItemStd"]);
                        dr["ColorName"] = entitydts.ColorName;//坯布带入颜色
                        dr["MWidth"] = entitydts.MWidth;//坯布带入门幅
                        dr["MWeight"] = entitydts.MWeight;//坯布带入克重
                        dr["Needle"] = entitydts.Needle;//坯布带入针形
                        dr["ItemModel"] = SysConvert.ToString(dto.Rows[i]["ItemModel"]);
                        dr["SQty"] = entitydts.Qty;
                        dr["RQty"] = entitydts.Qty;
                        dr["Unit"] = SysConvert.ToString(dto.Rows[i]["ItemUnit"]); //"KG";
                        dr["SO"] = m_SO;
                        dt.Rows.Add(dr);
                    }
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
                SaleOrderFabricRule rule = new SaleOrderFabricRule();
                SaleOrderFabric[] entityDts = GetEntityDts();
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

        private SaleOrderFabric[] GetEntityDts()
        {
            int Index = 0;
            int Row = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(SysConvert.ToString(gridView1.GetRowCellValue(i,"ItemCode"))!="")
                {
                    Index++;
                }
            }
            SaleOrderFabric[] entity=new SaleOrderFabric[Index];
            Index=0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Row = i + 1;
                if(SysConvert.ToString(gridView1.GetRowCellValue(i,"ItemCode"))!="")
                {
                   
                    entity[Index] = new SaleOrderFabric();
                    entity[Index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i,"ID"));
                    entity[Index].SelectByID();
                    entity[Index].CPItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemCode"));
                    entity[Index].CPItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemModel"));
                    entity[Index].CPItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemName"));
                    entity[Index].CPItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "CPItemStd"));

                    entity[Index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entity[Index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entity[Index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entity[Index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entity[Index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entity[Index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entity[Index].BL = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "BL"));
                    entity[Index].SH = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SH"));
                    entity[Index].SQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SQty"));
                    entity[Index].Qty = entity[Index].SQty * (1m + entity[Index].SH / 100m);
                    entity[Index].Needle = SysConvert.ToString(gridView1.GetRowCellValue(i, "Needle"));
                    entity[Index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entity[Index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));

                    if (entity[Index].BL > 0)
                    {
                        entity[Index].Qty = entity[Index].Qty * entity[Index].BL;
                        entity[Index].RQty = entity[Index].SQty * entity[Index].BL;
                    }
                    else
                    {
                        entity[Index].RQty = entity[Index].SQty;
                    }
                    entity[Index].SO = m_SO;
                    entity[Index].DID = DID;
                    if (entity[Index].SH == 0 && SaleItemType==(int)EnumItemType.面料)
                    {
                        throw new BaseException("请输入第" + SysString.ToDBString(Row) + "行的损耗");
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
                int IID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                string sql = "DELETE Sale_SaleOrderFabric WHERE ID=" + SysString.ToDBString(IID);
                SysUtils.ExecuteNonQuery(sql);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txt_Click(object sender, EventArgs e)
        {
            try
            {

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
                decimal SQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"SQty"));
                decimal BL = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BL"));
                decimal SH = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SH"));
                decimal RQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RQty"));
                decimal Qty = SQty * (1m + SH / 100m);
                if (BL > 0)
                {
                    Qty = Qty * BL;
                    RQty = SQty * BL;

                }
                else
                {
                    RQty = SQty;
                }
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle,"Qty",Qty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "RQty", RQty);
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