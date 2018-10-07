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
    public partial class frmWOFollowFieldSet : frmAPBaseUISin
    {
        public frmWOFollowFieldSet()
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
            //
            if (SysConvert.ToInt32(drpQWOFollowTypeID.EditValue) != 0)
            {
                tempStr = " AND WOFollowTypeID = " + SysString.ToDBString(SysConvert.ToInt32(drpQWOFollowTypeID.EditValue));
            }

            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_WOFollowFieldSet";
            this.HTDataList = gridView1;

            Common.BindWOFollowType(drpQWOFollowTypeID, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WOFollowFieldSet EntityGet()
        {
            WOFollowFieldSet entity = new WOFollowFieldSet();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void drpQWOFollowTypeID_EditValueChanged(object sender, EventArgs e)
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
    }
}