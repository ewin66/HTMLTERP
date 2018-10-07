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
	/// Ŀ�ģ�BBS_InfoMainAttʵ�������
	/// ����:����ǿ
	/// ��������:2012/7/21
	/// </summary>
	public sealed class InfoMainAttCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public InfoMainAttCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public InfoMainAttCtl(IDBTransAccess p_SqlCmd)
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
                InfoMainAtt MasterEntity=(InfoMainAtt)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO BBS_InfoMainAtt(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("FileTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileTypeID)+","); 
  				MasterField.Append("Context"+","); 
  				MasterValue.Append(@"@Context"+","); 
  				MasterField.Append("EntityID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EntityID)+","); 
  				MasterField.Append("EntitySeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EntitySeq)+","); 
  				MasterField.Append("FileName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileName)+","); 
  				MasterField.Append("FileExec"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileExec)+","); 
  				MasterField.Append("FileLength"+","); 
  				if(MasterEntity.FileLength!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FileLength)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("UploadTime"+","); 
  				if(MasterEntity.UploadTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.UploadTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UploadOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UploadOPID)+")"); 
 
                
                 
  				object[,] obja= new object[2,1]; 
  				obja[0,0]="@Context"; 
  				obja[1,0]=MasterEntity.Context;

                //ִ��
                int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(),obja);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(),obja);
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
                InfoMainAtt MasterEntity=(InfoMainAtt)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE BBS_InfoMainAtt SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" FileTypeID="+SysString.ToDBString(MasterEntity.FileTypeID)+","); 
  				UpdateBuilder.Append(" Context=@Context"+","); 
  				UpdateBuilder.Append(" EntityID="+SysString.ToDBString(MasterEntity.EntityID)+","); 
  				UpdateBuilder.Append(" EntitySeq="+SysString.ToDBString(MasterEntity.EntitySeq)+","); 
  				UpdateBuilder.Append(" FileName="+SysString.ToDBString(MasterEntity.FileName)+","); 
  				UpdateBuilder.Append(" FileExec="+SysString.ToDBString(MasterEntity.FileExec)+","); 
  				 
  				if(MasterEntity.FileLength!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FileLength="+SysString.ToDBString(MasterEntity.FileLength)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FileLength=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.UploadTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" UploadTime="+SysString.ToDBString(MasterEntity.UploadTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" UploadTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" UploadOPID="+SysString.ToDBString(MasterEntity.UploadOPID)); 
 
                UpdateBuilder.Append(" WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq));
                
                 
  				object[,] obja= new object[2,1]; 
  				obja[0,0]="@Context"; 
  				obja[1,0]=MasterEntity.Context;

               //ִ��
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString(),obja);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString(),obja);
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
                InfoMainAtt MasterEntity=(InfoMainAtt)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM BBS_InfoMainAtt WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
