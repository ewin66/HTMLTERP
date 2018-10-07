using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using HttSoft.Framework;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 基类编辑画面
    /// </summary>
    public partial class frmAPBaseToolEdit : frmAPBaseTool
    {
        public frmAPBaseToolEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获得查询结果集方法
        /// </summary>
        /// <param name="p_Sql"></param>
        /// <returns></returns>
        public string GetReustGrid(string p_Sql,out GridView o_View)
        {
            string outstr = string.Empty;
            o_View = new GridView();
            DevExpress.XtraGrid.GridControl gridCtl = new DevExpress.XtraGrid.GridControl();
            gridCtl.MainView = o_View;
            gridCtl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { o_View });
            this.Controls.Add(gridCtl);
            o_View.GridControl = gridCtl;
            DataTable dt = SysUtils.Fill(p_Sql);
            o_View.GridControl.DataSource = dt;
            o_View.GridControl.Show();
            gridCtl.Visible = false;
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
            }
            return outstr;
        }

        #region 翻页通用方法
       

        /// <summary>
        /// 获取定位数据查询结果集当前行序号
        /// </summary>
        /// <param name="p_IDValue">ID值</param>
        /// <param name="p_IDFieldName">ID字段</param>
        /// <returns>行序号</returns>
        public int SetToolButtonPosStatusQueryResutCurRowID(GridView p_View,string p_IDValue, string p_IDFieldName)
        {
            int outint = -1;
            if (p_View != null)
            {
                for (int i = 0; i < p_View.RowCount; i++)
                {
                    if (p_IDValue == SysConvert.ToString(p_View.GetRowCellValue(i, p_IDFieldName)))
                    {
                        outint = i;
                        break;
                    }
                }
                if (outint == -1)//如果没有找到载入末页
                {
                    outint = p_View.RowCount - 1;
                }
            }
            return outint;
        }
        /// <summary>
        /// 获取定位数据查询结果集 前页ID
        /// </summary>
        /// <param name="p_CurRowID">当前行位置</param>
        /// <param name="p_IDValue">ID值</param>
        /// <param name="p_IDFieldName">ID字段</param>
        /// <returns>ID值</returns>
        public string SetToolButtonPosStatusQueryResutPrevID(GridView p_View, int p_CurRowID, string p_IDValue, string p_IDFieldName)
        {
            string outint = "";
            if (p_View != null)
            {
                if (p_View.RowCount > 0) 
                {
                    for (int i = p_CurRowID; i > 0; i--)
                    {
                        if (i - 1 >= 0)
                        {
                            if (SysConvert.ToString(p_View.GetRowCellValue(i - 1, p_IDFieldName)) != p_IDValue)//找到和本行不一致的讯息
                            {
                                outint = SysConvert.ToString(p_View.GetRowCellValue(i - 1, p_IDFieldName));
                                break;
                            }
                        }
                    }
                }
            }
            return outint;
        }

        /// <summary>
        /// 获取定位数据查询结果集 后页ID
        /// </summary>
        /// <param name="p_CurRowID">当前行位置</param>
        /// <param name="p_IDValue">ID值</param>
        /// <param name="p_IDFieldName">ID字段</param>
        /// <returns>ID值</returns>
        public string SetToolButtonPosStatusQueryResutNextID(GridView p_View, int p_CurRowID, string p_IDValue, string p_IDFieldName)
        {
            string outint = "";
            if (p_View != null)
            {
                if (p_View.RowCount > 0)
                {
                    for (int i = p_CurRowID; i <p_View.RowCount; i++)
                    {
                        if (i + 1 < p_View.RowCount)
                        {
                            if (SysConvert.ToString(p_View.GetRowCellValue(i + 1, p_IDFieldName)) != p_IDValue)//找到和本行不一致的讯息
                            {
                                outint = SysConvert.ToString(p_View.GetRowCellValue(i + 1, p_IDFieldName));
                                break;

                            }
                        }
                    }
                }
            }
            return outint;
        }

        /// <summary>
        /// 获取定位数据查询结果集 首页ID
        /// </summary>
        /// <param name="p_CurRowID">当前行位置</param>
        /// <param name="p_IDValue">ID值</param>
        /// <param name="p_IDFieldName">ID字段</param>
        /// <returns>ID值</returns>
        public string SetToolButtonPosStatusQueryResutFirstID(GridView p_View, int p_CurRowID, string p_IDValue, string p_IDFieldName)
        {
            string outint = "";
            if (p_View != null)
            {
                if (p_View.RowCount > 0)
                {
                    if (SysConvert.ToString(p_View.GetRowCellValue(0, p_IDFieldName)) != p_IDValue)//找到和本行不一致的讯息
                    {
                        outint = SysConvert.ToString(p_View.GetRowCellValue(0, p_IDFieldName));
                    }
                }
            }
            return outint;
        }
        /// <summary>
        /// 获取定位数据查询结果集 末页ID
        /// </summary>
        /// <param name="p_CurRowID">当前行位置</param>
        /// <param name="p_IDValue">ID值</param>
        /// <param name="p_IDFieldName">ID字段</param>
        /// <returns>ID值</returns>
        public string SetToolButtonPosStatusQueryResutLastID(GridView p_View, int p_CurRowID, string p_IDValue, string p_IDFieldName)
        {
            string outint = "";
            if (p_View != null)
            {
                if (p_View.RowCount > 0)
                {
                    if (SysConvert.ToString(p_View.GetRowCellValue(p_View.RowCount - 1, p_IDFieldName)) != p_IDValue)//找到和本行不一致的讯息
                    {
                        outint = SysConvert.ToString(p_View.GetRowCellValue(p_View.RowCount - 1, p_IDFieldName));
                    }
                }
            }
            return outint;
        }

        #endregion


        #region 关于验证配置项方法
        /// <summary>
        /// 获得明细表校验字符串
        /// </summary>
        /// <param name="p_FormGridID"></param>
        /// <returns></returns>
        public string[] GetHTCheckDataField(int p_FormGridID)
        {
            string[] outStrA = new string[] { };
            if (WinUIParamSet.GetIntValueByID(8020) == 1)//系统编辑表单明细启用配置必输项验证
            {
                string sql = "SELECT FieldName FROM Sys_FormGridUIDtsAttach WHERE FormGridID=" + p_FormGridID + " AND HeadTypeID=" + this.FormListAID + " AND SubTypeID=" + this.FormListBID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outStrA = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        outStrA[i] = dt.Rows[i]["FieldName"].ToString();
                    }
                }
            }
            return outStrA;
        }
        #endregion

    }
}