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
    public partial class frmOperateQuote : frmAPBaseUIForm
    {
        public frmOperateQuote()
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
            if (txtQCode.Text.Trim() != "")
            {
                tempStr += " AND Code LIKE " + SysString.ToDBString("%" + txtQCode.Text.Trim() + "%");
            }
            if (chkQuoteDate.Checked)
            {
                tempStr += " AND QuoteDate BETWEEN " + SysString.ToDBString(txtQuoteDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQuoteDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (SysConvert.ToString(drpQuoteOPID.EditValue) != "")
            {
                tempStr += " AND QuoteOPID=" + SysString.ToDBString(SysConvert.ToString(drpQuoteOPID.EditValue));
            }
       
            if (SysConvert.ToString(drpQCompanyTypeID.EditValue) != "")
            {
                tempStr += " AND CompanyTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQCompanyTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQCurrencyID.EditValue) != "")
            {
                tempStr += " AND CurrencyID=" + SysString.ToDBString(SysConvert.ToString(drpQCurrencyID.EditValue));
            }
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode =" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }

            if (txtQItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }

            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                tempStr += " AND VendorID in(Select VendorID FROM UV1_Data_VendorInSaleOP WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                tempStr += "  OR DtsInSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";
            }



            tempStr += " ORDER BY Code DESC";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            OperateQuoteRule rule = new OperateQuoteRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            OperateQuoteRule rule = new OperateQuoteRule();
            OperateQuote entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_OperateQuote";
            this.HTDataList = gridView1;


            txtQuoteDateE.DateTime = DateTime.Now.Date;
            txtQuoteDateS.DateTime = DateTime.Now.Date.AddDays(0 - ParamConfig.QueryDayNum);

            this.btnSubmitCancelVisible = false;
            this.btnSubmitVisible = false;
            this.btnUpdateVisible = false;
            this.btnDeleteVisible = false;

            Common.BindCompanyType(drpQCompanyTypeID, true);//绑定公司别
            Common.BindOPID(drpQuoteOPID, true);//业务员
            Common.BindCurrency(drpQCurrencyID, true);//币种
            new ItemProcLookUp(drpQItemCode, new int[] {  (int)EnumItemType.面料 }, true, true);
            txtQCode_EditValueChanged(null,null);


            ///客户参照相关，只查看自己的客户
            string p_Conidion = string.Empty;
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                  p_Conidion = " AND ( ";
                p_Conidion += " InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion += " OR ID in (Select MainID From Data_VendorInSaleOP where InSaleOP= " + SysString.ToDBString(FParamConfig.LoginID) + ")";
                p_Conidion += ")";

            }
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, p_Conidion, true);//客户
            new VendorProc(drpQVendorID, p_Conidion);

            SetTabIndex(0,groupControlQuery);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OperateQuote EntityGet()
        {
            OperateQuote entity = new OperateQuote();
            entity.ID = HTDataID;      
            return entity;
        }
     /// <summary>
        ///  快速查询
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        private void txtQCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtQItemName.Text = "";
                txtQItemStd.Text = "";
                //txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    //txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
                txtQCode_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

       
    }
}