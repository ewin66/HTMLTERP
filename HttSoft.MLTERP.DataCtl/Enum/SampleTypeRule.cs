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
	/// 目的：Enum_SampleType实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2009-4-2
	/// </summary>
	public class SampleTypeRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public SampleTypeRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			SampleType entity=(SampleType)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Enum_SampleType WHERE 1=1 ";
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
				SampleType entity=(SampleType)p_BE;				
				SampleTypeCtl control=new SampleTypeCtl(sqlTrans);
                string sql = "";
                //string sql = "SELECT Code FROM Enum_SampleType WHERE Code=" + SysString.ToDBString(entity.Code);

                //DataTable dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    throw new Exception("编码已经存在，请重新输入！");
                //}
                sql = "SELECT ID FROM Enum_SampleType WHERE ID=" + SysString.ToDBString(entity.ID);
                DataTable dt2 = sqlTrans.Fill(sql);
                dt2 = sqlTrans.Fill(sql);
                if (dt2.Rows.Count != 0)
                {
                    throw new Exception("ID已经存在，请重新输入！");
                }
                sql = "SELECT Name FROM Enum_SampleType WHERE Name=" + SysString.ToDBString(entity.Name);
                DataTable dt3 = sqlTrans.Fill(sql);
                dt3 = sqlTrans.Fill(sql);
                if (dt3.Rows.Count != 0)
                {
                    throw new Exception("名称已经存在，请重新输入！");
                }
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
				SampleType entity=(SampleType)p_BE;				
				SampleTypeCtl control=new SampleTypeCtl(sqlTrans);
                string sql = "";
                //string sql = "SELECT Code FROM Enum_SampleType WHERE Code=" + SysString.ToDBString(entity.Code);

                //sql += " AND ID<>" + SysString.ToDBString(entity.ID);
                //DataTable dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    throw new Exception("编码已经存在，请重新输入！");
                //}
                sql = "SELECT Name FROM Enum_SampleType WHERE Name=" + SysString.ToDBString(entity.Name);

                sql += " AND ID<>" + SysString.ToDBString(entity.ID);
                DataTable dt2 = sqlTrans.Fill(sql);
                dt2 = sqlTrans.Fill(sql);
                if (dt2.Rows.Count != 0)
                {
                    throw new Exception("名称已经存在，请重新输入！");
                }


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
				SampleType entity=(SampleType)p_BE;				
				SampleTypeCtl control=new SampleTypeCtl(sqlTrans);
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
