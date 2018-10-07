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
	/// Ŀ�ģ�SMS_MSGMainʵ�������
	/// ����:�����
	/// ��������:2012-7-31
	/// </summary>
	public sealed class MSGMainCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public MSGMainCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public MSGMainCtl(IDBTransAccess p_SqlCmd)
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
                MSGMain MasterEntity=(MSGMain)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO SMS_MSGMain(");
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
  
  				MasterField.Append("InsertTime"+","); 
  				if(MasterEntity.InsertTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InsertTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MSGSourceID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MSGSourceID)+","); 
  				MasterField.Append("Context"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Context)+","); 
  				MasterField.Append("SendInfo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SendInfo)+","); 
  				MasterField.Append("SendDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SendDesc)+","); 
  				MasterField.Append("SendPhone"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SendPhone)+","); 
  				MasterField.Append("TargetPhone"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TargetPhone)+","); 
  				MasterField.Append("TaregtInfo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TaregtInfo)+","); 
  				MasterField.Append("TargetDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TargetDesc)+","); 
  				MasterField.Append("SendTime"+","); 
  				if(MasterEntity.SendTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SendTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SendFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SendFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("DID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DID)+")"); 
 
                
                

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
                MSGMain MasterEntity=(MSGMain)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE SMS_MSGMain SET ");
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
  
  				 
  				if(MasterEntity.InsertTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" InsertTime="+SysString.ToDBString(MasterEntity.InsertTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InsertTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" MSGSourceID="+SysString.ToDBString(MasterEntity.MSGSourceID)+","); 
  				UpdateBuilder.Append(" Context="+SysString.ToDBString(MasterEntity.Context)+","); 
  				UpdateBuilder.Append(" SendInfo="+SysString.ToDBString(MasterEntity.SendInfo)+","); 
  				UpdateBuilder.Append(" SendDesc="+SysString.ToDBString(MasterEntity.SendDesc)+","); 
  				UpdateBuilder.Append(" SendPhone="+SysString.ToDBString(MasterEntity.SendPhone)+","); 
  				UpdateBuilder.Append(" TargetPhone="+SysString.ToDBString(MasterEntity.TargetPhone)+","); 
  				UpdateBuilder.Append(" TaregtInfo="+SysString.ToDBString(MasterEntity.TaregtInfo)+","); 
  				UpdateBuilder.Append(" TargetDesc="+SysString.ToDBString(MasterEntity.TargetDesc)+","); 
  				 
  				if(MasterEntity.SendTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SendTime="+SysString.ToDBString(MasterEntity.SendTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SendTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" SendFlag="+SysString.ToDBString(MasterEntity.SendFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" DID="+SysString.ToDBString(MasterEntity.DID)); 
 
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
                MSGMain MasterEntity=(MSGMain)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM SMS_MSGMain WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
