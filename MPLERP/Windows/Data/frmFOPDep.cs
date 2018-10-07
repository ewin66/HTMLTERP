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
    public partial class frmFOPDep : frmAPBaseUISin
    {
        public frmFOPDep()
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
            if (txtName.Text.Trim() != string.Empty)
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }
            if (!Common.CheckLookUpEditBlank(drpDepID))
            {
                tempStr += " AND DepID = " + SysString.ToDBString(SysConvert.ToString(drpDepID.EditValue));
            }
            tempStr += "ORDER BY CLSA ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FOPDepRule rule = new FOPDepRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_FOPDep";
            this.HTDataList = gridView1;
            Common.BindDep(drpDepID);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FOPDep EntityGet()
        {
            FOPDep entity = new FOPDep();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }
    }
}