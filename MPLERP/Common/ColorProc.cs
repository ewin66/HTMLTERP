using System;
using System.Drawing;
using System.Data;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using System.Windows.Forms;
using HttSoft.MLTERP.Sys;

namespace MLTERP
{
    #region 采购状态颜色处理类
    /// <summary>
    /// 采购状态颜色处理类
    /// </summary>
    class ItemBuyStatusProc
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

        public static int DayNum = 0;//预警天数
        public static decimal FinishPer = 0m;//完成百分率
        public static decimal StartFinishQty = 0m;//多少数量开始统计,低于这个数量有入库数直接表示完成

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;

        public static DataTable ColorStatusDt;
        /// <summary>
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr,DayNum,FinishPer,StartFinishQty FROM Enum_ItemBuyStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
            ColorStatusDt = dt;
            if (dt.Rows.Count != 0)
            {
                DayNum = SysConvert.ToInt32(dt.Rows[0]["DayNum"]);
                FinishPer = SysConvert.ToDecimal(dt.Rows[0]["FinishPer"]);
                StartFinishQty = SysConvert.ToDecimal(dt.Rows[0]["StartFinishQty"]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


        #region 处理状态名称
        /// <summary>
        /// 处理状态名称
        /// </summary>
        /// <param name="p_Dt">数据表</param>
        public static void ProcColorStatusName(DataTable p_Dt)
        {

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["TotalRecQty"]);
                dt1 = SysConvert.ToDateTime(dr["ReqDate"]);
                dt2 = SysConvert.ToDateTime(dr["ReceivedDate"]);

                if (SysConvert.ToInt32(dr["StatusFlag"]) == 1)
                {
                    dr["FormStatusName"] = dr["StatusName"];
                }
                else
                {
                    if (inwhqty >= qty *SysConvert.ToDecimal(0.8) || (qty < StartFinishQty && inwhqty > 0))//有超过百分比数量则完成
                    {
                        if (dt1 < dt2)
                        {
                            statusname = ColorStatusName[4];//延时完成
                        }
                        else//按时完成
                        {
                            statusname = ColorStatusName[2];
                        }
                    }
                    else
                    {
                        DateTime chkTime = dt1;

                        TimeSpan ts = DateTime.Now - chkTime;
                        if (ts.Days > 0)//已经延期
                        {
                            statusname = ColorStatusName[3];
                        }
                        else if (ts.Days > 0 - DayNum)//预警
                        {
                            statusname = ColorStatusName[1];
                        }
                        else
                        {
                            statusname = ColorStatusName[0];
                        }


                    }

                    dr["FormStatusName"] = statusname;
                }
            }
        }
        #endregion
    }
    #endregion


    #region 色卡管理站别颜色处理类
    /// <summary>
    /// 色卡管理站别颜色处理类
    /// </summary>
    class ColorCardStatusProc
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

        public static DataTable ColorStatusDt;
        /// <summary>
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr FROM Enum_ColorCardStatus WHERE ID<>0  ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusDt = dt;

            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion

    #region 销售订单状态颜色处理类
    /// <summary>
    /// 销售订单状态颜色处理类
    /// </summary>
    class SaleOrderStatusProc
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

        public static int DayNum = 0;//预警天数
        public static decimal FinishPer = 0m;//完成百分率
        public static decimal StartFinishQty = 0m;//多少数量开始统计,低于这个数量有入库数直接表示完成

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;


        public static DataTable ColorStatusDt;
        /// <summary>
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr,DayNum,FinishPer,StartFinishQty FROM Enum_OrderStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
            ColorStatusDt = dt;
            if (dt.Rows.Count != 0)
            {
                DayNum = SysConvert.ToInt32(dt.Rows[0]["DayNum"]);
                FinishPer = SysConvert.ToDecimal(dt.Rows[0]["FinishPer"]);
                StartFinishQty = SysConvert.ToDecimal(dt.Rows[0]["StartFinishQty"]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


        #region 处理状态名称
        /// <summary>
        /// 处理状态名称
        /// </summary>
        /// <param name="p_Dt">数据表</param>
        public static void ProcColorStatusName(DataTable p_Dt)
        {

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                if (SysConvert.ToInt32(dr["StatusFlag"]) == 1)
                {
                    dr["FormStatusName"] = dr["StatusName"];
                }
                else
                {

                    qty = SysConvert.ToDecimal(dr["Qty"]);
                    inwhqty = SysConvert.ToDecimal(dr["TotalRecQty"]);
                    dt1 = SysConvert.ToDateTime(dr["DtsReqDate"]);
                    dt2 = SysConvert.ToDateTime(dr["ReceivedDate"]);


                    if (inwhqty >= qty * FinishPer || (qty < StartFinishQty && inwhqty > 0))//有超过百分比数量则完成
                    {
                        if (dt1 < dt2)
                        {
                            statusname = ColorStatusName[4];//延时完成
                        }
                        else//按时完成
                        {
                            statusname = ColorStatusName[2];
                        }
                    }
                    else
                    {
                        DateTime chkTime = dt1;

                        TimeSpan ts = DateTime.Now - chkTime;
                        if (ts.Days > 0)//已经延期
                        {
                            statusname = ColorStatusName[3];
                        }
                        else if (ts.Days > 0 - DayNum)//预警
                        {
                            statusname = ColorStatusName[1];
                        }
                        else
                        {
                            statusname = ColorStatusName[0];
                        }


                    }

                    dr["FormStatusName"] = statusname;
                }
                
            }
            
        }
        #endregion
    }
    #endregion

    #region 销售订单站别颜色处理类
    /// <summary>
    /// 销售订单站别颜色处理类
    /// </summary>
    class SaleOrderStepProc
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

        public static DataTable ColorStatusDt;
        /// <summary>
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr FROM Enum_OrderStep WHERE ID<>0  AND ShowFlag=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusDt = dt;

            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


     
    }
    #endregion

    #region 仓库颜色处理类
    /// <summary>
    /// 仓库颜色处理类
    /// </summary>
    public class WHIOStatusProc
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
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,ColorCaption,ColorStr FROM Enum_WHQtyPos WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["ColorCaption"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }
            }
        }
        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }


        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }
    }
    #endregion

    #region 成品条码查询颜色处理类
    /// <summary>
    /// 成品条码查询颜色处理类
    /// </summary>
    class PackBoxStatusProc
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
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Code,Name,ColorStr FROM Enum_BoxStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
       
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


        
    }
    #endregion

    #region 挂板查询颜色处理类
    /// <summary>
    /// 挂板查询颜色处理类
    /// </summary>
    class ItemGBQuery
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
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Code,Name,ColorStr FROM Enum_GBStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion

    #region 挂板调单状态颜色处理类
    /// <summary>
    /// 采购状态颜色处理类
    /// </summary>
    class GBDYStatusProc
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
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr FROM Enum_DYStatus WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


       
    }
    #endregion

    #region 发货单状态颜色处理类
    /// <summary>
    /// 采购状态颜色处理类
    /// </summary>
    class FHFormStatusProc
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
        public static string[] ColorStatusName;
        public static Color[] ColorStatusColor;
        /// <summary>
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
          
            ColorStatusID = new int[2];
            ColorStatusName = new string[2];
            ColorStatusColor = new Color[2];

            ColorStatusID[0] = 0;
            ColorStatusID[1]=1;

            ColorStatusName[0] = "未发货";
            ColorStatusName[1] = "已发货";

            ColorStatusColor[0] = Color.FromArgb(255,255,255);
            ColorStatusColor[1] = Color.FromArgb(255, 128, 255);

            
        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion

    #region 库存预警状态颜色处理类
    /// <summary>
    /// 库存预警状态颜色处理类
    /// </summary>
    class StorgeAlarmStatusProc
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
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {

            ColorStatusID = new int[3];
            ColorStatusName = new string[3];
            ColorStatusColor = new Color[3];

            ColorStatusID[0] = 0;
            ColorStatusID[1] = 1;
            ColorStatusID[2] = 2;

            ColorStatusName[0] = "正常";
            ColorStatusName[1] = "库存最低预警";
            ColorStatusName[2] = "库存最高预警";

            ColorStatusColor[0] = Color.FromArgb(255, 255, 255);
            ColorStatusColor[1] = Color.FromArgb(255, 128, 255);
            ColorStatusColor[2] = Color.FromArgb(192, 192, 0);

        }

        /// <summary>
        /// 初始化控件颜色
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// 设置Grid行颜色
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion
}
