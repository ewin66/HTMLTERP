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
	/// Ŀ�ģ�WH_SBitʵ�������
	/// ����:xushoucheng
	/// ��������:2015/11/20
	/// </summary>
	public sealed class SBitCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public SBitCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public SBitCtl(IDBTransAccess p_SqlCmd)
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
                SBit MasterEntity=(SBit)p_Entity;
                if (MasterEntity.SBitID=="")
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_SBit(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("SubSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
  				MasterField.Append("SBitID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SBitID)+","); 
  				MasterField.Append("IsUseable"+","); 
  				if(MasterEntity.IsUseable!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.IsUseable)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WeightMax"+","); 
  				if(MasterEntity.WeightMax!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WeightMax)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BulkMax"+","); 
  				if(MasterEntity.BulkMax!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BulkMax)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SBitISN"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SBitISN)+")"); 
 
                
                

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
                SBit MasterEntity=(SBit)p_Entity;
                if (MasterEntity.SBitID=="")
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_SBit SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" SubSeq="+SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				UpdateBuilder.Append(" SBitID="+SysString.ToDBString(MasterEntity.SBitID)+","); 
  				 
  				if(MasterEntity.IsUseable!=0) 
  				{ 
  			 		UpdateBuilder.Append(" IsUseable="+SysString.ToDBString(MasterEntity.IsUseable)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" IsUseable=null,");  
  				} 
  
  				 
  				if(MasterEntity.WeightMax!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WeightMax="+SysString.ToDBString(MasterEntity.WeightMax)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WeightMax=null,");  
  				} 
  
  				 
  				if(MasterEntity.BulkMax!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BulkMax="+SysString.ToDBString(MasterEntity.BulkMax)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BulkMax=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SBitISN="+SysString.ToDBString(MasterEntity.SBitISN)); 
 
                UpdateBuilder.Append(" WHERE "+ "SBitID="+SysString.ToDBString(MasterEntity.SBitID));
                
                

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
                SBit MasterEntity=(SBit)p_Entity;
                if (MasterEntity.SBitID=="")
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM WH_SBit WHERE "+ "SBitID="+SysString.ToDBString(MasterEntity.SBitID);
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
