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
    /// 功能：录入码单 横向模式
    /// 作者：陈加海
    /// 日期：2014-3-31
    /// </summary>
    public partial class UCFabIHori : UCFabBaseInputCtl
    {
        public UCFabIHori()
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
            int rowIndex = gridView1.FocusedRowHandle / 5;//匹号、米数、重量三个合并一行
            if (!UCVolumeNumberShowFlag)//如果不显示卷号，就是两行米数、重量，则行数就是GridView行号
            {
                rowIndex = gridView1.FocusedRowHandle / 4;
            }
            int colIndex = 0;
            if (gridView1.FocusedColumn.FieldName == "ColTitle")
            {
                colIndex = 1;
            }
            else if (gridView1.FocusedColumn.FieldName.IndexOf("ColVal") != -1)//值序号
            {
                colIndex = SysConvert.ToInt32(gridView1.FocusedColumn.FieldName.Substring(6));
            }

            int dataSourceIndex = UCColumnCount * rowIndex + colIndex - 1;

            UCCurrnetFocusIndex = dataSourceIndex;
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 绑定Grid
        /// </summary>
        void BindGrid()
        {
            UCFabCommon.AddDtRow(UCDataSource, UCInputCount);
            gridView1.GridControl.DataSource = ConvertDataSource(UCDataSource);
            gridView1.GridControl.Show();
            DataSourceTotalCalcAll();//计算小计
            DataSourceTotalInfoSet();
            //lblFabCount.Text = "匹数:" + SysConvert.ToString(UCDataSource.Compute("COUNT(Qty)", " ISNULL(Qty,0)<>0")); //UCDataSource.Rows.Count.ToString();
            //lblFabQty.Text = "数量:"+SysConvert.ToString(UCDataSource.Compute("SUM(Qty)", ""));
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
        /// 汇总信息设置
        /// </summary>
        void DataSourceTotalInfoSet()
        {
            lblFabCount.Text = "匹数:" + SysConvert.ToString(UCDataSource.Compute("COUNT(SubSeq)", "(ISNULL(Qty,0)<>0 OR ISNULL(Weight,0)<>0 OR ISNULL(Yard,0)<>0)")); //UCDataSource.Rows.Count.ToString();
            lblFabQty.Text = "米数:" + SysConvert.ToString(UCDataSource.Compute("SUM(Qty)", ""));
            lblFabWeight.Text = "公斤数:" + SysConvert.ToString(UCDataSource.Compute("SUM(Weight)", ""));
            lblFabYard.Text = "码数:" + SysConvert.ToString(UCDataSource.Compute("SUM(Yard)", ""));
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
                    if (rowID % 5 == 0)//匹号
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
        #endregion


        #region 内部方法



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
            gridView1.Columns.Add(CreateGridColumnOne("ColTitle", "标题", 0, 0, true));//添加一列

            int colWidth = UCFabParamSet.GetIntValueByID(6026);//码单编辑横向模式列宽度
            if (colWidth <= 0)
            {
                colWidth = 0;
            }


            for (int i = 1; i <= UCColumnCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));
                gridView1.Columns.Add(CreateGridColumnOne("ColVal" + i.ToString(), (i).ToString(), colWidth, i + 1, false));//添加一列
            }


            outdt.Columns.Add(new DataColumn("ColTotal", typeof(string)));
            gridView1.Columns.Add(CreateGridColumnOne("ColTotal", "小计", 0, UCColumnCount + 2, true));//添加一列

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
                    if (UCVolumeNumberShowFlag)//如果显示卷号，则添加匹号行
                    {
                        DataRow dr3 = outdt.NewRow();
                        dr3["ColTitle"] = "重量";
                        outdt.Rows.Add(dr3);
                        DataRow dr5 = outdt.NewRow();
                        dr5["ColTitle"] = "码数";
                        outdt.Rows.Add(dr5);
                    }
                    if (UCVolumeNumberShowFlag)//如果显示卷号，则添加匹号行
                    {
                        DataRow dr4 = outdt.NewRow();
                        dr4["ColTitle"] = "等级";
                        outdt.Rows.Add(dr4);
                    }
                }

                //开始赋值
                if (UCVolumeNumberShowFlag)//显示卷号
                {
                    outdt.Rows[rowIndex * 5]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//匹号
                    outdt.Rows[rowIndex * 5 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//米数
                    outdt.Rows[rowIndex * 5 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//公斤数
                    outdt.Rows[rowIndex * 5 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Yard"].ToString();//码数
                    outdt.Rows[rowIndex * 5 + 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["GoodsLevel"].ToString();//等级
                }
                else//如果不显示卷号，就是一行数量，则不赋值匹号
                {
                    outdt.Rows[rowIndex * 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//米数
                    outdt.Rows[rowIndex * 4 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//公斤数
                    outdt.Rows[rowIndex * 4 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Yard"].ToString();//码数
                    outdt.Rows[rowIndex * 4 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["GoodsLevel"].ToString();//等级
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
        GridColumn CreateGridColumnOne(string p_FiledName, string p_Title, int p_ColSize, int p_VIndex, bool p_ReadOnly)
        {
            GridColumn col = new GridColumn();
            col.Name = "col" + p_FiledName;
            col.FieldName = p_FiledName;
            col.Caption = p_Title;
            col.OptionsColumn.ReadOnly = p_ReadOnly;
            if (p_ReadOnly)
            {
                col.OptionsColumn.AllowEdit = !p_ReadOnly;
            }
            if (p_ColSize != 0)
            {
                col.Width = p_ColSize;
            }
            col.VisibleIndex = p_VIndex;
            return col;

        }
        #endregion

        #region 控件加载事件
        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabIHori_Load(object sender, EventArgs e)
        {
            try
            {
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
                if (e.Column.FieldName == "ColTitle" || e.Column.FieldName == "ColTotal")//标题
                {
                    e.Appearance.BackColor = UCTitleColor;
                }
                else
                {
                    if (e.RowHandle % 10 == 0 || e.RowHandle % 10 == 1 || e.RowHandle % 10 == 2 || e.RowHandle % 10 == 3 || e.RowHandle % 10 == 4)//奇数值（10行）
                    {
                        e.Appearance.BackColor = UCBackColor2;
                    }
                    else//偶数值(10行)
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

        /// <summary>
        /// 值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.IndexOf("ColVal") != -1)//是值
                {
                    int colIndex = SysConvert.ToInt32(e.Column.FieldName.Substring(6));//列号 1开始
                    int rowIndex = e.RowHandle / 5;//行号，取整 0开始
                    if (!UCVolumeNumberShowFlag)//如果不显示卷号，就是一行数量，则行数就是GridView行号
                    {
                        rowIndex = e.RowHandle;
                    }
                    int datasourceRow = rowIndex * UCColumnCount + (colIndex - 1);//数据源行号

                    if (UCDataSource.Rows.Count <= datasourceRow)//溢出
                    {
                        UCFabCommon.AddDtRow(UCDataSource, datasourceRow + 2);
                    }
                    if (UCDataSource.Rows.Count > datasourceRow)//未溢出
                    {
                        if (UCVolumeNumberShowFlag)//如果显示卷号，就是两行，一行匹号，一行卷号
                        {
                            if (e.RowHandle % 5 == 0)//匹号
                            {
                                if (SysConvert.ToInt32(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["SubSeq"] = SysConvert.ToInt32(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["SubSeq"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 5 == 1)//数量
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 5 == 2)//公斤数
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 5 == 3)//码数
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                if (SysConvert.ToString(e.Value) != string.Empty)
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = SysConvert.ToString(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = DBNull.Value;
                                }
                            }
                        }
                        else//如果不显示卷号，就是一行数量
                        {
                            if (e.RowHandle % 4 == 0)//数量
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 4 == 1)//公斤数
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 4 == 2)
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                if (SysConvert.ToString(e.Value) != string.Empty)
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = SysConvert.ToString(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = DBNull.Value;
                                }
                            }
                        }
                    }

                    DataSourceTotalCalc(e.RowHandle);//计算小计
                    DataSourceTotalInfoSet();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




        #endregion

        #region 清空行数据
        /// <summary>
        /// 清空当前行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiClearRowData_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == this.ShowConfirmMessage("确定要清空本行数据"))
                {
                    if (gridView1.FocusedRowHandle != -1)
                    {
                        for (int j = 0; j < gridView1.Columns.Count; j++)
                        {
                            if (gridView1.Columns[j].FieldName != "ColTitle" && gridView1.Columns[j].FieldName != "ColTotal")
                            {
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[j], "");
                            }

                        }
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
