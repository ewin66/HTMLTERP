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
	/// 目的：WH_StorgeLock实体业务规则类
	/// 作者:周富春
	/// 创建日期:2009-9-14
	/// </summary>
	public class StorgeLockRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public StorgeLockRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			StorgeLock entity=(StorgeLock)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_StorgeLock WHERE 1=1";
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
				StorgeLock entity=(StorgeLock)p_BE;				
				StorgeLockCtl control=new StorgeLockCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_StorgeLock, sqlTrans);
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
				StorgeLock entity=(StorgeLock)p_BE;				
				StorgeLockCtl control=new StorgeLockCtl(sqlTrans);				
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
				StorgeLock entity=(StorgeLock)p_BE;				
				StorgeLockCtl control=new StorgeLockCtl(sqlTrans);
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


        #region 
        /// <summary>
        /// 锁定库存
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RLock(BaseEntity p_BE, bool p_CheckLockNum)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RLock(p_BE, p_CheckLockNum, sqlTrans);

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
        /// 锁定库存(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RLock(BaseEntity p_BE, bool p_CheckLockNum, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                StorgeLock entity = (StorgeLock)p_BE;

                string sql = string.Empty;
                //DataTable dt;
                //if (p_CheckLockNum)//校验是否超过最大锁定次数
                //{
                //    ParamSetRule ruleparam = new ParamSetRule();
                //    sql = "SELECT COUNT(*) FROM WH_StorgeLockHis WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                //    sql += " AND LockOPID=" + SysString.ToDBString(entity.LockOPID);
                //    sql += " AND LockTime BETWEEN " + SysString.ToDBString(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-1");
                //    sql += " AND " + SysString.ToDBString(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
                //    dt = sqlTrans.Fill(sql);
                //    if (SysConvert.ToInt32(dt.Rows[0][0]) >= ruleparam.RShowInt((int)ParamSet.锁定次数))
                //    {
                //        throw new Exception("纱种：" + entity.ItemName + " 本月已达到最大锁定次数" + dt.Rows[0][0].ToString() + "，锁定失败");
                //    }
                //}

                StorgeLockHisRule rule = new StorgeLockHisRule();
                StorgeLockHis entityhis = new StorgeLockHis(sqlTrans);
                entityhis.ID = entity.ID;
                entityhis.WHID = entity.WHID;
                //entityhis.StorgeID = entity.StorgeID;
                entityhis.ItemCode = entity.ItemCode;
                entityhis.ItemName = entity.ItemName;
                entityhis.ItemStd = entity.ItemStd;
                entityhis.LockDesc = entity.Remark;
                entityhis.LockOPID = entity.LockOPID;
                //entityhis.LockQty = entity.LockQty;
                entityhis.LockSO = entity.LockSO;
                entityhis.LockTime = entity.LockTime;
                entityhis.NeedDate = entity.NeedDate;
                entityhis.Batch = entity.Batch;
                entityhis.VendorBatch = entity.VendorBatch;
                entityhis.ColorName = entity.ColorName;
                entityhis.ColorNum = entity.ColorNum;
                entityhis.JarNum = entity.JarNum;
                //entityhis.WHTypeID = entity.WHTypeID;
                //entityhis.LockTypeID = (int)LockType.锁定;
                entity.LastUpdOP = ParamConfig.LoginName;
                entity.LastUpdTime = DateTime.Now;
                this.RAdd(entity, sqlTrans);
                //更新库存
                StorgeRule rules = new StorgeRule();
               // rules.UpdateStorge(entity.StorgeID, SysConvert.ToFloat(entity.LockQty), true, sqlTrans);
                //新增锁定历史数据
                rule.RAdd(entityhis, sqlTrans);
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
        /// 解锁
        /// </summary>
        /// <param name="p_StorgeLockID">原锁定库存ID</param>
        /// <param name="p_UnLockQty">解锁数量</param>
        /// <param name="p_Remark">解锁备注</param>
        /// <param name="p_AboveFlag">超过解锁数量是否提示  1/0：提示/不提示</param>
        public void RUnLock(int p_StorgeLockID, decimal p_UnLockQty, string p_Remark, bool p_AboveFlag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUnLock(p_StorgeLockID, p_UnLockQty, p_Remark, p_AboveFlag, sqlTrans);

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
        /// 解锁
        /// </summary>
        /// <param name="p_StorgeLockID">锁定记录ID</param>
        /// <param name="sqlTrans">事务类</param>
        public void RUnLock(int p_StorgeLockID, decimal p_UnLockQty, string p_Remark, bool p_AboveFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                StorgeLock entity = new StorgeLock(sqlTrans);
                entity.ID = p_StorgeLockID;
                entity.SelectByID();

                StorgeLockHisRule rule = new StorgeLockHisRule();
                StorgeLockHis entityhis = new StorgeLockHis(sqlTrans);

                //entityhis.StorgeID = p_StorgeLockID;
                //entityhis.LockStorgeID = p_StorgeLockID;
                entityhis.ID = entity.ID;
                entityhis.WHID = entity.WHID;
               // entityhis.StorgeID = entity.StorgeID;
                entityhis.ItemCode = entity.ItemCode;
                entityhis.ItemName = entity.ItemName;
                entityhis.ItemStd = entity.ItemStd;
                entityhis.LockOPID = entity.LockOPID;
                //entityhis.LockQty = entity.LockQty;
                entityhis.LockSO = entity.LockSO;
                entityhis.Batch = entity.Batch;
                entityhis.VendorBatch = entity.VendorBatch;
                entityhis.ColorName = entity.ColorName;
                entityhis.ColorNum = entity.ColorNum;
                entityhis.JarNum = entity.JarNum;
                entityhis.VendorBatch = entity.VendorBatch;
                entityhis.LockTime = entity.LockTime;
                entityhis.NeedDate = entity.NeedDate;
                entityhis.LockDesc = entity.Remark;
                //entityhis.LockTypeID = (int)LockType.解除锁定;

                //entityhis.LockQty = p_UnLockQty;
                //entityhis.UnLockQty = p_UnLockQty;
                //entityhis.UnlockOPID = ParamConfig.LoginID;
                //entityhis.UnlockTime = DateTime.Now;
                //entityhis.UnlockDesc = p_Remark;
                entityhis.Remark = p_Remark;

                entityhis.LastUpdOP = ParamConfig.LoginName;
                entityhis.LastUpdTime = DateTime.Now;

                if (p_UnLockQty >= entity.LockQty)//已经全部解锁
                {
                    if (p_AboveFlag && (p_UnLockQty > entity.LockQty))
                    {
                        throw new Exception("解锁数量：" + p_UnLockQty.ToString() + " 大于当前锁定数量：" + entity.LockQty.ToString() + "，解锁失败");
                    }
                    this.RDelete(entity, sqlTrans);
                    StorgeRule rules = new StorgeRule();
                   // rules.UpdateStorge(entity.StorgeID, SysConvert.ToFloat(entity.LockQty), false, sqlTrans);

                }
                else//未全部解锁
                {
                    entity.LockQty = entity.LockQty - p_UnLockQty;
                    entity.LastUpdOP = ParamConfig.LoginName;
                    entity.LastUpdTime = DateTime.Now.Date;
                    this.RUpdate(entity, sqlTrans);
                    StorgeRule rules = new StorgeRule();
                    //rules.UpdateStorge(entity.StorgeID, SysConvert.ToFloat(p_UnLockQty), false, sqlTrans);
                }

                rule.RAdd(entityhis, sqlTrans);//新增解锁历史记录
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
