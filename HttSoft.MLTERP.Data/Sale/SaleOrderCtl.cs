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
	/// 目的：Sale_SaleOrder实体控制类
	/// 作者:zhp
	/// 创建日期:2016/7/6
	/// </summary>
	public sealed class SaleOrderCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderCtl(IDBTransAccess p_SqlCmd)
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
                SaleOrder MasterEntity=(SaleOrder)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_SaleOrder(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
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
  
  				MasterField.Append("CSFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CSFlag)+","); 
  				MasterField.Append("CSTime"+","); 
  				if(MasterEntity.CSTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CSTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CSOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CSOPID)+","); 
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
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("CustomerCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CustomerCode)+","); 
  				MasterField.Append("OrderTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderTypeID)+","); 
  				MasterField.Append("OrderLevelID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderLevelID)+","); 
  				MasterField.Append("OrderDate"+","); 
  				if(MasterEntity.OrderDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReqDate"+","); 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("PayMethodID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayMethodID)+","); 
  				MasterField.Append("ContractDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ContractDesc)+","); 
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
  
  				MasterField.Append("OrderPreStepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderPreStepID)+","); 
  				MasterField.Append("OrderStepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderStepID)+","); 
  				MasterField.Append("PayMethodFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayMethodFlag)+","); 
  				MasterField.Append("StatusFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusFlag)+","); 
  				MasterField.Append("StatusName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusName)+","); 
  				MasterField.Append("WLAmountType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WLAmountType)+","); 
  				MasterField.Append("WLAmount"+","); 
  				if(MasterEntity.WLAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WLAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CancelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CancelFlag)+","); 
  				MasterField.Append("CancelReason"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CancelReason)+","); 
  				MasterField.Append("FKFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FKFlag)+","); 
  				MasterField.Append("SaleFlowModuleID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleFlowModuleID)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("ConvertUnitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ConvertUnitFlag)+","); 
  				MasterField.Append("VendorOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				MasterField.Append("HQFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HQFlag)+","); 
  				MasterField.Append("ToMes"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ToMes)+","); 
  				MasterField.Append("SCNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SCNO)+","); 
  				MasterField.Append("Ref"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Ref)+","); 
  				MasterField.Append("OrderNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderNo)+","); 
  				MasterField.Append("ORIGINOFMERCHANDISE"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ORIGINOFMERCHANDISE)+","); 
  				MasterField.Append("SHIPPER"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SHIPPER)+","); 
  				MasterField.Append("Termsofdelivery"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Termsofdelivery)+","); 
  				MasterField.Append("Countryofloading"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Countryofloading)+","); 
  				MasterField.Append("Package"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Package)+","); 
  				MasterField.Append("FreightModality"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreightModality)+","); 
  				MasterField.Append("Countryofdischarge"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Countryofdischarge)+","); 
  				MasterField.Append("Insuranceby"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Insuranceby)+","); 
  				MasterField.Append("Shipmentdetails"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Shipmentdetails)+","); 
  				MasterField.Append("Exfacotry"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Exfacotry)+","); 
  				MasterField.Append("Originport"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Originport)+","); 
  				MasterField.Append("Shipmentdate"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Shipmentdate)+","); 
  				MasterField.Append("Destinationprot"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Destinationprot)+","); 
  				MasterField.Append("Paymentterms"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Paymentterms)+","); 
  				MasterField.Append("OrderType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderType)+","); 
  				MasterField.Append("FAID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FAID)+","); 
  				MasterField.Append("Currency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Currency)+","); 
  				MasterField.Append("AuditTime"+","); 
  				if(MasterEntity.AuditTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AuditTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("VAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VAddress)+","); 
  				MasterField.Append("VTel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VTel)+","); 
  				MasterField.Append("VFax"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VFax)+","); 
  				MasterField.Append("EngAmount"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EngAmount)+","); 
  				MasterField.Append("CustomerCode2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CustomerCode2)+","); 
  				MasterField.Append("HKFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HKFlag)+","); 
  				MasterField.Append("BGJFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BGJFlag)+","); 
  				MasterField.Append("HKDate"+","); 
  				if(MasterEntity.HKDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HKDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGJDate"+","); 
  				if(MasterEntity.BGJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BGJDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HKString"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HKString)+","); 
  				MasterField.Append("BGJString"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BGJString)+","); 
  				MasterField.Append("WLVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WLVendorID)+","); 
  				MasterField.Append("WLFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WLFormNo)+","); 
  				MasterField.Append("TotalWeight"+","); 
  				if(MasterEntity.TotalWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalPieceQty"+","); 
  				if(MasterEntity.TotalPieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalYard"+","); 
  				if(MasterEntity.TotalYard!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalYard)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SpecialReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SpecialReq)+","); 
  				MasterField.Append("PackReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackReq)+","); 
  				MasterField.Append("SelaoDu"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SelaoDu)+","); 
  				MasterField.Append("GuangZhaoQiangDu"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GuangZhaoQiangDu)+","); 
  				MasterField.Append("WaiGou"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WaiGou)+",");
                MasterField.Append("ProductTypeID" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.ProductTypeID) + ","); 
  				MasterField.Append("MaiTou"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MaiTou)+")"); 
 
                
                

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
                SaleOrder MasterEntity=(SaleOrder)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_SaleOrder SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
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
  
  				UpdateBuilder.Append(" CSFlag="+SysString.ToDBString(MasterEntity.CSFlag)+","); 
  				 
  				if(MasterEntity.CSTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CSTime="+SysString.ToDBString(MasterEntity.CSTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CSTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" CSOPID="+SysString.ToDBString(MasterEntity.CSOPID)+","); 
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
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" CustomerCode="+SysString.ToDBString(MasterEntity.CustomerCode)+","); 
  				UpdateBuilder.Append(" OrderTypeID="+SysString.ToDBString(MasterEntity.OrderTypeID)+","); 
  				UpdateBuilder.Append(" OrderLevelID="+SysString.ToDBString(MasterEntity.OrderLevelID)+","); 
  				 
  				if(MasterEntity.OrderDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" OrderDate="+SysString.ToDBString(MasterEntity.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OrderDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate="+SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" PayMethodID="+SysString.ToDBString(MasterEntity.PayMethodID)+","); 
  				UpdateBuilder.Append(" ContractDesc="+SysString.ToDBString(MasterEntity.ContractDesc)+","); 
  				 
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
  
  				UpdateBuilder.Append(" OrderPreStepID="+SysString.ToDBString(MasterEntity.OrderPreStepID)+","); 
  				UpdateBuilder.Append(" OrderStepID="+SysString.ToDBString(MasterEntity.OrderStepID)+","); 
  				UpdateBuilder.Append(" PayMethodFlag="+SysString.ToDBString(MasterEntity.PayMethodFlag)+","); 
  				UpdateBuilder.Append(" StatusFlag="+SysString.ToDBString(MasterEntity.StatusFlag)+","); 
  				UpdateBuilder.Append(" StatusName="+SysString.ToDBString(MasterEntity.StatusName)+","); 
  				UpdateBuilder.Append(" WLAmountType="+SysString.ToDBString(MasterEntity.WLAmountType)+","); 
  				 
  				if(MasterEntity.WLAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WLAmount="+SysString.ToDBString(MasterEntity.WLAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WLAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" CancelFlag="+SysString.ToDBString(MasterEntity.CancelFlag)+","); 
  				UpdateBuilder.Append(" CancelReason="+SysString.ToDBString(MasterEntity.CancelReason)+","); 
  				UpdateBuilder.Append(" FKFlag="+SysString.ToDBString(MasterEntity.FKFlag)+","); 
  				UpdateBuilder.Append(" SaleFlowModuleID="+SysString.ToDBString(MasterEntity.SaleFlowModuleID)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" ConvertUnitFlag="+SysString.ToDBString(MasterEntity.ConvertUnitFlag)+","); 
  				UpdateBuilder.Append(" VendorOPID="+SysString.ToDBString(MasterEntity.VendorOPID)+","); 
  				UpdateBuilder.Append(" HQFlag="+SysString.ToDBString(MasterEntity.HQFlag)+","); 
  				UpdateBuilder.Append(" ToMes="+SysString.ToDBString(MasterEntity.ToMes)+","); 
  				UpdateBuilder.Append(" SCNO="+SysString.ToDBString(MasterEntity.SCNO)+","); 
  				UpdateBuilder.Append(" Ref="+SysString.ToDBString(MasterEntity.Ref)+","); 
  				UpdateBuilder.Append(" OrderNo="+SysString.ToDBString(MasterEntity.OrderNo)+","); 
  				UpdateBuilder.Append(" ORIGINOFMERCHANDISE="+SysString.ToDBString(MasterEntity.ORIGINOFMERCHANDISE)+","); 
  				UpdateBuilder.Append(" SHIPPER="+SysString.ToDBString(MasterEntity.SHIPPER)+","); 
  				UpdateBuilder.Append(" Termsofdelivery="+SysString.ToDBString(MasterEntity.Termsofdelivery)+","); 
  				UpdateBuilder.Append(" Countryofloading="+SysString.ToDBString(MasterEntity.Countryofloading)+","); 
  				UpdateBuilder.Append(" Package="+SysString.ToDBString(MasterEntity.Package)+","); 
  				UpdateBuilder.Append(" FreightModality="+SysString.ToDBString(MasterEntity.FreightModality)+","); 
  				UpdateBuilder.Append(" Countryofdischarge="+SysString.ToDBString(MasterEntity.Countryofdischarge)+","); 
  				UpdateBuilder.Append(" Insuranceby="+SysString.ToDBString(MasterEntity.Insuranceby)+","); 
  				UpdateBuilder.Append(" Shipmentdetails="+SysString.ToDBString(MasterEntity.Shipmentdetails)+","); 
  				UpdateBuilder.Append(" Exfacotry="+SysString.ToDBString(MasterEntity.Exfacotry)+","); 
  				UpdateBuilder.Append(" Originport="+SysString.ToDBString(MasterEntity.Originport)+","); 
  				UpdateBuilder.Append(" Shipmentdate="+SysString.ToDBString(MasterEntity.Shipmentdate)+","); 
  				UpdateBuilder.Append(" Destinationprot="+SysString.ToDBString(MasterEntity.Destinationprot)+","); 
  				UpdateBuilder.Append(" Paymentterms="+SysString.ToDBString(MasterEntity.Paymentterms)+","); 
  				UpdateBuilder.Append(" OrderType="+SysString.ToDBString(MasterEntity.OrderType)+","); 
  				UpdateBuilder.Append(" FAID="+SysString.ToDBString(MasterEntity.FAID)+","); 
  				UpdateBuilder.Append(" Currency="+SysString.ToDBString(MasterEntity.Currency)+","); 
  				 
  				if(MasterEntity.AuditTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" AuditTime="+SysString.ToDBString(MasterEntity.AuditTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AuditTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" VAddress="+SysString.ToDBString(MasterEntity.VAddress)+","); 
  				UpdateBuilder.Append(" VTel="+SysString.ToDBString(MasterEntity.VTel)+","); 
  				UpdateBuilder.Append(" VFax="+SysString.ToDBString(MasterEntity.VFax)+","); 
  				UpdateBuilder.Append(" EngAmount="+SysString.ToDBString(MasterEntity.EngAmount)+","); 
  				UpdateBuilder.Append(" CustomerCode2="+SysString.ToDBString(MasterEntity.CustomerCode2)+","); 
  				UpdateBuilder.Append(" HKFlag="+SysString.ToDBString(MasterEntity.HKFlag)+","); 
  				UpdateBuilder.Append(" BGJFlag="+SysString.ToDBString(MasterEntity.BGJFlag)+","); 
  				 
  				if(MasterEntity.HKDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" HKDate="+SysString.ToDBString(MasterEntity.HKDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HKDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.BGJDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" BGJDate="+SysString.ToDBString(MasterEntity.BGJDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BGJDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" HKString="+SysString.ToDBString(MasterEntity.HKString)+","); 
  				UpdateBuilder.Append(" BGJString="+SysString.ToDBString(MasterEntity.BGJString)+","); 
  				UpdateBuilder.Append(" WLVendorID="+SysString.ToDBString(MasterEntity.WLVendorID)+","); 
  				UpdateBuilder.Append(" WLFormNo="+SysString.ToDBString(MasterEntity.WLFormNo)+","); 
  				 
  				if(MasterEntity.TotalWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalWeight="+SysString.ToDBString(MasterEntity.TotalWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalPieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPieceQty="+SysString.ToDBString(MasterEntity.TotalPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalYard!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalYard="+SysString.ToDBString(MasterEntity.TotalYard)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalYard=null,");  
  				} 
  
  				UpdateBuilder.Append(" SpecialReq="+SysString.ToDBString(MasterEntity.SpecialReq)+","); 
  				UpdateBuilder.Append(" PackReq="+SysString.ToDBString(MasterEntity.PackReq)+","); 
  				UpdateBuilder.Append(" SelaoDu="+SysString.ToDBString(MasterEntity.SelaoDu)+","); 
  				UpdateBuilder.Append(" GuangZhaoQiangDu="+SysString.ToDBString(MasterEntity.GuangZhaoQiangDu)+","); 
  				UpdateBuilder.Append(" WaiGou="+SysString.ToDBString(MasterEntity.WaiGou)+",");
                UpdateBuilder.Append(" ProductTypeID=" + SysString.ToDBString(MasterEntity.ProductTypeID) + ","); 
  				UpdateBuilder.Append(" MaiTou="+SysString.ToDBString(MasterEntity.MaiTou)); 
 
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
                SaleOrder MasterEntity=(SaleOrder)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_SaleOrder WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
