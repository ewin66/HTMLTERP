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
	/// 目的：Sale_SaleOrderCapDts实体业务规则类
	/// 作者:章文强
	/// 创建日期:2012/7/30
	/// </summary>
	public class SaleOrderCapDtsRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public SaleOrderCapDtsRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			SaleOrderCapDts entity=(SaleOrderCapDts)p_BE;
		}	
		
		/// <summary>
        /// 检验字段值是否已存在
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_FieldName">字段名</param>
        /// <param name="p_FieldValue">字段值</param>
        /// <param name="p_KeyField">主键（只考虑主键为ID的情况）</param>
        /// <param name="p_KeyValue">主键值</param>
        /// <param name="p_sqlTrans"></param>
        /// <returns></returns>
        private bool CheckFieldValueIsExist(BaseEntity p_BE, string p_FieldName, string p_FieldValue, IDBTransAccess p_sqlTrans)
        {
            SaleOrderCapDts entity = (SaleOrderCapDts)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, SaleOrderCapDts.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
            DataTable dt = p_sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                ret = true;
            }

            return ret;
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
                string sql = "SELECT " + p_FieldName + " FROM Sale_SaleOrderCapDts WHERE 1=1";
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


        #region 保存资金明细

        /// <summary>
        /// 保存资金明细
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RSaveSaleCap(SaleOrder p_BEMain)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSaveSaleCap(p_BEMain, sqlTrans);

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
        /// 保存资金明细(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RSaveSaleCap(SaleOrder p_BEMain, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                sql = "SELECT * FROM Sale_SaleOrderCapDts WHERE MainID=" + p_BEMain.ID + " ORDER BY Seq";
                DataTable dtOld = sqlTrans.Fill(sql);//找到原始的ID

                sql = "SELECT * FROM Data_PayMethodDts WHERE MainID=" + SysConvert.ToInt32(p_BEMain.PayMethodFlag) + " ORDER BY Seq";
                DataTable dtPayMethodDts = sqlTrans.Fill(sql);//付款方式明细

                sql = "SELECT ItemCode,SUM(Amount) Amount,MIN(DtsReqDate) DtsReqDate FROM Sale_SaleOrderDts WHERE MainID=" + p_BEMain.ID + " GROUP BY ItemCode";
                DataTable dtSaleDts = sqlTrans.Fill(sql);//合同品种明细



                //根据不同品种生成独立的付款明细
                SaleOrderCapDts[] entityDts = new SaleOrderCapDts[dtPayMethodDts.Rows.Count * dtSaleDts.Rows.Count];//初始化资金明细实体数组
                int ci = 0;
                for (int i = 0; i < dtPayMethodDts.Rows.Count; i++)
                {
                    for (int m = 0; m < dtSaleDts.Rows.Count; m++)//多个品种生成独立的资金计划
                    {
                        entityDts[ci] = new SaleOrderCapDts();
                        if (dtOld.Rows.Count > ci)
                        {
                            entityDts[ci].ID = SysConvert.ToInt32(dtOld.Rows[ci]["ID"]);
                        }
                        entityDts[ci].MainID = p_BEMain.ID;
                        entityDts[ci].Seq = ci + 1;
                        entityDts[ci].CapName = dtPayMethodDts.Rows[i]["Name"].ToString();//名称
                        entityDts[ci].PayStepTypeID = SysConvert.ToInt32(dtPayMethodDts.Rows[i]["PayStepTypeID"]);
                        entityDts[ci].PayPer = SysConvert.ToDecimal(dtPayMethodDts.Rows[i]["PayPer"]);
                        switch (SysConvert.ToInt32(dtPayMethodDts.Rows[i]["PayDateTypeInt"]))//根据付款判断日期类型类型
                        {
                            case (int)EnumPayDateType.依据合同签署日:
                                entityDts[ci].PayLimitDate = p_BEMain.OrderDate.AddDays(SysConvert.ToInt32(dtPayMethodDts.Rows[i]["DelayDayNum"])).Date;//合同日延后多少天
                                break;

                            case (int)EnumPayDateType.依据发货日://备注下发货日；读取默认交期；后续发货后回填实际日期
                                entityDts[ci].Remark = "根据发货日";
                                entityDts[ci].PayLimitDate = SysConvert.ToDateTime(dtSaleDts.Rows[m]["DtsReqDate"]).AddDays(SysConvert.ToInt32(dtPayMethodDts.Rows[i]["DelayDayNum"])).Date;
                                break;
                        }

                        entityDts[ci].ItemCode = dtSaleDts.Rows[m]["ItemCode"].ToString();
                        entityDts[ci].PayAmount = SysConvert.ToDecimal(dtSaleDts.Rows[m]["Amount"]) * entityDts[ci].PayPer;//付款金额
                        ci++;
                    }
                }
                this.RSave(p_BEMain, entityDts, sqlTrans);//保存明细

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


        #region 保存方法
        /// <summary>
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(SaleOrder p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Sale_SaleOrderCapDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//删除原单据里应该删除的明细数据，即数据库里有但是UI里已经删除的数据
                for (int i = 0; i < p_BE.Length; i++)
                {
                    SaleOrderCapDts entitydts = (SaleOrderCapDts)p_BE[i];
                    if (entitydts.ID != 0)//ID不为0说明数据库中已经存在
                    {
                        this.RUpdate(entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);
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
                SaleOrderCapDts entitydts = (SaleOrderCapDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
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
				SaleOrderCapDts entity=(SaleOrderCapDts)p_BE;				
				SaleOrderCapDtsCtl control=new SaleOrderCapDtsCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Sale_SaleOrderCapDts,sqlTrans);
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
				SaleOrderCapDts entity=(SaleOrderCapDts)p_BE;				
				SaleOrderCapDtsCtl control=new SaleOrderCapDtsCtl(sqlTrans);				
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
				SaleOrderCapDts entity=(SaleOrderCapDts)p_BE;				
				SaleOrderCapDtsCtl control=new SaleOrderCapDtsCtl(sqlTrans);
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

        #region 新增方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(int p_ID,BaseEntity[] p_BE)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_ID,p_BE, sqlTrans);

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
        public void RAdd(int p_ID,BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                if (p_ID > 0)
                {
                    string sql = "DELETE Sale_SaleOrderCapDts WHERE MainID="+SysString.ToDBString(p_ID);
                    sqlTrans.ExecuteNonQuery(sql);
                    for (int i = 0; i < p_BE.Length; i++)
                    {
                        SaleOrderCapDtsRule rule = new SaleOrderCapDtsRule();
                        SaleOrderCapDts entity = (SaleOrderCapDts)p_BE[i];
                        entity.MainID = p_ID;
                        entity.Seq = i + 1;
                        rule.RAdd(entity, sqlTrans);

                    }
                    sql = "UPDATE Sale_SaleOrder SET FKFlag=1";
                    sql += " WHERE ID="+SysString.ToDBString(p_ID);
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
        #endregion
    }
}
