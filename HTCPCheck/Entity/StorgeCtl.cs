using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;

namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// 目的：WH_Storge实体控制类
	/// 作者:周富春
	/// 创建日期:2014/10/17
	/// </summary>
	public sealed class StorgeCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public StorgeCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public StorgeCtl(IDBTransAccess p_SqlCmd)
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
                Storge MasterEntity=(Storge)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_Storge(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
  				MasterField.Append("SBitID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SBitID)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("CustomerID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CustomerID)+","); 
  				MasterField.Append("WHType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHType)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("VendorBatch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				MasterField.Append("Twist"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Twist)+","); 
  				MasterField.Append("YarnType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YarnType)+","); 
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TubeGW"+","); 
  				if(MasterEntity.TubeGW!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TubeGW)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TubeQty"+","); 
  				if(MasterEntity.TubeQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TubeQty)+","); 
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
  
  				MasterField.Append("LockQty"+","); 
  				if(MasterEntity.LockQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LockQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeQty"+","); 
  				if(MasterEntity.FreeQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Needle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+","); 
  				MasterField.Append("SinglePrice"+","); 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SinglePrice)+","); 
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
  
  				MasterField.Append("PieceQty"+","); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("JarNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNo)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("SO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SO)+","); 
  				MasterField.Append("LastUpdTime"+","); 
  				if(MasterEntity.LastUpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LastUpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LastUpdOP"+","); 
  				if(MasterEntity.LastUpdOP!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LastUpdOP.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("Indate"+","); 
  				if(MasterEntity.Indate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Indate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DutyOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DutyOPID)+","); 
  				MasterField.Append("CostPrice"+","); 
  				if(MasterEntity.CostPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CostPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WHQualityFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHQualityFlag)+","); 
  				MasterField.Append("WHQualityFFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHQualityFFlag)+","); 
  				MasterField.Append("WHXiePianFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHXiePianFlag)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("GoodsLevel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
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
  				MasterField.Append("OrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				MasterField.Append("MLType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MLType)+","); 
  				MasterField.Append("PDDate"+","); 
  				if(MasterEntity.PDDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PDDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PDFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PDFlag)+","); 
  				MasterField.Append("DVendorID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DVendorID)+")"); 
 
                
                

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
                Storge MasterEntity=(Storge)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_Storge SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				UpdateBuilder.Append(" SBitID="+SysString.ToDBString(MasterEntity.SBitID)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" CustomerID="+SysString.ToDBString(MasterEntity.CustomerID)+","); 
  				UpdateBuilder.Append(" WHType="+SysString.ToDBString(MasterEntity.WHType)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" VendorBatch="+SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				UpdateBuilder.Append(" Twist="+SysString.ToDBString(MasterEntity.Twist)+","); 
  				UpdateBuilder.Append(" YarnType="+SysString.ToDBString(MasterEntity.YarnType)+","); 
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				 
  				if(MasterEntity.TubeGW!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TubeGW="+SysString.ToDBString(MasterEntity.TubeGW)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TubeGW=null,");  
  				} 
  
  				 
  				if(MasterEntity.TubeQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TubeQty="+SysString.ToDBString(MasterEntity.TubeQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TubeQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				 
  				if(MasterEntity.LockQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LockQty="+SysString.ToDBString(MasterEntity.LockQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LockQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FreeQty="+SysString.ToDBString(MasterEntity.FreeQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)+","); 
  				 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice="+SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" JarNo="+SysString.ToDBString(MasterEntity.JarNo)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" SO="+SysString.ToDBString(MasterEntity.SO)+","); 
  				 
  				if(MasterEntity.LastUpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime="+SysString.ToDBString(MasterEntity.LastUpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime=null,");  
  				} 
  
  				 
  				if(MasterEntity.LastUpdOP!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdOP="+SysString.ToDBString(MasterEntity.LastUpdOP.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdOP=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.Indate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" Indate="+SysString.ToDBString(MasterEntity.Indate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Indate=null,");  
  				} 
  
  				UpdateBuilder.Append(" DutyOPID="+SysString.ToDBString(MasterEntity.DutyOPID)+","); 
  				 
  				if(MasterEntity.CostPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CostPrice="+SysString.ToDBString(MasterEntity.CostPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CostPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" WHQualityFlag="+SysString.ToDBString(MasterEntity.WHQualityFlag)+","); 
  				UpdateBuilder.Append(" WHQualityFFlag="+SysString.ToDBString(MasterEntity.WHQualityFFlag)+","); 
  				UpdateBuilder.Append(" WHXiePianFlag="+SysString.ToDBString(MasterEntity.WHXiePianFlag)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" GoodsLevel="+SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				 
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
  				UpdateBuilder.Append(" OrderFormNo="+SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				UpdateBuilder.Append(" MLType="+SysString.ToDBString(MasterEntity.MLType)+","); 
  				 
  				if(MasterEntity.PDDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" PDDate="+SysString.ToDBString(MasterEntity.PDDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PDDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" PDFlag="+SysString.ToDBString(MasterEntity.PDFlag)+","); 
  				UpdateBuilder.Append(" DVendorID="+SysString.ToDBString(MasterEntity.DVendorID)); 
 
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
                Storge MasterEntity=(Storge)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_Storge WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
