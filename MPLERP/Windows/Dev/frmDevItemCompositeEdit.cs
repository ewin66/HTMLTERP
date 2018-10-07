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
    /// 功能：产品管理明细
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmDevItemCompositeEdit : frmAPBaseUIFormEdit
    {
        public frmDevItemCompositeEdit()
        {
            InitializeComponent();
        }

        public int rowhandle = 1;
        #region 自定义虚方法定义[需要修改]     
       
        public int GBFormStatus = (int)EnumFormStatus.查询;
        public int CheckFlag = 0;
        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            //设置物品信息
          
            Item entity = new Item();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();


            HTDataFormNo = entity.ItemCode;


            txtGoodsCode.Text = entity.GoodsCode.ToString();
            txtItemCode.Text = entity.ItemCode.ToString();
            txtItemModel.Text = entity.ItemModel.ToString();
            txtItemModelEn.Text = entity.ItemModelEn.ToString();
            txtItemName.Text = entity.ItemName.ToString();
            txtItemStd.Text = entity.ItemStd.ToString();
            txtItemNameEn.Text = entity.ItemNameEn.ToString();
            drpItemUnit.Text = entity.ItemUnit.ToString();
            txtJWM.Text = entity.JWM.ToString();
            txtMWeight.Text = entity.MWeight.ToString();
            txtMWidth.Text = entity.MWidth.ToString();
            txtNeedle.Text = entity.Needle.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtSeason.Text = entity.Season.ToString();
            txtWeightUnit.Text = entity.WeightUnit.ToString();
            txtYarnStd.Text = entity.YarnStd.ToString();
            txtZWZZ.Text = entity.ZWZZ.ToString();
            drpItemClassID.EditValue = entity.ItemClassID;
            //drpItemTypeID.EditValue = entity.ItemTypeID;
            drpMLDLCode.EditValue = entity.MLDLCode;
            drpMLDL.EditValue = entity.MLDLCode;
            drpVendorID.EditValue = entity.VendorID;
            drpUseable.EditValue = entity.UseableFlag;
            drpPFlag.EditValue = entity.PFlag;
            drpXFlag.EditValue = entity.XFlag;
            SetCheckMLLB(chkLamp1, entity.MLLBCode);
            txtItemDate.DateTime = entity.ItemDate;
            txtWeb.Text = entity.Web;
            txtPerMiWeight.Text = entity.PerMiWeight.ToString();



            if (!findFlag)
            {

            }
           
            //绑定明细信息
            BindGrid();// 绑定挂板
            BindGrid2();// 绑定成份信息
            BindGrid3();// 绑定颜色信息
            BindGrid4();// 绑定颜色信息

        }

        /// <summary>
        /// 绑定挂板
        /// </summary>
        private void BindGrid()
        {
            ItemGBRule rule = new ItemGBRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 绑定成份信息
        /// </summary>
        private void BindGrid2()
        {

            ItemCompositeDtsRule rule = new ItemCompositeDtsRule();
            DataTable dt = rule.RShowView(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }


        /// <summary>
        /// 绑定坯布成份信息
        /// （加载坯布时用到）
        /// </summary>
        private void BindGrid2LoadPB(int p_PBItemID)
        {

            //ItemDtsRule rule = new ItemDtsRule();
            //DataTable dt = rule.RShow(" AND MainID=" + p_PBItemID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));
            //if (dt.Rows.Count != 0)//有原料信息才绑定
            //{
            //    gridView2.GridControl.DataSource = dt;
            //    gridView2.GridControl.Show();
            //}
        }

        /// <summary>
        /// 绑定颜色信息
        /// </summary>
        private void BindGrid3()
        {
           
            //ItemColorDtsRule rule = new ItemColorDtsRule();
            //DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3));
            //gridView3.GridControl.DataSource = dt;
            //gridView3.GridControl.Show();
        }

        /// <summary>
        /// 绑定类别信息
        /// </summary>
        private void BindGrid4()
        {
            //ItemLBDtsRule rule = new ItemLBDtsRule();
            //DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView4));
            //gridView4.GridControl.DataSource = dt;
            //gridView4.GridControl.Show();
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {

            ItemRule rule = new ItemRule();
            Item entity = GetItem();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);


            ProductCommon.FormNoCtlEditSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.面料, p_Flag);
            ProcItemCompositeDtsDefault();
           
        }


        /// <summary>
        ///  处理默认数据源
        ///  因为特殊性
        /// </summary>
        void ProcItemCompositeDtsDefault()
        {
            if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//处理默认数据源
            {
                DataTable dt = (DataTable)gridView2.GridControl.DataSource;

                if (dt.Rows.Count<2)
                {
                    WCommon.AddDtRow(dt, 2);
                }
                if (SysConvert.ToInt32(dt.Rows[0]["ComTypeID"]) == 0)//面布
                {
                    dt.Rows[0]["ComTypeID"] = 1;
                }
                if (SysConvert.ToInt32(dt.Rows[1]["ComTypeID"]) == 0)//底布
                {
                    dt.Rows[1]["ComTypeID"] = 2;
                }
            }
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {

            this.HTDataTableName = "Data_Item";
            this.HTDataDts = gridView2;
            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView1, gridView2 };
            HTDataAddFlag = false;
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI
            gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(frmAPBaseUIFormEdit_RowCellStyle);

            Common.BindVendorID(drpVendorID,true);

            //Common.BindMLDL(drpMLDLCode, true);     //绑定面料大类
            //Common.BindMLDL(drpMLDL, true);
            //Common.BindItemClass(drpItemClassID,(int)EnumItemType.面料,true);
            ////Common.BindItemType(drpItemTypeID, true);
            ////Common.BindNeedle(txtNeedle, true);

            //Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitFab", true);
            //Common.BindCLS(txtNeedle, "Enum_Needle", "Needle", true);
            //Common.BindSeason(txtSeason, true);
         
            //Common.BindMLLB(chkLamp1, true);
          
         
            SetTabIndex(0, groupControlMainten);
          
            txtItemCode.Properties.ReadOnly = true;

            //new ItemProcResLookUP(BaseFocusLabel, gridView2, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.纱线 }, "", "ItemStd", true, true);
            IniUCPicture();
            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);

           
        }

        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindMLDL(drpMLDLCode, true);     //绑定面料大类
            Common.BindMLDL(drpMLDL, true);
            Common.BindItemClass(drpItemClassID, (int)EnumItemType.面料, true);
            //Common.BindItemType(drpItemTypeID, true);
            //Common.BindNeedle(txtNeedle, true);

            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitFab", true);
            Common.BindCLS(txtNeedle, "Enum_Needle", "Needle", true);
            Common.BindSeason(txtSeason, true);

            Common.BindMLLB(chkLamp1, true); 
            new ItemProcResLookUP(BaseFocusLabel, gridView2, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.面料 }, "", "ItemStd", true, true);
          

        }

        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "DtsID"));

                    ItemGB entityGB = new ItemGB();
                    entityGB.ID = ID;
                    entityGB.SelectByID();

                    List<Image> lstimage = new List<Image>();
                    if (entityGB.GBPic.Length > 10)
                    {
                        lstimage.Add(TemplatePic.ByteToImage(entityGB.GBPic));
                    }
                    ucPictureView1.UCDataLstImage = lstimage;
                }
                else
                {
                    List<Image> lstimage = new List<Image>();
                    ucPictureView1.UCDataLstImage = lstimage;
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 获取面料类别
        /// </summary>
        /// <param name="p_CheckList"></param>
        /// <returns></returns>
        private string GetCheckMLLB(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            string MLLB = string.Empty;
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                if (p_CheckList.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (MLLB == string.Empty)
                    {
                        MLLB += p_CheckList.GetItemValue(i).ToString();
                    }
                    else
                    {
                        MLLB += "," + p_CheckList.GetItemValue(i).ToString();
                    }

                }
            }
            return MLLB;
        }

        /// <summary>
        /// 设置所属公司类型
        /// </summary>
        private void SetCheckMLLB(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList, string p_CheckValus)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }
            string[] VenodrTypes = p_CheckValus.Split(',');

            foreach (string dr in VenodrTypes)
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr == p_CheckList.GetItemValue(i).ToString())//
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }
        
        /// <summary>
        /// 新增初始化
        /// </summary>
        public override void IniInsertSet()
        {
            txtWeightUnit.Text = "g/m";
            txtItemCode_DoubleClick(null, null);
         
            drpUseable.EditValue = 1;
            drpPFlag.EditValue = 0;
            drpXFlag.EditValue = 0;
            txtItemDate.DateTime = DateTime.Now.Date;


            drpItemUnit.Text = ProductParamSet.GetStrValueByID(5001);//面料默认单位设置

         
        }

        /// <summary>
        /// 得到产品类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkLamp1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                string outstr = string.Empty;
                for (int i = 0; i < chkLamp1.ItemCount; i++)
                {
                    if (chkLamp1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        if (outstr != string.Empty)
                        {
                            outstr += ",";
                        }
                        outstr += chkLamp1.GetItemText(i).ToString();
                    }
                }
                drpLamp1.EditValue = outstr;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 双击得到产品编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {


                    ProductCommon.FormNoIniSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.面料);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 新增修改删除
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入产品编码");
                txtItemCode.Focus();
                return false;
            }

            //if (txtItemName.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入成份");
            //    txtItemName.Focus();
            //    return false;
            //}

            //if (txtItemStd.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入规格");
            //    txtItemStd.Focus();
            //    return false;
            //}

            //if (txtItemModel.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入品名");
            //    txtItemModel.Focus();
            //    return false;
            //}

            if (SysConvert.ToInt32(drpItemClassID.EditValue)==0)
            {
                this.ShowMessage("请选择面料类型");
                drpItemClassID.Focus();
                return false;
            }

            //if (!CheckCorrectItemDts())
            //{
            //    this.ShowMessage("原料比例之和不等于100");
            //    return false;
            //}
           
            return true;
        }
        /// <summary>
        /// 校验成份比例
        /// </summary>
        /// <returns></returns>
        public bool CheckCorrectItemDts()
        {
            //decimal Percentage = 0;
            //int Num = 0;
            //for (int i = 0; i < gridView2.RowCount; i++)
            //{
            //    if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
            //    {
            //        Percentage += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Percentage"));
            //        Num++;
            //    }
            //}
            //if (Num > 0)
            //{
            //    if (Percentage != 100)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }


        //public bool CheckCorrectItemDts()
        //{
        //    decimal Percentage = 0;
        //    int Num = 0;
        //    for (int i = 0; i < gridView2.RowCount; i++)
        //    {
        //        if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
        //        {
        //            Percentage += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Percentage"));
        //            Num++;
        //        }
        //    }
        //    if (Num > 0)
        //    {
        //        if (Percentage != 100 && Percentage != 200)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
           
            ItemRule rule = new ItemRule();
            Item entity = GetItem();
            //ItemGB[] entityItemGB = GetItemGB();
            ItemCompositeDts[] entityItemCompositeDts = GetItemCompositeDts();
            //ItemLBDts[] entityItemLBDts = GetItemLBDts();
            //ItemColorDts[] entityItemColorDts = GetItemColorDts();
            rule.RAdd(entity, entityItemCompositeDts);
            return entity.ID;
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ItemRule rule = new ItemRule();
            Item entity = GetItem();
            //ItemGB[] entityItemGB = GetItemGB();
            ItemCompositeDts[] entityItemCompositeDts = GetItemCompositeDts();
            //ItemLBDts[] entityItemLBDts = GetItemLBDts();
            //ItemColorDts[] entityItemColorDts = GetItemColorDts();
            rule.RUpdate(entity, entityItemCompositeDts);
          
        }

        /// <summary>
        /// 物品实体
        /// </summary>
        /// <returns></returns>
        private Item GetItem()
        {
            Item entity = new Item();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ItemCode = txtItemCode.Text.Trim();
            entity.VendorID =SysConvert.ToString(drpVendorID.EditValue);
            entity.MLDLCode = SysConvert.ToString(drpMLDLCode.EditValue);           
            entity.ItemTypeID = (int)EnumItemType.面料;
            entity.GoodsCode = txtGoodsCode.Text.Trim();
            entity.ItemClassID = SysConvert.ToInt32(drpItemClassID.EditValue);
            entity.ItemName = txtItemName.Text.Trim();
            entity.ItemStd = txtItemStd.Text.Trim();
            entity.ItemModel = txtItemModel.Text.Trim();
            entity.ItemNameEn = txtItemNameEn.Text.Trim();
            entity.ItemModelEn = txtItemModelEn.Text.Trim();
            entity.ItemUnit = drpItemUnit.Text.Trim();
            entity.MWidth =txtMWidth.Text.Trim();
            entity.MWeight =txtMWeight.Text.Trim();
            entity.WeightUnit = txtWeightUnit.Text.Trim();
            entity.YarnStd = txtYarnStd.Text.Trim();
            entity.JWM = txtJWM.Text.Trim();
            entity.ZWZZ = txtZWZZ.Text.Trim();
            entity.Season = txtSeason.Text.Trim();
            entity.Needle = txtNeedle.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.UseableFlag = SysConvert.ToInt32(drpUseable.EditValue);
            entity.XFlag = SysConvert.ToInt32(drpXFlag.EditValue);
            entity.PFlag = SysConvert.ToInt32(drpPFlag.EditValue);
            entity.MLLBCode = GetCheckMLLB(chkLamp1);
            entity.MLLBName = drpLamp1.Text.ToString();
            entity.ItemDate = txtItemDate.DateTime.Date;
            entity.Web = txtWeb.Text.Trim();
            entity.PerMiWeight = SysConvert.ToDecimal(txtPerMiWeight.Text.Trim());
            entity.FabricTypeID = (int)EnumFabricType.复合面料;

            return entity;

        }

        /// <summary>
        /// 获取挂板信息实体
        /// </summary>
        /// <returns></returns>
        private ItemGB[] GetItemGB()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) != string.Empty)
                {
                    Num++;
                }
            }
            ItemGB[] entitydts = new ItemGB[0];
            int index = 0;
            for (int i = 0; i < 0; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) != string.Empty)
                {
                    entitydts[index] = new ItemGB(); 
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                  
                    index++;
                    
                }
            }
            return entitydts;
        }


     

        /// <summary>
        /// 获取颜色信息实体
        /// </summary>
        /// <returns></returns>
        private ItemColorDts[] GetItemColorDts()
        {
            int Num = 0;
            //for (int i = 0; i < gridView3.RowCount; i++)
            //{
            //    if (SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum")) != string.Empty || SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName")) != string.Empty)
            //    {
            //        Num++;
            //    }
            //}
            ItemColorDts[] entitydts = new ItemColorDts[Num];
            //int index = 0;
            //for (int i = 0; i < gridView3.RowCount; i++)
            //{
            //    if (SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum")) != string.Empty || SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName")) != string.Empty)
            //    {
            //        entitydts[index] = new ItemColorDts();
            //        entitydts[index].ID = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "ID"));
            //        entitydts[index].SelectByID();
            //        entitydts[index].MainID = HTDataID;
            //        entitydts[index].Seq = i + 1;


            //        entitydts[index].ColorNum = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum"));
            //        entitydts[index].ColorName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName"));
            //        entitydts[index].BuyPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "BuyPrice"));
            //        entitydts[index].BuyPriceDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "BuyPriceDate"));
            //        entitydts[index].SalePrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "SalePrice"));
            //        entitydts[index].SalePriceDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "SalePriceDate"));

            //        entitydts[index].DHPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "DHPrice"));
            //        entitydts[index].YBPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "YBPrice"));
            //        entitydts[index].XHPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "XHPrice"));

            //        entitydts[index].Remark = SysConvert.ToString(gridView3.GetRowCellValue(i, "Remark"));
            //        index++;

            //    }
            //}
            return entitydts;
        }



        /// <summary>
        /// 获取颜色信息实体
        /// </summary>
        /// <returns></returns>
        private ItemCompositeDts[] GetItemCompositeDts()
        {
            int Num = 0;
            DataTable dt = (DataTable)gridView2.GridControl.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (SysConvert.ToString(dt.Rows[i]["ItemCode"]) != string.Empty || SysConvert.ToString(dt.Rows[i]["ComTypeID"]) != string.Empty)
                {
                    Num++;
                }
            }
            ItemCompositeDts[] entitydts = new ItemCompositeDts[Num];
            int index = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (SysConvert.ToString(dt.Rows[i]["ItemCode"]) != string.Empty || SysConvert.ToString(dt.Rows[i]["ComTypeID"]) != string.Empty)
                {
                    entitydts[index] = new ItemCompositeDts();
                    entitydts[index].ID = SysConvert.ToInt32(dt.Rows[i]["ID"]);
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].ComTypeID = SysConvert.ToInt32(dt.Rows[i]["ComTypeID"]);
                    entitydts[index].ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                    //entitydts[index].Remark = SysConvert.ToString(dt.Rows[i]["Remark"]);
                    index++;

                }
            }
            return entitydts;
        }


        /// <summary>
        /// 获取类别信息实体
        /// </summary>
        /// <returns></returns>
        private ItemLBDts[] GetItemLBDts()
        {
            int Num = 0;
            string[] mllb = GetCheckMLLB(chkLamp1).Split(',');
            Num = mllb.Length;
            ItemLBDts[] entitydts = new ItemLBDts[Num];
            int index = 0;
            for (int i = 0; i < Num; i++)
            {
                entitydts[index] = new ItemLBDts();
                entitydts[index].MainID = HTDataID;
                entitydts[index].Seq = i + 1;
                entitydts[index].SelectByID();
                entitydts[index].MLLBCode =mllb[i].ToString();

                index++;

                
            }
            return entitydts;
        }
        #endregion

     

        #region 设置面料类别
        /// <summary>
        /// 设置选择
        /// </summary>
        private void SetRangeTo(string SelectRangeTo)
        {
            for (int i = 0; i < chkLamp1.ItemCount; i++)
            {
                chkLamp1.SetItemCheckState(i, CheckState.Unchecked);
            }
            string[] tempRangeTo = SelectRangeTo.Split(',');
            for (int k = 0; k < tempRangeTo.Length; k++)
            {
                for (int i = 0; i < chkLamp1.ItemCount; i++)
                {
                    if (tempRangeTo[k] == chkLamp1.GetItemText(i).ToString())
                    {
                        chkLamp1.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }
      
        #endregion


        #region 自定义方法
        /// <summary>
        /// 初始化图片控件
        /// </summary>
        void IniUCPicture()
        {
            ucPictureView1.UCReadOnly = true;
            ucPictureView1.UCInputPictureMultiFlag = false;//单图模式
            ucPictureView1.UCInputMainType = 2;//图片模式
            ucPictureView1.UCInputDBSaveType = 1;//同一数据只有Update  

            ucPictureView1.UCDBMainIDFieldName = "";
            ucPictureView1.UCDBRemarkFieldName = "";
            ucPictureView1.UCDBTableName = "Data_ItemGB";
            ucPictureView1.UCDBPicFieldName = "GBPic";
            ucPictureView1.UCDBSmallPicFieldName = "GBPic2";
            ucPictureView1.UCDataID = 0;
            ucPictureView1.UCAct();
        }
        #endregion






        #region 其它事件

        private void lbtnCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (drpVendorID.Text.Trim() == "" && txtGoodsCode.Text.Trim() == "")
                    {
                        this.ShowMessage("请输入厂码或商品码后重新检测");
                        return;
                    }
                    CheckFlag = 1;
                    string sql = "SELECT * FROM Data_Item WHERE VendorID=" + SysString.ToDBString(drpVendorID.Text.Trim());
                    sql += " AND GoodsCode=" + SysString.ToDBString(txtGoodsCode.Text.Trim());
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        frmLoadMLItem frm = new frmLoadMLItem();
                        frm.dt = dt;
                        frm.ShowDialog();
                        if (frm.ID != 0)
                        {
                            this.NavigateWin("frmDevItemEdit", frm.ID.ToString(), FormStatus.查询);
                        }
                    }
                    else
                    {
                        this.ShowMessage("没有检测到相同厂码和商品码的产品，请放心添加");

                    }
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

        private void txtGBItemName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (GBFormStatus == (int)EnumFormStatus.查询)
                {
                    return;
                }
                string itemname = string.Empty;
                string sql = "Select * from Data_ItemDts Where MainID=" + HTDataID.ToString();
                DataTable dts = SysUtils.Fill(sql);
                if (dts.Rows.Count > 0)
                {
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {
                        if (itemname != string.Empty)
                        {
                            itemname += " ";
                        }
                        itemname += dts.Rows[i]["DtsItemName"].ToString() + "" + dts.Rows[i]["Percentage"].ToString()+ "%";

                    }
                }
               
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存产品后添加挂板！");
                    return;
                }

                frmGBAdd frm = new frmGBAdd();
                frm.ID = HTDataID;
                frm.Owner = this;
                frm.ShowDialog();
                BindGrid();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "DtsID" }, new string[1] { frm.DID.ToString() });
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请保存产品后修改！");
                    return;
                }
                this.BaseFocusLabel.Focus();
                int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"DtsID"));
                if (ID > 0)
                {
                    frmGBAdd frm = new frmGBAdd();
                    frm.ID = HTDataID;
                    frm.DID = ID;
                    frm.Owner = this;
                    frm.ShowDialog();
                    BindGrid();
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "DtsID" }, new string[1] { ID.ToString() });
                }
                else
                {
                    this.ShowMessage("请选择需要修改的挂板！");
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (HTDataID == 0)
            {
                this.ShowMessage("请保存产品后删除！");
                return;
            }

            if (MessageBox.Show("您真的要删除吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.BaseFocusLabel.Focus();
                int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                if (ID > 0)
                {
                    string sql = "DELETE Data_ItemGB WHERE ID=" + SysString.ToDBString(ID);
                    SysUtils.ExecuteNonQuery(sql);
                    this.ShowInfoMessage("删除成功！");
                    BindGrid();
                }
            }
           
        }


        /// <summary>
        /// 加载坯布信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGreyFabItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.HTItemTypeID = (int)EnumItemType.坯布;
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {
                        string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(frm.GBID[0]));
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            //txtGreyFabItemCode.Text = dt.Rows[0]["ItemCode"].ToString();

                            //txtGreyItemDes.Text = Common.GetItemDesc(txtGreyFabItemCode.Text.Trim());

                            BindGrid2LoadPB(SysConvert.ToInt32(dt.Rows[0]["ID"]));//绑定原料信息

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




    }
}