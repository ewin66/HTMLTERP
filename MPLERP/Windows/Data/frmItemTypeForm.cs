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
    public partial class frmItemTypeForm : frmAPBaseUISin
    {
        public frmItemTypeForm()
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
            if (!Common.CheckLookUpEditBlank(drpQItemType))
            {
                tempStr += " AND ItemTypeID=" + SysString.ToDBString(drpQItemType.EditValue.ToString());
            }
            tempStr += " ORDER BY ItemTypeID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemTypeFormRule rule = new ItemTypeFormRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemTypeFormRule rule = new ItemTypeFormRule();
            ItemTypeForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ItemTypeForm";
            this.HTDataList = gridView1;
            Common.BindItemType(drpQItemType, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemTypeForm EntityGet()
        {
            ItemTypeForm entity = new ItemTypeForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

     

        #region
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQItemType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch(Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}