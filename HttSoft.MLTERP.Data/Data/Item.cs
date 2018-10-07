using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_Item实体类
	/// 作者:qiuchao
	/// 创建日期:2015/6/8
	/// </summary>
	public sealed class Item : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Item()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Item(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_Item";
		 
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
  
  		private DateTime m_ItemDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ItemDate 
  		{ 
  			get 
  			{ 
  				return m_ItemDate ; 
  			}  
  			set 
  			{ 
  				m_ItemDate = value ; 
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
  
  		private string m_MLDLCode = string.Empty ; 
  		public string MLDLCode 
  		{ 
  			get 
  			{ 
  				return m_MLDLCode ; 
  			}  
  			set 
  			{ 
  				m_MLDLCode = value ; 
  			}  
  		} 
  
  		private string m_MLLBCode = string.Empty ; 
  		public string MLLBCode 
  		{ 
  			get 
  			{ 
  				return m_MLLBCode ; 
  			}  
  			set 
  			{ 
  				m_MLLBCode = value ; 
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
  
  		private int m_ItemTypeID = 0; 
  		public int ItemTypeID 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID = value ; 
  			}  
  		} 
  
  		private int m_ItemClassID = 0; 
  		public int ItemClassID 
  		{ 
  			get 
  			{ 
  				return m_ItemClassID ; 
  			}  
  			set 
  			{ 
  				m_ItemClassID = value ; 
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
  
  		private string m_ItemNameEn = string.Empty ; 
  		public string ItemNameEn 
  		{ 
  			get 
  			{ 
  				return m_ItemNameEn ; 
  			}  
  			set 
  			{ 
  				m_ItemNameEn = value ; 
  			}  
  		} 
  
  		private string m_ItemModelEn = string.Empty ; 
  		public string ItemModelEn 
  		{ 
  			get 
  			{ 
  				return m_ItemModelEn ; 
  			}  
  			set 
  			{ 
  				m_ItemModelEn = value ; 
  			}  
  		} 
  
  		private string m_ItemUnit = string.Empty ; 
  		public string ItemUnit 
  		{ 
  			get 
  			{ 
  				return m_ItemUnit ; 
  			}  
  			set 
  			{ 
  				m_ItemUnit = value ; 
  			}  
  		} 
  
  		private string m_ItemAttnCode = string.Empty ; 
  		public string ItemAttnCode 
  		{ 
  			get 
  			{ 
  				return m_ItemAttnCode ; 
  			}  
  			set 
  			{ 
  				m_ItemAttnCode = value ; 
  			}  
  		} 
  
  		private string m_MWidth = string.Empty ; 
  		public string MWidth 
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
  
  		private string m_MWeight = string.Empty ; 
  		public string MWeight 
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
  
  		private string m_YarnStd = string.Empty ; 
  		public string YarnStd 
  		{ 
  			get 
  			{ 
  				return m_YarnStd ; 
  			}  
  			set 
  			{ 
  				m_YarnStd = value ; 
  			}  
  		} 
  
  		private string m_JWM = string.Empty ; 
  		public string JWM 
  		{ 
  			get 
  			{ 
  				return m_JWM ; 
  			}  
  			set 
  			{ 
  				m_JWM = value ; 
  			}  
  		} 
  
  		private string m_ZWZZ = string.Empty ; 
  		public string ZWZZ 
  		{ 
  			get 
  			{ 
  				return m_ZWZZ ; 
  			}  
  			set 
  			{ 
  				m_ZWZZ = value ; 
  			}  
  		} 
  
  		private string m_Season = string.Empty ; 
  		public string Season 
  		{ 
  			get 
  			{ 
  				return m_Season ; 
  			}  
  			set 
  			{ 
  				m_Season = value ; 
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
  
  		private int m_UseableFlag = 0; 
  		public int UseableFlag 
  		{ 
  			get 
  			{ 
  				return m_UseableFlag ; 
  			}  
  			set 
  			{ 
  				m_UseableFlag = value ; 
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
  
  		private int m_PFlag = 0; 
  		public int PFlag 
  		{ 
  			get 
  			{ 
  				return m_PFlag ; 
  			}  
  			set 
  			{ 
  				m_PFlag = value ; 
  			}  
  		} 
  
  		private int m_XFlag = 0; 
  		public int XFlag 
  		{ 
  			get 
  			{ 
  				return m_XFlag ; 
  			}  
  			set 
  			{ 
  				m_XFlag = value ; 
  			}  
  		} 
  
  		private string m_MLLBName = string.Empty ; 
  		public string MLLBName 
  		{ 
  			get 
  			{ 
  				return m_MLLBName ; 
  			}  
  			set 
  			{ 
  				m_MLLBName = value ; 
  			}  
  		} 
  
  		private decimal m_BuyPrice = 0; 
  		public decimal BuyPrice 
  		{ 
  			get 
  			{ 
  				return m_BuyPrice ; 
  			}  
  			set 
  			{ 
  				m_BuyPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_BuyPriceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime BuyPriceDate 
  		{ 
  			get 
  			{ 
  				return m_BuyPriceDate ; 
  			}  
  			set 
  			{ 
  				m_BuyPriceDate = value ; 
  			}  
  		} 
  
  		private decimal m_SalePrice = 0; 
  		public decimal SalePrice 
  		{ 
  			get 
  			{ 
  				return m_SalePrice ; 
  			}  
  			set 
  			{ 
  				m_SalePrice = value ; 
  			}  
  		} 
  
  		private DateTime m_SalePriceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SalePriceDate 
  		{ 
  			get 
  			{ 
  				return m_SalePriceDate ; 
  			}  
  			set 
  			{ 
  				m_SalePriceDate = value ; 
  			}  
  		} 
  
  		private string m_Web = string.Empty ; 
  		public string Web 
  		{ 
  			get 
  			{ 
  				return m_Web ; 
  			}  
  			set 
  			{ 
  				m_Web = value ; 
  			}  
  		} 
  
  		private decimal m_PerMiWeight = 0; 
  		public decimal PerMiWeight 
  		{ 
  			get 
  			{ 
  				return m_PerMiWeight ; 
  			}  
  			set 
  			{ 
  				m_PerMiWeight = value ; 
  			}  
  		} 
  
  		private string m_GreyFabItemCode = string.Empty ; 
  		public string GreyFabItemCode 
  		{ 
  			get 
  			{ 
  				return m_GreyFabItemCode ; 
  			}  
  			set 
  			{ 
  				m_GreyFabItemCode = value ; 
  			}  
  		} 
  
  		private decimal m_Shrinkage = 0; 
  		public decimal Shrinkage 
  		{ 
  			get 
  			{ 
  				return m_Shrinkage ; 
  			}  
  			set 
  			{ 
  				m_Shrinkage = value ; 
  			}  
  		} 
  
  		private decimal m_ColorLoss = 0; 
  		public decimal ColorLoss 
  		{ 
  			get 
  			{ 
  				return m_ColorLoss ; 
  			}  
  			set 
  			{ 
  				m_ColorLoss = value ; 
  			}  
  		} 
  
  		private decimal m_LastLoss = 0; 
  		public decimal LastLoss 
  		{ 
  			get 
  			{ 
  				return m_LastLoss ; 
  			}  
  			set 
  			{ 
  				m_LastLoss = value ; 
  			}  
  		} 
  
  		private int m_FabricTypeID = 0; 
  		public int FabricTypeID 
  		{ 
  			get 
  			{ 
  				return m_FabricTypeID ; 
  			}  
  			set 
  			{ 
  				m_FabricTypeID = value ; 
  			}  
  		} 
  
  		private string m_ClientNO = string.Empty ; 
  		public string ClientNO 
  		{ 
  			get 
  			{ 
  				return m_ClientNO ; 
  			}  
  			set 
  			{ 
  				m_ClientNO = value ; 
  			}  
  		} 
  
  		private string m_MiDu = string.Empty ; 
  		public string MiDu 
  		{ 
  			get 
  			{ 
  				return m_MiDu ; 
  			}  
  			set 
  			{ 
  				m_MiDu = value ; 
  			}  
  		} 
  
  		private string m_ShiYangNO = string.Empty ; 
  		public string ShiYangNO 
  		{ 
  			get 
  			{ 
  				return m_ShiYangNO ; 
  			}  
  			set 
  			{ 
  				m_ShiYangNO = value ; 
  			}  
  		} 
  
  		private decimal m_PBPrice = 0; 
  		public decimal PBPrice 
  		{ 
  			get 
  			{ 
  				return m_PBPrice ; 
  			}  
  			set 
  			{ 
  				m_PBPrice = value ; 
  			}  
  		} 
  
  		private decimal m_CPPrice = 0; 
  		public decimal CPPrice 
  		{ 
  			get 
  			{ 
  				return m_CPPrice ; 
  			}  
  			set 
  			{ 
  				m_CPPrice = value ; 
  			}  
  		} 
  
  		private string m_ColorRemark = string.Empty ; 
  		public string ColorRemark 
  		{ 
  			get 
  			{ 
  				return m_ColorRemark ; 
  			}  
  			set 
  			{ 
  				m_ColorRemark = value ; 
  			}  
  		} 
  
  		private string m_YPSource = string.Empty ; 
  		public string YPSource 
  		{ 
  			get 
  			{ 
  				return m_YPSource ; 
  			}  
  			set 
  			{ 
  				m_YPSource = value ; 
  			}  
  		} 
  
  		private decimal m_RFPrice = 0; 
  		public decimal RFPrice 
  		{ 
  			get 
  			{ 
  				return m_RFPrice ; 
  			}  
  			set 
  			{ 
  				m_RFPrice = value ; 
  			}  
  		} 
  
  		private string m_RFUnit = string.Empty ; 
  		public string RFUnit 
  		{ 
  			get 
  			{ 
  				return m_RFUnit ; 
  			}  
  			set 
  			{ 
  				m_RFUnit = value ; 
  			}  
  		} 
  
  		private decimal m_ValidMWidth = 0; 
  		public decimal ValidMWidth 
  		{ 
  			get 
  			{ 
  				return m_ValidMWidth ; 
  			}  
  			set 
  			{ 
  				m_ValidMWidth = value ; 
  			}  
  		} 
  
  		private decimal m_SampleCBPrice = 0; 
  		public decimal SampleCBPrice 
  		{ 
  			get 
  			{ 
  				return m_SampleCBPrice ; 
  			}  
  			set 
  			{ 
  				m_SampleCBPrice = value ; 
  			}  
  		} 
  
  		private string m_AttRSGYDesc = string.Empty ; 
  		public string AttRSGYDesc 
  		{ 
  			get 
  			{ 
  				return m_AttRSGYDesc ; 
  			}  
  			set 
  			{ 
  				m_AttRSGYDesc = value ; 
  			}  
  		} 
  
  		private string m_AttMachineDesc = string.Empty ; 
  		public string AttMachineDesc 
  		{ 
  			get 
  			{ 
  				return m_AttMachineDesc ; 
  			}  
  			set 
  			{ 
  				m_AttMachineDesc = value ; 
  			}  
  		} 
  
  		private string m_AttYarnDesc = string.Empty ; 
  		public string AttYarnDesc 
  		{ 
  			get 
  			{ 
  				return m_AttYarnDesc ; 
  			}  
  			set 
  			{ 
  				m_AttYarnDesc = value ; 
  			}  
  		} 
  
  		private string m_FreeStr1 = string.Empty ; 
  		public string FreeStr1 
  		{ 
  			get 
  			{ 
  				return m_FreeStr1 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr1 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr2 = string.Empty ; 
  		public string FreeStr2 
  		{ 
  			get 
  			{ 
  				return m_FreeStr2 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr2 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr3 = string.Empty ; 
  		public string FreeStr3 
  		{ 
  			get 
  			{ 
  				return m_FreeStr3 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr3 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr4 = string.Empty ; 
  		public string FreeStr4 
  		{ 
  			get 
  			{ 
  				return m_FreeStr4 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr4 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr5 = string.Empty ; 
  		public string FreeStr5 
  		{ 
  			get 
  			{ 
  				return m_FreeStr5 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr5 = value ; 
  			}  
  		} 
  
  		private string m_Machine = string.Empty ; 
  		public string Machine 
  		{ 
  			get 
  			{ 
  				return m_Machine ; 
  			}  
  			set 
  			{ 
  				m_Machine = value ; 
  			}  
  		} 
  
  		private string m_TecDesc = string.Empty ; 
  		public string TecDesc 
  		{ 
  			get 
  			{ 
  				return m_TecDesc ; 
  			}  
  			set 
  			{ 
  				m_TecDesc = value ; 
  			}  
  		} 
  
  		private string m_HD = string.Empty ; 
  		public string HD 
  		{ 
  			get 
  			{ 
  				return m_HD ; 
  			}  
  			set 
  			{ 
  				m_HD = value ; 
  			}  
  		} 
  
  		private string m_DB = string.Empty ; 
  		public string DB 
  		{ 
  			get 
  			{ 
  				return m_DB ; 
  			}  
  			set 
  			{ 
  				m_DB = value ; 
  			}  
  		} 
  
  		private string m_SS = string.Empty ; 
  		public string SS 
  		{ 
  			get 
  			{ 
  				return m_SS ; 
  			}  
  			set 
  			{ 
  				m_SS = value ; 
  			}  
  		} 
  
  		private string m_FK = string.Empty ; 
  		public string FK 
  		{ 
  			get 
  			{ 
  				return m_FK ; 
  			}  
  			set 
  			{ 
  				m_FK = value ; 
  			}  
  		} 
  
  		private string m_AfterFinish = string.Empty ; 
  		public string AfterFinish 
  		{ 
  			get 
  			{ 
  				return m_AfterFinish ; 
  			}  
  			set 
  			{ 
  				m_AfterFinish = value ; 
  			}  
  		} 
  
  		private string m_COST = string.Empty ; 
  		public string COST 
  		{ 
  			get 
  			{ 
  				return m_COST ; 
  			}  
  			set 
  			{ 
  				m_COST = value ; 
  			}  
  		} 
  
  		private string m_COSTA = string.Empty ; 
  		public string COSTA 
  		{ 
  			get 
  			{ 
  				return m_COSTA ; 
  			}  
  			set 
  			{ 
  				m_COSTA = value ; 
  			}  
  		} 
  
  		private string m_QUOT = string.Empty ; 
  		public string QUOT 
  		{ 
  			get 
  			{ 
  				return m_QUOT ; 
  			}  
  			set 
  			{ 
  				m_QUOT = value ; 
  			}  
  		} 
  
  		private string m_RShrinkage = string.Empty ; 
  		public string RShrinkage 
  		{ 
  			get 
  			{ 
  				return m_RShrinkage ; 
  			}  
  			set 
  			{ 
  				m_RShrinkage = value ; 
  			}  
  		} 
  
  		private decimal m_RSAmount = 0; 
  		public decimal RSAmount 
  		{ 
  			get 
  			{ 
  				return m_RSAmount ; 
  			}  
  			set 
  			{ 
  				m_RSAmount = value ; 
  			}  
  		} 
  
  		private string m_RSSH = string.Empty ; 
  		public string RSSH 
  		{ 
  			get 
  			{ 
  				return m_RSSH ; 
  			}  
  			set 
  			{ 
  				m_RSSH = value ; 
  			}  
  		} 
  
  		private decimal m_JGAmount = 0; 
  		public decimal JGAmount 
  		{ 
  			get 
  			{ 
  				return m_JGAmount ; 
  			}  
  			set 
  			{ 
  				m_JGAmount = value ; 
  			}  
  		} 
  
  		private string m_JGSH = string.Empty ; 
  		public string JGSH 
  		{ 
  			get 
  			{ 
  				return m_JGSH ; 
  			}  
  			set 
  			{ 
  				m_JGSH = value ; 
  			}  
  		} 
  
  		private string m_RColorName = string.Empty ; 
  		public string RColorName 
  		{ 
  			get 
  			{ 
  				return m_RColorName ; 
  			}  
  			set 
  			{ 
  				m_RColorName = value ; 
  			}  
  		} 
  
  		private string m_PBVendor = string.Empty ; 
  		public string PBVendor 
  		{ 
  			get 
  			{ 
  				return m_PBVendor ; 
  			}  
  			set 
  			{ 
  				m_PBVendor = value ; 
  			}  
  		} 
  
  		private string m_RSVendor = string.Empty ; 
  		public string RSVendor 
  		{ 
  			get 
  			{ 
  				return m_RSVendor ; 
  			}  
  			set 
  			{ 
  				m_RSVendor = value ; 
  			}  
  		} 
  
  		private string m_HZVendor = string.Empty ; 
  		public string HZVendor 
  		{ 
  			get 
  			{ 
  				return m_HZVendor ; 
  			}  
  			set 
  			{ 
  				m_HZVendor = value ; 
  			}  
  		} 
  
  		private decimal m_HZAmount = 0; 
  		public decimal HZAmount 
  		{ 
  			get 
  			{ 
  				return m_HZAmount ; 
  			}  
  			set 
  			{ 
  				m_HZAmount = value ; 
  			}  
  		} 
  
  		private string m_ProfitMargin = string.Empty ; 
  		public string ProfitMargin 
  		{ 
  			get 
  			{ 
  				return m_ProfitMargin ; 
  			}  
  			set 
  			{ 
  				m_ProfitMargin = value ; 
  			}  
  		} 
  
  		private decimal m_JGAmount2 = 0; 
  		public decimal JGAmount2 
  		{ 
  			get 
  			{ 
  				return m_JGAmount2 ; 
  			}  
  			set 
  			{ 
  				m_JGAmount2 = value ; 
  			}  
  		} 
  
  		private string m_JGSH2 = string.Empty ; 
  		public string JGSH2 
  		{ 
  			get 
  			{ 
  				return m_JGSH2 ; 
  			}  
  			set 
  			{ 
  				m_JGSH2 = value ; 
  			}  
  		} 
  
  		private decimal m_JGAmount3 = 0; 
  		public decimal JGAmount3 
  		{ 
  			get 
  			{ 
  				return m_JGAmount3 ; 
  			}  
  			set 
  			{ 
  				m_JGAmount3 = value ; 
  			}  
  		} 
  
  		private string m_JGSH3 = string.Empty ; 
  		public string JGSH3 
  		{ 
  			get 
  			{ 
  				return m_JGSH3 ; 
  			}  
  			set 
  			{ 
  				m_JGSH3 = value ; 
  			}  
  		} 
  
  		private string m_MWeight2 = string.Empty ; 
  		public string MWeight2 
  		{ 
  			get 
  			{ 
  				return m_MWeight2 ; 
  			}  
  			set 
  			{ 
  				m_MWeight2 = value ; 
  			}  
  		} 
  
  		private string m_HZType = string.Empty ; 
  		public string HZType 
  		{ 
  			get 
  			{ 
  				return m_HZType ; 
  			}  
  			set 
  			{ 
  				m_HZType = value ; 
  			}  
  		} 
  
  		private string m_Organ = string.Empty ; 
  		public string Organ 
  		{ 
  			get 
  			{ 
  				return m_Organ ; 
  			}  
  			set 
  			{ 
  				m_Organ = value ; 
  			}  
  		} 
  
  		private string m_MinQty = string.Empty ; 
  		public string MinQty 
  		{ 
  			get 
  			{ 
  				return m_MinQty ; 
  			}  
  			set 
  			{ 
  				m_MinQty = value ; 
  			}  
  		} 
  
  		private string m_DeliveryTime = string.Empty ; 
  		public string DeliveryTime 
  		{ 
  			get 
  			{ 
  				return m_DeliveryTime ; 
  			}  
  			set 
  			{ 
  				m_DeliveryTime = value ; 
  			}  
  		} 
  
  		private string m_SalePriceRMB = string.Empty ; 
  		public string SalePriceRMB 
  		{ 
  			get 
  			{ 
  				return m_SalePriceRMB ; 
  			}  
  			set 
  			{ 
  				m_SalePriceRMB = value ; 
  			}  
  		} 
  
  		private string m_SalePriceUSD = string.Empty ; 
  		public string SalePriceUSD 
  		{ 
  			get 
  			{ 
  				return m_SalePriceUSD ; 
  			}  
  			set 
  			{ 
  				m_SalePriceUSD = value ; 
  			}  
  		} 
  
  		private string m_SalePricePro = string.Empty ; 
  		public string SalePricePro 
  		{ 
  			get 
  			{ 
  				return m_SalePricePro ; 
  			}  
  			set 
  			{ 
  				m_SalePricePro = value ; 
  			}  
  		} 
  
  		private string m_SLDGM = string.Empty ; 
  		public string SLDGM 
  		{ 
  			get 
  			{ 
  				return m_SLDGM ; 
  			}  
  			set 
  			{ 
  				m_SLDGM = value ; 
  			}  
  		} 
  
  		private string m_SLDSM = string.Empty ; 
  		public string SLDSM 
  		{ 
  			get 
  			{ 
  				return m_SLDSM ; 
  			}  
  			set 
  			{ 
  				m_SLDSM = value ; 
  			}  
  		} 
  
  		private string m_SSLJX = string.Empty ; 
  		public string SSLJX 
  		{ 
  			get 
  			{ 
  				return m_SSLJX ; 
  			}  
  			set 
  			{ 
  				m_SSLJX = value ; 
  			}  
  		} 
  
  		private string m_SSLWX = string.Empty ; 
  		public string SSLWX 
  		{ 
  			get 
  			{ 
  				return m_SSLWX ; 
  			}  
  			set 
  			{ 
  				m_SSLWX = value ; 
  			}  
  		} 
  
  		private string m_SPQLJX = string.Empty ; 
  		public string SPQLJX 
  		{ 
  			get 
  			{ 
  				return m_SPQLJX ; 
  			}  
  			set 
  			{ 
  				m_SPQLJX = value ; 
  			}  
  		} 
  
  		private string m_SPQLWX = string.Empty ; 
  		public string SPQLWX 
  		{ 
  			get 
  			{ 
  				return m_SPQLWX ; 
  			}  
  			set 
  			{ 
  				m_SPQLWX = value ; 
  			}  
  		} 
  
  		private string m_LSQLJX = string.Empty ; 
  		public string LSQLJX 
  		{ 
  			get 
  			{ 
  				return m_LSQLJX ; 
  			}  
  			set 
  			{ 
  				m_LSQLJX = value ; 
  			}  
  		} 
  
  		private string m_LSQLWX = string.Empty ; 
  		public string LSQLWX 
  		{ 
  			get 
  			{ 
  				return m_LSQLWX ; 
  			}  
  			set 
  			{ 
  				m_LSQLWX = value ; 
  			}  
  		} 
  
  		private string m_PH = string.Empty ; 
  		public string PH 
  		{ 
  			get 
  			{ 
  				return m_PH ; 
  			}  
  			set 
  			{ 
  				m_PH = value ; 
  			}  
  		} 
  
  		private string m_KQMQ = string.Empty ; 
  		public string KQMQ 
  		{ 
  			get 
  			{ 
  				return m_KQMQ ; 
  			}  
  			set 
  			{ 
  				m_KQMQ = value ; 
  			}  
  		} 
  
  		private string m_GZLD = string.Empty ; 
  		public string GZLD 
  		{ 
  			get 
  			{ 
  				return m_GZLD ; 
  			}  
  			set 
  			{ 
  				m_GZLD = value ; 
  			}  
  		} 
  
  		private string m_MFUnit = string.Empty ; 
  		public string MFUnit 
  		{ 
  			get 
  			{ 
  				return m_MFUnit ; 
  			}  
  			set 
  			{ 
  				m_MFUnit = value ; 
  			}  
  		} 
  
  		private string m_InchNum = string.Empty ; 
  		public string InchNum 
  		{ 
  			get 
  			{ 
  				return m_InchNum ; 
  			}  
  			set 
  			{ 
  				m_InchNum = value ; 
  			}  
  		} 
  
  		private string m_ItemModelNo = string.Empty ; 
  		public string ItemModelNo 
  		{ 
  			get 
  			{ 
  				return m_ItemModelNo ; 
  			}  
  			set 
  			{ 
  				m_ItemModelNo = value ; 
  			}  
  		} 
  
  		private decimal m_ColorPrice = 0; 
  		public decimal ColorPrice 
  		{ 
  			get 
  			{ 
  				return m_ColorPrice ; 
  			}  
  			set 
  			{ 
  				m_ColorPrice = value ; 
  			}  
  		} 
  
  		private decimal m_ZLPrice = 0; 
  		public decimal ZLPrice 
  		{ 
  			get 
  			{ 
  				return m_ZLPrice ; 
  			}  
  			set 
  			{ 
  				m_ZLPrice = value ; 
  			}  
  		} 
  
  		private decimal m_TotalPriceUSB = 0; 
  		public decimal TotalPriceUSB 
  		{ 
  			get 
  			{ 
  				return m_TotalPriceUSB ; 
  			}  
  			set 
  			{ 
  				m_TotalPriceUSB = value ; 
  			}  
  		} 
  
  		private decimal m_ExchangeRate = 0; 
  		public decimal ExchangeRate 
  		{ 
  			get 
  			{ 
  				return m_ExchangeRate ; 
  			}  
  			set 
  			{ 
  				m_ExchangeRate = value ; 
  			}  
  		} 
  
  		private decimal m_TotalPriceRMB = 0; 
  		public decimal TotalPriceRMB 
  		{ 
  			get 
  			{ 
  				return m_TotalPriceRMB ; 
  			}  
  			set 
  			{ 
  				m_TotalPriceRMB = value ; 
  			}  
  		} 
  
  		private decimal m_CBPrice = 0; 
  		public decimal CBPrice 
  		{ 
  			get 
  			{ 
  				return m_CBPrice ; 
  			}  
  			set 
  			{ 
  				m_CBPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_ZJBJDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ZJBJDate 
  		{ 
  			get 
  			{ 
  				return m_ZJBJDate ; 
  			}  
  			set 
  			{ 
  				m_ZJBJDate = value ; 
  			}  
  		} 
  
  		private decimal m_JGPrice = 0; 
  		public decimal JGPrice 
  		{ 
  			get 
  			{ 
  				return m_JGPrice ; 
  			}  
  			set 
  			{ 
  				m_JGPrice = value ; 
  			}  
  		} 
  
  		private decimal m_TotalPrice = 0; 
  		public decimal TotalPrice 
  		{ 
  			get 
  			{ 
  				return m_TotalPrice ; 
  			}  
  			set 
  			{ 
  				m_TotalPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_ZXBJDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ZXBJDate 
  		{ 
  			get 
  			{ 
  				return m_ZXBJDate ; 
  			}  
  			set 
  			{ 
  				m_ZXBJDate = value ; 
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
            string Sql="SELECT * FROM Data_Item WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_Item WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ItemDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ItemDate"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_MLDLCode=SysConvert.ToString(MasterTable.Rows[0]["MLDLCode"]); 
  				m_MLLBCode=SysConvert.ToString(MasterTable.Rows[0]["MLLBCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ItemTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID"]); 
  				m_ItemClassID=SysConvert.ToInt32(MasterTable.Rows[0]["ItemClassID"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ItemNameEn=SysConvert.ToString(MasterTable.Rows[0]["ItemNameEn"]); 
  				m_ItemModelEn=SysConvert.ToString(MasterTable.Rows[0]["ItemModelEn"]); 
  				m_ItemUnit=SysConvert.ToString(MasterTable.Rows[0]["ItemUnit"]); 
  				m_ItemAttnCode=SysConvert.ToString(MasterTable.Rows[0]["ItemAttnCode"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_YarnStd=SysConvert.ToString(MasterTable.Rows[0]["YarnStd"]); 
  				m_JWM=SysConvert.ToString(MasterTable.Rows[0]["JWM"]); 
  				m_ZWZZ=SysConvert.ToString(MasterTable.Rows[0]["ZWZZ"]); 
  				m_Season=SysConvert.ToString(MasterTable.Rows[0]["Season"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UseableFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UseableFlag"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_PFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PFlag"]); 
  				m_XFlag=SysConvert.ToInt32(MasterTable.Rows[0]["XFlag"]); 
  				m_MLLBName=SysConvert.ToString(MasterTable.Rows[0]["MLLBName"]); 
  				m_BuyPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["BuyPrice"]); 
  				m_BuyPriceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["BuyPriceDate"]); 
  				m_SalePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SalePrice"]); 
  				m_SalePriceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SalePriceDate"]); 
  				m_Web=SysConvert.ToString(MasterTable.Rows[0]["Web"]); 
  				m_PerMiWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["PerMiWeight"]); 
  				m_GreyFabItemCode=SysConvert.ToString(MasterTable.Rows[0]["GreyFabItemCode"]); 
  				m_Shrinkage=SysConvert.ToDecimal(MasterTable.Rows[0]["Shrinkage"]); 
  				m_ColorLoss=SysConvert.ToDecimal(MasterTable.Rows[0]["ColorLoss"]); 
  				m_LastLoss=SysConvert.ToDecimal(MasterTable.Rows[0]["LastLoss"]); 
  				m_FabricTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FabricTypeID"]); 
  				m_ClientNO=SysConvert.ToString(MasterTable.Rows[0]["ClientNO"]); 
  				m_MiDu=SysConvert.ToString(MasterTable.Rows[0]["MiDu"]); 
  				m_ShiYangNO=SysConvert.ToString(MasterTable.Rows[0]["ShiYangNO"]); 
  				m_PBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PBPrice"]); 
  				m_CPPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["CPPrice"]); 
  				m_ColorRemark=SysConvert.ToString(MasterTable.Rows[0]["ColorRemark"]); 
  				m_YPSource=SysConvert.ToString(MasterTable.Rows[0]["YPSource"]); 
  				m_RFPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["RFPrice"]); 
  				m_RFUnit=SysConvert.ToString(MasterTable.Rows[0]["RFUnit"]); 
  				m_ValidMWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["ValidMWidth"]); 
  				m_SampleCBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SampleCBPrice"]); 
  				m_AttRSGYDesc=SysConvert.ToString(MasterTable.Rows[0]["AttRSGYDesc"]); 
  				m_AttMachineDesc=SysConvert.ToString(MasterTable.Rows[0]["AttMachineDesc"]); 
  				m_AttYarnDesc=SysConvert.ToString(MasterTable.Rows[0]["AttYarnDesc"]); 
  				m_FreeStr1=SysConvert.ToString(MasterTable.Rows[0]["FreeStr1"]); 
  				m_FreeStr2=SysConvert.ToString(MasterTable.Rows[0]["FreeStr2"]); 
  				m_FreeStr3=SysConvert.ToString(MasterTable.Rows[0]["FreeStr3"]); 
  				m_FreeStr4=SysConvert.ToString(MasterTable.Rows[0]["FreeStr4"]); 
  				m_FreeStr5=SysConvert.ToString(MasterTable.Rows[0]["FreeStr5"]); 
  				m_Machine=SysConvert.ToString(MasterTable.Rows[0]["Machine"]); 
  				m_TecDesc=SysConvert.ToString(MasterTable.Rows[0]["TecDesc"]); 
  				m_HD=SysConvert.ToString(MasterTable.Rows[0]["HD"]); 
  				m_DB=SysConvert.ToString(MasterTable.Rows[0]["DB"]); 
  				m_SS=SysConvert.ToString(MasterTable.Rows[0]["SS"]); 
  				m_FK=SysConvert.ToString(MasterTable.Rows[0]["FK"]); 
  				m_AfterFinish=SysConvert.ToString(MasterTable.Rows[0]["AfterFinish"]); 
  				m_COST=SysConvert.ToString(MasterTable.Rows[0]["COST"]); 
  				m_COSTA=SysConvert.ToString(MasterTable.Rows[0]["COSTA"]); 
  				m_QUOT=SysConvert.ToString(MasterTable.Rows[0]["QUOT"]); 
  				m_RShrinkage=SysConvert.ToString(MasterTable.Rows[0]["RShrinkage"]); 
  				m_RSAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["RSAmount"]); 
  				m_RSSH=SysConvert.ToString(MasterTable.Rows[0]["RSSH"]); 
  				m_JGAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["JGAmount"]); 
  				m_JGSH=SysConvert.ToString(MasterTable.Rows[0]["JGSH"]); 
  				m_RColorName=SysConvert.ToString(MasterTable.Rows[0]["RColorName"]); 
  				m_PBVendor=SysConvert.ToString(MasterTable.Rows[0]["PBVendor"]); 
  				m_RSVendor=SysConvert.ToString(MasterTable.Rows[0]["RSVendor"]); 
  				m_HZVendor=SysConvert.ToString(MasterTable.Rows[0]["HZVendor"]); 
  				m_HZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HZAmount"]); 
  				m_ProfitMargin=SysConvert.ToString(MasterTable.Rows[0]["ProfitMargin"]); 
  				m_JGAmount2=SysConvert.ToDecimal(MasterTable.Rows[0]["JGAmount2"]); 
  				m_JGSH2=SysConvert.ToString(MasterTable.Rows[0]["JGSH2"]); 
  				m_JGAmount3=SysConvert.ToDecimal(MasterTable.Rows[0]["JGAmount3"]); 
  				m_JGSH3=SysConvert.ToString(MasterTable.Rows[0]["JGSH3"]); 
  				m_MWeight2=SysConvert.ToString(MasterTable.Rows[0]["MWeight2"]); 
  				m_HZType=SysConvert.ToString(MasterTable.Rows[0]["HZType"]); 
  				m_Organ=SysConvert.ToString(MasterTable.Rows[0]["Organ"]); 
  				m_MinQty=SysConvert.ToString(MasterTable.Rows[0]["MinQty"]); 
  				m_DeliveryTime=SysConvert.ToString(MasterTable.Rows[0]["DeliveryTime"]); 
  				m_SalePriceRMB=SysConvert.ToString(MasterTable.Rows[0]["SalePriceRMB"]); 
  				m_SalePriceUSD=SysConvert.ToString(MasterTable.Rows[0]["SalePriceUSD"]); 
  				m_SalePricePro=SysConvert.ToString(MasterTable.Rows[0]["SalePricePro"]); 
  				m_SLDGM=SysConvert.ToString(MasterTable.Rows[0]["SLDGM"]); 
  				m_SLDSM=SysConvert.ToString(MasterTable.Rows[0]["SLDSM"]); 
  				m_SSLJX=SysConvert.ToString(MasterTable.Rows[0]["SSLJX"]); 
  				m_SSLWX=SysConvert.ToString(MasterTable.Rows[0]["SSLWX"]); 
  				m_SPQLJX=SysConvert.ToString(MasterTable.Rows[0]["SPQLJX"]); 
  				m_SPQLWX=SysConvert.ToString(MasterTable.Rows[0]["SPQLWX"]); 
  				m_LSQLJX=SysConvert.ToString(MasterTable.Rows[0]["LSQLJX"]); 
  				m_LSQLWX=SysConvert.ToString(MasterTable.Rows[0]["LSQLWX"]); 
  				m_PH=SysConvert.ToString(MasterTable.Rows[0]["PH"]); 
  				m_KQMQ=SysConvert.ToString(MasterTable.Rows[0]["KQMQ"]); 
  				m_GZLD=SysConvert.ToString(MasterTable.Rows[0]["GZLD"]); 
  				m_MFUnit=SysConvert.ToString(MasterTable.Rows[0]["MFUnit"]); 
  				m_InchNum=SysConvert.ToString(MasterTable.Rows[0]["InchNum"]); 
  				m_ItemModelNo=SysConvert.ToString(MasterTable.Rows[0]["ItemModelNo"]); 
  				m_ColorPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["ColorPrice"]); 
  				m_ZLPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["ZLPrice"]); 
  				m_TotalPriceUSB=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPriceUSB"]); 
  				m_ExchangeRate=SysConvert.ToDecimal(MasterTable.Rows[0]["ExchangeRate"]); 
  				m_TotalPriceRMB=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPriceRMB"]); 
  				m_CBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["CBPrice"]); 
  				m_ZJBJDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ZJBJDate"]); 
  				m_JGPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["JGPrice"]); 
  				m_TotalPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPrice"]); 
  				m_ZXBJDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ZXBJDate"]); 
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
