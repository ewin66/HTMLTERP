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
    public partial class frmWHALarmDts : frmAPBaseUISin
    {
        public frmWHALarmDts()
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
            if (!Common.CheckLookUpEditBlank(drpQWHAlarmID))
            {
                tempStr += " AND WHAlarmID = " + SysString.ToDBString(drpQWHAlarmID.EditValue.ToString());
            }
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }

            tempStr += " AND WHAlarmID IN(SELECT ID FROM WH_WHAlarm WHERE 1=1 AND ItemTypeID=" + FormListAID + ")";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_WHALarmDts";
            this.HTDataList = gridView1;
            Common.BindWHAlarmType(drpQWHAlarmID, FormListAID, false);
            drpQWHAlarmID_EditValueChanged(null,null);

            if (this.FormListAID == 1)
            {
                label2.Text = "ɴ�߱���";
                label5.Text = "ɴ��Ʒ��";
                label4.Text = "ɴ��֧��";
                label3.Text = "ɴ�߳ɷ�";
            }
            if (this.FormListAID == 2)
            {
                label2.Text = "ԭ�ϱ���";
                label5.Text = "ɴ��Ʒ��";
                label4.Text = "ԭ�Ϲ��";
                label3.Text = "ԭ������";
            }
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WHALarmDts EntityGet()
        {
            WHALarmDts entity = new WHALarmDts();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void drpQWHAlarmID_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }
    }
}