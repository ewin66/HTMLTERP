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
	/// Ŀ�ģ�Data_CheckContentʵ�������
	/// ����:�˽ܿ�
	/// ��������:2009-7-10
	/// </summary>
	public sealed class CheckContentCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public CheckContentCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CheckContentCtl(IDBTransAccess p_SqlCmd)
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
                CheckContent MasterEntity=(CheckContent)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_CheckContent(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("Content"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Content)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("ParentID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ParentID)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("SubmitTime"+","); 
  				if(MasterEntity.SubmitTime!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitTime)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				MasterField.Append("AuditFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				MasterField.Append("AuditOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AuditOPID)+","); 
  				MasterField.Append("AddTime"+","); 
  				if(MasterEntity.AddTime!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddTime)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AddOPID)+","); 
  				MasterField.Append("UpdTime"+","); 
  				if(MasterEntity.UpdTime!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.UpdTime)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UpdOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UpdOPID)+")"); 
 
                
                

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
                CheckContent MasterEntity=(CheckContent)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_CheckContent SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" Content="+SysString.ToDBString(MasterEntity.Content)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" ParentID="+SysString.ToDBString(MasterEntity.ParentID)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				 
  				if(MasterEntity.SubmitTime!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime="+SysString.ToDBString(MasterEntity.SubmitTime)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitOPID="+SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				UpdateBuilder.Append(" AuditFlag="+SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				UpdateBuilder.Append(" AuditOPID="+SysString.ToDBString(MasterEntity.AuditOPID)+","); 
  				 
  				if(MasterEntity.AddTime!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddTime="+SysString.ToDBString(MasterEntity.AddTime)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" AddOPID="+SysString.ToDBString(MasterEntity.AddOPID)+","); 
  				 
  				if(MasterEntity.UpdTime!=0) 
  				{ 
  			 		UpdateBuilder.Append(" UpdTime="+SysString.ToDBString(MasterEntity.UpdTime)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" UpdTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" UpdOPID="+SysString.ToDBString(MasterEntity.UpdOPID)); 
 
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
                CheckContent MasterEntity=(CheckContent)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Data_CheckContent WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
