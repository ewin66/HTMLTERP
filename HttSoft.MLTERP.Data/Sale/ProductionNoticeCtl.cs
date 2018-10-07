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
	/// 目的：Sale_ProductionNotice实体控制类
	/// 作者:tanghao
	/// 创建日期:2015/5/27
	/// </summary>
	public sealed class ProductionNoticeCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ProductionNoticeCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionNoticeCtl(IDBTransAccess p_SqlCmd)
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
                ProductionNotice MasterEntity=(ProductionNotice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_ProductionNotice(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
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
  
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OutDate"+","); 
  				if(MasterEntity.OutDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OutDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("TrackOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TrackOPID)+","); 
  				MasterField.Append("ProductionLeader"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProductionLeader)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("ZZRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZZRemark)+","); 
  				MasterField.Append("RSReamrk"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RSReamrk)+","); 
  				MasterField.Append("HZLRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HZLRemark)+","); 
  				MasterField.Append("BZRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BZRemark)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SOTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SOTypeID)+","); 
  				MasterField.Append("TrackOPID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TrackOPID2)+","); 
  				MasterField.Append("TrackOPID3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TrackOPID3)+","); 
  				MasterField.Append("FormNoIndex"+","); 
  				if(MasterEntity.FormNoIndex!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormNoIndex)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RSGDOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RSGDOPID)+","); 
  				MasterField.Append("HZGDOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HZGDOPID)+","); 
  				MasterField.Append("HZLRemark2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HZLRemark2)+","); 
  				MasterField.Append("HZLRemark3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HZLRemark3)+","); 
  				MasterField.Append("BZGDOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BZGDOPID)+","); 
  				MasterField.Append("FactoryID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				MasterField.Append("FactoryID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID2)+","); 
  				MasterField.Append("FactoryID3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID3)+","); 
  				MasterField.Append("FactoryID4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID4)+","); 
  				MasterField.Append("FactoryID5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID5)+","); 
  				MasterField.Append("LightSource"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LightSource)+","); 
  				MasterField.Append("QtyReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QtyReq)+","); 
  				MasterField.Append("CheckStandard"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckStandard)+","); 
  				MasterField.Append("CheckReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckReq)+","); 
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("PBItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBItemCode)+","); 
  				MasterField.Append("PBDensity"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBDensity)+","); 
  				MasterField.Append("PBMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBMWidth)+","); 
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
  				MasterField.Append("XGDate"+","); 
  				if(MasterEntity.XGDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.XGDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("XGReason"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XGReason)+")"); 
 
                
                

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
                ProductionNotice MasterEntity=(ProductionNotice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_ProductionNotice SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" MakeOPName="+SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.OutDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" OutDate="+SysString.ToDBString(MasterEntity.OutDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OutDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" TrackOPID="+SysString.ToDBString(MasterEntity.TrackOPID)+","); 
  				UpdateBuilder.Append(" ProductionLeader="+SysString.ToDBString(MasterEntity.ProductionLeader)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" ZZRemark="+SysString.ToDBString(MasterEntity.ZZRemark)+","); 
  				UpdateBuilder.Append(" RSReamrk="+SysString.ToDBString(MasterEntity.RSReamrk)+","); 
  				UpdateBuilder.Append(" HZLRemark="+SysString.ToDBString(MasterEntity.HZLRemark)+","); 
  				UpdateBuilder.Append(" BZRemark="+SysString.ToDBString(MasterEntity.BZRemark)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SOTypeID="+SysString.ToDBString(MasterEntity.SOTypeID)+","); 
  				UpdateBuilder.Append(" TrackOPID2="+SysString.ToDBString(MasterEntity.TrackOPID2)+","); 
  				UpdateBuilder.Append(" TrackOPID3="+SysString.ToDBString(MasterEntity.TrackOPID3)+","); 
  				 
  				if(MasterEntity.FormNoIndex!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FormNoIndex="+SysString.ToDBString(MasterEntity.FormNoIndex)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormNoIndex=null,");  
  				} 
  
  				UpdateBuilder.Append(" RSGDOPID="+SysString.ToDBString(MasterEntity.RSGDOPID)+","); 
  				UpdateBuilder.Append(" HZGDOPID="+SysString.ToDBString(MasterEntity.HZGDOPID)+","); 
  				UpdateBuilder.Append(" HZLRemark2="+SysString.ToDBString(MasterEntity.HZLRemark2)+","); 
  				UpdateBuilder.Append(" HZLRemark3="+SysString.ToDBString(MasterEntity.HZLRemark3)+","); 
  				UpdateBuilder.Append(" BZGDOPID="+SysString.ToDBString(MasterEntity.BZGDOPID)+","); 
  				UpdateBuilder.Append(" FactoryID="+SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				UpdateBuilder.Append(" FactoryID2="+SysString.ToDBString(MasterEntity.FactoryID2)+","); 
  				UpdateBuilder.Append(" FactoryID3="+SysString.ToDBString(MasterEntity.FactoryID3)+","); 
  				UpdateBuilder.Append(" FactoryID4="+SysString.ToDBString(MasterEntity.FactoryID4)+","); 
  				UpdateBuilder.Append(" FactoryID5="+SysString.ToDBString(MasterEntity.FactoryID5)+","); 
  				UpdateBuilder.Append(" LightSource="+SysString.ToDBString(MasterEntity.LightSource)+","); 
  				UpdateBuilder.Append(" QtyReq="+SysString.ToDBString(MasterEntity.QtyReq)+","); 
  				UpdateBuilder.Append(" CheckStandard="+SysString.ToDBString(MasterEntity.CheckStandard)+","); 
  				UpdateBuilder.Append(" CheckReq="+SysString.ToDBString(MasterEntity.CheckReq)+","); 
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" PBItemCode="+SysString.ToDBString(MasterEntity.PBItemCode)+","); 
  				UpdateBuilder.Append(" PBDensity="+SysString.ToDBString(MasterEntity.PBDensity)+","); 
  				UpdateBuilder.Append(" PBMWidth="+SysString.ToDBString(MasterEntity.PBMWidth)+","); 
  				UpdateBuilder.Append(" PBMWeight="+SysString.ToDBString(MasterEntity.PBMWeight)+","); 
  				UpdateBuilder.Append(" CPItemCode="+SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				UpdateBuilder.Append(" CPDensity="+SysString.ToDBString(MasterEntity.CPDensity)+","); 
  				UpdateBuilder.Append(" CPMWidth="+SysString.ToDBString(MasterEntity.CPMWidth)+","); 
  				UpdateBuilder.Append(" CPMWeight="+SysString.ToDBString(MasterEntity.CPMWeight)+","); 
  				 
  				if(MasterEntity.XGDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" XGDate="+SysString.ToDBString(MasterEntity.XGDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" XGDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" XGReason="+SysString.ToDBString(MasterEntity.XGReason)); 
 
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
                ProductionNotice MasterEntity=(ProductionNotice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_ProductionNotice WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
