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
    /// 功能：公司别管理表
    /// 作者：刘德苏
    /// 日期：2012-4-20
    /// 操作：新增
    public partial class frmCompanyType : frmAPBaseUISin
    {
        public frmCompanyType()
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
            if (!txtQName.Text.Trim().Equals(""))
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtQName.Text.Trim() + "%");
            }
            tempStr += " ORDER BY Code";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            CompanyTypeRule rule = new CompanyTypeRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CompanyTypeRule rule = new CompanyTypeRule();
            CompanyType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_CompanyType";
            this.HTDataList = gridView1;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CompanyType EntityGet()
        {
            CompanyType entity = new CompanyType();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        #region 快速查询
        /// <summary>
        ///快速查询 
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
                ShowMessage(E.Message);
            }

        }
        #endregion
    }
}