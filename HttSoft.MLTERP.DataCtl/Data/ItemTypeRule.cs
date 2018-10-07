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
	/// Ŀ�ģ�Enum_ItemTypeʵ��ҵ�������
	/// ����:LookSun
	/// ��������:2009-3-31
	/// </summary>
	public class ItemTypeRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public ItemTypeRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
            HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Enum_ItemType WHERE 1=1";
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
                HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;
                string sql = string.Empty;

                sql = " SELECT 1 FROM  Enum_ItemType WHERE ID= " + SysString.ToDBString(entity.ID);

                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("��ID�Ѿ����ڣ����������룡");
                }

                sql = " SELECT 1 FROM  Enum_ItemType WHERE Code= " + SysString.ToDBString(entity.Code);

                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("�ñ����Ѿ����ڣ����������룡");
                }

				ItemTypeCtl control=new ItemTypeCtl(sqlTrans);
				//entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Enum_ItemType,sqlTrans);
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
                HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;	
			
				ItemTypeCtl control=new ItemTypeCtl(sqlTrans);				
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
                HttSoft.MLTERP.Data.ItemType entity = (HttSoft.MLTERP.Data.ItemType)p_BE;				
				
                ItemTypeCtl control=new ItemTypeCtl(sqlTrans);
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
