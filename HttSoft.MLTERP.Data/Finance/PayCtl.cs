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
	/// Ŀ�ģ�Finance_Payʵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public sealed class PayCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public PayCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public PayCtl(IDBTransAccess p_SqlCmd)
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
                Pay MasterEntity=(Pay)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_Pay(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("PayUnitId"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayUnitId)+","); 
  				MasterField.Append("PayAmount"+","); 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MoneyType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MoneyType)+","); 
  				MasterField.Append("Rate"+","); 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Handler"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Handler)+","); 
  				MasterField.Append("PayDate"+","); 
  				if(MasterEntity.PayDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PayDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PayBank"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayBank)+","); 
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
                Pay MasterEntity=(Pay)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_Pay SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" PayUnitId="+SysString.ToDBString(MasterEntity.PayUnitId)+","); 
  				 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount="+SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" MoneyType="+SysString.ToDBString(MasterEntity.MoneyType)+","); 
  				 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Rate="+SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Rate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Handler="+SysString.ToDBString(MasterEntity.Handler)+","); 
  				 
  				if(MasterEntity.PayDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" PayDate="+SysString.ToDBString(MasterEntity.PayDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PayDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" PayBank="+SysString.ToDBString(MasterEntity.PayBank)+","); 
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
                Pay MasterEntity=(Pay)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Finance_Pay WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
