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
    public partial class frmBrand : frmAPBaseUISin
    {
        public frmBrand()
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
            if (txtQBrandID.Text.Trim() != "")//查询
            {
                tempStr += " AND BrandID LIKE " + SysString.ToDBString("%" + txtQBrandID.Text.Trim() + "%");
            }
            if (txtQBrandAttn.Text.Trim()!= "")//查询
            {
                tempStr += " AND BrandAttn LIKE " + SysString.ToDBString("%" + txtQBrandAttn.Text.Trim() + "%");
            }
            if (!Common.CheckLookUpEditBlank(drpQSaleOPID))
            {
                tempStr += " AND SaleOPID = " + SysString.ToDBString(drpQSaleOPID.EditValue.ToString());
            }
            if (txtQDesignName.Text.Trim() != "")
            {
                tempStr += " AND DesignName LIKE " + SysString.ToDBString("%" + txtQDesignName.Text.Trim() + "%");
            }
            tempStr += " ORDER BY BrandID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            BrandRule rule = new BrandRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Brand";
            this.HTDataList = gridView1;

           // Common.BindOPID(drpQSaleOPID, true);
            Common.BindOPID(drpQSaleOPID, this.HTDataTableName, "SaleOPID", true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Brand EntityGet()
        {
            Brand entity = new Brand();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion
    }
}