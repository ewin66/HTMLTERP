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
	/// Ŀ�ģ�Sale_HandleEventʵ�������
	/// ����:tanghao
	/// ��������:2015/5/22
	/// </summary>
	public sealed class HandleEventCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public HandleEventCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public HandleEventCtl(IDBTransAccess p_SqlCmd)
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
                HandleEvent MasterEntity=(HandleEvent)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_HandleEvent(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("EventType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EventType)+","); 
  				MasterField.Append("VedorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VedorID)+","); 
  				MasterField.Append("OrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				MasterField.Append("Remark1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark1)+","); 
  				MasterField.Append("Remark2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark2)+","); 
  				MasterField.Append("Remark3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark3)+","); 
  				MasterField.Append("Remark4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark4)+","); 
  				MasterField.Append("Remark5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark5)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("EventStatus"+","); 
  				if(MasterEntity.EventStatus!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.EventStatus)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RDate"+")"); 
  				if(MasterEntity.RDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RDate.ToString("yyyy-MM-dd HH:mm:ss"))+")"); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null)"); 
  				} 
  
 
                
                

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
                HandleEvent MasterEntity=(HandleEvent)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_HandleEvent SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" EventType="+SysString.ToDBString(MasterEntity.EventType)+","); 
  				UpdateBuilder.Append(" VedorID="+SysString.ToDBString(MasterEntity.VedorID)+","); 
  				UpdateBuilder.Append(" OrderFormNo="+SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				UpdateBuilder.Append(" Remark1="+SysString.ToDBString(MasterEntity.Remark1)+","); 
  				UpdateBuilder.Append(" Remark2="+SysString.ToDBString(MasterEntity.Remark2)+","); 
  				UpdateBuilder.Append(" Remark3="+SysString.ToDBString(MasterEntity.Remark3)+","); 
  				UpdateBuilder.Append(" Remark4="+SysString.ToDBString(MasterEntity.Remark4)+","); 
  				UpdateBuilder.Append(" Remark5="+SysString.ToDBString(MasterEntity.Remark5)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				 
  				if(MasterEntity.EventStatus!=0) 
  				{ 
  			 		UpdateBuilder.Append(" EventStatus="+SysString.ToDBString(MasterEntity.EventStatus)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" EventStatus=null,");  
  				} 
  
  				 
  				if(MasterEntity.RDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" RDate="+SysString.ToDBString(MasterEntity.RDate.ToString("yyyy-MM-dd HH:mm:ss"))); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RDate=null");  
  				} 
  
 
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
                HandleEvent MasterEntity=(HandleEvent)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Sale_HandleEvent WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
