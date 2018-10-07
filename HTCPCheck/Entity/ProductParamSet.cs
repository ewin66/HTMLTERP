using System;
using HttSoft.Framework;
using System.Data;

namespace HttSoft.HTERP.Sys
{

    #region ��Ʒ������
    /// <summary>
    /// ��Ʒ������
    /// �¼Ӻ�
    /// 2014.4.18
    /// </summary>
    public class ProductParamSet
    {
        /// <summary>
        /// ��Ʒ������
        /// </summary>
        static DataTable m_ProductParamSetDt;
        /// <summary>
        /// ��Ʒ������
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
                    sql = "SELECT * FROM Sys_ParamSet";//������Χ
                    m_ProductParamSetDt = SysUtils.Fill(sql);
                }
                return m_ProductParamSetDt;
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
            DataRow[] drA = ProductParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }

        /// <summary>
        /// ����ַ�������ֵID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>����ֵ</returns>
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
