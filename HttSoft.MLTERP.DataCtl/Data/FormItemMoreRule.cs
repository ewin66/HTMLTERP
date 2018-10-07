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
	/// 目的：Data_FormItemMore实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2010/7/7
	/// </summary>
	public class FormItemMoreRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public FormItemMoreRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			FormItemMore entity=(FormItemMore)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Data_FormItemMore WHERE 1=1";
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
        #region 原料共用方法处理
        char strConChar = '◎';//连接符
        /// <summary>
        /// 加载页面显示数据处理
        /// </summary>
        /// <param name="p_Dt"></param>
        /// <param name="p_Val"></param>
        public void RShowVal(DataTable p_Dt, string p_Val)
        {
            p_Dt.Rows.Clear();
            string[] valStrA = p_Val.Split(strConChar);
            if (valStrA.Length > 1)
            {
                for (int i = 0; i < valStrA.Length / 3; i++)//遍历字符串循环
                {
                    DataRow dr = p_Dt.NewRow();
                    dr["ItemCode"] = valStrA[i * 3];
                    dr["ItemName"] = valStrA[i * 3 + 1];
                    dr["ItemStd"] = valStrA[i * 3 + 2];

                    p_Dt.Rows.Add(dr);
                }
            }

        }

        /// <summary>
        /// 读取值，连接符
        /// </summary>
        /// <param name="p_AL"></param>
        /// <param name="o_Txt"></param>
        /// <param name="o_Val"></param>
        public void RConVal(ArrayList p_AL,out string o_Txt,out string o_Val)
        {
            o_Txt = string.Empty;
            o_Val = string.Empty;
            for (int i = 0; i < p_AL.Count; i++)
            {
                if (o_Val != string.Empty)
                {
                    o_Val += strConChar;
                }
                if (o_Txt != string.Empty)
                {
                    o_Txt += Environment.NewLine;
                }
                string[] tempa = (string[])p_AL[i];
                o_Val += tempa[0] + strConChar + tempa[1] + strConChar + tempa[2];
                o_Txt += tempa[0] + "  " + tempa[1] + "  " + tempa[2];
            }
        }
        /// <summary>
        /// 读取值
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_TableID"></param>
        /// <param name="o_Txt"></param>
        /// <param name="o_Val"></param>
        public void RRead(string p_TableName, int p_TableID, out string o_Txt, out string o_Val)
        {
            string sql = "SELECT ItemCode,ItemName,ItemStd FROM  Data_FormItemMore WHERE TableName=" + SysString.ToDBString(p_TableName) + " AND TableID=" + p_TableID;
            DataTable dt = SysUtils.Fill(sql);
            o_Txt = string.Empty;
            o_Val = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (o_Val != string.Empty)
                {
                    o_Val += strConChar;
                }
                if (o_Txt != string.Empty)
                {
                    o_Txt += Environment.NewLine;
                }

                o_Val += dt.Rows[i]["ItemCode"].ToString() + strConChar + dt.Rows[i]["ItemName"].ToString() + strConChar + dt.Rows[i]["ItemStd"].ToString();
                o_Txt += dt.Rows[i]["ItemCode"].ToString() + "  " + dt.Rows[i]["ItemName"].ToString() + "  " + dt.Rows[i]["ItemStd"].ToString();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_TableID"></param>
        /// <param name="p_Val"></param>
        public void RSave(string p_TableName, int p_TableID,string p_Val)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSave(p_TableName, p_TableID,p_Val, sqlTrans);

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
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RSave(string p_TableName, int p_TableID, string p_Val, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Data_FormItemMore WHERE TableName=" + SysString.ToDBString( p_TableName) + " AND TableID=" + p_TableID;
                sqlTrans.ExecuteNonQuery(sql);
                string[] valStrA = p_Val.Split(strConChar);
                if (valStrA.Length > 1)
                {
                    if (valStrA.Length % 3 != 0)
                    {
                        throw new Exception("多原料数据保存异常，请检查");
                    }

                    for (int i = 0; i < valStrA.Length / 3; i++)//遍历字符串循环
                    {
                        FormItemMore entity = new FormItemMore(sqlTrans);
                        entity.TableName = p_TableName;
                        entity.TableID = p_TableID;
                        entity.Seq = i + 1;
                        entity.ItemCode = valStrA[i * 3];
                        entity.ItemName = valStrA[i * 3 + 1];
                        entity.ItemStd = valStrA[i * 3 + 2];
                        this.RAdd(entity, sqlTrans);
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
        /// 删除
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_TableID"></param>
        /// <param name="p_Val"></param>
        public void RDelete(string p_TableName, int p_TableID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RDelete(p_TableName, p_TableID, sqlTrans);

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
        /// 保存(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RDelete(string p_TableName, int p_TableID , IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "DELETE FROM Data_FormItemMore WHERE TableName=" + SysString.ToDBString( p_TableName) + " AND  TableID=" + p_TableID;
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
				FormItemMore entity=(FormItemMore)p_BE;				
				FormItemMoreCtl control=new FormItemMoreCtl(sqlTrans);
				//entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_FormItemMore,sqlTrans);
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
				FormItemMore entity=(FormItemMore)p_BE;				
				FormItemMoreCtl control=new FormItemMoreCtl(sqlTrans);				
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
				FormItemMore entity=(FormItemMore)p_BE;				
				FormItemMoreCtl control=new FormItemMoreCtl(sqlTrans);
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
