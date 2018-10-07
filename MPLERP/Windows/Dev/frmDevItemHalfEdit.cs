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
    /// 功能：坯布管理明细
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmDevItemHalfEdit : frmAPBaseUIFormEdit
    {
        public frmDevItemHalfEdit()
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
            txtItemDate.DateTime = entity.ItemDate;


            drpMachine.EditValue = entity.Machine;
            txtTecDesc.Text = entity.TecDesc;

            if (!findFlag)
            {

            }
           
            //绑定明细信息
           
            BindGrid2();// 绑定成份信息

            BindGrid6();
           

        }

      

        /// <summary>
        /// 绑定成份信息
        /// </summary>
        private void BindGrid2()
        {

            ItemDtsRule rule = new ItemDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }




        /// <summary>
        /// 绑定工厂编码及报价
        /// </summary>
        private void BindGrid6()
        {

            ItemCodeFacDtsRule rule = new ItemCodeFacDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
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

            ProductCommon.FormNoCtlEditSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.半成品, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {

            this.HTDataTableName = "Data_Item";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };


            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5010)))//面料定义界面不要显示原料信息管理内容
            //{
            //    xtraTabPage1.PageVisible = false;
            //}

           
            
            //Common.BindVendorID(drpVendorID,true);

            //Common.BindMLDL(drpMLDLCode, true);     //绑定面料大类
            //Common.BindMLDL(drpMLDL, true);
            //Common.BindItemClass(drpItemClassID,(int)EnumItemType.坯布,true);
            ////Common.BindItemType(drpItemTypeID, true);
            ////Common.BindNeedle(txtNeedle, true);

            ////Common.BindEnumUnit(drpItemUnit, true);
            //Common.BindCLS(drpLoss,"Data_Item","Loss",true);

            //Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitFab", true);
            //Common.BindCLS(txtNeedle, "Enum_Needle", "Needle", true);
            //Common.BindSeason(txtSeason, true);
         
            //Common.BindMLLB(chkLamp1, true);
          
         
            SetTabIndex(0, groupControlMainten);
          
            txtItemCode.Properties.ReadOnly = true;

            //new ItemProcResLookUP(BaseFocusLabel, gridView2, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.纱线 }, "", "ItemStd", true, true);
            
            //gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            //gridViewBindEventA2(gridView1);

           
        }

        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindVendorID(drpVendorID, true);

            Common.BindMLDL(drpMLDLCode, true);     //绑定面料大类
            Common.BindMLDL(drpMLDL, true);
            Common.BindItemClass(drpItemClassID, (int)EnumItemType.半成品, true);
            Common.BindVendor(drpGridFactoryID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.供应商 }, true);
            //Common.BindItemType(drpItemTypeID, true);
            //Common.BindNeedle(txtNeedle, true);

            //Common.BindEnumUnit(drpItemUnit, true);
            Common.BindCLS(drpLoss, "Data_Item", "Loss", true);

            Common.BindMachine(drpMachine,true);

            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitFab", true);
            Common.BindCLS(txtNeedle, "Enum_Needle", "Needle", true);
            Common.BindSeason(txtSeason, true);

            Common.BindMLLB(chkLamp1, true); 
            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.纱线 }, "", "DtsItemModel", true, true);
            

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

            drpItemUnit.Text = ProductParamSet.GetStrValueByID(5002);//坯布默认单位设置
         
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
                    ProductCommon.FormNoIniSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.半成品);
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

            //if (txtItemModel.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入品名");
            //    txtItemModel.Focus();
            //    return false;
            //}

            //if (SysConvert.ToInt32(drpItemClassID.EditValue)==0)
            //{
            //    this.ShowMessage("请选择坯布类型");
            //    drpItemClassID.Focus();
            //    return false;
            //}

            //if (!CheckCorrectItemDts())
            //{
            //    this.ShowMessage("比例之和不等于100");
            //    return false;
            //}
           
            return true;
        }

        public bool CheckCorrectItemDts()
        {
            decimal Percentage = 0;
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    Percentage += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Percentage"));
                    Num++;
                }
            }
            if (Num > 0)
            {
                if (Percentage != 100)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
           
            ItemRule rule = new ItemRule();
            Item entity = GetItem();
            ItemGB[] entityItemGB = GetItemGB();
            ItemDts[] entityItemDts = GetItemDts();
            ItemLBDts[] entityItemLBDts = GetItemLBDts();
            ItemColorDts[] entityItemColorDts = GetItemColorDts();
            ItemCodeFacDts[] entityItemFacDts = GetItemCodeFacDts();
            rule.RAdd(entity, entityItemDts, entityItemColorDts, entityItemLBDts, null, null, entityItemFacDts);
            return entity.ID;
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ItemRule rule = new ItemRule();
            Item entity = GetItem();
            ItemGB[] entityItemGB = GetItemGB();
            ItemDts[] entityItemDts = GetItemDts();
            ItemLBDts[] entityItemLBDts = GetItemLBDts();
            ItemColorDts[] entityItemColorDts = GetItemColorDts();
            ItemCodeFacDts[] entityItemFacDts = GetItemCodeFacDts();
            rule.RUpdate(entity, entityItemDts, entityItemColorDts, entityItemLBDts, null, null, entityItemFacDts);
          
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
            entity.ItemTypeID = (int)EnumItemType.半成品;
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

            entity.Machine = SysConvert.ToString(drpMachine.EditValue);
            entity.TecDesc = txtTecDesc.Text.Trim();
            return entity;

        }

        /// <summary>
        /// 获取挂板信息实体
        /// </summary>
        /// <returns></returns>
        private ItemGB[] GetItemGB()
        {
            int Num = 0;
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) != string.Empty)
            //    {
            //        Num++;
            //    }
            //}
            ItemGB[] entitydts = new ItemGB[0];
            //int index = 0;
            //for (int i = 0; i < 0; i++)
            //{
            //    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) != string.Empty)
            //    {
            //        entitydts[index] = new ItemGB(); 
            //        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
            //        entitydts[index].SelectByID();
            //        entitydts[index].MainID = HTDataID;
            //        entitydts[index].Seq = i + 1;


                  
            //        index++;
                    
            //    }
            //}
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
        private ItemDts[] GetItemDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    Num++;
                }
            }
            ItemDts[] entitydts = new ItemDts[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    entitydts[index] = new ItemDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].DtsItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsItemCode"));
                    entitydts[index].DtsItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsItemName"));
                    entitydts[index].DtsItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsItemStd"));
                    entitydts[index].DtsItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsItemModel"));
                    entitydts[index].Percentage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Percentage"));
                    entitydts[index].Loss = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Loss"));
                    entitydts[index].PerMiWeight = SysConvert.ToDecimal(txtPerMiWeight.Text.Trim()) * (entitydts[index].Percentage / 100m) * (1 + entitydts[index].Loss);//SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "PerMiWeight"));


                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].MWeight2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight2"));
                    entitydts[index].FactoryID = SysConvert.ToString(gridView1.GetRowCellValue(i, "FactoryID"));
                    entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));
                    entitydts[index].Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Price"));
                    entitydts[index].FormDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FormDate"));
                    entitydts[index].ReqDate = SysConvert.ToString(gridView1.GetRowCellValue(i, "ReqDate"));
                    entitydts[index].MinQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MinQty"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));


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




        /// <summary>
        /// 获取供应商代码及报价
        /// </summary>
        /// <returns></returns>
        private ItemCodeFacDts[] GetItemCodeFacDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "FactoryID")) != string.Empty)
                {
                    Num++;
                }
            }
            ItemCodeFacDts[] entitydts = new ItemCodeFacDts[Num];
            int index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "FactoryID")) != string.Empty)
                {
                    entitydts[index] = new ItemCodeFacDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].FactoryID = SysConvert.ToString(gridView2.GetRowCellValue(i, "FactoryID"));
                    entitydts[index].FacItemCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "FacItemCode"));
                    entitydts[index].FacPrice = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "FacPrice"));
                    entitydts[index].FacPriceLimitDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "FacPriceLimitDate"));
                    entitydts[index].Remark = SysConvert.ToString(gridView2.GetRowCellValue(i, "Remark"));

                    entitydts[index].FormDate = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "FormDate"));
                    entitydts[index].VendorID = SysConvert.ToString(gridView2.GetRowCellValue(i, "VendorID"));
                    entitydts[index].Price = SysConvert.ToString(gridView2.GetRowCellValue(i, "Price"));
                    entitydts[index].SH = SysConvert.ToString(gridView2.GetRowCellValue(i, "SH"));
                    entitydts[index].ReqDate = SysConvert.ToString(gridView2.GetRowCellValue(i, "ReqDate"));
                    entitydts[index].MinQty = SysConvert.ToString(gridView2.GetRowCellValue(i, "MinQty"));
                    index++;

                }
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
                            this.NavigateWin("frmDevItemGrayEdit", frm.ID.ToString(), FormStatus.查询);
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

        private void groupControlMainten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void drpGridFactoryID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string VendorID = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "FactoryID"));
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "VendorID", VendorID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

      
      


       

        


    }
}