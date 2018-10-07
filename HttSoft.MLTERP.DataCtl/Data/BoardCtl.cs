using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;

namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�Data_Boardʵ�������
	/// ����:�¼Ӻ�
	/// ��������:2006-11-09
	/// </summary>
	public sealed class BoardCtl : BaseControl
	{
		private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		/// <summary>
		/// ���캯��
		/// </summary>
		public BoardCtl()
		{
		    
		}
		
		/// <summary>
		/// ���캯��
		/// </summary>
		public BoardCtl(IDBTransAccess p_SqlCmd)
		{
			sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		
		/// <summary>
		/// ����
		/// </summary>
		/// <param name="p_Entity">ʵ����</param>
		/// <returns>����Ӱ��ļ�¼����</returns>
		public override int AddNew(BaseEntity p_Entity)
		{
			try
			{
				Board MasterEntity=(Board)p_Entity;
				if (MasterEntity.ID==0)
				{
					return 0;
				}

				//������������
				StringBuilder MasterField=new StringBuilder();
				StringBuilder MasterValue=new StringBuilder();
				MasterField.Append("INSERT INTO Data_Board(");
				MasterValue.Append(" VALUES(");
				MasterField.Append("ID"+","); 
				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
				MasterField.Append("Title"+","); 
				MasterValue.Append(SysString.ToDBString(MasterEntity.Title)+","); 
				MasterField.Append("Context"+","); 
				MasterValue.Append(SysString.ToDBString(MasterEntity.Context)+","); 
				MasterField.Append("SendDate"+","); 
				if(MasterEntity.SendDate!=SystemConfiguration.DateTimeDefaultValue) 
				{ 
					MasterValue.Append(SysString.ToDBString(MasterEntity.SendDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
				} 
				else 
				{ 
					MasterValue.Append("null,"); 
				} 
  
				MasterField.Append("IsShow"+","); 
				if(MasterEntity.IsShow!=0) 
				{ 
					MasterValue.Append(SysString.ToDBString(MasterEntity.IsShow)+","); 
				} 
				else 
				{ 
					MasterValue.Append("null,"); 
				} 
  
				MasterField.Append("SendOP"+")"); 
				MasterValue.Append(SysString.ToDBString(MasterEntity.SendOP)+")"); 
 

				//ִ��
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
				return AffectedRows;
			}
			catch(BaseException E)
			{
				throw new BaseException(E.Message,E);
			}
			catch(Exception E)
			{
				throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBInsert),E);
			}
		}

		/// <summary>
		/// �޸�
		/// </summary>
		/// <param name="p_Entity">ʵ����</param>
		/// <returns>����Ӱ��ļ�¼����</returns>
		public override int Update(BaseEntity p_Entity)
		{
			try
			{
				Board MasterEntity=(Board)p_Entity;
				if (MasterEntity.ID==0)
				{
					return 0;
				}

				//������������
				StringBuilder UpdateBuilder=new StringBuilder();
				UpdateBuilder.Append("UPDATE Data_Board SET ");
				UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
				UpdateBuilder.Append(" Title="+SysString.ToDBString(MasterEntity.Title)+","); 
				UpdateBuilder.Append(" Context="+SysString.ToDBString(MasterEntity.Context)+","); 
  				 
				if(MasterEntity.SendDate!=SystemConfiguration.DateTimeDefaultValue) 
				{ 
					UpdateBuilder.Append(" SendDate="+SysString.ToDBString(MasterEntity.SendDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 				} 
				else 
				{ 
					UpdateBuilder.Append(" SendDate=null,");  
				} 
  
  				 
				if(MasterEntity.IsShow!=0) 
				{ 
					UpdateBuilder.Append(" IsShow="+SysString.ToDBString(MasterEntity.IsShow)+","); 
				} 
				else 
				{ 
					UpdateBuilder.Append(" IsShow=null,");  
				} 
  
				UpdateBuilder.Append(" SendOP="+SysString.ToDBString(MasterEntity.SendOP));
				UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));

				//ִ��
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString());
				}
				return AffectedRows;
			}
			catch(BaseException E)
			{
				throw new BaseException(E.Message,E);
			}
			catch(Exception E)
			{
				throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBUpdate),E);
			}
		}

		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="p_Entity">ʵ����</param>
		/// <returns>����Ӱ��ļ�¼����</returns>
		public override int Delete(BaseEntity p_Entity)
		{
			try
			{
				Board MasterEntity=(Board)p_Entity;
				if (MasterEntity.ID==0)
				{
					return 0;
				}

				//ɾ����������
				string Sql="";
				Sql="DELETE FROM Data_Board WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
				//ִ��
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(Sql);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(Sql);
				}

				return AffectedRows;
			}
			catch(BaseException E)
			{
				throw new BaseException(E.Message,E);
			}
			catch(Exception E)
			{
				throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBDelete),E);
			}
		}
	}
}
