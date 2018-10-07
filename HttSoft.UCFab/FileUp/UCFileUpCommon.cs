using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ݿ������
    /// </summary>
    public class UCFileUPParamSet
    {
        /// <summary>
        /// �ļ�����UI������
        /// </summary>
        static DataTable m_FileUPUIParamSetDt;
        /// <summary>
        /// �ļ�����UI������
        /// </summary>
        public static DataTable FileUPUIParamSetDt
        {

            set
            {
                m_FileUPUIParamSetDt = value;
            }
            get
            {
                if (m_FileUPUIParamSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_ParamSet WHERE ID BETWEEN 7200 AND  7300";//�ļ���������ؼ���Χ
                    m_FileUPUIParamSetDt = SysUtils.Fill(sql);
                }
                return m_FileUPUIParamSetDt;
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
            DataRow[] drA = FileUPUIParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }



        /// <summary>
        /// ������ʱ��
        /// </summary>
        public static DateTime ServerTime
        {
            get
            {
                string sql = "SELECT GetDate()";
                return SysConvert.ToDateTime(SysUtils.Fill(sql).Rows[0][0]);
            }
        }

        /// <summary>
        /// ����ļ�����
        /// </summary>
        /// <returns></returns>
        public static int GetFileNumber(int winListID, int headtype, int subtype, int dataid)
        {
            int outi = 0;
            if (winListID != 0 && dataid != 0)
            {
                string sql = "SELECT COUNT(ID) FROM Data_WinListAttachFile WHERE 1=1 ";
                sql += " AND WinListID=" + SysString.ToDBString(winListID);
                sql += " AND HeadType=" + SysString.ToDBString(headtype);
                sql += " AND SubType=" + SysString.ToDBString(subtype);
                sql += " AND HTDataID=" + SysString.ToDBString(dataid);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outi = SysConvert.ToInt32(dt.Rows[0][0]);
                }
            }
            return outi;
        }


        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <returns></returns>
        public static void DeleteFileByDataID(int winListID, int headtype, int subtype, int dataid)
        {
            if (winListID != 0 && dataid != 0)
            {
                string sql = "DELETE FROM Data_WinListAttachFile WHERE 1=1 ";
                sql += " AND WinListID=" + SysString.ToDBString(winListID);
                sql += " AND HeadType=" + SysString.ToDBString(headtype);
                sql += " AND SubType=" + SysString.ToDBString(subtype);
                sql += " AND HTDataID=" + SysString.ToDBString(dataid);
                SysUtils.ExecuteNonQuery(sql);
            }

        }

    }
}
