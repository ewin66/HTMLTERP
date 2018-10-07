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
using DevExpress.XtraGrid.Views.Base;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmOrderStep : frmAPBaseUISin
    {
        public frmOrderStep()
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
  
        }

       
        #endregion
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;

            if (txtName.Text.Trim() != "")
            {
                tempStr += " AND Name LIke " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }
            tempStr += " AND ShowFlag=1 ORDER BY Code";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            OrderStepRule rule = new OrderStepRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_OrderStep";
            this.HTDataList = gridView1;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OrderStep EntityGet()
        {
            OrderStep entity = new OrderStep();
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

        /// <summary>
        /// 给每一行赋颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                string ColorStr = SysConvert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["ColorStr"]));
                e.Appearance.BackColor = Color.YellowGreen;
                string[] tempstr = ColorStr.Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    e.Appearance.BackColor = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    e.Appearance.BackColor = Color.FromName(ColorStr);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion
    }
}