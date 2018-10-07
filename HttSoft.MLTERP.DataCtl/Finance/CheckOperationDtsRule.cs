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
	/// 目的：Finance_CheckOperationDts实体业务规则类
	/// 作者:刘德苏
	/// 创建日期:2012/5/8
	/// </summary>
	public class CheckOperationDtsRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public CheckOperationDtsRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOperationDts entity=(CheckOperationDts)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV2_Finance_CheckOperationDts WHERE 1=1";
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
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow2(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV2_Finance_CheckOperationDts2 WHERE 1=1";
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
        /// 获得数据库里没有被删除的ID(即数据库里有而且UI里也没有删除的数据)
        /// </summary>
        /// <param name="p_BE"></param>
        /// <returns></returns>
        private string GetIDExist(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                CheckOperationDts entitydts = (CheckOperationDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        private string GetIDExist2(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                CheckOperationInvDts entitydts = (CheckOperationInvDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        private string GetIDExist3(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                CheckOperationPayDts entitydts = (CheckOperationPayDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        /// <summary>
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(CheckOperation p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();////找到最大的Seq    将获得最大Seq的语句放到循环外更高效(多人操作时会有问题吗?)
                int MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE.Length; i++)
                {
                    CheckOperationDts entitydts = (CheckOperationDts)p_BE[i];
                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.Seq = MSEQ;
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);

                        MSEQ++;//最大值加1
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

        public void RSave(CheckOperation p_Entity, BaseEntity[] p_BE,BaseEntity[] p_BE2,BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationDts WHERE MainID=" + p_Entity.ID.ToString();////找到最大的Seq    将获得最大Seq的语句放到循环外更高效(多人操作时会有问题吗?)
                int MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE.Length; i++)
                {
                    CheckOperationDts entitydts = (CheckOperationDts)p_BE[i];
                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.Seq = MSEQ;
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);

                        MSEQ++;//最大值加1
                    }
                }

                sql = "DELETE FROM Finance_CheckOperationInvDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist2(p_BE2));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationInvDts WHERE MainID=" + p_Entity.ID.ToString();////找到最大的Seq    将获得最大Seq的语句放到循环外更高效(多人操作时会有问题吗?)
                MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    CheckOperationInvDtsRule rule2 = new CheckOperationInvDtsRule();
                    CheckOperationInvDts entityInvDts = (CheckOperationInvDts)p_BE2[i];
                    if (entityInvDts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        rule2.RUpdate(entityInvDts, sqlTrans);
                    }
                    else
                    {
                        entityInvDts.Seq = MSEQ;
                        entityInvDts.MainID = p_Entity.ID;
                        rule2.RAdd(entityInvDts, sqlTrans);

                        MSEQ++;//最大值加1
                    }
                }


                sql = "DELETE FROM Finance_CheckOperationPayDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist3(p_BE3));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Finance_CheckOperationPayDts WHERE MainID=" + p_Entity.ID.ToString();////找到最大的Seq    将获得最大Seq的语句放到循环外更高效(多人操作时会有问题吗?)
                MSEQ = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    CheckOperationPayDtsRule rule3 = new CheckOperationPayDtsRule();
                    CheckOperationPayDts entityPayDts = (CheckOperationPayDts)p_BE3[i];
                    if (entityPayDts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        rule3.RUpdate(entityPayDts, sqlTrans);
                    }
                    else
                    {
                        entityPayDts.Seq = MSEQ;
                        entityPayDts.MainID = p_Entity.ID;
                        rule3.RAdd(entityPayDts, sqlTrans);

                        MSEQ++;//最大值加1
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
				CheckOperationDts entity=(CheckOperationDts)p_BE;				
				CheckOperationDtsCtl control=new CheckOperationDtsCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Finance_CheckOperationDts,sqlTrans);
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
				CheckOperationDts entity=(CheckOperationDts)p_BE;				
				CheckOperationDtsCtl control=new CheckOperationDtsCtl(sqlTrans);				
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
				CheckOperationDts entity=(CheckOperationDts)p_BE;				
				CheckOperationDtsCtl control=new CheckOperationDtsCtl(sqlTrans);
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
