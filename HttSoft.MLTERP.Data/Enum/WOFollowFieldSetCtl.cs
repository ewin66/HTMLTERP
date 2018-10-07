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
	/// Ŀ�ģ�Enum_WOFollowFieldSetʵ�������
	/// ����:�ܸ���
	/// ��������:2014/8/1
	/// </summary>
	public sealed class WOFollowFieldSetCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public WOFollowFieldSetCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WOFollowFieldSetCtl(IDBTransAccess p_SqlCmd)
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
                WOFollowFieldSet MasterEntity=(WOFollowFieldSet)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Enum_WOFollowFieldSet(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("WOFollowTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WOFollowTypeID)+","); 
  				MasterField.Append("FTableType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FTableType)+","); 
  				MasterField.Append("DFieldName"+","); 
  				if(MasterEntity.DFieldName!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DFieldName)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DCaption"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DCaption)+","); 
  				MasterField.Append("DShowFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DShowFlag)+","); 
  				MasterField.Append("UpdateMainFieldName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UpdateMainFieldName)+","); 
  				MasterField.Append("Remark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+")"); 
 
                
                

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
                WOFollowFieldSet MasterEntity=(WOFollowFieldSet)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Enum_WOFollowFieldSet SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" WOFollowTypeID="+SysString.ToDBString(MasterEntity.WOFollowTypeID)+","); 
  				UpdateBuilder.Append(" FTableType="+SysString.ToDBString(MasterEntity.FTableType)+","); 
  				 
  				if(MasterEntity.DFieldName!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DFieldName="+SysString.ToDBString(MasterEntity.DFieldName)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DFieldName=null,");  
  				} 
  
  				UpdateBuilder.Append(" DCaption="+SysString.ToDBString(MasterEntity.DCaption)+","); 
  				UpdateBuilder.Append(" DShowFlag="+SysString.ToDBString(MasterEntity.DShowFlag)+","); 
  				UpdateBuilder.Append(" UpdateMainFieldName="+SysString.ToDBString(MasterEntity.UpdateMainFieldName)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)); 
 
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
                WOFollowFieldSet MasterEntity=(WOFollowFieldSet)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Enum_WOFollowFieldSet WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
