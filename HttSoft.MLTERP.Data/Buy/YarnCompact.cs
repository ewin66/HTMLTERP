using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_YarnCompact实体类
	/// 作者:周富春
	/// 创建日期:2011/11/29
	/// </summary>
	public sealed class YarnCompact : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public YarnCompact()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public YarnCompact(IDBTransAccess p_SqlCmd)
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
  
  		private string m_BuyOPID = string.Empty ; 
  		public string BuyOPID 
  		{ 
  			get 
  			{ 
  				return m_BuyOPID ; 
  			}  
  			set 
  			{ 
  				m_BuyOPID = value ; 
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
  
  		private int m_ProcFlag = 0; 
  		public int ProcFlag 
  		{ 
  			get 
  			{ 
  				return m_ProcFlag ; 
  			}  
  			set 
  			{ 
  				m_ProcFlag = value ; 
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
  
  		private int m_ItemTypeID = 0; 
  		public int ItemTypeID 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID = value ; 
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
            string Sql="SELECT * FROM Buy_YarnCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_YarnCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_BuyOPID=SysConvert.ToString(MasterTable.Rows[0]["BuyOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_ProcFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ProcFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_InDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InDate"]); 
  				m_NeedDate=SysConvert.ToDateTime(MasterTable.Rows[0]["NeedDate"]); 
  				m_PayMethod=SysConvert.ToString(MasterTable.Rows[0]["PayMethod"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_ItemTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID"]); 
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
