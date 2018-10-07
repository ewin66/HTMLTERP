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
	/// 目的：Data_ItemColorDts实体控制类
	/// 作者:陈加海
	/// 创建日期:2012-4-18
	/// </summary>
	public sealed class ItemColorDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ItemColorDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemColorDtsCtl(IDBTransAccess p_SqlCmd)
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
                ItemColorDts MasterEntity=(ItemColorDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_ItemColorDts(");
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
                MasterField.Append("VendorID" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID) + ",");
                MasterField.Append("DyePrice" + ",");
                if (MasterEntity.DyePrice != 0)
                {
                    MasterValue.Append(SysString.ToDBString(MasterEntity.DyePrice) + ",");
                }
                else
                {
                    MasterValue.Append("null,");
                }

                MasterField.Append("RS" + ")");
                if (MasterEntity.RS != 0)
                {
                    MasterValue.Append(SysString.ToDBString(MasterEntity.RS) + ")");
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
                ItemColorDts MasterEntity=(ItemColorDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_ItemColorDts SET ");
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
  			 		UpdateBuilder.Append(" YBPrice="+SysString.ToDBString(MasterEntity.YBPrice) + ","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YBPrice=null,");  
  				}
                UpdateBuilder.Append(" VendorID=" + SysString.ToDBString(MasterEntity.VendorID) + ",");

                if (MasterEntity.DyePrice != 0)
                {
                    UpdateBuilder.Append(" DyePrice=" + SysString.ToDBString(MasterEntity.DyePrice) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" DyePrice=null,");
                }


                if (MasterEntity.RS != 0)
                {
                    UpdateBuilder.Append(" RS=" + SysString.ToDBString(MasterEntity.RS));
                }
                else
                {
                    UpdateBuilder.Append(" RS=null");
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
                ItemColorDts MasterEntity=(ItemColorDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_ItemColorDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
