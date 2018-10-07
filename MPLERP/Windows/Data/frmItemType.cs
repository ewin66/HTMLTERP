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
    /// 功能：物品类型列表
    /// </summary>
    public partial class frmItemType : frmAPBaseUISin
    {
        public frmItemType()
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
            if (txtQItemTypeName.Text.Trim() != "")//查询
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtQItemTypeName.Text.Trim() + "%");
            }
            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemTypeRule rule = new ItemTypeRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemTypeRule rule = new ItemTypeRule();
            HttSoft.MLTERP.Data.ItemType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_ItemType";
            this.HTDataList = gridView1;

            Common.BindVendorType(drpGridVendorTypeID, false);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private HttSoft.MLTERP.Data.ItemType EntityGet()
        {
            HttSoft.MLTERP.Data.ItemType entity = new HttSoft.MLTERP.Data.ItemType();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion
    }
}