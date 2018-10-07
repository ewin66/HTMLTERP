using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_QuotedPriceDts实体类
	/// 作者:qiuchao
	/// 创建日期:2015/6/11
	/// </summary>
	public sealed class QuotedPriceDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public QuotedPriceDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public QuotedPriceDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_QuotedPriceDts";
		 
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
  
  		private string m_GBCode = string.Empty ; 
  		public string GBCode 
  		{ 
  			get 
  			{ 
  				return m_GBCode ; 
  			}  
  			set 
  			{ 
  				m_GBCode = value ; 
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
  
  		private string m_SelePriceDesc = string.Empty ; 
  		public string SelePriceDesc 
  		{ 
  			get 
  			{ 
  				return m_SelePriceDesc ; 
  			}  
  			set 
  			{ 
  				m_SelePriceDesc = value ; 
  			}  
  		} 
  
  		private DateTime m_SalePriceYXDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SalePriceYXDate 
  		{ 
  			get 
  			{ 
  				return m_SalePriceYXDate ; 
  			}  
  			set 
  			{ 
  				m_SalePriceYXDate = value ; 
  			}  
  		} 
  
  		private string m_SelePriceRemark = string.Empty ; 
  		public string SelePriceRemark 
  		{ 
  			get 
  			{ 
  				return m_SelePriceRemark ; 
  			}  
  			set 
  			{ 
  				m_SelePriceRemark = value ; 
  			}  
  		} 
  
  		private string m_JQDesc = string.Empty ; 
  		public string JQDesc 
  		{ 
  			get 
  			{ 
  				return m_JQDesc ; 
  			}  
  			set 
  			{ 
  				m_JQDesc = value ; 
  			}  
  		} 
  
  		private int m_PBFlag = 0; 
  		public int PBFlag 
  		{ 
  			get 
  			{ 
  				return m_PBFlag ; 
  			}  
  			set 
  			{ 
  				m_PBFlag = value ; 
  			}  
  		} 
  
  		private decimal m_SaleOPPrice = 0; 
  		public decimal SaleOPPrice 
  		{ 
  			get 
  			{ 
  				return m_SaleOPPrice ; 
  			}  
  			set 
  			{ 
  				m_SaleOPPrice = value ; 
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
  
  		private decimal m_AddPrice = 0; 
  		public decimal AddPrice 
  		{ 
  			get 
  			{ 
  				return m_AddPrice ; 
  			}  
  			set 
  			{ 
  				m_AddPrice = value ; 
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
  
  		private string m_KZ = string.Empty ; 
  		public string KZ 
  		{ 
  			get 
  			{ 
  				return m_KZ ; 
  			}  
  			set 
  			{ 
  				m_KZ = value ; 
  			}  
  		} 
  
  		private decimal m_HL = 0; 
  		public decimal HL 
  		{ 
  			get 
  			{ 
  				return m_HL ; 
  			}  
  			set 
  			{ 
  				m_HL = value ; 
  			}  
  		} 
  
  		private decimal m_USDPrice = 0; 
  		public decimal USDPrice 
  		{ 
  			get 
  			{ 
  				return m_USDPrice ; 
  			}  
  			set 
  			{ 
  				m_USDPrice = value ; 
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
  
  		private decimal m_USB = 0; 
  		public decimal USB 
  		{ 
  			get 
  			{ 
  				return m_USB ; 
  			}  
  			set 
  			{ 
  				m_USB = value ; 
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
  
  		private decimal m_PackFee = 0; 
  		public decimal PackFee 
  		{ 
  			get 
  			{ 
  				return m_PackFee ; 
  			}  
  			set 
  			{ 
  				m_PackFee = value ; 
  			}  
  		} 
  
  		private decimal m_LiRunFee = 0; 
  		public decimal LiRunFee 
  		{ 
  			get 
  			{ 
  				return m_LiRunFee ; 
  			}  
  			set 
  			{ 
  				m_LiRunFee = value ; 
  			}  
  		} 
  
  		private decimal m_TradeFee = 0; 
  		public decimal TradeFee 
  		{ 
  			get 
  			{ 
  				return m_TradeFee ; 
  			}  
  			set 
  			{ 
  				m_TradeFee = value ; 
  			}  
  		} 
  
  		private decimal m_YongJin = 0; 
  		public decimal YongJin 
  		{ 
  			get 
  			{ 
  				return m_YongJin ; 
  			}  
  			set 
  			{ 
  				m_YongJin = value ; 
  			}  
  		} 
  
  		private string m_HouZLReq = string.Empty ; 
  		public string HouZLReq 
  		{ 
  			get 
  			{ 
  				return m_HouZLReq ; 
  			}  
  			set 
  			{ 
  				m_HouZLReq = value ; 
  			}  
  		} 
  
  		private decimal m_Fee1 = 0; 
  		public decimal Fee1 
  		{ 
  			get 
  			{ 
  				return m_Fee1 ; 
  			}  
  			set 
  			{ 
  				m_Fee1 = value ; 
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
  
  		private decimal m_RMB = 0; 
  		public decimal RMB 
  		{ 
  			get 
  			{ 
  				return m_RMB ; 
  			}  
  			set 
  			{ 
  				m_RMB = value ; 
  			}  
  		} 
  
  		private decimal m_RMBY = 0; 
  		public decimal RMBY 
  		{ 
  			get 
  			{ 
  				return m_RMBY ; 
  			}  
  			set 
  			{ 
  				m_RMBY = value ; 
  			}  
  		} 
  
  		private decimal m_USBY = 0; 
  		public decimal USBY 
  		{ 
  			get 
  			{ 
  				return m_USBY ; 
  			}  
  			set 
  			{ 
  				m_USBY = value ; 
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
            string Sql="SELECT * FROM Sale_QuotedPriceDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_QuotedPriceDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_GBCode=SysConvert.ToString(MasterTable.Rows[0]["GBCode"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SalePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SalePrice"]); 
  				m_SelePriceDesc=SysConvert.ToString(MasterTable.Rows[0]["SelePriceDesc"]); 
  				m_SalePriceYXDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SalePriceYXDate"]); 
  				m_SelePriceRemark=SysConvert.ToString(MasterTable.Rows[0]["SelePriceRemark"]); 
  				m_JQDesc=SysConvert.ToString(MasterTable.Rows[0]["JQDesc"]); 
  				m_PBFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PBFlag"]); 
  				m_SaleOPPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SaleOPPrice"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_PBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PBPrice"]); 
  				m_COST=SysConvert.ToString(MasterTable.Rows[0]["COST"]); 
  				m_COSTA=SysConvert.ToString(MasterTable.Rows[0]["COSTA"]); 
  				m_QUOT=SysConvert.ToString(MasterTable.Rows[0]["QUOT"]); 
  				m_RShrinkage=SysConvert.ToString(MasterTable.Rows[0]["RShrinkage"]); 
  				m_RSAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["RSAmount"]); 
  				m_RSSH=SysConvert.ToString(MasterTable.Rows[0]["RSSH"]); 
  				m_JGAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["JGAmount"]); 
  				m_JGSH=SysConvert.ToString(MasterTable.Rows[0]["JGSH"]); 
  				m_HZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HZAmount"]); 
  				m_JGAmount2=SysConvert.ToDecimal(MasterTable.Rows[0]["JGAmount2"]); 
  				m_JGSH2=SysConvert.ToString(MasterTable.Rows[0]["JGSH2"]); 
  				m_JGAmount3=SysConvert.ToDecimal(MasterTable.Rows[0]["JGAmount3"]); 
  				m_JGSH3=SysConvert.ToString(MasterTable.Rows[0]["JGSH3"]); 
  				m_ProfitMargin=SysConvert.ToString(MasterTable.Rows[0]["ProfitMargin"]); 
  				m_AddPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["AddPrice"]); 
  				m_FK=SysConvert.ToString(MasterTable.Rows[0]["FK"]); 
  				m_HZType=SysConvert.ToString(MasterTable.Rows[0]["HZType"]); 
  				m_ItemClassID=SysConvert.ToInt32(MasterTable.Rows[0]["ItemClassID"]); 
  				m_DeliveryTime=SysConvert.ToString(MasterTable.Rows[0]["DeliveryTime"]); 
  				m_MinQty=SysConvert.ToString(MasterTable.Rows[0]["MinQty"]); 
  				m_PerMiWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["PerMiWeight"]); 
  				m_KZ=SysConvert.ToString(MasterTable.Rows[0]["KZ"]); 
  				m_HL=SysConvert.ToDecimal(MasterTable.Rows[0]["HL"]); 
  				m_USDPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["USDPrice"]); 
  				m_TotalPriceUSB=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPriceUSB"]); 
  				m_TotalPriceRMB=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPriceRMB"]); 
  				m_ColorPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["ColorPrice"]); 
  				m_ZLPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["ZLPrice"]); 
  				m_Shrinkage=SysConvert.ToDecimal(MasterTable.Rows[0]["Shrinkage"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_USB=SysConvert.ToDecimal(MasterTable.Rows[0]["USB"]); 
  				m_ItemUnit=SysConvert.ToString(MasterTable.Rows[0]["ItemUnit"]); 
  				m_PackFee=SysConvert.ToDecimal(MasterTable.Rows[0]["PackFee"]); 
  				m_LiRunFee=SysConvert.ToDecimal(MasterTable.Rows[0]["LiRunFee"]); 
  				m_TradeFee=SysConvert.ToDecimal(MasterTable.Rows[0]["TradeFee"]); 
  				m_YongJin=SysConvert.ToDecimal(MasterTable.Rows[0]["YongJin"]); 
  				m_HouZLReq=SysConvert.ToString(MasterTable.Rows[0]["HouZLReq"]); 
  				m_Fee1=SysConvert.ToDecimal(MasterTable.Rows[0]["Fee1"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_RMB=SysConvert.ToDecimal(MasterTable.Rows[0]["RMB"]); 
  				m_RMBY=SysConvert.ToDecimal(MasterTable.Rows[0]["RMBY"]); 
  				m_USBY=SysConvert.ToDecimal(MasterTable.Rows[0]["USBY"]); 
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
