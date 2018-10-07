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
	/// 目的：WH_YQForm实体控制类
	/// 作者:章文强
	/// 创建日期:2013/5/30
	/// </summary>
	public sealed class YQFormCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public YQFormCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public YQFormCtl(IDBTransAccess p_SqlCmd)
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
                YQForm MasterEntity=(YQForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_YQForm(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FromIOFormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FromIOFormID)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("WHTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("HeadType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadType)+","); 
  				MasterField.Append("SubType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubType)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("OutDep"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutDep)+","); 
  				MasterField.Append("Indep"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Indep)+","); 
  				MasterField.Append("WHOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHOP)+","); 
  				MasterField.Append("PassOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PassOP)+","); 
  				MasterField.Append("DutyOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DutyOP)+","); 
  				MasterField.Append("SOID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SOID)+","); 
  				MasterField.Append("SpecialNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SpecialNo)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CardNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CardNo)+","); 
  				MasterField.Append("ConfirmFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ConfirmFlag)+","); 
  				MasterField.Append("CheckOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOP)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("WHType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHType)+","); 
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
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LastUpdOP)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("JHCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JHCode)+","); 
  				MasterField.Append("XZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XZ)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("DM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DM)+","); 
  				MasterField.Append("InvoiceNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				MasterField.Append("TotalQty"+","); 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalAmount"+","); 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  
  				MasterField.Append("FHTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FHTypeID)+","); 
  				MasterField.Append("KDNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KDNo)+","); 
  				MasterField.Append("DEFlag"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DEFlag)+")"); 
 
                
                

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
                YQForm MasterEntity=(YQForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_YQForm SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FromIOFormID="+SysString.ToDBString(MasterEntity.FromIOFormID)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" WHTypeID="+SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" HeadType="+SysString.ToDBString(MasterEntity.HeadType)+","); 
  				UpdateBuilder.Append(" SubType="+SysString.ToDBString(MasterEntity.SubType)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" OutDep="+SysString.ToDBString(MasterEntity.OutDep)+","); 
  				UpdateBuilder.Append(" Indep="+SysString.ToDBString(MasterEntity.Indep)+","); 
  				UpdateBuilder.Append(" WHOP="+SysString.ToDBString(MasterEntity.WHOP)+","); 
  				UpdateBuilder.Append(" PassOP="+SysString.ToDBString(MasterEntity.PassOP)+","); 
  				UpdateBuilder.Append(" DutyOP="+SysString.ToDBString(MasterEntity.DutyOP)+","); 
  				UpdateBuilder.Append(" SOID="+SysString.ToDBString(MasterEntity.SOID)+","); 
  				UpdateBuilder.Append(" SpecialNo="+SysString.ToDBString(MasterEntity.SpecialNo)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CardNo="+SysString.ToDBString(MasterEntity.CardNo)+","); 
  				UpdateBuilder.Append(" ConfirmFlag="+SysString.ToDBString(MasterEntity.ConfirmFlag)+","); 
  				UpdateBuilder.Append(" CheckOP="+SysString.ToDBString(MasterEntity.CheckOP)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" WHType="+SysString.ToDBString(MasterEntity.WHType)+","); 
  				 
  				if(MasterEntity.LastUpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime="+SysString.ToDBString(MasterEntity.LastUpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" LastUpdOP="+SysString.ToDBString(MasterEntity.LastUpdOP)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" JHCode="+SysString.ToDBString(MasterEntity.JHCode)+","); 
  				UpdateBuilder.Append(" XZ="+SysString.ToDBString(MasterEntity.XZ)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" DM="+SysString.ToDBString(MasterEntity.DM)+","); 
  				UpdateBuilder.Append(" InvoiceNo="+SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty="+SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount="+SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitOPID="+SysString.ToDBString(MasterEntity.SubmitOPID)+","); 
  				 
  				if(MasterEntity.SubmitTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime="+SysString.ToDBString(MasterEntity.SubmitTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SubmitTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" FHTypeID="+SysString.ToDBString(MasterEntity.FHTypeID)+","); 
  				UpdateBuilder.Append(" KDNo="+SysString.ToDBString(MasterEntity.KDNo)+","); 
  				UpdateBuilder.Append(" DEFlag="+SysString.ToDBString(MasterEntity.DEFlag)); 
 
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
                YQForm MasterEntity=(YQForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_YQForm WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
