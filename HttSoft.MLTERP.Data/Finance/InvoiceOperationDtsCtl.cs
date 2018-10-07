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
	/// 目的：Finance_InvoiceOperationDts实体控制类
	/// 作者:xushoucheng
	/// 创建日期:2015/8/17
	/// </summary>
	public sealed class InvoiceOperationDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public InvoiceOperationDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public InvoiceOperationDtsCtl(IDBTransAccess p_SqlCmd)
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
                InvoiceOperationDts MasterEntity=(InvoiceOperationDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_InvoiceOperationDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DLOADID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADID)+","); 
  				MasterField.Append("DLOADSEQ"+","); 
  				if(MasterEntity.DLOADSEQ!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADSEQ)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DLOADNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADNO)+","); 
  				MasterField.Append("DLOADDtsID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADDtsID)+","); 
  				MasterField.Append("DInvoiceQty"+","); 
  				if(MasterEntity.DInvoiceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DInvoiceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DInvoiceSinglePrice"+","); 
  				if(MasterEntity.DInvoiceSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DInvoiceSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DInvoiceAmount"+","); 
  				if(MasterEntity.DInvoiceAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DInvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("PayAmount"+","); 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DInvoiceTaxAmount"+","); 
  				if(MasterEntity.DInvoiceTaxAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DInvoiceTaxAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("DLoadCheckDtsID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLoadCheckDtsID)+","); 
  				MasterField.Append("DInvoiceDYPrice"+","); 
  				if(MasterEntity.DInvoiceDYPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DInvoiceDYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("MergeFlage"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MergeFlage)+")"); 
 
                
                

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
                InvoiceOperationDts MasterEntity=(InvoiceOperationDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_InvoiceOperationDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" DLOADID="+SysString.ToDBString(MasterEntity.DLOADID)+","); 
  				 
  				if(MasterEntity.DLOADSEQ!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DLOADSEQ="+SysString.ToDBString(MasterEntity.DLOADSEQ)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DLOADSEQ=null,");  
  				} 
  
  				UpdateBuilder.Append(" DLOADNO="+SysString.ToDBString(MasterEntity.DLOADNO)+","); 
  				UpdateBuilder.Append(" DLOADDtsID="+SysString.ToDBString(MasterEntity.DLOADDtsID)+","); 
  				 
  				if(MasterEntity.DInvoiceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceQty="+SysString.ToDBString(MasterEntity.DInvoiceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.DInvoiceSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceSinglePrice="+SysString.ToDBString(MasterEntity.DInvoiceSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.DInvoiceAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceAmount="+SysString.ToDBString(MasterEntity.DInvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount="+SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.DInvoiceTaxAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceTaxAmount="+SysString.ToDBString(MasterEntity.DInvoiceTaxAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceTaxAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" DLoadCheckDtsID="+SysString.ToDBString(MasterEntity.DLoadCheckDtsID)+","); 
  				 
  				if(MasterEntity.DInvoiceDYPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceDYPrice="+SysString.ToDBString(MasterEntity.DInvoiceDYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DInvoiceDYPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				UpdateBuilder.Append(" MergeFlage="+SysString.ToDBString(MasterEntity.MergeFlage)); 
 
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
                InvoiceOperationDts MasterEntity=(InvoiceOperationDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Finance_InvoiceOperationDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
