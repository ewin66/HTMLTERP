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
    /// 功能：物品类型分类
    /// </summary>
    public partial class frmItemClass :frmAPBaseUISin
    {
        public frmItemClass()
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

            if (SysConvert.ToInt32(drpqQItemTypeID.EditValue) != 0)
            {
                tempStr += " AND ItemTypeID=" + SysString.ToDBString(SysConvert.ToInt32(drpqQItemTypeID.EditValue));
            }

            if (txtQCode.Text.Trim() != "")
            {
                tempStr += " AND Code LIKE" + SysString.ToDBString("%"+txtQCode.Text.Trim()+"%");
            }
            if (txtQName.Text.Trim() != "")
            {
                tempStr += " AND Name LIKE" + SysString.ToDBString("%"+txtQName.Text.Trim()+"%");
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemClassRule rule = new ItemClassRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ItemClass";            
            this.HTDataList = gridView1;

            Common.BindItemType(drpqQItemTypeID, true);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemClass EntityGet()
        {
            ItemClass entity = new ItemClass();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}