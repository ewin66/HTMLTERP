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
	/// 目的：WO_ProductionPlan实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/6/30
	/// </summary>
	public sealed class ProductionPlanCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ProductionPlanCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionPlanCtl(IDBTransAccess p_SqlCmd)
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
                ProductionPlan MasterEntity=(ProductionPlan)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_ProductionPlan(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				MasterField.Append("OrderFormQty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderFormQty)+","); 
  				MasterField.Append("PBItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBItemCode)+","); 
  				MasterField.Append("PBItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBItemName)+","); 
  				MasterField.Append("PBItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBItemStd)+","); 
  				MasterField.Append("PBItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBItemModel)+","); 
  				MasterField.Append("FactoryID1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID1)+","); 
  				MasterField.Append("PBMWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBMWeight)+","); 
  				MasterField.Append("CPItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				MasterField.Append("CPDensity"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPDensity)+","); 
  				MasterField.Append("CPMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPMWidth)+","); 
  				MasterField.Append("CPMWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPMWeight)+","); 
  				MasterField.Append("FactoryID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID2)+","); 
  				MasterField.Append("LightSource"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LightSource)+","); 
  				MasterField.Append("PBReqDate"+","); 
  				if(MasterEntity.PBReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TGReqDate"+","); 
  				if(MasterEntity.TGReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TGReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPReqDate"+","); 
  				if(MasterEntity.CPReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CPReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("PBMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBMWidth)+","); 
  				MasterField.Append("CPItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				MasterField.Append("CPItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemModel)+","); 
  				MasterField.Append("CPItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				MasterField.Append("GenDan"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GenDan)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("Remark2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark2)+","); 
  				MasterField.Append("SO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SO)+","); 
  				MasterField.Append("SaleOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+")"); 
 
                
                

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
                ProductionPlan MasterEntity=(ProductionPlan)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_ProductionPlan SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" OrderFormNo="+SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				UpdateBuilder.Append(" OrderFormQty="+SysString.ToDBString(MasterEntity.OrderFormQty)+","); 
  				UpdateBuilder.Append(" PBItemCode="+SysString.ToDBString(MasterEntity.PBItemCode)+","); 
  				UpdateBuilder.Append(" PBItemName="+SysString.ToDBString(MasterEntity.PBItemName)+","); 
  				UpdateBuilder.Append(" PBItemStd="+SysString.ToDBString(MasterEntity.PBItemStd)+","); 
  				UpdateBuilder.Append(" PBItemModel="+SysString.ToDBString(MasterEntity.PBItemModel)+","); 
  				UpdateBuilder.Append(" FactoryID1="+SysString.ToDBString(MasterEntity.FactoryID1)+","); 
  				UpdateBuilder.Append(" PBMWeight="+SysString.ToDBString(MasterEntity.PBMWeight)+","); 
  				UpdateBuilder.Append(" CPItemCode="+SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				UpdateBuilder.Append(" CPDensity="+SysString.ToDBString(MasterEntity.CPDensity)+","); 
  				UpdateBuilder.Append(" CPMWidth="+SysString.ToDBString(MasterEntity.CPMWidth)+","); 
  				UpdateBuilder.Append(" CPMWeight="+SysString.ToDBString(MasterEntity.CPMWeight)+","); 
  				UpdateBuilder.Append(" FactoryID2="+SysString.ToDBString(MasterEntity.FactoryID2)+","); 
  				UpdateBuilder.Append(" LightSource="+SysString.ToDBString(MasterEntity.LightSource)+","); 
  				 
  				if(MasterEntity.PBReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" PBReqDate="+SysString.ToDBString(MasterEntity.PBReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBReqDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.TGReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" TGReqDate="+SysString.ToDBString(MasterEntity.TGReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TGReqDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CPReqDate="+SysString.ToDBString(MasterEntity.CPReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" MakeOPName="+SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CheckOPID="+SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" PBMWidth="+SysString.ToDBString(MasterEntity.PBMWidth)+","); 
  				UpdateBuilder.Append(" CPItemName="+SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				UpdateBuilder.Append(" CPItemModel="+SysString.ToDBString(MasterEntity.CPItemModel)+","); 
  				UpdateBuilder.Append(" CPItemStd="+SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				UpdateBuilder.Append(" GenDan="+SysString.ToDBString(MasterEntity.GenDan)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" Remark2="+SysString.ToDBString(MasterEntity.Remark2)+","); 
  				UpdateBuilder.Append(" SO="+SysString.ToDBString(MasterEntity.SO)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)); 
 
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
                ProductionPlan MasterEntity=(ProductionPlan)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_ProductionPlan WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
