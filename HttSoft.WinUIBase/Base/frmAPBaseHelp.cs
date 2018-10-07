using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using DevExpress.XtraGrid.Views.Base;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 帮助页面
    /// </summary>
    public partial class frmAPBaseHelp : BaseForm
    {
        public frmAPBaseHelp()
        {
            InitializeComponent();
        }

        #region 全局变量、属性
        int SaveID = 0;
        public int HelpWinListID = 0;
        public int HelpHeadTypeID = 0;
        public int HelpSubTypeID = 0;
        public string HelpFormCaption = string.Empty;
        #endregion

        #region 自定义方法
        /// <summary>
        /// 绑定GRID数据
        /// </summary>
        private void BindGrid()
        {
            string conditionStr = string.Empty;
            conditionStr += " AND WinListID=" + HelpWinListID;
            conditionStr += " AND HeadTypeID=" + HelpHeadTypeID;
            conditionStr += " AND SubTypeID=" + HelpSubTypeID;
            SysStudyDicRule rule = new SysStudyDicRule();
            gridView1.GridControl.DataSource = rule.RShow(conditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        private void SetEntity()
        {
            SysStudyDic entity = new SysStudyDic();
            entity.ID = SaveID;
            if (entity.SelectByID())
            {
                txtTitle.Text = entity.Title;
                txtContext.Text = entity.Context;
                lblInfo.Text = "添加：" + entity.AddOPID + "(" + entity.AddTime.ToString("yyyy-MM-dd HH:mm") + ") 最近编辑：" + entity.UpdOPID + "(" + entity.UpdTime.ToString("yyyy-MM-dd HH:mm") + ")";
            }
            else
            {
                txtTitle.Text = "帮助内容未定义";
                txtContext.Text = "帮助内容未定义";
                lblInfo.Text = "";
            }
        }

        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAPBaseHelp_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += "--"+HelpFormCaption;
                this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);
                this.gridViewBindEventA1(gridView1);

                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 重置实体到控件
        /// </summary>
        /// <param name="sender"></param>
        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            SaveID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
            SetEntity();
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 编辑窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmAPBaseHelpEdit frm = new frmAPBaseHelpEdit();
                frm.HelpWinListID = this.HelpWinListID;
                frm.HelpHeadTypeID = this.HelpHeadTypeID;
                frm.HelpSubTypeID = this.HelpSubTypeID;
                frm.HelpFormCaption = this.HelpFormCaption;
                frm.ShowDialog();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}