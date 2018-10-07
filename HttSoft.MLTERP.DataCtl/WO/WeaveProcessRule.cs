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
	/// 目的：WO_WeaveProcess实体业务规则类
	/// 作者:翟晓东
	/// 创建日期:2012-8-17
	/// </summary>
	public class WeaveProcessRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
        public WeaveProcessRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			WeaveProcess entity=(WeaveProcess)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WO_WeaveProcess WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WO_WeaveProcessDts WHERE 1=1";
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
                WeaveProcess entity = new WeaveProcess(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//如果相同异常
                {
                    throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                }



                sql = "UPDATE WO_WeaveProcess SET SubmitFlag=" + SysString.ToDBString(p_Type);
                //if (p_Type == (int)ConfirmFlag.审核通过 || p_Type == (int)ConfirmFlag.审核拒绝)
                //{
                    //sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                //}
                sql += " WHERE ID=" + p_FormID.ToString();//更新单据主表审核状态
                sqlTrans.ExecuteNonQuery(sql);
                //if (p_Type == (int)YesOrNo.Yes)
                //{
                //    sql = "SELECT ItemCode,ColorNum,ColorName FROM WO_PrintingProcessDts WHERE MainID=" + p_FormID;
                //    DataTable dtDts = sqlTrans.Fill(sql);

                //    SaleOrderRule salerule = new SaleOrderRule();
                //    foreach (DataRow dr in dtDts.Rows)
                //    {
                //        salerule.RUpdateStep(entity.OrderFormNo, dr["ItemCode"].ToString(), dr["ColorNum"].ToString(),dr["ColorName"].ToString(), (int)EnumOrderStep.采购, p_Type, true, sqlTrans);
                //    }
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
				WeaveProcess entity=(WeaveProcess)p_BE;
                string sql = "SELECT FormNo FROM WO_WeaveProcess WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("织造加工单号已存在，请重新生成");
                }
				WeaveProcessCtl control=new WeaveProcessCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_WeaveProcess, sqlTrans);
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
				WeaveProcess entity=(WeaveProcess)p_BE;				
				WeaveProcessCtl control=new WeaveProcessCtl(sqlTrans);				
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
				WeaveProcess entity=(WeaveProcess)p_BE;				
				WeaveProcessCtl control=new WeaveProcessCtl(sqlTrans);
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
                WeaveProcess entity = (WeaveProcess)p_BE;
                string sql = "SELECT FormNo FROM WO_WeaveProcess WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("印花加工单号已存在，请重新生成");
                }
                WeaveProcessCtl control = new WeaveProcessCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_WeaveProcess, sqlTrans);
                control.AddNew(entity);
                for (int i = 0; i < p_BE2.Length;i++ )
                {
                    WeaveProcessDtsRule rule = new WeaveProcessDtsRule();
                    WeaveProcessDts entityDts = (WeaveProcessDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts,sqlTrans);
                }
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.白坯织造加工单号, sqlTrans);

                //ItemBuyCapDtsRule capRule = new ItemBuyCapDtsRule();
                //capRule.RSaveBuyCap(entity, sqlTrans);//保存资金计划明细
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
                WeaveProcess entity = (WeaveProcess)p_BE;
                WeaveProcessCtl control = new WeaveProcessCtl(sqlTrans);
                control.Update(entity);
                WeaveProcessDtsRule rule = new WeaveProcessDtsRule();
                rule.RSave(entity, p_BE2, sqlTrans);
                //string sql = "DELETE WO_PrintingProcessDts WHERE MainID="+SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);
                //for (int i = 0; i < p_BE2.Length; i++)
                //{
                //    WeaveProcessDtsRule rule = new WeaveProcessDtsRule();
                //    WeaveProcessDts entityDts = (WeaveProcessDts)p_BE2[i];
                //    entityDts.MainID = entity.ID;
                //    entityDts.Seq = i + 1;
                //    rule.RAdd(entityDts, sqlTrans);
                //}

                //ItemBuyCapDtsRule capRule = new ItemBuyCapDtsRule();
                //capRule.RSaveBuyCap(entity, sqlTrans);//保存资金计划明细
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
        /// 保存明细数据
        /// </summary>
        /// <param name="p_BE">主表</param>
        /// <param name="p_BE2">明细表</param>
        /// <param name="p_BE3">明细表2</param>
        private void RSaveDts(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            WeaveProcessDtsRule ruledts = new WeaveProcessDtsRule();
            ruledts.RSave((WeaveProcess)p_BE, p_BE2, sqlTrans);//保存从表

            WeaveProcessDts2Rule ruledts2 = new WeaveProcessDts2Rule();
            ruledts2.RSave((WeaveProcess)p_BE, p_BE3, sqlTrans);//保存从表2
        }
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

                    this.RAdd(p_BE, p_BE2, p_BE3, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                WeaveProcess entity = (WeaveProcess)p_BE;
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    WeaveProcessDtsRule rule = new WeaveProcessDtsRule();
                    WeaveProcessDts entityDts = (WeaveProcessDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
                }
                for (int i = 0; i < p_BE3.Length; i++)
                {
                    WeaveProcessDts2Rule rule2 = new WeaveProcessDts2Rule();
                    WeaveProcessDts2 entityDts2 = (WeaveProcessDts2)p_BE3[i];
                    entityDts2.MainID = entity.ID;
                    entityDts2.Seq = i + 1;
                    rule2.RAdd(entityDts2, sqlTrans);
                }
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.白坯织造加工单号, sqlTrans);
                //this.RAddDts(p_BE, p_BE2, p_BE3, sqlTrans);//保存明细数据
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

                    this.RUpdate(p_BE, p_BE2, p_BE3, sqlTrans);

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
                this.RSaveDts(p_BE, p_BE2, p_BE3, sqlTrans);//保存明细数据
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
