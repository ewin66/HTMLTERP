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
    public partial class frmDevItemFinishEdit : frmAPBaseUIFormEdit
    {
        public frmDevItemFinishEdit()
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
         
            drpItemName.EditValue = entity.ItemName.ToString();
            txtItemStd.Text = entity.ItemStd.ToString();
          
            drpItemUnit.Text = entity.ItemUnit.ToString();
         
            txtMWeight.Text = entity.MWeight.ToString();
            txtMWidth.Text = entity.MWidth.ToString();
          
            txtRemark.Text = entity.Remark.ToString();
      
            drpItemClassID.EditValue = entity.ItemClassID;
            //drpItemTypeID.EditValue = entity.ItemTypeID;
       
            drpUseable.EditValue = entity.UseableFlag;

            drpVendorID.EditValue = entity.VendorID;
        
            txtItemDate.DateTime = entity.ItemDate;
        
            txtPerMiWeight.Text = entity.PerMiWeight.ToString();

            txtGreyFabItemCode.Text = entity.GreyFabItemCode.ToString();
            txtShrinkage.Text = entity.Shrinkage.ToString();
            txtColorLoss.Text = entity.ColorLoss.ToString();
            txtLastLoss.Text = entity.LastLoss.ToString();

            txtGreyItemDes.Text = Common.GetItemDesc(txtGreyFabItemCode.Text.Trim());


            txtAttRSGYDesc.Text = entity.AttRSGYDesc;
            txtAttMachineDesc.Text = entity.AttMachineDesc;
            txtAttYarnDesc.Text = entity.AttYarnDesc;

            txtWeightUnit.Text = entity.WeightUnit.ToString();


            txtHZType.Text = entity.HZType;
            txtSalePrice.Text = entity.SalePrice.ToString();
            txtOrgan.Text = entity.Organ.ToString();
            txtSeason.Text = entity.Season.ToString();
            txtMinQty.Text = entity.MinQty.ToString();
            txtDeliveryTime.Text = entity.DeliveryTime.ToString();
            

        

            if (!findFlag)
            {

            }
           
            //绑定明细信息
            BindGird();
            BindGrid2();// 绑定成份信息
            BindGrid3();// 绑定颜色信息
            BindGrid4();// 绑定颜色信息
            BindGrid6();// 绑定颜色信息
            BindPic();


        }

        private void BindGird()
        {
            ItemCodeFacDtsRule rule = new ItemCodeFacDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void BindPic()
        {
            ItemPic entity = new ItemPic();
            entity.MainID = HTDataID;
            entity.Seq = 1;
            entity.SelectByID();
            if (entity.PicImage != null)
            {
                pictureBox1.Image = TemplatePic.ByteToImage(entity.PicImage);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }


        /// <summary>
        /// 绑定成份信息
        /// </summary>
        private void BindGrid2()
        {

            ItemDtsRule rule = new ItemDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }

        private void BindGrid6()
        {
            iniFiledSet();
            ItemAddRule rule = new ItemAddRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " AND ISNULL(FormID,0)=" + this.FormID + " AND ISNULL(FormAID,0)=" + this.FormListAID + " AND ISNULL(FormBID,0)=" + this.FormListBID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView6).Replace("BindType", "0 BindType"));
            Common.SetItemAdd(gridView6, dt);
            //gridView6.GridControl.DataSource = dt;
            //gridView6.GridControl.Show();
        }


        /// <summary>
        /// 绑定坯布成份信息
        /// （加载坯布时用到）
        /// </summary>
        private void BindGrid2LoadPB(int p_PBItemID)
        {

            ItemDtsRule rule = new ItemDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + p_PBItemID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));
            if (dt.Rows.Count != 0)//有原料信息才绑定
            {
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();
            }
        }

        /// <summary>
        /// 绑定颜色信息
        /// </summary>
        private void BindGrid3()
        {
           
            ItemColorDtsRule rule = new ItemColorDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3));
            gridView3.GridControl.DataSource = dt;
            gridView3.GridControl.Show();
        }

        /// <summary>
        /// 绑定类别信息
        /// </summary>
        private void BindGrid4()
        {

            ItemGreyFabReplaceRule rule = new ItemGreyFabReplaceRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView4));
            gridView4.GridControl.DataSource = dt;
            gridView4.GridControl.Show();
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


           // ProductCommon.FormNoCtlEditSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.面料, p_Flag);

            ProcessGrid.SetGridEdit(gridView6, new string[] { "Name" }, false);
            ProcessGrid.SetGridColumnReadOnly(gridView6, new string[] { "Name" }, true);



            txtGreyFabItemCode.Properties.ReadOnly = true;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {

            this.HTDataTableName = "Data_Item";
            this.HTDataDts = gridView6;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView1,gridView2, gridView3, gridView6 };
       

            Common.BindVendor(drpGridFactoryID,new int []{(int)EnumVendorType.工厂,(int)EnumVendorType.供应商},true);
         


            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5012)))//
            {
                btnCalc.Visible = true;
            }

         
         
            SetTabIndex(0, groupControlMainten);
          
            //txtItemCode.Properties.ReadOnly = true;

            Common.BindCLS(txtWeightUnit,"Data_Item","WeightUnit",true);
            Common.BindCLS(txtOrgan, "Data_Item", "Organ", true);

            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnit", true);

            gridViewBaseRowChangedA3 += new gridViewBaseRowChangedA(gridViewRowChanged3);
            gridViewBindEventA3(gridView6);

           
        }

        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
          
            Common.BindItemClass(drpItemClassID, (int)EnumItemType.面料, true);
            //Common.BindItemType(drpItemTypeID, true);
            //Common.BindNeedle(txtNeedle, true);

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.供应商 }, true);

            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitFab", true);
         
            WCommon.BindCLS(drpItemName, "Data_Item", "ItemName", true);
   
            new ItemProcResLookUP(BaseFocusLabel, gridView2, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.纱线 }, "", "ItemStd", true, true);

            new ItemProcResLookUP(BaseFocusLabel, gridView4, new string[3] { "GreyFabItemCode", "ItemName", "ItemStd" }, drpGridItemCodeFab, txtGridItemNameFab, new int[] { (int)EnumItemType.坯布 }, "", "ItemStd", true, true);
        }

       


        private void gridViewRowChanged3(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;

                string Name=SysConvert.ToString(gridView6.GetRowCellValue(gridView6.FocusedRowHandle,"Name"));//名称
               
                int BindType=Common.GetBindTypeByName(Name);

                Common.BindCLS(drpGridValue, BindType, true);
              
                //Common.BindCLS(drpGridValue,Name,true)

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
            //txtWeightUnit.Text = "g/m";

            
         
            drpUseable.EditValue = 1;
         
            txtItemDate.DateTime = DateTime.Now.Date;


            drpItemUnit.Text = ProductParamSet.GetStrValueByID(5001);//面料默认单位设置


            txtColorLoss.Text = ProductParamSet.GetStrValueByID(5006);//默认染损
            txtLastLoss.Text = ProductParamSet.GetStrValueByID(5007);//默认整理损


            if (ProductParamSet.GetIntValueByID(5022) == 1)//面料编码生成规格
            {
                txtItemCode_DoubleClick(null, null);
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5011)))//面料定义界面不要显示原料信息管理内容
            {
                txtWeightUnit.Text = SysConvert.ToString(ProductParamSet.GetStrValueByID(5011));
            }
            //iniFiledSet();
         
        }

        /// <summary>
        /// 设置
        /// </summary>
        private void iniFiledSet()
        {
            try
            {
                string sql = "Select ID AS FiledSetID, Name,FiledName,'' Value,'' DRemark,0 FormID,0 FormAID,0 FormBID,BindType from Sys_FiledSet where 1=1";
                sql+=" AND FormID="+this.FormID;
                sql += " AND ISNULL(FAID,0)=" + this.FormListAID;
                sql += " AND ISNULL(FBID,0)=" + this.FormListBID;
                sql += " AND ISNULL(UseableFlag,0)=1";//有效
                sql+=" Order by Sort";
                DataTable dt = SysUtils.Fill(sql);

                gridView6.GridControl.DataSource = dt;
                gridView6.GridControl.Show();
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
                    if (ProductParamSet.GetIntValueByID(5022) == 1)//面料编码生成规格
                    {
                        ProductCommon.FormNoIniSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.面料);
                    }
                    if (ProductParamSet.GetIntValueByID(5022) == 2) //面料编码生成规格-新春兰使用
                    {



                        string ItemCode = string.Empty;

                        string sql = "Select ItemCodeRule from Data_ItemClass where ID=" + SysConvert.ToInt32(drpItemClassID.EditValue);
                        sql += " AND ISNULL(ItemCodeRule,'')<>''";
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {

                            string VendorID = SysConvert.ToString(drpVendorID.EditValue);
                            string ItemModel = txtItemModel.Text.Trim();
                            string KZ = txtMWeight.Text.Trim();
                            string HD = string.Empty;
                            string DB = string.Empty;
                            string SS = string.Empty;


                            for (int i = 0; i < gridView6.RowCount; i++)
                            {
                                if (SysConvert.ToString(gridView6.GetRowCellValue(i, "Name")) == "厚度")
                                {
                                    HD = Common.GetCLSIDByCLSNM(SysConvert.ToString(gridView6.GetRowCellValue(i, "Value")));
                                }
                                if (SysConvert.ToString(gridView6.GetRowCellValue(i, "Name")) == "底布")
                                {
                                    DB = Common.GetCLSIDByCLSNM(SysConvert.ToString(gridView6.GetRowCellValue(i, "Value")));
                                }
                                if (SysConvert.ToString(gridView6.GetRowCellValue(i, "Name")) == "色水")
                                {
                                    SS = Common.GetCLSIDByCLSNM(SysConvert.ToString(gridView6.GetRowCellValue(i, "Value")));
                                }
                            }



                            string ItemCodeRule = SysConvert.ToString(dt.Rows[0]["ItemCodeRule"]);

                            string[] FieldName = ItemCodeRule.Split('+');
                            for (int i = 0; i < FieldName.Length; i++)
                            {
                                if (FieldName[i].ToString() == "VendorID")
                                {
                                    ItemCode += VendorID;
                                }
                                if (FieldName[i].ToString() == "ItemModel")
                                {
                                    ItemCode += ItemModel;
                                }
                                if (FieldName[i].ToString() == "HD")
                                {
                                    ItemCode += HD;
                                }
                                if (FieldName[i].ToString() == "DB")
                                {
                                    ItemCode += DB;
                                }
                                if (FieldName[i].ToString() == "SS")
                                {
                                    ItemCode += SS;
                                }
                                if (FieldName[i].ToString() == "MWeight")
                                {
                                    ItemCode += KZ;
                                }
                            }
                        }
                        else
                        {
                            this.ShowMessage("请先选择面料类型，并指定好生成规则！");
                            return;
                        }

                        txtItemCode.Text = ItemCode;
                    }
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

            if (!CheckCorrectItemDts())
            {
                this.ShowMessage("原料比例之和不等于100");
                return false;
            }
           
            return true;
        }
        /// <summary>
        /// 校验成份比例
        /// </summary>
        /// <returns></returns>
        public bool CheckCorrectItemDts()
        {
            decimal Percentage = 0;
            int Num = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    Percentage += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Percentage"));
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
            //ItemDts[] entityItemDts = GetItemDts();
            //ItemLBDts[] entityItemLBDts = GetItemLBDts();
            ItemColorDts[] entityItemColorDts = GetItemColorDts();
            //ItemGreyFabReplace[] entitygfr = GetEntityGreyFabReplace();
            ItemAdd[] entityItemAdd = GetItemAdd();
            ItemPic[] entityPic = GetItemPic();
            ItemCodeFacDts[] entityItemFacDts = GetItemCodeFacDts();
            rule.RAdd(entity, entityItemColorDts, entityItemAdd, entityPic, entityItemFacDts,1);
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
            //ItemDts[] entityItemDts = GetItemDts();
            //ItemLBDts[] entityItemLBDts = GetItemLBDts();
            ItemColorDts[] entityItemColorDts = GetItemColorDts();
            //ItemGreyFabReplace[] entitygfr = GetEntityGreyFabReplace();
            ItemAdd[] entityItemAdd = GetItemAdd();
            ItemPic[] entityPic = GetItemPic();
            ItemCodeFacDts[] entityItemFacDts = GetItemCodeFacDts();
            rule.RUpdate(entity, entityItemColorDts, entityItemAdd, entityPic, entityItemFacDts,1);
          
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
            
            entity.ItemTypeID = (int)EnumItemType.面料;
            entity.GoodsCode = txtGoodsCode.Text.Trim();
            entity.ItemClassID = SysConvert.ToInt32(drpItemClassID.EditValue);
            entity.ItemName =SysConvert.ToString( drpItemName.EditValue);
            entity.ItemStd = txtItemStd.Text.Trim();
            entity.ItemModel = txtItemModel.Text.Trim();
            entity.ItemUnit = drpItemUnit.Text.Trim();
            entity.MWidth =txtMWidth.Text.Trim();
            entity.MWeight =txtMWeight.Text.Trim();
        
            entity.Remark = txtRemark.Text.Trim();
            entity.UseableFlag = SysConvert.ToInt32(drpUseable.EditValue);
       
            entity.ItemDate = txtItemDate.DateTime.Date;
          
            entity.PerMiWeight = SysConvert.ToDecimal(txtPerMiWeight.Text.Trim());
            entity.GreyFabItemCode = txtGreyFabItemCode.Text.Trim();
            entity.Shrinkage = SysConvert.ToDecimal(txtShrinkage.Text.Trim());
            entity.ColorLoss = SysConvert.ToDecimal(txtColorLoss.Text.Trim());
            entity.LastLoss = SysConvert.ToDecimal(txtLastLoss.Text.Trim());
            entity.FabricTypeID = (int)EnumFabricType.普通面料;

            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);


            entity.AttRSGYDesc = txtAttRSGYDesc.Text;
            entity.AttMachineDesc = txtAttMachineDesc.Text.Trim();
            entity.AttYarnDesc = txtAttYarnDesc.Text;

            entity.WeightUnit = txtWeightUnit.Text.Trim();

            entity.HZType = txtHZType.Text.Trim();
            entity.SalePrice = SysConvert.ToDecimal(txtSalePrice.Text.Trim());
            entity.Organ = txtOrgan.Text.Trim();
            entity.Season = txtSeason.Text.Trim();
            entity.MinQty = txtMinQty.Text.Trim();
            entity.DeliveryTime = txtDeliveryTime.Text.Trim();
 

            return entity;

        }


        private ItemAdd[] GetItemAdd()
        {
            int index = 0;
            for (int i = 0; i < gridView6.RowCount; i++)
            {
                if (SysConvert.ToString(gridView6.GetRowCellValue(i, "Name")) != "")
                {
                    index++;
                }
            }
            ItemAdd[] entity=new ItemAdd[index];
            index = 0;
            for (int i = 0; i < gridView6.RowCount; i++)
            {
                if (SysConvert.ToString(gridView6.GetRowCellValue(i, "Name")) != "")
                {
                    entity[index] = new ItemAdd();
                    entity[index].MainID = SysConvert.ToInt32(gridView6.GetRowCellValue(i,"MainID"));
                    entity[index].Seq = SysConvert.ToInt32(gridView6.GetRowCellValue(i, "Seq"));
                    entity[index].SelectByID();

                    entity[index].FiledSetID = SysConvert.ToInt32(gridView6.GetRowCellValue(i, "FiledSetID"));
                    entity[index].Name = SysConvert.ToString(gridView6.GetRowCellValue(i, "Name"));
                    entity[index].FiledName = SysConvert.ToString(gridView6.GetRowCellValue(i, "FiledName"));
                    entity[index].Value = SysConvert.ToString(gridView6.GetRowCellValue(i, "Value"));
                    entity[index].DRemark = SysConvert.ToString(gridView6.GetRowCellValue(i, "DRemark"));
                    entity[index].FormID = this.FormID;
                    entity[index].FormAID = this.FormListAID;
                    entity[index].FormBID = this.FormListBID ;
                    index++;
                }
            }

            return entity;
        }


        private ItemPic[] GetItemPic()
        {
           
            ItemPic[] entity = new ItemPic[1];
            for (int i = 0; i < 1; i++)
            {
                
                entity[i] = new ItemPic();
                entity[i].MainID =HTDataID;
                entity[i].Seq = i+1;
                entity[i].SelectByID();

                if (i == 0)
                {
                    entity[i].PicImage = TemplatePic.ImageToByte(pictureBox1.Image); 

                }
              
                    
            }

            return entity;
        }


        /// <summary>
        /// 获取供应商代码及报价
        /// </summary>
        /// <returns></returns>
        private ItemCodeFacDts[] GetItemCodeFacDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "FactoryID")) != string.Empty)
                {
                    Num++;
                }
            }
            ItemCodeFacDts[] entitydts = new ItemCodeFacDts[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "FactoryID")) != string.Empty)
                {
                    entitydts[index] = new ItemCodeFacDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].FactoryID = SysConvert.ToString(gridView1.GetRowCellValue(i, "FactoryID"));
                    entitydts[index].FacItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "FacItemCode"));
                    entitydts[index].FacPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "FacPrice"));
                    entitydts[index].FacPriceLimitDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FacPriceLimitDate"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));

                    entitydts[index].FormDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FormDate"));
                    entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));
                    entitydts[index].Price = SysConvert.ToString(gridView1.GetRowCellValue(i, "Price"));
                    entitydts[index].SH = SysConvert.ToString(gridView1.GetRowCellValue(i, "SH"));
                    entitydts[index].ReqDate = SysConvert.ToString(gridView1.GetRowCellValue(i, "ReqDate"));
                    entitydts[index].MinQty = SysConvert.ToString(gridView1.GetRowCellValue(i, "MinQty"));
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
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum")) != string.Empty || SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName")) != string.Empty)
                {
                    Num++;
                }
            }
            ItemColorDts[] entitydts = new ItemColorDts[Num];
            int index = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum")) != string.Empty || SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName")) != string.Empty)
                {
                    entitydts[index] = new ItemColorDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView3.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].ColorNum = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView3.GetRowCellValue(i, "ColorName"));
                    entitydts[index].BuyPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "BuyPrice"));
                    entitydts[index].BuyPriceDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "BuyPriceDate"));
                    entitydts[index].SalePrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "SalePrice"));
                    entitydts[index].SalePriceDate = SysConvert.ToDateTime(gridView3.GetRowCellValue(i, "SalePriceDate"));

                    entitydts[index].DHPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "DHPrice"));
                    entitydts[index].YBPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "YBPrice"));
                    entitydts[index].XHPrice = SysConvert.ToDecimal(gridView3.GetRowCellValue(i, "XHPrice"));

                    entitydts[index].Remark = SysConvert.ToString(gridView3.GetRowCellValue(i, "Remark"));
                    index++;

                }
            }
            return entitydts;
        }



        /// <summary>
        /// 获取颜色信息实体
        /// </summary>
        /// <returns></returns>
        private ItemDts[] GetItemDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    Num++;
                }
            }
            ItemDts[] entitydts = new ItemDts[Num];
            int index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode")) != string.Empty)
                {
                    entitydts[index] = new ItemDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView2.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].DtsItemCode = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemCode"));
                    entitydts[index].DtsItemName = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemName"));
                    entitydts[index].DtsItemStd = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemStd"));
                    entitydts[index].DtsItemModel = SysConvert.ToString(gridView2.GetRowCellValue(i, "DtsItemModel"));
                    entitydts[index].Percentage = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Percentage"));
                    entitydts[index].Loss = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Loss"));
                    entitydts[index].PerMiWeight = SysConvert.ToDecimal(txtPerMiWeight.Text.Trim()) * (entitydts[index].Percentage/100m) * (1 + entitydts[index].Loss);//SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "PerMiWeight"));
                    index++;

                }
            }
            return entitydts;
        }


        /// <summary>
        /// 获取白坯面料替代表实体
        /// </summary>
        /// <returns></returns>
        private ItemGreyFabReplace[] GetEntityGreyFabReplace()
        {
            int Num = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                if (SysConvert.ToString(gridView4.GetRowCellValue(i, "GreyFabItemCode")) != string.Empty)
                {
                    Num++;
                }
            }
            ItemGreyFabReplace[] entitydts = new ItemGreyFabReplace[Num];
            int index = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                if (SysConvert.ToString(gridView4.GetRowCellValue(i, "GreyFabItemCode")) != string.Empty)
                {
                    entitydts[index] = new ItemGreyFabReplace();
                    entitydts[index].ID = SysConvert.ToInt32(gridView4.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].GreyFabItemCode = SysConvert.ToString(gridView4.GetRowCellValue(i, "GreyFabItemCode"));
                    entitydts[index].ItemCode = txtItemCode.Text.Trim();
                    index++;

                }
            }
            return entitydts;
        }


        /// <summary>
        /// 获取类别信息实体
        /// </summary>
        /// <returns></returns>
        //private ItemLBDts[] GetItemLBDts()
        //{
            //int Num = 0;
            //string[] mllb = GetCheckMLLB(chkLamp1).Split(',');
            //Num = mllb.Length;
            //ItemLBDts[] entitydts = new ItemLBDts[Num];
            //int index = 0;
            //for (int i = 0; i < Num; i++)
            //{
            //    entitydts[index] = new ItemLBDts();
            //    entitydts[index].MainID = HTDataID;
            //    entitydts[index].Seq = i + 1;
            //    entitydts[index].SelectByID();
            //    entitydts[index].MLLBCode =mllb[i].ToString();

            //    index++;

                
            //}
            //return entitydts;
        //}
        #endregion

     

  





        #region 其它事件


        /// <summary>
        /// 单位改变调整每米重量Label的文字表述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpItemUnit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblPerMiWeight.Text = Common.GetUnitQtyNam(drpItemUnit.Text.Trim());

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
                            txtGreyFabItemCode.Text = dt.Rows[0]["ItemCode"].ToString();

                            txtGreyItemDes.Text = Common.GetItemDesc(txtGreyFabItemCode.Text.Trim());
                            txtItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                            txtItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                            drpItemName.EditValue = dt.Rows[0]["ItemName"].ToString();

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

        private void gridView6_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                int CLSListID = SysConvert.ToInt32(gridView6.GetRowCellValue(gridView6.FocusedRowHandle,"BindType"));
                
                Common.BindCLS(drpGridValue, CLSListID, true);
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    openFileDialog1.Filter = "JPG文件(*.jpg)|*.jpg|GIF文件(*.gif)|*.gif|BMP文件(*.bmp)|*.bmp|全部文件(*.*)|*.*";
                    if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filenamerount = openFileDialog1.FileName;
                        pictureBox1.Image = Image.FromFile(filenamerount);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("面料数据没有保存，请检查！");
                    return;
                }
                ItemRule rule = new ItemRule();
                Item entity = new Item();
                entity.ID = HTDataID;
                entity.SelectByID();
                
                if (entity.GreyFabItemCode != "")
                {
                    this.ShowMessage("坯布信息已关联，请检查！");
                    return;
                }

                ItemRule p_rule = new ItemRule();
                Item p_entity = new Item();
                p_entity.ItemCode ="G"+ entity.ItemCode;
                p_entity.ItemName = entity.ItemName;
                p_entity.ItemStd = entity.ItemStd;
                p_entity.ItemModel = entity.ItemModel;
                p_entity.ItemModelEn = entity.ItemModelEn;
                p_entity.UseableFlag = entity.UseableFlag;
                p_entity.MWeight = entity.MWeight;
                p_entity.MWeight2 = entity.MWeight2;
                p_entity.FK = entity.FK;
                p_entity.ItemUnit = entity.ItemUnit;
                p_entity.ItemDate = DateTime.Now.Date;

                p_entity.MWidth = entity.MWidth;
                p_entity.Remark = entity.Remark;
                p_entity.ItemTypeID = (int)EnumItemType.坯布;
                p_rule.RAdd(p_entity);

                entity.GreyFabItemCode = p_entity.ItemCode;
                rule.RUpdate(entity);
                txtGreyItemDes.Text=Common.GetItemDesc(p_entity.ItemCode);
                txtGreyFabItemCode.Text = p_entity.ItemCode;

                

               

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #region 条码打印

        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();

            if (HTDataID == 0)
            {
                this.ShowMessage("请保存面料后打印");
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
            string sql = "SELECT * FROM Data_Item WHERE ID = "+SysString.ToDBString(HTDataID);
            DataTable dtSource = SysUtils.Fill(sql);

            dtSource.Columns.Add(new DataColumn("ERCode", typeof(Image)));
            foreach (DataRow dr in dtSource.Rows)
            {
                string EWM1 = SysConvert.ToString(dr["ItemCode"]);
                string MSG = "";
                dr["ERCode"] = HTERCode.HTERBarcode.Create(EWM1, 2, 0, "", out MSG);
            }

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtSource);

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

                btnPrintAbount((int)ReportPrintType.设计);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    string Cost = GetValue("Cost");
                    decimal ProfitMargin = SysConvert.ToDecimal(GetValue("ProfitMargin"));
                    decimal Quot = GetDecimalByString(Cost, '/') * (1m + (ProfitMargin / 100m));
                    for (int i = 0; i < gridView6.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView6.GetRowCellValue(i, "FiledName")) == "QUOT")
                        {
                            gridView6.SetRowCellValue(i, "Value", Quot.ToString() + "/M");
                        }
                    }
                }
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private string GetValue(string p_FiledName)
        {
            string Value = "";
            for (int i = 0; i < gridView6.RowCount; i++)
            {
                if (SysConvert.ToString(gridView6.GetRowCellValue(i, "FiledName")) == p_FiledName)
                {
                    Value = SysConvert.ToString(gridView6.GetRowCellValue(i, "Value"));
                }
            }
            return Value;
        }


        private decimal GetDecimalByString(string p_Decimal, char p_Char)
        {
            decimal value = 0;
            if (SysConvert.ToDecimal(p_Decimal) > 0)
            {
                value = SysConvert.ToDecimal(p_Decimal);
            }
            else
            {
                string[] decimalArr = p_Decimal.Split(p_Char);
                if (decimalArr.Length > 0)
                {
                    value = SysConvert.ToDecimal(decimalArr[0]);
                }
                else
                {
                    value = 0;
                }
            }
            return value;
        }

        private void drpGridFactoryID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string VendorID = SysConvert.ToString(gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "FactoryID"));
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "VendorID", VendorID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }






    }
}