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
    /// 功能：物品管理
    /// </summary>
    public partial class frmItemFLEdit : frmAPBaseUISinEdit
    {
        public frmItemFLEdit()
        {
            InitializeComponent();
        }

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入辅料编码");
                txtItemCode.Focus();
                return false;
            }
            if (txtItemName.Text.Trim() == "")
            {
                this.ShowMessage("请输入辅料名称");
                txtItemName.Focus();
                return false;
            }
            if (txtItemStd.Text.Trim() == "")
            {
                this.ShowMessage("请输入辅料规格");
                txtItemStd.Focus();
                return false;
            }
            if (SysConvert.ToString(drpItemType.EditValue) == "")
            {
                this.ShowMessage("请选择辅料类型");
                drpItemType.Focus();
                return false;
            }
           
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            rule.RUpdate(entity);
           
        }

        /// <summary>
        /// 设置
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
        /// 删除
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
            //    ShowMessage("该原料在出入库报表中，不可删除！");
            
        }


        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            ProcessCtl.ProcControlEdit(new Control[] {   }, false);

            ProductCommon.FormNoCtlEditSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.辅料, p_Flag);
        }

            /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtItemDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);

            txtItemCode_DoubleClick(null, null);
            drpItemUnit.Text = ProductParamSet.GetStrValueByID(5004);//辅料默认单位设置
        
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";

            Common.BindCLS(drpItemUnit, "Data_Item", "ItemUnitAtt", true);
            Common.BindCLS(drpItemrSeason, "Data_Item", "Season", true);
            Common.BindCLS(drpItemCW, "Data_Item", "ItemCW", true);
            Common.BindOP(drpCYOPID, (int)EnumOPDep.业务部, true);

         
            Common.BindItemClass(drpItemType, this.FormListAID, true);//绑定物品分类
            Common.BindVendor(drpBuyShopID, new int[] { (int)EnumVendorType.辅料供应商}, true);//绑定辅料供应商
            this.SetPosCondition = " AND ItemTypeID=" + this.FormListAID;
            new VendorProc(drpBuyShopID);

           

            SetTabIndex(0, groupControlMainten);
        }
    

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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
            if (HTFormStatus == FormStatus.新增)
            {
            }
          
            return entity;
        }
       
        #endregion

        #region 其它事件

        /// <summary>
        /// 物品类型离开绑定物品分类
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
        /// 双击获得单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {

                    ProductCommon.FormNoIniSet(txtItemCode, "Data_Item", "ItemCode", (int)EnumItemType.辅料);
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