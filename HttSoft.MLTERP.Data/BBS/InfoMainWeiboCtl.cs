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
	/// Ŀ�ģ�BBS_InfoMainWeiboʵ�������
	/// ����:����ǿ
	/// ��������:2012/7/21
	/// </summary>
	public sealed class InfoMainWeiboCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public InfoMainWeiboCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public InfoMainWeiboCtl(IDBTransAccess p_SqlCmd)
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
                InfoMainWeibo MasterEntity=(InfoMainWeibo)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO BBS_InfoMainWeibo(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DContext"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DContext)+","); 
  				MasterField.Append("AddTime"+","); 
  				if(MasterEntity.AddTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AddOPID)+")"); 
 
                
                

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
                InfoMainWeibo MasterEntity=(InfoMainWeibo)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE BBS_InfoMainWeibo SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" DContext="+SysString.ToDBString(MasterEntity.DContext)+","); 
  				 
  				if(MasterEntity.AddTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" AddTime="+SysString.ToDBString(MasterEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" AddOPID="+SysString.ToDBString(MasterEntity.AddOPID)); 
 
                UpdateBuilder.Append(" WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq));
                
                

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
                InfoMainWeibo MasterEntity=(InfoMainWeibo)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM BBS_InfoMainWeibo WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
