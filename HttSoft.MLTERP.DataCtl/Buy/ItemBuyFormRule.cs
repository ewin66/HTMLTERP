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
	/// 目的：Buy_ItemBuyForm实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public class ItemBuyFormRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public ItemBuyFormRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ItemBuyForm entity=(ItemBuyForm)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Buy_ItemBuyForm WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Buy_ItemBuyFormDts WHERE 1=1";
                sql += p_condition;
                sql += " ORDER BY FormNo DESC ";
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
                ItemBuyForm entity = new ItemBuyForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }
                if (p_Type == (int)ConfirmFlag.未提交)//撤销提交验证
                {
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5609)))//采购单有仓库单据不允许修改
                    {
                        bool allowOPFlag = true;
                        string refuseMessage = string.Empty;
                        DataTable dtSOFlow;
                        if (allowOPFlag)
                        {
                            //仓库流程单据
                            sql = "SELECT TOP 1 ID,FormNo FROM UV1_WH_IOFormDts WHERE DtsSO=" + SysString.ToDBString(entity.FormNo);
                            dtSOFlow = SysUtils.Fill(sql);
                            if (dtSOFlow.Rows.Count != 0)
                            {
                                allowOPFlag = false;
                                refuseMessage = "此单已有仓库单据(单号):" + dtSOFlow.Rows[0]["FormNo"].ToString() + "，不允许撤销";
                            }
                        }

                        if (!allowOPFlag)//不允许操作
                        {
                            throw new Exception(refuseMessage);
                        }
                    }
                }


                sql = "UPDATE Buy_ItemBuyForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                //if (p_Type == (int)ConfirmFlag.审核通过 || p_Type == (int)ConfirmFlag.审核拒绝)
                //{
                    //sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                //}
                sql += " WHERE ID=" + p_FormID.ToString();//更新单据主表审核状态
                sqlTrans.ExecuteNonQuery(sql);

                int tempSaleProcedureID = 0;
                switch (entity.FormAID)//1/2/3/4/5：成品，坯布，纱线，色坯，辅料


                {
                    case 1:
                        tempSaleProcedureID = (int)EnumSaleProcedure.成品采购单;
                        break;
                    case 2:
                        tempSaleProcedureID = (int)EnumSaleProcedure.坯布采购单;
                        break;
                    case 3:
                        tempSaleProcedureID = (int)EnumSaleProcedure.纱线采购单;
                        break;
                    case 4:
                        tempSaleProcedureID = (int)EnumSaleProcedure.坯布采购单;
                        break;
                    case 5://辅料
                        tempSaleProcedureID = (int)EnumSaleProcedure.辅料采购单;
                        break;
                
                }
                if (p_Type == (int)YesOrNo.Yes)
                {
                    if (tempSaleProcedureID != (int)EnumSaleProcedure.坯布采购单)
                    {
                        sql = "SELECT DtsSO,ItemCode,ColorNum,ColorName FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                        DataTable dtDts = sqlTrans.Fill(sql);

                        SaleOrderRule salerule = new SaleOrderRule();
                        foreach (DataRow dr in dtDts.Rows)
                        {
                            salerule.RUpdateStep(dr["DtsSO"].ToString(), dr["ItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString(), tempSaleProcedureID, 0, 0, 0, p_Type, true, sqlTrans);
                        }
                    }
                    else  //坯布采购加载订单时候  将订单里的 ItemCode 加载到 CPItemCode
                    {
                        sql = "SELECT DtsSO,CPItemCode,ColorNum,ColorName FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                        DataTable dtDts = sqlTrans.Fill(sql);

                        SaleOrderRule salerule = new SaleOrderRule();
                        foreach (DataRow dr in dtDts.Rows)
                        {
                            salerule.RUpdateStep(dr["DtsSO"].ToString(), dr["CPItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString(), tempSaleProcedureID, 0, 0, 0, p_Type, true, sqlTrans);
                        }
                    }

                    
                }

                //#region 回填采购完成数
                //if (p_Type == (int)YesOrNo.Yes)//提交
                //{
                //    if (entity.MLType == (int)EnumMLType.纱线 || entity.MLType == (int)EnumMLType.白坯)
                //    {
                //        decimal TotalQty = 0m;
                //        sql = "SELECT  SUM(Qty) Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts = sqlTrans.Fill(sql);
                //        if (dtDts.Rows.Count != 0)
                //        {
                //            TotalQty = SysConvert.ToDecimal(dtDts.Rows[0]["Qty"]);
                //        }
                //        sql = "SELECT ID FROM Sale_SaleOrderDts WHERE MainID=(SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo) + ")";
                //        DataTable dtorder = sqlTrans.Fill(sql);//寻找原始订单
                //        if (dtorder.Rows.Count != 0)
                //        {
                //            while (TotalQty > 0m)//开始回填
                //            {
                //                for (int i = 0; i < dtorder.Rows.Count;i++ )
                //                {
                //                    SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                    orderentity.ID = SysConvert.ToInt32(dtorder.Rows[i]["ID"]);
                //                    bool findR=orderentity.SelectByID();
                //                    if (i == dtorder.Rows.Count - 1)
                //                    {
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.纱线:
                //                                orderentity.PSCGQty += TotalQty;
                //                                TotalQty = 0;
                //                                break;
                //                            case (int)EnumMLType.白坯:
                //                                orderentity.PBCGQty += TotalQty;
                //                                TotalQty = 0;
                //                                break;
                //                            default:
                //                                break;
                //                        }
                //                    }
                //                    else
                //                    {
                //                       // decimal HTQty = DifQty <= TotalQty ? DifQty : TotalQty;
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.纱线:
                //                                decimal DifPSQty = orderentity.Qty - orderentity.PSCGQty;
                //                                if (TotalQty <= DifPSQty)
                //                                {
                //                                    orderentity.PSCGQty += TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (DifPSQty > 0)
                //                                    {
                //                                        orderentity.PSCGQty += DifPSQty;
                //                                        TotalQty -= DifPSQty;
                //                                        break;
                //                                    }
                //                                }                                              
                //                                break;
                //                            case (int)EnumMLType.白坯:
                //                                decimal DifPBQty = orderentity.Qty - orderentity.PBCGQty;
                //                                if (TotalQty <= DifPBQty)
                //                                {
                //                                    orderentity.PBCGQty += TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (DifPBQty > 0)
                //                                    {
                //                                        orderentity.PBCGQty += DifPBQty;
                //                                        TotalQty -= DifPBQty;
                //                                        break;
                //                                    }
                //                                }
                //                                break;
                //                            default:
                //                                break;

                //                        }
                //                    }
                //                    if (findR)
                //                    {
                //                        SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                        rule.RUpdate(orderentity, sqlTrans);
                //                    }
                                   
                //                } //For循环结尾
                //            }   //While结尾
                //        }
                //        else
                //        {
                //            throw new Exception("数据出现异常未找到原始订单");
                //        }

                //    }
                //    if (entity.MLType == (int)EnumMLType.成品)
                //    {
                //        sql = "SELECT ItemCode,ColorNum,ColorName,Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts1 = sqlTrans.Fill(sql);
                //        foreach(DataRow dr in dtDts1.Rows)
                //        {
                //             sql = "SELECT DtsID FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo);
                //             sql += " AND ItemCode=" + SysString.ToDBString(dr["ItemCode"].ToString());
                //             sql += " AND ColorNum=" + SysString.ToDBString(dr["ColorNum"].ToString());
                //             sql += " AND ColorName=" + SysString.ToDBString(dr["ColorName"].ToString());
                //            DataTable dtorder = sqlTrans.Fill(sql);//寻找原始订单
                //            if (dtorder.Rows.Count == 1)
                //            {
                //                SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                orderentity.ID = SysConvert.ToInt32(dtorder.Rows[0]["DtsID"]);
                //                bool findR=orderentity.SelectByID();
                //                orderentity.CPCGQty += SysConvert.ToDecimal(dr["Qty"]);
                //                if (findR)
                //                {
                //                    SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                    rule.RUpdate(orderentity, sqlTrans);
                //                }
                //            }
                //            else
                //            {
                //                throw new Exception("数据出现异常未找到原始订单 订单号："+entity.FormNo);
                //            }
                //        }
                //    }

                //}
                //else        //撤销提交回填数量
                //{
                //    if (entity.MLType == (int)EnumMLType.纱线 || entity.MLType == (int)EnumMLType.白坯)
                //    {
                //        decimal TotalQty = 0m;
                //        sql = "SELECT  SUM(Qty) Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts = sqlTrans.Fill(sql);
                //        if (dtDts.Rows.Count != 0)
                //        {
                //            TotalQty = SysConvert.ToDecimal(dtDts.Rows[0]["Qty"]);
                //        }
                //        sql = "SELECT ID FROM Sale_SaleOrderDts WHERE MainID=(SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo) + ")";
                //        DataTable dtorder = sqlTrans.Fill(sql);//寻找原始订单
                //        if (dtorder.Rows.Count != 0)
                //        {
                //            while (TotalQty > 0m)//开始回填
                //            {
                //                for (int i = 0; i < dtorder.Rows.Count; i++)
                //                {
                //                    SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                    orderentity.ID = SysConvert.ToInt32(dtorder.Rows[i]["ID"]);
                //                    bool findR=orderentity.SelectByID();
                //                    if (i == dtorder.Rows.Count - 1)
                //                    {
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.纱线:
                //                                orderentity.PSCGQty -= TotalQty;
                //                                //if (orderentity.PSCGQty < 0)
                //                                //{
                //                                //    orderentity.PSCGQty = 0;
                //                                //}
                //                                TotalQty = 0;
                //                                break;
                //                            case (int)EnumMLType.白坯:
                //                                orderentity.PBCGQty -= TotalQty;
                //                                //if (orderentity.PBCGQty < 0)
                //                                //{
                //                                //    orderentity.PBCGQty = 0;
                //                                //}
                //                                TotalQty = 0;
                //                                break;
                //                            default:
                //                                break;
                //                        }
                //                    }
                //                    else
                //                    {
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.纱线:
                //                               // decimal DifPSQty = orderentity.Qty - orderentity.PSCGQty;
                //                                if (TotalQty <= orderentity.PSCGQty)
                //                                {
                //                                    orderentity.PSCGQty -= TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (orderentity.PSCGQty > 0)
                //                                    {
                //                                        TotalQty -= orderentity.PSCGQty;
                //                                        orderentity.PSCGQty =0;
                //                                        break;
                //                                    }
                //                                }
                //                                break;
                //                            case (int)EnumMLType.白坯:
                //                                //decimal DifPBQty = orderentity.Qty - orderentity.PBCGQty;
                //                                if (TotalQty <= orderentity.PBCGQty)
                //                                {
                //                                    orderentity.PBCGQty -= TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (orderentity.PBCGQty > 0)
                //                                    {
                //                                        TotalQty -= orderentity.PBCGQty;
                //                                        orderentity.PBCGQty= 0;
                //                                        break;
                //                                    }
                //                                }
                //                                break;
                //                            default:
                //                                break;

                //                        }
                //                    }
                //                    if (findR)
                //                    {
                //                        SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                        rule.RUpdate(orderentity, sqlTrans);
                //                    }

                //                } //For循环结尾
                //            }   //While结尾
                //        }
                //        else
                //        {
                //            throw new Exception("数据出现异常未找到原始订单");
                //        }

                //    }
                //    if (entity.MLType == (int)EnumMLType.成品)
                //    {
                //        sql = "SELECT ItemCode,ColorNum,ColorName,Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts1 = sqlTrans.Fill(sql);
                //        foreach (DataRow dr in dtDts1.Rows)
                //        {
                //            sql = "SELECT DtsID FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo);
                //            sql += " AND ItemCode=" + SysString.ToDBString(dr["ItemCode"].ToString());
                //            sql += " AND ColorNum=" + SysString.ToDBString(dr["ColorNum"].ToString());
                //            sql += " AND ColorName=" + SysString.ToDBString(dr["ColorName"].ToString());
                //            DataTable dtorder = sqlTrans.Fill(sql);//寻找原始订单
                //            if (dtorder.Rows.Count == 1)
                //            {
                //                SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                orderentity.ID = SysConvert.ToInt32(dtorder.Rows[0]["DtsID"]);
                //                bool findR= orderentity.SelectByID();
                //                orderentity.CPCGQty -= SysConvert.ToDecimal(dr["Qty"]);
                //                if (findR)
                //                {
                //                    SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                    rule.RUpdate(orderentity, sqlTrans);
                //                }
                //            }
                //            else
                //            {
                //                throw new Exception("数据出现异常未找到原始订单 订单号：" + entity.FormNo);
                //            }
                //        }
                //    }
                //}
                //#endregion
    

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
                ItemBuyForm entity = (ItemBuyForm)p_BE;

                string sql = "SELECT FormNo FROM Buy_ItemBuyForm WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("采购单号已存在，请重新生成");
                }
                ItemBuyFormCtl control = new ItemBuyFormCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Buy_ItemBuyForm, sqlTrans);
                control.AddNew(entity);

                FormNoControlRule fnrule = new FormNoControlRule();
                fnrule.RAddSort("Buy_ItemBuyForm", "FormNo", entity.FormAID, sqlTrans);

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
				ItemBuyForm entity=(ItemBuyForm)p_BE;				
				ItemBuyFormCtl control=new ItemBuyFormCtl(sqlTrans);				
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
				ItemBuyForm entity=(ItemBuyForm)p_BE;				
				ItemBuyFormCtl control=new ItemBuyFormCtl(sqlTrans);
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

        #region  新增方法 
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2,sqlTrans);

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
        public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                ItemBuyForm entity = (ItemBuyForm)p_BE;
                this.RAdd(entity, sqlTrans);
                for (int i = 0; i < p_BE2.Length;i++ )
                {
                    ItemBuyFormDtsRule rule = new ItemBuyFormDtsRule();
                    ItemBuyFormDts entityDts = (ItemBuyFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts,sqlTrans);
                }
                //FormNoControlRule rulest = new FormNoControlRule();
                //switch (entity.FormAID)     //注意各采购窗体的配置
                //{ 
                //    case 0:
                //        rulest.RAddSort((int)FormNoControlEnum.销售合同采购单号, sqlTrans); //采购成品面料
                //        break;
                //    case 1:
                //        rulest.RAddSort((int)FormNoControlEnum.坯布采购单号, sqlTrans);
                //        break;
                //    case 2:
                //        rulest.RAddSort((int)FormNoControlEnum.纱线采购单号, sqlTrans);
                //        break;
                //    default:
                //        rulest.RAddSort((int)FormNoControlEnum.销售合同采购单号, sqlTrans);
                //        break;
                //}
               
                ItemBuyCapDtsRule capRule = new ItemBuyCapDtsRule();
                capRule.RSaveBuyCap(entity, sqlTrans);//保存资金计划明细
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
        public void RUpdate(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE,p_BE2, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2,IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                ItemBuyForm entity = (ItemBuyForm)p_BE;
                ItemBuyFormCtl control = new ItemBuyFormCtl(sqlTrans);
                control.Update(entity);
                ItemBuyFormDtsRule rule = new ItemBuyFormDtsRule();
                rule.RSave(entity, p_BE2, sqlTrans);
                //string sql = "DELETE Buy_ItemBuyFormDts WHERE MainID="+SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);
                //for (int i = 0; i < p_BE2.Length; i++)
                //{
                //    ItemBuyFormDtsRule rule = new ItemBuyFormDtsRule();
                //    ItemBuyFormDts entityDts = (ItemBuyFormDts)p_BE2[i];
                //    entityDts.MainID = entity.ID;
                //    entityDts.Seq = i + 1;
                //    rule.RAdd(entityDts, sqlTrans);
                //}

                ItemBuyCapDtsRule capRule = new ItemBuyCapDtsRule();
                capRule.RSaveBuyCap(entity, sqlTrans);//保存资金计划明细
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
