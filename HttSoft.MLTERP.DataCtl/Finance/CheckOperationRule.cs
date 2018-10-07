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
	/// 目的：Finance_CheckOperation实体业务规则类
	/// 作者:刘德苏
	/// 创建日期:2012/5/8
	/// </summary>
	public class CheckOperationRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public CheckOperationRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOperation entity=(CheckOperation)p_BE;
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
            CheckOperation entity = (CheckOperation)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, CheckOperation.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_CheckOperation WHERE 1=1";
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
        public DataTable RShowDts(string p_condition)
        {
            try
            {
                return RShowDts(p_condition, "*");
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_CheckOperationDts WHERE 1=1";
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
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, sqlTrans);//保存从表


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
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, sqlTrans);//保存从表
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
				CheckOperation entity=(CheckOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_CheckOperation WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("对账单号已存在，请重新生成");
                }
				CheckOperationCtl control=new CheckOperationCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Finance_CheckOperation, sqlTrans);
				control.AddNew(entity);

                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.对账单号,sqlTrans);
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
				CheckOperation entity=(CheckOperation)p_BE;				
				CheckOperationCtl control=new CheckOperationCtl(sqlTrans);				
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
				CheckOperation entity=(CheckOperation)p_BE;				
				CheckOperationCtl control=new CheckOperationCtl(sqlTrans);
				
				
                string sql = "DELETE FROM Finance_CheckOperationDts WHERE MainID=" + entity.ID.ToString();
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
                CheckOperation entity = new CheckOperation(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }

                //更新状态
                sql = "UPDATE  Finance_CheckOperation SET SubmitFlag=" + SysString.ToDBString(p_Type) + " WHERE ID=" + p_FormID;
                sqlTrans.ExecuteNonQuery(sql);

                if (entity.MergeFlage == 1)
                {
                    SetCheckOperationTotal(p_FormID, p_Type, sqlTrans);
                }
                else
                {
                    SetCheckOperation(p_FormID, p_Type, sqlTrans);//回填数据处理
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
        /// 处理对账回填数据
        /// </summary>
        /// <param name="p_FormID"></param>
        /// <param name="p_Type"></param>
        /// <param name="sqlTrans"></param>
        private void SetCheckOperation(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,MainID,Seq FROM Finance_CheckOperationDts WHERE MainID=" + SysString.ToDBString(p_FormID);
            sql += " ORDER BY Seq";
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {

                    //对账单
                    CheckOperation entity = new CheckOperation();
                    entity.ID = p_FormID;

                    ///对账单明细
                    CheckOperationDts entityDts = new CheckOperationDts();
                    entityDts.ID = SysConvert.ToInt32(dr["ID"]);
                    entityDts.SelectByID();

                    ///仓库单据明细
                    IOFormDts entityIOF = new IOFormDts(sqlTrans);
                    entityIOF.ID = entityDts.DLOADDtsID;
                    if (entityDts.DLOADDtsID > 0) ///回填仓库出入库数据
                    {
                        if (entityIOF.SelectByID())
                        {
                        }
                        else
                        {
                            throw new Exception("操作异常，没有找到出入库记录 ID:" + entityDts.DLOADDtsID);
                        }
                        if (p_Type == (int)YesOrNo.Yes)//提交
                        {
                            //if (entityIOF.DZFlag == (int)YesOrNo.Yes && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("不能操作，数据已对账 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            ///回填数据到出库明细表中：对账数量、对账金额、对账单价、对账标志、对账单、对账日期、对账单号                            
                            sql = "UPDATE WH_IOFormDts SET DZQty=ISNULL(DZQty,0)+(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)+(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=" + SysString.ToDBString(entityDts.DCheckSinglePrice);
                            sql += ",DZFlag=1";
                            sql += ",DZOPID=" + SysString.ToDBString(entity.SaleOPID);
                            sql += ",DZTime=GetDate()";
                            sql += ",DZNo=" + SysString.ToDBString(entity.FormNo);
                            sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else//撤销提交
                        {
                            //if (entityIOF.InvoiceQty != 0 && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("不能操作，数据已有开票数据 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            sql = "UPDATE WH_IOFormDts SET DZQty=ISNULL(DZQty,0)-(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)-(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=NULL";
                            if (entityIOF.DZQty == entityDts.DCheckQty)
                            {
                                sql += ",DZFlag=0";
                            }
                            sql += ",DZOPID=''";
                            sql += ",DZTime=NULL";
                            sql += ",DZNo=''";
                            sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 处理对账回填数据
        /// </summary>
        /// <param name="p_FormID"></param>
        /// <param name="p_Type"></param>
        /// <param name="sqlTrans"></param>
        private void SetCheckOperationTotal(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,MainID,Seq FROM Finance_CheckOperationDts WHERE MainID=" + SysString.ToDBString(p_FormID);
            sql += " ORDER BY Seq";
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {

                    //对账单
                    CheckOperation entity = new CheckOperation();
                    entity.ID = p_FormID;

                    ///对账单明细
                    CheckOperationDts entityDts = new CheckOperationDts();
                    entityDts.ID = SysConvert.ToInt32(dr["ID"]);
                    entityDts.SelectByID();

                    ///仓库单据明细
                    IOForm entityIOF = new IOForm(sqlTrans);
                    entityIOF.ID = entityDts.DLOADID;
                    entityIOF.SelectByID();
                    if (entityDts.DLOADID > 0) ///回填仓库出入库数据
                    {
                        if (entityIOF.SelectByID())
                        {
                        }
                        else
                        {
                            throw new Exception("操作异常，没有找到出入库记录 ID:" + entityDts.DLOADID);
                        }
                        if (p_Type == (int)YesOrNo.Yes)//提交
                        {
                            //if (entityIOF.DZFlag == (int)YesOrNo.Yes && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("不能操作，数据已对账 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            ///回填数据到出库明细表中：对账数量、对账金额、对账单价、对账标志、对账单、对账日期、对账单号               
                            ///
                            sql = "UPDATE WH_IOForm SET DZQty=ISNULL(DZQty,0)+(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)+(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=" + SysString.ToDBString(entityDts.DCheckSinglePrice);
                            sql += ",DZFlag=1";
                            sql += ",DZOPID=" + SysString.ToDBString(entity.SaleOPID);
                            sql += ",DZTime=GetDate()";
                            sql += ",DZNo=" + SysString.ToDBString(entity.FormNo);
                            sql += " WHERE ID=" + SysString.ToDBString(entityIOF.ID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else//撤销提交
                        {
                            //if (entityIOF.InvoiceQty != 0 && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("不能操作，数据已有开票数据 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            sql = "UPDATE WH_IOForm SET DZQty=ISNULL(DZQty,0)-(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)-(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=NULL";
                            if (entityIOF.DZQty == entityDts.DCheckQty)
                            {
                                sql += ",DZFlag=0";
                            }
                            sql += ",DZOPID=''";
                            sql += ",DZTime=NULL";
                            sql += ",DZNo=''";
                            sql += " WHERE ID=" + SysString.ToDBString(entityIOF.ID);
                            sqlTrans.ExecuteNonQuery(sql);

                        }

                    }
                }
            }
        }
        
    
    
        #endregion

        #region  主从表保存方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3,BaseEntity[] p_BE4)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, p_BE3, p_BE4,sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3,BaseEntity[] p_BE4,IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, p_BE3, p_BE4,sqlTrans);//保存从表


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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2,p_BE3,p_BE4, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3,BaseEntity[] p_BE4, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, p_BE3, p_BE4,sqlTrans);//保存从表
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
