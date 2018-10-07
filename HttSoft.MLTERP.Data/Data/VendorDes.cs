using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_VendorDes实体类
	/// 作者:章文强
	/// 创建日期:2012/11/27
	/// </summary>
	public sealed class VendorDes : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public VendorDes()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorDes(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_VendorDes";
		 
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
  
  		private string m_www = string.Empty ; 
  		public string www 
  		{ 
  			get 
  			{ 
  				return m_www ; 
  			}  
  			set 
  			{ 
  				m_www = value ; 
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
  
  		private string m_MLCGDate = string.Empty ; 
  		public string MLCGDate 
  		{ 
  			get 
  			{ 
  				return m_MLCGDate ; 
  			}  
  			set 
  			{ 
  				m_MLCGDate = value ; 
  			}  
  		} 
  
  		private string m_DHHDate = string.Empty ; 
  		public string DHHDate 
  		{ 
  			get 
  			{ 
  				return m_DHHDate ; 
  			}  
  			set 
  			{ 
  				m_DHHDate = value ; 
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
  
  		private int m_LS = 0; 
  		public int LS 
  		{ 
  			get 
  			{ 
  				return m_LS ; 
  			}  
  			set 
  			{ 
  				m_LS = value ; 
  			}  
  		} 
  
  		private int m_PFANDLS = 0; 
  		public int PFANDLS 
  		{ 
  			get 
  			{ 
  				return m_PFANDLS ; 
  			}  
  			set 
  			{ 
  				m_PFANDLS = value ; 
  			}  
  		} 
  
  		private string m_PFBL = string.Empty ; 
  		public string PFBL 
  		{ 
  			get 
  			{ 
  				return m_PFBL ; 
  			}  
  			set 
  			{ 
  				m_PFBL = value ; 
  			}  
  		} 
  
  		private string m_LSBL = string.Empty ; 
  		public string LSBL 
  		{ 
  			get 
  			{ 
  				return m_LSBL ; 
  			}  
  			set 
  			{ 
  				m_LSBL = value ; 
  			}  
  		} 
  
  		private int m_WF = 0; 
  		public int WF 
  		{ 
  			get 
  			{ 
  				return m_WF ; 
  			}  
  			set 
  			{ 
  				m_WF = value ; 
  			}  
  		} 
  
  		private int m_ZX = 0; 
  		public int ZX 
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
  
  		private string m_PVendorName = string.Empty ; 
  		public string PVendorName 
  		{ 
  			get 
  			{ 
  				return m_PVendorName ; 
  			}  
  			set 
  			{ 
  				m_PVendorName = value ; 
  			}  
  		} 
  
  		private string m_PVendorAddress = string.Empty ; 
  		public string PVendorAddress 
  		{ 
  			get 
  			{ 
  				return m_PVendorAddress ; 
  			}  
  			set 
  			{ 
  				m_PVendorAddress = value ; 
  			}  
  		} 
  
  		private string m_ContactTel = string.Empty ; 
  		public string ContactTel 
  		{ 
  			get 
  			{ 
  				return m_ContactTel ; 
  			}  
  			set 
  			{ 
  				m_ContactTel = value ; 
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
  
  		private string m_AddOPID = string.Empty ; 
  		public string AddOPID 
  		{ 
  			get 
  			{ 
  				return m_AddOPID ; 
  			}  
  			set 
  			{ 
  				m_AddOPID = value ; 
  			}  
  		} 
  
  		private string m_AddOPName = string.Empty ; 
  		public string AddOPName 
  		{ 
  			get 
  			{ 
  				return m_AddOPName ; 
  			}  
  			set 
  			{ 
  				m_AddOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_AddDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AddDate 
  		{ 
  			get 
  			{ 
  				return m_AddDate ; 
  			}  
  			set 
  			{ 
  				m_AddDate = value ; 
  			}  
  		} 
  
  		private string m_CGJJ = string.Empty ; 
  		public string CGJJ 
  		{ 
  			get 
  			{ 
  				return m_CGJJ ; 
  			}  
  			set 
  			{ 
  				m_CGJJ = value ; 
  			}  
  		} 
  
  		private string m_DHJJ = string.Empty ; 
  		public string DHJJ 
  		{ 
  			get 
  			{ 
  				return m_DHJJ ; 
  			}  
  			set 
  			{ 
  				m_DHJJ = value ; 
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
  
  		private decimal m_Fprice1 = 0; 
  		public decimal Fprice1 
  		{ 
  			get 
  			{ 
  				return m_Fprice1 ; 
  			}  
  			set 
  			{ 
  				m_Fprice1 = value ; 
  			}  
  		} 
  
  		private decimal m_Fprice2 = 0; 
  		public decimal Fprice2 
  		{ 
  			get 
  			{ 
  				return m_Fprice2 ; 
  			}  
  			set 
  			{ 
  				m_Fprice2 = value ; 
  			}  
  		} 
  
  		private decimal m_Fprice3 = 0; 
  		public decimal Fprice3 
  		{ 
  			get 
  			{ 
  				return m_Fprice3 ; 
  			}  
  			set 
  			{ 
  				m_Fprice3 = value ; 
  			}  
  		} 
  
  		private decimal m_Fprice4 = 0; 
  		public decimal Fprice4 
  		{ 
  			get 
  			{ 
  				return m_Fprice4 ; 
  			}  
  			set 
  			{ 
  				m_Fprice4 = value ; 
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
  
  		private string m_CG1 = string.Empty ; 
  		public string CG1 
  		{ 
  			get 
  			{ 
  				return m_CG1 ; 
  			}  
  			set 
  			{ 
  				m_CG1 = value ; 
  			}  
  		} 
  
  		private string m_CG2 = string.Empty ; 
  		public string CG2 
  		{ 
  			get 
  			{ 
  				return m_CG2 ; 
  			}  
  			set 
  			{ 
  				m_CG2 = value ; 
  			}  
  		} 
  
  		private string m_CG3 = string.Empty ; 
  		public string CG3 
  		{ 
  			get 
  			{ 
  				return m_CG3 ; 
  			}  
  			set 
  			{ 
  				m_CG3 = value ; 
  			}  
  		} 
  
  		private string m_CG4 = string.Empty ; 
  		public string CG4 
  		{ 
  			get 
  			{ 
  				return m_CG4 ; 
  			}  
  			set 
  			{ 
  				m_CG4 = value ; 
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
  
  		private string m_JJ = string.Empty ; 
  		public string JJ 
  		{ 
  			get 
  			{ 
  				return m_JJ ; 
  			}  
  			set 
  			{ 
  				m_JJ = value ; 
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
  
  		private string m_FormOPName = string.Empty ; 
  		public string FormOPName 
  		{ 
  			get 
  			{ 
  				return m_FormOPName ; 
  			}  
  			set 
  			{ 
  				m_FormOPName = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_VendorDes WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_VendorDes WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorName=SysConvert.ToString(MasterTable.Rows[0]["VendorName"]); 
  				m_CHBrand=SysConvert.ToString(MasterTable.Rows[0]["CHBrand"]); 
  				m_ENBrand=SysConvert.ToString(MasterTable.Rows[0]["ENBrand"]); 
  				m_Tel=SysConvert.ToString(MasterTable.Rows[0]["Tel"]); 
  				m_Fax=SysConvert.ToString(MasterTable.Rows[0]["Fax"]); 
  				m_Contact=SysConvert.ToString(MasterTable.Rows[0]["Contact"]); 
  				m_www=SysConvert.ToString(MasterTable.Rows[0]["www"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_MLCGDate=SysConvert.ToString(MasterTable.Rows[0]["MLCGDate"]); 
  				m_DHHDate=SysConvert.ToString(MasterTable.Rows[0]["DHHDate"]); 
  				m_PF=SysConvert.ToInt32(MasterTable.Rows[0]["PF"]); 
  				m_LS=SysConvert.ToInt32(MasterTable.Rows[0]["LS"]); 
  				m_PFANDLS=SysConvert.ToInt32(MasterTable.Rows[0]["PFANDLS"]); 
  				m_PFBL=SysConvert.ToString(MasterTable.Rows[0]["PFBL"]); 
  				m_LSBL=SysConvert.ToString(MasterTable.Rows[0]["LSBL"]); 
  				m_WF=SysConvert.ToInt32(MasterTable.Rows[0]["WF"]); 
  				m_ZX=SysConvert.ToInt32(MasterTable.Rows[0]["ZX"]); 
  				m_PVendorName=SysConvert.ToString(MasterTable.Rows[0]["PVendorName"]); 
  				m_PVendorAddress=SysConvert.ToString(MasterTable.Rows[0]["PVendorAddress"]); 
  				m_ContactTel=SysConvert.ToString(MasterTable.Rows[0]["ContactTel"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_AddOPID=SysConvert.ToString(MasterTable.Rows[0]["AddOPID"]); 
  				m_AddOPName=SysConvert.ToString(MasterTable.Rows[0]["AddOPName"]); 
  				m_AddDate=SysConvert.ToDateTime(MasterTable.Rows[0]["AddDate"]); 
  				m_CGJJ=SysConvert.ToString(MasterTable.Rows[0]["CGJJ"]); 
  				m_DHJJ=SysConvert.ToString(MasterTable.Rows[0]["DHJJ"]); 
  				m_age1=SysConvert.ToInt32(MasterTable.Rows[0]["age1"]); 
  				m_age2=SysConvert.ToInt32(MasterTable.Rows[0]["age2"]); 
  				m_Fprice1=SysConvert.ToDecimal(MasterTable.Rows[0]["Fprice1"]); 
  				m_Fprice2=SysConvert.ToDecimal(MasterTable.Rows[0]["Fprice2"]); 
  				m_Fprice3=SysConvert.ToDecimal(MasterTable.Rows[0]["Fprice3"]); 
  				m_Fprice4=SysConvert.ToDecimal(MasterTable.Rows[0]["Fprice4"]); 
  				m_SJFG=SysConvert.ToString(MasterTable.Rows[0]["SJFG"]); 
  				m_CG1=SysConvert.ToString(MasterTable.Rows[0]["CG1"]); 
  				m_CG2=SysConvert.ToString(MasterTable.Rows[0]["CG2"]); 
  				m_CG3=SysConvert.ToString(MasterTable.Rows[0]["CG3"]); 
  				m_CG4=SysConvert.ToString(MasterTable.Rows[0]["CG4"]); 
  				m_MPrice1=SysConvert.ToString(MasterTable.Rows[0]["MPrice1"]); 
  				m_MPrice2=SysConvert.ToString(MasterTable.Rows[0]["MPrice2"]); 
  				m_MPrice3=SysConvert.ToString(MasterTable.Rows[0]["MPrice3"]); 
  				m_MPrice4=SysConvert.ToString(MasterTable.Rows[0]["MPrice4"]); 
  				m_ZY=SysConvert.ToInt32(MasterTable.Rows[0]["ZY"]); 
  				m_DL=SysConvert.ToInt32(MasterTable.Rows[0]["DL"]); 
  				m_JJ=SysConvert.ToString(MasterTable.Rows[0]["JJ"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_FormOPName=SysConvert.ToString(MasterTable.Rows[0]["FormOPName"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
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
