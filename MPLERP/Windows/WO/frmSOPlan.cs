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
    public partial class frmSOPlan : frmAPBaseUISin
    {
        public frmSOPlan()
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
            if (txtCode.Text.Trim() !="")
            {
                tempStr += " AND Code LIKE" + SysString.ToDBString("%"+txtCode.Text.Trim()+""); ;
            }
            if (txtSO.Text.Trim() !="")
            {
                tempStr += " AND SO LIKE"+SysString.ToDBString("%"+txtSO.Text.Trim()+"%");
            }
            if (chkInDate.Checked)
            {
                tempStr += " AND InDate BETWEEN " + SysString.ToDBString(txtQInDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQInDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");

            }
            if (chkNeedDate.Checked)
            {
                tempStr += " AND NeedDate BETWEEN " + SysString.ToDBString(txtNeedDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtNeedDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");

            }
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(drpQVendorID.EditValue.ToString());
            }
            if (!Common.CheckLookUpEditBlank(drpQCompanyTypeID))
            {
                tempStr += " AND CompanyTypeID = " + SysString.ToDBString(drpQCompanyTypeID.EditValue.ToString());
            }
            if (!Common.CheckLookUpEditBlank(drpQSaleOPID))
            {
                tempStr += " AND MakeOPID = " + SysString.ToDBString(drpQSaleOPID.EditValue.ToString());
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


            tempStr += " ORDER BY Code DESC ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SOPlanRule rule = new SOPlanRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_SOPlan";
            this.HTDataList = gridView1;

            //Common.BindOPID(drpQSaleOPID, true);
            //Common.BindCompanyType(drpQCompanyTypeID, true);
            //Common.BindVendor(drpQVendorID, new int[] {  (int)EnumVendorType.客户, (int)EnumVendorType.全部 }, true);//客户
        
            txtQInDateS.DateTime = DateTime.Now.Date.AddMonths(-1);
            txtQInDateE.DateTime = DateTime.Now.Date;
            txtNeedDateS.DateTime = DateTime.Now.Date.AddMonths(-1);
            txtNeedDateE.DateTime = DateTime.Now.Date;
            ///隐藏按钮
         
        
            txtCode_EditValueChanged(null, null);

        }


        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindOPID(drpQSaleOPID, true);
            Common.BindCompanyType(drpQCompanyTypeID, true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.全部 }, true);//客户
        
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SOPlan EntityGet()
        {
            SOPlan entity = new SOPlan();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_EditValueChanged(object sender, EventArgs e)
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
                //txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    //txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
                txtCode_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }
    }
}