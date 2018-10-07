using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HttSoft.Framework;
using System.Drawing;


namespace HttSoft.UCFab
{
     /// <summary>
    /// ���ݿ������
    /// </summary>
    public class UCStatusBarParamSet
    {
        /// <summary>
        /// ������UI������
        /// </summary>
        static DataTable m_StatusBarUIParamSetDt;
        /// <summary>
        /// ������UI������
        /// </summary>
        public static DataTable StatusBarUIParamSetDt
        {

            set
            {
                m_StatusBarUIParamSetDt = value;
            }
            get
            {
                if (m_StatusBarUIParamSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_ParamSet WHERE ID BETWEEN 7400 AND  7500";//�������ؼ�������Χ
                    m_StatusBarUIParamSetDt = SysUtils.Fill(sql);
                }
                return m_StatusBarUIParamSetDt;
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
            DataRow[] drA = StatusBarUIParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }



        /// <summary>
        /// �����������ֵID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>����ֵ</returns>
        public static string GetStrValueByID(int p_ID)
        {
            string outS = "";
            DataRow[] drA = StatusBarUIParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outS = SysConvert.ToString(drA[0]["SetValueStr"]);
            }

            return outS;
        }

        /// <summary>
        /// ������ɫ�ַ���ת����ɫ
        /// </summary>
        /// <param name="p_Str"></param>
        /// <returns></returns>
        public static Color ConvertColorByStr(string p_Str)
        {
            Color oc;
            string[] tempstr = p_Str.Split(',');
            if (tempstr.Length == 3)//����Ϊ3
            {
                oc = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
            }
            else
            {
                oc = Color.White;
            }
            return oc;
        }
    }
   
}
