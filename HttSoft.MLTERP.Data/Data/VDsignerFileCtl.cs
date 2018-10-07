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
	/// Ŀ�ģ�Data_VDsignerFileʵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-19
	/// </summary>
	public sealed class VDsignerFileCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public VDsignerFileCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public VDsignerFileCtl(IDBTransAccess p_SqlCmd)
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
                VDsignerFile MasterEntity=(VDsignerFile)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }
                
                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_VDsignerFile(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("FileTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileTypeID)+","); 
  				MasterField.Append("Context"+","); 
  				MasterValue.Append(@"@Context"+","); 
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
                MasterField = null;
                MasterValue = null;
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
                VDsignerFile MasterEntity=(VDsignerFile)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_VDsignerFile SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" FileTypeID="+SysString.ToDBString(MasterEntity.FileTypeID)+","); 
  				UpdateBuilder.Append(" Context=@Context"+","); 
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
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                 
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
                VDsignerFile MasterEntity=(VDsignerFile)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Data_VDsignerFile WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
