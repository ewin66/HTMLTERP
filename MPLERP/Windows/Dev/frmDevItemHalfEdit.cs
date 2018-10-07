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
    /// ���ܣ�����������ϸ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmDevItemHalfEdit : frmAPBaseUIFormEdit
    {
        public frmDevItemHalfEdit()
        {
            InitializeComponent();
        }

        public int rowhandle = 1;
        #region �Զ����鷽������[��Ҫ�޸�]     
       
        public int GBFormStatus = (int)EnumFormStatus.��ѯ;
        public int CheckFlag = 0;
        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            //������Ʒ��Ϣ
          
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
           
            //����ϸ��Ϣ
           
            BindGrid2();// �󶨳ɷ���Ϣ

            BindGrid6();
           

        }

      

        /// <summary>
        /// �󶨳ɷ���Ϣ
        /// </summary>
        private void BindGrid2()
        {

            ItemDtsRule rule = new ItemDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }




        /// <summary>
        /// �󶨹������뼰����
        /// </summary>
        private void BindGrid6()
        {

            ItemCodeFacDtsRule rule = new ItemCodeFacDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {

            ItemRule rule = new ItemRule();
            Item entity = GetItem();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            ProductCommon.FormNoCtlEditSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.���Ʒ, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {

            this.HTDataTableName = "Data_Item";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };


            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5010)))//���϶�����治Ҫ��ʾԭ����Ϣ��������
            //{
            //    xtraTabPage1.PageVisible = false;
            //}

           
            
            //Common.BindVendorID(drpVendorID,true);

            //Common.BindMLDL(drpMLDLCode, true);     //�����ϴ���
            //Common.BindMLDL(drpMLDL, true);
            //Common.BindItemClass(drpItemClassID,(int)EnumItemType.����,true);
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

            //new ItemProcResLookUP(BaseFocusLabel, gridView2, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.ɴ�� }, "", "ItemStd", true, true);
            
            //gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            //gridViewBindEventA2(gridView1);

           
        }

        /// <summary>
        /// ��ʼ��ˢ������(�������ʱ���û�ˢ�°�ťʱ����)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindVendorID(drpVendorID, true);

            Common.BindMLDL(drpMLDLCode, true);     //�����ϴ���
            Common.BindMLDL(drpMLDL, true);
            Common.BindItemClass(drpItemClassID, (int)EnumItemType.���Ʒ, true);
            Common.BindVendor(drpGridFactoryID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.��Ӧ�� }, true);
            //Common.BindItemType(drpItemTypeID, true);
            //Common.BindNeedle(txtNeedle, true);

            //Common.BindEnumUnit(drpItemUnit, true);
            Common.BindCLS(drpLoss, "Data_Item", "Loss", true);

            Common.BindMachine(drpMachine,true);

            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitFab", true);
            Common.BindCLS(txtNeedle, "Enum_Needle", "Needle", true);
            Common.BindSeason(txtSeason, true);

            Common.BindMLLB(chkLamp1, true); 
            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.ɴ�� }, "", "DtsItemModel", true, true);
            

        }
        

        /// <summary>
        /// ��ȡ�������
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
        /// ����������˾����
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
        /// ������ʼ��
        /// </summary>
        public override void IniInsertSet()
        {
            txtWeightUnit.Text = "g/m";
            txtItemCode_DoubleClick(null, null);
         
            drpUseable.EditValue = 1;
            drpPFlag.EditValue = 0;
            drpXFlag.EditValue = 0;
            txtItemDate.DateTime = DateTime.Now.Date;

            drpItemUnit.Text = ProductParamSet.GetStrValueByID(5002);//����Ĭ�ϵ�λ����
         
        }

        /// <summary>
        /// �õ���Ʒ���
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
        /// ˫���õ���Ʒ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    ProductCommon.FormNoIniSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.���Ʒ);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �����޸�ɾ��
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("�������Ʒ����");
                txtItemCode.Focus();
                return false;
            }

            //if (txtItemModel.Text.Trim() == "")
            //{
            //    this.ShowMessage("������Ʒ��");
            //    txtItemModel.Focus();
            //    return false;
            //}

            //if (SysConvert.ToInt32(drpItemClassID.EditValue)==0)
            //{
            //    this.ShowMessage("��ѡ����������");
            //    drpItemClassID.Focus();
            //    return false;
            //}

            //if (!CheckCorrectItemDts())
            //{
            //    this.ShowMessage("����֮�Ͳ�����100");
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
        /// ����
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
        /// �޸�
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
        /// ��Ʒʵ��
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
            entity.ItemTypeID = (int)EnumItemType.���Ʒ;
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
        /// ��ȡ�Ұ���Ϣʵ��
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
        /// ��ȡ��ɫ��Ϣʵ��
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
        /// ��ȡ��ɫ��Ϣʵ��
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
        /// ��ȡ�����Ϣʵ��
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
        /// ��ȡ��Ӧ�̴��뼰����
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

     

        #region �����������
        /// <summary>
        /// ����ѡ��
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
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    if (drpVendorID.Text.Trim() == "" && txtGoodsCode.Text.Trim() == "")
                    {
                        this.ShowMessage("�����볧�����Ʒ������¼��");
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
                            this.NavigateWin("frmDevItemGrayEdit", frm.ID.ToString(), FormStatus.��ѯ);
                        }
                    }
                    else
                    {
                        this.ShowMessage("û�м�⵽��ͬ�������Ʒ��Ĳ�Ʒ����������");

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
                if (GBFormStatus == (int)EnumFormStatus.��ѯ)
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