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
	/// 目的：Ship_Custom实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/23
	/// </summary>
	public sealed class CustomCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CustomCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CustomCtl(IDBTransAccess p_SqlCmd)
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
                Custom MasterEntity=(Custom)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Ship_Custom(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("SO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SO)+","); 
  				MasterField.Append("InvoiceDate"+","); 
  				if(MasterEntity.InvoiceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InvoiceNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("Messrs"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Messrs)+","); 
  				MasterField.Append("ShipMethod"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShipMethod)+","); 
  				MasterField.Append("ShipFrom"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShipFrom)+","); 
  				MasterField.Append("ShipTo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShipTo)+","); 
  				MasterField.Append("ShipDate"+","); 
  				if(MasterEntity.ShipDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ShipDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MidChange"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MidChange)+","); 
  				MasterField.Append("ContractNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ContractNo)+","); 
  				MasterField.Append("LCNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LCNO)+","); 
  				MasterField.Append("SCNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SCNo)+","); 
  				MasterField.Append("SaleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleNo)+","); 
  				MasterField.Append("MarkNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MarkNo)+","); 
  				MasterField.Append("Description"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Description)+","); 
  				MasterField.Append("TradeType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TradeType)+","); 
  				MasterField.Append("GainType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GainType)+","); 
  				MasterField.Append("TotalQty"+","); 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Currency"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Currency)+","); 
  				MasterField.Append("Rate"+","); 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("TotalCtnQty"+","); 
  				if(MasterEntity.TotalCtnQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalCtnQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalCrossWeight"+","); 
  				if(MasterEntity.TotalCrossWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalCrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalNetWeight"+","); 
  				if(MasterEntity.TotalNetWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalNetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalBulk"+","); 
  				if(MasterEntity.TotalBulk!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalBulk)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("IssueBank"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.IssueBank)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("AuditOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AuditOPID)+","); 
  				MasterField.Append("AuditTime"+","); 
  				if(MasterEntity.AuditTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AuditTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LastUpdTime"+","); 
  				if(MasterEntity.LastUpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LastUpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LastUpdOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LastUpdOPID)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("HSCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HSCode)+","); 
  				MasterField.Append("CustomFee"+","); 
  				if(MasterEntity.CustomFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CustomFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OthFee"+","); 
  				if(MasterEntity.OthFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OthFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FeeRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FeeRemark)+","); 
  				MasterField.Append("BGDate"+","); 
  				if(MasterEntity.BGDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BGDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JHFS"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JHFS)+","); 
  				MasterField.Append("BZZL"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BZZL)+","); 
  				MasterField.Append("FROMADDR"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FROMADDR)+","); 
  				MasterField.Append("TOADDR"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TOADDR)+","); 
  				MasterField.Append("BANo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BANo)+","); 
  				MasterField.Append("SBDate"+","); 
  				if(MasterEntity.SBDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SBDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZMXZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZMXZ)+","); 
  				MasterField.Append("XKNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XKNo)+","); 
  				MasterField.Append("PZNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PZNo)+","); 
  				MasterField.Append("HTNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTNo)+","); 
  				MasterField.Append("SCS"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SCS)+","); 
  				MasterField.Append("KHDM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KHDM)+","); 
  				MasterField.Append("BoxStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BoxStd)+","); 
  				MasterField.Append("TotalNet"+","); 
  				if(MasterEntity.TotalNet!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalNet)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalGross"+","); 
  				if(MasterEntity.TotalGross!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalGross)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("ZX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZX)+","); 
  				MasterField.Append("ZXType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZXType)+","); 
  				MasterField.Append("YSFS"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YSFS)+","); 
  				MasterField.Append("FormListAID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormListAID)+","); 
  				MasterField.Append("TotalAmount"+","); 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YAmount"+","); 
  				if(MasterEntity.YAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YPercent"+","); 
  				if(MasterEntity.YPercent!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YPercent)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SAmount"+","); 
  				if(MasterEntity.SAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LastSKDate"+","); 
  				if(MasterEntity.LastSKDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.LastSKDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SHDate"+","); 
  				if(MasterEntity.SHDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SHDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YSTotalAmount"+","); 
  				if(MasterEntity.YSTotalAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YSTotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("QGFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QGFlag)+","); 
  				MasterField.Append("ZFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZFormNo)+","); 
  				MasterField.Append("TranFee"+","); 
  				if(MasterEntity.TranFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TranFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ProFee"+","); 
  				if(MasterEntity.ProFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ProFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OtherFee"+")"); 
  				if(MasterEntity.OtherFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OtherFee)+")"); 
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
                Custom MasterEntity=(Custom)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Ship_Custom SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" SO="+SysString.ToDBString(MasterEntity.SO)+","); 
  				 
  				if(MasterEntity.InvoiceDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceDate="+SysString.ToDBString(MasterEntity.InvoiceDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" InvoiceNo="+SysString.ToDBString(MasterEntity.InvoiceNo)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" Messrs="+SysString.ToDBString(MasterEntity.Messrs)+","); 
  				UpdateBuilder.Append(" ShipMethod="+SysString.ToDBString(MasterEntity.ShipMethod)+","); 
  				UpdateBuilder.Append(" ShipFrom="+SysString.ToDBString(MasterEntity.ShipFrom)+","); 
  				UpdateBuilder.Append(" ShipTo="+SysString.ToDBString(MasterEntity.ShipTo)+","); 
  				 
  				if(MasterEntity.ShipDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ShipDate="+SysString.ToDBString(MasterEntity.ShipDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ShipDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" MidChange="+SysString.ToDBString(MasterEntity.MidChange)+","); 
  				UpdateBuilder.Append(" ContractNo="+SysString.ToDBString(MasterEntity.ContractNo)+","); 
  				UpdateBuilder.Append(" LCNO="+SysString.ToDBString(MasterEntity.LCNO)+","); 
  				UpdateBuilder.Append(" SCNo="+SysString.ToDBString(MasterEntity.SCNo)+","); 
  				UpdateBuilder.Append(" SaleNo="+SysString.ToDBString(MasterEntity.SaleNo)+","); 
  				UpdateBuilder.Append(" MarkNo="+SysString.ToDBString(MasterEntity.MarkNo)+","); 
  				UpdateBuilder.Append(" Description="+SysString.ToDBString(MasterEntity.Description)+","); 
  				UpdateBuilder.Append(" TradeType="+SysString.ToDBString(MasterEntity.TradeType)+","); 
  				UpdateBuilder.Append(" GainType="+SysString.ToDBString(MasterEntity.GainType)+","); 
  				 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty="+SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Currency="+SysString.ToDBString(MasterEntity.Currency)+","); 
  				 
  				if(MasterEntity.Rate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Rate="+SysString.ToDBString(MasterEntity.Rate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Rate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.TotalCtnQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalCtnQty="+SysString.ToDBString(MasterEntity.TotalCtnQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalCtnQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalCrossWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalCrossWeight="+SysString.ToDBString(MasterEntity.TotalCrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalCrossWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalNetWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalNetWeight="+SysString.ToDBString(MasterEntity.TotalNetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalNetWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalBulk!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalBulk="+SysString.ToDBString(MasterEntity.TotalBulk)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalBulk=null,");  
  				} 
  
  				UpdateBuilder.Append(" IssueBank="+SysString.ToDBString(MasterEntity.IssueBank)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" AuditOPID="+SysString.ToDBString(MasterEntity.AuditOPID)+","); 
  				 
  				if(MasterEntity.AuditTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" AuditTime="+SysString.ToDBString(MasterEntity.AuditTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AuditTime=null,");  
  				} 
  
  				 
  				if(MasterEntity.LastUpdTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime="+SysString.ToDBString(MasterEntity.LastUpdTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LastUpdTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" LastUpdOPID="+SysString.ToDBString(MasterEntity.LastUpdOPID)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" HSCode="+SysString.ToDBString(MasterEntity.HSCode)+","); 
  				 
  				if(MasterEntity.CustomFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CustomFee="+SysString.ToDBString(MasterEntity.CustomFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CustomFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.OthFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OthFee="+SysString.ToDBString(MasterEntity.OthFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OthFee=null,");  
  				} 
  
  				UpdateBuilder.Append(" FeeRemark="+SysString.ToDBString(MasterEntity.FeeRemark)+","); 
  				 
  				if(MasterEntity.BGDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" BGDate="+SysString.ToDBString(MasterEntity.BGDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BGDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" JHFS="+SysString.ToDBString(MasterEntity.JHFS)+","); 
  				UpdateBuilder.Append(" BZZL="+SysString.ToDBString(MasterEntity.BZZL)+","); 
  				UpdateBuilder.Append(" FROMADDR="+SysString.ToDBString(MasterEntity.FROMADDR)+","); 
  				UpdateBuilder.Append(" TOADDR="+SysString.ToDBString(MasterEntity.TOADDR)+","); 
  				UpdateBuilder.Append(" BANo="+SysString.ToDBString(MasterEntity.BANo)+","); 
  				 
  				if(MasterEntity.SBDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SBDate="+SysString.ToDBString(MasterEntity.SBDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SBDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" ZMXZ="+SysString.ToDBString(MasterEntity.ZMXZ)+","); 
  				UpdateBuilder.Append(" XKNo="+SysString.ToDBString(MasterEntity.XKNo)+","); 
  				UpdateBuilder.Append(" PZNo="+SysString.ToDBString(MasterEntity.PZNo)+","); 
  				UpdateBuilder.Append(" HTNo="+SysString.ToDBString(MasterEntity.HTNo)+","); 
  				UpdateBuilder.Append(" SCS="+SysString.ToDBString(MasterEntity.SCS)+","); 
  				UpdateBuilder.Append(" KHDM="+SysString.ToDBString(MasterEntity.KHDM)+","); 
  				UpdateBuilder.Append(" BoxStd="+SysString.ToDBString(MasterEntity.BoxStd)+","); 
  				 
  				if(MasterEntity.TotalNet!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalNet="+SysString.ToDBString(MasterEntity.TotalNet)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalNet=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalGross!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalGross="+SysString.ToDBString(MasterEntity.TotalGross)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalGross=null,");  
  				} 
  
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" ZX="+SysString.ToDBString(MasterEntity.ZX)+","); 
  				UpdateBuilder.Append(" ZXType="+SysString.ToDBString(MasterEntity.ZXType)+","); 
  				UpdateBuilder.Append(" YSFS="+SysString.ToDBString(MasterEntity.YSFS)+","); 
  				UpdateBuilder.Append(" FormListAID="+SysString.ToDBString(MasterEntity.FormListAID)+","); 
  				 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount="+SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.YAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YAmount="+SysString.ToDBString(MasterEntity.YAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.YPercent!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YPercent="+SysString.ToDBString(MasterEntity.YPercent)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YPercent=null,");  
  				} 
  
  				 
  				if(MasterEntity.SAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SAmount="+SysString.ToDBString(MasterEntity.SAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.LastSKDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" LastSKDate="+SysString.ToDBString(MasterEntity.LastSKDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" LastSKDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.SHDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SHDate="+SysString.ToDBString(MasterEntity.SHDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SHDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.YSTotalAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YSTotalAmount="+SysString.ToDBString(MasterEntity.YSTotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YSTotalAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" QGFlag="+SysString.ToDBString(MasterEntity.QGFlag)+","); 
  				UpdateBuilder.Append(" ZFormNo="+SysString.ToDBString(MasterEntity.ZFormNo)+","); 
  				 
  				if(MasterEntity.TranFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TranFee="+SysString.ToDBString(MasterEntity.TranFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TranFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.ProFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ProFee="+SysString.ToDBString(MasterEntity.ProFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ProFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.OtherFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OtherFee="+SysString.ToDBString(MasterEntity.OtherFee)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OtherFee=null");  
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
                Custom MasterEntity=(Custom)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Ship_Custom WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
