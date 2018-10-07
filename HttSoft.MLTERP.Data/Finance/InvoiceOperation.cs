using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_InvoiceOperation实体类
	/// 作者:qiuchao
	/// 创建日期:2015/8/15
	/// </summary>
	public sealed class InvoiceOperation : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public InvoiceOperation()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public InvoiceOperation(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_InvoiceOperation";
		 
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
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private string m_OrderCode = string.Empty ; 
  		public string OrderCode 
  		{ 
  			get 
  			{ 
  				return m_OrderCode ; 
  			}  
  			set 
  			{ 
  				m_OrderCode = value ; 
  			}  
  		} 
  
  		private string m_InvoiceNO = string.Empty ; 
  		public string InvoiceNO 
  		{ 
  			get 
  			{ 
  				return m_InvoiceNO ; 
  			}  
  			set 
  			{ 
  				m_InvoiceNO = value ; 
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
  
  		private string m_MakeOPName = string.Empty ; 
  		public string MakeOPName 
  		{ 
  			get 
  			{ 
  				return m_MakeOPName ; 
  			}  
  			set 
  			{ 
  				m_MakeOPName = value ; 
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
  
  		private string m_CheckOPID = string.Empty ; 
  		public string CheckOPID 
  		{ 
  			get 
  			{ 
  				return m_CheckOPID ; 
  			}  
  			set 
  			{ 
  				m_CheckOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_CheckDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CheckDate 
  		{ 
  			get 
  			{ 
  				return m_CheckDate ; 
  			}  
  			set 
  			{ 
  				m_CheckDate = value ; 
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
  
  		private string m_DVendorCon = string.Empty ; 
  		public string DVendorCon 
  		{ 
  			get 
  			{ 
  				return m_DVendorCon ; 
  			}  
  			set 
  			{ 
  				m_DVendorCon = value ; 
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
  
  		private int m_DZTypeID = 0; 
  		public int DZTypeID 
  		{ 
  			get 
  			{ 
  				return m_DZTypeID ; 
  			}  
  			set 
  			{ 
  				m_DZTypeID = value ; 
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
  
  		private decimal m_TotalTaxAmount = 0; 
  		public decimal TotalTaxAmount 
  		{ 
  			get 
  			{ 
  				return m_TotalTaxAmount ; 
  			}  
  			set 
  			{ 
  				m_TotalTaxAmount = value ; 
  			}  
  		} 
  
  		private decimal m_PreHXAmount = 0; 
  		public decimal PreHXAmount 
  		{ 
  			get 
  			{ 
  				return m_PreHXAmount ; 
  			}  
  			set 
  			{ 
  				m_PreHXAmount = value ; 
  			}  
  		} 
  
  		private decimal m_PreHXQty = 0; 
  		public decimal PreHXQty 
  		{ 
  			get 
  			{ 
  				return m_PreHXQty ; 
  			}  
  			set 
  			{ 
  				m_PreHXQty = value ; 
  			}  
  		} 
  
  		private int m_PreHXFlag = 0; 
  		public int PreHXFlag 
  		{ 
  			get 
  			{ 
  				return m_PreHXFlag ; 
  			}  
  			set 
  			{ 
  				m_PreHXFlag = value ; 
  			}  
  		} 
  
  		private int m_PreInvFlag = 0; 
  		public int PreInvFlag 
  		{ 
  			get 
  			{ 
  				return m_PreInvFlag ; 
  			}  
  			set 
  			{ 
  				m_PreInvFlag = value ; 
  			}  
  		} 
  
  		private int m_KPType = 0; 
  		public int KPType 
  		{ 
  			get 
  			{ 
  				return m_KPType ; 
  			}  
  			set 
  			{ 
  				m_KPType = value ; 
  			}  
  		} 
  
  		private int m_MXFlag = 0; 
  		public int MXFlag 
  		{ 
  			get 
  			{ 
  				return m_MXFlag ; 
  			}  
  			set 
  			{ 
  				m_MXFlag = value ; 
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
            string Sql="SELECT * FROM Finance_InvoiceOperation WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_InvoiceOperation WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_OrderCode=SysConvert.ToString(MasterTable.Rows[0]["OrderCode"]); 
  				m_InvoiceNO=SysConvert.ToString(MasterTable.Rows[0]["InvoiceNO"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DVendorCon=SysConvert.ToString(MasterTable.Rows[0]["DVendorCon"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_DZTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["DZTypeID"]); 
  				m_PayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PayAmount"]); 
  				m_TotalTaxAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalTaxAmount"]); 
  				m_PreHXAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PreHXAmount"]); 
  				m_PreHXQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PreHXQty"]); 
  				m_PreHXFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PreHXFlag"]); 
  				m_PreInvFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PreInvFlag"]); 
  				m_KPType=SysConvert.ToInt32(MasterTable.Rows[0]["KPType"]); 
  				m_MXFlag=SysConvert.ToInt32(MasterTable.Rows[0]["MXFlag"]); 
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
