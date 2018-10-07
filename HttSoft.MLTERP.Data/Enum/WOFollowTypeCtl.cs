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
	/// Ŀ�ģ�Enum_WOFollowTypeʵ�������
	/// ����:�ܸ���
	/// ��������:2014/8/1
	/// </summary>
	public sealed class WOFollowTypeCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public WOFollowTypeCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WOFollowTypeCtl(IDBTransAccess p_SqlCmd)
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
                WOFollowType MasterEntity=(WOFollowType)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Enum_WOFollowType(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("Name"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Name)+","); 
  				MasterField.Append("UseFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UseFlag)+","); 
  				MasterField.Append("SaleProcedureID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleProcedureID)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("QryTableName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QryTableName)+","); 
  				MasterField.Append("QryIDFieldName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QryIDFieldName)+","); 
  				MasterField.Append("QryFieldName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QryFieldName)+","); 
  				MasterField.Append("QryShowCaption"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QryShowCaption)+","); 
  				MasterField.Append("QryOrderByFieldName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QryOrderByFieldName)+","); 
  				MasterField.Append("QryWhereConFirst"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QryWhereConFirst)+","); 
  				MasterField.Append("UIImgUrl"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UIImgUrl)+")"); 
 
                
                

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
                WOFollowType MasterEntity=(WOFollowType)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Enum_WOFollowType SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" Name="+SysString.ToDBString(MasterEntity.Name)+","); 
  				UpdateBuilder.Append(" UseFlag="+SysString.ToDBString(MasterEntity.UseFlag)+","); 
  				UpdateBuilder.Append(" SaleProcedureID="+SysString.ToDBString(MasterEntity.SaleProcedureID)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" QryTableName="+SysString.ToDBString(MasterEntity.QryTableName)+","); 
  				UpdateBuilder.Append(" QryIDFieldName="+SysString.ToDBString(MasterEntity.QryIDFieldName)+","); 
  				UpdateBuilder.Append(" QryFieldName="+SysString.ToDBString(MasterEntity.QryFieldName)+","); 
  				UpdateBuilder.Append(" QryShowCaption="+SysString.ToDBString(MasterEntity.QryShowCaption)+","); 
  				UpdateBuilder.Append(" QryOrderByFieldName="+SysString.ToDBString(MasterEntity.QryOrderByFieldName)+","); 
  				UpdateBuilder.Append(" QryWhereConFirst="+SysString.ToDBString(MasterEntity.QryWhereConFirst)+","); 
  				UpdateBuilder.Append(" UIImgUrl="+SysString.ToDBString(MasterEntity.UIImgUrl)); 
 
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
                WOFollowType MasterEntity=(WOFollowType)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Enum_WOFollowType WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
