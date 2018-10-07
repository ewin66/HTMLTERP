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
    /// ���ܣ��ֿ����
    /// </summary>
    public partial class frmWH : frmAPBaseUIForm
    {
        public frmWH()
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
            if (txtQWHID.Text.Trim() != "")
            {
                tempStr += " AND WHID LIKE" + SysString.ToDBString("%" + txtQWHID.Text.Trim() + "%");
            }
            if (txtQWHNM.Text.Trim() != "")
            {
                tempStr += " AND WHNM LIKE" + SysString.ToDBString("%" + txtQWHNM.Text.Trim() + "%");
            }
            //if (!Common.CheckLookUpEditBlank(drpQCompanyTypeID))
            //{
            //    tempStr += " AND CompanyTypeID =" + SysString.ToDBString(drpQCompanyTypeID.EditValue.ToString());
            //}
            tempStr += " ORDER BY WHID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            WHRule rule = new WHRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WHRule rule = new WHRule();
            WH entity = EntityGet();
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
            this.HTDataTableName = "WH_WH";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);
            //Common.BindCompanyType(drpQCompanyTypeID, false);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WH EntityGet()
        {
            WH entity = new WH();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtQWHID_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

    }
}