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
	/// 目的：WO_TowelProductionPlanDtsStepProducts实体控制类
	/// 作者:zhp
	/// 创建日期:2016/9/21
	/// </summary>
	public sealed class TowelProductionPlanDtsStepProductsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public TowelProductionPlanDtsStepProductsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public TowelProductionPlanDtsStepProductsCtl(IDBTransAccess p_SqlCmd)
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
                TowelProductionPlanDtsStepProducts MasterEntity=(TowelProductionPlanDtsStepProducts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_TowelProductionPlanDtsStepProducts(");
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
  				MasterField.Append("ProOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProOPID)+","); 
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
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("RecQty"+","); 
  				if(MasterEntity.RecQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RecQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CQty"+","); 
  				if(MasterEntity.CQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("SeCha"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SeCha)+","); 
  				MasterField.Append("SeLaoDu"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SeLaoDu)+","); 
  				MasterField.Append("XiShuiXing"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XiShuiXing)+","); 
  				MasterField.Append("Conclusion"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Conclusion)+","); 
  				MasterField.Append("MLDefect"+","); 
  				if(MasterEntity.MLDefect!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MLDefect)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RSDefect"+","); 
  				if(MasterEntity.RSDefect!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RSDefect)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FRDefect"+","); 
  				if(MasterEntity.FRDefect!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FRDefect)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OtherDefect"+","); 
  				if(MasterEntity.OtherDefect!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OtherDefect)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WorkStartTime"+","); 
  				if(MasterEntity.WorkStartTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WorkStartTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WorkingHours"+")"); 
  				if(MasterEntity.WorkingHours!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WorkingHours)+")"); 
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
                TowelProductionPlanDtsStepProducts MasterEntity=(TowelProductionPlanDtsStepProducts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_TowelProductionPlanDtsStepProducts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" DtsID="+SysString.ToDBString(MasterEntity.DtsID)+","); 
  				UpdateBuilder.Append(" SubSeq="+SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				UpdateBuilder.Append(" StepID="+SysString.ToDBString(MasterEntity.StepID)+","); 
  				UpdateBuilder.Append(" CardNo="+SysString.ToDBString(MasterEntity.CardNo)+","); 
  				UpdateBuilder.Append(" ProOPID="+SysString.ToDBString(MasterEntity.ProOPID)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				 
  				if(MasterEntity.RecQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RecQty="+SysString.ToDBString(MasterEntity.RecQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RecQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CQty="+SysString.ToDBString(MasterEntity.CQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" SeCha="+SysString.ToDBString(MasterEntity.SeCha)+","); 
  				UpdateBuilder.Append(" SeLaoDu="+SysString.ToDBString(MasterEntity.SeLaoDu)+","); 
  				UpdateBuilder.Append(" XiShuiXing="+SysString.ToDBString(MasterEntity.XiShuiXing)+","); 
  				UpdateBuilder.Append(" Conclusion="+SysString.ToDBString(MasterEntity.Conclusion)+","); 
  				 
  				if(MasterEntity.MLDefect!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MLDefect="+SysString.ToDBString(MasterEntity.MLDefect)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MLDefect=null,");  
  				} 
  
  				 
  				if(MasterEntity.RSDefect!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RSDefect="+SysString.ToDBString(MasterEntity.RSDefect)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RSDefect=null,");  
  				} 
  
  				 
  				if(MasterEntity.FRDefect!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FRDefect="+SysString.ToDBString(MasterEntity.FRDefect)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FRDefect=null,");  
  				} 
  
  				 
  				if(MasterEntity.OtherDefect!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OtherDefect="+SysString.ToDBString(MasterEntity.OtherDefect)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OtherDefect=null,");  
  				} 
  
  				 
  				if(MasterEntity.WorkStartTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" WorkStartTime="+SysString.ToDBString(MasterEntity.WorkStartTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WorkStartTime=null,");  
  				} 
  
  				 
  				if(MasterEntity.WorkingHours!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WorkingHours="+SysString.ToDBString(MasterEntity.WorkingHours)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WorkingHours=null");  
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
                TowelProductionPlanDtsStepProducts MasterEntity=(TowelProductionPlanDtsStepProducts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_TowelProductionPlanDtsStepProducts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
