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
	/// 目的：Sale_VendorCompact实体控制类
	/// 作者:周富春
	/// 创建日期:2011/12/14
	/// </summary>
	public sealed class VendorCompactCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public VendorCompactCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorCompactCtl(IDBTransAccess p_SqlCmd)
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
                VendorCompact MasterEntity=(VendorCompact)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_VendorCompact(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("SOID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SOID)+","); 
  				MasterField.Append("CompactNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				MasterField.Append("VendorSO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorSO)+","); 
  				MasterField.Append("WriteDate"+","); 
  				if(MasterEntity.WriteDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WriteDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WriteAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WriteAddress)+","); 
  				MasterField.Append("Aname"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Aname)+","); 
  				MasterField.Append("Aaddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Aaddress)+","); 
  				MasterField.Append("Atel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Atel)+","); 
  				MasterField.Append("Afax"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Afax)+","); 
  				MasterField.Append("Bname"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Bname)+","); 
  				MasterField.Append("Baddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Baddress)+","); 
  				MasterField.Append("Btel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Btel)+","); 
  				MasterField.Append("Bfax"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Bfax)+","); 
  				MasterField.Append("TotalAmount"+","); 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("VendorOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("CurrencyID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CurrencyID)+","); 
  				MasterField.Append("Rate"+","); 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalQty"+","); 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
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
  
  				MasterField.Append("Terms"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Terms)+","); 
  				MasterField.Append("TotalAmountEn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TotalAmountEn)+","); 
  				MasterField.Append("NeedDate"+","); 
  				if(MasterEntity.NeedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NeedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PayMethod"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayMethod)+")"); 
 
                
                

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
                VendorCompact MasterEntity=(VendorCompact)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_VendorCompact SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" SOID="+SysString.ToDBString(MasterEntity.SOID)+","); 
  				UpdateBuilder.Append(" CompactNo="+SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				UpdateBuilder.Append(" VendorSO="+SysString.ToDBString(MasterEntity.VendorSO)+","); 
  				 
  				if(MasterEntity.WriteDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" WriteDate="+SysString.ToDBString(MasterEntity.WriteDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WriteDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" WriteAddress="+SysString.ToDBString(MasterEntity.WriteAddress)+","); 
  				UpdateBuilder.Append(" Aname="+SysString.ToDBString(MasterEntity.Aname)+","); 
  				UpdateBuilder.Append(" Aaddress="+SysString.ToDBString(MasterEntity.Aaddress)+","); 
  				UpdateBuilder.Append(" Atel="+SysString.ToDBString(MasterEntity.Atel)+","); 
  				UpdateBuilder.Append(" Afax="+SysString.ToDBString(MasterEntity.Afax)+","); 
  				UpdateBuilder.Append(" Bname="+SysString.ToDBString(MasterEntity.Bname)+","); 
  				UpdateBuilder.Append(" Baddress="+SysString.ToDBString(MasterEntity.Baddress)+","); 
  				UpdateBuilder.Append(" Btel="+SysString.ToDBString(MasterEntity.Btel)+","); 
  				UpdateBuilder.Append(" Bfax="+SysString.ToDBString(MasterEntity.Bfax)+","); 
  				 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount="+SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" VendorOPID="+SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" CurrencyID="+SysString.ToDBString(MasterEntity.CurrencyID)+","); 
  				 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Rate="+SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Rate=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty="+SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Terms="+SysString.ToDBString(MasterEntity.Terms)+","); 
  				UpdateBuilder.Append(" TotalAmountEn="+SysString.ToDBString(MasterEntity.TotalAmountEn)+","); 
  				 
  				if(MasterEntity.NeedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" NeedDate="+SysString.ToDBString(MasterEntity.NeedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NeedDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" PayMethod="+SysString.ToDBString(MasterEntity.PayMethod)); 
 
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
                VendorCompact MasterEntity=(VendorCompact)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_VendorCompact WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
