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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
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
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            FOPDepRule rule = new FOPDepRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FOPDepRule rule = new FOPDepRule();
            FOPDep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_FOPDep";
            this.HTDataList = gridView1;
            Common.BindDep(drpDepID);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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