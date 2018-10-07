using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_Brand实体类
	/// 作者:sunxun
	/// 创建日期:2010-5-5
	/// </summary>
	public sealed class Brand : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Brand()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Brand(IDBTransAccess p_SqlCmd)
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
  
  		private string m_BrandID = string.Empty ; 
  		public string BrandID 
  		{ 
  			get 
  			{ 
  				return m_BrandID ; 
  			}  
  			set 
  			{ 
  				m_BrandID = value ; 
  			}  
  		} 
  
  		private string m_BrandAttn = string.Empty ; 
  		public string BrandAttn 
  		{ 
  			get 
  			{ 
  				return m_BrandAttn ; 
  			}  
  			set 
  			{ 
  				m_BrandAttn = value ; 
  			}  
  		} 
  
  		private string m_BrandName = string.Empty ; 
  		public string BrandName 
  		{ 
  			get 
  			{ 
  				return m_BrandName ; 
  			}  
  			set 
  			{ 
  				m_BrandName = value ; 
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
  
  		private string m_AttOPID = string.Empty ; 
  		public string AttOPID 
  		{ 
  			get 
  			{ 
  				return m_AttOPID ; 
  			}  
  			set 
  			{ 
  				m_AttOPID = value ; 
  			}  
  		} 
  
  		private string m_WOOPID = string.Empty ; 
  		public string WOOPID 
  		{ 
  			get 
  			{ 
  				return m_WOOPID ; 
  			}  
  			set 
  			{ 
  				m_WOOPID = value ; 
  			}  
  		} 
  
  		private string m_RightName = string.Empty ; 
  		public string RightName 
  		{ 
  			get 
  			{ 
  				return m_RightName ; 
  			}  
  			set 
  			{ 
  				m_RightName = value ; 
  			}  
  		} 
  
  		private string m_MD = string.Empty ; 
  		public string MD 
  		{ 
  			get 
  			{ 
  				return m_MD ; 
  			}  
  			set 
  			{ 
  				m_MD = value ; 
  			}  
  		} 
  
  		private string m_DesignName = string.Empty ; 
  		public string DesignName 
  		{ 
  			get 
  			{ 
  				return m_DesignName ; 
  			}  
  			set 
  			{ 
  				m_DesignName = value ; 
  			}  
  		} 
  
  		private string m_ProName = string.Empty ; 
  		public string ProName 
  		{ 
  			get 
  			{ 
  				return m_ProName ; 
  			}  
  			set 
  			{ 
  				m_ProName = value ; 
  			}  
  		} 
  
  		private string m_BrandCls = string.Empty ; 
  		public string BrandCls 
  		{ 
  			get 
  			{ 
  				return m_BrandCls ; 
  			}  
  			set 
  			{ 
  				m_BrandCls = value ; 
  			}  
  		} 
  
  		private string m_BrandDesc = string.Empty ; 
  		public string BrandDesc 
  		{ 
  			get 
  			{ 
  				return m_BrandDesc ; 
  			}  
  			set 
  			{ 
  				m_BrandDesc = value ; 
  			}  
  		} 
  
  		private string m_BrandCodeRule = string.Empty ; 
  		public string BrandCodeRule 
  		{ 
  			get 
  			{ 
  				return m_BrandCodeRule ; 
  			}  
  			set 
  			{ 
  				m_BrandCodeRule = value ; 
  			}  
  		} 
  
  		private string m_SaleType = string.Empty ; 
  		public string SaleType 
  		{ 
  			get 
  			{ 
  				return m_SaleType ; 
  			}  
  			set 
  			{ 
  				m_SaleType = value ; 
  			}  
  		} 
  
  		private int m_BeginYear = 0; 
  		public int BeginYear 
  		{ 
  			get 
  			{ 
  				return m_BeginYear ; 
  			}  
  			set 
  			{ 
  				m_BeginYear = value ; 
  			}  
  		} 
  
  		private string m_ShowPlan = string.Empty ; 
  		public string ShowPlan 
  		{ 
  			get 
  			{ 
  				return m_ShowPlan ; 
  			}  
  			set 
  			{ 
  				m_ShowPlan = value ; 
  			}  
  		} 
  
  		private string m_GoodsDesc = string.Empty ; 
  		public string GoodsDesc 
  		{ 
  			get 
  			{ 
  				return m_GoodsDesc ; 
  			}  
  			set 
  			{ 
  				m_GoodsDesc = value ; 
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
  
  		private string m_Free1 = string.Empty ; 
  		public string Free1 
  		{ 
  			get 
  			{ 
  				return m_Free1 ; 
  			}  
  			set 
  			{ 
  				m_Free1 = value ; 
  			}  
  		} 
  
  		private string m_Free2 = string.Empty ; 
  		public string Free2 
  		{ 
  			get 
  			{ 
  				return m_Free2 ; 
  			}  
  			set 
  			{ 
  				m_Free2 = value ; 
  			}  
  		} 
  
  		private string m_Free3 = string.Empty ; 
  		public string Free3 
  		{ 
  			get 
  			{ 
  				return m_Free3 ; 
  			}  
  			set 
  			{ 
  				m_Free3 = value ; 
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
  
  		private string m_RequestType = string.Empty ; 
  		public string RequestType 
  		{ 
  			get 
  			{ 
  				return m_RequestType ; 
  			}  
  			set 
  			{ 
  				m_RequestType = value ; 
  			}  
  		} 
  
  		private string m_FinalType = string.Empty ; 
  		public string FinalType 
  		{ 
  			get 
  			{ 
  				return m_FinalType ; 
  			}  
  			set 
  			{ 
  				m_FinalType = value ; 
  			}  
  		} 
  
  		private string m_ExpressFinal = string.Empty ; 
  		public string ExpressFinal 
  		{ 
  			get 
  			{ 
  				return m_ExpressFinal ; 
  			}  
  			set 
  			{ 
  				m_ExpressFinal = value ; 
  			}  
  		} 
  
  		private string m_ExitType = string.Empty ; 
  		public string ExitType 
  		{ 
  			get 
  			{ 
  				return m_ExitType ; 
  			}  
  			set 
  			{ 
  				m_ExitType = value ; 
  			}  
  		} 
  
  		private string m_SSNExpense = string.Empty ; 
  		public string SSNExpense 
  		{ 
  			get 
  			{ 
  				return m_SSNExpense ; 
  			}  
  			set 
  			{ 
  				m_SSNExpense = value ; 
  			}  
  		} 
  
  		private string m_ItemFinalType = string.Empty ; 
  		public string ItemFinalType 
  		{ 
  			get 
  			{ 
  				return m_ItemFinalType ; 
  			}  
  			set 
  			{ 
  				m_ItemFinalType = value ; 
  			}  
  		} 
  
  		private string m_AttnFinalType = string.Empty ; 
  		public string AttnFinalType 
  		{ 
  			get 
  			{ 
  				return m_AttnFinalType ; 
  			}  
  			set 
  			{ 
  				m_AttnFinalType = value ; 
  			}  
  		} 
  
  		private string m_AttnRequirement = string.Empty ; 
  		public string AttnRequirement 
  		{ 
  			get 
  			{ 
  				return m_AttnRequirement ; 
  			}  
  			set 
  			{ 
  				m_AttnRequirement = value ; 
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
  
  		private string m_Payment = string.Empty ; 
  		public string Payment 
  		{ 
  			get 
  			{ 
  				return m_Payment ; 
  			}  
  			set 
  			{ 
  				m_Payment = value ; 
  			}  
  		} 
  
  		private string m_QY = string.Empty ; 
  		public string QY 
  		{ 
  			get 
  			{ 
  				return m_QY ; 
  			}  
  			set 
  			{ 
  				m_QY = value ; 
  			}  
  		} 
  
  		private int m_LimitBuyQty = 0; 
  		public int LimitBuyQty 
  		{ 
  			get 
  			{ 
  				return m_LimitBuyQty ; 
  			}  
  			set 
  			{ 
  				m_LimitBuyQty = value ; 
  			}  
  		} 
  
  		private int m_ProQty = 0; 
  		public int ProQty 
  		{ 
  			get 
  			{ 
  				return m_ProQty ; 
  			}  
  			set 
  			{ 
  				m_ProQty = value ; 
  			}  
  		} 
  
  		private string m_Contact = string.Empty ; 
  		public string Contact 
  		{ 
  			get 
  			{ 
  				return m_Contact ; 
  			}  
  			set 
  			{ 
  				m_Contact = value ; 
  			}  
  		} 
  
  		private string m_ContactEMail = string.Empty ; 
  		public string ContactEMail 
  		{ 
  			get 
  			{ 
  				return m_ContactEMail ; 
  			}  
  			set 
  			{ 
  				m_ContactEMail = value ; 
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
  
  		private string m_VendorDutyOP = string.Empty ; 
  		public string VendorDutyOP 
  		{ 
  			get 
  			{ 
  				return m_VendorDutyOP ; 
  			}  
  			set 
  			{ 
  				m_VendorDutyOP = value ; 
  			}  
  		} 
  
  		private string m_SaleOPDepartment = string.Empty ; 
  		public string SaleOPDepartment 
  		{ 
  			get 
  			{ 
  				return m_SaleOPDepartment ; 
  			}  
  			set 
  			{ 
  				m_SaleOPDepartment = value ; 
  			}  
  		} 
  
  		private string m_BJOPID = string.Empty ; 
  		public string BJOPID 
  		{ 
  			get 
  			{ 
  				return m_BJOPID ; 
  			}  
  			set 
  			{ 
  				m_BJOPID = value ; 
  			}  
  		} 
  
  		private int m_ISSHCheck = 0; 
  		public int ISSHCheck 
  		{ 
  			get 
  			{ 
  				return m_ISSHCheck ; 
  			}  
  			set 
  			{ 
  				m_ISSHCheck = value ; 
  			}  
  		} 
  
  		private string m_JSXType = string.Empty ; 
  		public string JSXType 
  		{ 
  			get 
  			{ 
  				return m_JSXType ; 
  			}  
  			set 
  			{ 
  				m_JSXType = value ; 
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
  
  		private string m_TecOPID = string.Empty ; 
  		public string TecOPID 
  		{ 
  			get 
  			{ 
  				return m_TecOPID ; 
  			}  
  			set 
  			{ 
  				m_TecOPID = value ; 
  			}  
  		} 
  
  		private string m_ChkDepID = string.Empty ; 
  		public string ChkDepID 
  		{ 
  			get 
  			{ 
  				return m_ChkDepID ; 
  			}  
  			set 
  			{ 
  				m_ChkDepID = value ; 
  			}  
  		} 
  
  		private decimal m_LRJS = 0; 
  		public decimal LRJS 
  		{ 
  			get 
  			{ 
  				return m_LRJS ; 
  			}  
  			set 
  			{ 
  				m_LRJS = value ; 
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
            string Sql="SELECT * FROM Data_Brand WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_Brand WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_BrandID=SysConvert.ToString(MasterTable.Rows[0]["BrandID"]); 
  				m_BrandAttn=SysConvert.ToString(MasterTable.Rows[0]["BrandAttn"]); 
  				m_BrandName=SysConvert.ToString(MasterTable.Rows[0]["BrandName"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_AttOPID=SysConvert.ToString(MasterTable.Rows[0]["AttOPID"]); 
  				m_WOOPID=SysConvert.ToString(MasterTable.Rows[0]["WOOPID"]); 
  				m_RightName=SysConvert.ToString(MasterTable.Rows[0]["RightName"]); 
  				m_MD=SysConvert.ToString(MasterTable.Rows[0]["MD"]); 
  				m_DesignName=SysConvert.ToString(MasterTable.Rows[0]["DesignName"]); 
  				m_ProName=SysConvert.ToString(MasterTable.Rows[0]["ProName"]); 
  				m_BrandCls=SysConvert.ToString(MasterTable.Rows[0]["BrandCls"]); 
  				m_BrandDesc=SysConvert.ToString(MasterTable.Rows[0]["BrandDesc"]); 
  				m_BrandCodeRule=SysConvert.ToString(MasterTable.Rows[0]["BrandCodeRule"]); 
  				m_SaleType=SysConvert.ToString(MasterTable.Rows[0]["SaleType"]); 
  				m_BeginYear=SysConvert.ToInt32(MasterTable.Rows[0]["BeginYear"]); 
  				m_ShowPlan=SysConvert.ToString(MasterTable.Rows[0]["ShowPlan"]); 
  				m_GoodsDesc=SysConvert.ToString(MasterTable.Rows[0]["GoodsDesc"]); 
  				m_UseableFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UseableFlag"]); 
  				m_Free1=SysConvert.ToString(MasterTable.Rows[0]["Free1"]); 
  				m_Free2=SysConvert.ToString(MasterTable.Rows[0]["Free2"]); 
  				m_Free3=SysConvert.ToString(MasterTable.Rows[0]["Free3"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_RequestType=SysConvert.ToString(MasterTable.Rows[0]["RequestType"]); 
  				m_FinalType=SysConvert.ToString(MasterTable.Rows[0]["FinalType"]); 
  				m_ExpressFinal=SysConvert.ToString(MasterTable.Rows[0]["ExpressFinal"]); 
  				m_ExitType=SysConvert.ToString(MasterTable.Rows[0]["ExitType"]); 
  				m_SSNExpense=SysConvert.ToString(MasterTable.Rows[0]["SSNExpense"]); 
  				m_ItemFinalType=SysConvert.ToString(MasterTable.Rows[0]["ItemFinalType"]); 
  				m_AttnFinalType=SysConvert.ToString(MasterTable.Rows[0]["AttnFinalType"]); 
  				m_AttnRequirement=SysConvert.ToString(MasterTable.Rows[0]["AttnRequirement"]); 
  				m_Currency=SysConvert.ToString(MasterTable.Rows[0]["Currency"]); 
  				m_Payment=SysConvert.ToString(MasterTable.Rows[0]["Payment"]); 
  				m_QY=SysConvert.ToString(MasterTable.Rows[0]["QY"]); 
  				m_LimitBuyQty=SysConvert.ToInt32(MasterTable.Rows[0]["LimitBuyQty"]); 
  				m_ProQty=SysConvert.ToInt32(MasterTable.Rows[0]["ProQty"]); 
  				m_Contact=SysConvert.ToString(MasterTable.Rows[0]["Contact"]); 
  				m_ContactEMail=SysConvert.ToString(MasterTable.Rows[0]["ContactEMail"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_VendorDutyOP=SysConvert.ToString(MasterTable.Rows[0]["VendorDutyOP"]); 
  				m_SaleOPDepartment=SysConvert.ToString(MasterTable.Rows[0]["SaleOPDepartment"]); 
  				m_BJOPID=SysConvert.ToString(MasterTable.Rows[0]["BJOPID"]); 
  				m_ISSHCheck=SysConvert.ToInt32(MasterTable.Rows[0]["ISSHCheck"]); 
  				m_JSXType=SysConvert.ToString(MasterTable.Rows[0]["JSXType"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_TecOPID=SysConvert.ToString(MasterTable.Rows[0]["TecOPID"]); 
  				m_ChkDepID=SysConvert.ToString(MasterTable.Rows[0]["ChkDepID"]); 
  				m_LRJS=SysConvert.ToDecimal(MasterTable.Rows[0]["LRJS"]); 
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
