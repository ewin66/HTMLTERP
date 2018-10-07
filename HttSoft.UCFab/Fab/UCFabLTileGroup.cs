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
    /// 功能：加载布磁贴列表
    /// 作者：陈加海
    /// 日期：2014-3-27
    /// 
    /// 自动创建列数量，行是自动增长的
    /// </summary>
    public partial class UCFabLTileGroup : UCFabBaseLoadCtl
    {
        public UCFabLTileGroup()
        {
            InitializeComponent();
            InitPanGroup();
        }
        #region 属性




        ///// <summary>
        ///// 获取选择的数据源
        ///// </summary>
        //public DataTable UCSelectDataSource
        //{
        //    get
        //    {
        //        DataTable outdt = UCDataSource.Clone();
        //        foreach (Control ctl in panGroup.Controls)//
        //        {
        //            if (ctl is UCFabLTile)
        //            {
        //                UCFabLTile ucf = (UCFabLTile)ctl;
        //                if (ucf.UCChecked)
        //                {
        //                    DataRow[] drA = UCDataSource.Select("BoxNo=" + ucf.UCISN);
        //                    if (drA.Length == 1)//找到条码
        //                    {
        //                        DataRow outdr = outdt.NewRow();
        //                        for (int i = 0; i < outdt.Columns.Count; i++)//循环复制
        //                        {
        //                            outdr[i] = drA[0][i];
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return outdt;
        //    }
        //}
        #endregion


        #region 外部调用方法


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public override void UCAct()
        {
            CreateFabTile(UCDataSource, UCColumnCount);
        }

        /// <summary>
        /// 全选
        /// </summary>
        public override void UCSelectAll()
        {
            foreach (Control ctl in panGroup.Controls)//
            {
                if (ctl is UCFabLTile)
                {
                    UCFabLTile ucf = (UCFabLTile)ctl;
                    ucf.UCChecked = true;
                }
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        public override void UCSelectFan()
        {
            foreach (Control ctl in panGroup.Controls)
            {
                if (ctl is UCFabLTile)
                {
                    UCFabLTile ucf = (UCFabLTile)ctl;
                    ucf.UCChecked = !ucf.UCChecked;
                }
            }
        }


        /// <summary>
        /// 取消一个选项，外部调用
        /// </summary>
        /// <param name="p_ISN"></param>
        public override void UCCancelOne(string p_ISN)
        {
            foreach (Control ctl in panGroup.Controls)
            {
                if (ctl is UCFabLTile)
                {
                    UCFabLTile ucf = (UCFabLTile)ctl;
                    if (ucf.UCISN == p_ISN)
                    {
                        ucf.UCChecked = false;
                    }
                }
            }
        }

        /// <summary>
        /// 设置当前聚焦行号
        /// </summary>
        public override void UCSetCurrectIndex()
        {
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 创建磁贴
        /// </summary>
        /// <param name="dtSource">数据源，列0/1/2/3/4:选择标志/BoxNo/卷号/数量/缸号</param>
        /// <param name="p_ColumnCount">列数量</param>
        void CreateFabTile(DataTable dtSource, int p_ColumnCount)
        {

            RemoveUserCtl(panGroup);
            //panGroup.Controls.Clear();//清除界面上所有控件
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                int xIndex = i % p_ColumnCount;//水平 取余
                int yIndex = i / p_ColumnCount;//垂直 取整

                int colorIndex = 1;//色系
                //if (xIndex % 2 == 1)//取余
                //{
                //    colorIndex = 2;
                //}

                UCFabLTile ucft = CreateFabTileOne(xIndex, yIndex);
                ucft.IniValue(dtSource.Rows[i]["BoxNo"].ToString()
                    , new string[] { dtSource.Rows[i]["SubSeq"].ToString(), dtSource.Rows[i]["Qty"].ToString(), dtSource.Rows[i]["JarNum"].ToString(), dtSource.Rows[i]["Weight"].ToString(), dtSource.Rows[i]["GoodsLevel"].ToString(), dtSource.Rows[i]["Yard"].ToString() }
                    , SysConvert.ToBoolean(SysConvert.ToInt32(dtSource.Rows[i]["SelectFlag"])), colorIndex);
                ucft.UCRowIndex = i;//磁贴序号
                panGroup.Controls.Add(ucft);

            }
        }

        /// <summary>
        /// 创建磁贴一个
        /// </summary>
        /// <param name="p_XIndex">水平序号</param>
        /// <param name="p_YIndex">垂直序号</param>
        UCFabLTile CreateFabTileOne(int p_XIndex, int p_YIndex)
        {
            int splitpixel = 2;//间隔像素
            int tempWidth = 175, tempHeight = 175;

            UCFabLTile ucft = new UCFabLTile();
            ucft.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1), p_YIndex * tempHeight + splitpixel * (p_YIndex + 1));
            ucft.Name = "ucft" + (10000 * p_YIndex + p_XIndex);
            ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            //ucft.UCBackColorIndex = p_ColorIndex;
            ucft.object_CheckedChanged += new UCFabLTileCheckChanged(UCFabLTile_CheckChanged);//关联委托事件
            //ucft.MouseClick += new MouseEventHandler(panGroup_MouseClick);//快速点击及滚动用

            ucft.UCControl_RowIndexChanged += new UCFabRowIndexChanged(UCControl_RowIndexChanged);

            if (UCAllowKPFlag)
            {
                ucft.ContextMenuStrip = cMenuLoadFab;
            }
            return ucft;
        }

        /// <summary>
        /// Shift按键执行过程中
        /// </summary>
        bool tempTileShifFlag = false;
        /// <summary>
        /// 磁贴选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        void UCFabLTile_CheckChanged(object sender)
        {
            if (tempTileShifFlag)//在执行Shift事件中，不执行，防止死循环
            {
                return;
            }
            tempTileShifFlag = true;


            UCFabLTile ucft = (UCFabLTile)sender;
            DataRow[] drA = UCDataSource.Select(" BoxNo=" + SysString.ToDBString(ucft.UCISN));
            if (drA.Length == 1)
            {
                drA[0]["SelectFlag"] = SysConvert.ToInt32(ucft.UCChecked);
            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)//按住了Shift键盘
            {
                if (UCCurrnetFocusIndex != -1)//前一聚焦行号已存在
                {
                    for (int i = UCCurrnetFocusIndex + 1; i < ucft.UCRowIndex; i++)//防止死循环调用
                    {
                        UCDataSource.Rows[i]["SelectFlag"] = ucft.UCChecked;
                    }

                    foreach (Control ctl in panGroup.Controls)
                    {
                        if (ctl is UCFabLTile)
                        {
                            UCFabLTile ucf = (UCFabLTile)ctl;
                            if (ucf.UCRowIndex >= UCCurrnetFocusIndex + 1 && ucf.UCRowIndex <= ucft.UCRowIndex)
                            {
                                ucf.UCChecked = ucft.UCChecked;
                            }
                        }
                    }

                }
            }
            UCCurrnetFocusIndex = ucft.UCRowIndex;
            tempTileShifFlag = false;

        }

        /// <summary>
        /// 磁贴序号改变事件
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        void UCControl_RowIndexChanged(object sender, int rowIndex)
        {
            //UCCurrnetFocusIndex = rowIndex;
            panGroup_MouseClick(null, null);

        }

        /// <summary>
        /// 初始化Panel方法
        /// </summary>
        void InitPanGroup()
        {
            this.panGroup.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panGroup_MouseWheel);
        }

        private void panGroup_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                int tempValue = panGroup.VerticalScroll.Value;

                if (tempValue - e.Delta <= this.panGroup.VerticalScroll.Minimum)
                {
                    tempValue = 0;
                    panGroup.VerticalScroll.Value = tempValue;
                }
                else if (tempValue - e.Delta >= this.panGroup.VerticalScroll.Maximum)
                {
                    tempValue = this.panGroup.VerticalScroll.Maximum;
                    panGroup.VerticalScroll.Value = tempValue;
                }
                else
                {
                    panGroup.VerticalScroll.Value -= e.Delta;
                }


                panGroup.Refresh();
                panGroup.Invalidate();
                panGroup.Update();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void panGroup_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.panGroup.Focus();
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
                Control ctl = (sender as ContextMenuStrip).SourceControl;
                if (ctl is UCFabLTile)
                {
                    cmiLoadFabKP.Tag = ((UCFabLTile)ctl).UCISN;
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
