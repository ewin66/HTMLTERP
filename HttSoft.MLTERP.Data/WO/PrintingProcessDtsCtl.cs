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
	/// 目的：WO_PrintingProcessDts实体控制类
	/// 作者:翟晓东
	/// 创建日期:2012/8/22
	/// </summary>
	public sealed class PrintingProcessDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public PrintingProcessDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PrintingProcessDtsCtl(IDBTransAccess p_SqlCmd)
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
                PrintingProcessDts MasterEntity=(PrintingProcessDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_PrintingProcessDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("MWidth"+","); 
  				if(MasterEntity.MWidth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MWeight"+","); 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WeightUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("SingPrice"+","); 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SingPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Amount"+","); 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedDate"+","); 
  				if(MasterEntity.ReceivedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedQty"+","); 
  				if(MasterEntity.ReceivedQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalRecQty"+","); 
  				if(MasterEntity.TotalRecQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalRecQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RemainQty"+","); 
  				if(MasterEntity.RemainQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RemainQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RemainRate"+","); 
  				if(MasterEntity.RemainRate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RemainRate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsReqDate"+","); 
  				if(MasterEntity.DtsReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DtsReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("OrderPreStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderPreStatusID)+","); 
  				MasterField.Append("OrderStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderStatusID)+","); 
  				MasterField.Append("DtsSO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				MasterField.Append("DVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				MasterField.Append("JarNum"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+")"); 
 
                
                

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
                PrintingProcessDts MasterEntity=(PrintingProcessDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_PrintingProcessDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				 
  				if(MasterEntity.MWidth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWidth=null,");  
  				} 
  
  				 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" WeightUnit="+SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice="+SysString.ToDBString(MasterEntity.SingPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedDate="+SysString.ToDBString(MasterEntity.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedQty="+SysString.ToDBString(MasterEntity.ReceivedQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalRecQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecQty="+SysString.ToDBString(MasterEntity.TotalRecQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.RemainQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RemainQty="+SysString.ToDBString(MasterEntity.RemainQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RemainQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.RemainRate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RemainRate="+SysString.ToDBString(MasterEntity.RemainRate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RemainRate=null,");  
  				} 
  
  				 
  				if(MasterEntity.DtsReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" DtsReqDate="+SysString.ToDBString(MasterEntity.DtsReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DtsReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" OrderPreStatusID="+SysString.ToDBString(MasterEntity.OrderPreStatusID)+","); 
  				UpdateBuilder.Append(" OrderStatusID="+SysString.ToDBString(MasterEntity.OrderStatusID)+","); 
  				UpdateBuilder.Append(" DtsSO="+SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				UpdateBuilder.Append(" DVendorID="+SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)); 
 
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
                PrintingProcessDts MasterEntity=(PrintingProcessDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_PrintingProcessDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
