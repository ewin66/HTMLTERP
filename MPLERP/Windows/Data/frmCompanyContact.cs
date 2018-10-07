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
    public partial class frmCompanyContact : frmAPBaseUISin
    {
        public frmCompanyContact()
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
                tempStr += " AND CompanyID = " + SysString.ToDBString(drpQCompanyID.EditValue.ToString() );
            }

            if (!Common.CheckLookUpEditBlank(drpQDepID))//��ѯ
            {
                tempStr += " AND DepID = " + SysString.ToDBString(drpQDepID.EditValue.ToString());
            }

            tempStr += " ORDER BY CompanyID";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            CompanyContactRule rule = new CompanyContactRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CompanyContact";
            this.HTDataList = gridView1;
            Common.BindCompanyType(drpQCompanyID, true);
            Common.BindDep(drpQDepID, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CompanyContact EntityGet()
        {
            CompanyContact entity = new CompanyContact();
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

        private void drpQDepID_EditValueChanged(object sender, EventArgs e)
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