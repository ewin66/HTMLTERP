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
	/// 目的：Finance_RecPay实体业务规则类
	/// 作者:周富春
	/// 创建日期:2012-5-22
	/// </summary>
	public class RecPayRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public RecPayRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			RecPay entity=(RecPay)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_RecPay WHERE 1=1";
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


        #region 根据销售合同返回关联信息
        #endregion



        #region 根据采购合同返回关联信息
        #endregion

        #region 核销处理
        /// <summary>
        /// 核销处理
        /// </summary>
        public void RHX(RecPay entity,int p_InvoiceID,decimal p_HXAmount)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHX(entity, p_InvoiceID, p_HXAmount, sqlTrans);

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
        public void RHX(RecPay entity, int p_InvoiceID, decimal p_HXAmount, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                //First 处理收付款主表数据
                RecPay entitypay=new RecPay(sqlTrans);//处理收付款主表数据
                entitypay.ID=entity.ID;
                entitypay.SelectByID();

                if (entitypay.HXAmount + p_HXAmount > entitypay.ExAmount)
                {
                    throw new Exception("不能操作，核销金额超过了付款未核金额");
                }
                if (entitypay.HXAmount + p_HXAmount == entitypay.ExAmount)
                {
                    entitypay.HXFlag = (int)YesOrNo.Yes;
                }
                entitypay.HXAmount += p_HXAmount;
                entitypay.NoHXAmount = entitypay.ExAmount - entitypay.HXAmount;
                this.RUpdate(entitypay, sqlTrans);


                //Second
                InvoiceOperationRule invoicerule = new InvoiceOperationRule();//处理发票主表数据
                InvoiceOperation invoiceentity=new InvoiceOperation(sqlTrans);//发票实体
                invoiceentity.ID=p_InvoiceID;
                invoiceentity.SelectByID();
                if (invoiceentity.PayAmount + p_HXAmount > invoiceentity.TotalAmount)
                {
                    throw new Exception("不能操作，核销金额超过了发票未核金额");
                }
                invoiceentity.PayAmount += p_HXAmount;
                invoicerule.RUpdate(invoiceentity, sqlTrans);
                
                

                //Third 增加付款核销明细数据
                RecPayHXDtsRule dtsRule = new RecPayHXDtsRule();
                RecPayHXDts dtsentity = new RecPayHXDts(sqlTrans);
                dtsentity.MainID = entity.ID;
                dtsentity.HXOPID = entity.MakeOPID;
                dtsentity.HXOPName = entity.MakeOPName;
                dtsentity.HXDate = DateTime.Now;
                dtsentity.HXAmount = p_HXAmount;
                dtsentity.InvoiceNo = invoiceentity.InvoiceNO;
                dtsentity.InvoiceOperationID = p_InvoiceID;
                dtsRule.RAdd(dtsentity, sqlTrans);//增加明细实体
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
        public void RHXCancel(RecPay entity, int p_DtsID)
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
        public void RHXCancel(RecPay entity, int p_DtsID, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = string.Empty;
                //First 处理收付款主表数据
                RecPay entitypay = new RecPay(sqlTrans);//处理收付款主表数据
                entitypay.ID = entity.ID;
                entitypay.SelectByID();

                //Second 删除付款核销明细数据
                RecPayHXDtsRule dtsRule = new RecPayHXDtsRule();
                RecPayHXDts dtsentity = new RecPayHXDts(sqlTrans);
                dtsentity.ID = p_DtsID;
                dtsentity.SelectByID();
                dtsRule.RDelete(dtsentity, sqlTrans);//删除明细实体


                //First 处理收付款主表数据
                entitypay.HXFlag = (int)YesOrNo.No;
                entitypay.HXAmount -= dtsentity.HXAmount;
                entitypay.NoHXAmount = entitypay.ExAmount - entitypay.HXAmount;
                this.RUpdate(entitypay, sqlTrans);


                //Third 处理发票主表数据
                InvoiceOperationRule invoicerule = new InvoiceOperationRule();//处理发票主表数据
                InvoiceOperation invoiceentity = new InvoiceOperation(sqlTrans);//发票实体
                invoiceentity.ID = dtsentity.InvoiceOperationID;
                invoiceentity.SelectByID();

                invoiceentity.PayAmount -= dtsentity.HXAmount;
                if (invoiceentity.PayAmount < 0)
                {
                    throw new BaseException("撤销后数据有误，请检查，发票的核销金额小于0");
                }
                invoicerule.RUpdate(invoiceentity, sqlTrans);

               
              


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


        #region 合同关联处理
        ///// <summary>
        ///// 合同关联处理
        ///// </summary>
        //public void RHT(RecPay entity, string p_HTNo, decimal p_HTAmount, int p_HTTypeID)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            this.RHT(entity, p_HTNo, p_HTAmount, p_HTTypeID, sqlTrans);

        //            sqlTrans.CommitTrans();
        //        }
        //        catch (Exception TE)
        //        {
        //            sqlTrans.RollbackTrans();
        //            throw TE;
        //        }
        //    }
        //    catch (BaseException)
        //    {
        //        throw;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new BaseException(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 合同关联处理
        ///// </summary>
        //public void RHT(RecPay entity, string p_HTNo, decimal p_HTAmount,int p_HTTypeID, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        string sql = string.Empty;
        //        //First 处理收付款主表数据
        //        RecPay entitypay = new RecPay(sqlTrans);//处理收付款主表数据
        //        entitypay.ID = entity.ID;
        //        entitypay.SelectByID();

        //        if (entitypay.HTAmount + p_HTAmount > entitypay.ExAmount)
        //        {
        //            throw new Exception("不能操作，关联合同金额超过了付款金额");
        //        }
        //        if (entitypay.HTAmount + p_HTAmount == entitypay.ExAmount)
        //        {
        //            entitypay.HTFlag = (int)YesOrNo.Yes;
        //        }
        //        entitypay.HTAmount += p_HTAmount;
        //        if (entitypay.HTNo == string.Empty || entitypay.HTNo.IndexOf(" "+p_HTNo) == -1)
        //        {
        //            if (entitypay.HTNo != string.Empty)//多合同关联
        //            {
        //                entitypay.HTNo += " ";
        //            }
        //            entitypay.HTNo += p_HTNo;
        //        }
        //        this.RUpdate(entitypay, sqlTrans);



        //        //Second 增加付款合同明细数据
        //        RecPayHTDtsRule dtsRule = new RecPayHTDtsRule();
        //        RecPayHTDts dtsentity = new RecPayHTDts(sqlTrans);
        //        dtsentity.MainID = entity.ID;
        //        dtsentity.HTOPID = entity.MakeOPID;
        //        dtsentity.HTOPName = entity.MakeOPName;
        //        dtsentity.HTDate = DateTime.Now;
        //        dtsentity.HTAmount = p_HTAmount;
        //        dtsentity.HTNo = p_HTNo;
        //        dtsentity.HTTypeID = p_HTTypeID;
        //        dtsRule.RAdd(dtsentity, sqlTrans);//增加明细实体

              
        //    }
        //    catch (BaseException)
        //    {
        //        throw;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new BaseException(E.Message);
        //    }
        //}



        #endregion

        #region 合同关联处理-包含ItemCode
        /// <summary>
        /// 合同关联处理
        /// </summary>
        public void RHT(RecPay entity, string p_HTNo,string p_HTItemCode,string p_HTGoodsCode, decimal p_HTAmount, int p_HTTypeID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHT(entity, p_HTNo,p_HTItemCode,p_HTGoodsCode, p_HTAmount, p_HTTypeID, sqlTrans);

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
        /// 合同关联处理
        /// </summary>
        public void RHT(RecPay entity, string p_HTNo,string p_HTItemCode,string p_HTGoodsCode, decimal p_HTAmount, int p_HTTypeID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                //First 处理收付款主表数据
                RecPay entitypay = new RecPay(sqlTrans);//处理收付款主表数据
                entitypay.ID = entity.ID;
                entitypay.SelectByID();

                if (entitypay.HTAmount + p_HTAmount > entitypay.ExAmount)
                {
                    throw new Exception("不能操作，关联合同金额超过了收付款金额");
                }
                if (entitypay.HTAmount + p_HTAmount == entitypay.ExAmount)
                {
                    entitypay.HTFlag = (int)YesOrNo.Yes;
                }
                entitypay.HTAmount += p_HTAmount;
                if (entitypay.HTNo == string.Empty || entitypay.HTNo.IndexOf(" " + p_HTNo) == -1)
                {
                    if (entitypay.HTNo != string.Empty)//多合同关联
                    {
                        entitypay.HTNo += " ";
                    }
                    entitypay.HTNo += p_HTNo;
                }
                if (entitypay.HTGoodsCode == string.Empty || entitypay.HTGoodsCode.IndexOf(" " + p_HTGoodsCode) == -1)
                {
                    if (entitypay.HTGoodsCode != string.Empty)//多合同关联
                    {
                        entitypay.HTGoodsCode += " ";
                    }
                    entitypay.HTGoodsCode += p_HTGoodsCode;
                }
                this.RUpdate(entitypay, sqlTrans);



                //Second 增加付款合同明细数据
                RecPayHTDtsRule dtsRule = new RecPayHTDtsRule();
                RecPayHTDts dtsentity = new RecPayHTDts(sqlTrans);
                dtsentity.MainID = entity.ID;
                dtsentity.HTOPID = entity.MakeOPID;
                dtsentity.HTOPName = entity.MakeOPName;
                dtsentity.HTDate = DateTime.Now;
                dtsentity.HTAmount = p_HTAmount;
                dtsentity.HTNo = p_HTNo;
                dtsentity.HTGoodsCode = p_HTGoodsCode;
                dtsentity.HTTypeID = p_HTTypeID;
                dtsentity.HTItemCode = p_HTItemCode;
                dtsRule.RAdd(dtsentity, sqlTrans);//增加明细实体

                //关联到采购单或者销售合同资金实际执行表
                if (p_HTTypeID == (int)EnumRecPayType.收款)
                {
                    SaleOrderCapExDtsRule capRule = new SaleOrderCapExDtsRule();
                    capRule.RHT(entitypay, dtsentity, sqlTrans);
                }
                else if (p_HTTypeID == (int)EnumRecPayType.付款)
                {
                    ItemBuyCapExDtsRule capRule = new ItemBuyCapExDtsRule();
                    capRule.RHT(entitypay,dtsentity, sqlTrans);
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

        #region 撤销合同关联处理
        /// <summary>
        /// 撤销合同关联处理
        /// </summary>
        public void RHTCancel(RecPay entity, int p_DtsID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHTCancel(entity, p_DtsID, sqlTrans);
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
        /// 撤销合同关联处理
        /// </summary>
        public void RHTCancel(RecPay entity, int p_DtsID, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = string.Empty;
                //First 处理收付款主表数据
                RecPay entitypay = new RecPay(sqlTrans);//处理收付款主表数据
                entitypay.ID = entity.ID;
                entitypay.SelectByID();

                //Second 删除付款核销明细数据
                RecPayHTDtsRule dtsRule = new RecPayHTDtsRule();
                RecPayHTDts dtsentity = new RecPayHTDts(sqlTrans);
                dtsentity.ID = p_DtsID;
                dtsentity.SelectByID();
                dtsRule.RDelete(dtsentity, sqlTrans);//删除明细实体


                //First 处理收付款主表数据
                entitypay.HTFlag = (int)YesOrNo.No;
                entitypay.HTAmount -= dtsentity.HTAmount;
                entitypay.HTNo=entitypay.HTNo.Replace(dtsentity.HTNo, "").Replace(" " + dtsentity.HTNo, "");//替换合同号
                if (entitypay.HTGoodsCode != "")
                {
                    entitypay.HTGoodsCode = entitypay.HTGoodsCode.Replace(dtsentity.HTGoodsCode, "").Replace(" " + dtsentity.HTGoodsCode, "");//替换商品码
                }
                this.RUpdate(entitypay, sqlTrans);

                //关联到采购单或者销售合同资金实际执行表
                if (dtsentity.HTTypeID == (int)EnumRecPayType.收款)
                {
                    SaleOrderCapExDtsRule capRule = new SaleOrderCapExDtsRule();
                    capRule.RHTCancel(dtsentity, sqlTrans);
                }
                else if (dtsentity.HTTypeID == (int)EnumRecPayType.付款)
                {
                    ItemBuyCapExDtsRule capRule = new ItemBuyCapExDtsRule();
                    capRule.RHTCancel(dtsentity, sqlTrans);
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
                RecPay entity = new RecPay(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }
                if (entity.HXAmount != 0)
                {
                    throw new Exception("核销金额有值,不允许操作");
                }

                if (entity.HTNo != string.Empty && entity.HTAmount!=0)
                {
                    throw new Exception("有关联合同,不允许操作");
                }

                //更新状态
                sql = "UPDATE Finance_RecPay SET SubmitFlag=" + SysString.ToDBString(p_Type) + " WHERE ID=" + p_FormID;
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
				RecPay entity=(RecPay)p_BE;
                string sql = "SELECT FormNo FROM Finance_RecPay WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("单号已存在，请重新生成");
                }
				RecPayCtl control=new RecPayCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Finance_RecPay,sqlTrans);
				control.AddNew(entity);
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.收付款单号,sqlTrans);
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
				RecPay entity=(RecPay)p_BE;				
				RecPayCtl control=new RecPayCtl(sqlTrans);				
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
				RecPay entity=(RecPay)p_BE;				
				RecPayCtl control=new RecPayCtl(sqlTrans);
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
                RecPayDtsRule ruledts = new RecPayDtsRule();
                ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//保存从表


                //RecPayHXDtsRule ruledts = new RecPayHXDtsRule();
                //ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//保存从表


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
                RecPayDtsRule ruledts = new RecPayDtsRule();
                ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//保存从表

                //RecPayHXDtsRule ruledts = new RecPayHXDtsRule();
                //ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//保存从表
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
