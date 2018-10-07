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
    /// </summary>
    public partial class frmItemFLEdit : frmAPBaseUISinEdit
    {
        public frmItemFLEdit()
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
                this.ShowMessage("�����븨�ϱ���");
                txtItemCode.Focus();
                return false;
            }
            if (txtItemName.Text.Trim() == "")
            {
                this.ShowMessage("�����븨������");
                txtItemName.Focus();
                return false;
            }
            if (txtItemStd.Text.Trim() == "")
            {
                this.ShowMessage("�����븨�Ϲ��");
                txtItemStd.Focus();
                return false;
            }
            if (SysConvert.ToString(drpItemType.EditValue) == "")
            {
                this.ShowMessage("��ѡ��������");
                drpItemType.Focus();
                return false;
            }
           
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            rule.RUpdate(entity);
           
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
            //    rule.RDelete(entity);
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

            ProductCommon.FormNoCtlEditSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.����, p_Flag);
        }

            /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtItemDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);

            txtItemCode_DoubleClick(null, null);
            drpItemUnit.Text = ProductParamSet.GetStrValueByID(5004);//����Ĭ�ϵ�λ����
        
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";

            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitAtt", true);
            Common.BindCLS(drpItemrSeason, "Data_Item", "Season", true);
            Common.BindCLS(drpItemCW, "Data_Item", "ItemCW", true);
            Common.BindOP(drpCYOPID, (int)EnumOPDep.ҵ��, true);

         
            Common.BindItemClass(drpItemType, this.FormListAID, true);//����Ʒ����
            Common.BindVendor(drpBuyShopID, new int[] { (int)EnumVendorType.���Ϲ�Ӧ��}, true);//�󶨸��Ϲ�Ӧ��
            this.SetPosCondition = " AND ItemTypeID=" + this.FormListAID;
            new VendorProc(drpBuyShopID);

           

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
        /// ˫����õ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {

                    ProductCommon.FormNoIniSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.����);
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