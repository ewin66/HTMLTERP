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
	/// Ŀ�ģ�Data_MachineManageʵ�������
	/// ����:���
	/// ��������:11/20/2011
	/// </summary>
	public sealed class MachineManageCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public MachineManageCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public MachineManageCtl(IDBTransAccess p_SqlCmd)
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
                MachineManage MasterEntity=(MachineManage)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_MachineManage(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("MachineType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MachineType)+","); 
  				MasterField.Append("Machine"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Machine)+","); 
  				MasterField.Append("Needie"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needie)+","); 
  				MasterField.Append("UserFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UserFlag)+","); 
  				MasterField.Append("DayOuty"+","); 
  				if(MasterEntity.DayOuty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DayOuty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("NeedleLen"+","); 
  				if(MasterEntity.NeedleLen!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NeedleLen)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TolNeedle"+","); 
  				if(MasterEntity.TolNeedle!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TolNeedle)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InItem"+")"); 
  				if(MasterEntity.InItem!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InItem)+")"); 
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
                MachineManage MasterEntity=(MachineManage)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_MachineManage SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" MachineType="+SysString.ToDBString(MasterEntity.MachineType)+","); 
  				UpdateBuilder.Append(" Machine="+SysString.ToDBString(MasterEntity.Machine)+","); 
  				UpdateBuilder.Append(" Needie="+SysString.ToDBString(MasterEntity.Needie)+","); 
  				UpdateBuilder.Append(" UserFlag="+SysString.ToDBString(MasterEntity.UserFlag)+","); 
  				 
  				if(MasterEntity.DayOuty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DayOuty="+SysString.ToDBString(MasterEntity.DayOuty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DayOuty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				 
  				if(MasterEntity.NeedleLen!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NeedleLen="+SysString.ToDBString(MasterEntity.NeedleLen)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NeedleLen=null,");  
  				} 
  
  				 
  				if(MasterEntity.TolNeedle!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TolNeedle="+SysString.ToDBString(MasterEntity.TolNeedle)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TolNeedle=null,");  
  				} 
  
  				 
  				if(MasterEntity.InItem!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InItem="+SysString.ToDBString(MasterEntity.InItem)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InItem=null");  
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
                MachineManage MasterEntity=(MachineManage)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Data_MachineManage WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
