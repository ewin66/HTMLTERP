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
	/// 目的：Data_FNORel实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2009-04-07
	/// </summary>
	public class FNORelRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public FNORelRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			FNORel entity=(FNORel)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Data_FNORel WHERE 1=1";
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

        /// <summary>
		/// 新增
		/// </summary>
		/// <param name="p_BE">要新增的实体</param>
		public void RAdd(BaseEntity p_BE)
		{
			try
			{
			    IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RAdd(p_BE,sqlTrans);
			
			        sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 新增(传入事务处理)
		/// </summary>
		/// <param name="p_BE">要新增的实体</param>
		/// <param name="sqlTrans">事务类</param>
		public void RAdd(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
				this.CheckCorrect(p_BE);
				FNORel entity=(FNORel)p_BE;				
				FNORelCtl control=new FNORelCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_FNORel,sqlTrans);
				control.AddNew(entity);
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="p_BE">要修改的实体</param>
		public void RUpdate(BaseEntity p_BE)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RUpdate(p_BE,sqlTrans);
					
					sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}				
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="p_BE">要修改的实体</param>
		/// <param name="sqlTrans">事务类</param>
		public void RUpdate(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
				this.CheckCorrect(p_BE);
				FNORel entity=(FNORel)p_BE;				
				FNORelCtl control=new FNORelCtl(sqlTrans);				
				control.Update(entity);
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="p_BE">要删除的实体</param>
		public void RDelete(BaseEntity p_BE)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RDelete(p_BE,sqlTrans);
					
					sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}				
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="p_BE">要删除的实体</param>
		/// <param name="sqlTrans">事务类</param>
		public void RDelete(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
			    this.CheckCorrect(p_BE);
				FNORel entity=(FNORel)p_BE;				
				FNORelCtl control=new FNORelCtl(sqlTrans);
				control.Delete(entity);						
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
	}
}
