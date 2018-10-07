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
	/// 目的：CaiWu_CWInvoiceDts实体业务规则类
	/// 作者:辛明献
	/// 创建日期:2011-11-4
	/// </summary>
	public class CWInvoiceDtsRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public CWInvoiceDtsRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CWInvoiceDts entity=(CWInvoiceDts)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM CaiWu_CWInvoiceDts WHERE 1=1";
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
        public void RSave(CWInvoice p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                #region 初始化对账标志
                //初始化对账标志
                string sql = "Select * From CaiWu_CWInvoiceDts WHERE  1=1";
                sql += " AND MainID=" + SysString.ToDBString(p_Entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sql = "Update CaiWu_CWDuiZhang Set DZFlag=0 ";
                        sql += " WHERE 1=1 AND Code=" + SysString.ToDBString(dt.Rows[i]["DZCode"].ToString());
                        sqlTrans.ExecuteNonQuery(sql);


                        ///初始化仓库发票标志
                        sql = "Select * From CaiWu_CWDuiZhangDts WHERE  1=1";
                        sql += " AND MainID=" + " (SELECT ID FROM CaiWu_CWDuiZhang WHERE Code=" + SysString.ToDBString(dt.Rows[i]["DZCode"].ToString()) + ")";
                        DataTable dt1 = sqlTrans.Fill(sql);
                        if (dt1.Rows.Count != 0)
                        {
                            for (int m = 0; m < dt1.Rows.Count; m++)
                            {
                                sql = "Update WH_IOFormDts Set DtsInvoiceDelFlag=0,DtsInvoiceDelTime=null,DtsInvoiceDelOPID='',DtsInvoiceNo='',InvoiceQty=0";
                                sql += " WHERE 1=1 AND MainID=" + SysConvert.ToInt32(dt1.Rows[m]["IOFormID"]);
                                sql += " AND Seq=" + SysConvert.ToInt32(dt1.Rows[m]["IOFormSeq"]);
                                sqlTrans.ExecuteNonQuery(sql);
                            }
                        }
                    }
                }
                #endregion


                sql = "DELETE FROM CaiWu_CWInvoiceDts WHERE MainID=" + p_Entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//删除原单据明细数据
                for (int i = 0; i < p_BE.Length; i++)
                {
                    CWInvoiceDts entitydts = (CWInvoiceDts)p_BE[i];
                    sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM CaiWu_CWInvoiceDts WHERE MainID=" + p_Entity.ID.ToString();
                    entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//找到最大的Seq
                    entitydts.MainID = p_Entity.ID;
                    this.RAdd(entitydts, sqlTrans);

                    #region 处理对账和仓库开票的数据回填
                    //处理对账单中的对账标志
                    sql = "UPDATE CaiWu_CWDuiZhang Set DZFlag=1 WHERE Code=" + SysString.ToDBString(entitydts.DZCode);
                    sqlTrans.ExecuteNonQuery(sql);


                    sql = "Select * From CaiWu_CWDuiZhangDts WHERE  1=1 ";
                    sql += " AND MainID=" + " (SELECT ID FROM CaiWu_CWDuiZhang WHERE Code=" + SysString.ToDBString(entitydts.DZCode) + ")";
                    DataTable dt2 = sqlTrans.Fill(sql);
                    if (dt2.Rows.Count != 0)
                    {
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            ///处理仓库发票标志
                            sql = "Update WH_IOFormDts Set DtsInvoiceDelFlag=1";
                            if (p_Entity.InvoiceDate != SystemConfiguration.DateTimeDefaultValue)
                            {
                                sql += " ,DtsInvoiceDelTime=" + SysString.ToDBString(p_Entity.InvoiceDate);
                            }
                            else
                            {
                                sql += " ,DtsInvoiceDelTime=null";
                            }
                            sql += ",InvoiceQty=" + SysString.ToDBString(p_Entity.InvoiceQty);
                            sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(p_Entity.InvoiceOPID);
                            sql += ",DtsInvoiceNo=" + SysString.ToDBString(p_Entity.InvoiceNo);
                            sql += " WHERE 1=1 AND MainID=" + SysString.ToDBString(dt2.Rows[j]["IOFormID"].ToString());
                            sql += " AND Seq=" + SysString.ToDBString(dt2.Rows[j]["IOFormSeq"].ToString());
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                    } 
                    #endregion
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
				CWInvoiceDts entity=(CWInvoiceDts)p_BE;				
				CWInvoiceDtsCtl control=new CWInvoiceDtsCtl(sqlTrans);
                //entity.ID=(int)EntityIDTable.GetID((long)SysEntity.CaiWu_CWInvoiceDts,sqlTrans);
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
				CWInvoiceDts entity=(CWInvoiceDts)p_BE;				
				CWInvoiceDtsCtl control=new CWInvoiceDtsCtl(sqlTrans);				
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
				CWInvoiceDts entity=(CWInvoiceDts)p_BE;				
				CWInvoiceDtsCtl control=new CWInvoiceDtsCtl(sqlTrans);

                string sqldz = "SELECT DZID FROM CaiWu_CWInvoiceDts WHERE MainID=" + SysString.ToDBString(entity.MainID);
                DataTable dt = sqlTrans.Fill(sqldz);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sqldz = "UPDATE CaiWu_CWDuiZhang SET DZFlag=0 WHERE Code=" + SysString.ToDBString(dt.Rows[i]["DZCode"].ToString());
                        sqlTrans.ExecuteNonQuery(sqldz);
                    }
                }
                string sql = "DELETE FROM CaiWu_CWInvoiceDts WHERE MainID=" + SysString.ToDBString(entity.MainID);
                sqlTrans.ExecuteNonQuery(sql);              


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
