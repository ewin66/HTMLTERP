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
	/// Ŀ�ģ�Data_Structureʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2007-04-21
	/// </summary>
	public class StructureRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public StructureRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			Structure entity=(Structure)p_BE;
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
				string sql="SELECT "+p_FieldName+" FROM Data_Structure WHERE 1=1";
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


		#region ������Ա��
		/// <summary>
		/// ����
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
		public void RAddStruectureOP(string[] p_OPA,int p_StructureID)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RAddStruectureOP(p_OPA,p_StructureID,sqlTrans);
			
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
		public void RAddStruectureOP(string[] p_OPA,int p_StructureID,IDBTransAccess sqlTrans)
		{
			try
			{

                StructureMemberRule rule = new StructureMemberRule();

                StructureMember[] entityA = new StructureMember[p_OPA.Length];
                for (int i = 0; i < p_OPA.Length; i++)
                {
                    entityA[i] = new StructureMember(sqlTrans);
                    entityA[i].StuctureID = p_StructureID;
                    entityA[i].OPID = p_OPA[i].ToString();
                    entityA[i].SelectByCode();
                } 
                
                
                string sql = "DELETE Data_StructureMember WHERE StuctureID=" + SysString.ToDBString(p_StructureID);
                sqlTrans.ExecuteNonQuery(sql);

                for (int i = 0; i < entityA.Length; i++)
                {
                    rule.RAdd(entityA[i], sqlTrans);
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
		/// <param name="p_BE">Ҫ������ʵ��</param>
		public void RDeleteStruectureOP(string[] p_OPA,string p_StructID)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RDeleteStruectureOP(p_OPA,p_StructID,sqlTrans);
			
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
		/// ɾ��(����������)
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
		/// <param name="sqlTrans">������</param>
		public void RDeleteStruectureOP(string[] p_OPA,string p_StructID,IDBTransAccess sqlTrans)
		{
			try
			{
				string sql=string.Empty;
				for(int i=0;i<p_OPA.Length;i++)
				{
					sql="DELETE FROM Data_OPStructure WHERE OPID="+SysString.ToDBString(p_OPA[i])+" AND StructureID IN( "+p_StructID+")";
					sqlTrans.ExecuteNonQuery(sql);

                    sql = "UPDATE Data_OP Set StructureID=0 WHERE OPID=" + SysString.ToDBString(p_OPA[i]);
					sqlTrans.ExecuteNonQuery(sql);
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
		
		#endregion

        #region ���½ṹ
        /// <summary>
        /// ���¸��ṹ
        /// </summary>
        public void RUpdateParentID(int p_ID ,int p_ParentID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdateParentID( p_ID , p_ParentID, sqlTrans);

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
        /// ���¸��ṹ(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdateParentID(int p_ID, int p_ParentID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;

                if (p_ID != 0)
                {
                    sql = "UPDATE Data_Structure SET ParentID="+p_ParentID+" WHERE ID=" + SysString.ToDBString(p_ID);
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
				Structure entity=(Structure)p_BE;				
				StructureCtl control=new StructureCtl(sqlTrans);
                string sql = "SELECT * FROM Data_Structure WHERE Name="+SysString.ToDBString(entity.Name);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѿ������ˣ�����������");
                }
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_Structure,sqlTrans);
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
				Structure entity=(Structure)p_BE;				
				StructureCtl control=new StructureCtl(sqlTrans);				
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
				Structure entity=(Structure)p_BE;				
				StructureCtl control=new StructureCtl(sqlTrans);
				control.Delete(entity);

                string sql = "SELECT * FROM Data_Structure WHERE ParentID="+SysString.ToDBString(entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("����������Ŀ����ɾ�����������Ŀ����ɾ������Ŀ");
                }

                sql = "DELETE FROM Data_Structure WHERE ID=" + SysString.ToDBString(entity.ID);
				sqlTrans.ExecuteNonQuery(sql);

                sql = "DELETE Data_StructureMember WHERE StuctureID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
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
