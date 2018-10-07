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
	/// 目的：WO_Design实体控制类
	/// 作者:曹小艮
	/// 创建日期:2011-12-1
	/// </summary>
	public sealed class DesignCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public DesignCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public DesignCtl(IDBTransAccess p_SqlCmd)
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
                Design MasterEntity=(Design)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_Design(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("PlanCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PlanCode)+","); 
  				MasterField.Append("SOID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SOID)+","); 
  				MasterField.Append("XinXian"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XinXian)+","); 
  				MasterField.Append("YaXian"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YaXian)+","); 
  				MasterField.Append("FuXian"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FuXian)+","); 
  				MasterField.Append("GYRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GYRemark)+","); 
  				MasterField.Append("PJiaoChang"+","); 
  				if(MasterEntity.PJiaoChang!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PJiaoChang)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PJiaoZhong"+","); 
  				if(MasterEntity.PJiaoZhong!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PJiaoZhong)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PRemark)+","); 
  				MasterField.Append("SJiaoChang"+","); 
  				if(MasterEntity.SJiaoChang!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SJiaoChang)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SJiaoZhong"+","); 
  				if(MasterEntity.SJiaoZhong!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SJiaoZhong)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SRemark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SRemark)+")"); 
 
                
                

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
                Design MasterEntity=(Design)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_Design SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" PlanCode="+SysString.ToDBString(MasterEntity.PlanCode)+","); 
  				UpdateBuilder.Append(" SOID="+SysString.ToDBString(MasterEntity.SOID)+","); 
  				UpdateBuilder.Append(" XinXian="+SysString.ToDBString(MasterEntity.XinXian)+","); 
  				UpdateBuilder.Append(" YaXian="+SysString.ToDBString(MasterEntity.YaXian)+","); 
  				UpdateBuilder.Append(" FuXian="+SysString.ToDBString(MasterEntity.FuXian)+","); 
  				UpdateBuilder.Append(" GYRemark="+SysString.ToDBString(MasterEntity.GYRemark)+","); 
  				 
  				if(MasterEntity.PJiaoChang!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PJiaoChang="+SysString.ToDBString(MasterEntity.PJiaoChang)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PJiaoChang=null,");  
  				} 
  
  				 
  				if(MasterEntity.PJiaoZhong!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PJiaoZhong="+SysString.ToDBString(MasterEntity.PJiaoZhong)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PJiaoZhong=null,");  
  				} 
  
  				UpdateBuilder.Append(" PRemark="+SysString.ToDBString(MasterEntity.PRemark)+","); 
  				 
  				if(MasterEntity.SJiaoChang!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SJiaoChang="+SysString.ToDBString(MasterEntity.SJiaoChang)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SJiaoChang=null,");  
  				} 
  
  				 
  				if(MasterEntity.SJiaoZhong!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SJiaoZhong="+SysString.ToDBString(MasterEntity.SJiaoZhong)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SJiaoZhong=null,");  
  				} 
  
  				UpdateBuilder.Append(" SRemark="+SysString.ToDBString(MasterEntity.SRemark)); 
 
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
                Design MasterEntity=(Design)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_Design WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
