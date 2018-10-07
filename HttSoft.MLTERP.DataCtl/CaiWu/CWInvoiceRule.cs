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
	/// 目的：CaiWu_CWInvoice实体业务规则类
	/// 作者:辛明献
	/// 创建日期:2011-11-4
	/// </summary>
	public class CWInvoiceRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public CWInvoiceRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CWInvoice entity=(CWInvoice)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_CaiWu_CWInvoice WHERE 1=1";
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
        
        
        #region  主从表保存方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, sqlTrans);

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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                CWInvoiceDtsRule ruledts = new CWInvoiceDtsRule();
                ruledts.RSave((CWInvoice)p_BE, p_BE2, sqlTrans);//保存从表


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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, sqlTrans);

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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                CWInvoiceDtsRule ruledts = new CWInvoiceDtsRule();
                ruledts.RSave((CWInvoice)p_BE, p_BE2, sqlTrans);//保存从表
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
                CWInvoice entity = (CWInvoice)p_BE;
                CWInvoiceCtl control = new CWInvoiceCtl(sqlTrans);

                string sql = string.Empty;
                sql = " SELECT InvoiceNo FROM CaiWu_CWInvoice WHERE 1=1 AND InvoiceNo=" + SysString.ToDBString(entity.InvoiceNo);
                if (sqlTrans.Fill(sql).Rows.Count != 0)
                {
                    throw new Exception("发票号已经存在，请重新生成");
                }
                //entity.ID = (int)EntityIDTable.GetID((long)SysEntity.CaiWu_CWInvoice, sqlTrans);
                control.AddNew(entity);

                //sql = " UPDATE Enum_FormNoControl SET CurSort=CurSort+1 WHERE ID=" + (int)FormNoControlEnum.发票号码;//更新CurSort
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
                CWInvoice entity = (CWInvoice)p_BE;
                CWInvoiceCtl control = new CWInvoiceCtl(sqlTrans);
                string sql = string.Empty;
                sql = " SELECT InvoiceNo FROM CaiWu_CWInvoice WHERE 1=1 AND InvoiceNo=" + SysString.ToDBString(entity.InvoiceNo)+" AND ID<>"+SysString.ToDBString(entity.ID);
                if (sqlTrans.Fill(sql).Rows.Count != 0)
                {
                    throw new Exception("该发票号已经存在，请重新生成");
                }
                else
                {
                    control.Update(entity);
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
				CWInvoice entity=(CWInvoice)p_BE;				
				CWInvoiceCtl control=new CWInvoiceCtl(sqlTrans);
				
				
       
                string sql = "Select * From CaiWu_CWInvoiceDts WHERE  1=1";
                sql += " AND MainID=" + SysString.ToDBString(entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        #region 处理对账和仓库开票的数据回填
                        //处理对账单中的对账标志
                        sql = "UPDATE CaiWu_CWDuiZhang Set DZFlag=0 WHERE Code=" + SysString.ToDBString(dt.Rows[i]["DZCode"].ToString());
                        sqlTrans.ExecuteNonQuery(sql);


                        sql = "Select * From CaiWu_CWDuiZhangDts WHERE  1=1 ";
                        sql += " AND MainID=" + " (SELECT ID FROM CaiWu_CWDuiZhang WHERE Code=" + SysString.ToDBString(dt.Rows[i]["DZCode"].ToString()) +")";
                        DataTable dt2 = sqlTrans.Fill(sql);
                        if (dt2.Rows.Count != 0)
                        {
                            for (int j = 0; j < dt2.Rows.Count; j++)
                            {
                                ///处理仓库发票标志

                                sql = "Update WH_IOFormDts Set DtsInvoiceDelFlag=0,DtsInvoiceDelTime=null,DtsInvoiceDelOPID='',DtsInvoiceNo='',InvoiceQty=0";
                                sql += " WHERE 1=1 AND MainID=" + SysString.ToDBString(dt2.Rows[j]["IOFormID"].ToString());
                                sql += " AND Seq=" + SysString.ToDBString(dt2.Rows[j]["IOFormSeq"].ToString());
                                sqlTrans.ExecuteNonQuery(sql);
                            }
                        }
                    }
                    #endregion
                }

                 sql = "DELETE FROM CaiWu_CWInvoiceDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据
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
