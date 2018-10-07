using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_Shipment实体类
	/// 作者:周富春
	/// 创建日期:2011/12/7
	/// </summary>
	public sealed class Shipment : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Shipment()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Shipment(IDBTransAccess p_SqlCmd)
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
  
  		private int m_ShipTypeID = 0; 
  		public int ShipTypeID 
  		{ 
  			get 
  			{ 
  				return m_ShipTypeID ; 
  			}  
  			set 
  			{ 
  				m_ShipTypeID = value ; 
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
  
  		private string m_VendorAddress = string.Empty ; 
  		public string VendorAddress 
  		{ 
  			get 
  			{ 
  				return m_VendorAddress ; 
  			}  
  			set 
  			{ 
  				m_VendorAddress = value ; 
  			}  
  		} 
  
  		private string m_VendorTel = string.Empty ; 
  		public string VendorTel 
  		{ 
  			get 
  			{ 
  				return m_VendorTel ; 
  			}  
  			set 
  			{ 
  				m_VendorTel = value ; 
  			}  
  		} 
  
  		private string m_VendorFax = string.Empty ; 
  		public string VendorFax 
  		{ 
  			get 
  			{ 
  				return m_VendorFax ; 
  			}  
  			set 
  			{ 
  				m_VendorFax = value ; 
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
  
  		private string m_RecVendorID = string.Empty ; 
  		public string RecVendorID 
  		{ 
  			get 
  			{ 
  				return m_RecVendorID ; 
  			}  
  			set 
  			{ 
  				m_RecVendorID = value ; 
  			}  
  		} 
  
  		private string m_RecVendorAddress = string.Empty ; 
  		public string RecVendorAddress 
  		{ 
  			get 
  			{ 
  				return m_RecVendorAddress ; 
  			}  
  			set 
  			{ 
  				m_RecVendorAddress = value ; 
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
            string Sql="SELECT * FROM Sale_Shipment WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_Shipment WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ShipTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ShipTypeID"]); 
  				m_ShipDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ShipDate"]); 
  				m_VendorName=SysConvert.ToString(MasterTable.Rows[0]["VendorName"]); 
  				m_VendorAddress=SysConvert.ToString(MasterTable.Rows[0]["VendorAddress"]); 
  				m_VendorTel=SysConvert.ToString(MasterTable.Rows[0]["VendorTel"]); 
  				m_VendorFax=SysConvert.ToString(MasterTable.Rows[0]["VendorFax"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_CurrencyID=SysConvert.ToInt32(MasterTable.Rows[0]["CurrencyID"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_RecVendorID=SysConvert.ToString(MasterTable.Rows[0]["RecVendorID"]); 
  				m_RecVendorAddress=SysConvert.ToString(MasterTable.Rows[0]["RecVendorAddress"]); 
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
