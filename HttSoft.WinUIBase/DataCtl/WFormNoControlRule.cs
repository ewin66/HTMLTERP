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
    /// 目的：Enum_FormNoControl实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2006-2-21
    /// </summary>
    public class WFormNoControlRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WFormNoControlRule()
        {
        }

        

        

        #region 单据号码处理



        public void RAddSort(string p_ClsA, string p_ClsB, IDBTransAccess sqlTrans)
        {
            RAddSort(p_ClsA, p_ClsB, 0, sqlTrans);
        }
        /// <summary>
        /// 获得单据号码(通过单号关系表)
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
                if (!SysConvert.ToBoolean(SysConvert.ToInt32(dt.Rows[0]["SelfEditFlag"])))//未自行编辑号码才增加序号
                {
                    this.RAddSort(SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]), sqlTrans);
                }
            }
        }


        /// <summary>
        /// 单据序号加一
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="sqlTrans">事务</param>
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
        /// 单据序号加N(有些批号可能一次产生多个)
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
        /// <param name="sqlTrans">事务</param>
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
