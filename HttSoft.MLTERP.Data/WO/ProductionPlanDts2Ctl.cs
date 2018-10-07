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
	/// 目的：WO_ProductionPlanDts2实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/6/18
	/// </summary>
	public sealed class ProductionPlanDts2Ctl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ProductionPlanDts2Ctl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionPlanDts2Ctl(IDBTransAccess p_SqlCmd)
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
                ProductionPlanDts2 MasterEntity=(ProductionPlanDts2)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_ProductionPlanDts2(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("WagonNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WagonNo)+","); 
  				MasterField.Append("PBFormDate"+","); 
  				if(MasterEntity.PBFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBieceQty"+","); 
  				if(MasterEntity.PBieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBQty"+","); 
  				if(MasterEntity.PBQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPFormDate"+","); 
  				if(MasterEntity.CPFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CPFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
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
  
  				MasterField.Append("Shrinkage"+","); 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("ZPQty"+","); 
  				if(MasterEntity.ZPQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZPQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("HuiXiu"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HuiXiu)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+")"); 
 
                
                

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
                ProductionPlanDts2 MasterEntity=(ProductionPlanDts2)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_ProductionPlanDts2 SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" WagonNo="+SysString.ToDBString(MasterEntity.WagonNo)+","); 
  				 
  				if(MasterEntity.PBFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" PBFormDate="+SysString.ToDBString(MasterEntity.PBFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBFormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBieceQty="+SysString.ToDBString(MasterEntity.PBieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBQty="+SysString.ToDBString(MasterEntity.PBQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CPFormDate="+SysString.ToDBString(MasterEntity.CPFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPFormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CPQty="+SysString.ToDBString(MasterEntity.CPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.Shrinkage!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage="+SysString.ToDBString(MasterEntity.Shrinkage)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Shrinkage=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.ZPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZPQty="+SysString.ToDBString(MasterEntity.ZPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZPQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" HuiXiu="+SysString.ToDBString(MasterEntity.HuiXiu)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)); 
 
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
                ProductionPlanDts2 MasterEntity=(ProductionPlanDts2)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_ProductionPlanDts2 WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
