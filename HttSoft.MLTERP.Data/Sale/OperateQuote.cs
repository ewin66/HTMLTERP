using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_OperateQuote实体类
	/// 作者:曹小艮
	/// 创建日期:2012-3-30
	/// </summary>
	public sealed class OperateQuote : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OperateQuote()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OperateQuote(IDBTransAccess p_SqlCmd)
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
  
  		private DateTime m_QuoteDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime QuoteDate 
  		{ 
  			get 
  			{ 
  				return m_QuoteDate ; 
  			}  
  			set 
  			{ 
  				m_QuoteDate = value ; 
  			}  
  		} 
  
  		private string m_QuoteOPID = string.Empty ; 
  		public string QuoteOPID 
  		{ 
  			get 
  			{ 
  				return m_QuoteOPID ; 
  			}  
  			set 
  			{ 
  				m_QuoteOPID = value ; 
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
  
  		private int m_YarnTypeID = 0; 
  		public int YarnTypeID 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Sale_OperateQuote WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_OperateQuote WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_QuoteDate=SysConvert.ToDateTime(MasterTable.Rows[0]["QuoteDate"]); 
  				m_QuoteOPID=SysConvert.ToString(MasterTable.Rows[0]["QuoteOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_CurrencyID=SysConvert.ToInt32(MasterTable.Rows[0]["CurrencyID"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_YarnStatus=SysConvert.ToString(MasterTable.Rows[0]["YarnStatus"]); 
  				m_YarnTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["YarnTypeID"]); 
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
