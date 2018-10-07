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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
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
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_WHALarmDts";
            this.HTDataList = gridView1;
            Common.BindWHAlarmType(drpQWHAlarmID, FormListAID, false);
            drpQWHAlarmID_EditValueChanged(null,null);

            if (this.FormListAID == 1)
            {
                label2.Text = "纱线编码";
                label5.Text = "纱线品名";
                label4.Text = "纱线支数";
                label3.Text = "纱线成份";
            }
            if (this.FormListAID == 2)
            {
                label2.Text = "原料编码";
                label5.Text = "纱线品名";
                label4.Text = "原料规格";
                label3.Text = "原料名称";
            }
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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