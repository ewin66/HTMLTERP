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
    /// 部门
    /// </summary>
    public partial class frmDep : frmAPBaseUISin
    {
        public frmDep()
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
            if (txtName.Text.Trim() != "")//查询。
            {
                tempStr = " AND Name LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }

            tempStr += " ORDER BY Code,ID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            DepRule rule = new DepRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            DepRule rule = new DepRule();
            Dep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Dep";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Dep EntityGet()
        {
            Dep entity = new Dep();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}