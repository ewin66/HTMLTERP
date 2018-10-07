using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Ship_Custom实体类
	/// 作者:qiuchao
	/// 创建日期:2015/7/23
	/// </summary>
	public sealed class Custom : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Custom()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Custom(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Ship_Custom";
		 
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
  
  		private int m_CompanyTypeID = 0; 
  		public int CompanyTypeID 
  		{ 
  			get 
  			{ 
  				return m_CompanyTypeID ; 
  			}  
  			set 
  			{ 
  				m_CompanyTypeID = value ; 
  			}  
  		} 
  
  		private string m_SO = string.Empty ; 
  		public string SO 
  		{ 
  			get 
  			{ 
  				return m_SO ; 
  			}  
  			set 
  			{ 
  				m_SO = value ; 
  			}  
  		} 
  
  		private DateTime m_InvoiceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InvoiceDate 
  		{ 
  			get 
  			{ 
  				return m_InvoiceDate ; 
  			}  
  			set 
  			{ 
  				m_InvoiceDate = value ; 
  			}  
  		} 
  
  		private string m_InvoiceNo = string.Empty ; 
  		public string InvoiceNo 
  		{ 
  			get 
  			{ 
  				return m_InvoiceNo ; 
  			}  
  			set 
  			{ 
  				m_InvoiceNo = value ; 
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
  
  		private string m_Messrs = string.Empty ; 
  		public string Messrs 
  		{ 
  			get 
  			{ 
  				return m_Messrs ; 
  			}  
  			set 
  			{ 
  				m_Messrs = value ; 
  			}  
  		} 
  
  		private string m_ShipMethod = string.Empty ; 
  		public string ShipMethod 
  		{ 
  			get 
  			{ 
  				return m_ShipMethod ; 
  			}  
  			set 
  			{ 
  				m_ShipMethod = value ; 
  			}  
  		} 
  
  		private string m_ShipFrom = string.Empty ; 
  		public string ShipFrom 
  		{ 
  			get 
  			{ 
  				return m_ShipFrom ; 
  			}  
  			set 
  			{ 
  				m_ShipFrom = value ; 
  			}  
  		} 
  
  		private string m_ShipTo = string.Empty ; 
  		public string ShipTo 
  		{ 
  			get 
  			{ 
  				return m_ShipTo ; 
  			}  
  			set 
  			{ 
  				m_ShipTo = value ; 
  			}  
  		} 
  
  		private DateTime m_ShipDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ShipDate 
  		{ 
  			get 
  			{ 
  				return m_ShipDate ; 
  			}  
  			set 
  			{ 
  				m_ShipDate = value ; 
  			}  
  		} 
  
  		private string m_MidChange = string.Empty ; 
  		public string MidChange 
  		{ 
  			get 
  			{ 
  				return m_MidChange ; 
  			}  
  			set 
  			{ 
  				m_MidChange = value ; 
  			}  
  		} 
  
  		private string m_ContractNo = string.Empty ; 
  		public string ContractNo 
  		{ 
  			get 
  			{ 
  				return m_ContractNo ; 
  			}  
  			set 
  			{ 
  				m_ContractNo = value ; 
  			}  
  		} 
  
  		private string m_LCNO = string.Empty ; 
  		public string LCNO 
  		{ 
  			get 
  			{ 
  				return m_LCNO ; 
  			}  
  			set 
  			{ 
  				m_LCNO = value ; 
  			}  
  		} 
  
  		private string m_SCNo = string.Empty ; 
  		public string SCNo 
  		{ 
  			get 
  			{ 
  				return m_SCNo ; 
  			}  
  			set 
  			{ 
  				m_SCNo = value ; 
  			}  
  		} 
  
  		private string m_SaleNo = string.Empty ; 
  		public string SaleNo 
  		{ 
  			get 
  			{ 
  				return m_SaleNo ; 
  			}  
  			set 
  			{ 
  				m_SaleNo = value ; 
  			}  
  		} 
  
  		private string m_MarkNo = string.Empty ; 
  		public string MarkNo 
  		{ 
  			get 
  			{ 
  				return m_MarkNo ; 
  			}  
  			set 
  			{ 
  				m_MarkNo = value ; 
  			}  
  		} 
  
  		private string m_Description = string.Empty ; 
  		public string Description 
  		{ 
  			get 
  			{ 
  				return m_Description ; 
  			}  
  			set 
  			{ 
  				m_Description = value ; 
  			}  
  		} 
  
  		private string m_TradeType = string.Empty ; 
  		public string TradeType 
  		{ 
  			get 
  			{ 
  				return m_TradeType ; 
  			}  
  			set 
  			{ 
  				m_TradeType = value ; 
  			}  
  		} 
  
  		private string m_GainType = string.Empty ; 
  		public string GainType 
  		{ 
  			get 
  			{ 
  				return m_GainType ; 
  			}  
  			set 
  			{ 
  				m_GainType = value ; 
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
  
  		private decimal m_Rate = 0; 
  		public decimal Rate 
  		{ 
  			get 
  			{ 
  				return m_Rate ; 
  			}  
  			set 
  			{ 
  				m_Rate = value ; 
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
  
  		private decimal m_TotalCtnQty = 0; 
  		public decimal TotalCtnQty 
  		{ 
  			get 
  			{ 
  				return m_TotalCtnQty ; 
  			}  
  			set 
  			{ 
  				m_TotalCtnQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalCrossWeight = 0; 
  		public decimal TotalCrossWeight 
  		{ 
  			get 
  			{ 
  				return m_TotalCrossWeight ; 
  			}  
  			set 
  			{ 
  				m_TotalCrossWeight = value ; 
  			}  
  		} 
  
  		private decimal m_TotalNetWeight = 0; 
  		public decimal TotalNetWeight 
  		{ 
  			get 
  			{ 
  				return m_TotalNetWeight ; 
  			}  
  			set 
  			{ 
  				m_TotalNetWeight = value ; 
  			}  
  		} 
  
  		private decimal m_TotalBulk = 0; 
  		public decimal TotalBulk 
  		{ 
  			get 
  			{ 
  				return m_TotalBulk ; 
  			}  
  			set 
  			{ 
  				m_TotalBulk = value ; 
  			}  
  		} 
  
  		private string m_IssueBank = string.Empty ; 
  		public string IssueBank 
  		{ 
  			get 
  			{ 
  				return m_IssueBank ; 
  			}  
  			set 
  			{ 
  				m_IssueBank = value ; 
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
  
  		private string m_AuditOPID = string.Empty ; 
  		public string AuditOPID 
  		{ 
  			get 
  			{ 
  				return m_AuditOPID ; 
  			}  
  			set 
  			{ 
  				m_AuditOPID = value ; 
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
  
  		private DateTime m_LastUpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LastUpdTime 
  		{ 
  			get 
  			{ 
  				return m_LastUpdTime ; 
  			}  
  			set 
  			{ 
  				m_LastUpdTime = value ; 
  			}  
  		} 
  
  		private string m_LastUpdOPID = string.Empty ; 
  		public string LastUpdOPID 
  		{ 
  			get 
  			{ 
  				return m_LastUpdOPID ; 
  			}  
  			set 
  			{ 
  				m_LastUpdOPID = value ; 
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
  
  		private string m_HSCode = string.Empty ; 
  		public string HSCode 
  		{ 
  			get 
  			{ 
  				return m_HSCode ; 
  			}  
  			set 
  			{ 
  				m_HSCode = value ; 
  			}  
  		} 
  
  		private decimal m_CustomFee = 0; 
  		public decimal CustomFee 
  		{ 
  			get 
  			{ 
  				return m_CustomFee ; 
  			}  
  			set 
  			{ 
  				m_CustomFee = value ; 
  			}  
  		} 
  
  		private decimal m_OthFee = 0; 
  		public decimal OthFee 
  		{ 
  			get 
  			{ 
  				return m_OthFee ; 
  			}  
  			set 
  			{ 
  				m_OthFee = value ; 
  			}  
  		} 
  
  		private string m_FeeRemark = string.Empty ; 
  		public string FeeRemark 
  		{ 
  			get 
  			{ 
  				return m_FeeRemark ; 
  			}  
  			set 
  			{ 
  				m_FeeRemark = value ; 
  			}  
  		} 
  
  		private DateTime m_BGDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime BGDate 
  		{ 
  			get 
  			{ 
  				return m_BGDate ; 
  			}  
  			set 
  			{ 
  				m_BGDate = value ; 
  			}  
  		} 
  
  		private string m_JHFS = string.Empty ; 
  		public string JHFS 
  		{ 
  			get 
  			{ 
  				return m_JHFS ; 
  			}  
  			set 
  			{ 
  				m_JHFS = value ; 
  			}  
  		} 
  
  		private string m_BZZL = string.Empty ; 
  		public string BZZL 
  		{ 
  			get 
  			{ 
  				return m_BZZL ; 
  			}  
  			set 
  			{ 
  				m_BZZL = value ; 
  			}  
  		} 
  
  		private string m_FROMADDR = string.Empty ; 
  		public string FROMADDR 
  		{ 
  			get 
  			{ 
  				return m_FROMADDR ; 
  			}  
  			set 
  			{ 
  				m_FROMADDR = value ; 
  			}  
  		} 
  
  		private string m_TOADDR = string.Empty ; 
  		public string TOADDR 
  		{ 
  			get 
  			{ 
  				return m_TOADDR ; 
  			}  
  			set 
  			{ 
  				m_TOADDR = value ; 
  			}  
  		} 
  
  		private string m_BANo = string.Empty ; 
  		public string BANo 
  		{ 
  			get 
  			{ 
  				return m_BANo ; 
  			}  
  			set 
  			{ 
  				m_BANo = value ; 
  			}  
  		} 
  
  		private DateTime m_SBDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SBDate 
  		{ 
  			get 
  			{ 
  				return m_SBDate ; 
  			}  
  			set 
  			{ 
  				m_SBDate = value ; 
  			}  
  		} 
  
  		private string m_ZMXZ = string.Empty ; 
  		public string ZMXZ 
  		{ 
  			get 
  			{ 
  				return m_ZMXZ ; 
  			}  
  			set 
  			{ 
  				m_ZMXZ = value ; 
  			}  
  		} 
  
  		private string m_XKNo = string.Empty ; 
  		public string XKNo 
  		{ 
  			get 
  			{ 
  				return m_XKNo ; 
  			}  
  			set 
  			{ 
  				m_XKNo = value ; 
  			}  
  		} 
  
  		private string m_PZNo = string.Empty ; 
  		public string PZNo 
  		{ 
  			get 
  			{ 
  				return m_PZNo ; 
  			}  
  			set 
  			{ 
  				m_PZNo = value ; 
  			}  
  		} 
  
  		private string m_HTNo = string.Empty ; 
  		public string HTNo 
  		{ 
  			get 
  			{ 
  				return m_HTNo ; 
  			}  
  			set 
  			{ 
  				m_HTNo = value ; 
  			}  
  		} 
  
  		private string m_SCS = string.Empty ; 
  		public string SCS 
  		{ 
  			get 
  			{ 
  				return m_SCS ; 
  			}  
  			set 
  			{ 
  				m_SCS = value ; 
  			}  
  		} 
  
  		private string m_KHDM = string.Empty ; 
  		public string KHDM 
  		{ 
  			get 
  			{ 
  				return m_KHDM ; 
  			}  
  			set 
  			{ 
  				m_KHDM = value ; 
  			}  
  		} 
  
  		private string m_BoxStd = string.Empty ; 
  		public string BoxStd 
  		{ 
  			get 
  			{ 
  				return m_BoxStd ; 
  			}  
  			set 
  			{ 
  				m_BoxStd = value ; 
  			}  
  		} 
  
  		private decimal m_TotalNet = 0; 
  		public decimal TotalNet 
  		{ 
  			get 
  			{ 
  				return m_TotalNet ; 
  			}  
  			set 
  			{ 
  				m_TotalNet = value ; 
  			}  
  		} 
  
  		private decimal m_TotalGross = 0; 
  		public decimal TotalGross 
  		{ 
  			get 
  			{ 
  				return m_TotalGross ; 
  			}  
  			set 
  			{ 
  				m_TotalGross = value ; 
  			}  
  		} 
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
  			}  
  		} 
  
  		private string m_ZX = string.Empty ; 
  		public string ZX 
  		{ 
  			get 
  			{ 
  				return m_ZX ; 
  			}  
  			set 
  			{ 
  				m_ZX = value ; 
  			}  
  		} 
  
  		private string m_ZXType = string.Empty ; 
  		public string ZXType 
  		{ 
  			get 
  			{ 
  				return m_ZXType ; 
  			}  
  			set 
  			{ 
  				m_ZXType = value ; 
  			}  
  		} 
  
  		private string m_YSFS = string.Empty ; 
  		public string YSFS 
  		{ 
  			get 
  			{ 
  				return m_YSFS ; 
  			}  
  			set 
  			{ 
  				m_YSFS = value ; 
  			}  
  		} 
  
  		private int m_FormListAID = 0; 
  		public int FormListAID 
  		{ 
  			get 
  			{ 
  				return m_FormListAID ; 
  			}  
  			set 
  			{ 
  				m_FormListAID = value ; 
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
  
  		private decimal m_YAmount = 0; 
  		public decimal YAmount 
  		{ 
  			get 
  			{ 
  				return m_YAmount ; 
  			}  
  			set 
  			{ 
  				m_YAmount = value ; 
  			}  
  		} 
  
  		private decimal m_YPercent = 0; 
  		public decimal YPercent 
  		{ 
  			get 
  			{ 
  				return m_YPercent ; 
  			}  
  			set 
  			{ 
  				m_YPercent = value ; 
  			}  
  		} 
  
  		private decimal m_SAmount = 0; 
  		public decimal SAmount 
  		{ 
  			get 
  			{ 
  				return m_SAmount ; 
  			}  
  			set 
  			{ 
  				m_SAmount = value ; 
  			}  
  		} 
  
  		private DateTime m_LastSKDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LastSKDate 
  		{ 
  			get 
  			{ 
  				return m_LastSKDate ; 
  			}  
  			set 
  			{ 
  				m_LastSKDate = value ; 
  			}  
  		} 
  
  		private DateTime m_SHDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SHDate 
  		{ 
  			get 
  			{ 
  				return m_SHDate ; 
  			}  
  			set 
  			{ 
  				m_SHDate = value ; 
  			}  
  		} 
  
  		private decimal m_YSTotalAmount = 0; 
  		public decimal YSTotalAmount 
  		{ 
  			get 
  			{ 
  				return m_YSTotalAmount ; 
  			}  
  			set 
  			{ 
  				m_YSTotalAmount = value ; 
  			}  
  		} 
  
  		private int m_QGFlag = 0; 
  		public int QGFlag 
  		{ 
  			get 
  			{ 
  				return m_QGFlag ; 
  			}  
  			set 
  			{ 
  				m_QGFlag = value ; 
  			}  
  		} 
  
  		private string m_ZFormNo = string.Empty ; 
  		public string ZFormNo 
  		{ 
  			get 
  			{ 
  				return m_ZFormNo ; 
  			}  
  			set 
  			{ 
  				m_ZFormNo = value ; 
  			}  
  		} 
  
  		private decimal m_TranFee = 0; 
  		public decimal TranFee 
  		{ 
  			get 
  			{ 
  				return m_TranFee ; 
  			}  
  			set 
  			{ 
  				m_TranFee = value ; 
  			}  
  		} 
  
  		private decimal m_ProFee = 0; 
  		public decimal ProFee 
  		{ 
  			get 
  			{ 
  				return m_ProFee ; 
  			}  
  			set 
  			{ 
  				m_ProFee = value ; 
  			}  
  		} 
  
  		private decimal m_OtherFee = 0; 
  		public decimal OtherFee 
  		{ 
  			get 
  			{ 
  				return m_OtherFee ; 
  			}  
  			set 
  			{ 
  				m_OtherFee = value ; 
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
            string Sql="SELECT * FROM Ship_Custom WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Ship_Custom WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_SO=SysConvert.ToString(MasterTable.Rows[0]["SO"]); 
  				m_InvoiceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InvoiceDate"]); 
  				m_InvoiceNo=SysConvert.ToString(MasterTable.Rows[0]["InvoiceNo"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_Messrs=SysConvert.ToString(MasterTable.Rows[0]["Messrs"]); 
  				m_ShipMethod=SysConvert.ToString(MasterTable.Rows[0]["ShipMethod"]); 
  				m_ShipFrom=SysConvert.ToString(MasterTable.Rows[0]["ShipFrom"]); 
  				m_ShipTo=SysConvert.ToString(MasterTable.Rows[0]["ShipTo"]); 
  				m_ShipDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ShipDate"]); 
  				m_MidChange=SysConvert.ToString(MasterTable.Rows[0]["MidChange"]); 
  				m_ContractNo=SysConvert.ToString(MasterTable.Rows[0]["ContractNo"]); 
  				m_LCNO=SysConvert.ToString(MasterTable.Rows[0]["LCNO"]); 
  				m_SCNo=SysConvert.ToString(MasterTable.Rows[0]["SCNo"]); 
  				m_SaleNo=SysConvert.ToString(MasterTable.Rows[0]["SaleNo"]); 
  				m_MarkNo=SysConvert.ToString(MasterTable.Rows[0]["MarkNo"]); 
  				m_Description=SysConvert.ToString(MasterTable.Rows[0]["Description"]); 
  				m_TradeType=SysConvert.ToString(MasterTable.Rows[0]["TradeType"]); 
  				m_GainType=SysConvert.ToString(MasterTable.Rows[0]["GainType"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_Currency=SysConvert.ToString(MasterTable.Rows[0]["Currency"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_TotalCtnQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalCtnQty"]); 
  				m_TotalCrossWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalCrossWeight"]); 
  				m_TotalNetWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalNetWeight"]); 
  				m_TotalBulk=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalBulk"]); 
  				m_IssueBank=SysConvert.ToString(MasterTable.Rows[0]["IssueBank"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_AuditOPID=SysConvert.ToString(MasterTable.Rows[0]["AuditOPID"]); 
  				m_AuditTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AuditTime"]); 
  				m_LastUpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["LastUpdTime"]); 
  				m_LastUpdOPID=SysConvert.ToString(MasterTable.Rows[0]["LastUpdOPID"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_HSCode=SysConvert.ToString(MasterTable.Rows[0]["HSCode"]); 
  				m_CustomFee=SysConvert.ToDecimal(MasterTable.Rows[0]["CustomFee"]); 
  				m_OthFee=SysConvert.ToDecimal(MasterTable.Rows[0]["OthFee"]); 
  				m_FeeRemark=SysConvert.ToString(MasterTable.Rows[0]["FeeRemark"]); 
  				m_BGDate=SysConvert.ToDateTime(MasterTable.Rows[0]["BGDate"]); 
  				m_JHFS=SysConvert.ToString(MasterTable.Rows[0]["JHFS"]); 
  				m_BZZL=SysConvert.ToString(MasterTable.Rows[0]["BZZL"]); 
  				m_FROMADDR=SysConvert.ToString(MasterTable.Rows[0]["FROMADDR"]); 
  				m_TOADDR=SysConvert.ToString(MasterTable.Rows[0]["TOADDR"]); 
  				m_BANo=SysConvert.ToString(MasterTable.Rows[0]["BANo"]); 
  				m_SBDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SBDate"]); 
  				m_ZMXZ=SysConvert.ToString(MasterTable.Rows[0]["ZMXZ"]); 
  				m_XKNo=SysConvert.ToString(MasterTable.Rows[0]["XKNo"]); 
  				m_PZNo=SysConvert.ToString(MasterTable.Rows[0]["PZNo"]); 
  				m_HTNo=SysConvert.ToString(MasterTable.Rows[0]["HTNo"]); 
  				m_SCS=SysConvert.ToString(MasterTable.Rows[0]["SCS"]); 
  				m_KHDM=SysConvert.ToString(MasterTable.Rows[0]["KHDM"]); 
  				m_BoxStd=SysConvert.ToString(MasterTable.Rows[0]["BoxStd"]); 
  				m_TotalNet=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalNet"]); 
  				m_TotalGross=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalGross"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_ZX=SysConvert.ToString(MasterTable.Rows[0]["ZX"]); 
  				m_ZXType=SysConvert.ToString(MasterTable.Rows[0]["ZXType"]); 
  				m_YSFS=SysConvert.ToString(MasterTable.Rows[0]["YSFS"]); 
  				m_FormListAID=SysConvert.ToInt32(MasterTable.Rows[0]["FormListAID"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_YAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["YAmount"]); 
  				m_YPercent=SysConvert.ToDecimal(MasterTable.Rows[0]["YPercent"]); 
  				m_SAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["SAmount"]); 
  				m_LastSKDate=SysConvert.ToDateTime(MasterTable.Rows[0]["LastSKDate"]); 
  				m_SHDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SHDate"]); 
  				m_YSTotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["YSTotalAmount"]); 
  				m_QGFlag=SysConvert.ToInt32(MasterTable.Rows[0]["QGFlag"]); 
  				m_ZFormNo=SysConvert.ToString(MasterTable.Rows[0]["ZFormNo"]); 
  				m_TranFee=SysConvert.ToDecimal(MasterTable.Rows[0]["TranFee"]); 
  				m_ProFee=SysConvert.ToDecimal(MasterTable.Rows[0]["ProFee"]); 
  				m_OtherFee=SysConvert.ToDecimal(MasterTable.Rows[0]["OtherFee"]); 
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
