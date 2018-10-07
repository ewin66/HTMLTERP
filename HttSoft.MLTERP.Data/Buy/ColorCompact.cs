using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_ColorCompact实体类
	/// 作者:曹小艮
	/// 创建日期:2011-12-19
	/// </summary>
	public sealed class ColorCompact : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ColorCompact()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ColorCompact(IDBTransAccess p_SqlCmd)
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
  
  		private string m_ColorSample = string.Empty ; 
  		public string ColorSample 
  		{ 
  			get 
  			{ 
  				return m_ColorSample ; 
  			}  
  			set 
  			{ 
  				m_ColorSample = value ; 
  			}  
  		} 
  
  		private string m_TestRequire = string.Empty ; 
  		public string TestRequire 
  		{ 
  			get 
  			{ 
  				return m_TestRequire ; 
  			}  
  			set 
  			{ 
  				m_TestRequire = value ; 
  			}  
  		} 
  
  		private string m_ChkColorLight = string.Empty ; 
  		public string ChkColorLight 
  		{ 
  			get 
  			{ 
  				return m_ChkColorLight ; 
  			}  
  			set 
  			{ 
  				m_ChkColorLight = value ; 
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
  
  		private string m_OthMatter = string.Empty ; 
  		public string OthMatter 
  		{ 
  			get 
  			{ 
  				return m_OthMatter ; 
  			}  
  			set 
  			{ 
  				m_OthMatter = value ; 
  			}  
  		} 
  
  		private int m_InputTypeID = 0; 
  		public int InputTypeID 
  		{ 
  			get 
  			{ 
  				return m_InputTypeID ; 
  			}  
  			set 
  			{ 
  				m_InputTypeID = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Buy_ColorCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_ColorCompact WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorOPID=SysConvert.ToString(MasterTable.Rows[0]["VendorOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_ProcFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ProcFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_InDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InDate"]); 
  				m_NeedDate=SysConvert.ToDateTime(MasterTable.Rows[0]["NeedDate"]); 
  				m_BuyOPID=SysConvert.ToString(MasterTable.Rows[0]["BuyOPID"]); 
  				m_PayMethod=SysConvert.ToString(MasterTable.Rows[0]["PayMethod"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_ColorSample=SysConvert.ToString(MasterTable.Rows[0]["ColorSample"]); 
  				m_TestRequire=SysConvert.ToString(MasterTable.Rows[0]["TestRequire"]); 
  				m_ChkColorLight=SysConvert.ToString(MasterTable.Rows[0]["ChkColorLight"]); 
  				m_Terms=SysConvert.ToString(MasterTable.Rows[0]["Terms"]); 
  				m_OthMatter=SysConvert.ToString(MasterTable.Rows[0]["OthMatter"]); 
  				m_InputTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["InputTypeID"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
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
