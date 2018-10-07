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
	/// Ŀ�ģ�WH_StorgeLockʵ��ҵ�������
	/// ����:�ܸ���
	/// ��������:2009-9-14
	/// </summary>
	public class StorgeLockRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public StorgeLockRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			StorgeLock entity=(StorgeLock)p_BE;
		}	
		
		
		 /// <summary>
        /// ��ʾ����
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
        /// ��ʾ����
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
		/// ����
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
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
		/// ����(����������)
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
		/// <param name="sqlTrans">������</param>
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
		/// �޸�
		/// </summary>
		/// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
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
		/// �޸�
		/// </summary>
		/// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
		/// <param name="sqlTrans">������</param>
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
		/// ɾ��
		/// </summary>
		/// <param name="p_BE">Ҫɾ����ʵ��</param>
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
		/// ɾ��
		/// </summary>
		/// <param name="p_BE">Ҫɾ����ʵ��</param>
		/// <param name="sqlTrans">������</param>
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
        /// �������
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
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
        /// �������(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RLock(BaseEntity p_BE, bool p_CheckLockNum, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                StorgeLock entity = (StorgeLock)p_BE;

                string sql = string.Empty;
                //DataTable dt;
                //if (p_CheckLockNum)//У���Ƿ񳬹������������
                //{
                //    ParamSetRule ruleparam = new ParamSetRule();
                //    sql = "SELECT COUNT(*) FROM WH_StorgeLockHis WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                //    sql += " AND LockOPID=" + SysString.ToDBString(entity.LockOPID);
                //    sql += " AND LockTime BETWEEN " + SysString.ToDBString(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-1");
                //    sql += " AND " + SysString.ToDBString(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
                //    dt = sqlTrans.Fill(sql);
                //    if (SysConvert.ToInt32(dt.Rows[0][0]) >= ruleparam.RShowInt((int)ParamSet.��������))
                //    {
                //        throw new Exception("ɴ�֣�" + entity.ItemName + " �����Ѵﵽ�����������" + dt.Rows[0][0].ToString() + "������ʧ��");
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
                //entityhis.LockTypeID = (int)LockType.����;
                entity.LastUpdOP = ParamConfig.LoginName;
                entity.LastUpdTime = DateTime.Now;
                this.RAdd(entity, sqlTrans);
                //���¿��
                StorgeRule rules = new StorgeRule();
               // rules.UpdateStorge(entity.StorgeID, SysConvert.ToFloat(entity.LockQty), true, sqlTrans);
                //����������ʷ����
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
        /// ����
        /// </summary>
        /// <param name="p_StorgeLockID">ԭ�������ID</param>
        /// <param name="p_UnLockQty">��������</param>
        /// <param name="p_Remark">������ע</param>
        /// <param name="p_AboveFlag">�������������Ƿ���ʾ  1/0����ʾ/����ʾ</param>
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
        /// ����
        /// </summary>
        /// <param name="p_StorgeLockID">������¼ID</param>
        /// <param name="sqlTrans">������</param>
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
                //entityhis.LockTypeID = (int)LockType.�������;

                //entityhis.LockQty = p_UnLockQty;
                //entityhis.UnLockQty = p_UnLockQty;
                //entityhis.UnlockOPID = ParamConfig.LoginID;
                //entityhis.UnlockTime = DateTime.Now;
                //entityhis.UnlockDesc = p_Remark;
                entityhis.Remark = p_Remark;

                entityhis.LastUpdOP = ParamConfig.LoginName;
                entityhis.LastUpdTime = DateTime.Now;

                if (p_UnLockQty >= entity.LockQty)//�Ѿ�ȫ������
                {
                    if (p_AboveFlag && (p_UnLockQty > entity.LockQty))
                    {
                        throw new Exception("����������" + p_UnLockQty.ToString() + " ���ڵ�ǰ����������" + entity.LockQty.ToString() + "������ʧ��");
                    }
                    this.RDelete(entity, sqlTrans);
                    StorgeRule rules = new StorgeRule();
                   // rules.UpdateStorge(entity.StorgeID, SysConvert.ToFloat(entity.LockQty), false, sqlTrans);

                }
                else//δȫ������
                {
                    entity.LockQty = entity.LockQty - p_UnLockQty;
                    entity.LastUpdOP = ParamConfig.LoginName;
                    entity.LastUpdTime = DateTime.Now.Date;
                    this.RUpdate(entity, sqlTrans);
                    StorgeRule rules = new StorgeRule();
                    //rules.UpdateStorge(entity.StorgeID, SysConvert.ToFloat(p_UnLockQty), false, sqlTrans);
                }

                rule.RAdd(entityhis, sqlTrans);//����������ʷ��¼
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
