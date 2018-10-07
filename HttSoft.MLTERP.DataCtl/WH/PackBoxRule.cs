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
	/// 目的：WH_PackBox实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2012-5-7
	/// </summary>
	public class PackBoxRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public PackBoxRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			PackBox entity=(PackBox)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_PackBox WHERE 1=1";
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
        public DataTable RUShow(string p_condition)
        {
            try
            {
                return RUShow(p_condition, "*");
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
        public DataTable RUShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_PackBox WHERE 1=1";
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
        #region 自定义方法
        /// <summary>
        /// 校验删除功能(传入事务处理)
        /// </summary>
        /// <param name="p_BoxNo">箱号</param>
        /// <param name="sqlTrans"></param>
        public void RCheckDelete(string p_BoxNo, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                if (p_BoxNo != string.Empty)
                {
                    return;
                }
                sql = "SELECT BoxStatusID FROM WH_PackBox WHERE BoxNo="+SysString.ToDBString(p_BoxNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.未入库)
                    {
                        throw new Exception("条码" + p_BoxNo + "状态处于未入库状态，不能删除");
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
        /// 校验更新功能(传入事务处理)
        /// </summary>
        /// <param name="p_BoxNo">箱号</param>
        /// <param name="sqlTrans"></param>
        public void RCheckUpdate(string p_BoxNo, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                if (p_BoxNo != string.Empty)
                {
                    return;
                }
                sql = "SELECT BoxStatusID,KPFlag FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_BoxNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.未入库)
                    {
                        throw new Exception("条码" + p_BoxNo + "状态处于未入库状态，不能更新");
                    }
                    if (SysConvert.ToInt32(dt.Rows[0]["KPFlag"]) == (int)YesOrNo.Yes)
                    {
                        throw new Exception("条码" + p_BoxNo + "状态处于已经被开匹状态，不能更新");
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
        /// 根据获得实体箱号
        /// </summary>
        /// <param name="p_BoxNo">箱号</param>
        /// <returns>返回箱号实体</returns>
        public PackBox RGetEntityByBoxNo(string p_BoxNo, IDBTransAccess sqlTrans)
        {
            PackBox entity = new PackBox(sqlTrans);
            string sql = "SELECT ID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_BoxNo);//寻找ID
            DataTable dt = sqlTrans.Fill(sql);

            if (dt.Rows.Count != 0)
            {
                entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                entity.SelectByID();
            }
            return entity;
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
				PackBox entity=(PackBox)p_BE;				
				PackBoxCtl control=new PackBoxCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WH_PackBox,sqlTrans);
                if (entity.BoxNo == string.Empty)//条码号不存在
                {
                    entity.CreateTime = DateTime.Now;

                    FormNoControlRule rulest = new FormNoControlRule();

                    //处理生成箱号
                    entity.BoxNo = rulest.RGetFormNo((int)FormNoControlEnum.码单箱号, sqlTrans);
                    rulest.RAddSort((int)FormNoControlEnum.码单箱号, sqlTrans);
                }
                else//已存在
                {
                    string sql = "SELECT BoxNo FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(entity.BoxNo);
                    if (sqlTrans.Fill(sql).Rows.Count != 0)//条码号已存在，则生成新条码
                    {
                        entity.CreateTime = DateTime.Now;

                        FormNoControlRule rulest = new FormNoControlRule();

                        //处理生成箱号
                        entity.BoxNo = rulest.RGetFormNo((int)FormNoControlEnum.码单箱号, sqlTrans);
                        rulest.RAddSort((int)FormNoControlEnum.码单箱号, sqlTrans);
                    }
                }

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
				PackBox entity=(PackBox)p_BE;				
				PackBoxCtl control=new PackBoxCtl(sqlTrans);				
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
				PackBox entity=(PackBox)p_BE;				
				PackBoxCtl control=new PackBoxCtl(sqlTrans);
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
