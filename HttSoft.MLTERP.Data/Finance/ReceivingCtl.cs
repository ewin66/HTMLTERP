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
	/// 目的：Finance_Receiving实体控制类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public sealed class ReceivingCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ReceivingCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ReceivingCtl(IDBTransAccess p_SqlCmd)
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
                Receiving MasterEntity=(Receiving)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_Receiving(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("ReceiveUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReceiveUnit)+","); 
  				MasterField.Append("ReceiveAmount"+","); 
  				if(MasterEntity.ReceiveAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceiveAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Currency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Currency)+","); 
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
  				MasterField.Append("ReceiveDate"+","); 
  				if(MasterEntity.ReceiveDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceiveDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceiveBank"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReceiveBank)+","); 
  				MasterField.Append("CutPayment"+","); 
  				if(MasterEntity.CutPayment!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CutPayment)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("Remark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+")"); 
 
                
                

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
                Receiving MasterEntity=(Receiving)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_Receiving SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" ReceiveUnit="+SysString.ToDBString(MasterEntity.ReceiveUnit)+","); 
  				 
  				if(MasterEntity.ReceiveAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceiveAmount="+SysString.ToDBString(MasterEntity.ReceiveAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceiveAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Currency="+SysString.ToDBString(MasterEntity.Currency)+","); 
  				 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Rate="+SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Rate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Handler="+SysString.ToDBString(MasterEntity.Handler)+","); 
  				 
  				if(MasterEntity.ReceiveDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReceiveDate="+SysString.ToDBString(MasterEntity.ReceiveDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceiveDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" ReceiveBank="+SysString.ToDBString(MasterEntity.ReceiveBank)+","); 
  				 
  				if(MasterEntity.CutPayment!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CutPayment="+SysString.ToDBString(MasterEntity.CutPayment)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CutPayment=null,");  
  				} 
  
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)); 
 
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
                Receiving MasterEntity=(Receiving)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Finance_Receiving WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
