using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_Vendor实体类
	/// 作者:周富春
	/// 创建日期:2014/11/11
	/// </summary>
	public sealed class Vendor : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Vendor()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Vendor(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_Vendor";
		 
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
  
  		private string m_VendorAttn = string.Empty ; 
  		public string VendorAttn 
  		{ 
  			get 
  			{ 
  				return m_VendorAttn ; 
  			}  
  			set 
  			{ 
  				m_VendorAttn = value ; 
  			}  
  		} 
  
  		private string m_VendorName = string.Empty ; 
  		public string VendorName 
  		{ 
  			get 
  			{ 
  				return m_VendorName ; 
  			}  
  			set 
  			{ 
  				m_VendorName = value ; 
  			}  
  		} 
  
  		private string m_VendorNameEn = string.Empty ; 
  		public string VendorNameEn 
  		{ 
  			get 
  			{ 
  				return m_VendorNameEn ; 
  			}  
  			set 
  			{ 
  				m_VendorNameEn = value ; 
  			}  
  		} 
  
  		private int m_VendorTypeID = 0; 
  		public int VendorTypeID 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID = value ; 
  			}  
  		} 
  
  		private string m_Tel = string.Empty ; 
  		public string Tel 
  		{ 
  			get 
  			{ 
  				return m_Tel ; 
  			}  
  			set 
  			{ 
  				m_Tel = value ; 
  			}  
  		} 
  
  		private string m_Fax = string.Empty ; 
  		public string Fax 
  		{ 
  			get 
  			{ 
  				return m_Fax ; 
  			}  
  			set 
  			{ 
  				m_Fax = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
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
  
  		private int m_WebFlag = 0; 
  		public int WebFlag 
  		{ 
  			get 
  			{ 
  				return m_WebFlag ; 
  			}  
  			set 
  			{ 
  				m_WebFlag = value ; 
  			}  
  		} 
  
  		private string m_Password = string.Empty ; 
  		public string Password 
  		{ 
  			get 
  			{ 
  				return m_Password ; 
  			}  
  			set 
  			{ 
  				m_Password = value ; 
  			}  
  		} 
  
  		private string m_Country = string.Empty ; 
  		public string Country 
  		{ 
  			get 
  			{ 
  				return m_Country ; 
  			}  
  			set 
  			{ 
  				m_Country = value ; 
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
  
  		private DateTime m_InDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InDate 
  		{ 
  			get 
  			{ 
  				return m_InDate ; 
  			}  
  			set 
  			{ 
  				m_InDate = value ; 
  			}  
  		} 
  
  		private string m_InSaleOP = string.Empty ; 
  		public string InSaleOP 
  		{ 
  			get 
  			{ 
  				return m_InSaleOP ; 
  			}  
  			set 
  			{ 
  				m_InSaleOP = value ; 
  			}  
  		} 
  
  		private string m_WebUrl = string.Empty ; 
  		public string WebUrl 
  		{ 
  			get 
  			{ 
  				return m_WebUrl ; 
  			}  
  			set 
  			{ 
  				m_WebUrl = value ; 
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
  
  		private string m_Area = string.Empty ; 
  		public string Area 
  		{ 
  			get 
  			{ 
  				return m_Area ; 
  			}  
  			set 
  			{ 
  				m_Area = value ; 
  			}  
  		} 
  
  		private int m_VendorTypeID2 = 0; 
  		public int VendorTypeID2 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID2 ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID2 = value ; 
  			}  
  		} 
  
  		private int m_VendorTypeID3 = 0; 
  		public int VendorTypeID3 
  		{ 
  			get 
  			{ 
  				return m_VendorTypeID3 ; 
  			}  
  			set 
  			{ 
  				m_VendorTypeID3 = value ; 
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
  
  		private string m_QueryAccount = string.Empty ; 
  		public string QueryAccount 
  		{ 
  			get 
  			{ 
  				return m_QueryAccount ; 
  			}  
  			set 
  			{ 
  				m_QueryAccount = value ; 
  			}  
  		} 
  
  		private string m_VendorLevel = string.Empty ; 
  		public string VendorLevel 
  		{ 
  			get 
  			{ 
  				return m_VendorLevel ; 
  			}  
  			set 
  			{ 
  				m_VendorLevel = value ; 
  			}  
  		} 
  
  		private string m_CHBrand = string.Empty ; 
  		public string CHBrand 
  		{ 
  			get 
  			{ 
  				return m_CHBrand ; 
  			}  
  			set 
  			{ 
  				m_CHBrand = value ; 
  			}  
  		} 
  
  		private string m_ENBrand = string.Empty ; 
  		public string ENBrand 
  		{ 
  			get 
  			{ 
  				return m_ENBrand ; 
  			}  
  			set 
  			{ 
  				m_ENBrand = value ; 
  			}  
  		} 
  
  		private int m_age1 = 0; 
  		public int age1 
  		{ 
  			get 
  			{ 
  				return m_age1 ; 
  			}  
  			set 
  			{ 
  				m_age1 = value ; 
  			}  
  		} 
  
  		private int m_age2 = 0; 
  		public int age2 
  		{ 
  			get 
  			{ 
  				return m_age2 ; 
  			}  
  			set 
  			{ 
  				m_age2 = value ; 
  			}  
  		} 
  
  		private string m_SJFG = string.Empty ; 
  		public string SJFG 
  		{ 
  			get 
  			{ 
  				return m_SJFG ; 
  			}  
  			set 
  			{ 
  				m_SJFG = value ; 
  			}  
  		} 
  
  		private string m_MPrice1 = string.Empty ; 
  		public string MPrice1 
  		{ 
  			get 
  			{ 
  				return m_MPrice1 ; 
  			}  
  			set 
  			{ 
  				m_MPrice1 = value ; 
  			}  
  		} 
  
  		private string m_MPrice2 = string.Empty ; 
  		public string MPrice2 
  		{ 
  			get 
  			{ 
  				return m_MPrice2 ; 
  			}  
  			set 
  			{ 
  				m_MPrice2 = value ; 
  			}  
  		} 
  
  		private string m_MPrice3 = string.Empty ; 
  		public string MPrice3 
  		{ 
  			get 
  			{ 
  				return m_MPrice3 ; 
  			}  
  			set 
  			{ 
  				m_MPrice3 = value ; 
  			}  
  		} 
  
  		private string m_MPrice4 = string.Empty ; 
  		public string MPrice4 
  		{ 
  			get 
  			{ 
  				return m_MPrice4 ; 
  			}  
  			set 
  			{ 
  				m_MPrice4 = value ; 
  			}  
  		} 
  
  		private int m_PF = 0; 
  		public int PF 
  		{ 
  			get 
  			{ 
  				return m_PF ; 
  			}  
  			set 
  			{ 
  				m_PF = value ; 
  			}  
  		} 
  
  		private int m_DL = 0; 
  		public int DL 
  		{ 
  			get 
  			{ 
  				return m_DL ; 
  			}  
  			set 
  			{ 
  				m_DL = value ; 
  			}  
  		} 
  
  		private int m_ZY = 0; 
  		public int ZY 
  		{ 
  			get 
  			{ 
  				return m_ZY ; 
  			}  
  			set 
  			{ 
  				m_ZY = value ; 
  			}  
  		} 
  
  		private string m_MainSale = string.Empty ; 
  		public string MainSale 
  		{ 
  			get 
  			{ 
  				return m_MainSale ; 
  			}  
  			set 
  			{ 
  				m_MainSale = value ; 
  			}  
  		} 
  
  		private decimal m_LimitAmount = 0; 
  		public decimal LimitAmount 
  		{ 
  			get 
  			{ 
  				return m_LimitAmount ; 
  			}  
  			set 
  			{ 
  				m_LimitAmount = value ; 
  			}  
  		}

        private decimal m_SHXAmount = 0;
        public decimal SHXAmount
        {
            get
            {
                return m_SHXAmount;
            }
            set
            {
                m_SHXAmount = value;
            }
        } 
  
  		private int m_LimitDayNum = 0; 
  		public int LimitDayNum 
  		{ 
  			get 
  			{ 
  				return m_LimitDayNum ; 
  			}  
  			set 
  			{ 
  				m_LimitDayNum = value ; 
  			}  
  		} 
  
  		private string m_QQ = string.Empty ; 
  		public string QQ 
  		{ 
  			get 
  			{ 
  				return m_QQ ; 
  			}  
  			set 
  			{ 
  				m_QQ = value ; 
  			}  
  		} 
  
  		private string m_Alibaba = string.Empty ; 
  		public string Alibaba 
  		{ 
  			get 
  			{ 
  				return m_Alibaba ; 
  			}  
  			set 
  			{ 
  				m_Alibaba = value ; 
  			}  
  		} 
  
  		private string m_MainBusiness = string.Empty ; 
  		public string MainBusiness 
  		{ 
  			get 
  			{ 
  				return m_MainBusiness ; 
  			}  
  			set 
  			{ 
  				m_MainBusiness = value ; 
  			}  
  		} 
  
  		private string m_VendorNameSpell = string.Empty ; 
  		public string VendorNameSpell 
  		{ 
  			get 
  			{ 
  				return m_VendorNameSpell ; 
  			}  
  			set 
  			{ 
  				m_VendorNameSpell = value ; 
  			}  
  		} 
  
  		private string m_ZhangHao = string.Empty ; 
  		public string ZhangHao 
  		{ 
  			get 
  			{ 
  				return m_ZhangHao ; 
  			}  
  			set 
  			{ 
  				m_ZhangHao = value ; 
  			}  
  		} 
  
  		private string m_ContactEn = string.Empty ; 
  		public string ContactEn 
  		{ 
  			get 
  			{ 
  				return m_ContactEn ; 
  			}  
  			set 
  			{ 
  				m_ContactEn = value ; 
  			}  
  		} 
  
  		private string m_Mobile = string.Empty ; 
  		public string Mobile 
  		{ 
  			get 
  			{ 
  				return m_Mobile ; 
  			}  
  			set 
  			{ 
  				m_Mobile = value ; 
  			}  
  		} 
  
  		private string m_VendorStyle = string.Empty ; 
  		public string VendorStyle 
  		{ 
  			get 
  			{ 
  				return m_VendorStyle ; 
  			}  
  			set 
  			{ 
  				m_VendorStyle = value ; 
  			}  
  		} 
  
  		private string m_EMail = string.Empty ; 
  		public string EMail 
  		{ 
  			get 
  			{ 
  				return m_EMail ; 
  			}  
  			set 
  			{ 
  				m_EMail = value ; 
  			}  
  		} 
  
  		private string m_Province = string.Empty ; 
  		public string Province 
  		{ 
  			get 
  			{ 
  				return m_Province ; 
  			}  
  			set 
  			{ 
  				m_Province = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_Vendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_Vendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorAttn=SysConvert.ToString(MasterTable.Rows[0]["VendorAttn"]); 
  				m_VendorName=SysConvert.ToString(MasterTable.Rows[0]["VendorName"]); 
  				m_VendorNameEn=SysConvert.ToString(MasterTable.Rows[0]["VendorNameEn"]); 
  				m_VendorTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID"]); 
  				m_Tel=SysConvert.ToString(MasterTable.Rows[0]["Tel"]); 
  				m_Fax=SysConvert.ToString(MasterTable.Rows[0]["Fax"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_UseableFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UseableFlag"]); 
  				m_WebFlag=SysConvert.ToInt32(MasterTable.Rows[0]["WebFlag"]); 
  				m_Password=SysConvert.ToString(MasterTable.Rows[0]["Password"]); 
  				m_Country=SysConvert.ToString(MasterTable.Rows[0]["Country"]); 
  				m_Contact=SysConvert.ToString(MasterTable.Rows[0]["Contact"]); 
  				m_InDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InDate"]); 
  				m_InSaleOP=SysConvert.ToString(MasterTable.Rows[0]["InSaleOP"]); 
  				m_WebUrl=SysConvert.ToString(MasterTable.Rows[0]["WebUrl"]); 
  				m_Free1=SysConvert.ToString(MasterTable.Rows[0]["Free1"]); 
  				m_Free2=SysConvert.ToString(MasterTable.Rows[0]["Free2"]); 
  				m_Free3=SysConvert.ToString(MasterTable.Rows[0]["Free3"]); 
  				m_Area=SysConvert.ToString(MasterTable.Rows[0]["Area"]); 
  				m_VendorTypeID2=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID2"]); 
  				m_VendorTypeID3=SysConvert.ToInt32(MasterTable.Rows[0]["VendorTypeID3"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_QueryAccount=SysConvert.ToString(MasterTable.Rows[0]["QueryAccount"]); 
  				m_VendorLevel=SysConvert.ToString(MasterTable.Rows[0]["VendorLevel"]); 
  				m_CHBrand=SysConvert.ToString(MasterTable.Rows[0]["CHBrand"]); 
  				m_ENBrand=SysConvert.ToString(MasterTable.Rows[0]["ENBrand"]); 
  				m_age1=SysConvert.ToInt32(MasterTable.Rows[0]["age1"]); 
  				m_age2=SysConvert.ToInt32(MasterTable.Rows[0]["age2"]); 
  				m_SJFG=SysConvert.ToString(MasterTable.Rows[0]["SJFG"]); 
  				m_MPrice1=SysConvert.ToString(MasterTable.Rows[0]["MPrice1"]); 
  				m_MPrice2=SysConvert.ToString(MasterTable.Rows[0]["MPrice2"]); 
  				m_MPrice3=SysConvert.ToString(MasterTable.Rows[0]["MPrice3"]); 
  				m_MPrice4=SysConvert.ToString(MasterTable.Rows[0]["MPrice4"]); 
  				m_PF=SysConvert.ToInt32(MasterTable.Rows[0]["PF"]); 
  				m_DL=SysConvert.ToInt32(MasterTable.Rows[0]["DL"]); 
  				m_ZY=SysConvert.ToInt32(MasterTable.Rows[0]["ZY"]); 
  				m_MainSale=SysConvert.ToString(MasterTable.Rows[0]["MainSale"]); 
  				m_LimitAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["LimitAmount"]);
                m_SHXAmount = SysConvert.ToDecimal(MasterTable.Rows[0]["SHXAmount"]); //授信额
  				m_LimitDayNum=SysConvert.ToInt32(MasterTable.Rows[0]["LimitDayNum"]); 
  				m_QQ=SysConvert.ToString(MasterTable.Rows[0]["QQ"]); 
  				m_Alibaba=SysConvert.ToString(MasterTable.Rows[0]["Alibaba"]); 
  				m_MainBusiness=SysConvert.ToString(MasterTable.Rows[0]["MainBusiness"]); 
  				m_VendorNameSpell=SysConvert.ToString(MasterTable.Rows[0]["VendorNameSpell"]); 
  				m_ZhangHao=SysConvert.ToString(MasterTable.Rows[0]["ZhangHao"]); 
  				m_ContactEn=SysConvert.ToString(MasterTable.Rows[0]["ContactEn"]); 
  				m_Mobile=SysConvert.ToString(MasterTable.Rows[0]["Mobile"]); 
  				m_VendorStyle=SysConvert.ToString(MasterTable.Rows[0]["VendorStyle"]); 
  				m_EMail=SysConvert.ToString(MasterTable.Rows[0]["EMail"]); 
  				m_Province=SysConvert.ToString(MasterTable.Rows[0]["Province"]); 
  				m_PayMethodFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PayMethodFlag"]); 
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
