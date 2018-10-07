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
	/// 目的：Sale_SaleOrderJS实体控制类
	/// 作者:周富春
	/// 创建日期:2015/8/5
	/// </summary>
	public sealed class SaleOrderJSCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderJSCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderJSCtl(IDBTransAccess p_SqlCmd)
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
                SaleOrderJS MasterEntity=(SaleOrderJS)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_SaleOrderJS(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SO)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("OrderAmount"+","); 
  				if(MasterEntity.OrderAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OrderAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CGAmount"+","); 
  				if(MasterEntity.CGAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CGAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RSAmount"+","); 
  				if(MasterEntity.RSAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RSAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZZAmount"+","); 
  				if(MasterEntity.ZZAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RZAmount"+","); 
  				if(MasterEntity.RZAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OtherAmount"+","); 
  				if(MasterEntity.OtherAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OtherAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LRAmount"+","); 
  				if(MasterEntity.LRAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LRAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RowIndex"+","); 
  				if(MasterEntity.RowIndex!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RowIndex)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("CBAmount"+","); 
  				if(MasterEntity.CBAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CBAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LRPer"+","); 
  				if(MasterEntity.LRPer!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LRPer)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HKAmount"+","); 
  				if(MasterEntity.HKAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HKAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YSAmount"+")"); 
  				if(MasterEntity.YSAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YSAmount)+")"); 
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
                SaleOrderJS MasterEntity=(SaleOrderJS)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_SaleOrderJS SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SO="+SysString.ToDBString(MasterEntity.SO)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				 
  				if(MasterEntity.OrderAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OrderAmount="+SysString.ToDBString(MasterEntity.OrderAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OrderAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.CGAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CGAmount="+SysString.ToDBString(MasterEntity.CGAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CGAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.RSAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RSAmount="+SysString.ToDBString(MasterEntity.RSAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RSAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZZAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZZAmount="+SysString.ToDBString(MasterEntity.ZZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZZAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.RZAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RZAmount="+SysString.ToDBString(MasterEntity.RZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RZAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.OtherAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OtherAmount="+SysString.ToDBString(MasterEntity.OtherAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OtherAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.LRAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LRAmount="+SysString.ToDBString(MasterEntity.LRAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LRAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.RowIndex!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RowIndex="+SysString.ToDBString(MasterEntity.RowIndex)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RowIndex=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.CBAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CBAmount="+SysString.ToDBString(MasterEntity.CBAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CBAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.LRPer!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LRPer="+SysString.ToDBString(MasterEntity.LRPer)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LRPer=null,");  
  				} 
  
  				 
  				if(MasterEntity.HKAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HKAmount="+SysString.ToDBString(MasterEntity.HKAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HKAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.YSAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YSAmount="+SysString.ToDBString(MasterEntity.YSAmount)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YSAmount=null");  
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
                SaleOrderJS MasterEntity=(SaleOrderJS)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_SaleOrderJS WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
