using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;


namespace HttSoft.WinUIBase
{
    /// <summary>
    /// Ŀ�ģ�Enum_FormNoControlʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2006-2-21
    /// </summary>
    public class WFormNoControlRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public WFormNoControlRule()
        {
        }

        

        

        #region ���ݺ��봦��



        public void RAddSort(string p_ClsA, string p_ClsB, IDBTransAccess sqlTrans)
        {
            RAddSort(p_ClsA, p_ClsB, 0, sqlTrans);
        }
        /// <summary>
        /// ��õ��ݺ���(ͨ�����Ź�ϵ��)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <returns></returns>
        public void RAddSort(string p_ClsA, string p_ClsB,int p_SubTypeID, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT FormNoControlID,SelfEditFlag FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_ClsA) + " AND CLSB=" + SysString.ToDBString(p_ClsB);
            sql += " AND ISNULL(SubTypeID,0)="+p_SubTypeID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (!SysConvert.ToBoolean(SysConvert.ToInt32(dt.Rows[0]["SelfEditFlag"])))//δ���б༭������������
                {
                    this.RAddSort(SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]), sqlTrans);
                }
            }
        }


        /// <summary>
        /// ������ż�һ
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="sqlTrans">����</param>
        public void RAddSort(int p_FormNoID, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAddSort(p_FormNoID, 1, sqlTrans);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        /// <summary>
        /// ������ż�N(��Щ���ſ���һ�β������)
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        /// <param name="sqlTrans">����</param>
        public void RAddSort(int p_FormNoID, int p_Num, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "UPDATE Enum_FormNoControl SET CurSort=ISNULL(CurSort,0)+" + ( p_Num) + " WHERE ID=" + p_FormNoID;
                sqlTrans.ExecuteNonQuery(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion




   




    }
}
