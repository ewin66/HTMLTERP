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
	/// 目的：Data_ItemColorDtsHis实体控制类
	/// 作者:tanghao
	/// 创建日期:2015/5/27
	/// </summary>
	public sealed class ItemColorDtsHisCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ItemColorDtsHisCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemColorDtsHisCtl(IDBTransAccess p_SqlCmd)
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
                ItemColorDtsHis MasterEntity=(ItemColorDtsHis)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_ItemColorDtsHis(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("BuyPrice"+","); 
  				if(MasterEntity.BuyPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BuyPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BuyPriceDate"+","); 
  				if(MasterEntity.BuyPriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BuyPriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SalePrice"+","); 
  				if(MasterEntity.SalePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SalePriceDate"+","); 
  				if(MasterEntity.SalePriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SalePriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("DHPrice"+","); 
  				if(MasterEntity.DHPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DHPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("XHPrice"+","); 
  				if(MasterEntity.XHPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.XHPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YBPrice"+","); 
  				if(MasterEntity.YBPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBPrice"+","); 
  				if(MasterEntity.PBPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBPriceDate"+","); 
  				if(MasterEntity.PBPriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBPriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBSalePrice"+","); 
  				if(MasterEntity.PBSalePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBSalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBSalePriceDate"+","); 
  				if(MasterEntity.PBSalePriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBSalePriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeStr1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				MasterField.Append("FreeNum1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeNum1)+","); 
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("ColorPrice"+","); 
  				if(MasterEntity.ColorPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ColorPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZLPrice"+","); 
  				if(MasterEntity.ZLPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZLPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPriceUSB"+","); 
  				if(MasterEntity.TotalPriceUSB!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPriceUSB)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ExchangeRate"+","); 
  				if(MasterEntity.ExchangeRate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ExchangeRate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPriceRMB"+","); 
  				if(MasterEntity.TotalPriceRMB!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPriceRMB)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CBPrice"+","); 
  				if(MasterEntity.CBPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JGPrice"+","); 
  				if(MasterEntity.JGPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JGPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPrice"+","); 
  				if(MasterEntity.TotalPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RFPrice"+","); 
  				if(MasterEntity.RFPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RFPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZXBJDate"+","); 
  				if(MasterEntity.ZXBJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZXBJDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Shrinkage"+")"); 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Shrinkage)+")"); 
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
                ItemColorDtsHis MasterEntity=(ItemColorDtsHis)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_ItemColorDtsHis SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				 
  				if(MasterEntity.BuyPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BuyPrice="+SysString.ToDBString(MasterEntity.BuyPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BuyPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.BuyPriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" BuyPriceDate="+SysString.ToDBString(MasterEntity.BuyPriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BuyPriceDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.SalePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SalePrice="+SysString.ToDBString(MasterEntity.SalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SalePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.SalePriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SalePriceDate="+SysString.ToDBString(MasterEntity.SalePriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SalePriceDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.DHPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DHPrice="+SysString.ToDBString(MasterEntity.DHPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DHPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.XHPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" XHPrice="+SysString.ToDBString(MasterEntity.XHPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" XHPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.YBPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YBPrice="+SysString.ToDBString(MasterEntity.YBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YBPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBPrice="+SysString.ToDBString(MasterEntity.PBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBPriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" PBPriceDate="+SysString.ToDBString(MasterEntity.PBPriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBPriceDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBSalePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBSalePrice="+SysString.ToDBString(MasterEntity.PBSalePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBSalePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBSalePriceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" PBSalePriceDate="+SysString.ToDBString(MasterEntity.PBSalePriceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBSalePriceDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" FreeStr1="+SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				UpdateBuilder.Append(" FreeNum1="+SysString.ToDBString(MasterEntity.FreeNum1)+","); 
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.ColorPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ColorPrice="+SysString.ToDBString(MasterEntity.ColorPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ColorPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZLPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZLPrice="+SysString.ToDBString(MasterEntity.ZLPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZLPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPriceUSB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceUSB="+SysString.ToDBString(MasterEntity.TotalPriceUSB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceUSB=null,");  
  				} 
  
  				 
  				if(MasterEntity.ExchangeRate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ExchangeRate="+SysString.ToDBString(MasterEntity.ExchangeRate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ExchangeRate=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPriceRMB!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceRMB="+SysString.ToDBString(MasterEntity.TotalPriceRMB)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPriceRMB=null,");  
  				} 
  
  				 
  				if(MasterEntity.CBPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CBPrice="+SysString.ToDBString(MasterEntity.CBPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CBPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.JGPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JGPrice="+SysString.ToDBString(MasterEntity.JGPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JGPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPrice="+SysString.ToDBString(MasterEntity.TotalPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.RFPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RFPrice="+SysString.ToDBString(MasterEntity.RFPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RFPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZXBJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ZXBJDate="+SysString.ToDBString(MasterEntity.ZXBJDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZXBJDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage="+SysString.ToDBString(MasterEntity.Shrinkage)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage=null");  
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
                ItemColorDtsHis MasterEntity=(ItemColorDtsHis)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_ItemColorDtsHis WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
