using System;
using HttSoft.Framework;
using System.Data;

namespace HttSoft.HTERP.Sys
{

    #region 产品参数类
    /// <summary>
    /// 产品参数类
    /// 陈加海
    /// 2014.4.18
    /// </summary>
    public class ProductParamSet
    {
        /// <summary>
        /// 产品参数表
        /// </summary>
        static DataTable m_ProductParamSetDt;
        /// <summary>
        /// 产品参数表
        /// </summary>
        public static DataTable ProductParamSetDt
        {
            set
            {
                m_ProductParamSetDt = value;
            }
            get
            {
                if (m_ProductParamSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_ParamSet";//参数范围
                    m_ProductParamSetDt = SysUtils.Fill(sql);
                }
                return m_ProductParamSetDt;
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
            DataRow[] drA = ProductParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }

        /// <summary>
        /// 获得字符串参数值ID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>参数值</returns>
        public static string GetStrValueByID(int p_ID)
        {
            string outS = "";
            DataRow[] drA = ProductParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outS = SysConvert.ToString(drA[0]["SetValueStr"]);
            }

            return outS;
        }



    }
    #endregion
}
