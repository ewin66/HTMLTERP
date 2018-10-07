using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using HttSoft.Framework;
using System.Drawing;

namespace HttSoft.UCFab
{

    #region 公共事件定义

    /// <summary>
    /// 写入磁贴  聚焦Index 改变事件
    /// </summary>
    /// <param name="sender">对象</param>
    /// <param name="rowIndex">行值</param>
    public delegate void UCFabRowIndexChanged(object sender, int rowIndex);// 定义委托处理程序



    /// <summary>
    /// 选择控件 取消匹委托事件定义
    /// </summary>
    public delegate void UCFabSelectCancel(string p_ISN);// 定义委托处理程序




    /// <summary>
    /// 加载控件 选择改变委托事件定义
    /// </summary>
    /// <param name="sender">控件</param>
    public delegate void UCFabLTileCheckChanged(object sender);// 定义委托处理程序 ,bool p_ShiftKeyFlag/// <param name="p_ShiftKeyFlag">Shift按键</param>

    #endregion


    /// <summary>
    /// 数据库参数类
    /// </summary>
    public class UCFabParamSet
    {
        /// <summary>
        /// 面料码单UI参数表
        /// </summary>
        static DataTable m_FabUIParamSetDt;
        /// <summary>
        /// 面料码单UI参数表
        /// </summary>
        public static DataTable FabUIParamSetDt
        {

            set
            {
                m_FabUIParamSetDt = value;
            }
            get
            {
                if (m_FabUIParamSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_ParamSet WHERE ID BETWEEN 6001 AND  6050";//面料码单参数控件范围
                    m_FabUIParamSetDt = SysUtils.Fill(sql);
                }
                return m_FabUIParamSetDt;
            }
        }


        /// <summary>
        /// 获得整数参数值ID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>参数值</returns>
        public static int GetIntValueByID(int p_ID)
        {
            int outI = 0;
            DataRow[] drA = FabUIParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }



    }


    /// <summary>
    /// 码单数据转换类
    /// </summary>
    public class UCFabDataConvert
    {


        /// <summary>
        /// 仓库码单转换
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_ColCount">码单列数</param>
        /// <returns>转换后的数据源</returns>
        public static DataTable WHFabConvert(int p_FormID, int p_ColCount)
        {
            DataTable outdt = FabConvertDtStructure(p_ColCount);
            string sql = string.Empty;
            sql = "SELECT Seq  FROM WH_IOFormDts WHERE MainID=" + p_FormID + " ORDER BY Seq ";
            DataTable dtSeq = SysUtils.Fill(sql);
            for (int i = 0; i < dtSeq.Rows.Count; i++)
            {
                sql = "SELECT SubSeq,Qty FROM WH_IOFormDtsPack WHERE  MainID=" + p_FormID + " AND Seq=" + SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]) + " ORDER BY SubSeq";
                DataTable dtPack = SysUtils.Fill(sql);
                DataTable dtConvert = FabConvertDtsData(SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]), dtPack, p_ColCount);

                FabConvertInResult(outdt, dtPack, dtConvert);
            }


            return outdt;
        }

        /// <summary>
        /// 发货码单转换
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_ColCount">码单列数</param>
        /// <returns></returns>
        public static DataTable FHFabConvert(int p_FormID, int p_ColCount)
        {
            DataTable outdt = FabConvertDtStructure(p_ColCount);
            string sql = string.Empty;
            sql = "SELECT Seq  FROM Sale_FHFormDts WHERE MainID=" + p_FormID + " ORDER BY Seq ";
            DataTable dtSeq = SysUtils.Fill(sql);
            for (int i = 0; i < dtSeq.Rows.Count; i++)
            {
                sql = "SELECT SubSeq,Qty FROM Sale_FHFormDtsPack WHERE  MainID=" + p_FormID + " AND Seq=" + SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]) + " ORDER BY SubSeq";
                DataTable dtPack = SysUtils.Fill(sql);
                DataTable dtConvert = FabConvertDtsData(SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]), dtPack, p_ColCount);

                FabConvertInResult(outdt, dtPack, dtConvert);
            }


            return outdt;
        }


        /// <summary>
        /// 格式化到总表内
        /// 总表添加每行值，并添加一汇总行
        /// </summary>
        /// <param name="dtResult">结果表</param>
        /// <param name="dtPack">码单明细表</param>
        /// <param name="dtConvert">转换后的码单二维表</param>
        static void FabConvertInResult(DataTable dtResult, DataTable dtPack, DataTable dtConvert)
        {
            foreach (DataRow drConvert in dtConvert.Rows)//逐行复制数据
            {
                DataRow drResult = dtResult.NewRow();
                for (int i = 0; i < dtResult.Columns.Count; i++)
                {
                    drResult[i] = drConvert[i];
                }
                dtResult.Rows.Add(drResult);
            }

            ////添加一个明细汇总行
            //DataRow drResultTotal = dtResult.NewRow();
            //drResultTotal[1] = "小计";
            //drResultTotal[2] = "卷数";
            //drResultTotal[3] = dtPack.Rows.Count.ToString();
            //drResultTotal[4] = "数量";
            //drResultTotal[5] = SysConvert.ToDecimal(dtPack.Compute("SUM(Qty)", ""));

            //dtResult.Rows.Add(drResultTotal);
        }

        /// <summary>
        /// 最终码单转换二维
        /// </summary>
        /// <returns>第0列为明细表Seq,第一列为标题；每笔数据占两行，第一行匹号，第二行数量</returns>
        static DataTable FabConvertDtsData(int Seq, DataTable dtSource, int p_ColCount)
        {
            DataTable outdt = FabConvertDtStructure(p_ColCount);

            //列添加完毕，开始转换数据
            int rowIndex = 0;//转换后行号
            int colIndex = 0;//转换后列号

            int rowFabNum = 0;//每行卷数
            decimal rowFabTotalQty = 0;//每行汇总数
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                rowIndex = i / p_ColCount;
                colIndex = i % p_ColCount;

                if (colIndex == 0)//第一列，则添加两行
                {
                    DataRow dr = outdt.NewRow();
                    dr["Seq"] = Seq;
                    dr["ColTitle"] = "匹号";
                    outdt.Rows.Add(dr);


                    DataRow dr2 = outdt.NewRow();
                    dr2["ColTitle"] = "数量";
                    dr2["Seq"] = Seq;
                    outdt.Rows.Add(dr2);

                    rowFabNum = 1;
                    rowFabTotalQty = SysConvert.ToDecimal(dtSource.Rows[i]["Qty"]);
                }
                else
                {
                    rowFabNum++;
                    rowFabTotalQty += SysConvert.ToDecimal(dtSource.Rows[i]["Qty"]);
                }

                //开始赋值
                outdt.Rows[rowIndex * 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//匹号
                outdt.Rows[rowIndex * 2 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//数量


                outdt.Rows[rowIndex * 2]["RowFabNum"] = rowFabNum;//每行卷数
                outdt.Rows[rowIndex * 2]["RowTotalQty"] = rowFabTotalQty;//每行汇总数
            }
            return outdt;
        }

        /// <summary>
        /// 数据转换最终表结构
        /// </summary>
        /// <param name="p_ColCount">码单列数</param>
        /// <returns></returns>
        static DataTable FabConvertDtStructure(int p_ColCount)
        {
            DataTable outdt = new DataTable();
            outdt.Columns.Add(new DataColumn("Seq", typeof(int)));
            outdt.Columns.Add(new DataColumn("ColTitle", typeof(string)));
            for (int i = 1; i <= p_ColCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));//添加一列
            }
            outdt.Columns.Add(new DataColumn("RowFabNum", typeof(int)));//每行卷数
            outdt.Columns.Add(new DataColumn("RowTotalQty", typeof(decimal)));//每行汇总数
            return outdt;
        }
    }

    /// <summary>
    /// 公共类
    /// </summary>
    class UCFabCommon
    {



        #region 绑定GridView行号
        /// <summary>
        /// 绑定GridView行号
        /// </summary>
        /// <param name="p_Grid"></param>
        public static void GridViewRowIndexBind(GridView p_Grid)
        {
            p_Grid.IndicatorWidth = 40;
            p_Grid.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView_CustomDrawRowIndicator);
        }
        /// <summary>
        /// 增加一列行序号
        /// </summary>
        private static void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (e.Info.IsRowIndicator)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// 移除录入码单数据源中的空行;从后往前
        /// 遇到有值行则自动结束
        /// </summary>
        /// <param name="p_Dt"></param>
        public static void RemoveInputBankRow(DataTable p_Dt)
        {
            for (int i = p_Dt.Rows.Count - 1; i >= 0; i--)
            {
                if (p_Dt.Rows[i]["BoxNo"].ToString() == string.Empty
                    && SysConvert.ToDecimal(p_Dt.Rows[i]["Qty"]) == 0 && SysConvert.ToDecimal(p_Dt.Rows[i]["Weight"]) == 0
                    && SysConvert.ToString(p_Dt.Rows[i]["SubSeq"]) == string.Empty)//没有值
                {
                    p_Dt.Rows.Remove(p_Dt.Rows[i]);
                }
                else//找到有值的数据则跳出循环
                {
                    break;
                }
            }
        }
        #endregion

        #region 通用方法
        /// <summary>
        /// 增加DataTable至指定的行数
        /// </summary>表
        /// <param name="p_Dt">数据</param>
        /// <param name="RowCount">行数</param>
        public static void AddDtRow(DataTable p_Dt, int RowCount)
        {
            for (int i = p_Dt.Rows.Count; i < RowCount; i++)
            {
                p_Dt.Rows.Add(p_Dt.NewRow());
            }
        }

        /// <summary>
        /// 删除一行数据源
        /// </summary>
        public static void DelDtRow(DataTable p_Dt, int RowID)
        {
            if (RowID > -1)
            {
                p_Dt.Rows.RemoveAt(RowID);
            }
        }
        #endregion

        #region 颜色转换
        /// <summary>
        /// 根据字符串转换为颜色
        /// </summary>
        /// <param name="p_Str"></param>
        /// <returns></returns>
        public static Color ConvertColorByStr(string p_Str)
        {
            Color outc = Color.White;
            string[] tempstr = p_Str.ToString().Split(',');
            if (tempstr.Length == 3)//长度为3
            {
                outc = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
            }
            else
            {
                outc = Color.White;
            }
            return outc;
        }
        #endregion
    }
}
