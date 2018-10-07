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
	/// 目的：Buy_YarnCompactDts实体业务规则类
	/// 作者:辛明献
	/// 创建日期:2011-11-4
	/// </summary>
	public class YarnCompactDtsRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public YarnCompactDtsRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			YarnCompactDts entity=(YarnCompactDts)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Buy_YarnCompactDts WHERE 1=1";
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
        
         #region 保存

        /// <summary>
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(YarnCompact p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Buy_YarnCompactDts WHERE MainID=" + p_Entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据
                for (int i = 0; i < p_BE.Length; i++)
                {
                    YarnCompactDts entitydts = (YarnCompactDts)p_BE[i];
                    sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Buy_YarnCompactDts WHERE MainID=" + p_Entity.ID.ToString();
                    entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//找到最大的Seq
                    entitydts.MainID = p_Entity.ID;
                    this.RAdd(entitydts, sqlTrans);
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
				YarnCompactDts entity=(YarnCompactDts)p_BE;				
				YarnCompactDtsCtl control=new YarnCompactDtsCtl(sqlTrans);
                //entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Buy_YarnCompactDts,sqlTrans);
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
				YarnCompactDts entity=(YarnCompactDts)p_BE;				
				YarnCompactDtsCtl control=new YarnCompactDtsCtl(sqlTrans);				
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
				YarnCompactDts entity=(YarnCompactDts)p_BE;				
				YarnCompactDtsCtl control=new YarnCompactDtsCtl(sqlTrans);
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
