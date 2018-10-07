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
	/// 目的：WO_TowelProductionPlanDtsStep实体控制类
	/// 作者:zhp
	/// 创建日期:2016/9/7
	/// </summary>
	public sealed class TowelProductionPlanDtsStepCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public TowelProductionPlanDtsStepCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public TowelProductionPlanDtsStepCtl(IDBTransAccess p_SqlCmd)
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
                TowelProductionPlanDtsStep MasterEntity=(TowelProductionPlanDtsStep)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_TowelProductionPlanDtsStep(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("DtsID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsID)+","); 
  				MasterField.Append("SubSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				MasterField.Append("StepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StepID)+","); 
  				MasterField.Append("CardNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CardNo)+","); 
  				MasterField.Append("RecQty"+","); 
  				if(MasterEntity.RecQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RecQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RecDate"+","); 
  				if(MasterEntity.RecDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RecDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZPQty"+","); 
  				if(MasterEntity.ZPQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZPQty)+","); 
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
  
  				MasterField.Append("CompleteDate"+","); 
  				if(MasterEntity.CompleteDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CompleteDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("ProOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProOPID)+","); 
  				MasterField.Append("Remark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+")"); 
 
                
                

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
                TowelProductionPlanDtsStep MasterEntity=(TowelProductionPlanDtsStep)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_TowelProductionPlanDtsStep SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" DtsID="+SysString.ToDBString(MasterEntity.DtsID)+","); 
  				UpdateBuilder.Append(" SubSeq="+SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				UpdateBuilder.Append(" StepID="+SysString.ToDBString(MasterEntity.StepID)+","); 
  				UpdateBuilder.Append(" CardNo="+SysString.ToDBString(MasterEntity.CardNo)+","); 
  				 
  				if(MasterEntity.RecQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RecQty="+SysString.ToDBString(MasterEntity.RecQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RecQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.RecDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" RecDate="+SysString.ToDBString(MasterEntity.RecDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RecDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZPQty="+SysString.ToDBString(MasterEntity.ZPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZPQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CPQty="+SysString.ToDBString(MasterEntity.CPQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CompleteDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CompleteDate="+SysString.ToDBString(MasterEntity.CompleteDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CompleteDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" ProOPID="+SysString.ToDBString(MasterEntity.ProOPID)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)); 
 
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
                TowelProductionPlanDtsStep MasterEntity=(TowelProductionPlanDtsStep)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_TowelProductionPlanDtsStep WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
