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
    /// ������
    /// 
    /// </summary>
    public partial class frmCLS : frmAPBaseUISin
    {
        public frmCLS()
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
            if (txtQCLSNM.Text.Trim() != "")//��ѯ
            {
                tempStr += " AND CLSNM LIKE " + SysString.ToDBString("%" + txtQCLSNM.Text.Trim() + "%");
            }
            if (!Common.CheckLookUpEditBlank(drpQCLSList))
            {
                tempStr += " AND CLSListID =" + SysString.ToDBString(SysConvert.ToInt32(drpQCLSList.EditValue));
            }
            tempStr += " ORDER BY CLSListID,CLSIDC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            CLSRule rule = new CLSRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CLS";
            this.HTDataList = gridView1;

            Common.BindCLSList(drpQCLSList, true);
            btnQuery_Click(null, null);
            SetTabIndex(0, groupControl1);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CLS EntityGet()
        {
            CLS entity = new CLS();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQCLSNM_EditValueChanged(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }

    }
}