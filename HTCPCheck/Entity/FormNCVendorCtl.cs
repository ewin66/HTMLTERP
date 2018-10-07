using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;
using HttSoft.HTERP.Sys;

namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�Data_FormNCVendorʵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public sealed class FormNCVendorCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public FormNCVendorCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public FormNCVendorCtl(IDBTransAccess p_SqlCmd)
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
                FormNCVendor MasterEntity=(FormNCVendor)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_FormNCVendor(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("FNCVID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FNCVID)+","); 
  				MasterField.Append("CurSort"+","); 
  				if(MasterEntity.CurSort!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurSort)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CurYear"+","); 
  				if(MasterEntity.CurYear!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurYear)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CurMonth"+","); 
  				if(MasterEntity.CurMonth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurMonth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CurDay"+","); 
  				if(MasterEntity.CurDay!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CurDay)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
                FormNCVendor MasterEntity=(FormNCVendor)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_FormNCVendor SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" FNCVID="+SysString.ToDBString(MasterEntity.FNCVID)+","); 
  				 
  				if(MasterEntity.CurSort!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurSort="+SysString.ToDBString(MasterEntity.CurSort)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurSort=null,");  
  				} 
  
  				 
  				if(MasterEntity.CurYear!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurYear="+SysString.ToDBString(MasterEntity.CurYear)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurYear=null,");  
  				} 
  
  				 
  				if(MasterEntity.CurMonth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurMonth="+SysString.ToDBString(MasterEntity.CurMonth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurMonth=null,");  
  				} 
  
  				 
  				if(MasterEntity.CurDay!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CurDay="+SysString.ToDBString(MasterEntity.CurDay)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CurDay=null,");  
  				} 
  
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
                FormNCVendor MasterEntity=(FormNCVendor)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Data_FormNCVendor WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
