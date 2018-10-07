using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_SaleOrder实体类
	/// 作者:zhp
	/// 创建日期:2016/7/6
	/// </summary>
	public sealed class SaleOrder : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrder()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrder(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_SaleOrder";
		 
  		private int m_ID = 0; 
  		public int ID 
  		{ 
  			get 
  			{ 
  				return m_ID ; 
  			}  
  			set 
  			{ 
  				m_ID = value ; 
  			}  
  		} 
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private string m_MakeOPID = string.Empty ; 
  		public string MakeOPID 
  		{ 
  			get 
  			{ 
  				return m_MakeOPID ; 
  			}  
  			set 
  			{ 
  				m_MakeOPID = value ; 
  			}  
  		} 
  
  		private string m_MakeOPName = string.Empty ; 
  		public string MakeOPName 
  		{ 
  			get 
  			{ 
  				return m_MakeOPName ; 
  			}  
  			set 
  			{ 
  				m_MakeOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_MakeDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MakeDate 
  		{ 
  			get 
  			{ 
  				return m_MakeDate ; 
  			}  
  			set 
  			{ 
  				m_MakeDate = value ; 
  			}  
  		} 
  
  		private int m_CSFlag = 0; 
  		public int CSFlag 
  		{ 
  			get 
  			{ 
  				return m_CSFlag ; 
  			}  
  			set 
  			{ 
  				m_CSFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_CSTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CSTime 
  		{ 
  			get 
  			{ 
  				return m_CSTime ; 
  			}  
  			set 
  			{ 
  				m_CSTime = value ; 
  			}  
  		} 
  
  		private string m_CSOPID = string.Empty ; 
  		public string CSOPID 
  		{ 
  			get 
  			{ 
  				return m_CSOPID ; 
  			}  
  			set 
  			{ 
  				m_CSOPID = value ; 
  			}  
  		} 
  
  		private string m_CheckOPID = string.Empty ; 
  		public string CheckOPID 
  		{ 
  			get 
  			{ 
  				return m_CheckOPID ; 
  			}  
  			set 
  			{ 
  				m_CheckOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_CheckDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CheckDate 
  		{ 
  			get 
  			{ 
  				return m_CheckDate ; 
  			}  
  			set 
  			{ 
  				m_CheckDate = value ; 
  			}  
  		} 
  
  		private int m_SubmitFlag = 0; 
  		public int SubmitFlag 
  		{ 
  			get 
  			{ 
  				return m_SubmitFlag ; 
  			}  
  			set 
  			{ 
  				m_SubmitFlag = value ; 
  			}  
  		} 
  
  		private int m_DelFlag = 0; 
  		public int DelFlag 
  		{ 
  			get 
  			{ 
  				return m_DelFlag ; 
  			}  
  			set 
  			{ 
  				m_DelFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private string m_VendorID = string.Empty ; 
  		public string VendorID 
  		{ 
  			get 
  			{ 
  				return m_VendorID ; 
  			}  
  			set 
  			{ 
  				m_VendorID = value ; 
  			}  
  		} 
  
  		private string m_CustomerCode = string.Empty ; 
  		public string CustomerCode 
  		{ 
  			get 
  			{ 
  				return m_CustomerCode ; 
  			}  
  			set 
  			{ 
  				m_CustomerCode = value ; 
  			}  
  		} 
  
  		private int m_OrderTypeID = 0; 
  		public int OrderTypeID 
  		{ 
  			get 
  			{ 
  				return m_OrderTypeID ; 
  			}  
  			set 
  			{ 
  				m_OrderTypeID = value ; 
  			}  
  		} 
  
  		private int m_OrderLevelID = 0; 
  		public int OrderLevelID 
  		{ 
  			get 
  			{ 
  				return m_OrderLevelID ; 
  			}  
  			set 
  			{ 
  				m_OrderLevelID = value ; 
  			}  
  		} 
  
  		private DateTime m_OrderDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OrderDate 
  		{ 
  			get 
  			{ 
  				return m_OrderDate ; 
  			}  
  			set 
  			{ 
  				m_OrderDate = value ; 
  			}  
  		} 
  
  		private DateTime m_ReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReqDate 
  		{ 
  			get 
  			{ 
  				return m_ReqDate ; 
  			}  
  			set 
  			{ 
  				m_ReqDate = value ; 
  			}  
  		} 
  
  		private string m_Remark = string.Empty ; 
  		public string Remark 
  		{ 
  			get 
  			{ 
  				return m_Remark ; 
  			}  
  			set 
  			{ 
  				m_Remark = value ; 
  			}  
  		} 
  
  		private string m_PayMethodID = string.Empty ; 
  		public string PayMethodID 
  		{ 
  			get 
  			{ 
  				return m_PayMethodID ; 
  			}  
  			set 
  			{ 
  				m_PayMethodID = value ; 
  			}  
  		} 
  
  		private string m_ContractDesc = string.Empty ; 
  		public string ContractDesc 
  		{ 
  			get 
  			{ 
  				return m_ContractDesc ; 
  			}  
  			set 
  			{ 
  				m_ContractDesc = value ; 
  			}  
  		} 
  
  		private decimal m_TotalQty = 0; 
  		public decimal TotalQty 
  		{ 
  			get 
  			{ 
  				return m_TotalQty ; 
  			}  
  			set 
  			{ 
  				m_TotalQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalAmount = 0; 
  		public decimal TotalAmount 
  		{ 
  			get 
  			{ 
  				return m_TotalAmount ; 
  			}  
  			set 
  			{ 
  				m_TotalAmount = value ; 
  			}  
  		} 
  
  		private int m_OrderPreStepID = 0; 
  		public int OrderPreStepID 
  		{ 
  			get 
  			{ 
  				return m_OrderPreStepID ; 
  			}  
  			set 
  			{ 
  				m_OrderPreStepID = value ; 
  			}  
  		} 
  
  		private int m_OrderStepID = 0; 
  		public int OrderStepID 
  		{ 
  			get 
  			{ 
  				return m_OrderStepID ; 
  			}  
  			set 
  			{ 
  				m_OrderStepID = value ; 
  			}  
  		} 
  
  		private int m_PayMethodFlag = 0; 
  		public int PayMethodFlag 
  		{ 
  			get 
  			{ 
  				return m_PayMethodFlag ; 
  			}  
  			set 
  			{ 
  				m_PayMethodFlag = value ; 
  			}  
  		} 
  
  		private int m_StatusFlag = 0; 
  		public int StatusFlag 
  		{ 
  			get 
  			{ 
  				return m_StatusFlag ; 
  			}  
  			set 
  			{ 
  				m_StatusFlag = value ; 
  			}  
  		} 
  
  		private string m_StatusName = string.Empty ; 
  		public string StatusName 
  		{ 
  			get 
  			{ 
  				return m_StatusName ; 
  			}  
  			set 
  			{ 
  				m_StatusName = value ; 
  			}  
  		} 
  
  		private int m_WLAmountType = 0; 
  		public int WLAmountType 
  		{ 
  			get 
  			{ 
  				return m_WLAmountType ; 
  			}  
  			set 
  			{ 
  				m_WLAmountType = value ; 
  			}  
  		} 
  
  		private decimal m_WLAmount = 0; 
  		public decimal WLAmount 
  		{ 
  			get 
  			{ 
  				return m_WLAmount ; 
  			}  
  			set 
  			{ 
  				m_WLAmount = value ; 
  			}  
  		} 
  
  		private int m_CancelFlag = 0; 
  		public int CancelFlag 
  		{ 
  			get 
  			{ 
  				return m_CancelFlag ; 
  			}  
  			set 
  			{ 
  				m_CancelFlag = value ; 
  			}  
  		} 
  
  		private string m_CancelReason = string.Empty ; 
  		public string CancelReason 
  		{ 
  			get 
  			{ 
  				return m_CancelReason ; 
  			}  
  			set 
  			{ 
  				m_CancelReason = value ; 
  			}  
  		} 
  
  		private int m_FKFlag = 0; 
  		public int FKFlag 
  		{ 
  			get 
  			{ 
  				return m_FKFlag ; 
  			}  
  			set 
  			{ 
  				m_FKFlag = value ; 
  			}  
  		} 
  
  		private int m_SaleFlowModuleID = 0; 
  		public int SaleFlowModuleID 
  		{ 
  			get 
  			{ 
  				return m_SaleFlowModuleID ; 
  			}  
  			set 
  			{ 
  				m_SaleFlowModuleID = value ; 
  			}  
  		} 
  
  		private string m_SaleOPID = string.Empty ; 
  		public string SaleOPID 
  		{ 
  			get 
  			{ 
  				return m_SaleOPID ; 
  			}  
  			set 
  			{ 
  				m_SaleOPID = value ; 
  			}  
  		} 
  
  		private int m_ConvertUnitFlag = 0; 
  		public int ConvertUnitFlag 
  		{ 
  			get 
  			{ 
  				return m_ConvertUnitFlag ; 
  			}  
  			set 
  			{ 
  				m_ConvertUnitFlag = value ; 
  			}  
  		} 
  
  		private string m_VendorOPID = string.Empty ; 
  		public string VendorOPID 
  		{ 
  			get 
  			{ 
  				return m_VendorOPID ; 
  			}  
  			set 
  			{ 
  				m_VendorOPID = value ; 
  			}  
  		} 
  
  		private int m_HQFlag = 0; 
  		public int HQFlag 
  		{ 
  			get 
  			{ 
  				return m_HQFlag ; 
  			}  
  			set 
  			{ 
  				m_HQFlag = value ; 
  			}  
  		} 
  
  		private string m_ToMes = string.Empty ; 
  		public string ToMes 
  		{ 
  			get 
  			{ 
  				return m_ToMes ; 
  			}  
  			set 
  			{ 
  				m_ToMes = value ; 
  			}  
  		} 
  
  		private string m_SCNO = string.Empty ; 
  		public string SCNO 
  		{ 
  			get 
  			{ 
  				return m_SCNO ; 
  			}  
  			set 
  			{ 
  				m_SCNO = value ; 
  			}  
  		} 
  
  		private string m_Ref = string.Empty ; 
  		public string Ref 
  		{ 
  			get 
  			{ 
  				return m_Ref ; 
  			}  
  			set 
  			{ 
  				m_Ref = value ; 
  			}  
  		} 
  
  		private string m_OrderNo = string.Empty ; 
  		public string OrderNo 
  		{ 
  			get 
  			{ 
  				return m_OrderNo ; 
  			}  
  			set 
  			{ 
  				m_OrderNo = value ; 
  			}  
  		} 
  
  		private string m_ORIGINOFMERCHANDISE = string.Empty ; 
  		public string ORIGINOFMERCHANDISE 
  		{ 
  			get 
  			{ 
  				return m_ORIGINOFMERCHANDISE ; 
  			}  
  			set 
  			{ 
  				m_ORIGINOFMERCHANDISE = value ; 
  			}  
  		} 
  
  		private string m_SHIPPER = string.Empty ; 
  		public string SHIPPER 
  		{ 
  			get 
  			{ 
  				return m_SHIPPER ; 
  			}  
  			set 
  			{ 
  				m_SHIPPER = value ; 
  			}  
  		} 
  
  		private string m_Termsofdelivery = string.Empty ; 
  		public string Termsofdelivery 
  		{ 
  			get 
  			{ 
  				return m_Termsofdelivery ; 
  			}  
  			set 
  			{ 
  				m_Termsofdelivery = value ; 
  			}  
  		} 
  
  		private string m_Countryofloading = string.Empty ; 
  		public string Countryofloading 
  		{ 
  			get 
  			{ 
  				return m_Countryofloading ; 
  			}  
  			set 
  			{ 
  				m_Countryofloading = value ; 
  			}  
  		} 
  
  		private string m_Package = string.Empty ; 
  		public string Package 
  		{ 
  			get 
  			{ 
  				return m_Package ; 
  			}  
  			set 
  			{ 
  				m_Package = value ; 
  			}  
  		} 
  
  		private string m_FreightModality = string.Empty ; 
  		public string FreightModality 
  		{ 
  			get 
  			{ 
  				return m_FreightModality ; 
  			}  
  			set 
  			{ 
  				m_FreightModality = value ; 
  			}  
  		} 
  
  		private string m_Countryofdischarge = string.Empty ; 
  		public string Countryofdischarge 
  		{ 
  			get 
  			{ 
  				return m_Countryofdischarge ; 
  			}  
  			set 
  			{ 
  				m_Countryofdischarge = value ; 
  			}  
  		} 
  
  		private string m_Insuranceby = string.Empty ; 
  		public string Insuranceby 
  		{ 
  			get 
  			{ 
  				return m_Insuranceby ; 
  			}  
  			set 
  			{ 
  				m_Insuranceby = value ; 
  			}  
  		} 
  
  		private string m_Shipmentdetails = string.Empty ; 
  		public string Shipmentdetails 
  		{ 
  			get 
  			{ 
  				return m_Shipmentdetails ; 
  			}  
  			set 
  			{ 
  				m_Shipmentdetails = value ; 
  			}  
  		} 
  
  		private string m_Exfacotry = string.Empty ; 
  		public string Exfacotry 
  		{ 
  			get 
  			{ 
  				return m_Exfacotry ; 
  			}  
  			set 
  			{ 
  				m_Exfacotry = value ; 
  			}  
  		} 
  
  		private string m_Originport = string.Empty ; 
  		public string Originport 
  		{ 
  			get 
  			{ 
  				return m_Originport ; 
  			}  
  			set 
  			{ 
  				m_Originport = value ; 
  			}  
  		} 
  
  		private string m_Shipmentdate = string.Empty ; 
  		public string Shipmentdate 
  		{ 
  			get 
  			{ 
  				return m_Shipmentdate ; 
  			}  
  			set 
  			{ 
  				m_Shipmentdate = value ; 
  			}  
  		} 
  
  		private string m_Destinationprot = string.Empty ; 
  		public string Destinationprot 
  		{ 
  			get 
  			{ 
  				return m_Destinationprot ; 
  			}  
  			set 
  			{ 
  				m_Destinationprot = value ; 
  			}  
  		} 
  
  		private string m_Paymentterms = string.Empty ; 
  		public string Paymentterms 
  		{ 
  			get 
  			{ 
  				return m_Paymentterms ; 
  			}  
  			set 
  			{ 
  				m_Paymentterms = value ; 
  			}  
  		} 
  
  		private string m_OrderType = string.Empty ; 
  		public string OrderType 
  		{ 
  			get 
  			{ 
  				return m_OrderType ; 
  			}  
  			set 
  			{ 
  				m_OrderType = value ; 
  			}  
  		} 
  
  		private int m_FAID = 0; 
  		public int FAID 
  		{ 
  			get 
  			{ 
  				return m_FAID ; 
  			}  
  			set 
  			{ 
  				m_FAID = value ; 
  			}  
  		} 
  
  		private string m_Currency = string.Empty ; 
  		public string Currency 
  		{ 
  			get 
  			{ 
  				return m_Currency ; 
  			}  
  			set 
  			{ 
  				m_Currency = value ; 
  			}  
  		} 
  
  		private DateTime m_AuditTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AuditTime 
  		{ 
  			get 
  			{ 
  				return m_AuditTime ; 
  			}  
  			set 
  			{ 
  				m_AuditTime = value ; 
  			}  
  		} 
  
  		private string m_VAddress = string.Empty ; 
  		public string VAddress 
  		{ 
  			get 
  			{ 
  				return m_VAddress ; 
  			}  
  			set 
  			{ 
  				m_VAddress = value ; 
  			}  
  		} 
  
  		private string m_VTel = string.Empty ; 
  		public string VTel 
  		{ 
  			get 
  			{ 
  				return m_VTel ; 
  			}  
  			set 
  			{ 
  				m_VTel = value ; 
  			}  
  		} 
  
  		private string m_VFax = string.Empty ; 
  		public string VFax 
  		{ 
  			get 
  			{ 
  				return m_VFax ; 
  			}  
  			set 
  			{ 
  				m_VFax = value ; 
  			}  
  		} 
  
  		private string m_EngAmount = string.Empty ; 
  		public string EngAmount 
  		{ 
  			get 
  			{ 
  				return m_EngAmount ; 
  			}  
  			set 
  			{ 
  				m_EngAmount = value ; 
  			}  
  		} 
  
  		private string m_CustomerCode2 = string.Empty ; 
  		public string CustomerCode2 
  		{ 
  			get 
  			{ 
  				return m_CustomerCode2 ; 
  			}  
  			set 
  			{ 
  				m_CustomerCode2 = value ; 
  			}  
  		} 
  
  		private int m_HKFlag = 0; 
  		public int HKFlag 
  		{ 
  			get 
  			{ 
  				return m_HKFlag ; 
  			}  
  			set 
  			{ 
  				m_HKFlag = value ; 
  			}  
  		} 
  
  		private int m_BGJFlag = 0; 
  		public int BGJFlag 
  		{ 
  			get 
  			{ 
  				return m_BGJFlag ; 
  			}  
  			set 
  			{ 
  				m_BGJFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_HKDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime HKDate 
  		{ 
  			get 
  			{ 
  				return m_HKDate ; 
  			}  
  			set 
  			{ 
  				m_HKDate = value ; 
  			}  
  		} 
  
  		private DateTime m_BGJDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime BGJDate 
  		{ 
  			get 
  			{ 
  				return m_BGJDate ; 
  			}  
  			set 
  			{ 
  				m_BGJDate = value ; 
  			}  
  		} 
  
  		private string m_HKString = string.Empty ; 
  		public string HKString 
  		{ 
  			get 
  			{ 
  				return m_HKString ; 
  			}  
  			set 
  			{ 
  				m_HKString = value ; 
  			}  
  		} 
  
  		private string m_BGJString = string.Empty ; 
  		public string BGJString 
  		{ 
  			get 
  			{ 
  				return m_BGJString ; 
  			}  
  			set 
  			{ 
  				m_BGJString = value ; 
  			}  
  		} 
  
  		private string m_WLVendorID = string.Empty ; 
  		public string WLVendorID 
  		{ 
  			get 
  			{ 
  				return m_WLVendorID ; 
  			}  
  			set 
  			{ 
  				m_WLVendorID = value ; 
  			}  
  		} 
  
  		private string m_WLFormNo = string.Empty ; 
  		public string WLFormNo 
  		{ 
  			get 
  			{ 
  				return m_WLFormNo ; 
  			}  
  			set 
  			{ 
  				m_WLFormNo = value ; 
  			}  
  		} 
  
  		private decimal m_TotalWeight = 0; 
  		public decimal TotalWeight 
  		{ 
  			get 
  			{ 
  				return m_TotalWeight ; 
  			}  
  			set 
  			{ 
  				m_TotalWeight = value ; 
  			}  
  		} 
  
  		private int m_TotalPieceQty = 0; 
  		public int TotalPieceQty 
  		{ 
  			get 
  			{ 
  				return m_TotalPieceQty ; 
  			}  
  			set 
  			{ 
  				m_TotalPieceQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalYard = 0; 
  		public decimal TotalYard 
  		{ 
  			get 
  			{ 
  				return m_TotalYard ; 
  			}  
  			set 
  			{ 
  				m_TotalYard = value ; 
  			}  
  		} 
  
  		private string m_SpecialReq = string.Empty ; 
  		public string SpecialReq 
  		{ 
  			get 
  			{ 
  				return m_SpecialReq ; 
  			}  
  			set 
  			{ 
  				m_SpecialReq = value ; 
  			}  
  		} 
  
  		private string m_PackReq = string.Empty ; 
  		public string PackReq 
  		{ 
  			get 
  			{ 
  				return m_PackReq ; 
  			}  
  			set 
  			{ 
  				m_PackReq = value ; 
  			}  
  		} 
  
  		private string m_SelaoDu = string.Empty ; 
  		public string SelaoDu 
  		{ 
  			get 
  			{ 
  				return m_SelaoDu ; 
  			}  
  			set 
  			{ 
  				m_SelaoDu = value ; 
  			}  
  		} 
  
  		private string m_GuangZhaoQiangDu = string.Empty ; 
  		public string GuangZhaoQiangDu 
  		{ 
  			get 
  			{ 
  				return m_GuangZhaoQiangDu ; 
  			}  
  			set 
  			{ 
  				m_GuangZhaoQiangDu = value ; 
  			}  
  		} 
  
  		private string m_WaiGou = string.Empty ; 
  		public string WaiGou 
  		{ 
  			get 
  			{ 
  				return m_WaiGou ; 
  			}  
  			set 
  			{ 
  				m_WaiGou = value ; 
  			}  
  		}
        private int m_ProductTypeID = 0;
        public int ProductTypeID
        {
            get
            {
                return m_ProductTypeID;
            }
            set
            {
                m_ProductTypeID = value;
            }
        }
  
  		private string m_MaiTou = string.Empty ; 
  		public string MaiTou 
  		{ 
  			get 
  			{ 
  				return m_MaiTou ; 
  			}  
  			set 
  			{ 
  				m_MaiTou = value ; 
  			}  
  		} 
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Sale_SaleOrder WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrder WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按传入的SQL语句查询后给属性赋值
        /// </summary>
        /// <param name="p_Sql">SQL语句</param>
        /// <returns>记录存在回true，不存在返回false</returns>
        protected override bool Select(string p_Sql)
        {
            DataTable MasterTable=new DataTable();
            if(!this.sqlTransFlag)
			{
				MasterTable=this.Fill(p_Sql);
			}
			else
			{
				MasterTable=sqlTrans.Fill(p_Sql);
			}
				
            if (MasterTable.Rows.Count>0)
            {
                //查询主表记录
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CSFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CSFlag"]); 
  				m_CSTime=SysConvert.ToDateTime(MasterTable.Rows[0]["CSTime"]); 
  				m_CSOPID=SysConvert.ToString(MasterTable.Rows[0]["CSOPID"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_CustomerCode=SysConvert.ToString(MasterTable.Rows[0]["CustomerCode"]); 
  				m_OrderTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderTypeID"]); 
  				m_OrderLevelID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderLevelID"]); 
  				m_OrderDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OrderDate"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_PayMethodID=SysConvert.ToString(MasterTable.Rows[0]["PayMethodID"]); 
  				m_ContractDesc=SysConvert.ToString(MasterTable.Rows[0]["ContractDesc"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_OrderPreStepID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderPreStepID"]); 
  				m_OrderStepID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderStepID"]); 
  				m_PayMethodFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PayMethodFlag"]); 
  				m_StatusFlag=SysConvert.ToInt32(MasterTable.Rows[0]["StatusFlag"]); 
  				m_StatusName=SysConvert.ToString(MasterTable.Rows[0]["StatusName"]); 
  				m_WLAmountType=SysConvert.ToInt32(MasterTable.Rows[0]["WLAmountType"]); 
  				m_WLAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["WLAmount"]); 
  				m_CancelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CancelFlag"]); 
  				m_CancelReason=SysConvert.ToString(MasterTable.Rows[0]["CancelReason"]); 
  				m_FKFlag=SysConvert.ToInt32(MasterTable.Rows[0]["FKFlag"]); 
  				m_SaleFlowModuleID=SysConvert.ToInt32(MasterTable.Rows[0]["SaleFlowModuleID"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_ConvertUnitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ConvertUnitFlag"]); 
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_HQFlag=SysConvert.ToInt32(MasterTable.Rows[0]["HQFlag"]); 
  				m_ToMes=SysConvert.ToString(MasterTable.Rows[0]["ToMes"]); 
  				m_SCNO=SysConvert.ToString(MasterTable.Rows[0]["SCNO"]); 
  				m_Ref=SysConvert.ToString(MasterTable.Rows[0]["Ref"]); 
  				m_OrderNo=SysConvert.ToString(MasterTable.Rows[0]["OrderNo"]); 
  				m_ORIGINOFMERCHANDISE=SysConvert.ToString(MasterTable.Rows[0]["ORIGINOFMERCHANDISE"]); 
  				m_SHIPPER=SysConvert.ToString(MasterTable.Rows[0]["SHIPPER"]); 
  				m_Termsofdelivery=SysConvert.ToString(MasterTable.Rows[0]["Termsofdelivery"]); 
  				m_Countryofloading=SysConvert.ToString(MasterTable.Rows[0]["Countryofloading"]); 
  				m_Package=SysConvert.ToString(MasterTable.Rows[0]["Package"]); 
  				m_FreightModality=SysConvert.ToString(MasterTable.Rows[0]["FreightModality"]); 
  				m_Countryofdischarge=SysConvert.ToString(MasterTable.Rows[0]["Countryofdischarge"]); 
  				m_Insuranceby=SysConvert.ToString(MasterTable.Rows[0]["Insuranceby"]); 
  				m_Shipmentdetails=SysConvert.ToString(MasterTable.Rows[0]["Shipmentdetails"]); 
  				m_Exfacotry=SysConvert.ToString(MasterTable.Rows[0]["Exfacotry"]); 
  				m_Originport=SysConvert.ToString(MasterTable.Rows[0]["Originport"]); 
  				m_Shipmentdate=SysConvert.ToString(MasterTable.Rows[0]["Shipmentdate"]); 
  				m_Destinationprot=SysConvert.ToString(MasterTable.Rows[0]["Destinationprot"]); 
  				m_Paymentterms=SysConvert.ToString(MasterTable.Rows[0]["Paymentterms"]); 
  				m_OrderType=SysConvert.ToString(MasterTable.Rows[0]["OrderType"]); 
  				m_FAID=SysConvert.ToInt32(MasterTable.Rows[0]["FAID"]); 
  				m_Currency=SysConvert.ToString(MasterTable.Rows[0]["Currency"]); 
  				m_AuditTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AuditTime"]); 
  				m_VAddress=SysConvert.ToString(MasterTable.Rows[0]["VAddress"]); 
  				m_VTel=SysConvert.ToString(MasterTable.Rows[0]["VTel"]); 
  				m_VFax=SysConvert.ToString(MasterTable.Rows[0]["VFax"]); 
  				m_EngAmount=SysConvert.ToString(MasterTable.Rows[0]["EngAmount"]); 
  				m_CustomerCode2=SysConvert.ToString(MasterTable.Rows[0]["CustomerCode2"]); 
  				m_HKFlag=SysConvert.ToInt32(MasterTable.Rows[0]["HKFlag"]); 
  				m_BGJFlag=SysConvert.ToInt32(MasterTable.Rows[0]["BGJFlag"]); 
  				m_HKDate=SysConvert.ToDateTime(MasterTable.Rows[0]["HKDate"]); 
  				m_BGJDate=SysConvert.ToDateTime(MasterTable.Rows[0]["BGJDate"]); 
  				m_HKString=SysConvert.ToString(MasterTable.Rows[0]["HKString"]); 
  				m_BGJString=SysConvert.ToString(MasterTable.Rows[0]["BGJString"]); 
  				m_WLVendorID=SysConvert.ToString(MasterTable.Rows[0]["WLVendorID"]); 
  				m_WLFormNo=SysConvert.ToString(MasterTable.Rows[0]["WLFormNo"]); 
  				m_TotalWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalWeight"]); 
  				m_TotalPieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["TotalPieceQty"]); 
  				m_TotalYard=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalYard"]); 
  				m_SpecialReq=SysConvert.ToString(MasterTable.Rows[0]["SpecialReq"]); 
  				m_PackReq=SysConvert.ToString(MasterTable.Rows[0]["PackReq"]); 
  				m_SelaoDu=SysConvert.ToString(MasterTable.Rows[0]["SelaoDu"]); 
  				m_GuangZhaoQiangDu=SysConvert.ToString(MasterTable.Rows[0]["GuangZhaoQiangDu"]); 
  				m_WaiGou=SysConvert.ToString(MasterTable.Rows[0]["WaiGou"]);
                m_ProductTypeID = SysConvert.ToInt32(MasterTable.Rows[0]["ProductTypeID"]); 
  				m_MaiTou=SysConvert.ToString(MasterTable.Rows[0]["MaiTou"]); 
                MasterTable.Dispose();
                return true;
            }
            else
            {
                MasterTable.Dispose();
                return false;
            }
        }
	}
}
