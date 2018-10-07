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
    /// 功能：收发存报表
    /// </summary>
    public partial class frmWHIOStorgeRpt2 : frmAPBaseUIRpt
    {
        public frmWHIOStorgeRpt2()
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
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtQSSN.Text.Trim() != "")
            {
                tempStr += " AND SSN LIKE " + SysString.ToDBString("%" + txtQSSN.Text.Trim() + "%");
            }
            if (txtQDSN.Text.Trim() != "")
            {
                tempStr += " AND DSN LIKE " + SysString.ToDBString("%" + txtQDSN.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }

            //tempStr += " AND FormDate <=" + SysString.ToDBString(DateTime.Now.Date.AddDays(-iLKParamSet).ToString("yyyy-MM-dd"));

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " Exec USP1_WHIOStorgeDts " + SysString.ToDBString(SysConvert.ToString(txtWriteDateS.DateTime.Date));
            sql += "," + SysString.ToDBString(SysConvert.ToString(txtWriteDateE.DateTime.Date));
            sql += "," + SysString.ToDBString(HTDataConditionStr);

            DataTable datatable = SysUtils.Fill(sql);

            gridView1.GridControl.DataSource = SysUtils.Fill(sql);
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;


            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂}, true);//客户 

            Common.BindWHType(drpQWHTypeID, false);
            Common.BindWHByWHType(drpQWHID, true);
            new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.面料 }, true, true);//(int)ItemType.纱线


            txtWriteDateS.DateTime = DateTime.Now.Date.AddDays(0 - 15);
            txtWriteDateE.DateTime = DateTime.Now.Date;

            SetTabIndex(0, groupControlQuery);

        }

        #endregion

    }
}