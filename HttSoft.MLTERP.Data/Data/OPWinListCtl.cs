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
	/// Ŀ�ģ�Data_OPWinListʵ�������
	/// ����:�¼Ӻ�
	/// ��������:2006-12-12
	/// </summary>
	public sealed class OPWinListCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public OPWinListCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public OPWinListCtl(IDBTransAccess p_SqlCmd)
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
                OPWinList MasterEntity=(OPWinList)p_Entity;
                if (MasterEntity.OPID=="")
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_OPWinList(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("OPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OPID)+","); 
  				MasterField.Append("WinListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WinListID)+","); 
  				MasterField.Append("HeadTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				MasterField.Append("SubTypeID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubTypeID)+")"); 
 
                
                

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
                OPWinList MasterEntity=(OPWinList)p_Entity;
                if (MasterEntity.OPID=="")
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_OPWinList SET ");
                UpdateBuilder.Append(" OPID="+SysString.ToDBString(MasterEntity.OPID)+","); 
  				UpdateBuilder.Append(" WinListID="+SysString.ToDBString(MasterEntity.WinListID)+","); 
  				UpdateBuilder.Append(" HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				UpdateBuilder.Append(" SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID)); 
 
                UpdateBuilder.Append(" WHERE "+ "OPID="+SysString.ToDBString(MasterEntity.OPID)+" AND WinListID="+SysString.ToDBString(MasterEntity.WinListID)+" AND HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID));
                
                

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
                OPWinList MasterEntity=(OPWinList)p_Entity;
                if (MasterEntity.OPID=="")
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Data_OPWinList WHERE "+ "OPID="+SysString.ToDBString(MasterEntity.OPID)+" AND WinListID="+SysString.ToDBString(MasterEntity.WinListID)+" AND HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID);
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
