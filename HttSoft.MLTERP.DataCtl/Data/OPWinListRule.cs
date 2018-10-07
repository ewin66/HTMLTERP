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
	/// 目的：Data_OPWinList实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2006-11-20
	/// </summary>
	public class OPWinListRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public OPWinListRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			OPWinList entity=(OPWinList)p_BE;
		}		

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
				OPWinList entity=(OPWinList)p_BE;				
				OPWinListCtl control=new OPWinListCtl(sqlTrans);
				//entity.ID=EntityIDTable.GetID((long)SysEntity.Data_OPWinList,sqlTrans);
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
				OPWinList entity=(OPWinList)p_BE;				
				OPWinListCtl control=new OPWinListCtl(sqlTrans);				
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
				OPWinList entity=(OPWinList)p_BE;				
				OPWinListCtl control=new OPWinListCtl(sqlTrans);
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
		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="p_BE"></param>
		/// <param name="p_BESub"></param>
		public void RSave(BaseEntity[] p_BE,BaseEntity[] p_BESub,string p_OPID)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RSave(p_BE,p_BESub,p_OPID,sqlTrans);
					
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
		/// 保存
		/// </summary>
		/// <param name="p_BE">要删除的实体</param>
		/// <param name="sqlTrans">事务类</param>
		public void RSave(BaseEntity[] p_BE,BaseEntity[] p_BESub,string p_OPID,IDBTransAccess sqlTrans)
		{
			try
			{				
				string sql="DELETE FROM Data_OPWinList WHERE OPID="+SysString.ToDBString(p_OPID);
				sqlTrans.ExecuteNonQuery(sql);
				sql="DELETE FROM Data_OPWinListSub WHERE OPID="+SysString.ToDBString(p_OPID);
				sqlTrans.ExecuteNonQuery(sql);
				for(int i=0;i<p_BE.Length;i++)
				{
					this.RAdd(p_BE[i],sqlTrans);
				}
				OPWinListSubRule rule=new OPWinListSubRule();
				for(int i=0;i<p_BESub.Length;i++)
				{
					rule.RAdd(p_BESub[i],sqlTrans);
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
        /// 批量保存
        /// </summary>
        /// <param name="p_BE"></param>
        /// <param name="p_BESub"></param>
        public void RAllSave(BaseEntity[] p_BE, BaseEntity[] p_BESub)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAllSave(p_BE, p_BESub, sqlTrans);

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
        /// 批量保存
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAllSave(BaseEntity[] p_BE, BaseEntity[] p_BESub, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Data_OPWinList WHERE 1=1";
                sqlTrans.ExecuteNonQuery(sql);
                sql = "DELETE FROM Data_OPWinListSub WHERE 1=1";
                sqlTrans.ExecuteNonQuery(sql);

                sql = "  SELECT OPID FROM Data_OP WHERE ISNULL(DefaultFlag,0)=0 AND ISNULL(UseableFlag,0)=1";
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int i = 0; i < p_BE.Length; i++)
                        {
                            OPWinList entity = (OPWinList)p_BE[i];
                            entity.OPID = dt.Rows[j]["OPID"].ToString();
                            this.RAdd(entity, sqlTrans);
                        }
                        OPWinListSubRule rule = new OPWinListSubRule();
                        for (int i = 0; i < p_BESub.Length; i++)
                        {
                            OPWinListSub entitySub = (OPWinListSub)p_BESub[i];
                            entitySub.OPID = dt.Rows[j]["OPID"].ToString();
                            rule.RAdd(entitySub, sqlTrans);
                        }
                    }
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
