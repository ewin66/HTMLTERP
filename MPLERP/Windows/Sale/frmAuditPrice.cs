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
    public partial class frmAuditPrice : frmAPBaseUIForm
    {
        public frmAuditPrice()
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
            if (txtQCode.Text.Trim() != "")
            {
                tempStr += " AND Code LIKE" + SysString.ToDBString("%" + txtQCode.Text.Trim() + "%");
            }
            if (txtQProductCode.Text.Trim() != "")
            {
                tempStr += " AND ProductCode LIKE" + SysString.ToDBString("%" + txtQProductCode.Text.Trim() + "%");
            }
   
            if (!Common.CheckLookUpEditBlank(drpQCompanyTypeID))
            {
                tempStr += " AND CompanyTypeID = " + SysString.ToDBString(drpQCompanyTypeID.EditValue.ToString());
            }
            if (!Common.CheckLookUpEditBlank(drpQItemCode))
            {
                tempStr += " AND ItemCode = " + SysString.ToDBString(drpQItemCode.EditValue.ToString());
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
            if (!Common.CheckLookUpEditBlank(drpQSaleOPID))
            {
                tempStr += " AND MakeOPID = " + SysString.ToDBString(drpQSaleOPID.EditValue.ToString());
            }
            if (chkInDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQInDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQInDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");

            }
            tempStr += "ORDER BY Code DESC ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            AuditPriceRule rule = new AuditPriceRule();
            gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            AuditPriceRule rule = new AuditPriceRule();
            AuditPrice entity = EntityGet();
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
            this.HTDataTableName = "Sale_AuditPrice";
            this.HTDataList = gridView1;
            txtQInDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQInDateE.DateTime = DateTime.Now.Date;
            new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.面料 }, true, true);
            Common.BindOPID(drpQSaleOPID, true);
            Common.BindCompanyType(drpQCompanyTypeID, true);
            txtQCode_EditValueChanged(null,null);
            ///隐藏按钮
            this.btnSubmitCancelVisible = false;
            this.btnSubmitVisible = false;
            this.btnUpdateVisible = false;
            this.btnDeleteVisible = false;
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private AuditPrice EntityGet()
        {
            AuditPrice entity = new AuditPrice();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtQCode_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtQItemName.Text = "";
                txtQItemStd.Text = "";
                txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode,ItemModel FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
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