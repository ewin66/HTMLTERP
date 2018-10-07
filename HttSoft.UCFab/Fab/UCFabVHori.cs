using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;
using DevExpress.XtraGrid.Columns;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：查看码单 横向模式
    /// 作者：陈加海
    /// 日期：2014-3-31
    /// </summary>
    public partial class UCFabVHori : UCFabBaseViewCtl
    {
        public UCFabVHori()
        {
            InitializeComponent();
        }


        #region 临时静态变量，后续移动到全局变量，或配置数据库内
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//默认色系

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//偶数列色系 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//偶数列色系 128, 255, 128Color.AliceBlueColor.FromArgb(255, 255, 128)

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//选择色系
        static Color UCTitleColor = Color.FromArgb(224, 224, 224);//Color.Gray;//Color.FromArgb(255, 192, 255);//选择色系
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




        #endregion


        #region 内部方法
        void BindGrid()
        {
            gridView1.GridControl.DataSource = ConvertDataSource(UCDataSource);
            gridView1.GridControl.Show();
            DataSourceTotalCalcAll();//计算小计

            lblFabCount.Text = "匹数:" + UCDataSource.Rows.Count.ToString();
            lblFabQty.Text = "米数:" + SysConvert.ToString(UCDataSource.Compute("SUM(Qty)", ""));
            lblFabWeight.Text = "重量:" + SysConvert.ToString(UCDataSource.Compute("SUM(Weight)", ""));
            lblFabYard.Text = "码数:" + SysConvert.ToString(UCDataSource.Compute("SUM(Yard)", ""));
        }
        /// <summary>
        /// 数据源行小计的计算计算所有
        /// </summary>
        void DataSourceTotalCalcAll()
        {
            DataTable dtView = (DataTable)gridView1.GridControl.DataSource;
            for (int i = 0; i < dtView.Rows.Count; i++)
            {
                DataSourceTotalCalc(dtView, i);

            }
        }


        /// <summary>
        /// 数据源行小计的计算
        /// </summary>
        /// <param name="rowID"></param>
        void DataSourceTotalCalc(int rowID)
        {
            DataTable dtView = (DataTable)gridView1.GridControl.DataSource;
            DataSourceTotalCalc(dtView, rowID);
        }
        /// <summary>
        /// 数据源行小计的计算
        /// </summary>
        /// <param name="rowID"></param>
        void DataSourceTotalCalc(DataTable dtView, int rowID)
        {

            decimal totalQty = 0m;
            for (int i = 0; i < UCColumnCount; i++)
            {
                if (UCVolumeNumberShowFlag)//如果显示卷号,就是两行
                {
                    if (rowID % 4 == 0)//匹号
                    {
                        if (SysConvert.ToInt32(dtView.Rows[rowID]["ColVal" + (i + 1)]) != 0)
                        {
                            totalQty = totalQty + 1;
                        }
                    }
                    else//数量
                    {
                        totalQty = totalQty + SysConvert.ToDecimal(dtView.Rows[rowID]["ColVal" + (i + 1)]);
                    }
                }
                else//如果不显示卷号，就是一行数量
                {
                    totalQty = totalQty + SysConvert.ToDecimal(dtView.Rows[rowID]["ColVal" + (i + 1)]);
                }
            }

            if (totalQty != 0)
            {
                dtView.Rows[rowID]["ColTotal"] = totalQty;
            }
            else
            {
                dtView.Rows[rowID]["ColTotal"] = DBNull.Value;
            }

        }


        /// <summary>
        /// 转换数据源为横向
        /// </summary>
        /// <returns>第一列为标题；每笔数据占两行，第一行匹号，第二行数量</returns>
        DataTable ConvertDataSource(DataTable dtSource)
        {
            gridView1.Columns.Clear();
            //列数 UCColumnCount;
            DataTable outdt = new DataTable();
            outdt.Columns.Add(new DataColumn("ColTitle", typeof(string)));
            gridView1.Columns.Add(CreateGridColumnOne("ColTitle", "标题", 0, 0));//添加一列

            int colWidth = UCFabParamSet.GetIntValueByID(6003);//码单显示横向模式列宽度
            if (colWidth <= 0)
            {
                colWidth = 0;
            }
            for (int i = 1; i <= UCColumnCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));

                gridView1.Columns.Add(CreateGridColumnOne("ColVal" + i.ToString(), (i).ToString(), colWidth, i + 1));//添加一列
            }

            outdt.Columns.Add(new DataColumn("ColTotal", typeof(string)));
            gridView1.Columns.Add(CreateGridColumnOne("ColTotal", "小计", 0, UCColumnCount + 2));//添加一列

            //列添加完毕，开始转换数据
            int rowIndex = 0;//转换后行号
            int colIndex = 0;//转换后列号
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                rowIndex = i / UCColumnCount;
                colIndex = i % UCColumnCount;

                if (colIndex == 0)//第一列，则添加两行
                {
                    if (UCVolumeNumberShowFlag)//如果显示卷号，则添加匹号行
                    {
                        DataRow dr = outdt.NewRow();
                        dr["ColTitle"] = "匹号";
                        outdt.Rows.Add(dr);
                    }
                    DataRow dr2 = outdt.NewRow();
                    if (UCVolumeNumberShowFlag)//如果显示卷号，则显示文字
                    {
                        dr2["ColTitle"] = "米数";
                    }
                    else
                    {
                        dr2["ColTitle"] = (rowIndex + 1).ToString();//显示行号,直观
                    }
                    outdt.Rows.Add(dr2);
                    if (UCVolumeNumberShowFlag)
                    {
                        DataRow dr3 = outdt.NewRow();
                        dr3["ColTitle"] = "重量";
                        outdt.Rows.Add(dr3);
                    }

                    DataRow dr4 = outdt.NewRow();
                    dr4["ColTitle"] = "码数";
                    outdt.Rows.Add(dr4);
                }

                //开始赋值
                if (UCVolumeNumberShowFlag)//显示卷号
                {
                    outdt.Rows[rowIndex * 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//匹号
                    outdt.Rows[rowIndex * 4 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//数量
                    outdt.Rows[rowIndex * 4 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//重量
                    outdt.Rows[rowIndex * 4 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Yard"].ToString();//码数
                }
                else//如果不显示卷号，就是一行数量，则不赋值匹号
                {
                    outdt.Rows[rowIndex * 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//数量
                    outdt.Rows[rowIndex * 3 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//重量
                    outdt.Rows[rowIndex * 3 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Yard"].ToString();//码数
                }

            }

            return outdt;

        }


        /// <summary>
        /// 创建一个Grid列
        /// </summary>
        /// <param name="p_FiledName"></param>
        /// <param name="p_Title"></param>
        /// <param name="p_ColSize"></param>
        /// <param name="p_VIndex"></param>
        /// <returns></returns>
        GridColumn CreateGridColumnOne(string p_FiledName, string p_Title, int p_ColSize, int p_VIndex)
        {
            GridColumn col = new GridColumn();
            col.Name = "col" + p_FiledName;
            col.FieldName = p_FiledName;
            col.Caption = p_Title;
            col.OptionsColumn.ReadOnly = true;
            if (p_ColSize != 0)
            {
                col.Width = p_ColSize;
            }
            col.VisibleIndex = p_VIndex;
            return col;

        }
        #endregion


        #region 加载事件
        private void UCFabSGridView_Load(object sender, EventArgs e)
        {
            try
            {
                //gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
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
                if (e.Column.FieldName == "ColTitle")//标题
                {
                    e.Appearance.BackColor = UCTitleColor;
                }
                else
                {
                    if (e.RowHandle % 6 == 0 || e.RowHandle % 6 == 1 || e.RowHandle % 6 == 2)//奇数值（3行）
                    {
                        e.Appearance.BackColor = UCBackColor2;
                    }
                    else//偶数值(2行)
                    {
                        e.Appearance.BackColor = UCBackColorS2;
                    }
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
