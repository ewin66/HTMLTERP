using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;

namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// 目的：WH_WH实体控制类
	/// 作者:陈加海
	/// 创建日期:2012/5/10
	/// </summary>
	public sealed class WHCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public WHCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WHCtl(IDBTransAccess p_SqlCmd)
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
                WH MasterEntity=(WH)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_WH(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("WHNM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHNM)+","); 
  				MasterField.Append("WHType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHType)+","); 
  				MasterField.Append("WHStartDate"+","); 
  				if(MasterEntity.WHStartDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WHStartDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WHCalMethodID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHCalMethodID)+","); 
  				MasterField.Append("IsUseable"+","); 
  				if(MasterEntity.IsUseable!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.IsUseable)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("WHPosMethodID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHPosMethodID)+","); 
  				MasterField.Append("ItemUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("ISJK"+")"); 
  				if(MasterEntity.ISJK!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ISJK)+")"); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null)"); 
  				} 
  
 
                
                

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
                WH MasterEntity=(WH)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_WH SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" WHNM="+SysString.ToDBString(MasterEntity.WHNM)+","); 
  				UpdateBuilder.Append(" WHType="+SysString.ToDBString(MasterEntity.WHType)+","); 
  				 
  				if(MasterEntity.WHStartDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" WHStartDate="+SysString.ToDBString(MasterEntity.WHStartDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WHStartDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" WHCalMethodID="+SysString.ToDBString(MasterEntity.WHCalMethodID)+","); 
  				 
  				if(MasterEntity.IsUseable!=0) 
  				{ 
  			 		UpdateBuilder.Append(" IsUseable="+SysString.ToDBString(MasterEntity.IsUseable)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" IsUseable=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" WHPosMethodID="+SysString.ToDBString(MasterEntity.WHPosMethodID)+","); 
  				UpdateBuilder.Append(" ItemUnit="+SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				 
  				if(MasterEntity.ISJK!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ISJK="+SysString.ToDBString(MasterEntity.ISJK)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ISJK=null");  
  				} 
  
 
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
                WH MasterEntity=(WH)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_WH WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
