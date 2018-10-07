using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.WinUIBase
{
	/// <summary>
	/// Ŀ�ģ�Data_ReportManageDtsʵ�������
	/// ����:�ܸ���
	/// ��������:2012/4/16
	/// </summary>
	public sealed class ReportManageDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public ReportManageDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ReportManageDtsCtl(IDBTransAccess p_SqlCmd)
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
                ReportManageDts MasterEntity=(ReportManageDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_ReportManageDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DataSourceName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DataSourceName)+","); 
  				MasterField.Append("SqlName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SqlName)+",");
                MasterField.Append("OrderCondition" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.OrderCondition) + ","); 
  				MasterField.Append("SqlStr"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SqlStr)+","); 
  				MasterField.Append("QueryName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QueryName)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SqlFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SqlFlag)+","); 
  				MasterField.Append("SourceType"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SourceType)+")"); 
 
                
                

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
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)EnumMessage.CommonDBInsert), E);
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
                ReportManageDts MasterEntity=(ReportManageDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_ReportManageDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" DataSourceName="+SysString.ToDBString(MasterEntity.DataSourceName)+","); 
  				UpdateBuilder.Append(" SqlName="+SysString.ToDBString(MasterEntity.SqlName)+","); 
  				UpdateBuilder.Append(" SqlStr="+SysString.ToDBString(MasterEntity.SqlStr)+","); 
  				UpdateBuilder.Append(" QueryName="+SysString.ToDBString(MasterEntity.QueryName)+",");
                UpdateBuilder.Append(" OrderCondition=" + SysString.ToDBString(MasterEntity.OrderCondition) + ",");
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SqlFlag="+SysString.ToDBString(MasterEntity.SqlFlag)+","); 
  				UpdateBuilder.Append(" SourceType="+SysString.ToDBString(MasterEntity.SourceType)); 
 
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
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)EnumMessage.CommonDBUpdate), E);
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
                ReportManageDts MasterEntity=(ReportManageDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Data_ReportManageDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)EnumMessage.CommonDBDelete), E);
            }
        }
	}
}
