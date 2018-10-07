using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_VendorCompact实体类
	/// 作者:周富春
	/// 创建日期:2011/12/14
	/// </summary>
	public sealed class VendorCompact : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public VendorCompact()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorCompact(IDBTransAccess p_SqlCmd)
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
  
  		private string m_SOID = string.Empty ; 
  		public string SOID 
  		{ 
  			get 
  			{ 
  				return m_SOID ; 
  			}  
  			set 
  			{ 
  				m_SOID = value ; 
  			}  
  		} 
  
  		private string m_CompactNo = string.Empty ; 
  		public string CompactNo 
  		{ 
  			get 
  			{ 
  				return m_CompactNo ; 
  			}  
  			set 
  			{ 
  				m_CompactNo = value ; 
  			}  
  		} 
  
  		private string m_VendorSO = string.Empty ; 
  		public string VendorSO 
  		{ 
  			get 
  			{ 
  				return m_VendorSO ; 
  			}  
  			set 
  			{ 
  				m_VendorSO = value ; 
  			}  
  		} 
  
  		private DateTime m_WriteDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime WriteDate 
  		{ 
  			get 
  			{ 
  				return m_WriteDate ; 
  			}  
  			set 
  			{ 
  				m_WriteDate = value ; 
  			}  
  		} 
  
  		private string m_WriteAddress = string.Empty ; 
  		public string WriteAddress 
  		{ 
  			get 
  			{ 
  				return m_WriteAddress ; 
  			}  
  			set 
  			{ 
  				m_WriteAddress = value ; 
  			}  
  		} 
  
  		private string m_Aname = string.Empty ; 
  		public string Aname 
  		{ 
  			get 
  			{ 
  				return m_Aname ; 
  			}  
  			set 
  			{ 
  				m_Aname = value ; 
  			}  
  		} 
  
  		private string m_Aaddress = string.Empty ; 
  		public string Aaddress 
  		{ 
  			get 
  			{ 
  				return m_Aaddress ; 
  			}  
  			set 
  			{ 
  				m_Aaddress = value ; 
  			}  
  		} 
  
  		private string m_Atel = string.Empty ; 
  		public string Atel 
  		{ 
  			get 
  			{ 
  				return m_Atel ; 
  			}  
  			set 
  			{ 
  				m_Atel = value ; 
  			}  
  		} 
  
  		private string m_Afax = string.Empty ; 
  		public string Afax 
  		{ 
  			get 
  			{ 
  				return m_Afax ; 
  			}  
  			set 
  			{ 
  				m_Afax = value ; 
  			}  
  		} 
  
  		private string m_Bname = string.Empty ; 
  		public string Bname 
  		{ 
  			get 
  			{ 
  				return m_Bname ; 
  			}  
  			set 
  			{ 
  				m_Bname = value ; 
  			}  
  		} 
  
  		private string m_Baddress = string.Empty ; 
  		public string Baddress 
  		{ 
  			get 
  			{ 
  				return m_Baddress ; 
  			}  
  			set 
  			{ 
  				m_Baddress = value ; 
  			}  
  		} 
  
  		private string m_Btel = string.Empty ; 
  		public string Btel 
  		{ 
  			get 
  			{ 
  				return m_Btel ; 
  			}  
  			set 
  			{ 
  				m_Btel = value ; 
  			}  
  		} 
  
  		private string m_Bfax = string.Empty ; 
  		public string Bfax 
  		{ 
  			get 
  			{ 
  				return m_Bfax ; 
  			}  
  			set 
  			{ 
  				m_Bfax = value ; 
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
  
  		private int m_CurrencyID = 0; 
  		public int CurrencyID 
  		{ 
  			get 
  			{ 
  				return m_CurrencyID ; 
  			}  
  			set 
  			{ 
  				m_CurrencyID = value ; 
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
  
  		private string m_Terms = string.Empty ; 
  		public string Terms 
  		{ 
  			get 
  			{ 
  				return m_Terms ; 
  			}  
  			set 
  			{ 
  				m_Terms = value ; 
  			}  
  		} 
  
  		private string m_TotalAmountEn = string.Empty ; 
  		public string TotalAmountEn 
  		{ 
  			get 
  			{ 
  				return m_TotalAmountEn ; 
  			}  
  			set 
  			{ 
  				m_TotalAmountEn = value ; 
  			}  
  		} 
  
  		private DateTime m_NeedDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime NeedDate 
  		{ 
  			get 
  			{ 
  				return m_NeedDate ; 
  			}  
  			set 
  			{ 
  				m_NeedDate = value ; 
  			}  
  		} 
  
  		private string m_PayMethod = string.Empty ; 
  		public string PayMethod 
  		{ 
  			get 
  			{ 
  				return m_PayMethod ; 
  			}  
  			set 
  			{ 
  				m_PayMethod = value ; 
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
            string Sql="SELECT * FROM Sale_VendorCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_VendorCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_SOID=SysConvert.ToString(MasterTable.Rows[0]["SOID"]); 
  				m_CompactNo=SysConvert.ToString(MasterTable.Rows[0]["CompactNo"]); 
  				m_VendorSO=SysConvert.ToString(MasterTable.Rows[0]["VendorSO"]); 
  				m_WriteDate=SysConvert.ToDateTime(MasterTable.Rows[0]["WriteDate"]); 
  				m_WriteAddress=SysConvert.ToString(MasterTable.Rows[0]["WriteAddress"]); 
  				m_Aname=SysConvert.ToString(MasterTable.Rows[0]["Aname"]); 
  				m_Aaddress=SysConvert.ToString(MasterTable.Rows[0]["Aaddress"]); 
  				m_Atel=SysConvert.ToString(MasterTable.Rows[0]["Atel"]); 
  				m_Afax=SysConvert.ToString(MasterTable.Rows[0]["Afax"]); 
  				m_Bname=SysConvert.ToString(MasterTable.Rows[0]["Bname"]); 
  				m_Baddress=SysConvert.ToString(MasterTable.Rows[0]["Baddress"]); 
  				m_Btel=SysConvert.ToString(MasterTable.Rows[0]["Btel"]); 
  				m_Bfax=SysConvert.ToString(MasterTable.Rows[0]["Bfax"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_CurrencyID=SysConvert.ToInt32(MasterTable.Rows[0]["CurrencyID"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_Terms=SysConvert.ToString(MasterTable.Rows[0]["Terms"]); 
  				m_TotalAmountEn=SysConvert.ToString(MasterTable.Rows[0]["TotalAmountEn"]); 
  				m_NeedDate=SysConvert.ToDateTime(MasterTable.Rows[0]["NeedDate"]); 
  				m_PayMethod=SysConvert.ToString(MasterTable.Rows[0]["PayMethod"]); 
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
