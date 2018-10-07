using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;


namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// 目的：Data_VendorTypeDts实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2014/5/24
	/// </summary>
	public class VendorTypeDtsRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public VendorTypeDtsRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			VendorTypeDts entity=(VendorTypeDts)p_BE;
		}	
		
		
		 /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition)
        {
            try
            {
                return RShow(p_condition, "*");
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM Data_VendorTypeDts WHERE 1=1";
                sql += p_condition;
                return SysUtils.Fill(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RSave(BaseEntity p_BEMain, ArrayList p_BEDts)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSave(p_BEMain, p_BEDts, sqlTrans);

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
        }

        /// <summary>
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RSave(BaseEntity p_BEMain, ArrayList p_BEDts, IDBTransAccess sqlTrans)
        {
            try
            {
                Vendor entityVendor = (Vendor)p_BEMain;
                string sql = "";

                sql = "DELETE FROM Data_VendorTypeDts WHERE VendorID=" + SysString.ToDBString(entityVendor.VendorID);
                sqlTrans.ExecuteNonQuery(sql);

                for (int i = 0; i < p_BEDts.Count; i++)
                {
                    VendorTypeDts entity=(VendorTypeDts)p_BEDts[i];
                    sql = "INSERT INTO Data_VendorTypeDts(VendorID,VendorTypeID) VALUES("+SysString.ToDBString(entityVendor.VendorID)+","+entity.VendorTypeID+")";
                    sqlTrans.ExecuteNonQuery(sql);
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
        }

		
	}
}
