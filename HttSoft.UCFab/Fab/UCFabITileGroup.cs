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
    /// 功能：录入码单 磁贴Group模式
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// 
    /// 
    /// 自动创建列数量，行是自动增长的
    /// </summary>
    public partial class UCFabITileGroup : UCFabBaseInputCtl
    {
        public UCFabITileGroup()
        {
            InitializeComponent();
            InitPanGroup();
        }

        #region 属性

        #endregion

        #region 外部调用方法


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public override void UCAct()
        {
            UCFabCommon.AddDtRow(UCDataSource, UCInputCount);
            CreateFabTile(UCDataSource, UCColumnCount);
        }


        /// <summary>
        /// 执行重新赋值，用在批量录入时
        /// </summary>
        public override void UCBind()
        {
            BindFabTile();//刷新数据
        }

        #endregion

        #region 内部方法
        /// <summary>
        /// 重新赋值磁贴
        /// </summary>
        void BindFabTile()
        {
            foreach (Control ctl in panGroup.Controls)
            {
                if (ctl is UCFabITile)
                {
                    ((UCFabITile)ctl).UCBindData();
                }
            }
        }

       

        /// <summary>
        /// 创建磁贴
        /// </summary>
        /// <param name="dtSource">数据源，列0/1/2/3/4:选择标志/BoxNo/卷号/数量/缸号</param>
        /// <param name="p_ColumnCount">列数量</param>
        void CreateFabTile(DataTable dtSource, int p_ColumnCount)
        {


            panGroup.Controls.Clear();//清除界面上所有控件
            int firstColumnWidth = 46+1;
            int firstRowHeight = 27+1;
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                int xIndex = i % p_ColumnCount;//水平 取余
                int yIndex = i / p_ColumnCount;//垂直 取整

                int colorIndex = 1;//色系
                //if (xIndex % 2 == 1)//取余
                //{
                //    colorIndex = 2;
                //}


                if (xIndex == 0)//创建一个起始列
                {
                    UCFabITileFirstColumn ucftc = CreateFabTileFirstColumnOne(xIndex, yIndex, firstRowHeight);
                    ucftc.UCRowIndex = yIndex + 1;
                    panGroup.Controls.Add(ucftc);
                }
                if (yIndex == 0)//创建一个起始行
                {
                    UCFabITileFirstRow ucftr = CreateFabTileFirstRowOne(xIndex, yIndex, firstColumnWidth);
                    ucftr.UCColIndex = xIndex + 1;
                    panGroup.Controls.Add(ucftr);
                }

                UCFabITile ucft = CreateFabTileOne(xIndex, yIndex, firstColumnWidth, firstRowHeight);
                ucft.UCBackColorIndex = colorIndex;
                ucft.DrSource = dtSource.Rows[i];
                ucft.UCRowIndex = i;

                panGroup.Controls.Add(ucft);

                Application.DoEvents();

            }
        }

        /// <summary>
        /// 创建磁贴一个 第一列
        /// </summary>
        /// <param name="p_XIndex">水平序号</param>
        /// <param name="p_YIndex">垂直序号</param>
        UCFabITileFirstColumn CreateFabTileFirstColumnOne(int p_XIndex, int p_YIndex,int p_FirstRowHeight)
        {
            int splitpixel = 1;//间隔像素
            int tempHeight = 85;
            UCFabITileFirstColumn ucftc = new UCFabITileFirstColumn();
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
        UCFabITileFirstRow CreateFabTileFirstRowOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth)
        {
            int splitpixel = 1;//间隔像素
            int tempWidth = 97;
            UCFabITileFirstRow ucftr = new UCFabITileFirstRow();
            ucftr.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, splitpixel);
            ucftr.Name = "ucftfr" + (10000 * p_YIndex + p_XIndex);
            //ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            //ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucftr.MouseClick += new MouseEventHandler(panGroup_MouseClick);//快速点击及滚动用
            return ucftr;
        }


        /// <summary>
        /// 创建磁贴一个
        /// </summary>
        /// <param name="p_XIndex">水平序号</param>
        /// <param name="p_YIndex">垂直序号</param>
        UCFabITile CreateFabTileOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth, int p_FirstRowHeight)
        {
            int splitpixel = 1;//间隔像素
            int tempWidth = 97, tempHeight = 85;

            UCFabITile ucft = new UCFabITile();
            ucft.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, p_YIndex * tempHeight + splitpixel * (p_YIndex + 1) + p_FirstRowHeight);
            ucft.Name = "ucft" + (10000 * p_YIndex + p_XIndex);
            ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucft.UCTileXY = p_XIndex.ToString() + " " + p_YIndex.ToString();
            ucft.UCControl_RowIndexChanged += new UCFabRowIndexChanged(UCControl_RowIndexChanged);

            //ucft.MouseClick += new MouseEventHandler(panGroup_MouseClick);//快速点击及滚动用
            return ucft;
        }

        /// <summary>
        /// 磁贴序号改变事件
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        void UCControl_RowIndexChanged(object sender, int rowIndex)
        {
            UCCurrnetFocusIndex = rowIndex;

            if (sender is DevExpress.XtraEditors.TextEdit)
            {
            }
            else
            {
                panGroup_MouseClick(null, null);
            }

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

        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
