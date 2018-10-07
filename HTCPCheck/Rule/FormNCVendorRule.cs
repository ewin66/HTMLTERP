using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;
using HttSoft.HTERP.Sys;


namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// 目的：Data_FormNCVendor实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public class FormNCVendorRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public FormNCVendorRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			FormNCVendor entity=(FormNCVendor)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Data_FormNCVendor WHERE 1=1";
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

        #region 流水号处理

        bool THAddOneFlag = false;//2010/12月处理系统调号异常 标志是否已经自动跳过一次了

        /// <summary>
        /// 获得流水号处理
        /// </summary>
        /// <param name="fncEntity">单号控制表</param>
        /// <param name="p_VendorID">客户</param>
        /// <param name="sqlTrans">事务</param>
        /// <returns></returns>
        public string RGetFormNo(FormNoControl fncEntity, int p_FNCVID, string p_VendorID, IDBTransAccess sqlTrans)
        {
            string outstr = string.Empty;
            string sql = "";

            //先期处理获得客户流水号实体BEGIN
            sql = "SELECT ID FROM Data_FormNCVendor WHERE VendorID=" + SysString.ToDBString(p_VendorID) + " AND FNCVID=" + p_FNCVID;
            DataTable dt = sqlTrans.Fill(sql);
            FormNCVendor entity = new FormNCVendor(sqlTrans);
            if (dt.Rows.Count != 0)
            {
                entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                entity.SelectByID();
            }
            else//如果没找到，新增一笔进去
            {
                entity.VendorID = p_VendorID;
                entity.FNCVID = p_FNCVID;
                this.RAdd(entity, sqlTrans);
            }
            //先期处理获得客户流水号实体END

            #region 开始取号
            sql = "SELECT getdate() AS ServerTime";
            DateTime dtserver = SysConvert.ToDateTime(sqlTrans.Fill(sql).Rows[0][0].ToString());

            bool UpdFlag = false;
            if (fncEntity.CurYear != 0 && entity.CurYear != dtserver.Year)//判断年
            {
                entity.CurYear = dtserver.Year;
                UpdFlag = true;
            }
            if (fncEntity.CurMonth != 0 && entity.CurMonth != dtserver.Month)//判断月
            {
                entity.CurMonth = dtserver.Month;
                UpdFlag = true;
            }
            if (fncEntity.CurDay != 0 && entity.CurDay != dtserver.Day)//判断日
            {
                entity.CurDay = dtserver.Day;
                UpdFlag = true;
            }
            if (UpdFlag)//需要更新
            {
                entity.CurSort = 0;
                this.RUpdate(entity, sqlTrans);
            }
            outstr = fncEntity.FormRulePre;

            if (entity.CurYear != 0)//替换年
            {
                outstr = outstr.Replace("YYYY", entity.CurYear.ToString());//如果是4位 陈加海2010/3/26日修改
                outstr = outstr.Replace("YY", entity.CurYear.ToString().Substring(2));
            }
            if (entity.CurMonth != 0)//替换月
            {
                outstr = outstr.Replace("MM", SysString.IntToStr(entity.CurMonth, 2));
            }
            if (entity.CurDay != 0)//替换日
            {
                outstr = outstr.Replace("DD", SysString.IntToStr(entity.CurDay, 2));
            }
            if (fncEntity.FormRuleSpecial == "V4")
            {
                string spstr = p_VendorID;
                if (p_VendorID.Length > 4)
                {
                    spstr = p_VendorID.Substring(p_VendorID.Length - 4);
                }
                outstr = outstr.Replace("X", spstr);
            }
            else if (fncEntity.FormRuleSpecial != "")//替换特殊符号
            {
                outstr = outstr.Replace("X", fncEntity.FormRuleSpecial);
            }
            outstr += SysString.IntToStr(entity.CurSort + 1, fncEntity.FormRuleSort.Length);//获得序号

            #endregion

            #region 多跳一个号处理
            if (!THAddOneFlag)//没有调号过，防止死循环
            {
                try//跳号验证是否存在处理，存在则加1
                {
                    sql = "SELECT DTableName,DFieldName FROM Enum_FormNoControl WHERE ID=" + fncEntity.ID;
                    DataTable dtL = sqlTrans.Fill(sql);
                    if (dtL.Rows.Count != 0)
                    {
                        if (dtL.Rows[0]["DTableName"].ToString() != string.Empty && dtL.Rows[0]["DFieldName"].ToString() != string.Empty)
                        {
                            sql = "SELECT " + dtL.Rows[0]["DFieldName"].ToString() + " FROM " + dtL.Rows[0]["DTableName"].ToString() + " WHERE " + dtL.Rows[0]["DFieldName"].ToString() + "=" + SysString.ToDBString(outstr);
                            if (sqlTrans.Fill(sql).Rows.Count != 0)//产生的号码系统中已存在，则序号跳号
                            {
                                THAddOneFlag = true;
                                this.RAddSort(fncEntity.ID, p_FNCVID, p_VendorID, sqlTrans);
                                outstr = RGetFormNo(fncEntity, p_FNCVID, p_VendorID, sqlTrans);//循环调用一次

                            }
                        }
                    }
                }
                catch (Exception EL)//异常情况下填写临时信息
                {
                    SysFile.WriteFrameworkLog(EL.Message);
                }
            }
            #endregion
            return outstr;
        }

        /// <summary>
        /// 单据序号加1
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
        /// <param name="sqlTrans">事务</param>
        public void RAddSort(int p_FormNoContronlID, int p_FNCVID, string p_VendorID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT ID FROM Data_FormNCVendor WHERE VendorID=" + SysString.ToDBString(p_VendorID) + " AND FNCVID=" + p_FNCVID;
                DataTable dt = sqlTrans.Fill(sql);
                FormNCVendor entity = new FormNCVendor(sqlTrans);
                if (dt.Rows.Count != 0)
                {
                    entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    entity.SelectByID();

                    sql = "UPDATE Data_FormNCVendor SET CurSort=" + (entity.CurSort + 1) + " WHERE ID=" + entity.ID;
                    sqlTrans.ExecuteNonQuery(sql);
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
				FormNCVendor entity=(FormNCVendor)p_BE;
                //根据客户编码和单据ID查询表，如查询得到，则已重复
                string sql = "SELECT * FROM Data_FormNCVendor WHERE VendorID="+SysString.ToDBString(entity.VendorID);
                sql += " AND FNCVID="+SysString.ToDBString(entity.FNCVID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("同客户的单据流水号设置已存在,请检查后重新输入!");
                }
				FormNCVendorCtl control=new FormNCVendorCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_FormNCVendor,sqlTrans);
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
				FormNCVendor entity=(FormNCVendor)p_BE;				
				FormNCVendorCtl control=new FormNCVendorCtl(sqlTrans);				
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
				FormNCVendor entity=(FormNCVendor)p_BE;				
				FormNCVendorCtl control=new FormNCVendorCtl(sqlTrans);
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
