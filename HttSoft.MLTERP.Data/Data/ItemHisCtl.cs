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
	/// 目的：Data_ItemHis实体控制类
	/// 作者:陈加海
	/// 创建日期:2012-4-18
	/// </summary>
	public sealed class ItemHisCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ItemHisCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemHisCtl(IDBTransAccess p_SqlCmd)
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
                ItemHis MasterEntity=(ItemHis)p_Entity;
                if (MasterEntity.ItemCode=="")
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_ItemHis(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemTypeID)+","); 
  				MasterField.Append("ItemClassID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemClassID)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				MasterField.Append("ItemAttnCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemAttnCode)+","); 
  				MasterField.Append("IsDevide"+","); 
  				if(MasterEntity.IsDevide!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.IsDevide)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("ItemNameEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemNameEn)+","); 
  				MasterField.Append("ItemStdEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStdEn)+","); 
  				MasterField.Append("BuyShopID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BuyShopID)+","); 
  				MasterField.Append("BuyUnitPrice"+","); 
  				if(MasterEntity.BuyUnitPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BuyUnitPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("ItemrSeason"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemrSeason)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("ItemCW"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCW)+","); 
  				MasterField.Append("NewFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NewFlag)+","); 
  				MasterField.Append("CDate"+")"); 
  				if(MasterEntity.CDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CDate.ToString("yyyy-MM-dd HH:mm:ss"))+")"); 
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
                ItemHis MasterEntity=(ItemHis)p_Entity;
                if (MasterEntity.ItemCode=="")
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_ItemHis SET ");
                UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemTypeID="+SysString.ToDBString(MasterEntity.ItemTypeID)+","); 
  				UpdateBuilder.Append(" ItemClassID="+SysString.ToDBString(MasterEntity.ItemClassID)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemUnit="+SysString.ToDBString(MasterEntity.ItemUnit)+","); 
  				UpdateBuilder.Append(" ItemAttnCode="+SysString.ToDBString(MasterEntity.ItemAttnCode)+","); 
  				 
  				if(MasterEntity.IsDevide!=0) 
  				{ 
  			 		UpdateBuilder.Append(" IsDevide="+SysString.ToDBString(MasterEntity.IsDevide)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" IsDevide=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" ItemNameEn="+SysString.ToDBString(MasterEntity.ItemNameEn)+","); 
  				UpdateBuilder.Append(" ItemStdEn="+SysString.ToDBString(MasterEntity.ItemStdEn)+","); 
  				UpdateBuilder.Append(" BuyShopID="+SysString.ToDBString(MasterEntity.BuyShopID)+","); 
  				 
  				if(MasterEntity.BuyUnitPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BuyUnitPrice="+SysString.ToDBString(MasterEntity.BuyUnitPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BuyUnitPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" ItemrSeason="+SysString.ToDBString(MasterEntity.ItemrSeason)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" ItemCW="+SysString.ToDBString(MasterEntity.ItemCW)+","); 
  				UpdateBuilder.Append(" NewFlag="+SysString.ToDBString(MasterEntity.NewFlag)+","); 
  				 
  				if(MasterEntity.CDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CDate="+SysString.ToDBString(MasterEntity.CDate.ToString("yyyy-MM-dd HH:mm:ss"))); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CDate=null");  
  				} 
  
 
                UpdateBuilder.Append(" WHERE "+ "ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+" AND ItemName="+SysString.ToDBString(MasterEntity.ItemName)+" AND ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+" AND ItemModel="+SysString.ToDBString(MasterEntity.ItemModel));
                
                

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
                ItemHis MasterEntity=(ItemHis)p_Entity;
                if (MasterEntity.ItemCode=="")
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_ItemHis WHERE "+ "ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+" AND ItemName="+SysString.ToDBString(MasterEntity.ItemName)+" AND ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+" AND ItemModel="+SysString.ToDBString(MasterEntity.ItemModel);
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
