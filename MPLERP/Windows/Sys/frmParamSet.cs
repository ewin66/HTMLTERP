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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：参数管理表
    /// 作者：刘德苏
    /// 日期：2012-4-17
    ///操作：新增
    public partial class frmParamSet : frmAPBaseUISin
    {
        public frmParamSet()
        {
            InitializeComponent();
        }

        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(22, ToolButtonName.btnQuery.ToString(), "查询", false, btnQuery_Click, eShortcut.F5);
            this.ToolBarItemAdd(22, ToolButtonName.btnQueryAdvance.ToString(), "更多查询", false, btnQueryAdvance_Click);
            this.ToolBarItemAdd(13, ToolButtonName.btnBrowse.ToString(), "浏览", false, btnBrowse_Click, eShortcut.CtrlB);
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "修改", false, btnUpdate_Click, eShortcut.F2);
            this.ToolBarItemAdd(32, ToolButtonName.btnToExcel.ToString(), "导出列表", true, btnToExcel_Click, eShortcut.F9);
            this.ToolBarCItemAdd(ToolButtonName.drpPrintFile.ToString(), 120);
            BindReport(ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString()));
        }

        
        #endregion
     
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtQCode.Text.Trim() != "")//查询
            {
                tempStr += " AND Code LIKE " + SysString.ToDBString("%" + txtQCode.Text.Trim() + "%");
            }
            if (txtQName.Text.Trim() != "")//查询
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtQName.Text.Trim() + "%");
            }
            tempStr += " AND ShowFlag=1";
            tempStr += " ORDER BY ID";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ParamSetRule rule = new ParamSetRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ParamSetRule rule = new ParamSetRule();
            ParamSet entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sys_ParamSet";
            this.HTDataList = gridView1;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ParamSet EntityGet()
        {
            ParamSet entity = new ParamSet();
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
        private void txtQCode_EditValueChanged(object sender, EventArgs e)
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

        private void btnSetPDDate_Click(object sender, EventArgs e)
        {
            try
            {
                ParamSetRule rule = new ParamSetRule();
                rule.RUpdatePDDate();
                this.ShowInfoMessage("已处理成功，查看库存数据");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        
    }
}