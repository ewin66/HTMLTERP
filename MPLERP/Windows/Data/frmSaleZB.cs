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
    public partial class frmSaleZB : frmAPBaseUISin
    {
        public frmSaleZB()
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
            if (!txtQZB.Text.Trim().Equals(""))
            {
                tempStr += " AND CName LIKE " + SysString.ToDBString("%" + txtQZB.Text.Trim() + "%");
            }
            if (!txtQCode.Text.Trim().Equals(""))
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtQCode.Text.Trim() + "%"); 
            }
            tempStr += " ORDER BY Code";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleGroupRule rule = new SaleGroupRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SaleGroupRule rule = new SaleGroupRule();
            SaleGroup entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_SaleGroup";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleGroup EntityGet()
        {
            SaleGroup entity = new SaleGroup();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion        

        #region 其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQName_EditValueChanged(object sender, EventArgs e)
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

        private void txtQCName_EditValueChanged(object sender, EventArgs e)
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