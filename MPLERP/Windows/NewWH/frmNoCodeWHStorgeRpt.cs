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

    /// <summary>
    ///功能：库存报表  zhoufc
    /// </summary>
    public partial class frmNoCodeWHStorgeRpt : frmAPBaseUIRpt
    {
        public frmNoCodeWHStorgeRpt()
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

            if (SysConvert.ToString(drpWHID.EditValue) != string.Empty)
            {
                tempStr += " AND WHID=" + SysString.ToDBString(drpWHID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpSection.EditValue) != string.Empty)
            {
                tempStr += " AND SectionID = " + SysString.ToDBString(SysConvert.ToString(drpSection.EditValue));
            }
            if (SysConvert.ToString(drpSBits.EditValue) != string.Empty)
            {
                tempStr += " AND SBitID = " + SysString.ToDBString(SysConvert.ToString(drpSBits.EditValue));
            }
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
            if (txtOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND OrderFormNo LIKE " + SysString.ToDBString("%" + txtOrderFormNo.Text.Trim() + "%");
            }

            if (txtJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtJarNum.Text.Trim() + "%");
            }

            if (txtBatch.Text.Trim() != string.Empty)
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtBatch.Text.Trim() + "%");
            }
            tempStr += " AND WHID IN (SELECT WHID FROM WH_WH WHERE WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(this.FormListAID) + "))";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeAlarmRule rule = new StorgeAlarmRule();
            DataTable dt = rule.RShowStorge(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("YCFlag", "0 AS YCFlag"));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();


        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataList = gridView1;
            Common.BindWHByFormList(drpWHID, this.FormListAID, true);
            Common.BindVendor(drpDtsVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.辅料供应商, (int)EnumVendorType.其他加工厂, (int)EnumVendorType.客户, (int)EnumVendorType.供应商 }, true);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
        }

        #endregion
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindSection(drpSection, SysConvert.ToString(drpWHID.EditValue), true);
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void txtOrderFormNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetCondtion();
                    this.BindGrid();
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }

        private void drpSection_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindSBit(drpSBits, SysConvert.ToString(drpWHID.EditValue), SysConvert.ToString(drpSection.Text), true);
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }
        private void drpSBits_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }
    }
}