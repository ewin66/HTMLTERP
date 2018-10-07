using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using HttSoft.Framework;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 公用参数类
    /// </summary>
    public class WinUIParamSet
    {
        /// <summary>
        /// 面料码单UI参数表
        /// </summary>
        static DataTable m_WinUIParamSetDt;
        /// <summary>
        /// 面料码单UI参数表
        /// </summary>
        public static DataTable WinUIParamSetDt
        {

            set
            {
                m_WinUIParamSetDt = value;
            }
            get
            {
                if (m_WinUIParamSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_ParamSet WHERE (ID BETWEEN 7200 AND  7300) OR (ID BETWEEN 8000 AND 8100) ";//面料码单参数控件范围
                    m_WinUIParamSetDt = SysUtils.Fill(sql);
                }
                return m_WinUIParamSetDt;
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
            DataRow[] drA = WinUIParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }
    }
}
