using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;

namespace HttSoft.WinUIBase
{

    /// <summary>
    /// 功能：界面共用类
    /// 作者：Standy
    /// 日期：2014-5-16
    /// </summary>
    public class WCommon
    {

        #region 组织结构只绑定自己这个账号的数据
        /// <summary>
        /// 绑定组织结构内属于自己管理成员的字符串
        /// </summary>
        /// <returns>用于查询条件，员工连接字符串，可以直接用于查询条件</returns>
        public static string GetStructureMemberOPStr()
        {
            string sql = string.Empty;
            sql = "EXEC USP1_Data_Stucture_GetMemberOP " + SysString.ToDBString(FParamConfig.LoginID);
            DataTable dt = SysUtils.Fill(sql);
            string outstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                if (outstr != string.Empty)
                {
                    outstr += ",";
                }
                outstr += SysString.ToDBString(dr["OPID"].ToString());
            }

            if (outstr == string.Empty)//空白字符串
            {
                outstr = SysString.ToDBString(FParamConfig.LoginID);
            }
            return outstr;
        }
        #endregion


        #region 类别绑定
        /// <summary>
        /// 绑定选择类型枚举
        /// </summary>
        public static void BindCLSList(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[4] { 0, 75, 75, 100 }, new string[4] { "ID", "CLSA", "CLSB", "CLSDESC" }, new string[4] { "", "", "", "" }, new bool[4] { false, false, false, true });
            string sql = "SELECT ID,CLSA,CLSB,CLSDESC FROM Data_CLSList";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "CLSDESC", "ID", p_ShowBlank);
        }

        /// <summary>
        /// 绑定CLS
        /// </summary>
        public static void BindCLS(ComboBoxEdit p_DrpID, string p_TableName, string p_FieldName, bool p_AllowEdit, bool p_ShowBlank)
        {
            if (p_AllowEdit)
            {
                p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                p_DrpID.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }


            FCommon.LoadDropComb(p_DrpID, BindCLSDataSource(p_TableName, p_FieldName), "CLSNM", p_ShowBlank);


            if (BindCLSDataSource(p_TableName, p_FieldName).Rows.Count == 1)//如果只有一条数据
            {
                p_DrpID.EditValue = SysConvert.ToString(BindCLSDataSource(p_TableName, p_FieldName).Rows[0]["CLSNM"]);
            }
        }
        /// <summary>
        /// 绑定CLS
        /// </summary>
        public static void BindCLS(ComboBoxEdit p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, p_TableName, p_FieldName, true, p_ShowBlank);
        }
        /// <summary>
        /// 绑定CLS
        /// </summary>
        public static void BindCLS(RepositoryItemComboBox p_DrpID, string p_TableName, string p_FieldName, bool p_AllowEdit, bool p_ShowBlank)
        {
            if (p_AllowEdit)
            {
                p_DrpID.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            }
            FCommon.LoadDropRepositoryComb(p_DrpID, BindCLSDataSource(p_TableName, p_FieldName), "CLSNM", p_ShowBlank);

        }
        /// <summary>
        /// 绑定CLS
        /// </summary>
        public static void BindCLS(RepositoryItemComboBox p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, p_TableName, p_FieldName, true, p_ShowBlank);
        }



        /// <summary>
        /// 绑定CLS
        /// </summary>
        private static DataTable BindCLSDataSource(string p_TableName, string p_FieldName)
        {
            string sql = string.Empty;
            sql = "SELECT ID,CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT ID FROM Data_CLSList  WHERE 1=1";
            sql += " AND CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName) + ")";
            sql += " AND ISNULL(DelFlag,0)=0";
            sql += " ORDER BY CLSIDC,CLSNM";
            return SysUtils.Fill(sql);
        }


        /// <summary>
        /// 绑定CLS
        /// </summary>
        public static void BindCLS(CheckedListBoxControl p_CHK, string p_TableName, string p_FieldName)
        {
            string sql = string.Empty;
            sql = "SELECT CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT ID FROM Data_CLSList WHERE 1=1 ";
            sql += " AND CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName) + ")";
            sql += " ORDER BY CLSIDC,CLSNM";

            p_CHK.DataSource = SysUtils.Fill(sql);
            p_CHK.DisplayMember = "CLSNM";
            p_CHK.ValueMember = "CLSNM";
            p_CHK.Show();

        }
        #endregion

        #region 共用类

        /// <summary>
        /// 获取GridView排序后的数据集
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static DataTable PrintDataTable(GridView gridView)
        {
            DataTable dtin = new DataTable();
            try
            {

                string exportfile = string.Empty;
                string strSort = "";
                foreach (DevExpress.XtraGrid.Columns.GridColumnSortInfo gcsi in gridView.SortInfo)
                {
                    strSort += gcsi.Column.FieldName.ToString();
                    switch (gcsi.SortOrder.ToString())
                    {
                        case "Ascending":
                            strSort += " ASC,";
                            break;
                        case "Descending":
                            strSort += " DESC,";
                            break;
                    }
                }
                if (strSort != "")
                {
                    strSort = strSort.Remove(strSort.Length - 1, 1);
                }
                DataTable dt = (DataTable)gridView.GridControl.DataSource;
                DataRow[] Total = dt.Select(gridView.ActiveFilter.Expression, strSort);


                dtin = dt.Clone();
                foreach (DataRow dr in Total)
                {

                    dtin.ImportRow(dr);
                }

                return dtin;

            }
            catch (Exception E)
            {
                return dtin;
            }
        }

        public static DataTable PrintDataTable(GridView gridView, string FileName, string Value)
        {
            DataTable dtin = new DataTable();
            try
            {

                string exportfile = string.Empty;
                string strSort = string.Empty;
                foreach (DevExpress.XtraGrid.Columns.GridColumnSortInfo gcsi in gridView.SortInfo)
                {
                    strSort += gcsi.Column.FieldName.ToString();
                    switch (gcsi.SortOrder.ToString())
                    {
                        case "Ascending":
                            strSort += " ASC,";
                            break;
                        case "Descending":
                            strSort += " DESC,";
                            break;
                    }
                }
                if (strSort != "")
                {
                    strSort = strSort.Remove(strSort.Length - 1, 1);
                }
                DataTable dt = (DataTable)gridView.GridControl.DataSource;
                DataRow[] Total = dt.Select(gridView.ActiveFilter.Expression, strSort);
                dtin = dt.Clone();
                foreach (DataRow dr in Total)
                {
                    if (SysConvert.ToString(dr[FileName]) == Value)
                    {
                        dtin.ImportRow(dr);
                    }
                }
                return dtin;

            }
            catch (Exception E)
            {
                return dtin;
            }
        }
        #endregion


        #region 特殊转换

        /// <summary>
        /// 验证是否为ASCII码
        /// </summary>
        /// <param name="p_Char">要验证的字符</param>
        /// <returns>如是标准的返回-1，否则返回该字符的ASCII值</returns>
        public static int CheckASCII(string p_String, out string tempstr)
        {
            int ascNum = -1;
            tempstr = "";
            for (int i = 0; i < p_String.Length; i++)
            {
                string tempString = p_String.Substring(i, 1);
                tempstr = tempString;
                if (tempString != "?")
                {
                    byte[] temp = System.Text.Encoding.ASCII.GetBytes(tempString);
                    if (temp[0] >= 0 && temp[0] < 128 && temp[0] != 63)
                    {
                        ascNum = -1;
                    }
                    else
                    {
                        ascNum = temp[0];
                        return ascNum;
                    }
                }
                else
                {
                    ascNum = -1;
                }
            }
            return ascNum;
        }

        /// <summary>
        /// 在当前行位置下面增加一行
        /// </summary>
        /// <param name="p_Dt">表</param>
        /// <param name="p_RowID">行号</param>
        public static void DataTableAddRow(DataTable p_Dt, int p_RowID)
        {
            if (p_Dt == null || p_RowID == -1)
            {
            }
            DataRow dr = p_Dt.NewRow();
            if (p_RowID == p_Dt.Rows.Count - 1 || p_RowID < -1)//处于最后一行
            {
                p_Dt.Rows.Add(dr);
            }
            else//
            {
                p_Dt.Rows.Add(dr);
                for (int i = p_Dt.Rows.Count - 1; i > p_RowID; i--)
                {
                    for (int j = 0; j < p_Dt.Columns.Count; j++)
                    {
                        p_Dt.Rows[i][j] = p_Dt.Rows[i - 1][j];
                    }
                }
                for (int j = 0; j < p_Dt.Columns.Count; j++)
                {
                    p_Dt.Rows[p_RowID + 1][j] = DBNull.Value;
                }
            }
        }


        /// <summary>
        /// 上移
        /// </summary>
        /// <returns>移动后的行号</returns>
        public static int DataTableUpRow(DataTable p_Dt, int RowID)
        {
            int outint = RowID;
            if (RowID > 0)//行号大于0才上移
            {
                DataRow dr = p_Dt.NewRow();
                for (int j = 0; j < p_Dt.Columns.Count; j++)//缓存上一行数据
                {
                    dr[j] = p_Dt.Rows[RowID - 1][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//移动到上一行
                {
                    p_Dt.Rows[RowID - 1][j] = p_Dt.Rows[RowID][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//上一行缓存保存到本行
                {
                    p_Dt.Rows[RowID][j] = dr[j];
                }
                outint--;
            }

            return outint;
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <returns>移动后的行号</returns>
        public static int DataTableDownRow(DataTable p_Dt, int RowID)
        {
            int outint = RowID;
            if (RowID < p_Dt.Rows.Count - 1)//行号小于最大行才下移
            {
                DataRow dr = p_Dt.NewRow();
                for (int j = 0; j < p_Dt.Columns.Count; j++)//缓存下一行数据
                {
                    dr[j] = p_Dt.Rows[RowID + 1][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//移动到下一行
                {
                    p_Dt.Rows[RowID + 1][j] = p_Dt.Rows[RowID][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//下一行缓存保存到本行
                {
                    p_Dt.Rows[RowID][j] = dr[j];
                }
                outint++;
            }
            return outint;
        }

        /// <summary>
        /// 获得查询字符串
        /// </summary>
        /// <param name="gridview"></param>
        /// <returns></returns>
        public static string GridGetQueryField(GridView gridview)
        {
            string outstr = string.Empty;
            for (int i = 0; i < gridview.Columns.Count; i++)
            {
                if (outstr != string.Empty)
                {
                    outstr += ",";
                }
                outstr += gridview.Columns[i].FieldName;
            }
            return outstr;
        }

        /// <summary>
        /// 设置报表数据源行数增加至满页
        /// </summary>
        /// <param name="p_Dt">数据源</param>
        /// <param name="p_PageSize">每页行数</param>
        public static void SetReportDataSource(DataTable p_Dt, int p_PageSize)
        {
            int count = p_Dt.Rows.Count % p_PageSize;//取余
            if (count != 0)
            {
                for (int i = count; i < p_PageSize; i++)
                {
                    p_Dt.Rows.Add(p_Dt.NewRow());
                }
            }
            else
            {
                AddDtRow(p_Dt, p_PageSize);
            }
        }

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

        /// <summary>
        /// 拷贝上一行数据
        /// </summary>
        public static void CopyPreRowData(GridView p_GridView)
        {
            if (p_GridView.FocusedRowHandle >= 0 && p_GridView.FocusedRowHandle + 1 < p_GridView.RowCount)//行数足够才复制
            {
                for (int i = 0; i < p_GridView.Columns.Count; i++)
                {
                    p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle + 1, p_GridView.Columns[i], p_GridView.GetRowCellValue(p_GridView.FocusedRowHandle, p_GridView.Columns[i]));
                }
            }
        }


        /// <summary>
        /// 得到加载开始行
        /// </summary>
        /// <returns></returns>
        public static int GetNewRow(GridView p_GridView, string sFiledName)
        {
            int outstr = 0;
            for (int i = 0; i < p_GridView.RowCount; i++)
            {
                if (SysConvert.ToString(p_GridView.GetRowCellValue(i, sFiledName)) == string.Empty)
                {
                    outstr = i;
                    break;
                }
            }
            return outstr;
        }

        /// <summary>
        /// 转换小数点
        /// </summary>
        /// <param name="p_Num">数字串</param>
        /// <returns>转换后的数字串</returns>
        public static string ConvertNum(string p_Num)
        {
            string outstr = p_Num;
            if (outstr.IndexOf('.') != -1)
            {
                while (outstr.Length > 1 && (outstr.Substring(outstr.Length - 1) == "0" || outstr.Substring(outstr.Length - 1) == "."))
                {
                    if (outstr.Substring(outstr.Length - 1) == ".")
                    {
                        outstr = outstr.Substring(0, outstr.Length - 1);
                        break;
                    }
                    else
                    {
                        outstr = outstr.Substring(0, outstr.Length - 1);
                    }

                }
            }
            return outstr;
        }


        /// <summary>
        /// 获得日期转换字符串，默认的返回空
        /// </summary>
        /// <param name="p_Dt">日期</param>
        /// <returns></returns>
        public static string GetExcelDateStr(DateTime p_Dt)
        {
            if (p_Dt != SystemConfiguration.DateTimeDefaultValue)
            {
                return p_Dt.ToString("yyyy-MM-dd");
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 获得日期转换字符串，默认的返回空
        /// </summary>
        /// <param name="p_Dt">日期</param>
        /// <returns></returns>
        public static string GetExcelNumStr(decimal p_Num)
        {
            if (p_Num != SystemConfiguration.DecimalDefaultValue)
            {
                return p_Num.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
