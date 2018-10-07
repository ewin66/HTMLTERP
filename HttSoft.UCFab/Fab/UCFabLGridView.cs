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
    /// 功能：加载面料码单GridView模式
    /// 作者：陈加海
    /// 日期：2014-3-28
    /// </summary>
    public partial class UCFabLGridView : UCFabBaseLoadCtl
    {
        public UCFabLGridView()
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

        #region 属性
      



        /// <summary>
        /// 获取选择的数据源
        /// </summary>
        public DataTable UCSelectDataSource
        {
            get
            {
                DataTable outdt = UCDataSource.Clone();

                DataRow[] drA = UCDataSource.Select("SelectFlag=1");//寻找选择的代码
                for (int i = 0; i < drA.Length; i++)
                {
                    DataRow outdr = outdt.NewRow();
                    for (int j = 0; j < outdt.Columns.Count; j++)//循环复制
                    {
                        outdr[j] = drA[i][j];
                    }
                }
                return outdt;
            }
        }
        #endregion

        #region 外部调用方法


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public override void UCAct()
        {
            BindGrid();
            if (UCAllowKPFlag)
            {
                this.gridView1.GridControl.ContextMenuStrip = cMenuLoadFab;
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        public override void UCSelectAll()
        {
            foreach (DataRow dr in UCDataSource.Rows)
            {
                dr["SelectFlag"] = 1;
            }
            
        }

        /// <summary>
        /// 反选
        /// </summary>
        public override void UCSelectFan()
        {
            foreach (DataRow dr in UCDataSource.Rows)
            {
                if (SysConvert.ToInt32(dr["SelectFlag"]) == 1)
                {
                    dr["SelectFlag"] = 0;
                }
                else
                {
                    dr["SelectFlag"] = 1;
                }
            }
        }


        /// <summary>
        /// 取消一个选项，外部调用
        /// </summary>
        /// <param name="p_ISN"></param>
        public override void UCCancelOne(string p_ISN)
        {
            DataRow[] drA = UCDataSource.Select("BoxNo="+SysString.ToDBString(p_ISN));
            if (drA.Length == 1)
            {
                drA[0]["SelectFlag"] = 0;
            }
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
        private void UCFabLGridView_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;

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
                int selectFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "SelectFlag"));
                if (selectFlag == 1)//选择
                {
                    e.Appearance.BackColor = UCSelectColor;
                }
                else//未选
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

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)//按住了Shift键盘
                {
                    if (UCCurrnetFocusIndex != -1)//前一聚焦行号已存在
                    {
                        for (int i = UCCurrnetFocusIndex + 1; i < gridView1.FocusedRowHandle; i++)//防止死循环调用
                        {
                            UCDataSource.Rows[i]["SelectFlag"] = UCDataSource.Rows[gridView1.FocusedRowHandle]["SelectFlag"];
                        }
                    }
                }

                UCCurrnetFocusIndex = gridView1.FocusedRowHandle;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 开匹操作
        /// <summary>
        /// 开匹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiLoadFabKP_Click(object sender, EventArgs e)
        {
            try
            {
                UCKP(SysConvert.ToString(cmiLoadFabKP.Tag));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 右键菜单打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuLoadFab_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                string ucisn = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BoxNo"));
                if (ucisn != string.Empty)
                {
                    cmiLoadFabKP.Tag = ucisn;
                }
                //Control ctl = (sender as ContextMenuStrip).SourceControl;
                //if (ctl is UCFabLTileSimple)
                //{
                //    cmiLoadFabKP.Tag = ((UCFabLTileSimple)ctl).UCISN;
                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void gridControlDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
