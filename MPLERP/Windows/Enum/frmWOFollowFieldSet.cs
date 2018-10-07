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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
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
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WOFollowFieldSetRule rule = new WOFollowFieldSetRule();
            WOFollowFieldSet entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_WOFollowFieldSet";
            this.HTDataList = gridView1;

            Common.BindWOFollowType(drpQWOFollowTypeID, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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