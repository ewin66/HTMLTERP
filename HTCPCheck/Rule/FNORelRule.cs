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

        #region 单据单号规则 自定义开发代码    
        /// <summary>
        /// 获得单号控制ID
        /// </summary>
        /// <param name="p_CLSA">大类</param>
        /// <param name="p_CLSB">小类</param>
        /// <returns>返回单号控制</returns>
        public int RGetFormNoControlID(string p_CLSA,string p_CLSB)
        {
            return RGetFormNoControlID(p_CLSA,p_CLSB,0);
        }

         /// <summary>
        /// 获得单号控制ID
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
        /// 获得单号规则ID
        /// </summary>
        /// <param name="p_CLSA">大类</param>
        /// <param name="p_CLSB">小类</param>
        /// <param name="p_SubTypeID">子类型</param>
        /// <param name="sqlTrans">事务SQL执行类</param>
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
        /// 获得是否需要单号控制
        /// </summary>
        /// <returns></returns>
        public bool RGetFormNoControlEditFlag(string p_CLSA,string p_CLSB)
        {
            return RGetFormNoControlEditFlag(p_CLSA, p_CLSB, 0);
        }




       
        /// <summary>
        /// 获得是否需要单号控制
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
        /// 获得是否需要单号控制
        /// </summary>
        /// <param name="p_CLSA">大类</param>
        /// <param name="p_CLSB">小类</param>
        /// <param name="p_SubTypeID">子类型</param>
        /// <param name="sqlTrans">事务SQL执行类</param>
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
            else//如果没找到，表示可编辑
            {
                outb = true;
            }
            return outb;
        }

        #endregion
    }
}
