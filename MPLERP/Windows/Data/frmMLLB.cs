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
    /// 功能：面料类别查询
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmMLLB : frmAPBaseUISin
    {
        public frmMLLB()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]

        /// <summary>
        /// 查询条件
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtName.Text.Trim() != "")//查询。
            {
                tempStr = " AND Name LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }

            tempStr += " ORDER BY Sort";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            MLLBRule rule = new MLLBRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            MLLBRule rule = new MLLBRule();
            MLLB entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_MLLB";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private MLLB EntityGet()
        {
            MLLB entity = new MLLB();
            entity.ID = HTDataID;      
            return entity;
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
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