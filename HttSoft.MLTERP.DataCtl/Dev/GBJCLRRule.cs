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
	/// 目的：Dev_GBJC实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public class GBJCLRRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public GBJCLRRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			GBJCLR entity=(GBJCLR)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV2_Dev_GBJCLRDts WHERE 1=1";
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
				GBJCLR entity=(GBJCLR)p_BE;
                string sql = "SELECT FormNo FROM Dev_GBJCLR WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("挂板借出单号已存在，请重新生成");
                }
				GBJCLRCtl control=new GBJCLRCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Dev_GBJCLR,sqlTrans);
				control.AddNew(entity);
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.挂板借出单号,sqlTrans);
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
				GBJCLR entity=(GBJCLR)p_BE;				
				GBJCLRCtl control=new GBJCLRCtl(sqlTrans);				
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
				GBJCLR entity=(GBJCLR)p_BE;				
				GBJCLRCtl control=new GBJCLRCtl(sqlTrans);
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
        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="p_BE">要新增的实体</param>
        //public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            this.RAdd(p_BE,p_BE2,sqlTrans);

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
        ///// 新增(传入事务处理)
        ///// </summary>
        ///// <param name="p_BE">要新增的实体</param>
        ///// <param name="sqlTrans">事务类</param>
        //public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        this.CheckCorrect(p_BE);
        //        GBJCLR entity = (GBJCLR)p_BE;
        //        string sql = "SELECT FormNo FROM Dev_GBJC WHERE FormNo="+SysString.ToDBString(entity.FormNo);
        //        DataTable dt = sqlTrans.Fill(sql);
        //        if (dt.Rows.Count > 0)
        //        {
        //            throw new BaseException("挂板借出单号重复，请检查后重新输入");
        //        }
        //        GBJCLRCtl control = new GBJCLRCtl(sqlTrans);
        //        entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Dev_GBJC, sqlTrans);
        //        control.AddNew(entity);
        //        for (int i = 0; i < p_BE2.Length; i++)
        //        {
        //            GBJCDtsRule rule = new GBJCDtsRule();
        //            GBJCDts entityDts = (GBJCDts)p_BE2[i];
        //            entityDts.MainID = entity.ID;
        //            entityDts.Seq = i + 1;
        //            rule.RAdd(entityDts, sqlTrans);
        //        }
        //        FormNoControlRule rulefst = new FormNoControlRule();
        //        rulefst.RAddSort((int)FormNoControlEnum.挂板借出单号,sqlTrans);
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
        ///// 修改
        ///// </summary>
        ///// <param name="p_BE">要修改的实体</param>
        //public void RUpdate(BaseEntity p_BE,BaseEntity[] p_BE2)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            this.RUpdate(p_BE,p_BE2,sqlTrans);

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
        ///// 修改
        ///// </summary>
        ///// <param name="p_BE">要修改的实体</param>
        ///// <param name="sqlTrans">事务类</param>
        //public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        this.CheckCorrect(p_BE);
        //        GBJCLR entity = (GBJCLR)p_BE;
        //        GBJCLRCtl control = new GBJCLRCtl(sqlTrans);
        //        control.Update(entity);
        //        string sql = "DELETE Dev_GBJCDts  WHERE MainID="+SysString.ToDBString(entity.ID);
        //        sqlTrans.Fill(sql);
        //        for (int i = 0; i < p_BE2.Length; i++)
        //        {
        //            GBJCDtsRule rule = new GBJCDtsRule();
        //            GBJCDts entityDts = (GBJCDts)p_BE2[i];
        //            entityDts.MainID = entity.ID;
        //            entityDts.Seq = i + 1;
        //            rule.RAdd(entityDts, sqlTrans);
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

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RSubmit(int p_ID,int p_SubmitFlag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_ID, p_SubmitFlag, sqlTrans);

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
        /// 提交
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RSubmit(int p_ID, int p_SubmitFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT SubmitFlag FROM Dev_GBJCLR WHERE ID="+SysString.ToDBString(p_ID);
                DataTable dt = sqlTrans.Fill(sql);
                int SubmitFlag = 0;
                if (dt.Rows.Count > 0)
                {
                    SubmitFlag = SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"]);
                    if (SubmitFlag == p_SubmitFlag)
                    {
                        throw new Exception("单据状态重复设置，请关闭程序重新打开操作");
                    }
                    switch (SubmitFlag)
                    {
                        case 1://撤销提交
                            sql = "UPDATE Dev_GBJCLR SET SubmitFlag=0 WHERE ID=" + SysString.ToDBString(p_ID);
                            sqlTrans.ExecuteNonQuery(sql);
                            break;
                        case 0://提交
                            sql = "UPDATE Dev_GBJCLR SET SubmitFlag=1 WHERE ID=" + SysString.ToDBString(p_ID);
                            sqlTrans.ExecuteNonQuery(sql);
                            break;
                    }

                    
                    //RSetGBStatus(p_ID, p_SubmitFlag, sqlTrans);//处理挂板状态

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
        /// 处理挂板状态
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_SubmitFlag"></param>
        /// <param name="sqlTrans"></param>
        private void RSetGBStatus(int p_ID, int p_SubmitFlag, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,GBCode FROM Dev_GBJCDts WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dt = sqlTrans.Fill(sql);
            int QStatus = 0;
            if (p_SubmitFlag == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(dr["GBCode"].ToString());
                    DataTable dto = sqlTrans.Fill(sql);
                    if (dto.Rows.Count > 0)
                    {
                        QStatus = SysConvert.ToInt32(dto.Rows[0][0]);
                        if (QStatus == (int)EnumGBStatus.在库 || QStatus == (int)EnumGBStatus.归还)
                        {
                            sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
                            sql += "WHERE GBCode=" + SysString.ToDBString(SysConvert.ToString(dr["GBCode"]));
                            sqlTrans.ExecuteNonQuery(sql);

                            sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
                            sql += "WHERE ID="+SysString.ToDBString(SysConvert.ToInt32(dr["ID"]));
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            throw new BaseException("挂板[" + SysConvert.ToString(dr["GBCode"]) + "]不处于在库或归还状态，请查看");
                        }
                    }
                    else
                    {
                        throw new BaseException("挂板[" + SysConvert.ToString(dr["GBCode"]) + "]不存在，请检查挂板管理");
                    }
                }
            }

            else if (p_SubmitFlag == 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(dr["GBCode"].ToString());
                    DataTable dto = sqlTrans.Fill(sql);
                    if (dto.Rows.Count > 0)
                    {
                        QStatus = SysConvert.ToInt32(dto.Rows[0][0]);
                        if (QStatus == (int)EnumGBStatus.借出)
                        {
                            sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.在库);
                            sql += "WHERE GBCode=" + SysString.ToDBString(SysConvert.ToString(dr["GBCode"]));
                            sqlTrans.ExecuteNonQuery(sql);

                            //sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.在库);
                            //sql += "WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(dr["ID"]));
                            //sqlTrans.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            throw new BaseException("挂板[" + SysConvert.ToString(dr["GBCode"]) + "]不处于借出状态，请查看");
                        }
                    }
                    else
                    {
                        throw new BaseException("挂板[" + SysConvert.ToString(dr["GBCode"]) + "]不存在，请检查挂板管理");
                    }
                }
            }
        }

        /// <summary>
        /// 根据状态ID得到状态名
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        private string GetStatusName(int p_ID)
        {
            string sql = "SELECT Name FROM Enum_GBStatus WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return string.Empty;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdate(string p_GBCode, int p_SubmitFlag, int p_MainID,int LYFlag,string p_OPID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_GBCode, p_SubmitFlag, p_MainID, LYFlag, p_OPID,sqlTrans);

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
        public void RUpdate(string p_GBCode,int p_SubmitFlag,int p_MainID,int LYFlag,string p_OPID,IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT GBCode FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(p_GBCode);
                DataTable dto = sqlTrans.Fill(sql);
                if (dto.Rows.Count == 0)
                {
                    throw new BaseException("扫描挂板不存在，请在挂板管理进行查看");
                }
                if (p_SubmitFlag == 1)
                {

                    sql = "SELECT * FROM UV1_Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                    sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        throw new BaseException("挂板[" + p_GBCode + "]没开借出单或已归还，请检查");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.归还);
                        sql += ",GHTime=" + SysString.ToDBString(DateTime.Now.Date);
                        sql += ",LYFlag="+SysString.ToDBString(LYFlag);
                        sql += ",GHOPID="+SysString.ToDBString(p_OPID);
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
                        sql += " AND MainID IN(SELECT ID FROM Dev_GBJC)";
                        sqlTrans.ExecuteNonQuery(sql);

                        sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.归还);
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sqlTrans.ExecuteNonQuery(sql);

                    }
                    else
                    {
                        throw new BaseException("挂板[" + p_GBCode + "]在借出单中存在两条同为借出状态的数据，请检查");
                    }
                }
                else if (p_SubmitFlag == 0)
                {
                    if (p_MainID == 0)
                    {
                        throw new BaseException("撤销归还数据处理异常，请查看");
                    }
                    sql = "SELECT * FROM Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                    sql += " AND MainID=" + SysString.ToDBString(p_MainID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        throw new BaseException("挂板[" + p_GBCode + "]没有归还或其借出单不存在");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
                        sql += ",GHTime=null,LYFlag=0,GHOPID='' ";
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sql += " AND MainID=" + SysString.ToDBString(p_MainID);
                        sqlTrans.ExecuteNonQuery(sql);

                        sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.借出);
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sqlTrans.ExecuteNonQuery(sql);

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
        #endregion
    }
}
