using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：录入码单 列表模式
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// </summary>
    public partial class UCFabIGridView : UCFabBaseInputCtl
    {
        public UCFabIGridView()
        {
            InitializeComponent();
        }

        #region 临时静态变量，后续移动到全局变量，或配置数据库内
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//默认色系

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//偶数列色系 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//偶数列色系 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//选择色系
        #endregion

        #region 外部调用方法


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public override void UCAct()
        {
            BindGrid();
        }

        /// <summary>
        /// 执行重新赋值，用在批量录入时
        /// </summary>
        public override void UCBind()
        {
            BindGrid();
        }

        /// <summary>
        /// 设置当前聚焦行号
        /// </summary>
        public override void UCSetCurrectIndex()
        {
            UCCurrnetFocusIndex = gridView1.FocusedRowHandle;
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 绑定Grid
        /// </summary>
        void BindGrid()
        {
            UCFabCommon.AddDtRow(UCDataSource, UCInputCount);
            gridView1.GridControl.DataSource = UCDataSource;
            gridView1.GridControl.Show();
        }
        #endregion

        #region 控件加载事件
        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabIGridView_Load(object sender, EventArgs e)
        {
            try
            {
                UCFabCommon.GridViewRowIndexBind(gridView1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 行变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (e.RowHandle % 2 == 1)
                {
                    e.Appearance.BackColor = UCBackColorS2;
                }
                else
                {
                    e.Appearance.BackColor = UCBackColor2;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
        #endregion

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //this.BaseFocusLabel.Focus();
                    
                    SendKeys.Send("{DOWN}");
                    SendKeys.Send("{Enter}");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtSubSeq_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //this.BaseFocusLabel.Focus();

                    SendKeys.Send("{DOWN}");
                    SendKeys.Send("{Enter}");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
    }
}
