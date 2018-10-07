using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using HttSoft.Framework;

namespace MLTERP
{
    #region 具体颜色状态类

    #region 色卡状态颜色处理
    /// <summary>
    /// 色卡状态颜色处理
    /// </summary>
    public class ColorCardStatus
    {
        private static bool m_ColorIniFlag = false;//颜色是否初始化标志
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// 初始化颜色(每个颜色类调用不一样)
        /// </summary>
        private static void ColorIniProc()
        {
            FlowColorCommon.ColorIniProc("Enum_ColorCardStatus", "", out ColorStatusID, out ColorStatusName, out ColorStatusColor);
        }

        public static void ColorIniTextBox(DevExpress.XtraEditors.GroupControl p_Group)
        {
            if (ColorIniFlag)
            {
                FlowColorCommon.ColorIniTextBox(p_Group, "状态", ColorStatusName, ColorStatusColor);
            }
        }

        /// <summary>
        /// 获得行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            return FlowColorCommon.GetGridRowBackColor(p_ColorStatusID, ColorStatusID, ColorStatusColor);
        }
    }
    #endregion

    #region 采购单状态颜色处理
    /// <summary>
    /// 采购单状态颜色处理类
    /// </summary>
    public class YarnCompactStatus
    {
        private static bool m_ColorIniFlag = false;//颜色是否初始化标志
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// 初始化颜色(每个颜色类调用不一样)
        /// </summary>
        private static void ColorIniProc()
        {
            FlowColorCommon.ColorIniProc("Enum_InWHStatus", "", out ColorStatusID, out ColorStatusName, out ColorStatusColor);
        }

        public static void ColorIniTextBox(DevExpress.XtraEditors.GroupControl p_Group)
        {
            if (ColorIniFlag)
            {
                FlowColorCommon.ColorIniTextBox(p_Group, "状态", ColorStatusName, ColorStatusColor);
            }
        }


        /// <summary>
        /// 获得颜色
        /// </summary>
        /// <param name="p_Dt1">分样时间</param>
        /// <param name="p_Dt2">交样时间</param>
        /// <returns>true/false</returns>
        public static Color GetGridRowBackColor(DateTime p_time, decimal p_Qty1, decimal p_Qty2, decimal p_Per, int p_Day, int ProcFlag)
        {
            if (ProcFlag == 1)
            {
                return GetGridRowBackColor(5);
            }
            else
            {
                if (p_Qty2 != 0)//已经入库
                {
                    if (p_Qty2 > p_Qty1 * p_Per)
                    {
                        return GetGridRowBackColor(5);
                    }
                    else
                    {
                        return GetGridRowBackColor(4);//部分入库
                    }
                }
                else
                {
                    if (p_time < DateTime.Now.Date)//延期 希望交期小于今天
                    {
                        return GetGridRowBackColor(3);//延期
                    }
                    else if (p_time > DateTime.Now.Date.AddDays(-1) && p_time < DateTime.Now.Date.AddDays(+p_Day))//提前三天预警 希望交期小于三天以后
                    {
                        return GetGridRowBackColor(2);
                    }
                }

                return GetGridRowBackColor(1);//正常
            }
        }

        /// <summary>
        /// 获得行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            return FlowColorCommon.GetGridRowBackColor(p_ColorStatusID, ColorStatusID, ColorStatusColor);
        }

        /// <summary>
        /// 处理状态名称
        /// </summary>
        /// <param name="p_time"></param>
        /// <param name="p_ProcFlag"></param>
        /// <param name="p_Day"></param>
        /// <returns></returns>
        public static string GetGridCellName(DateTime p_time, decimal p_Qty1, decimal p_Qty2, decimal p_Per, int p_Day, int ProcFlag)
        {
            if (ProcFlag == 1)
            {
                return ColorStatusName[4];
            }
            else
            {
                if (p_Qty2 != 0)//已经入库
                {
                    if (p_Qty2 > p_Qty1 * p_Per)
                    {
                        return ColorStatusName[4];
                    }
                    else
                    {
                        return ColorStatusName[3];//部分入库
                    }
                }
                else
                {
                    if (p_time < DateTime.Now.Date)//延期 希望交期小于今天
                    {
                        return ColorStatusName[2];//延期
                    }
                    else if (p_time > DateTime.Now.Date.AddDays(-1) && p_time < DateTime.Now.Date.AddDays(+p_Day))//提前三天预警 希望交期小于三天以后
                    {
                        return ColorStatusName[1];
                    }
                }
                return ColorStatusName[0];//正常
            }
        }
    }
    #endregion

    #region 染色单状态颜色处理
    /// <summary>
    /// 染色单状态颜色处理类
    /// </summary>
    public class ColorCompactStatus
    {
        private static bool m_ColorIniFlag = false;//颜色是否初始化标志
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// 初始化颜色(每个颜色类调用不一样)
        /// </summary>
        private static void ColorIniProc()
        {
            FlowColorCommon.ColorIniProc("Enum_InWHStatus", "", out ColorStatusID, out ColorStatusName, out ColorStatusColor);
        }

        public static void ColorIniTextBox(DevExpress.XtraEditors.GroupControl p_Group)
        {
            if (ColorIniFlag)
            {
                FlowColorCommon.ColorIniTextBox(p_Group, "状态", ColorStatusName, ColorStatusColor);
            }
        }


        /// <summary>
        /// 获得颜色
        /// </summary>
        /// <param name="p_Dt1">分样时间</param>
        /// <param name="p_Dt2">交样时间</param>
        /// <returns>true/false</returns>
        public static Color GetGridRowBackColor(DateTime p_time, decimal p_Qty1, decimal p_Qty2, decimal p_Per, int p_Day, int ProcFlag)
        {
            if (ProcFlag == 1)
            {
                return GetGridRowBackColor(5);
            }
            else
            {
                if (p_Qty2 != 0)//已经入库
                {
                    if (p_Qty2 > p_Qty1 * p_Per)
                    {
                        return GetGridRowBackColor(5);
                    }
                    else
                    {
                        return GetGridRowBackColor(4);//部分入库
                    }
                }
                else
                {
                    if (p_time < DateTime.Now.Date)//延期 希望交期小于今天
                    {
                        return GetGridRowBackColor(3);//延期
                    }
                    else if (p_time > DateTime.Now.Date.AddDays(-1) && p_time < DateTime.Now.Date.AddDays(+p_Day))//提前三天预警 希望交期小于三天以后
                    {
                        return GetGridRowBackColor(2);
                    }
                }
                return GetGridRowBackColor(1);//正常
            }
        }

        /// <summary>
        /// 获得行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            return FlowColorCommon.GetGridRowBackColor(p_ColorStatusID, ColorStatusID, ColorStatusColor);
        }

        /// <summary>
        /// 处理状态名称
        /// </summary>
        /// <param name="p_time"></param>
        /// <param name="p_ProcFlag"></param>
        /// <param name="p_Day"></param>
        /// <returns></returns>
        public static string GetGridCellName(DateTime p_time, decimal p_Qty1, decimal p_Qty2, decimal p_Per, int p_Day, int ProcFlag)
        {
            if (ProcFlag == 1)
            {
                return ColorStatusName[4];
            }
            else
            {
                if (p_Qty2 != 0)//已经入库
                {
                    if (p_Qty2 > p_Qty1 * p_Per)
                    {
                        return ColorStatusName[4];
                    }
                    else
                    {
                        return ColorStatusName[3];//部分入库
                    }
                }
                else
                {
                    if (p_time < DateTime.Now.Date)//延期 希望交期小于今天
                    {
                        return ColorStatusName[2];//延期
                    }
                    else if (p_time > DateTime.Now.Date.AddDays(-1) && p_time < DateTime.Now.Date.AddDays(+p_Day))//提前三天预警 希望交期小于三天以后
                    {
                        return ColorStatusName[1];
                    }
                }
                return ColorStatusName[0];//正常
            }
        }
    }
    #endregion

    #region 辅料单状态颜色处理
    /// <summary>
    /// 辅料申请状态颜色处理
    /// </summary>
    public class AccesoryCompactStatus
    {
        private static bool m_ColorIniFlag = false;//颜色是否初始化标志
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// 初始化颜色(每个颜色类调用不一样)
        /// </summary>
        private static void ColorIniProc()
        {
            FlowColorCommon.ColorIniProc("Enum_InWHStatus", "", out ColorStatusID, out ColorStatusName, out ColorStatusColor);
        }

        public static void ColorIniTextBox(DevExpress.XtraEditors.GroupControl p_Group)
        {
            if (ColorIniFlag)
            {
                FlowColorCommon.ColorIniTextBox(p_Group, "状态", ColorStatusName, ColorStatusColor);
            }
        }


        /// <summary>
        /// 获得颜色
        /// </summary>
        /// <param name="p_Dt1">分样时间</param>
        /// <param name="p_Dt2">交样时间</param>
        /// <returns>true/false</returns>
        public static Color GetGridRowBackColor(DateTime p_time, decimal p_Qty1, decimal p_Qty2, decimal p_Per, int p_Day)
        {
            if (p_Qty2 != 0)//已经入库
            {
                if (p_Qty2 > p_Qty1 * p_Per)
                {
                    return GetGridRowBackColor(5);
                }
                else
                {
                    return GetGridRowBackColor(4);//部分入库
                }
            }
            else
            {
                if (p_time < DateTime.Now.Date)//延期 希望交期小于今天
                {
                    return GetGridRowBackColor(3);//延期
                }
                else if (p_time > DateTime.Now.Date.AddDays(-1) && p_time < DateTime.Now.Date.AddDays(+p_Day))//提前三天预警 希望交期小于三天以后
                {
                    return GetGridRowBackColor(2);
                }
            }
            return GetGridRowBackColor(1);//正常
        }

        /// <summary>
        /// 获得行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            return FlowColorCommon.GetGridRowBackColor(p_ColorStatusID, ColorStatusID, ColorStatusColor);
        }

        /// <summary>
        /// 处理状态名称
        /// </summary>
        /// <param name="p_time"></param>
        /// <param name="p_ProcFlag"></param>
        /// <param name="p_Day"></param>
        /// <returns></returns>
        public static string GetGridCellName(DateTime p_time, decimal p_Qty1, decimal p_Qty2, decimal p_Per, int p_Day)
        {

            if (p_Qty2 != 0)//已经入库
            {
                if (p_Qty2 > p_Qty1 * p_Per)
                {
                    return ColorStatusName[4];
                }
                else
                {
                    return ColorStatusName[3];//部分入库
                }
            }
            else
            {
                if (p_time < DateTime.Now.Date)//延期 希望交期小于今天
                {
                    return ColorStatusName[2];//延期
                }
                else if (p_time > DateTime.Now.Date.AddDays(-1) && p_time < DateTime.Now.Date.AddDays(+p_Day))//提前三天预警 希望交期小于三天以后
                {
                    return ColorStatusName[1];
                }
            }
            return ColorStatusName[0];//正常
        }
    }

    #endregion  

    #region 出入库状态颜色处理
    /// <summary>
    /// 出入库状态颜色处理类
    /// </summary>
    public class InOutWHStatus
    {
        private static bool m_ColorIniFlag = false;//颜色是否初始化标志
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// 初始化颜色(每个颜色类调用不一样)
        /// </summary>
        private static void ColorIniProc()
        {
            FlowColorCommon.ColorIniProc("Enum_WHFormType", " AND StatusFlag=1 ", out ColorStatusID, out ColorStatusName, out ColorStatusColor);
        }

        public static void ColorIniTextBox(DevExpress.XtraEditors.GroupControl p_Group)
        {
            if (ColorIniFlag)
            {
                FlowColorCommon.ColorIniTextBox(p_Group, "状态", ColorStatusName, ColorStatusColor);
            }
        }

        /// <summary>
        /// 获得行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            return FlowColorCommon.GetGridRowBackColor(p_ColorStatusID, ColorStatusID, ColorStatusColor);
        }

    }
    #endregion 

    #region 偏差状态处理类
    /// <summary>
    /// 偏差状态处理类
    /// </summary>
    public class DeviationStatus
    {
        private static bool m_ColorIniFlag = false;//颜色是否初始化标志
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        private static string condition;
        private static DataTable dt = new DataTable();

        public static string ProcCondition(string p_TableName)
        {
            return ProcCondition(p_TableName, "", "");
        }

        public static string ProcCondition(string p_TableName, string p_ClSA)
        {
            return ProcCondition(p_TableName, p_ClSA, "");
        }

        public static string ProcCondition(string p_TableName, string p_CLSA, string p_CLSB)
        {
            m_ColorIniFlag = false;
            string sql = "Select * FROM Data_FormDeviation WHERE DTableName=" + SysString.ToDBString(p_TableName);
            if (p_CLSA != string.Empty)
            {
                sql += " AND CLSA=" + SysString.ToDBString(p_CLSA);
            }
            if (p_CLSB != string.Empty)
            {
                sql += " AND CLSB=" + SysString.ToDBString(p_CLSB);
            }

            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                condition = SysConvert.ToString(dt.Rows[0]["DeviationID"]);
            }
            return condition;
        }

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// 初始化颜色(每个颜色类调用不一样)
        /// </summary>
        private static void ColorIniProc()
        {
            FlowColorCommon.ColorIniProcZ("Data_DeviationDts", " AND MainID=" + SysString.ToDBString(condition), out ColorStatusID, out ColorStatusName, out ColorStatusColor);
        }

        public static void ColorIniTextBox(DevExpress.XtraEditors.GroupControl p_Group)
        {
            if (ColorIniFlag)
            {
                FlowColorCommon.ColorIniTextBox(p_Group, "状态", ColorStatusName, ColorStatusColor);
            }
        }


        /// <summary>
        /// 获得颜色
        /// </summary>
        /// <param name="p_Dt1">分样时间</param>
        /// <param name="p_Dt2">交样时间</param>
        /// <returns>true/false</returns>
        public static Color GetGridRowBackColor(DateTime p_time1, DateTime p_time2)
        {

            string sql = "Select * from Data_DeviationDts WHERE MainID=" + SysConvert.ToInt32(dt.Rows[0]["DeviationID"]);
            sql += " ORDER BY Seq Desc";
            DataTable dtA = SysUtils.Fill(sql);
            for (int i = 0; i < dtA.Rows.Count; i++)
            {
                if (p_time2 == SystemConfiguration.DateTimeDefaultValue || p_time1 == SystemConfiguration.DateTimeDefaultValue)
                {
                    return Color.White;
                }
                else
                {
                    if (i == 0 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) <= p_time2)
                    {
                        return GetGridRowBackColor(dtA.Rows.Count);
                    }
                    else if (i == dtA.Rows.Count - 1 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) >= p_time2)
                    {
                        return GetGridRowBackColor(1);
                    }
                    //else if (p_time1 == p_time2 && SysConvert.ToInt32(dtA.Rows[i]["Num"]) == 0)
                    //{
                    //    return GetGridRowBackColor(dtA.Rows.Count - i);
                    //}
                    else if (p_time1 == p_time2)
                    {
                        return GetGridRowBackColor(0);
                    }
                    else if (p_time1 < p_time2 && i != 0 && i != dtA.Rows.Count - 1 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i - 1]["Num"])) > p_time2 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) <= p_time2)
                    {
                        return GetGridRowBackColor(dtA.Rows.Count - i);
                    }
                    else if (p_time1 > p_time2 && i != 0 && i != dtA.Rows.Count - 1 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) >= p_time2 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i + 1]["Num"])) < p_time2)
                    {
                        return GetGridRowBackColor(dtA.Rows.Count - i);
                    }
                }


            }
            return GetGridRowBackColor(0);
        }

        /// <summary>
        /// 获得行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            return FlowColorCommon.GetGridRowBackColor(p_ColorStatusID, ColorStatusID, ColorStatusColor);
        }

        // <summary>
        /// 处理状态名称
        /// </summary>
        /// <param name="p_time"></param>
        /// <param name="p_ProcFlag"></param>
        /// <param name="p_Day"></param>
        /// <returns></returns>
        public static string GetGridCellStatusName(DateTime p_time1, DateTime p_time2)
        {
            string sql = "Select * from Data_DeviationDts WHERE MainID=" + SysConvert.ToInt32(dt.Rows[0]["DeviationID"]);
            sql += " ORDER BY Seq Desc";
            DataTable dtA = SysUtils.Fill(sql);
            for (int i = 0; i < dtA.Rows.Count; i++)
            {
                if (i == 0 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) <= p_time2)
                {
                    return ColorStatusName[dtA.Rows.Count - 1];
                }
                else if (i == dtA.Rows.Count - 1 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) >= p_time2)
                {
                    return ColorStatusName[1 - 1];
                }
                //else if (p_time1 == p_time2 && SysConvert.ToInt32(dtA.Rows[i]["Num"]) == 0)
                //{
                //    return GetGridRowBackColor(dtA.Rows.Count - i);
                //}
                else if (p_time1 == p_time2)
                {
                    return "";
                }
                else if (p_time1 < p_time2 && i != 0 && i != dtA.Rows.Count - 1 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i - 1]["Num"])) > p_time2 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) <= p_time2)
                {
                    return ColorStatusName[dtA.Rows.Count - i - 1];
                }
                else if (p_time1 > p_time2 && i != 0 && i != dtA.Rows.Count - 1 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i]["Num"])) >= p_time2 && p_time1.AddDays(SysConvert.ToInt32(dtA.Rows[i + 1]["Num"])) < p_time2)
                {
                    return ColorStatusName[dtA.Rows.Count - i - 1];
                }

            }
            return ColorStatusName[0];

        }
    }
    #endregion

    #endregion

    #region   颜色绑定通用类
    /// <summary>
    /// 颜色绑定通用类
    /// </summary>
    public class FlowColorCommon
    {
        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID, int[] p_ColorStatusIDA, Color[] p_ColorStatusColorA)
        {
            int findsort = -1;
            for (int i = 0; i < p_ColorStatusIDA.Length; i++)
            {
                if (p_ColorStatusIDA[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return p_ColorStatusColorA[findsort];
            }
            return Color.White;
        }

        #region 周富春-增加的
        /// <summary>
        /// 初始化颜色类
        /// </summary>
        /// <param name="p_StatusTableName"></param>
        /// <param name="p_Condition"></param>
        /// <param name="o_ColorStatusID"></param>
        /// <param name="o_ColorStatusName"></param>
        /// <param name="o_ColorStatusColor"></param>
        public static void ColorIniProcZ(string p_StatusTableName, string p_Condition, out int[] o_ColorStatusID, out string[] o_ColorStatusName, out Color[] o_ColorStatusColor)
        {
            string sql = string.Empty;
            sql = "SELECT Seq,Name,ColorStr FROM " + p_StatusTableName + " WHERE 1=1" + p_Condition + " ORDER BY Seq";
            DataTable dt = SysUtils.Fill(sql);

            o_ColorStatusID = new int[dt.Rows.Count];
            o_ColorStatusName = new string[dt.Rows.Count];
            o_ColorStatusColor = new Color[dt.Rows.Count];
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    o_ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["Seq"].ToString());
                    o_ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                    string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                    if (tempstr.Length == 3)//长度为3
                    {
                        o_ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                    }
                    else
                    {
                        o_ColorStatusColor[i] = Color.White;
                    }

                }
            }
        }
        #endregion

        /// <summary>
        /// 初始化颜色类
        /// </summary>
        /// <param name="p_StatusTableName"></param>
        /// <param name="p_Condition"></param>
        /// <param name="o_ColorStatusID"></param>
        /// <param name="o_ColorStatusName"></param>
        /// <param name="o_ColorStatusColor"></param>
        public static void ColorIniProc(string p_StatusTableName, string p_Condition, out int[] o_ColorStatusID, out string[] o_ColorStatusName, out Color[] o_ColorStatusColor)
        {
            string sql = string.Empty;
            sql = "SELECT ID,Name,ColorStr FROM " + p_StatusTableName + " WHERE 1=1" + p_Condition + " ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);

            o_ColorStatusID = new int[dt.Rows.Count];
            o_ColorStatusName = new string[dt.Rows.Count];
            o_ColorStatusColor = new Color[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                o_ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                o_ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    o_ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    o_ColorStatusColor[i] = Color.White;
                }

            }
        }


        /// <summary>
        /// 初始化显示控件
        /// </summary>
        /// <param name="p_Group"></param>
        /// <param name="p_StatusCaption"></param>
        /// <param name="p_ColorStatusName"></param>
        /// <param name="p_ColorStatusColor"></param>
        public static void ColorIniTextBox(DevExpress.XtraEditors.GroupControl p_Group, string p_StatusCaption, string[] p_ColorStatusName, Color[] p_ColorStatusColor)
        {
            p_Group.Controls.Clear();


            int startPosX = 6 + 15 * p_StatusCaption.Length;
            int txtWidth = 64;

            //增加Lable
            System.Windows.Forms.Label lblStatus = new System.Windows.Forms.Label();
            lblStatus.Location = new System.Drawing.Point(6, 4);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(startPosX - 6, 16);
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblStatus.Text = p_StatusCaption;
            p_Group.Controls.Add(lblStatus);

            for (int i = 0; i < p_ColorStatusName.Length; i++)//增加TextBox 颜色说明
            {
                System.Windows.Forms.TextBox txtColor = new System.Windows.Forms.TextBox();
                txtColor.Name = "txtColorStatus" + (i + 1).ToString();
                txtColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
                txtColor.Font = new System.Drawing.Font("宋体", 10F);
                txtColor.Location = new System.Drawing.Point(startPosX + txtWidth * i, 4);
                txtColor.ReadOnly = true;
                txtColor.Size = new System.Drawing.Size(txtWidth, 16);
                txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                txtColor.Text = p_ColorStatusName[i];
                txtColor.BackColor = p_ColorStatusColor[i];
                p_Group.Controls.Add(txtColor);
            }
        }
    }
    #endregion

}
