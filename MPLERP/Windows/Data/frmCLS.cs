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
    /// 类别管理
    /// 
    /// </summary>
    public partial class frmCLS : frmAPBaseUISin
    {
        public frmCLS()
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
            if (txtQCLSNM.Text.Trim() != "")//查询
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
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            CLSRule rule = new CLSRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
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

        #region 自定义方法
        /// <summary>
        /// 获得实体
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
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQCLSNM_EditValueChanged(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }

    }
}