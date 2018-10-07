using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_AuditPrice实体类
	/// 作者:曹小艮
	/// 创建日期:2011-12-30
	/// </summary>
	public sealed class AuditPrice : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public AuditPrice()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public AuditPrice(IDBTransAccess p_SqlCmd)
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
  
  		private string m_ProductCode = string.Empty ; 
  		public string ProductCode 
  		{ 
  			get 
  			{ 
  				return m_ProductCode ; 
  			}  
  			set 
  			{ 
  				m_ProductCode = value ; 
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
  
  		private string m_ProductName = string.Empty ; 
  		public string ProductName 
  		{ 
  			get 
  			{ 
  				return m_ProductName ; 
  			}  
  			set 
  			{ 
  				m_ProductName = value ; 
  			}  
  		} 
  
  		private string m_Equipment = string.Empty ; 
  		public string Equipment 
  		{ 
  			get 
  			{ 
  				return m_Equipment ; 
  			}  
  			set 
  			{ 
  				m_Equipment = value ; 
  			}  
  		} 
  
  		private string m_ProductGY = string.Empty ; 
  		public string ProductGY 
  		{ 
  			get 
  			{ 
  				return m_ProductGY ; 
  			}  
  			set 
  			{ 
  				m_ProductGY = value ; 
  			}  
  		} 
  
  		private string m_ProductRSGY = string.Empty ; 
  		public string ProductRSGY 
  		{ 
  			get 
  			{ 
  				return m_ProductRSGY ; 
  			}  
  			set 
  			{ 
  				m_ProductRSGY = value ; 
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
  
  		private string m_JSOPID = string.Empty ; 
  		public string JSOPID 
  		{ 
  			get 
  			{ 
  				return m_JSOPID ; 
  			}  
  			set 
  			{ 
  				m_JSOPID = value ; 
  			}  
  		} 
  
  		private string m_SHOPID = string.Empty ; 
  		public string SHOPID 
  		{ 
  			get 
  			{ 
  				return m_SHOPID ; 
  			}  
  			set 
  			{ 
  				m_SHOPID = value ; 
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
  
  		private decimal m_PPrice = 0; 
  		public decimal PPrice 
  		{ 
  			get 
  			{ 
  				return m_PPrice ; 
  			}  
  			set 
  			{ 
  				m_PPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_PDatetime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PDatetime 
  		{ 
  			get 
  			{ 
  				return m_PDatetime ; 
  			}  
  			set 
  			{ 
  				m_PDatetime = value ; 
  			}  
  		} 
  
  		private decimal m_SPrice = 0; 
  		public decimal SPrice 
  		{ 
  			get 
  			{ 
  				return m_SPrice ; 
  			}  
  			set 
  			{ 
  				m_SPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_SDatetime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SDatetime 
  		{ 
  			get 
  			{ 
  				return m_SDatetime ; 
  			}  
  			set 
  			{ 
  				m_SDatetime = value ; 
  			}  
  		} 
  
  		private decimal m_ItemAmount = 0; 
  		public decimal ItemAmount 
  		{ 
  			get 
  			{ 
  				return m_ItemAmount ; 
  			}  
  			set 
  			{ 
  				m_ItemAmount = value ; 
  			}  
  		} 
  
  		private decimal m_OthAmount = 0; 
  		public decimal OthAmount 
  		{ 
  			get 
  			{ 
  				return m_OthAmount ; 
  			}  
  			set 
  			{ 
  				m_OthAmount = value ; 
  			}  
  		} 
  
  		private decimal m_ColorAmount = 0; 
  		public decimal ColorAmount 
  		{ 
  			get 
  			{ 
  				return m_ColorAmount ; 
  			}  
  			set 
  			{ 
  				m_ColorAmount = value ; 
  			}  
  		} 
  
  		private decimal m_DTAmount = 0; 
  		public decimal DTAmount 
  		{ 
  			get 
  			{ 
  				return m_DTAmount ; 
  			}  
  			set 
  			{ 
  				m_DTAmount = value ; 
  			}  
  		} 
  
  		private decimal m_DTSHAmount = 0; 
  		public decimal DTSHAmount 
  		{ 
  			get 
  			{ 
  				return m_DTSHAmount ; 
  			}  
  			set 
  			{ 
  				m_DTSHAmount = value ; 
  			}  
  		} 
  
  		private decimal m_STPrice = 0; 
  		public decimal STPrice 
  		{ 
  			get 
  			{ 
  				return m_STPrice ; 
  			}  
  			set 
  			{ 
  				m_STPrice = value ; 
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
            string Sql="SELECT * FROM Sale_AuditPrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_AuditPrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_ProductCode=SysConvert.ToString(MasterTable.Rows[0]["ProductCode"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ProductName=SysConvert.ToString(MasterTable.Rows[0]["ProductName"]); 
  				m_Equipment=SysConvert.ToString(MasterTable.Rows[0]["Equipment"]); 
  				m_ProductGY=SysConvert.ToString(MasterTable.Rows[0]["ProductGY"]); 
  				m_ProductRSGY=SysConvert.ToString(MasterTable.Rows[0]["ProductRSGY"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_JSOPID=SysConvert.ToString(MasterTable.Rows[0]["JSOPID"]); 
  				m_SHOPID=SysConvert.ToString(MasterTable.Rows[0]["SHOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_PPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PPrice"]); 
  				m_PDatetime=SysConvert.ToDateTime(MasterTable.Rows[0]["PDatetime"]); 
  				m_SPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SPrice"]); 
  				m_SDatetime=SysConvert.ToDateTime(MasterTable.Rows[0]["SDatetime"]); 
  				m_ItemAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ItemAmount"]); 
  				m_OthAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["OthAmount"]); 
  				m_ColorAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ColorAmount"]); 
  				m_DTAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DTAmount"]); 
  				m_DTSHAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DTSHAmount"]); 
  				m_STPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["STPrice"]); 
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
