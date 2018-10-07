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
    /// ���ܣ���Ʒ����
    /// 
    /// </summary>
    public partial class frmItemEdit : frmAPBaseUIFormEdit
    {
        public frmItemEdit()
        {
            InitializeComponent();
        }

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("������ɴ�߱���");
                txtItemCode.Focus();
                return false;
            }
            if (txtItemName.Text.Trim() == "")
            {
                this.ShowMessage("������ɴ�߳ɷ�");
                txtItemName.Focus();
                return false;
            }
            if (txtItemStd.Text.Trim() == "")
            {
                this.ShowMessage("������ɴ�߹��");
                txtItemStd.Focus();
                return false;
            }
            if (SysConvert.ToString(drpItemType.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ɴ������");
                drpItemType.Focus();
                return false;
            }
           
            return true;
        }


        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            ItemDtsRule rule = new ItemDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }



        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            ItemDts[] entityDts = GetItemDts();
            rule.RAddYarn(entity, entityDts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            ItemDts[] entityDts = GetItemDts();
            rule.RUpdateYarn(entity, entityDts);
           
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Item entity = new Item();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtItemCode.Text = SysConvert.ToString(entity.ItemCode);
            txtItemName.Text = SysConvert.ToString(entity.ItemName);
            txtItemStd.Text = SysConvert.ToString(entity.ItemStd);
            txtItemAttnCode.Text = SysConvert.ToString(entity.ItemAttnCode);
            txtRemark.EditValue = SysConvert.ToString(entity.Remark);
            drpItemUnit.EditValue = SysConvert.ToString(entity.ItemUnit);
            txtItemNameEN.Text = entity.ItemNameEn;
            txtItemDate.DateTime = entity.ItemDate;
            drpBuyShopID.EditValue = SysConvert.ToString(entity.VendorID);
            drpItemType.EditValue = SysConvert.ToInt32(entity.ItemClassID.ToString());
           // drpCYOPID.EditValue = SysConvert.ToString(entity.CYOPID);
         
            txtItemModel.Text = SysConvert.ToString(entity.ItemModel);
            //txtBuyUnitPrice.Text = SysConvert.ToString(entity.BuyUnitPrice);
            //txtItemModelNo.Text = entity.ItemModelNo.ToString();

            //txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
            //txtMakeDate.DateTime = entity.MakeDate;


            //HTDataSubmitFlag = entity.SubmitFlag;
            //HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }

            BindGridDts();
       
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemRule rule = new ItemRule();
            
            Item entity = EntityGet();
            //if (rule.IsCanDelect(entity.ItemCode))
            //{
            rule.RDelete(entity);
            //}
            //else
            //    ShowMessage("��ԭ���ڳ���ⱨ���У�����ɾ����");
            
        }


        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            

            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            ProcessCtl.ProcControlEdit(new Control[] {   }, false);

            ProductCommon.FormNoCtlEditSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.ɴ��, p_Flag);

        }

            /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtItemDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtItemCode_DoubleClick(null, null);

            drpItemUnit.Text = ProductParamSet.GetStrValueByID(5003);//ɴ��Ĭ�ϵ�λ����
        
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "DtsItemCode" };//������ϸУ�����¼���ֶ�
            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitYarn", true);
            Common.BindCLS(drpItemrSeason, "Data_Item", "Season", true);
            Common.BindCLS(drpItemCW, "Data_Item", "ItemCW", true);
            Common.BindOP(drpCYOPID, (int)EnumOPDep.ҵ��, true);

         
            Common.BindItemClass(drpItemType, this.FormListAID, true);//����Ʒ����
            Common.BindVendor(drpBuyShopID, new int[] { (int)EnumVendorType.��Ӧ��}, true);
            this.SetPosCondition = " AND ItemTypeID=" + this.FormListAID;
            new VendorProc(drpBuyShopID);

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "DtsItemCode", "DtsItemName", "DtsItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.ɴ��, (int)EnumItemType.ԭ�� }, "", "DtsItemModel", true, true);


            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5024)))//��ϸ�б���ʾ
            {
                groupControl1.Visible = true;
            }
            else
            {
                groupControl1.Visible = false;
            }


            SetTabIndex(0, groupControlMainten);
        }
    

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Item EntityGet()
        {
            Item entity = new Item();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ItemCode = txtItemCode.Text.Trim();
            entity.ItemName = txtItemName.Text.Trim();
            entity.ItemAttnCode = txtItemAttnCode.Text.Trim();
            entity.ItemStd = txtItemStd.Text.Trim();
            entity.ItemUnit = SysConvert.ToString(drpItemUnit.EditValue);
            entity.ItemTypeID = this.FormListAID;
            entity.ItemClassID = SysConvert.ToInt32(drpItemType.EditValue);
            entity.VendorID = SysConvert.ToString(drpBuyShopID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.ItemModel = txtItemModel.Text.Trim();
            entity.ItemNameEn = txtItemNameEN.Text.Trim();
            
            //entity.BuyUnitPrice = SysConvert.ToDecimal(txtBuyUnitPrice.Text);
            //entity.ItemModelNo = SysConvert.ToString(txtItemModelNo.Text);
            //entity.CYOPID = entity.ItemUnit = SysConvert.ToString(drpCYOPID.EditValue);

            entity.ItemDate = txtItemDate.DateTime;
            if (HTFormStatus == FormStatus.����)
            {
                   
            }
          
            return entity;
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
                              index++;

                }
            }
            return entitydts;
        }
       
        #endregion
        #region �����¼�

        /// <summary>
        /// ��Ʒ�����뿪����Ʒ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpItemType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindItemClass(drpItemClass, SysConvert.ToInt32(drpItemType.EditValue), true);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ��Ʒ˫�������µ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {

                    ProductCommon.FormNoIniSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.ɴ��);
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