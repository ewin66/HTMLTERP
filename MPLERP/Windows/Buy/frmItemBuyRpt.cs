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
    public partial class frmItemBuyRpt : frmAPBaseUIRpt
    {
        public frmItemBuyRpt()
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
            if (chkIndate.Checked)
            {
                tempStr += " AND MakeDate  BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQIndateE.DateTime.ToString("yyyy-MM-dd"));
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode =" + SysString.ToDBString(txtItemCode.Text.Trim());
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode =" + SysString.ToDBString(txtGoodsCode.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum=" + SysString.ToDBString(txtColorNum.Text.Trim());
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName=" + SysString.ToDBString(txtColorName.Text.Trim());
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemBuyFormRule rule = new ItemBuyFormRule();
            gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemBuyFormRule rule = new ItemBuyFormRule();
            ItemBuyForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);


            txtQIndateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQIndateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            this.HTDataTableName = "Buy_ItemBuyForm";
            this.HTDataList = gridView1;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemBuyForm EntityGet()
        {
            ItemBuyForm entity = new ItemBuyForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region 快速查询
        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

        private void txtItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

        private void txtGoodsCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

        private void txtColorNum_EditValueChanged(object sender, EventArgs e)
        {   
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

        private void txtColorName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }
        #endregion

    }
}