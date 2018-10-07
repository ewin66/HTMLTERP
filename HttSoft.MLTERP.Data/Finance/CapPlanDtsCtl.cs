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
	/// 目的：Finance_CapPlanDts实体控制类
	/// 作者:章文强
	/// 创建日期:2012/9/4
	/// </summary>
	public sealed class CapPlanDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CapPlanDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CapPlanDtsCtl(IDBTransAccess p_SqlCmd)
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
                CapPlanDts MasterEntity=(CapPlanDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_CapPlanDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("InvoiceAmount"+","); 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("NoInvoiceAmount"+","); 
  				if(MasterEntity.NoInvoiceAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NoInvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalNeedPay"+","); 
  				if(MasterEntity.TotalNeedPay!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalNeedPay)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PlanInvoiceAmount"+","); 
  				if(MasterEntity.PlanInvoiceAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PlanInvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PlanRecAmount"+","); 
  				if(MasterEntity.PlanRecAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PlanRecAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PlanLeaveAmount"+","); 
  				if(MasterEntity.PlanLeaveAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PlanLeaveAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PlanSaleAmount"+","); 
  				if(MasterEntity.PlanSaleAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PlanSaleAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("NoInvoiceQty"+")"); 
  				if(MasterEntity.NoInvoiceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NoInvoiceQty)+")"); 
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
                CapPlanDts MasterEntity=(CapPlanDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_CapPlanDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount="+SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.NoInvoiceAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NoInvoiceAmount="+SysString.ToDBString(MasterEntity.NoInvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NoInvoiceAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalNeedPay!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalNeedPay="+SysString.ToDBString(MasterEntity.TotalNeedPay)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalNeedPay=null,");  
  				} 
  
  				 
  				if(MasterEntity.PlanInvoiceAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PlanInvoiceAmount="+SysString.ToDBString(MasterEntity.PlanInvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PlanInvoiceAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.PlanRecAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PlanRecAmount="+SysString.ToDBString(MasterEntity.PlanRecAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PlanRecAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.PlanLeaveAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PlanLeaveAmount="+SysString.ToDBString(MasterEntity.PlanLeaveAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PlanLeaveAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.PlanSaleAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PlanSaleAmount="+SysString.ToDBString(MasterEntity.PlanSaleAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PlanSaleAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.NoInvoiceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NoInvoiceQty="+SysString.ToDBString(MasterEntity.NoInvoiceQty)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NoInvoiceQty=null");  
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
                CapPlanDts MasterEntity=(CapPlanDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Finance_CapPlanDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
