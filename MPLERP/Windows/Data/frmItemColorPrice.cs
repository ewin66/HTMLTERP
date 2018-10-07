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
    public partial class frmItemColorPrice : frmAPBaseUIRpt
    {
        public frmItemColorPrice()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtItemCode.Text.Trim() != "")//��ѯ��
            {
               tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (txtItemStd.Text.Trim() != "")//��ѯ��
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtItemStd.Text.Trim() + "%");
            }
            if (txtVendorID.Text.Trim() != "")
            {
                tempStr += " AND VendorID LIKE " + SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }
            if (txtMLDL.Text.Trim() != "")
            {
                tempStr += " AND MLDLCode LIKE " + SysString.ToDBString("%"+txtMLDL.Text.Trim()+"%");
            }
            if (txtItemNameEn.Text.Trim() != "")
            {
                tempStr += " AND ItemNameEn LIKE " + SysString.ToDBString("%"+txtItemNameEn.Text.Trim()+"%");
            }
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
            if (txtNeedle.Text.Trim() != "")
            {
                tempStr += " AND Needle LIKE " + SysString.ToDBString("%" + txtNeedle.Text.Trim() + "%");
            }
         
          
            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
           

            if (txtMLLBCode.Text.Trim() != "")
            {
                tempStr += " AND MLLBName LIKE " + SysString.ToDBString("%" + txtMLLBCode.Text.Trim() + "%");
            }
            if (chkSalePriceDate.Checked)
            {
                tempStr += " AND SalePriceDate BETWEEN " + SysString.ToDBString (txtSaleDateS.DateTime) + " AND " + SysString.ToDBString (txtSaleDateE.DateTime);
            }

            if (chkYB.Checked)
            {
                tempStr += " AND ID IN (SELECT MainID FROM Data_ItemColorDtsHis)";
            }

            if (chkBuyDate.Checked)
            {
                tempStr += " AND ID IN (SELECT MainID FROM Data_ItemColorDtsHis WHERE 1=1";
                tempStr += " AND BuyPriceDate BETWEEN "+SysString.ToDBString(txtBuyPriceDateS.DateTime)+" AND "+SysString.ToDBString(txtBuyPriceDateE.DateTime);
                tempStr += " )";
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = string.Empty;
            sql = "SELECT * FROM Data_Item WHERE 1=1";
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
           
        }

        /// <summary>
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            //ProcessGrid.SetGridEdit(HTDataList, new string[] { "SalePrice" }, true);
        }

        public override  void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPBPrice.Text.Trim() == "")
                {
                    this.ShowMessage("�������������");
                    txtPBPrice.Focus();
                    return;
                }
                if (txtColorPrice.Text.Trim() == "")
                {
                    this.ShowMessage("������Ⱦɫ����");
                    txtColorPrice.Focus();
                    return;
                }
                if (txtShrinkage.Text.Trim() == "")
                {
                    this.ShowMessage("����������");
                    txtShrinkage.Focus();
                    return;
                }
                if (txtZLPrice.Text.Trim() == "")
                {
                    this.ShowMessage("�������������");
                    txtZLPrice.Focus();
                    return;
                }
                TotalPriceRMB.Text = SysConvert.ToString(SysConvert.ToDecimal(txtPBPrice.Text.Trim()) 
                    + SysConvert.ToDecimal(txtColorPrice.Text.Trim()) * SysConvert.ToDecimal(txtShrinkage.Text.Trim())
                    + SysConvert.ToDecimal(txtZLPrice.Text.Trim()) + SysConvert.ToDecimal(txtCBPrice.Text.Trim()));
                TotalPriceUSB.Text = SysConvert.ToString((SysConvert.ToDecimal(txtPBPrice.Text.Trim()) 
                    + SysConvert.ToDecimal(txtColorPrice.Text.Trim()) * SysConvert.ToDecimal(txtShrinkage.Text.Trim()) 
                    + SysConvert.ToDecimal(txtZLPrice.Text.Trim()) 
                    + SysConvert.ToDecimal(txtCBPrice.Text.Trim())) / SysConvert.ToDecimal(txtExchangeRate.Text.Trim()));
                int rowhandele = gridView1.FocusedRowHandle;    // ��ȡ��ǰ��
             
               
                string sql = string.Empty;
                sql = "UPDATE Data_Item SET PBPrice=" + SysConvert.ToDecimal(txtPBPrice.Text.Trim());
                sql += ",ColorPrice=" + SysConvert.ToDecimal(txtColorPrice.Text.Trim());
                sql += ",Shrinkage=" + SysConvert.ToDecimal(txtShrinkage.Text.Trim());
                sql += ",ZLPrice=" + SysConvert.ToDecimal(txtZLPrice.Text.Trim());
                sql += ",TotalPriceUSB=" + SysConvert.ToDecimal(((SysConvert.ToDecimal(txtPBPrice.Text.Trim())
                    + SysConvert.ToDecimal(txtColorPrice.Text.Trim()) * SysConvert.ToDecimal(txtShrinkage.Text.Trim())
                    + SysConvert.ToDecimal(txtZLPrice.Text.Trim())
                    + SysConvert.ToDecimal(txtCBPrice.Text.Trim())) / SysConvert.ToDecimal(txtExchangeRate.Text.Trim())),2);
                sql += ",ExchangeRate=" + SysConvert.ToDecimal(txtExchangeRate.Text.Trim());
                sql += ",TotalPriceRMB=" + SysConvert.ToDecimal((SysConvert.ToDecimal(txtPBPrice.Text.Trim())
                    + SysConvert.ToDecimal(txtColorPrice.Text.Trim()) * SysConvert.ToDecimal(txtShrinkage.Text.Trim())
                    + SysConvert.ToDecimal(txtZLPrice.Text.Trim()) + SysConvert.ToDecimal(txtCBPrice.Text.Trim())),2);
                sql += ",Remark=" + SysString.ToDBString(txtRemark.Text.Trim());
                sql += ",SalePrice=" + SysConvert.ToDecimal(txtSalePrice.Text.Trim());
                sql += ",CBPrice=" + SysConvert.ToDecimal(txtCBPrice.Text.Trim());
                sql += ",JGPrice=" + SysConvert.ToDecimal(txtJGPrice.Text.Trim());
                sql += ",RFPrice=" + SysConvert.ToDecimal(txtRFPrice.Text.Trim());
                sql += ",ZXBJDate=" + "'"+ txtZXBJDate.DateTime+"'";
                sql += ",TotalPrice=" + SysConvert.ToDecimal(txtTotalPrice.Text.Trim());

                sql += " WHERE ID=" + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));

                ItemColorDtsHisRule rule2 = new ItemColorDtsHisRule();
                ItemColorDtsHis entity2 = new ItemColorDtsHis();
                entity2.MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                entity2.Seq = 1;
                entity2.PBPrice = SysConvert.ToDecimal(txtPBPrice.Text.Trim());
                entity2.ColorPrice = SysConvert.ToDecimal(txtColorPrice.Text.Trim());
                entity2.Shrinkage = SysConvert.ToDecimal(txtShrinkage.Text.Trim());
                entity2.ZLPrice = SysConvert.ToDecimal(txtZLPrice.Text.Trim());
                entity2.TotalPriceUSB = SysConvert.ToDecimal(txtPBPrice.Text.Trim()) + SysConvert.ToDecimal(txtColorPrice.Text.Trim()) * SysConvert.ToDecimal(txtShrinkage.Text.Trim()) + SysConvert.ToDecimal(txtZLPrice.Text.Trim());
                entity2.ExchangeRate = SysConvert.ToDecimal(txtExchangeRate.Text.Trim());
                entity2.TotalPriceRMB = (SysConvert.ToDecimal(txtPBPrice.Text.Trim()) + SysConvert.ToDecimal(txtColorPrice.Text.Trim()) * SysConvert.ToDecimal(txtShrinkage.Text.Trim()) + SysConvert.ToDecimal(txtZLPrice.Text.Trim())) * SysConvert.ToDecimal(txtExchangeRate.Text.Trim());

                entity2.SalePrice = SysConvert.ToDecimal(txtSalePrice.Text.Trim());
                entity2.CBPrice = SysConvert.ToDecimal(txtCBPrice.Text.Trim());
                entity2.JGPrice = SysConvert.ToDecimal(txtJGPrice.Text.Trim());
                entity2.RFPrice = SysConvert.ToDecimal(txtRFPrice.Text.Trim());
                entity2.ZXBJDate = txtZXBJDate.DateTime;
                entity2.TotalPrice = SysConvert.ToDecimal(txtTotalPrice.Text.Trim());

                DataTable dt = SysUtils.Fill(sql);
                gridView1.GridControl.DataSource = dt;
                //gridView1.GridControl.Show();
                rule2.RAdd(entity2);
                BindGrid();
                gridView1.FocusedRowHandle = rowhandele;  // ��λ��ԭ���ĵ�ǰ��
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private ItemColorDts getEntity()
        {
            int id = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));  // ȡ��itemColor���ID
            ItemColorDts entity = new ItemColorDts();
            entity.ID = id;
            entity.SelectByID();
         
            return entity;     

        }

        public void btnQuery_Click()
        {
            try 
            {
                GetCondtion();
                BindGrid ();
            }

            catch 
            { 

            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            //LYGLRule rule = new LYGLRule();
            //LYGL entity = EntityGet();
            //rule.RDelete(entity);
            

        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ItemColorDtsHis";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
           // this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2, gridView3 };
            this.ToolBarItemAdd(28, ToolButtonName.btnSave.ToString(), "����", false, btnSave_Click);

            txtSaleDateS.DateTime = DateTime.Now.AddHours(-3).Date;
            txtSaleDateE.DateTime = DateTime.Now.Date;
            //txtQShipDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            //txtQShipDateE.DateTime = DateTime.Now.Date;

            //Common.BindEnumUnit(txtUnit, true);
            Common.BindCLS(txtUnit, "Data_Item", "ItemUnitFab", true);
            txtBuyPriceDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtBuyPriceDateE.DateTime = DateTime.Now.Date;
            txtZXBJDate.DateTime = DateTime.Now.Date;
            btnQuery_Click(null, null);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
        }


        ///// <summary>
        /////ͨ�� ��������ʵ��
        ///// 
        ///// </summary>
        //private void gridViewRowChanged1(object sender)
        //{
        //    try
        //    {
        //        ColumnView view = sender as ColumnView;
        //        string ItemCode= SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
        //        string ColorNum= SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
        //        string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));
        //        string sql = "SELECT * FROM UV1_Sale_QuotedPriceDts WHERE ItemCode="+SysString.ToDBString(ItemCode);
        //        sql += " AND ColorNum="+SysString.ToDBString(ColorNum);
        //        sql += " AND ColorName="+SysString.ToDBString(ColorName);
        //        DataTable dt = SysUtils.Fill(sql);
        //        gridView3.GridControl.DataSource = dt;
        //        gridView3.GridControl.Show();
                
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        #endregion
       
        #region �Զ��巽��
        /// <summary>
        /// ����ʷGrid
        /// </summary>
        public void BindGridHis(int p_MainID,string p_ColorNum)
        {
            string sql = string.Empty;

            sql = "SELECT * FROM Data_ItemColorDtsHis WHERE 1=1 ";
            sql += " AND MainID=" + SysString.ToDBString(p_MainID);
            sql += " ORDER BY ID DESC";
            DataTable dt2 = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt2;
            gridView2.GridControl.Show();



        }

        #endregion


        #region �����¼�

       

        public override void gridViewRowChanged1(object sender)
        {
            try
            {

                base.gridViewRowChanged1(sender);
                ColumnView view = sender as ColumnView;

                Item entity = new Item();
                entity.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                entity.SelectByID();

                txtPBPrice.Text = SysConvert.ToString(entity.PBPrice);
                txtColorPrice.Text = SysConvert.ToString(entity.ColorPrice);
                txtZLPrice.Text = SysConvert.ToString(entity.ZLPrice);
                txtShrinkage.Text = SysConvert.ToString(entity.Shrinkage);
                TotalPriceUSB.Text = SysConvert.ToString(entity.TotalPriceUSB);
                TotalPriceRMB.Text = SysConvert.ToString(entity.TotalPriceRMB);
                txtExchangeRate.Text = SysConvert.ToString(entity.ExchangeRate);
                txtCBPrice.Text = SysConvert.ToString(entity.CBPrice);
                txtRemark.Text = SysConvert.ToString(entity.Remark);
              

                BindGridHis(SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")),SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum")));

                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));
                string sql = "SELECT * FROM UV1_Sale_QuotedPriceDts WHERE ItemCode=" + SysString.ToDBString(ItemCode);
                //sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                sql += " ORDER BY MakeDate DESC";
                DataTable dt = SysUtils.Fill(sql);
                gridView3.GridControl.DataSource = dt;
                gridView3.GridControl.Show();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void expandableSplitter2_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {

        }





        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        ///
          
        //# region ���ʵ��
        //private Item EntityGet()                      
        //{   
        //    int index = GetDataCompleteNum();
        //    Item[] entity = new Item[index];
        //    indexer = 0;
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    { 
        //        if(CheckDataCompleteDts(i))
        //        {
        //         entity[index] = new Item();
        //         entity[index].ID = HTDataID;
        //         entity[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
        //         entity[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));
        //         entity[index].MLDLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "MLDLCode"));
        //         entity[index].MLLBCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "MLLBCode"));
        //         entity[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
        //         entity[index].ItemTypeID = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemTypeID"));
        //         entity[index].ItemClassID = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemClassID"));
        //         entity[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
        //         entity[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
        //         entity[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
        //         entity[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
        //         entity[index].ItemNameEn = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemNameEn"));
        //         entity[index].ItemModelEn = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModelEn"));
        //         entity[index].ItemUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemUnit"));
        //         entity[index].ItemAttnCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemAttnCode"));
        //         index++;
        //        }
        //      }
        //    return entity ;
        //}
       
        //private ItemColorDts EntitydtsGet()
        //{
        //    int index = GetDataCompleteNum();
        //    ItemColorDts[] entitydts = new ItemColorDts[index];
        //    indexer = 0;
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (CheckDataCompleteDts(i))
        //        {
        //            entitydts[index] = new ItemColorDts();
        //            entitydts[index].Seq = i +1;
        //            entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
        //            entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));
        //            entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
        //            entitydts[index].BuyPrice = SysConvert.ToString(gridView1.GetRowCellValue(i, "BuyPrice"));
        //            entitydts[index].BuyPriceDate = SysConvert.ToString(gridView1.GetRowCellValue(i, "BuyPriceDate"));
        //            entitydts[index].SalePrice = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SalePrice"));
        //            entitydts[index].SalePriceDate = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SalePriceDate"));
        //            entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                  
        //            index++;
        //        }
        //    }
        //    return entitydts;
        //}
       #endregion 

    }
}