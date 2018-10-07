using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_CheckOperation实体类
	/// 作者:xushoucheng
	/// 创建日期:2015/8/17
	/// </summary>
	public sealed class CheckOperation : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckOperation()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOperation(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_CheckOperation";
		 
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
  
  		private decimal m_TotalCheckAmount = 0; 
  		public decimal TotalCheckAmount 
  		{ 
  			get 
  			{ 
  				return m_TotalCheckAmount ; 
  			}  
  			set 
  			{ 
  				m_TotalCheckAmount = value ; 
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
  
  		private int m_CheckMethodTypeID = 0; 
  		public int CheckMethodTypeID 
  		{ 
  			get 
  			{ 
  				return m_CheckMethodTypeID ; 
  			}  
  			set 
  			{ 
  				m_CheckMethodTypeID = value ; 
  			}  
  		} 
  
  		private decimal m_PreInvoiceAmount = 0; 
  		public decimal PreInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_PreInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_PreInvoiceAmount = value ; 
  			}  
  		} 
  
  		private decimal m_PreInvoiceQty = 0; 
  		public decimal PreInvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_PreInvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_PreInvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_PreExAmount = 0; 
  		public decimal PreExAmount 
  		{ 
  			get 
  			{ 
  				return m_PreExAmount ; 
  			}  
  			set 
  			{ 
  				m_PreExAmount = value ; 
  			}  
  		} 
  
  		private decimal m_ThisInvoiceAmount = 0; 
  		public decimal ThisInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_ThisInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_ThisInvoiceAmount = value ; 
  			}  
  		} 
  
  		private decimal m_ThisInvoiceQty = 0; 
  		public decimal ThisInvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_ThisInvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_ThisInvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_ThisExAmount = 0; 
  		public decimal ThisExAmount 
  		{ 
  			get 
  			{ 
  				return m_ThisExAmount ; 
  			}  
  			set 
  			{ 
  				m_ThisExAmount = value ; 
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
  
  		private string m_InvoiceApplyNo = string.Empty ; 
  		public string InvoiceApplyNo 
  		{ 
  			get 
  			{ 
  				return m_InvoiceApplyNo ; 
  			}  
  			set 
  			{ 
  				m_InvoiceApplyNo = value ; 
  			}  
  		} 
  
  		private int m_MergeFlage = 0; 
  		public int MergeFlage 
  		{ 
  			get 
  			{ 
  				return m_MergeFlage ; 
  			}  
  			set 
  			{ 
  				m_MergeFlage = value ; 
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
            string Sql="SELECT * FROM Finance_CheckOperation WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_CheckOperation WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_TotalCheckAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalCheckAmount"]); 
  				m_DZTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["DZTypeID"]); 
  				m_CheckMethodTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CheckMethodTypeID"]); 
  				m_PreInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PreInvoiceAmount"]); 
  				m_PreInvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PreInvoiceQty"]); 
  				m_PreExAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PreExAmount"]); 
  				m_ThisInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ThisInvoiceAmount"]); 
  				m_ThisInvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["ThisInvoiceQty"]); 
  				m_ThisExAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ThisExAmount"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_InvoiceApplyNo=SysConvert.ToString(MasterTable.Rows[0]["InvoiceApplyNo"]); 
  				m_MergeFlage=SysConvert.ToInt32(MasterTable.Rows[0]["MergeFlage"]); 
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
