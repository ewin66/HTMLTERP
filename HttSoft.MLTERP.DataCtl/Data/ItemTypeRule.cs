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
	/// 目的：Enum_ItemType实体业务规则类
	/// 作者:LookSun
	/// 创建日期:2009-3-31
	/// </summary>
	public class ItemTypeRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public ItemTypeRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
            HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;
		}		


        	/// <summary>
		/// 显示数据
		/// </summary>
		/// <param name="p_condition"></param>
		public DataTable RShow(string p_condition)
		{
			try
			{				
				return RShow(p_condition,"*");
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new Exception(E.Message);
			}
		}	

		/// <summary>
		/// 显示数据
		/// </summary>
		/// <param name="p_condition"></param>
		public DataTable RShow(string p_condition,string p_FieldName)
		{
			try
			{
				if(p_FieldName==string.Empty)
				{
					p_FieldName="*";
				}
                string sql = "SELECT " + p_FieldName + " FROM Enum_ItemType WHERE 1=1";
				sql+=p_condition;
				return SysUtils.Fill(sql);
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
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
                HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;
                string sql = string.Empty;

                sql = " SELECT 1 FROM  Enum_ItemType WHERE ID= " + SysString.ToDBString(entity.ID);

                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("该ID已经存在，请重新输入！");
                }

                sql = " SELECT 1 FROM  Enum_ItemType WHERE Code= " + SysString.ToDBString(entity.Code);

                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("该编码已经存在，请重新输入！");
                }

				ItemTypeCtl control=new ItemTypeCtl(sqlTrans);
				//entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Enum_ItemType,sqlTrans);
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
                HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;	
			
				ItemTypeCtl control=new ItemTypeCtl(sqlTrans);				
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
                HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;				
				
                ItemTypeCtl control=new ItemTypeCtl(sqlTrans);
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
