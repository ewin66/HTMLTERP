using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_OthCompact实体类
	/// 作者:辛明献
	/// 创建日期:2011-11-8
	/// </summary>
	public sealed class OthCompact : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OthCompact()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OthCompact(IDBTransAccess p_SqlCmd)
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
  
  		private string m_CompactDesc = string.Empty ; 
  		public string CompactDesc 
  		{ 
  			get 
  			{ 
  				return m_CompactDesc ; 
  			}  
  			set 
  			{ 
  				m_CompactDesc = value ; 
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
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
  			}  
  		} 
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
  			}  
  		} 
  
  		private string m_ColourName = string.Empty ; 
  		public string ColourName 
  		{ 
  			get 
  			{ 
  				return m_ColourName ; 
  			}  
  			set 
  			{ 
  				m_ColourName = value ; 
  			}  
  		} 
  
  		private string m_ColourNum = string.Empty ; 
  		public string ColourNum 
  		{ 
  			get 
  			{ 
  				return m_ColourNum ; 
  			}  
  			set 
  			{ 
  				m_ColourNum = value ; 
  			}  
  		} 
  
  		private string m_DesignNO = string.Empty ; 
  		public string DesignNO 
  		{ 
  			get 
  			{ 
  				return m_DesignNO ; 
  			}  
  			set 
  			{ 
  				m_DesignNO = value ; 
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
  
  		private int m_YarnYtpeID = 0; 
  		public int YarnYtpeID 
  		{ 
  			get 
  			{ 
  				return m_YarnYtpeID ; 
  			}  
  			set 
  			{ 
  				m_YarnYtpeID = value ; 
  			}  
  		} 
  
  		private string m_EditionNo = string.Empty ; 
  		public string EditionNo 
  		{ 
  			get 
  			{ 
  				return m_EditionNo ; 
  			}  
  			set 
  			{ 
  				m_EditionNo = value ; 
  			}  
  		} 
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
  			}  
  		} 
  
  		private decimal m_SinglePrice = 0; 
  		public decimal SinglePrice 
  		{ 
  			get 
  			{ 
  				return m_SinglePrice ; 
  			}  
  			set 
  			{ 
  				m_SinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
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
            string Sql="SELECT * FROM Buy_OthCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_OthCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_InDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InDate"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_BuyOPID=SysConvert.ToString(MasterTable.Rows[0]["BuyOPID"]); 
  				m_NeedDate=SysConvert.ToDateTime(MasterTable.Rows[0]["NeedDate"]); 
  				m_PayMethod=SysConvert.ToString(MasterTable.Rows[0]["PayMethod"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_ProcFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ProcFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_CompactDesc=SysConvert.ToString(MasterTable.Rows[0]["CompactDesc"]); 
  				m_SOID=SysConvert.ToString(MasterTable.Rows[0]["SOID"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ColourName=SysConvert.ToString(MasterTable.Rows[0]["ColourName"]); 
  				m_ColourNum=SysConvert.ToString(MasterTable.Rows[0]["ColourNum"]); 
  				m_DesignNO=SysConvert.ToString(MasterTable.Rows[0]["DesignNO"]); 
  				m_YarnStatus=SysConvert.ToString(MasterTable.Rows[0]["YarnStatus"]); 
  				m_YarnYtpeID=SysConvert.ToInt32(MasterTable.Rows[0]["YarnYtpeID"]); 
  				m_EditionNo=SysConvert.ToString(MasterTable.Rows[0]["EditionNo"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
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
