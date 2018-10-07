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
	/// 目的：Sale_AuditPrice实体控制类
	/// 作者:曹小艮
	/// 创建日期:2011-12-30
	/// </summary>
	public sealed class AuditPriceCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public AuditPriceCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public AuditPriceCtl(IDBTransAccess p_SqlCmd)
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
                AuditPrice MasterEntity=(AuditPrice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_AuditPrice(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("ProductCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProductCode)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("ProductName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProductName)+","); 
  				MasterField.Append("Equipment"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Equipment)+","); 
  				MasterField.Append("ProductGY"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProductGY)+","); 
  				MasterField.Append("ProductRSGY"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProductRSGY)+","); 
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
  
  				MasterField.Append("JSOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JSOPID)+","); 
  				MasterField.Append("SHOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SHOPID)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("PPrice"+","); 
  				if(MasterEntity.PPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PDatetime"+","); 
  				if(MasterEntity.PDatetime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PDatetime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SPrice"+","); 
  				if(MasterEntity.SPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SDatetime"+","); 
  				if(MasterEntity.SDatetime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SDatetime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemAmount"+","); 
  				if(MasterEntity.ItemAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ItemAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OthAmount"+","); 
  				if(MasterEntity.OthAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OthAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ColorAmount"+","); 
  				if(MasterEntity.ColorAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ColorAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DTAmount"+","); 
  				if(MasterEntity.DTAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DTAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DTSHAmount"+","); 
  				if(MasterEntity.DTSHAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DTSHAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("STPrice"+")"); 
  				if(MasterEntity.STPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.STPrice)+")"); 
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
                AuditPrice MasterEntity=(AuditPrice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_AuditPrice SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" ProductCode="+SysString.ToDBString(MasterEntity.ProductCode)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" ProductName="+SysString.ToDBString(MasterEntity.ProductName)+","); 
  				UpdateBuilder.Append(" Equipment="+SysString.ToDBString(MasterEntity.Equipment)+","); 
  				UpdateBuilder.Append(" ProductGY="+SysString.ToDBString(MasterEntity.ProductGY)+","); 
  				UpdateBuilder.Append(" ProductRSGY="+SysString.ToDBString(MasterEntity.ProductRSGY)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" JSOPID="+SysString.ToDBString(MasterEntity.JSOPID)+","); 
  				UpdateBuilder.Append(" SHOPID="+SysString.ToDBString(MasterEntity.SHOPID)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.PPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PPrice="+SysString.ToDBString(MasterEntity.PPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.PDatetime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" PDatetime="+SysString.ToDBString(MasterEntity.PDatetime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PDatetime=null,");  
  				} 
  
  				 
  				if(MasterEntity.SPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SPrice="+SysString.ToDBString(MasterEntity.SPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.SDatetime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SDatetime="+SysString.ToDBString(MasterEntity.SDatetime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SDatetime=null,");  
  				} 
  
  				 
  				if(MasterEntity.ItemAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ItemAmount="+SysString.ToDBString(MasterEntity.ItemAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ItemAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.OthAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OthAmount="+SysString.ToDBString(MasterEntity.OthAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OthAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ColorAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ColorAmount="+SysString.ToDBString(MasterEntity.ColorAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ColorAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.DTAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DTAmount="+SysString.ToDBString(MasterEntity.DTAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DTAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.DTSHAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DTSHAmount="+SysString.ToDBString(MasterEntity.DTSHAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DTSHAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.STPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" STPrice="+SysString.ToDBString(MasterEntity.STPrice)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" STPrice=null");  
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
                AuditPrice MasterEntity=(AuditPrice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_AuditPrice WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
