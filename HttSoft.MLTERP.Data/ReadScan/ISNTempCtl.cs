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
	/// Ŀ�ģ�WO_ISNTempʵ�������
	/// ����:Johnny
	/// ��������:2012/5/26
	/// </summary>
	public sealed class ISNTempCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public ISNTempCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ISNTempCtl(IDBTransAccess p_SqlCmd)
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
                ISNTemp MasterEntity=(ISNTemp)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_ISNTemp(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("ISN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ISN)+","); 
  				MasterField.Append("Status"+","); 
  				if(MasterEntity.Status!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Status)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Sort"+","); 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ImportTime"+")"); 
  				if(MasterEntity.ImportTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ImportTime.ToString("yyyy-MM-dd HH:mm:ss"))+")"); 
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
                ISNTemp MasterEntity=(ISNTemp)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_ISNTemp SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" ISN="+SysString.ToDBString(MasterEntity.ISN)+","); 
  				 
  				if(MasterEntity.Status!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Status="+SysString.ToDBString(MasterEntity.Status)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Status=null,");  
  				} 
  
  				 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Sort="+SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Sort=null,");  
  				} 
  
  				 
  				if(MasterEntity.ImportTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ImportTime="+SysString.ToDBString(MasterEntity.ImportTime.ToString("yyyy-MM-dd HH:mm:ss"))); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ImportTime=null");  
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
                ISNTemp MasterEntity=(ISNTemp)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM WO_ISNTemp WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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