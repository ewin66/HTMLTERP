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
	/// 目的：Sale_ProductionNoticeDts实体控制类
	/// 作者:章文强
	/// 创建日期:2014/12/3
	/// </summary>
	public sealed class ProductionNoticeDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ProductionNoticeDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionNoticeDtsCtl(IDBTransAccess p_SqlCmd)
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
                ProductionNoticeDts MasterEntity=(ProductionNoticeDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_ProductionNoticeDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("SO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SO)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("ConfirmSample"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ConfirmSample)+","); 
  				MasterField.Append("SOQty"+","); 
  				if(MasterEntity.SOQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SOQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPQty"+","); 
  				if(MasterEntity.CPQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CPQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TPQty"+","); 
  				if(MasterEntity.TPQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TPQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("DRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DRemark)+","); 
  				MasterField.Append("Shrinkage"+","); 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("Flower"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Flower)+","); 
  				MasterField.Append("LoadID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LoadID)+","); 
  				MasterField.Append("TBCPQty"+","); 
  				if(MasterEntity.TBCPQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TBCPQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FactoryID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				MasterField.Append("ReqDate"+","); 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MaxQty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MaxQty)+","); 
  				MasterField.Append("MainQty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainQty)+","); 
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("OutRange"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutRange)+",");
                MasterField.Append("Needle" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.Needle) + ","); 
  				MasterField.Append("VItemCode"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+")"); 
 
                
                

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
                ProductionNoticeDts MasterEntity=(ProductionNoticeDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_ProductionNoticeDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" SO="+SysString.ToDBString(MasterEntity.SO)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" ConfirmSample="+SysString.ToDBString(MasterEntity.ConfirmSample)+","); 
  				 
  				if(MasterEntity.SOQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SOQty="+SysString.ToDBString(MasterEntity.SOQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SOQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CPQty="+SysString.ToDBString(MasterEntity.CPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TPQty="+SysString.ToDBString(MasterEntity.TPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TPQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+",");
                UpdateBuilder.Append(" MWeight="+ SysString.ToDBString(MasterEntity.MWeight) + ",");
                UpdateBuilder.Append(" Needle=" + SysString.ToDBString(MasterEntity.Needle) + ","); 
  				UpdateBuilder.Append(" DRemark="+SysString.ToDBString(MasterEntity.DRemark)+","); 
  				 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage="+SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage=null,");  
  				} 
  
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" Flower="+SysString.ToDBString(MasterEntity.Flower)+","); 
  				UpdateBuilder.Append(" LoadID="+SysString.ToDBString(MasterEntity.LoadID)+","); 
  				 
  				if(MasterEntity.TBCPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TBCPQty="+SysString.ToDBString(MasterEntity.TBCPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TBCPQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" FactoryID="+SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate="+SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" MaxQty="+SysString.ToDBString(MasterEntity.MaxQty)+","); 
  				UpdateBuilder.Append(" MainQty="+SysString.ToDBString(MasterEntity.MainQty)+","); 
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" OutRange="+SysString.ToDBString(MasterEntity.OutRange)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)); 
 
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
                ProductionNoticeDts MasterEntity=(ProductionNoticeDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_ProductionNoticeDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
