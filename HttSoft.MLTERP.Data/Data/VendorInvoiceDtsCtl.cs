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
	/// Ŀ�ģ�Data_VendorInvoiceDtsʵ�������
	/// ����:����ǿ
	/// ��������:2014/11/12
	/// </summary>
	public sealed class VendorInvoiceDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public VendorInvoiceDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public VendorInvoiceDtsCtl(IDBTransAccess p_SqlCmd)
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
                VendorInvoiceDts MasterEntity=(VendorInvoiceDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_VendorInvoiceDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("CompName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompName)+","); 
  				MasterField.Append("TaxNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TaxNo)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("Tel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Tel)+","); 
  				MasterField.Append("Bank"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Bank)+","); 
  				MasterField.Append("No"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.No)+","); 
  				MasterField.Append("DRemark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DRemark)+")"); 
 
                
                

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
                VendorInvoiceDts MasterEntity=(VendorInvoiceDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_VendorInvoiceDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" CompName="+SysString.ToDBString(MasterEntity.CompName)+","); 
  				UpdateBuilder.Append(" TaxNo="+SysString.ToDBString(MasterEntity.TaxNo)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" Tel="+SysString.ToDBString(MasterEntity.Tel)+","); 
  				UpdateBuilder.Append(" Bank="+SysString.ToDBString(MasterEntity.Bank)+","); 
  				UpdateBuilder.Append(" No="+SysString.ToDBString(MasterEntity.No)+","); 
  				UpdateBuilder.Append(" DRemark="+SysString.ToDBString(MasterEntity.DRemark)); 
 
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
                VendorInvoiceDts MasterEntity=(VendorInvoiceDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM Data_VendorInvoiceDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
