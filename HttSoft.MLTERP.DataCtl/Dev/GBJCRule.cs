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
	public class GBJCRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public GBJCRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			GBJC entity=(GBJC)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV2_Dev_GBJCDts WHERE 1=1";
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
				GBJC entity=(GBJC)p_BE;
                string sql = "SELECT FormNo FROM Dev_GBJC WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("挂板借出单号已存在，请重新生成");
                }
				GBJCCtl control=new GBJCCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Dev_GBJC,sqlTrans);
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
				GBJC entity=(GBJC)p_BE;				
				GBJCCtl control=new GBJCCtl(sqlTrans);				
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
				GBJC entity=(GBJC)p_BE;				
				GBJCCtl control=new GBJCCtl(sqlTrans);
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
        //        GBJC entity = (GBJC)p_BE;
        //        string sql = "SELECT FormNo FROM Dev_GBJC WHERE FormNo="+SysString.ToDBString(entity.FormNo);
        //        DataTable dt = sqlTrans.Fill(sql);
        //        if (dt.Rows.Count > 0)
        //        {
        //            throw new BaseException("挂板借出单号重复，请检查后重新输入");
        //        }
        //        GBJCCtl control = new GBJCCtl(sqlTrans);
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
        //        GBJC entity = (GBJC)p_BE;
        //        GBJCCtl control = new GBJCCtl(sqlTrans);
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
                string sql = "SELECT SubmitFlag FROM Dev_GBJC WHERE ID="+SysString.ToDBString(p_ID);
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
                            sql = "UPDATE Dev_GBJC SET SubmitFlag=0 WHERE ID=" + SysString.ToDBString(p_ID);
                            sqlTrans.ExecuteNonQuery(sql);
                            break;
                        case 0://提交
                            sql = "UPDATE Dev_GBJC SET SubmitFlag=1 WHERE ID=" + SysString.ToDBString(p_ID);
                            sqlTrans.ExecuteNonQuery(sql);
                            break;
                    }

                    
                    RSetGBStatus(p_ID, p_SubmitFlag, sqlTrans);//处理挂板状态

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
                    sql += " AND SubmitFlag > 0";
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
                        sql += " AND MainID IN(SELECT ID FROM Dev_GBJC WHERE SubmitFlag > 0)";
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
                    //sql += " AND MainID=" + SysString.ToDBString(p_MainID);
                    sql += " AND MainID IN(SELECT ID FROM Dev_GBJC WHERE SubmitFlag > 0)";
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
                        sql += " AND MainID IN(SELECT ID FROM Dev_GBJC WHERE SubmitFlag > 0)";
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

        #region 同步数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="HTDataID"></param>
        public void RAddLR(int HTDataID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAddLR(HTDataID, sqlTrans);

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
        /// 
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RAddLR(int HTDataID, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = "SELECT ID FROM Dev_GBJCLR WHERE DID="+SysString.ToDBString(HTDataID);
                if (sqlTrans.Fill(sql).Rows.Count > 0)
                {
                    throw new BaseException("已经同步，请撤销后再同步");
                }

                GBJC entity = new GBJC(sqlTrans);
                entity.ID = HTDataID;
                entity.SelectByID();

                sql = "SELECT * FROM Dev_GBJCDts WHERE MainID="+SysString.ToDBString(HTDataID);
                sql += " AND ISNULL(LYVendorID,'')<>''";
                DataTable dt = sqlTrans.Fill(sql);

                DataTable dtVendor = new DataTable();
                dtVendor.Columns.Add("VendorID", typeof(string));
                dtVendor.Columns.Add("GBCode", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string VendorIDStr = SysConvert.ToString(dt.Rows[i]["LYVendorID"]);
                    string[] VendorID = VendorIDStr.Split(',');
                    for (int j = 0; j < VendorID.Length; j++)
                    {
                        DataRow dr = dtVendor.NewRow();
                        dr["VendorID"] = VendorID[j].ToString();
                        dr["GBCode"] = SysConvert.ToString(dt.Rows[i]["GBCode"]);
                        dtVendor.Rows.Add(dr);
                       
                    }
                    
                }

                ArrayList list = new ArrayList();
                for (int i = 0; i < dtVendor.Rows.Count; i++)
                {
                    string VendorID = SysConvert.ToString(dtVendor.Rows[i]["VendorID"]);
                    bool Find = false;
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (VendorID == list[j].ToString())
                        {
                            Find = true;
                        }
                    }
                    if (!Find)
                    {
                        list.Add(VendorID);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    DataRow[] drVendor = dtVendor.Select(" VendorID="+SysConvert.ToString(list[i]));

                    FormNoControlRule frule = new FormNoControlRule();
                    GBJCLRRule rule = new GBJCLRRule();
                    GBJCLR entityLR = new GBJCLR();
                    entityLR.FormNo = frule.RGetFormNo((int)FormNoControlEnum.挂板借出录入单号, sqlTrans);
                    entityLR.DID = HTDataID;
                    entityLR.DNo = entity.FormNo;
                    entityLR.MakeDate = entity.MakeDate;
                    entityLR.MakeOPID = entity.MakeOPID;
                    entityLR.SaleOPID = entity.SaleOPID;
                    entityLR.VendorID = list[i].ToString();
                    entityLR.SubmitFlag = 1;
                    entityLR.Remark = "自动回填，回填单号：" + entity.FormNo + ",日期：" + entity.MakeDate.ToString("yyyy-MM-dd");
                    rule.RAdd(entityLR, sqlTrans);

                    frule.RAddSort((int)FormNoControlEnum.挂板借出录入单号, sqlTrans);

                    for (int j = 0; j < drVendor.Length; j++)
                    {
                        GBJCLRDtsRule DRule = new GBJCLRDtsRule();
                        GBJCLRDts entityDts = new GBJCLRDts(sqlTrans);
                        entityDts.MainID = entityLR.ID;
                        entityDts.Seq = 1;
                        entityDts.GBCode = SysConvert.ToString(drVendor[j]["GBCode"]);
                        entityDts.JCTime = entity.MakeDate;
                        entityDts.LYFlag = 1;
                        DRule.RAdd(entityDts, sqlTrans);
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


        public void RDelLR(int HTDataID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RDelLR(HTDataID, sqlTrans);

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
        /// 
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RDelLR(int HTDataID, IDBTransAccess sqlTrans)
        {
            try
            {

                //删除明细
                string sql = "DELETE Dev_GBJCLRDts WHERE MainID IN (SELECT ID FROM Dev_GBJCLR WHERE DID="+SysString.ToDBString(HTDataID)+")";
                sqlTrans.ExecuteNonQuery(sql);

                //删除主表
                sql = "DELETE Dev_GBJCLR WHERE  DID=" + SysString.ToDBString(HTDataID);
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
    }
}
