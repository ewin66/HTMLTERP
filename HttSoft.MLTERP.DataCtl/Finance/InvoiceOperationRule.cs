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
	/// 目的：Finance_InvoiceOperation实体业务规则类
	/// 作者:刘德苏
	/// 创建日期:2012/5/8
	/// </summary>
	public class InvoiceOperationRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public InvoiceOperationRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			InvoiceOperation entity=(InvoiceOperation)p_BE;
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
            InvoiceOperation entity = (InvoiceOperation)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, "Finance_InvoiceOperation", SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_InvoiceOperationDts WHERE 1=1";
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
        public DataTable RShowPay(string p_condition)
        {
            try
            {
                return RShowPay(p_condition, "*");
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
        public DataTable RShowPay(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_InvoiceOperation WHERE 1=1";
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



        #region 核销处理
        /// <summary>
        /// 核销处理
        /// </summary>
        public void RHX(InvoiceOperation entity, InvoiceOperationDts entityDts)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHX(entity, entityDts, sqlTrans);

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
        /// 核销处理
        /// </summary>
        public void RHX(InvoiceOperation entity, InvoiceOperationDts entityDts, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                //First 处理发票主表数据
                InvoiceOperation entityinvoice = new InvoiceOperation(sqlTrans);//处理收付款主表数据
                entityinvoice.ID = entity.ID;
                entityinvoice.SelectByID();

                if (entityinvoice.PreHXAmount + entityDts.DInvoiceAmount > entityinvoice.TotalAmount)
                {
                    throw new Exception("不能操作，核销金额超过了开票未核金额");
                }
                if (entityinvoice.PreHXQty + entityDts.DInvoiceQty > entityinvoice.TotalQty)
                {
                    throw new Exception("不能操作，核销数量超过了开票未核数量");
                }
                if (entityinvoice.PreHXAmount + entityDts.DInvoiceAmount == entityinvoice.TotalAmount)
                {
                    entityinvoice.PreHXFlag = (int)YesOrNo.Yes;
                }
                entityinvoice.PreHXQty += entityDts.DInvoiceQty;
                entityinvoice.PreHXAmount += entityDts.DInvoiceAmount;
                this.RUpdate(entityinvoice, sqlTrans);


                //Second

                IOFormDtsRule ioformdtsRule = new IOFormDtsRule();//处理出入库单据明细数据
                IOFormDts entityIOF = new IOFormDts(sqlTrans);//出入库单据明细
                entityIOF.ID = entityDts.DLOADDtsID;
                entityIOF.SelectByID();

                if (entityIOF.DtsInvoiceDelFlag == (int)YesOrNo.Yes)
                {
                    throw new Exception("不能操作，数据已开票结束 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                }
                if (entityDts.DInvoiceQty + entityIOF.InvoiceQty > entityIOF.DZQty || entityDts.DInvoiceAmount + entityIOF.InvoiceAmount > entityIOF.DZAmount)//开票溢出
                {
                    throw new Exception("不能操作，开票数超过对账数 或 开票金额超过对账金额 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                }

                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                sql += ",DtsInvoiceDelTime=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                sql += ",DtsInvoiceNo=" + SysString.ToDBString(entity.InvoiceNO);
                if (entityDts.DInvoiceAmount + entityIOF.InvoiceAmount >= entityIOF.DZAmount)//开票完成
                {
                    sql += ",DtsInvoiceDelFlag=1";
                }
                else
                {
                    sql += ",DtsInvoiceDelFlag=0";
                }
                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                sqlTrans.ExecuteNonQuery(sql);


                InvoiceOperationDtsRule dtsRule = new InvoiceOperationDtsRule();
                entityDts.MainID = entity.ID;
                entityDts.Seq = SysConvert.ToInt32(sqlTrans.Fill("SELECT ISNULL(MAX(Seq),0)+1 FROM Finance_InvoiceOperationDts WHERE MainID="+entity.ID).Rows[0][0]);//取最大的MAXSEQ值

                dtsRule.RAdd(entityDts, sqlTrans);

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

        #region 撤销核销处理
        /// <summary>
        /// 撤销核销处理
        /// </summary>
        public void RHXCancel(InvoiceOperation entity, int p_DtsID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHXCancel(entity, p_DtsID, sqlTrans);
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
        /// 撤销核销处理
        /// </summary>
        public void RHXCancel(InvoiceOperation entity, int p_DtsID, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = string.Empty;
                //First 处理发票主表数据
                InvoiceOperation entityinvoice = new InvoiceOperation(sqlTrans);//处理收付款主表数据
                entityinvoice.ID = entity.ID;
                entityinvoice.SelectByID();


                //Second 删除发票核销明细数据
                InvoiceOperationDtsRule dtsRule = new InvoiceOperationDtsRule();
                InvoiceOperationDts entityDts = new InvoiceOperationDts(sqlTrans);
                entityDts.ID = p_DtsID;
                entityDts.SelectByID();
                if (entityDts.PayAmount != 0)
                {
                    throw new Exception("不能操作，数据有收付款数据了，不能进行撤销");
                }

                dtsRule.RDelete(entityDts, sqlTrans);//删除明细实体


                //First 处理发票主表数据
                entityinvoice.PreHXFlag = (int)YesOrNo.No;
                entityinvoice.PreHXQty -= entityDts.DInvoiceQty;
                entityinvoice.PreHXAmount -= entityDts.DInvoiceAmount;
                this.RUpdate(entityinvoice, sqlTrans);



                IOFormDtsRule ioformdtsRule = new IOFormDtsRule();//处理出入库单据明细数据
                IOFormDts entityIOF = new IOFormDts(sqlTrans);//出入库单据明细
                entityIOF.ID = entityDts.DLOADDtsID;
                entityIOF.SelectByID();
                //处理发票明细数据;出入库明细数据
                if (entityIOF.PayAmount != 0)
                {
                    throw new Exception("不能操作，数据已有收付款数据 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                }

                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                sql += ",DtsInvoiceDelTime=null";
                sql += ",DtsInvoiceNo=''";
                sql += ",DtsInvoiceDelFlag=0";//开票完成标志
                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
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
        #endregion
        
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
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave((InvoiceOperation)p_BE, p_BE2, sqlTrans);//保存从表


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
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave((InvoiceOperation)p_BE, p_BE2, sqlTrans);//保存从表
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

        #region  主从表保存方法2
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2,p_BE3, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave2((InvoiceOperation)p_BE, p_BE2,p_BE3, sqlTrans);//保存从表


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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2,p_BE3, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave2((InvoiceOperation)p_BE, p_BE2, p_BE3, sqlTrans);//保存从表
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
				InvoiceOperation entity=(InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("单号已存在，请重新生成");
                }
                if (entity.InvoiceNO != "")
                {
                    sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("发票号已存在，请重新输入");
                    }
                }

				InvoiceOperationCtl control=new InvoiceOperationCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Finance_InvoiceOperation,sqlTrans);
				control.AddNew(entity);

                FormNoControlRule rulest = new FormNoControlRule();
                if (entity.DZTypeID == 3)
                {
                    rulest.RAddSort((int)FormNoControlEnum.发票单号, sqlTrans);
                }
                else
                {
                    rulest.RAddSort((int)FormNoControlEnum.发票单号2, sqlTrans);
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
				InvoiceOperation entity=(InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                sql += " AND ID<>"+entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("单号已存在，异常操作，请联系管理员检查");
                }

                //sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                //sql += " AND ID<>" + entity.ID;
                //dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count > 0)
                //{
                //    throw new BaseException("发票号已存在，请重新输入");
                //}

				InvoiceOperationCtl control=new InvoiceOperationCtl(sqlTrans);				
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
				InvoiceOperation entity=(InvoiceOperation)p_BE;				
				InvoiceOperationCtl control=new InvoiceOperationCtl(sqlTrans);
				
				
                string sql = "DELETE FROM Finance_InvoiceOperationDts WHERE MainID=" + entity.ID.ToString();
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
                InvoiceOperation entity = new InvoiceOperation(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }

                //更新状态
                sql = "UPDATE  Finance_InvoiceOperation SET SubmitFlag=" + SysString.ToDBString(p_Type);
                sql += " WHERE ID="+SysString.ToDBString(p_FormID);
                sqlTrans.ExecuteNonQuery(sql);

                
                SetInvoiceOperation(p_FormID, p_Type, sqlTrans);//提交操作
                //switch (p_Type)
                //{
                //    case 1://提交
                //        break;
                //    case 0://撤销提交
                //        SetCancelInvoiceOperation(p_FormID, p_Type, sqlTrans);
                //        break;

                //}







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
        /// 提交
        /// </summary>
        /// <param name="p_FormID"></param>
        /// <param name="p_Type"></param>
        /// <param name="sqlTrans"></param>
        private void SetInvoiceOperation(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,MainID,Seq FROM Finance_InvoiceOperationDts WHERE MainID=" + SysString.ToDBString(p_FormID);
            sql += " ORDER BY Seq";
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    //对账单
                    InvoiceOperation entity = new InvoiceOperation(sqlTrans);
                    entity.ID = p_FormID;
                    entity.SelectByID();

                    ///对账单明细
                    InvoiceOperationDts entityDts = new InvoiceOperationDts(sqlTrans);
                    entityDts.ID = SysConvert.ToInt32(dr["ID"]);
                    entityDts.SelectByID();
                    
                    ///仓库单据明细
                    IOFormDts entityIOF = new IOFormDts(sqlTrans);
                    if (entityDts.MergeFlage == 1)
                    {
                        if (entityDts.DLOADID > 0)
                        {
                            IOForm entityNoDts = new IOForm(sqlTrans);
                            entityNoDts.ID = entityDts.DLOADID;
                            entityNoDts.SelectByID();
                            if (entityNoDts.SelectByID())
                            {
                            }
                            else
                            {
                                throw new Exception("操作异常，没有找到出入库记录 ID:" + entityDts.DLOADID);
                            }
                            if (p_Type == (int)YesOrNo.Yes)//提交
                            {

                                //if (entityDts.DInvoiceQty + entityIOF.InvoiceQty > entityIOF.DZQty || entityDts.DInvoiceAmount + entityIOF.InvoiceAmount > entityIOF.DZAmount)//开票溢出
                                //{
                                //    throw new Exception("不能操作，开票数超过对账数 或 开票金额超过对账金额 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                //}
                                if (entityNoDts.InvoiceDelFlag == (int)YesOrNo.Yes && entityNoDts.TotalQty == entityNoDts.InvoiceQty)
                                {
                                    throw new Exception("不能操作，数据已开票结束 ID:" + entityDts.DLOADID);
                                    //+ " " + SysConvert.ToString(drs["ItemCode"]) + " " + SysConvert.ToString(drs["ColorNum"])
                                }
                                sql = "UPDATE WH_IOForm SET InvoiceQty=ISNULL(InvoiceQty,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)+" + "(" + SysString.ToDBString(SysConvert.ToDecimal(entityDts.DInvoiceAmount)) + ")";
                                sql += ",InvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",InvoiceDelTime=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                                sql += ",InvoiceNo=" + SysString.ToDBString(entity.InvoiceNO);
                                if (entityDts.DInvoiceAmount +  entityNoDts.InvoiceAmount >= entityNoDts.DZAmount)//开票完成
                                {
                                    sql += ",InvoiceDelFlag=1";
                                }
                                else
                                {
                                    sql += ",InvoiceDelFlag=0";
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityNoDts.ID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else//撤销提交
                            {


                                if (entityNoDts.PayAmount != 0)
                                {
                                    throw new Exception("不能操作，数据已有收付款数据 ID:" + entityDts.DLOADID);
                                }
                                sql = "UPDATE WH_IOForm SET InvoiceQty=ISNULL(InvoiceQty,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                                sql += ",InvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",InvoiceDelTime=null";
                                sql += ",InvoiceNo=''";
                                if (entityNoDts.InvoiceQty == entityDts.DInvoiceQty)
                                {
                                    sql += ",InvoiceDelFlag=0";//开票完成标志
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityNoDts.ID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }

                            }
                        }
                        else
                        {

                            if (p_Type == (int)YesOrNo.Yes)//提交
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }

                        }
                    }
                    else
                    {
                        entityIOF.ID = entityDts.DLOADDtsID;
                        if (entityDts.DLOADDtsID > 0)
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
                                if (entityIOF.DtsInvoiceDelFlag == (int)YesOrNo.Yes && entityIOF.Qty == entityIOF.InvoiceQty)
                                {
                                    throw new Exception("不能操作，数据已开票结束 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                }
                                //if (entityDts.DInvoiceQty + entityIOF.InvoiceQty > entityIOF.DZQty || entityDts.DInvoiceAmount + entityIOF.InvoiceAmount > entityIOF.DZAmount)//开票溢出
                                //{
                                //    throw new Exception("不能操作，开票数超过对账数 或 开票金额超过对账金额 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                //}

                                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",DtsInvoiceDelTime=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                                sql += ",DtsInvoiceNo=" + SysString.ToDBString(entity.InvoiceNO);
                                if (entityDts.DInvoiceAmount + entityIOF.InvoiceAmount >= entityIOF.DZAmount)//开票完成
                                {
                                    sql += ",DtsInvoiceDelFlag=1";
                                }
                                else
                                {
                                    sql += ",DtsInvoiceDelFlag=0";
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else//撤销提交
                            {
                                if (entityIOF.PayAmount != 0)
                                {
                                    throw new Exception("不能操作，数据已有收付款数据 ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                }

                                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",DtsInvoiceDelTime=null";
                                sql += ",DtsInvoiceNo=''";
                                if (entityIOF.InvoiceQty == entityDts.DInvoiceQty)
                                {
                                    sql += ",DtsInvoiceDelFlag=0";//开票完成标志
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                        }
                        else
                        {

                            if (p_Type == (int)YesOrNo.Yes)//提交
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }

                        }
                    }
                }
            }
        }
        #endregion

        #region 
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd2(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd2(p_BE,p_BE2, sqlTrans);

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
        public void RAdd2(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                InvoiceOperation entity = (InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("单号已存在，请重新生成");
                }

                if (entity.InvoiceNO != "")
                {
                    sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("发票号已存在，请重新输入");
                    }
                }

                InvoiceOperationCtl control = new InvoiceOperationCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Finance_InvoiceOperation, sqlTrans);
                control.AddNew(entity);

                for (int i = 0; i < p_BE2.Length; i++)
                {
                    InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
                    InvoiceYOperationDts entityDts = (InvoiceYOperationDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
                }

                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.发票单号, sqlTrans);
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
        public void RUpdate2(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate2(p_BE,p_BE2, sqlTrans);

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
        public void RUpdate2(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                InvoiceOperation entity = (InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                sql += " AND ID<>" + entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("单号已存在，异常操作，请联系管理员检查");
                }

                if (entity.InvoiceNO != "")
                {
                    sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                    sql += " AND ID<>" + entity.ID;
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("发票号已存在，请重新输入");
                    }
                }

                

                InvoiceOperationCtl control = new InvoiceOperationCtl(sqlTrans);
                control.Update(entity);

                sql = "DELETE Finance_InvoiceYOperationDts WHERE MainID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
                    InvoiceYOperationDts entityDts = (InvoiceYOperationDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
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
