using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;


namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// 目的：Chk_CheckOrderISN实体业务规则类
	/// 作者:周富春
	/// 创建日期:2015/11/4
	/// </summary>
	public class CheckOrderISNRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public CheckOrderISNRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOrderISN entity=(CheckOrderISN)p_BE;
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
            CheckOrderISN entity = (CheckOrderISN)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, CheckOrderISN.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM Chk_CheckOrderISN WHERE 1=1";
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
        public DataTable RShowDts(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_Chk_CheckOrderISN WHERE 1=1";
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
				CheckOrderISN entity=(CheckOrderISN)p_BE;				
                //CheckOrderISNCtl control=new CheckOrderISNCtl(sqlTrans);
                //entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Chk_CheckOrderISN, sqlTrans);
                //control.AddNew(entity);

                if (entity.ID == 0)
                {
                    CheckOrderISNCtl control = new CheckOrderISNCtl(sqlTrans);
                    entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Chk_CheckOrderISN, sqlTrans);
                    if (entity.Seq == 0)
                    {
                        entity.StatusID = (int)EnumBoxStatus.未入库;
                        entity.DISN = GetDISN(sqlTrans);
                        entity.Seq = GetMaxSeq(entity.MainID, entity.JarNum, sqlTrans);
                        entity.ReelNo = SysConvert.ToString(entity.Seq);//卷号

                    }

                    control.AddNew(entity);
                }
                else
                {
                    if (entity.StatusID != (int)EnumBoxStatus.未入库)//已经入库的条码不能修改
                    {
                        throw new Exception("条码不是初始状态不能修改");
                    }

                    RUpdate(entity, sqlTrans);
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
				CheckOrderISN entity=(CheckOrderISN)p_BE;				
				CheckOrderISNCtl control=new CheckOrderISNCtl(sqlTrans);				
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
				CheckOrderISN entity=(CheckOrderISN)p_BE;				
				CheckOrderISNCtl control=new CheckOrderISNCtl(sqlTrans);
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


        #region 获取ID
        /// <summary>
        /// 得到条码号
        /// </summary>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        string GetDISN(IDBTransAccess sqlTrans)
        {
            string Str = string.Empty;
            string sql = "SELECT MAX(DISN) DISN FROM Chk_CheckOrderISN WHERE DISN LIKE " + SysString.ToDBString(DateTime.Now.ToString("yyyyMMdd") + "____");
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["DISN"].ToString() == string.Empty)
                {
                    return DateTime.Now.ToString("yyyyMMdd") + "0001";
                }
                else
                {
                    Str = dt.Rows[0]["DISN"].ToString();
                    Str = Str.Substring(8, 4);
                    return DateTime.Now.ToString("yyyyMMdd") + SysString.LongToStr(SysConvert.ToInt32(Str) + 1, 4);
                }
            }
            else
            {
                return DateTime.Now.ToString("yyyyMMdd") + "0001";
            }
            return Str;
        }

        public int GetMaxSeq(int p_ID, string JarNum, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT MAX(Seq) Seq FROM Chk_CheckOrderISN WHERE JarNum=" + SysString.ToDBString(JarNum);
            sql += " AND MainID=" + p_ID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["Seq"]) + 1;
            }
            else
            {
                return 1;
            }
        }
        #endregion
    }
}
