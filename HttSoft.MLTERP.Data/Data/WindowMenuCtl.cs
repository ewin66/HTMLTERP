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
	/// Ŀ�ģ�Sys_WindowMenuʵ�������
	/// ����:�ܸ���
	/// ��������:2012-4-24
	/// </summary>
	public sealed class WindowMenuCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public WindowMenuCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public WindowMenuCtl(IDBTransAccess p_SqlCmd)
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
                WindowMenu MasterEntity=(WindowMenu)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sys_WindowMenu(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("WinListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WinListID)+","); 
  				MasterField.Append("Name"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Name)+","); 
  				MasterField.Append("ParentID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ParentID)+","); 
  				MasterField.Append("Sort"+","); 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HttFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HttFlag)+","); 
  				MasterField.Append("ShowFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShowFlag)+","); 
  				MasterField.Append("SystemTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SystemTypeID)+","); 
  				MasterField.Append("ShortCutChar"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShortCutChar)+","); 
  				MasterField.Append("HeadTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				MasterField.Append("SubTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubTypeID)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("AuditFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				MasterField.Append("ModuleFlowID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ModuleFlowID)+","); 
  				MasterField.Append("MenuTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MenuTypeID)+","); 
  				MasterField.Append("UseTypeID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UseTypeID)+")"); 
 
                
                

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
                WindowMenu MasterEntity=(WindowMenu)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sys_WindowMenu SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" WinListID="+SysString.ToDBString(MasterEntity.WinListID)+","); 
  				UpdateBuilder.Append(" Name="+SysString.ToDBString(MasterEntity.Name)+","); 
  				UpdateBuilder.Append(" ParentID="+SysString.ToDBString(MasterEntity.ParentID)+","); 
  				 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Sort="+SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Sort=null,");  
  				} 
  
  				UpdateBuilder.Append(" HttFlag="+SysString.ToDBString(MasterEntity.HttFlag)+","); 
  				UpdateBuilder.Append(" ShowFlag="+SysString.ToDBString(MasterEntity.ShowFlag)+","); 
  				UpdateBuilder.Append(" SystemTypeID="+SysString.ToDBString(MasterEntity.SystemTypeID)+","); 
  				UpdateBuilder.Append(" ShortCutChar="+SysString.ToDBString(MasterEntity.ShortCutChar)+","); 
  				UpdateBuilder.Append(" HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				UpdateBuilder.Append(" SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" AuditFlag="+SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				UpdateBuilder.Append(" ModuleFlowID="+SysString.ToDBString(MasterEntity.ModuleFlowID)+","); 
  				UpdateBuilder.Append(" MenuTypeID="+SysString.ToDBString(MasterEntity.MenuTypeID)+","); 
  				UpdateBuilder.Append(" UseTypeID="+SysString.ToDBString(MasterEntity.UseTypeID)); 
 
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
                WindowMenu MasterEntity=(WindowMenu)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Sys_WindowMenu WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
