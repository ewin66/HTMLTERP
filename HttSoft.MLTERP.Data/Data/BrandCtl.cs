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
	/// 目的：Data_Brand实体控制类
	/// 作者:sunxun
	/// 创建日期:2010-5-5
	/// </summary>
	public sealed class BrandCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public BrandCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public BrandCtl(IDBTransAccess p_SqlCmd)
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
                Brand MasterEntity=(Brand)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_Brand(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("BrandID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BrandID)+","); 
  				MasterField.Append("BrandAttn"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BrandAttn)+","); 
  				MasterField.Append("BrandName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BrandName)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("AttOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AttOPID)+","); 
  				MasterField.Append("WOOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WOOPID)+","); 
  				MasterField.Append("RightName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RightName)+","); 
  				MasterField.Append("MD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MD)+","); 
  				MasterField.Append("DesignName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DesignName)+","); 
  				MasterField.Append("ProName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ProName)+","); 
  				MasterField.Append("BrandCls"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BrandCls)+","); 
  				MasterField.Append("BrandDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BrandDesc)+","); 
  				MasterField.Append("BrandCodeRule"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BrandCodeRule)+","); 
  				MasterField.Append("SaleType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleType)+","); 
  				MasterField.Append("BeginYear"+","); 
  				if(MasterEntity.BeginYear!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BeginYear)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ShowPlan"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShowPlan)+","); 
  				MasterField.Append("GoodsDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsDesc)+","); 
  				MasterField.Append("UseableFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				MasterField.Append("Free1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Free1)+","); 
  				MasterField.Append("Free2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Free2)+","); 
  				MasterField.Append("Free3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Free3)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("RequestType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RequestType)+","); 
  				MasterField.Append("FinalType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FinalType)+","); 
  				MasterField.Append("ExpressFinal"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExpressFinal)+","); 
  				MasterField.Append("ExitType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ExitType)+","); 
  				MasterField.Append("SSNExpense"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SSNExpense)+","); 
  				MasterField.Append("ItemFinalType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemFinalType)+","); 
  				MasterField.Append("AttnFinalType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AttnFinalType)+","); 
  				MasterField.Append("AttnRequirement"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AttnRequirement)+","); 
  				MasterField.Append("Currency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Currency)+","); 
  				MasterField.Append("Payment"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Payment)+","); 
  				MasterField.Append("QY"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QY)+","); 
  				MasterField.Append("LimitBuyQty"+","); 
  				if(MasterEntity.LimitBuyQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LimitBuyQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ProQty"+","); 
  				if(MasterEntity.ProQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ProQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Contact"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Contact)+","); 
  				MasterField.Append("ContactEMail"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ContactEMail)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("VendorDutyOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorDutyOP)+","); 
  				MasterField.Append("SaleOPDepartment"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPDepartment)+","); 
  				MasterField.Append("BJOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BJOPID)+","); 
  				MasterField.Append("ISSHCheck"+","); 
  				if(MasterEntity.ISSHCheck!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ISSHCheck)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JSXType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JSXType)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
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
  
  				MasterField.Append("TecOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TecOPID)+","); 
  				MasterField.Append("ChkDepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ChkDepID)+","); 
  				MasterField.Append("LRJS"+")"); 
  				if(MasterEntity.LRJS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LRJS)+")"); 
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
                Brand MasterEntity=(Brand)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_Brand SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" BrandID="+SysString.ToDBString(MasterEntity.BrandID)+","); 
  				UpdateBuilder.Append(" BrandAttn="+SysString.ToDBString(MasterEntity.BrandAttn)+","); 
  				UpdateBuilder.Append(" BrandName="+SysString.ToDBString(MasterEntity.BrandName)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" AttOPID="+SysString.ToDBString(MasterEntity.AttOPID)+","); 
  				UpdateBuilder.Append(" WOOPID="+SysString.ToDBString(MasterEntity.WOOPID)+","); 
  				UpdateBuilder.Append(" RightName="+SysString.ToDBString(MasterEntity.RightName)+","); 
  				UpdateBuilder.Append(" MD="+SysString.ToDBString(MasterEntity.MD)+","); 
  				UpdateBuilder.Append(" DesignName="+SysString.ToDBString(MasterEntity.DesignName)+","); 
  				UpdateBuilder.Append(" ProName="+SysString.ToDBString(MasterEntity.ProName)+","); 
  				UpdateBuilder.Append(" BrandCls="+SysString.ToDBString(MasterEntity.BrandCls)+","); 
  				UpdateBuilder.Append(" BrandDesc="+SysString.ToDBString(MasterEntity.BrandDesc)+","); 
  				UpdateBuilder.Append(" BrandCodeRule="+SysString.ToDBString(MasterEntity.BrandCodeRule)+","); 
  				UpdateBuilder.Append(" SaleType="+SysString.ToDBString(MasterEntity.SaleType)+","); 
  				 
  				if(MasterEntity.BeginYear!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BeginYear="+SysString.ToDBString(MasterEntity.BeginYear)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BeginYear=null,");  
  				} 
  
  				UpdateBuilder.Append(" ShowPlan="+SysString.ToDBString(MasterEntity.ShowPlan)+","); 
  				UpdateBuilder.Append(" GoodsDesc="+SysString.ToDBString(MasterEntity.GoodsDesc)+","); 
  				UpdateBuilder.Append(" UseableFlag="+SysString.ToDBString(MasterEntity.UseableFlag)+","); 
  				UpdateBuilder.Append(" Free1="+SysString.ToDBString(MasterEntity.Free1)+","); 
  				UpdateBuilder.Append(" Free2="+SysString.ToDBString(MasterEntity.Free2)+","); 
  				UpdateBuilder.Append(" Free3="+SysString.ToDBString(MasterEntity.Free3)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" RequestType="+SysString.ToDBString(MasterEntity.RequestType)+","); 
  				UpdateBuilder.Append(" FinalType="+SysString.ToDBString(MasterEntity.FinalType)+","); 
  				UpdateBuilder.Append(" ExpressFinal="+SysString.ToDBString(MasterEntity.ExpressFinal)+","); 
  				UpdateBuilder.Append(" ExitType="+SysString.ToDBString(MasterEntity.ExitType)+","); 
  				UpdateBuilder.Append(" SSNExpense="+SysString.ToDBString(MasterEntity.SSNExpense)+","); 
  				UpdateBuilder.Append(" ItemFinalType="+SysString.ToDBString(MasterEntity.ItemFinalType)+","); 
  				UpdateBuilder.Append(" AttnFinalType="+SysString.ToDBString(MasterEntity.AttnFinalType)+","); 
  				UpdateBuilder.Append(" AttnRequirement="+SysString.ToDBString(MasterEntity.AttnRequirement)+","); 
  				UpdateBuilder.Append(" Currency="+SysString.ToDBString(MasterEntity.Currency)+","); 
  				UpdateBuilder.Append(" Payment="+SysString.ToDBString(MasterEntity.Payment)+","); 
  				UpdateBuilder.Append(" QY="+SysString.ToDBString(MasterEntity.QY)+","); 
  				 
  				if(MasterEntity.LimitBuyQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LimitBuyQty="+SysString.ToDBString(MasterEntity.LimitBuyQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LimitBuyQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ProQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ProQty="+SysString.ToDBString(MasterEntity.ProQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ProQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Contact="+SysString.ToDBString(MasterEntity.Contact)+","); 
  				UpdateBuilder.Append(" ContactEMail="+SysString.ToDBString(MasterEntity.ContactEMail)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" VendorDutyOP="+SysString.ToDBString(MasterEntity.VendorDutyOP)+","); 
  				UpdateBuilder.Append(" SaleOPDepartment="+SysString.ToDBString(MasterEntity.SaleOPDepartment)+","); 
  				UpdateBuilder.Append(" BJOPID="+SysString.ToDBString(MasterEntity.BJOPID)+","); 
  				 
  				if(MasterEntity.ISSHCheck!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ISSHCheck="+SysString.ToDBString(MasterEntity.ISSHCheck)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ISSHCheck=null,");  
  				} 
  
  				UpdateBuilder.Append(" JSXType="+SysString.ToDBString(MasterEntity.JSXType)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" TecOPID="+SysString.ToDBString(MasterEntity.TecOPID)+","); 
  				UpdateBuilder.Append(" ChkDepID="+SysString.ToDBString(MasterEntity.ChkDepID)+","); 
  				 
  				if(MasterEntity.LRJS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" LRJS="+SysString.ToDBString(MasterEntity.LRJS)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LRJS=null");  
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
                Brand MasterEntity=(Brand)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_Brand WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
