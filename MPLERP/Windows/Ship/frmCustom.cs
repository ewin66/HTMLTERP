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
    /// ���ܣ������䵥��Ʊ
    /// </summary>
    public partial class frmCustom : frmAPBaseUIForm
    {
        public frmCustom()
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
            //if (!Common.CheckLookUpEditBlank(drpQCompanyTypeID))
            //{
            //    tempStr += " AND CompanyTypeID = " + SysString.ToDBString(drpQCompanyTypeID.EditValue.ToString());
            //}
            if (drpQCurrency.EditValue.ToString() != "")
            {
                tempStr += " AND Currency = " + SysString.ToDBString(drpQCurrency.EditValue.ToString());
            }
            if (drpQShipMethod.EditValue.ToString() != "")
            {
                tempStr += " AND ShipMethod = " + SysString.ToDBString(drpQShipMethod.EditValue.ToString());
            }
            if (txtQContractNo.Text.Trim() != "")
            {
                tempStr += " AND ContractNo LIKE " + SysString.ToDBString("%"+txtQContractNo.Text.Trim()+"%");
            }
            if (txtQInvoiceNo.Text.Trim() != "")
                
            {
                tempStr += " AND InvoiceNo LIKE " + SysString.ToDBString("%" + txtQInvoiceNo.Text.Trim() + "%");
            }

            if (txtQIssueBank.Text.Trim() != "")
            {
                tempStr += " AND IssueBank LIKE " + SysString.ToDBString("%" + txtQIssueBank.Text.Trim() + "%");
            }

            if (txtQLCNO.Text.Trim() != "")
            {
                tempStr += " AND LCNO LIKE " + SysString.ToDBString("%" + txtQLCNO.Text.Trim() + "%");
            }

            if (txtQSCNo.Text.Trim() != "")
            {
                tempStr += " AND SCNo LIKE " + SysString.ToDBString("%" + txtQSCNo.Text.Trim() + "%");
            }

            if (txtQSO.Text.Trim() != "")
            {
                tempStr += " AND DSN LIKE " + SysString.ToDBString("%" + txtQSO.Text.Trim() + "%");
            }

            if (chkInvoiceDate.Checked)
            {
                tempStr += " AND InvoiceDate BETWEEN " + SysString.ToDBString(txtQInvoiceDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQInvoiceDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            tempStr += " AND CompanyTypeID ="+this.FormListAID;
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            CustomRule rule = new CustomRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CustomRule rule = new CustomRule();
            Custom entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Ship_Custom";
            this.HTDataList = gridView1;

            Common.BindCompanyType(drpQCompanyTypeID, true);
            Common.BindCLS(drpQShipMethod, this.HTDataTableName, "ShipMethod", true);
            Common.BindCurrency(drpQCurrency, true);

            txtQInvoiceDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQInvoiceDateE.DateTime = DateTime.Now.Date;

            SetTabIndex(0, groupControlQuery);


        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Custom EntityGet()
        {
            Custom entity = new Custom();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}