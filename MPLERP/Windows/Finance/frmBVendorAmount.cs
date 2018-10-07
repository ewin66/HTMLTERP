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
    public partial class frmBVendorAmount : frmAPBaseUISin
    {
        public frmBVendorAmount()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            tempStr += " AND VendorID IN (SELECT VendorID FROM Data_Vendor WHERE VendorTypeID="+FormListAID+")";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_BVendorAmount";
            this.HTDataList = gridView1;
            switch (FormListAID)
            {
                case 1:
                    lbVendor.Text = "客户";
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                    new VendorProc(drpVendorID);
                    break;
                case 2:
                    lbVendor.Text = "工厂";
                    Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.工厂 }, true);
                    new VendorProc(drpVendorID);
                    break;
                
            }

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private BVendorAmount EntityGet()
        {
            BVendorAmount entity = new BVendorAmount();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}