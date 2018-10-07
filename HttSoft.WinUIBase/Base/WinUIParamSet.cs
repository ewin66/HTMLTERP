using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using HttSoft.Framework;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// ���ò�����
    /// </summary>
    public class WinUIParamSet
    {
        /// <summary>
        /// �����뵥UI������
        /// </summary>
        static DataTable m_WinUIParamSetDt;
        /// <summary>
        /// �����뵥UI������
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
                    sql = "SELECT * FROM Sys_ParamSet WHERE (ID BETWEEN 7200 AND  7300) OR (ID BETWEEN 8000 AND 8100) ";//�����뵥�����ؼ���Χ
                    m_WinUIParamSetDt = SysUtils.Fill(sql);
                }
                return m_WinUIParamSetDt;
            }
        }


        /// <summary>
        /// �����������ֵID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>����ֵ</returns>
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
