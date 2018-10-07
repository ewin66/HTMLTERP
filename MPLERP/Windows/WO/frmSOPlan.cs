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


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
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
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            SOPlanRule rule = new SOPlanRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_SOPlan";
            this.HTDataList = gridView1;

            //Common.BindOPID(drpQSaleOPID, true);
            //Common.BindCompanyType(drpQCompanyTypeID, true);
            //Common.BindVendor(drpQVendorID, new int[] {  (int)EnumVendorType.�ͻ�, (int)EnumVendorType.ȫ�� }, true);//�ͻ�
        
            txtQInDateS.DateTime = DateTime.Now.Date.AddMonths(-1);
            txtQInDateE.DateTime = DateTime.Now.Date;
            txtNeedDateS.DateTime = DateTime.Now.Date.AddMonths(-1);
            txtNeedDateE.DateTime = DateTime.Now.Date;
            ///���ذ�ť
         
        
            txtCode_EditValueChanged(null, null);

        }


        /// <summary>
        /// ��ʼ��ˢ������(�������ʱ���û�ˢ�°�ťʱ����)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindOPID(drpQSaleOPID, true);
            Common.BindCompanyType(drpQCompanyTypeID, true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.ȫ�� }, true);//�ͻ�
        
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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
        /// ���ٲ�ѯ
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