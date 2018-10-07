using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：选择码单GridView模式
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// </summary>
    public partial class UCFabSGridView : UCFabBaseSelectCtl
    {
        public UCFabSGridView()
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
        /// 取消一行
        /// </summary>
        public override void UCCancelOne(string p_ISN)
        {
            base.UCCancelOne(p_ISN);
        }
        #endregion


        #region 内部方法
        void BindGrid()
        {
            gridView1.GridControl.DataSource = UCDataSource;
            gridView1.GridControl.Show();
        }
        #endregion


        #region 加载事件
        private void UCFabSGridView_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
                //UCFabCommon.GridViewRowIndexBind(gridView1);
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

        /// <summary>
        /// 数据值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "SelectFlag")
                {
                    UCCancelOne(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BoxNo")));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 值改变聚焦
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkGridSelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblFocus.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


       

       
    }
}
