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
	/// 目的：Dev_Sample实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/1
	/// </summary>
	public sealed class SampleCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SampleCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SampleCtl(IDBTransAccess p_SqlCmd)
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
                Sample MasterEntity=(Sample)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Dev_Sample(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("SFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SFormNo)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SampleType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SampleType)+","); 
  				MasterField.Append("SOType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SOType)+","); 
  				MasterField.Append("FactoryID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				MasterField.Append("ReqDate"+","); 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("PBItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBItemCode)+","); 
  				MasterField.Append("PBDensity"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBDensity)+","); 
  				MasterField.Append("PBMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBMWidth)+","); 
  				MasterField.Append("PBMWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PBMWeight)+","); 
  				MasterField.Append("FactoryID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID2)+","); 
  				MasterField.Append("CPItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				MasterField.Append("CPDensity"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPDensity)+","); 
  				MasterField.Append("CPMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPMWidth)+","); 
  				MasterField.Append("CPMWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPMWeight)+","); 
  				MasterField.Append("FactoryID3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryID3)+","); 
  				MasterField.Append("LightSource"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LightSource)+","); 
  				MasterField.Append("PrintingMethod"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintingMethod)+","); 
  				MasterField.Append("TecReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TecReq)+","); 
  				MasterField.Append("PBQty"+","); 
  				if(MasterEntity.PBQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BCPSampleQty"+","); 
  				if(MasterEntity.BCPSampleQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BCPSampleQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBSampleQty"+","); 
  				if(MasterEntity.PBSampleQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBSampleQty)+","); 
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
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("SubmitOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				MasterField.Append("SubmitTime"+","); 
  				if(MasterEntity.SubmitTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("CPItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				MasterField.Append("CPItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				MasterField.Append("VendorOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				MasterField.Append("GenDan"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GenDan)+","); 
  				MasterField.Append("SO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SO)+","); 
  				MasterField.Append("LightSource2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LightSource2)+","); 
  				MasterField.Append("LightSource3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LightSource3)+","); 
  				MasterField.Append("AllMWidth"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AllMWidth)+")"); 
 
                
                

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
                Sample MasterEntity=(Sample)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Dev_Sample SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" SFormNo="+SysString.ToDBString(MasterEntity.SFormNo)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SampleType="+SysString.ToDBString(MasterEntity.SampleType)+","); 
  				UpdateBuilder.Append(" SOType="+SysString.ToDBString(MasterEntity.SOType)+","); 
  				UpdateBuilder.Append(" FactoryID="+SysString.ToDBString(MasterEntity.FactoryID)+","); 
  				 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate="+SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" PBItemCode="+SysString.ToDBString(MasterEntity.PBItemCode)+","); 
  				UpdateBuilder.Append(" PBDensity="+SysString.ToDBString(MasterEntity.PBDensity)+","); 
  				UpdateBuilder.Append(" PBMWidth="+SysString.ToDBString(MasterEntity.PBMWidth)+","); 
  				UpdateBuilder.Append(" PBMWeight="+SysString.ToDBString(MasterEntity.PBMWeight)+","); 
  				UpdateBuilder.Append(" FactoryID2="+SysString.ToDBString(MasterEntity.FactoryID2)+","); 
  				UpdateBuilder.Append(" CPItemCode="+SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				UpdateBuilder.Append(" CPDensity="+SysString.ToDBString(MasterEntity.CPDensity)+","); 
  				UpdateBuilder.Append(" CPMWidth="+SysString.ToDBString(MasterEntity.CPMWidth)+","); 
  				UpdateBuilder.Append(" CPMWeight="+SysString.ToDBString(MasterEntity.CPMWeight)+","); 
  				UpdateBuilder.Append(" FactoryID3="+SysString.ToDBString(MasterEntity.FactoryID3)+","); 
  				UpdateBuilder.Append(" LightSource="+SysString.ToDBString(MasterEntity.LightSource)+","); 
  				UpdateBuilder.Append(" PrintingMethod="+SysString.ToDBString(MasterEntity.PrintingMethod)+","); 
  				UpdateBuilder.Append(" TecReq="+SysString.ToDBString(MasterEntity.TecReq)+","); 
  				 
  				if(MasterEntity.PBQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBQty="+SysString.ToDBString(MasterEntity.PBQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.BCPSampleQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BCPSampleQty="+SysString.ToDBString(MasterEntity.BCPSampleQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BCPSampleQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBSampleQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBSampleQty="+SysString.ToDBString(MasterEntity.PBSampleQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBSampleQty=null,");  
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
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" SubmitOPID="+SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				 
  				if(MasterEntity.SubmitTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime="+SysString.ToDBString(MasterEntity.SubmitTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" CPItemName="+SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				UpdateBuilder.Append(" CPItemStd="+SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				UpdateBuilder.Append(" VendorOPID="+SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				UpdateBuilder.Append(" GenDan="+SysString.ToDBString(MasterEntity.GenDan)+","); 
  				UpdateBuilder.Append(" SO="+SysString.ToDBString(MasterEntity.SO)+","); 
  				UpdateBuilder.Append(" LightSource2="+SysString.ToDBString(MasterEntity.LightSource2)+","); 
  				UpdateBuilder.Append(" LightSource3="+SysString.ToDBString(MasterEntity.LightSource3)+","); 
  				UpdateBuilder.Append(" AllMWidth="+SysString.ToDBString(MasterEntity.AllMWidth)); 
 
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
                Sample MasterEntity=(Sample)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Dev_Sample WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
