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
    /// 功能：加载布横向列表
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// 
    /// 自动创建列数量，行是自动增长的
    /// </summary>
    public partial class UCFabLTileSimpleGroup : UCFabBaseLoadCtl
    {
        public UCFabLTileSimpleGroup()
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
                if (ctl is UCFabLTileSimple)
                {
                    UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
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
                if (ctl is UCFabLTileSimple)
                {
                    UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
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
                if (ctl is UCFabLTileSimple)
                {
                    UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
                    if (ucf.UCISN == p_ISN)
                    {
                        ucf.UCChecked = false;
                    }
                }
            }
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


            int firstColumnWidth = 55 + 1;
            int firstRowHeight = 23 + 1;


            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                int xIndex = i % (p_ColumnCount);//水平 取余 小尺寸，倍率2 *2
                int yIndex = i / (p_ColumnCount);//垂直 取整 小尺寸，倍率2 * 2

                int colorIndex = 1;//色系
                //if (xIndex % 2 == 1)//取余
                //{
                //    colorIndex = 2;
                //}


                if (xIndex == 0)//创建一个起始列
                {
                    UCFabLTileSimpleFirstColumn ucftc = CreateFabTileFirstColumnOne(xIndex, yIndex, firstRowHeight);
                    ucftc.UCRowIndex = yIndex + 1;
                    panGroup.Controls.Add(ucftc);
                }
                if (yIndex == 0)//创建一个起始行
                {
                    UCFabLTileSimpleFirstRow ucftr = CreateFabTileFirstRowOne(xIndex, yIndex, firstColumnWidth);
                    ucftr.UCColIndex = xIndex + 1;
                    panGroup.Controls.Add(ucftr);
                }


                UCFabLTileSimple ucft = CreateFabTileOne(xIndex, yIndex, firstColumnWidth, firstRowHeight);
                ucft.IniValue(dtSource.Rows[i]["BoxNo"].ToString()
                    , new string[] { dtSource.Rows[i]["SubSeq"].ToString(), dtSource.Rows[i]["Qty"].ToString(), dtSource.Rows[i]["JarNum"].ToString() }
                    , SysConvert.ToBoolean(SysConvert.ToInt32(dtSource.Rows[i]["SelectFlag"])), colorIndex);
                ucft.UCRowIndex = i;//磁贴序号
                panGroup.Controls.Add(ucft);

            }
        }


        /// <summary>
        /// 创建磁贴一个 第一列
        /// </summary>
        /// <param name="p_XIndex">水平序号</param>
        /// <param name="p_YIndex">垂直序号</param>
        UCFabLTileSimpleFirstColumn CreateFabTileFirstColumnOne(int p_XIndex, int p_YIndex, int p_FirstRowHeight)
        {
            int splitpixel = 2;//间隔像素
            int tempHeight = 44;
            UCFabLTileSimpleFirstColumn ucftc = new UCFabLTileSimpleFirstColumn();
            ucftc.Location = new System.Drawing.Point(splitpixel, p_YIndex * tempHeight + splitpixel * (p_YIndex + 1) + p_FirstRowHeight);
            ucftc.Name = "ucftfc" + (10000 * p_YIndex + p_XIndex);
            //ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            //ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucftc.MouseClick += new MouseEventHandler(panGroup_MouseClick);//快速点击及滚动用
            return ucftc;
        }

        /// <summary>
        /// 创建磁贴一个 第一行
        /// </summary>
        /// <param name="p_XIndex">水平序号</param>
        /// <param name="p_YIndex">垂直序号</param>
        UCFabLTileSimpleFirstRow CreateFabTileFirstRowOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth)
        {
            int splitpixel = 2;//间隔像素
            int tempWidth = 85;
            int setWidth = UCFabParamSet.GetIntValueByID(6014);//码单选择简洁模式磁贴宽度
            if (setWidth > 0)
            {
                tempWidth = setWidth;
            }
            int tempHeight = 23;


            UCFabLTileSimpleFirstRow ucftr = new UCFabLTileSimpleFirstRow();
            ucftr.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, splitpixel);
            ucftr.Name = "ucftfr" + (10000 * p_YIndex + p_XIndex);
            ucftr.Size = new System.Drawing.Size(tempWidth, tempHeight);
            //ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucftr.MouseClick += new MouseEventHandler(panGroup_MouseClick);//快速点击及滚动用
            return ucftr;
        }

        /// <summary>
        /// 创建磁贴一个
        /// </summary>
        /// <param name="p_XIndex">水平序号</param>
        /// <param name="p_YIndex">垂直序号</param>
        UCFabLTileSimple CreateFabTileOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth, int p_FirstRowHeight)
        {
            int splitpixel = 2;//间隔像素
            int tempWidth = 85, tempHeight = 44;

            int setWidth = UCFabParamSet.GetIntValueByID(6014);//码单选择简洁模式磁贴宽度
            if (setWidth > 0)
            {
                tempWidth = setWidth;
            }

            UCFabLTileSimple ucft = new UCFabLTileSimple();
            ucft.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, p_YIndex * tempHeight + splitpixel * (p_YIndex + 1) + p_FirstRowHeight);
            ucft.Name = "ucft" + (10000 * p_YIndex + p_XIndex);
            ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            //ucft.UCBackColorIndex = p_ColorIndex;
            ucft.object_CheckedChanged += new UCFabLTileCheckChanged(UCFabLTile_CheckChanged);//关联委托事件
            //ucft.MouseClick += new MouseEventHandler(panGroup_MouseClick);//快速点击及滚动用

            ucft.UCControl_RowIndexChanged += new UCFabRowIndexChanged(UCControl_RowIndexChanged);

            if (UCAllowKPFlag)//允许开匹
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

            UCFabLTileSimple ucft = (UCFabLTileSimple)sender;
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
                        if (ctl is UCFabLTileSimple)
                        {
                            UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
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
                Control ctl= (sender as ContextMenuStrip).SourceControl;
                if (ctl is UCFabLTileSimple)
                {
                    cmiLoadFabKP.Tag = ((UCFabLTileSimple)ctl).UCISN;
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
