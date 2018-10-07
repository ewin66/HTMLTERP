using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.Sys;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：仓库平面图
    /// </summary>
    public partial class frmWHPlane : BaseForm
    {
        public frmWHPlane()
        {
            InitializeComponent();
        }


        #region 窗体事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        private void frmWHPlane_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindWHRight(radioGroup1, 0, false);
                //btnQuery_ItemClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 按钮事件
        /// <summary>
        /// 查询
        /// </summary>
        private void btnQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string whid = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value.ToString();
                WHPlaneProc.CallWH(whid, groupControlWH, toolTip1);	
                //WHPlaneProc.CallWH(saveWHID, groupControlWH,toolTip1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        private void radioGroup1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                btnQuery_ItemClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


    }
}