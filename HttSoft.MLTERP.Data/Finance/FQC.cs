using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_FQC实体类
	/// 作者:章文强
	/// 创建日期:2012-8-30
	/// </summary>
	public sealed class FQC : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FQC()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FQC(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_FQC";
		 
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
  
  		private int m_RecPayTypeID = 0; 
  		public int RecPayTypeID 
  		{ 
  			get 
  			{ 
  				return m_RecPayTypeID ; 
  			}  
  			set 
  			{ 
  				m_RecPayTypeID = value ; 
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
  
  		private decimal m_DNoInvoiceQty = 0; 
  		public decimal DNoInvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_DNoInvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_DNoInvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_DNoInvoiceAmount = 0; 
  		public decimal DNoInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_DNoInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_DNoInvoiceAmount = value ; 
  			}  
  		} 
  
  		private decimal m_ExAmount = 0; 
  		public decimal ExAmount 
  		{ 
  			get 
  			{ 
  				return m_ExAmount ; 
  			}  
  			set 
  			{ 
  				m_ExAmount = value ; 
  			}  
  		} 
  
  		private decimal m_InvoiceQty = 0; 
  		public decimal InvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_InvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_InvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_InvoiceAmount = 0; 
  		public decimal InvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_InvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_InvoiceAmount = value ; 
  			}  
  		} 
  
  		private int m_InvoicePayFlag = 0; 
  		public int InvoicePayFlag 
  		{ 
  			get 
  			{ 
  				return m_InvoicePayFlag ; 
  			}  
  			set 
  			{ 
  				m_InvoicePayFlag = value ; 
  			}  
  		} 
  
  		private decimal m_HXAmount = 0; 
  		public decimal HXAmount 
  		{ 
  			get 
  			{ 
  				return m_HXAmount ; 
  			}  
  			set 
  			{ 
  				m_HXAmount = value ; 
  			}  
  		} 
  
  		private int m_HXFlag = 0; 
  		public int HXFlag 
  		{ 
  			get 
  			{ 
  				return m_HXFlag ; 
  			}  
  			set 
  			{ 
  				m_HXFlag = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Finance_FQC WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_FQC WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_RecPayTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["RecPayTypeID"]); 
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_DNoInvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DNoInvoiceQty"]); 
  				m_DNoInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DNoInvoiceAmount"]); 
  				m_ExAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ExAmount"]); 
  				m_InvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InvoiceQty"]); 
  				m_InvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["InvoiceAmount"]); 
  				m_InvoicePayFlag=SysConvert.ToInt32(MasterTable.Rows[0]["InvoicePayFlag"]); 
  				m_HXAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HXAmount"]); 
  				m_HXFlag=SysConvert.ToInt32(MasterTable.Rows[0]["HXFlag"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
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
