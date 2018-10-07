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
	/// 目的：Chk_CheckOrderISN实体控制类
	/// 作者:周富春
	/// 创建日期:2015/11/17
	/// </summary>
	public sealed class CheckOrderISNCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CheckOrderISNCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOrderISNCtl(IDBTransAccess p_SqlCmd)
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
                CheckOrderISN MasterEntity=(CheckOrderISN)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Chk_CheckOrderISN(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DISN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DISN)+","); 
  				MasterField.Append("StatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusID)+","); 
  				MasterField.Append("InWHFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InWHFlag)+","); 
  				MasterField.Append("CheckOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("VendorBatch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("ReelNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReelNo)+","); 
  				MasterField.Append("YQty"+","); 
  				if(MasterEntity.YQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ChkQty"+","); 
  				if(MasterEntity.ChkQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ChkQty)+","); 
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
  
  				MasterField.Append("KJQty"+","); 
  				if(MasterEntity.KJQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.KJQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ChkMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ChkMWidth)+","); 
  				MasterField.Append("ChkMWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ChkMWeight)+","); 
  				MasterField.Append("ChkQtyKG"+","); 
  				if(MasterEntity.ChkQtyKG!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ChkQtyKG)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FaultDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FaultDesc)+","); 
  				MasterField.Append("ChkLevel"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ChkLevel)+")"); 
 
                
                

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
                CheckOrderISN MasterEntity=(CheckOrderISN)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Chk_CheckOrderISN SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" DISN="+SysString.ToDBString(MasterEntity.DISN)+","); 
  				UpdateBuilder.Append(" StatusID="+SysString.ToDBString(MasterEntity.StatusID)+","); 
  				UpdateBuilder.Append(" InWHFlag="+SysString.ToDBString(MasterEntity.InWHFlag)+","); 
  				UpdateBuilder.Append(" CheckOPID="+SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" VendorBatch="+SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" ReelNo="+SysString.ToDBString(MasterEntity.ReelNo)+","); 
  				 
  				if(MasterEntity.YQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YQty="+SysString.ToDBString(MasterEntity.YQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ChkQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ChkQty="+SysString.ToDBString(MasterEntity.ChkQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ChkQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				 
  				if(MasterEntity.KJQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" KJQty="+SysString.ToDBString(MasterEntity.KJQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" KJQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" ChkMWidth="+SysString.ToDBString(MasterEntity.ChkMWidth)+","); 
  				UpdateBuilder.Append(" ChkMWeight="+SysString.ToDBString(MasterEntity.ChkMWeight)+","); 
  				 
  				if(MasterEntity.ChkQtyKG!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ChkQtyKG="+SysString.ToDBString(MasterEntity.ChkQtyKG)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ChkQtyKG=null,");  
  				} 
  
  				UpdateBuilder.Append(" FaultDesc="+SysString.ToDBString(MasterEntity.FaultDesc)+","); 
  				UpdateBuilder.Append(" ChkLevel="+SysString.ToDBString(MasterEntity.ChkLevel)); 
 
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
                CheckOrderISN MasterEntity=(CheckOrderISN)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Chk_CheckOrderISN WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
