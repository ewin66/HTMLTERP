using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;

namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�WO_BProductCheckDtsModifyLogʵ�������
	/// ����:�¼Ӻ�
	/// ��������:2014/5/4
	/// </summary>
	public sealed class BProductCheckDtsModifyLogCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public BProductCheckDtsModifyLogCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public BProductCheckDtsModifyLogCtl(IDBTransAccess p_SqlCmd)
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
                BProductCheckDtsModifyLog MasterEntity=(BProductCheckDtsModifyLog)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_BProductCheckDtsModifyLog(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("ModifyID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ModifyID)+","); 
  				MasterField.Append("ModifyDay"+","); 
  				if(MasterEntity.ModifyDay!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ModifyDay.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OldCompactNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OldCompactNo)+","); 
  				MasterField.Append("OldJarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OldJarNum)+","); 
  				MasterField.Append("OldSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OldSeq)+","); 
  				MasterField.Append("CompactNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("NewISNID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NewISNID)+")"); 
 
                
                

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
                BProductCheckDtsModifyLog MasterEntity=(BProductCheckDtsModifyLog)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_BProductCheckDtsModifyLog SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" ModifyID="+SysString.ToDBString(MasterEntity.ModifyID)+","); 
  				 
  				if(MasterEntity.ModifyDay!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ModifyDay="+SysString.ToDBString(MasterEntity.ModifyDay.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ModifyDay=null,");  
  				} 
  
  				UpdateBuilder.Append(" OldCompactNo="+SysString.ToDBString(MasterEntity.OldCompactNo)+","); 
  				UpdateBuilder.Append(" OldJarNum="+SysString.ToDBString(MasterEntity.OldJarNum)+","); 
  				UpdateBuilder.Append(" OldSeq="+SysString.ToDBString(MasterEntity.OldSeq)+","); 
  				UpdateBuilder.Append(" CompactNo="+SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" NewISNID="+SysString.ToDBString(MasterEntity.NewISNID)); 
 
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
                BProductCheckDtsModifyLog MasterEntity=(BProductCheckDtsModifyLog)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM WO_BProductCheckDtsModifyLog WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
