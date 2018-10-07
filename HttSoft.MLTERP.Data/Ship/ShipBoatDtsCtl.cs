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
	/// 目的：Ship_ShipBoatDts实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/21
	/// </summary>
	public sealed class ShipBoatDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ShipBoatDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ShipBoatDtsCtl(IDBTransAccess p_SqlCmd)
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
                ShipBoatDts MasterEntity=(ShipBoatDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Ship_ShipBoatDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("SSN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SSN)+","); 
  				MasterField.Append("DSN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSN)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("CrossWeight"+","); 
  				if(MasterEntity.CrossWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("NetWeight"+","); 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SizeChang"+","); 
  				if(MasterEntity.SizeChang!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SizeChang)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SizeKuan"+","); 
  				if(MasterEntity.SizeKuan!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SizeKuan)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SizeGao"+","); 
  				if(MasterEntity.SizeGao!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SizeGao)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("StyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				MasterField.Append("Style"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Style)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("BoxNum"+","); 
  				if(MasterEntity.BoxNum!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BoxNum)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("Country"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Country)+","); 
  				MasterField.Append("HSCODE"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HSCODE)+","); 
  				MasterField.Append("dex"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.dex)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("SinglePrice"+","); 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PrintStatus"+","); 
  				if(MasterEntity.PrintStatus!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PrintStatus)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Model"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Model)+","); 
  				MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("TSItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TSItemName)+","); 
  				MasterField.Append("BulkSize"+","); 
  				if(MasterEntity.BulkSize!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BulkSize)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  
  				MasterField.Append("PieceQty"+")"); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+")"); 
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
                ShipBoatDts MasterEntity=(ShipBoatDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Ship_ShipBoatDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" SSN="+SysString.ToDBString(MasterEntity.SSN)+","); 
  				UpdateBuilder.Append(" DSN="+SysString.ToDBString(MasterEntity.DSN)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.CrossWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CrossWeight="+SysString.ToDBString(MasterEntity.CrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CrossWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight="+SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.SizeChang!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SizeChang="+SysString.ToDBString(MasterEntity.SizeChang)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SizeChang=null,");  
  				} 
  
  				 
  				if(MasterEntity.SizeKuan!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SizeKuan="+SysString.ToDBString(MasterEntity.SizeKuan)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SizeKuan=null,");  
  				} 
  
  				 
  				if(MasterEntity.SizeGao!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SizeGao="+SysString.ToDBString(MasterEntity.SizeGao)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SizeGao=null,");  
  				} 
  
  				UpdateBuilder.Append(" StyleNo="+SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				UpdateBuilder.Append(" Style="+SysString.ToDBString(MasterEntity.Style)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				 
  				if(MasterEntity.BoxNum!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BoxNum="+SysString.ToDBString(MasterEntity.BoxNum)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BoxNum=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				UpdateBuilder.Append(" Country="+SysString.ToDBString(MasterEntity.Country)+","); 
  				UpdateBuilder.Append(" HSCODE="+SysString.ToDBString(MasterEntity.HSCODE)+","); 
  				UpdateBuilder.Append(" dex="+SysString.ToDBString(MasterEntity.dex)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice="+SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.PrintStatus!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PrintStatus="+SysString.ToDBString(MasterEntity.PrintStatus)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PrintStatus=null,");  
  				} 
  
  				UpdateBuilder.Append(" Model="+SysString.ToDBString(MasterEntity.Model)+","); 
  				UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" TSItemName="+SysString.ToDBString(MasterEntity.TSItemName)+","); 
  				 
  				if(MasterEntity.BulkSize!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BulkSize="+SysString.ToDBString(MasterEntity.BulkSize)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BulkSize=null,");  
  				} 
  
  				 
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
  
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null");  
  				} 
  
 
                UpdateBuilder.Append(" WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq));
                
                

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
                ShipBoatDts MasterEntity=(ShipBoatDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Ship_ShipBoatDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
