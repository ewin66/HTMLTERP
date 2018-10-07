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
	/// Ŀ�ģ�Data_CLSʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2006-11-7
	/// </summary>
	public class CLSRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CLSRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CLS entity=(CLS)p_BE;
		}		

		/// <summary>
		/// ��ʾ����
		/// </summary>
		/// <param name="p_condition"></param>
		public DataTable RShow(string p_condition)
		{
			try
			{				
				return RShow(p_condition,"*");
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new Exception(E.Message);
			}
		}	

		/// <summary>
		/// ��ʾ����
		/// </summary>
		/// <param name="p_condition"></param>
		public DataTable RShow(string p_condition,string p_FieldName)
		{
			try
			{
				if(p_FieldName==string.Empty)
				{
					p_FieldName="*";
				}
				string sql="SELECT "+p_FieldName+" FROM UV1_Data_CLS WHERE 1=1";
				sql+=p_condition;
				return SysUtils.Fill(sql);
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
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
				CLS entity=(CLS)p_BE;				
				CLSCtl control=new CLSCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_CLS,sqlTrans);
                string sql = string.Empty;
                //sql="SELECT CLSIDC FROM Data_CLS WHERE CLSIDC="+SysString.ToDBString(entity.CLSIDC);
                //sql+=" AND CLSListID="+SysString.ToDBString(entity.CLSListID);
                //DataTable dt=SysUtils.Fill(sql);
                //if(dt.Rows.Count!=0)
                //{
                //    throw new Exception("�ñ����Ѿ����ڣ����������룡");
                //}
				sql="SELECT CLSNM FROM Data_CLS WHERE CLSNM="+SysString.ToDBString(entity.CLSNM);
				sql+=" AND CLSListID="+SysString.ToDBString(entity.CLSListID);
                DataTable dt = SysUtils.Fill(sql);
				if(dt.Rows.Count!=0)
				{
					throw new Exception("�������Ѿ����ڣ����������룡");
				}
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
				CLS entity=(CLS)p_BE;				
				CLSCtl control=new CLSCtl(sqlTrans);
                string sql = string.Empty;
                //string sql="SELECT CLSIDC FROM Data_CLS WHERE CLSIDC="+SysString.ToDBString(entity.CLSIDC);
                //sql+=" AND CLSListID="+SysString.ToDBString(entity.CLSListID);
                //sql+=" AND ID<>"+SysString.ToDBString(entity.ID);
                //DataTable dt=SysUtils.Fill(sql);
                //if(dt.Rows.Count!=0)
                //{
                //    throw new Exception("�ñ����Ѿ����ڣ����������룡");
                //}
				sql="SELECT CLSNM FROM Data_CLS WHERE CLSNM="+SysString.ToDBString(entity.CLSNM);
				sql+=" AND CLSListID="+SysString.ToDBString(entity.CLSListID);
				sql+=" AND ID<>"+SysString.ToDBString(entity.ID);
                DataTable dt = SysUtils.Fill(sql);
				if(dt.Rows.Count!=0)
				{
					throw new Exception("�������Ѿ����ڣ����������룡");
				}
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
				CLS entity=(CLS)p_BE;				
				CLSCtl control=new CLSCtl(sqlTrans);
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
