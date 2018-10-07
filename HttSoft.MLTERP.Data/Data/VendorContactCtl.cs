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
	/// 目的：Data_VendorContact实体控制类
	/// 作者:章文强
	/// 创建日期:2014/11/3
	/// </summary>
	public sealed class VendorContactCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public VendorContactCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorContactCtl(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		
		/// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int AddNew(BaseEntity p_Entity)
        {
            try
            {
                VendorContact MasterEntity=(VendorContact)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_VendorContact(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("Name"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Name)+","); 
  				MasterField.Append("FL"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FL)+","); 
  				MasterField.Append("TEL"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TEL)+","); 
  				MasterField.Append("FAX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FAX)+","); 
  				MasterField.Append("Mobil"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Mobil)+","); 
  				MasterField.Append("SubTel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubTel)+","); 
  				MasterField.Append("Dep"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Dep)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("Birthday"+","); 
  				if(MasterEntity.Birthday!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Birthday.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SpecialDay"+","); 
  				if(MasterEntity.SpecialDay!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SpecialDay.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BirthdayNoAlarmFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BirthdayNoAlarmFlag)+","); 
  				MasterField.Append("TELTwo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TELTwo)+","); 
  				MasterField.Append("TELThree"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TELThree)+","); 
  				MasterField.Append("QQ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QQ)+","); 
  				MasterField.Append("Email"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Email)+","); 
  				MasterField.Append("FreeStr"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr)+","); 
  				MasterField.Append("ContactEn"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ContactEn)+")"); 
 
                
                

                //执行
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
        /// 修改
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Update(BaseEntity p_Entity)
        {
            try
            {
                VendorContact MasterEntity=(VendorContact)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_VendorContact SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" Name="+SysString.ToDBString(MasterEntity.Name)+","); 
  				UpdateBuilder.Append(" FL="+SysString.ToDBString(MasterEntity.FL)+","); 
  				UpdateBuilder.Append(" TEL="+SysString.ToDBString(MasterEntity.TEL)+","); 
  				UpdateBuilder.Append(" FAX="+SysString.ToDBString(MasterEntity.FAX)+","); 
  				UpdateBuilder.Append(" Mobil="+SysString.ToDBString(MasterEntity.Mobil)+","); 
  				UpdateBuilder.Append(" SubTel="+SysString.ToDBString(MasterEntity.SubTel)+","); 
  				UpdateBuilder.Append(" Dep="+SysString.ToDBString(MasterEntity.Dep)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.Birthday!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" Birthday="+SysString.ToDBString(MasterEntity.Birthday.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Birthday=null,");  
  				} 
  
  				 
  				if(MasterEntity.SpecialDay!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SpecialDay="+SysString.ToDBString(MasterEntity.SpecialDay.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SpecialDay=null,");  
  				} 
  
  				UpdateBuilder.Append(" BirthdayNoAlarmFlag="+SysString.ToDBString(MasterEntity.BirthdayNoAlarmFlag)+","); 
  				UpdateBuilder.Append(" TELTwo="+SysString.ToDBString(MasterEntity.TELTwo)+","); 
  				UpdateBuilder.Append(" TELThree="+SysString.ToDBString(MasterEntity.TELThree)+","); 
  				UpdateBuilder.Append(" QQ="+SysString.ToDBString(MasterEntity.QQ)+","); 
  				UpdateBuilder.Append(" Email="+SysString.ToDBString(MasterEntity.Email)+","); 
  				UpdateBuilder.Append(" FreeStr="+SysString.ToDBString(MasterEntity.FreeStr)+","); 
  				UpdateBuilder.Append(" ContactEn="+SysString.ToDBString(MasterEntity.ContactEn)); 
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                

               //执行
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
        /// 删除
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Delete(BaseEntity p_Entity)
        {
            try
            {
                VendorContact MasterEntity=(VendorContact)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_VendorContact WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
                //执行
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
