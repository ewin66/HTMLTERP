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
	/// 目的：Finance_CostRecord实体控制类
	/// 作者:xushoucheng
	/// 创建日期:2015/8/19
	/// </summary>
	public sealed class CostRecordCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CostRecordCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CostRecordCtl(IDBTransAccess p_SqlCmd)
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
                CostRecord MasterEntity=(CostRecord)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_CostRecord(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("OrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				MasterField.Append("CostType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CostType)+","); 
  				MasterField.Append("Amount"+","); 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SinglePrice"+","); 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CostContent"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CostContent)+","); 
  				MasterField.Append("InvoiceNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				MasterField.Append("InvoiceAmount"+","); 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AidNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AidNo)+","); 
  				MasterField.Append("InvoiceBalance"+","); 
  				if(MasterEntity.InvoiceBalance!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceBalance)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("SJAmount"+","); 
  				if(MasterEntity.SJAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SJAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Payment"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Payment)+")"); 
 
                
                

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
                CostRecord MasterEntity=(CostRecord)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_CostRecord SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" OrderFormNo="+SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				UpdateBuilder.Append(" CostType="+SysString.ToDBString(MasterEntity.CostType)+","); 
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" MakeOPName="+SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice="+SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" CostContent="+SysString.ToDBString(MasterEntity.CostContent)+","); 
  				UpdateBuilder.Append(" InvoiceNo="+SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount="+SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" AidNo="+SysString.ToDBString(MasterEntity.AidNo)+","); 
  				 
  				if(MasterEntity.InvoiceBalance!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceBalance="+SysString.ToDBString(MasterEntity.InvoiceBalance)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceBalance=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.SJAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SJAmount="+SysString.ToDBString(MasterEntity.SJAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SJAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Payment="+SysString.ToDBString(MasterEntity.Payment)); 
 
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
                CostRecord MasterEntity=(CostRecord)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Finance_CostRecord WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
