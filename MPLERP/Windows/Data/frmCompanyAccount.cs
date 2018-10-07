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
    public partial class frmCompanyAccount : frmAPBaseUISin
    {
        public frmCompanyAccount()
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
            if (!Common.CheckLookUpEditBlank(drpQCompanyID))//��ѯ
            {
                tempStr += " AND CompanyID = " + SysString.ToDBString(drpQCompanyID.EditValue.ToString());
            }
            if (txtAccount.Text.Trim()!="")//��ѯ
            {
                tempStr += " AND Account LIKE " + SysString.ToDBString("%" + txtAccount.Text.Trim() + "%");
            }
            tempStr += " ORDER BY CompanyID";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            CompanyAccountRule rule = new CompanyAccountRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CompanyAccountRule rule = new CompanyAccountRule();
            CompanyAccount entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CompanyAccount";
            this.HTDataList = gridView1;

            Common.BindCompanyType(drpQCompanyID, true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CompanyAccount EntityGet()
        {
            CompanyAccount entity = new CompanyAccount();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        #region �����¼�
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQCompanyID_EditValueChanged(object sender, EventArgs e)
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
       
    }
}