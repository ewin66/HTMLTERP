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
	/// Ŀ�ģ�Data_FNORelʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2009-04-07
	/// </summary>
	public class FNORelRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public FNORelRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			FNORel entity=(FNORel)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Data_FNORel WHERE 1=1";
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

        #region ���ݵ��Ź��� �Զ��忪������    
        /// <summary>
        /// ��õ��ſ���ID
        /// </summary>
        /// <param name="p_CLSA">����</param>
        /// <param name="p_CLSB">С��</param>
        /// <returns>���ص��ſ���</returns>
        public int RGetFormNoControlID(string p_CLSA,string p_CLSB)
        {
            return RGetFormNoControlID(p_CLSA,p_CLSB,0);
        }

         /// <summary>
        /// ��õ��ſ���ID
        /// </summary>
        /// <returns></returns>
        public int RGetFormNoControlID(string p_CLSA,string p_CLSB,int p_SubTypeID)
        {
            int outI = 0;
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    outI = this.RGetFormNoControlID(p_CLSA, p_CLSB, p_SubTypeID, sqlTrans);

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
            return outI;
        }




        /// <summary>
        /// ��õ��Ź���ID
        /// </summary>
        /// <param name="p_CLSA">����</param>
        /// <param name="p_CLSB">С��</param>
        /// <param name="p_SubTypeID">������</param>
        /// <param name="sqlTrans">����SQLִ����</param>
        /// <returns></returns>
        public int RGetFormNoControlID(string p_CLSA, string p_CLSB, int p_SubTypeID, IDBTransAccess sqlTrans)
        {
            int outI = 0;
            string sql = string.Empty;
            sql = "SELECT FormNoControlID FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_CLSA);
            sql += " AND CLSB=" + SysString.ToDBString(p_CLSB);
            sql += " AND ISNULL(SubTypeID,0)=" + p_SubTypeID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outI = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]);
            }
            return outI;
        }




        /// <summary>
        /// ����Ƿ���Ҫ���ſ���
        /// </summary>
        /// <returns></returns>
        public bool RGetFormNoControlEditFlag(string p_CLSA,string p_CLSB)
        {
            return RGetFormNoControlEditFlag(p_CLSA, p_CLSB, 0);
        }




       
        /// <summary>
        /// ����Ƿ���Ҫ���ſ���
        /// </summary>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        /// <returns></returns>
        public bool RGetFormNoControlEditFlag(string p_CLSA, string p_CLSB, int p_SubTypeID)
        {
            bool outb = false;
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    outb = this.RGetFormNoControlEditFlag(p_CLSA, p_CLSB, p_SubTypeID, sqlTrans);

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
            return outb;
        }


     

        /// <summary>
        /// ����Ƿ���Ҫ���ſ���
        /// </summary>
        /// <param name="p_CLSA">����</param>
        /// <param name="p_CLSB">С��</param>
        /// <param name="p_SubTypeID">������</param>
        /// <param name="sqlTrans">����SQLִ����</param>
        /// <returns></returns>
        public bool RGetFormNoControlEditFlag(string p_CLSA, string p_CLSB, int p_SubTypeID, IDBTransAccess sqlTrans)
        {
            bool outb = false;
            string sql = string.Empty;
            sql = "SELECT SelfEditFlag FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_CLSA);
            sql += " AND CLSB=" + SysString.ToDBString(p_CLSB);
            sql += " AND ISNULL(SubTypeID,0)=" + p_SubTypeID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outb = SysConvert.ToBoolean(SysConvert.ToInt32(dt.Rows[0]["SelfEditFlag"]));
            }
            else//���û�ҵ�����ʾ�ɱ༭
            {
                outb = true;
            }
            return outb;
        }

        #endregion

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
				FNORel entity=(FNORel)p_BE;				
				FNORelCtl control=new FNORelCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_FNORel,sqlTrans);
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
				FNORel entity=(FNORel)p_BE;				
				FNORelCtl control=new FNORelCtl(sqlTrans);				
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
				FNORel entity=(FNORel)p_BE;				
				FNORelCtl control=new FNORelCtl(sqlTrans);
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
