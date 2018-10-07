using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.Framework;
using HttSoft.HTERP.Sys;
using System.Data;
using HttSoft.HTCPCheck.DataCtl;

namespace HttSoft.HTCPCheck.DataCtl
{
    public class FNORelRule
    {

        #region ���ݵ��Ź��� �Զ��忪������    
        /// <summary>
        /// ��õ��ſ���ID
        /// </summary>
        /// <param name="p_CLSA">����</param>
        /// <param name="p_CLSB">С��</param>
        /// <returns>���ص��ſ���</returns>
        public int RGetFormNoControlID(string p_CLSA,string p_CLSB)
        {
            return RGetFormNoControlID(p_CLSA,p_CLSB,0);
        }

         /// <summary>
        /// ��õ��ſ���ID
        /// </summary>
        /// <returns></returns>
        public int RGetFormNoControlID(string p_CLSA,string p_CLSB,int p_SubTypeID)
        {
            int outI = 0;
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    outI = this.RGetFormNoControlID(p_CLSA, p_CLSB, p_SubTypeID, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
            return outI;
        }




        /// <summary>
        /// ��õ��Ź���ID
        /// </summary>
        /// <param name="p_CLSA">����</param>
        /// <param name="p_CLSB">С��</param>
        /// <param name="p_SubTypeID">������</param>
        /// <param name="sqlTrans">����SQLִ����</param>
        /// <returns></returns>
        public int RGetFormNoControlID(string p_CLSA, string p_CLSB, int p_SubTypeID, IDBTransAccess sqlTrans)
        {
            int outI = 0;
            string sql = string.Empty;
            sql = "SELECT FormNoControlID FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_CLSA);
            sql += " AND CLSB=" + SysString.ToDBString(p_CLSB);
            sql += " AND ISNULL(SubTypeID,0)=" + p_SubTypeID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outI = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]);
            }
            return outI;
        }




        /// <summary>
        /// ����Ƿ���Ҫ���ſ���
        /// </summary>
        /// <returns></returns>
        public bool RGetFormNoControlEditFlag(string p_CLSA,string p_CLSB)
        {
            return RGetFormNoControlEditFlag(p_CLSA, p_CLSB, 0);
        }




       
        /// <summary>
        /// ����Ƿ���Ҫ���ſ���
        /// </summary>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        /// <returns></returns>
        public bool RGetFormNoControlEditFlag(string p_CLSA, string p_CLSB, int p_SubTypeID)
        {
            bool outb = false;
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    outb = this.RGetFormNoControlEditFlag(p_CLSA, p_CLSB, p_SubTypeID, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
            return outb;
        }


     

        /// <summary>
        /// ����Ƿ���Ҫ���ſ���
        /// </summary>
        /// <param name="p_CLSA">����</param>
        /// <param name="p_CLSB">С��</param>
        /// <param name="p_SubTypeID">������</param>
        /// <param name="sqlTrans">����SQLִ����</param>
        /// <returns></returns>
        public bool RGetFormNoControlEditFlag(string p_CLSA, string p_CLSB, int p_SubTypeID, IDBTransAccess sqlTrans)
        {
            bool outb = false;
            string sql = string.Empty;
            sql = "SELECT SelfEditFlag FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_CLSA);
            sql += " AND CLSB=" + SysString.ToDBString(p_CLSB);
            sql += " AND ISNULL(SubTypeID,0)=" + p_SubTypeID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outb = SysConvert.ToBoolean(SysConvert.ToInt32(dt.Rows[0]["SelfEditFlag"]));
            }
            else//���û�ҵ�����ʾ�ɱ༭
            {
                outb = true;
            }
            return outb;
        }

        #endregion
    }
}
