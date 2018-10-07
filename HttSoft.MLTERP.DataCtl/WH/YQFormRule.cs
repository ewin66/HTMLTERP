using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;
using HttSoft.FrameFunc;


namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// 目的：WH_YQForm实体业务规则类
	/// 作者:章文强
	/// 创建日期:2013/5/30
	/// </summary>
	public class YQFormRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public YQFormRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			YQForm entity=(YQForm)p_BE;
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
            YQForm entity = (YQForm)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, YQForm.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_YQFormDts WHERE 1=1";
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
				YQForm entity=(YQForm)p_BE;				
				YQFormCtl control=new YQFormCtl(sqlTrans);
                string sql = "SELECT FormNo FROM WH_YQForm WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("溢缺单号已存在，请双击单号重新生成");
                }
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WH_YQForm,sqlTrans);
				control.AddNew(entity);

                FormNoControlRule rule = new FormNoControlRule();
                rule.RAddSort((int)FormNoControlEnum.溢缺单号, sqlTrans);

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
				YQForm entity=(YQForm)p_BE;				
				YQFormCtl control=new YQFormCtl(sqlTrans);				
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
				YQForm entity=(YQForm)p_BE;				
				YQFormCtl control=new YQFormCtl(sqlTrans);
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
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList List)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd2(p_BE, p_BE2, List, sqlTrans);

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
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {
               

                YQForm entity = (YQForm)p_BE;

                this.RAdd(p_BE, sqlTrans);
                YQFormDtsRule ruledts = new YQFormDtsRule();
                ruledts.RSave((YQForm)p_BE, p_BE2, sqlTrans);//保存从表


                YQFormDtsPackRule dtsprule = new YQFormDtsPackRule();//保存码单明细
                dtsprule.RSave(entity, (YQFormDts[])p_BE2, list, sqlTrans);

               
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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, list, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {

              

                YQForm entity = (YQForm)p_BE;
                this.RUpdate(p_BE, sqlTrans);
                YQFormDtsRule ruledts = new YQFormDtsRule();
                ruledts.RSave((YQForm)p_BE, (YQFormDts[])p_BE2, sqlTrans);//保存从表

                //删除数据库中此单据类型的码单信息2011-07-12

                YQFormDtsPackRule dtsprule = new YQFormDtsPackRule();//保存码单明细
                dtsprule.RSave(entity, (YQFormDts[])p_BE2, list, sqlTrans);
               
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

        #region 提交处理
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1:弃审/审核</param>
        public void RSubmit(int p_FormID, int p_Type)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_FormID, p_Type, sqlTrans);
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
        /// 审核
        /// </summary>
        /// <param name="p_FormID">单据ID</param>
        /// <param name="p_Type">0/1/2/3:弃审/审核</param>
        public void RSubmit(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//处理状态
                string sql = string.Empty;
                YQForm entity = new YQForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();



                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }



                #region 提交
                sql = "UPDATE WH_YQForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                if (p_Type == (int)ConfirmFlag.审核通过 || p_Type == (int)ConfirmFlag.审核拒绝)
                {
                    sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                }
                sql += " WHERE ID=" + p_FormID.ToString();//更新单据主表审核状态
                sqlTrans.ExecuteNonQuery(sql);


                sql = "SELECT DLaodDtsID,MoveQty FROM WH_YQFormDts WHERE MainID=" + SysString.ToDBString(p_FormID);
                DataTable dt = sqlTrans.Fill(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int DLaodDtsID = SysConvert.ToInt32(dt.Rows[i][0]);
                    if (DLaodDtsID > 0)
                    {
                        if (p_Type == (int)ConfirmFlag.已提交)
                        {
                            sql = "UPDATE WH_IOFormDts SET YQQty=ISNULL(YQQty,0)+" + SysString.ToDBString(SysConvert.ToDecimal(dt.Rows[i]["MoveQty"]));
                            sql += " WHERE ID=" + SysString.ToDBString(DLaodDtsID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            sql = "UPDATE WH_IOFormDts SET YQQty=ISNULL(YQQty,0)-(" + SysString.ToDBString(SysConvert.ToDecimal(dt.Rows[i]["MoveQty"]))+")";
                            sql += " WHERE ID=" + SysString.ToDBString(DLaodDtsID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                    }
                }





                #endregion



                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
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
