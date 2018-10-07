using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_DBFormDts实体类
	/// 作者:陈加海
	/// 创建日期:2014/7/21
	/// </summary>
	public sealed class DBFormDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public DBFormDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public DBFormDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
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
  
  		private int m_WHTypeID = 0; 
  		public int WHTypeID 
  		{ 
  			get 
  			{ 
  				return m_WHTypeID ; 
  			}  
  			set 
  			{ 
  				m_WHTypeID = value ; 
  			}  
  		} 
  
  		private string m_WHID = string.Empty ; 
  		public string WHID 
  		{ 
  			get 
  			{ 
  				return m_WHID ; 
  			}  
  			set 
  			{ 
  				m_WHID = value ; 
  			}  
  		} 
  
  		private string m_SectionID = string.Empty ; 
  		public string SectionID 
  		{ 
  			get 
  			{ 
  				return m_SectionID ; 
  			}  
  			set 
  			{ 
  				m_SectionID = value ; 
  			}  
  		} 
  
  		private string m_SBitID = string.Empty ; 
  		public string SBitID 
  		{ 
  			get 
  			{ 
  				return m_SBitID ; 
  			}  
  			set 
  			{ 
  				m_SBitID = value ; 
  			}  
  		} 
  
  		private string m_DtsVendorID = string.Empty ; 
  		public string DtsVendorID 
  		{ 
  			get 
  			{ 
  				return m_DtsVendorID ; 
  			}  
  			set 
  			{ 
  				m_DtsVendorID = value ; 
  			}  
  		} 
  
  		private string m_FromWHID = string.Empty ; 
  		public string FromWHID 
  		{ 
  			get 
  			{ 
  				return m_FromWHID ; 
  			}  
  			set 
  			{ 
  				m_FromWHID = value ; 
  			}  
  		} 
  
  		private string m_FromSectionID = string.Empty ; 
  		public string FromSectionID 
  		{ 
  			get 
  			{ 
  				return m_FromSectionID ; 
  			}  
  			set 
  			{ 
  				m_FromSectionID = value ; 
  			}  
  		} 
  
  		private string m_FromSBitID = string.Empty ; 
  		public string FromSBitID 
  		{ 
  			get 
  			{ 
  				return m_FromSBitID ; 
  			}  
  			set 
  			{ 
  				m_FromSBitID = value ; 
  			}  
  		} 
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
  			}  
  		} 
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
  			}  
  		} 
  
  		private string m_Batch = string.Empty ; 
  		public string Batch 
  		{ 
  			get 
  			{ 
  				return m_Batch ; 
  			}  
  			set 
  			{ 
  				m_Batch = value ; 
  			}  
  		} 
  
  		private string m_VendorBatch = string.Empty ; 
  		public string VendorBatch 
  		{ 
  			get 
  			{ 
  				return m_VendorBatch ; 
  			}  
  			set 
  			{ 
  				m_VendorBatch = value ; 
  			}  
  		} 
  
  		private string m_ColorNum = string.Empty ; 
  		public string ColorNum 
  		{ 
  			get 
  			{ 
  				return m_ColorNum ; 
  			}  
  			set 
  			{ 
  				m_ColorNum = value ; 
  			}  
  		} 
  
  		private string m_ColorName = string.Empty ; 
  		public string ColorName 
  		{ 
  			get 
  			{ 
  				return m_ColorName ; 
  			}  
  			set 
  			{ 
  				m_ColorName = value ; 
  			}  
  		} 
  
  		private string m_JarNum = string.Empty ; 
  		public string JarNum 
  		{ 
  			get 
  			{ 
  				return m_JarNum ; 
  			}  
  			set 
  			{ 
  				m_JarNum = value ; 
  			}  
  		} 
  
  		private string m_YarnStatus = string.Empty ; 
  		public string YarnStatus 
  		{ 
  			get 
  			{ 
  				return m_YarnStatus ; 
  			}  
  			set 
  			{ 
  				m_YarnStatus = value ; 
  			}  
  		} 
  
  		private string m_YarnTypeID = string.Empty ; 
  		public string YarnTypeID 
  		{ 
  			get 
  			{ 
  				return m_YarnTypeID ; 
  			}  
  			set 
  			{ 
  				m_YarnTypeID = value ; 
  			}  
  		} 
  
  		private string m_SizeName = string.Empty ; 
  		public string SizeName 
  		{ 
  			get 
  			{ 
  				return m_SizeName ; 
  			}  
  			set 
  			{ 
  				m_SizeName = value ; 
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
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
  			}  
  		} 
  
  		private string m_Unit = string.Empty ; 
  		public string Unit 
  		{ 
  			get 
  			{ 
  				return m_Unit ; 
  			}  
  			set 
  			{ 
  				m_Unit = value ; 
  			}  
  		} 
  
  		private decimal m_Weight = 0; 
  		public decimal Weight 
  		{ 
  			get 
  			{ 
  				return m_Weight ; 
  			}  
  			set 
  			{ 
  				m_Weight = value ; 
  			}  
  		} 
  
  		private decimal m_SinglePrice = 0; 
  		public decimal SinglePrice 
  		{ 
  			get 
  			{ 
  				return m_SinglePrice ; 
  			}  
  			set 
  			{ 
  				m_SinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
  			}  
  		} 
  
  		private decimal m_WAmount = 0; 
  		public decimal WAmount 
  		{ 
  			get 
  			{ 
  				return m_WAmount ; 
  			}  
  			set 
  			{ 
  				m_WAmount = value ; 
  			}  
  		} 
  
  		private string m_DtsSO = string.Empty ; 
  		public string DtsSO 
  		{ 
  			get 
  			{ 
  				return m_DtsSO ; 
  			}  
  			set 
  			{ 
  				m_DtsSO = value ; 
  			}  
  		} 
  
  		private string m_DtsSaleOPID = string.Empty ; 
  		public string DtsSaleOPID 
  		{ 
  			get 
  			{ 
  				return m_DtsSaleOPID ; 
  			}  
  			set 
  			{ 
  				m_DtsSaleOPID = value ; 
  			}  
  		} 
  
  		private string m_Needle = string.Empty ; 
  		public string Needle 
  		{ 
  			get 
  			{ 
  				return m_Needle ; 
  			}  
  			set 
  			{ 
  				m_Needle = value ; 
  			}  
  		} 
  
  		private string m_YarnType = string.Empty ; 
  		public string YarnType 
  		{ 
  			get 
  			{ 
  				return m_YarnType ; 
  			}  
  			set 
  			{ 
  				m_YarnType = value ; 
  			}  
  		} 
  
  		private decimal m_SourceQty = 0; 
  		public decimal SourceQty 
  		{ 
  			get 
  			{ 
  				return m_SourceQty ; 
  			}  
  			set 
  			{ 
  				m_SourceQty = value ; 
  			}  
  		} 
  
  		private decimal m_MoveQty = 0; 
  		public decimal MoveQty 
  		{ 
  			get 
  			{ 
  				return m_MoveQty ; 
  			}  
  			set 
  			{ 
  				m_MoveQty = value ; 
  			}  
  		} 
  
  		private decimal m_SourceWeight = 0; 
  		public decimal SourceWeight 
  		{ 
  			get 
  			{ 
  				return m_SourceWeight ; 
  			}  
  			set 
  			{ 
  				m_SourceWeight = value ; 
  			}  
  		} 
  
  		private decimal m_MoveWeight = 0; 
  		public decimal MoveWeight 
  		{ 
  			get 
  			{ 
  				return m_MoveWeight ; 
  			}  
  			set 
  			{ 
  				m_MoveWeight = value ; 
  			}  
  		} 
  
  		private decimal m_TubeGW = 0; 
  		public decimal TubeGW 
  		{ 
  			get 
  			{ 
  				return m_TubeGW ; 
  			}  
  			set 
  			{ 
  				m_TubeGW = value ; 
  			}  
  		} 
  
  		private decimal m_SourceTubeQty = 0; 
  		public decimal SourceTubeQty 
  		{ 
  			get 
  			{ 
  				return m_SourceTubeQty ; 
  			}  
  			set 
  			{ 
  				m_SourceTubeQty = value ; 
  			}  
  		} 
  
  		private decimal m_MoveTubeQty = 0; 
  		public decimal MoveTubeQty 
  		{ 
  			get 
  			{ 
  				return m_MoveTubeQty ; 
  			}  
  			set 
  			{ 
  				m_MoveTubeQty = value ; 
  			}  
  		} 
  
  		private int m_TubeQty = 0; 
  		public int TubeQty 
  		{ 
  			get 
  			{ 
  				return m_TubeQty ; 
  			}  
  			set 
  			{ 
  				m_TubeQty = value ; 
  			}  
  		} 
  
  		private int m_SourcePieceQty = 0; 
  		public int SourcePieceQty 
  		{ 
  			get 
  			{ 
  				return m_SourcePieceQty ; 
  			}  
  			set 
  			{ 
  				m_SourcePieceQty = value ; 
  			}  
  		} 
  
  		private int m_MovePieceQty = 0; 
  		public int MovePieceQty 
  		{ 
  			get 
  			{ 
  				return m_MovePieceQty ; 
  			}  
  			set 
  			{ 
  				m_MovePieceQty = value ; 
  			}  
  		} 
  
  		private int m_PieceQty = 0; 
  		public int PieceQty 
  		{ 
  			get 
  			{ 
  				return m_PieceQty ; 
  			}  
  			set 
  			{ 
  				m_PieceQty = value ; 
  			}  
  		} 
  
  		private string m_PieceQtyDesc = string.Empty ; 
  		public string PieceQtyDesc 
  		{ 
  			get 
  			{ 
  				return m_PieceQtyDesc ; 
  			}  
  			set 
  			{ 
  				m_PieceQtyDesc = value ; 
  			}  
  		} 
  
  		private string m_JarNo = string.Empty ; 
  		public string JarNo 
  		{ 
  			get 
  			{ 
  				return m_JarNo ; 
  			}  
  			set 
  			{ 
  				m_JarNo = value ; 
  			}  
  		} 
  
  		private string m_Twist = string.Empty ; 
  		public string Twist 
  		{ 
  			get 
  			{ 
  				return m_Twist ; 
  			}  
  			set 
  			{ 
  				m_Twist = value ; 
  			}  
  		} 
  
  		private string m_DLCode = string.Empty ; 
  		public string DLCode 
  		{ 
  			get 
  			{ 
  				return m_DLCode ; 
  			}  
  			set 
  			{ 
  				m_DLCode = value ; 
  			}  
  		} 
  
  		private string m_GoodsCode = string.Empty ; 
  		public string GoodsCode 
  		{ 
  			get 
  			{ 
  				return m_GoodsCode ; 
  			}  
  			set 
  			{ 
  				m_GoodsCode = value ; 
  			}  
  		} 
  
  		private string m_GoodsLevel = string.Empty ; 
  		public string GoodsLevel 
  		{ 
  			get 
  			{ 
  				return m_GoodsLevel ; 
  			}  
  			set 
  			{ 
  				m_GoodsLevel = value ; 
  			}  
  		} 
  
  		private string m_VColorNum = string.Empty ; 
  		public string VColorNum 
  		{ 
  			get 
  			{ 
  				return m_VColorNum ; 
  			}  
  			set 
  			{ 
  				m_VColorNum = value ; 
  			}  
  		} 
  
  		private string m_VColorName = string.Empty ; 
  		public string VColorName 
  		{ 
  			get 
  			{ 
  				return m_VColorName ; 
  			}  
  			set 
  			{ 
  				m_VColorName = value ; 
  			}  
  		} 
  
  		private string m_VItemCode = string.Empty ; 
  		public string VItemCode 
  		{ 
  			get 
  			{ 
  				return m_VItemCode ; 
  			}  
  			set 
  			{ 
  				m_VItemCode = value ; 
  			}  
  		} 
  
  		private decimal m_PFPrice = 0; 
  		public decimal PFPrice 
  		{ 
  			get 
  			{ 
  				return m_PFPrice ; 
  			}  
  			set 
  			{ 
  				m_PFPrice = value ; 
  			}  
  		} 
  
  		private string m_ToWHID = string.Empty ; 
  		public string ToWHID 
  		{ 
  			get 
  			{ 
  				return m_ToWHID ; 
  			}  
  			set 
  			{ 
  				m_ToWHID = value ; 
  			}  
  		} 
  
  		private string m_ToSectionID = string.Empty ; 
  		public string ToSectionID 
  		{ 
  			get 
  			{ 
  				return m_ToSectionID ; 
  			}  
  			set 
  			{ 
  				m_ToSectionID = value ; 
  			}  
  		} 
  
  		private string m_ToSBitID = string.Empty ; 
  		public string ToSBitID 
  		{ 
  			get 
  			{ 
  				return m_ToSBitID ; 
  			}  
  			set 
  			{ 
  				m_ToSBitID = value ; 
  			}  
  		} 
  
  		private decimal m_MWidth = 0; 
  		public decimal MWidth 
  		{ 
  			get 
  			{ 
  				return m_MWidth ; 
  			}  
  			set 
  			{ 
  				m_MWidth = value ; 
  			}  
  		} 
  
  		private decimal m_MWeight = 0; 
  		public decimal MWeight 
  		{ 
  			get 
  			{ 
  				return m_MWeight ; 
  			}  
  			set 
  			{ 
  				m_MWeight = value ; 
  			}  
  		} 
  
  		private string m_WeightUnit = string.Empty ; 
  		public string WeightUnit 
  		{ 
  			get 
  			{ 
  				return m_WeightUnit ; 
  			}  
  			set 
  			{ 
  				m_WeightUnit = value ; 
  			}  
  		} 
  
  		private string m_DtsInVendorID = string.Empty ; 
  		public string DtsInVendorID 
  		{ 
  			get 
  			{ 
  				return m_DtsInVendorID ; 
  			}  
  			set 
  			{ 
  				m_DtsInVendorID = value ; 
  			}  
  		} 
  
  		private string m_InSO = string.Empty ; 
  		public string InSO 
  		{ 
  			get 
  			{ 
  				return m_InSO ; 
  			}  
  			set 
  			{ 
  				m_InSO = value ; 
  			}  
  		} 
  
  		private string m_InOrderFormNo = string.Empty ; 
  		public string InOrderFormNo 
  		{ 
  			get 
  			{ 
  				return m_InOrderFormNo ; 
  			}  
  			set 
  			{ 
  				m_InOrderFormNo = value ; 
  			}  
  		} 
  
  		private decimal m_InvoiceQty = 0; 
  		public decimal InvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_InvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_InvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_InvoiceAmount = 0; 
  		public decimal InvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_InvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_InvoiceAmount = value ; 
  			}  
  		} 
  
  		private decimal m_PayAmount = 0; 
  		public decimal PayAmount 
  		{ 
  			get 
  			{ 
  				return m_PayAmount ; 
  			}  
  			set 
  			{ 
  				m_PayAmount = value ; 
  			}  
  		} 
  
  		private int m_DtsInvoiceDelFlag = 0; 
  		public int DtsInvoiceDelFlag 
  		{ 
  			get 
  			{ 
  				return m_DtsInvoiceDelFlag ; 
  			}  
  			set 
  			{ 
  				m_DtsInvoiceDelFlag = value ; 
  			}  
  		} 
  
  		private string m_DtsInvoiceDelOPID = string.Empty ; 
  		public string DtsInvoiceDelOPID 
  		{ 
  			get 
  			{ 
  				return m_DtsInvoiceDelOPID ; 
  			}  
  			set 
  			{ 
  				m_DtsInvoiceDelOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_DtsInvoiceDelTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DtsInvoiceDelTime 
  		{ 
  			get 
  			{ 
  				return m_DtsInvoiceDelTime ; 
  			}  
  			set 
  			{ 
  				m_DtsInvoiceDelTime = value ; 
  			}  
  		} 
  
  		private string m_DtsInvoiceNo = string.Empty ; 
  		public string DtsInvoiceNo 
  		{ 
  			get 
  			{ 
  				return m_DtsInvoiceNo ; 
  			}  
  			set 
  			{ 
  				m_DtsInvoiceNo = value ; 
  			}  
  		} 
  
  		private decimal m_DZQty = 0; 
  		public decimal DZQty 
  		{ 
  			get 
  			{ 
  				return m_DZQty ; 
  			}  
  			set 
  			{ 
  				m_DZQty = value ; 
  			}  
  		} 
  
  		private decimal m_DZSinglePrice = 0; 
  		public decimal DZSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_DZSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_DZSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_DZAmount = 0; 
  		public decimal DZAmount 
  		{ 
  			get 
  			{ 
  				return m_DZAmount ; 
  			}  
  			set 
  			{ 
  				m_DZAmount = value ; 
  			}  
  		} 
  
  		private int m_DZFlag = 0; 
  		public int DZFlag 
  		{ 
  			get 
  			{ 
  				return m_DZFlag ; 
  			}  
  			set 
  			{ 
  				m_DZFlag = value ; 
  			}  
  		} 
  
  		private string m_DZOPID = string.Empty ; 
  		public string DZOPID 
  		{ 
  			get 
  			{ 
  				return m_DZOPID ; 
  			}  
  			set 
  			{ 
  				m_DZOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_DZTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DZTime 
  		{ 
  			get 
  			{ 
  				return m_DZTime ; 
  			}  
  			set 
  			{ 
  				m_DZTime = value ; 
  			}  
  		} 
  
  		private string m_DZNo = string.Empty ; 
  		public string DZNo 
  		{ 
  			get 
  			{ 
  				return m_DZNo ; 
  			}  
  			set 
  			{ 
  				m_DZNo = value ; 
  			}  
  		} 
  
  		private decimal m_FreeNum1 = 0; 
  		public decimal FreeNum1 
  		{ 
  			get 
  			{ 
  				return m_FreeNum1 ; 
  			}  
  			set 
  			{ 
  				m_FreeNum1 = value ; 
  			}  
  		} 
  
  		private string m_DtsOrderFormNo = string.Empty ; 
  		public string DtsOrderFormNo 
  		{ 
  			get 
  			{ 
  				return m_DtsOrderFormNo ; 
  			}  
  			set 
  			{ 
  				m_DtsOrderFormNo = value ; 
  			}  
  		} 
  
  		private string m_InSaleOPID = string.Empty ; 
  		public string InSaleOPID 
  		{ 
  			get 
  			{ 
  				return m_InSaleOPID ; 
  			}  
  			set 
  			{ 
  				m_InSaleOPID = value ; 
  			}  
  		} 
  
  		private decimal m_Tax = 0; 
  		public decimal Tax 
  		{ 
  			get 
  			{ 
  				return m_Tax ; 
  			}  
  			set 
  			{ 
  				m_Tax = value ; 
  			}  
  		} 
  
  		private decimal m_TaxAmount = 0; 
  		public decimal TaxAmount 
  		{ 
  			get 
  			{ 
  				return m_TaxAmount ; 
  			}  
  			set 
  			{ 
  				m_TaxAmount = value ; 
  			}  
  		} 
  
  		private string m_PackDts = string.Empty ; 
  		public string PackDts 
  		{ 
  			get 
  			{ 
  				return m_PackDts ; 
  			}  
  			set 
  			{ 
  				m_PackDts = value ; 
  			}  
  		} 
  
  		private int m_MLType = 0; 
  		public int MLType 
  		{ 
  			get 
  			{ 
  				return m_MLType ; 
  			}  
  			set 
  			{ 
  				m_MLType = value ; 
  			}  
  		} 
  
  		private decimal m_DYPrice = 0; 
  		public decimal DYPrice 
  		{ 
  			get 
  			{ 
  				return m_DYPrice ; 
  			}  
  			set 
  			{ 
  				m_DYPrice = value ; 
  			}  
  		} 
  
  		private decimal m_YQQty = 0; 
  		public decimal YQQty 
  		{ 
  			get 
  			{ 
  				return m_YQQty ; 
  			}  
  			set 
  			{ 
  				m_YQQty = value ; 
  			}  
  		} 
  
  		private decimal m_AQty = 0; 
  		public decimal AQty 
  		{ 
  			get 
  			{ 
  				return m_AQty ; 
  			}  
  			set 
  			{ 
  				m_AQty = value ; 
  			}  
  		} 
  
  		private decimal m_NOKPQty = 0; 
  		public decimal NOKPQty 
  		{ 
  			get 
  			{ 
  				return m_NOKPQty ; 
  			}  
  			set 
  			{ 
  				m_NOKPQty = value ; 
  			}  
  		} 
  
  		private decimal m_NoKPAmount = 0; 
  		public decimal NoKPAmount 
  		{ 
  			get 
  			{ 
  				return m_NoKPAmount ; 
  			}  
  			set 
  			{ 
  				m_NoKPAmount = value ; 
  			}  
  		} 
  
  		private int m_PackFlag = 0; 
  		public int PackFlag 
  		{ 
  			get 
  			{ 
  				return m_PackFlag ; 
  			}  
  			set 
  			{ 
  				m_PackFlag = value ; 
  			}  
  		} 
  
  		private int m_LoadDtsID = 0; 
  		public int LoadDtsID 
  		{ 
  			get 
  			{ 
  				return m_LoadDtsID ; 
  			}  
  			set 
  			{ 
  				m_LoadDtsID = value ; 
  			}  
  		} 
  
  		private decimal m_InputQty = 0; 
  		public decimal InputQty 
  		{ 
  			get 
  			{ 
  				return m_InputQty ; 
  			}  
  			set 
  			{ 
  				m_InputQty = value ; 
  			}  
  		} 
  
  		private string m_InputUnit = string.Empty ; 
  		public string InputUnit 
  		{ 
  			get 
  			{ 
  				return m_InputUnit ; 
  			}  
  			set 
  			{ 
  				m_InputUnit = value ; 
  			}  
  		} 
  
  		private decimal m_InputSinglePrice = 0; 
  		public decimal InputSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_InputSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_InputSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_InputAmount = 0; 
  		public decimal InputAmount 
  		{ 
  			get 
  			{ 
  				return m_InputAmount ; 
  			}  
  			set 
  			{ 
  				m_InputAmount = value ; 
  			}  
  		} 
  
  		private decimal m_InputConvertXS = 0; 
  		public decimal InputConvertXS 
  		{ 
  			get 
  			{ 
  				return m_InputConvertXS ; 
  			}  
  			set 
  			{ 
  				m_InputConvertXS = value ; 
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
            string Sql="SELECT * FROM WH_DBFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_DBFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_WHTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WHTypeID"]); 
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_SectionID=SysConvert.ToString(MasterTable.Rows[0]["SectionID"]); 
  				m_SBitID=SysConvert.ToString(MasterTable.Rows[0]["SBitID"]); 
  				m_DtsVendorID=SysConvert.ToString(MasterTable.Rows[0]["DtsVendorID"]); 
  				m_FromWHID=SysConvert.ToString(MasterTable.Rows[0]["FromWHID"]); 
  				m_FromSectionID=SysConvert.ToString(MasterTable.Rows[0]["FromSectionID"]); 
  				m_FromSBitID=SysConvert.ToString(MasterTable.Rows[0]["FromSBitID"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_VendorBatch=SysConvert.ToString(MasterTable.Rows[0]["VendorBatch"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_YarnStatus=SysConvert.ToString(MasterTable.Rows[0]["YarnStatus"]); 
  				m_YarnTypeID=SysConvert.ToString(MasterTable.Rows[0]["YarnTypeID"]); 
  				m_SizeName=SysConvert.ToString(MasterTable.Rows[0]["SizeName"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_WAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["WAmount"]); 
  				m_DtsSO=SysConvert.ToString(MasterTable.Rows[0]["DtsSO"]); 
  				m_DtsSaleOPID=SysConvert.ToString(MasterTable.Rows[0]["DtsSaleOPID"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_YarnType=SysConvert.ToString(MasterTable.Rows[0]["YarnType"]); 
  				m_SourceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["SourceQty"]); 
  				m_MoveQty=SysConvert.ToDecimal(MasterTable.Rows[0]["MoveQty"]); 
  				m_SourceWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["SourceWeight"]); 
  				m_MoveWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MoveWeight"]); 
  				m_TubeGW=SysConvert.ToDecimal(MasterTable.Rows[0]["TubeGW"]); 
  				m_SourceTubeQty=SysConvert.ToDecimal(MasterTable.Rows[0]["SourceTubeQty"]); 
  				m_MoveTubeQty=SysConvert.ToDecimal(MasterTable.Rows[0]["MoveTubeQty"]); 
  				m_TubeQty=SysConvert.ToInt32(MasterTable.Rows[0]["TubeQty"]); 
  				m_SourcePieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["SourcePieceQty"]); 
  				m_MovePieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["MovePieceQty"]); 
  				m_PieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PieceQty"]); 
  				m_PieceQtyDesc=SysConvert.ToString(MasterTable.Rows[0]["PieceQtyDesc"]); 
  				m_JarNo=SysConvert.ToString(MasterTable.Rows[0]["JarNo"]); 
  				m_Twist=SysConvert.ToString(MasterTable.Rows[0]["Twist"]); 
  				m_DLCode=SysConvert.ToString(MasterTable.Rows[0]["DLCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_GoodsLevel=SysConvert.ToString(MasterTable.Rows[0]["GoodsLevel"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_PFPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PFPrice"]); 
  				m_ToWHID=SysConvert.ToString(MasterTable.Rows[0]["ToWHID"]); 
  				m_ToSectionID=SysConvert.ToString(MasterTable.Rows[0]["ToSectionID"]); 
  				m_ToSBitID=SysConvert.ToString(MasterTable.Rows[0]["ToSBitID"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_DtsInVendorID=SysConvert.ToString(MasterTable.Rows[0]["DtsInVendorID"]); 
  				m_InSO=SysConvert.ToString(MasterTable.Rows[0]["InSO"]); 
  				m_InOrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["InOrderFormNo"]); 
  				m_InvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InvoiceQty"]); 
  				m_InvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["InvoiceAmount"]); 
  				m_PayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PayAmount"]); 
  				m_DtsInvoiceDelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DtsInvoiceDelFlag"]); 
  				m_DtsInvoiceDelOPID=SysConvert.ToString(MasterTable.Rows[0]["DtsInvoiceDelOPID"]); 
  				m_DtsInvoiceDelTime=SysConvert.ToDateTime(MasterTable.Rows[0]["DtsInvoiceDelTime"]); 
  				m_DtsInvoiceNo=SysConvert.ToString(MasterTable.Rows[0]["DtsInvoiceNo"]); 
  				m_DZQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DZQty"]); 
  				m_DZSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DZSinglePrice"]); 
  				m_DZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DZAmount"]); 
  				m_DZFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DZFlag"]); 
  				m_DZOPID=SysConvert.ToString(MasterTable.Rows[0]["DZOPID"]); 
  				m_DZTime=SysConvert.ToDateTime(MasterTable.Rows[0]["DZTime"]); 
  				m_DZNo=SysConvert.ToString(MasterTable.Rows[0]["DZNo"]); 
  				m_FreeNum1=SysConvert.ToDecimal(MasterTable.Rows[0]["FreeNum1"]); 
  				m_DtsOrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["DtsOrderFormNo"]); 
  				m_InSaleOPID=SysConvert.ToString(MasterTable.Rows[0]["InSaleOPID"]); 
  				m_Tax=SysConvert.ToDecimal(MasterTable.Rows[0]["Tax"]); 
  				m_TaxAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TaxAmount"]); 
  				m_PackDts=SysConvert.ToString(MasterTable.Rows[0]["PackDts"]); 
  				m_MLType=SysConvert.ToInt32(MasterTable.Rows[0]["MLType"]); 
  				m_DYPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DYPrice"]); 
  				m_YQQty=SysConvert.ToDecimal(MasterTable.Rows[0]["YQQty"]); 
  				m_AQty=SysConvert.ToDecimal(MasterTable.Rows[0]["AQty"]); 
  				m_NOKPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["NOKPQty"]); 
  				m_NoKPAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["NoKPAmount"]); 
  				m_PackFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PackFlag"]); 
  				m_LoadDtsID=SysConvert.ToInt32(MasterTable.Rows[0]["LoadDtsID"]); 
  				m_InputQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InputQty"]); 
  				m_InputUnit=SysConvert.ToString(MasterTable.Rows[0]["InputUnit"]); 
  				m_InputSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["InputSinglePrice"]); 
  				m_InputAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["InputAmount"]); 
  				m_InputConvertXS=SysConvert.ToDecimal(MasterTable.Rows[0]["InputConvertXS"]); 
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
