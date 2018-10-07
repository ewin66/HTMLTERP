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
	/// Ŀ�ģ�Data_PayMethodʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public class PayMethodRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public PayMethodRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			PayMethod entity=(PayMethod)p_BE;
		}	
		
		
		 /// <summary>
        /// ��ʾ����
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
        /// ��ʾ����
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
                string sql = "SELECT " + p_FieldName + " FROM Data_PayMethod WHERE 1=1";
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
		/// ����
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
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
		/// ����(����������)
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
		/// <param name="sqlTrans">������</param>
		public void RAdd(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
				this.CheckCorrect(p_BE);
				PayMethod entity=(PayMethod)p_BE;
                string sql = "SELECT * FROM Data_PayMethod WHERE ID=" + SysString.ToDBString(entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽID�Ѵ���,�������������!");
                }
                 sql = "SELECT * FROM Data_PayMethod WHERE Code="+SysString.ToDBString(entity.Code);
                 dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�����Ѵ���,�������������!");
                }
                sql = "SELECT * FROM Data_PayMethod WHERE Name="+SysString.ToDBString(entity.Name);
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�������Ѵ���,�������������!");
                }
				PayMethodCtl control=new PayMethodCtl(sqlTrans);
				//entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_PayMethod,sqlTrans);
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
		/// �޸�
		/// </summary>
		/// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
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
		/// �޸�
		/// </summary>
		/// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
		/// <param name="sqlTrans">������</param>
		public void RUpdate(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
				this.CheckCorrect(p_BE);
				PayMethod entity=(PayMethod)p_BE;
                string sql = "SELECT * FROM Data_PayMethod WHERE Code=" + SysString.ToDBString(entity.Code) + " AND ID<>" + entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�����Ѵ���,�������������!");
                }
                sql = "SELECT * FROM Data_PayMethod WHERE Name=" + SysString.ToDBString(entity.Name) + " AND ID<>" + entity.ID;
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�������Ѵ���,�������������!");
                }
				PayMethodCtl control=new PayMethodCtl(sqlTrans);				
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
		/// ɾ��
		/// </summary>
		/// <param name="p_BE">Ҫɾ����ʵ��</param>
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
		/// ɾ��
		/// </summary>
		/// <param name="p_BE">Ҫɾ����ʵ��</param>
		/// <param name="sqlTrans">������</param>
		public void RDelete(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
			    this.CheckCorrect(p_BE);
				PayMethod entity=(PayMethod)p_BE;				
				PayMethodCtl control=new PayMethodCtl(sqlTrans);
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

        #region �·���

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE,p_BE2, sqlTrans);

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
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                PayMethod entity = (PayMethod)p_BE;
                string sql = "SELECT * FROM Data_PayMethod WHERE ID=" + SysString.ToDBString(entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("ID�Ѵ���,�������������!");
                }
                sql = "SELECT * FROM Data_PayMethod WHERE Code=" + SysString.ToDBString(entity.Code);
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�����Ѵ���,�������������!");
                }
                sql = "SELECT * FROM Data_PayMethod WHERE Name=" + SysString.ToDBString(entity.Name);
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�������Ѵ���,�������������!");
                }
                PayMethodCtl control = new PayMethodCtl(sqlTrans);
                //entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_PayMethod,sqlTrans);
                control.AddNew(entity);

                for (int i = 0; i < p_BE2.Length; i++)
                {
                    PayMethodDtsRule rule = new PayMethodDtsRule();
                    PayMethodDts entityDts = (PayMethodDts)p_BE2[i];
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

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
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
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdate(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                PayMethod entity = (PayMethod)p_BE;
                string sql = "SELECT * FROM Data_PayMethod WHERE Code=" + SysString.ToDBString(entity.Code) + " AND ID<>" + entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�����Ѵ���,�������������!");
                }
                sql = "SELECT * FROM Data_PayMethod WHERE Name=" + SysString.ToDBString(entity.Name) + " AND ID<>" + entity.ID;
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���ʽ�������Ѵ���,�������������!");
                }
                PayMethodCtl control = new PayMethodCtl(sqlTrans);
                control.Update(entity);

                sql = "DELETE Data_PayMethodDts WHERE MainID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                for (int i = 0; i < p_BE2.Length; i++)
                {
                    PayMethodDtsRule rule = new PayMethodDtsRule();
                    PayMethodDts entityDts = (PayMethodDts)p_BE2[i];
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
