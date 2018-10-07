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
	/// 目的：Buy_ItemBuyCapExDts实体业务规则类
	/// 作者:章文强
	/// 创建日期:2012/7/30
	/// </summary>
	public class ItemBuyCapExDtsRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public ItemBuyCapExDtsRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;
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
            ItemBuyCapExDts entity = (ItemBuyCapExDts)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, ItemBuyCapExDts.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM Buy_ItemBuyCapExDts WHERE 1=1";
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

        #region 资金核销关联、撤销核销关联
        /// <summary>
        /// 资金核销关联
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sqlTrans"></param>
        public void RHT(RecPay payEntity, RecPayHTDts htentity, IDBTransAccess sqlTrans)
        {
            ItemBuyCapExDts entityDts = new ItemBuyCapExDts();
            entityDts.ExCapName = payEntity.FormNo;//存储付款单号
            entityDts.ExItemCode = htentity.HTItemCode;
            entityDts.ExPayStepTypeID = payEntity.PayStepTypeID;
            entityDts.ExPayAmount = htentity.HTAmount;
            entityDts.ExPayLimitDate = payEntity.ExDate.Date;
            entityDts.ExRemark = htentity.ID.ToString();//备注记录付款合同核销ID,便于关联检索            
                
            string sql = string.Empty;
            sql = "SELECT ID FROM Buy_ItemBuyForm WHERE FormNo=" + SysString.ToDBString(htentity.HTNo);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                entityDts.MainID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
            }

            sql = "SELECT ISNULL(MAX(Seq),0)+1 AS MSeq FROM Buy_ItemBuyCapExDts WHERE MainID=" + SysString.ToDBString(entityDts.MainID);
            entityDts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0]["MSeq"]);

            this.RAdd(entityDts, sqlTrans);
        }

        /// <summary>
        /// 撤销核销关联
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sqlTrans"></param>
        public void RHTCancel(RecPayHTDts htentity, IDBTransAccess sqlTrans)
        {
            ItemBuyCapExDts entityDts = new ItemBuyCapExDts();
            string sql = string.Empty;
            sql = "SELECT ID FROM Buy_ItemBuyCapExDts WHERE ExRemark=" + SysString.ToDBString(htentity.ID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                entityDts.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                entityDts.SelectByID();
            }

            this.RDelete(entityDts, sqlTrans);
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
				ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;				
				ItemBuyCapExDtsCtl control=new ItemBuyCapExDtsCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Buy_ItemBuyCapExDts,sqlTrans);
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
				ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;				
				ItemBuyCapExDtsCtl control=new ItemBuyCapExDtsCtl(sqlTrans);				
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
				ItemBuyCapExDts entity=(ItemBuyCapExDts)p_BE;				
				ItemBuyCapExDtsCtl control=new ItemBuyCapExDtsCtl(sqlTrans);
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
